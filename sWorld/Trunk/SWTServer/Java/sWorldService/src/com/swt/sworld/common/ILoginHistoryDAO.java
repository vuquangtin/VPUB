package com.swt.sworld.common;

import java.util.List;

import com.swt.sworld.common.domain.LoginHistory;
import com.swt.sworld.communication.customer.object.LoginHistoryFilterDto;

public interface ILoginHistoryDAO {
	
	List<LoginHistory> getLoginHistoryList(LoginHistoryFilterDto loginfilter);

}
