package com.swt.timekeeping.customer.object;

public enum GeneralConfigureValue {
	HAFT_DAY(1), LATE_DAY(2);
	private int value;

	private GeneralConfigureValue(int value) {
		this.value = value;
	}

	public int getValue() {
		return this.value;
	}
}
