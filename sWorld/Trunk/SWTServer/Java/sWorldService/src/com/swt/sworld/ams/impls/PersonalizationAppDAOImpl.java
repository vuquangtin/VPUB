/**
 * 
 */
package com.swt.sworld.ams.impls;
import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;

import com.nhn.utilities.HibernateUtil;
import com.swt.sworld.ams.IPersonalizationApp;
import com.swt.sworld.ams.domain.PersonalizationApp;

/**
 * @author Administrator
 *
 */
public class PersonalizationAppDAOImpl implements IPersonalizationApp {

	@Override
	public int insert(PersonalizationApp pa) {
		return HibernateUtil.insert(pa);
	}

	@Override
	public int update(PersonalizationApp pa) {
		return HibernateUtil.update(pa);
	}

	@Override
	public int delete(long id) {
		PersonalizationApp persoApp = new PersonalizationApp();
		return HibernateUtil.deleteById(persoApp,id);
	}

	@Override
	public PersonalizationApp getPersonalizationAppById(long id) {
		Session session = HibernateUtil.getSession();
		PersonalizationApp persoapp = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM PersonalizationApp WHERE Id = :id";
			Query query = session.createQuery(strQuery);
			query.setParameter("id", id);
			persoapp = (PersonalizationApp) query.uniqueResult();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}
		return persoapp;
	}

	

}
