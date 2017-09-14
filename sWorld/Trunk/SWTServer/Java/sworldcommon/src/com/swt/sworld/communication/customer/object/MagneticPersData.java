/**
 * 
 */
package com.swt.sworld.communication.customer.object;

import java.io.Serializable;

/**
 * @author Vo tinh
 * 
 */
public class MagneticPersData implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = -8776121015125021403L;

	private String FullName;
	private String CompanyName;
	private String PhoneNumber;
	private String ExpiredTime;
	private String SerialNumber;
	private String TrackOneData;
	
//	public MagneticPersData(String FullName, String CompanyName,
//			String PhoneNumber, String ExpiredTime, String SerialNumber,
//			String TrackOneData)
//	{
//		this.FullName = FullName;
//		this.CompanyName = CompanyName;
//		this.PhoneNumber = PhoneNumber;
//		this.ExpiredTime = ExpiredTime;
//		this.SerialNumber = SerialNumber;
//		this.TrackOneData = TrackOneData;
//	}
	
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
