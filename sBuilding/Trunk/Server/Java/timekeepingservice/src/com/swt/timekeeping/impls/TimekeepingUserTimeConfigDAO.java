
package com.swt.timekeeping.impls;

import java.util.List;

import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;

import com.nhn.utilities.HibernateUtil;
import com.swt.timekeeping.ITimekeepingUserTimeConfig;
import com.swt.timekeeping.domain.UserTimeConfig;
/**
 * TimekeepingUserTimeConfigDAO implements ITimekeepingUserTimeConfig
 * @author Trang-PC
 *
 */
public class TimekeepingUserTimeConfigDAO implements ITimekeepingUserTimeConfig{

	@Override
	public UserTimeConfig insert(UserTimeConfig userTimeConfig) {
		return HibernateUtil.insertObject(userTimeConfig);
	}

	@Override
	public UserTimeConfig update(UserTimeConfig userTimeConfig) {
		return HibernateUtil.updateObject(userTimeConfig);
	}

	@Override
	public int delete(List<Long> shList) {
		int cnt = 0;
		for(long sh : shList){
			UserTimeConfig timeKeepingConfig = new UserTimeConfig();
			cnt += HibernateUtil.deleteById(timeKeepingConfig, sh);
		}
		
		return cnt > 0 ? 0 : 1;
	}

	@Override
	public UserTimeConfig getUserTimeConfigById(long id) {
		Session session = HibernateUtil.getSession();

		UserTimeConfig result = new UserTimeConfig();
		try {
			session.getTransaction().begin();
			String strQuery = "FROM UserTimeConfig WHERE id = :confid";
			Query query = session.createQuery(strQuery);
			query.setParameter("confid", id);
		
			result = (UserTimeConfig) query.uniqueResult();
			
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

	@SuppressWarnings("unchecked")
	@Override
	public List<UserTimeConfig> getListUserTimeConfigByMemberId(long orgId,
			long memberId) {
		Session session = HibernateUtil.getSession();

		List<UserTimeConfig> result =  null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM UserTimeConfig WHERE orgId = :orgid AND memberId = :memberid";
			Query query = session.createQuery(strQuery);
			query.setParameter("orgid", orgId);
			query.setParameter("memberid", memberId);
		
			result =  query.list();
			
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

	/* get list user timeconfig by orgid for delete
	 *
	 */
	@Override
	public void deleteListUserTimeConfigOrgId(long orgId) {
		Session session = HibernateUtil.getSession();

		try {
			session.getTransaction().begin();
			String strQuery = "delete FROM UserTimeConfig WHERE orgId = :orgid";
			Query query = session.createQuery(strQuery);
			query.setParameter("orgid", orgId);
		
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
	}

}
