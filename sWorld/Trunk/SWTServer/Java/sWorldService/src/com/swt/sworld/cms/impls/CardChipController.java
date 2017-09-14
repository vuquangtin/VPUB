/**
 * 
 */
package com.swt.sworld.cms.impls;

import java.util.ArrayList;
import java.util.List;

import com.nhn.utilities.Utilities;
import com.swt.sworld.cms.domain.CardChip;
import com.swt.sworld.common.errors.ErrorCode;
import com.swt.sworld.common.utilitis.TokenManager;

import com.swt.sworld.communication.customer.object.CardChipDto;
import com.swt.sworld.communication.customer.object.CardFilterDto;
import com.swt.sworld.communication.customer.object.MethodResultDto;
import com.swt.sworld.ps.domain.ChipPersonalization;
import com.swt.sworld.ps.impl.ChipPersonalizationDAOImpl;
import com.swt.sworld.utilites.SworldConst;

/**
 * @author Administrator
 * 
 */
public class CardChipController {

	public static final CardChipController Instance = new CardChipController();

	private CardChipDAOImpl CARDCDAO = new CardChipDAOImpl();
	private ChipPersonalizationDAOImpl CHIPPER = new ChipPersonalizationDAOImpl();
	private String methodBroken = "MARK_BROKEN_CARDCHIP";
	private String methodUnBroken = "UNMARK_BROKEN_CARDCHIP";
	private String methodLost = "MARK_LOST_CARDCHIP";
	private String methodUnLost = "UNMARK_LOST_CARDCHIP";

	private CardChipController() {

	}

	public long getCardChipIdBySerial(String serial) {

		return CARDCDAO.getCardChipIdBySerialNumber(serial) ;
	}

	public CardChip getCardChipBySerial(String serialnumberhex) {
		return CARDCDAO.getCardChipBySerial(serialnumberhex);
	}

	public long insertCardChipWithRSA(String session, long orgMasterId,
			String orgcode, String serialhex, String licensemaster,
			int cardtype, int status) {

		CardChip card = new CardChip();

		String user = TokenManager.getInstance().getUserBySession(session);

		if (!"".equals(user)) {

			String date = Utilities.getInstance().currentDateStrDDMMYYYY();

			card.setOrgMasterId(orgMasterId);
			card.setOrgPartnerId(0);
			card.setSerialNumberHex(serialhex);
			card.setLicensemaster(licensemaster);
			card.setTypeCard(cardtype);
			card.setTypeCrypto("RSA");
			card.setCreatedBy(user);
			card.setCreatedOn(date);

			card.setModifyBy(user);
			card.setModifyOn(date);

			card.setOrgMasterCode(orgcode);
			card.setLogicalStatus(status);

			return CARDCDAO.insertCardChip(card);
		}

		return -1;
	}

	public int updateCardChip(CardChip card) {
		return CARDCDAO.updateCardChip(card);
	}
	
	public int deleteCardChip(String serialnumberhex){
		CardChip card = new CardChip();
		card = getCardChipBySerial(serialnumberhex);
		if(card == null)
			return ErrorCode.CARD_ERROR;
		
		return CARDCDAO.deleteCardChip(card);
	}

	public int updateCardChipStatus(String session, long orgMasterId, long partnerId,
			String serialhex, int cardtype, int status) {

		CardChip card = CARDCDAO.getCardChipBySerialCardType(orgMasterId,
				serialhex, cardtype);

		int result = -1;
		String user = TokenManager.getInstance().getUserBySession(session);
		if (!"".equals(user)) {
			card.setModifyBy(user);
			card.setModifyOn(Utilities.getInstance().currentDateStrDDMMYYYY());
			card.setLogicalStatus(status);
			card.setOrgPartnerId(partnerId);
			result = CARDCDAO.updateCardChip(card);
		}

		return result;

	}

	public int updateCardChipStatusByPartnerId(String session, long partnerid,
			String serial, int cardtype, int status) {
		CardChip card = CARDCDAO.getCardChipBySerialCardType(serial, cardtype);

		int result = -1;
		String user = TokenManager.getInstance().getUserBySession(session);
		if (!"".equals(user)) {
			card.setModifyBy(user);
			card.setModifyOn(Utilities.getInstance().currentDateStrDDMMYYYY());
			card.setLogicalStatus(status);
			result = CARDCDAO.updateCardChip(card);
		}

		return result;

	}

	private CardChip updatePhysicalStatus(String session, String user,
			long cardid, int status) {
		CardChip card = null;

		card = CARDCDAO.getCardChipById(cardid);
		card.setModifyBy(user);
		card.setModifyOn(Utilities.getInstance().currentDateStrDDMMYYYY());
		card.setPhysicalStatus(status);

		long isOkie = CARDCDAO.updateCardChip(card);

		return isOkie == ErrorCode.SUCCESS ? card : null;
	}

