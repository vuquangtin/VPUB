/**
 * 
 */
package com.swt.sworld.communication.customer.object;

import java.io.Serializable;
import java.util.List;

/**
 * @author Administrator
 *
 */
public class DataForReadCard implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = 199869672417028911L;
	
	private long MemberId ;
	private String FullName ;
	private String BirthDate ;
	private String PhoneNo ;
	private String Email ;
	private List<Long> AppIds ;
	
//	public DataForReadCard(long MemberId, String FullName, String BirthDate,
//			String PhoneNo, String Email, List<Long> AppIds)
//	{
//		this.MemberId = MemberId;
//		this.FullName = FullName;
//		this.BirthDate = BirthDate;
//		this.PhoneNo = PhoneNo;
//		this.Email = Email;
//		this.AppIds = AppIds;
//	}
	
	/**
	 * @return the memberId
	 */
	public long getMemberId() {
		return MemberId;
	}
	/**
	 * @param memberId the memberId to set
	 */
	public void setMemberId(long memberId) {
		MemberId = memberId;
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
	 * @return the appIds
	 */
	public List<Long> getAppIds() {
		return AppIds;
	}
	/**
	 * @param appIds the appIds to set
	 */
	public void setAppIds(List<Long> appIds) {
		AppIds = appIds;
	}

}
