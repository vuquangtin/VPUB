package com.sworld.timekeeping.services;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.List;

import javax.ws.rs.Consumes;
import javax.ws.rs.CookieParam;
import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;

import org.codehaus.jettison.json.JSONArray;
import org.codehaus.jettison.json.JSONObject;

import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;
import com.sworld.common.Defines;
import com.sworld.common.ResultObject;
import com.sworld.common.Status;
import com.sworld.common.Utilites;
import com.sworld.timekeeping.common.TimeKeepingDefines;
import com.sworld.timekeeping.common.TimeKeepingUtilites;
import com.swt.sworld.device.domain.DeviceDoor;
import com.swt.sworld.common.errors.ErrorCode;
import com.swt.sworld.common.utilitis.TokenManager;
import com.swt.sworld.ps.domain.Member;
import com.swt.sworld.ps.impl.MemberController;
import com.swt.timekeeping.customer.object.ConfigForStatisticDTO;
import com.swt.timekeeping.customer.object.EventFilter;
import com.swt.timekeeping.customer.object.TimeKeepingAcessDTO;
import com.swt.timekeeping.domain.DailyConfig;
import com.swt.timekeeping.domain.Event;
import com.swt.timekeeping.domain.TimeConfig;
import com.swt.timekeeping.domain.DeviceConfig;
import com.swt.timekeeping.domain.UserTimeConfig;
import com.swt.timekeeping.impls.TimeKeepingDailyConfigController;
import com.swt.timekeeping.impls.TimeKeepingDeviceConfigController;
import com.swt.timekeeping.impls.TimeKeepingEventController;
import com.swt.timekeeping.impls.TimeKeepingTimeConfigController;
import com.swt.timekeeping.impls.TimekeepingUserTimeConfigController;
/**
 * 
 * @author Trang-PC
 *
 */
@Path(TimeKeepingDefines.TIMEKEEPINGCONFIGMANAGER)
@Produces(TimeKeepingDefines.APPLICATION_JSON)
public class TimeKeepingConfigManager {

