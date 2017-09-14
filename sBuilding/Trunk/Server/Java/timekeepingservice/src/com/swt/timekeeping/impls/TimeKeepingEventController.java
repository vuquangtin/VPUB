package com.swt.timekeeping.impls;

import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.List;
import java.util.StringTokenizer;

import com.google.gson.Gson;
import com.swt.sworld.common.errors.ErrorCode;
import com.swt.sworld.ps.domain.Member;
import com.swt.sworld.ps.impl.MemberController;
import com.swt.timekeeping.customer.object.EventDTO;
import com.swt.timekeeping.customer.object.EventFilter;
import com.swt.timekeeping.customer.object.EventInsResult;
import com.swt.timekeeping.customer.object.EventMemberListDTO;
import com.swt.timekeeping.customer.object.EventResultForGet;
import com.swt.timekeeping.customer.object.SessionWorking;
import com.swt.timekeeping.domain.DailyConfig;
import com.swt.timekeeping.domain.Event;
import com.swt.timekeeping.domain.EventMember;
import com.swt.timekeeping.domain.TimeConfig;

/**
 * TimeKeepingEventController
 * 
 * @author TrangPig
 * 
 */
public class TimeKeepingEventController {
	/**
	 * Instance of TimeKeepingEventController
	 */
	public static final TimeKeepingEventController Instance = new TimeKeepingEventController();

	private TimeKeepingEventDAO teDAO = new TimeKeepingEventDAO();

	/**
	 * insert TimeKeepingEvent
	 * 
	 * @param timeKeepingEvent
	 * @return EventInsResult
	 */
	public EventInsResult insert(Event timeKeepingEvent) {
		Event event = insertEvent(timeKeepingEvent);
		EventInsResult result = new EventInsResult();
		result.setDateIn(event.getDateIn().getTime());
		result.setDescription(event.getDescription());
		result.setEventId(event.getEventId());
		result.setEventName(event.getEventName());
		result.setHourEventBegin(event.getHourEventBegin());
		result.setHourEventKeeping(event.getHourEventKeeping());
		result.setOrgId(event.getOrgId());
		result.setSubOrgId(event.getSubOrgId());

		return result;
	}

	/**
	 * insertEvent
	 * 
	 * @param timeKeepingEvent
	 * @return Event
	 */
	public Event insertEvent(Event timeKeepingEvent) {
		return teDAO.insert(timeKeepingEvent);

	}

	/**
	 * insert List Time Keeping Event
	 * 
	 * @param list
	 * @return int
	 */
	public int insertList(List<Event> list) {
		int result = 0;
		for (Event timeEvent : list) {
			if (null != teDAO.insert(timeEvent))
				result++;
		}
		return result;
	}

	/**
	 * update TimeKeepingEvent
	 * 
	 * @param timeKeepingEvent
	 * @return Event
	 */
	public Event update(Event timeKeepingEvent) {
		return teDAO.update(timeKeepingEvent);
	}

	/**
	 * delete TimeKeepingEvent
	 * 
	 * @param timeKeepingEventId
	 * @return int
	 */
	public int delete(long timeKeepingEventId) {
		return teDAO.delete(timeKeepingEventId);
	}

	/**
	 * deleteList
	 * 
	 * @param listEventId
	 * @return
	 */
	public int deleteList(List<Long> listEventId) {
		int result = 0;
		for (long id : listEventId) {
			if (ErrorCode.SUCCESS == delete(id))
				result++;
		}
		if (result > 0) {
			return ErrorCode.SUCCESS;
		} else {
			return ErrorCode.FALSED;
		}
	}

	/**
	 * getTimeKeepingEventById
	 * 
	 * @param timeKeepingEventId
	 * @return TimeKeepingEvent
	 */
	public Event getTimeKeepingEventById(long timeKeepingEventId) {
		return teDAO.getTimeKeepingEventById(timeKeepingEventId);
	}

	/**
	 * 
	 * @param timeKeepingEventId
	 * @return
	 */
	public EventResultForGet getTimeKeepingEventResultForGetById(
			long timeKeepingEventId) {
		Event event = teDAO.getTimeKeepingEventById(timeKeepingEventId);
		if (null != event)
			return new EventResultForGet(event);
		else
			return null;
	}

