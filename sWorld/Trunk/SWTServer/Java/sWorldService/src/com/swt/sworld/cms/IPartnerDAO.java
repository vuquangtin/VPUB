package com.swt.sworld.cms;


import java.util.List;

import com.swt.sworld.cms.domain.PartnersOfMaster;

public interface IPartnerDAO {
	List<PartnersOfMaster> getPartnersOfMaster(long masterid);
	List<Long> getPartnersIdOfMaster(long masterid);
	
	int insert(PartnersOfMaster pom);
	int update(PartnersOfMaster pom);
	int delete(long id);
	
	List<Long> getAllMasterList();
	
	List<Long> getPartnersByFilter(long masterid);
	
	List<PartnersOfMaster> checkPartnersOfMaster(long masterid, long partnerid);
	
	long getId(String mastercode, String partnercode);
	
	void deleteAllMaster(String code);
	
	List<PartnersOfMaster> getByMasterCode(String masterCode);
	
}