	/*
	 * service for timekeepingdeviceconfig
	 */
	@GET
	@Path(TimeKeepingDefines.CHECK_DEVICE_IP_CONFIG
			+ "/{token}/{serial}/{deviceconfigip}")
	@Consumes(TimeKeepingDefines.APPLICATION_JSON)
	public ResultObject checkIpDeviceForTimeKeeping(
			@CookieParam("sessionid") String session,
			@PathParam("token") String token,
			@PathParam("serial") String serial,
			@PathParam("deviceconfigip") String deviceConfigIp) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session,
				token);
		if (flag) {
			TimeKeepingAcessDTO resultObj = TimeKeepingDeviceConfigController.Instance
					.checkIpDeviceForTimeKeeping(serial, deviceConfigIp);
			if (null != resultObj) {
				result.setStatus(Status.SUCCESS);
			} else {
				result.setStatus(Status.FAILED);
			}
			result.setObj(resultObj);
		}
		return result;
	}

	@GET
	@Path(TimeKeepingDefines.GET_TIMEKEEPING_DEVICE_CONFIG
			+ "/{token}/{deviceconfigid}")
	@Consumes(TimeKeepingDefines.APPLICATION_JSON)
	public ResultObject getConfigByDeviceConfigId(
			@CookieParam("sessionid") String session,
			@PathParam("token") String token,
			@PathParam("deviceconfigid") long deviceConfigId) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session,
				token);
		if (flag) {
			DeviceConfig timeKeepingDeviceConfig = TimeKeepingDeviceConfigController.Instance
					.getTimeKeepingConfigById(deviceConfigId);
			if (null != timeKeepingDeviceConfig) {
				result.setStatus(Status.SUCCESS);
			} else {
				result.setStatus(Status.FAILED);
			}
			result.setObj(timeKeepingDeviceConfig);
		}
		return result;
	}

	@POST
	@Path(TimeKeepingDefines.INSERT_TIMEKEEPING_DEVICE_CONFIG + "/{token}")
	@Consumes(TimeKeepingDefines.APPLICATION_JSON)
	public ResultObject insertDeviceConfig(
			@CookieParam(value = "sessionid") String session,
			@PathParam("token") String token, JSONObject deviceConfig) {
		ResultObject result = new ResultObject(Status.FAILED);

		boolean flag = TokenManager.getInstance().checkTokenSession(session,
				token);
		if (flag) {
			DeviceConfig deviceConfigRequest = new DeviceConfig();

			deviceConfigRequest = Utilites.getInstance()
					.convertJsonObjToObject(deviceConfig,
							deviceConfigRequest.getClass());
			DeviceConfig deviceConfigDB = TimeKeepingDeviceConfigController.Instance
					.insert(deviceConfigRequest);

			if (deviceConfigDB != null) {
				result.setStatus(Status.SUCCESS);
			} else {
				result.setStatus(Status.FAILED);
			}
			result.setObj(deviceConfigDB);
		}

		return result;
	}

	@POST
	@Path(TimeKeepingDefines.UPDATE_TIMEKEEPING_DEVICE_CONFIG + "/{token}")
	@Consumes(TimeKeepingDefines.APPLICATION_JSON)
	public ResultObject updateDeviceConfig(
			@CookieParam("sessionid") String session,
			@PathParam("token") String token, JSONObject deviceConfig) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session,
				token);
		if (flag) {
			DeviceConfig deviceConfigRequest = new DeviceConfig();

			deviceConfigRequest = Utilites.getInstance()
					.convertJsonObjToObject(deviceConfig,
							deviceConfigRequest.getClass());
			if (null != TimeKeepingDeviceConfigController.Instance
					.update(deviceConfigRequest));
			result.setStatus(Status.SUCCESS);
		}
		return result;
	}

	@GET
	@Path(TimeKeepingDefines.DELETE_TIMEKEEPING_DEVICE_CONFIG
			+ "/{token}/{deviceconfigid}")
	@Consumes(TimeKeepingDefines.APPLICATION_JSON)
	public ResultObject deleteDeviceConfig(
			@CookieParam("sessionid") String session,
			@PathParam("token") String token,
			@PathParam("deviceconfigid") long deviceConfigId) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session,
				token);
		if (flag) {
			int kq = TimeKeepingDeviceConfigController.Instance
					.delete(deviceConfigId);
			if (kq == ErrorCode.SUCCESS) {
				result.setStatus(Status.SUCCESS);
			} else {
				result.setStatus(Status.FAILED);
			}
		}

		return result;
	}

	// insert devicecofig theo orgid gui len orgId va listdevice de insert vao
	// bang deviceconfig
	@POST
	@Path(TimeKeepingDefines.INSERT_TIMEKEEPING_DEVICE_CONFIG_BY_ORG_ID
			+ "/{token}/{orgId}")
	@Consumes(TimeKeepingDefines.APPLICATION_JSON)
	public ResultObject insertDeviceConfigByOrgId(
			@CookieParam("sessionid") String session,
			@PathParam("token") String token, @PathParam("orgId") long orgId,
			JSONArray lstDeviceDoorJson) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session,
				token);
		if (flag) {
			List<DeviceConfig> listDeviceConfig = new ArrayList<DeviceConfig>();
			// conver jsonarray DeviceConfig to list
			TypeToken<List<DeviceConfig>> temp = new TypeToken<List<DeviceConfig>>() {
			};
			Gson gson = new Gson();
			listDeviceConfig = gson.fromJson(lstDeviceDoorJson.toString(),
					temp.getType());
			int kq = TimeKeepingDeviceConfigController.Instance
					.insertDeviceConfigByOrgId(orgId, listDeviceConfig);
			if (kq == ErrorCode.SUCCESS) {
				result.setStatus(Status.SUCCESS);
			} else {
				result.setStatus(Status.FAILED);
			}
		}

		return result;
	}

	// getlist deviceconfig by orgid
	@GET
	@Path(TimeKeepingDefines.GET_LIST_DEVICECONFIG_BY_ORG_ID
			+ "/{token}/{orgId}")
	@Consumes(Defines.APPLICATION_JSON)
	public ResultObject getListDeviceConfigByOrgId(
			@CookieParam(value = "sessionid") String session,
			@PathParam("token") String token, @PathParam("orgId") long orgId) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session,
				token);
		if (flag) {
			List<DeviceDoor> lstDeviceConfig = TimeKeepingDeviceConfigController.Instance
					.getListDeviceConfigByOrgId(orgId);
			if (lstDeviceConfig != null) {
				result.setStatus(Status.SUCCESS);

			} else {
				result.setStatus(Status.FAILED);
			}
			result.setObj(lstDeviceConfig);
		}
		return result;
	}

	/**
	 * delete list deviceConfig
	 * 
	 * @param session
	 * @param token
	 * @param lstDeviceDoorGroupDeviceDoorId
	 * @return
	 */
	@POST
	@Path(TimeKeepingDefines.DELETE_LIST_DEVICE_CONFIG + "/{token}")
	@Consumes(Defines.APPLICATION_JSON)
	public ResultObject deleteListDeviceConfig(
			@CookieParam(value = "sessionid") String session,
			@PathParam("token") String token, JSONArray lstDeviceConfigIdJson) {
		ResultObject result = new ResultObject(Status.FAILED);

		boolean flag = TokenManager.getInstance().checkTokenSession(session,
				token);
		if (flag) {
			List<Long> lstId = Utilites.getInstance()
					.convertJsonArrayToListLong(lstDeviceConfigIdJson);
			// du lieu tra ve la mot kieu int la success hay failed
			int kq = TimeKeepingDeviceConfigController.Instance
					.deleteListDeviceConfig(lstId);
			if (kq == ErrorCode.SUCCESS) {
				result.setStatus(Status.SUCCESS);
			} else {
				result.setStatus(Status.FAILED);
			}
		}

		return result;
	}

	// service for timekeepingtimeconfig

	@GET
	@Path(TimeKeepingDefines.GET_TIMEKEEPING_TIME_CONFIG
			+ "/{token}/{timeconfigid}")
	@Consumes(TimeKeepingDefines.APPLICATION_JSON)
	public ResultObject getConfigByTimeConfigId(
			@CookieParam("sessionid") String session,
			@PathParam("token") String token,
			@PathParam("timeconfigid") long timeConfigId) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session,
				token);
		if (flag) {
			TimeConfig timeKeepingDeviceConfig = TimeKeepingTimeConfigController.Instance
					.getTimeKeepingConfigById(timeConfigId);
			if (timeKeepingDeviceConfig != null) {
				result.setStatus(Status.SUCCESS);
			} else {
				result.setStatus(Status.FAILED);
			}
			result.setObj(timeKeepingDeviceConfig);
		}
		return result;
	}

	@POST
	@Path(TimeKeepingDefines.INSERT_TIMEKEEPING_TIME_CONFIG + "/{token}")
	@Consumes(TimeKeepingDefines.APPLICATION_JSON)
	public ResultObject insertTimeKeepingTimeConfig(
			@CookieParam(value = "sessionid") String session,
			@PathParam("token") String token, JSONObject timeConfig) {
		ResultObject result = new ResultObject(Status.FAILED);

		boolean flag = TokenManager.getInstance().checkTokenSession(session,
				token);
		if (flag) {
			TimeConfig timekeepingTimeConfig = new TimeConfig();

			timekeepingTimeConfig = Utilites.getInstance()
					.convertJsonObjToObject(timeConfig,
							timekeepingTimeConfig.getClass());
			TimeConfig timeConfigDB = TimeKeepingTimeConfigController.Instance
					.insert(timekeepingTimeConfig);

			if (timeConfigDB != null) {
				result.setStatus(Status.SUCCESS);
			} else {
				result.setStatus(Status.FAILED);
			}
			result.setObj(timeConfigDB);
		}

		return result;
	}

	/**
	 * insert list time keeping configuration
	 * 
	 * @param session
	 * @param token
	 * @param lsttimeconfig
	 * : list data
	 * @return
	 */
	@POST
	@Path(TimeKeepingDefines.INSERT_TIMEKEEPING_LIST_TIME_CONFIG + "/{token}/{orgId}")
	@Consumes(TimeKeepingDefines.APPLICATION_JSON)
	public ResultObject insertListTimeKeepingTimeConfig(
			@CookieParam(value = "sessionid") String session,
			@PathParam("token") String token,
			@PathParam("orgId") long orgId,JSONArray lsttimeconfig) {
		ResultObject result = new ResultObject(Status.FAILED);

		boolean flag = TokenManager.getInstance().checkTokenSession(session,
				token);
		if (flag) {

			List<TimeConfig> lst = TimeKeepingUtilites.getInstance()
					.convertJsonArrayToListTimeKeeping(lsttimeconfig);
			int tmp = TimeKeepingTimeConfigController.Instance.insert(lst,orgId);

			if (tmp > 0) {
				result.setStatus(Status.SUCCESS);
			} else {
				result.setStatus(Status.FAILED);
			}
		}

		return result;
	}

	@POST
	@Path(TimeKeepingDefines.UPDATE_TIMEKEEPING_TIME_CONFIG + "/{token}")
	@Consumes(TimeKeepingDefines.APPLICATION_JSON)
	public ResultObject updateTimeKeepingTimeConfig(
			@CookieParam("sessionid") String session,
			@PathParam("token") String token, JSONObject timeConfig) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session,
				token);
		if (flag) {
			TimeConfig timeKeepingTimeConfig = new TimeConfig();

			timeKeepingTimeConfig = Utilites.getInstance()
					.convertJsonObjToObject(timeConfig,
							timeKeepingTimeConfig.getClass());
			if (null != TimeKeepingTimeConfigController.Instance
					.update(timeKeepingTimeConfig))
				;
			result.setStatus(Status.SUCCESS);
		}
		return result;
	}

	@GET
	@Path(TimeKeepingDefines.DELETE_TIMEKEEPING_TIME_CONFIG
			+ "/{token}/{timekeepingtimeconfigid}")
	@Consumes(TimeKeepingDefines.APPLICATION_JSON)
	public ResultObject deleteTimeKeepingTimeConfig(
			@CookieParam("sessionid") String session,
			@PathParam("token") String token,
			@PathParam("timekeepingtimeconfigid") long timeConfigId) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session,
				token);
		if (flag) {
			int kq = TimeKeepingTimeConfigController.Instance
					.delete(timeConfigId);
			if (kq == ErrorCode.SUCCESS) {
				result.setStatus(Status.SUCCESS);
			} else {
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}

	@GET
	@Path(TimeKeepingDefines.GET_TIMEKEEPING_TIME_CONFIG_LIST_DAYOFWEEK
			+ "/{token}/{orgid}/{dayofweek}")
	@Consumes(TimeKeepingDefines.APPLICATION_JSON)
	public ResultObject getTimeKeepingTimeConfigList(
			@CookieParam("sessionid") String session,
			@PathParam("token") String token, @PathParam("orgid") long orgId,
			@PathParam("dayofweek") String dayOfWeek) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session,
				token);
		if (flag) {

			List<TimeConfig> timeKeepingDeviceConfigList = TimeKeepingTimeConfigController.Instance
					.getListTimeKeepingTimeConfigByOrgCode(orgId, dayOfWeek);
			if (timeKeepingDeviceConfigList != null) {
				result.setStatus(Status.SUCCESS);
			} else {
				result.setStatus(Status.FAILED);
			}
			result.setObj(timeKeepingDeviceConfigList);
		}
		return result;
	}

	@GET
	@Path(TimeKeepingDefines.GET_TIMEKEEPING_TIME_CONFIG_LIST_ORG_ID
			+ "/{token}/{orgid}")
	@Consumes(TimeKeepingDefines.APPLICATION_JSON)
	public ResultObject getTimeKeepingTimeConfigListOrg(
			@CookieParam("sessionid") String session,
			@PathParam("token") String token, @PathParam("orgid") long orgId) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session,
				token);
		if (flag) {
			List<TimeConfig> timeKeepingDeviceConfigList = TimeKeepingTimeConfigController.Instance
					.getListTimeKeepingTimeConfigByOrgId(orgId);
			if (timeKeepingDeviceConfigList != null) {
				result.setStatus(Status.SUCCESS);
			} else {
				result.setStatus(Status.FAILED);
			}
			result.setObj(timeKeepingDeviceConfigList);
		}
		return result;
	}

	/**
	 * get list event and timeconfig by memberId and date and orgId
	 * 
	 * @param memId
	 * @param date
	 * @param orgId
	 * @return list event
	 */
	@SuppressWarnings({ "deprecation", "unused" })
	@GET
	@Path(TimeKeepingDefines.GET_TIME_CONFIG_EVENT_CONFIG_BY_FILTER
			+ "/{token}/{memberid}/{date}/{orgid}")
	@Consumes(TimeKeepingDefines.APPLICATION_JSON)
	public ResultObject getTimeConfigEventConfigByFilter(
			@CookieParam("sessionid") String session,
			@PathParam("token") String token,
			@PathParam("memberid") long memberId,
			@PathParam("date") String stringDate, @PathParam("orgid") long orgId) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session,
				token);
		if (flag) {
			ConfigForStatisticDTO objResult = new ConfigForStatisticDTO();;

			// get list event by orgid and filter
			List<Event> eventList = null;
			Member member = MemberController.Instance.getMemberById(memberId);
			if (null != member) {
				try {
				EventFilter filter = new EventFilter();
				filter.setFilterByMemberName(true);
				filter.setMemberName(member.getLastName() + " "
						+ member.getFirstName());
				// format: yyyy-MM-dd HH:mm:ss
				SimpleDateFormat sdfs = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
				Date dateEvent = sdfs.parse(stringDate);
				filter.setFilterByDateBegin(true);
				filter.setDateBegin((dateEvent.getYear() + 1900) + "-" + (dateEvent.getMonth() + 1) + "-" + dateEvent.getDate() + " 00:00:00");
				filter.setFilterByDateEnd(true);
				filter.setDateEnd((dateEvent.getYear() + 1900) + "-" + (dateEvent.getMonth() + 1) + "-" + dateEvent.getDate() + " 23:59:59");

				eventList = TimeKeepingEventController.Instance
						.getTimeKeepingEventListByOrgId(filter, orgId);

				// get time config by date (dateformat: yyyy-MM-dd HH:mm:ss)
				DailyConfig dailyConfig = null;
				TimeConfig timeConfig = null;
				String sessionWorking = "";
				
					Date curDate = new Date();
					curDate.setHours(0);
					curDate.setMinutes(0);
					curDate.setSeconds(0);
					//xoa phan tram giay
					long timeCurDate = curDate.getTime() - curDate.getTime() % 1000;
					SimpleDateFormat sdf = new SimpleDateFormat(
							"yyyy-MM-dd HH:mm:ss");
					Date date = sdf.parse(stringDate);
					date.setHours(0);
					date.setMinutes(0);
					date.setSeconds(0);
					long timeDate = date.getTime() - date.getTime() % 1000;
					if (timeCurDate == timeDate) {
						Calendar c = Calendar.getInstance();
						c.setTime(curDate);
						int dayOfWeek = c.get(Calendar.DAY_OF_WEEK);
						timeConfig = TimeKeepingTimeConfigController.Instance
								.getTimeConfigByDayOfWeekOrgId(dayOfWeek, orgId);
						if(null != timeConfig) sessionWorking = timeConfig.getSessionWorking();
					} else {
						dailyConfig = TimeKeepingDailyConfigController.Instance
								.getDailyConfigByDate(date, orgId);
						if(null != dailyConfig) sessionWorking = dailyConfig.getJsonTimeConfig();
					}
				
				// set value to objResult
				if (null != dailyConfig || null != timeConfig) {
					
					objResult.setSessionWorking(sessionWorking);
					if (null != eventList)
						objResult.setEventList(eventList);
				}
				if (null != objResult) {
					result.setStatus(Status.SUCCESS);
				} else {
					result.setStatus(Status.FAILED);
				}
				result.setObj(objResult);
				} catch (ParseException e) {
					e.printStackTrace();
				}
			}
		}
		return result;
	}
	
	// service for timekeepingusertimeconfig
	/**
	 * insert UserTimeConfig
	 * @param session
	 * @param token
	 * @param userTimeConfig
	 * @return
	 */
	@POST
	@Path(TimeKeepingDefines.INSERT_TIMEKEEPING_USER_TIME_CONFIG + "/{token}")
	@Consumes(TimeKeepingDefines.APPLICATION_JSON)
	public ResultObject insertUserTimeConfig(
			@CookieParam(value = "sessionid") String session,
			@PathParam("token") String token, JSONObject userTimeConfig) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			UserTimeConfig objRequest = new UserTimeConfig();
			objRequest = Utilites.getInstance().convertJsonObjToObject(userTimeConfig, objRequest.getClass());
			UserTimeConfig objResult = TimekeepingUserTimeConfigController.Instance.insert(objRequest);
			if (objResult != null) {
				result.setStatus(Status.SUCCESS);
			} else {
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}
	/**
	 * update UserTimeConfig
	 * @param session
	 * @param token
	 * @param userTimeConfig
	 * @return
	 */
	@POST
	@Path(TimeKeepingDefines.UPDATE_TIMEKEEPING_USER_TIME_CONFIG + "/{token}")
	@Consumes(TimeKeepingDefines.APPLICATION_JSON)
	public ResultObject updateUserTimeConfig(
			@CookieParam("sessionid") String session,
			@PathParam("token") String token, JSONObject userTimeConfig) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session,
				token);
		if (flag) {
			UserTimeConfig timeKeepingTimeConfig = new UserTimeConfig();
			timeKeepingTimeConfig = Utilites.getInstance()
					.convertJsonObjToObject(userTimeConfig, timeKeepingTimeConfig.getClass());			
			UserTimeConfig objResult = TimekeepingUserTimeConfigController.Instance.update(timeKeepingTimeConfig);
			if (null != objResult){
				result.setStatus(Status.SUCCESS);
			}
			else{
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}
	/**
	 * delete UserTimeConfig
	 * @param session
	 * @param token
	 * @param listLongJson
	 * @return
	 */
	@POST
	@Path(TimeKeepingDefines.DELETE_TIMEKEEPING_USER_TIME_CONFIG
			+ "/{token}/{timekeepingtimeconfigid}")
	@Consumes(TimeKeepingDefines.APPLICATION_JSON)
	public ResultObject deleteUserTimeConfig(
			@CookieParam("sessionid") String session,
			@PathParam("token") String token, JSONArray listLongJson) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session,
				token);
		if (flag) {
			List<Long> listId = Utilites.getInstance().convertJsonArrayToListLong(listLongJson);
				int kq = TimekeepingUserTimeConfigController.Instance.delete(listId);
			if (kq == ErrorCode.SUCCESS) {
				result.setStatus(Status.SUCCESS);
			} else {
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}
	/**
	 * get UserTimeConfig By Id
	 * @param session
	 * @param token
	 * @param id
	 * @return
	 */
	@GET
	@Path(TimeKeepingDefines.GET_TIMEKEEPING_USER_TIME_CONFIG_BY_ID
			+ "/{token}/{id}")
	@Consumes(TimeKeepingDefines.APPLICATION_JSON)
	public ResultObject getUserTimeConfigById(
			@CookieParam("sessionid") String session,
			@PathParam("token") String token,
			@PathParam("id") long id) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session,
				token);
		if (flag) {
			UserTimeConfig timeKeepingUserTimeConfig = TimekeepingUserTimeConfigController.Instance
					.getUserTimeConfigById(id);
			if (timeKeepingUserTimeConfig != null) {
				result.setStatus(Status.SUCCESS);
			} else {
				result.setStatus(Status.FAILED);
			}
			result.setObj(timeKeepingUserTimeConfig);
		}
		return result;
	}
	/**
	 * get UserTimeConfig By List MemberId
	 * @param session
	 * @param token
	 * @param orgid
	 * @param listLongJson
	 * @return
	 */
	@POST
	@Path(TimeKeepingDefines.GET_TIMEKEEPING_USER_TIME_CONFIG_LIST
			+ "/{token}/{orgid}")
	@Consumes(TimeKeepingDefines.APPLICATION_JSON)
	public ResultObject getUserTimeConfigByListMemberId( @CookieParam("sessionid") String session,
			@PathParam("token") String token, @PathParam("orgid") long orgid, JSONArray listLongJson) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session,
				token);
		if (flag) {
			List<Long> listId = Utilites.getInstance().convertJsonArrayToListLong(listLongJson);
			List<List<UserTimeConfig>> usTimeConfig = TimekeepingUserTimeConfigController.Instance.getListUserTimeConfigByMemberIdList(orgid, listId);
		
			if (usTimeConfig != null) {
				result.setStatus(Status.SUCCESS);
			} else {
				result.setStatus(Status.FAILED);
			}
			result.setObj(usTimeConfig);
		}
		return result;
	}
}
