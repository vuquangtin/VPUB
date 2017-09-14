/**
 * 
 */
package com.swt.sworld.communication.customer.object;

import java.io.Serializable;

/**
 * @author Administrator
 *
 */
public class MagneticPersonalizationDTO implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = -7908628885891564515L;
	
	private long OrgMasterId ;
	private long OrgPartnerId ;
    private String MasterCode ;
    private String PartnerCode ;
    private String OrgName ;
    private String SubOrgName ;
    private long MagneticPersId ;
    private long CardMagneticId ;
    private long MemberId ;
    private String FullName ;
    private String CompayName ;
    private String PhoneNumber ;
    private String SerialCard ;
    private String TrackData ;
    private String PinCodeNew ;
    private String ActiveCodeNew ;
    private String PersoDate ;
    private String ExpirationDate ;
    private int Status ;
    private String Notes ;
    private String cardtypes ;
	/**
	 * @return the orgMasterId
	 */
	public long getOrgMasterId() {
		return OrgMasterId;
	}
	/**
	 * @param orgMasterId the orgMasterId to set
	 */
	public void setOrgMasterId(long orgMasterId) {
		OrgMasterId = orgMasterId;
	}
	/**
	 * @return the orgPartnerId
	 */
	public long getOrgPartnerId() {
		return OrgPartnerId;
	}
	/**
	 * @param orgPartnerId the orgPartnerId to set
	 */
	public void setOrgPartnerId(long orgPartnerId) {
		OrgPartnerId = orgPartnerId;
	}
	/**
	 * @return the masterCode
	 */
	public String getMasterCode() {
		return MasterCode;
	}
	/**
	 * @param masterCode the masterCode to set
	 */
	public void setMasterCode(String masterCode) {
		MasterCode = masterCode;
	}
	/**
	 * @return the partnerCode
	 */
	public String getPartnerCode() {
		return PartnerCode;
	}
	/**
	 * @param partnerCode the partnerCode to set
	 */
	public void setPartnerCode(String partnerCode) {
		PartnerCode = partnerCode;
	}
	/**
	 * @return the orgName
	 */
	public String getOrgName() {
		return OrgName;
	}
	/**
	 * @param orgName the orgName to set
	 */
	public void setOrgName(String orgName) {
		OrgName = orgName;
	}
	/**
	 * @return the subOrgName
	 */
	public String getSubOrgName() {
		return SubOrgName;
	}
	/**
	 * @param subOrgName the subOrgName to set
	 */
	public void setSubOrgName(String subOrgName) {
		SubOrgName = subOrgName;
	}
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
	 * @return the cardtypes
	 */
	public String getCardtypes() {
		return cardtypes;
	}
	/**
	 * @param cardtypes the cardtypes to set
	 */
	public void setCardtypes(String cardtypes) {
		this.cardtypes = cardtypes;
	}

}
