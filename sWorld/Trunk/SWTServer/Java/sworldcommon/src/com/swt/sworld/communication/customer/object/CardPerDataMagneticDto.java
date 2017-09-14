/**
 * 
 */
package com.swt.sworld.communication.customer.object;

import java.io.Serializable;

/**
 * @author Administrator
 *
 */
public class CardPerDataMagneticDto implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = 2842325032806136552L;
	private String MarterId ;//ghi vao bang cms_cardmagnetic
	private String PartnerId ;//ghi vao bang cms_cardmagnetic
	
	private String FullName ; //ghi vao table member
	private String CompanyName ; //ghi vao table member
	private String PhoneNumber ;//ghi vao table member
	
	private String ExpiredTime ;  //ghi vao bang ps_cardmagnetic_personalization va bang cms_cardmagnetic
	private String SerialNumber ; //ghi vao bang cms_cardmagnetic
	private String TrackOneData ;//ghi vao bang ps_cardmagnetic_personalization

	/**
	 * @return the marterId
	 */
	public String getMarterId() {
		return MarterId;
	}

	/**
	 * @param marterId the marterId to set
	 */
	public void setMarterId(String marterId) {
		MarterId = marterId;
	}

	/**
	 * @return the partnerId
	 */
	public String getPartnerId() {
		return PartnerId;
	}

	/**
	 * @param partnerId the partnerId to set
	 */
	public void setPartnerId(String partnerId) {
		PartnerId = partnerId;
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
	 * @return the companyName
	 */
	public String getCompanyName() {
		return CompanyName;
	}

	/**
	 * @param companyName the companyName to set
	 */
	public void setCompanyName(String companyName) {
		CompanyName = companyName;
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
	 * @return the expiredTime
	 */
	public String getExpiredTime() {
		return ExpiredTime;
	}

	/**
	 * @param expiredTime the expiredTime to set
	 */
	public void setExpiredTime(String expiredTime) {
		ExpiredTime = expiredTime;
	}

	/**
	 * @return the serialNumber
	 */
	public String getSerialNumber() {
		return SerialNumber;
	}

	/**
	 * @param serialNumber the serialNumber to set
	 */
	public void setSerialNumber(String serialNumber) {
		SerialNumber = serialNumber;
	}

	/**
	 * @return the trackOneData
	 */
	public String getTrackOneData() {
		return TrackOneData;
	}

	/**
	 * @param trackOneData the trackOneData to set
	 */
	public void setTrackOneData(String trackOneData) {
		TrackOneData = trackOneData;
	}

}
