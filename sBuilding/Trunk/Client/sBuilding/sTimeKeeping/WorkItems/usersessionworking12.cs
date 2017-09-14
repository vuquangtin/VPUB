using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sTimeKeeping.Model;

namespace sTimeKeeping.WorkItems
{
    /// <summary>
    /// class usersessionworking12 : UserControl
    /// </summary>
    public partial class usersessionworking12 : UserControl
    {
        public bool isShowChbx2 { get; set; }
        //20170308 Bug #741 [sTimeKeeping] Cau hinh thoi gian cham cong ca nhan - Trang Vo Start
        public bool isShowChbx3 { get; set; }
        //20170308 Bug #741 [sTimeKeeping] Cau hinh thoi gian cham cong ca nhan - Trang Vo End

        /// <summary>
        /// contructor usersessionworking12()
        /// </summary>
        public usersessionworking12()
        {
            InitializeComponent();
            this.isShowChbx2 = false;
            this.isShowChbx3 = false;
        }

        /// <summary>
        /// contructor usersessionworking12(int count, bool isShowChbx2, bool isShowChbx3)
        /// </summary>
        /// <param name="count"></param>
        /// <param name="isShowChbx2"></param>
        /// <param name="isShowChbx3"></param>
        public usersessionworking12(int count, bool isShowChbx2, bool isShowChbx3)
        {
            InitializeComponent();
            this.isShowChbx2 = isShowChbx2;
            this.isShowChbx3 = isShowChbx3;
            chbx1.Text = "Ca " + count.ToString();
            chbx1.TabIndex = count + 1;
            chbx2.Text = "Ca " + (count + 1).ToString();
            chbx2.TabIndex = count + 2;
            chbx3.Text = "Ca " + (count + 2).ToString();

            //20170308 Bug #741 [sTimeKeeping] Cau hinh thoi gian cham cong ca nhan - Trang Vo Start
            chbx3.TabIndex = count + 3;
            if (isShowChbx2) Show(count + 1);
            if (isShowChbx3) Show(count + 2);
            else Show(count);
            //20170308 Bug #741 [sTimeKeeping] Cau hinh thoi gian cham cong ca nhan - Trang Vo End
        }

        /// <summary>
        /// hide of show panel
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="flag"></param>
        private void HidenPanel(Panel panel, bool flag)
        {
            panel.Visible = flag;
            int s = panelc1.TabIndex;
            int i = panel.TabIndex;
        }

        /// <summary>
        /// show controll ẩn
        /// </summary>
        /// <param name="count"></param>
        public void Show(int count)
        {
            //20170308 Bug #741 [sTimeKeeping] Cau hinh thoi gian cham cong ca nhan - Trang Vo Start
            bool flag2 = count % 2 == 0 ? true : false;
            bool flag3 = count % 3 == 0 ? true : false;
            if (flag3) flag2 = true;
            HidenPanel(panelc2, flag2);
            HidenPanel(panelc3, flag3);
            //20170308 Bug #741 [sTimeKeeping] Cau hinh thoi gian cham cong ca nhan - Trang Vo End
        }

        /// <summary>
        /// thêm dữ liệu vào giao diện để show cho người dùng
        /// </summary>
        /// <param name="index"></param>
        /// <param name="sessionWorking"></param>
        public void Add(int index, SessionWorking sessionWorking)
        {
            // index == 0 thi hien cum control ca 1 Chbx1
            if (index == 0)
            {
                chbx1.Checked = sessionWorking.isCheckSession == 0 ? false : true;
                chbx1.Enabled = true;
                hoursBegin1.Text = sessionWorking.hoursBegin + string.Empty;
                muniteBegin1.Text = sessionWorking.minuteBegin + string.Empty;
                hoursEnd1.Text = sessionWorking.hoursEnd + string.Empty;
                muniteEnd1.Text = sessionWorking.minuteEnd + string.Empty;
            }

            // index == 1 thi hien thi cum control ca 2 Chbx2
            if (index == 1)
            {
                chbx2.Checked = sessionWorking.isCheckSession == 0 ? false : true;
                chbx2.Enabled = true;
                hoursBegin2.Text = sessionWorking.hoursBegin + string.Empty;
                muniteBegin2.Text = sessionWorking.minuteBegin + string.Empty;
                hoursEnd2.Text = sessionWorking.hoursEnd + string.Empty;
                muniteEnd2.Text = sessionWorking.minuteEnd + string.Empty;
            }

            //20170308 Bug #741 [sTimeKeeping] Cau hinh thoi gian cham cong ca nhan - Trang Vo Start
            // index == 2 thi hien thi cum control ca 3 Chbx3
            if (index == 2)
            {
                chbx3.Checked = sessionWorking.isCheckSession == 0 ? false : true;
                chbx3.Enabled = true;
                hoursBegin3.Text = sessionWorking.hoursBegin + string.Empty;
                muniteBegin3.Text = sessionWorking.minuteBegin + string.Empty;
                hoursEnd3.Text = sessionWorking.hoursEnd + string.Empty;
                muniteEnd3.Text = sessionWorking.minuteEnd + string.Empty;
            }
            //20170308 Bug #741 [sTimeKeeping] Cau hinh thoi gian cham cong ca nhan - Trang Vo End
        }