	/**
	 * get TimeKeepingEventList By subOrgId
	 * 
	 * @param orgId
	 * @param suborgId
	 * @return
	 */
	public List<Event> getTimeKeepingEventListBySubOrgId(
			EventFilter eventFilter, long orgId, long suborgId) {

		return teDAO.getTimeKeepingEventListBySubOrgId(eventFilter, orgId,
				suborgId);
	}

	/**
	 * get TimeKeepingEventList By orgId
	 * 
	 * @param eventFilter
	 * @param orgId
	 * @return
	 */
	public List<Event> getTimeKeepingEventListByOrgId(EventFilter eventFilter,
			long orgId) {
		return teDAO.getTimeKeepingEventListByOrgId(eventFilter, orgId);
	}

	/**
	 * getTimeKeepingEventDTOList by subOrgId
	 * 
	 * @param eventFilter
	 * @param orgId
	 * @param suborgId
	 * @return
	 */
	@SuppressWarnings("null")
	public List<EventDTO> getTimeKeepingEventDTOListBySubOrgId(
			EventFilter eventFilter, long orgId, long suborgId) {
		List<EventDTO> eventDTOList = new ArrayList<EventDTO>();
		List<EventMember> listMember = null;
		EventDTO eventTmp = null;
		List<Event> eventList = getTimeKeepingEventListBySubOrgId(eventFilter,
				orgId, suborgId);
		EventResultForGet evResult = new EventResultForGet();
		// kiem tra eventList khac null
		if (null != eventList) {
			for (Event event : eventList) {
				listMember = TimeKeepingEventMemberController.Instance
						.getTimeKeepingEventMemberListByEventId(event
								.getEventId());
				evResult = new EventResultForGet(event);
				// kiem tra listMember khac null
				if (null != listMember || listMember.size() != 0) {
					for (EventMember eventMember : listMember) {
						eventTmp = new EventDTO();
						eventTmp.setEventMemberId(eventMember
								.getEventmemberId());
						eventTmp.setEventObj(evResult);
						eventTmp.setEventMemberObj(eventMember);
						eventDTOList.add(eventTmp);
					}
				}
				// kiem tra danh sach listMember bang null
				if (null == listMember || listMember.size() == 0) {
					eventTmp = new EventDTO();
					eventTmp.setEventObj(evResult);
					eventDTOList.add(eventTmp);
				}
			}
		}
		return eventDTOList;
	}

	/**
	 * getTimeKeepingEventDTO List by orgId
	 * 
	 * @param eventFilter
	 * @param orgId
	 * @return
	 */
	@SuppressWarnings("null")
	public List<EventDTO> getTimeKeepingEventDTOListByOrgId(
			EventFilter eventFilter, long orgId) {
		List<EventDTO> eventDTOList = new ArrayList<EventDTO>();
		List<EventMember> listMember = null;
		EventDTO eventTmp = null;
		List<Event> eventList = getTimeKeepingEventListByOrgId(eventFilter,
				orgId);
		EventResultForGet evResult = new EventResultForGet();
		// kiem tra eventList khac null
		if (null != eventList) {
			for (Event event : eventList) {
				listMember = TimeKeepingEventMemberController.Instance
						.getTimeKeepingEventMemberListByEventId(event
								.getEventId());
				evResult = new EventResultForGet(event);
				// kiem tra listMember khac null
				if (null != listMember || listMember.size() != 0) {
					for (EventMember eventMember : listMember) {
						// set gia tri
						eventTmp = new EventDTO();
						eventTmp.setEventMemberId(eventMember
								.getEventmemberId());
						eventTmp.setEventObj(evResult);
						eventTmp.setEventMemberObj(eventMember);
						// add
						eventDTOList.add(eventTmp);
					}
				}
				// kiem tra listMember bang null
				if (null == listMember || listMember.size() == 0) {
					eventTmp = new EventDTO();
					eventTmp.setEventObj(evResult);
					eventDTOList.add(eventTmp);
				}
			}
		}
		return eventDTOList;
	}

