package com.swt.timekeeping.impls;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.List;

import com.google.gson.Gson;
import com.swt.sworld.cms.domain.SubOrganization;
import com.swt.sworld.cms.impls.SubOrganizationController;
import com.swt.sworld.communication.customer.object.MemberFilter;
import com.swt.sworld.ps.domain.Member;
import com.swt.sworld.ps.impl.MemberController;
import com.swt.timekeeping.customer.object.GeneralConfigJson;
import com.swt.timekeeping.customer.object.GeneralConfigTime;
import com.swt.timekeeping.customer.object.GeneralConfigureValue;
import com.swt.timekeeping.customer.object.SessionWorking;
import com.swt.timekeeping.customer.object.ShiftFilter;
import com.swt.timekeeping.customer.object.TimeKeepingStatus;
import com.swt.timekeeping.domain.DailyConfig;
import com.swt.timekeeping.domain.MonthlyReport;
import com.swt.timekeeping.domain.Shift;
import com.swt.timekeeping.domain.TimeConfig;

/**
 * TimeKeepingMonthlyReport Controller
 * 
 * @author Trang-PC
 *
 */
public class TimeKeepingMonthlyReportController {

	/**
	 * Instance of TimeKeepingMonthlyReportController
	 */
	public static final TimeKeepingMonthlyReportController Instance = new TimeKeepingMonthlyReportController();

	private TimeKeepingMonthlyReportDAO mrDAO = new TimeKeepingMonthlyReportDAO();

	/**
	 * get MonthlyReport by memberId, year and month
	 * 
	 * @param memberId
	 * @param year
	 * @param month
	 * @return
	 */
	public MonthlyReport getMonthlyReport(long memberId, int year, int month) {
		return mrDAO.getMonthlyReport(memberId, year, month);
	}

	/**
	 * get MonthlyReport List by orgId, subOrgId, year and month
	 * 
	 * @param orgId
	 * @param subOrgId
	 * @param year
	 * @param month
	 * @return
	 */
	public List<MonthlyReport> getMonthlyReportList(long orgId, long subOrgId,
			int year, int month) {
		List<MonthlyReport> result = new ArrayList<MonthlyReport>();
		if (subOrgId == -1) {
			result = mrDAO.getMonthlyReportList(orgId, subOrgId, year, month);
		} else {
			List<SubOrganization> listSubOrg = new ArrayList<SubOrganization>();
			// neu khong co subOrg cap nho hon thi listSubOrg co 1 gia tri la
			// subOrgId
			listSubOrg = SubOrganizationController.Instance
					.getSubOrgByParentId(subOrgId);

			if (null != listSubOrg && listSubOrg.size() != 0) {
				List<MonthlyReport> dl = new ArrayList<MonthlyReport>();
				for (SubOrganization subOrgbj : listSubOrg) {
					dl = mrDAO.getMonthlyReportList(orgId,
							subOrgbj.getSuborgid(), year, month);
					result.addAll(dl);
				}
			}
		}
		return result;
	}

	/**
	 * Calculate Monthly Report
	 * 
	 * @param members
	 * @param startDate
	 * @param endDate
	 * @return effect count
	 */
	@SuppressWarnings({ "deprecation", "unused" })
	public int calculateMonthlyReport(List<Long> members, Date startDateTmp,
			Date endDateTmp) {
		int countResult = 0;
		boolean check = true;
		SimpleDateFormat formatDayOff = new SimpleDateFormat("dd/MM/yyyy");
		Date startDate = removeTime(startDateTmp); // remove milisecond

		Date endDate = removeTime(endDateTmp);

		// check end day so voi ngay hien tai
		Date curDates = removeTime(new Date());
		if (startDate.compareTo(curDates) < 0
				&& startDate.compareTo(endDate) < 1) {

			if (curDates.compareTo(endDate) < 1) {
				// tinh toan lai ngay ket thuc neu ngay ket thuc lon hon ngay
				// hien tai
				curDates.setDate(curDates.getDate() - 1);
				endDate = curDates;
			}

			// bat dau tinh toan
			int size = members.size();
			if (members.size() > 0) {

				// tinh toan cho tung nguoi
				for (int i = 0; i < size; i++) {
					// tra lai gia tri ngay begin ban dau
					startDate = removeTime(new Date(startDateTmp.getTime()));
					Date dateCheckHoliday = new Date(startDateTmp.getTime()); // date
																				// dung
																				// cho
																				// check
																				// holiday
					// tinh toan tung ngay cho moi nguoi
					CalculatePersionTimePerDay(members.get(i), startDate,
							endDate, dateCheckHoliday);
				}
			}
		}

		return countResult;
	}

