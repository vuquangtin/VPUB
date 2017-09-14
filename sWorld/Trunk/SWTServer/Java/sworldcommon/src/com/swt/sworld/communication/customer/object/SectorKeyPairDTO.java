package com.swt.sworld.communication.customer.object;

import java.io.Serializable;

public class SectorKeyPairDTO implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = -4249770229002639659L;
	private String KeyA;
	private String KeyB;
	public String getKeyA() {
		return KeyA;
	}
	public void setKeyA(String keyA) {
		KeyA = keyA;
	}
	public String getKeyB() {
		return KeyB;
	}
	public void setKeyB(String keyB) {
		KeyB = keyB;
	}
}
