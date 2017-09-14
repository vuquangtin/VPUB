package com.swt.meeting.customObject;

import java.io.Serializable;

public class NumberObj implements Serializable {
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	private int value;

	public void setValue(int value) {
		this.value = value;
	}

	public int getValue() {
		return value;
	}
}
