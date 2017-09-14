using CommonHelper.Utils;
using sTimeKeeping.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Windows.Forms;

namespace sTimeKeeping.WorkItems
{
    /// <summary>
    /// class FrmEventDetail : Form
    /// </summary>
    public partial class FrmEventDetail : Form
    {
        // khai bao
        public Event eventObj;
        public ResourceManager rm;

        /// <summary>
        /// contructor 
        /// </summary>
        /// <param name="rm"></param>
        /// <param name="eventObj"></param>
        public FrmEventDetail(ResourceManager rm, Event eventObj)
        {
            // init 
            InitializeComponent();

            // gan gia tri
            this.eventObj = eventObj;
            this.rm = rm;
        }

        /// <summary>
        /// load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmEventDetail_Load(object sender, EventArgs e)
        {
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
            this.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.Name);

            // kiem tra eventObj nhan vao
            if (eventObj != null)
            {

                // load data len cac control
                DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                DateTime date = start.AddMilliseconds(long.Parse(eventObj.dateIn)).ToLocalTime();
                this.lblEvDetailName.Text = eventObj.eventName;
                this.lblEvDetailDateView.Text = date.ToString("dd/MM/yyyy");
                this.lblEvDetailTimeBeginView.Text = eventObj.hourEventBegin;
                this.lblEvDetailHourKeepView.Text = eventObj.hourEventKeeping + String.Empty;
                this.lblEvDetailDescriptionView.Text = eventObj.description;
            }
        }
    }
}
