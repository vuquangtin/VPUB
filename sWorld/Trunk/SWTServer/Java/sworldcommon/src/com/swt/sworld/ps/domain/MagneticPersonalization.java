/**
 * 
 */
package com.swt.sworld.ps.domain;

import java.io.Serializable;

import javax.persistence.*;

/**
 * @author sangdb
 *
 */

@Entity
@Table(name = "swtgp_ps_magnetic_personalization")
public class MagneticPersonalization implements Serializable {
	/**
	 * 
	 */
	private static final long serialVersionUID = 5653065795236202700L;

	
	
	@Id 
	@GeneratedValue
	@Column(name = "MagneticPersId", nullable = false) 
	private long MagneticPersId ;
	
	@Column(name = "CardMagneticId", nullable = false)
	private long CardMagneticId ;
	
	@Column(name = "MemberId")
	private long MemberId ;
	
	@Column(name ="SerialCard", length=45)
	private String SerialCard ;
		
	@Column(name = "FullName", length=100)
	private String FullName ;
	
	@Column(name = "CompayName", length=255)
    private String CompayName;
	
	@Column(name = "PhoneNumber", length=255)
    private String PhoneNumber;
	
	@Column(name = "TrackData", length=500)
	private String TrackData;
	
	@Column(name = "PinCodeNew", length=255)
    private String PinCodeNew ;
	
	@Column(name = "ActiveCodeNew", length=255)
    private String ActiveCodeNew ;
	
	@Column(name = "PersoDate")
	private String PersoDate ;
	
	@Column(name = "ExpirationDate")
	private String ExpirationDate ;
	
	@Column(name = "Notes", length=255)
    private String Notes ;
	
	@Column(name = "PreFix", length=5)
    private String PreFix ;
	
	@Column(name = "Status")
	private int Status ;
    
	/**
	 * @return the magneticPersId
	 */
	public long getMagneticPersId() {
		return MagneticPersId;
	}

	/**
	 * @param magneticPersId the magneticPersId to set
	 */
	public void setMagneticPersId(long magneticPersId) {
		MagneticPersId = magneticPersId;
	}

	/**
	 * @return the cardMagneticId
	 */
	public long getCardMagneticId() {
		return CardMagneticId;
	}

	/**
	 * @param cardMagneticId the cardMagneticId to set
	 */
	public void setCardMagneticId(long cardMagneticId) {
		CardMagneticId = cardMagneticId;
	}

	/**
	 * @return the serialCard
	 */
	public String getSerialCard() {
		return SerialCard;
	}

	/**
	 * @param serialCard the serialCard to set
	 */
	public void setSerialCard(String serialCard) {
		SerialCard = serialCard;
	}

	/**
	 * @return the fullName
	 */
	public String getFullName() {
		return FullName;
	}

	/**
	 * @param fullName the fullName to set
	 */
	public void setFullName(String fullName) {
		FullName = fullName;
	}

	/**
	 * @return the compayName
	 */
	public String getCompayName() {
		return CompayName;
	}

	/**
	 * @param compayName the compayName to set
	 */
	public void setCompayName(String compayName) {
		CompayName = compayName;
	}

	/**
	 * @return the phoneNumber
	 */
	public String getPhoneNumber() {
		return PhoneNumber;
	}

	/**
	 * @param phoneNumber the phoneNumber to set
	 */
	public void setPhoneNumber(String phoneNumber) {
		PhoneNumber = phoneNumber;
	}

	/**
	 * @return the trackData
	 */
	public String getTrackData() {
		return TrackData;
	}

	/**
	 * @param trackData the trackData to set
	 */
	public void setTrackData(String trackData) {
		TrackData = trackData;
	}

	/**
	 * @return the pinCodeNew
	 */
	public String getPinCodeNew() {
		return PinCodeNew;
	}

	/**
	 * @param pinCodeNew the pinCodeNew to set
	 */
	public void setPinCodeNew(String pinCodeNew) {
		PinCodeNew = pinCodeNew;
	}

	/**
	 * @return the activeCodeNew
	 */
	public String getActiveCodeNew() {
		return ActiveCodeNew;
	}

	/**
	 * @param activeCodeNew the activeCodeNew to set
	 */
	public void setActiveCodeNew(String activeCodeNew) {
		ActiveCodeNew = activeCodeNew;
	}

	/**
	 * @return the persoDate
	 */
	public String getPersoDate() {
		return PersoDate;
	}

	/**
	 * @param persoDate the persoDate to set
	 */
	public void setPersoDate(String persoDate) {
		PersoDate = persoDate;
	}

	/**
	 * @return the expirationDate
	 */
	public String getExpirationDate() {
		return ExpirationDate;
	}

	/**
	 * @param expirationDate the expirationDate to set
	 */
	public void setExpirationDate(String expirationDate) {
		ExpirationDate = expirationDate;
	}

	/**
	 * @return the notes
	 */
	public String getNotes() {
		return Notes;
	}

	/**
	 * @param notes the notes to set
	 */
	public void setNotes(String notes) {
		Notes = notes;
	}


	

	/**
	 * @return the memberId
	 */
	public long getMemberId() {
		return MemberId;
	}

	/**
	 * @param memberId the memberId to set
	 */
	public void setMemberId(long memberId) {
		MemberId = memberId;
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
	 * @return the preFix
	 */
	public String getPreFix() {
		return PreFix;
	}

	/**
	 * @param preFix the preFix to set
	 */
	public void setPreFix(String preFix) {
		PreFix = preFix;
	}

	
}

	
	