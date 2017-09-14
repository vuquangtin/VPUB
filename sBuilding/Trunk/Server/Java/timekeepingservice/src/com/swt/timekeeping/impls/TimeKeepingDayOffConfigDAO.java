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
import com.swt.sworld.ps.domain.Member;
import com.swt.sworld.ps.impl.MemberController;
import com.swt.timekeeping.ITimeKeepingDayOffConfig;
import com.swt.timekeeping.customer.object.DayOffImportObject;
import com.swt.timekeeping.customer.object.DayOffResultForGet;
import com.swt.timekeeping.domain.DayOffConfig;

/**
 * TimeKeepingDayOffConfigDAO implements ITimeKeepingDayOffConfig
 * 
 * @author minh.nguyen
 *
 */
public class TimeKeepingDayOffConfigDAO implements ITimeKeepingDayOffConfig {

	@Override
	public DayOffConfig insertDayOffConfig(DayOffResultForGet doResult) {
		DateFormat dateFormat = new SimpleDateFormat("dd/MM/yyyy");
		DayOffConfig doConfig = new DayOffConfig();

		doConfig.setMemberId(doResult.getMemberId());
		try {
			doConfig.setDate(dateFormat.parse(doResult.getDate()));
		} catch (ParseException e) {
			e.printStackTrace();
		}
		doConfig.setStatus(doResult.getStatus());
		doConfig.setSubOrgId(doResult.getSubOrgId());

		return HibernateUtil.insertObject(doConfig);
	}

	@Override
	public DayOffConfig updateDayOffConfig(DayOffResultForGet doResult) {
		DateFormat dateFormat = new SimpleDateFormat("dd/MM/yyyy");
		DayOffConfig doConfig = new DayOffConfig();

		doConfig.setDayOffConfigId(doResult.getDayOffConfigId());
		doConfig.setMemberId(doResult.getMemberId());
		try {
			doConfig.setDate(dateFormat.parse(doResult.getDate()));
		} catch (ParseException e) {
			e.printStackTrace();
		}
		doConfig.setStatus(doResult.getStatus());
		doConfig.setSubOrgId(doResult.getSubOrgId());

		return HibernateUtil.updateObject(doConfig);
	}

	@Override
	public DayOffConfig insertOrUpdateDayOffByListMemberId(
			DayOffResultForGet doResult) {
		DayOffConfig doConfig = new DayOffConfig();
		DayOffResultForGet doResultTemp = getDayOffByMemberIdAndDate(
				doResult.getMemberId(), doResult.getDate());

		if (null == doResultTemp) {
			doResultTemp = new DayOffResultForGet();
			doResultTemp = doResult;

			doConfig = insertDayOffConfig(doResultTemp);
		} else {
			doResultTemp.setStatus(doResult.getStatus());

			doConfig = updateDayOffConfig(doResultTemp);
		}

		return doConfig;
	}

	@Override
	public int deleteDayOffConfig(List<Long> listDOConfigId) {
		DayOffConfig doConfig = new DayOffConfig();
		int result = 0;

		for (Long doConfigId : listDOConfigId) {
			result = HibernateUtil.deleteById(doConfig, doConfigId);
			if (result == ErrorCodeSworld.NOT_FOUND_OBJ) {
				return result;
			}
		}

		return result;
	}

