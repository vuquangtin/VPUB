package com.swt.nonresident.impls;

import java.util.Collections;
import java.util.Comparator;
import java.util.List;

import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;

import com.nhn.utilities.HibernateUtil;
import com.swt.nonresident.INonResidentOrganization;
import com.swt.nonresident.domain.NonResidentOrganization;

public class NonResidentOrganizationDAO implements INonResidentOrganization {

	@Override
	public NonResidentOrganization insert(NonResidentOrganization nonResOrg) {
		return HibernateUtil.insertObject(nonResOrg);
	}

	@Override
	public NonResidentOrganization update(NonResidentOrganization nonResOrg) {
		return HibernateUtil.updateObject(nonResOrg);
	}

	@Override
	public int delete(long nonOrgId) {
		NonResidentOrganization nonResOrg = new NonResidentOrganization();
		return HibernateUtil.deleteById(nonResOrg, nonOrgId);
	}

	@Override
	public NonResidentOrganization get(long nonOrgId) {
		Session session = HibernateUtil.getSession();
		NonResidentOrganization nonResOrg = new NonResidentOrganization();

		try {
			session.beginTransaction();
			String strQuery = "FROM NonResidentOrganization WHERE nonOrgId = :nonOrgId";
			Query query = session.createQuery(strQuery);

			query.setParameter("nonOrgId", nonOrgId);
			nonResOrg = (NonResidentOrganization) query.uniqueResult();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}

		return nonResOrg;
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<NonResidentOrganization> getListAllOrg(String orgCode) {
		Session session = HibernateUtil.getSession();
		List<NonResidentOrganization> nonResListAllOrg = null;

		try {
			session.beginTransaction();
			String strQuery = "FROM NonResidentOrganization WHERE orgCode = :orgCode";
			Query query = session.createQuery(strQuery);

			query.setParameter("orgCode", orgCode);
			nonResListAllOrg = query.list();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}

		// Sort
		if (nonResListAllOrg.size() > 0)
			Collections.sort(nonResListAllOrg, new Comparator<NonResidentOrganization>() {

				@Override
				public int compare(NonResidentOrganization obj1, NonResidentOrganization obj2) {
					return (obj1.getNonOrgName().compareTo(obj2.getNonOrgName()));
				}
			});

		return nonResListAllOrg;
	}
}
