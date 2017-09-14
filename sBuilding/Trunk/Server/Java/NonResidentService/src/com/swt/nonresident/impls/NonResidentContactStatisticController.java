package com.swt.nonresident.impls;

import java.util.Date;

import com.swt.nonresident.customObject.NonResidentContactStatisticDetatiObj;
import com.swt.nonresident.customObject.NonResidentContactStatisticObj;
import com.swt.nonresident.domain.NonResidentContactStatistic;

// khong dung den
public class NonResidentContactStatisticController {
	
	public static final NonResidentContactStatisticController Instance = new NonResidentContactStatisticController();

	private NonResidentContactStatisticDAO dao = new NonResidentContactStatisticDAO();

	// insert
	public NonResidentContactStatistic insert(NonResidentContactStatistic contactStatistic) {
		return dao.insert(contactStatistic);
	}

	// thong ke theo ma don vi lien he tu ngay den ngay gioi han de phan trang
	public NonResidentContactStatisticDetatiObj statisticDetailByOrgId(int start, int limit, Date fromDate, Date toDate,
			long orgId) {
		return dao.statisticDetailByOrgId(start, limit, fromDate, toDate, orgId);
	}

	// thong ke so luong nguoi den don vi theo ngay
	public NonResidentContactStatisticObj statisticByDate(int start, int limit, Date fromDate, Date toDate,
			long orgId) {
		return dao.statisticByDate(start, limit, fromDate, toDate, orgId);
	}
}
