/**
 * 
 */
package com.swt.sworld.ams.impls;

import java.util.List;

import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;

import com.nhn.utilities.HibernateUtil;
import com.swt.sworld.ams.ICardChipApp;
import com.swt.sworld.ams.domain.CardChipApp;

/**
 * @author Administrator
 *
 */
public class CardChipAppDAOImpl implements ICardChipApp {

	/* (non-Javadoc)
	 * @see com.swt.sworld.ams.interfaces.ICardChipAppDAO#UpdateMemberAppOfPerso(byte[], java.lang.String)
	 */
	@Override
	public int updateMemberAppOfPerso(byte[] serialNumberHex,
			String lastDateUpdate) {
		String serial= null;
		String.format("serial",serialNumberHex);
		Session session = HibernateUtil.getSession();
		
		try {
			session.getTransaction().begin();
			String strQuery = "SELECT CardChipId FROM CMSCardChip WHERE SerialNumberHex = :serial";
			Query query = session.createQuery(strQuery);
			query.setParameter("serial", serial);
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}
		
		return 0;
	}


	@Override
	public int insert(CardChipApp cca) {
		
		return HibernateUtil.insert(cca);
		
	}

	@Override
	public void update(CardChipApp cca) {
		HibernateUtil.update(cca)	;
	}

	@Override
	public void delete(long CardChipAppId) {
		
		Session session = HibernateUtil.getSession();
		try
		{
			session.getTransaction().begin();
			CardChipApp cca = (CardChipApp) session.get(CardChipApp.class, CardChipAppId);
			session.delete(cca);
			session.getTransaction().commit();
		}
		catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		}
		finally
		{
			session.flush();
			session.clear();
			session.close();
		}
		
	}

	@Override
	public void deleteBySerial(long chipPerso) {
		Session session = HibernateUtil.getSession();
		
		try {
			session.getTransaction().begin();
			String strQuery = "DELETE CardChipApp WHERE ChipPersoId = :chipPerso";
			Query query = session.createQuery(strQuery);
			query.setParameter("chipPerso", chipPerso);
			query.executeUpdate();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		}
		finally
		{
			session.flush();
			session.clear();
			session.close();
		}
	}

	@Override
	public CardChipApp getBySerial(long chipperso) {
		Session session = HibernateUtil.getSession();
		
		CardChipApp card = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM CardChipApp WHERE ChipPersoId = :chipperso";
			Query query = session.createQuery(strQuery);
			query.setParameter("chipperso", chipperso);
			card = (CardChipApp) query.uniqueResult();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}
		return card;
	}

	@Override
	public CardChipApp getCardChipAppByID(long cardchipappid) {
		Session session = HibernateUtil.getSession();
		
		CardChipApp card = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM CardChipApp WHERE CardChipAppId = :cardchipappid";
			Query query = session.createQuery(strQuery);
			query.setParameter("cardchipappid", cardchipappid);
			card = (CardChipApp) query.uniqueResult();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}
		return card;
	}


	@SuppressWarnings("unchecked")
	@Override
	public List<CardChipApp> getByChipperso(long chipPerso) {
		Session session = HibernateUtil.getSession();
		
		List<CardChipApp> card = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM CardChipApp WHERE ChipPersoId = :chipperso";
			Query query = session.createQuery(strQuery);
			query.setParameter("chipperso", chipPerso);
			card = query.list();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}
		return card;
	}

}
