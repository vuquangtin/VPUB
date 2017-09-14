package com.swt.timekeeping.impls;

import java.util.Date;

import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;

import com.nhn.utilities.HibernateUtil;
import com.swt.timekeeping.ITimekeepingDailyConfig;
import com.swt.timekeeping.domain.DailyConfig;
/**
 *  TimeKeepingDailyConfigDAO implements ITimekeepingDailyConfig
 * @author Trang-PC
 *
 */
public class TimeKeepingDailyConfigDAO implements ITimekeepingDailyConfig{

	@Override
	public DailyConfig insert(DailyConfig daily) {
		return HibernateUtil.insertObject(daily);
	}
	
	@SuppressWarnings({ "deprecation" })
	@Override
	public DailyConfig getDailyConfigByDate(Date date, long orgId) {
		Session session = HibernateUtil.getSession();

		DailyConfig result = new DailyConfig();
		try {
			session.getTransaction().begin();
			int y = date.getYear()+1900;
			int m = date.getMonth()+1;
			int d = date.getDate();
			String dateBegin = y+"-"+m+"-"+(d<10?"0"+d:d)+" 00:00:00";
			String dateEnd = y+"-"+m+"-"+(d<10?"0"+d:d)+" 23:59:59";
			String strQuery = "FROM DailyConfig WHERE orgId = "+ orgId  +" AND date BETWEEN '"+dateBegin+"' AND '"+dateEnd+"'";

			
			Query query = session.createQuery(strQuery);
			result =  (DailyConfig) query.uniqueResult();
			
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
