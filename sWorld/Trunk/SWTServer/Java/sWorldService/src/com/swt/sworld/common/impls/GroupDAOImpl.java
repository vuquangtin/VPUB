/**
 * 
 */
package com.swt.sworld.common.impls;

import java.util.List;

import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;

import com.nhn.utilities.HibernateUtil;
import com.swt.sworld.common.IGroupDAO;
import com.swt.sworld.common.domain.GroupSworld;


/**
 * @author sang.do
 *
 */
public class GroupDAOImpl implements IGroupDAO {

	@SuppressWarnings("unchecked")
	@Override
	public List<GroupSworld> getGroupList() {
		Session session = HibernateUtil.getSession();
		
		List<GroupSworld> result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM GroupSworld";
			Query query = session.createQuery(strQuery);
			
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
	public GroupSworld getById(long groupid) {
		Session session = HibernateUtil.getSession();
		
		GroupSworld result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM GroupSworld WHERE id = :groupid";
			Query query = session.createQuery(strQuery);
			query.setParameter("groupid", groupid);
			
			result = (GroupSworld) query.uniqueResult();
			
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
	public GroupSworld addGroup(GroupSworld groupSworld) {
		return HibernateUtil.insertObject(groupSworld);
	
	}

	@Override
	public GroupSworld updateGroup(GroupSworld groupSworld) {
		return HibernateUtil.updateObject(groupSworld);
	}

	@Override
	public int deleteGroup(long groupid) {
		GroupSworld gr = new GroupSworld();
		return HibernateUtil.deleteById(gr, groupid);
	}

}