	/**
	 * is holiday date
	 * 
	 * @param orgid
	 * @param holiday
	 * @return 1 : is holidate , -1 no calculate
	 */
	private int validateHolidayDate(long orgid, Date holiday) {
		int result = TimeKeepingStatus.NGAY_NGHI_TRONG_TUAN.getValue();
		// kiem tra ngay le
		int checkLe = TimeKeepingHolidayConfigController.Instance.checkHoliday(
				holiday, orgid);
		if (checkLe == 0)
			result = TimeKeepingStatus.NGAY_LE.getValue();

		return result;
	}

	/**
	 * kiem tra ngay nghi ( 1 ngay hoac nua ngay) co phep
	 * 
	 * @param memberid
	 * @param date
	 * @param dayoff_value
	 *            : 2 full day, 1: haft day
	 * @return
	 */
	private int validateVacationDay(long memberid, Date date,
			List<Shift> taglist) {
		int result = TimeKeepingStatus.NGAY_NGHI_TRONG_TUAN.getValue();

		SimpleDateFormat formatDayOff = new SimpleDateFormat("dd/MM/yyyy");

		// validate vacation day
		result = TimeKeepingDayOffConfigController.Instance
				.getStatusOfDateByMemberId(memberid, formatDayOff.format(date));

		// nghi ca ngay co phep
		if (result == TimeKeepingStatus.VANG_CA_NGAY_PHEP.getValue())
			return result;

		if (result == TimeKeepingStatus.VANG_NUA_NGAY_PHEP.getValue()) {
			if (null == taglist || taglist.size() == 0) {
				result = TimeKeepingStatus.VANG_NUA_NGAY_KO_PHEP.getValue();
			} else {
				result = TimeKeepingStatus.VANG_NUA_NGAY_PHEP.getValue();
			}
		}

		return result;
	}

	/**
	 * get session working on day
	 * 
	 * @param orgid
	 * @param startDate
	 * @return
	 */
	private String getSessionWorkingOnDay(long orgid, Date startDate) {

		String sessionWorking = "";

		long timeStartDate = startDate.getTime();

		Date curDate = new Date();
		curDate = removeTime(curDate);
		long timeCurDate = curDate.getTime();

		if (timeStartDate == timeCurDate) {
			// get configure in systen
			Calendar c = Calendar.getInstance();
			c.setTime(curDate);
			int dayOfWeek = c.get(Calendar.DAY_OF_WEEK);
			TimeConfig timeConfig = TimeKeepingTimeConfigController.Instance
					.getTimeConfigByDayOfWeekOrgId(dayOfWeek, orgid);

			if (null != timeConfig)
				sessionWorking = timeConfig.getSessionWorking();
		} else {

			// get configure of special day
			DailyConfig dailyConfig = TimeKeepingDailyConfigController.Instance
					.getDailyConfigByDate(startDate, orgid);
			if (null != dailyConfig)
				sessionWorking = dailyConfig.getJsonTimeConfig();
		}

		return sessionWorking;
	}

