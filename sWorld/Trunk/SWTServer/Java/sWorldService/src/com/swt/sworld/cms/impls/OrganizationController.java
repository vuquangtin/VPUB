/**
 * 
 */
package com.swt.sworld.cms.impls;

import java.util.ArrayList;
import java.util.List;

import org.apache.commons.lang3.RandomStringUtils;

import com.nhn.error.ErrorCodeSworld;
import com.nhn.utilities.HibernateUtil;
import com.nhn.utilities.Utilities;
import com.swt.sworld.cms.domain.CardType;
import com.swt.sworld.cms.domain.Organization;
import com.swt.sworld.cms.domain.SubOrganization;
import com.swt.sworld.common.domain.Config;
import com.swt.sworld.common.errors.ErrorCode;
import com.swt.sworld.common.impls.ConfigDAOImpl;
import com.swt.sworld.common.utilitis.TokenManager;
import com.swt.sworld.communication.customer.object.CardTypeDTO;
import com.swt.sworld.communication.customer.object.CmsOrgCustomerDto;
import com.swt.sworld.communication.customer.object.KeyDTO;
import com.swt.sworld.communication.customer.object.MasterInfoDTO;
import com.swt.sworld.communication.customer.object.OrgCustomerDto;
import com.swt.sworld.communication.customer.object.OrgFilterDto;
import com.swt.sworld.communication.customer.object.PartnerInfoDto;
import com.swt.sworld.communication.customer.object.SectorKeyPairDTO;
import com.swt.sworld.communication.customer.object.SubOrgCustomerDto;
import com.swt.sworld.kms.domain.SecretKey;
import com.swt.sworld.kms.impls.SecretKeyDaoImpl;
import com.swt.sworld.utilites.SworldConst;

/**
 * @author Administrator
 * 
 */
public class OrganizationController {
	public static final OrganizationController Instance = new OrganizationController();

	private OrganizationDAOImpl ORG = new OrganizationDAOImpl();
	private CardTypeDAOImpl CARD = new CardTypeDAOImpl();
	private PartnersDAOImpl PARTMASTER = new PartnersDAOImpl();
	private SubOrganizationDAOImpl SUBORG = new SubOrganizationDAOImpl();
	private ConfigDAOImpl CONFIG = new ConfigDAOImpl();
	private SecretKeyDaoImpl SCRECTDAO = new SecretKeyDaoImpl();
	private String keyA = "";
	private String keyB = "";
	private String keyValue = "";

	@SuppressWarnings("unused")
	private void loadConfig() {
		keyA = "";
		keyB = "";
		keyValue = "";
		Config keyAObj = CONFIG
				.getValueActiveByName(SworldConst.KEY_A_SECOR_VALUE);
		if (null != keyAObj)
			keyA = keyAObj.getValue();

		// check a keyB
		Config keyBObj = CONFIG
				.getValueActiveByName(SworldConst.KEY_B_SECOR_VALUE);
		if (null != keyBObj)
			keyB = keyBObj.getValue();

		// created keyvalue.
		// TODO: check role of key value.
		// we will discuss about it. It need created the same or diffirent
		// between sectors
		// get key value one for sector
		Config key1 = CONFIG
				.getValueActiveByName(SworldConst.KEY_VALUE1_SECTOR);
		if (null != key1)
			keyValue = key1.getValue();
	}

	private OrganizationController() {
		// loadConfig();
	}

	private List<CardTypeDTO> getListCardTypeDTO(long orgid) {
		List<CardType> cardtypes = CARD.getByOrgId(orgid);

		List<CardTypeDTO> cards = new ArrayList<CardTypeDTO>();
		for (CardType cardType : cardtypes) {
			CardTypeDTO temp = new CardTypeDTO(cardType.getCardTypeID(),
					cardType.getPrefix(), cardType.getCardTypeName(),
					cardType.getCardLow(), cardType.getCardHigh(),
					cardType.getPinLength());
			cards.add(temp);
		}

		return cards;
	}

