package com.sworld.web.services;

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

import com.sworld.common.Defines;
import com.sworld.common.ResultObject;
import com.sworld.common.Status;
import com.sworld.common.Utilites;
import com.swt.sworld.common.errors.ErrorCode;
import com.swt.sworld.common.utilitis.TokenManager;
import com.swt.sworld.device.domain.DeviceDoor;
import com.swt.sworld.device.impls.DeviceDoorController;
/**
 * @author Tenit
 *
 */
@Path(Defines.DEVICE)
@Produces(Defines.APPLICATION_JSON)
public class DeviceManager {
	@POST
	@Path(Defines.INSERT_DEVICE_DOOR + "/{token}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject InsertDeviceDoor(@CookieParam("sessionid") String session, @PathParam("token") String token,
			JSONObject deviceDoor) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			DeviceDoor device = new DeviceDoor();
			device = Utilites.getInstance().convertJsonObjToObject(deviceDoor, device.getClass());
			DeviceDoor deviceDoorResult = DeviceDoorController.Instance.insert(device);

			if (deviceDoorResult != null) {
				result.setStatus(Status.SUCCESS);

			} else {
				result.setStatus(Status.FAILED);
			}
			result.setObj(deviceDoorResult);
		}
		return result;
	}

	@POST
	@Path(Defines.UPDATE_DEVICE_DOOR + "/{token}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject UpdateDeviceDoor(@CookieParam("sessionid") String session,

			@PathParam("token") String token, JSONObject deviceDoor) {

		ResultObject result = new ResultObject(Status.FAILED);

		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			DeviceDoor device = new DeviceDoor();

			device = Utilites.getInstance().convertJsonObjToObject(deviceDoor, device.getClass());
			DeviceDoor deviceDoorResult = DeviceDoorController.Instance.update(device);

			if (deviceDoorResult != null) {
				result.setStatus(Status.SUCCESS);

			} else {
				result.setStatus(Status.FAILED);
			}
			result.setObj(deviceDoorResult);
		}
		return result;
	}

	@GET
	@Path(Defines.DELETE_DEVICE_DOOR + "/{token}/{deviceDoorId}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject DeleteDeviceDoor(@CookieParam("sessionid") String session, @PathParam("token") String token,
			@PathParam("deviceDoorId") long deviceDoorId) {

		ResultObject result = new ResultObject(Status.FAILED);

		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {

			int status = DeviceDoorController.Instance.delete(deviceDoorId);

			if (status == ErrorCode.SUCCESS) {
				result.setStatus(Status.SUCCESS);

			} else {
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}

	@GET
	@Path(Defines.GET_DEVICE_DOOR_BY_ID + "/{token}/{deviceDoorId}")
	@Consumes(Defines.APPLICATION_JSON)
	public ResultObject GetDeviceDoorById(@CookieParam(value = "sessionid") String session,
			@PathParam("token") String token, @PathParam("deviceDoorId") long deviceDoorId) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {

			DeviceDoor deviceDoorResult = DeviceDoorController.Instance.getDeviceDoorId(deviceDoorId);

			if (deviceDoorResult != null) {
				result.setStatus(Status.SUCCESS);

			} else {
				result.setStatus(Status.FAILED);
			}
			result.setObj(deviceDoorResult);
		}

		return result;
	}

	@GET
	@Path(Defines.GET_DEVICE_DOOR_LIST + "/{token}")
	@Consumes(Defines.APPLICATION_JSON)
	public ResultObject getAppDataList(@CookieParam(value = "sessionid") String session,
			@PathParam("token") String token) {

		ResultObject result = new ResultObject(Status.FAILED);

		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {

			List<DeviceDoor> deviceDoorList = DeviceDoorController.Instance.getDeviceDoorList();
			if (deviceDoorList != null) {
				result.setStatus(Status.SUCCESS);

			} else {
				result.setStatus(Status.FAILED);
			}
			result.setObj(deviceDoorList);
		}

		return result;
	}
}
