/**
 * 
 */
package com.swt.sworld.ams;

import java.util.List;

import com.swt.sworld.ams.domain.App;

/**
 * @author Administrator
 *
 */
public interface IApp {
	
	int insert(App app);
	int update(App app);
	int delete(long id);
	List<App> getall();
	App selectByAppId(long appId);
}
