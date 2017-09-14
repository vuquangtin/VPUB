/**
 * 
 */
package com.swt.sworld.communication.customer.object;

import java.io.Serializable;

/**
 * @author Administrator
 *
 */
public class MemberCardDto implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = 132110556831216306L;
	
	private long Id;
	private long OrgId;
	private String FirstName;
	private String LastName;
	private String LowerFullName;
	private String BirthDate;
	private String Gender;
	private String Degree;
	private String Position;
	private String PermanentAddress;
	private String TemporaryAddress;
	private String PhoneNo;
	private String Email;
	private String Nationality;
	private String ImagePath;
	private String CreatedDate;
	private String ModifiedDate;
	private String HashCode;
	private int Active;
	private long SubOrgId;
	private PersoCard persocard;
	
	public MemberCardDto(long Id, long OrgId, String FirstName,
			String LastName, String LowerFullName, String BirthDate,
			String Gender, String Degree, String Position,
			String PermanentAddress, String TemporaryAddress, String PhoneNo,
			String Email, String Nationality, String ImagePath,
			String CreatedDate, String ModifiedDate, String HashCode,
			int Active, long SubOrgId, PersoCard persocard)
	{
		this.Id = Id;
		this.OrgId = OrgId;
		this.LastName = LastName;
		this.LowerFullName = LowerFullName;
		this.BirthDate = BirthDate;
		this.Gender = Gender;
		this.Degree = Degree;
		this.Position = Position;
		this.PermanentAddress = PermanentAddress;
		this.TemporaryAddress = TemporaryAddress;
		this.PhoneNo = PhoneNo;
		this.Email = Email;
		this.Nationality = Nationality;
		this.ImagePath = ImagePath;
		this.CreatedDate = CreatedDate;
		this.ModifiedDate = ModifiedDate;
		this.HashCode = HashCode;
		this.Active = Active;
		this.SubOrgId = SubOrgId;
		this.persocard = persocard;
	}
	
	/**
	 * @return the id
	 */
	public long getId() {
		return Id;
	}
	/**
	 * @param id the id to set
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
	 * @param orgId the orgId to set
	 */
	public void setOrgId(long orgId) {
		OrgId = orgId;
	}
	/**
	 * @return the firstName
	 */
	public String getFirstName() {
		return FirstName;
	}
	/**
	 * @param firstName the firstName to set
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
	 * @param lastName the lastName to set
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
	 * @param lowerFullName the lowerFullName to set
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
	 * @param birthDate the birthDate to set
	 */
	public void setBirthDate(String birthDate) {
		BirthDate = birthDate;
	}
	/**
	 * @return the gender
	 */
	public String getGender() {
		return Gender;
	}
	/**
	 * @param gender the gender to set
	 */
	public void setGender(String gender) {
		Gender = gender;
	}
	/**
	 * @return the degree
	 */
	public String getDegree() {
		return Degree;
	}
	/**
	 * @param degree the degree to set
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
	 * @param position the position to set
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
	 * @param permanentAddress the permanentAddress to set
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
	 * @param temporaryAddress the temporaryAddress to set
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
	 * @param phoneNo the phoneNo to set
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
	 * @param email the email to set
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
	 * @param nationality the nationality to set
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
	 * @param imagePath the imagePath to set
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
	 * @param createdDate the createdDate to set
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
	 * @param modifiedDate the modifiedDate to set
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
	 * @param hashCode the hashCode to set
	 */
	public void setHashCode(String hashCode) {
		HashCode = hashCode;
	}
	/**
	 * @return the active
	 */
	public int getActive() {
		return Active;
	}
	/**
	 * @param active the active to set
	 */
	public void setActive(int active) {
		Active = active;
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
	/**
	 * @return the persocard
	 */
	public PersoCard getPersocard() {
		return persocard;
	}
	/**
	 * @param persocard the persocard to set
	 */
	public void setPersocard(PersoCard persocard) {
		this.persocard = persocard;
	}

}
