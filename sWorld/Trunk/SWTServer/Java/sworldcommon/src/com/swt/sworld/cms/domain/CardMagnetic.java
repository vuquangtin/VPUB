/**
 * 
 */
package com.swt.sworld.cms.domain;

import java.io.Serializable;

import javax.persistence.*;

/**
 * @author LOCVIP
 *
 */

@Entity
@Table(name = "swtgp_cms_cardmagnetic")
public class CardMagnetic implements Serializable {
	
	/**
	 * 
	 */
	private static final long serialVersionUID = -153036127030591311L;

	@Id
	@GeneratedValue
	@Column(name = "MagneticId", nullable = false)
	private long MagneticId ;
	
	@Column(name = "OrgMasterId")
	private long OrgMasterId ;
	
	@Column(name = "OrgPartnerId")
	private long OrgPartnerId ;
	
	@Column(name = "MasterCode")
	private String MasterCode ;
	
	@Column(name = "PartnerCode")
	private String PartnerCode ;
	
	@Column(name = "SubOrgId")
	private long SubOrgId ;
	
	@Column(name = "CardNumber", nullable = false)
	private String CardNumber ;
	
	
	
	@Column(name = "FullName", length =100)
	private String FullName ;
	
	@Column(name = "Company", length =255)
	private String Company ;
	
	
	@Column(name = "PhoneNumber", length =45)
	private String PhoneNumber ;
	
	
	@Column(name = "TrackData", length = 500)
	private String TrackData ;
	
	@Column(name = "PinCode", length =6)
	private String PinCode ;
	
	@Column(name = "ActiveCode", length =10)
	private String ActiveCode ;
	
	@Column(name = "TypeCrypto", length = 45)
	private String TypeCrypto ;
	
	@Column(name = "StartDate", length = 10)
	private String StartDate;
	
	@Column(name = "ExpireDate", length = 10)
	private String ExpireDate;
	
	@Column(name = "Status")
	private int Status ;
	
	@Column(name = "PhysicalStatus")
	private int PhysicalStatus ;
	
	@Column(name = "PrintedStatus")
	private int PrintedStatus ;
	
	@Column(name = "PrefixCard", length =4)
	private String PrefixCard ;
	
	@Column(name = "Notes", length =255)
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
	 * @return the cardNumber
	 */
	public String getCardNumber() {
		return CardNumber;
	}

	/**
	 * @param cardNumber the cardNumber to set
	 */
	public void setCardNumber(String cardNumber) {
		CardNumber = cardNumber;
	}

	/**
	 * @return the track1Data
	 */
	public String getTrackData() {
		return TrackData;
	}

	/**
	 * @param track1Data the track1Data to set
	 */
	public void setTrack1Data(String track1Data) {
		TrackData = track1Data;
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
	 * @return the logicalStatus
	 */
	public int getStatus() {
		return Status;
	}

	/**
	 * @param logicalStatus the logicalStatus to set
	 */
	public void setStatus(int status) {
		Status = status;
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

	public String getMasterCode() {
		return MasterCode;
	}

	public void setMasterCode(String masterCode) {
		MasterCode = masterCode;
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

	/**
	 * @return the prefixCard
	 */
	public String getPrefixCard() {
		return PrefixCard;
	}

	/**
	 * @param prefixCard the prefixCard to set
	 */
	public void setPrefixCard(String prefixCard) {
		PrefixCard = prefixCard;
	}

	/**
	 * @return the printedStatus
	 */
	public int getPrintedStatus() {
		return PrintedStatus;
	}

	/**
	 * @param printedStatus the printedStatus to set
	 */
	public void setPrintedStatus(int printedStatus) {
		PrintedStatus = printedStatus;
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
	 * @return the subOrgId
	 */
	public long getSubOrgId() {
		return SubOrgId;
	}

	/**
	 * @param subOrgId the subOrgId to set
	 */
	public void setSubOrgId(long subOrgId) {
		SubOrgId = subOrgId;
	}

	

}
