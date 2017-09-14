/**
 * 
 */
package com.swt.sworld.communication.customer.object;

import java.io.Serializable;

public class PreGenerateData implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = -8129113706691153634L;

	private int AlgorithmSerial;
	private int BeginNumber;
	private String FullName; // default
	private String CompanyName; // default
	private String PhoneNumber; // default
	private String SubOrgName;
	private String MasterName;
	private String PartnerName;

	/**
	 * @return the beginNumber
	 */
	public int getBeginNumber() {
		return BeginNumber;
	}

	/**
	 * @param beginNumber
	 *            the beginNumber to set
	 */
	public void setBeginNumber(int beginNumber) {
		BeginNumber = beginNumber;
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

	public int getAlgorithmSerial() {
		return AlgorithmSerial;
	}

	public void setAlgorithmSerial(int algorithmSerial) {
		AlgorithmSerial = algorithmSerial;
	}

	/**
	 * @return the suborgname
	 */
	public String getSuborgname() {
		return SubOrgName;
	}

	/**
	 * @param suborgname the suborgname to set
	 */
	public void setSuborgname(String SubOrgName) {
		this.SubOrgName = SubOrgName;
	}

	/**
	 * @return the masterName
	 */
	public String getMasterName() {
		return MasterName;
	}

	/**
	 * @param masterName the masterName to set
	 */
	public void setMasterName(String masterName) {
		MasterName = masterName;
	}

	/**
	 * @return the partnerName
	 */
	public String getPartnerName() {
		return PartnerName;
	}

	/**
	 * @param partnerName the partnerName to set
	 */
	public void setPartnerName(String partnerName) {
		PartnerName = partnerName;
	}

}
