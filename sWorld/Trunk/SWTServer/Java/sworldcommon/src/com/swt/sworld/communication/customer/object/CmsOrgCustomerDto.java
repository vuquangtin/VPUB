/**
 * 
 */
package com.swt.sworld.communication.customer.object;

import java.io.Serializable;

/**
 * @author Administrator
 *
 */
public class CmsOrgCustomerDto implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = -7357847394560125597L;
	
	private long OrgId ;
	private String OrgCode ;
	private String OrgShortName ;
	private String Name ;
    private String Address ;
    private String Issuer ;
    private String City ;
    private String State ;
    private String CountryCode ;
    private String ZipCode ;
    private String Fax ;
    private String Phone ;
    private String Email ;
    private String WebSite ;
    private String ContactName ;
    private String ContactEmail ;
    private String ContactPhone ;
    private String ContactMobile ;
    private String ContactFax ;
    private String Notes ;
    private String SettlementEmail ;
    private String SettlementFrequency ;
    private int Status ;
	/**
	 * @return the orgId
	 */
	public long getOrgId() {
		return OrgId;
	}
	/**
	 * @param orgId the orgId to set
	 */
	public void setOrgId(long orgId) {
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
	 * @return the issuer
	 */
	public String getIssuer() {
		return Issuer;
	}
	/**
	 * @param issuer the issuer to set
	 */
	public void setIssuer(String issuer) {
		Issuer = issuer;
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
	 * @return the contactFax
	 */
	public String getContactFax() {
		return ContactFax;
	}
	/**
	 * @param contactFax the contactFax to set
	 */
	public void setContactFax(String contactFax) {
		ContactFax = contactFax;
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

}
