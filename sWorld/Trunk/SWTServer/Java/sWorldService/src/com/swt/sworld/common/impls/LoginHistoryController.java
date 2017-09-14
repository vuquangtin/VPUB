/**
 * 
 */
package com.swt.sworld.common.impls;

import java.util.List;

import com.swt.sworld.common.domain.LoginHistory;
import com.swt.sworld.communication.customer.object.LoginHistoryFilterDto;

/**
 * @author Administrator
 *
 */
public class LoginHistoryController {
	
	public static final LoginHistoryController Instance = new LoginHistoryController();
	private LoginHistoryDAOImpl loginDAO = new LoginHistoryDAOImpl();

	private LoginHistoryController() {

	}
	
	public List<LoginHistory> getLoginHistoryList(LoginHistoryFilterDto loginfilter)
	{
		return loginDAO.getLoginHistoryList(loginfilter);
	}

}
