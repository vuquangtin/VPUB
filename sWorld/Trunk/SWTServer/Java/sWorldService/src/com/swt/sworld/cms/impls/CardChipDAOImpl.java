/**
 * 
 */
package com.swt.sworld.cms.impls;

import java.util.List;

import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;

import com.nhn.utilities.HibernateUtil;
import com.swt.sworld.cms.ICardChipDAO;
import com.swt.sworld.cms.domain.CardChip;
import com.swt.sworld.communication.customer.object.CardFilterDto;
import com.swt.sworld.utilites.SworldConst;

/**
 * @author loc.le
 * 
 */
public class CardChipDAOImpl implements ICardChipDAO {

	@Override
	public long getCardChipIdBySerialNumber(String serial) {
		Session session = HibernateUtil.getSessionFactory().openSession();

		long result = 0;
		try {

			session.getTransaction().begin();
			String strQuery = "Select CardChipId FROM CardChip WHERE SerialNumberHex = :serial AND PhysicalStatus = :physical AND LogicalStatus = :logical";
			Query query = session.createQuery(strQuery);
			query.setParameter("serial", serial);
			query.setParameter("physical", 0);
			query.setParameter("logical", 103);
			if (query.list().size() > 0)
				result = (long) query.uniqueResult();

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
	public CardChip getCardChipBySerialCardType(String serialnumberhex, int cardtype) {
		return getCardChipBySerial(serialnumberhex);
	}

	@Override
	public CardChip getCardChipBySerialCardType(long masterid, String serialnumberhex, int cardtype) {
		return getCardChipBySerial(masterid, serialnumberhex);
	}

	@Override
	public CardChip getCardChipById(long cardchipid) {
		Session session = HibernateUtil.getSession();

		CardChip result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM CardChip WHERE CardChipId = :cardchipid";
			Query query = session.createQuery(strQuery);
			query.setParameter("cardchipid", cardchipid);
			result = (CardChip) query.uniqueResult();
			session.getTransaction().commit();

		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.close();
		}

		return result;
	}

	@Override
	public long markBrokenCardByCardChipId(long cardchipid) {

		Session session = HibernateUtil.getSession();

		try {
			session.getTransaction().begin();
			String strQuery = "UPDATE CardChip SET PhysicalStatus=:physical WHERE CardChipId=:cardchipid";
			Query query = session.createQuery(strQuery);
			query.setParameter("cardchipid", cardchipid);
			query.setParameter("physical", SworldConst.MARKBROKEN);
			query.executeUpdate();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.close();
		}
		return cardchipid;
	}

	@Override
	public long unmarkBrokenCardByCardChipId(long cardchipid) {
		Session session = HibernateUtil.getSession();

		try {
			session.getTransaction().begin();
			String strQuery = "UPDATE CardChip SET PhysicalStatus=:physical WHERE CardChipId=:cardchipid";
			Query query = session.createQuery(strQuery);
			query.setParameter("cardchipid", cardchipid);
			query.setParameter("physical", SworldConst.NORMAL);
			query.executeUpdate();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.close();
		}
		return cardchipid;
	}

	@Override
	public long markLostCardByCardChipId(long cardchipid) {
		Session session = HibernateUtil.getSession();

		try {
			session.getTransaction().begin();
			String strQuery = "UPDATE CardChip SET PhysicalStatus=:physical WHERE CardChipId=:cardchipid";
			Query query = session.createQuery(strQuery);
			query.setParameter("cardchipid", cardchipid);
			query.setParameter("physical", SworldConst.MARKLOST);
			query.executeUpdate();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.close();
		}
		return cardchipid;
	}

	@Override
	public long unmarkLostCardByCardChipId(long cardchipid) {
		Session session = HibernateUtil.getSession();

		try {
			session.getTransaction().begin();
			String strQuery = "UPDATE CardChip SET PhysicalStatus=:physical WHERE CardChipId=:cardchipid";
			Query query = session.createQuery(strQuery);
			query.setParameter("cardchipid", cardchipid);
			query.setParameter("physical", SworldConst.NORMAL);
			query.executeUpdate();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.close();
		}
		return cardchipid;
	}

	@Override
	public CardChip getCardChipBySerial(String serialnumberhex) {
		Session session = HibernateUtil.getSession();

		CardChip result = new CardChip();
		try {

			session.getTransaction().begin();
			String strQuery = "FROM CardChip WHERE SerialNumberHex = :serial";
			Query query = session.createQuery(strQuery);
			query.setParameter("serial", serialnumberhex);
			result = (CardChip) query.uniqueResult();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.close();
		}

		return result;
	}

	@Override
	public long insertCardChip(CardChip cardchip) {
		HibernateUtil.insert(cardchip);
		return cardchip.getCardChipId();
	}

	@Override
	public int updateCardChip(CardChip cardchip) {
		return HibernateUtil.update(cardchip);

	}

	@Override
	public CardChip getCardChipBySerial(long masterid, String serialnumberhex) {
		Session session = HibernateUtil.getSession();

		CardChip result = null;
		try {

			session.getTransaction().begin();
			String strQuery = "FROM CardChip WHERE SerialNumberHex = :serial AND OrgMasterId = :masterid";
			Query query = session.createQuery(strQuery);
			query.setParameter("serial", serialnumberhex);
			query.setParameter("masterid", masterid);
			result = (CardChip) query.uniqueResult();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.close();
		}

		return result;
	}

	@Override
	public CardChip getLogicAndPhyByCardId(long CardChipId) {
		Session session = HibernateUtil.getSession();

		CardChip cp = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM CardChip WHERE CardChipId = :CardChipId";
			Query query = session.createQuery(strQuery);
			query.setParameter("CardChipId", CardChipId);
			cp = (CardChip) query.uniqueResult();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.close();
		}

		return cp;
	}

