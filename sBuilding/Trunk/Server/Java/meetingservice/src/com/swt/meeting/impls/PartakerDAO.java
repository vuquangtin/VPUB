/**
 * 
 */
package com.swt.meeting.impls;

import java.util.ArrayList;
import java.util.List;

import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;

import com.nhn.utilities.HibernateUtil;
import com.swt.meeting.IPartaker;
import com.swt.meeting.domain.Partaker;

/**
 * @author TaiMai
 *
 * 
 */
public class PartakerDAO implements IPartaker {

	/*
	 * @see com.swt.meeting.IPartaker#insert(com.swt.meeting.domain.Partaker)
	 */
	@Override
	public Partaker insert(Partaker partaker) {
		return HibernateUtil.insertObject(partaker);
	}

	/*
	 * @see com.swt.meeting.IPartaker#update(com.swt.meeting.domain.Partaker)
	 */
	@Override
	public Partaker update(Partaker partaker) {
		return HibernateUtil.updateObject(partaker);
	}

	/*
	 * @see com.swt.meeting.IPartaker#delete(long)
	 */
	@Override
	public int delete(long partakerId) {
		Partaker partaker = new Partaker();
		return HibernateUtil.deleteById(partaker, partakerId);
	}

	/*
	 * @see com.swt.meeting.IPartaker#getPartakerById(int)
	 */
	@Override
	public Partaker getPartakerById(long partakerId) {
		Session session = HibernateUtil.getSession();

		Partaker result = new Partaker();
		try {
			session.getTransaction().begin();
			String strQuery = "FROM Partaker WHERE id = :confid";
			Query query = session.createQuery(strQuery);
			query.setParameter("confid", partakerId);

			result = (Partaker) query.uniqueResult();

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
	 * @see com.swt.meeting.IPartaker#getAllPartaker()
	 */
	@SuppressWarnings("unchecked")
	@Override
	public List<Partaker> getAllPartaker() {
		Session session = HibernateUtil.getSession();

		List<Partaker> result = new ArrayList<Partaker>();
		try {
			session.getTransaction().begin();
			String strQuery = "FROM Partaker";
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

	@SuppressWarnings("unchecked")
	@Override
	public List<Partaker> getPartakerByMeetingId(long meetingId) {
		Session session = HibernateUtil.getSession();

		List<Partaker> result = null;
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
	@SuppressWarnings("unchecked")
	@Override
	public List<Partaker> getPartakerByOrgPartakerId(long orgPartakerId) {
		Session session = HibernateUtil.getSession();

		List<Partaker> result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM Partaker WHERE orgId = :orgId ";
			Query query = session.createQuery(strQuery);
			query.setParameter("orgId", orgPartakerId);
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

	/* function for web get partaker by barcode
	 * @see com.swt.meeting.IPartaker#getListPartakerByOrgIdAndMeetingId(long, long)
	 */
	@Override
	public Partaker getPartakerByBarcode(String barcode) {
		Session session = HibernateUtil.getSession();

		Partaker result = new Partaker();
		try {
			session.getTransaction().begin();
			String strQuery = "FROM Partaker WHERE barcode = :barcode";
			Query query = session.createQuery(strQuery);
			query.setParameter("barcode", barcode);
			result = (Partaker) query.uniqueResult();

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
