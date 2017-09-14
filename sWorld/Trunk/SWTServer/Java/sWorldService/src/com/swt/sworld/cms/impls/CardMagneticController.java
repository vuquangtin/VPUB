/**
 * 
 */
package com.swt.sworld.cms.impls;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import org.apache.commons.lang3.RandomStringUtils;

import com.swt.sworld.cms.domain.CardMagnetic;
import com.swt.sworld.cms.domain.CardType;
import com.swt.sworld.cms.domain.Organization;
import com.swt.sworld.cms.domain.SubOrganization;
import com.swt.sworld.communication.customer.object.CardMagneticFilterDto;
import com.swt.sworld.communication.customer.object.CardStatisticsData;
import com.swt.sworld.communication.customer.object.CardmagneticDTO;
import com.swt.sworld.communication.customer.object.MemberDataExcelDto;
import com.swt.sworld.communication.customer.object.PersoMagneticCardInforDTO;
import com.swt.sworld.communication.customer.object.PreGenerateData;
import com.swt.sworld.ps.domain.MagneticPersonalization;
import com.swt.sworld.ps.impl.MagneticPersonalizationDAOImpl;
import com.swt.sworld.utilites.SworldConst;

/**
 * @author Administrator
 * 
 */
public class CardMagneticController {

	public static final CardMagneticController Instance = new CardMagneticController();

	private CardMagneticDAOImpl MAGNETICDAO = new CardMagneticDAOImpl();
	private CardTypeDAOImpl TYPEDAO = new CardTypeDAOImpl();
	private OrganizationDAOImpl ORGDAO = new OrganizationDAOImpl();
	private MagneticPersonalizationDAOImpl DAO = new MagneticPersonalizationDAOImpl();
	private SubOrganizationDAOImpl suborg = new SubOrganizationDAOImpl();

	private CardMagneticController() {

	}

	public void saveListCardinfor(PersoMagneticCardInforDTO dto) {
		List<MemberDataExcelDto> lstMemExcel = dto.getListperso();

		for (MemberDataExcelDto lst : lstMemExcel) {
			String activecode = RandomStringUtils.randomAlphanumeric(10);
			String pincode = RandomStringUtils.randomNumeric(4);

			saveCardinfor(dto.getMasterid(), dto.getPartnerid(),
					dto.getMastercode(), dto.getPartnercode(), lst, activecode,
					pincode, "AES", dto.getPrefix(), dto.getSubOrgId());
		}

	}

	public PreGenerateData getPregenerateData(long master, long partner,long suborgid,
			int serial) {
		PreGenerateData pre = new PreGenerateData();

		int AlgorithmSerial = 30061989;
		String FullName = "Le Xuan Loc";
		String CompanyName = "SmartWorld";
		String PhoneNumber = "01267620716";
		List<CardMagnetic> lstMagnetic = MAGNETICDAO
				.getTotalRecordByorgidandsuborgid(master, partner);
		int total = lstMagnetic.size() + 1;
		
		Organization masterinfor= ORGDAO.getById(master);
		if(null == masterinfor)
			return null;
		
		pre.setMasterName(masterinfor.getName());
		
		Organization partnerinfor= ORGDAO.getById(partner);
		if(null == partnerinfor)
			return null;
		
		pre.setPartnerName(partnerinfor.getName());

		pre.setAlgorithmSerial(AlgorithmSerial);
		pre.setBeginNumber(total);
		pre.setFullName(FullName);
		pre.setCompanyName(CompanyName);
		pre.setPhoneNumber(PhoneNumber);
		SubOrganization sub = suborg.getSubOrgById(suborgid);
		pre.setSuborgname(sub.getNames());

		return pre;

	}

