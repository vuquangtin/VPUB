package com.swt.nonresident;

import java.util.Date;

import com.swt.nonresident.customObject.NonResidentContactStatisticDetatiObj;
import com.swt.nonresident.customObject.NonResidentContactStatisticObj;
import com.swt.nonresident.domain.NonResidentContactStatistic;

public interface INonResidentContactStatistic {
	// insert
	public NonResidentContactStatistic insert(NonResidentContactStatistic contactStatistic);

	/**
	// tong so nguoi vao theo ngay
	 * 
	 * @param fromDate
	 * @param toDate
	 * @return
	 */
	public long sumPersonContactByDate(Date fromDate, Date toDate);

	/**
	 * tong so nguoi vao theo ngay va orgId
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
	public NonResidentContactStatisticDetatiObj statisticDetailByOrgId(int start, int limit, Date fromDate, Date toDate,
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
	public NonResidentContactStatisticObj statisticByDate(int start, int limit, Date fromDate, Date toDate, long orgId);

}
