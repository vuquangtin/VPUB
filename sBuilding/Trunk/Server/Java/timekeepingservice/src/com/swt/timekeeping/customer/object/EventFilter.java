package com.swt.timekeeping.customer.object;

import java.io.Serializable;

public class EventFilter implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;

	private boolean filterByMemberName;

	private String memberName;

	private boolean filterByEventName;

	private String eventName;

	private boolean filterByDateBegin;

	private String dateBegin;

	private boolean filterByDateEnd;

	private String dateEnd;
/**
 * tao cau lenh hql 
 * @param orgId
 * @param suborgId
 * @return
 */
	public String clone(long orgId, long suborgId) {
		
		String result = "";
		
		if (filterByMemberName) {
			result = "SELECT ev FROM EventMember evm, Event ev WHERE evm.eventId = ev.eventId  AND evm.memberName LIKE '%"
					+ memberName + "%'" + " AND ev.orgId = " + orgId;
		} else {
			result = "FROM Event WHERE orgId = " + orgId;
		}

		if (suborgId != -1){
			if(filterByMemberName)
				result += " AND ev.subOrgId = " + suborgId;
			else result += " AND subOrgId = " + suborgId;
		}

		if (filterByDateBegin && filterByDateEnd) {
			if(filterByMemberName)
			result += " AND ev.dateIn BETWEEN '" + dateBegin + "' AND '" + dateEnd + "'";
			else result += " AND dateIn BETWEEN '" + dateBegin + "' AND '" + dateEnd + "'";
		}

		if (filterByEventName) {
			if(filterByMemberName)
			result += " AND ev.eventName LIKE '%" + eventName + "%'";
			else result += " AND eventName LIKE '%" + eventName + "%'";
		}

		return result;
	}

	public boolean isFilterByMemberName() {
		return filterByMemberName;
	}

	public void setFilterByMemberName(boolean filterByMemberName) {
		this.filterByMemberName = filterByMemberName;
	}

	public String getMemberName() {
		return memberName;
	}

	public void setMemberName(String memberName) {
		this.memberName = memberName;
	}

	public boolean isFilterByEventName() {
		return filterByEventName;
	}

	public void setFilterByEventName(boolean filterByEventName) {
		this.filterByEventName = filterByEventName;
	}

	public String getEventName() {
		return eventName;
	}

	public void setEventName(String eventName) {
		this.eventName = eventName;
	}

	public String getDateBegin() {
		return dateBegin;
	}

	public void setDateBegin(String dateBegin) {
		this.dateBegin = dateBegin;
	}

	public String getDateEnd() {
		return dateEnd;
	}

	public void setDateEnd(String dateEnd) {
		this.dateEnd = dateEnd;
	}

	public boolean isFilterByDateBegin() {
		return filterByDateBegin;
	}

	public void setFilterByDateBegin(boolean filterByDateBegin) {
		this.filterByDateBegin = filterByDateBegin;
	}

	public boolean isFilterByDateEnd() {
		return filterByDateEnd;
	}

	public void setFilterByDateEnd(boolean filterByDateEnd) {
		this.filterByDateEnd = filterByDateEnd;
	}

}