	public long saveCardinfor(long masterid, long partnerid, String mastercode,
			String partnercode, MemberDataExcelDto lst, String activecode,
			String pincode, String algorithm, String prefix, long suborgid) {

		Date persoDate = new Date();
		SimpleDateFormat dt1 = new SimpleDateFormat("dd/MM/yyyy");
		String ngay = dt1.format(persoDate);
		CardMagnetic magnetic = new CardMagnetic();
		magnetic.setOrgMasterId(masterid);
		magnetic.setOrgPartnerId(partnerid);
		magnetic.setMasterCode(mastercode);
		magnetic.setPartnerCode(partnercode);
		magnetic.setStartDate(ngay);
		magnetic.setExpireDate(lst.getExpiredTime());
		magnetic.setTrack1Data(lst.getTrackData());
		magnetic.setCompany(lst.getCompanyName());
		magnetic.setFullName(lst.getFullName());
		magnetic.setPhoneNumber(lst.getPhoneNumber());
		magnetic.setCardNumber(lst.getSerialNumber());
		magnetic.setStatus(SworldConst.DeActived);
		magnetic.setPhysicalStatus(SworldConst.Normal);
		magnetic.setTypeCrypto(algorithm);
		magnetic.setActiveCode(activecode.toUpperCase());
		magnetic.setPinCode(pincode);
		magnetic.setPrefixCard(prefix);
		magnetic.setPrintedStatus(SworldConst.NoPrinted);
		magnetic.setSubOrgId(suborgid);

		// add data into List<MagneticPersonalization>
		MAGNETICDAO.saveInforDefault(magnetic);

		return magnetic.getMagneticId();
	}

	public long saveCardinforFollowPersoMagnetic(long masterid, long partnerid,
			String mastercode, String partnercode, MemberDataExcelDto lst,
			String activecode, String pincode, String algorithm, String prefix, long suborgid) {

		Date persoDate = new Date();
		SimpleDateFormat dt1 = new SimpleDateFormat("dd/MM/yyyy");
		String ngay = dt1.format(persoDate);
		CardMagnetic magnetic = new CardMagnetic();
		magnetic.setOrgMasterId(masterid);
		magnetic.setOrgPartnerId(partnerid);
		magnetic.setMasterCode(mastercode);
		magnetic.setPartnerCode(partnercode);
		magnetic.setStartDate(ngay);
		magnetic.setExpireDate(lst.getExpiredTime());
		magnetic.setTrack1Data(lst.getTrackData());
		magnetic.setCompany(lst.getCompanyName());
		magnetic.setFullName(lst.getFullName());
		magnetic.setPhoneNumber(lst.getPhoneNumber());
		magnetic.setCardNumber(lst.getSerialNumber());
		magnetic.setStatus(SworldConst.Actived);
		magnetic.setPhysicalStatus(SworldConst.Normal);
		magnetic.setTypeCrypto(algorithm);
		magnetic.setActiveCode(activecode.toUpperCase());
		magnetic.setPinCode(pincode);
		magnetic.setPrefixCard(prefix);
		magnetic.setPrintedStatus(SworldConst.NoPrinted);
		magnetic.setSubOrgId(suborgid);

		// add data into List<MagneticPersonalization>
		MAGNETICDAO.saveInforDefault(magnetic);

		return magnetic.getMagneticId();
	}

	public long totalRecordbyMasterPartnerPrefix(long masterid, long partnerid,
			String prefix) {
		return MAGNETICDAO.totalRecord(masterid, partnerid, prefix);
	}

	public void updateLogicalStatusOfListCard(PersoMagneticCardInforDTO dto) {
		List<MemberDataExcelDto> lstMemExcel = dto.getListperso();
		for (MemberDataExcelDto lst : lstMemExcel) {
			CardMagnetic temp = MAGNETICDAO
					.getLogicAndPhysicalBySerialNumber(lst.getSerialNumber());
			temp.setStatus(dto.getLogicalstatus());

			MAGNETICDAO.UpdateCardMagnetic(temp);
		}
	}

	public void updatePhysicalStatusOfListCard(PersoMagneticCardInforDTO dto) {
		List<MemberDataExcelDto> lstMemExcel = dto.getListperso();

		for (MemberDataExcelDto lst : lstMemExcel) {
			CardMagnetic temp = MAGNETICDAO
					.getLogicAndPhysicalBySerialNumber(lst.getSerialNumber());
			temp.setPhysicalStatus(dto.getPhysicalstatus());

			MAGNETICDAO.UpdateCardMagnetic(temp);
		}
	}

	public void updateLogicalAndPhysicalStatusOfListCard(
			PersoMagneticCardInforDTO dto) {
		List<MemberDataExcelDto> lstMemExcel = dto.getListperso();

		for (MemberDataExcelDto lst : lstMemExcel) {
			CardMagnetic temp = MAGNETICDAO
					.getLogicAndPhysicalBySerialNumber(lst.getSerialNumber());
			temp.setStatus(dto.getLogicalstatus());
			temp.setPhysicalStatus(dto.getPhysicalstatus());
			MAGNETICDAO.UpdateCardMagnetic(temp);
		}
	}

