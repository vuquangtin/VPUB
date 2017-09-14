package com.swt.meeting.impls;

import java.math.BigInteger;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;

import com.nhn.utilities.HibernateUtil;
import com.swt.meeting.IAttendMeeting;
import com.swt.meeting.customObject.NumberObj;
import com.swt.meeting.customObject.PersonAttend;
import com.swt.meeting.customObject.PersonAttendDetail;
import com.swt.meeting.customObject.PersonAttendDetailObj;
import com.swt.meeting.customObject.PersonAttendObj;
import com.swt.meeting.domain.AttendMeeting;
import com.swt.meeting.domain.Meeting;
import com.swt.meeting.domain.NonResident;
import com.swt.meeting.domain.PersonNotBarcode;
import com.swt.meeting.lib.tm.CommonFunction;
import com.swt.meeting.lib.tm.Constant;
import com.swt.meeting.lib.tm.TMCondition;

public class AttendMeetingDAO implements IAttendMeeting {
	private final int NOT_EXIST_BARCODE = 1;
	private final int UPDATE_BARCODE = 2;
	private final int ALREADY_EXIST_BARCODE = 3;

	@Override
	@SuppressWarnings("unchecked")
	public AttendMeeting insert(AttendMeeting attendMeeting) {
		// kiem tra barcode da ton tai chua
		String sql = "FROM AttendMeeting WHERE meetingBarcode = '" + attendMeeting.getMeetingBarcode() + "'";
		List<AttendMeeting> attendMeetings = (List<AttendMeeting>) CommonFunction.INSTANCE.getByQuery(sql);
		if (attendMeetings != null) {
			if (attendMeetings.size() > 0) {
				String note = attendMeeting.getNote();
				attendMeeting = attendMeetings.get(0);
				// neu chua vao lan nao => chuyen status = true, tang so luong
				// vao len 1
				if (!attendMeeting.isStatus()) {
					attendMeeting.setInputTime(new Date());
					attendMeeting.setStatus(true);
					MeetingController.Instance.increasePersonAttend(attendMeeting.getMeetingId(),
							Constant.PERSON_ATTEND_INVITED);
				}
				attendMeeting.setNote(note);
				HibernateUtil.updateObject(attendMeeting);
				return attendMeeting;
			}
		}
		return HibernateUtil.insertObject(attendMeeting);
	}

	@Override
	public int delete(long attendMeetingId) {
		AttendMeeting attendMeeting = new AttendMeeting();
		return HibernateUtil.deleteById(attendMeeting, attendMeetingId);
	}

