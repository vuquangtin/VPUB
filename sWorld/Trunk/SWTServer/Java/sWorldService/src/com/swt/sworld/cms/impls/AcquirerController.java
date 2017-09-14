/**
 * 
 */
package com.swt.sworld.cms.impls;
import java.util.ArrayList;
import java.util.List;

import com.nhn.utilities.Utilities;
import com.swt.sworld.cms.domain.Acquirer;
import com.swt.sworld.cms.domain.Organization;
import com.swt.sworld.common.errors.ErrorCode;
import com.swt.sworld.common.utilitis.TokenManager;
import com.swt.sworld.communication.customer.object.CmsOrgCustomerDto;
import com.swt.sworld.communication.customer.object.OrgFilterDto;

/**
 * @author Administrator
 *
 */
public class AcquirerController {
	
	public static final AcquirerController Instance = new AcquirerController();
	
	private AcquirerDAOImpl ACQUIDAO= new AcquirerDAOImpl();
	private OrganizationDAOImpl ORGDAO = new OrganizationDAOImpl();
	private AcquirerController() {
		
	}
	
	public int delete(long id)
	{
		return ACQUIDAO.delete(id);
	}
	
	public Acquirer getAcquirerById(long id)
	{
		return ACQUIDAO.getAcquirerById(id);
	}
	
	public int insertOrgAcquirer(String session, long masterId, List<Long> partnerId)
	{
		int kq =-1;
		Organization org = ORGDAO.getById(masterId);
		if(null == org)
			return ErrorCode.FALSED;
		
		ACQUIDAO.deleteAllMaster(org.getOrgCode());
		for (Long long1 : partnerId) {
			Organization orgpartner = ORGDAO.getById(long1);
			if(null == orgpartner)
				continue;
			
			List<Acquirer> lstac = ACQUIDAO.check(org.getOrgCode(), orgpartner.getOrgCode());
			if(lstac.size() != 0)
			{
				continue;
			}
			else
			{
				String user = TokenManager.getInstance().getUserBySession(session);
				if( !"".contains(user))
				{
					Acquirer ac = new Acquirer();
					ac.setCreatedBy(user);
					ac.setModifiedBy(user);
					
					String date = Utilities.getInstance().currentDateStrDDMMYYYY();
					ac.setCreatedOn(date);
					ac.setModifiedOn(date);
					
					ac.setAcquierMasterCode(org.getOrgCode());
					ac.setAccessCode(orgpartner.getOrgCode());
					kq = ACQUIDAO.insert(ac);
				}
			}
		}
		return kq;
	}
	
	public int deleteOrgQcquirer(String masterCode, List<Long> partnerId)
	{
		int kq =-1;
		for (Long long1 : partnerId) {
			Organization orgpartner = ORGDAO.getById(long1);
			if(null == orgpartner)
				continue;
			
			Acquirer iddelete = ACQUIDAO.getId(masterCode, orgpartner.getOrgCode());
			if(iddelete != null)
			{
				kq = ACQUIDAO.delete(iddelete.getId());
			}
			else
			{
				kq = ErrorCode.UNKNOW;
			}
		}
		
		return kq;
		
	}
	
	public List<Acquirer> getAll()
	{
		return ACQUIDAO.getall();
	}
	
	public List<CmsOrgCustomerDto> getPartnerByMastercode(String masterCode, OrgFilterDto filter)
	{
		List<CmsOrgCustomerDto> lstorg = new ArrayList<CmsOrgCustomerDto>();
		List<String> lstmastercode = ACQUIDAO.getPartnerByMasterCode(masterCode);
		if(lstmastercode == null)
		{
			lstorg = null;
		}
		else
		{
			for (String string : lstmastercode) {
				Organization org = ORGDAO.getOrgByPartnerCode(string, filter);
				CmsOrgCustomerDto cmsorg = new CmsOrgCustomerDto();
				if(org == null)
				{
					continue;
				}
				else
				{
				cmsorg.setAddress(org.getAddress());
				cmsorg.setCity(org.getCity());
				cmsorg.setContactEmail(org.getContactEmail());
				cmsorg.setContactFax(org.getFax());
				cmsorg.setContactMobile(org.getContactMobile());
				cmsorg.setContactName(org.getContactName());
				cmsorg.setContactPhone(org.getContactPhone());
				cmsorg.setCountryCode(org.getCountryCode());
				cmsorg.setEmail(org.getEmail());
				cmsorg.setFax(org.getFax());
				cmsorg.setIssuer(org.getIssuer());
				cmsorg.setName(org.getName());
				cmsorg.setNotes(org.getNotes());
				cmsorg.setOrgCode(org.getOrgCode());
				cmsorg.setOrgId(org.getOrgId());
				cmsorg.setOrgShortName(org.getOrgShortName());
				cmsorg.setPhone(org.getPhone());
				cmsorg.setSettlementEmail(org.getSettlementEmail());
				cmsorg.setSettlementFrequency(org.getSettlementFrequency());
				cmsorg.setState(org.getState());
				cmsorg.setStatus(org.getStatus());
				cmsorg.setWebSite(org.getWebSite());
				cmsorg.setZipCode(org.getZipCode());
				}
				
				lstorg.add(cmsorg);
			}
		}
		return lstorg;
	}

	public List<Acquirer> getAcquirerByMasterCode(String orgCode) {
		return ACQUIDAO.getByMasterCode(orgCode);
	}

}
