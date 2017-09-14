package com.swt.timekeeping.customer.object;

import java.text.DateFormat;
import java.text.SimpleDateFormat;
import com.swt.timekeeping.domain.DayOffConfig;

public class DayOffResultForGet {
	private long dayOffConfigId;
	private long memberId;
	private String date;
	private int status;
	private long subOrgId;

	public DayOffResultForGet() {

	}

	public DayOffResultForGet(DayOffConfig doConfig) {
		DateFormat dateFormat = new SimpleDateFormat("dd/MM/yyyy");
		this.dayOffConfigId = doConfig.getDayOffConfigId();
		this.memberId = doConfig.getMemberId();
		this.date = dateFormat.format(doConfig.getDate());
		this.status = doConfig.getStatus();
		this.subOrgId = doConfig.getSubOrgId();
	}

	public long getDayOffConfigId() {
		return dayOffConfigId;
	}

	public void setDayOffConfigId(long dayOffConfigId) {
		this.dayOffConfigId = dayOffConfigId;
	}

	public long getMemberId() {
		return memberId;
	}

	public void setMemberId(long memberId) {
		this.memberId = memberId;
	}

	public String getDate() {
		return date;
	}

	public void setDate(String date) {
		this.date = date;
	}

	public int getStatus() {
		return status;
	}

	public void setStatus(int status) {
		this.status = status;
	}

	public long getSubOrgId() {
		return subOrgId;
	}

	public void setSubOrgId(long subOrgId) {
		this.subOrgId = subOrgId;
	}
}
