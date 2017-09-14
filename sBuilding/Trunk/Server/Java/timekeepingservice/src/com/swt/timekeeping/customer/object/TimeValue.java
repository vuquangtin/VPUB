package com.swt.timekeeping.customer.object;

public enum TimeValue {
	MINUTE(0), HOUR(1);

	private int value;

	private TimeValue(int value) {
		this.value = value;
	}

	public int getValue() {
		return this.value;
	}
}
