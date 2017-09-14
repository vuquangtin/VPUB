package com.swt.main;
import java.io.IOException;
import java.util.Timer;
import java.util.TimerTask;

import com.swt.meetingregister.utilities.Logging;
import com.swt.meetingregister.webservice.Session;
import com.swt.meetingregister.webservice.SystemService;

public class Main {

	/**
	 * @param args
	 * @throws IOException
	 */

	public static Session session = null;

	public static void main(String[] args) throws IOException {

		try {
			checkServer();
		} catch (Exception e) {
			e.printStackTrace();
		}
	}
	public static void checkServer() {
		try {
			session = SystemService.getInstance().login();
		} catch (Exception e) {
			e.printStackTrace();
		}
	}
}
