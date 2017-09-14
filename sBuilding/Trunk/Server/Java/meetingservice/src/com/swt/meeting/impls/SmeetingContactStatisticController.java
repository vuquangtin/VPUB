package com.swt.meeting.impls;

import java.util.Date;

import com.swt.meeting.customObject.SmeetingContactStatisticDetatiObj;
import com.swt.meeting.customObject.SmeetingContactStatisticObj;
import com.swt.meeting.domain.SmeetingContactStatistic;

public class SmeetingContactStatisticController {
	public static final SmeetingContactStatisticController Instance = new SmeetingContactStatisticController();

	private SmeetingContactStatisticDAO dao = new SmeetingContactStatisticDAO();

	/**
	 * them nguoi vao lien he cong tac
	 * 
	 * @param contactStatistic
	 * @return
	 */
	public SmeetingContactStatistic insert(SmeetingContactStatistic contactStatistic) {
		return dao.insert(contactStatistic);
	}

	/**
	 * // thong ke theo ma don vi lien he tu ngay den ngay gioi han de phan
	 * trang
	 * 
	 * @param start
	 * @param limit
	 * @param fromDate
	 * @param toDate
	 * @param orgId
	 * @return
	 */
	public SmeetingContactStatisticDetatiObj statisticDetailByOrgId(int start, int limit, Date fromDate, Date toDate,
			long orgId) {
		return dao.statisticDetailByOrgId(start, limit, fromDate, toDate, orgId);
	}

	/**
	 * // thong ke so luong nguoi den don vi theo ngay
	 * 
	 * @param start
	 * @param limit
	 * @param fromDate
	 * @param toDate
	 * @param orgId
	 * @return
	 */
	public SmeetingContactStatisticObj statisticByDate(int start, int limit, Date fromDate, Date toDate, long orgId) {
		return dao.statisticByDate(start, limit, fromDate, toDate, orgId);
	}
}
