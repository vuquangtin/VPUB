package com.sworld.timekeeping.services;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
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
import com.sworld.common.ResultObject;
import com.sworld.common.Status;
import com.sworld.common.Utilites;
import com.sworld.timekeeping.common.TimeKeepingDefines;
import com.sworld.timekeeping.common.TimeKeepingUtilites;
import com.swt.sworld.common.errors.ErrorCode;
import com.swt.sworld.common.utilitis.TokenManager;
import com.swt.sworld.ps.domain.Member;
import com.swt.sworld.ps.impl.MemberController;
import com.swt.timekeeping.customer.object.EventDTO;
import com.swt.timekeeping.customer.object.EventFilter;
import com.swt.timekeeping.customer.object.EventImportObject;
import com.swt.timekeeping.customer.object.EventResultForGet;
import com.swt.timekeeping.domain.Event;
import com.swt.timekeeping.domain.EventMember;
import com.swt.timekeeping.impls.TimeKeepingEventController;
import com.swt.timekeeping.impls.TimeKeepingEventMemberController;
/**
 * 
 * @author Trang-PC
 *
 */
@Path(TimeKeepingDefines.TIMEKEEPINGEVENTMANAGER)
@Produces(TimeKeepingDefines.APPLICATION_JSON)
public class TimeKeepingEventManager {
	/**
	 * get event by eventId
	 * 
	 * @param session
	 * @param token
	 * @param timeKeepingEventId
	 * @return
	 */
	@GET
	@Path(TimeKeepingDefines.GET_TIMEKEEPING_EVENT_BY_EVENTID
			+ "/{token}/{timekeepingeventid}")
	@Consumes(TimeKeepingDefines.APPLICATION_JSON)
	public ResultObject getEventByEventId(
			@CookieParam("sessionid") String session,
			@PathParam("token") String token,
			@PathParam("timekeepingeventid") long timeKeepingEventId) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session,
				token);
		if (flag) {
			EventResultForGet timeKeepingEvent = TimeKeepingEventController.Instance
					.getTimeKeepingEventResultForGetById(timeKeepingEventId);
			if (null != timeKeepingEvent) {
				result.setStatus(Status.SUCCESS);
			} else {
				result.setStatus(Status.FAILED);
			}
			result.setObj(timeKeepingEvent);
		}
		return result;
	}

	/**
	 * get event list by org id
	 * 
	 * @param session
	 * @param token
	 * @param orgId
	 * @param event
	 * @return
	 */
	@POST
	@Path(TimeKeepingDefines.GET_TIMEKEEPING_EVENT_LIST_BY_ORGID
			+ "/{token}/{orgid}")
	@Consumes(TimeKeepingDefines.APPLICATION_JSON)
	public ResultObject getEventListByOrgId(
			@CookieParam("sessionid") String session,
			@PathParam("token") String token, @PathParam("orgid") long orgId,
			JSONObject filters) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session,
				token);
		if (flag) {
			EventFilter filter = new EventFilter();
			filter = Utilites.getInstance().convertJsonObjToObject(filters,
					filter.getClass());
			// set dateBegin va dateEnd thanh dang yyyy-MM-dd
			if (filter.isFilterByDateBegin() && filter.isFilterByDateEnd()) {

				String dateBegin = filter.getDateBegin().trim();
				dateBegin = dateBegin.substring(6) + "-"
						+ dateBegin.substring(3, 5) + "-"
						+ dateBegin.substring(0, 2);
				filter.setDateBegin(dateBegin);

				String dateEnd = filter.getDateEnd().trim();
				dateEnd = dateEnd.substring(6) + "-"
						+ dateEnd.substring(3, 5) + "-"
						+ dateEnd.substring(0, 2);
				filter.setDateEnd(dateEnd);
			}
			List<EventDTO> eventDTOList = TimeKeepingEventController.Instance
					.getTimeKeepingEventDTOListByOrgId(filter, orgId);
			if (null != eventDTOList) {
				result.setStatus(Status.SUCCESS);
			} else {
				result.setStatus(Status.FAILED);
			}
			result.setObj(eventDTOList);
		}
		return result;
	}

	/**
	 * get event list by suborg id
	 * 
	 * @param session
	 * @param token
	 * @param orgId
	 * @param subOrgId
	 * @param event
	 * @return
	 */
	@POST
	@Path(TimeKeepingDefines.GET_TIMEKEEPING_EVENT_LIST_BY_SUBORGID
			+ "/{token}/{orgid}/{suborgid}")
	@Consumes(TimeKeepingDefines.APPLICATION_JSON)
	public ResultObject getEventListBySubOrgId(
			@CookieParam("sessionid") String session,
			@PathParam("token") String token, @PathParam("orgid") long orgId,
			@PathParam("suborgid") long subOrgId, JSONObject eventfilter) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session,
				token);
		if (flag) {
			EventFilter filter = new EventFilter();
			filter = Utilites.getInstance().convertJsonObjToObject(eventfilter,
					filter.getClass());
			// set dateBegin va dateEnd thanh dang yyyy-MM-dd
						if (filter.isFilterByDateBegin() && filter.isFilterByDateEnd()) {

							String dateBegin = filter.getDateBegin().trim();
							dateBegin = dateBegin.substring(6) + "-"
									+ dateBegin.substring(3, 5) + "-"
									+ dateBegin.substring(0, 2);
							filter.setDateBegin(dateBegin);

							String dateEnd = filter.getDateEnd().trim();
							dateEnd = dateEnd.substring(6) + "-"
									+ dateEnd.substring(3, 5) + "-"
									+ dateEnd.substring(0, 2);
							filter.setDateEnd(dateEnd);
						}
			List<EventDTO> eventDTOList = TimeKeepingEventController.Instance
					.getTimeKeepingEventDTOListBySubOrgId(filter, orgId,
							subOrgId);
			if (null != eventDTOList) {
				result.setStatus(Status.SUCCESS);
			} else {
				result.setStatus(Status.FAILED);
			}
			result.setObj(eventDTOList);
		}
		return result;
	}

	/**
	 * insert event
	 * 
	 * @param session
	 * @param token
	 * @param event
	 * @return
	 */
	@POST
	@Path(TimeKeepingDefines.INSERT_TIMEKEEPING_EVENT + "/{token}")
	@Consumes(TimeKeepingDefines.APPLICATION_JSON)
	public ResultObject insertEvent(
			@CookieParam(value = "sessionid") String session,
			@PathParam("token") String token, JSONObject event) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session,
				token);
		if (flag) {
			Event shiftRequest = new Event();
			try {
				// parse dateIn thanh dang Date
				String datain = event.getString("dateIn");
				SimpleDateFormat format = new SimpleDateFormat("yyyy-MM-dd");
				Date date = format.parse(datain);
				// set thuoc tinh cho shiftRequest
				shiftRequest.setDateIn(date);
				shiftRequest.setDescription(event.getString("description"));
				shiftRequest.setEventName(event.getString("eventName"));
				shiftRequest.setHourEventBegin(event
						.getString("hourEventBegin"));
				shiftRequest.setHourEventKeeping(event
						.getInt("hourEventKeeping"));
				shiftRequest.setOrgId(event.getLong("orgId"));
				shiftRequest.setSubOrgId(event.getLong("subOrgId"));

				Event shiftDB = TimeKeepingEventController.Instance
						.insertEvent(shiftRequest);
				if (shiftDB != null) {
					result.setStatus(Status.SUCCESS);
				} else {
					result.setStatus(Status.FAILED);
				}
				result.setObj(shiftDB);
			} catch (Exception ex) {
			}
		}
		return result;
	}

	/**
	 * insert list time event configuration
	 * 
	 * @param session
	 * @param token
	 * @param listevent
	 *            : list data
	 * @return
	 */
	@POST
	@Path(TimeKeepingDefines.INSERT_TIMEKEEPING_EVENT_LIST + "/{token}")
	@Consumes(TimeKeepingDefines.APPLICATION_JSON)
	public ResultObject insertListTimeKeepingEvent(
			@CookieParam(value = "sessionid") String session,
			@PathParam("token") String token, JSONArray listevent) {
		ResultObject result = new ResultObject(Status.FAILED);

		boolean flag = TokenManager.getInstance().checkTokenSession(session,
				token);
		if (flag) {
			List<Event> list = TimeKeepingUtilites.getInstance()
					.convertJsonArrayToListEvent(listevent);
			int tmp = TimeKeepingEventController.Instance.insertList(list);
			if (tmp > 0) {
				result.setStatus(Status.SUCCESS);
			} else {
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}

	/**
	 * update event
	 * 
	 * @param session
	 * @param token
	 * @param shift
	 * @return
	 */
	@POST
	@Path(TimeKeepingDefines.UPDATE_TIMEKEEPING_EVENT + "/{token}")
	@Consumes(TimeKeepingDefines.APPLICATION_JSON)
	public ResultObject updateEvent(@CookieParam("sessionid") String session,
			@PathParam("token") String token, JSONObject event) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session,
				token);
		if (flag) {
			Event shiftRequest = new Event();

			try {
				// parse dateIn thanh dang Date
				String datain = event.getString("dateIn");
				SimpleDateFormat format = new SimpleDateFormat("yyyy-MM-dd");
				Date date = format.parse(datain);
				// set thuoc tinh cho shiftRequest
				shiftRequest.setDateIn(date);
				shiftRequest.setEventId(event.getLong("eventId"));
				shiftRequest.setDescription(event.getString("description"));
				shiftRequest.setEventName(event.getString("eventName"));
				shiftRequest.setHourEventBegin(event
						.getString("hourEventBegin"));
				shiftRequest.setHourEventKeeping(event
						.getInt("hourEventKeeping"));
				shiftRequest.setOrgId(event.getLong("orgId"));
				shiftRequest.setSubOrgId(event.getLong("subOrgId"));

				Event eventsResult = TimeKeepingEventController.Instance
						.update(shiftRequest);
				if (null != eventsResult)
					result.setStatus(Status.SUCCESS);
				result.setObj(eventsResult);
			} catch (Exception ex) {
			}
		}
		return result;
	}

	/**
	 * xoa event
	 * 
	 * @param session
	 * @param token
	 * @param timeKeepingShiftId
	 * @return
	 */
	@GET
	@Path(TimeKeepingDefines.DELETE_TIMEKEEPING_EVENT
			+ "/{token}/{timekeepingshiftid}")
	@Consumes(TimeKeepingDefines.APPLICATION_JSON)
	public ResultObject deleteEvent(@CookieParam("sessionid") String session,
			@PathParam("token") String token,
			@PathParam("timekeepingshiftid") long timeKeepingShiftId) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session,
				token);
		if (flag) {
			int kq = TimeKeepingEventController.Instance
					.delete(timeKeepingShiftId);
			if (kq == ErrorCode.SUCCESS) {
				result.setStatus(Status.SUCCESS);
			} else {
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}
/**
 * delete list event
 * @param session
 * @param token
 * @param listeventId
 * @return
 */
	@POST
	@Path(TimeKeepingDefines.DELETE_TIMEKEEPING_EVENT_LIST + "/{token}")
	@Consumes(TimeKeepingDefines.APPLICATION_JSON)
	public ResultObject deleteEventList(
			@CookieParam("sessionid") String session,
			@PathParam("token") String token, JSONArray listeventId) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session,
				token);
		if (flag) {
			List<Long> listIdEvent = Utilites.getInstance()
					.convertJsonArrayToListLong(listeventId);
			int kq = TimeKeepingEventController.Instance
					.deleteList(listIdEvent);
			if (kq == ErrorCode.SUCCESS) {
				result.setStatus(Status.SUCCESS);
			} else {
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}
	
	
	/**
	 * Ham nay kiem tra mot danh sach member dang ky event co bi trung event ko? 
	 * @param session
	 * @param token
	 * @return danh sach cac member bi trung event
	 */
	@POST
	@Path(TimeKeepingDefines.CHECK_CONFLICT_EVENT + "/{token}/{eventid}/{date}")
	@Consumes(TimeKeepingDefines.APPLICATION_JSON)
	public ResultObject checkConflictEvent(
			@CookieParam("sessionid") String session,
			@PathParam("token") String token, @PathParam("eventid") long eventId,
			@PathParam("date") String date, JSONArray listIdJson) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session,
				token);
		if (flag) {
			// parse List<Long>
			List<Long> memIdList = Utilites.getInstance()
					.convertJsonArrayToListLong(listIdJson);
			// kiem tra trung su kien
			List<Member> kq = TimeKeepingEventController.Instance.checkConflictEvent(memIdList, eventId, date);
			if (null != kq && kq.size() > 0) {
				result.setStatus(Status.SUCCESS);
			} else {
				result.setStatus(Status.FAILED);
			}
			result.setObj(kq);
		}
		return result;
	}
	

	/**
	 * getEventMemberListByEventId
	 * 
	 * @param session
	 * @param token
	 * @param orgId
	 * @param subOrgId
	 * @return
	 */
	@GET
	@Path(TimeKeepingDefines.GET_TIMEKEEPING_EVENT_MEMBER_LIST_BY_EVENTID
			+ "/{token}/{eventid}")
	@Consumes(TimeKeepingDefines.APPLICATION_JSON)
	public ResultObject getEventMemberListByEventId(
			@CookieParam("sessionid") String session,
			@PathParam("token") String token, @PathParam("eventid") long eventId) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session,
				token);
		if (flag) {
			List<EventMember> eventMemvberList = TimeKeepingEventMemberController.Instance
					.getTimeKeepingEventMemberListByEventId(eventId);
			if (null != eventMemvberList) {
				result.setStatus(Status.SUCCESS);
			} else {
				result.setStatus(Status.FAILED);
			}
			result.setObj(eventMemvberList);
		}
		return result;
	}

	/**
	 * Insert mot event va mot list member theo event do vao bang evenmember
	 * Nhan 1 id event va mot list object dang json
	 * 
	 * @param session
	 * @param token
	 * @param eventMemberListDTO
	 * @return
	 */
	@POST
	@Path(TimeKeepingDefines.INSERT_TIMEKEEPING_EVENT_MEMBER_LIST + "/{token}")
	@Consumes(TimeKeepingDefines.APPLICATION_JSON)
	public ResultObject insertEventMemberList(
			@CookieParam(value = "sessionid") String session,
			@PathParam("token") String token, JSONArray eventMemberListJson) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session,
				token);
		if (flag) {
			List<EventMember> listEventMember = new ArrayList<EventMember>();
			TypeToken<List<EventMember>> temp = new TypeToken<List<EventMember>>() {
			};
			Gson gson = new Gson();
			listEventMember = gson.fromJson(eventMemberListJson.toString(),
					temp.getType());

			int tmp = TimeKeepingEventMemberController.Instance
					.insertListEventMember(listEventMember);
			if (tmp == 0) {
				result.setStatus(Status.SUCCESS);
			} else {
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}

	/**
	 * Ham nay xoa list eventMember dua vao list eventmemberId client gui len
	 * 
	 * @param session
	 * @param token
	 * @param timeKeepingShiftId
	 * @return
	 */
	@POST
	@Path(TimeKeepingDefines.DELETE_EVENT_MEMBER_LIST + "/{token}")
	@Consumes(TimeKeepingDefines.APPLICATION_JSON)
	public ResultObject deleteEventMemberList(
			@CookieParam("sessionid") String session,
			@PathParam("token") String token, JSONArray listIdJson) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session,
				token);
		if (flag) {
			List<Long> lstIdEventMember = Utilites.getInstance()
					.convertJsonArrayToListLong(listIdJson);
			int kq = TimeKeepingEventMemberController.Instance
					.deleteEventMemberList(lstIdEventMember);
			if (kq == ErrorCode.SUCCESS) {
				result.setStatus(Status.SUCCESS);
			} else {
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}
	
	/**
	 * get list event by memberId and date and orgId
	 * @param memId
	 * @param date
	 * @return list event
	 */
	@GET
	@Path(TimeKeepingDefines.GET_TIMEKEEPING_EVENT_LIST_BY_MEMID + "/{token}/{memberid}/{date}/{orgid}")
	@Consumes(TimeKeepingDefines.APPLICATION_JSON)
		public ResultObject getListEventByMemberIdDate(@CookieParam("sessionid") String session,
				@PathParam("token") String token, @PathParam("memberid") long memberId, 
				@PathParam("date") String stringDate, @PathParam("orgid") long orgId ) {
			ResultObject result = new ResultObject(Status.FAILED);
			boolean flag = TokenManager.getInstance().checkTokenSession(session,
					token);
			if (flag) {
				List<Event> eventList = null;
			Member member = MemberController.Instance.getMemberById(memberId);
			if(null != member){
				EventFilter filter = new EventFilter();
				filter.setFilterByEventName(true);
				filter.setEventName(member.getLastName()+" "+member.getFirstName());
				// format: yyyy-MM-dd HH:mm:ss
				filter.setFilterByDateBegin(true);
				filter.setDateBegin(stringDate + " 00:00:00");
				filter.setFilterByDateEnd(true);
				filter.setDateEnd(stringDate + " 23:59:59");				
				eventList = TimeKeepingEventController.Instance
				.getTimeKeepingEventListByOrgId(filter, orgId);
				if (null != eventList) {
					result.setStatus(Status.SUCCESS);
				} else {
					result.setStatus(Status.FAILED);
				}
				result.setObj(eventList);
			}
		}
		return result;
	}	
	
	/**
	 * Ham nay import danh sach su kien trong 1 thang 
	 * 
	 * @param session
	 * @param token
	 * @param timeKeepingShiftId
	 * @return
	 */
	@POST
	@Path(TimeKeepingDefines.IMPORT_lIST_EVENT + "/{token}")
	@Consumes(TimeKeepingDefines.APPLICATION_JSON)
	public ResultObject importListEvent(
			@CookieParam("sessionid") String session,
			@PathParam("token") String token, JSONArray listJson) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			List<EventImportObject> listEventImportObject = new ArrayList<EventImportObject>();
			// conver jsonarray EventImportObject to list
			TypeToken<List<EventImportObject>> temp = new TypeToken<List<EventImportObject>>() {
			};
			Gson gson = new Gson();
			listEventImportObject = gson.fromJson(listJson.toString(),
					temp.getType());
//				listEventImportObject = Utilites.getInstance()
//						.convertJsonArrayToList(listJson);
			List<EventImportObject> kq = TimeKeepingEventMemberController.Instance.importEventList(listEventImportObject);
			if (kq.size() <= 0) {
				result.setStatus(Status.SUCCESS);
			} else {
				result.setStatus(Status.FAILED);
			}
			result.setObj(kq);

		}
		return result;
	}
	
}