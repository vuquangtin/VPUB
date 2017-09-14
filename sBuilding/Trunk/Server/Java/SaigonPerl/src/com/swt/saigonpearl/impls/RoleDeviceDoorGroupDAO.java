package com.swt.saigonpearl.impls;

import java.util.List;

import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;

import com.nhn.utilities.HibernateUtil;
import com.swt.saigonpearl.IRoleDeviceDoorGroup;
import com.swt.saigonpearl.domain.RoleDeviceDoorGroup;

public class RoleDeviceDoorGroupDAO implements IRoleDeviceDoorGroup {

	@Override
	public RoleDeviceDoorGroup insert(RoleDeviceDoorGroup roleDeviceDoorGroup) {
		return HibernateUtil.insertObject(roleDeviceDoorGroup);
	}

	@Override
	public RoleDeviceDoorGroup update(RoleDeviceDoorGroup roleDeviceDoorGroup) {
		return HibernateUtil.updateObject(roleDeviceDoorGroup);
	}

	@Override
	public int delete(long roleDeviceDoorGroupId) {
		RoleDeviceDoorGroup roleDeviceDoorGroup = new RoleDeviceDoorGroup();
		return HibernateUtil.deleteById(roleDeviceDoorGroup, roleDeviceDoorGroupId);
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<RoleDeviceDoorGroup> getRoleDeviceDoorGroups() {
		Session session = HibernateUtil.getSession();

		List<RoleDeviceDoorGroup> roleDeviceDoorGroup = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM RoleDeviceDoorGroup";
			Query query = session.createQuery(strQuery);
			roleDeviceDoorGroup = query.list();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}
		return roleDeviceDoorGroup;
	}

	@Override
	public RoleDeviceDoorGroup getRoleDeviceDoorGroupById(long roleDeviceDoorGroupId) {
		Session session = HibernateUtil.getSession();

		RoleDeviceDoorGroup roleDeviceDoorGroup = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM RoleDeviceDoorGroup WHERE roleDeviceDoorGroupId = :roleDeviceDoorGroupId";
			Query query = session.createQuery(strQuery);
			query.setParameter("roleDeviceDoorGroupId", roleDeviceDoorGroupId);
			roleDeviceDoorGroup = (RoleDeviceDoorGroup) query.uniqueResult();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}
		return roleDeviceDoorGroup;
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<RoleDeviceDoorGroup> getDeviceDoorGroupByRoleId(long roleId) {
		Session session = HibernateUtil.getSession();
		List<RoleDeviceDoorGroup> result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM RoleDeviceDoorGroup WHERE roleId = :roleId";
			Query query = session.createQuery(strQuery);
			query.setParameter("roleId", roleId);
			result = query.list();
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
	public List<RoleDeviceDoorGroup> getDeviceDoorGroupByGroupId(long deviceDoorGroupId) {
		Session session = HibernateUtil.getSession();
		List<RoleDeviceDoorGroup> result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM RoleDeviceDoorGroup WHERE devicedoorgroupid = :deviceDoorGroupId";
			Query query = session.createQuery(strQuery);
			query.setParameter("deviceDoorGroupId", deviceDoorGroupId);
			result = query.list();
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

	/*
	 * (non-Javadoc)
	 * 
	 * @see
	 * com.swt.saigonpearl.IRoleDeviceDoorGroup#deleteRoleDeviceDoorGroup(long,
	 * long)
	 */
	@Override
	public void deleteRoleDeviceDoorGroup(long roleId, long deviceDoorGroupId) {
		Session session = HibernateUtil.getSession();

		try {
			session.getTransaction().begin();
			String strQuery = "DELETE RoleDeviceDoorGroup WHERE roleid = :roleId and devicedoorgroupid = :deviceDoorGroupId";
			Query query = session.createQuery(strQuery);
			query.setParameter("roleId", roleId);
			query.setParameter("deviceDoorGroupId", deviceDoorGroupId);
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
