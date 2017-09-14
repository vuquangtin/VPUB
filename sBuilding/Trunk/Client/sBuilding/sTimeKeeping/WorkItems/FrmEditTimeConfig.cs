using sTimeKeeping.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sTimeKeeping.WorkItems
{
    public partial class FrmEditTimeConfig : Form
    {
        public FrmEditTimeConfig(TimeConfig timeConfig)
        {
            InitializeComponent();
            InitComponent(timeConfig);


        }

        private void InitComponent(TimeConfig timeConfig)
        {
             tbxDayOfWeek.Text = timeConfig.configDayOfWeek;
             txtSession.Text = "" + timeConfig.configSessions;
             numericHour.Value = timeConfig.configHourBegin.Hour;
             numericMinutes.Value = timeConfig.configHourBegin.Minute;
             cbxColor.Text = timeConfig.confidTimeColor;
             txtTimeLate1.Text = timeConfig.configHourLate1 + "";
             txtHourKeeping.Text = timeConfig.configHourKeeping + "";
             tbxDescription.Text = timeConfig.configTimeDecription;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {

        }

    
    }
}
