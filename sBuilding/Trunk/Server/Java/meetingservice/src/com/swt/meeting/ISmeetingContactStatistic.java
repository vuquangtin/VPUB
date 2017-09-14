package com.swt.meeting;

import java.util.Date;

import com.swt.meeting.customObject.SmeetingContactStatisticDetatiObj;
import com.swt.meeting.customObject.SmeetingContactStatisticObj;
import com.swt.meeting.domain.SmeetingContactStatistic;

public interface ISmeetingContactStatistic {
	/**
	 * them nguoi vao lien he cong tac
	 * @param contactStatistic
	 * @return
	 */
	public SmeetingContactStatistic insert(SmeetingContactStatistic contactStatistic);

	/**
	// tong so nguoi vao theo ngay
	 * 
	 * @param fromDate
	 * @param toDate
	 * @return
	 */
	public long sumPersonContactByDate(Date fromDate, Date toDate);
	
	/**
	// tong so nguoi vao theo ngay va orgId
	 * 
	 * @param fromDate
	 * @param toDate
	 * @param orgId
	 * @return
	 */
	public long sumPersonContactByDate(Date fromDate, Date toDate, long orgId);

	/**
	// tong so nguoi vao theo ngay nhung gioi han de phan trang
	 * 
	 * @param start
	 * @param limit
	 * @param fromDate
	 * @param toDate
	 * @return
	 */
	public long sumPersonContactByDateLimit(int start, int limit, Date fromDate, Date toDate);

	/**
	// tong so nguoi vao mot don vi tu ngay den ngay
	 * 
	 * @param fromDate
	 * @param toDate
	 * @param orgId
	 * @return
	 */
	public long sumPersonContactByOrgIdAndDate(Date fromDate, Date toDate, long orgId);

	/**
	// tong so nguoi vao mot don vi tu ngay den ngay nhung gioi han de phan
	// trang
	 * 
	 * @param start
	 * @param limit
	 * @param fromDate
	 * @param toDate
	 * @param orgId
	 * @return
	 */
	public long sumPersonContactByOrgIdAndDateLimit(int start, int limit, Date fromDate, Date toDate, long orgId);

	/**
	// thong ke theo ma don vi lien he tu ngay den ngay gioi han de phan trang
	 * 
	 * @param start
	 * @param limit
	 * @param fromDate
	 * @param toDate
	 * @param orgId
	 * @return
	 */
	public SmeetingContactStatisticDetatiObj statisticDetailByOrgId(int start, int limit, Date fromDate, Date toDate,
			long orgId);

	/**
	// thong ke so luong nguoi den don vi theo ngay
	 * 
	 * @param start
	 * @param limit
	 * @param fromDate
	 * @param toDate
	 * @param orgId
	 * @return
	 */
	public SmeetingContactStatisticObj statisticByDate(int start, int limit, Date fromDate, Date toDate,long orgId);

}
