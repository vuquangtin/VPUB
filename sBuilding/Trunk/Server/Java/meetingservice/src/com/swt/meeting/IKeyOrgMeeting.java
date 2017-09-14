/**
 * 
 */
package com.swt.meeting;

import com.swt.meeting.domain.KeyOrgMeeting;

/**
 * @author Tenit
 *
 */
public interface IKeyOrgMeeting {
	public KeyOrgMeeting getKeyOrgMeetingByKey(String key);
	
	/**
	 * update meetingid moi khi doi lich hop
	 * @param meetingIdOld
	 * @param meetingIdNew
	 * @return
	 */
	public boolean updateMeetingId(long meetingIdOld, long meetingIdNew);
}
