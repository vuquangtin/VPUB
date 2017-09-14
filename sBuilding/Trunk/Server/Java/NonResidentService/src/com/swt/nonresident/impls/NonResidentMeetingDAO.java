package com.swt.nonresident.impls;

import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;
import java.util.List;

import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;

import com.google.gson.Gson;
import com.nhn.utilities.HibernateUtil;
import com.swt.nonresident.INonResidentMeeting;
import com.swt.nonresident.customObject.NonResidentMeetingObj;
import com.swt.nonresident.domain.NonResidentMeeting;
import com.swt.nonresident.domain.NonResidentPartaker;

public class NonResidentMeetingDAO implements INonResidentMeeting {

	@Override
	public NonResidentMeeting insert(NonResidentMeeting meeting) {
		return HibernateUtil.insertObject(meeting);
	}

	/**
	 * 30/11/2016 lay danh sach cuoc hop trong ngay theo organizationAttendId
	 * 
	 * @param organizationMeetingId
	 */
	@SuppressWarnings("unchecked")
	@Override
	public List<NonResidentMeeting> getNonResidentMeetingByOrganizationMeetingId(long organizationMeetingId) {
		Session session = HibernateUtil.getSession();

		List<NonResidentMeeting> result = null;
		try {
			session.getTransaction().begin();

			// lay ngay hien tai cua he thong
			Date date = new Date();
			Calendar c = Calendar.getInstance();
			c.setTime(date);
			c.add(Calendar.DATE, 1);
			Date toDate = c.getTime();

			SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd 00:00:00");

			String strQuery = "";
			Query query = null;
			if (organizationMeetingId == -1) {
				// lay danh sach cac cuoc hop cua tat ca cac don vi to chuc cuoc hop  
				strQuery = "FROM NonResidentMeeting " + "WHERE startTime BETWEEN :fromDate AND :toDate ";
				query = session.createQuery(strQuery);
			} else {
				strQuery = "FROM NonResidentMeeting "
						+ "WHERE organizationMeetingId = :organizationMeetingId AND startTime BETWEEN :fromDate AND :toDate ";
				query = session.createQuery(strQuery);
				query.setLong("organizationMeetingId", organizationMeetingId);
			}
			query.setString("fromDate", sdf.format(date));
			query.setString("toDate", sdf.format(toDate));
			result = query.list();
			session.getTransaction().commit();

			// them danh sach nguoi tham du cho nhung cuoc hop da co san
			Gson gson = new Gson();
			for (NonResidentMeeting nonResidentMeeting : result) {
				if (nonResidentMeeting.getListNonResident() == null
						|| nonResidentMeeting.getListNonResident().isEmpty()) {
					List<NonResidentPartaker> partakers = PartakerController.Instance
							.getPartakerByMeetingId(nonResidentMeeting.getId());
					nonResidentMeeting.setListNonResident(gson.toJson(partakers));
				}
			}

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


	/**
	 * 30/11/2016 lay danh sach cuoc hop tu ngay den ngay va ten to chuc cuoc
	 * hop va ten cuoc hop
	 * 
	 * @param start
	 * @param end
	 * @param fromTime
	 * @param toTime
	 * @param organizationMeetingId
	 * @param meetingName
	 */
	@SuppressWarnings("unchecked")
	@Override
	public NonResidentMeetingObj getNonResidentMeetingByDateAndOrgIdAndMeetingName(int start, int end, Date fromDate,
			Date toDate, long organizationMeetingId, String meetingName) {
		Session session = HibernateUtil.getSession();

		NonResidentMeetingObj result = null;
		List<NonResidentMeeting> nonResidentMeetings = null;
		try {
			session.getTransaction().begin();

			// lay ngay hien tai cua he thong
			Calendar c = Calendar.getInstance();
			c.setTime(toDate);
			c.add(Calendar.DATE, 1);
			toDate = c.getTime();

			SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd 00:00:00");
			String strQuery = null;
			Query query = null;
			if (organizationMeetingId == -1) {
				// lay danh sach cac cuoc hop cua tat ca cac don vi to chuc
//				strQuery = "FROM NonResidentMeeting " 
//						+ "WHERE startTime BETWEEN :fromDate AND :toDate ";
				strQuery = "FROM NonResidentMeeting " 
						+ " WHERE startTime BETWEEN :fromDate AND :toDate "
						+ " AND nonresident = TRUE "
						+ " AND meetingCodeStatus = TRUE "
						+ " ORDER BY startTime ASC";
				query = session.createQuery(strQuery);
			} else {
				if ("all".equalsIgnoreCase(meetingName)) {
					meetingName = "";
				}
//				strQuery = "FROM NonResidentMeeting " 
//						+ "WHERE organizationMeetingId = :organizationMeetingId "
//						+ "AND name LIKE '%" + meetingName + "%' " + "AND startTime BETWEEN :fromDate AND :toDate "
//						+ "ORDER BY startTime ASC";
				strQuery = "FROM NonResidentMeeting " 
						+ " WHERE organizationMeetingId = :organizationMeetingId "
						+ " AND name LIKE '%" + meetingName + "%' " + " AND startTime BETWEEN :fromDate AND :toDate "
						+ " AND nonresident = TRUE "
						+ " AND meetingCodeStatus = TRUE " 
						+ "ORDER BY startTime ASC";

				query = session.createQuery(strQuery);
				query.setLong("organizationMeetingId", organizationMeetingId);
			}
			query.setString("fromDate", sdf.format(fromDate));
			query.setString("toDate", sdf.format(toDate));
			query.setFirstResult(start);
			query.setMaxResults(end);

			nonResidentMeetings = query.list();
			session.getTransaction().commit();

			if (nonResidentMeetings.size() > 0) {
				result = new NonResidentMeetingObj();
				result.setNonResidentMeetings(nonResidentMeetings);

				result.setSum(sumNonResidentMeetingByDateAndOrgIdAndMeetingName(fromDate, toDate, organizationMeetingId,
						meetingName));
			}

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

	/**
	 * 6/12/2016 lay cuoc hop theo id cuoc hop
	 * 
	 * @param meetingId
	 */
	@Override
	public NonResidentMeeting getNonResidentMeetingById(long meetingId) {
		Session session = HibernateUtil.getSession();

		NonResidentMeeting result = null;
		try {
			session.getTransaction().begin();

			String strQuery = "FROM NonResidentMeeting WHERE id = :meetingId";
			Query query = session.createQuery(strQuery);
			query.setLong("meetingId", meetingId);

			result = (NonResidentMeeting) query.uniqueResult();
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

	//duoc dung trong ham getNonResidentMeetingByDateAndOrgIdAndMeetingName
	@Override
	public long sumNonResidentMeetingByDateAndOrgIdAndMeetingName(Date fromDate, Date toDate,
			long organizationMeetingId, String meetingName) {
		Session session = HibernateUtil.getSession();

		long result = 0;
		try {
			session.getTransaction().begin();

			// lay ngay hien tai cua he thong
			Calendar c = Calendar.getInstance();
			c.setTime(toDate);
			c.add(Calendar.DATE, 1);
			toDate = c.getTime();

			SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd 00:00:00");
			String strQuery = null;
			Query query = null;
			if (organizationMeetingId == -1) {
				strQuery = "SELECT COUNT(*) FROM NonResidentMeeting "
						+ " WHERE startTime BETWEEN :fromDate AND :toDate "
						+ " AND nonresident = TRUE "
						+ " AND meetingCodeStatus = TRUE ";
				query = session.createQuery(strQuery);
			} else {
				if ("all".equalsIgnoreCase(meetingName)) {
					meetingName = "";
				}
				strQuery = "SELECT COUNT(*) FROM NonResidentMeeting "
						+ " WHERE organizationMeetingId = :organizationMeetingId " 
						+ " AND name LIKE '%" + meetingName + "%' " 
						+ " AND nonresident = TRUE "
						+ " AND meetingCodeStatus = TRUE " 
						+ " AND startTime BETWEEN :fromDate AND :toDate " + "ORDER BY startTime ASC";

				query = session.createQuery(strQuery);
				query.setLong("organizationMeetingId", organizationMeetingId);
			}
			query.setString("fromDate", sdf.format(fromDate));
			query.setString("toDate", sdf.format(toDate));

			result = Long.parseLong(query.uniqueResult().toString());
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
	public NonResidentMeeting update(NonResidentMeeting meeting) {
		return HibernateUtil.updateObject(meeting);
	}

	@Override
	public int delete(long meetingId) {
		return HibernateUtil.deleteById(new NonResidentMeeting(), meetingId);
	}

}
