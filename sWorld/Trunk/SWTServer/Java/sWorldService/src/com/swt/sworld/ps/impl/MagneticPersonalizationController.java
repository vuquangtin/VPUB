/**
 * 
 */
package com.swt.sworld.ps.impl;

import java.io.Serializable;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import org.apache.commons.lang3.RandomStringUtils;

import com.swt.sworld.cms.domain.CardMagnetic;
import com.swt.sworld.cms.domain.CardType;
import com.swt.sworld.cms.domain.Organization;
import com.swt.sworld.cms.domain.SubOrganization;
import com.swt.sworld.cms.impls.CardMagneticController;
import com.swt.sworld.cms.impls.CardMagneticDAOImpl;
import com.swt.sworld.cms.impls.CardTypeDAOImpl;
import com.swt.sworld.cms.impls.OrganizationDAOImpl;
import com.swt.sworld.cms.impls.SubOrganizationDAOImpl;
import com.swt.sworld.common.errors.ErrorCode;
import com.swt.sworld.communication.customer.object.CardMagneticFilterDto;
import com.swt.sworld.communication.customer.object.MagneticPersData;
import com.swt.sworld.communication.customer.object.MagneticPersonalizationDTO;
import com.swt.sworld.communication.customer.object.MemberDataExcelDto;
import com.swt.sworld.communication.customer.object.PersoMagneticCardInforDTO;
import com.swt.sworld.ps.domain.MagneticPersonalization;
import com.swt.sworld.utilites.SworldConst;

/**
 * @author Administrator
 * 
 */
