	package com.swt.meeting.impls;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.List;

import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;

import com.nhn.utilities.HibernateUtil;
import com.swt.meeting.IMeeting;
import com.swt.meeting.customObject.MeetingObjManager;
import com.swt.meeting.domain.EmailConfig;
import com.swt.meeting.domain.Meeting;
import com.swt.meeting.lib.tm.Constant;

/**
 * @author TaiMai
 * 
 */
public class MeetingDAO implements IMeeting {

	@Override
	public Meeting insert(Meeting meeting) {

		return HibernateUtil.insertObject(meeting);
	}

	@Override
	public Meeting update(Meeting meeting) {
		return HibernateUtil.updateObject(meeting);
	}

	@Override
	public int delete(long meetingId) {
		Meeting meeting = new Meeting();
		return HibernateUtil.deleteById(meeting, meetingId);
	}

	@Override
	public Meeting getMeetingById(long meetingId) {
		Session session = HibernateUtil.getSession();

		Meeting result = new Meeting();
		try {
			session.getTransaction().begin();
			String strQuery = "FROM Meeting WHERE id = :confid";
			Query query = session.createQuery(strQuery);
			query.setParameter("confid", meetingId);

			result = (Meeting) query.uniqueResult();

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

	/**
	 * 26/10/2016 danh sach Meeting theo ngay va gio, de getMeetingObjByDateTime
	 * dung getMeetingByDateTime
	 * 
	 * @param meetingDateTime
	 * @return List<Meeting>
	 */
	@SuppressWarnings("unchecked")
	@Override
	public List<Meeting> getMeetingByDateTime(Date meetingDateTime) {

		Session session = HibernateUtil.getSession();
		List<Meeting> result = null;
		try {
			session.getTransaction().begin();

			Calendar date = Calendar.getInstance();
			date.setTime(meetingDateTime);
			date.add(Calendar.DAY_OF_MONTH, 1);
			Date nextDate = date.getTime();
			SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd HH:mm");

			// kiem tra den cuoi ngay hom do
			SimpleDateFormat sdf1 = new SimpleDateFormat("yyyy-MM-dd 00:00");

			String strQuery = "FROM Meeting " + " WHERE StartTime BETWEEN '" + sdf.format(meetingDateTime) + "' and '"
					+ sdf1.format(nextDate) + "'" + " AND meetingCodeStatus = TRUE " + " AND startTime != '"
					+ MeetingLCTDAO.DATE_DEFAULT + "' " + "ORDER BY StartTime asc";
			Query query = session.createQuery(strQuery);
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
	public Meeting getMeetingByIdAndDateTime(long meetingId, Date meetingDateTime) {
		Session session = HibernateUtil.getSession();
		Meeting result = null;
		try {
			session.getTransaction().begin();

			Calendar date = Calendar.getInstance();
			date.setTime(meetingDateTime);
			date.add(Calendar.DAY_OF_MONTH, 1);
			Date nextDate = date.getTime();
			SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd HH:mm");

			// kiem tra den cuoi ngay hom do
			SimpleDateFormat sdf1 = new SimpleDateFormat("yyyy-MM-dd 00:00");

			String strQuery = "FROM Meeting WHERE id = :meetingid and StartTime BETWEEN '" + sdf.format(meetingDateTime)
					+ "' and '" + sdf1.format(nextDate) + "'";
			Query query = session.createQuery(strQuery);
			query.setParameter("meetingid", meetingId);
			result = (Meeting) query.uniqueResult();

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
	public int edit(Meeting meeting) {
		int result = -1;
		Session session = HibernateUtil.getSession();
		try {
			session.getTransaction().begin();

			String strQuery = "UPDATE Meeting " + "SET name = :name,"
					+ "organizationMeetingId = :organizationMeetingId,"
					+ "organizationMeetingName = :organizationMeetingName," + "roomId = :roomId,"
					+ "roomName = :roomName," + "number = :number," + "startTime = :startTime," + "endTime = :endTime,"
					+ "note = :note " + "WHERE meetingcode = :meetingcode ";
			Query query = session.createQuery(strQuery);
			query.setParameter("meetingcode", meeting.getMeetingCode());
			query.setParameter("name", meeting.getName());
			query.setParameter("organizationMeetingId", meeting.getOrganizationMeetingId());
			query.setParameter("organizationMeetingName", meeting.getOrganizationMeetingName());
			query.setParameter("roomId", meeting.getRoomId());
			query.setParameter("roomName", meeting.getRoomName());
			query.setParameter("number", meeting.getNumber());
			query.setParameter("startTime", meeting.getStartTime());
			query.setParameter("endTime", meeting.getEndTime());
			query.setParameter("note", meeting.getNote());
			result = query.executeUpdate();

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
	public int updateNeocoreStatus(long neocoreId) {
		int result = -1;
		Session session = HibernateUtil.getSession();
		try {
			session.getTransaction().begin();

			String strQuery = "UPDATE Meeting " + "SET meetingCodeStatus = FALSE "
					+ "WHERE meetingCode = :neocoreId AND meetingCodeStatus = True";
			Query query = session.createQuery(strQuery);
			query.setParameter("neocoreId", neocoreId);
			result = query.executeUpdate();

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

	/*
	 * (non-Javadoc)
	 * 
	 * @see com.swt.meeting.IMeeting#getListMeeting()
	 */
	@SuppressWarnings("unchecked")
	@Override
	public List<Meeting> getListMeeting() {
		Session session = HibernateUtil.getSession();
		List<Meeting> result = null;
		try {
			session.getTransaction().begin();

			String strQuery = "FROM Meeting";
			Query query = session.createQuery(strQuery);
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

	// start giong service ben snonresident

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
	public MeetingObjManager getMeetingByDateAndOrgIdAndMeetingName(int start, int end, Date fromDate, Date toDate,
			long organizationMeetingId, String meetingName) {
		Session session = HibernateUtil.getSession();

		MeetingObjManager result = null;
		List<Meeting> Meetings = null;
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
				strQuery = "FROM Meeting " + " WHERE startTime BETWEEN :fromDate AND :toDate "
						+ " AND nonresident = FALSE " + " AND meetingCodeStatus = TRUE " + " ORDER BY startTime ASC";
				query = session.createQuery(strQuery);
			} else {
				if ("all".equalsIgnoreCase(meetingName)) {
					meetingName = "";
				}
				strQuery = "FROM Meeting " + "" + " WHERE organizationMeetingId = :organizationMeetingId "
						+ " AND name LIKE '%" + meetingName + "%' " + " AND startTime BETWEEN :fromDate AND :toDate "
						+ " AND nonresident = FALSE " + " AND meetingCodeStatus = TRUE " + "ORDER BY startTime ASC";

				query = session.createQuery(strQuery);
				query.setLong("organizationMeetingId", organizationMeetingId);
			}
			query.setString("fromDate", sdf.format(fromDate));
			query.setString("toDate", sdf.format(toDate));
			query.setFirstResult(start);
			query.setMaxResults(end);

			Meetings = query.list();
			session.getTransaction().commit();

			if (Meetings.size() > 0) {
				result = new MeetingObjManager();
				result.setMeetings(Meetings);

				// my.nguyen set todate -1 do da +1 roi , nhung ham sum lai +1
				// nen phai -1 truoc khi chuyen qua ham moi
				// lay ngay hien tai cua he thong
				c.setTime(toDate);
				c.add(Calendar.DATE, -1);
				toDate = c.getTime();

				result.setSum(
						sumMeetingByDateAndOrgIdAndMeetingName(fromDate, toDate, organizationMeetingId, meetingName));
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

	@Override
	public long sumMeetingByDateAndOrgIdAndMeetingName(Date fromDate, Date toDate, long organizationMeetingId,
			String meetingName) {
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
				strQuery = "SELECT COUNT(*) FROM Meeting " + " WHERE startTime BETWEEN :fromDate AND :toDate "
						+ " AND meetingCodeStatus = TRUE " + " AND nonresident = FALSE ORDER BY startTime ASC";
				query = session.createQuery(strQuery);
			} else {
				if ("all".equalsIgnoreCase(meetingName)) {
					meetingName = "";
				}
				strQuery = "SELECT COUNT(*) FROM Meeting " + " WHERE organizationMeetingId = :organizationMeetingId "
						+ " AND name LIKE '%" + meetingName + "%' " + "AND startTime BETWEEN :fromDate AND :toDate "
						+ " AND meetingCodeStatus = TRUE " + " AND nonresident = FALSE ORDER BY startTime ASC";

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

	/*
	 * getmeeting by meetingcode function for web
	 * 
	 * @see com.swt.meeting.IMeeting#getMeetingByMeetingCode(long)
	 */
	@SuppressWarnings("unchecked")
	@Override
	public List<Meeting> getMeetingByMeetingCode(long meetingcode) {
		Session session = HibernateUtil.getSession();

//		Meeting result = new Meeting();
		List<Meeting> result = new ArrayList<Meeting>();
		try {
			session.getTransaction().begin();
			String strQuery = "FROM Meeting WHERE meetingCode = :meetingcode";
			Query query = session.createQuery(strQuery);
			query.setParameter("meetingcode", meetingcode);

//			result = (Meeting) query.uniqueResult();
			
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

	public EmailConfig insertEmailConfig(EmailConfig emailConfig) {
		return HibernateUtil.insertObject(emailConfig);
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see com.swt.meetingregister.RegisterAccount#getEmailConfig()
	 */
	public EmailConfig getEmailConfig() {
		Session session = HibernateUtil.getSession();
		EmailConfig result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM EmailConfig";
			Query query = session.createQuery(strQuery);
			result = (EmailConfig) query.uniqueResult();
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
	// end giong service ben snonresident

	@Override
	public void increasePersonAttend(long meetingId, int personAttendType) {
		Meeting meeting = getMeetingById(meetingId);
		if (meeting != null) {
			switch (personAttendType) {
			case Constant.PERSON_ATTEND_INVITED:
				meeting.setNumberPeopleAttendInvited(meeting.getNumberPeopleAttendInvited() + 1);
				break;
			case Constant.PERSON_ATTEND_ADD:
				meeting.setNumberPeopleAdded(meeting.getNumberPeopleAdded() + 1);
				break;
			case Constant.JOURNALIST:
				meeting.setNumberJournalist(meeting.getNumberJournalist() + 1);
				break;
			case Constant.NONRESIDON:
				meeting.setNumberNonresident(meeting.getNumberNonresident() + 1);
				break;
			}
			update(meeting);
		}
	}

	@Override
	public Meeting getMeetingByMeetingCodeActive(long meetingcode) {
		Session session = HibernateUtil.getSession();
		Meeting result = null;
		try {
			session.getTransaction().begin();

			String strQuery = "FROM Meeting WHERE meetingCode = :neocoreId AND meetingCodeStatus = true";
			Query query = session.createQuery(strQuery);
			query.setParameter("neocoreId", meetingcode);
			result = (Meeting) query.uniqueResult();
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
}