	/**
	 * kiem tra ngay nghi khong phep hoac di tre
	 * 
	 * @param orgid
	 * @param memberid
	 * @param startDate
	 * @param shifts
	 * @param sessionWorking
	 * @return
	 */
	@SuppressWarnings("deprecation")
	private int validateOffDayOrLate(long orgid, long memberid, Date startDate,
			List<Shift> shifts, String sessionWorking) {
		Gson gson = new Gson();
		SessionWorking[] tempList = {};
		tempList = gson.fromJson(sessionWorking, SessionWorking[].class);

		Date date = shifts.get(0).getDateIn();
		int shiftBegin = date.getHours() * 60 + date.getMinutes();

		date = shifts.get(shifts.size() - 1).getDateIn();
		int shiftEnd = date.getHours() * 60 + date.getMinutes();

		int sessionBegin = (tempList[0].getHoursBegin() * 60 + tempList[0]
				.getMinuteBegin());
		int sessionEnd = (tempList[tempList.length - 1].getHoursEnd() * 60 + tempList[tempList.length - 1]
				.getMinuteEnd());

		int realBeginTime = 0;
		int realEndTime = 0;

		if (tempList.length > 0) {
			// lay shift dau tien tru cho thoi gian bat dau lam viec de tinh
			// toán thoi gian di tre hay nghỉ nua ngay
			realBeginTime = shiftBegin - sessionBegin;

			if (shifts.size() > 1) {
				// lay shift cuoi cung tru cho thoi gian ket thuc lam viec de
				// tinh toán thoi gian ve som hay nghỉ nua ngay
				realEndTime = sessionEnd - shiftEnd;
			}
		}

		// validate range time have in event
		boolean checkHalfDay = TimeKeepingEventController.Instance
				.checkEventForTime(sessionBegin, shiftBegin, memberid,
						startDate)
				|| TimeKeepingEventController.Instance.checkEventForTime(
						shiftEnd, sessionEnd, memberid, startDate);

		// lay thoi gian giua 2 lan tag
		GeneralConfigJson genJson = TimeKeepingGeneralConfigController.Instance
				.getTimeGeneralConfigByOrgId(orgid);
		int cardTag = genJson.getCardTag().getType() == 0 ? genJson
				.getCardTag().getValue() : genJson.getCardTag().getValue() * 60;

		// check event
		boolean joinEvent = TimeKeepingEventController.Instance
				.checkFullTimeEventByMemId(memberid, startDate);

		// checj off day
		int durationtime = shiftEnd - shiftBegin;
		int result = validateOffDayWithOutAccepted(joinEvent, cardTag, shifts,
				durationtime);

		if (result != TimeKeepingStatus.VANG_CA_NGAY_KO_PHEP.getValue()) {
			// validate haft day without accepted
			result = validateOffHaftDayWithOutAccepted(orgid, memberid,
					sessionWorking, startDate, shifts, realBeginTime,
					realEndTime, durationtime, cardTag, checkHalfDay);

			// check late
			if (result == Integer.MAX_VALUE) {
				result = valudateLate(orgid, realBeginTime, realEndTime,
						checkHalfDay);
			}
		}

		return result;

	}

	/**
	 * kiem tra di tre hoac ve som
	 * 
	 * @param orgid
	 * @param realBeginTime
	 * @param realEndTime
	 * @param checkHalfDay
	 * @return
	 */
	private int valudateLate(long orgid, int realBeginTime, int realEndTime,
			boolean checkHalfDay) {
		// liem tra tre
		int result = Integer.MAX_VALUE;

		int lTime = getGeneralConfigTime(orgid,
				GeneralConfigureValue.LATE_DAY.getValue());
		if ((realBeginTime > lTime || realEndTime > lTime)) {
			if (checkHalfDay) {
				result = TimeKeepingStatus.LAM_VIEC_DUNG_GIO.getValue();
			} else {
				result = TimeKeepingStatus.DI_TRE_VE_SOM.getValue();
			}
		}

		return result;
	}

	/**
	 * kiem tra nghi nguyen ngay khong phep
	 * 
	 * @param joinevent
	 * @param cardtag
	 * @param tagshift
	 * @param durationTag
	 * @return
	 */
	private int validateOffDayWithOutAccepted(boolean joinevent, int cardtag,
			List<Shift> tagshift, int durationTag) {
		int result = Integer.MAX_VALUE;
		// kiem tra nghi khong phep 1 ngay
		// (null == shifts || shifts.size() <= 1) : khong tag
		// (shifts.size() > 1 && (shiftEnd - shiftBegin < cardTag)) : khoan thoi
		// gian tag qua nho
		// joinevent: (true) co tham gia su kien
		if (((null == tagshift || tagshift.size() <= 1) || (tagshift.size() > 1 && (durationTag < cardtag)))
				&& !joinevent) {

			return TimeKeepingStatus.VANG_CA_NGAY_KO_PHEP.getValue();
		}
		return result;
	}