	@Override
	public DayOffResultForGet getDayOffConfigById(long doConfigId) {
		Session session = HibernateUtil.getSession();
		DayOffResultForGet doResult;
		DayOffConfig doConfig = new DayOffConfig();

		try {
			session.beginTransaction();
			String strQuery = "FROM DayOffConfig WHERE dayOffConfigId = :id";
			Query query = session.createQuery(strQuery);

			query.setParameter("id", doConfigId);
			doConfig = (DayOffConfig) query.uniqueResult();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}

		doResult = new DayOffResultForGet(doConfig);
		return doResult;
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<DayOffResultForGet> getListDayOffConfigByMemberId(long memberId) {
		Session session = HibernateUtil.getSession();
		List<DayOffResultForGet> listDayOffResult = new ArrayList<>();
		List<DayOffConfig> listDayOffConfig = null;

		try {
			session.beginTransaction();
			String strQuery = "FROM DayOffConfig WHERE memberId = :id";
			Query query = session.createQuery(strQuery);

			query.setParameter("id", memberId);
			listDayOffConfig = query.list();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}

		for (int i = 0; i < listDayOffConfig.size(); i++) {
			DayOffResultForGet doResult = new DayOffResultForGet(
					listDayOffConfig.get(i));
			listDayOffResult.add(doResult);
		}

		return listDayOffResult;
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<DayOffResultForGet> filterListDayOffBySubOrgId(Date dateStart,
			Date dateEnd, long subOrgId) {
		Session session = HibernateUtil.getSession();
		List<DayOffResultForGet> listDayOffResult = new ArrayList<>();
		List<DayOffConfig> listDayOffConfig = null;

		try {
			session.beginTransaction();
			String strQuery = "FROM DayOffConfig WHERE (date BETWEEN :dateStart AND :dateEnd) AND "
					+ "(subOrgId = :id) ORDER BY date";
			Query query = session.createQuery(strQuery);

			query.setParameter("dateStart", dateStart);
			query.setParameter("dateEnd", dateEnd);
			query.setParameter("id", subOrgId);
			listDayOffConfig = query.list();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}

		for (int i = 0; i < listDayOffConfig.size(); i++) {
			DayOffResultForGet doResult = new DayOffResultForGet(
					listDayOffConfig.get(i));
			listDayOffResult.add(doResult);
		}

		return listDayOffResult;
	}

	@Override
	public int getStatusOfDateByMemberId(long memberId, String date) {
		int status = 0;
		List<DayOffResultForGet> listDayOffConfig = null;

		listDayOffConfig = getListDayOffConfigByMemberId(memberId);
		// Neu tren database khong co list thi tra ve status = 0 luon
		if (listDayOffConfig == null) {
			return status;
		}
		// Kiem tra trong listDayOffConfig co date can tim hay khong
		// neu co thi status la gi
		for (int i = 0; i < listDayOffConfig.size(); i++) {
			if (listDayOffConfig.get(i).getDate().equals(date)) {
				status = listDayOffConfig.get(i).getStatus();
				break;
			}
		}

		return status;
	}

	@Override
	public DayOffResultForGet getDayOffByMemberIdAndDate(long memberId,
			String date) {
		DayOffResultForGet doResult = null;
		List<DayOffResultForGet> listDayOffConfig = null;

		listDayOffConfig = getListDayOffConfigByMemberId(memberId);
		// Neu tren database khong co list thi tra ve status = 0 luon
		if (listDayOffConfig == null) {
			return doResult;
		}
		// Kiem tra trong listDayOffConfig co date can tim hay khong
		// neu co thi status la gi
		for (int i = 0; i < listDayOffConfig.size(); i++) {
			if (listDayOffConfig.get(i).getDate().equals(date)) {
				doResult = listDayOffConfig.get(i);
				break;
			}
		}

		return doResult;
	}

	/**
	 * importDayOffList: improt danh sach ngay nghi cua thang cua tung phong ban
	 */
	@Override
	public List<DayOffImportObject> importDayOffList(
			List<DayOffImportObject> excelDayOffList) {
		SimpleDateFormat sdf = new SimpleDateFormat("dd/MM/yyyy HH:mm:ss aa");
		@SuppressWarnings("unused")
		Date date, 
		dateBegin, dateEnd;
		List<Long> listIdForCal = new ArrayList<Long>();
		List<DayOffImportObject> listResult = new ArrayList<DayOffImportObject>();
		DayOffResultForGet dayOffTmp = new DayOffResultForGet();
		Member member;
		DayOffConfig dayOffConfig;
		DayOffImportObject object = new DayOffImportObject();
		int size = excelDayOffList.size();
		String dateStr;
		
		try {
		// duyet
		for (int i = 0; i < size; i++) {
			
			object = excelDayOffList.get(i);
			member = MemberController.Instance.getMemberByCode(
					object.getOrgId(), object.getMemberCode());
			dayOffTmp = new DayOffResultForGet();
			dayOffTmp.setSubOrgId(object.getSubOrgId());
			dayOffTmp.setMemberId(member.getId());
			date = sdf.parse(object.getDateOff());
			dateStr = object.getDateOff().substring(0, 10); 
			dayOffTmp.setDate(dateStr);
			dayOffTmp.setStatus(object.getTypeDayOff());
			dayOffConfig = insertDayOffConfig(dayOffTmp);

			// update status
			listIdForCal = new ArrayList<Long>();
			listIdForCal.add(member.getId());
			
				dateBegin = sdf.parse(object.getDateOff());
				dateEnd = sdf.parse(object.getDateOff());

				TimeKeepingMonthlyReportController.Instance.calculateMonthlyReport(listIdForCal, dateBegin, dateEnd);

				// ko add duoc
				if (null == dayOffConfig) {
					listResult.add(object);
				}
			}

			} catch (ParseException e) {
				e.printStackTrace();
			}
		return listResult;
	}
}
