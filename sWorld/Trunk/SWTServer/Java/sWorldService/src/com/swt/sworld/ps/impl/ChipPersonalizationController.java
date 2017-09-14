/**
 * 
 */
package com.swt.sworld.ps.impl;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;

import com.google.gson.JsonObject;
import com.nhn.utilities.HibernateUtil;
import com.nhn.utilities.Utilities;
import com.swt.sworld.ams.domain.CardChipApp;
import com.swt.sworld.ams.impls.CardChipAppDAOImpl;
import com.swt.sworld.cms.domain.CardChip;
import com.swt.sworld.cms.domain.Organization;
import com.swt.sworld.cms.impls.CardChipDAOImpl;
import com.swt.sworld.cms.impls.OrganizationDAOImpl;
import com.swt.sworld.common.errors.ErrorCode;
import com.swt.sworld.common.impls.ConfigDAOImpl;
import com.swt.sworld.common.utilitis.TokenManager;
import com.swt.sworld.communication.customer.object.CardStatisticsData;
import com.swt.sworld.communication.customer.object.DataForReadCard;
import com.swt.sworld.communication.customer.object.MemberCustomerDTO;
import com.swt.sworld.communication.customer.object.MethodResultDto;
import com.swt.sworld.communication.customer.object.PersoCardCustomerDTO;
import com.swt.sworld.communication.customer.object.PersoChipFilter;
import com.swt.sworld.kms.domain.SecretKey;
import com.swt.sworld.kms.impls.SecretKeyDaoImpl;
import com.swt.sworld.ps.domain.ChipPersonalization;
import com.swt.sworld.ps.domain.Member;
import com.swt.sworld.utilites.SworldConst;

/**
 * @author Administrator
 * 
 */
public class ChipPersonalizationController implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = 2059946755689680232L;

	public static final ChipPersonalizationController Instance = new ChipPersonalizationController();

	private ChipPersonalizationDAOImpl CHIPPER = new ChipPersonalizationDAOImpl();
	private CardChipAppDAOImpl CARDCHIPAPPDAO = new CardChipAppDAOImpl();
	private MemberDAOImpl MEMDAO = new MemberDAOImpl();
	private CardChipDAOImpl CARDCHIPDAO = new CardChipDAOImpl();
	private SecretKeyDaoImpl KeyDAO = new SecretKeyDaoImpl();
	private OrganizationDAOImpl ORG = new OrganizationDAOImpl();
	private ConfigDAOImpl confObj = new ConfigDAOImpl();
	private String methodCancel = "CANCEL_PERSOES";
	private String methodLock = "LOCK_PERSOES";
	private String methodExtend = "Extend_PERSOES";

	private ChipPersonalizationController() {

	}

