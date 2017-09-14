/**
 * 
 */
package com.swt.sworld.communication.customer.object;

import java.io.Serializable;
import java.util.Date;


public class PersonalInfoDto implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = 6792683097555730181L;

	private String BirthDate;

	private String Email;

	private String FirstName;

	private String Gender;

	private Date IdCardIssuedDate;

	private String IdCardIssuedPlace;

	private String IdCardNo;

	private String ImagePath;

	private String LastName;

	private String Nationality;

	private String PermanentAddress;

	private String PhoneNo;

	private String TemporaryAddress;

	public String GetFullName() {
		String firstName = getFirstName() == null ? String.valueOf(0)
				: getFirstName();
		String lastName = getLastName() == null ? String.valueOf(0)
				: getLastName();
		return String.format("{0} {1}", lastName, firstName);
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
	 * @return the gender
	 */
	public String getGender() {
		return Gender;
	}

	/**
	 * @param gender
	 *            the gender to set
	 */
	public void setGender(String gender) {
		Gender = gender;
	}

	/**
	 * @return the idCardIssuedDate
	 */
	public Date getIdCardIssuedDate() {
		return IdCardIssuedDate;
	}

	/**
	 * @param idCardIssuedDate
	 *            the idCardIssuedDate to set
	 */
	public void setIdCardIssuedDate(Date idCardIssuedDate) {
		IdCardIssuedDate = idCardIssuedDate;
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
	 * @return the idCardIssuedPlace
	 */
	public String getIdCardIssuedPlace() {
		return IdCardIssuedPlace;
	}

	/**
	 * @param idCardIssuedPlace
	 *            the idCardIssuedPlace to set
	 */
	public void setIdCardIssuedPlace(String idCardIssuedPlace) {
		IdCardIssuedPlace = idCardIssuedPlace;
	}

	/**
	 * @return the idCardNo
	 */
	public String getIdCardNo() {
		return IdCardNo;
	}

	/**
	 * @param idCardNo
	 *            the idCardNo to set
	 */
	public void setIdCardNo(String idCardNo) {
		IdCardNo = idCardNo;
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

}
