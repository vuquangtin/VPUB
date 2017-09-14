using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Web.Script.Serialization;
using sTimeKeeping.Factory;
using JavaCommunication;
using Newtonsoft.Json;

namespace sTimeKeeping.Model
{
    /// <summary>
    /// TimeDetail: class gom cac bien va ham static dung de tinh toan va ve giao dien thong ke cham cong
    /// </summary>
    public class TimeDetail
    {
        // list ngay le
        public static int yearCheckHoliday = -1;
        public static List<HolidayConfig> holidayOfOneYear = new List<HolidayConfig>();
        /// <summary>
        /// Tao va update list holiday cua 1 nam
        /// </summary>
        /// <param name="session"></param>
        /// <param name="orgId"></param>
        /// <param name="dateCheck"></param>
        /// <returns></returns>
        public static int checkHolidayOfOrg(string session, long orgId, DateTime dateCheck)
        {
            int year = dateCheck.Year;
            int check = (int)Status.FAILED;
            if (holidayOfOneYear == null || year != yearCheckHoliday)
            {
                yearCheckHoliday = year;

                holidayOfOneYear = TimeKeepingHolidayConfigFactory.Instance.GetChannel().getHolidayListByOrgIdAndYear(session, year, orgId);
                // TimeKeepingHolidayConfigFactory.Instance.GetChannel().checkHoliday(StorageService.CurrentSessionId, dateCheck, orgId);
            }
            // check
            if (checkHolidayOfDate(dateCheck))
                check = (int)Status.SUCCESS;
            return check;
        }
        /// <summary>
        /// check Holiday Of Date
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        private static bool checkHolidayOfDate(DateTime date)
        {
            DateTime dateBegin = DateTime.Now;
            DateTime dateEnd = DateTime.Now;
            String[] holidayDateString;

            foreach (HolidayConfig holiday in holidayOfOneYear)
            {
                // Split dateBegin & dateEnd
                holidayDateString = holiday.holidayStart.Split('/');
                dateBegin = new DateTime(Int32.Parse(holidayDateString[2]), Int32.Parse(holidayDateString[1]), Int32.Parse(holidayDateString[0]));
                holidayDateString = holiday.holidayEnd.Split('/');
                dateEnd = new DateTime(Int32.Parse(holidayDateString[2]), Int32.Parse(holidayDateString[1]), Int32.Parse(holidayDateString[0]));
                // so sanh dateStart < date < dateEnd
                if (dateBegin.CompareTo(date) <= 0 && date.CompareTo(dateEnd) <= 0)
                    return true;
            }
            return false;
        }

        // const cho colorConfigList
        public static List<ColorConfig> colorConfigList;
        public static List<ColorConfig> getColorConfigList(string session, long orgId)
            {
                if (colorConfigList == null || orgId != OrgId)
                {
                    colorConfigList = TimeKeepingColorConfigFactory.Instance.GetChannel().getColorConfigListByOrgId(session, orgId);
                }
                return colorConfigList;
            }

        // const cho timeConfig
        public static List<TimeConfig> timeConfig;
        public static List<TimeConfig> getTimeConfig(string session, long orgId)
        {
            if (timeConfig == null || orgId != OrgId)
            {
                timeConfig = TimeKeepingTimeConfigFactory.Instance.GetChannel().GetListTimeConfigByOrgId(session, orgId);
            }
            return timeConfig;
        }

        // tao 2 bien static de luu tru sesion và orgid
        public static string Session = String.Empty;
        public static long OrgId = -1;

        // for ListTimeDetailForBigSheet
        public static List<Shift> ListShift = null;     
        public static List<ColorConfig> colorConfigs = new List<ColorConfig>();
        public static List<ColorConfig> colorConfigListRight = new List<ColorConfig>();

