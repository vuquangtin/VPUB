/**
 * 
 */
package com.swt.sworld.cms.impls;

import java.util.List;

import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;

import com.nhn.utilities.HibernateUtil;
import com.swt.sworld.cms.ICardMagneticDAO;
import com.swt.sworld.cms.domain.CardMagnetic;
import com.swt.sworld.communication.customer.object.CardMagneticFilterDto;
/**
 * @author loc.le
 * 
 */
public class CardMagneticDAOImpl implements ICardMagneticDAO {

	@Override
	public CardMagnetic getLogicAndPhyByCardId(long cardmagneid) {
		Session session = HibernateUtil.getSessionFactory().openSession();
		
		CardMagnetic cm = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM CardMagnetic WHERE MagneticId = :cardmagneid";
			Query query = session.createQuery(strQuery);
			query.setParameter("cardmagneid", cardmagneid);
			cm = (CardMagnetic) query.uniqueResult();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.close();
		}

		return cm;
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<Long> getCardMagneticIdByMasterIdAndPartnerId(long masterid,
			long partnerid) {
		Session session = HibernateUtil.getSessionFactory().openSession();
		
		List<Long> cm = null;
		try {
			session.getTransaction().begin();
			String strQuery = "SELECT MagneticId FROM CardMagnetic WHERE OrgPartnerId = :masterid AND SubOrgId = :partnerid";
			Query query = session.createQuery(strQuery);
			query.setParameter("masterid", masterid);
			query.setParameter("partnerid", partnerid);
			cm = query.list();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.close();
		}

		return cm;
	}

	@Override
	public int saveInforDefault(CardMagnetic cardm) {
		return HibernateUtil.insert(cardm);
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<CardMagnetic> getListCardByLogicalStatus(long masterid,
			long partnerid, int logicalstatus) {
		Session session = HibernateUtil.getSessionFactory().openSession();
		
		List<CardMagnetic> cm = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM CardMagnetic WHERE OrgMasterId = :masterid AND OrgPartnerId = :partnerid AND LogicalStatus = :logicalstatus";
			Query query = session.createQuery(strQuery);
			query.setParameter("masterid", masterid);
			query.setParameter("partnerid", partnerid);
			query.setParameter("logicalstatus", logicalstatus);
			cm = query.list();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.close();
		}

		return cm;
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<CardMagnetic> getListCardByPhysicalStatus(long masterid,
			long partnerid, int physicalstatus) {
		Session session = HibernateUtil.getSessionFactory().openSession();
		
		List<CardMagnetic> cm = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM CardMagnetic WHERE OrgMasterId = :masterid AND OrgPartnerId = :partnerid AND PhysicalStatus = :physicalstatus";
			Query query = session.createQuery(strQuery);
			query.setParameter("masterid", masterid);
			query.setParameter("partnerid", partnerid);
			query.setParameter("physicalstatus", physicalstatus);
			cm = query.list();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.close();
		}

		return cm;
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<CardMagnetic> getListCardByLogicalAndPhysicalStatus(
			long masterid, long partnerid, int logicalstatus, int physicalstatus) {
		Session session = HibernateUtil.getSessionFactory().openSession();
		
		List<CardMagnetic> cm = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM CardMagnetic WHERE OrgMasterId = :masterid AND OrgPartnerId = :partnerid AND LogicalStatus = :logicalstatus AND PhysicalStatus = :physicalstatus";
			Query query = session.createQuery(strQuery);
			query.setParameter("masterid", masterid);
			query.setParameter("partnerid", partnerid);
			query.setParameter("logicalstatus", logicalstatus);
			query.setParameter("physicalstatus", physicalstatus);
			cm = query.list();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.close();
		}

		return cm;
	}

	@Override
	public long UpdateCardMagnetic(CardMagnetic card) {
		HibernateUtil.update(card);
		return card.getMagneticId();
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<CardMagnetic> getTotalRecordByorgidandsuborgid(long orgid,
			long suborgid) {
		Session session = HibernateUtil.getSessionFactory().openSession();
		
		List<CardMagnetic> cm = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM CardMagnetic WHERE OrgMasterId = :orgid AND OrgPartnerId = :suborgid";
			Query query = session.createQuery(strQuery);
			query.setParameter("orgid", orgid);
			query.setParameter("suborgid", suborgid);
			cm = query.list();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.close();
		}

		return cm;
	}

