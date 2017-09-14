/**
 * 
 */
package com.swt.meeting.customObject;

import java.io.Serializable;

import com.swt.meeting.domain.Meeting;
import com.swt.meeting.domain.OrganizationMeeting;
import com.swt.meeting.domain.Room;

/**
 * @author TaiMai
 *
 * 
 */

public class MeetingObj implements Serializable {
	/**
	 * 
	 */
	private static final long serialVersionUID = 156165156L;

	private Meeting meeting;
	private Room room;
	private OrganizationMeeting organizationMeeting;
	private boolean checkInvite;

	public Meeting getMeeting() {
		return meeting;
	}

	public void setMeeting(Meeting meeting) {
		this.meeting = meeting;
	}

	public Room getRoom() {
		return room;
	}

	public void setRoom(Room room) {
		this.room = room;
	}

	public OrganizationMeeting getOrganizationMeeting() {
		return organizationMeeting;
	}

	public void setOrganizationMeeting(OrganizationMeeting organizationMeeting) {
		this.organizationMeeting = organizationMeeting;
	}

	public boolean isCheckInvite() {
		return checkInvite;
	}

	public void setCheckInvite(boolean checkInvite) {
		this.checkInvite = checkInvite;
	}

 
}
