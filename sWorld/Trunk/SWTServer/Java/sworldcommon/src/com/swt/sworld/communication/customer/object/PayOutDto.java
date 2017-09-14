package com.swt.sworld.communication.customer.object;

import java.io.Serializable;

/**
 * @author Hoang Ha
 * 
 */
/**
* <summary>
* 	Thực hiện quy trình trừ tiền trong thẻ gồm 3 giai đoạn:
* 	1. Kiểm tra tính hiệu lực và xác thực của thẻ (đã xác thực bước 7.1)
*	2. Ghi Log Request Client yêu cầu trừ tiền
* 	3. Ghi Log Request Success Client đã trừ tiền vào thẻ thành công
* </summary>
*/

@SuppressWarnings("serial")
public class PayOutDto implements Serializable{

	public long Id;

	/*
	 * <summary> Id của Log Request </summary>
	 */
    public long PayOutParentId;
    public long PartnerId;
    public long MemberId;

    /* 
	 * <summary>  </summary>
	 */
	private long AppId;
	
	/* 
	 * <summary> Địa chỉ IP của máy trạm thực hiện giao dịch </summary>
	 */
	private String UnitCode;
	
    public String SerialNumber;

    /*
    * <summary>
    * 		Số tiền được trừ trong thẻ
    * </summary>
    */
    public double Amount;
    public String PayOutDate;

    /*
    * <summary>
    * Username thực hiện yêu cầu trừ tiền
    * </summary>
    */
    public String Owner;

    /*
    * <summary>
    * 		Dữ liệu được ghi vào sector 12 của thẻ
    * </summary>
    */
    public String DataWriteToCard;

    /*
    * <summary>
    * 		KeyB của sector 12
    *</summary>
    */
    public String KeyB;

    /*
    * <summary>
    *		Mã xác nhận của bên thứ 3 (VD: ngân hàng)
    * </summary>
    */
    public String VerificationCode;

    /*
    * <summary>
    *		Lưu số lần đồng bộ dữ liệu
    * </summary>
    */
    public int SnysDataNumber;

    /*
    * <summary>
    * 0: Successful
    * 1: Processing
    * 3: LockMoneyCard
    * </summary>
    */
    public int Status;

	public long getId() {
		return Id;
	}

	public void setId(long id) {
		Id = id;
	}

	public long getPayOutParentId() {
		return PayOutParentId;
	}

	public void setPayOutParentId(long payOutParentId) {
		PayOutParentId = payOutParentId;
	}

	public long getPartnerId() {
		return PartnerId;
	}

	public void setPartnerId(long partnerId) {
		PartnerId = partnerId;
	}

	public long getMemberId() {
		return MemberId;
	}

	public void setMemberId(long memberId) {
		MemberId = memberId;
	}

	public long getAppId() {
		return AppId;
	}

	public void setAppId(long appId) {
		AppId = appId;
	}

	public String getUnitCode() {
		return UnitCode;
	}

	public void setUnitCode(String unitCode) {
		UnitCode = unitCode;
	}

	public String getSerialNumber() {
		return SerialNumber;
	}

	public void setSerialNumber(String serialNumber) {
		SerialNumber = serialNumber;
	}

	public double getAmount() {
		return Amount;
	}

	public void setAmount(double amount) {
		Amount = amount;
	}

	public String getPayOutDate() {
		return PayOutDate;
	}

	public void setPayOutDate(String payOutDate) {
		PayOutDate = payOutDate;
	}

	public String getOwner() {
		return Owner;
	}

	public void setOwner(String owner) {
		Owner = owner;
	}

	public String getDataWriteToCard() {
		return DataWriteToCard;
	}

	public void setDataWriteToCard(String dataWriteToCard) {
		DataWriteToCard = dataWriteToCard;
	}

	public String getKeyB() {
		return KeyB;
	}

	public void setKeyB(String keyB) {
		KeyB = keyB;
	}

	public String getVerificationCode() {
		return VerificationCode;
	}

	public void setVerificationCode(String verificationCode) {
		VerificationCode = verificationCode;
	}

	public int getSnysDataNumber() {
		return SnysDataNumber;
	}

	public void setSnysDataNumber(int snysDataNumber) {
		SnysDataNumber = snysDataNumber;
	}

	public int getStatus() {
		return Status;
	}

	public void setStatus(int status) {
		Status = status;
	}
    
}
