package com.swt.timekeeping.customer.object;

import java.text.DateFormat;
import java.text.SimpleDateFormat;

import com.swt.timekeeping.domain.HolidayConfig;

public class HolidayResultForGet {
	private long holidayId;
	private String holidayName;
	private String holidayStart;
	private String holidayEnd;
	private String holidayDescription;
	private long orgId;

	public HolidayResultForGet() {

	}

	public HolidayResultForGet(HolidayConfig hConfig) {
		DateFormat dateFormat = new SimpleDateFormat("dd/MM/yyyy");
		this.holidayId = hConfig.getHolidayId();
		this.holidayName = hConfig.getHolidayName();
		this.holidayStart = dateFormat.format(hConfig.getHolidayStart());
		this.holidayEnd = dateFormat.format(hConfig.getHolidayEnd());
		this.holidayDescription = hConfig.getHolidayDescription();
		this.orgId = hConfig.getOrgId();
	}

	public long getHolidayId() {
		return holidayId;
	}

	public void setHolidayId(long holidayId) {
		this.holidayId = holidayId;
	}

	public String getHolidayName() {
		return holidayName;
	}

	public void setHolidayName(String holidayName) {
		this.holidayName = holidayName;
	}

	public String getHolidayStart() {
		return holidayStart;
	}

	public void setHolidayStart(String holidayStart) {
		this.holidayStart = holidayStart;
	}

	public String getHolidayEnd() {
		return holidayEnd;
	}

	public void setHolidayEnd(String holidayEnd) {
		this.holidayEnd = holidayEnd;
	}

	public String getHolidayDescription() {
		return holidayDescription;
	}

	public void setHolidayDescription(String holidayDescription) {
		this.holidayDescription = holidayDescription;
	}

	public long getOrgId() {
		return orgId;
	}

	public void setOrgId(long orgId) {
		this.orgId = orgId;
	}
}
