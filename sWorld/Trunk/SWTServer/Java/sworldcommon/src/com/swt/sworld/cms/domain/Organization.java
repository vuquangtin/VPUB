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
@Table(name = "swtgp_cms_organization")
public class Organization implements Serializable {
	
	/**
	 * 
	 */
	private static final long serialVersionUID = -2333245588340203279L;

	@Id
	@GeneratedValue
	@Column(name = "OrgId")
	private long OrgId;

	@Column(name = "SecretKeyId")
	private long secretkeyid;
	
	
	@Column(name = "OrgCode", length = 50)
	private String OrgCode;
	
	@Column(name = "OrgShortName", length = 10)
	private String OrgShortName;
	
	@Column(name = "Name", length = 45)
	private String Name;
	
	@Column(name = "Address", length=255)
	private String Address;
	
	@Column(name = "Issuer", length=100)
	private String Issuer;
	
	@Column(name = "City", length=45)
	private String City;
	
	@Column(name = "State", length=45)
	private String State;
	
	@Column(name = "CountryCode", length=45)
	private String CountryCode;
	
	@Column(name = "ZipCode", length=45)
	private String ZipCode;
	
	@Column(name = "Fax", length=45)
	private String Fax;
	
	@Column(name = "Phone", length=45)
	private String Phone;
	
	@Column(name = "Email", length=45)
	private String Email;
	
	@Column(name = "WebSite", length=45)
	private String WebSite;
	
	@Column(name = "ContactName", length=45)
	private String ContactName;
	
	@Column(name = "ContactEmail", length=45)
	private String ContactEmail;
	
	@Column(name = "ContactPhone", length=45)
	private String ContactPhone;
	
	@Column(name = "ContactMobile", length=45)
	private String ContactMobile;
	
	@Column(name = "Notes", length=255)
	private String Notes;
	
	@Column(name = "SettlementEmail", length=45)
	private String SettlementEmail;
	
	@Column(name = "SettlementFrequency", length=45)
	private String SettlementFrequency;
	
	@Column(name = "CreatedBy", length=45)
	private String CreatedBy;
	
	@Column(name = "CreatedOn", length=45)
	private String CreatedOn;
	
	@Column(name = "ModifiedBy", length=45)
	private String ModifiedBy;
	
	@Column(name = "ModifiedOn", length=45)
	private String ModifiedOn;
	
	@Column(name = "Status")
	private int Status;
	
	

	/**
	 * @return the orgId
	 */
	public long getOrgId() {
		return OrgId;
	}

	/**
	 * @param orgId the orgId to set
	 */
	public void setOrgId(int orgId) {
		OrgId = orgId;
	}

	/**
	 * @return the orgCode
	 */
	public String getOrgCode() {
		return OrgCode;
	}

	/**
	 * @param orgCode the orgCode to set
	 */
	public void setOrgCode(String orgCode) {
		OrgCode = orgCode;
	}

	/**
	 * @return the orgShortName
	 */
	public String getOrgShortName() {
		return OrgShortName;
	}

	/**
	 * @param orgShortName the orgShortName to set
	 */
	public void setOrgShortName(String orgShortName) {
		OrgShortName = orgShortName;
	}

	/**
	 * @return the name
	 */
	public String getName() {
		return Name;
	}

	/**
	 * @param name the name to set
	 */
	public void setName(String name) {
		Name = name;
	}

	/**
	 * @return the address
	 */
	public String getAddress() {
		return Address;
	}

	/**
	 * @param address the address to set
	 */
	public void setAddress(String address) {
		Address = address;
	}

	

	/**
	 * @return the city
	 */
	public String getCity() {
		return City;
	}

	/**
	 * @param city the city to set
	 */
	public void setCity(String city) {
		City = city;
	}

	/**
	 * @return the state
	 */
	public String getState() {
		return State;
	}

	/**
	 * @param state the state to set
	 */
	public void setState(String state) {
		State = state;
	}

	/**
	 * @return the countryCode
	 */
	public String getCountryCode() {
		return CountryCode;
	}

	/**
	 * @param countryCode the countryCode to set
	 */
	public void setCountryCode(String countryCode) {
		CountryCode = countryCode;
	}