        /// <summary>
        /// Lấy dữ liệu để lưu DB
        /// </summary>
        /// <returns></returns>
        public List<SessionWorking> GetValueToSave()
        {
            List<SessionWorking> lstSessionWoking = new List<SessionWorking>();
            SessionWorking sessionWorking = null;

            // sessionWorking ca 1 Chbx1
            sessionWorking = new SessionWorking();
            sessionWorking.isCheckSession = chbx1.Checked == true ? chbx1.TabIndex : 0;
            sessionWorking.hoursBegin = int.Parse(hoursBegin1.Text);
            sessionWorking.minuteBegin = int.Parse(muniteBegin1.Text);
            sessionWorking.hoursEnd = int.Parse(hoursEnd1.Text);
            sessionWorking.minuteEnd = int.Parse(muniteEnd1.Text);
            lstSessionWoking.Add(sessionWorking);

            // sessionWorking ca 2 Chbx2
            if (isShowChbx2)
            {
                sessionWorking = new SessionWorking();
                sessionWorking.isCheckSession = chbx2.Checked == true ? chbx2.TabIndex : 0;
                sessionWorking.hoursBegin = int.Parse(hoursBegin2.Text);
                sessionWorking.minuteBegin = int.Parse(muniteBegin2.Text);
                sessionWorking.hoursEnd = int.Parse(hoursEnd2.Text);
                sessionWorking.minuteEnd = int.Parse(muniteEnd2.Text);
                lstSessionWoking.Add(sessionWorking);
            }

            //20170308 Bug #741 [sTimeKeeping] Cau hinh thoi gian cham cong ca nhan - Trang Vo Start
            // sessionWorking ca 3 Chbx3
            if (isShowChbx3)
            {
                sessionWorking = new SessionWorking();
                sessionWorking.isCheckSession = chbx3.Checked == true ? chbx3.TabIndex : 0;
                sessionWorking.hoursBegin = int.Parse(hoursBegin3.Text);
                sessionWorking.minuteBegin = int.Parse(muniteBegin3.Text);
                sessionWorking.hoursEnd = int.Parse(hoursEnd3.Text);
                sessionWorking.minuteEnd = int.Parse(muniteEnd3.Text);
                lstSessionWoking.Add(sessionWorking);
            }

            //20170308 Bug #741 [sTimeKeeping] Cau hinh thoi gian cham cong ca nhan - Trang Vo End
            return lstSessionWoking;
        }

        /// <summary>
        /// Set dữ liệu mặc định khi server trả về list rông chưa cấu hình với tổ chức
        /// </summary>
        public void SetDefaultValue()
        {
            // chbx1
            chbx1.Checked = false;
            chbx1.Enabled = false;
            hoursBegin1.Text = string.Empty;
            muniteBegin1.Text = string.Empty;
            hoursEnd1.Text = string.Empty;
            muniteEnd1.Text = string.Empty;

            // chbx2
            chbx2.Checked = false;
            chbx2.Enabled = false;
            hoursBegin2.Text = string.Empty;
            muniteBegin2.Text = string.Empty;
            hoursEnd2.Text = string.Empty;
            muniteEnd2.Text = string.Empty;

            //20170308 Bug #741 [sTimeKeeping] Cau hinh thoi gian cham cong ca nhan - Trang Vo Start
            // chbx3
            chbx3.Checked = false;
            chbx3.Enabled = false;
            hoursBegin3.Text = string.Empty;
            muniteBegin3.Text = string.Empty;
            hoursEnd3.Text = string.Empty;
            muniteEnd3.Text = string.Empty;
            //20170308 Bug #741 [sTimeKeeping] Cau hinh thoi gian cham cong ca nhan - Trang Vo End
        }
    }
}