	/**
	 * Hàm này lỗi khi gửi dữ liệu 22222 từ client lên và báo hàm này trả về null
	 * @param code
	 * @return
	 */
	public MasterInfoDTO getDataMasterByKey(String code) {

		// get org info
		Organization org = ORG.getOrgByIssuerCode(code);

		// get card type by org id
		// cards DTO bị rỗng 

		if ( null == org)
			return null;
		
		List<CardTypeDTO> cardtypes = getListCardTypeDTO(org.getOrgId());

		for (CardTypeDTO cardTypeDTO : cardtypes) {
			System.out.println(cardTypeDTO.getCardTypeName());
		}

		//loadConfig();
		SecretKey secretLocFix = SCRECTDAO.getById(org.getSecretkeyid());
		keyA = secretLocFix.getKeyADM();
		keyB = secretLocFix.getKeyBDM();
		keyValue = secretLocFix.getKeyValue();
		if ("".equals(keyA) || "".equals(keyB) || "".equals(keyValue))
			return null;

		// created key pair for sector
		SectorKeyPairDTO sector = new SectorKeyPairDTO();
		sector.setKeyA(keyA);
		sector.setKeyB(keyB);

		// get secrect key
		SecretKey secret = SCRECTDAO.getById(org.getSecretkeyid());

		// created KeyDTo object
		KeyDTO keydto = new KeyDTO(secret.getSecretKeyId(), secret.getAlias(),
				keyValue, sector);

		// created master information object
		MasterInfoDTO obj = new MasterInfoDTO(org.getOrgId(),
				org.getOrgShortName(), org.getName(), keydto, org.getOrgCode(),
				cardtypes);

		return obj;

	}

	/**
	 * 
	 * @param masterid
	 * @param code
	 * @return
	 */
	public List<PartnerInfoDto> getDataPartnerByKey(int masterid, String code) {

		List<PartnerInfoDto> ls = new ArrayList<PartnerInfoDto>();

		// get list id of partner of master
		List<Long> lsId = PARTMASTER.getPartnersIdOfMaster(masterid);

		for (Long long1 : lsId) {
			// get org info
			Organization org = ORG.getById(long1);
			if (null == org)
				continue;

			// get card type by org id
			List<CardTypeDTO> cards = getListCardTypeDTO(org.getOrgId());

//			loadConfig();
			SecretKey secretLocFix = SCRECTDAO.getById(org.getSecretkeyid());
			keyA = secretLocFix.getKeyADM();
			keyB = secretLocFix.getKeyBDM();
			keyValue = secretLocFix.getKeyValue();
			if ("".equals(keyA) || "".equals(keyB) || "".equals(keyValue))
				return null;

			// created key pair for sector
			SectorKeyPairDTO sector = new SectorKeyPairDTO();
			sector.setKeyA(keyA);
			sector.setKeyB(keyB);
			KeyDTO keydto = new KeyDTO(1, 2, keyValue, sector);

			PartnerInfoDto obj = new PartnerInfoDto(masterid, org.getOrgId(),
					org.getOrgShortName(), org.getName(), keydto,
					org.getOrgCode(), cards);

			ls.add(obj);
		}

		return ls;

	}