	public List<CardStatisticsData> StatisticCardMagneticStatus(long orgId,
			long subOrgId, String cardType) {
		List<CardStatisticsData> lstcardstatic = new ArrayList<CardStatisticsData>();

		// logical
		int lstcancel = MAGNETICDAO.statismagnetic(orgId, subOrgId, cardType,
				"Status", SworldConst.Cancel);
		CardStatisticsData staticcancel = new CardStatisticsData(
				SworldConst.Cancel, lstcancel);
		lstcardstatic.add(staticcancel);

		int lstnomarl = MAGNETICDAO.statismagnetic(orgId, subOrgId, cardType,
				"PhysicalStatus", SworldConst.Normal);
		CardStatisticsData staticnomarl = new CardStatisticsData(
				SworldConst.Normal, lstnomarl);
		lstcardstatic.add(staticnomarl);

		int lstBroken = MAGNETICDAO.statismagnetic(orgId, subOrgId, cardType,
				"PhysicalStatus", SworldConst.Broken);
		CardStatisticsData Broken = new CardStatisticsData(SworldConst.Broken,
				lstBroken);
		lstcardstatic.add(Broken);

		int lstLost = MAGNETICDAO.statismagnetic(orgId, subOrgId, cardType,
				"PhysicalStatus", SworldConst.Lost);
		CardStatisticsData Lost = new CardStatisticsData(SworldConst.Lost,
				lstLost);
		lstcardstatic.add(Lost);

		int lstLock = MAGNETICDAO.statismagnetic(orgId, subOrgId, cardType,
				"Status", SworldConst.Lock);
		CardStatisticsData Lock = new CardStatisticsData(SworldConst.Lock,
				lstLock);
		lstcardstatic.add(Lock);

		int lstExpired = MAGNETICDAO.statismagnetic(orgId, subOrgId, cardType,
				"Status", SworldConst.Expired);
		CardStatisticsData Expired = new CardStatisticsData(SworldConst.Expired,
				lstExpired);
		lstcardstatic.add(Expired);

		// physical
		int lstPrinted = MAGNETICDAO.statismagnetic(orgId, subOrgId, cardType,
				"PrintedStatus", SworldConst.Printed);
		CardStatisticsData Printed = new CardStatisticsData(SworldConst.Printed,
				lstPrinted);
		lstcardstatic.add(Printed);

		int lstNoPrinted = MAGNETICDAO.statismagnetic(orgId, subOrgId,
				cardType, "PrintedStatus", SworldConst.NoPrinted);
		CardStatisticsData NoPrinted = new CardStatisticsData(
				SworldConst.NoPrinted, lstNoPrinted);
		lstcardstatic.add(NoPrinted);

		int lstActived = MAGNETICDAO.statismagnetic(orgId, subOrgId, cardType,
				"Status", SworldConst.Actived);
		CardStatisticsData Actived = new CardStatisticsData(SworldConst.Actived,
				lstActived);
		lstcardstatic.add(Actived);

		int lstDeActived = MAGNETICDAO.statismagnetic(orgId, subOrgId,
				cardType, "Status", SworldConst.DeActived);
		CardStatisticsData DeActived = new CardStatisticsData(
				SworldConst.DeActived, lstDeActived);
		lstcardstatic.add(DeActived);

		return lstcardstatic;
	}