//	public int updateByMemberId(long memberId, String serialNumber) {
//
//		return CHIPPER.update(memberId, serialNumber);
//	}
	
	public boolean ValidatePersoCard(String serialNumber,long memberId)
	{
		ChipPersonalization chipPersoByMember = CHIPPER.getChipPersoforPersoCusMember( memberId);
		ChipPersonalization chipPersoBySerial = CHIPPER.getBySerial(serialNumber);
		return (chipPersoByMember != null && chipPersoByMember.getChipPersoId() > 0) 
				|| (chipPersoBySerial != null && chipPersoBySerial.getChipPersoId() > 0);
	}

	@SuppressWarnings("null")
	public List<ChipPersonalization> getPersoDataByOrgAndSubOrg(long orgId,
			long SubOrgId, PersoChipFilter filter) {
		List<ChipPersonalization> result = new ArrayList<ChipPersonalization>();

		List<Long> lstId = MEMDAO.getListMemberIdByOrgAndSub(orgId, SubOrgId,
				filter);
		for (Long long1 : lstId) {
			List<ChipPersonalization> temp = CHIPPER.getChipPersoByMemberId(long1);
			if (temp != null || temp.size() != 0)

				result.addAll(temp);
		}

		return result;

	}
	
	private List<MethodResultDto> updateStatusPerso(String session, List<Long> chippersoid, String resion, String method, int status)
	{
		List<MethodResultDto> result = new ArrayList<MethodResultDto>();
		String user = TokenManager.getInstance().getUserBySession(session);
		
		if(!"".equals(user))
		{
			String date = Utilities.getInstance().currentDateStrDDMMYYYY();
			for (int i = 0; i < chippersoid.size(); i++) {
				ChipPersonalization chipperson = CHIPPER.getChippersoByCardchipid(chippersoid.get(i));
				chipperson.setNotes(resion);
				chipperson.setStatus(status);
				
				chipperson.setModifiedBy(user);
				chipperson.setModifiedOn(date);
				
				CHIPPER.update(chipperson);
			
			}
		}
		else
		{
			MethodResultDto mr = new MethodResultDto("", method, false, String.valueOf(ErrorCode.CARD_ERROR));
			result.add(mr);		
		}
		
		return result;
	}
	
	private List<MethodResultDto> updateStatusCancelPerso(String session, List<Long> chippersoid, String resion, String method, int status)
	{
		List<MethodResultDto> result = new ArrayList<MethodResultDto>();
		String user = TokenManager.getInstance().getUserBySession(session);
		
		if(!"".equals(user))
		{
			
			for (int i = 0; i < chippersoid.size(); i++) {
				ChipPersonalization chipperson = CHIPPER.getChippersoByCardchipid(chippersoid.get(i));
				
				
				List<CardChipApp> lstCardApp = CARDCHIPAPPDAO.getByChipperso(chipperson.getChipPersoId());
				
				if(lstCardApp != null)
				{
					for (CardChipApp cardChipApp : lstCardApp) {
						CARDCHIPAPPDAO.delete(cardChipApp.getCardChipAppId());
					}
				}
				
				CHIPPER.deletePerso(chipperson.getChipPersoId());
			}
		}
		else
		{
			MethodResultDto mr = new MethodResultDto("", method, false, String.valueOf(ErrorCode.CARD_ERROR));
			result.add(mr);		
		}
		
		return result;
	}

	public List<MethodResultDto> cancelPerso(String ression, List<Long> chippersoid, String cancelreason) {
		return updateStatusCancelPerso(ression ,chippersoid, cancelreason, methodCancel,  SworldConst.CANCEL);
	}

	
	public List<MethodResultDto> lockPerso(String ression, List<Long> chippersoid, String lockreason) {
		return updateStatusPerso(ression ,chippersoid, lockreason, methodLock,  SworldConst.LOCK);
	}

	public List<MethodResultDto> unLockPerso(String ression, List<Long> chippersoid, String unlockreason) {
		return updateStatusPerso(ression ,chippersoid, unlockreason, methodLock,  SworldConst.NORMAL);
	}

	public List<MethodResultDto> extendPerso(List<Long> chippersoid,
			String expirationDate) {
		List<MethodResultDto> result = new ArrayList<MethodResultDto>();
		boolean kq = false;
		for (int i = 0; i < chippersoid.size(); i++) {
			long temp = CHIPPER.extendPersoByChipPersoId(chippersoid.get(i),
					expirationDate);
			String converttemp = String.valueOf(temp);
			String Detail = String.valueOf(ErrorCode.CARD_SUCCESS);
			kq = true;
			MethodResultDto mr = new MethodResultDto(converttemp, methodExtend, kq, Detail);
			result.add(mr);
		}

		return result;
	}

	public int clearCardData(String serial) {
		ChipPersonalization chipper = CHIPPER.getCardChipBySerial(serial);

		if (chipper == null) {
			return ErrorCode.FALSED;
		} else {
			CARDCHIPAPPDAO.deleteBySerial(chipper.getChipPersoId());

			return CHIPPER.ClearCardData(serial);
		}
	}

	/**
	 * format data for writing in chip card
	 * @param inObj
	 * @return
	 */
	private String formatMemberData(Member inObj){
		String format = confObj.getValueActive(SworldConst.FORMAT_CARD_DATA);
		String[] split = format.split(SworldConst.SPLITER);
		
		JsonObject jsonObj = new JsonObject();
		
		long orgid =  inObj.getOrgId();
		
		OrganizationDAOImpl orgDao = new OrganizationDAOImpl();
		Organization org = orgDao.getById(orgid);
		
		if(null != org){
			jsonObj.addProperty("OI", org.getOrgId());
			jsonObj.addProperty("ON", org.getName());
		}
		
		jsonObj.addProperty("ID", inObj.getId());
		for(String s : split){	
			if(s.equals("name")){
				jsonObj.addProperty("N", inObj.getLastName() + " " + inObj.getFirstName());
				continue;
			}
			
			if(s.equals("code")){
				jsonObj.addProperty("M", inObj.getCode());
				continue;
			}
			
			if(s.equals("cmnd")){
				jsonObj.addProperty("C", inObj.getIdentityCard());
				continue;
			}

			if(s.equals("birthday")){
				jsonObj.addProperty("B", inObj.getBirthDate());
				continue;
			}
			
			if(s.equals("position")){
				jsonObj.addProperty("P", inObj.getPosition());
				continue;
			}
			
			if(s.equals("tel")){
				jsonObj.addProperty("T",inObj.getPhoneNo());
			}
			
			if(s.equals("title")){
				jsonObj.addProperty("TI",inObj.getTitle());
			}
		
			if(s.equals("gender")){
				jsonObj.addProperty("G",inObj.getGender());
			}
			
			if(s.equals("email")){
				jsonObj.addProperty("G",inObj.getEmail());
			}

			if(s.equals("nationality")){
				jsonObj.addProperty("NA",inObj.getNationality());
			}
			if(s.equals("image")){
				jsonObj.addProperty("I",inObj.getImagePath());
			}
			if(s.equals("address")){
				jsonObj.addProperty("A",inObj.getContactAddress());
			}
			
		}
		return jsonObj.toString();
	}
	/**
	 * insert perso
	 * @param session
	 * @param memberid
	 * @param serialnumberhex
	 * @param lstAppId
	 * @return
	 */
	public int insertPersoCardChip(String session, long memberid, String serialnumberhex) {
		
		Member mem = MEMDAO.getMembeByMemberid(memberid);

		String serial = serialnumberhex;
		String expDate = "";
		if(serialnumberhex.contains("@")){
			String[] serialExp = serialnumberhex.split("@");
			serial = serialExp[0];
			expDate = serialExp[1];
		}
		
		CardChip cardchip = CARDCHIPDAO.getCardChipBySerial(serial);

		// check table in CardChip logicalStatus
		if (cardchip.getLogicalStatus() == SworldConst.CARD_HAS_MASTER_PARTNER_READED) {
			return ErrorCode.FALSED;
		} else {

			String user = TokenManager.getInstance().getUserBySession(session);
			if("".equals(user))
				return ErrorCode.FALSED; 
			
			ChipPersonalization chipper = new ChipPersonalization();
			
			chipper.setPsMemberId(mem.getId());
			
			//du lieu len quan den the
			chipper.setCardChipId(cardchip.getCardChipId());
			chipper.setSerialNumber(serial);

			//The data is writed in chip card
			chipper.setData(formatMemberData(mem));
			
			String dur = confObj.getValueActive(SworldConst.DURATION_CHIP_CARD);
			int[] duration = {0,0};
			try
			{
				duration = Utilities.getInstance().getDurationMonthYear(Integer.parseInt(dur)) ;
			}
			catch(Exception ex)
			{
				duration = Utilities.getInstance().getDurationMonthYear(12) ;
			}
		
			//hhh
			if("".equals(expDate)){
				chipper.setExpirationDate("28-" + duration[0] + "-" + duration[1]);
			}else{
				chipper.setExpirationDate(expDate);
			}
			
			
			String date =Utilities.getInstance().currentDateStrDDMMYYYY();
			chipper.setPersoDate(date);
			chipper.setCreatedBy(user);// can cu vao session nhung chua biet lam
			chipper.setCreatedOn(date);
			chipper.setModifiedBy(user);
			chipper.setModifiedOn(date);
			
			chipper.setTemp1("");
			
			chipper.setStatus((byte) SworldConst.NORMAL);
			ChipPersonalization locCheck = CHIPPER.getCardChipBySerial(chipper.getSerialNumber());

			// check table ChipPersonalization exsit serialnumber?
			if (locCheck == null) {
				locCheck = HibernateUtil.insertObject(chipper);
			}

			
			return ErrorCode.SUCCESS;
			
		}

	}

	@SuppressWarnings("unused")
	private SecretKey getSecretKeyByOrgId(long orgid) {
		// get key id
		long keyid = ORG.getSecrectKeyId(orgid);

		// select secrect key by key id
		return KeyDAO.getById(keyid);
	}

	public String getDataToUpdateCard(String serial, byte sectordata) {

		String totalString = null;
		ChipPersonalization chipper = CHIPPER.getCardChipBySerial(serial);
		if (chipper != null) {
			Member mem = MEMDAO.getMembeByMemberid(chipper.getPsMemberId());
			if (mem != null) {
				totalString = formatMemberData(mem);
			}
		}

		return totalString;
	}

