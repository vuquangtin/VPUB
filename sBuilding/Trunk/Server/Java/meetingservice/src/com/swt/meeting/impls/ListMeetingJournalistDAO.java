package com.swt.meeting.impls;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.List;

import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;

import com.google.gson.Gson;
import com.nhn.utilities.HibernateUtil;
import com.swt.meeting.IListMeetingJournalist;
import com.swt.meeting.customObject.ListMeetingJournalistObj;
import com.swt.meeting.domain.ListMeetingJournalist;
import com.swt.meeting.domain.Meeting;
import com.swt.meeting.domain.OrganizationMeeting;
import com.swt.meeting.domain.Partaker;
import com.swt.meeting.lib.tm.CommonFunction;
import com.swt.sworld.ps.domain.Member;

public class ListMeetingJournalistDAO implements IListMeetingJournalist {

	@SuppressWarnings("unchecked")
	@Override
	public List<ListMeetingJournalist> getListMeetingJournalistBySerialNumer(String serialNumber) {
		Session session = HibernateUtil.getSession();

		List<ListMeetingJournalist> result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM ListMeetingJournalist WHERE serialNumber = :serialNumber";
			Query query = session.createQuery(strQuery);
			query.setParameter("serialNumber", serialNumber);
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
	 * danh sach cac cuoc hop ma nha bao duoc moi truoc bao nhieu phut
	 * 
	 * @param serialNumber
	 * @param dateTime
	 * @param previousMinutes
	 * 
	 * @return List<Meeting>
	 */
	@SuppressWarnings("unchecked")
	@Override
	public List<Meeting> getListMeetingJournalistInvited(String serialNumber, Date dateTime, int previousMinutes) {
		Session session = HibernateUtil.getSession();

		List<Meeting> result = null;
		try {
			session.getTransaction().begin();

			Calendar c = Calendar.getInstance();
			c.setTime(dateTime);
			c.add(Calendar.MINUTE, -previousMinutes);
			Date toDate = c.getTime();

			SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd HH:mm:00");

			String strQuery = "SELECT m " + "FROM ListMeetingJournalist lmj, Meeting m  "
					+ "WHERE m.id = lmj.meetingId AND serialNumber = :serialNumber AND m.startTime BETWEEN :toDate AND :fromDate";
			Query query = session.createQuery(strQuery);
			query.setParameter("serialNumber", serialNumber);
			query.setString("fromDate", sdf.format(dateTime));
			query.setString("toDate", sdf.format(toDate));

			result = query.list();
			session.getTransaction().commit();
			// Danh sach tat ca nhung nguoi tham du trong cuoc hop
			// them danh sach nguoi tham du cho nhung cuoc hop da co san
			for (Meeting meeting : result) {
				Gson gson = new Gson();
				if (meeting.getListNonResident() == null || meeting.getListNonResident().isEmpty()) {
					List<Partaker> sumPartaker = PartakerController.Instance.getPartakerByMeetingId(meeting.getId());
					meeting.setListNonResident(gson.toJson(sumPartaker));
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
	 * danh sach cac cuoc hop ma nha bao KHONG duoc moi truoc bao nhieu phut
	 * 
	 * @param serialNumber
	 * @param dateTime
	 * @param previousMinutes
	 * 
	 * @return List<Meeting>
	 */
	@SuppressWarnings("unchecked")
	@Override
	public List<Meeting> getListMeetingJournalistNotInvited(String serialNumber, Date dateTime, int previousMinutes) {
		Session session = HibernateUtil.getSession();

		List<Meeting> result = null;
		try {
			session.getTransaction().begin();

			Calendar c = Calendar.getInstance();
			c.setTime(dateTime);
			c.add(Calendar.MINUTE, -previousMinutes);
			Date toDate = c.getTime();

			SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd HH:mm:00");

			Query query = session.getNamedQuery("getListMeetingJournalistNotInvited");
			query.setString("paraSerialNumber", serialNumber);
			query.setString("fromdate", sdf.format(dateTime));
			query.setString("todate", sdf.format(toDate));

			result = query.list();
			session.getTransaction().commit();
			// Danh sach tat ca nhung nguoi tham du trong cuoc hop
			// them danh sach nguoi tham du cho nhung cuoc hop da co san
			for (Meeting meeting : result) {
				Gson gson = new Gson();
				if (meeting.getListNonResident() == null || meeting.getListNonResident().isEmpty()) {
					List<Partaker> sumPartaker = PartakerController.Instance.getPartakerByMeetingId(meeting.getId());
					meeting.setListNonResident(gson.toJson(sumPartaker));
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
	 * danh sach cac cuoc hop ma nha bao duoc moi tham du truoc bao nhieu phut
	 * 
	 * @param serialNumber
	 * @param dateTime
	 * @param previousMinutes
	 */
	@Override
	public ListMeetingJournalistObj getListMeetingJonalist(String serialNumber, Date dateTime, int previousMinutes) {
		ListMeetingJournalistObj listMeetingJournalistObj = new ListMeetingJournalistObj();
		Member journaList = JournaListController.Instance.getJournalistBySerial(serialNumber);
		listMeetingJournalistObj.setJournalist(journaList);
		return listMeetingJournalistObj;
	}

	@SuppressWarnings("unchecked")
	private List<Meeting> getListMeetingJournalistNotInvitedVer2(Date dateTime) {
		Calendar date = Calendar.getInstance();
		date.setTime(dateTime);
		date.add(Calendar.DAY_OF_MONTH, 1);
		Date nextDate = date.getTime();
		SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd 00:00");

		// kiem tra den cuoi ngay hom do
		SimpleDateFormat sdf1 = new SimpleDateFormat("yyyy-MM-dd 00:00");
		String strQuery = "FROM Meeting " + " WHERE StartTime BETWEEN '" + sdf.format(dateTime) + "' and '"
				+ sdf1.format(nextDate) + "'" + " AND meetingCodeStatus = TRUE " + " AND startTime != '"
				+ MeetingLCTDAO.DATE_DEFAULT + "' " + "ORDER BY StartTime asc";
		return (List<Meeting>) CommonFunction.INSTANCE.getByQuery(strQuery);
	}

	@Override
	public ListMeetingJournalistObj getListMeetingJonalist(String serialNumber, Date dateTime) {
		ListMeetingJournalistObj listMeetingJournalistObj = new ListMeetingJournalistObj();
		Member journaList = JournaListController.Instance.getJournalistBySerial(serialNumber);
		if (journaList != null) {

			listMeetingJournalistObj.setJournalist(journaList);
			List<OrganizationMeeting> organizationMeetings = OrganizationMeetingController.Instance
					.getOrganizationMeetingByReferenceId(journaList.getSubOrgId());
			if (organizationMeetings.size() > 0) {
				OrganizationMeeting organizationMeeting = organizationMeetings.get(0);
				listMeetingJournalistObj.setOrgId(organizationMeeting.getId());
				listMeetingJournalistObj.setOrgName(organizationMeeting.getName());
			} else {
				listMeetingJournalistObj.setOrgId(0);// set 0 thì khong hien thi
														// thong tin to chuc cua
														// nha bap
			}

			listMeetingJournalistObj.setMeetingInviteds(new ArrayList<Meeting>());

			listMeetingJournalistObj.setMeetingNotInviteds(getListMeetingJournalistNotInvitedVer2(dateTime));
		}
		return listMeetingJournalistObj;
	}

}
