package com.swt.meeting.impls;

import java.util.ArrayList;
import java.util.List;

import org.apache.tomcat.util.codec.binary.Base64;

import com.swt.meeting.customObject.KeyOrgMeetingObj;
import com.swt.meeting.domain.KeyOrgMeeting;
import com.swt.meeting.domain.Meeting;
import com.swt.meeting.domain.MeetingInvitation;
import com.swt.meeting.domain.OrganizationMeeting;
import com.swt.meeting.domain.Partaker;

/**
 * MeetingInvitationController
 * 
 * @author TaiMai
 * 
 */
public class MeetingInvitationController {
	/**
	 * Instance of MeetingInvitationController
	 */
	public static final MeetingInvitationController Instance = new MeetingInvitationController();

	private MeetingInvitationDAO miDAO = new MeetingInvitationDAO();

	/**
	 * insert MeetingInvitation
	 * 
	 * @param meetingInvitation
	 * @return MeetingInvitation
	 */
	public MeetingInvitation insert(MeetingInvitation MeetingInvitation) {
		return miDAO.insert(MeetingInvitation);
	}

	/**
	 * update MeetingInvitation
	 * 
	 * @param meetingInvitation
	 * @return MeetingInvitation
	 */
	public MeetingInvitation update(MeetingInvitation MeetingInvitation) {
		return miDAO.update(MeetingInvitation);
	}

	/**
	 * delete MeetingInvitation
	 * 
	 * @param meetingInvitationId
	 * @return int
	 */
	public int delete(long meetingInvitationId) {
		return miDAO.delete(meetingInvitationId);
	}

	/**
	 * getMeetingInvitationById
	 * 
	 * @param meetingInvitationId
	 * @return MeetingInvitation
	 */
	public MeetingInvitation getMeetingInvitationById(long meetingInvitationId) {
		return miDAO.getMeetingInvitationById(meetingInvitationId);
	}

	/**
	 * getAllMeetingInvitation
	 * 
	 * @param
	 * @return List<MeetingInvitation>
	 */
	public List<MeetingInvitation> getAllMeetingInvitation() {
		return miDAO.getAllMeetingInvitation();
	}

	public MeetingInvitation getMeetingInvitationByBarcode(String barcode) {
		return miDAO.getMeetingInvitationByBarcode(barcode);
	}

	/**
	 * xoa MeetingInvitation theo meetingBarcode
	 * 
	 * @param meetingInvitationId
	 * @return
	 */
	public int deleteByBarcode(String meetingBarcode) {
		return miDAO.deleteByBarcode(meetingBarcode);
	}
	public List<Partaker> getInvitationByOrgAndMeetingId(long orgid, long meetingId) {
		List<Partaker> result = new ArrayList<Partaker>();
		List<MeetingInvitation> lstInvite = miDAO.getInvitationByOrgAndMeetingId(orgid, meetingId);
		if (lstInvite != null) {
			for (MeetingInvitation objInvite : lstInvite) {
				Partaker partaker = PartakerController.Instance.getPartakerByBarcode(objInvite.getMeetingBarCode());
				if (partaker != null) {
					result.add(partaker);
				}
			}
		}
		return result;

	}
	public List<MeetingInvitation> getInvitationByMeetingId(long meetingId) {
		List<MeetingInvitation> lstInvite = miDAO.getInvitationByMeetingId(meetingId);
		return lstInvite;

	}
	public KeyOrgMeetingObj getDetailMeeting(String keycheck) {
		KeyOrgMeetingObj result = new KeyOrgMeetingObj();
		List<Partaker> lstPartaker = new ArrayList<Partaker>();
		byte[] keyByte = Base64.decodeBase64(keycheck);
		String key = new String(keyByte);
		KeyOrgMeeting keyOrgMeeting = KeyOrgMeetingController.Instance.getKeyOrgMeetingByKey(key);
		if (keyOrgMeeting != null) {
			Meeting meeting = MeetingController.Instance.getMeetingById(keyOrgMeeting.getMeetingId());
			OrganizationMeeting orgMeeting = OrganizationMeetingController.Instance.getOrganizationMeetingById(keyOrgMeeting.getOrgAttendId());
			
			List<MeetingInvitation> lstInvite = miDAO.getInvitationByOrgAndMeetingId(keyOrgMeeting.getOrgAttendId(),
					keyOrgMeeting.getMeetingId());

			if (lstInvite != null) {
				for (MeetingInvitation objInvite : lstInvite) {
					Partaker partaker = PartakerController.Instance.getPartakerByBarcode(objInvite.getMeetingBarCode());
					if (partaker != null) {
						lstPartaker.add(partaker);
					}
				}
			}
			try {
				result.setPartaker(lstPartaker);
				result.setMeeting(meeting);
				result.setOrgPartakerName(orgMeeting.getName());
				result.setOrgPartakerId(orgMeeting.getId());
				
			} catch (Exception e) {
				e.getMessage();
			}
		}
		else{
			return null;
		}
		return result;
	}
	
	/**
	 * update meetingId khi doi lich hop
	 * @param meetingIdOld
	 * @param meetingIdNew
	 * @return
	 */
	public boolean updateMeetingId(long meetingIdOld, long meetingIdNew){
		return miDAO.updateMeetingId(meetingIdOld, meetingIdNew);
	}
}
