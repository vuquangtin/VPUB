package com.swt.meeting.domain;

import java.io.Serializable;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.NamedNativeQueries;
import javax.persistence.NamedNativeQuery;
import javax.persistence.Table;

@Entity
@Table(name = "swt_smeeting_contact_count")
@NamedNativeQueries({
		@NamedNativeQuery(name = "statisticContactByDateAll", query = "CALL statisticContactByDateAll(:start, :limit, :fromdate, :todate, :orgid)", resultClass = SmeetingContactCount.class),
		@NamedNativeQuery(name = "statisticContactByDateAndOrgId", query = "CALL statisticContactByDateAndOrgId(:start, :limit, :fromdate, :todate, :orgid)", resultClass = SmeetingContactCount.class) })
public class SmeetingContactCount implements Serializable {
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	@Id
	@GeneratedValue
	private long orgId;
	private String orgName;
	private long sum;

	public long getOrgId() {
		return orgId;
	}

	public void setOrgId(long orgId) {
		this.orgId = orgId;
	}

	public String getOrgName() {
		return orgName;
	}

	public void setOrgName(String orgName) {
		this.orgName = orgName;
	}

	public long getSum() {
		return sum;
	}

	public void setSum(long sum) {
		this.sum = sum;
	}

}
