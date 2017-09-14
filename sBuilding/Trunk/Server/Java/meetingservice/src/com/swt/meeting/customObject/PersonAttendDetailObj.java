package com.swt.meeting.customObject;

import java.io.Serializable;
import java.util.List;

import com.swt.meeting.domain.NonResident;

public class PersonAttendDetailObj implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;

	private List<PersonAttendDetail> personAttendDetails;
	private List<NonResident> nonresidentDetails;

	private long sum;

	public List<PersonAttendDetail> getPersonAttendDetails() {
		return personAttendDetails;
	}

	public void setPersonAttendDetails(List<PersonAttendDetail> personAttendDetails) {
		this.personAttendDetails = personAttendDetails;
	}

	public long getSum() {
		return sum;
	}

	public void setSum(long sum) {
		this.sum = sum;
	}

	public void setNonresidentDetails(List<NonResident> nonresidentDetails) {
		this.nonresidentDetails = nonresidentDetails;
	}

	public List<NonResident> getNonresidentDetails() {
		return nonresidentDetails;
	}

}
