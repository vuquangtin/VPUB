package com.swt.meeting.impls;

import java.util.ArrayList;
import java.util.List;

import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;
import org.hibernate.criterion.Restrictions;

import com.nhn.utilities.HibernateUtil;
import com.swt.meeting.IOrganizationMeeting;
import com.swt.meeting.domain.MeetingInvitationOrgOther;
import com.swt.meeting.domain.OrganizationMeeting;
import com.swt.meeting.lib.tm.CommonFunction;
import com.swt.meeting.lib.tm.Constant;

public class OrganizationMeetingDAO implements IOrganizationMeeting {
	@Override
	public OrganizationMeeting insert(OrganizationMeeting organizationMeeting) {
		return HibernateUtil.insertObject(organizationMeeting);
	}

	@Override
	public OrganizationMeeting update(OrganizationMeeting organizationMeeting) {
		return HibernateUtil.updateObject(organizationMeeting);
	}

	@Override
	public int delete(long organizationMeetingId) {
		OrganizationMeeting organizationMeeting = new OrganizationMeeting();
		return HibernateUtil.deleteById(organizationMeeting, organizationMeetingId);
	}

	// get Organization meeting by id
	@Override
	public OrganizationMeeting getOrganizationMeetingById(long organizationMeetingId) {
		Session session = HibernateUtil.getSession();

		OrganizationMeeting result = new OrganizationMeeting();
		try {
			session.getTransaction().begin();
			String strQuery = "FROM OrganizationMeeting WHERE id = :confid";
			Query query = session.createQuery(strQuery);
			query.setParameter("confid", organizationMeetingId);

			result = (OrganizationMeeting) query.uniqueResult();

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
	public List<OrganizationMeeting> getAllOrganizationMeeting() {
		Session session = HibernateUtil.getSession();

		List<OrganizationMeeting> result = new ArrayList<OrganizationMeeting>();
		try {
			session.getTransaction().begin();
			String strQuery = "FROM OrganizationMeeting ORDER BY name DESC";
			Query query = session.createQuery(strQuery);

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
	public List<OrganizationMeeting> getAllOrganizationMeetingASC() {
		Session session = HibernateUtil.getSession();

		List<OrganizationMeeting> result = new ArrayList<OrganizationMeeting>();
		try {
			session.getTransaction().begin();
			String strQuery = "FROM OrganizationMeeting ORDER BY name ASC";
			Query query = session.createQuery(strQuery);

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
	public List<OrganizationMeeting> getAllOrganizationPartaker() {
		Session session = HibernateUtil.getSession();
		
		List<OrganizationMeeting> result = new ArrayList<OrganizationMeeting>();
		try {
			session.getTransaction().begin();
			String strQuery = "FROM OrganizationMeeting Where meeting = 0";
			Query query = session.createQuery(strQuery);
			
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
	@Override
	@SuppressWarnings("unchecked")
	public List<OrganizationMeeting> getByName(String name, int meetingType) {
		String sql = "FROM OrganizationMeeting WHERE name = '" + name + "' AND meeting = " +Constant.ORG_OTHER;
		List<OrganizationMeeting> list = (List<OrganizationMeeting>) CommonFunction.INSTANCE
				.getByQuery(sql);
		return list;
	}

	// lay thong tin to chuc khac duoc them vao bang barcode
	@Override
	@SuppressWarnings("unchecked")
	public MeetingInvitationOrgOther getByBarcode(String barcode) {
		String sql = "FROM MeetingInvitationOrgOther WHERE barcode = '" + barcode + "'";
		List<MeetingInvitationOrgOther> list = (List<MeetingInvitationOrgOther>) CommonFunction.INSTANCE
				.getByQuery(sql);
		if (list != null) {
			if (list.size() == 1) {
				return list.get(0);
			}
		}
		return null;
	}

	/**
	 * @author My.nguyen Kiem tra orgmeting co id nay chua co: khong insert duoc
	 *         khong: cho insert getOrganizationMeetingByReferenceId
	 * 
	 * @param organizationMeetingId
	 * @return OrganizationMeeting
	 */
	@Override
	@SuppressWarnings("unchecked")
	public List<OrganizationMeeting> getOrganizationMeetingByReferenceId(long getOrganizationMeetingByReferenceId) {
		Session session = HibernateUtil.getSession();

		List<OrganizationMeeting> result = new ArrayList<>();
		try {
			session.getTransaction().begin();
			String strQuery = "FROM OrganizationMeeting WHERE referenceId = :confid";
			Query query = session.createQuery(strQuery);
			query.setParameter("confid", getOrganizationMeetingByReferenceId);

//			result = (OrganizationMeeting) query.uniqueResult();
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

	/**
	 * @author My.nguyen
	 */
	@Override
	public int edit(OrganizationMeeting organizationMeetingNew) {
		int result = -1;
		Session session = HibernateUtil.getSession();
		try {
			session.getTransaction().begin();

			String strQuery = "UPDATE OrganizationMeeting " + "SET name = :name"
					+ ", code = :code"
					+ ", meeting = :meeting"
					+ " WHERE referenceId = :referenceId ";
			Query query = session.createQuery(strQuery);
			query.setParameter("referenceId", organizationMeetingNew.getReferenceId());
			query.setParameter("name", organizationMeetingNew.getName());
			query.setParameter("code", organizationMeetingNew.getCode());
			query.setParameter("meeting", organizationMeetingNew.getTypeOrg());

			result = query.executeUpdate();

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

	/**
	 * @author My.nguyen
	 */
	@Override
	public int deleteByReferenceId(long organizationLCTId) {
		int result = -1;
		Session session = HibernateUtil.getSession();
		try {
			session.getTransaction().begin();

			String strQuery = "DELETE OrganizationMeeting WHERE referenceId = :referenceId ";
			Query query = session.createQuery(strQuery);
			query.setParameter("referenceId", organizationLCTId);

			result = query.executeUpdate();

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

	@Override
	public OrganizationMeeting getByName(String name) {
		Session session = HibernateUtil.getSession();
		return (OrganizationMeeting) session.createCriteria(OrganizationMeeting.class)
				.add(Restrictions.eq("name", name)).uniqueResult();
	}

}
