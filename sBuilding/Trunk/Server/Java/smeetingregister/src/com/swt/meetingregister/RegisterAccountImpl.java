/**
 * 
 */
package com.swt.meetingregister;

import java.util.List;

import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;

import com.nhn.utilities.HibernateUtil;
import com.swt.meetingregister.doman.Account;
import com.swt.meetingregister.doman.EmailConfig;

/**
 * @author Tenit
 *
 */
public class RegisterAccountImpl implements RegisterAccount {

	/* (non-Javadoc)
	 * @see com.swt.meetingregister.RegisterAccount#login(java.lang.String, java.lang.String)
	 */
	public Account login(String userName, String passWord) {
		Session session = HibernateUtil.getSession();
		Account account = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM Account WHERE userName = :userName AND passWord = :passWord";
			Query query = session.createQuery(strQuery);
			query.setParameter("userName", userName);
			query.setParameter("passWord", passWord);
			account = (Account) query.uniqueResult();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}
		return account;
	}

	/* (non-Javadoc)
	 * @see com.swt.meetingregister.RegisterAccount#insert(com.swt.meetingregister.doman.Account)
	 */
	public Account insert(Account account) {
		return HibernateUtil.insertObject(account);
	}

	/* (non-Javadoc)
	 * @see com.swt.meetingregister.RegisterAccount#update(com.swt.meetingregister.doman.Account)
	 */
	public Account update(Account account) {
		
		return HibernateUtil.updateObject(account);
	}

	/* (non-Javadoc)
	 * @see com.swt.meetingregister.RegisterAccount#delete(long)
	 */
	public int delete(long accountId) {
		Account account = new Account();
		return HibernateUtil.deleteById(account,accountId);
	}

	/* (non-Javadoc)
	 * @see com.swt.meetingregister.RegisterAccount#getListAccount()
	 */
	@SuppressWarnings("unchecked")
	public List<Account> getListAccount() {
		
		Session session = HibernateUtil.getSession();
		List<Account> result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM Account";
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

	/* (non-Javadoc)
	 * @see com.swt.meetingregister.RegisterAccount#insertEmailConfig(com.swt.meetingregister.doman.EmailConfig)
	 */
	public EmailConfig insertEmailConfig(EmailConfig emailConfig) {
		return HibernateUtil.insertObject(emailConfig);
	}

	/* (non-Javadoc)
	 * @see com.swt.meetingregister.RegisterAccount#getEmailConfig()
	 */
	public EmailConfig getEmailConfig() {
		Session session = HibernateUtil.getSession();
		EmailConfig result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM EmailConfig";
			Query query = session.createQuery(strQuery);
			result = (EmailConfig) query.uniqueResult();
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

}
