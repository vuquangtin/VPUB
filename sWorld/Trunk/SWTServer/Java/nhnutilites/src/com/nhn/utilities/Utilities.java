package com.nhn.utilities;

import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;

/**
 * @author Hoang Ha
 * 
 */
public class Utilities {
	private static final Utilities instance = new Utilities();

	private Utilities() {

	}

	public static Utilities getInstance() {
		return instance;
	}

	/**
	 * Ngày tháng hiện tại của hệ thống theo kiểu dd/mm/yyyy
	 * 
	 * @return một chuỗi theo format dd/mm/yyyy
	 */
	public String currentDateStrDDMMYYYY() {
		SimpleDateFormat sdfDate = new SimpleDateFormat("dd-MM-yyyy");
		return sdfDate.format(new Date());
	}

	/**
	 * Ngày tháng hiện tại của hệ thống theo kiểu yyyy-MM-dd
	 * 
	 * @return một chuỗi theo format yyy-MM-dd
	 */
	public String currentDateStrYYYYMMDD() {
		SimpleDateFormat sdfDate = new SimpleDateFormat("yyyy-MM-dd");
		Date now = new Date();
		String strDate = sdfDate.format(now);

		return strDate;
	}

	@SuppressWarnings("deprecation")
	public String currentDateStr() {
		String result = "";
		Date now = new Date();
		result += now.getSeconds();
		result += now.getMinutes();
		result += now.getHours();
		result += now.getDay();
		result += now.getMonth();
		result += now.getYear();
		return result;
	}
	
	@SuppressWarnings("deprecation")
	public String currentDateStrYYYYMMDD_hhmmss() {
		String result = "";
		Date now = new Date();
		result += now.getYear();
		result += now.getMonth();
		result += now.getDay();
		result += now.getHours();
		result += now.getMinutes();
		result += now.getSeconds();
		return result;
	}		
	
	public int[] getYearFromDate(Date date) {
		int[] result = { 1, 2015 };
		if (date != null) {
			Calendar cal = Calendar.getInstance();
			cal.setTime(date);
			result[1] = cal.get(Calendar.YEAR);
			result[0] = cal.get(Calendar.MONTH) + 1;
		}
		return result;
	}
	
	public int[] getDurationMonthYear(int dur)
	{
		Date now = new Date();
		int[] monthyear = Utilities.getInstance().getYearFromDate(now);
		int month = monthyear[0] + dur;
		int year = monthyear[1];
		int[] result = { month, year + 1 };
		if (month > 12) {
			year += month / 12;
			month = month % 12;
		}
		result[1] = year;
		result[0] = month;
		return result;
	}
}
