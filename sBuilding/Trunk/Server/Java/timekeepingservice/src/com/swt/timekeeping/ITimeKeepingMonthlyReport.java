package com.swt.timekeeping;

import java.util.List;

import com.swt.timekeeping.domain.MonthlyReport;
/**
 *  interface ITimeKeepingMonthlyReport 
 * @author Trang-PC
 *
 */
public interface ITimeKeepingMonthlyReport {
	/**
	 * get MonthlyReport by memberId, year and month
	 * @param memberId
	 * @param year
	 * @param month
	 * @return
	 */
	public MonthlyReport getMonthlyReport(long memberId, int year, int month);
	/**
	 * get MonthlyReport List
	 * @param orgId
	 * @param subOrgId
	 * @param year
	 * @param month
	 * @return
	 */
	public List<MonthlyReport> getMonthlyReportList(long orgId, long subOrgId, int year, int month);
	/**
	 * get MonthlyReportList By Date
	 * @param orgId
	 * @param subOrgId
	 * @param startDate
	 * @param endDate
	 * @return
	 */
	public List<MonthlyReport> getMonthlyReportListByDate(long orgId, long subOrgId, String startDate, String endDate);
	/**
	 * insert MonthlyReport
	 * @param report
	 * @return
	 */
	public MonthlyReport insert(MonthlyReport report);
	/**
	 * update MonthlyReport
	 * @param monthlyReport
	 * @return
	 */
	public MonthlyReport update(MonthlyReport monthlyReport);
}
