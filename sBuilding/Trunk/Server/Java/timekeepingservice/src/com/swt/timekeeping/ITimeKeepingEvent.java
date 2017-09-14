package com.swt.timekeeping;

import java.util.List;

import com.swt.timekeeping.customer.object.EventFilter;
import com.swt.timekeeping.domain.Event;

/**
 * ITimeKeepingEvent interface
 * 
 * @author TrangPig
 *
 */
public interface ITimeKeepingEvent {
	/**
	 * insert TimeKeepingEvent
	 * 
	 * @param timeKeepingEvent
	 * @return
	 */
	public Event insert(Event timeKeepingEvent);

	/**
	 * update TimeKeepingEvent
	 * 
	 * @param timeKeepingEvent
	 * @return
	 */
	public Event update(Event timeKeepingEvent);

	/**
	 * delete TimeKeepingEvent
	 * 
	 * @param timeKeepingEventId
	 * @return
	 */
	public int delete(long timeKeepingEventId);

	/**
	 * getTimeKeepingEventById
	 * 
	 * @param timeKeepingEventId
	 * @return
	 */
	public Event getTimeKeepingEventById(long timeKeepingEventId);

	/**
	 * getTimeKeepingEventListByOrgId
	 * 
	 * @param orgId
	 * @param suborgId
	 * @return List<Event>
	 */
	public List<Event> getTimeKeepingEventListByOrgId(EventFilter eventFilter,
			long orgId);

	/**
	 * get TimeKeepingEventList By SubOrgId
	 * 
	 * @param eventFilter
	 * @param orgId
	 * @param suborgId
	 * @return
	 */
	public List<Event> getTimeKeepingEventListBySubOrgId(
			EventFilter eventFilter, long orgId, long suborgId);

	/**
	 * get ListEvent By Date For Member
	 * 
	 * @param memberId
	 * @param date
	 * @return
	 */
	public List<Event> getListEventByDateForMember(long memberId, String date);
}
