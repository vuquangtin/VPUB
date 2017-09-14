using System;
using System.Configuration;

namespace sMeetingComponent.Constants
{
    public class ConfigTime
    {
        public ConfigTime()
        {
        }

        #region Setting timer

        /// <summary>
        /// SET TIME FOR SHOW MESSAGE
        /// Set thời gian để hiển thị tin nhắn thông báo
        /// </summary>
        /// <returns></returns>
        public int SetTime()
        {
            string timerStr = "";
            int timerInt = 3000;
            try
            {
                timerStr = ConfigurationManager.AppSettings["timer"];
            }
            catch (Exception ex)
            {
            }
            if (timerStr != null)
            {
                if (timerStr.Equals(""))
                {
                    timerInt = 3000;
                }
                else
                {
                    timerInt = Convert.ToInt32(timerStr);
                }
            }
            return timerInt;

        }

        #endregion

        #region Setting previous minutes

        /// <summary>
        /// GetPreviousMinutes 
        /// CHƯA SỬ DỤNG
        /// </summary>
        /// <returns></returns>
        public int GetPreviousMinutes()
        {
            string timerStr = "";
            int timerInt = 60;
            try
            {
                timerStr = ConfigurationManager.AppSettings["previousminutes"];
            }
            catch (Exception ex)
            {
            }
            if (timerStr != null)
            {

                if (timerStr.Equals(""))
                {
                    timerInt = 60;
                }
                else
                {
                    timerInt = Convert.ToInt32(timerStr);
                }
            }
            return timerInt;
        }

        #endregion

    }
}
