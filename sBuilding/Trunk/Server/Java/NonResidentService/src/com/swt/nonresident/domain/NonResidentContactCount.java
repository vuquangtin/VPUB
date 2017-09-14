package com.swt.nonresident.domain;

import java.io.Serializable;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.NamedNativeQueries;
import javax.persistence.NamedNativeQuery;
import javax.persistence.Table;

@Entity
@Table(name = "swt_nonresident_contact_count")
@NamedNativeQueries({
		@NamedNativeQuery(name = "statisticNonresidentContactByDateAll", query = "CALL statisticNonresidentContactByDateAll(:start, :limit, :fromdate, :todate, :orgid)", resultClass = NonResidentContactCount.class),
		@NamedNativeQuery(name = "statisticNonresidentContactByDateAndOrgId", query = "CALL statisticNonresidentContactByDateAndOrgId(:start, :limit, :fromdate, :todate, :orgid)", resultClass = NonResidentContactCount.class) })
public class NonResidentContactCount implements Serializable {
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