	/**
	 * insert Event and ListEventMember
	 * 
	 * @param evmlistDTO
	 * @return
	 */
	public int insertEventAndListEventMember(EventMemberListDTO evmlistDTO) {
		if (null != evmlistDTO) {
			// insert
			Event event = insertEvent(evmlistDTO.getEventObj());
			// neu insert ko duoc
			if (null == event) {
				return -1;
			}
			// get danh sach thanh vien thanh vien du duoc gui tu client
			List<EventMember> emList = evmlistDTO.getEventMemberListObj();
			if (null != emList) {
				// insert danh sach thanh vien tham du
				TimeKeepingEventMemberController.Instance.insertList(emList);
			}
		}
		return 0;
	}

	/**
	 * Kiem tra trung su kien trong 1 ngay
	 * 
	 * @param memIdList
	 * @param eventId
	 * @return resultList lầ danh sách các member có event bi trung
	 */
	public List<Member> checkConflictEvent(List<Long> memIdList, long eventId,
			String date) {
		List<Member> resultList = new ArrayList<Member>();
		// get event tu database
		Event eventCur = TimeKeepingEventController.Instance
				.getTimeKeepingEventById(eventId);
		int size = memIdList.size();
		// duyet tren danh sach id gui tu client
		for (int i = 0; i < size; i++) {
			// get danh sach event by date
			List<Event> eList = teDAO.getListEventByDateForMember(
					memIdList.get(i), date);
			// kiem tra mot event co bi trung voi mot event khac
			boolean check = checkEvent(eList, eventCur);
			Member mem = new Member();
			if (check) {
				// neu trung add vao danh sach member tra ve
				mem = MemberController.Instance.getMemberById(memIdList.get(i));
				resultList.add(mem);
			}
		}
		return resultList;
	}

	/**
	 * kiem tra mot event co bi trung voi mot event khac
	 * 
	 * @param evList
	 * @param ev
	 * @return true khi 2 event giao nhau
	 */
	private boolean checkEvent(List<Event> evList, Event ev) {
		int size = evList.size();
		if (null != ev && null != evList && evList.size() > 0) {
			StringTokenizer stk = new StringTokenizer(ev.getHourEventBegin(),
					":");
			int curHourBegin = Integer.parseInt(stk.nextToken()), curMinute = Integer
					.parseInt(stk.nextToken());
			curHourBegin = curHourBegin + curMinute;
			int curHourEnd = curHourBegin + ev.getHourEventKeeping();
			// kiem tra neu trong evList co chua ev => loai ev khoi evList
			for (int i = 0; i < size; i++) {
				if (evList.get(i).getEventId() == ev.getEventId()) {
					evList.remove(i);
					size = size - 1;
				}
			}
			int hourBegin, minute, hourEnd;
			// kiem tra ev co trung gio voi su kien nao trong evList
			for (int i = 0; i < size; i++) {
				stk = new StringTokenizer(evList.get(i).getHourEventBegin(),
						":");
				hourBegin = Integer.parseInt(stk.nextToken());
				minute = Integer.parseInt(stk.nextToken());
				hourBegin = hourBegin + minute;
				hourEnd = hourBegin + evList.get(i).getHourEventKeeping();
				// if((curHourBegin <= hourBegin && curHourEnd >= hourEnd) ||
				// (hourBegin <= curHourBegin && hourEnd >= curHourEnd)
				// || (curHourBegin <= hourBegin && hourBegin <= curHourEnd &&
				// curHourEnd <= hourEnd)
				// || (hourBegin <= curHourBegin && curHourBegin <= hourEnd &&
				// hourEnd <= curHourEnd))
				// return true;
				if (!((curHourEnd <= hourBegin) || (hourEnd <= curHourBegin)))
					return true;
			}
		}
		return false;
	}

