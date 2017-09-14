package com.swt.sworld.cms;

import java.util.List;

import com.swt.sworld.cms.domain.Organization;
import com.swt.sworld.communication.customer.object.OrgFilterDto;


public interface IOrganizationDAO {
	List<Organization> getAll(OrgFilterDto filter);
	Organization getById(long id, OrgFilterDto filter);
	long getSecrectKeyId(long id);
	int makePersistence(Organization org);
	int updateStatus(int id, boolean newStatus);
	int delete(Organization org);
	
	Organization getOrgByIssuerCode(String code);
	
	Organization addOrgObj(Organization org);
//	int addorg(Organization org);
	
	List<Organization> getOrgIssuerList();
	
	List<Organization> getAllOrgList();
	
	Organization getOrgByPartnerCode(String code, OrgFilterDto filter);
	
	Organization getById(long id);
	
	Organization getByOrgCode(String orgCode);
}
