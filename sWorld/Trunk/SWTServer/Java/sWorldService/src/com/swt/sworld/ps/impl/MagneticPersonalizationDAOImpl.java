/**
 * 
 */
package com.swt.sworld.ps.impl;

import java.util.List;

import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;

import com.nhn.utilities.HibernateUtil;
import com.swt.sworld.communication.customer.object.CardMagneticFilterDto;
import com.swt.sworld.ps.IMagneticPersonalization;
import com.swt.sworld.ps.domain.MagneticPersonalization;

/**
 * @author Administrator
 * 
 */
public class MagneticPersonalizationDAOImpl implements IMagneticPersonalization {

	@Override
	public MagneticPersonalization getMagneticPersoByMemberId(long memid) {
		Session session = HibernateUtil.getSessionFactory().openSession();

		MagneticPersonalization cp = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM MagneticPersonalization WHERE PsMemberId = :memid";
			Query query = session.createQuery(strQuery);
			query.setParameter("memid", memid);
			cp = (MagneticPersonalization) query.uniqueResult();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}

		return cp;
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<MagneticPersonalization> getall(long valueId) {
		Session session = HibernateUtil.getSessionFactory().openSession();

		List<MagneticPersonalization> lstMagnetic = null;
		try {
			if (valueId != 0) {
				session.getTransaction().begin();
				String strQuery = "FROM MagneticPersonalization WHERE MagneticPersId > :valueId";
				Query query = session.createQuery(strQuery);
				query.setParameter("valueId", valueId);
				lstMagnetic = query.list();
				session.getTransaction().commit();
			} else {
				session.getTransaction().begin();
				String strQuery = "FROM MagneticPersonalization";
				Query query = session.createQuery(strQuery);
				lstMagnetic = query.list();
				session.getTransaction().commit();
			}
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}

		return lstMagnetic;
	}

	@Override
	public MagneticPersonalization getMagneticPersoByCardMagneticId(
			long cardid, CardMagneticFilterDto filter) {
		Session session = HibernateUtil.getSessionFactory().openSession();

		MagneticPersonalization cp = null;
		try {
			String search = filter.cloneMagneticPerso();
			if (search == "") {
				session.getTransaction().begin();
				String strQuery = "FROM MagneticPersonalization WHERE CardMagneticId = :cardid";
				Query query = session.createQuery(strQuery);
				query.setParameter("cardid", cardid);
				cp = (MagneticPersonalization) query.uniqueResult();
			} else {
				session.getTransaction().begin();
				String strQuery = "FROM MagneticPersonalization WHERE CardMagneticId = :cardid"
						+ search;
				Query query = session.createQuery(strQuery);
				query.setParameter("cardid", cardid);
				cp = (MagneticPersonalization) query.uniqueResult();
			}
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}

		return cp;
	}

	@Override
	public int presoCardMagnetic(MagneticPersonalization magneticperso) {
		return HibernateUtil.insert(magneticperso);
	}

	@Override
	public int saveinfo(MagneticPersonalization dto) {
		return HibernateUtil.insert(dto);
	}

	@Override
	public MagneticPersonalization updateStatus(long persoid, int status,
			String reason, String fieldupdate) {
		Session session = HibernateUtil.getSessionFactory().openSession();

		MagneticPersonalization cp = null;
		try {
			session.getTransaction().begin();
			String strQuery = "UPDATE MagneticPersonalization SET Notes=:reason, "
					+ fieldupdate + "=:status WHERE MagneticPersId=:persoid";
			Query query = session.createQuery(strQuery);
			query.setParameter("persoid", persoid);
			query.setParameter("status", status);
			query.setParameter("reason", reason);
			query.executeUpdate();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}

		return cp;
	}

	@Override
	public MagneticPersonalization getByPerId(long persoid) {
		Session session = HibernateUtil.getSessionFactory().openSession();

		MagneticPersonalization cp = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM MagneticPersonalization WHERE MagneticPersId = :persoid";
			Query query = session.createQuery(strQuery);
			query.setParameter("persoid", persoid);
			cp = (MagneticPersonalization) query.uniqueResult();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}

		return cp;
	}

	@Override
	public MagneticPersonalization getByFilter(long cardid) {
		Session session = HibernateUtil.getSessionFactory().openSession();

		MagneticPersonalization cp = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM MagneticPersonalization WHERE CardMagneticId = :cardid";
			Query query = session.createQuery(strQuery);
			query.setParameter("cardid", cardid);
			cp = (MagneticPersonalization) query.uniqueResult();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}

		return cp;
	}

	@Override
	public MagneticPersonalization getCardByCardId(long cardId) {
		Session session = HibernateUtil.getSessionFactory().openSession();

		MagneticPersonalization cp = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM MagneticPersonalization WHERE CardMagneticId = :cardId";
			Query query = session.createQuery(strQuery);
			query.setParameter("cardId", cardId);
			cp = (MagneticPersonalization) query.uniqueResult();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}
		return cp;
	}

	@Override
	public MagneticPersonalization getCardBySerial(String serial) {
		Session session = HibernateUtil.getSessionFactory().openSession();

		MagneticPersonalization cp = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM MagneticPersonalization WHERE SerialCard = :serial";
			Query query = session.createQuery(strQuery);
			query.setParameter("serial", serial);
			cp = (MagneticPersonalization) query.uniqueResult();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}

		return cp;
	}

}