	@Override
	public CardMagnetic getLogicAndPhysicalBySerialNumber(String CardNumber) {
		Session session = HibernateUtil.getSessionFactory().openSession();
		
		CardMagnetic cm = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM CardMagnetic WHERE CardNumber = :CardNumber";
			Query query = session.createQuery(strQuery);
			query.setParameter("CardNumber", CardNumber);
			cm = (CardMagnetic) query.uniqueResult();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.close();
		}

		return cm;
	}

	@Override
	public long totalRecord(long masterid, long partnerid, String prefix) {
		Session session = HibernateUtil.getSessionFactory().openSession();
		
		long cm = 0;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM CardMagnetic WHERE OrgMasterId = :masterid AND OrgPartnerId = :partnerid AND PrefixCard = :prefix";
			Query query = session.createQuery(strQuery);
			query.setParameter("masterid", masterid);
			query.setParameter("partnerid", partnerid);
			query.setParameter("prefix", prefix);
			cm = query.list().size();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.close();
		}

		return cm;
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<Long> getCardMagneticIdByMasterId(long masterid) {
		Session session = HibernateUtil.getSessionFactory().openSession();
		
		List<Long> cm = null;
		try {
			session.getTransaction().begin();
			String strQuery = "SELECT MagneticId FROM CardMagnetic WHERE OrgPartnerId = :masterid";
			Query query = session.createQuery(strQuery);
			query.setParameter("masterid", masterid);
			cm = query.list();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.close();
		}

		return cm;
	}

	// @Override
	// public List<CardMagnetic> statismagnetic(long masterid, long partnerid,
	// String prefix, int status) {
	// Session session = HibernateUtil.getSessionFactory().openSession();
	// TransactionMerchant transaction = null;
	// List<CardMagnetic> result = null;
	// try {
	// session.getTransaction().begin()
	// String strQuery =
	// "FROM CardMagnetic WHERE OrgMasterId = :masterid AND OrgPartnerId = :partnerid AND PrefixCard = :prefix";
	// Query query = session.createQuery(strQuery);
	// query.setParameter("masterid", masterid);
	// query.setParameter("partnerid", partnerid);
	// query.setParameter("prefix", prefix);
	// result = query.list();
	// session.getTransaction().commit();
	// } catch (HibernateException e) {
	// session.getTransaction().rollback();
	// e.printStackTrace();
	// } finally {
	// session.close();
	// }
	//
	// return result;
	// }

	@Override
	public int statismagnetic(long masterid, long partnerid, String prefix,
			String nameStatus, int status) {
		Session session = HibernateUtil.getSessionFactory().openSession();
		
		int result = 0;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM CardMagnetic WHERE OrgMasterId = :masterid AND OrgPartnerId = :partnerid AND PrefixCard = :prefix AND "
					+ nameStatus + " = :status";
			Query query = session.createQuery(strQuery);
			query.setParameter("masterid", masterid);
			query.setParameter("partnerid", partnerid);
			query.setParameter("prefix", prefix);
			query.setParameter("status", status);
			result = query.list().size();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.close();
		}

		return result;
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<Long> getMemberPersoByfilter(long masterid, long partnerid,
			CardMagneticFilterDto filter) {
		Session session = HibernateUtil.getSessionFactory().openSession();
		
		List<Long> cm = null;
		try {
			String search = filter.clone();
			if (search == "") {
				session.getTransaction().begin();
				String strQuery = "SELECT MagneticId FROM CardMagnetic WHERE OrgMasterId = :masterid AND OrgPartnerId = :partnerid";
				Query query = session.createQuery(strQuery);
				query.setParameter("masterid", masterid);
				query.setParameter("partnerid", partnerid);
				cm = query.list();
			} else {
				session.getTransaction().begin();
				String strQuery = "SELECT MagneticId FROM CardMagnetic WHERE OrgMasterId = :masterid AND OrgPartnerId = :partnerid"
						+ search;
				Query query = session.createQuery(strQuery);
				query.setParameter("masterid", masterid);
				query.setParameter("partnerid", partnerid);
				cm = query.list();
			}
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.close();
		}

		return cm;
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<CardMagnetic> getall(long orgid, long partnerid,
			CardMagneticFilterDto filter) {
		Session session = HibernateUtil.getSessionFactory().openSession();
		
		List<CardMagnetic> cm = null;
		try {
			String search = filter.clone();
			if (partnerid < 0) {
				if (search == "") {
					session.getTransaction().begin();
					String strQuery = "FROM CardMagnetic WHERE OrgMasterId = :orgid";
					Query query = session.createQuery(strQuery);
					query.setParameter("orgid", orgid);
					cm = query.list();
				} else {
					session.getTransaction().begin();
					String strQuery = "FROM CardMagnetic WHERE OrgMasterId = :orgid"
							+ search;
					Query query = session.createQuery(strQuery);
					query.setParameter("orgid", orgid);
					cm = query.list();
				}
			} else {
				if (search == "") {
					session.getTransaction().begin();
					String strQuery = "FROM CardMagnetic WHERE OrgMasterId = :orgid AND OrgPartnerId = :partnerid";
					Query query = session.createQuery(strQuery);
					query.setParameter("orgid", orgid);
					query.setParameter("partnerid", partnerid);
					cm = query.list();
				} else {
					session.getTransaction().begin();
					String strQuery = "FROM CardMagnetic WHERE OrgMasterId = :orgid AND OrgPartnerId = :partnerid"
							+ search;
					Query query = session.createQuery(strQuery);
					query.setParameter("orgid", orgid);
					query.setParameter("partnerid", partnerid);
					cm = query.list();
				}
			}
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.close();
		}

		return cm;
	}

	@Override
	public CardMagnetic UpdateStatus(long cardid, int status, String reason,
			String fieldupdate) {
		Session session = HibernateUtil.getSessionFactory().openSession();
		
		CardMagnetic cp = null;
		try {
			session.getTransaction().begin();
			String strQuery = "UPDATE CardMagnetic SET Notes=:reason, "+ fieldupdate +"=:status WHERE MagneticId=:cardid";
			Query query = session.createQuery(strQuery);
			query.setParameter("cardid", cardid);
			query.setParameter("status", status);
			query.setParameter("reason", reason);
			query.executeUpdate();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		}
		finally
		{
			session.close();
		}
		
		return cp;
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<CardMagnetic> getALLCardMagnetic() {
		Session session = HibernateUtil.getSessionFactory().openSession();
		
		List<CardMagnetic> lstCard = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM CardMagnetic";
			Query query = session.createQuery(strQuery);
			lstCard = query.list();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.close();
		}

		return lstCard;
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<CardMagnetic> getCardMagneticByPartnerId(long masterId, long partnerId) {
		Session session = HibernateUtil.getSessionFactory().openSession();
		
		List<CardMagnetic> cm = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM CardMagnetic WHERE OrgPartnerId = :partnerId AND OrgMasterId <> :masterId";
			Query query = session.createQuery(strQuery);
			query.setParameter("partnerId", partnerId);
			query.setParameter("masterId", masterId);
			cm = query.list();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.close();
		}

		return cm;
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<CardMagnetic> getCardMagneticByMasterPartnerId(long masterId,
			long partnerId) {
		Session session = HibernateUtil.getSessionFactory().openSession();
		
		List<CardMagnetic> cm = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM CardMagnetic WHERE OrgMasterId = :masterId AND OrgPartnerId = :partnerId";
			Query query = session.createQuery(strQuery);
			query.setParameter("masterId", masterId);
			query.setParameter("partnerId", partnerId);
			cm = query.list();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.close();
		}

		return cm;
	}

	@Override
	public CardMagnetic getCardBySerial(String serial) {
		Session session = HibernateUtil.getSessionFactory().openSession();
		
		CardMagnetic cm = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM CardMagnetic WHERE CardNumber = :serial";
			Query query = session.createQuery(strQuery);
			query.setParameter("serial", serial);
			cm = (CardMagnetic) query.uniqueResult();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.close();
		}

		return cm;
	}

}
