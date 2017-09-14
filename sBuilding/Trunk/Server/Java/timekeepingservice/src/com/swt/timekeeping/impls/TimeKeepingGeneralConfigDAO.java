package com.swt.timekeeping.impls;

import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;

import com.google.gson.Gson;
import com.nhn.utilities.HibernateUtil;
//import com.sworld.common.Utilites;
import com.swt.timekeeping.ITimeKeepingGeneralConfig;
import com.swt.timekeeping.customer.object.GeneralConfigJson;
import com.swt.timekeeping.domain.GeneralConfig;

/**
 * TimeKeepingGeneralConfigDAO implements ITimeKeepingGeneralConfig
 * 
 * @author minh.nguyen
 *
 */
public class TimeKeepingGeneralConfigDAO implements ITimeKeepingGeneralConfig {

	@Override
	public GeneralConfig insertGeneralConfig(GeneralConfig gConfig) {
		return HibernateUtil.insertObject(gConfig);
	}

	@Override
	public GeneralConfig updateGeneralConfig(GeneralConfig gConfig) {
		return HibernateUtil.updateObject(gConfig);
	}

	@Override
	public GeneralConfig getGeneralConfigByOrgId(long orgId) {
		Session session = HibernateUtil.getSession();
		GeneralConfig gConfig = new GeneralConfig();

		try {
			session.beginTransaction();
			String strQuery = "FROM GeneralConfig WHERE orgId = :id";
			Query query = session.createQuery(strQuery);

			query.setParameter("id", orgId);
			gConfig = (GeneralConfig) query.uniqueResult();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}

		return gConfig;
	}

	@Override
	public GeneralConfigJson getTimeGeneralConfigByOrgId(long orgId) {
		Gson gson = new Gson();
		// Lay cau hinh chung bang orgId
		GeneralConfig gConfig = getGeneralConfigByOrgId(orgId);
		// Lay string cau hinh thoi gian tre, thoi gian tag the,...
		String strJson = gConfig.getGeneralConfigJson();
		// Covert tu strJson sang object
		// GeneralConfigJson gConfigJson =
		// Utilites.getInstance().convertJsonStrToObject(strJson);
		GeneralConfigJson gConfigJson = gson.fromJson(strJson, GeneralConfigJson.class);

		return gConfigJson;
	}
}
