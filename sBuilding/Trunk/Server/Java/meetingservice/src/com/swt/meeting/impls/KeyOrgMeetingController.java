/**
 * 
 */
package com.swt.meeting.impls;

import com.swt.meeting.domain.KeyOrgMeeting;

/**
 * @author Tenit
 *
 */
public class KeyOrgMeetingController {
	public static final KeyOrgMeetingController Instance = new KeyOrgMeetingController();
	KeyOrgMeetingDAO keyOrgDao = new KeyOrgMeetingDAO();
	
	public KeyOrgMeeting getKeyOrgMeetingByKey(String key){
		return keyOrgDao.getKeyOrgMeetingByKey(key);
	}

	
	/**
	 * update meetingid moi khi doi lich hop
	 * @param meetingIdOld
	 * @param meetingIdNew
	 * @return
	 */
	public boolean updateMeetingId(long meetingIdOld, long meetingIdNew){
		return keyOrgDao.updateMeetingId(meetingIdOld, meetingIdNew);
	}
}
