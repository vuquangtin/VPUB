/**
 * 
 */
package com.swt.sworld.ams.impls;

import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;

import com.nhn.utilities.HibernateUtil;
import com.swt.sworld.ams.ICardMagneticApp;
import com.swt.sworld.ams.domain.CardMagneticApp;

/**
 * @author loc.le
 *
 */
public class CardMagneticAppDAOImpl implements ICardMagneticApp {
	
	@Override
	public int insert(CardMagneticApp cma) {
		
		return HibernateUtil.insert(cma);
		
	}
	@Override
	public int update(CardMagneticApp cma) {
		
		return HibernateUtil.update(cma);
		
	}
	@Override
	public int delete(long cardMagniteId) {
		
		CardMagneticApp cardMagneticApp = new CardMagneticApp();
		
		return HibernateUtil.deleteById(cardMagneticApp, cardMagniteId);
	}
	@Override
	public CardMagneticApp getCardMagneticAppByID(long cardMagniteId) {
		Session session = HibernateUtil.getSession();
		CardMagneticApp card = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM CardMagneticApp WHERE CardMagniteId = :cardMagniteId";
			Query query = session.createQuery(strQuery);
			query.setParameter("cardMagniteId", cardMagniteId);
			card = (CardMagneticApp) query.uniqueResult();
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
