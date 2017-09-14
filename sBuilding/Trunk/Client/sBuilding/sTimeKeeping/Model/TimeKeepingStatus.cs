using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sTimeKeeping.Model
{
    public enum TimeKeepingStatus : int
    {
        NGAY_NGHI_TRONG_TUAN = 0, 
        NGAY_LE = 1, 
        VANG_CA_NGAY_PHEP = 2, 
        VANG_CA_NGAY_KO_PHEP = 3, 
        VANG_NUA_NGAY_PHEP = 4,
        VANG_NUA_NGAY_KO_PHEP = 5,
        DI_TRE_VE_SOM = 6,
        LAM_VIEC_DUNG_GIO = 7
    }
    public class TimeKeepingStatusValue
    {

        /// <summary>
        /// lay 1 report cua 1 nguoi
        /// </summary>
        /// <param name="report"></param>
        /// <param name="memId"></param>
        /// <returns></returns>
        public static MonthlyReport getMonthlyReport(List<MonthlyReport> report, long memId)
        {
            foreach (MonthlyReport month in report)
            {
                if (month.memberId == memId)
                    return month;
            }
            return null;
        }

        /// <summary>
        /// ham tinh toan tong cong 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="report"></param>
        /// <param name="days"></param>
        /// <returns></returns>
        public static int getTotal(int type, MonthlyReport report, int days)
        {
            int cnt = 0;
            if (report.day1 == type) cnt++;
            if (report.day2 == type) cnt++;
            if (report.day3 == type) cnt++;
            if (report.day4 == type) cnt++;
            if (report.day5 == type) cnt++;
            if (report.day6 == type) cnt++;
            if (report.day7 == type) cnt++;
            if (report.day8 == type) cnt++;
            if (report.day9 == type) cnt++;
            if (report.day10 == type) cnt++;
            if (report.day11 == type) cnt++;
            if (report.day12 == type) cnt++;
            if (report.day13 == type) cnt++;
            if (report.day14 == type) cnt++;
            if (report.day15 == type) cnt++;
            if (report.day16 == type) cnt++;
            if (report.day17 == type) cnt++;
            if (report.day18 == type) cnt++;
            if (report.day19 == type) cnt++;
            if (report.day20 == type) cnt++;
            if (report.day21 == type) cnt++;
            if (report.day22 == type) cnt++;
            if (report.day23 == type) cnt++;
            if (report.day24 == type) cnt++;
            if (report.day25 == type) cnt++;
            if (report.day26 == type) cnt++;
            if (report.day27 == type) cnt++;
            if (days >= 28)
                if (report.day28 == type) cnt++;
            if (days >= 29)
                if (report.day29 == type) cnt++;
            if (days >= 30)
                if (report.day30 == type) cnt++;
            if (days >= 31)
                if (report.day31 == type) cnt++;

            return cnt;
        }

        /// <summary>
        /// get ki tu hien le thong ke thang, neu khong co gọi service tính toán lại
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetTypeName(int type)
        {
            switch (type)
            {
                case 6:
                    return "T";
                case 2:
                    return "P";
                case 4:
                    return "P1";
                case 3:
                    return "K";
                case 5:
                    return "K1";


            }
            return "";
        }
    }
}