	/**
	 * kiem tra nghi khong phep nua ngay
	 * 
	 * @param orgid
	 * @param memberid
	 * @param sessionWorking
	 * @param startDate
	 * @param tagshift
	 * @param realbegintime
	 * @param realendtime
	 * @param durationTag
	 * @param cardTag
	 * @param checkhalfday
	 * @return
	 */
	private int validateOffHaftDayWithOutAccepted(long orgid, long memberid,
			String sessionWorking, Date startDate, List<Shift> tagshift,
			int realbegintime, int realendtime, int durationTag, int cardTag,
			boolean checkhalfday) {
		// kiem tra nghi khong phep nua ngay
		// trong truong hop nghi phep nua ngay && tag the trong thoi gian nghi
		// phep (ktra shift end < tgian nghi phep end)
		int result = Integer.MAX_VALUE;
		boolean flag = TimeKeepingEventController.Instance
				.checkFullTimeEventForSessionByMemId(memberid, sessionWorking,
						startDate);
		int lHTime = getGeneralConfigTime(orgid,
				GeneralConfigureValue.HAFT_DAY.getValue());

		if (tagshift.size() > 0
				&& ((realbegintime > lHTime || realendtime > lHTime) && (durationTag > cardTag))
				&& !flag) {
			if (checkhalfday) {
				result = TimeKeepingStatus.LAM_VIEC_DUNG_GIO.getValue();
			} else {
				result = TimeKeepingStatus.VANG_NUA_NGAY_KO_PHEP.getValue();
			}
		}

		return result;
	}

	/**
	 * calculate persion time per day
	 * 
	 * @param memberid
	 * @param startDate
	 * @param endDate
	 * @param holidayDate
	 *            : ngay bat dau check holiday
	 */
	@SuppressWarnings({ "unused", "deprecation" })
	private void CalculatePersionTimePerDay(long memberid, Date startDate,
			Date endDate, Date holidayDate) {
		boolean check = false;

		while (startDate.compareTo(endDate) < 1) {
			check = true;

			// prepare data for query
			ShiftFilter shiftFilter = new ShiftFilter();
			shiftFilter.setFilterByMemberId(true);
			shiftFilter.setMemberId(memberid);
			shiftFilter.setFilterByDateIn(true);
			shiftFilter.setDateIn(startDate);
			List<Shift> listShift = TimeKeepingShiftController.Instance
					.getShiftListByShiftFilter(shiftFilter);

			long orgId = MemberController.Instance.getMemberById(memberid)
					.getOrgId();

			// kiem tra ngay le
			int timeKeepingStatus = validateHolidayDate(orgId, holidayDate);

			if (timeKeepingStatus != TimeKeepingStatus.NGAY_LE.getValue()) {
				// check not working day by configuration

				// get session working on day
				String sessionWorking = getSessionWorkingOnDay(orgId, startDate);

				if ("".equals(sessionWorking) || null == sessionWorking) {
					timeKeepingStatus = TimeKeepingStatus.NGAY_NGHI_TRONG_TUAN
							.getValue();
					check = false;
				}

				// khong phai ngay nghi trong tuan
				if (check) {
					SimpleDateFormat formatDayOff = new SimpleDateFormat(
							"dd/MM/yyyy");
					// validate vacation day
					// validate vacation with accepting
					timeKeepingStatus = validateVacationDay(memberid,
							startDate, listShift);
					if (timeKeepingStatus == TimeKeepingStatus.VANG_CA_NGAY_PHEP
							.getValue()
							|| timeKeepingStatus == TimeKeepingStatus.VANG_NUA_NGAY_PHEP
									.getValue()
							|| timeKeepingStatus == TimeKeepingStatus.VANG_NUA_NGAY_KO_PHEP
									.getValue())
						check = false;
				}

				// chuan bi data de kiem tra khong phap

				int lHTime = getGeneralConfigTime(orgId,
						GeneralConfigureValue.HAFT_DAY.getValue());
				int realBTime = 0, realETime = 0, shiftBegin = 0, shiftEnd = 0;

				// kiem tra vang
				if (check) {
					// vang ca ngay khong phep
					if (null == listShift || listShift.size() == 0) {
						timeKeepingStatus = TimeKeepingStatus.VANG_CA_NGAY_KO_PHEP
								.getValue();
					} else {
						// vang nua ngay khong phep va di tre
						timeKeepingStatus = validateOffDayOrLate(orgId,
								memberid, startDate, listShift, sessionWorking);

					}

					if (timeKeepingStatus == Integer.MAX_VALUE)
						timeKeepingStatus = TimeKeepingStatus.NGAY_NGHI_TRONG_TUAN
								.getValue();

					check = false;
				}

				// default: di lam binh thuong
				if (check) {
					timeKeepingStatus = TimeKeepingStatus.LAM_VIEC_DUNG_GIO
							.getValue();
				}
			}
			// update cho monthly report
			inserOrUpdateMonthlyReport(memberid, startDate, timeKeepingStatus);

			holidayDate.setDate(holidayDate.getDate() + 1);
			startDate.setDate(startDate.getDate() + 1);
		}
	}

