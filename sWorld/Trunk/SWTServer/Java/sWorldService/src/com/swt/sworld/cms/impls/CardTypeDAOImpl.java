package com.swt.sworld.cms.impls;

import java.util.List;

import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;

import com.nhn.utilities.HibernateUtil;
import com.swt.sworld.cms.ICardTypeDAO;
import com.swt.sworld.cms.domain.CardType;
import com.swt.sworld.communication.customer.object.CardTypeDTO;

public class CardTypeDAOImpl implements ICardTypeDAO {

	@Override
	public CardType getByOrgId(String id, long orgid) {
		Session session = HibernateUtil.getSession();
		
		CardType result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "SELECT * FROM CardType WHERE CardTypeID = :id AND OrgId =:orgid";
			Query query = session.createQuery(strQuery);
			query.setParameter("CardTypeID", id);
			query.setParameter("OrgId", orgid);

			result = (CardType) query.uniqueResult();

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
	public List<CardType> getByOrgId(long orgid) {
		Session session = HibernateUtil.getSession();
		
		List<CardType> result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM CardType WHERE OrgId =:orgid";
			Query query = session.createQuery(strQuery);
			query.setParameter("orgid", orgid);

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
	public List<CardTypeDTO> getCardTypeDTOByOrgId(long orgid) {
		Session session = HibernateUtil.getSession();
		
		List<CardTypeDTO> result = null;
		try {
			
			
			session.getTransaction().begin();
			String strQuery = "SELECT CardTypeID,Prefix,CardTypeName,CardLow,CardHigh,PinLength FROM CardType WHERE OrgId =:orgid";
			Query query = session.createQuery(strQuery);
			query.setParameter("orgid", orgid);

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
	public CardType getById(long id) {
		Session session = HibernateUtil.getSession();
		
		CardType result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM CardType WHERE CardTypeID =:id";
			Query query = session.createQuery(strQuery);
			query.setParameter("id", id);
			result = (CardType) query.uniqueResult();

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
	public CardType getById(long id, String prix) {
		Session session = HibernateUtil.getSession();
		
		CardType result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM CardType WHERE CardTypeID =:id AND Prefix =:prix";
			Query query = session.createQuery(strQuery);
			query.setParameter("id", id);
			query.setParameter("prix", prix);
			result = (CardType) query.uniqueResult();

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
	public CardType getbyprefix(String prefix) {
		Session session = HibernateUtil.getSession();
		
		CardType result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM CardType WHERE Prefix =:prefix";
			Query query = session.createQuery(strQuery);
			query.setParameter("prefix", prefix);
			result = (CardType) query.uniqueResult();

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
