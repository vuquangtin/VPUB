using System;

namespace CommonHelper.Utils
{
    public static class ConvertDateToStringExtensions 
    {
        public static String ToStringFormatDate(this DateTime date)
        {
            return date.Date.ToString("dd/MM/yyyy");
        }

        public static String ToStringFormatDateServer(this DateTime date)
        {
            return date.Date.ToString("dd-MM-yyyy");
        }

        public static String ToStringFormatDateServeryyyyMMdd(this DateTime date)
        {
            return date.Date.ToString("yyyy-MM-dd");
        }
        public static String ToStringFormatDateFullServer(this DateTime date)
        {
            return String.Format("{0:dd-MM-yyyy HH:mm:ss}", date);
        }
   
    }

    public static class ConvertStringToDateExtensions 
    {
        public static DateTime ToDateFormatString(this String strDate)
        {
            strDate = strDate.Replace('-', '/');
            if (String.IsNullOrEmpty(strDate))
                return new DateTime();
            try
            {
                var culture = System.Globalization.CultureInfo.CurrentCulture;
                return DateTime.ParseExact(strDate, "dd/MM/yyyy", culture);
            }
            catch (System.Exception ex)
            {
                var culture = System.Globalization.CultureInfo.CurrentCulture;
                return DateTime.ParseExact(strDate, "MM/dd/yyyy", culture);
            }
        }

        public static DateTime ToDateTimeFormatString(this String strDate)
        {
            strDate = strDate.Replace('-', '/');
            if (String.IsNullOrEmpty(strDate))
                return new DateTime();
            try
            {
                var culture = System.Globalization.CultureInfo.CurrentCulture;
                DateTime result = DateTime.ParseExact(strDate, "dd/MM/yyyy HH:mm:ss", culture);
                return result;
            }
            catch (System.Exception ex)
            {
                var culture = System.Globalization.CultureInfo.CurrentCulture;
                return DateTime.ParseExact(strDate, "MM/dd/yyyy HH:mm:ss", culture);
            }
        }
    }
}
