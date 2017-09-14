package com.swt.nonresident.customObject;

import java.io.Serializable;

import com.swt.meeting.domain.NonResident;

public class NonResidentObj implements Serializable {
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;

	private NonResident nonResident;
	private String dataImageFace;
	private String dataImageIdentityCard;

	public NonResident getNonResident() {
		return nonResident;
	}

	public void setNonResident(NonResident nonResident) {
		this.nonResident = nonResident;
	}

	public String getDataImageFace() {
		return dataImageFace;
	}

	public void setDataImageFace(String dataImageFace) {
		this.dataImageFace = dataImageFace;
	}

	public String getDataImageIdentityCard() {
		return dataImageIdentityCard;
	}

	public void setDataImageIdentityCard(String dataImageIdentityCard) {
		this.dataImageIdentityCard = dataImageIdentityCard;
	}

}