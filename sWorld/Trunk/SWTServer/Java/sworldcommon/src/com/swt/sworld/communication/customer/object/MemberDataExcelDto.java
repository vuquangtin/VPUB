/**
 * 
 */
package com.swt.sworld.communication.customer.object;

import java.io.Serializable;

public class MemberDataExcelDto implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = -4621656416062669122L;

	private String SheetName;

	private int RowIndex;

	private String FullName;

	private String CompanyName;

	private String PhoneNumber;

	private String ExpiredTime;

	private String SerialNumber;

	private String TrackData;

	/**
	 * @return the sheetName
	 */
	public String getSheetName() {
		return SheetName;
	}

	/**
	 * @param sheetName
	 *            the sheetName to set
	 */
	public void setSheetName(String sheetName) {
		SheetName = sheetName;
	}

	/**
	 * @return the rowIndex
	 */
	public int getRowIndex() {
		return RowIndex;
	}

	/**
	 * @param rowIndex
	 *            the rowIndex to set
	 */
	public void setRowIndex(int rowIndex) {
		RowIndex = rowIndex;
	}

	/**
	 * @return the fullName
	 */
	public String getFullName() {
		return FullName;
	}

	/**
	 * @param fullName
	 *            the fullName to set
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
	 * @param companyName
	 *            the companyName to set
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
	 * @param phoneNumber
	 *            the phoneNumber to set
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
	 * @param expiredTime
	 *            the expiredTime to set
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
	 * @param serialNumber
	 *            the serialNumber to set
	 */
	public void setSerialNumber(String serialNumber) {
		SerialNumber = serialNumber;
	}

	/**
	 * @return the trackOneData
	 */
	public String getTrackData() {
		return TrackData;
	}

	/**
	 * @param trackOneData
	 *            the trackOneData to set
	 */
	public void setTrackData(String trackOneData) {
		TrackData = trackOneData;
	}

}
