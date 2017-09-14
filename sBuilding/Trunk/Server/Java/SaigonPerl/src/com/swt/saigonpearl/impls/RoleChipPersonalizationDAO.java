package com.swt.saigonpearl.impls;

import java.util.List;

import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;

import com.nhn.utilities.HibernateUtil;
import com.swt.saigonpearl.IRoleChipPersonalization;
import com.swt.saigonpearl.domain.RoleChipPersonalization;
import com.swt.saigonpearl.domain.RoleDeviceDoorGroup;
import com.swt.sworld.ps.domain.Member;

public class RoleChipPersonalizationDAO implements IRoleChipPersonalization {

	@Override
	public RoleChipPersonalization insert(RoleChipPersonalization roleChipPersonalization) {
		return HibernateUtil.insertObject(roleChipPersonalization);
	}

	@Override
	public int insertRoleChipPersonalization(RoleChipPersonalization roleChipPersonalization) {
		return HibernateUtil.insert(roleChipPersonalization);
	}

	@Override
	public RoleChipPersonalization update(RoleChipPersonalization roleChipPersonalization) {
		return HibernateUtil.updateObject(roleChipPersonalization);
	}

	@Override
	public int delete(long roleChipPersonalizationId) {
		RoleChipPersonalization roleChipPersonalization = new RoleChipPersonalization();
		return HibernateUtil.deleteById(roleChipPersonalization, roleChipPersonalizationId);
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<RoleChipPersonalization> getRoleChipPersonalizations() {
		Session session = HibernateUtil.getSession();

		List<RoleChipPersonalization> roleChipPersonalization = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM RoleChipPersonalization";
			Query query = session.createQuery(strQuery);
			roleChipPersonalization = query.list();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}
		return roleChipPersonalization;
	}

	@Override
	public RoleChipPersonalization getRoleChipPersonalizationById(long roleChipPersonalizationId) {
		Session session = HibernateUtil.getSession();

		RoleChipPersonalization roleChipPersonalization = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM RoleChipPersonalization WHERE roleChipPersonalizationId = :roleChipPersonalizationId";
			Query query = session.createQuery(strQuery);
			query.setParameter("roleChipPersonalizationId", roleChipPersonalizationId);
			roleChipPersonalization = (RoleChipPersonalization) query.uniqueResult();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}
		return roleChipPersonalization;
	}
	
	@SuppressWarnings("unchecked")
	@Override
	public List<RoleChipPersonalization> getRoleChipPersonalizationsByRoleId(long roleId) {
		Session session = HibernateUtil.getSession();

		List<RoleChipPersonalization> roleChipPersonalizations = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM RoleChipPersonalization WHERE roleId = :roleId";
			Query query = session.createQuery(strQuery);
			query.setParameter("roleId", roleId);
			roleChipPersonalizations =query.list();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}
		return roleChipPersonalizations;
	}

	/* (non-Javadoc)
	 * @see com.swt.saigonpearl.IRoleChipPersonalization#getListMember(long, long)
	 */
	@SuppressWarnings("unchecked")
	@Override
	public List<Member> getListMember(long roleId, long subOrgId) {
		Session session = HibernateUtil.getSession();
		List<Member> result = null;
		try {
			session.getTransaction().begin();
				//call storeprocedure
			Query query = session.getNamedQuery("getMemberList"/*name procedure in object member*/).setParameter("roleid", roleId).setParameter("suborgid", subOrgId);
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

	/* get list group id by role id
	 * @see com.swt.saigonpearl.IRoleChipPersonalization#getListGroupByRoleId(long)
	 */
	@SuppressWarnings("unchecked")
	@Override
	public List<RoleDeviceDoorGroup> getListGroupByRoleId(long roleId) {
		Session session = HibernateUtil.getSession();
		List<RoleDeviceDoorGroup> lstGroupId = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM RoleDeviceDoorGroup WHERE roleId = :roleId";
			Query query = session.createQuery(strQuery);
			query.setParameter("roleId", roleId);
			lstGroupId = query.list();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}
		return lstGroupId;
	}
}