	@Override
	public CardChip getCardChipBySerialAndPartnerId(long partnerid, String serialnumberhex) {
		Session session = HibernateUtil.getSession();

		CardChip result = null;
		try {

			session.getTransaction().begin();
			String strQuery = "FROM CardChip WHERE SerialNumberHex = :serial AND OrgPartnerId = :partnerid";
			Query query = session.createQuery(strQuery);
			query.setParameter("serial", serialnumberhex);
			query.setParameter("partnerid", partnerid);
			result = (CardChip) query.uniqueResult();
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
	public List<CardChip> getAll(long orgid, long suborgid, CardFilterDto filter) {
		Session session = HibernateUtil.getSession();

		List<CardChip> result = null;
		try {
			String search = filter.clone();
			if (search == "") {
				session.getTransaction().begin();
				String strQuery = "FROM CardChip WHERE OrgMasterId = :orgid AND OrgPartnerId = :suborgid";
				Query query = session.createQuery(strQuery);
				query.setParameter("orgid", orgid);
				query.setParameter("suborgid", suborgid);
				result = query.list();

			} else {
				session.getTransaction().begin();
				String strQuery = "FROM CardChip WHERE OrgMasterId = :orgid AND OrgPartnerId = :suborgid" + search;
				Query query = session.createQuery(strQuery);
				query.setParameter("orgid", orgid);
				query.setParameter("suborgid", suborgid);
				result = query.list();
			}
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
	public List<CardChip> getAllCardChip() {
		Session session = HibernateUtil.getSession();

		List<CardChip> cp = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM CardChip";
			Query query = session.createQuery(strQuery);
			cp = query.list();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.close();
		}

		return cp;
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<CardChip> getCardChipByPhysical(int physicalstatus, long masterid, long orgpartnerid) {
		Session session = HibernateUtil.getSession();

		List<CardChip> lstcard = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM CardChip WHERE PhysicalStatus = :physicalstatus AND OrgMasterId =:masterid AND OrgPartnerId = :orgpartnerid";
			Query query = session.createQuery(strQuery);
			query.setParameter("physicalstatus", physicalstatus);
			query.setParameter("orgpartnerid", orgpartnerid);
			query.setParameter("masterid", masterid);
			lstcard = query.list();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.close();
		}

		return lstcard;
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<CardChip> getAllCardChipByOrgPartnerId(long masterid, long partnerid) {
		Session session = HibernateUtil.getSession();

		List<CardChip> result = null;
		try {

			session.getTransaction().begin();
			String strQuery = "FROM CardChip WHERE OrgMasterId =:masterid AND OrgPartnerId = :partnerid";
			Query query = session.createQuery(strQuery);
			query.setParameter("partnerid", partnerid);
			query.setParameter("masterid", masterid);
			result = query.list();
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
	public List<CardChip> getCardChipByPartnerId(long masterId, long partnerId) {
		Session session = HibernateUtil.getSession();

		List<CardChip> result = null;
		try {

			session.getTransaction().begin();
			String strQuery = "FROM CardChip WHERE OrgPartnerId = :partnerId AND OrgMasterId <> :masterId";
			Query query = session.createQuery(strQuery);
			query.setParameter("partnerId", partnerId);
			query.setParameter("masterId", masterId);
			result = query.list();
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
	public List<CardChip> getCardChipByMasterId(long masterId) {
		Session session = HibernateUtil.getSession();

		List<CardChip> result = null;
		try {

			session.getTransaction().begin();
			String strQuery = "FROM CardChip WHERE OrgMasterId = :masterId";
			Query query = session.createQuery(strQuery);
			query.setParameter("masterId", masterId);
			result = query.list();
			session.getTransaction().commit();

		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.close();
		}

		return result;
	}

	@Override
	public int deleteCardChip(CardChip cardchip) {
		return HibernateUtil.deleteById(cardchip, cardchip.getCardChipId());
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see com.swt.sworld.cms.ICardChipDAO#getCardChipListExport()
	 */
	@SuppressWarnings("unchecked")
	@Override
	public List<CardChip> getCardChipListExport() {
		Session session = HibernateUtil.getSession();

		List<CardChip> result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM CardChip WHERE LogicalStatus = 101 AND OrgMasterId = OrgPartnerId";
			Query query = session.createQuery(strQuery);
			result = query.list();
			session.getTransaction().commit();

		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.close();
		}

		return result;
	}

	/* (non-Javadoc)
	 * @see com.swt.sworld.cms.ICardChipDAO#getCardChipListByOrg(long)
	 */
	@SuppressWarnings("unchecked")
	@Override
	public List<CardChip> getCardChipListByOrg(long orgId) {
		Session session = HibernateUtil.getSession();

		List<CardChip> result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM CardChip WHERE LogicalStatus = 100 AND OrgPartnerId = :orgId";
			Query query = session.createQuery(strQuery);
			query.setParameter("orgId", orgId);
			result = query.list();
			session.getTransaction().commit();

		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.close();
		}

		return result;
	}
}
