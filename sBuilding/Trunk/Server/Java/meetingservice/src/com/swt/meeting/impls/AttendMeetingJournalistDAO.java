package com.swt.meeting.impls;

import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;
import java.util.List;

import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;

import com.nhn.utilities.HibernateUtil;
import com.swt.meeting.IAttendMeetingJournalist;
import com.swt.meeting.customObject.JournalistAttendStatistic;
import com.swt.meeting.customObject.JournalistAttendStatisticDetail;
import com.swt.meeting.customObject.JournalistAttendStatisticDetailObj;
import com.swt.meeting.customObject.JournalistAttendStatisticObj;
import com.swt.meeting.customObject.NumberObj;
import com.swt.meeting.domain.AttendMeetingJournalist;
import com.swt.meeting.lib.tm.CommonFunction;
import com.swt.meeting.lib.tm.Constant;

public class AttendMeetingJournalistDAO implements IAttendMeetingJournalist {
	private final int NOT_EXIST_SERIALNUMBER = 1;
	private final int UPDATE_SERIALNUMBER = 2;
	// private final int ALREADY_EXIST_SERIALNUMBER = 3;

	private final String DATE_DEFAULT = "1971-1-1 00:00:00";

	/**
	 * 28/10/2016 insert attendMeetingJournalist
	 * 
	 * @param attendMeetingJournalist
	 * @return int
	 */
	@Override
	@SuppressWarnings("unchecked")
	public AttendMeetingJournalist insert(AttendMeetingJournalist attendMeetingJournalist) {
		//kiem tra nha bao da vao cuoc hoc do chua
		String sql = "FROM AttendMeetingJournalist WHERE serialNumber = '" + attendMeetingJournalist.getSerialNumber() + "' AND meetingId = "+attendMeetingJournalist.getMeetingId();
		List<AttendMeetingJournalist> attendMeetingJournalists = (List<AttendMeetingJournalist>) CommonFunction.INSTANCE.getByQuery(sql);
		if (attendMeetingJournalists != null) {
			if (attendMeetingJournalists.size() > 0) {
				String note = attendMeetingJournalist.getNote();
				attendMeetingJournalist = attendMeetingJournalists.get(0);
				attendMeetingJournalist.setNote(note);
				HibernateUtil.updateObject(attendMeetingJournalist);
				return attendMeetingJournalist;
			}
		}
		MeetingController.Instance.increasePersonAttend(attendMeetingJournalist.getMeetingId(),
				Constant.JOURNALIST);
		return HibernateUtil.insertObject(attendMeetingJournalist);
	}

	/**
	 * 28/10/2016 checkout journalist 1: chua ton tai 2: update thoi gian ve
	 * 
	 * @param serialNumber
	 * @param date
	 * @return
	 */
	public NumberObj checkoutJournalist(String serialNumber, Date date) {
		Session session = HibernateUtil.getSession();
		NumberObj result = new NumberObj();
		result.setValue(0);
		long count = 0;
		Calendar calendar = Calendar.getInstance();
		calendar.setTime(date);
		calendar.add(Calendar.DAY_OF_MONTH, 1);
		Date nextDate = calendar.getTime();
		SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd 00:00");

		// kiem tra den cuoi ngay hom do
		SimpleDateFormat sdf1 = new SimpleDateFormat("yyyy-MM-dd 00:00");
		try {
			session.getTransaction().begin();

			String strQuery = "SELECT COUNT(*) FROM AttendMeetingJournalist WHERE serialnumber = :serialnumber AND inputtime BETWEEN '"
					+ sdf.format(date) + "' and '" + sdf1.format(nextDate) + "'";
			Query query = session.createQuery(strQuery);
			query.setParameter("serialnumber", serialNumber);
			count = (long) query.uniqueResult();

			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}
		if (count == 0) {
			// nha bao chua tham du
			result.setValue(NOT_EXIST_SERIALNUMBER);
			return result;
		} else {
			// set lai gia tri de tiep tuc dung de kiem tra
			count = 0;
			session = HibernateUtil.getSession();
			try {
				// kiem tra de update thoi gian ra cho nha bao
				session.getTransaction().begin();
				String strQuery = "SELECT COUNT(*) FROM AttendMeetingJournalist WHERE serialnumber = :serialnumber "
						+ "AND outputTime = :outtime " + "AND inputtime BETWEEN '" + sdf.format(date) + "' and '"
						+ sdf1.format(nextDate) + "'";
				Query query = session.createQuery(strQuery);
				query.setParameter("serialnumber", serialNumber);
				query.setString("outtime", DATE_DEFAULT);

				count = (long) query.uniqueResult();

				session.getTransaction().commit();
				if (count == 0) {
					// khong co de update
					result.setValue(NOT_EXIST_SERIALNUMBER);
				} else {
					// trong truong hop nay, update thoi gian ra ve luon
					result.setValue(UPDATE_SERIALNUMBER);
					updateOutputTimeJournalist(serialNumber, new Date());
				}
				return result;
			} catch (HibernateException e) {
				session.getTransaction().rollback();
				e.printStackTrace();
			} finally {
				session.flush();
				session.clear();
				session.close();
			}
		}
		return result;
	}

