package com.swt.nonresident.impls;

import java.util.Date;

import com.nhn.utilities.HibernateUtil;
import com.swt.nonresident.INonResidentContactStatistic;
import com.swt.nonresident.customObject.NonResidentContactStatisticDetatiObj;
import com.swt.nonresident.customObject.NonResidentContactStatisticObj;
import com.swt.nonresident.domain.NonResidentContactStatistic;

public class NonResidentContactStatisticDAO implements INonResidentContactStatistic {
	//hien tai cac phuong thuc cua ham nay khong dung => comment lai het
	
	@Override
	public NonResidentContactStatistic insert(NonResidentContactStatistic contactStatistic) {
		return HibernateUtil.insertObject(contactStatistic);
	}

	@Override
	public long sumPersonContactByDate(Date fromDate, Date toDate) {

//		Calendar c = Calendar.getInstance();
//		c.setTime(toDate);
//		c.add(Calendar.DATE, 1);
//		toDate = c.getTime();
//		SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");
//
//		String sql = "SELECT COUNT(*) " + " FROM NonResidentContactStatistic " + " WHERE inputTime BETWEEN '"
//				+ sdf.format(fromDate) + "' AND '" + sdf.format(toDate) + "' " + " GROUP BY organizationMeetingId";
//		return ((List<Object>) CommonFunction.INSTANCE.getByQuery(sql)).size();
		return 0;
	}

	@Override
	public long sumPersonContactByDate(Date fromDate, Date toDate, long orgId) {
//		Calendar c = Calendar.getInstance();
//		c.setTime(toDate);
//		c.add(Calendar.DATE, 1);
//		toDate = c.getTime();
//		SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");
//
//		String sql = "SELECT COUNT(*) " + " FROM NonResidentContactStatistic " + " WHERE organizationMeetingId = "
//				+ orgId + " AND inputTime BETWEEN '" + sdf.format(fromDate) + "' AND '" + sdf.format(toDate) + "' "
//				+ " GROUP BY organizationMeetingId";
//		return ((List<Object>) CommonFunction.INSTANCE.getByQuery(sql)).size();
		
		return 0;
	}

	@Override
	public long sumPersonContactByDateLimit(int start, int limit, Date fromDate, Date toDate) {
		// TODO Auto-generated method stub
		return 0;
	}

	@Override
	public long sumPersonContactByOrgIdAndDate(Date fromDate, Date toDate, long orgId) {
//		Calendar c = Calendar.getInstance();
//		c.setTime(toDate);
//		c.add(Calendar.DATE, 1);
//		toDate = c.getTime();
//		SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");
//
//		String sql = "SELECT COUNT(*) " + " FROM NonResidentContactStatistic " + " WHERE organizationMeetingId = "
//				+ orgId + " AND inputTime BETWEEN '" + sdf.format(fromDate) + "' AND '" + sdf.format(toDate) + "'";
//		return (long) CommonFunction.INSTANCE.sumByQuery(sql);
		return 0;
	}

	@Override
	public long sumPersonContactByOrgIdAndDateLimit(int start, int limit, Date fromDate, Date toDate, long orgId) {
		// TODO Auto-generated method stub
		return 0;
	}

	@Override
	public NonResidentContactStatisticDetatiObj statisticDetailByOrgId(int start, int limit, Date fromDate, Date toDate,
			long orgId) {
//		Session session = HibernateUtil.getSession();
//
//		NonResidentContactStatisticDetatiObj result = null;
//		List<NonResidentContactStatistic> contactStatistics = null;
//		try {
//			session.getTransaction().begin();
//
//			Calendar c = Calendar.getInstance();
//			c.setTime(toDate);
//			c.add(Calendar.DATE, 1);
//			toDate = c.getTime();
//			SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");
//
//			Query query = session.getNamedQuery("statisticNonresidentContactDetailByDateAndOrgId");
//			query.setInteger("start", start);
//			query.setInteger("limit", limit);
//			query.setString("fromdate", sdf.format(fromDate));
//			query.setString("todate", sdf.format(toDate));
//			query.setParameter("orgid", orgId);
//			contactStatistics = query.list();
//			session.getTransaction().commit();
//
//		} catch (HibernateException e) {
//			session.getTransaction().rollback();
//			e.printStackTrace();
//		} finally {
//			session.flush();
//			session.clear();
//			session.close();
//		}
//		if (contactStatistics != null) {
//			if (contactStatistics.size() > 0) {
//				result = new NonResidentContactStatisticDetatiObj();
//				result.setContactStatisticDetails(contactStatistics);
//
//				result.setSum(sumPersonContactByOrgIdAndDate(fromDate, toDate, orgId));
//			}
//		}
//		return result;
		return null;
	}

	@Override
	public NonResidentContactStatisticObj statisticByDate(int start, int limit, Date fromDate, Date toDate,
			long orgId) {
//		Session session = HibernateUtil.getSession();
//
//		NonResidentContactStatisticObj result = null;
//		List<NonResidentContactCount> contactStatistics = null;
//		try {
//			session.getTransaction().begin();
//
//			Calendar c = Calendar.getInstance();
//			c.setTime(toDate);
//			c.add(Calendar.DATE, 1);
//			toDate = c.getTime();
//			SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");
//			String nameProcedure = "";
//			if (orgId == -1) {
//				nameProcedure = "statisticNonresidentContactByDateAll";
//			} else {
//				nameProcedure = "statisticNonresidentContactByDateAndOrgId";
//			}
//			Query query = session.getNamedQuery(nameProcedure);
//			query.setInteger("start", start);
//			query.setInteger("limit", limit);
//			query.setString("fromdate", sdf.format(fromDate));
//			query.setString("todate", sdf.format(toDate));
//			query.setParameter("orgid", orgId);
//			contactStatistics = query.list();
//			session.getTransaction().commit();
//
//		} catch (HibernateException e) {
//			session.getTransaction().rollback();
//			e.printStackTrace();
//		} finally {
//			session.flush();
//			session.clear();
//			session.close();
//		}
//		if (contactStatistics != null) {
//			if (contactStatistics.size() > 0) {
//				result = new NonResidentContactStatisticObj();
//				result.setContactStatistics(contactStatistics);
//				if (orgId == -1) {
//					result.setSum(sumPersonContactByDate(fromDate, toDate));
//				} else {
//					result.setSum(sumPersonContactByDate(fromDate, toDate, orgId));
//				}
//			}
//		}
//		return result;
		return null;
	}

}