	public List<CardmagneticDTO> getAllByFilterCardMagnetic(long orgid,
			long partnerid, CardMagneticFilterDto filter) {
		List<CardmagneticDTO> lstcardmagneticdto = new ArrayList<CardmagneticDTO>();
		
		List<CardMagnetic> lstcardmagnetic = MAGNETICDAO.getall(orgid,partnerid, filter);
		Organization org = ORGDAO.getById(orgid);
		Organization suborg = null;
		
		suborg = ORGDAO.getById(partnerid);
		for (CardMagnetic cardMagnetic : lstcardmagnetic) {
			CardmagneticDTO dto = new CardmagneticDTO();
			if (cardMagnetic == null) {
				continue;
			} else {

				dto.setOrgPartnerId(partnerid);
				if(suborg == null) 
				{
					dto.setSubOrgName("");
					dto.setPartnerCode("");
				}
				else
				{
					dto.setSubOrgName(suborg.getName());
					dto.setPartnerCode(suborg.getOrgCode());
				}
				
				
				dto.setOrgMasterId(orgid);
				
				dto.setMasterCode(org.getOrgCode());
				
				dto.setOrgName(org.getName());
				
				dto.setMagneticId(cardMagnetic.getMagneticId());
				dto.setFullName(cardMagnetic.getFullName());
				dto.setCompany(cardMagnetic.getCompany());
				dto.setPhoneNumber(cardMagnetic.getPhoneNumber());
				dto.setTrackData(cardMagnetic.getTrackData());
				dto.setSerialCard(cardMagnetic.getCardNumber());
				dto.setPinCode(cardMagnetic.getPinCode());
				dto.setActiveCode(cardMagnetic.getActiveCode());
				dto.setTypeCrypto(cardMagnetic.getTypeCrypto());
				dto.setStartDate(cardMagnetic.getStartDate());
				dto.setExpireDate(cardMagnetic.getExpireDate());
				dto.setStatus(cardMagnetic.getStatus());
				dto.setPrintStatus(cardMagnetic.getPrintedStatus());
				dto.setPhysicalStatus(cardMagnetic.getPhysicalStatus());
				CardType ct = TYPEDAO.getbyprefix(cardMagnetic.getPrefixCard());
				if(ct == null)
				{
					dto.setCardtypes("UNKNOW");
				}
				else
				{
					dto.setCardtypes(ct.getCardTypeName());
				}
				dto.setNotes(cardMagnetic.getNotes());

				lstcardmagneticdto.add(dto);

			}

		}
		return lstcardmagneticdto;
	}