	/**
	 * kiem tra 1 khoang thoi gian co nam trong thoi gian cua 1 su kien nao
	 * khong
	 * @param timeBegin
	 * @param timeEnd
	 * @param memId
	 * @param date
	 * @return
	 */
	@SuppressWarnings("deprecation")
	public boolean checkEventForTime(int timeBegin, int timeEnd, long memId,
			Date date) {
		List<Event> eventList = teDAO.getListEventByDateForMember(memId,
				(date.getYear() + 1900) + "-" + (date.getMonth() + 1) + "-"
						+ date.getDate());
		// duyet tren danh sach su kien
		for (Event ev : eventList) {
			String time = ev.getHourEventBegin();
			int eveHBegin = Integer.parseInt(time.substring(0,
					time.indexOf(":")));
			int eveMBegin = Integer
					.parseInt(time.substring(time.indexOf(":") + 1));
			eveHBegin = (eveHBegin * 60) + eveMBegin;
			int eveHEnd = ((eveHBegin + ev.getHourEventKeeping()) * 60)
					+ eveMBegin;
			if ((eveHBegin <= timeBegin) && (eveHEnd >= timeEnd))
				return true;
		}
		return false;
	}

	/**
	 * kiem tra co su kien nao dang ky full 1 ca lam viec
	 * 
	 * @param memId
	 * @param sessionWorking
	 * @param date
	 * @return true: dang ky su kien full sessionWorking, false: khong dang ky
	 *         full sessionWorking
	 */
	@SuppressWarnings("deprecation")
	public boolean checkFullTimeEventForSessionByMemId(long memId,
			String sessionWorking, Date date) {

		List<Event> eventList = teDAO.getListEventByDateForMember(memId,
				(date.getYear() + 1900) + "-" + (date.getMonth() + 1) + "-"
						+ date.getDate());

		// parse chuoi string json sessionWorking thanh mang SessionWorking[]
		// tempList
		Gson gson = new Gson();
		SessionWorking[] tempList;
		tempList = gson.fromJson(sessionWorking, SessionWorking[].class);

		// kiem tra xem su nguoi nay co di su kien nguyen ngay ko?
		String time = "";
		int eveHB = 0, eveMB = 0, sumEBegin = 0, sumEEnd = 0;
		if (null != eventList && eventList.size() > 0) {
			time = eventList.get(0).getHourEventBegin();
			eveHB = Integer.parseInt(time.substring(0, time.indexOf(":")));
			eveMB = Integer.parseInt(time.substring(time.indexOf(":") + 1));
			sumEBegin = (eveHB * 60) + eveMB;
			sumEEnd = ((eveHB + eventList.get(0).getHourEventKeeping()) * 60)
					+ eveMB;
		}
		// tinh tong thoi gian cua event, tong time config
		for (int i = 0; i < eventList.size(); i++) {
			time = eventList.get(i).getHourEventBegin();
			int eveHBegin = Integer.parseInt(time.substring(0,
					time.indexOf(":")));
			int eveMBegin = Integer
					.parseInt(time.substring(time.indexOf(":") + 1));
			int eveHEnd = ((eveHBegin + eventList.get(i).getHourEventKeeping()) * 60)
					+ eveMBegin;
			eveHBegin = (eveHBegin * 60) + eveMBegin;
			if (sumEBegin > eveHBegin)
				sumEBegin = eveHBegin;
			if (sumEEnd < eveHEnd)
				sumEEnd = eveHEnd;
		}
		int eventTotal = sumEEnd - sumEBegin;
		for (SessionWorking session : tempList) {
			int sumConfig = (session.getHoursEnd() * 60 + session
					.getMinuteEnd())
					- (session.getHoursBegin() * 60 + session.getMinuteBegin());
			// so sanh tong thoi gian cua event voi tong time config
			if ((sumEEnd <= (session.getHoursEnd() * 60 + session
					.getMinuteEnd())) && (eventTotal >= sumConfig))
				return true;
		}
		return false;
	}