	@Override
	public AttendMeeting getAttendMeetingById(long attendMeetingId) {
		Session session = HibernateUtil.getSession();

		AttendMeeting result = new AttendMeeting();
		try {
			session.getTransaction().begin();
			String strQuery = "FROM AttendMeeting WHERE id = :confid";
			Query query = session.createQuery(strQuery);
			query.setParameter("confid", attendMeetingId);

			result = (AttendMeeting) query.uniqueResult();

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
	 * isExistBarcode
	 * 
	 * 1: chua ton tai 2: update thoi gian ve 3: barcode da duoc dung duoc nua
	 * 
	 * @param barcode
	 * @return list attend meeting
	 */

	@Override
	public NumberObj isExistBarcode(String barcode) {
		Session session = HibernateUtil.getSession();
		NumberObj result = new NumberObj();
		result.setValue(0);
		long count = 0;
		try {
			// dem so luong theo barcode . De kiem tra the do da duoc dung chua?
			session.getTransaction().begin();
			String strQuery = "SELECT COUNT(*) FROM AttendMeeting WHERE meetingBarcode = :barcode";
			Query query = session.createQuery(strQuery);
			query.setParameter("barcode", barcode);

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
		// neu so luong == 0 => barcode chua duoc dung
		if (count == 0) {
			result.setValue(NOT_EXIST_BARCODE);
			return result;
		} else {
			session = HibernateUtil.getSession();
			try {
				// dem so luong theo barcode va thoi gian ra co bang thoi gian
				// mac dinh luc cho vao
				session.getTransaction().begin();
				String strQuery = "SELECT COUNT(*) FROM AttendMeeting WHERE meetingBarcode = :barcode AND outputTime = :outtime";
				Query query = session.createQuery(strQuery);
				query.setParameter("barcode", barcode);
				query.setString("outtime", Constant.DATE_DEFAULT);

				count = (long) query.uniqueResult();

				session.getTransaction().commit();
				if (count == 0) {
					// barcode da duoc dung
					result.setValue(ALREADY_EXIST_BARCODE);
				} else {
					// update thoi gian ra ve luon
					result.setValue(UPDATE_BARCODE);
					update(barcode, new Date());
				}
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
	 * update outputTime theo barcode
	 * 
	 * @param barcode
	 * @param date
	 * @return list attend meeting
	 */
	@Override
	public int update(String barcode, Date date) {
		int result = -1;
		Session session = HibernateUtil.getSession();
		try {
			session.getTransaction().begin();

			String strQuery = "UPDATE AttendMeeting SET outputTime = :outtime  WHERE meetingBarcode = :barcode ";
			Query query = session.createQuery(strQuery);
			query.setParameter("barcode", barcode);
			query.setParameter("outtime", date);
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
	 * ======================thong ke nguoi di hop
	 * moi===============================
	 */

	/**
	 * thong ke cuoc hop , so luong cac thanh phan tham du (nguoi duoc moi,
	 * nguoi duoc them vao, nha bao,..)
	 * 
	 * @param start
	 * @param limit
	 * @param fromDate
	 * @param toDate
	 * @param organizationMeetingId
	 * @param meetingName
	 * 
	 * @return PersonAttendObj
	 */
	@SuppressWarnings("unchecked")
	@Override
	public PersonAttendObj statisticPersonAttend(int start, int limit, Date fromDate, Date toDate,
			long organizationMeetingId, String meetingName) {
		Session session = HibernateUtil.getSession();

		PersonAttendObj result = null;
		List<PersonAttend> personAttends = null;
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
				query = session.getNamedQuery("statisticPersonAttendAll");
			} else {

				if ("all".equalsIgnoreCase(meetingName)) {
					// de duoi database LIKE lay tat ca cac cuoc hop cua to chuc
					meetingName = "";
				}
				query = session.getNamedQuery("statisticPersonAttend");
			}

			query.setInteger("start", start);
			query.setInteger("limit", limit);
			query.setString("fromDate", sdf.format(fromDate));
			query.setString("toDate", sdf.format(toDate));
			query.setLong("organizationMeetingId", organizationMeetingId);
			query.setString("meetingName", meetingName);

			personAttends = query.list();
			session.getTransaction().commit();

		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.clear();
			session.close();
		}
		if (personAttends != null) {
			if (personAttends.size() > 0) {
				// // set so luong khach vang lai
				// for (PersonAttend personAttend : personAttends) {
				// BigInteger meetingId = personAttend.getMeetingId();
				// // lay danh sach khach vang lai theo meeting id
				// personAttend.setNumberNonresident(sumNumberNonresident(meetingId));
				// }
				result = new PersonAttendObj();
				result.setPersonAttends(personAttends);
				// set tong so luong de client phan trang
				result.setSum(sumStatisticPersonAttend(fromDate, toDate, organizationMeetingId, meetingName));
			}
		}
		return result;
	}

	// Duoc dung trong ham statisticPersonAttend
	@Override
	public long sumStatisticPersonAttend(Date fromDate, Date toDate, long organizationMeetingId, String meetingName) {
		Session session = HibernateUtil.getSession();

		long result = 0;
		try {
			session.getTransaction().begin();

			SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd 00:00:00");
			String strQuery = "";
			if (organizationMeetingId == -1) {
				// lay tat ca cac to chuc
				strQuery = "CALL sumStatisticPersonAttendAll(:fromdate,:todate,:organizationMeetingId,:meetingname)";
			} else {
				if ("all".equalsIgnoreCase(meetingName)) {
					// de duoi database LIKE lay tat ca cac cuoc hop cua to chuc
					meetingName = "";
				}
				strQuery = "CALL sumStatisticPersonAttend(:fromdate,:todate,:organizationMeetingId,:meetingname)";
			}
			Query query = session.createSQLQuery(strQuery);
			query.setString("fromdate", sdf.format(fromDate));
			query.setString("todate", sdf.format(toDate));
			query.setLong("organizationMeetingId", organizationMeetingId);
			query.setString("meetingname", meetingName);

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

	/**
	 * thong ke chi tiet mot cuoc hop
	 * 
	 * @param start
	 * @param limit
	 * @param meetingId
	 * 
	 * @return PersonAttendDetailObj
	 */
	@SuppressWarnings("unchecked")
	@Override
	public PersonAttendDetailObj statisticPersonAttendDetailByMeetingId(int start, int limit, long meetingId) {
		Session session = HibernateUtil.getSession();
		Meeting meeting = MeetingController.Instance.getMeetingById(meetingId);
		PersonAttendDetailObj result = null;
		List<PersonAttendDetail> personAttendDetails = null;
		try {
			session.getTransaction().begin();

			Query query = null;
			query = session.getNamedQuery("statisticPersonAttendDetailByMeetingId");
			query.setInteger("start", start);
			query.setInteger("limit", limit);
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
		result = new PersonAttendDetailObj();

		if (personAttendDetails != null) {
			if (personAttendDetails.size() > 0) {
				CommonFunction.INSTANCE.setTable(new PersonNotBarcode());
				for (PersonAttendDetail personAttendDetail : personAttendDetails) {
					// neu la nguoi duoc them vao thi phai dien them thong tin
					if (personAttendDetail.isAdd()) {
						if (personAttendDetail.getPersonNotBarcodeId() != 0) {
							PersonNotBarcode personNotBarcode = (PersonNotBarcode) CommonFunction.INSTANCE
									.getById(personAttendDetail.getPersonNotBarcodeId());
							if (personNotBarcode != null) {
								personAttendDetail.setPartakerName(personNotBarcode.getName());
								personAttendDetail.setPartakerPosition(personNotBarcode.getPosition());
								personAttendDetail.setOrganizationAttendName(personNotBarcode.getOrgName());
								personAttendDetail.setIdentityCard(personNotBarcode.getIdentityCard());
								personAttendDetail.setPhonenumber(personNotBarcode.getPhonenumber());
							}
						}
					}

				}
				result.setPersonAttendDetails(personAttendDetails);
			}
		} else {
			result.setPersonAttendDetails(new ArrayList<PersonAttendDetail>());
		}

		long range = start + limit;

		// 13/04/2017 tinh cong kieu cu
		// long sumPersonAttendDeatail =
		// sumStatisticPersonAttendDetailByMeetingId(meetingId);

		long sumPersonAttendDeatail = meeting.getNumberPeopleAttendInvited() + meeting.getNumberPeopleAdded()
				+ meeting.getNumberJournalist();

		List<NonResident> nonResidents = null;
		if (sumPersonAttendDeatail < range) {
			if (range - sumPersonAttendDeatail <= limit) {
				nonResidents = sumNonresidentDetailLimit(meetingId, 0, range - sumPersonAttendDeatail);
			} else {
				long begin = (range - sumPersonAttendDeatail) - limit;
				nonResidents = sumNonresidentDetailLimit(meetingId, begin, limit);
			}
			result.setNonresidentDetails(nonResidents);
		}
		// long sum = (sumPersonAttendDeatail +
		// sumNonresidentDetail(meetingId).size());
		// // set tong so luong de phan trang
		result.setSum(0);
		return result;
	}

	// Duoc dung trong ham statisticPersonAttendDetailByMeetingId
	@Override
	public long sumStatisticPersonAttendDetailByMeetingId(long meetingId) {
		Session session = HibernateUtil.getSession();
		long result = 0;
		try {
			session.getTransaction().begin();

			String strQuery = "";
			strQuery = "CALL sumStatisticPersonAttendDetailByMeetingId(:parameetingid)";
			Query query = session.createSQLQuery(strQuery);
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

	/**
	 * Thong ke chi tiet nhung nguoi tham du cuoc hop theo ma don vi to chuc va
	 * ten cuoc hop
	 * 
	 * @param start
	 * @param limit
	 * @param fromDate
	 * @param toDate
	 * @param organizationMeetingId,
	 * @param meetingName
	 * 
	 * @return PersonAttendDetailObj
	 */
	@SuppressWarnings("unchecked")
	@Override
	public PersonAttendDetailObj statisticPersonAttendDetail(int start, int limit, Date fromDate, Date toDate,
			long organizationMeetingId, String meetingName) {
		Session session = HibernateUtil.getSession();

		PersonAttendDetailObj result = null;
		List<PersonAttendDetail> personAttendDetails = null;
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
				query = session.getNamedQuery("statisticPersonAttendDetailAll");
			} else {
				if ("all".equalsIgnoreCase(meetingName)) {
					// lay tat ca cac cuoc hop cua to chuc
					meetingName = "";
				}
				query = session.getNamedQuery("statisticPersonAttendDetail");
			}

			query.setInteger("start", start);
			query.setInteger("limit", limit);
			query.setString("fromDate", sdf.format(fromDate));
			query.setString("toDate", sdf.format(toDate));
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
		result = new PersonAttendDetailObj();

		if (personAttendDetails != null) {
			if (personAttendDetails.size() > 0) {
				CommonFunction.INSTANCE.setTable(new PersonNotBarcode());
				for (PersonAttendDetail personAttendDetail : personAttendDetails) {
					// neu la nguoi duoc them vao thi phai dien them thong tin
					if (personAttendDetail.isAdd()) {
						PersonNotBarcode personNotBarcode = (PersonNotBarcode) CommonFunction.INSTANCE
								.getById(personAttendDetail.getPersonNotBarcodeId());
						if (personNotBarcode != null) {
							personAttendDetail.setPartakerName(personNotBarcode.getName());
							personAttendDetail.setOrganizationAttendName(personNotBarcode.getOrgName());
							personAttendDetail.setIdentityCard(personNotBarcode.getIdentityCard());
							personAttendDetail.setPhonenumber(personNotBarcode.getPhonenumber());
						}
					}
				}
				result.setPersonAttendDetails(personAttendDetails);
			}
		} else {
			result.setPersonAttendDetails(new ArrayList<PersonAttendDetail>());
		}

		long range = start + limit;

		if ("all".equalsIgnoreCase(meetingName)) {
			meetingName = "";
		}
		meetingName = "%" + meetingName + "%";
		long sumPersonAttendDeatail = 0;
		// them %% de thoa dieu kien Like
		if (organizationMeetingId == -1) {
			// set tong so luong de client phan trang
			sumPersonAttendDeatail = sumStatisticPersonAttendDetailAll(fromDate, toDate, organizationMeetingId,
					meetingName);
		} else {
			// set tong so luong de client phan trang
			sumPersonAttendDeatail = sumStatisticPersonAttendDetail(fromDate, toDate, organizationMeetingId,
					meetingName);
		}

		List<NonResident> nonResidents = null;
		if (sumPersonAttendDeatail < range) {
			if (range - sumPersonAttendDeatail <= limit) {
				nonResidents = sumNonresidentDetailLimit(fromDate, toDate, organizationMeetingId, meetingName, 0,
						range - sumPersonAttendDeatail);
			} else {
				long begin = (range - sumPersonAttendDeatail) - limit;
				nonResidents = sumNonresidentDetailLimit(fromDate, toDate, organizationMeetingId, meetingName, begin,
						limit);
			}
			result.setNonresidentDetails(nonResidents);
		}
		long sum = (sumPersonAttendDeatail
				+ sumNonresidentDetail(fromDate, toDate, organizationMeetingId, meetingName).size());
		// set tong so luong de phan trang
		result.setSum(sum);
		return result;
	}

	// Duoc dung trong ham statisticPersonAttendDetail
	@Override
	public long sumStatisticPersonAttendDetail(Date fromDate, Date toDate, long organizationMeetingId,
			String meetingName) {
		Session session = HibernateUtil.getSession();
		long result = 0;
		try {
			session.getTransaction().begin();

			SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");

			String strQuery = "";
			strQuery = "CALL sumStatisticPersonAttendDetail(:fromDate, :toDate, :organizationMeetingId, :meetingName)";
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

	// Duoc dung trong ham statisticPersonAttendDetail
	@Override
	public long sumStatisticPersonAttendDetailAll(Date fromDate, Date toDate, long organizationMeetingId,
			String meetingName) {
		Session session = HibernateUtil.getSession();
		long result = 0;
		try {
			session.getTransaction().begin();

			SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd 00:00:00");

			String strQuery = "";
			strQuery = "CALL sumStatisticPersonAttendDetailAll(:fromDate, :toDate, :organizationMeetingId, :meetingName)";
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

	/**
	 * thong ke so luong nguoi tham du theo ma don vi to chuc
	 * 
	 * @param fromDate
	 * @param toDate
	 * @param organizationMeetingId
	 * 
	 * @return List<PersonAttend>
	 */
	@SuppressWarnings("unchecked")
	@Override
	public List<PersonAttend> statisticPersonAttend(Date fromDate, Date toDate, long organizationMeetingId) {
		Session session = HibernateUtil.getSession();
		List<PersonAttend> result = null;
		try {
			session.getTransaction().begin();
			Calendar c = Calendar.getInstance();
			c.setTime(toDate);
			c.add(Calendar.DATE, 1);
			toDate = c.getTime();
			SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");

			Query query = session.getNamedQuery("statisticPersonAttendNew");
			query.setString("fromDate", sdf.format(fromDate));
			query.setString("toDate", sdf.format(toDate));
			query.setLong("organizationMeetingId", organizationMeetingId);

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

	/**
	 * Thong ke chi tiet nguoi tham du hop theo ma don vi to chuc va ma cuoc hop
	 * 
	 * @param start
	 * @param limit
	 * @param fromDate
	 * @param toDate
	 * @param organizationMeetingId
	 * @param meetingId
	 * 
	 * @return PersonAttendDetailObj
	 */
	@SuppressWarnings("unchecked")
	@Override
	public PersonAttendDetailObj statisticPersonAttendDetail(int start, int limit, Date fromDate, Date toDate,
			long organizationMeetingId, long meetingId) {
		Session session = HibernateUtil.getSession();

		PersonAttendDetailObj result = null;
		List<PersonAttendDetail> personAttendDetails = null;
		try {
			session.getTransaction().begin();

			Calendar c = Calendar.getInstance();
			c.setTime(toDate);
			c.add(Calendar.DATE, 1);
			toDate = c.getTime();
			SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");

			Query query = session.getNamedQuery("statisticPersonAttendDetailByOrgIdAndMeetingId");
			query.setInteger("start", start);
			query.setInteger("limit", limit);
			query.setString("fromdate", sdf.format(fromDate));
			query.setString("todate", sdf.format(toDate));
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
		result = new PersonAttendDetailObj();
		if (personAttendDetails != null) {
			if (personAttendDetails.size() > 0) {
				CommonFunction.INSTANCE.setTable(new PersonNotBarcode());
				for (PersonAttendDetail personAttendDetail : personAttendDetails) {
					// neu la nguoi duoc them vao thi phai dien them thong tin
					if (personAttendDetail.isAdd()) {
						PersonNotBarcode personNotBarcode = (PersonNotBarcode) CommonFunction.INSTANCE
								.getById(personAttendDetail.getPersonNotBarcodeId());
						if (personNotBarcode != null) {
							personAttendDetail.setPartakerName(personNotBarcode.getName());
							personAttendDetail.setOrganizationAttendName(personNotBarcode.getOrgName());
							personAttendDetail.setIdentityCard(personNotBarcode.getIdentityCard());
							personAttendDetail.setPhonenumber(personNotBarcode.getPhonenumber());
						}
					}
				}
				result.setPersonAttendDetails(personAttendDetails);
			}
		} else {
			result.setPersonAttendDetails(new ArrayList<PersonAttendDetail>());
		}

		long range = start + limit;
		long sumPersonAttendDeatail = sumStatisticPersonAttendDetailByMeetingId(meetingId);

		List<NonResident> nonResidents = null;
		if (sumPersonAttendDeatail < range) {
			if (range - sumPersonAttendDeatail <= limit) {
				nonResidents = sumNonresidentDetailLimit(meetingId, 0, range - sumPersonAttendDeatail);
			} else {
				long begin = (range - sumPersonAttendDeatail) - limit;
				nonResidents = sumNonresidentDetailLimit(meetingId, begin, limit);
			}
			result.setNonresidentDetails(nonResidents);
		}
		long sum = (sumPersonAttendDeatail + sumNonresidentDetail(meetingId).size());
		// set tong so luong de phan trang
		result.setSum(sum);
		return result;
	}

	// Duoc dung trong ham PersonAttendDetailObj
	@Override
	public long sumStatisticPersonAttendDetailByOgranizationMeetingIdAndMeetingId(Date fromDate, Date toDate,
			long organizationMeetingId, long meetingId) {
		Session session = HibernateUtil.getSession();
		long result = 0;
		try {
			session.getTransaction().begin();

			SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");

			String strQuery = "";
			strQuery = "CALL sumStatisticPersonAttendDetailByOrgIdAndMeetingId(:fromdate, :todate, :organizationmeetingid, :parameetingid)";
			Query query = session.createSQLQuery(strQuery);
			query.setString("fromdate", sdf.format(fromDate));
			query.setString("todate", sdf.format(toDate));
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

	/*
	 * =====================================================
	 */
	@Override
	public boolean refreshBarcodeByMeetingId(long meetingId) {
		// xoa het cac barcode da cho vao
		String stringQuery = "DELETE FROM AttendMeeting WHERE meetingid = :meetingid";
		List<String> keys = new ArrayList<>();
		keys.add("meetingid");

		Map<String, Object> mapValue = new HashMap<String, Object>();
		mapValue.put("meetingid", "" + meetingId);
		long result = (long) CommonFunction.INSTANCE.getOnlyOneDataByProcedure(stringQuery, keys, mapValue, null, null);
		if (result > 0) {
			return true;
		} else {
			return false;
		}
	}

	@Override
	public boolean updateMeetingStartTime(long meetingId, Date date) {
		Session session = HibernateUtil.getSession();

		long result = 0;
		try {
			session.getTransaction().begin();

			SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");

			String strQuery = "UPDATE Meeting SET starttime = :starttime WHERE meetingid = :meetingid ";
			Query query = session.createQuery(strQuery);
			query.setString("starttime", sdf.format(date));
			query.setLong("meetingid", meetingId);

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

		if (result > 0) {
			return true;
		} else {
			return false;
		}
	}

	@Override
	public long sumNumberNonresident(BigInteger meetingId) {
		Session session = HibernateUtil.getSession();

		long result = 0;
		try {
			session.getTransaction().begin();
			String strQuery = "CALL countNonresidentMeeting(:meetingid)";
			Query query = session.createSQLQuery(strQuery);
			query.setParameter("meetingid", meetingId);

			result = Long.parseLong(((BigInteger) query.uniqueResult()).toString());
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
	public List<NonResident> sumNonresidentDetailLimit(long meetingId, long start, long limit) {
		List<TMCondition> conditions = new ArrayList<>();
		conditions.add(new TMCondition("eqnumberic", "meetingId", "" + meetingId));

		CommonFunction.INSTANCE.setTable(new NonResident());
		return (List<NonResident>) CommonFunction.INSTANCE.getByCriteriaLimit(conditions, start, limit);
	}

	@Override
	@SuppressWarnings("unchecked")
	public List<NonResident> sumNonresidentDetail(long meetingId) {
		List<TMCondition> conditions = new ArrayList<>();
		conditions.add(new TMCondition("eqnumberic", "meetingId", "" + meetingId));
		CommonFunction.INSTANCE.setTable(new NonResident());
		return (List<NonResident>) CommonFunction.INSTANCE.getByCriteria(conditions);
	}

	@Override
	@SuppressWarnings("unchecked")
	public List<NonResident> sumNonresidentDetail(Date fromDate, Date toDate, long organizationMeetingId,
			String meetingName) {
		Session session = HibernateUtil.getSession();

		List<NonResident> result = null;
		try {
			session.getTransaction().begin();

			Calendar c = Calendar.getInstance();
			c.setTime(toDate);
			c.add(Calendar.DATE, 1);
			toDate = c.getTime();

			SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd 00:00:00");

			String strQuery = "";
			Query query = null;
			if (organizationMeetingId == -1) {
				strQuery = "FROM NonResident "
						+ "WHERE meetingName like :meetingName AND inputTime BETWEEN :fromDate AND :toDate AND meetingId != -1";
				query = session.createQuery(strQuery);
			} else {

				strQuery = "FROM NonResident "
						+ "WHERE meetingName like :meetingName AND orgId = :orgId AND inputTime BETWEEN :fromDate AND :toDate AND meetingId != -1";
				query = session.createQuery(strQuery);
				query.setParameter("orgId", organizationMeetingId);
			}

			query.setParameter("meetingName", meetingName);
			query.setString("fromDate", sdf.format(fromDate));
			query.setString("toDate", sdf.format(toDate));
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
	@SuppressWarnings("unchecked")
	public List<NonResident> sumNonresidentDetailLimit(Date fromDate, Date toDate, long organizationMeetingId,
			String meetingName, long start, long limit) {
		Session session = HibernateUtil.getSession();

		List<NonResident> result = null;
		try {
			session.getTransaction().begin();

			SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd 00:00:00");

			String strQuery = "";
			Query query = null;
			if (organizationMeetingId == -1) {
				strQuery = "FROM NonResident "
						+ "WHERE meetingName like :meetingName AND inputTime BETWEEN :fromDate AND :toDate AND meetingId != -1";
				query = session.createQuery(strQuery);
			} else {

				strQuery = "FROM NonResident "
						+ "WHERE meetingName like :meetingName AND orgId = :orgId AND inputTime BETWEEN :fromDate AND :toDate AND meetingId != -1";
				query = session.createQuery(strQuery);
				query.setParameter("orgId", organizationMeetingId);
			}

			query.setParameter("meetingName", meetingName);
			query.setString("fromDate", sdf.format(fromDate));
			query.setString("toDate", sdf.format(toDate));
			query.setFirstResult((int) start);
			query.setMaxResults((int) limit);
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
	public NonResident insertNonresident(NonResident nonResident) {
		return HibernateUtil.insertObject(nonResident);
	}

	@Override
	public void deleteByPartakerId(long partakerId) {
		String sql = "DELETE FROM AttendMeeting WHERE partakerId = " + partakerId;
		CommonFunction.INSTANCE.executeUpdateBySqlQuery(sql);
	}

	@Override
	public boolean updateMeetingId(long meetingIdOld, long meetingIdNew) {
		int result = -1;
		Session session = HibernateUtil.getSession();
		try {
			session.getTransaction().begin();

			String strQuery = "UPDATE AttendMeeting " + "SET meetingId = :meetingIdNew "
					+ "WHERE meetingId = :meetingIdOld";
			Query query = session.createQuery(strQuery);
			query.setParameter("meetingIdOld", meetingIdOld);
			query.setParameter("meetingIdNew", meetingIdNew);
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
		if(result > 1){
			return true;
		}else{
			return false;
		}
	}

}
