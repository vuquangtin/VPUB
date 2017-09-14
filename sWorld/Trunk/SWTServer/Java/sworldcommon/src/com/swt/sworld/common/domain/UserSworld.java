/**
 * 
 */
package com.swt.sworld.common.domain;

import java.io.Serializable;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Table;
import javax.persistence.Id;

/**
 * @author loc.le
 *
 */

@Entity
@Table(name = "swtgp_user")
public class UserSworld implements Serializable{
	
	/**
	 * 
	 */
	private static final long serialVersionUID = 7808988654280849920L;

	@Id
	@GeneratedValue
	@Column(name = "Id")
	private long id ;
	
	@Column(name = "GroupId", nullable = false)
	private long GroupId ;
	
	@Column(name = "Memberid", columnDefinition ="int default 0")
	private long memberid ;
	
	@Column(name = "UserName", nullable = false, length = 255)
	private String UserName ;
	
	@Column(name = "PasswordHash", length = 255)
	private String PasswordHash ;
	
	@Column(name = "Status", nullable = false)
	private int Status ;
	
	@Column(name = "OrgId", columnDefinition ="int default 0")
	private long orgId ;
	
	@Column(name = "IsRoot")
	private boolean IsRoot ;
	
	@Column(name = "FirstName", length=40)
	private String FirstName ;
	
	@Column(name = "LastName", length=40)
	private String LastName ;
	
	@Column(name = "BirthDate", length=40)
	private String BirthDate ;
	
	@Column(name = "Email", length=40)
	private String Email ;
	
	@Column(name = "PhoneNo", length=40)
	private String PhoneNo ;
	
	@Column(name = "Gender", length=40)
	private String Gender ;
	
	@Column(name = "IdCardIssuedDate", length=40)
	private String IdCardIssuedDate ;
	
	@Column(name = "IdCardIssuedPlace", length=40)
	private String IdCardIssuedPlace;
	
	@Column(name = "IdCardNo", length=40)
	private String IdCardNo ;
	
	@Column(name = "Nationality", length=100)
	private String Nationality ;
	
	@Column(name = "PermanentAddress", length=200)
	private String PermanentAddress ;
	
	@Column(name = "TemporaryAddress", length=200)
	private String TemporaryAddress ;
	
	@Column(name = "Salt", columnDefinition ="varchar(100)")
	private String salt;
	
	@Column(name = "Code" , columnDefinition ="varchar(50)")
	private String code;
	
	@Column(name = "Ip", columnDefinition = "varchar(25)")
	private String ip;
	
	@Column(name = "DateCreated", columnDefinition ="varchar(25)")
	private String date_created;
	
	@Column(name = "DateUpdated", columnDefinition ="varchar(25)")
	private String date_updated;
	
	@Column(name = "LocalCode", columnDefinition ="varchar(25)")
	private String local_code;

	public long getId() {
		return id;
	}

	public void setId(long id) {
		this.id = id;
	}

	public long getGroupId() {
		return GroupId;
	}

	public void setGroupId(long groupId) {
		GroupId = groupId;
	}

	public long getMemberid() {
		return memberid;
	}

	public void setMemberid(long memberid) {
		this.memberid = memberid;
	}

	public String getUserName() {
		return UserName;
	}

	public void setUserName(String userName) {
		UserName = userName;
	}

	public String getPasswordHash() {
		return PasswordHash;
	}

	public void setPasswordHash(String passwordHash) {
		PasswordHash = passwordHash;
	}

	public boolean isIsRoot() {
		return IsRoot;
	}

	public void setIsRoot(boolean isRoot) {
		IsRoot = isRoot;
	}

	public int getStatus() {
		return Status;
	}

	public void setStatus(int status) {
		Status = status;
	}

	public String getFirstName() {
		return FirstName;
	}

	public void setFirstName(String firstName) {
		FirstName = firstName;
	}

	public String getLastName() {
		return LastName;
	}

	public void setLastName(String lastName) {
		LastName = lastName;
	}

	public String getBirthDate() {
		return BirthDate;
	}

	public void setBirthDate(String birthDate) {
		BirthDate = birthDate;
	}

	public String getEmail() {
		return Email;
	}

	public void setEmail(String email) {
		Email = email;
	}

	public String getPhoneNo() {
		return PhoneNo;
	}

	public void setPhoneNo(String phoneNo) {
		PhoneNo = phoneNo;
	}

	public String getIdCardIssuedDate() {
		return IdCardIssuedDate;
	}

	public void setIdCardIssuedDate(String idCardIssuedDate) {
		IdCardIssuedDate = idCardIssuedDate;
	}

	public String getGender() {
		return Gender;
	}

	public void setGender(String gender) {
		Gender = gender;
	}

	public String getIdCardIssuedPlace() {
		return IdCardIssuedPlace;
	}

	public void setIdCardIssuedPlace(String idCardIssuedPlace) {
		IdCardIssuedPlace = idCardIssuedPlace;
	}

	public String getIdCardNo() {
		return IdCardNo;
	}

	public void setIdCardNo(String idCardNo) {
		IdCardNo = idCardNo;
	}

	public String getNationality() {
		return Nationality;
	}

	public void setNationality(String nationality) {
		Nationality = nationality;
	}

	public String getPermanentAddress() {
		return PermanentAddress;
	}

	public void setPermanentAddress(String permanentAddress) {
		PermanentAddress = permanentAddress;
	}

	public String getTemporaryAddress() {
		return TemporaryAddress;
	}

	public void setTemporaryAddress(String temporaryAddress) {
		TemporaryAddress = temporaryAddress;
	}

	public String getSalt() {
		return salt;
	}

	public void setSalt(String salt) {
		this.salt = salt;
	}

	public String getCode() {
		return code;
	}

	public void setCode(String code) {
		this.code = code;
	}

	public String getIp() {
		return ip;
	}

	public void setIp(String ip) {
		this.ip = ip;
	}

	public String getDate_created() {
		return date_created;
	}

	public void setDate_created(String date_created) {
		this.date_created = date_created;
	}

	public String getDate_updated() {
		return date_updated;
	}

	public void setDate_updated(String date_updated) {
		this.date_updated = date_updated;
	}

	public String getLocal_code() {
		return local_code;
	}

	public void setLocal_code(String local_code) {
		this.local_code = local_code;
	}

	/**
	 * @return the orgId
	 */
	public long getOrgId() {
		return orgId;
	}

	/**
	 * @param orgId the orgId to set
	 */
	public void setOrgId(long orgId) {
		this.orgId = orgId;
	}

}
