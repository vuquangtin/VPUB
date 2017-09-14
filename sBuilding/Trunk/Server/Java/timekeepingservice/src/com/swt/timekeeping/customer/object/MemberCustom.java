package com.swt.timekeeping.customer.object;

public class MemberCustom {

	private long memberId;
	private String memberCode;
	private String subOrg;
	private String firstName;
	private String lastName;
	private String position;
	private String idCardNumber;

	public MemberCustom() {

	}

	public MemberCustom(long memberId, String memberCode, String subOrg, String firstName, String lastName,
			String position, String idCardNumber) {
		this.memberId = memberId;
		this.memberCode = memberCode;
		this.subOrg = subOrg;
		this.firstName = firstName;
		this.lastName = lastName;
		this.position = position;
		this.idCardNumber = idCardNumber;
	}

	public long getMemberId() {
		return memberId;
	}

	public void setMemberId(long memberId) {
		this.memberId = memberId;
	}

	public String getMemberCode() {
		return memberCode;
	}

	public void setMemberCode(String memberCode) {
		this.memberCode = memberCode;
	}

	public String getSubOrg() {
		return subOrg;
	}

	public void setSubOrg(String subOrg) {
		this.subOrg = subOrg;
	}

	public String getFirstName() {
		return firstName;
	}

	public void setFirstName(String firstName) {
		this.firstName = firstName;
	}

	public String getLastName() {
		return lastName;
	}

	public void setLastName(String lastName) {
		this.lastName = lastName;
	}

	public String getPosition() {
		return position;
	}

	public void setPosition(String position) {
		this.position = position;
	}

	public String getIdCardNumber() {
		return idCardNumber;
	}

	public void setIdCardNumber(String idCardNumber) {
		this.idCardNumber = idCardNumber;
	}
}
