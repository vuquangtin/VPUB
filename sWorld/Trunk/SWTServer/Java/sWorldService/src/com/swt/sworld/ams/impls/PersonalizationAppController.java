/**
 * 
 */
package com.swt.sworld.ams.impls;
import com.swt.sworld.ams.domain.PersonalizationApp;

/**
 * @author Administrator
 *
 */
public class PersonalizationAppController {
	
	public static final PersonalizationAppController Instance = new PersonalizationAppController();
	
	private PersonalizationAppDAOImpl PERSONAPPDAO= new PersonalizationAppDAOImpl();
	private PersonalizationAppController() {
		
	}
	
	public int insertPersonalizationApp(PersonalizationApp pa)
	{
		return PERSONAPPDAO.insert(pa);
	}
	
	public int updatePersonalizationApp(PersonalizationApp pa)
	{
		return PERSONAPPDAO.update(pa);
	}
	
	public int deletePersonalizationApp(long id)
	{
		return PERSONAPPDAO.delete(id);
	}
	
	public PersonalizationApp getPersonalizationAppById(long id)
	{
		return PERSONAPPDAO.getPersonalizationAppById(id);
	}

}
