/**
 * 
 */
package com.swt.sworld.communication.customer.object;

import java.io.Serializable;

/**
 * @author Administrator
 *
 */
public class CardmagneticDTO implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = 5915226091150287266L;
	
	private long MagneticId ;
	private long OrgMasterId ;
	private long OrgPartnerId ;
	private String  MasterCode ;
	private String PartnerCode ;
	private String OrgName ;
	private String SubOrgName ;
	private String FullName ;
	private String Company ;
	private String PhoneNumber ;
	private String TrackData ;
	private String SerialCard ;
	private String PinCode ;
	private String ActiveCode ;
	private String TypeCrypto ;
	private String StartDate ;
	private String ExpireDate ;
	private int Status ;
	private int PrintStatus ;
	private int PhysicalStatus ;
	private String cardtypes ;
	private String Notes ;
	/**
	 * @return the magneticId
	 */
	public long getMagneticId() {
		return MagneticId;
	}
	/**
	 * @param magneticId the magneticId to set
	 */
	public void setMagneticId(long magneticId) {
		MagneticId = magneticId;
	}
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
	 * @return the company
	 */
	public String getCompany() {
		return Company;
	}
	/**
	 * @param company the company to set
	 */
	public void setCompany(String company) {
		Company = company;
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
	 * @return the pinCode
	 */
	public String getPinCode() {
		return PinCode;
	}
	/**
	 * @param pinCode the pinCode to set
	 */
	public void setPinCode(String pinCode) {
		PinCode = pinCode;
	}
	/**
	 * @return the activeCode
	 */
	public String getActiveCode() {
		return ActiveCode;
	}
	/**
	 * @param activeCode the activeCode to set
	 */
	public void setActiveCode(String activeCode) {
		ActiveCode = activeCode;
	}
	/**
	 * @return the typeCrypto
	 */
	public String getTypeCrypto() {
		return TypeCrypto;
	}
	/**
	 * @param typeCrypto the typeCrypto to set
	 */
	public void setTypeCrypto(String typeCrypto) {
		TypeCrypto = typeCrypto;
	}
	/**
	 * @return the startDate
	 */
	public String getStartDate() {
		return StartDate;
	}
	/**
	 * @param startDate the startDate to set
	 */
	public void setStartDate(String startDate) {
		StartDate = startDate;
	}
	/**
	 * @return the expireDate
	 */
	public String getExpireDate() {
		return ExpireDate;
	}
	/**
	 * @param expireDate the expireDate to set
	 */
	public void setExpireDate(String expireDate) {
		ExpireDate = expireDate;
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
	 * @return the printStatus
	 */
	public int getPrintStatus() {
		return PrintStatus;
	}
	/**
	 * @param printStatus the printStatus to set
	 */
	public void setPrintStatus(int printStatus) {
		PrintStatus = printStatus;
	}
	/**
	 * @return the physicalStatus
	 */
	public int getPhysicalStatus() {
		return PhysicalStatus;
	}
	/**
	 * @param physicalStatus the physicalStatus to set
	 */
	public void setPhysicalStatus(int physicalStatus) {
		PhysicalStatus = physicalStatus;
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

}