	public List<OrgCustomerDto> getOrgList(OrgFilterDto filter) {
		List<OrgCustomerDto> lstorg = new ArrayList<OrgCustomerDto>();
		List<Organization> org = ORG.getAll(filter);
		for (Organization organization : org) {
			if (organization.getStatus() == -1) {
				continue;
			} else {
				List<SubOrganization> sub = SUBORG.getByOrgId(
						organization.getOrgId(), null);
				if (sub.size() == 0) {
					OrgCustomerDto orgdto = new OrgCustomerDto();
					orgdto.setName(organization.getName());
					orgdto.setOrgCode(organization.getOrgCode());
					orgdto.setOrgId(organization.getOrgId());
					orgdto.setOrgShortName(organization.getOrgShortName());
					orgdto.setSubOrgList(null);
					orgdto.setIssuer(organization.getIssuer());
					lstorg.add(orgdto);
				} else {
					OrgCustomerDto orgdto = new OrgCustomerDto();
					List<SubOrgCustomerDto> lstsuborgdto = new ArrayList<SubOrgCustomerDto>();
					for (SubOrganization subOrganization : sub) {
						if (subOrganization.getStatus() == -1) {
							continue;
						} else {
							SubOrgCustomerDto subdto = new SubOrgCustomerDto();
							subdto.setSubOrgId(subOrganization.getSuborgid());
							subdto.setOrgId(subOrganization.getOrgid());
							subdto.setOrgCode(subOrganization.getOrgcode());
							subdto.setName(subOrganization.getNames());
							subdto.setOrgShortName(subOrganization.getShortname());
							subdto.setParentOrgId(subOrganization.getParentOrgId());
							lstsuborgdto.add(subdto);
						}
					}
					orgdto.setSubOrgList(lstsuborgdto);
					orgdto.setName(organization.getName());
					orgdto.setOrgCode(organization.getOrgCode());
					orgdto.setOrgId(organization.getOrgId());
					orgdto.setOrgShortName(organization.getOrgShortName());
					orgdto.setIssuer(organization.getIssuer());
					lstorg.add(orgdto);
				}
			}

		}
		return lstorg;
	}

	public Organization getOrgByOrgId(long orgid) {
		Organization temp = ORG.getById(orgid);

		if (temp.getIssuer().contentEquals(SworldConst.NOTMASTER)) {
			temp.setIssuer(SworldConst.NOTMASTER);
		}

		return temp;
	}

	public int addOrg(String session, Organization org) {
		Config cfg = CONFIG.getValueActiveByName(SworldConst.KEY_ACTIVE);

		// get secrect key active value
		if (null == cfg)
			return ErrorCodeSworld.FALSED;

		try {
			long secid = Long.valueOf(cfg.getId());
			org.setSecretkeyid(secid);
		} catch (Exception e) {
			return ErrorCodeSworld.FALSED;
		}

		if (org.getIssuer().compareToIgnoreCase(SworldConst.TRUE) == 0) {

			String Issuer = RandomStringUtils.randomAlphanumeric(10).toUpperCase();
			org.setIssuer(Issuer);
		} else {
			org.setIssuer(SworldConst.NOTMASTER);
		}

		// checked user session
		String user = TokenManager.getInstance().getUserBySession(session);
		if ("".equals(user))
			return ErrorCodeSworld.FALSED;

		// set current date created
		String date = Utilities.getInstance().currentDateStrDDMMYYYY();

		// created user and modified user
		org.setCreatedBy(user);
		org.setModifiedBy(user);

		// created date and modified date
		org.setCreatedOn(date);
		org.setModifiedOn(date);

		org = ORG.addOrgObj(org);
		if (null == org || org.getOrgId() < 0)
			return ErrorCodeSworld.FALSED;

		// has add sub org default?
		Config cfg2 = CONFIG.getValueActiveByName(SworldConst.AUTO_ADD_DEFAULT_ORG);

		if (null != cfg2 && SworldConst.TRUE.equalsIgnoreCase(cfg2.getValue())) {

			SubOrganization suborg = new SubOrganization();

			suborg.setCreatedby(user);
			suborg.setCreatedon(date);
			suborg.setModifiedby(user);
			suborg.setModifiedon(date);

			suborg.setAddress(org.getAddress());
			suborg.setCity(org.getCity());
			suborg.setContactemail(org.getContactEmail());
			suborg.setContactphone(org.getContactMobile());
			suborg.setContactname(org.getContactName());
			suborg.setCountrycode(org.getCountryCode());
			suborg.setEmail(org.getEmail());
			suborg.setFax(org.getFax());
			
			// using the default sub-organization
			// in case smart world only 
			suborg.setNames(SworldConst.ORG_CENTRAL + org.getName());
			suborg.setNotes(SworldConst.ORG_CENTRAL);
			suborg.setNames(org.getName());
			suborg.setOrgshortname(org.getOrgShortName());
			suborg.setOrgcode(org.getOrgCode());
			
			
			suborg.setOrgid(org.getOrgId());
			
			suborg.setPhone(org.getPhone());
			suborg.setSettlementemail(org.getSettlementEmail());
			suborg.setState(org.getState());
			suborg.setStatus(org.getStatus());
			suborg.setWebsite(org.getWebSite());
			suborg.setZipcode(org.getZipCode());
			SUBORG.insert(suborg);
		}

		return ErrorCodeSworld.SUCCESS;
	}

