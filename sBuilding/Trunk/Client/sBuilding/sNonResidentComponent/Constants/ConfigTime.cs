using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace sNonResidentComponent.Constants
{
    public class ConfigTime
    {
        private System.Windows.Forms.Timer timer = null;

        public ConfigTime()
        {
        }

        #region Setting timer
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

    }
}
