package com.meeting.services;

import java.util.List;

import javax.ws.rs.Consumes;
import javax.ws.rs.CookieParam;
import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;

import org.codehaus.jettison.json.JSONObject;

import com.meeting.common.MeetingDefines;
import com.sworld.common.ResultObject;
import com.sworld.common.Status;
import com.sworld.common.Utilites;
import com.swt.meeting.domain.Room;
import com.swt.meeting.impls.RoomController;
import com.swt.sworld.common.errors.ErrorCode;
import com.swt.sworld.common.utilitis.TokenManager;

/**
 * @author TaiMai
 * 
 */
@Path(MeetingDefines.ROOM_MANAGER)
@Produces(MeetingDefines.APPLICATION_JSON)
public class SMeetingRoomManager {

	// insert room
	@POST
	@Path(MeetingDefines.INSERT_ROOM + "/{token}")
	@Produces(MediaType.APPLICATION_JSON)
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject insertRoom(@CookieParam("sessionid") String session, @PathParam("token") String token,
			JSONObject room) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			Room nRoom = new Room();
			nRoom = Utilites.getInstance().convertJsonObjToObject(room, Room.class);
			
			Room dl = RoomController.Instance.insert(nRoom);
			if (dl != null) {
				result.setStatus(Status.SUCCESS);
				result.setObj(dl);
			} else {
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}

	// update room
	@POST
	@Path(MeetingDefines.UPDATE_ROOM + "/{token}")
	@Produces(MediaType.APPLICATION_JSON)
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject updateRoom(@CookieParam("sessionid") String session, @PathParam("token") String token,
			JSONObject room) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			Room nRoom = new Room();
			nRoom = Utilites.getInstance().convertJsonObjToObject(room, Room.class);
			Room dl = RoomController.Instance.update(nRoom);
			if (dl != null) {
				result.setStatus(Status.SUCCESS);
				result.setObj(dl);
			} else {
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}

	// delete room
	@POST
	@Path(MeetingDefines.DELETE_ROOM + "/{token}/{roomid}")
	@Produces(MediaType.APPLICATION_JSON)
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject deleteRoom(@CookieParam("sessionid") String session, @PathParam("token") String token,
			@PathParam("roomId") long roomId) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			int kq = RoomController.Instance.delete(roomId);
			if (kq == ErrorCode.SUCCESS) {
				result.setStatus(Status.SUCCESS);
			} else {
				result.setStatus(Status.FAILED);
			}
		}

		return result;
	}

	// get all room
	@GET
	@Path(MeetingDefines.GET_ALL_ROOM + "/{token}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject getAllRoom(@CookieParam("sessionid") String session, @PathParam("token") String token) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			List<Room> dl = RoomController.Instance.getAllRoom();
			if (dl != null) {
				result.setStatus(Status.SUCCESS);
				result.setObj(dl);
			} else {
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}

	// get room by id
	@GET
	@Path(MeetingDefines.GET_ROOM_BY_ID + "/{token}/{roomid}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject getRoomById(@CookieParam("sessionid") String session, @PathParam("token") String token,
			@PathParam("roomid") int roomId) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			Room dl = RoomController.Instance.getRoomById(roomId);
			if (dl != null) {
				result.setStatus(Status.SUCCESS);
				result.setObj(dl);
			} else {
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}
}
