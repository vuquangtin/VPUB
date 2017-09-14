using System;
using System.Collections.Generic;
using System.Linq;

namespace sMeetingComponent.Constants
{
    public enum FunctionMeeting
    {
        NULL = 0,
        FUNC_MEETING = 500,
        FUNC_MEETING_SCHEDULE = 501,
        FUNC_MEETING_STATISTIC = 502,
        FUNC_MEETING_STATISTIC_DETAIL = 503,
        FUNC_MEETING_JOURNALIST_ATTENDMEETING = 504,
        FUNC_MEETING_JOURNALIST_STATISTIC = 505,
        FUNC_MEETING_JOURNALIST_STATISTIC_DETAIL = 506,

        FUNC_MEETING_STATISTIC_CONTACT_WORK = 507,
    }

    public static class FunctionMeetingExtMethod
    {

        public static string GetName(this FunctionMeeting function)
        {
            switch (function)
            {
                case FunctionMeeting.FUNC_MEETING:
                    return MeetingDefineName.MenuMeetingItem;
                case FunctionMeeting.FUNC_MEETING_SCHEDULE:
                    return MeetingDefineName.MenuMeetingItemScheduleAMeeting;
                case FunctionMeeting.FUNC_MEETING_STATISTIC:
                    return MeetingDefineName.MenuMeetingItemStatistic;
                case FunctionMeeting.FUNC_MEETING_STATISTIC_DETAIL:
                    return MeetingDefineName.MenuMeetingItemStatisticDetail;
                case FunctionMeeting.FUNC_MEETING_JOURNALIST_ATTENDMEETING:
                    return MeetingDefineName.MenuMeetingItemJournalistAttendMeeting;
                case FunctionMeeting.FUNC_MEETING_JOURNALIST_STATISTIC:
                    return MeetingDefineName.MenuMeetingItemStatisticOfJournalist;
                case FunctionMeeting.FUNC_MEETING_JOURNALIST_STATISTIC_DETAIL:
                    return MeetingDefineName.MenuMeetingItemStatisticDetailOfJournalist;
                case FunctionMeeting.FUNC_MEETING_STATISTIC_CONTACT_WORK:
                    return MeetingDefineName.MenuMeetingItemStatisticContactWork;
                default:
                    return "N/A";
            }
        }

        public static string GetDescription(this FunctionMeeting function)
        {
            switch (function)
            {
                case FunctionMeeting.FUNC_MEETING:
                    return "Kiểm soát hội họp";
                case FunctionMeeting.FUNC_MEETING_SCHEDULE:
                    return "Dời lịch họp";
                case FunctionMeeting.FUNC_MEETING_STATISTIC:
                    return "Thống kê hội họp";
                case FunctionMeeting.FUNC_MEETING_STATISTIC_DETAIL:
                    return "Thống kê chi tiết hội họp";
                case FunctionMeeting.FUNC_MEETING_JOURNALIST_ATTENDMEETING:
                    return "Kiểm soát báo chí";
                case FunctionMeeting.FUNC_MEETING_JOURNALIST_STATISTIC:
                    return "Thống kê báo chí tham dự họp";
                case FunctionMeeting.FUNC_MEETING_JOURNALIST_STATISTIC_DETAIL:
                    return "Thống kê chi tiết báo chí tham dự họp";
                case FunctionMeeting.FUNC_MEETING_STATISTIC_CONTACT_WORK:
                    return "Thống kê liên hệ công tác";
                default:
                    return "N/A";
            }
        }

        public static List<FunctionMeeting> GetAll()
        {
            return Enum.GetValues(typeof(FunctionMeeting)).Cast<FunctionMeeting>().ToList();
        }

        public static List<FunctionMeeting> GetModuleList()
        {
            Object[] attributeList = typeof(FunctionMeeting).GetCustomAttributes(typeof(StructuredAttribute), true);

            if (attributeList.Length > 0)
            {
                StructuredAttribute attribute = (StructuredAttribute)attributeList[0];
                long span = attribute.Span;

                List<FunctionMeeting> result = new List<FunctionMeeting>();
                FunctionMeeting[] functions = (FunctionMeeting[])Enum.GetValues(typeof(FunctionMeeting));
                long modIndex;

                foreach (FunctionMeeting f in functions)
                {
                    modIndex = (long)Convert.ChangeType(f, typeof(long));
                    if (f != FunctionMeeting.NULL && (modIndex % span) == 0)
                    {
                        result.Add(f);
                    }
                }
                return result;
            }
            else
            {
                return new List<FunctionMeeting>();
            }
        }

        public static List<FunctionMeeting> GetChildList(this FunctionMeeting parent)
        {
            List<FunctionMeeting> result = new List<FunctionMeeting>();
            FunctionMeeting[] functions = (FunctionMeeting[])Enum.GetValues(typeof(FunctionMeeting));
            Object[] attributeList = typeof(FunctionMeeting).GetCustomAttributes(typeof(StructuredAttribute), true);

            if (attributeList.Length > 0)
            {
                StructuredAttribute attribute = (StructuredAttribute)attributeList[0];
                long span = attribute.Span;
                long parentIndex, childIndex, index;

                foreach (FunctionMeeting f in functions)
                {
                    parentIndex = (long)Convert.ChangeType(parent, typeof(long));
                    childIndex = (long)Convert.ChangeType(f, typeof(long));
                    index = (childIndex / span) * span;
                    if (index == parentIndex && childIndex != parentIndex)
                    {
                        result.Add(f);
                    }
                }
                return result;
            }
            else
            {
                return new List<FunctionMeeting>();
            }
        }

        public static bool IsChildOf(this FunctionMeeting child, FunctionMeeting parent)
        {
            Object[] attributeList = typeof(FunctionMeeting).GetCustomAttributes(typeof(StructuredAttribute), true);

            if (attributeList.Length > 0)
            {
                StructuredAttribute attribute = (StructuredAttribute)attributeList[0];
                long span = attribute.Span;
                long parentIndex = (long)Convert.ChangeType(parent, typeof(long));
                long childIndex = (long)Convert.ChangeType(child, typeof(long));
                long index = (childIndex / span) * span;
                bool res = index == parentIndex && childIndex != parentIndex;
                return res;
            }

            return false;
        }

        public static bool IsParentOf(this FunctionMeeting parent, FunctionMeeting child)
        {
            return child.IsChildOf(parent);
        }

        public static FunctionMeeting GetParent(this FunctionMeeting child)
        {
            Object[] attributeList = typeof(FunctionMeeting).GetCustomAttributes(typeof(StructuredAttribute), true);

            if (attributeList.Length > 0)
            {
                StructuredAttribute attribute = (StructuredAttribute)attributeList[0];
                long span = attribute.Span;
                long childIndex = (long)Convert.ChangeType(child, typeof(long));
                long index = childIndex / span;
                long parentIndex = index * span;
                if (parentIndex == childIndex)
                {
                    return FunctionMeeting.NULL;
                }
                return (FunctionMeeting)(index * span);
            }
            return FunctionMeeting.NULL;
        }


        public static FunctionMeeting ToFunction(long longValue)
        {
            return (FunctionMeeting)longValue;
        }
    }

    [AttributeUsage(AttributeTargets.Enum)]
    public class StructuredAttribute : Attribute
    {
        public long span;

        public long Span
        {
            get { return span; }
            set { span = value; }
        }

        public StructuredAttribute(long span)
        {
            this.span = span;
        }
    }
}
