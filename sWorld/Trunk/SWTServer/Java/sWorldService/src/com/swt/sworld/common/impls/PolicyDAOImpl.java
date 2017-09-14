/**
 * 
 */
package com.swt.sworld.common.impls;

import java.util.List;

import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;

import com.nhn.utilities.HibernateUtil;
import com.swt.sworld.common.IPolicyDAO;
import com.swt.sworld.common.domain.PolicySworld;

/**
 * @author sang.do
 *
 */
public class PolicyDAOImpl implements IPolicyDAO {

	@SuppressWarnings("unchecked")
	@Override
	public List<Long> getModuleByGroupId(long groupid) {
		Session session = HibernateUtil.getSession();
		
		List<Long> result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "SELECT ModuleId FROM Policy WHERE GroupId = :groupid";
			Query query = session.createQuery(strQuery);
			query.setParameter("groupid", groupid);
			
			result = query.list();
			
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		}
		finally
		{
			session.close();
		}
		
		return result;
	}

	@Override
	public PolicySworld addPolicy(PolicySworld pol) {
		return HibernateUtil.insertObject(pol);
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<PolicySworld> getAllPolicyByGroupId(long groupid) {
		Session session = HibernateUtil.getSession();
		
		List<PolicySworld> result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM PolicySworld WHERE GroupId = :groupid";
			Query query = session.createQuery(strQuery);
			query.setParameter("groupid", groupid);
			
			result = query.list();
			
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		}
		finally
		{
			session.close();
		}
		
		return result;
	}

	@Override
	public PolicySworld updatePolicy(PolicySworld pol) {
		return HibernateUtil.updateObject(pol);
	}
	
	@Override
	public int removePolicy(long policyId) {
		PolicySworld policy = new PolicySworld();
		return HibernateUtil.deleteById(policy, policyId);
	}
}
