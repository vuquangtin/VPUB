package com.swt.service;

import com.google.gson.Gson;
import com.swt.constants.UrlPattern;
import com.swt.constants.MethodName;
import com.swt.object.ShiftReturn;
import com.swt.object.DoorOutReturn;
import com.swt.object.DoorOut;
import com.swt.object.Session;
import com.swt.object.TimeKeepingAcess;
import com.swt.object.TimeKeepingImage;
import com.swt.utilities.AppConfig;
import com.swt.utilities.Logging;
import com.swt.utilities.Utilities;

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
					AppConfig.getInstance().getUser(),
					AppConfig.getInstance().getPassworld());
			session = new Gson()
					.fromJson(new Gson().toJson(obj), Session.class);
			return session;
		} catch (Exception ex) {
			Logging.getInstance().writeError(ex.getMessage());
			ex.printStackTrace();
			return null;
		}
	}

	public boolean accessProcess(String _serial, String _IP) {
		try {
			DoorOut doorOut = new DoorOut();
			doorOut.setSerialNumber(_serial);
			doorOut.setDateIn(Utilities.getInstance()
					.getCurrentDateStrDDMMYYYY());
			doorOut.setDateOut(Utilities.getInstance()
					.getCurrentDateStrDDMMYYYY());
			String _doorOut = new Gson().toJson(doorOut);
			Object obj = Utilities.getInstance().postDataFromServer(
					session.getToken(), UrlPattern.ACCESS,
					MethodName.ACCESSPROCESS, _doorOut, session.getToken(),
					AppConfig.getInstance().getMode(), _IP);
			DoorOutReturn doorOutReturn = new Gson().fromJson(
					new Gson().toJson(obj), DoorOutReturn.class);
			if (doorOutReturn.getStatus() > 0) {
				return true;
			} else {
				return false;
			}
		} catch (Exception ex) {
			Logging.getInstance().writeError(ex.getMessage());
			ex.printStackTrace();
		}
		return false;
	}

	public TimeKeepingAcess checkIpDeviceForTimeKeeping(String _serial,
			String _IP) {
		try {
			Object obj = Utilities.getInstance().getDataFromServer(
					session.getToken(), UrlPattern.TIMEKEEPING_CONFIG,
					MethodName.CHECK_DEVICE_IP_CONFIG, session.getToken(),
					_serial, _IP);
			return new Gson().fromJson(new Gson().toJson(obj),
					TimeKeepingAcess.class);
		} catch (Exception e) {
			Logging.getInstance().writeError(e.getMessage());
			return null;
		}
	}

	public ShiftReturn insertShift(String _shift) {
		try {
			Object obj = Utilities.getInstance().postDataFromServer(
					session.getToken(), UrlPattern.TIMEKEEPING_SHIFT_MANAGER,
					MethodName.INSERT_TIMEKEEPING_SHIFT, _shift,
					session.getToken());
			return new Gson().fromJson(new Gson().toJson(obj),
					ShiftReturn.class);
		} catch (Exception e) {
			Logging.getInstance().writeError(e.getMessage());
			return null;
		}
	}

	public TimeKeepingImage insertShiftImage(String _image,
			long timekeepingShiftId) {
		try {
			Object obj = Utilities.getInstance().postDataFromServer(
					session.getToken(), UrlPattern.TIMEKEEPING_SHIFT_MANAGER,
					MethodName.INSERT_SHIFT_IMAGE, _image, session.getToken(),
					timekeepingShiftId);
			return new Gson().fromJson(new Gson().toJson(obj),
					TimeKeepingImage.class);
		} catch (Exception e) {
			Logging.getInstance().writeError(e.getMessage());
			return null;
		}
	}
}
