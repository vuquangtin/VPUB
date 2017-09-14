package com.swt.meeting.impls;

import java.util.List;

import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;

import com.nhn.utilities.HibernateUtil;
import com.swt.meeting.IDetailInfo;
import com.swt.meeting.customObject.DetailInfo;
import com.swt.meeting.customObject.DetailInfoOnlyPerson;
import com.swt.meeting.customObject.DetailInfoOrgOther;
import com.swt.meeting.customObject.NumberObj;
import com.swt.meeting.domain.Meeting;
import com.swt.meeting.domain.MeetingInvitationOrgOther;
import com.swt.meeting.domain.Partaker;

/**
 * version 2
 */
public class DetailInfoBarcodeDAO implements IDetailInfo {
	private final int NOT_EXIST_BARCODE = 1;
	private final int UPDATE_BARCODE = 2;
	private final int ALREADY_EXIST_BARCODE = 3;
	private final int BARCODE_ORG_OTHER = 4;

	private final String DATE_DEFAULT = "1971-1-1 00:00:00";

	@Override
	public DetailInfo getDetailInfoPartakerAttend(String barcode) {
		Session session = HibernateUtil.getSession();

		DetailInfo result = null;
		try {
			session.getTransaction().begin();

			Query query = session.getNamedQuery("getDetailInfoPerson");

			query.setString("barcode", barcode);

			DetailInfoOnlyPerson detailInfoOnlyPerson = (DetailInfoOnlyPerson) query.uniqueResult();
			session.getTransaction().commit();

			if (detailInfoOnlyPerson != null) {
				result = new DetailInfo();
				result.setDetailInfoOnlyPerson(detailInfoOnlyPerson);
				// danh sach nguoi duoc moi trong barcode
				List<Partaker> partakers = PartakerController.Instance
						.getPartakerByMeetingId(detailInfoOnlyPerson.getMeetingId());
				result.setPartakers(partakers);
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
	public NumberObj checkBarcode(String barcode) {
		NumberObj result = new NumberObj();
		result.setValue(0);
		// kiem tra barcode co phai la moi to chuc ben ngoai va duoc them tu
		// service LCT
		if (OrganizationMeetingController.Instance.getOrgOtherByBarcode(barcode) != null) {
			result.setValue(BARCODE_ORG_OTHER);
			return result;
		}
		// check barcode co trong danh sach thu moi khong
		// so luong barcode trong meeting invitation
		long count = checkedBarcodeInMeetingInvitation(barcode);
		if (count == 0) {
			// barcode khong ton tai
			result.setValue(NOT_EXIST_BARCODE);
		} else {
			// dem so luong theo barcode trong attendmeeting
			count = checkedBarcodeInAttendMeeting(barcode);
			if (count == 0) {
				// barcode chua su dung
				result.setValue(UPDATE_BARCODE);
			} else {
				// barcode da duoc su dung
				result.setValue(ALREADY_EXIST_BARCODE);
			}
		}
		return result;
	}

	// dem so luong barcode trong attend meeting
	public long checkedBarcodeInAttendMeeting(String barcode) {
		Session session = HibernateUtil.getSession();
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
		return count;
	}

	// dem so luong barcode trong attend meeting va ngay ra == default date

	public long checkedBarcodeInAttendMeetingAndOutTimeEqualDefaultDate(String barcode) {
		Session session = HibernateUtil.getSession();
		long count = 0;
		try {
			session.getTransaction().begin();
			String strQuery = "SELECT COUNT(*) FROM AttendMeeting WHERE meetingBarcode = :barcode AND outputTime = :outtime";
			Query query = session.createQuery(strQuery);
			query.setParameter("barcode", barcode);
			query.setString("outtime", DATE_DEFAULT);

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
		return count;
	}

	// check barcode co trong danh sach thu moi khong
	public long checkedBarcodeInMeetingInvitation(String barcode) {
		Session session = HibernateUtil.getSession();
		long count = 0;
		try {
			session.getTransaction().begin();
			String strQuery = "SELECT COUNT(*) FROM MeetingInvitation WHERE meetingbarcode = :barcode ";
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
		return count;
	}

	@Override
	public DetailInfoOrgOther getDetailInfoOrgOther(String barcode) {
		// get org other
		MeetingInvitationOrgOther invitationOrgOther = OrganizationMeetingController.Instance
				.getOrgOtherByBarcode(barcode);
		if (invitationOrgOther == null) {
			return null;
		}

		// get meeting
		Meeting meeting = MeetingController.Instance.getMeetingById(invitationOrgOther.getMeetingId());
		if (meeting == null) {
			return null;
		}
		// day du lieu vao doi tuong tra ve
		DetailInfoOrgOther result = new DetailInfoOrgOther();
		result.setMeetingId(meeting.getId());
		result.setMeetingname(meeting.getName());
		result.setNote(meeting.getNote());
		result.setStartTime(meeting.getStartTime());
		result.setOrganizationMeetingId(meeting.getOrganizationMeetingId());
		result.setOrganizationMeetingName(meeting.getOrganizationMeetingName());
		result.setOrganizationAttendId(invitationOrgOther.getOrgId());
		result.setOrganizationAttendName(invitationOrgOther.getOrgName());
		result.setOrganizationAttendCode(invitationOrgOther.getOrgCode());

		return result;
	}

}
/**
 * version 2
 */
