/**
 * 
 */
package com.swt.sworld.ps.impl;

import java.io.Serializable;

import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;
import org.hibernate.Transaction;

import com.nhn.utilities.HibernateUtil;
import com.swt.sworld.communication.customer.object.PartnerInfoDto;

/**
 * @author Administrator
 *
 */
public class PartnerInfoDAO implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = 2876605382770869916L;
	
	public PartnerInfoDto getPartnerDataByKey( String code)
	{
		Session session = HibernateUtil.getSessionFactory().openSession();
		Transaction transaction = null;
		PartnerInfoDto result = null;
		try {
			transaction = session.beginTransaction();
			String strQuery = "SELECT * FROM PartnerInfoDto WHERE PartnerCode = :code";
			Query query = session.createQuery(strQuery);
			query.setParameter("code", code);
			
			result = (PartnerInfoDto) query.uniqueResult();
			
			transaction.commit();
		} catch (HibernateException e) {
			transaction.rollback();
			e.printStackTrace();
		} finally {
			session.close();
		}
		return result;
	}

}
