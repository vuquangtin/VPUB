package com.swt.timekeeping.impls;

import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;

import com.nhn.error.ErrorCodeSworld;
import com.nhn.utilities.HibernateUtil;
import com.swt.timekeeping.ITimeKeepingHolidayConfig;
import com.swt.timekeeping.customer.object.HolidayResultForGet;
import com.swt.timekeeping.domain.HolidayConfig;

/**
 * TimeKeepingHolidayConfigDAO implements ITimeKeepingHolidayConfig
 * 
 * @author minh.nguyen
 *
 */
public class TimeKeepingHolidayConfigDAO implements ITimeKeepingHolidayConfig {

	// Them ngay le
	@Override
	public HolidayConfig insertHolidayConfig(HolidayResultForGet hResult) {
		DateFormat dateFormat = new SimpleDateFormat("dd/MM/yyyy");
		HolidayConfig hConfig = new HolidayConfig();

		hConfig.setHolidayName(hResult.getHolidayName());
		try {
			hConfig.setHolidayStart(dateFormat.parse(hResult.getHolidayStart()));
			hConfig.setHolidayEnd(dateFormat.parse(hResult.getHolidayEnd()));
		} catch (ParseException e) {
			e.printStackTrace();
		}
		hConfig.setHolidayDescription(hResult.getHolidayDescription());
		hConfig.setOrgId(hResult.getOrgId());

		return HibernateUtil.insertObject(hConfig);
	}

	// Cap nhat/chinh sua ngay le
	@Override
	public HolidayConfig updateHolidayConfig(HolidayResultForGet hResult) {
		DateFormat dateFormat = new SimpleDateFormat("dd/MM/yyyy");
		HolidayConfig hConfig = new HolidayConfig();

		hConfig.setHolidayId(hResult.getHolidayId());
		hConfig.setHolidayName(hResult.getHolidayName());
		try {
			hConfig.setHolidayStart(dateFormat.parse(hResult.getHolidayStart()));
			hConfig.setHolidayEnd(dateFormat.parse(hResult.getHolidayEnd()));
		} catch (ParseException e) {
			e.printStackTrace();
		}
		hConfig.setHolidayDescription(hResult.getHolidayDescription());
		hConfig.setOrgId(hResult.getOrgId());

		return HibernateUtil.updateObject(hConfig);
	}

	// Xoa ngay le
	@Override
	public int deleteHolidayConfigById(List<Long> listHolidayId) {
		HolidayConfig hConfig = new HolidayConfig();
		int result = 0;

		for (Long holidayId : listHolidayId) {
			result = HibernateUtil.deleteById(hConfig, holidayId);
			if (result == ErrorCodeSworld.NOT_FOUND_OBJ) {
				return result;
			}
		}

		return result;
	}

	// Lay ngay le theo Id
	@Override
	public HolidayResultForGet getHolidayConfigById(long holidayId) {
		Session session = HibernateUtil.getSession();
		HolidayResultForGet hResult;
		HolidayConfig hConfig = new HolidayConfig();

		try {
			session.beginTransaction();
			String strQuery = "FROM HolidayConfig WHERE holidayId = :id";
			Query query = session.createQuery(strQuery);

			query.setParameter("id", holidayId);
			hConfig = (HolidayConfig) query.uniqueResult();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}

		hResult = new HolidayResultForGet(hConfig);
		return hResult;
	}

	// Check if it's holiday or not by orgId
	@SuppressWarnings("unchecked")
	@Override
	public int checkHoliday(Date dateCheck, long orgId) {
		Session session = HibernateUtil.getSession();
		int isHoliday = 1;
		List<HolidayConfig> listHolidayConfig = null;

		try {
			session.beginTransaction();
			String strQuery = "FROM HolidayConfig WHERE (holidayStart <= :dateCheck) AND "
					+ "(holidayEnd >= :dateCheck) AND " + "(orgId = :id)";
			Query query = session.createQuery(strQuery);

			query.setParameter("dateCheck", dateCheck);
			query.setParameter("id", orgId);
			listHolidayConfig = query.list();
			session.getTransaction().commit();
			if (listHolidayConfig == null || listHolidayConfig.size() == 0) {
				return isHoliday;
			}
			if (listHolidayConfig.size() > 0) {
				isHoliday = 0;
			}
			// for (HolidayConfig holidayConfig : listHolidayConfig) {
			// if (!holidayConfig.getHolidayStart().after(dateCheck)
			// && !holidayConfig.getHolidayEnd().before(dateCheck)) {
			// isHoliday = 0;
			// break;
			// }
			// }
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}

		return isHoliday;
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<HolidayResultForGet> filterHolidayListByOrgId(Date dateStart,
			Date dateEnd, long orgId) {
		Session session = HibernateUtil.getSession();
		List<HolidayResultForGet> listHolidayResult = new ArrayList<>();
		List<HolidayConfig> listHolidayConfig = null;

		try {
			session.beginTransaction();
			String strQuery = "FROM HolidayConfig WHERE (holidayStart BETWEEN :dateStart AND :dateEnd) AND "
					+ "(holidayEnd BETWEEN :dateStart AND :dateEnd) AND (orgId = :id) ORDER BY holidayStart";
			Query query = session.createQuery(strQuery);

			query.setParameter("dateStart", dateStart);
			query.setParameter("dateEnd", dateEnd);
			query.setParameter("id", orgId);
			listHolidayConfig = query.list();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}

		for (int i = 0; i < listHolidayConfig.size(); i++) {
			HolidayResultForGet hResult = new HolidayResultForGet(
					listHolidayConfig.get(i));
			listHolidayResult.add(hResult);
		}

		return listHolidayResult;
	}

	// trang.vo
	@SuppressWarnings({ "deprecation" })
	@Override
	public List<HolidayResultForGet> GetHolidayListByOrgId(int year, long orgId) {
		Date dateStart = new Date(), dateEnd = new Date();

		// set value of dateStart
		dateStart.setYear(year);
		dateStart.setMonth(1);
		dateStart.setDate(1);
		dateStart.setHours(0);
		dateStart.setMinutes(1);

		// set value of dateEnd
		dateEnd.setYear(year);
		dateEnd.setMonth(12);
		dateEnd.setDate(31);
		dateEnd.setHours(23);
		dateEnd.setMinutes(59);

		return filterHolidayListByOrgId(dateStart, dateEnd, orgId);
	}
}
