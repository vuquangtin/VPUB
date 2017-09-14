/**
 * 
 */
package com.swt.sworld.communication.customer.object;

/**
 * @author Administrator
 *
 */
public class KeyUpdateSetDto {
	
	private byte[] CurrentKeyB;
	private byte[] NewKeyA;
	private byte[] NewKeyB;
	/**
	 * @return the currentKeyB
	 */
	public byte[] getCurrentKeyB() {
		return CurrentKeyB;
	}
	/**
	 * @param currentKeyB the currentKeyB to set
	 */
	public void setCurrentKeyB(byte[] currentKeyB) {
		CurrentKeyB = currentKeyB;
	}
	/**
	 * @return the newKeyA
	 */
	public byte[] getNewKeyA() {
		return NewKeyA;
	}
	/**
	 * @param newKeyA the newKeyA to set
	 */
	public void setNewKeyA(byte[] newKeyA) {
		NewKeyA = newKeyA;
	}
	/**
	 * @return the newKeyB
	 */
	public byte[] getNewKeyB() {
		return NewKeyB;
	}
	/**
	 * @param newKeyB the newKeyB to set
	 */
	public void setNewKeyB(byte[] newKeyB) {
		NewKeyB = newKeyB;
	}

}
