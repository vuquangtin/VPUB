package com.swt.meeting.impls;

import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;
import java.util.List;

import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;

import com.nhn.utilities.HibernateUtil;
import com.swt.meeting.ISmeetingContactStatistic;
import com.swt.meeting.customObject.SmeetingContactStatisticDetatiObj;
import com.swt.meeting.customObject.SmeetingContactStatisticObj;
import com.swt.meeting.domain.SmeetingContactCount;
import com.swt.meeting.domain.SmeetingContactStatistic;
import com.swt.meeting.lib.tm.CommonFunction;

public class SmeetingContactStatisticDAO implements ISmeetingContactStatistic {

	@Override
	public SmeetingContactStatistic insert(SmeetingContactStatistic contactStatistic) {
		return HibernateUtil.insertObject(contactStatistic);
	}

	@Override
	@SuppressWarnings("unchecked")
	public long sumPersonContactByDate(Date fromDate, Date toDate) {

		SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");

		String sql = "SELECT COUNT(*) " + " FROM SmeetingContactStatistic " + " WHERE inputTime BETWEEN '"
				+ sdf.format(fromDate) + "' AND '" + sdf.format(toDate) + "' " + " GROUP BY organizationMeetingId";
		return ((List<Object>) CommonFunction.INSTANCE.getByQuery(sql)).size();
	}

	@Override
	@SuppressWarnings("unchecked")
	public long sumPersonContactByDate(Date fromDate, Date toDate, long orgId) {
		SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");

		String sql = "SELECT COUNT(*) " + " FROM SmeetingContactStatistic " + " WHERE organizationMeetingId = " + orgId
				+ " AND inputTime BETWEEN '" + sdf.format(fromDate) + "' AND '" + sdf.format(toDate) + "' "
				+ " GROUP BY organizationMeetingId";
		return ((List<Object>) CommonFunction.INSTANCE.getByQuery(sql)).size();
	}

	@Override
	public long sumPersonContactByDateLimit(int start, int limit, Date fromDate, Date toDate) {
		// TODO Auto-generated method stub
		return 0;
	}

	@Override
	public long sumPersonContactByOrgIdAndDate(Date fromDate, Date toDate, long orgId) {
		Calendar c = Calendar.getInstance();
		c.setTime(toDate);
		c.add(Calendar.DATE, 1);
		toDate = c.getTime();
		SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");

		String sql = "SELECT COUNT(*) " + " FROM SmeetingContactStatistic " + " WHERE organizationMeetingId = " + orgId
				+ " AND inputTime BETWEEN '" + sdf.format(fromDate) + "' AND '" + sdf.format(toDate) + "'";
		return (long) CommonFunction.INSTANCE.sumByQuery(sql);
	}

	@Override
	public long sumPersonContactByOrgIdAndDateLimit(int start, int limit, Date fromDate, Date toDate, long orgId) {
		// TODO Auto-generated method stub
		return 0;
	}

	@Override
	@SuppressWarnings("unchecked")
	public SmeetingContactStatisticDetatiObj statisticDetailByOrgId(int start, int limit, Date fromDate, Date toDate,
			long orgId) {
		Session session = HibernateUtil.getSession();

		SmeetingContactStatisticDetatiObj result = null;
		List<SmeetingContactStatistic> contactStatistics = null;
		try {
			session.getTransaction().begin();

			Calendar c = Calendar.getInstance();
			c.setTime(toDate);
			c.add(Calendar.DATE, 1);
			toDate = c.getTime();
			SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");

			Query query = session.getNamedQuery("statisticContactDetailByDateAndOrgId");
			query.setInteger("start", start);
			query.setInteger("limit", limit);
			query.setString("fromdate", sdf.format(fromDate));
			query.setString("todate", sdf.format(toDate));
			query.setParameter("orgid", orgId);
			contactStatistics = query.list();
			session.getTransaction().commit();

		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}
		if (contactStatistics != null) {
			if (contactStatistics.size() > 0) {
				result = new SmeetingContactStatisticDetatiObj();
				result.setContactStatisticDetails(contactStatistics);

				result.setSum(sumPersonContactByOrgIdAndDate(fromDate, toDate, orgId));
			}
		}
		return result;
	}

	@Override
	@SuppressWarnings("unchecked")
	public SmeetingContactStatisticObj statisticByDate(int start, int limit, Date fromDate, Date toDate, long orgId) {
		Session session = HibernateUtil.getSession();

		SmeetingContactStatisticObj result = null;
		List<SmeetingContactCount> contactStatistics = null;
		try {
			session.getTransaction().begin();

			Calendar c = Calendar.getInstance();
			c.setTime(toDate);
			c.add(Calendar.DATE, 1);
			toDate = c.getTime();
			SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");
			String nameProcedure = "";
			if (orgId == -1) {
				nameProcedure = "statisticContactByDateAll";
			} else {
				nameProcedure = "statisticContactByDateAndOrgId";
			}
			Query query = session.getNamedQuery(nameProcedure);
			query.setInteger("start", start);
			query.setInteger("limit", limit);
			query.setString("fromdate", sdf.format(fromDate));
			query.setString("todate", sdf.format(toDate));
			query.setParameter("orgid", orgId);
			contactStatistics = query.list();
			session.getTransaction().commit();

		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}
		if (contactStatistics != null) {
			if (contactStatistics.size() > 0) {
				result = new SmeetingContactStatisticObj();
				result.setContactStatistics(contactStatistics);
				if (orgId == -1) {
					result.setSum(sumPersonContactByDate(fromDate, toDate));
				} else {
					result.setSum(sumPersonContactByDate(fromDate, toDate, orgId));
				}
			}
		}
		return result;
	}

}
