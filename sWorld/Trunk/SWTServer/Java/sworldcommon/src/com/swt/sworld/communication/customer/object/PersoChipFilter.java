/**
 * 
 */
package com.swt.sworld.communication.customer.object;

import java.io.Serializable;

import com.swt.sworld.communication.customer.object.TimePeriodDto;

/**
 * @author LOCVIP
 *
 */
public class PersoChipFilter implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = -8393586494888620878L;
	private boolean FilterByMemberName;
	private String MemberName;
	public boolean FilterByMemberCode;
	public String MemberCode;
	private boolean FilterByPersoStatus;
	private int PersoStatus;
	private boolean FilterByPersoDate;
	private TimePeriodDto PersoDatePeriod;
	private boolean FilterRecordNeedToUpdate;
	private boolean ExcludeCanceledPerso;;
	private int Start;
	private int Count;
	private String Status;

	public String cloneMember() {
		String resultSearch = "";
		if (FilterByMemberName)
			resultSearch += " AND LowerFullName = '" + MemberName + "'";
		return resultSearch;
	}

	public String clone() {
		String resultSearch = "";
		if (FilterByPersoStatus)
			resultSearch += " AND Active = " + PersoStatus;
		//20170703 #Bug675 Them cac string search vao object search Ten nguyen Start
		if (FilterByMemberName)
			resultSearch += " AND LowerFullName LIKE '%"+MemberName+"%'";
		if (FilterByMemberCode)
			resultSearch += " AND Code LIKE '%"+MemberCode+"%'" ;
		//20170703 #Bug675 Them cac string search vao object search Ten nguyen End
		if (FilterByPersoDate) {
			if (PersoDatePeriod.getStart() != null || !"null".equals(PersoDatePeriod.getStart())) {
				resultSearch += " AND STR_TO_DATE(PersoDate, '%d/%m/%Y') >= STR_TO_DATE('" + PersoDatePeriod.getStart()
						+ "', '%d/%m/%Y') ";
			}
			if (PersoDatePeriod.getEnd() != null || !"null".equals(PersoDatePeriod.getEnd())) {
				resultSearch += " AND STR_TO_DATE(PersoDate, '%d/%m/%Y') <= STR_TO_DATE('" + PersoDatePeriod.getEnd()
						+ "', '%d/%m/%Y') ";
			}
		}

		if (Status != null)
			resultSearch += " AND Status = " + Status;

		// chua lam filter theo start va count
		return resultSearch;
	}

	/**
	 * @return the start
	 */
	public int getStart() {
		return Start;
	}

	/**
	 * @param start
	 *            the start to set
	 */
	public void setStart(int start) {
		Start = start;
	}

	/**
	 * @return the count
	 */
	public int getCount() {
		return Count;
	}

	/**
	 * @param count
	 *            the count to set
	 */
	public void setCount(int count) {
		Count = count;
	}

	/**
	 * @return the status
	 */
	public String getStatus() {
		return Status;
	}

	/**
	 * @param status
	 *            the status to set
	 */
	public void setStatus(String status) {
		Status = status;
	}

	/**
	 * @return the filterByMemberName
	 */
	public boolean isFilterByMemberName() {
		return FilterByMemberName;
	}

	/**
	 * @param filterByMemberName
	 *            the filterByMemberName to set
	 */
	public void setFilterByMemberName(boolean filterByMemberName) {
		FilterByMemberName = filterByMemberName;
	}

	/**
	 * @return the memberName
	 */
	public String getMemberName() {
		return MemberName;
	}

	/**
	 * @param memberName
	 *            the memberName to set
	 */
	public void setMemberName(String memberName) {
		MemberName = memberName;
	}

	/**
	 * @return the filterByPersoStatus
	 */
	public boolean isFilterByPersoStatus() {
		return FilterByPersoStatus;
	}

	/**
	 * @param filterByPersoStatus
	 *            the filterByPersoStatus to set
	 */
	public void setFilterByPersoStatus(boolean filterByPersoStatus) {
		FilterByPersoStatus = filterByPersoStatus;
	}

	/**
	 * @return the persoStatus
	 */
	public int getPersoStatus() {
		return PersoStatus;
	}

	/**
	 * @param persoStatus
	 *            the persoStatus to set
	 */
	public void setPersoStatus(int persoStatus) {
		PersoStatus = persoStatus;
	}

	/**
	 * @return the filterByPersoDate
	 */
	public boolean isFilterByPersoDate() {
		return FilterByPersoDate;
	}

	/**
	 * @param filterByPersoDate
	 *            the filterByPersoDate to set
	 */
	public void setFilterByPersoDate(boolean filterByPersoDate) {
		FilterByPersoDate = filterByPersoDate;
	}

	/**
	 * @return the persoDatePeriod
	 */
	public TimePeriodDto getPersoDatePeriod() {
		return PersoDatePeriod;
	}

	/**
	 * @param persoDatePeriod
	 *            the persoDatePeriod to set
	 */
	public void setPersoDatePeriod(TimePeriodDto persoDatePeriod) {
		PersoDatePeriod = persoDatePeriod;
	}

	/**
	 * @return the filterRecordNeedToUpdate
	 */
	public boolean isFilterRecordNeedToUpdate() {
		return FilterRecordNeedToUpdate;
	}

	/**
	 * @param filterRecordNeedToUpdate
	 *            the filterRecordNeedToUpdate to set
	 */
	public void setFilterRecordNeedToUpdate(boolean filterRecordNeedToUpdate) {
		FilterRecordNeedToUpdate = filterRecordNeedToUpdate;
	}

	/**
	 * @return the excludeCanceledPerso
	 */
	public boolean isExcludeCanceledPerso() {
		return ExcludeCanceledPerso;
	}

	/**
	 * @param excludeCanceledPerso
	 *            the excludeCanceledPerso to set
	 */
	public void setExcludeCanceledPerso(boolean excludeCanceledPerso) {
		ExcludeCanceledPerso = excludeCanceledPerso;
	}

	public boolean isFilterByMemberCode() {
		return FilterByMemberCode;
	}

	public void setFilterByMemberCode(boolean filterByMemberCode) {
		FilterByMemberCode = filterByMemberCode;
	}

	public String getMemberCode() {
		return MemberCode;
	}

	public void setMemberCode(String memberCode) {
		MemberCode = memberCode;
	}

}
