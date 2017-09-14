package com.swt.meeting.impls;

import java.util.List;

import com.swt.meeting.domain.Room;

/**
 * RoomController
 * 
 * @author TaiMai
 * 
 */
public class RoomController {
	/**
	 * Instance of RoomController
	 */
	public static final RoomController Instance = new RoomController();

	private RoomDAO rDAO = new RoomDAO();

	/**
	 * insert Room
	 * 
	 * @param room
	 * @return Room
	 */
	public Room insert(Room room) {
		return rDAO.insert(room);
	}

	/**
	 * update Room
	 * 
	 * @param room
	 * @return Room
	 */
	public Room update(Room room) {
		return rDAO.update(room);
	}

	/**
	 * delete Room
	 * 
	 * @param roomId
	 * @return int
	 */
	public int delete(long roomId) {
		return rDAO.delete(roomId);
	}

	/**
	 * getroomById
	 * 
	 * @param roomId
	 * @return Room
	 */
	public Room getRoomById(long roomId) {
		return rDAO.getRoomById(roomId);
	}

	/**
	 * getAllRoom
	 * 
	 * @param
	 * @return List<Room>
	 */
	public List<Room> getAllRoom() {
		return rDAO.getAllRoom();
	}

	public Room getRoomByName(String name) {
		return rDAO.getRoomByName(name);
	}

	public Room getByReferenceId(long referenceId) {
		return rDAO.getByReferenceId(referenceId);
	}
}