	@SuppressWarnings("unused")
	public List<CardmagneticDTO> getChangeStatusCardMagnetic(int status,
			String reason, List<Long> cardid) {
		List<CardmagneticDTO> lstcarddto = new ArrayList<CardmagneticDTO>();
		
		for (Long idcard : cardid) {
			CardmagneticDTO dto = new CardmagneticDTO();
			if (status == SworldConst.Actived || status == SworldConst.DeActived
					|| status == SworldConst.Lock || status == SworldConst.Cancel
					|| status == SworldConst.Expired) {
				
				
				MAGNETICDAO.UpdateStatus(idcard, status, reason, "Status");
				MagneticPersonalization perso = DAO.getByFilter(idcard);
				DAO.updateStatus(perso.getMagneticPersId(), status, reason,"Status");
				CardMagnetic card = MAGNETICDAO.getLogicAndPhyByCardId(idcard);
				
				Organization org = ORGDAO.getById(card.getOrgMasterId());
				Organization suborg = ORGDAO.getById(card.getOrgPartnerId());
				
				if(null == org || null == suborg)
					continue;
				
				dto.setOrgMasterId(card.getOrgMasterId());
				dto.setOrgPartnerId(card.getOrgPartnerId());
				dto.setMasterCode(card.getMasterCode());
				dto.setPartnerCode(card.getPartnerCode());
				dto.setOrgName(org.getName());
				dto.setSubOrgName(suborg.getName());
				dto.setMagneticId(card.getMagneticId());
				if(perso == null)
				{
					dto.setFullName(card.getFullName());
				}
				else
				{
					dto.setFullName(perso.getFullName());
				}
				dto.setCompany(card.getCompany());
				dto.setPhoneNumber(card.getPhoneNumber());
				dto.setTrackData(card.getTrackData());
				dto.setSerialCard(card.getCardNumber());
				dto.setPinCode(card.getPinCode());
				dto.setActiveCode(card.getActiveCode());
				dto.setTypeCrypto(card.getTypeCrypto());
				dto.setStartDate(card.getStartDate());
				dto.setExpireDate(card.getExpireDate());
				dto.setStatus(card.getStatus());
				dto.setPrintStatus(card.getPrintedStatus());
				dto.setPhysicalStatus(card.getPhysicalStatus());
				CardType ct = TYPEDAO.getbyprefix(card.getPrefixCard());
				if(ct == null)
				{
					dto.setCardtypes("UNKNOW");
				}
				else
				{
					dto.setCardtypes(ct.getCardTypeName());
				}
				dto.setNotes(card.getNotes());
				
				lstcarddto.add(dto);
			} 
			if(status == SworldConst.Printed || status == SworldConst.NoPrinted)
			{
				MAGNETICDAO.UpdateStatus(idcard, status, reason, "PrintedStatus");
				MagneticPersonalization perso = DAO.getByFilter(idcard);
				CardMagnetic card = MAGNETICDAO.getLogicAndPhyByCardId(idcard);
				Organization org = ORGDAO.getById(card.getOrgMasterId());
				Organization suborg = ORGDAO.getById(card.getOrgPartnerId());
				
				if(null == org || null == suborg)
					continue;
				
				dto.setOrgMasterId(card.getOrgMasterId());
				dto.setOrgPartnerId(card.getOrgPartnerId());
				dto.setMasterCode(card.getMasterCode());
				dto.setPartnerCode(card.getPartnerCode());
				dto.setOrgName(org.getName());
				dto.setSubOrgName(suborg.getName());
				dto.setMagneticId(card.getMagneticId());
				if(perso == null)
				{
					dto.setFullName(card.getFullName());
				}
				else
				{
					dto.setFullName(perso.getFullName());
				}
				dto.setCompany(card.getCompany());
				dto.setPhoneNumber(card.getPhoneNumber());
				dto.setTrackData(card.getTrackData());
				dto.setPinCode(card.getPinCode());
				dto.setActiveCode(card.getActiveCode());
				dto.setTypeCrypto(card.getTypeCrypto());
				dto.setStartDate(card.getStartDate());
				dto.setExpireDate(card.getExpireDate());
				dto.setStatus(card.getStatus());
				dto.setPrintStatus(card.getPrintedStatus());
				dto.setPhysicalStatus(card.getPhysicalStatus());
				CardType ct = TYPEDAO.getbyprefix(card.getPrefixCard());
				if(ct == null)
				{
					dto.setCardtypes("UNKNOW");
				}
				else
				{
					dto.setCardtypes(ct.getCardTypeName());
				}
				dto.setNotes(card.getNotes());
				
				lstcarddto.add(dto);
			}
			
			if(status == SworldConst.Normal || status == SworldConst.Broken || status == SworldConst.Lost)
			{
				MAGNETICDAO.UpdateStatus(idcard, status, reason, "PhysicalStatus");
				MagneticPersonalization perso = DAO.getByFilter(idcard);
				CardMagnetic card = MAGNETICDAO.getLogicAndPhyByCardId(idcard);
				Organization org = ORGDAO.getById(card.getOrgMasterId());
				Organization suborg = ORGDAO.getById(card.getOrgPartnerId());
				
				if(null == org || null == suborg)
					continue;
				
				dto.setOrgMasterId(card.getOrgMasterId());
				dto.setOrgPartnerId(card.getOrgPartnerId());
				dto.setMasterCode(card.getMasterCode());
				dto.setPartnerCode(card.getPartnerCode());
				dto.setOrgName(org.getName());
				dto.setSubOrgName(suborg.getName());
				dto.setMagneticId(card.getMagneticId());
				if(perso == null)
				{
					dto.setFullName(card.getFullName());
				}
				else
				{
					dto.setFullName(perso.getFullName());
				}
				dto.setCompany(card.getCompany());
				dto.setPhoneNumber(card.getPhoneNumber());
				dto.setTrackData(card.getTrackData());
				dto.setPinCode(card.getPinCode());
				dto.setActiveCode(card.getActiveCode());
				dto.setTypeCrypto(card.getTypeCrypto());
				dto.setStartDate(card.getStartDate());
				dto.setExpireDate(card.getExpireDate());
				dto.setStatus(card.getStatus());
				dto.setPrintStatus(card.getPrintedStatus());
				dto.setPhysicalStatus(card.getPhysicalStatus());
				CardType ct = TYPEDAO.getbyprefix(card.getPrefixCard());
				if(ct == null)
				{
					dto.setCardtypes("UNKNOW");
				}
				else
				{
					dto.setCardtypes(ct.getCardTypeName());
				}
				dto.setNotes(card.getNotes());
				
				lstcarddto.add(dto);
			}
		}

		return lstcarddto;
	}
	
	public List<CardMagnetic> getAllCardMagnetic()
	{
		return MAGNETICDAO.getALLCardMagnetic();
	}
	
	public List<CardMagnetic> getCardBypartnerId(long masterId, long partnerId)
	{
		return MAGNETICDAO.getCardMagneticByPartnerId(masterId, partnerId);
	}
	
	public List<CardMagnetic> getCardByMasterAndPartnerId(long masterId, long partnerId)
	{
		return MAGNETICDAO.getCardMagneticByMasterPartnerId(masterId, partnerId);
	}

	public CardMagnetic getCardMagneticBySerial(String serialCard) {
		return MAGNETICDAO.getCardBySerial(serialCard);
	}
}
