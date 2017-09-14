package com.sworld.saigonpearl.services;

import java.util.ArrayList;
import java.util.List;

import javax.ws.rs.Consumes;
import javax.ws.rs.CookieParam;
import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;

import org.codehaus.jettison.json.JSONArray;
import org.codehaus.jettison.json.JSONObject;

import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;
import com.sworld.common.Defines;
import com.sworld.common.ResultObject;
import com.sworld.common.Status;
import com.sworld.common.Utilites;
import com.sworld.saigonpearl.common.SaigonPearlDefines;
import com.swt.saigonpearl.domain.DeviceDoorGroup;
import com.swt.saigonpearl.domain.DoorOut;
import com.swt.saigonpearl.domain.DoorOutFilterDto;
import com.swt.saigonpearl.domain.RoleChipPersonalization;
import com.swt.saigonpearl.domain.RoleChipPersonalizationCustomDTO;
import com.swt.saigonpearl.domain.RoleDTO;
import com.swt.saigonpearl.impls.AccessController;
import com.swt.saigonpearl.impls.DeviceDoorGroupController;
import com.swt.saigonpearl.impls.DeviceDoorGroupDeviceDoorController;
import com.swt.saigonpearl.impls.DoorOutController;
import com.swt.saigonpearl.impls.RoleChipPersonalizationController;
import com.swt.saigonpearl.impls.RoleController;
import com.swt.saigonpearl.impls.RoleDeviceDoorGroupController;
import com.swt.sworld.common.domain.Config;
import com.swt.sworld.common.errors.ErrorCode;
import com.swt.sworld.common.utilitis.TokenManager;
import com.swt.sworld.customer.object.DeviceDoorCustom;
import com.swt.sworld.customer.object.DeviceDoorGroupPostToServer;
import com.swt.sworld.customer.object.RoleChipPersonalizationDTO;
import com.swt.sworld.device.domain.DeviceDoor;
import com.swt.sworld.ps.domain.ChipPersonalization;
import com.swt.sworld.ps.impl.ChipPersonalizationController;

/**
 * @author Cong Thanh
 * 
 */

@Path(SaigonPearlDefines.Access)
@Produces(Defines.APPLICATION_JSON)
public class AccessManager {

	@POST
	@Path(SaigonPearlDefines.ACCESS_PROCESS_NOMAL + "/{token}/{mode}/{ipAddress}")
	@Consumes(Defines.APPLICATION_JSON)
	public ResultObject AccessProcess(@CookieParam(value = "sessionid") String session,

			@PathParam("token") String token, @PathParam("mode") int mode, @PathParam("ipAddress") String ipAddress,
			JSONObject doorOut) {
		ResultObject result = new ResultObject(Status.FAILED);

		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			DoorOut doorOutDB;
			DoorOut doorOutRequest = new DoorOut();

			doorOutRequest = Utilites.getInstance().convertJsonObjToObject(doorOut, doorOutRequest.getClass());
			//new trien khai cho saigonpearl thi xu ly ra vao binh thuong khong theo nhom.
			if (mode == SaigonPearlDefines.SAIGON_PEARL_CODE) {
				doorOutDB = AccessController.Instance.AccessProcess(ipAddress, doorOutRequest);
			} else {
				//xu ly ra vao theo nhom nguoi, nhom cua
				doorOutDB = AccessController.Instance.AccessProcessNomal(ipAddress, doorOutRequest);
			}
			if (doorOutDB != null) {
				result.setStatus(Status.SUCCESS);

			} else {
				result.setStatus(Status.FAILED);
			}
			result.setObj(doorOutDB);
		}

