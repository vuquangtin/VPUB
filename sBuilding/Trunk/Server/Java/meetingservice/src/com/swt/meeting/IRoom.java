package com.swt.meeting;

import java.util.List;

import com.swt.meeting.domain.Room;

/**
 * IRoom interface
 * 
 * @author TaiMai
 *
 */
public interface IRoom {
	/**
	 * insert Room
	 * 
	 * @param room
	 * @return Room
	 */
	public Room insert(Room room);

	/**
	 * update Room
	 * 
	 * @param room
	 * @return Room
	 */
	public Room update(Room room);

	/**
	 * delete Room
	 * 
	 * @param roomId
	 * @return Room
	 */
	public int delete(long roomId);

	/**
	 * getRoomById
	 * 
	 * @param roomId
	 * @return Room
	 */
	public Room getRoomById(long roomId);
	
	/**
	 * getAllRoom
	 * 
	 * @return
	 */
	public List<Room> getAllRoom();
	
	/**
	 * 
	 * @param name
	 * @return
	 */
	public Room getRoomByName(String name);
	
	/**
	 * 
	 * @param referenceId
	 * @return
	 */
	public Room getByReferenceId(long referenceId);
}
