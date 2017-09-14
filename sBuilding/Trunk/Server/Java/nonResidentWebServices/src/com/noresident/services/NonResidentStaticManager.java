package com.noresident.services;

import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.List;

import javax.ws.rs.CookieParam;
import javax.ws.rs.GET;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;

import com.nonresident.common.NonResidentDefines;
import com.sworld.common.ResultObject;
import com.sworld.common.Status;
import com.swt.nonresident.customObject.NonResidentObj;
import com.swt.nonresident.customObject.NonResidentStatisticDetailObj;
import com.swt.nonresident.customObject.NonResidentStatisticObj;
import com.swt.nonresident.impls.NonResidentController;
import com.swt.sworld.common.utilitis.TokenManager;

/**
 * @author TaiMai
 * 
 */
@Path(NonResidentDefines.NON_RESIDENT_STATSTIC_MANAGER)
@Produces(NonResidentDefines.APPLICATION_JSON)
public class NonResidentStaticManager {

	public static final String FORMAT_DATE = "yyyy-MM-dd HH:mm:ss";
	public static final String FORMAT_DATE_GETLIST = "yyyy-MM-dd";

	// thong ke so luong nguoi da den cac co quan tu ngay den ngay
	@GET
	@Path(NonResidentDefines.GET_LIST_NON_RESIDENT_STATISTIC_BY_DATE + "/{token}/{start}/{end}/{fromdate}/{todate}")
	@Produces(MediaType.APPLICATION_JSON)
	public ResultObject getListNonResidentStatsticByDate(@CookieParam("sessionid") String session,
			@PathParam("token") String token, @PathParam("start") int start, @PathParam("end") int end,
			@PathParam("fromdate") String fromDate, @PathParam("todate") String toDate) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			SimpleDateFormat simpleDateFormat = new SimpleDateFormat(FORMAT_DATE_GETLIST);
			Date paraFromDate = null;
			Date paraToDate = null;
			try {
				paraFromDate = simpleDateFormat.parse(fromDate);
				paraToDate = simpleDateFormat.parse(toDate);
			} catch (java.text.ParseException e) {
				e.printStackTrace();
			}
			NonResidentStatisticObj nonResidentstatisticObj = NonResidentController.Instance
					.getListNonResidentStatisticByDate(start, end, paraFromDate, paraToDate);
			if (nonResidentstatisticObj != null) {
				result.setStatus(Status.SUCCESS);
				result.setObj(nonResidentstatisticObj);
			} else {
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}

	// thong ke thong tin chi tiet nhung nguoi da vao co quan do tu ngay den
	// ngay
	@GET
	@Path(NonResidentDefines.GET_LIST_NON_RESIDENT_BY_ORGID_AND_DATE
			+ "/{token}/{start}/{end}/{fromdate}/{todate}/{orgid}")
	@Produces(MediaType.APPLICATION_JSON)
	public ResultObject getListNonResidentByOrgIdAndDate(@CookieParam("sessionid") String session,
			@PathParam("token") String token, @PathParam("start") int start, @PathParam("end") int end,
			@PathParam("fromdate") String fromDate, @PathParam("todate") String toDate,
			@PathParam("orgid") long orgId) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			SimpleDateFormat simpleDateFormat = new SimpleDateFormat(FORMAT_DATE_GETLIST);
			Date paraFromDate = null;
			Date paraToDate = null;
			try {
				paraFromDate = simpleDateFormat.parse(fromDate);
				paraToDate = simpleDateFormat.parse(toDate);
			} catch (java.text.ParseException e) {
				e.printStackTrace();
			}
			List<NonResidentObj> listNonResidentStatistic = NonResidentController.Instance
					.getListNonResidenByOrgIdAndDate(start, end, paraFromDate, paraToDate, orgId);

			if (listNonResidentStatistic != null) {
				result.setStatus(Status.SUCCESS);
				result.setObj(listNonResidentStatistic);
			} else {
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}

	// thong ke thong tin chi tiet nhung nguoi da vao tat ca cac co quan do tu
	// ngay den ngay
	@GET
	@Path(NonResidentDefines.GET_LIST_NON_RESIDENT_BY_DATE + "/{token}/{start}/{end}/{fromdate}/{todate}")
	@Produces(MediaType.APPLICATION_JSON)
	public ResultObject getListNonResidentByDate(@CookieParam("sessionid") String session,
			@PathParam("token") String token, @PathParam("start") int start, @PathParam("end") int end,
			@PathParam("fromdate") String fromDate, @PathParam("todate") String toDate) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			SimpleDateFormat simpleDateFormat = new SimpleDateFormat(FORMAT_DATE_GETLIST);
			Date paraFromDate = null;
			Date paraToDate = null;
			try {
				paraFromDate = simpleDateFormat.parse(fromDate);
				paraToDate = simpleDateFormat.parse(toDate);
			} catch (java.text.ParseException e) {
				e.printStackTrace();
			}
			NonResidentStatisticDetailObj rs = NonResidentController.Instance.getListNonResidentByDate(start, end,
					paraFromDate, paraToDate);
			if (rs != null) {
				result.setStatus(Status.SUCCESS);
				result.setObj(rs);
			} else {
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}

	// thong ke thong tin chi tiet nhung nguoi da vao co quan do tu
	// ngay den ngay
	@GET
	@Path(NonResidentDefines.GET_LIST_NON_RESIDENT_BY_DATE_ORGID + "/{token}/{start}/{end}/{fromdate}/{todate}"
			+ "/{orgid}/{memorsuborgid}/{ispeople}")
	@Produces(MediaType.APPLICATION_JSON)
	public ResultObject getListNonResidentByDateAndOrgId(@CookieParam("sessionid") String session,
			@PathParam("token") String token, @PathParam("start") int start, @PathParam("end") int end,
			@PathParam("fromdate") String fromDate, @PathParam("todate") String toDate,
			@PathParam("orgid") long orgId, @PathParam("memorsuborgid") long memOrSubOrgId, @PathParam("ispeople") int isPeople) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			SimpleDateFormat simpleDateFormat = new SimpleDateFormat(FORMAT_DATE_GETLIST);
			Date paraFromDate = null;
			Date paraToDate = null;
			try {
				paraFromDate = simpleDateFormat.parse(fromDate);
				paraToDate = simpleDateFormat.parse(toDate);
			} catch (java.text.ParseException e) {
				e.printStackTrace();
			}
			NonResidentStatisticDetailObj rs = NonResidentController.Instance.getListNonResidentByDate(start, end,
					paraFromDate, paraToDate, orgId, memOrSubOrgId, isPeople);
			if (rs != null) {
				result.setStatus(Status.SUCCESS);
				result.setObj(rs);
			} else {
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}
}
