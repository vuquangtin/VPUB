package com.swt.meeting.domain;

import java.io.Serializable;
import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity
@Table(name = "swt_smeeting_journalist")
public class JournaList implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	@Id
	@GeneratedValue

	private long id;
	@Column(name = "serialnumber", length = 30)
	private String serialNumber;
	@Column(name = "orgid")
	private long OrgId;
	@Column(name = "companyname")
	private String OrgName;
	@Column(name = "lowerfullname")
	private String LowerFullName;
	@Column(name = "email")
	private String Email;
	@Column(name = "position")
	private String Position;
	@Column(name = "phoneno")
	private String PhoneNo;
	@Column(name = "birthdate")
	private Date BirthDate;
	@Column(name = "identitycard")
	private String IdentityCard;

	public long getId() {
		return id;
	}

	public void setId(long id) {
		this.id = id;
	}

	public String getSerialNumber() {
		return serialNumber;
	}

	public void setSerialNumber(String serialNumber) {
		this.serialNumber = serialNumber;
	}

	public long getOrgId() {
		return OrgId;
	}

	public void setOrgId(long orgId) {
		OrgId = orgId;
	}

	public String getOrgName() {
		return OrgName;
	}

	public void setOrgName(String orgName) {
		OrgName = orgName;
	}

	public String getLowerFullName() {
		return LowerFullName;
	}

	public void setLowerFullName(String lowerFullName) {
		LowerFullName = lowerFullName;
	}

	public String getEmail() {
		return Email;
	}

	public void setEmail(String email) {
		Email = email;
	}

	public String getPosition() {
		return Position;
	}

	public void setPosition(String position) {
		Position = position;
	}

	public String getPhoneNo() {
		return PhoneNo;
	}

	public void setPhoneNo(String phoneNo) {
		PhoneNo = phoneNo;
	}

	public Date getBirthDate() {
		return BirthDate;
	}

	public void setBirthDate(Date birthDate) {
		BirthDate = birthDate;
	}

	public String getIdentityCard() {
		return IdentityCard;
	}

	public void setIdentityCard(String identityCard) {
		IdentityCard = identityCard;
	}

	public static long getSerialversionuid() {
		return serialVersionUID;
	}

}