        /// <summary>
        /// lay 3 danh sach timedetail cho sheet, dung cho user & date & month
        /// </summary>
        /// <param name="shiftList"></param>
        /// <param name="config"></param>
        /// <param name="ListUserTimeConfig"></param>
        /// <param name="dayoff"></param>
        /// <param name="date"></param>
        /// <param name="checkHoliday">0: SUCCESS, 1: FAILED</param>
        /// <returns></returns>
        public static List<List<TimeDetail>> ListTimeDetailForMiniSheet(List<Shift> shiftList, ConfigForStatisticDTO config, 
            List<List<UserTimeConfig>> ListUserTimeConfig, DayOffConfig dayoff, DateTime date, int checkHoliday)
        {
            //20170306 Bug Current day - Trang Vo Start
            DateTime dateCheck = DateTime.Now;
            dateCheck = dateCheck.AddHours(- dateCheck.Hour + 23);
            //20170306 Bug Current day - Trang Vo End
            List<List<TimeDetail>> listTimeDetail = new List<List<TimeDetail>>();

            // chuan bi du lieu
            if (null == shiftList) shiftList = new List<Shift>();
            if (null == colorConfigList) colorConfigList = new List<ColorConfig>();
            if (null == timeConfig) timeConfig = new List<TimeConfig>();

            // color
            colorConfigs = cloneColor(colorConfigList);
            colorConfigListRight = colorConfigList;
            if (null == colorConfigs) colorConfigListRight = colorConfigs = new List<ColorConfig>();
            if (dateCheck < date)
            {
                for (int i = 0; i < colorConfigs.Count; i++)
                {
                    colorConfigs[i].colorId = 15;
                }
            }

            List<TimeDetail> list = new List<TimeDetail>();

            // TO DO CONVERT TO LIST TIMEDETAIL
            // lay cau hinh thoi gian cham cong cua ngay hien tai
            TimeConfig curTimeConfig = new TimeConfig();

            // ngay dang chon
            int selected_date = (int)date.DayOfWeek + 1;

            foreach (TimeConfig time in timeConfig)
            {
                // kiem tra ngay 
                if (selected_date == time.dayOfWeek)
                {
                    curTimeConfig = time;
                    break;
                }
                else
                {
                    // kiem tra chu nhat
                    if (time.dayOfWeek == 8 && selected_date == 1)
                    {
                        curTimeConfig = time;
                        break;
                    }
                }
            }

            List<SessionWorking> curSessionWorking = ConvertFromStringToListSessionWorking(curTimeConfig.sessionWorking);
            int curHourBegin = curSessionWorking[0].hoursBegin, curMinuteBegin = curSessionWorking[0].minuteBegin,
                curHourEnd = curSessionWorking[curSessionWorking.Count - 1].hoursEnd, curMinuteEnd = curSessionWorking[curSessionWorking.Count - 1].minuteEnd;
            
            // kiem tra ngay lễ
            if (checkHoliday == (int)Status.SUCCESS)
            {
                // neu co cho doan giua mau nghỉ lễ
                list.Add(getTimeDetail(getColor(colorConfigs, (long)ColorEventId.holiday), curHourBegin, curMinuteBegin,
                    curHourEnd, curMinuteEnd, Straight.Holiday, Straight.Holiday));
                listTimeDetail.Add(list);
                return listTimeDetail;
            }
            else
            {
                // neu khong la le
                // get cau hinh thoi gian giua 2 lan tag

                // kiem tra ngay nghi thu 7, chu nhat
                if (null == config || null == config.sessionWorking)
                {
                    list.Add(getTimeDetail(getColor(colorConfigs, (long)ColorEventId.break_time), curHourBegin, curMinuteBegin,
                        curHourEnd, curMinuteEnd, Straight.Quitting, Straight.Quitting));
                    listTimeDetail.Add(list);
                    return listTimeDetail;
                }
                else
                {
                    // tao bien string sessionworking
                    string stringSessionWorking = config.sessionWorking;

                    // check ListUserTimeConfig
                    if (null == ListUserTimeConfig || ListUserTimeConfig.Count == 0)
                    {
                        stringSessionWorking = config.sessionWorking;
                    }
                    else
                    {
                        int size = ListUserTimeConfig[0].Count();
                        // load config for new panel
                        for (int i = 0; i < size; i++)
                        {
                            UserTimeConfig userTimeConfig = ListUserTimeConfig[0][i];
                            if (userTimeConfig.dayOfWeek == (selected_date - 1))
                            {
                                stringSessionWorking = userTimeConfig.sessionWorking;
                            }
                        }
                    }

                    // lay list event va list sesionworking
                    List<Event> evList = config.eventList;
                    if (null == evList) evList = new List<Event>();
                    List<SessionWorking> sessionWorking = ConvertFromStringToListSessionWorking(stringSessionWorking);

                    // check dayoff
                    if (null != dayoff)
                    {
                        // Tinh dayof cua nhan vien trong ngay lam viec binh thuong
                        list.Add(getTimeDetail(getColor(colorConfigs, (long)ColorEventId.off_day), curHourBegin, curMinuteBegin,
                            curHourEnd, curMinuteEnd, Straight.Quitting, Straight.Quitting));
                        listTimeDetail.Add(list);
                        return listTimeDetail;
                    }
                    else
                    {
                        // tao list Straight
                        List<Straight> strList = GetStraight(evList, sessionWorking, shiftList);
                        long colorEvId = 0;
                        // kiem tra list Straight

                        // neu chi chua sessionworking thi cho nhan vien nghi nguyen ngay 
                        for (int i = 0; i < strList.Count - 1; i++)
                        {
                            // xac dinh mau
                            colorEvId = FindColorStraight(i, shiftList, strList, evList, sessionWorking);
                            // them vao detail list
                            list.Add(getTimeDetail(getColor(colorConfigs, colorEvId), strList[i].Hour, strList[i].Minute, strList[i + 1].Hour, strList[i + 1].Minute, strList[i].Id, strList[i + 1].Id));
                        }
                        // tim 3 list time detail
                        List<TimeDetail> listLeft = new List<TimeDetail>();
                        List<TimeDetail> listFill = new List<TimeDetail>();
                        List<TimeDetail> listRight = new List<TimeDetail>();

                        // gia tri index de add TimeDetail vao cac lists
                        int t1 = -1, t2 = -1;

                        // duyet tim gia tri index de add TimeDetail vao cac lists
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (list[i].HourBegin == sessionWorking[0].hoursBegin && list[i].MinuteBegin == sessionWorking[0].minuteBegin)
                                t1 = i;
                            if (list[i].HourBegin == sessionWorking[sessionWorking.Count - 1].hoursEnd && list[i].MinuteBegin == sessionWorking[sessionWorking.Count - 1].minuteEnd)
                                t2 = i;
                        }
                        if (t2 == -1) t2 = list.Count;

                        // duyet add TimeDetail vao cac lists
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (i < t1)
                                listLeft.Add(list[i]);
                            else
                                if (i < t2)
                                    listFill.Add(list[i]);
                                else
                                    listRight.Add(list[i]);
                        }

                        // add 3 list tra ve
                        listTimeDetail.Add(listLeft);
                        listTimeDetail.Add(listFill);
                        listTimeDetail.Add(listRight);
                    }
                }
            }
            return listTimeDetail;
        }

        /// <summary>
        /// cloneColor
        /// </summary>
        /// <param name="colorConfigs"></param>
        /// <returns></returns>
        private static List<ColorConfig> cloneColor(List<ColorConfig> colorConfigs)
        {
            List<ColorConfig> result = new List<ColorConfig>();
            ColorConfig newColor;
            foreach (ColorConfig color in colorConfigs)
            {
                newColor = new ColorConfig();
                newColor.orgId = color.orgId;
                newColor.colorConfigId = color.colorConfigId;
                newColor.colorId = color.colorId;
                newColor.colorConfigNameId = color.colorConfigNameId;
                result.Add(newColor);
            }
            return result;
        }

        /// <summary>
        /// ConvertFrom String To Time
        /// </summary>
        /// <param name="strTime"></param>
        /// <returns></returns>
        private static DateTime ConvertFromStringToTime(string strTime)
        {
            DateTime timeFormat = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            DateTime timeResult = timeFormat.AddMilliseconds(long.Parse(strTime)).ToLocalTime();
            return timeResult;
        }

        /// <summary>
        /// getTimeDetail
        /// </summary>
        /// <param name="color"></param>
        /// <param name="hourBegin"></param>
        /// <param name="minuteBegin"></param>
        /// <param name="hourEnd"></param>
        /// <param name="minuteEnd"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        private static TimeDetail getTimeDetail(Color color, int hourBegin, int minuteBegin,
                                         int hourEnd, int minuteEnd, long idB, long idE)
        {
            TimeDetail timeDetail = new TimeDetail(color, hourBegin, minuteBegin,
                                                    hourEnd, minuteEnd, idB, idE);
            return timeDetail;
        }
        /// <summary>
        /// getColor by colorEventId
        /// </summary>
        /// <param name="colorConfigs"></param>
        /// <param name="colorEventId"></param>
        /// <returns></returns>
        public static Color getColor(List<ColorConfig> colorConfigs, long colorEventId)
        {
            long colorId = -1;
            foreach (ColorConfig colorConfig in colorConfigs)
            {
                if (colorConfig.colorConfigNameId == colorEventId)
                {
                    colorId = colorConfig.colorId;
                    break;
                }
            }
            if (-1 == colorId) colorId = (long)ColorValueName.black;
            Color color = ColorTranslator.FromHtml(ColorValue.getColorValue((ColorValueName)colorId));
            return color;
        }

        /// <summary>
        /// Convert From String To List SessionWorking
        /// </summary>
        /// <param name="strJson"></param>
        /// <returns> list object session working on day </returns>
        private static List<SessionWorking> ConvertFromStringToListSessionWorking(string strJson)
        {
            var jsonSerializer = new JavaScriptSerializer();
            List<SessionWorking> sessionWorkings = new List<SessionWorking>();
            if (null == strJson)
            {
                SessionWorking obj = new SessionWorking();
                sessionWorkings.Add(obj);
            }
            else
            {
                sessionWorkings = jsonSerializer.Deserialize<List<SessionWorking>>(strJson);
            }

            return sessionWorkings;
        }

        /// <summary>
        /// tim colorid cho 1 doan straight
        ///   Co the co 3 gia tri:  event_day
        ///                         day_work_time 
        ///                         day_off
        /// </summary>
        /// <param name="str01"></param>
        /// <param name="str02"></param>
        /// <param name="evList"></param>
        /// <param name="ssList"></param>
        /// <returns></returns>
        private static long FindColorStraight(int index, List<Shift> shList, List<Straight> stList, List<Event> evList, List<SessionWorking> ssList)
        {
            // get cau hinh chung thoi gian giua 2 lan tag the
            GeneralConfig gConfig = TimeKeepingGeneralConfigFactory.Instance.GetChannel().getGeneralConfigByOrgId(Session, OrgId);
            // int indexOfShift = 0;
            long color = 0;
            Straight str01 = stList[index], str02 = stList[index + 1];
            int h = 0, h1 = 0;
            int m = 0, m1 = 0;
            // theo do uu tien cua event
            foreach (Event ev in evList)
            {
                string[] time = ev.hourEventBegin.Split(':');
                h = int.Parse(time[0]);
                m = int.Parse(time[1]);
                h1 = h + ev.hourEventKeeping;
                if (((str01.Hour == h && str01.Minute >= m) || (str01.Hour > h)) &&
                    ((str02.Hour == h1 && str02.Minute <= m) || (str02.Hour < h1)))
                {
                    if ((str01.Id == Straight.Stripe && str02.Id == Straight.Session1)
                         || (str01.Id == Straight.Session2 && str02.Id == Straight.Stripe))
                    {
                        return 0;
                    }
                    return (long)ColorEventId.event_day;
                }
            }
            // theo do uu tien sessionworking
            foreach (SessionWorking ss in ssList)
            {
                h = ss.hoursBegin; h1 = ss.hoursEnd;
                m = ss.minuteBegin; m1 = ss.minuteEnd;
                if (((str01.Hour == h && str01.Minute >= m) || (str01.Hour > h)) &&
                    ((str02.Hour == h1 && str02.Minute <= m1) || (str02.Hour < h1)))
                {


                    // day_off
                    if (null == evList || evList.Count == 0)
                    {
                        if (null == shList || shList.Count == 0)
                        {
                            if ((str01.Id == Straight.Stripe && str02.Id == Straight.Session1)
                            || (str01.Id == Straight.Session2 && str02.Id == Straight.Stripe))
                            {
                                return 0;
                            }
                            return (long)ColorEventId.off_day;
                        }
                    }
                    // stripe
                    if ((str01.Id == Straight.Stripe && str02.Id == Straight.Session1)
                          || (str01.Id == Straight.Session2 && str02.Id == Straight.Stripe))
                    {
                        return 0;
                    }
                    // session1 && shift
                    if (str01.Id == Straight.Session1 && str02.Id >= 0)
                    {
                        // kiem tra tre
                        if (index == 1 || stList[index - 2].Id == Straight.Stripe)
                            return (long)ColorEventId.late;
                    }
                    // sesion1 && sesion2
                    if (str01.Id == Straight.Session1 && str02.Id == Straight.Session2)
                    {
                        if (shList.Count > 1)
                        {
                            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                            DateTime bTime = start.AddMilliseconds(long.Parse(shList[0].dateIn)).ToLocalTime();
                            DateTime eTime = start.AddMilliseconds(long.Parse(shList[shList.Count - 1].dateIn)).ToLocalTime();
                            DateTime timeNow = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                            if (((bTime.Hour < str01.Hour) || (bTime.Hour == str01.Hour && bTime.Minute <= str01.Minute)) &&
                                ((eTime.Hour > str02.Hour) || (eTime.Hour == str02.Hour && eTime.Minute >= str02.Minute)))
                                return (long)ColorEventId.day_work_time;
                            if ((bTime.CompareTo(timeNow) >= 0) &&
                                (bTime.Hour < str01.Hour) || (bTime.Hour == str01.Hour && bTime.Minute <= str01.Minute))
                                return (long)ColorEventId.day_work_time;
                        }

                        return (long)ColorEventId.off_half;
                    }
                    // shift && sesion2
                    if (str01.Id >= 0 && str02.Id == Straight.Session2)
                    {
                        int iSession1 = GetSession1Index(index, stList);
                        int iSh = GetIndexShiftOfList(str01, shList);
                        DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                        DateTime bTime = start.AddMilliseconds(long.Parse(shList[0].dateIn)).ToLocalTime();
                        DateTime timeNow = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                        // kiem tra ngay co nho hon ngay hien tai thi set mau 
                        if (shList.Count == 1 && bTime.CompareTo(timeNow) < 0)
                        {
                            return (long)ColorEventId.off_day;
                        }
                        if (shList.Count > 1)
                        {
                            if (null != gConfig)
                            {
                                GeneralConfigTime timeConfig = ConvertStringJsonToObject(gConfig.generalConfigJson).cardTag;
                                DateTime eTime = start.AddMilliseconds(long.Parse(shList[shList.Count - 1].dateIn)).ToLocalTime();
                                if (bTime.CompareTo(timeNow) < 0 && ((timeConfig.type == 0 ? timeConfig.value : timeConfig.value * 60)
                                    > (eTime.Hour * 60 + eTime.Minute) - (bTime.Hour * 60 + bTime.Minute)))
                                {
                                    return (long)ColorEventId.off_day;
                                }
                            }

                        }
                        // chi tag 1 lan trong 1 ca thi tinh la bat dau ca
                        if (stList[index - 1].Id != Straight.Session1)
                        {
                            // kiem tra lam them gio
                            if ((stList.Count - 1 >= index + 3) && (stList[index + 3].Id >= 0))
                            {
                                return (long)ColorEventId.day_work_time;
                            }
                            // if (iSession1 > 1 && stList[iSession1 - 2].Id >= 0)
                            return (long)ColorEventId.late;
                        }
                        if (iSession1 > 1 && stList[iSession1 - 2].Id >= 0)
                            return (long)ColorEventId.late;
                    }
                    // session && event
                    if ((str01.Id == Straight.Session1 && str02.Id == Straight.Event1)
                        || (str01.Id == Straight.Event2 && str02.Id == Straight.Session2))
                    {
                        // nghi nguyen ngay khong tag the
                        if (null == shList || shList.Count == 0)
                            return (long)ColorEventId.off_day;
                        // di lam nguyen ngay
                        if (shList.Count > 1)
                        {
                            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                            DateTime bTime = start.AddMilliseconds(long.Parse(shList[0].dateIn)).ToLocalTime();
                            DateTime eTime = start.AddMilliseconds(long.Parse(shList[shList.Count - 1].dateIn)).ToLocalTime();
                            // co tag the truoc va sau doan str01-str02
                            if ((bTime.Hour <= str01.Hour || (bTime.Hour == str01.Hour && bTime.Minute <= str01.Minute))
                                && (str02.Hour <= eTime.Hour || (str02.Hour == eTime.Hour && str02.Minute <= eTime.Minute)))
                                return (long)ColorEventId.day_work_time;
                        }

                        return (long)ColorEventId.off_half;
                    }
                    // Session && Stripe
                    if ((str01.Id == Straight.Session1 && str02.Id == Straight.Stripe)
                        || (str01.Id == Straight.Stripe && str02.Id == Straight.Session2))
                    {
                        return 0;
                    }
                    return (long)ColorEventId.day_work_time;
                }
            }
            color = (long)ColorEventId.break_time;


            return color;
        }

        /// <summary>
        /// Đổi chuỗi string Json sang một đối tượng
        /// </summary>
        /// <param name="strJson"></param>
        /// <returns></returns>
        private static GeneralConfigJson ConvertStringJsonToObject(string strJson)
        {
            var jsonSerializer = new JavaScriptSerializer();
            GeneralConfigJson gConfigJson = jsonSerializer.Deserialize<GeneralConfigJson>(strJson);

            return gConfigJson;
        }

        /// <summary>
        /// Get Index Shift Of List
        /// </summary>
        /// <param name="str01"></param>
        /// <param name="shList"></param>
        /// <returns></returns>
        private static int GetIndexShiftOfList(Straight str01, List<Shift> shList)
        {
            DateTime stTem = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            for (int i = 0; i < shList.Count; i++)
            {
                DateTime stDate = stTem.AddMilliseconds(long.Parse(shList[i].dateIn)).ToLocalTime();
                if (str01.Hour == stDate.Hour && str01.Minute == stDate.Minute)
                    return i;
            }
            return -1;
        }

        /// <summary>
        /// Get Session1 Index
        /// </summary>
        /// <param name="index"></param>
        /// <param name="stList"></param>
        /// <returns></returns>
        private static int GetSession1Index(int index, List<Straight> stList)
        {
            for (; index >= 0; index--)
            {
                if (stList[index].Id == Straight.Session1)
                    return index;
            }
            return -1;
        }

        /// <summary>
        /// Get Time Shift
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        private static List<int> GetTimeShift(string date)
        {
            List<int> timeList = new List<int>();
            DateTime stTem = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            DateTime stDate = stTem.AddMilliseconds(long.Parse(date)).ToLocalTime();
            timeList.Add(stDate.Hour);
            timeList.Add(stDate.Minute);
            return timeList;
        }

        /// <summary>
        /// tim danh sach cac Straight
        /// </summary>
        /// <param name="evList"></param>
        /// <param name="ssList"></param>
        /// <param name="shList"></param>
        /// <returns></returns>
        private static List<Straight> GetStraight(List<Event> evList, List<SessionWorking> ssList, List<Shift> shList)
        {
            List<Straight> strList = new List<Straight>();
            Straight strTmp = null;
            int h = 0;
            int m = 0;
            // add sessionworking
            for (int i = 0; i < ssList.Count; i++)
            {
                strTmp = new Straight(ssList[i].hoursBegin, (ssList[i].minuteBegin), Straight.Stripe);
                strList.Add(strTmp);
                strTmp = new Straight(ssList[i].hoursBegin, ssList[i].minuteBegin, Straight.Session1);
                strList.Add(strTmp);
                strTmp = new Straight(ssList[i].hoursEnd, ssList[i].minuteEnd, Straight.Session2);
                strList.Add(strTmp);
                if (i < ssList.Count - 1 || ssList.Count == 1)
                {
                    strTmp = new Straight(ssList[i].hoursEnd, (ssList[i].minuteEnd), Straight.Stripe);
                    strList.Add(strTmp);
                }
            }
            // add event theo thoi gian
            foreach (Event ev in evList)
            {
                string[] time = ev.hourEventBegin.Split(':');
                h = int.Parse(time[0]);
                m = int.Parse(time[1]);
                strTmp = new Straight(h, m, Straight.Event1);
                strList = AddStraight(strList, strTmp);
                strTmp = new Straight(h + ev.hourEventKeeping, m, Straight.Event2);
                strList = AddStraight(strList, strTmp);
            }
            // add shift theo thoi gian
            GeneralConfig generalConfig = TimeKeepingGeneralConfigFactory.Instance.GetChannel().getGeneralConfigByOrgId(Session, OrgId);
            GeneralConfigJson genJson = convertStringJsonToObject(generalConfig.generalConfigJson);
            GeneralConfigTime cardTag = genJson.cardTag;
            // time
            if (null != shList && shList.Count > 0)
            {
                DateTime stTem = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                DateTime stDate = stTem.AddMilliseconds(long.Parse(shList[0].dateIn)).ToLocalTime();
                Straight shiftTmp = new Straight(stDate.Hour, stDate.Minute, shList[0].Id);
                strList = AddStraight(strList, shiftTmp);
                for (int i = 1; i < shList.Count; i++)
                {
                    stDate = stTem.AddMilliseconds(long.Parse(shList[i].dateIn)).ToLocalTime();
                    strTmp = new Straight(stDate.Hour, stDate.Minute, shList[i].Id);
                    if (((strTmp.Hour * 60 + strTmp.Minute) - (shiftTmp.Hour * 60 + shiftTmp.Minute)) > (cardTag.type == 0 ? cardTag.value : cardTag.value * 60))
                        strList = AddStraight(strList, strTmp);
                }
            }
            return strList;
        }

        /// <summary>
        /// Add Straight theo do uu tien thoi gian
        /// </summary>
        /// <param name="strList"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        private static List<Straight> AddStraight(List<Straight> strList, Straight str)
        {
            int cnt = -1;
            List<Straight> listTmp = new List<Straight>();
            for (int i = 0; i < strList.Count; i++)
            {
                //if ((str.Hour * 60 + str.Minute) == (strList[i].Hour * 60 + strList[i].Minute))
                //{
                //    return strList;
                //}
                if ((str.Hour * 60 + str.Minute) < (strList[i].Hour * 60 + strList[i].Minute))
                {
                    cnt = i;
                    break;
                }
            }
            if (cnt == -1)
            {
                strList.Add(str);
            }
            else
            {
                // copy doan thay doi sang list #
                for (int i = cnt; i < strList.Count; i++)
                {
                    listTmp.Add(strList[i]);
                }
                // remove doan thay doi
                for (int i = strList.Count - 1; i >= cnt; i--)
                {
                    strList.RemoveAt(i);
                }
                // them moi 1 doi tuong o giua
                strList.Add(str);
                // them doan da xoa
                for (int i = 0; i < listTmp.Count; i++)
                {
                    strList.Add(listTmp[i]);
                }
            }
            return strList;
        }

        /// <summary>
        ///  Đổi chuỗi string Json sang một đối tượng 
        /// </summary>
        /// <param name="strJson"></param>
        /// <returns></returns>
        private static GeneralConfigJson convertStringJsonToObject(string strJson)
        {
            var jsonSerializer = new JavaScriptSerializer();
            GeneralConfigJson gConfigJson = jsonSerializer.Deserialize<GeneralConfigJson>(strJson);
            return gConfigJson;
        }

        #region Properties

        public TimeDetail(System.Drawing.Color color, int HourBegin, int MinuteBegin, int HourEnd, int MinuteEnd, long idB, long idE)
        {
            this.Color = color;
            this.HourBegin = HourBegin;
            this.MinuteBegin = MinuteBegin;
            this.HourEnd = HourEnd;
            this.MinuteEnd = MinuteEnd;
            this.idBegin = idB;
            this.idEnd = idE;
        }

        public System.Drawing.Color Color { get; set; }
        public int HourBegin { get; set; }
        public int MinuteBegin { get; set; }
        public int HourEnd { get; set; }
        public int MinuteEnd { get; set; }
        public long idBegin { get; set; }
        public long idEnd { get; set; }

        #endregion
    }

    /// <summary>
    /// class Straight
    /// </summary>
    public class Straight
    {
        public const long Holiday = -1, Quitting = -2, Session1 = -3, Session2 = -4, Stripe = -5, Event1 = -6, Event2 = -7;
        public int Hour { get; set; }
        public int Minute { get; set; }
        public long Id { get; set; }

        public Straight(int Hour, int Minute, long Id)
        {
            this.Hour = Hour;
            this.Minute = Minute;
            this.Id = Id;
        }
    }
}
