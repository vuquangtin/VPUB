/**
 * 
 */
package com.swt.sworld.cms.domain;

import java.io.Serializable;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.Table;


/**
 * @author loc.le
 *
 */

@Entity
@Table(name = "swtgp_cms_suborganization")

public class SubOrganization implements Serializable {
	/**
	 * 
	 */
	private static final long serialVersionUID = 4673094961124740876L;
	
	@Id 
	@GeneratedValue
	@Column(name = "suborgid",  nullable = false)
	private long suborgid ;
	
	@Column(name = "orgid", nullable = false)
	private long orgid;
	
	@Column(name = "orgcode", length=45, nullable = false)
	private String orgcode;

	@Column(name = "parentorgid")
	private long parentOrgId; 
	
	@Column(name = "orgshortname", length=45, nullable = false)
	private String orgshortname;
	
	@Column(name = "names", length=250,  nullable = false)
	private String names;
	
	@Column(name = "shortname", length=250)
	private String shortname;
	
	@Column(name = "address", length=250)
	private String address;
	
	@Column(name = "city", length=45)
	private String city;
	
	@Column(name = "state", length=45)
	private String State;
	
	@Column(name = "countrycode", length=20)
	private String countrycode;
	
	@Column(name = "zipcode", length=45)
	private String zipcode;
	
	@Column(name = "fax", length=45)
	private String fax;
	
	@Column(name = "email", length=45)
	private String email;
	
	@Column(name = "phone", length=45)
	private String phone;
	
	@Column(name = "website", length=45)
	private String website;
	
	@Column(name = "contactname", length=45)
	private String contactname;
	
	@Column(name = "contactemail", length=45)
	private String contactemail;
	
	@Column(name = "contactphone", length=45)
	private String contactphone;
	
	@Column(name = "notes", length=45)
	private String notes;
	
	@Column(name = "settlementemail", length=45)
	private String settlementemail;

	@Column(name = "createdby", length=20)
	private String createdby;
	
	@Column(name = "createdon", length=20)
	private String createdon;
	
	@Column(name = "modifiedby", length=20)
	private String modifiedby;
	
	@Column(name = "modifiedon", length=20)
	private String modifiedon;
	
	@Column(name = "transferDate", length=30)
	private String transferDate;
	
	@Column(name = "status")
	private int status;
	
	@Column(name = "SwtGroup", length=50)
	private String SwtGroup;

	public long getSuborgid() {
		return suborgid;
	}

	public void setSuborgid(long suborgid) {
		this.suborgid = suborgid;
	}

	public long getOrgid() {
		return orgid;
	}

	public void setOrgid(long orgid) {
		this.orgid = orgid;
	}
	
	public long getParentOrgId() {
		return parentOrgId;
	}

	public void setParentOrgId(long parentOrgId) {
		this.parentOrgId = parentOrgId;
	}

	public String getOrgcode() {
		return orgcode;
	}

	public void setOrgcode(String orgcode) {
		this.orgcode = orgcode;
	}

	public String getAddress() {
		return address;
	}

	public void setAddress(String address) {
		this.address = address;
	}

	public String getCity() {
		return city;
	}

	public void setCity(String city) {
		this.city = city;
	}

	public String getState() {
		return State;
	}

	public void setState(String state) {
		State = state;
	}

	public String getCountrycode() {
		return countrycode;
	}

	public void setCountrycode(String countrycode) {
		this.countrycode = countrycode;
	}

	public String getZipcode() {
		return zipcode;
	}

	public void setZipcode(String zipcode) {
		this.zipcode = zipcode;
	}

	public String getFax() {
		return fax;
	}

	public void setFax(String fax) {
		this.fax = fax;
	}

	public String getEmail() {
		return email;
	}

	public void setEmail(String email) {
		this.email = email;
	}

	public String getWebsite() {
		return website;
	}

	public void setWebsite(String website) {
		this.website = website;
	}

	public String getPhone() {
		return phone;
	}

	public void setPhone(String phone) {
		this.phone = phone;
	}

	public String getContactname() {
		return contactname;
	}

	public void setContactname(String contactname) {
		this.contactname = contactname;
	}

	public String getContactemail() {
		return contactemail;
	}

	public void setContactemail(String contactemail) {
		this.contactemail = contactemail;
	}

	public String getContactphone() {
		return contactphone;
	}

	public void setContactphone(String contactphone) {
		this.contactphone = contactphone;
	}

	public String getSettlementemail() {
		return settlementemail;
	}

	public void setSettlementemail(String settlementemail) {
		this.settlementemail = settlementemail;
	}

	public String getNotes() {
		return notes;
	}

	public void setNotes(String notes) {
		this.notes = notes;
	}

	public String getCreatedby() {
		return createdby;
	}

	public void setCreatedby(String createdby) {
		this.createdby = createdby;
	}

	public String getCreatedon() {
		return createdon;
	}

	public void setCreatedon(String createdon) {
		this.createdon = createdon;
	}

	public String getModifiedby() {
		return modifiedby;
	}

	public void setModifiedby(String modifiedby) {
		this.modifiedby = modifiedby;
	}

	public String getModifiedon() {
		return modifiedon;
	}

	public void setModifiedon(String modifiedon) {
		this.modifiedon = modifiedon;
	}

	public int getStatus() {
		return status;
	}

	public void setStatus(int status) {
		this.status = status;
	}

	/**
	 * @return the swtGroup
	 */
	public String getSwtGroup() {
		return SwtGroup;
	}

	/**
	 * @param swtGroup the swtGroup to set
	 */
	public void setSwtGroup(String swtGroup) {
		SwtGroup = swtGroup;
	}
	
	public String getTransferDate() {
		return transferDate;
	}

	public void setTransferDate(String transferDate) {
		this.transferDate = transferDate;
	}

	/**
	 * @return the shortname
	 */
	public String getShortname() {
		return shortname;
	}

	/**
	 * @param shortname the shortname to set
	 */
	public void setShortname(String shortname) {
		this.shortname = shortname;
	}
	
	/**
	 * @return the name
	 */
	public String getNames() {
		return names;
	}

	/**
	 * @param nameSWT the nameSWT to set
	 */
	public void setNames(String names) {
		this.names = names;
	}

	public String getOrgshortname() {
		return orgshortname;
	}

	public void setOrgshortname(String orgshortname) {
		this.orgshortname = orgshortname;
	}
}
