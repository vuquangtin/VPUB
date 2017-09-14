package com.swt.timekeeping.impls;

import java.util.ArrayList;
import java.util.List;

import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;

import com.nhn.utilities.HibernateUtil;
import com.swt.sworld.cms.domain.SubOrganization;
import com.swt.sworld.cms.impls.SubOrganizationController;
import com.swt.sworld.ps.domain.Member;
import com.swt.timekeeping.ITimeKeepingFormTimeKeeping;
import com.swt.timekeeping.customer.object.ChipPersonalizationCustom;
import com.swt.timekeeping.customer.object.MemberCustom;

/**
 * TimeKeepingTestDAO implements ITimeKeepingTest
 * 
 * @author minh.nguyen
 *
 */
public class TimeKeepingFormTimeKeepingDAO implements ITimeKeepingFormTimeKeeping {

	@SuppressWarnings("unchecked")
	@Override
	public List<ChipPersonalizationCustom> getListChipPersonalizationCustom() {
		Session session = HibernateUtil.getSession();
		List<Object[]> listObject = null;
		// List<ChipPersonalization> listChipPersonalization = null;

		try {
			session.beginTransaction();
			// String strQuery = "FROM ChipPersonalization";
			String strQuery = "SELECT PsMemberId, SerialNumber FROM ChipPersonalization";
			Query query = session.createQuery(strQuery);

			listObject = query.list();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}

		List<ChipPersonalizationCustom> listChipPersonalizationCustom = new ArrayList<>(listObject.size());
		for (Object[] object : listObject) {
			listChipPersonalizationCustom.add(new ChipPersonalizationCustom((long) object[0], (String) object[1]));
		}

		// for (ChipPersonalization chipPersonalization :
		// listChipPersonalization) {
		// ChipPersonalizationCustom chipPersonalizationCustom = new
		// ChipPersonalizationCustom(
		// chipPersonalization.getPsMemberId(),
		// chipPersonalization.getSerialNumber());
		// listChipPersonalizationCustom.add(chipPersonalizationCustom);
		// }

		return listChipPersonalizationCustom;
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<MemberCustom> getListMemberCustom() {
		Session session = HibernateUtil.getSession();
		// List<Object[]> listObject = null;
		List<Member> listMember = null;

		try {
			session.beginTransaction();
			// String strQuery = "SELECT Id, Code, SubOrgId, FirstName,
			// LastName, Position FROM Member";
			String strQuery = "FROM Member WHERE Active <> 0";
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

		// List<MemberCustom> listMemberCustom = new
		// ArrayList<>(listObject.size());
		// for (Object[] object : listObject) {
		// listMemberCustom.add(new MemberCustom((long) object[0], (String)
		// object[1], (long) object[2],
		// (String) object[3], (String) object[4], (String) object[5]));
		// }

		List<MemberCustom> listMemberCustom = new ArrayList<>(listMember.size());
		for (Member member : listMember) {
			// Lay sub org theo subOrgId, sau do get name cua suborg
			SubOrganization subOrg = SubOrganizationController.Instance.getSubOrgById(member.getSubOrgId());
			
			MemberCustom memberCustom = new MemberCustom(member.getId(), member.getCode(), subOrg.getNames(),
					member.getFirstName(), member.getLastName(), member.getPosition(), member.getIdentityCard());
			listMemberCustom.add(memberCustom);
		}

		return listMemberCustom;
	}

}
