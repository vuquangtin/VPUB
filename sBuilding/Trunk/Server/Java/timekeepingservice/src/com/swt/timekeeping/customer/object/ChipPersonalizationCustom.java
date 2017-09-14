package com.swt.timekeeping.customer.object;

public class ChipPersonalizationCustom {

	private long memberId;
	private String serialNumber;

	public ChipPersonalizationCustom() {

	}

	public ChipPersonalizationCustom(long memberId, String serialNumber) {
		this.memberId = memberId;
		this.serialNumber = serialNumber;
	}

	public long getMemberId() {
		return memberId;
	}

	public void setMemberId(long memberId) {
		this.memberId = memberId;
	}

	public String getSerialNumber() {
		return serialNumber;
	}

	public void setSerialNumber(String serialNumber) {
		this.serialNumber = serialNumber;
	}
}
