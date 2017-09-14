package com.swt.timekeeping;

import java.util.List;

import com.swt.timekeeping.domain.EventMember;

/**
 * interface ITimeKeepingEventMember 
 * @author TrangPig
 *
 */
public interface ITimeKeepingEventMember {

		/**
		 * insert
		 * @param timeKeepingEventMember
		 * @return
		 */
		public EventMember insert(EventMember timeKeepingEventMember);
		/**
		 * update
		 * @param timeKeepingEventMember
		 * @return
		 */
		public EventMember update(EventMember timeKeepingEventMember);
		/**
		 * delete
		 * @param timeKeepingEventMemberId
		 * @return
		 */
		public int delete(long timeKeepingEventMemberId);
		/**
		 * get TimeKeepingEventMember By Id
		 * @param eventMemberId
		 * @return
		 */
		public EventMember getTimeKeepingEventMemberById(long eventMemberId);
		/**
		 * get TimeKeepingEventMember List By EventId
		 * @param eventId
		 * @return
		 */
		public List<EventMember> getTimeKeepingEventMemberListByEventId( long eventId);
}
