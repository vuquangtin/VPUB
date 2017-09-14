package com.swt.timekeeping.impls;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import com.swt.sworld.common.errors.ErrorCode;
import com.swt.sworld.ps.domain.Member;
import com.swt.sworld.ps.impl.MemberController;
import com.swt.timekeeping.customer.object.EventFilter;
import com.swt.timekeeping.customer.object.EventImportObject;
import com.swt.timekeeping.domain.Event;
import com.swt.timekeeping.domain.EventMember;
/**
 * TimeKeepingEventMember Controller
 * @author Trang-PC
 *
 */
public class TimeKeepingEventMemberController {
	/**
	 * Instance of TimeKeepingEventMemberController
	 */
	public static final TimeKeepingEventMemberController Instance = new TimeKeepingEventMemberController();

	private TimeKeepingEventMemberDAO emDAO = new TimeKeepingEventMemberDAO();

	/**
	 * insert
	 * 
	 * @param timeKeepingEventMember
	 * @return
	 */
	public EventMember insert(EventMember timeKeepingEventMember) {
		return emDAO.insert(timeKeepingEventMember);
	}

	/**
	 * insertList
	 * 
	 * @param list
	 * @return
	 */
	public int insertList(List<EventMember> list) {
		int result = 0;
		for (EventMember timeEventMember : list) {
			if (null != emDAO.insert(timeEventMember))
				result++;
		}
		return result;
	}

	/**
	 * update update
	 * 
	 * @param timeKeepingEventMember
	 * @return
	 */
	public EventMember update(EventMember timeKeepingEventMember) {
		return emDAO.update(timeKeepingEventMember);
	}

	/**
	 * delete
	 * 
	 * @param timeKeepingEventMemberId
	 * @return
	 */
	public int delete(long timeKeepingEventMemberId) {
		return emDAO.delete(timeKeepingEventMemberId);
	}

	public int deleteList(List<Long> timeKeepingEventMemberListId) {
		int result = 0;
		for (long id : timeKeepingEventMemberListId) {
			if (0 != emDAO.delete(id))
				result--;
		}
		return result;
	}

	/**
	 * getTimeKeepingEventById
	 * 
	 * @param timeKeepingEventMemberId
	 * @return
	 */
	public EventMember getTimeKeepingEventById(long timeKeepingEventMemberId) {
		return emDAO.getTimeKeepingEventMemberById(timeKeepingEventMemberId);
	}

	/**
	 * getTimeKeepingEventMemberListByEventId
	 * 
	 * @param eventId
	 * @return
	 */
	public List<EventMember> getTimeKeepingEventMemberListByEventId(long eventId) {
		return emDAO.getTimeKeepingEventMemberListByEventId(eventId);
	}

	public int deleteEventMemberList(List<Long> lstIdEventMember) {
		List<Long> result = new ArrayList<Long>();
		for (Long idEventmember : lstIdEventMember) {
			// neu delete khong thanh cong thi add vao list result
			if (emDAO.delete(idEventmember) == ErrorCode.FALSED)
				result.add(idEventmember);
		}
		if (result.size() > 0) {
			return ErrorCode.FALSED;
		}
		return ErrorCode.SUCCESS;
	}

	/**
	 * insert EventMember List
	 * @param lstEventMember
	 * @return
	 */
	public int insertListEventMember(List<EventMember> lstEventMember) {
		int count = 0;
		if (null != lstEventMember) {
			int size = lstEventMember.size();
			for (int i = 0; i < size; i++) {
				EventMember obj = lstEventMember.get(i);
				EventMember eventMember = emDAO.insert(obj);
				if (null != eventMember) {
					// insert thanh cong thi tang bien count
					count++;
				}
			}
		}
		if (count > 0) {
			return ErrorCode.SUCCESS;
		}
		return ErrorCode.FALSE;
	}

	/**
	 * ham import danh sach su kien cua mot thang
	 * 
	 * @param session
	 * @param listEventImportObject
	 * @return
	 */
	public List<EventImportObject> importEventList(List<EventImportObject> listEventImportObject) {
		SimpleDateFormat sdf = new SimpleDateFormat("dd/MM/yyyy HH:mm:ss aa");
		Date dateBegin, dateEnd;
		List<EventImportObject> result = new ArrayList<EventImportObject>();
		Event event;
		EventMember eventMember;
		List<Event> listEvent = new ArrayList<Event>();
		Date date = null;
		Member member;
		int size = listEventImportObject.size();
		EventImportObject eIObject;
		List<Long> listIdForCal = new ArrayList<Long>();
		
		for (int i = 0; i < size; i++) {
			event = new Event();
			eIObject = listEventImportObject.get(i);
			
			EventFilter filter = new EventFilter();
			// set filter
			filter.setFilterByEventName(true);
			filter.setEventName(eIObject.getEventName());
			filter.setFilterByDateBegin(true);
			filter.setDateBegin(eIObject.getDate());
			filter.setDateEnd(eIObject.getDate());
			filter.setDateBegin(eIObject.getDate());
			filter.setDateEnd(eIObject.getDate());
			// get event
			listEvent = TimeKeepingEventController.Instance
					.getTimeKeepingEventListByOrgId(filter, eIObject.getOrgId());
			// neu event == null
			if (null == listEvent || listEvent.size() == 0 ) {
				try {
					// insert event
					event.setOrgId(eIObject.getOrgId());
					event.setSubOrgId(eIObject.getSubOrgId());
					event.setEventName(eIObject.getEventName());
					date = sdf.parse(eIObject.getDate());
					event.setDateIn(date);
					event.setHourEventBegin(eIObject.getHourBegin());
					event.setHourEventKeeping(eIObject.getHourKeeping());
					event.setDescription(eIObject.getDescription());

					TimeKeepingEventController.Instance.insert(event);

					listEvent = TimeKeepingEventController.Instance
							.getTimeKeepingEventListByOrgId(filter,
									eIObject.getOrgId());
					// get event id
					if (null == listEvent || listEvent.size() == 0 ) {
						listEvent = new ArrayList<Event>();
						listEvent.add(null);
					}
				} catch (ParseException e) {
					listEvent = new ArrayList<Event>();
					listEvent.add(null);
					e.printStackTrace();
				}
			}
			event = listEvent.get(0);
			if (null != event) {
				member = MemberController.Instance.getMemberByCode(listEventImportObject.get(i).getOrgId(), eIObject.getMemberCode());						
				// insert event member
				 eventMember = new EventMember();
				eventMember.setEventId(event.getEventId());
				eventMember.setMemberId(member.getId());
				eventMember.setMemberName(eIObject.getMemberName());
				
				// update status
				listIdForCal = new ArrayList<Long>();
				listIdForCal.add(member.getId()); 
				dateBegin = date;
				dateEnd = date;
				TimeKeepingMonthlyReportController.Instance.calculateMonthlyReport(listIdForCal, dateBegin, dateEnd);
				
				// insert eventMember
				TimeKeepingEventMemberController.Instance.insert(eventMember);
			}
			else{
				// neu insert ko dc (loi insert or da ton tai)
				// add vao list result
				result.add(eIObject);
			}
		}
		// return result
		return result;
	}
}
