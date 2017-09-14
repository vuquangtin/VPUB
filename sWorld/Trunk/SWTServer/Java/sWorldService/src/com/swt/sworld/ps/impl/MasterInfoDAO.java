/**
 * 
 */
package com.swt.sworld.ps.impl;

import java.io.Serializable;

import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;

import com.nhn.utilities.HibernateUtil;
import com.swt.sworld.communication.customer.object.MasterInfoDTO;

/**
 * @author Administrator
 *
 */
public class MasterInfoDAO implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = 2929642836704157155L;
	
	public MasterInfoDTO getMasterDataByKey( String code)
	{
		Session session = HibernateUtil.getSessionFactory().openSession();
		
		MasterInfoDTO result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "SELECT * FROM MasterInfoDto WHERE MasterCode = :code";
			Query query = session.createQuery(strQuery);
			query.setParameter("code", code);
			
			result = (MasterInfoDTO) query.uniqueResult();
			
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