	private List<MethodResultDto> updateListPhysicalStatus(String session, List<Long> cardchipid, String method, int status)
	{
		List<MethodResultDto> result = new ArrayList<MethodResultDto>();

		String user = TokenManager.getInstance().getUserBySession(session);
		if (!"".equals(user)) {
			for (int i = 0; i < cardchipid.size(); i++) {

				CardChip card = updatePhysicalStatus(session, user, cardchipid.get(i), status);

				String converttemp = "";
				boolean kq = false;
				String code = String.valueOf(ErrorCode.CARD_ERROR);
				if (card != null) {
					converttemp = String.valueOf(card.getCardChipId());
					code = String.valueOf(ErrorCode.CARD_SUCCESS);
					kq= true;
				}
				MethodResultDto mr = new MethodResultDto(converttemp, method, kq, code);
				
				result.add(mr);
			}
		}

		return result;
	}
	public List<MethodResultDto> markBrokenCard(String session, List<Long> cardchipid) {
		
		return updateListPhysicalStatus(session, cardchipid, methodBroken, SworldConst.MARKBROKEN);
	}

	public List<MethodResultDto> unMarkBrokenCard(String session, List<Long> cardchipid) {
		return updateListPhysicalStatus(session, cardchipid, methodUnBroken, SworldConst.NORMAL);
	}

	public List<MethodResultDto> markLostCard(String session, List<Long> cardchipid) {
		return updateListPhysicalStatus(session, cardchipid, methodLost, SworldConst.MARKLOST);
	}

	public List<MethodResultDto> unMarkLostCard(String session, List<Long> cardchipid) {
		return updateListPhysicalStatus(session, cardchipid, methodUnLost, SworldConst.NORMAL);
	}

	public List<CardChipDto> getAllCardChip(long orgid, long suborgid,
			CardFilterDto filter) {
		List<CardChipDto> lstcarddto = new ArrayList<CardChipDto>();
		List<CardChip> lstcardchipid = CARDCDAO.getAll(orgid, suborgid, filter);
		for (CardChip cardChip : lstcardchipid) {
			ChipPersonalization chipper = CHIPPER.getChippersoByCardchipid(cardChip.getCardChipId());
			if (chipper == null) {
				CardChipDto carddto = new CardChipDto();
				carddto.setCardChipId(cardChip.getCardChipId());
				carddto.setOrgMasterId(cardChip.getOrgMasterId());
				carddto.setOrgPartnerId(cardChip.getOrgPartnerId());
				carddto.setSerialNumberHex(cardChip.getSerialNumberHex());
				carddto.setTypeCard(cardChip.getTypeCard());
				carddto.setTypeCrypto(cardChip.getTypeCrypto());
				carddto.setLogicalStatus(cardChip.getLogicalStatus());
				carddto.setPhysicalStatus(cardChip.getPhysicalStatus());
				carddto.setPersonalized(false);
				carddto.setCreateOn(cardChip.getCreatedOn());

				lstcarddto.add(carddto);
			} else {
				CardChipDto carddto = new CardChipDto();
				carddto.setCardChipId(cardChip.getCardChipId());
				carddto.setOrgMasterId(cardChip.getOrgMasterId());
				carddto.setOrgPartnerId(cardChip.getOrgPartnerId());
				carddto.setSerialNumberHex(cardChip.getSerialNumberHex());
				carddto.setTypeCard(cardChip.getTypeCard());
				carddto.setTypeCrypto(cardChip.getTypeCrypto());
				carddto.setLogicalStatus(cardChip.getLogicalStatus());
				carddto.setPhysicalStatus(cardChip.getPhysicalStatus());
				carddto.setPersonalized(true);
				carddto.setCreateOn(cardChip.getCreatedOn());

				lstcarddto.add(carddto);
			}
		}

		return lstcarddto;
	}
	
	public List<CardChip> getCardChipByPartnerId(long masterId, long partnerId)
	{
		return CARDCDAO.getCardChipByPartnerId(masterId, partnerId);
	}
	
	public List<CardChip> getCardChipByMasterId(long masterId)
	{
		return CARDCDAO.getCardChipByMasterId(masterId);
	}
	
	public List<CardChip> getAllCardChipByOrgMasterPartnerId(long masterId, long partnerId)
	{
		return CARDCDAO.getAllCardChipByOrgPartnerId(masterId, partnerId);
	}

	public CardChip getCardChip(long CardChipId)
	{
		return CARDCDAO.getCardChipById(CardChipId);
	}
	
	public CardChip getBySerialNumber(String serial)
	{
		return CARDCDAO.getCardChipBySerial(serial);
	}
	public List<CardChip> getCardChipListExport(){
		return CARDCDAO.getCardChipListExport();
	}
	public List<CardChip> getCardChipListByOrg(long orgId){
		return CARDCDAO.getCardChipListByOrg(orgId);
	}
	public int importCardFromExcel(String userName,List<CardChip> lstCard){
		int count = 0;
		String date = Utilities.getInstance().currentDateStrDDMMYYYY();
		if(lstCard != null){
			for (CardChip cardChip : lstCard) {
				cardChip.setCreatedOn(date);
				cardChip.setModifyOn(date);
				cardChip.setCreatedBy(userName);
				cardChip.setModifyBy(userName);
				cardChip.setLogicalStatus(101);
				try {
					CARDCDAO.insertCardChip(cardChip);
				} catch (Exception e) {
					count++;
				}
			}
		}
		return count;
	}
}
