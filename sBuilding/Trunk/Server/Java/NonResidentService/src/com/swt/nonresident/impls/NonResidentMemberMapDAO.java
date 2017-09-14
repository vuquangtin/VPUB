package com.swt.nonresident.impls;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;
import java.util.HashMap;
import java.util.LinkedList;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;

import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;

import com.nhn.utilities.HibernateUtil;
import com.swt.nonresident.INonResidentMemberMap;
import com.swt.nonresident.customObject.NonResidentMemberMapCustom;
import com.swt.nonresident.domain.NonResidentMemberMap;
import com.swt.sworld.ps.domain.Member;

public class NonResidentMemberMapDAO implements INonResidentMemberMap {

	@Override
	public NonResidentMemberMap insert(NonResidentMemberMap nonResMemMap) {
		return HibernateUtil.insertObject(nonResMemMap);
	}

	@Override
	public NonResidentMemberMap update(NonResidentMemberMap nonResMemMap) {
		return HibernateUtil.updateObject(nonResMemMap);
	}

	@Override
	public int delete(long nonMemMapId) {
		NonResidentMemberMap nonResMemMap = new NonResidentMemberMap();
		return HibernateUtil.deleteById(nonResMemMap, nonMemMapId);
	}

	@Override
	public NonResidentMemberMap get(long nonMemMapId) {
		Session session = HibernateUtil.getSession();
		NonResidentMemberMap nonResMemMap = new NonResidentMemberMap();

		try {
			session.beginTransaction();
			String strQuery = "FROM NonResidentMemberMap WHERE nonMemMapId = :nonMemMapId";
			Query query = session.createQuery(strQuery);

			query.setParameter("nonMemMapId", nonMemMapId);
			nonResMemMap = (NonResidentMemberMap) query.uniqueResult();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}

		return nonResMemMap;
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<NonResidentMemberMapCustom> getListAllMemMap(long nonOrgId) {
		Session session = HibernateUtil.getSession();
		Map<NonResidentMemberMap, String> nonResMapAllMemMapCustom = new HashMap<NonResidentMemberMap, String>();
		List<NonResidentMemberMapCustom> nonResListAllMemMapCustom = new ArrayList<>();
		List<NonResidentMemberMap> nonResListAllMemMap = null;

		try {
			session.beginTransaction();
			String strQuery = "FROM NonResidentMemberMap WHERE nonOrgId = :nonOrgId";
			Query query = session.createQuery(strQuery);

			query.setParameter("nonOrgId", nonOrgId);
			nonResListAllMemMap = query.list();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}

		List<Member> listMember = getListMember(nonResListAllMemMap);
		if (listMember.size() > 0) {
			for (int i = 0; i < listMember.size(); i++) {
				Member member = listMember.get(i);
				if (!member.getActive()) {
					listMember.remove(i);
					nonResListAllMemMap.remove(i);
					continue;
				} else {
					nonResMapAllMemMapCustom.put(nonResListAllMemMap.get(i),
							member.getLastName() + " " + member.getFirstName());
				}
			}

			if (nonResMapAllMemMapCustom.size() > 0) {
				// Sort lai list theo ten
				// Dua vao Map -> List<Map> usort -> Sort -> List<Map> sorted -> resut
				// 1. List<Map> usort
				List<Map.Entry<NonResidentMemberMap, String>> nonResListMapAllMemMapCustom = new LinkedList<Map.Entry<NonResidentMemberMap, String>>(
						nonResMapAllMemMapCustom.entrySet());
				// 2. Sort
				Collections.sort(nonResListMapAllMemMapCustom, new Comparator<Map.Entry<NonResidentMemberMap, String>>() {

					@Override
					public int compare(Entry<NonResidentMemberMap, String> obj1, Entry<NonResidentMemberMap, String> obj2) {
						return (obj1.getValue().compareTo(obj2.getValue()));
					}

				});
				// 3. Result
				for (Map.Entry<NonResidentMemberMap, String> obj : nonResListMapAllMemMapCustom) {
					nonResListAllMemMapCustom.add(new NonResidentMemberMapCustom(obj.getKey(), obj.getValue()));
				}
			}
		}

		return nonResListAllMemMapCustom;
	}

	@SuppressWarnings("unchecked")
	public List<Member> getListMember(List<NonResidentMemberMap> nonResListAllMemMap) {
		Session session = HibernateUtil.getSession();
		List<Member> listMember = null;
		StringBuilder strQueryListMemberId = new StringBuilder("(");

		for (int i = 0; i < nonResListAllMemMap.size(); i++) {
			if (i == 0) {
				strQueryListMemberId.append(nonResListAllMemMap.get(i).getNonMemMapId());
			} else {
				strQueryListMemberId.append(", " + nonResListAllMemMap.get(i).getNonMemMapId());
			}
		}

		strQueryListMemberId.append(")");
		if (strQueryListMemberId.toString().equals("()")) {
			return new ArrayList<>();
		}

		try {
			session.beginTransaction();
			String strQuery = "FROM Member WHERE Id IN " + strQueryListMemberId.toString();
			Query query = session.createQuery(strQuery);

			listMember = query.list();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}

		return listMember;
	}
}
