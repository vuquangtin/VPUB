package com.swt.nonresident.customObject;

import com.swt.nonresident.domain.NonResidentMemberMap;

public class NonResidentMemberMapCustom {
	private NonResidentMemberMap nonResMemMap;
	private String memberName;
	
	public NonResidentMemberMapCustom(){
		
	}

	public NonResidentMemberMapCustom(NonResidentMemberMap nonResMemMap, String memberName) {
		this.nonResMemMap = nonResMemMap;
		this.memberName = memberName;
	}

	public NonResidentMemberMap getNonResMemMap() {
		return nonResMemMap;
	}

	public void setNonResMemMap(NonResidentMemberMap nonResMemMap) {
		this.nonResMemMap = nonResMemMap;
	}

	public String getMemberName() {
		return memberName;
	}

	public void setMemberName(String memberName) {
		this.memberName = memberName;
	}
}
