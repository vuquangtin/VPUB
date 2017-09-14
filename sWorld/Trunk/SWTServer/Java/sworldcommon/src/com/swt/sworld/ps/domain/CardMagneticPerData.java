/**
 * 
 */
package com.swt.sworld.ps.domain;

import java.io.Serializable;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.Table;

/**
 * @author Administrator
 *
 */

@Entity
@Table(name = "swtgp_ps_magnetic_personalization")
public class CardMagneticPerData implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = -4245782086567851567L;

	
	@Id
	@GeneratedValue
	@Column(name = "MagneticPersId", nullable = false)
	private long MagneticPersId ;
	
	@Column(name = "CardMagneticId", nullable = false)
	private long CardMagneticId ;
	
	@Column(name = "SerialCard", nullable = false)
	private String SerialCard ;
	
	
	@Column(name = "FullName", length =100)
	private String FullName ;
	
	@Column(name = "Company", length =255)
	private String Company ;
	
	@Column(name = "PhoneNumber", length =45)
	private String PhoneNumber ;
	
	@Column(name = "Track1Data",length =255, nullable = false)
	private String Track1Data ;
	
	@Column(name = "Track2Data", length =255)
	private String Track2Data ;
	
	@Column(name = "Track3Data", length =107)
	private String Track3Data ;
	
	@Column(name = "PinCodeNew", length =6)
	private String PinCodeNew ;
	
	@Column(name = "ActivePinCodeNew", length =10)
	private String ActiveCodeNew ;
	
	@Column(name = "TypeCrypto", length = 45)
	private String TypeCrypto ;
	
	@Column(name = "StartDate", length = 10)
	private String StartDate;
	
	@Column(name = "ExpireDate", length = 10)
	private String ExpireDate;
	
	@Column(name = "Notes")
	private String Notes ;
	
	@Column(name = "Status")
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
