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
@Table(name = "swtgp_ps_member")
@NamedNativeQueries({
    @NamedNativeQuery(
            name = "getMemberList",
            query = "CALL getMemberList(:roleid,:suborgid)",
            resultClass = Member.class
    )
})
public class Member implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = 7888560410618818012L;

	@Id
	@GeneratedValue
	@Column(name = "Id")
	private long Id;

	@Column(name = "OrgID")
	private long OrgId;

	@Column(name = "OrgCode", length = 10)
	private String OrgCode;

	@Column(name = "Code", length = 255)
	private String Code;

	@Column(name = "SubOrgId", length = 255)
	private long SubOrgId;

	@Column(name = "Companyname", length = 255)
	private String Companyname;

	@Column(name = "Title", length = 255)
	private String Title;

	@Column(name = "FirstName", length = 255)
	private String FirstName;

	@Column(name = "LastName", length = 255)
	private String LastName;

	@Column(name = "LowerFullName", length = 255)
	private String LowerFullName;

	@Column(name = "BirthDate", length = 20)
	private String BirthDate;

	@Column(name = "Gender", length = 1)
	private int Gender;

	@Column(name = "Degree", length = 255)
	private String Degree;

	@Column(name = "Position", length = 255)
	private String Position;

	@Column(name = "PermanentAddress", length = 255)
	private String PermanentAddress;

	@Column(name = "TemporaryAddress", length = 255)
	private String TemporaryAddress;

	@Column(name = "PhoneNo", length = 255)
	private String PhoneNo;

	@Column(name = "Email", length = 255)
	private String Email;

	@Column(name = "Nationality", length = 255)
	private String Nationality;

	@Column(name = "ImagePath", length = 255)
	private String ImagePath;

	@Column(name = "CreatedDate", length = 20)
	private String CreatedDate;

	@Column(name = "ModifiedDate", length = 20)
	private String ModifiedDate;
	
	@Column(name = "IdentityCard", length = 20)
	private String IdentityCard;
	
	@Column(name = "IdentityCardIssueDate", length = 30)
	private String IdentityCardIssueDate;
	
	@Column(name = "IdentityCardIssue", length = 255)
	private String IdentityCardIssue;
	
	@Column(name = "ContactName", length = 255)
	private String ContactName;
	
	@Column(name = "ContactPhone", length = 255)
	private String ContactPhone;
	
	@Column(name = "ContactEmail", length = 255)
	private String ContactEmail;
	
	@Column(name = "ContactAddress", length = 255)
	private String ContactAddress;

	@Column(name = "HashCode", length = 255)
	private String HashCode;

	@Column(name = "Active")
	private boolean Active;
	