	/**
	 * @return the zipCode
	 */
	public String getZipCode() {
		return ZipCode;
	}

	/**
	 * @param zipCode the zipCode to set
	 */
	public void setZipCode(String zipCode) {
		ZipCode = zipCode;
	}

	/**
	 * @return the fax
	 */
	public String getFax() {
		return Fax;
	}

	/**
	 * @param fax the fax to set
	 */
	public void setFax(String fax) {
		Fax = fax;
	}

	/**
	 * @return the phone
	 */
	public String getPhone() {
		return Phone;
	}

	/**
	 * @param phone the phone to set
	 */
	public void setPhone(String phone) {
		Phone = phone;
	}

	/**
	 * @return the email
	 */
	public String getEmail() {
		return Email;
	}

	/**
	 * @param email the email to set
	 */
	public void setEmail(String email) {
		Email = email;
	}

	/**
	 * @return the webSite
	 */
	public String getWebSite() {
		return WebSite;
	}

	/**
	 * @param webSite the webSite to set
	 */
	public void setWebSite(String webSite) {
		WebSite = webSite;
	}

	/**
	 * @return the contactName
	 */
	public String getContactName() {
		return ContactName;
	}

	/**
	 * @param contactName the contactName to set
	 */
	public void setContactName(String contactName) {
		ContactName = contactName;
	}

	/**
	 * @return the contactEmail
	 */
	public String getContactEmail() {
		return ContactEmail;
	}

	/**
	 * @param contactEmail the contactEmail to set
	 */
	public void setContactEmail(String contactEmail) {
		ContactEmail = contactEmail;
	}

	/**
	 * @return the contactPhone
	 */
	public String getContactPhone() {
		return ContactPhone;
	}

	/**
	 * @param contactPhone the contactPhone to set
	 */
	public void setContactPhone(String contactPhone) {
		ContactPhone = contactPhone;
	}

	/**
	 * @return the contactMobile
	 */
	public String getContactMobile() {
		return ContactMobile;
	}

	/**
	 * @param contactMobile the contactMobile to set
	 */
	public void setContactMobile(String contactMobile) {
		ContactMobile = contactMobile;
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
	 * @return the settlementEmail
	 */
	public String getSettlementEmail() {
		return SettlementEmail;
	}

	/**
	 * @param settlementEmail the settlementEmail to set
	 */
	public void setSettlementEmail(String settlementEmail) {
		SettlementEmail = settlementEmail;
	}

	/**
	 * @return the settlementFrequency
	 */
	public String getSettlementFrequency() {
		return SettlementFrequency;
	}

	/**
	 * @param settlementFrequency the settlementFrequency to set
	 */
	public void setSettlementFrequency(String settlementFrequency) {
		SettlementFrequency = settlementFrequency;
	}

	/**
	 * @return the createdBy
	 */
	public String getCreatedBy() {
		return CreatedBy;
	}

	/**
	 * @param createdBy the createdBy to set
	 */
	public void setCreatedBy(String createdBy) {
		CreatedBy = createdBy;
	}

	/**
	 * @return the createdOn
	 */
	public String getCreatedOn() {
		return CreatedOn;
	}

	/**
	 * @param createdOn the createdOn to set
	 */
	public void setCreatedOn(String createdOn) {
		CreatedOn = createdOn;
	}

	/**
	 * @return the modifiedBy
	 */
	public String getModifiedBy() {
		return ModifiedBy;
	}

	/**
	 * @param modifiedBy the modifiedBy to set
	 */
	public void setModifiedBy(String modifiedBy) {
		ModifiedBy = modifiedBy;
	}

	/**
	 * @return the modifiedOn
	 */
	public String getModifiedOn() {
		return ModifiedOn;
	}

	/**
	 * @param modifiedOn the modifiedOn to set
	 */
	public void setModifiedOn(String modifiedOn) {
		ModifiedOn = modifiedOn;
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

	
	public long getSecretkeyid() {
		return secretkeyid;
	}

	public void setSecretkeyid(long secretkeyid) {
		this.secretkeyid = secretkeyid;
	}

	public String getIssuer() {
		return Issuer;
	}

	public void setIssuer(String issuer) {
		Issuer = issuer;
	}
}