public class MagneticPersonalizationController implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = 7322665807307582622L;

	public static final MagneticPersonalizationController Instance = new MagneticPersonalizationController();

	private MagneticPersonalizationDAOImpl MADAO = new MagneticPersonalizationDAOImpl();
	private CardMagneticDAOImpl CARDMAGNETICDAO = new CardMagneticDAOImpl();
	private OrganizationDAOImpl ORGDAO = new OrganizationDAOImpl();
	private CardTypeDAOImpl CARDTYPEDAO = new CardTypeDAOImpl();
	private SubOrganizationDAOImpl SUBORG = new SubOrganizationDAOImpl();

	private MagneticPersonalizationController() {

	}

	public int presoCardMagnetic(List<MagneticPersData> lstMagneticPerData) {
		int kq = 0;
		MagneticPersonalization maperso = new MagneticPersonalization();
		for (MagneticPersData magneticPersData : lstMagneticPerData) {

			maperso.setFullName(magneticPersData.getFullName());
			maperso.setCompayName(magneticPersData.getCompanyName());
			maperso.setPhoneNumber(magneticPersData.getPhoneNumber());
			maperso.setExpirationDate(magneticPersData.getExpiredTime());
			maperso.setSerialCard(magneticPersData.getSerialNumber());
			maperso.setTrackData(magneticPersData.getTrackOneData());

			kq = MADAO.presoCardMagnetic(maperso);
		}

		return kq;
	}

	public int saveListCardinforNoDefault(PersoMagneticCardInforDTO dto) {
		MagneticPersonalization magneticPerso = new MagneticPersonalization();
		List<MemberDataExcelDto> lstMemExcel = dto.getListperso();
		int kq = ErrorCode.FALSED;
		for (MemberDataExcelDto lst : lstMemExcel) {
			String activecode = RandomStringUtils.randomAlphanumeric(10);
			String pincode = RandomStringUtils.randomNumeric(4);
			Date date= new Date();
			SimpleDateFormat dt1 = new SimpleDateFormat("dd/MM/yyyy");
			long magneticId = -99;
			try {
				if(lst.getExpiredTime() != dt1.parse(lst.getExpiredTime()).toString()) 
				{
					magneticId = CardMagneticController.Instance.saveCardinforFollowPersoMagnetic(
							dto.getMasterid(), dto.getPartnerid(), dto.getMastercode(),
							dto.getPartnercode(), lst, activecode, pincode, "AES", dto.getPrefix(), dto.getSubOrgId());
					kq = ErrorCode.SUCCESS;
				}
			} catch (ParseException e) {
				// TODO Auto-generated catch block
				System.out.println("Could not insert!");
				kq = ErrorCode.FALSED;
				break;
				
			}
			
			
			
			//get date now
			
			String ngay = dt1.format(date);
			magneticPerso.setActiveCodeNew(activecode.toUpperCase());
			
			//TODO: step1: implemnet insert member to partner and return id member
			// step2: insert card with id member.
			magneticPerso.setMemberId(0);
			magneticPerso.setCardMagneticId(magneticId);
			magneticPerso.setSerialCard(lst.getSerialNumber());
			magneticPerso.setPersoDate(ngay);
			magneticPerso.setExpirationDate(lst.getExpiredTime());
			magneticPerso.setTrackData(lst.getTrackData());
			magneticPerso.setCompayName(lst.getCompanyName());
			magneticPerso.setFullName(lst.getFullName());
			magneticPerso.setPhoneNumber(lst.getPhoneNumber());
			magneticPerso.setPinCodeNew(pincode);
			magneticPerso.setStatus(SworldConst.Actived);
			magneticPerso.setPreFix(dto.getPrefix());
			

			// add data into List<MagneticPersonalization>
			
			try {
				if(lst.getExpiredTime() != dt1.parse(lst.getExpiredTime()).toString()) 
				{
					MADAO.saveinfo(magneticPerso);
					kq = ErrorCode.SUCCESS;
				}
			} catch (ParseException e) {
				// TODO Auto-generated catch block
				System.out.println("Could not insert!");
				kq = ErrorCode.FALSED;
			}
		}
		
		return kq;

	}
	
	public List<MagneticPersonalizationDTO> getMemberPersoMagnetic(long partner, long suborgid, CardMagneticFilterDto filter)
	{
		List<MagneticPersonalizationDTO> listperso = new ArrayList<MagneticPersonalizationDTO>();
		
		List<Long> cardmagneticid = null;
		if(suborgid < 0)
		{
			cardmagneticid = CARDMAGNETICDAO.getCardMagneticIdByMasterId(partner);
		}
		else
		{
			cardmagneticid = CARDMAGNETICDAO.getCardMagneticIdByMasterIdAndPartnerId(partner, suborgid);
		}
		if(cardmagneticid == null)
		{
			return listperso;
		}
		else
		{
			Organization org= ORGDAO.getById(partner);
			if(suborgid > 0)
			{
			SubOrganization sub = SUBORG.getSubOrgById(suborgid);
			
			
			for (Long long1 : cardmagneticid) {
				MagneticPersonalization magneticperso = MADAO.getMagneticPersoByCardMagneticId(long1, filter);
				CardMagnetic cardma = CARDMAGNETICDAO.getLogicAndPhyByCardId(long1);
				if(magneticperso == null)
				{
					continue;
				}
				else
				{
					MagneticPersonalizationDTO magneticdto = new MagneticPersonalizationDTO();
					magneticdto.setOrgMasterId(cardma.getOrgMasterId());
					magneticdto.setOrgPartnerId(cardma.getOrgPartnerId());
					magneticdto.setMasterCode(org.getOrgCode());
					magneticdto.setPartnerCode(org.getOrgCode());
					magneticdto.setOrgName(org.getName());
					magneticdto.setSubOrgName(sub.getNames());
					magneticdto.setMagneticPersId(magneticperso.getMagneticPersId());
					magneticdto.setCardMagneticId(magneticperso.getCardMagneticId());
					magneticdto.setMemberId(magneticperso.getMemberId());
					magneticdto.setFullName(magneticperso.getFullName());
					magneticdto.setCompayName(magneticperso.getCompayName());
					magneticdto.setPhoneNumber(magneticperso.getPhoneNumber());
					magneticdto.setSerialCard(magneticperso.getSerialCard());
					magneticdto.setTrackData(magneticperso.getTrackData());
					magneticdto.setPinCodeNew(magneticperso.getPinCodeNew());
					magneticdto.setActiveCodeNew(magneticperso.getActiveCodeNew());
					magneticdto.setPersoDate(magneticperso.getPersoDate());
					magneticdto.setExpirationDate(magneticperso.getExpirationDate());
					magneticdto.setStatus(magneticperso.getStatus());
					magneticdto.setNotes(magneticperso.getNotes());
					CardType ct = CARDTYPEDAO.getbyprefix(magneticperso.getPreFix());
					if(ct == null)
					{
						magneticdto.setCardtypes("UNKNOW");
					}
					else
					{
						magneticdto.setCardtypes(ct.getCardTypeName());
					}
					
					
					listperso.add(magneticdto);
				}
			}
			}
			else
			{
				for (Long long1 : cardmagneticid) {
					MagneticPersonalization magneticperso = MADAO.getMagneticPersoByCardMagneticId(long1, filter);
					CardMagnetic cardma = CARDMAGNETICDAO.getLogicAndPhyByCardId(long1);
					if(magneticperso == null)
					{
						continue;
					}
					else
					{
						MagneticPersonalizationDTO magneticdto = new MagneticPersonalizationDTO();
						magneticdto.setOrgMasterId(cardma.getOrgMasterId());
						magneticdto.setOrgPartnerId(partner);
						magneticdto.setMasterCode(org.getOrgCode());
						magneticdto.setPartnerCode("0");
						magneticdto.setOrgName(org.getName());
						magneticdto.setSubOrgName(null);
						magneticdto.setMagneticPersId(magneticperso.getMagneticPersId());
						magneticdto.setCardMagneticId(magneticperso.getCardMagneticId());
						magneticdto.setMemberId(magneticperso.getMemberId());
						magneticdto.setFullName(magneticperso.getFullName());
						magneticdto.setCompayName(magneticperso.getCompayName());
						magneticdto.setPhoneNumber(magneticperso.getPhoneNumber());
						magneticdto.setSerialCard(magneticperso.getSerialCard());
						magneticdto.setTrackData(magneticperso.getTrackData());
						magneticdto.setPinCodeNew(magneticperso.getPinCodeNew());
						magneticdto.setActiveCodeNew(magneticperso.getActiveCodeNew());
						magneticdto.setPersoDate(magneticperso.getPersoDate());
						magneticdto.setExpirationDate(magneticperso.getExpirationDate());
						magneticdto.setStatus(magneticperso.getStatus());
						magneticdto.setNotes(magneticperso.getNotes());
						CardType ct = CARDTYPEDAO.getbyprefix(magneticperso.getPreFix());
						if(ct == null)
						{
							magneticdto.setCardtypes("UNKNOW");
						}
						else
						{
							magneticdto.setCardtypes(ct.getCardTypeName());
						}
						
						listperso.add(magneticdto);
						
					}
				}
				
			}
			
		}
		return listperso;
		
	}
	
	public List<MagneticPersonalization> getChangeStatusMagnetic(int status, String reason, List<Long> persoid)
	{
		List<MagneticPersonalization> lstmagneticperso = new ArrayList<MagneticPersonalization>();
		
		for (Long idperso : persoid) {
			
			if(status == SworldConst.Actived || status == SworldConst.DeActived || status == SworldConst.Lock 
				|| status == SworldConst.Cancel || status == SworldConst.Expired)
			{
				 MADAO.updateStatus(idperso, status, reason, "Status");
				 MagneticPersonalization ma = MADAO.getByPerId(idperso);
				 lstmagneticperso.add(ma);
			}
			else
			{
				lstmagneticperso.add(null);
			}
		}
		
		return lstmagneticperso;
	}
	
	public List<MagneticPersonalization> getAll(long valueId)
	{
		return MADAO.getall(valueId);
	}
	
	public MagneticPersonalization getCardByCardId(long cardId)
	{
		return MADAO.getCardByCardId(cardId);
	}
	
	public MagneticPersonalization getBySerial(String serial)
	{
		return MADAO.getCardBySerial(serial);
	}

}
