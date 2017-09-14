/**
 * 
 */
package com.swt.sworld.communication.customer.object;

import java.io.Serializable;

/**
 * @author Administrator
 *
 */
public class CardMagneticPerData implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = -4245782086567851567L;

	private long MagneticPersId ;
	private long CardMagneticId ;
	private String SerialCard ;
	private String FullName ;
	private String Company ;
	private String PhoneNumber ;
	private String Track1Data ;
	private String Track2Data ;
	private String Track3Data ;
	private String PinCodeNew ;
	private String ActiveCodeNew ;
	private String TypeCrypto ;
	private String StartDate;
	private String ExpireDate;
	private String Notes ;
	private int Status ;

	public long getMagneticPersId() {
		return MagneticPersId;
	}

	public void setMagneticPersId(long magneticPersId) {
		MagneticPersId = magneticPersId;
	}

	public long getCardMagneticId() {
		return CardMagneticId;
	}

	public void setCardMagneticId(long cardMagneticId) {
		CardMagneticId = cardMagneticId;
	}

	public String getSerialCard() {
		return SerialCard;
	}

	public void setSerialCard(String serialCard) {
		SerialCard = serialCard;
	}

	public String getFullName() {
		return FullName;
	}

	public void setFullName(String fullName) {
		FullName = fullName;
	}

	public String getCompany() {
		return Company;
	}

	public void setCompany(String company) {
		Company = company;
	}

	public String getPhoneNumber() {
		return PhoneNumber;
	}

	public void setPhoneNumber(String phoneNumber) {
		PhoneNumber = phoneNumber;
	}

	public String getTrack1Data() {
		return Track1Data;
	}

	public void setTrack1Data(String track1Data) {
		Track1Data = track1Data;
	}

	public String getTrack2Data() {
		return Track2Data;
	}

	public void setTrack2Data(String track2Data) {
		Track2Data = track2Data;
	}

	public String getTrack3Data() {
		return Track3Data;
	}

	public void setTrack3Data(String track3Data) {
		Track3Data = track3Data;
	}

	public String getPinCodeNew() {
		return PinCodeNew;
	}

	public void setPinCodeNew(String pinCodeNew) {
		PinCodeNew = pinCodeNew;
	}

	public String getActiveCodeNew() {
		return ActiveCodeNew;
	}

	public void setActiveCodeNew(String activeCodeNew) {
		ActiveCodeNew = activeCodeNew;
	}

	public String getTypeCrypto() {
		return TypeCrypto;
	}

	public void setTypeCrypto(String typeCrypto) {
		TypeCrypto = typeCrypto;
	}

	public String getStartDate() {
		return StartDate;
	}

	public void setStartDate(String startDate) {
		StartDate = startDate;
	}

	public String getExpireDate() {
		return ExpireDate;
	}

	public void setExpireDate(String expireDate) {
		ExpireDate = expireDate;
	}

	public String getNotes() {
		return Notes;
	}

	public void setNotes(String notes) {
		Notes = notes;
	}

	public int getStatus() {
		return Status;
	}

	public void setStatus(int status) {
		Status = status;
	}

	
}