	/**
	 * 28/10/2016 update output time journalist
	 * 
	 * @param serialNumber
	 * @param date
	 * @return
	 */
	public int updateOutputTimeJournalist(String serialNumber, Date date) {
		int result = -1;
		Session session = HibernateUtil.getSession();
		try {
			session.getTransaction().begin();

			String strQuery = "UPDATE AttendMeetingJournalist SET outputTime = :outtime  WHERE serialNumber = :serialNumber "
					+ "AND outputTime = :defaultdate ";
			Query query = session.createQuery(strQuery);
			query.setParameter("serialNumber", serialNumber);
			query.setParameter("outtime", date);
			query.setString("defaultdate", DATE_DEFAULT);
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
	@SuppressWarnings("unchecked")
	public JournalistAttendStatisticObj statisticJourlistAttend(int start, int limit, Date fromDate, Date toDate,
			long organizationMeetingId, String meetingName) {
		Session session = HibernateUtil.getSession();

		JournalistAttendStatisticObj result = null;
		try {
			session.getTransaction().begin();
			Calendar c = Calendar.getInstance();
			c.setTime(toDate);
			c.add(Calendar.DATE, 1);
			toDate = c.getTime();
			SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");

			Query query = null;

			if (organizationMeetingId == -1) {
				// lay tat ca cac to chuc
				query = session.getNamedQuery("statisticJournalistAttendAll");
			} else {

				if ("all".equalsIgnoreCase(meetingName)) {
					// de duoi database LIKE lay tat ca cac cuoc hop cua to chuc
					meetingName = "";
				}
				query = session.getNamedQuery("statisticJournalistAttend");
			}

			query.setInteger("start", start);
			query.setInteger("limit", limit);
			query.setString("fromDate", sdf.format(fromDate));
			query.setString("toDate", sdf.format(toDate));
			query.setLong("organizationMeetingId", organizationMeetingId);
			query.setString("meetingName", meetingName);

			List<JournalistAttendStatistic> personAttends = query.list();
			session.getTransaction().commit();

			if (personAttends.size() > 0) {
				result = new JournalistAttendStatisticObj();
				result.setJournalistAttendStatistics(personAttends);
				// set tong so luong de client phan trang
				result.setSum(sumStatisticJourlistAttend(fromDate, toDate, organizationMeetingId, meetingName));
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
	public long sumStatisticJourlistAttend(Date fromDate, Date toDate, long organizationMeetingId, String meetingName) {
		Session session = HibernateUtil.getSession();

		long result = 0;
		try {
			session.getTransaction().begin();

			SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd 00:00:00");
			String strQuery = "";
			if (organizationMeetingId == -1) {
				// lay tat ca cac to chuc
				strQuery = "CALL sumStatisticJournalistAttendAll(:fromdate,:todate,:organizationMeetingId,:meetingname)";
			} else {
				if ("all".equalsIgnoreCase(meetingName)) {
					// de duoi database LIKE lay tat ca cac cuoc hop cua to chuc
					meetingName = "";
				}
				strQuery = "CALL sumStatisticJournalistAttend(:fromdate,:todate,:organizationMeetingId,:meetingname)";
			}
			Query query = session.createSQLQuery(strQuery);
			query.setString("fromdate", sdf.format(fromDate));
			query.setString("todate", sdf.format(toDate));
			query.setLong("organizationMeetingId", organizationMeetingId);
			query.setString("meetingname", meetingName);

			result = query.list().size();

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
	@SuppressWarnings("unchecked")
	public JournalistAttendStatisticDetailObj statisticJournalistAttendDetailByMeetingId(int start, int limit,
			long meetingId) {
		Session session = HibernateUtil.getSession();

		JournalistAttendStatisticDetailObj result = null;
		List<JournalistAttendStatisticDetail> journalistAttendDetails = null;
		try {
			session.getTransaction().begin();

			Query query = null;
			query = session.getNamedQuery("statisticJournalistAttendDetailByMeetingId");
			query.setInteger("start", start);
			query.setInteger("limit", limit);
			query.setLong("meetingid", meetingId);

			journalistAttendDetails = query.list();
			session.getTransaction().commit();

		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}
		result = new JournalistAttendStatisticDetailObj();
		if (journalistAttendDetails != null) {
			if (journalistAttendDetails.size() > 0) {
				result.setAttendStatisticDetails(journalistAttendDetails);
				result.setSum(sumStatisticJournalistAttendDetailByMeetingId(meetingId));
			}
		}
		return result;
	}

	@Override
	@SuppressWarnings("unchecked")
	public JournalistAttendStatisticDetailObj statisticJournalistAttendDetail(int start, int limit, Date paraFromDate,
			Date paraToDate, long organizationMeetingId, long meetingId) {
		Session session = HibernateUtil.getSession();
		JournalistAttendStatisticDetailObj result = null;
		List<JournalistAttendStatisticDetail> personAttendDetails = null;
		try {
			session.getTransaction().begin();

			Calendar c = Calendar.getInstance();
			c.setTime(paraToDate);
			c.add(Calendar.DATE, 1);
			paraToDate = c.getTime();
			SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");

			Query query = session.getNamedQuery("statisticJournalistAttendDetailByOrgIdAndMeetingId");
			query.setInteger("start", start);
			query.setInteger("limit", limit);
			query.setString("fromdate", sdf.format(paraFromDate));
			query.setString("todate", sdf.format(paraToDate));
			query.setLong("organizationmeetingid", organizationMeetingId);
			query.setLong("meetingid", meetingId);

			personAttendDetails = query.list();
			session.getTransaction().commit();

		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}
		result = new JournalistAttendStatisticDetailObj();

		if (personAttendDetails != null) {
			if (personAttendDetails.size() > 0) {
				result.setAttendStatisticDetails(personAttendDetails);
				result.setSum(
						sumStatisticJournalistAttendDetail(paraFromDate, paraToDate, organizationMeetingId, meetingId));
			}
		}
		return result;
	}

	@Override
	// chua dung den 
	public long sumStatisticJournalistAttendDetailByMeetingId(long meetingId) {
		return 0;
	}

	@Override
	public long sumStatisticJournalistAttendDetail(Date paraFromDate, Date paraToDate, long organizationMeetingId,
			long meetingId) {
		Session session = HibernateUtil.getSession();
		long result = 0;
		try {
			session.getTransaction().begin();

			SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");

			String strQuery = "";
			strQuery = "CALL sumStatisticJournalistAttendDetailByOrgIdAndMeetingId(:fromdate, :todate, :organizationmeetingid, :parameetingid)";
			Query query = session.createSQLQuery(strQuery);
			query.setString("fromdate", sdf.format(paraFromDate));
			query.setString("todate", sdf.format(paraToDate));
			query.setLong("organizationmeetingid", organizationMeetingId);
			query.setLong("parameetingid", meetingId);

			result = Long.valueOf(query.uniqueResult().toString());
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
	@SuppressWarnings("unchecked")
	public JournalistAttendStatisticDetailObj statisticJournalistAttendDetail(int start, int limit, Date paraFromDate,
			Date paraToDate, long organizationMeetingId, String meetingName) {
		Session session = HibernateUtil.getSession();

		JournalistAttendStatisticDetailObj result = null;
		List<JournalistAttendStatisticDetail> personAttendDetails = null;
		try {
			session.getTransaction().begin();
			Calendar c = Calendar.getInstance();
			c.setTime(paraToDate);
			c.add(Calendar.DATE, 1);
			paraToDate = c.getTime();
			SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");

			Query query = null;
			if (organizationMeetingId == -1) {
				// lay tat ca cac to chuc
				query = session.getNamedQuery("statisticJournalistAttendDetailAll");
			} else {
				if ("all".equalsIgnoreCase(meetingName)) {
					// lay tat ca cac cuoc hop cua to chuc
					meetingName = "";
				}
				query = session.getNamedQuery("statisticJournalistAttendDetail");
			}

			query.setInteger("start", start);
			query.setInteger("limit", limit);
			query.setString("fromDate", sdf.format(paraFromDate));
			query.setString("toDate", sdf.format(paraToDate));
			query.setLong("organizationMeetingId", organizationMeetingId);
			query.setString("meetingName", meetingName);

			personAttendDetails = query.list();
			session.getTransaction().commit();

		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}
		result = new JournalistAttendStatisticDetailObj();

		if (personAttendDetails != null) {
			if (personAttendDetails.size() > 0) {
				result.setAttendStatisticDetails(personAttendDetails);
				if (organizationMeetingId == -1) {
					// set tong so luong de client phan trang
					result.setSum(sumStatisticJournalistAttendDetailAll(paraFromDate, paraToDate, organizationMeetingId,
							meetingName));
				} else {
					// set tong so luong de client phan trang
					result.setSum(sumStatisticJournalistAttendDetail(paraFromDate, paraToDate, organizationMeetingId,
							meetingName));
				}
			}
		}
		return result;
	}

	@Override
	public long sumStatisticJournalistAttendDetail(Date fromDate, Date toDate, long organizationMeetingId,
			String meetingName) {
		Session session = HibernateUtil.getSession();
		long result = 0;
		try {
			session.getTransaction().begin();

			SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");

			String strQuery = "";
			strQuery = "CALL sumStatisticJournalistAttendDetail(:fromDate, :toDate, :organizationMeetingId, :meetingName)";
			Query query = session.createSQLQuery(strQuery);
			query.setString("fromDate", sdf.format(fromDate));
			query.setString("toDate", sdf.format(toDate));
			query.setLong("organizationMeetingId", organizationMeetingId);
			query.setString("meetingName", meetingName);

			result = Long.valueOf(query.uniqueResult().toString());
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
	public long sumStatisticJournalistAttendDetailAll(Date fromDate, Date toDate, long organizationMeetingId,
			String meetingName) {
		Session session = HibernateUtil.getSession();
		long result = 0;
		try {
			session.getTransaction().begin();

			SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");

			String strQuery = "";
			strQuery = "CALL sumStatisticJournalistAttendDetailAll(:fromDate, :toDate, :organizationMeetingId, :meetingName)";
			Query query = session.createSQLQuery(strQuery);
			query.setString("fromDate", sdf.format(fromDate));
			query.setString("toDate", sdf.format(toDate));
			query.setLong("organizationMeetingId", organizationMeetingId);
			query.setString("meetingName", meetingName);

			result = Long.valueOf(query.uniqueResult().toString());
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
	@SuppressWarnings("unchecked")
	public AttendMeetingJournalist checkJournalistIsSaveByMeetingIdAndSerialNumber(String serialnumber,
			long meetingId) {
		String sql = "FROM AttendMeetingJournalist WHERE serialNumber = '" + serialnumber + "' " + " AND meetingId = "
				+ meetingId;
		List<AttendMeetingJournalist> attendMeetingJournalists = (List<AttendMeetingJournalist>) CommonFunction.INSTANCE
				.getByQuery(sql);
		if (attendMeetingJournalists != null) {
			if (attendMeetingJournalists.size() > 0) {
				return attendMeetingJournalists.get(0);
			}
		}

		return null;
	}

}
