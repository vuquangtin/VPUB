package com.swt.meeting.impls;

import com.swt.meeting.IMeetingLCT;
import com.swt.meeting.customObject.MeetingInvitationLCT;
import com.swt.meeting.customObject.MeetingLCT;
import com.swt.meeting.domain.Meeting;
import com.swt.meeting.domain.OrganizationMeeting;
import com.swt.meeting.domain.Room;

public class MeetingLCTDAO implements IMeetingLCT {
	public static  final String DATE_DEFAULT = "1971-1-1 00:00:00";
	/**
	 * xu ly service goi ben quan ly vn ban
	 */

	/**
	 * xu ly service goi ben quan ly vn ban
	 */
	@Override
	public boolean addMeeting(MeetingLCT meetingLCT) {
		Meeting meeting = new Meeting();

		// get organization
		OrganizationMeeting organizationMeeting = OrganizationMeetingController.Instance
				.getOrganizationMeetingById(meetingLCT.getOrganizationMeetingId());
		if (organizationMeeting == null) {
			return false;
		}
		meeting.setOrganizationMeetingId(organizationMeeting.getId());
		meeting.setOrganizationMeetingName(organizationMeeting.getName());

		// get room
		Room room = RoomController.Instance.getRoomById(meetingLCT.getRoomId());
		if (room == null) {
			return false;
		}
		meeting.setRoomId(room.getId());
		meeting.setRoomName(room.getName());

		//
		meeting.setMeetingCode(meetingLCT.getNeocoreId());
		meeting.setMeetingCodeStatus(true);

		meeting.setName(meetingLCT.getName());
		meeting.setDescription(meetingLCT.getDescription());
		meeting.setNumber(meetingLCT.getNumber());
		meeting.setStartTime(meetingLCT.getStartTime());
		meeting.setEndTime(meetingLCT.getEndTime());
		meeting.setNote(meeting.getNote());

		// add meeting into database
		MeetingController.Instance.insert(meeting);

		return true;
	}

	@Override
	public boolean editMeeting(MeetingLCT meetingLCT) {
		Meeting meeting = new Meeting();

		// get organization
		OrganizationMeeting organizationMeeting = OrganizationMeetingController.Instance
				.getOrganizationMeetingById(meetingLCT.getOrganizationMeetingId());
		if (organizationMeeting == null) {
			return false;
		}
		meeting.setOrganizationMeetingId(organizationMeeting.getId());
		meeting.setOrganizationMeetingName(organizationMeeting.getName());

		// get room
		Room room = RoomController.Instance.getRoomById(meetingLCT.getRoomId());
		if (room == null) {
			return false;
		}
		meeting.setRoomId(room.getId());
		meeting.setRoomName(room.getName());

		//
		meeting.setMeetingCode(meetingLCT.getNeocoreId());

		meeting.setName(meetingLCT.getName());
		meeting.setDescription(meetingLCT.getDescription());
		meeting.setNumber(meetingLCT.getNumber());
		meeting.setStartTime(meetingLCT.getStartTime());
		meeting.setEndTime(meetingLCT.getEndTime());
		meeting.setNote(meeting.getNote());

		// edit meeting into database
		int result = MeetingController.Instance.edit(meeting);
		if (result == -1 || result == 0) {
			return false;
		} else {
			return true;
		}
	}

	@Override
	public boolean deleteMeeting(long neocoreid) {
		// delete meeting in database
		int result = MeetingController.Instance.updateNeocoreStatus(neocoreid);
		if (result == -1 || result == 0) {
			return false;
		} else {
			return true;
		}
	}

	// version 2 : them thu moi hop
	@Override
	public boolean changetimeMeeting(long idMeetingtingInvitationLCT, MeetingInvitationLCT meetingInvitationLCT) {
		//lay thong tin cuoc hop cu
		Meeting meetingOld = MeetingController.Instance.getMeetingByMeetingCodeActive(idMeetingtingInvitationLCT);
		// huy cuoc hop cu
		deleteMeeting(idMeetingtingInvitationLCT);
		//them cuoc hop moi
		meetingInvitationLCT = MeetingInvitationLCTController.Instance.add(meetingInvitationLCT);
		
		if(meetingInvitationLCT != null){
			//lay danh sach cac nguoi da dang ky cuoc hop cu
			Meeting meetingNew = MeetingController.Instance.getMeetingByMeetingCodeActive(meetingInvitationLCT.getMeetingInvitationId());
			meetingNew.setNumber(meetingOld.getNumber());
			//update so luong nguoi da dang ky
			MeetingController.Instance.update(meetingNew);
			
			//update meetingid cho bang key
			KeyOrgMeetingController.Instance.updateMeetingId(meetingOld.getId(), meetingNew.getId());
			
			//update meetingid cho bang attendmeetin
			AttendMeetingController.Instance.updateMeetingId(meetingOld.getId(), meetingNew.getId());
			
			//update meetingid cho bang meeting invitation
			MeetingInvitationController.Instance.updateMeetingId(meetingOld.getId(), meetingNew.getId());
		}else{
			return false;
		}
		
		return true;
	}

	
	/**
	 * hoan lich la tao huy cuoc hop
	 */
	@Override
	public boolean postponedMeeting(long idMeetingtingInvitationLCT) {
		return deleteMeeting(idMeetingtingInvitationLCT);
	}

}
