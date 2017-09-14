package com.swt.nonresident.impls;

import java.util.List;

import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;

import com.nhn.utilities.HibernateUtil;
import com.swt.nonresident.IPartaker;
import com.swt.nonresident.domain.NonResidentPartaker;

public class PartakerDAO implements IPartaker {
	/**
	 * 16/12/2016 lay danh sach nguoi tham du cua cuoc hop da duoc moi truoc
	 * service nay giong ben cuc Smeeting  IPartaker
	 * @return
	 */
	@SuppressWarnings("unchecked")
	@Override
	public List<NonResidentPartaker> getPartakerByMeetingId(long meetingId) {
		Session session = HibernateUtil.getSession();

		List<NonResidentPartaker> result = null;
		try {
			session.getTransaction().begin();

			Query query = session.getNamedQuery("getPartakerByMeetingId");
			query.setLong("meetingid", meetingId);

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

}