//	private String FullName;
//
//	public String getFullNameH() {
//		return FullName;
//	}
//
//	public void setFullNameH(String LastName, String FirstName) {
//		FullName = LastName + " " + FirstName;
//	}

	/**
	 * @return the id
	 */
	public long getId() {
		return Id;
	}

	/**
	 * @param id
	 *            the id to set
	 */
	public void setId(long id) {
		Id = id;
	}

	/**
	 * @return the orgId
	 */
	public long getOrgId() {
		return OrgId;
	}

	/**
	 * @param orgId
	 *            the orgId to set
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
	 * @param orgCode
	 *            the orgCode to set
	 */
	public void setOrgCode(String orgCode) {
		OrgCode = orgCode;
	}

	/**
	 * @return the code
	 */
	public String getCode() {
		return Code;
	}

	/**
	 * @param code
	 *            the code to set
	 */
	public void setCode(String code) {
		Code = code;
	}

	/**
	 * @return the title
	 */
	public String getTitle() {
		return Title;
	}

	/**
	 * @param title
	 *            the title to set
	 */
	public void setTitle(String title) {
		Title = title;
	}

	/**
	 * @return the firstName
	 */
	public String getFirstName() {
		return FirstName;
	}

	/**
	 * @param firstName
	 *            the firstName to set
	 */
	public void setFirstName(String firstName) {
		FirstName = firstName;
	}

	/**
	 * @return the lastName
	 */
	public String getLastName() {
		return LastName;
	}

	/**
	 * @param lastName
	 *            the lastName to set
	 */
	public void setLastName(String lastName) {
		LastName = lastName;
	}

	/**
	 * @return the lowerFullName
	 */
	public String getLowerFullName() {
		return LowerFullName;
	}

	/**
	 * @param lowerFullName
	 *            the lowerFullName to set
	 */
	public void setLowerFullName(String lowerFullName) {
		LowerFullName = lowerFullName;
	}

	/**
	 * @return the birthDate
	 */
	public String getBirthDate() {
		return BirthDate;
	}

	/**
	 * @param birthDate
	 *            the birthDate to set
	 */
	public void setBirthDate(String birthDate) {
		BirthDate = birthDate;
	}

	/**
	 * @return the gender
	 */
	public int getGender() {
		return Gender;
	}

	/**
	 * @param gender
	 *            the gender to set
	 */
	public void setGender(int gender) {
		Gender = gender;
	}

	/**
	 * @return the degree
	 */
	public String getDegree() {
		return Degree;
	}

	/**
	 * @param degree
	 *            the degree to set
	 */
	public void setDegree(String degree) {
		Degree = degree;
	}

	/**
	 * @return the position
	 */
	public String getPosition() {
		return Position;
	}

	/**
	 * @param position
	 *            the position to set
	 */
	public void setPosition(String position) {
		Position = position;
	}

	/**
	 * @return the permanentAddress
	 */
	public String getPermanentAddress() {
		return PermanentAddress;
	}

	/**
	 * @param permanentAddress
	 *            the permanentAddress to set
	 */
	public void setPermanentAddress(String permanentAddress) {
		PermanentAddress = permanentAddress;
	}

	/**
	 * @return the temporaryAddress
	 */
	public String getTemporaryAddress() {
		return TemporaryAddress;
	}

	/**
	 * @param temporaryAddress
	 *            the temporaryAddress to set
	 */
	public void setTemporaryAddress(String temporaryAddress) {
		TemporaryAddress = temporaryAddress;
	}

	/**
	 * @return the phoneNo
	 */
	public String getPhoneNo() {
		return PhoneNo;
	}

	/**
	 * @param phoneNo
	 *            the phoneNo to set
	 */
	public void setPhoneNo(String phoneNo) {
		PhoneNo = phoneNo;
	}

	/**
	 * @return the email
	 */
	public String getEmail() {
		return Email;
	}

	/**
	 * @param email
	 *            the email to set
	 */
	public void setEmail(String email) {
		Email = email;
	}

	/**
	 * @return the nationality
	 */
	public String getNationality() {
		return Nationality;
	}

	/**
	 * @param nationality
	 *            the nationality to set
	 */
	public void setNationality(String nationality) {
		Nationality = nationality;
	}

	/**
	 * @return the imagePath
	 */
	public String getImagePath() {
		return ImagePath;
	}

	/**
	 * @param imagePath
	 *            the imagePath to set
	 */
	public void setImagePath(String imagePath) {
		ImagePath = imagePath;
	}

	/**
	 * @return the createdDate
	 */
	public String getCreatedDate() {
		return CreatedDate;
	}

	/**
	 * @param createdDate
	 *            the createdDate to set
	 */
	public void setCreatedDate(String createdDate) {
		CreatedDate = createdDate;
	}

	/**
	 * @return the modifiedDate
	 */
	public String getModifiedDate() {
		return ModifiedDate;
	}

	/**
	 * @param modifiedDate
	 *            the modifiedDate to set
	 */
	public void setModifiedDate(String modifiedDate) {
		ModifiedDate = modifiedDate;
	}

	/**
	 * @return the hashCode
	 */
	public String getHashCode() {
		return HashCode;
	}

	/**
	 * @param hashCode
	 *            the hashCode to set
	 */
	public void setHashCode(String hashCode) {
		HashCode = hashCode;
	}

	/**
	 * @return the active
	 */
	public boolean getActive() {
		return Active;
	}

	/**
	 * @param active
	 *            the active to set
	 */
	public void setActive(Boolean active) {
		Active = active;
	}

	/**
	 * @return the subOrgId
	 */
	public long getSubOrgId() {
		return SubOrgId;
	}

	public String getIdentityCard() {
		return IdentityCard;
	}

	public void setIdentityCard(String identityCard) {
		IdentityCard = identityCard;
	}

	public String getIdentityCardIssueDate() {
		return IdentityCardIssueDate;
	}

	public void setIdentityCardIssueDate(String identityCardIssueDate) {
		IdentityCardIssueDate = identityCardIssueDate;
	}

	public String getIdentityCardIssue() {
		return IdentityCardIssue;
	}

	public void setIdentityCardIssue(String identityCardIssue) {
		IdentityCardIssue = identityCardIssue;
	}

	public String getContactName() {
		return ContactName;
	}

	public void setContactName(String contactName) {
		ContactName = contactName;
	}

	public String getContactPhone() {
		return ContactPhone;
	}

	public void setContactPhone(String contactPhone) {
		ContactPhone = contactPhone;
	}

	public String getContactEmail() {
		return ContactEmail;
	}

	public void setContactEmail(String contactEmail) {
		ContactEmail = contactEmail;
	}

	public String getContactAddress() {
		return ContactAddress;
	}

	public void setContactAddress(String contactAddress) {
		ContactAddress = contactAddress;
	}

	/**
	 * @param subOrgId
	 *            the subOrgId to set
	 */
	public void setSubOrgId(long subOrgId) {
		SubOrgId = subOrgId;
	}

	public String getCompanyname() {
		return Companyname;
	}

	public void setCompanyname(String companyname) {
		Companyname = companyname;
	}

	public String strFormat(String spliter) {
		// user.getActivecode() | user.getBirthday() | user.getLocation() |
		// user.getDeviceid() | user.getTitle |
		// user.getSex() | user.getTelephone() | user.getUsername()
		String result = this.HashCode + spliter;
		result += this.BirthDate + spliter;
		result += this.PermanentAddress + spliter;

		result += this.Position + spliter;
		result += this.Title + spliter;

		result += this.Gender + spliter;
		result += this.PhoneNo + spliter;
		result += this.LowerFullName;

		// TODO: hascode
		// result

		return result;
	}

}