		return result;
	}
	/**
	 * ham xu ly ra vao cua su dung doi tuong nhan vao string
	 * @param session
	 * @param token
	 * @param mode
	 * @param ipAddress
	 * @param doorOut
	 * @return
	 */
	@POST
	@Path(SaigonPearlDefines.ACCESS_PROCESS_OBJECT_STRING + "/{token}/{mode}/{ipAddress}")
	@Consumes(Defines.APPLICATION_JSON)
	public ResultObject AccessProcessString(@CookieParam(value = "sessionid") String session,

			@PathParam("token") String token, @PathParam("mode") int mode, @PathParam("ipAddress") String ipAddress,
			String doorOut) {
		ResultObject result = new ResultObject(Status.FAILED);

		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			DoorOut doorOutDB;
			Gson gson = new Gson(); 
			DoorOut doorOutRequest = gson.fromJson(doorOut, DoorOut.class);
			//new trien khai cho saigonpearl thi xu ly ra vao binh thuong khong theo nhom.
			if (mode == SaigonPearlDefines.SAIGON_PEARL_CODE) {
				doorOutDB = AccessController.Instance.AccessProcess(ipAddress, doorOutRequest);
			} else {
				//xu ly ra vao theo nhom nguoi, nhom cua
				doorOutDB = AccessController.Instance.AccessProcessNomal(ipAddress, doorOutRequest);
			}
			if (doorOutDB != null) {
				result.setStatus(Status.SUCCESS);

			} else {
				result.setStatus(Status.FAILED);
			}
			result.setObj(doorOutDB);
		}

		return result;
	}
	@GET
	@Path(SaigonPearlDefines.LOAD_ACCESS_CONFIG + "/{token}")
	@Consumes(Defines.APPLICATION_JSON)
	public ResultObject LoadAccessConfig(@CookieParam(value = "sessionid") String session,
			@PathParam("token") String token) {
		ResultObject result = new ResultObject(Status.FAILED);

		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {

			Config config = AccessController.Instance.getConfigByName();

			if (config != null) {
				result.setStatus(Status.SUCCESS);

			} else {
				result.setStatus(Status.FAILED);
			}
			result.setObj(config);
		}

		return result;
	}

	@POST
	@Path(SaigonPearlDefines.UPDATE_ACCESS_CONFIG + "/{token}")
	@Consumes(Defines.APPLICATION_JSON)
	public ResultObject UpdateAccessConfig(@CookieParam(value = "sessionid") String session,

			@PathParam("token") String token, JSONObject config) {
		ResultObject result = new ResultObject(Status.FAILED);

		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {

			Config configRequest = new Config();

			configRequest = Utilites.getInstance().convertJsonObjToObject(config, configRequest.getClass());
			Config configDB = AccessController.Instance.getConfigByName();

			if (configDB == null) {
				configDB = AccessController.Instance.insertConfig(configRequest.getValue());
			} else {
				configDB = AccessController.Instance.updateConfig(configRequest);
			}

			if (configDB != null) {
				result.setStatus(Status.SUCCESS);

			} else {
				result.setStatus(Status.FAILED);
			}
			result.setObj(configDB);
		}

		return result;
	}

	@GET
	@Path(SaigonPearlDefines.DELETE_DEVICEDOOR_GROUP + "/{token}/{deviceDoorGroupId}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject DeleteDeviceDoorGroup(@CookieParam("sessionid") String session,
			@PathParam("token") String token, @PathParam("deviceDoorGroupId") long deviceDoorGroupId) {

		ResultObject result = new ResultObject(Status.FAILED);

		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {

			int status = DeviceDoorGroupController.Instance.delete(deviceDoorGroupId);

			if (status == ErrorCode.SUCCESS) {
				result.setStatus(Status.SUCCESS);

			} else {
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}

	@POST
	@Path(SaigonPearlDefines.GET_DOOR_OUT_LIST + "/{token}")
	@Consumes(Defines.APPLICATION_JSON)
	public ResultObject GetDoorOutList(@CookieParam(value = "sessionid") String session,

			@PathParam("token") String token, JSONObject filter) {
		ResultObject result = new ResultObject(Status.FAILED);

		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {

			DoorOutFilterDto doorOutFilterDto = new DoorOutFilterDto();

			doorOutFilterDto = Utilites.getInstance().convertJsonObjToObject(filter, doorOutFilterDto.getClass());
			List<DoorOut> doorOutDB = DoorOutController.Instance.getDoorOutByFilter(doorOutFilterDto);

			if (doorOutDB != null) {
				result.setStatus(Status.SUCCESS);

			} else {
				result.setStatus(Status.FAILED);
			}
			result.setObj(doorOutDB);
		}

		return result;
	}

	@GET
	@Path(SaigonPearlDefines.GET_DOOR_OUT_BY_ID + "/{token}/{doorOutId}")
	@Consumes(Defines.APPLICATION_JSON)
	public ResultObject GetDoorOutById(@CookieParam(value = "sessionid") String session,
			@PathParam("token") String token, @PathParam("doorOutId") long doorOutId) {
		ResultObject result = new ResultObject(Status.FAILED);

		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			DoorOut doorOut = DoorOutController.Instance.getDoorOutById(doorOutId);
			if (doorOut != null) {
				result.setStatus(Status.SUCCESS);
			} else {
				result.setStatus(Status.FAILED);
			}
			result.setObj(doorOut);
		}
		return result;
	}

	// ------------------------------------------------------------------------------------------------------------------
	// // Phan nay danh cho access control
	@POST
	@Path(SaigonPearlDefines.INSERT_DEVICEDOOR_GROUP + "/{token}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject InsertDeviceDoorGroup(@CookieParam("sessionid") String session,
			@PathParam("token") String token, JSONObject deviceDoorGroup) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			DeviceDoorGroup deviceDoor = new DeviceDoorGroup();
			deviceDoor = Utilites.getInstance().convertJsonObjToObject(deviceDoorGroup, deviceDoor.getClass());
			DeviceDoorGroup deviceDoorResult = DeviceDoorGroupController.Instance.insert(deviceDoor);

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
	@Path(SaigonPearlDefines.UPDATE_DEVICEDOOR_GROUP + "/{token}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject UpdateDeviceDoorGroup(@CookieParam("sessionid") String session,

			@PathParam("token") String token, JSONObject deviceDoor) {

		ResultObject result = new ResultObject(Status.FAILED);

		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			DeviceDoorGroup device = new DeviceDoorGroup();

			device = Utilites.getInstance().convertJsonObjToObject(deviceDoor, device.getClass());
			DeviceDoorGroup deviceDoorResult = DeviceDoorGroupController.Instance.update(device);

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
	@Path(SaigonPearlDefines.GET_DEVICE_DOOR_LIST_BY_GROUP_ID + "/{token}/{deviceDoorGroupId}")
	@Consumes(Defines.APPLICATION_JSON)
	public ResultObject GetDeviceDoorListByGroupId(@CookieParam(value = "sessionid") String session,
			@PathParam("token") String token, @PathParam("deviceDoorGroupId") long deviceDoorGroupId) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			List<DeviceDoor> deviceDoorResult = DeviceDoorGroupDeviceDoorController.Instance
					.getListDeviceDoorGroupDeviceDoorByGroupId(deviceDoorGroupId);
			
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
	@Path(SaigonPearlDefines.GET_DEVICEDOOR_GROUP_BY_ID + "/{token}/{deviceDoorGroupId}")
	@Consumes(Defines.APPLICATION_JSON)
	public ResultObject getDeviceDoorGroupById(@CookieParam(value = "sessionid") String session,
			@PathParam("token") String token, @PathParam("deviceDoorGroupId") long deviceDoorGroupId) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {

			DeviceDoorGroup deviceDoorGroup = DeviceDoorGroupController.Instance
					.getDeviceDoorGroupById(deviceDoorGroupId);
			if (deviceDoorGroup != null) {
				result.setStatus(Status.SUCCESS);

			} else {
				result.setStatus(Status.FAILED);
			}
			result.setObj(deviceDoorGroup);
		}

		return result;
	}

	/*
	 * Ham nay lay danh sach cac nhom thiet bi
	 */
	@GET
	@Path(SaigonPearlDefines.GET_DEVICEDOOR_GROUP_LIST + "/{token}")
	@Consumes(Defines.APPLICATION_JSON)
	public ResultObject getDeviceDoorGroupList(@CookieParam(value = "sessionid") String session,
			@PathParam("token") String token) {
		ResultObject result = new ResultObject(Status.FAILED);

		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {

			List<DeviceDoorGroup> deviceDoorGroupList = DeviceDoorGroupController.Instance.getDeviceDoorGroup();
			if (deviceDoorGroupList != null) {
				result.setStatus(Status.SUCCESS);
				result.setObj(deviceDoorGroupList);
			} else {
				result.setStatus(Status.FAILED);
			}
		}

		return result;
	}

	/*
	 * Ham nay insert 1 list device theo group muc dich la de nhom cac thiet bi
	 * theo group.
	 */
	@POST
	@Path(SaigonPearlDefines.INSERT_LIST_DEVICEDOOR_BY_GROUPID + "/{token}/{deviceDoorGroupId}")
	@Consumes(Defines.APPLICATION_JSON)
	public ResultObject insertListDeviceDoorByGroupId(@CookieParam(value = "sessionid") String session,
			@PathParam("token") String token, @PathParam("deviceDoorGroupId") long deviceDoorGroupId,
			JSONObject jsonObject) {
		ResultObject result = new ResultObject(Status.FAILED);

		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			DeviceDoorCustom deviceDoorCustom = new DeviceDoorCustom();
			deviceDoorCustom = Utilites.getInstance().convertJsonObjToObject(jsonObject, DeviceDoorCustom.class);
			int kq = DeviceDoorGroupDeviceDoorController.Instance.insertListDeviceDoorGroupDeviceDoor(deviceDoorGroupId,
					deviceDoorCustom);
			if (kq < 0) {
				result.setStatus(Status.FAILED);
			} else {
				result.setStatus(Status.SUCCESS);
			}
		}

		return result;
	}

	/*
	 * Ham nay lay danh sach cac thiet bi theo group Id trong bang
	 * DeviceDoorGroupDeviceDoor muc dich chu yeu de show trong datatable
	 */
	@POST
	@Path(SaigonPearlDefines.DELETE_LIST_DEVICEDOOR_BY_GROUPID + "/{token}")
	@Consumes(Defines.APPLICATION_JSON)
	public ResultObject deleteListDeviceDoorByGroupId(@CookieParam(value = "sessionid") String session,
			@PathParam("token") String token, JSONArray lstDeviceDoorGroupDeviceDoorId) {
		ResultObject result = new ResultObject(Status.FAILED);

		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			List<Long> deviceDoorGroupDeviceDoorDTOs = Utilites.getInstance()
					.convertJsonArrayToListLong(lstDeviceDoorGroupDeviceDoorId);
			List<Long> lstDeviceDoorGroupDeviceDoor = DeviceDoorGroupDeviceDoorController.Instance
					.deleteListDeviceDoorGroupDeviceDoor(deviceDoorGroupDeviceDoorDTOs);
			if (null != lstDeviceDoorGroupDeviceDoor) {
				result.setStatus(Status.SUCCESS);
			} else {
				result.setStatus(Status.FAILED);
			}
		}

		return result;
	}

	@GET
	@Path(SaigonPearlDefines.GET_PERSONALIZATION_LIST + "/{token}")
	@Consumes(Defines.APPLICATION_JSON)
	public ResultObject getPersonalizationList(@CookieParam(value = "sessionid") String session,
			@PathParam("token") String token) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {

			List<ChipPersonalization> chipPersonalizationList = ChipPersonalizationController.Instance.getAll(0);
			if (chipPersonalizationList != null) {
				result.setStatus(Status.SUCCESS);

			} else {
				result.setStatus(Status.FAILED);
			}
			result.setObj(chipPersonalizationList);
		}

		return result;
	}

	@POST
	@Path(SaigonPearlDefines.GET_LIST_MEMBER_BY_LIST_SUBORG_ID + "/{token}/{groupid}")
	@Consumes(Defines.APPLICATION_JSON)
	public ResultObject getListMemberByListSubOrgId(@CookieParam("sessionid") String session,
			@PathParam("token") String token, @PathParam("groupid") long groupid, JSONArray jsonArray) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {

			List<Long> listIdSubOrg = Utilites.getInstance().convertJsonArrayToListLong(jsonArray);
			List<RoleChipPersonalizationCustomDTO> listResult = RoleChipPersonalizationController.Instance
					.getListMemberByListSubOrgId(listIdSubOrg, groupid);

			if (listResult != null) {
				result.setStatus(Status.SUCCESS);

			} else {
				result.setStatus(Status.FAILED);
			}
			result.setObj(listResult);
		}

		return result;
	}

	@GET
	@Path(SaigonPearlDefines.GET_ROLE_LIST + "/{token}")
	@Consumes(Defines.APPLICATION_JSON)
	public ResultObject getRoleList(@CookieParam(value = "sessionid") String session,
			@PathParam("token") String token) {
		ResultObject result = new ResultObject(Status.FAILED);

		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {

			List<RoleDTO> roleList = RoleController.Instance.getRoles();
			if (roleList != null) {
				result.setStatus(Status.SUCCESS);
				result.setObj(roleList);
			} else {
				result.setStatus(Status.FAILED);
			}
		}

		return result;
	}

	@POST
	@Path(SaigonPearlDefines.INSERT_ROLE + "/{token}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject InsertRole(@CookieParam("sessionid") String session, @PathParam("token") String token,
			JSONObject roleObj) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			RoleDTO role = new RoleDTO();
			role = Utilites.getInstance().convertJsonObjToObject(roleObj, role.getClass());
			RoleDTO roleResult = RoleController.Instance.insert(role);

			if (roleResult != null) {
				result.setStatus(Status.SUCCESS);

			} else {
				result.setStatus(Status.FAILED);
			}
			result.setObj(roleResult);
		}
		return result;
	}

	@POST
	@Path(SaigonPearlDefines.UPDATE_ROLE + "/{token}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject UpdateRole(@CookieParam("sessionid") String session,

			@PathParam("token") String token, JSONObject roleObj) {

		ResultObject result = new ResultObject(Status.FAILED);

		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			RoleDTO role = new RoleDTO();

			role = Utilites.getInstance().convertJsonObjToObject(roleObj, role.getClass());
			RoleDTO roleResult = RoleController.Instance.update(role);

			if (roleResult != null) {
				result.setStatus(Status.SUCCESS);

			} else {
				result.setStatus(Status.FAILED);
			}
			result.setObj(roleResult);
		}
		return result;
	}

	@GET
	@Path(SaigonPearlDefines.GET_ROLE_BY_ID + "/{token}/{roleId}")
	@Consumes(Defines.APPLICATION_JSON)
	public ResultObject getRoleById(@CookieParam(value = "sessionid") String session, @PathParam("token") String token,
			@PathParam("roleId") long roleId) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			RoleDTO role = RoleController.Instance.getRoleById(roleId);
			if (role != null) {
				result.setStatus(Status.SUCCESS);

			} else {
				result.setStatus(Status.FAILED);
			}
			result.setObj(role);
		}
		return result;
	}

	@GET
	@Path(SaigonPearlDefines.DELETE_ROLE + "/{token}/{roleId}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject DeleteRole(@CookieParam("sessionid") String session, @PathParam("token") String token,
			@PathParam("roleId") long roleId) {

		ResultObject result = new ResultObject(Status.FAILED);

		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			int status = RoleController.Instance.delete(roleId);
			if (status == ErrorCode.SUCCESS) {
				result.setStatus(Status.SUCCESS);
			} else {
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}

	@GET
	@Path(SaigonPearlDefines.GET_PERSONALIZATION_BY_ROLE_ID + "/{token}/{roleId}")
	@Consumes(Defines.APPLICATION_JSON)
	public ResultObject GetPersonalizationByRoleId(@CookieParam(value = "sessionid") String session,
			@PathParam("token") String token, @PathParam("roleId") long roleId) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			List<RoleChipPersonalizationCustomDTO> roleChipPersonalizations = RoleChipPersonalizationController.Instance
					.getRoleChipPersonalizationsByRoleId(roleId);
			if (roleChipPersonalizations != null) {
				result.setStatus(Status.SUCCESS);
			} else {
				result.setStatus(Status.FAILED);
			}
			result.setObj(roleChipPersonalizations);
		}
		return result;
	}

	@POST
	@Path(SaigonPearlDefines.INSERT_PERSONALIZATION_BY_ROLEID + "/{token}/{roleId}")
	@Consumes(Defines.APPLICATION_JSON)
	public ResultObject insertPersonalizationByRoleId(@CookieParam(value = "sessionid") String session,
			@PathParam("token") String token, @PathParam("roleId") long roleId,
			JSONArray lstRoleChipPersonalizationDTO) {
		ResultObject result = new ResultObject(Status.FAILED);

		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			List<RoleChipPersonalizationDTO> roleChipPersonalizationDTOs = new ArrayList<RoleChipPersonalizationDTO>();

			// conver jsonarray role chip persionalization to list
			TypeToken<List<RoleChipPersonalizationDTO>> temp = new TypeToken<List<RoleChipPersonalizationDTO>>() {
			};
			Gson gson = new Gson();
			roleChipPersonalizationDTOs = gson.fromJson(lstRoleChipPersonalizationDTO.toString(), temp.getType());
			List<RoleChipPersonalization> roleChipPersonalizations = RoleChipPersonalizationController.Instance
					.insertRoleChipPersonalizationsByRoleId(roleId, roleChipPersonalizationDTOs);
			if (null != roleChipPersonalizations) {
				result.setStatus(Status.SUCCESS);
			} else {
				result.setStatus(Status.FAILED);
			}

		}
		return result;
	}

	@POST
	@Path(SaigonPearlDefines.INSERT_ROLE_DEVICE_DOORGROUP + "/{token}/{roleId}")
	@Consumes(Defines.APPLICATION_JSON)
	public ResultObject insertRoleDeviceDoorGroup(@CookieParam(value = "sessionid") String session,
			@PathParam("token") String token, @PathParam("roleId") long roleId, JSONObject lstIdDeviceDoorGroupDTO) {
		ResultObject result = new ResultObject(Status.FAILED);

		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			DeviceDoorGroupPostToServer deviceDoorGroupPostToServer = new DeviceDoorGroupPostToServer();

			// conver jsonarray role chip persionalization to list
			deviceDoorGroupPostToServer = Utilites.getInstance().convertJsonObjToObject(lstIdDeviceDoorGroupDTO, DeviceDoorGroupPostToServer.class);

			int kq = RoleDeviceDoorGroupController.Instance.insertRoleDeviceDoorGroupByRoleId(roleId,
					deviceDoorGroupPostToServer);
			if (kq >= 0) {
				result.setStatus(Status.SUCCESS);
			} else {
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}

	@POST
	@Path(SaigonPearlDefines.DELETE_LIST_MEMBER_FROM_GROUP + "/{token}")
	@Consumes(Defines.APPLICATION_JSON)
	public ResultObject deleteListMemberFromGroup(@CookieParam(value = "sessionid") String session,
			@PathParam("token") String token, JSONArray lstDeviceDoorGroupDeviceDoorId) {
		ResultObject result = new ResultObject(Status.FAILED);

		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			List<Long> idRoleChip = Utilites.getInstance().convertJsonArrayToListLong(lstDeviceDoorGroupDeviceDoorId);
			List<Long> lstDeviceDoorGroupDeviceDoor = RoleChipPersonalizationController.Instance
					.deleteListRoleChipPersonalization(idRoleChip);
			if (null != lstDeviceDoorGroupDeviceDoor) {
				result.setStatus(Status.SUCCESS);
			} else {
				result.setStatus(Status.FAILED);
			}
		}

		return result;
	}

	@GET
	@Path(SaigonPearlDefines.GET_DEVICEDOOR_GROUP_LIST_BY_ROLEID + "/{token}/{roleId}")
	@Consumes(Defines.APPLICATION_JSON)
	public ResultObject getDeviceDoorGroupListByRoleId(@CookieParam(value = "sessionid") String session,
			@PathParam("token") String token, @PathParam("roleId") long roleId) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			List<DeviceDoorGroup> lstdeviceDoorGroupCustomer = RoleDeviceDoorGroupController.Instance
					.getRoleDeviceDoorGroupByRoleId(roleId);

			if (lstdeviceDoorGroupCustomer != null) {
				result.setStatus(Status.SUCCESS);

			} else {
				result.setStatus(Status.FAILED);
			}
			result.setObj(lstdeviceDoorGroupCustomer);
		}
		return result;
	}

}
