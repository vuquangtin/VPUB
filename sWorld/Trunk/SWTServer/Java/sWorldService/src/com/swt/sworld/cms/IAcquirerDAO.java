/**
 * 
 */
package com.swt.sworld.cms;
import java.util.List;

import com.swt.sworld.cms.domain.Acquirer;

/**
 * @author Administrator
 *
 */
public interface IAcquirerDAO {
	
	int insert(Acquirer ac);
	int update(Acquirer ac);
	int delete(long Id);
	
	Acquirer getAcquirerById(long acid);
	
	List<Acquirer> check(String acquirerCode, String accessCode);
	
	Acquirer getId(String acquirerCode, String accessCode);
	
	List<Acquirer> getall();
	
	List<String> getPartnerByMasterCode(String masterCode);
	
	void deleteAllMaster(String code);
	
	List<Acquirer> getByMasterCode(String masterCode);
}
