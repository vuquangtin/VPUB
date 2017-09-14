package com.swt.timekeeping.customer.object;

public class GeneralConfigTime {
	private int value;
	private int type;

	public GeneralConfigTime() {

	}

	public GeneralConfigTime(int value, int type) {
		this.value = value;
		this.type = type;
	}

	public int getValue() {
		return value;
	}

	public void setValue(int value) {
		this.value = value;
	}

	public int getType() {
		return type;
	}

	public void setType(int type) {
		this.type = type;
	}
}
