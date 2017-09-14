/**
 * 
 */
package com.swt.sworld.ams;
import com.swt.sworld.ams.domain.PersonalizationApp;

/**
 * @author Administrator
 *
 */
public interface IPersonalizationApp {
	
	int insert(PersonalizationApp pa);
	int update(PersonalizationApp pa);
	int delete(long id);
	PersonalizationApp getPersonalizationAppById(long id);

}
