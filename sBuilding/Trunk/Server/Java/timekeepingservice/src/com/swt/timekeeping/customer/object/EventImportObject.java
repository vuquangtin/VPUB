package com.swt.timekeeping.customer.object;

import java.io.Serializable;
/**
 * @author Trang-PC
 */
public class EventImportObject implements Serializable{
	/**
	 */
	private static final long serialVersionUID = 1L;
	private long OrgId;
	private long SubOrgId;
	private String EventName;
	private String HourBegin;
	private String Date;
	private int HourKeeping;
	private String Description;
	private String MemberCode;
	private String MemberName;
	
	public long getOrgId() {
		return OrgId;
	}
	public void setOrgId(long orgId) {
		OrgId = orgId;
	}
	public long getSubOrgId() {
		return SubOrgId;
	}
	public void setSubOrgId(long subOrgId) {
		SubOrgId = subOrgId;
	}
	public String getEventName() {
		return EventName;
	}
	public void setEventName(String eventName) {
		EventName = eventName;
	}
	public String getHourBegin() {
		return HourBegin;
	}
	public void setHourBegin(String hourBegin) {
		HourBegin = hourBegin;
	}
	public String getDate() {
		return Date;
	}
	public void setDate(String date) {
		Date = date;
	}
	public int getHourKeeping() {
		return HourKeeping;
	}
	public void setHourKeeping(int hourKeeping) {
		HourKeeping = hourKeeping;
	}
	public String getDescription() {
		return Description;
	}
	public void setDescription(String description) {
		Description = description;
	}
	public String getMemberCode() {
		return MemberCode;
	}
	public void setMemberCode(String memberCode) {
		MemberCode = memberCode;
	}
	public String getMemberName() {
		return MemberName;
	}
	public void setMemberName(String memberName) {
		MemberName = memberName;
	}

}