	/**
	 * get GeneralConfigTime
	 * 
	 * @param orgId
	 * @param ishalfday
	 * @return
	 */
	private int getGeneralConfigTime(long orgId, int ishalfday) {
		int time = 0;
		GeneralConfigJson gJson = TimeKeepingGeneralConfigController.Instance
				.getTimeGeneralConfigByOrgId(orgId);
		GeneralConfigTime gTime = null;
		// get thoi gian nghi nua ngay
		if (ishalfday == GeneralConfigureValue.HAFT_DAY.getValue()) {
			gTime = gJson.getLateHalfDay();
		}
		// get thoi gian tre
		if (ishalfday == GeneralConfigureValue.LATE_DAY.getValue()) {
			gTime = gJson.getLate();
		}
		time = gTime.getType() == 0 ? gTime.getValue() : gTime.getValue() * 60;
		return time;
	}

	/**
	 * remove Time in Date remove second value
	 * 
	 * @param date
	 * @return
	 */
	@SuppressWarnings("deprecation")
	public Date removeTime(Date dates) {
		Date date = dates;
		date.setHours(0);
		date.setMinutes(0);
		date.setSeconds(0);
		date.setTime(date.getTime() - date.getTime() % 1000);
		return date;
	}

	/**
	 * inserOrUpdateMonthlyReport
	 * 
	 * @param memberId
	 * @param date
	 * @param timeKeepingStatus
	 */
	@SuppressWarnings("deprecation")
	public void inserOrUpdateMonthlyReport(long memberId, Date date,
			int timeKeepingStatus) {
		int y = date.getYear() + 1900;
		int m = date.getMonth() + 1;
		MonthlyReport monthlyReport = getMonthlyReport(memberId, y, m);
		if (null == monthlyReport)
			monthlyReport = new MonthlyReport();

		Member member = MemberController.Instance.getMemberById(memberId);
		if (null != member) {

			monthlyReport.setOrgId(member.getOrgId());
			monthlyReport.setSubOrgId(member.getSubOrgId());
			// set status
			int day = date.getDate();

			switch (day) {
			case 1:
				monthlyReport.setDay1(timeKeepingStatus);
				break;
			case 2:
				monthlyReport.setDay2(timeKeepingStatus);
				break;
			case 3:
				monthlyReport.setDay3(timeKeepingStatus);
				break;
			case 4:
				monthlyReport.setDay4(timeKeepingStatus);
				break;
			case 5:
				monthlyReport.setDay5(timeKeepingStatus);
				break;
			case 6:
				monthlyReport.setDay6(timeKeepingStatus);
				break;
			case 7:
				monthlyReport.setDay7(timeKeepingStatus);
				break;
			case 8:
				monthlyReport.setDay8(timeKeepingStatus);
				break;
			case 9:
				monthlyReport.setDay9(timeKeepingStatus);
				break;
			case 10:
				monthlyReport.setDay10(timeKeepingStatus);
				break;
			case 11:
				monthlyReport.setDay11(timeKeepingStatus);
				break;
			case 12:
				monthlyReport.setDay12(timeKeepingStatus);
				break;
			case 13:
				monthlyReport.setDay13(timeKeepingStatus);
				break;
			case 14:
				monthlyReport.setDay14(timeKeepingStatus);
				break;
			case 15:
				monthlyReport.setDay15(timeKeepingStatus);
				break;
			case 16:
				monthlyReport.setDay16(timeKeepingStatus);
				break;
			case 17:
				monthlyReport.setDay17(timeKeepingStatus);
				break;
			case 18:
				monthlyReport.setDay18(timeKeepingStatus);
				break;
			case 19:
				monthlyReport.setDay19(timeKeepingStatus);
				break;
			case 20:
				monthlyReport.setDay20(timeKeepingStatus);
				break;
			case 21:
				monthlyReport.setDay21(timeKeepingStatus);
				break;
			case 22:
				monthlyReport.setDay22(timeKeepingStatus);
				break;
			case 23:
				monthlyReport.setDay23(timeKeepingStatus);
				break;
			case 24:
				monthlyReport.setDay24(timeKeepingStatus);
				break;
			case 25:
				monthlyReport.setDay25(timeKeepingStatus);
				break;
			case 26:
				monthlyReport.setDay26(timeKeepingStatus);
				break;
			case 27:
				monthlyReport.setDay27(timeKeepingStatus);
				break;
			case 28:
				monthlyReport.setDay28(timeKeepingStatus);
				break;
			case 29:
				monthlyReport.setDay29(timeKeepingStatus);
				break;
			case 30:
				monthlyReport.setDay30(timeKeepingStatus);
				break;
			case 31:
				monthlyReport.setDay31(timeKeepingStatus);
				break;
			default:
				break;
			}

			// insert
			if (monthlyReport.getId() == 0) {
				monthlyReport.setMemberId(memberId);
				monthlyReport.setMonth(date.getMonth() + 1);
				monthlyReport.setYear(date.getYear() + 1900);

				mrDAO.insert(monthlyReport);
			} else {
				// update
				mrDAO.update(monthlyReport);
			}
		}
	}

