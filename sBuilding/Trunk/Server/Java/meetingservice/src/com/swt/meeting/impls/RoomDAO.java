package com.swt.meeting.impls;

import java.util.ArrayList;
import java.util.List;

import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;
import org.hibernate.criterion.Restrictions;

import com.nhn.utilities.HibernateUtil;
import com.swt.meeting.IRoom;
import com.swt.meeting.domain.Room;

public class RoomDAO implements IRoom {

	@Override
	public Room insert(Room room) {
		return HibernateUtil.insertObject(room);
	}

	@Override
	public Room update(Room room) {
		return HibernateUtil.updateObject(room);
	}

	@Override
	public int delete(long roomId) {
		Room room = new Room();
		return HibernateUtil.deleteById(room, roomId);
	}

	@Override
	public Room getRoomById(long roomId) {
		Session session = HibernateUtil.getSession();

		Room result = new Room();
		try {
			session.getTransaction().begin();
			String strQuery = "FROM Room WHERE id = :confid";
			Query query = session.createQuery(strQuery);
			query.setParameter("confid", roomId);

			result = (Room) query.uniqueResult();

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
	public List<Room> getAllRoom() {
		Session session = HibernateUtil.getSession();

		List<Room> result = new ArrayList<Room>();
		try {
			session.getTransaction().begin();
			String strQuery = "FROM Room";
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
	public Room getRoomByName(String name) {
		Session session = HibernateUtil.getSession();
		return (Room) session.createCriteria(Room.class).add(Restrictions.eq("name", name)).uniqueResult();
	}

	@Override
	public Room getByReferenceId(long referenceId) {
		Session session = HibernateUtil.getSession();
		return (Room) session.createCriteria(Room.class).add(Restrictions.eq("referenceId", referenceId)).uniqueResult();
	}

}
