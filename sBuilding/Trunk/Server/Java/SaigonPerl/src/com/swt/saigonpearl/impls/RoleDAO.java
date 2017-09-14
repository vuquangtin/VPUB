package com.swt.saigonpearl.impls;

import java.util.List;

import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;

import com.nhn.utilities.HibernateUtil;
import com.swt.saigonpearl.IRole;
import com.swt.saigonpearl.domain.RoleDTO;

public class RoleDAO implements IRole {

	@Override
	public RoleDTO insert(RoleDTO role) {
		return HibernateUtil.insertObject(role);
	}

	@Override
	public RoleDTO update(RoleDTO role) {
		return HibernateUtil.updateObject(role);
	}

	@Override
	public int delete(long roleId) {
		RoleDTO role = new RoleDTO();
		return HibernateUtil.deleteById(role, roleId);
	}


	@Override
	public RoleDTO getRoleById(long roleId) {
		Session session = HibernateUtil.getSession();

		RoleDTO role = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM RoleDTO WHERE roleId = :roleId";
			Query query = session.createQuery(strQuery);
			query.setParameter("roleId", roleId);
			role = (RoleDTO) query.uniqueResult();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}
		return role;
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<RoleDTO> getRoles() {
		Session session = HibernateUtil.getSession();
		
		List<RoleDTO> roleDTO = null;
				try {
					session.getTransaction().begin();
					String strQuery = "FROM RoleDTO";
					Query query = session.createQuery(strQuery);
					roleDTO = query.list();
					session.getTransaction().commit();
				} catch (HibernateException e) {
					session.getTransaction().rollback();
					e.printStackTrace();
				} finally {
					session.flush();
					session.clear();
					session.close();
				}
				return roleDTO;
	}
}
