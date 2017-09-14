package com.swt.meeting;

import java.util.List;

import com.swt.meeting.domain.Partaker;

/**
 * IPartaker interface
 * 
 * @author TaiMai
 *
 */
public interface IPartaker {
	/**
	 * insert Partaker
	 * 
	 * @param partaker
	 * @return Partaker
	 */
	public Partaker insert(Partaker partaker);

	/**
	 * update Partaker
	 * 
	 * @param partaker
	 * @return Partaker
	 */
	public Partaker update(Partaker partaker);

	/**
	 * delete Partaker
	 * 
	 * @param partakerId
	 * @return Partaker
	 */
	public int delete(long partakerId);

	/**
	 * getPartakerById
	 * 
	 * @param partakerId
	 * @return Partaker
	 */
	public Partaker getPartakerById(long partakerId);

	/**
	 * getAllPartaker
	 * 
	 * @return  List<Partaker>
	 */
	public List<Partaker> getAllPartaker();
	
	/**
	 * 24/12/2016 lay danh sach nguoi tham du cua cuoc hop da duoc moi truoc
	 * service nay giong ben cuc Nonresident trong INonResidentPartaker
	 * @return
	 */
	public List<Partaker> getPartakerByMeetingId(long meetingId); 

	
	public List<Partaker> getPartakerByOrgPartakerId(long orgMeetingId); 
	/**
	 * Function for web
	 * @param orgId
	 * @param meetingId
	 * @return
	 */
	public Partaker getPartakerByBarcode(String barcode); 

}
