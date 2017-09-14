package com.swt.sworld.ams.impls;


import java.util.List;

import com.swt.sworld.ams.domain.App;
import com.swt.sworld.ams.impls.AppDAOImpl;

/**
 * @author Administrator
 *
 */
public class AppController {
	
	public static final AppController Instance = new AppController();
	
	private AppDAOImpl APPDAO= new AppDAOImpl();
	private AppController() {
		
	}
	
	public List<App> GetAll()
	{
		return APPDAO.getall();
	}
	
	public int insert(App application)
	{
		return APPDAO.insert(application);
	}
	
	public int update(App application)
	{
		return APPDAO.update(application);
	}
	
	public int delete(long id)
	{
		return APPDAO.delete(id);
	}
	
	public App GetAppByAppId(long appId)
	{
		return APPDAO.selectByAppId(appId);
	}

}