	/**
	 * insertMonthlyReport
	 * 
	 * @param monthlyReport
	 * @return
	 */
	public MonthlyReport insertMonthlyReport(MonthlyReport monthlyReport) {
		Member member = MemberController.Instance.getMemberById(monthlyReport
				.getMemberId());
		if (null != member) {
			monthlyReport.setOrgId(member.getOrgId());
			monthlyReport.setSubOrgId(member.getSubOrgId());
		}
		return mrDAO.insert(monthlyReport);
	}

	/**
	 * get MonthlyReportList By Date
	 * 
	 * @param orgId
	 * @param subOrgId
	 * @param startDate
	 * @param endDate
	 * @return
	 */
	public List<MonthlyReport> getMonthlyReportListByDate(long orgId,
			long subOrgId, String startDate, String endDate) {
		return mrDAO.getMonthlyReportListByDate(orgId, subOrgId, startDate,
				endDate);
	}

	/**
	 * update Repport
	 */
	@SuppressWarnings("deprecation")
	public void updateRepport() {
		MemberFilter memFilter = new MemberFilter();
		List<Member> listMember = MemberController.Instance
				.getAllMemberNotJournalist(-1, memFilter);
		int count = listMember.size();
		List<Long> listIdMember = new ArrayList<Long>();
		for (int i = 0; i < count; i++) {
			listIdMember.add(listMember.get(i).getId());
		}
		Date date = new Date();
		Date endDate = new Date();
		int endMonth = date.getMonth();
		int endDay = 0;
		switch (endMonth) {
		case 1:
		case 3:
		case 5:
		case 7:
		case 8:
		case 10:
		case 12:
			endDay = 31;
			break;
		case 4:
		case 6:
		case 9:
		case 11:
			endDay = 30;
			break;
		case 2:
			// su dung gan lai endMonth: :year,
			endMonth = date.getYear();
			endDay = (endMonth % 400 == 0)
					|| (endMonth % 4 == 0 && endMonth % 100 != 0) ? 29 : 28;
			break;
		}
		date.setDate(1);
		endDate.setDate(endDay);
		calculateMonthlyReport(listIdMember, date, endDate);
	}

	/**
	 * getMonthlyReportAfterUpdate
	 * 
	 * @param listIdMember
	 * @param dateBegin
	 * @param dateEnd
	 * @return
	 */
	public List<MonthlyReport> getMonthlyReportAfterUpdate(
			List<Long> listIdMember, Date dateBegin, Date dateEnd) {
		List<MonthlyReport> result = new ArrayList<MonthlyReport>();
		if (null != listIdMember && listIdMember.size() != 0) {
			List<MonthlyReport> month = new ArrayList<MonthlyReport>();
			calculateMonthlyReport(listIdMember, dateBegin, dateEnd);
			Member mem = MemberController.Instance.getMemberById(listIdMember
					.get(0));
			List<SubOrganization> listSubOrg = new ArrayList<SubOrganization>();
			listSubOrg = SubOrganizationController.Instance
					.getSubOrgByParentId(mem.getOrgId());
			int subListSize = listSubOrg.size();
			for (int i = 1; i < subListSize; i++) {
				// lay danh sach monthlyreport theo tung suborgid
				month = getMonthlyReportListByDate(mem.getOrgId(), listSubOrg
						.get(i).getSuborgid(), dateBegin.toString(),
						dateEnd.toString());
				result.addAll(month);
			}
		}
		return result;
	}
}