//	public String getDataToPersoCard(long memberId) {
//		// get infor member by memberid
//		Member mem = MEMDAO.getMembeByMemberid(memberId);
//		return formatMemberData(mem);
//
//	}
	
	public String getDataToPersoCard(Member mem) {
		return formatMemberData(mem);

	}

	public DataForReadCard getDataToReadCard(String serial, int cardtype,
			String data) {
		DataForReadCard dataRead = new DataForReadCard();

		ChipPersonalization chipper = CHIPPER.getCardChipBySerial(serial);

		CardChip cardchip = CARDCHIPDAO.getCardChipBySerial(serial);

		if (chipper != null && chipper.getStatus() == 3
				&& cardchip.getPhysicalStatus() == 1) {
			String catchuoi[] = data.split("/");
			String chuoimem[] = catchuoi[0].split(",");
			dataRead.setMemberId(Long.parseLong(chuoimem[0]));
			dataRead.setFullName(chuoimem[1]);
			dataRead.setBirthDate(chuoimem[2]);
			dataRead.setPhoneNo(chuoimem[3]);
			dataRead.setEmail(chuoimem[4]);
			List<Long> loc = new ArrayList<Long>();
			String chuoiappid[] = catchuoi[1].split(",");
			for (int i = 0; i < chuoiappid.length; i++) {
				Long lstLong = Long.valueOf(chuoiappid[i].toString());
				loc.add(lstLong);
			}

			dataRead.setAppIds(loc);
		} else {
			dataRead = null;
		}

		return dataRead;
	}

	public List<MemberCustomerDTO> updateStatus(List<Long> chippersoId,
			byte status, String reason) {
		List<MemberCustomerDTO> lstmemberdto = new ArrayList<MemberCustomerDTO>();
		for (Long chipperid : chippersoId) {
			ChipPersonalization chip = CHIPPER
					.getPsMemberIdByChipPersoId(chipperid);
			CardChip cardchip = CARDCHIPDAO.getLogicAndPhyByCardId(chip
					.getCardChipId());
			Member mem = MEMDAO.getMembeByMemberid(chip.getPsMemberId());
			chip.setStatus(status);
			chip.setNotes(reason);
			HibernateUtil.update(chip);
			MemberCustomerDTO memdto = new MemberCustomerDTO(mem);
			PersoCardCustomerDTO persocard = new PersoCardCustomerDTO(
					chipperid, chip.getCardChipId(), chip.getSerialNumber(),
					chip.getPersoDate(), chip.getExpirationDate(),
					cardchip.getLogicalStatus(), cardchip.getPhysicalStatus(),
					chip.getNotes(), chip.getStatus());
			memdto.setPersoCard(persocard);
			lstmemberdto.add(memdto);
		}
		return lstmemberdto;
	}

	public List<CardStatisticsData> statisticCardChip(long masterid,long orgpartnerid) {
		List<CardStatisticsData> lststatistic = new ArrayList<CardStatisticsData>();

		// get broken card
		List<CardChip> lstcardbroken = CARDCHIPDAO.getCardChipByPhysical(
				SworldConst.MARKBROKEN,masterid, orgpartnerid);
		if (lstcardbroken != null) {
			CardStatisticsData data = new CardStatisticsData(
					SworldConst.MARKBROKEN, lstcardbroken.size());
			lststatistic.add(data);
		}

		// get lost card
		List<CardChip> lstcardlost = CARDCHIPDAO.getCardChipByPhysical(
				SworldConst.MARKLOST,masterid, orgpartnerid);
		if (lstcardlost != null) {
			CardStatisticsData data = new CardStatisticsData(
					SworldConst.MARKLOST, lstcardlost.size());
			lststatistic.add(data);
		}

		// get card normal
		List<CardChip> lstcardnormal = CARDCHIPDAO.getCardChipByPhysical(
				SworldConst.NORMAL,masterid, orgpartnerid);
		if (lstcardnormal != null) {
			CardStatisticsData data = new CardStatisticsData(
					SworldConst.NORMAL, lstcardnormal.size());
			lststatistic.add(data);
		}

		// get card perso or not perso
		List<CardChip> listCardIsPerso = CARDCHIPDAO.getAllCardChipByOrgPartnerId(masterid,orgpartnerid);
		
		if (listCardIsPerso != null) {
			
			int perso = 0;
			int notperso = 0;
			for (CardChip cardChip : listCardIsPerso) {
				ChipPersonalization chip = CHIPPER.getChippersoByCardchipid(cardChip.getCardChipId());
				if(chip != null)
				{
					perso += 1;
				}
				else
				{
					notperso += 1;
				}
			}
			CardStatisticsData dataperso = new CardStatisticsData(SworldConst.PERSO, perso);
			lststatistic.add(dataperso);
			CardStatisticsData datanotperso = new CardStatisticsData(SworldConst.NOT_PERSO, notperso);
			lststatistic.add(datanotperso);
		}

		return lststatistic;
	}
	
	public int updateMemberAppOfPerso(String userupdate, String serial, String lastupdateDate) {
		return CHIPPER.update(serial, lastupdateDate, userupdate);
	}
	
	public List<ChipPersonalization> getAll(long valueId)
	{
		return CHIPPER.getall(valueId);
	}
	
	public ChipPersonalization getCardByCardChipId(long cardId)
	{
		return CHIPPER.getChippersoByCardchipid(cardId);
	}
	
	public ChipPersonalization getBySerial(String serial)
	{
		return CHIPPER.getBySerial(serial);
	}
	
	public long getMemberIdBySerial(String serial)
	{
		return CHIPPER.getPersoIdByCardChipId(serial);
	}
	
	public ChipPersonalization getByMemberId(long memId)
	{
		return CHIPPER.getChipPersoforPersoCusMember(memId);
	}
	
}
