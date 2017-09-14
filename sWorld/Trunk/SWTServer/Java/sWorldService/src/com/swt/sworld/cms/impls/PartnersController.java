/**
 * 
 */
package com.swt.sworld.cms.impls;

import java.util.ArrayList;
import java.util.List;

import com.nhn.error.ErrorCodeSworld;
import com.swt.sworld.cms.domain.Organization;
import com.swt.sworld.cms.domain.PartnersOfMaster;
import com.swt.sworld.communication.customer.object.CmsOrgCustomerDto;
import com.swt.sworld.communication.customer.object.OrgFilterDto;

/**
 * @author Administrator
 * 
 */
public class PartnersController {

	public static final PartnersController Instance = new PartnersController();

	private PartnersDAOImpl PARTDAO = new PartnersDAOImpl();
	private OrganizationDAOImpl ORGDAO = new OrganizationDAOImpl();

	private PartnersController() {

	}

	public int insert(PartnersOfMaster pom) {
		return PARTDAO.insert(pom);
	}

	public int update(PartnersOfMaster pom) {
		return PARTDAO.update(pom);
	}

	public int delete(long id) {
		return PARTDAO.delete(id);
	}

	public List<CmsOrgCustomerDto> getAllMasterList() {
		List<CmsOrgCustomerDto> lstcms = new ArrayList<CmsOrgCustomerDto>();

		List<Organization> lstorg = ORGDAO.getOrgIssuerList();

		// get infor org from organization by id o tren
		for (Organization organization : lstorg) {
			if (organization == null) {
				continue;
			} else {
				if (organization.getStatus() == -1) {
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
		}

		return lstcms;
	}

	public List<CmsOrgCustomerDto> getPartnerByMasterIdAndFilter(long masterid,
			OrgFilterDto filter) {
		List<CmsOrgCustomerDto> lstcms = new ArrayList<CmsOrgCustomerDto>();

		List<Long> lstlong = PARTDAO.getPartnersByFilter(masterid);

		// get infor org from organization by id o tren
		for (Long long1 : lstlong) {
			Organization organization = ORGDAO.getById(long1, filter);
			if (organization == null) {
				continue;
			} else {
				if (organization.getStatus() == -1) {
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
		}

		return lstcms;
	}

	public int insertPartnerOfMaster(long masterid, List<Long> partnerid) {
		int kq = -1;
		Organization org = ORGDAO.getById(masterid);
		if(null == org)
			return ErrorCodeSworld.FALSED;
		
		PARTDAO.deleteAllMaster(org.getOrgCode());
		for (Long long1 : partnerid) {
			List<PartnersOfMaster> lstpartner = PARTDAO.checkPartnersOfMaster(
					masterid, long1);
			if (lstpartner.size() != 0) {
				continue;
			} else {
				Organization orgpartner = ORGDAO.getById(long1);
				if(null == orgpartner)
					continue;
				
				PartnersOfMaster pom = new PartnersOfMaster();
				pom.setMasterid(masterid);
				pom.setIssuer(org.getIssuer());
				pom.setPartnerid(long1);
				pom.setPartnercode(orgpartner.getOrgCode());
				kq = PARTDAO.insert(pom);
			}
		}
		return kq;
	}

	public int deletePartnerOfMaster(long masterid, List<Long> partnerid) {
		int kq = -1;

		Organization org = ORGDAO.getById(masterid);
		if(null == org)
			return ErrorCodeSworld.FALSED;
		
		for (Long long1 : partnerid) {
			Organization orgpartner = ORGDAO.getById(long1);
			if(null == orgpartner)
				continue;
			
			long iddelete = PARTDAO.getId(org.getOrgCode(),
					orgpartner.getOrgCode());
			kq = PARTDAO.delete(iddelete);
		}

		return kq;
	}
	
	public List<PartnersOfMaster> getByMasterCode(String masterCode)
	{
		return PARTDAO.getByMasterCode(masterCode);
	}
	
	public boolean checkRelationship(String issuer, String partnercode){
		return PARTDAO.getId(issuer, partnercode) > 0 ? true : false;
	}

}