	public int updateOrg(String session, Organization org) {
		int kq = -10;
		Organization checkorg = ORG.getById(org.getOrgId());
		if (checkorg == null)
			return ErrorCode.FALSED;

		String issuer = checkorg.getIssuer();
		if (org.getIssuer().compareToIgnoreCase(SworldConst.TRUE) == 0) {
			if (issuer.equalsIgnoreCase(SworldConst.NOTMASTER)) {
				String Issuer = RandomStringUtils.randomAlphanumeric(10)
						.toUpperCase();
				org.setIssuer(Issuer);
			} else {
				if (issuer.contains(SworldConst.NOTMASTER)) {
					issuer = issuer.substring(SworldConst.NOTMASTER.length());
					org.setIssuer(issuer);
				} else {
					org.setIssuer(issuer);
				}
			}
		} else {
			if (!issuer.equalsIgnoreCase(SworldConst.NOTMASTER)) {
				org.setIssuer(SworldConst.NOTMASTER + checkorg.getIssuer());
			}
		}

		org.setSecretkeyid(1);

		String user = TokenManager.getInstance().getUserBySession(session);
		if (!"".equals(user)) {
			org.setModifiedBy(user);
			org.setModifiedOn(Utilities.getInstance().currentDateStrDDMMYYYY());

			kq = HibernateUtil.update(org);
		}

		return kq;
	}

	public int deleteOrg(long orgid) {
		Organization org = ORG.getById(orgid);
		return ORG.delete(org);
	}

	public List<CmsOrgCustomerDto> getAllOrgList() {
		List<CmsOrgCustomerDto> lstcms = new ArrayList<CmsOrgCustomerDto>();
		List<Organization> lstorg = ORG.getAllOrgList();
		for (Organization organization : lstorg) {

			if (organization.getStatus() < 0) {
				continue;
			} else {
				CmsOrgCustomerDto cms = new CmsOrgCustomerDto();

				cms.setAddress(organization.getAddress());
				cms.setCity(organization.getCity());
				cms.setContactEmail(organization.getContactEmail());
				cms.setContactFax(organization.getFax());
				cms.setContactMobile(organization.getContactMobile());
				cms.setContactName(organization.getContactName());
				cms.setContactPhone(organization.getContactPhone());
				cms.setCountryCode(organization.getCountryCode());
				cms.setEmail(organization.getEmail());
				cms.setFax(organization.getFax());
				cms.setIssuer(organization.getIssuer());
				cms.setName(organization.getName());
				cms.setNotes(organization.getNotes());
				cms.setOrgCode(organization.getOrgCode());
				cms.setOrgId(organization.getOrgId());
				cms.setOrgShortName(organization.getOrgShortName());
				cms.setPhone(organization.getPhone());
				cms.setSettlementEmail(organization.getSettlementEmail());
				cms.setSettlementFrequency(organization
						.getSettlementFrequency());
				cms.setState(organization.getState());
				cms.setStatus(organization.getStatus());
				cms.setWebSite(organization.getWebSite());
				cms.setZipCode(organization.getZipCode());

				lstcms.add(cms);
			}
		}

		return lstcms;
	}

	public Organization getByOrgCode(String orgCode) {
		return ORG.getByOrgCode(orgCode);
	}
	
	public Organization getByIssuerCode(String issuerCode){
		return ORG.getOrgByIssuerCode(issuerCode);
	}

}
