package com.swt.timekeeping.customer.object;

import java.io.Serializable;

public class DayOffImportObject implements Serializable{
	/**
	 */
	private static final long serialVersionUID = 1L;
	  private long OrgId;
	  private long SubOrgId;
	  private String MemberCode;
	  private String MemberName;
	  private String DateOff;
	  private int TypeDayOff;
	  private String Note;

	public long getOrgId() {
		return OrgId;
	}
	public void setOrgId(long orgId) {
		this.OrgId = orgId;
	}
	public long getSubOrgId() {
		return SubOrgId;
	}
	public void setSubOrgId(long subOrgId) {
		SubOrgId = subOrgId;
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
	public String getDateOff() {
		return DateOff;
	}
	public void setDateOff(String dateOff) {
		DateOff = dateOff;
	}
	public int getTypeDayOff() {
		return TypeDayOff;
	}
	public void setTypeDayOff(int typeDayOff) {
		TypeDayOff = typeDayOff;
	}
	public String getNote() {
		return Note;
	}
	public void setNote(String note) {
		Note = note;
	}
}
