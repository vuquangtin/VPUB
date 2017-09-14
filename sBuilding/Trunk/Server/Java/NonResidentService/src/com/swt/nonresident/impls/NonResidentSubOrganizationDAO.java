package com.swt.nonresident.impls;

import java.util.Collections;
import java.util.Comparator;
import java.util.List;

import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;

import com.nhn.utilities.HibernateUtil;
import com.swt.nonresident.INonResidentSubOrganization;
import com.swt.nonresident.domain.NonResidentSubOrganization;

public class NonResidentSubOrganizationDAO implements INonResidentSubOrganization {

	@Override
	public NonResidentSubOrganization insert(NonResidentSubOrganization nonResSubOrg) {
		return HibernateUtil.insertObject(nonResSubOrg);
	}

	@Override
	public NonResidentSubOrganization update(NonResidentSubOrganization nonResSubOrg) {
		return HibernateUtil.updateObject(nonResSubOrg);
	}

	@Override
	public int delete(long nonSubOrgId) {
		NonResidentSubOrganization nonResSubOrg = new NonResidentSubOrganization();
		return HibernateUtil.deleteById(nonResSubOrg, nonSubOrgId);
	}

	@Override
	public NonResidentSubOrganization get(long nonSubOrgId) {
		Session session = HibernateUtil.getSession();
		NonResidentSubOrganization nonResSubOrg = new NonResidentSubOrganization();

		try {
			session.beginTransaction();
			String strQuery = "FROM NonResidentSubOrganization WHERE nonSubOrgId = :nonSubOrgId";
			Query query = session.createQuery(strQuery);

			query.setParameter("nonSubOrgId", nonSubOrgId);
			nonResSubOrg = (NonResidentSubOrganization) query.uniqueResult();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}

		return nonResSubOrg;
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<NonResidentSubOrganization> getListAllSubOrg(long nonOrgId) {
		Session session = HibernateUtil.getSession();
		List<NonResidentSubOrganization> nonResListAllSubOrg = null;

		try {
			session.beginTransaction();
			String strQuery = "FROM NonResidentSubOrganization WHERE nonOrgId = :nonOrgId";
			Query query = session.createQuery(strQuery);

			query.setParameter("nonOrgId", nonOrgId);
			nonResListAllSubOrg = query.list();
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
		if (nonResListAllSubOrg.size() > 0) {
			Collections.sort(nonResListAllSubOrg, new Comparator<NonResidentSubOrganization> (){

				@Override
				public int compare(NonResidentSubOrganization obj1, NonResidentSubOrganization obj2) {
					return (obj1.getNonSubOrgName().compareTo(obj2.getNonSubOrgName()));
				}
			});
		}

		return nonResListAllSubOrg;
	}

}
