/**
 * 
 */
package com.swt.sworld.common.impls;

import java.util.List;

import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;

import com.nhn.utilities.HibernateUtil;
import com.swt.sworld.common.IUserDAO;
import com.swt.sworld.common.domain.UserSworld;
import com.swt.sworld.communication.customer.object.UserFilterDto;
import com.swt.sworld.kms.impls.Sha1Hashing;

/**
 * The class implement IUserDAO The class communicate with database directly
 * 
 * @author sang.do
 * 
 */
public class UserDAOImpl implements IUserDAO {

	private Sha1Hashing SHA1 = new Sha1Hashing();

	/**
	 * get sworld user
	 * 
	 * @param username
	 *            : user name
	 * @param pwd
	 *            : password
	 * @return UserSworld object
	 */
	@Override
	public UserSworld getUserByUserNameAndPwd(String username, String pwd) {
		Session session = HibernateUtil.getSession();

		UserSworld result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM UserSworld WHERE  UserName = :username AND PasswordHash = :pwd";
			Query query = session.createQuery(strQuery);
			query.setParameter("username", username);
			query.setParameter("pwd", SHA1.encryptPassword(pwd));

			result = (UserSworld) query.uniqueResult();

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
	 * find the all users matching with filter values
	 * 
	 * @param UserFilterDto
	 *            : filter object
	 * @return list UserSworld object
	 */
	@SuppressWarnings("unchecked")
	@Override
	public List<UserSworld> getUserList(UserFilterDto filter) {
		Session session = HibernateUtil.getSession();

		List<UserSworld> result = null;
		try {
			String search = filter.clone();
			// get all users
			if (search == "") {
				session.getTransaction().begin();
				String strQuery = "FROM UserSworld";
				Query query = session.createQuery(strQuery);
				result = query.list();
			} else {
				if (filter.getGroupId() != -1) {
					session.getTransaction().begin();
					String strQuery = "FROM UserSworld WHERE " + search;
					Query query = session.createQuery(strQuery);
					result = query.list();
				} else {
					session.getTransaction().begin();
					String strQuery = "FROM UserSworld WHERE Status = :status";
					Query query = session.createQuery(strQuery);
					query.setParameter("status", filter.getUserStatus());
					result = query.list();
				}
			}

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
	public UserSworld getUserByUserId(long userid) {
		Session session = HibernateUtil.getSession();

		UserSworld result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM UserSworld WHERE id = :userid";
			Query query = session.createQuery(strQuery);
			query.setParameter("userid", userid);

			result = (UserSworld) query.uniqueResult();

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
	public UserSworld addUser(UserSworld userSworld) {
		userSworld.setPasswordHash(SHA1.encryptPassword(userSworld
				.getPasswordHash()));
		return HibernateUtil.insertObject(userSworld);
	}

	@Override
	public int updateUser(UserSworld userSworld) {
		userSworld.setPasswordHash(SHA1.encryptPassword(userSworld
				.getPasswordHash()));
		return HibernateUtil.update(userSworld);
	}

	@Override
	public int changeUserGroup(long userid, long newgroupid) {
		Session session = HibernateUtil.getSession();

		int result = -99;
		try {
			session.getTransaction().begin();
			String strQuery = "UPDATE UserSworld SET groupId = :newgroupid WHERE id = :userid";
			Query query = session.createQuery(strQuery);
			query.setParameter("userid", userid);
			query.setParameter("newgroupid", newgroupid);
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
	public long lockUser(long userid) {
		Session session = HibernateUtil.getSession();

		int result = -99;
		try {
			session.getTransaction().begin();
			String strQuery = "UPDATE UserSworld SET status = :status WHERE id = :userid";
			Query query = session.createQuery(strQuery);
			query.setParameter("userid", userid);
			query.setParameter("status", 1);
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
	public int resetPassword(long userid, String newpass) {
		Session session = HibernateUtil.getSession();

		int result = -99;
		try {
			session.getTransaction().begin();
			String strQuery = "UPDATE UserSworld SET passwordHash = :newpass WHERE id = :userid";
			Query query = session.createQuery(strQuery);
			query.setParameter("userid", userid);
			query.setParameter("newpass", SHA1.encryptPassword(newpass));
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
	public long unlockUser(long userid) {
		Session session = HibernateUtil.getSession();

		int result = -99;
		try {
			session.getTransaction().begin();
			String strQuery = "UPDATE UserSworld SET status = :status WHERE id = :userid";
			Query query = session.createQuery(strQuery);
			query.setParameter("userid", userid);
			query.setParameter("status", 0);
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
	public long removeUser(long userid) {
		Session session = HibernateUtil.getSession();

		int result = -99;
		try {
			session.getTransaction().begin();
			String strQuery = "UPDATE UserSworld SET status = :status WHERE id = :userid";
			Query query = session.createQuery(strQuery);
			query.setParameter("userid", userid);
			query.setParameter("status", 2);
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
	public UserSworld getUserByUserName(String user) {
		Session session = HibernateUtil.getSession();

		UserSworld result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM UserSworld WHERE  userName = :user";
			Query query = session.createQuery(strQuery);
			query.setParameter("user", user);

			result = (UserSworld) query.uniqueResult();

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
	public int deleteUser(UserSworld userSworld, long userid) {
		return HibernateUtil.deleteById(userSworld, userid);
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<UserSworld> getUser(long groupid) {
		Session session = HibernateUtil.getSession();

		List<UserSworld> result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM UserSworld WHERE groupId = :groupid";
			Query query = session.createQuery(strQuery);
			query.setParameter("groupid", groupid);

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
	public UserSworld getGroupIDByUserId(long userid) {
		Session session = HibernateUtil.getSession();

		UserSworld result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM UserSworld WHERE id = :userid";
			Query query = session.createQuery(strQuery);
			query.setParameter("userid", userid);
			result = (UserSworld) query.uniqueResult();
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
	public UserSworld getUserByUserNameAndPassWord(String username, String pwd) {
		Session session = HibernateUtil.getSession();

		UserSworld result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM UserSworld WHERE userName = :username AND passwordHash = :pwd";
			Query query = session.createQuery(strQuery);
			query.setParameter("username", username);
			query.setParameter("pwd", SHA1.encryptPassword(pwd));
			result = (UserSworld) query.uniqueResult();
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
	public List<UserSworld> getUsersMerchant(long orgid) {
		Session session = HibernateUtil.getSession();

		List<UserSworld> result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM UserSworld WHERE orgid = :orgid";
			Query query = session.createQuery(strQuery);
			query.setParameter("orgid", orgid);

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
	public UserSworld getUserByMemberId(long memberId) {
		Session session = HibernateUtil.getSession();

		UserSworld result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM UserSworld WHERE memberid = :memberId";
			Query query = session.createQuery(strQuery);
			query.setParameter("memberId", memberId);

			result = (UserSworld) query.uniqueResult();

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
	public int deleteUserShopping(long userId) {
		UserSworld user = new UserSworld();
		return HibernateUtil.deleteById(user, userId);
	}

}
