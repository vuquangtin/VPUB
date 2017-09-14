/**
 * 
 */
package com.swt.sworld.common.impls;

import java.util.List;

import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;

import com.nhn.utilities.HibernateUtil;
import com.swt.sworld.common.ILoginHistoryDAO;
import com.swt.sworld.common.domain.LoginHistory;
import com.swt.sworld.communication.customer.object.LoginHistoryFilterDto;

/**
 * @author sang.do
 * 
 */
public class LoginHistoryDAOImpl implements ILoginHistoryDAO {

	@SuppressWarnings("unchecked")
	@Override
	public List<LoginHistory> getLoginHistoryList(
			LoginHistoryFilterDto loginfilter) {

		Session session = HibernateUtil.getSession();
		
		List<LoginHistory> result = null;
		try {
			String search = loginfilter.clone();
			if (search == "") {
				session.getTransaction().begin();
				String strQuery = "FROM LoginHistory";
				Query query = session.createQuery(strQuery);
				result = query.list();
			}
			else
			{
				session.getTransaction().begin();
				String strQuery = "FROM LoginHistory WHERE "+search;
				Query query = session.createQuery(strQuery);
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

}
