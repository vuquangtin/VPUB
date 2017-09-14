package com.swt.meetingregister.webservice;

import com.google.gson.Gson;
import com.swt.constants.MethodName;
import com.swt.constants.UrlPattern;
import com.swt.meetingregister.utilities.Logging;
import com.swt.meetingregister.utilities.Utilities;

public class SystemService {

	private static SystemService Instance = new SystemService();

	private static Session session;

	public static SystemService getInstance() {
		return Instance;
	}

	public Session login() {
		try {
			Object obj = Utilities.getInstance().getDataFromServer("",
					UrlPattern.AUTH, MethodName.LOGIN,
					"ten.nguyen",
					"1");
			session = new Gson()
					.fromJson(new Gson().toJson(obj), Session.class);
			return session;
		} catch (Exception ex) {
			Logging.getInstance().writeError(ex.getMessage());
			ex.printStackTrace();
			return null;
		}
	}
}
