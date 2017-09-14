package com.swt.sworld.communication.customer.object;

import java.io.Serializable;

/**
 * @author Hoang Ha
 * 
 */
/**
* <summary>
* 	Thực hiện quy trình nạp tiền mặt vào thẻ gồm 3 giai đoạn:
* 	1. Kiểm tra tính hiệu lực và xác thực của thẻ (đã xác thực bước 7.1)
*	2. Ghi Log Request Client yêu cầu nạp tiền
* 	3. Ghi Log Request Success Client đã nạp tiền vào thẻ thành công
* </summary>
*/
@SuppressWarnings("serial")
public class PayInDto implements Serializable{

	public long Id;

	/*
	 * <summary> Id của Log Request </summary>
	 */
	public long PayInParentId;

	/*
	 * <summary> Khi thưc hiện quy trình tất toán mới lưu SettlementId, Mục đích để quản lý quy trình tất toán </summary>
	 */
	public long SettlementId;
	
	public long PartnerId;
	
	public long MemberId;
	  
	/* 
	 * <summary> Địa chỉ IP của máy trạm thực hiện giao dịch </summary>
	 */
	public String IpAddress;
	
	public String SerialNumber;

	/*
	 * <summary> Số tiền được nạp vào thẻ </summary>
	 */
	public double Amount;
	
	public String PayInDate;

	/*
	 * <summary> Username thực hiện yêu cầu nạp tiền </summary>
	 */
	public String Owner;

	/*
	 * <summary> Dữ liệu được ghi vào sector 11 của thẻ (dữ liệu này đã được mã hóa) </summary>
	 */
	public String DataWriteToCard;

	/*
	 * <summary> KeyB của sector 11 </summary>
	 */
	public String KeyB;

	/*
	 * <summary> Mã xác thực của bên thứ 3 (VD: ngân hàng) </summary>
	 */
	public String VerificationCode;

	/*
	 * <summary> Lưu số lần đồng bộ dữ liệu </summary>
	 */
	public int SnysDataNumber;

	/*
	 * <summary> 0: Successful 1: Processing 3: LockMoneyCard </summary>
	 */
	public int Status;

	public long getId() {
		return Id;
	}

	public void setId(long id) {
		Id = id;
	}

	public long getPayInParentId() {
		return PayInParentId;
	}

	public void setPayInParentId(long payInParentId) {
		PayInParentId = payInParentId;
	}

	public long getSettlementId() {
		return SettlementId;
	}

	public void setSettlementId(long settlementId) {
		SettlementId = settlementId;
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

	public String getIpAddress() {
		return IpAddress;
	}

	public void setIpAddress(String ipAddress) {
		IpAddress = ipAddress;
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

	public String getPayInDate() {
		return PayInDate;
	}

	public void setPayInDate(String payInDate) {
		PayInDate = payInDate;
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
