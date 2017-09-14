package com.sworld.timekeeping.services;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.List;

import javax.ws.rs.Consumes;
import javax.ws.rs.CookieParam;
import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;

import org.codehaus.jettison.json.JSONArray;

import com.sworld.common.ResultObject;
import com.sworld.common.Status;
import com.sworld.common.Utilites;
import com.sworld.timekeeping.common.TimeKeepingDefines;
import com.swt.sworld.common.utilitis.TokenManager;
import com.swt.sworld.ps.domain.Member;
import com.swt.sworld.ps.impl.MemberController;
import com.swt.timekeeping.domain.MonthlyReport;
import com.swt.timekeeping.domain.Shift;
import com.swt.timekeeping.impls.TimeKeepingMonthlyReportController;
import com.swt.timekeeping.impls.TimeKeepingShiftController;

/**
 * @author Trang Vo
 * 
 */

@Path(TimeKeepingDefines.TIMEKEEPINGMANAGER)
@Produces(TimeKeepingDefines.APPLICATION_JSON)
public class TimeKeepingManager {	
	
	
/// get timekeeping by year, by month, by date
	@GET
	@Path(TimeKeepingDefines.GET_TIMESHEET_BY_DATE + "/{token}/{date}/{name}/{deviceName}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject getTimeSheetByDate(
			@CookieParam("sessionid") String session,
			@PathParam("token") String token,
			@PathParam("date") String date,
			@PathParam("name") String name,
			@PathParam("deviceName") String deviceName) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session,token);
		if (flag) {		
			List<Shift> dl = TimeKeepingShiftController.Instance.getShiftListByDate(date,name,deviceName);
			
			if(dl != null)
			{
				result.setStatus(Status.SUCCESS);
				result.setObj(dl);
			}
			else
			{
				result.setObj(new Shift());
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}
	
	@GET
	@Path(TimeKeepingDefines.GET_TIMESHEET_BY_YEAR + "/{token}/{year}/{name}/{deviceName}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject getTimeSheetYear(
			@CookieParam("sessionid") String session,
			@PathParam("token") String token,
			@PathParam("year") String year,
			@PathParam("name") String name,
			@PathParam("deviceName") String deviceName) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session,token);
		if (flag) {		
			List<Shift> dl = TimeKeepingShiftController.Instance.getShiftListByYear(year, name, deviceName);
			if(dl != null)
			{
				result.setStatus(Status.SUCCESS);
				result.setObj(dl);
			}
			else
			{
				result.setObj(new Shift());
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}
	
	@GET
	@Path(TimeKeepingDefines.GET_TIMESHEET_BY_MONTH + "/{token}/{year}/{month}/{name}/{deviceName}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject getTimeSheetMonth(
			@CookieParam("sessionid") String session,
			@PathParam("token") String token,
			@PathParam("year") String year,
			@PathParam("month") String month,
			@PathParam("name") String name,
			@PathParam("deviceName") String deviceName) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session,token);
		if (flag) {		
			List<Shift> dl = TimeKeepingShiftController.Instance.getShiftListByMonth(month, year, name, deviceName);
			if(dl != null)
			{
				result.setStatus(Status.SUCCESS);
				result.setObj(dl);
			}
			else
			{
				result.setObj(new Shift());
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}
	
/// end part of get timekeeping by year, by month, by year
	
	@GET
	@Path(TimeKeepingDefines.GET_TIMEKEEPING_MONTHLY_REPORT+ "/{token}/{memberid}/{year}/{month}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject getTimeKeepingMonthlyReport(
			@CookieParam("sessionid") String session,
			@PathParam("token") String token,
			@PathParam("memberid") long memberId,
			@PathParam("year") int year,
			@PathParam("month") int month) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session,token);
		if (flag) {		
			MonthlyReport dl = TimeKeepingMonthlyReportController.Instance.getMonthlyReport( memberId, year, month);
			if(dl != null){
				result.setStatus(Status.SUCCESS);
			}
			else{
				result.setStatus(Status.FAILED);
			}
			result.setObj(dl);
		}
		return result;
	}
	
	@GET
	@Path(TimeKeepingDefines.GET_TIMEKEEPING_MONTHLY_REPORT_LIST + "/{token}/{orgid}/{suborgid}/{year}/{month}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject getTimeKeepingMonthlyReportList(
			@CookieParam("sessionid") String session,
			@PathParam("token") String token,
			@PathParam("orgid") long orgId,
			@PathParam("suborgid") long subOrgId,
			@PathParam("year") int year,
			@PathParam("month") int month) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session,token);
		if (flag) {	
			List<MonthlyReport> dl = TimeKeepingMonthlyReportController.Instance.getMonthlyReportList(orgId, subOrgId, year, month);
			if(dl != null){
				result.setStatus(Status.SUCCESS);
			}
			else{
				result.setStatus(Status.FAILED);
			}
			result.setObj(dl);
		}
		return result;
	}
	
	
	
	@GET
	@Path(TimeKeepingDefines.GET_TIMEKEEPING_MONTHLY_REPORT_LIST_BY_DATE + "/{token}/{orgid}/{suborgid}/{datebegin}/{dateend}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject getTimeKeepingMonthlyReportByDate(
			@CookieParam("sessionid") String session,
			@PathParam("token") String token,
			@PathParam("orgid") long orgId,
			@PathParam("suborgid") long subOrgId,
			@PathParam("datebegin") String datebegin,
			@PathParam("dateend") String dateend) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session,token);
		if (flag) {		
			List<MonthlyReport> dl = TimeKeepingMonthlyReportController.Instance.getMonthlyReportListByDate(orgId, subOrgId, datebegin, dateend);
			if(dl != null){
				result.setStatus(Status.SUCCESS);
			}
			else{
				result.setStatus(Status.FAILED);
			}
			result.setObj(dl);
		}
		return result;
	}
	
	@POST
	@Path(TimeKeepingDefines.INSERT_TIMEKEEPING_MONTHLY_REPORT_BY_LIST_ID + "/{token}/{startdate}/{enddate}")
	@Consumes(TimeKeepingDefines.APPLICATION_JSON)
	public ResultObject calculateMonthlyReport(
			@CookieParam(value = "sessionid") String session,
			@PathParam("token") String token, @PathParam("startdate") String startDate,
			@PathParam("enddate") String endDate, JSONArray listIdJson) {
		ResultObject result = new ResultObject(Status.FAILED);

		boolean flag = TokenManager.getInstance().checkTokenSession(session,
				token);
		if (flag) {
				List<Long> members = Utilites.getInstance()
						.convertJsonArrayToListLong(listIdJson);
				//chuyen doi date
				SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");
				Date dateBegin, dateEnd;
				try {
					dateBegin = sdf.parse(startDate);
					dateEnd = sdf.parse(endDate);
					int monthlyResult = 0;
					monthlyResult = TimeKeepingMonthlyReportController.Instance
							.calculateMonthlyReport(members, dateBegin, dateEnd);
					if(monthlyResult == 0) result.setStatus(Status.SUCCESS);
					else result.setStatus(Status.FAILED);
				} catch (ParseException e) {
					e.printStackTrace();
				}
				
		}
		return result;
	}

	@GET
	@Path(TimeKeepingDefines.INSERT_TIMEKEEPING_MONTHLY_REPORT_DEFAULT + "/{token}/{orgid}/{suborgid}/{memberid}/{year}/{month}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject insertTimeKeepingMonthlyReportDefault(@CookieParam(value = "sessionid") String session,
			@PathParam("token") String token, @PathParam("orgid") long orgId,
			@PathParam("suborgid") long subOrgId, @PathParam("memberid") long memberId,
			@PathParam("year") int year, @PathParam("month") int month) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session,
				token);
		if (flag) {
			MonthlyReport monthlyReport = new MonthlyReport();
			monthlyReport.setOrgId(orgId);
			
			// lay suborg
				Member mem = MemberController.Instance.getMemberById(memberId);
				subOrgId = mem.getSubOrgId();
			monthlyReport.setSubOrgId(subOrgId);
			monthlyReport.setMemberId(memberId);
			monthlyReport.setYear(year);
			monthlyReport.setMonth(month);
				monthlyReport = TimeKeepingMonthlyReportController.Instance
						.insertMonthlyReport(monthlyReport);

				if (monthlyReport != null) {
					result.setStatus(Status.SUCCESS);
				} else {
					result.setStatus(Status.FAILED);
				}
				result.setObj(monthlyReport);
		}
		return result;
	}
	
	
}
