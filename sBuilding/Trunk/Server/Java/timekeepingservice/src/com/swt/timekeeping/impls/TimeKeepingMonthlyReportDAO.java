package com.swt.timekeeping.impls;

import java.util.List;

import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;

import com.nhn.utilities.HibernateUtil;
import com.swt.timekeeping.ITimeKeepingMonthlyReport;
import com.swt.timekeeping.domain.MonthlyReport;

/**
 * TimeKeepingMonthlyReportDAO implements ITimeKeepingMonthlyReport
 * 
 * @author Trang-PC
 *
 */
public class TimeKeepingMonthlyReportDAO implements ITimeKeepingMonthlyReport {

	@Override
	public MonthlyReport getMonthlyReport(long memberId, int year, int month) {
		Session session = HibernateUtil.getSession();

		MonthlyReport result = new MonthlyReport();
		try {
			session.getTransaction().begin();
			String strQuery = "FROM MonthlyReport WHERE memberId = :memberId AND year = :year AND month = :month";
			Query query = session.createQuery(strQuery);
			query.setParameter("memberId", memberId);
			query.setParameter("year", year);
			query.setParameter("month", month);

			result = (MonthlyReport) query.uniqueResult();

			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}
		return result;
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<MonthlyReport> getMonthlyReportList(long orgId, long subOrgId,
			int year, int month) {
		Session session = HibernateUtil.getSession();

		List<MonthlyReport> result = null;
		try {
			session.getTransaction().begin();
			String sSubOrg = ((subOrgId == -1) ? "" : "AND subOrgId = "
					+ subOrgId);
			String strQuery = "FROM MonthlyReport WHERE orgId = :orgId "
					+ sSubOrg + " AND year = :year AND month = :month";
			Query query = session.createQuery(strQuery);
			query.setParameter("orgId", orgId);
			query.setParameter("year", year);
			query.setParameter("month", month);

			result = query.list();

			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}

		return result;
	}

	@Override
	public MonthlyReport insert(MonthlyReport monthlyReport) {
		if (!checkExistMonthlyReport(monthlyReport.getSubOrgId(),
				monthlyReport.getMemberId(), monthlyReport.getMonth(),
				monthlyReport.getYear())) {
			return HibernateUtil.insertObject(monthlyReport);
		}

		return null;
	}

	@Override
	public MonthlyReport update(MonthlyReport monthlyReport) {
		return HibernateUtil.updateObject(monthlyReport);
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<MonthlyReport> getMonthlyReportListByDate(long orgId,
			long subOrgId, String startDate, String endDate) {
		Session session = HibernateUtil.getSession();

		List<MonthlyReport> result = null;
		try {
			// format date: yyyy-MM-dd
			// get month and year
			int yearBegin = Integer.parseInt(startDate.substring(0, 4));
			int monthBegin = Integer.parseInt(startDate.substring(5, 7));
			int yearEnd = Integer.parseInt(endDate.substring(0, 4));
			int monthEnd = Integer.parseInt(endDate.substring(5, 7));

			session.getTransaction().begin();
			String strQuery = "Call getMonthlyReport(:orgId, :subOrgId, :startDate, :endDate)";
			Query query = session.createQuery(strQuery);
			query.setParameter("orgId", orgId);
			query.setParameter("subOrgId", subOrgId);
			query.setParameter("startDate", "'" + yearBegin + "-" + monthBegin
					+ "-01'");
			query.setParameter("endDate", "'" + yearEnd + "-" + monthEnd
					+ "-01'");

			result = query.list();

			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}

		return result;
	}

	public boolean checkExistMonthlyReport(long subOrgId, long memberId,
			int month, int year) {
		Session session = HibernateUtil.getSession();
		MonthlyReport monthlyReport = new MonthlyReport();
		boolean isExist = false;

		try {
			session.beginTransaction();
			String strQuery = "FROM MonthlyReport WHERE (subOrgId = :subOrgId) "
					+ "AND (memberId = :memberId) AND (month = :month) AND (year = :year)";
			Query query = session.createQuery(strQuery);

			query.setParameter("subOrgId", subOrgId);
			query.setParameter("memberId", memberId);
			query.setParameter("month", month);
			query.setParameter("year", year);
			monthlyReport = (MonthlyReport) query.uniqueResult();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}

		if (null != monthlyReport) {
			isExist = true;
		}

		return isExist;
	}
}
