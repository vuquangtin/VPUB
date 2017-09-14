package com.swt.timekeeping.domain;

import java.io.Serializable;
import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.Table;

/**
 * TimeKeepingHolidayConfig
 * 
 * @author minh.nguyen
 *
 */
@Entity
@Table(name = "swtgp_timekeeping_holiday_config")
public class HolidayConfig implements Serializable {
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue
	@Column(name = "holidayid", nullable = false)
	private long holidayId;

	@Column(name = "holidayname", nullable = false)
	private String holidayName;

	@Column(name = "holidaystart", nullable = false)
	private Date holidayStart;

	@Column(name = "holidayend", nullable = false)
	private Date holidayEnd;

	@Column(name = "holidaydescription", length = Integer.MAX_VALUE)
	private String holidayDescription;

	@Column(name = "orgid", nullable = false)
	private long orgId;

	/**
	 * getHolidayId
	 * 
	 * @return holidayId
	 */
	public long getHolidayId() {
		return holidayId;
	}

	/**
	 * setHolidayId
	 * 
	 * @param holidayId
	 */
	public void setHolidayId(long holidayId) {
		this.holidayId = holidayId;
	}

	/**
	 * getHolidayName
	 * 
	 * @return holidayName
	 */
	public String getHolidayName() {
		return holidayName;
	}

	/**
	 * setHolidayName
	 * 
	 * @param holidayName
	 */
	public void setHolidayName(String holidayName) {
		this.holidayName = holidayName;
	}

	/**
	 * getHolidayStart
	 * 
	 * @return holidayStart
	 */
	public Date getHolidayStart() {
		return holidayStart;
	}

	/**
	 * setHolidayStart
	 * 
	 * @param holidayStart
	 */
	public void setHolidayStart(Date holidayStart) {
		this.holidayStart = holidayStart;
	}

	/**
	 * getHolidayEnd
	 * 
	 * @return holidayEnd
	 */
	public Date getHolidayEnd() {
		return holidayEnd;
	}

	/**
	 * setHolidayEnd
	 * 
	 * @param holidayEnd
	 */
	public void setHolidayEnd(Date holidayEnd) {
		this.holidayEnd = holidayEnd;
	}

	/**
	 * getHolidayDescription
	 * 
	 * @return holidayDescription
	 */
	public String getHolidayDescription() {
		return holidayDescription;
	}

	/**
	 * setHolidayDescription
	 * 
	 * @param holidayDescription
	 */
	public void setHolidayDescription(String holidayDescription) {
		this.holidayDescription = holidayDescription;
	}

	/**
	 * getOrgId
	 * 
	 * @return orgId
	 */
	public long getOrgId() {
		return orgId;
	}

	/**
	 * setOrgId
	 * 
	 * @param orgId
	 */
	public void setOrgId(long orgId) {
		this.orgId = orgId;
	}
}