	/**
	 * Kiem tra trong 1 ngay 1 nguoi co dang ky su kien full ngay hay khong?
	 * 
	 * @param memId
	 * @param date
	 * @return true: dang ky su kien full ngay false: khong dang ky full ngay
	 */
	@SuppressWarnings("deprecation")
	public boolean checkFullTimeEventByMemId(long memId, Date date) {

		List<Event> eventList = teDAO.getListEventByDateForMember(memId,
				(date.getYear() + 1900) + "-" + (date.getMonth() + 1) + "-"
						+ date.getDate());

		// get time config by date (dateformat: yyyy-MM-dd HH:mm:ss)
		DailyConfig dailyConfig = null;
		TimeConfig timeConfig = null;
		String sessionWorking = "";
		Member mem = MemberController.Instance.getMemberById(memId);
		Date curDate = new Date();
		curDate.setMinutes(0);
		curDate.setHours(0);
		curDate.setSeconds(0);
		long timeCurDate = curDate.getTime() - (curDate.getTime() % 1000);
		date.setMinutes(0);
		date.setHours(0);
		date.setSeconds(0);
		long timeDate = date.getTime() - (date.getTime() % 1000);
		// neu timeCurDate == timeDate (thoi gian nhan vao == ngay hien tai):
		// lay sessionWorking cua timeConfig
		if (timeCurDate == timeDate) {
			Calendar c = Calendar.getInstance();
			c.setTime(curDate);
			int dayOfWeek = c.get(Calendar.DAY_OF_WEEK);
			timeConfig = TimeKeepingTimeConfigController.Instance
					.getTimeConfigByDayOfWeekOrgId(dayOfWeek, mem.getOrgId());
			sessionWorking = timeConfig.getSessionWorking();
		} else {
			// neu thoi gian nhan vao < ngay hien tai: lay sessionWorking cua
			// dailyConfig
			dailyConfig = TimeKeepingDailyConfigController.Instance
					.getDailyConfigByDate(date, mem.getOrgId());
			sessionWorking = dailyConfig.getJsonTimeConfig();
		}

		// parse chuoi string json sessionWorking thanh mang SessionWorking[]
		// tempList
		Gson gson = new Gson();
		SessionWorking[] tempList;
		tempList = gson.fromJson(sessionWorking, SessionWorking[].class);
		// kiem tra xem su nguoi nay co di su kien nguyen ngay ko?
		// tinh toan du lieu
		String time = "";
		int eveHB = 0, eveMB = 0, sumEBegin = 0, sumEEnd = 0;
		if (null != eventList && eventList.size() > 0) {
			time = eventList.get(0).getHourEventBegin();
			eveHB = Integer.parseInt(time.substring(0, time.indexOf(":")));
			eveMB = Integer.parseInt(time.substring(time.indexOf(":") + 1));
			sumEBegin = (eveHB * 60) + eveMB;
			sumEEnd = ((eveHB + eventList.get(0).getHourEventKeeping()) * 60)
					+ eveMB;
		}
		// tinh tong thoi gian cua event, tong time config
		for (int i = 0; i < eventList.size(); i++) {
			time = eventList.get(i).getHourEventBegin();
			int eveHBegin = Integer.parseInt(time.substring(0,
					time.indexOf(":")));
			int eveMBegin = Integer
					.parseInt(time.substring(time.indexOf(":") + 1));
			int eveHEnd = ((eveHBegin + eventList.get(i).getHourEventKeeping()) * 60)
					+ eveMBegin;
			eveHBegin = (eveHBegin * 60) + eveMBegin;
			if (sumEBegin > eveHBegin)
				sumEBegin = eveHBegin;
			if (sumEEnd < eveHEnd)
				sumEEnd = eveHEnd;
		}
		SessionWorking sBegin = tempList[0];
		SessionWorking sEnd = tempList[tempList.length - 1];
		int eventTotal = sumEEnd - sumEBegin;
		int sumConfig = (sEnd.getHoursEnd() * 60 + sEnd.getMinuteEnd())
				- (sBegin.getHoursBegin() * 60 + sBegin.getMinuteBegin());

		// so sanh tong thoi gian cua event voi tong time config
		if ((sumEEnd >= (sEnd.getHoursEnd() * 60 + sEnd.getMinuteEnd()))
				&& (eventTotal >= sumConfig))
			return true;

		return false;
	}
}
