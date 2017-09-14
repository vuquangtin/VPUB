/**
 * 
 */
package com.swt.sworld.communication.customer.object;

/**
 * @author LOCVIP
 *
 */

/*
 * Table này thêm vào dựa vào code của anh Dũng
 */
public class CardStatisticsData {
	
	private int Status;
	private int Amount;
	
	public CardStatisticsData(int status, int amount)
	{
		this.Status = status;
		this.Amount = amount;
	}

	/**
	 * @return the status
	 */
	public int getStatus() {
		return Status;
	}

	/**
	 * @param status the status to set
	 */
	public void setStatus(int status) {
		Status = status;
	}

	/**
	 * @return the amount
	 */
	public int getAmount() {
		return Amount;
	}

	/**
	 * @param amount the amount to set
	 */
	public void setAmount(int amount) {
		Amount = amount;
	}

}
