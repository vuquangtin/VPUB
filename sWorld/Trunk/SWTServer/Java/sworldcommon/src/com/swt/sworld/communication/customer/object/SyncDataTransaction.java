/**
 * 
 */
package com.swt.sworld.communication.customer.object;

import java.io.Serializable;

/**
 * @author Administrator
 *
 */
public class SyncDataTransaction implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = 3966624708101538379L;
	
	private long transaction_id;
	private String serialNumber;
	private String orderCode;
	private String date;
	private String cardType;
	private Double amount;
	
	//object point
	private Double saleoff_merchant; // chi dc set vao khi merchant cho phep
	private Double savepoint_at_merchant; // chi dc set vao khi merchant cho phep
	private long merchant_acc_point_id; // chi dc set vao khi merchant cho phep
	
	private Double savepoint_at_swt;
	private Double saleoff_swt;
	private Double payment;
	private long swt_acc_id; ///??? value in  @Column(name = "owner_id") from Accumlated point saleoff 
	
	/**
	 * @return the serialNumber
	 */
	public String getSerialNumber() {
		return serialNumber;
	}
	/**
	 * @param serialNumber the serialNumber to set
	 */
	public void setSerialNumber(String serialNumber) {
		this.serialNumber = serialNumber;
	}
	/**
	 * @return the orderCode
	 */
	public String getOrderCode() {
		return orderCode;
	}
	/**
	 * @param orderCode the orderCode to set
	 */
	public void setOrderCode(String orderCode) {
		this.orderCode = orderCode;
	}
	/**
	 * @return the date
	 */
	public String getDate() {
		return date;
	}
	/**
	 * @param date the date to set
	 */
	public void setDate(String date) {
		this.date = date;
	}
	/**
	 * @return the cardType
	 */
	public String getCardType() {
		return cardType;
	}
	/**
	 * @param cardType the cardType to set
	 */
	public void setCardType(String cardType) {
		this.cardType = cardType;
	}
	/**
	 * @return the amount
	 */
	public Double getAmount() {
		return amount;
	}
	/**
	 * @param amount the amount to set
	 */
	public void setAmount(Double amount) {
		this.amount = amount;
	}
	/**
	 * @return the saleoff_merchant
	 */
	public Double getSaleoff_merchant() {
		return saleoff_merchant;
	}
	/**
	 * @param saleoff_merchant the saleoff_merchant to set
	 */
	public void setSaleoff_merchant(Double saleoff_merchant) {
		this.saleoff_merchant = saleoff_merchant;
	}
	/**
	 * @return the savepoint_at_swt
	 */
	public Double getSavepoint_at_swt() {
		return savepoint_at_swt;
	}
	/**
	 * @param savepoint_at_swt the savepoint_at_swt to set
	 */
	public void setSavepoint_at_swt(Double savepoint_at_swt) {
		this.savepoint_at_swt = savepoint_at_swt;
	}
	/**
	 * @return the savepoint_at_merchant
	 */
	public Double getSavepoint_at_merchant() {
		return savepoint_at_merchant;
	}
	/**
	 * @param savepoint_at_merchant the savepoint_at_merchant to set
	 */
	public void setSavepoint_at_merchant(Double savepoint_at_merchant) {
		this.savepoint_at_merchant = savepoint_at_merchant;
	}
	/**
	 * @return the saleoff_swt
	 */
	public Double getSaleoff_swt() {
		return saleoff_swt;
	}
	/**
	 * @param saleoff_swt the saleoff_swt to set
	 */
	public void setSaleoff_swt(Double saleoff_swt) {
		this.saleoff_swt = saleoff_swt;
	}
	/**
	 * @return the transaction_id
	 */
	public long getTransaction_id() {
		return transaction_id;
	}
	/**
	 * @param transaction_id the transaction_id to set
	 */
	public void setTransaction_id(long transaction_id) {
		this.transaction_id = transaction_id;
	}
	/**
	 * @return the payment
	 */
	public Double getPayment() {
		return payment;
	}
	/**
	 * @param payment the payment to set
	 */
	public void setPayment(Double payment) {
		this.payment = payment;
	}
	/**
	 * @return the merchant_acc_point_id
	 */
	public long getMerchant_acc_point_id() {
		return merchant_acc_point_id;
	}
	/**
	 * @param merchant_acc_point_id the merchant_acc_point_id to set
	 */
	public void setMerchant_acc_point_id(long merchant_acc_point_id) {
		this.merchant_acc_point_id = merchant_acc_point_id;
	}
	/**
	 * @return the swt_acc_id
	 */
	public long getSwt_acc_id() {
		return swt_acc_id;
	}
	/**
	 * @param swt_acc_id the swt_acc_id to set
	 */
	public void setSwt_acc_id(long swt_acc_id) {
		this.swt_acc_id = swt_acc_id;
	}
	
	

}
