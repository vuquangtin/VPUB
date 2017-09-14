package com.swt.sworld.cms;

import java.util.List;

import com.swt.sworld.cms.domain.SubOrganization;
import com.swt.sworld.communication.customer.object.OrgFilterDto;

public interface ISubOrganizationDAO {
	
	List<SubOrganization> getByOrgId(long id, OrgFilterDto filter);
	
	List<SubOrganization> getSubOrgByOrgId(long id);
	
	int insert(SubOrganization suborg);
	int update(SubOrganization suborg);
	int delele(SubOrganization suborg);
	
	SubOrganization getSubOrgById(long id);
	
	List<SubOrganization> getSubOrgByOrgId(long orgId, long lastId);

	SubOrganization getSubOrgByCode(String code);
	
	List<SubOrganization> getSubOrgByParentId(long orgId);
	
	
	
}
