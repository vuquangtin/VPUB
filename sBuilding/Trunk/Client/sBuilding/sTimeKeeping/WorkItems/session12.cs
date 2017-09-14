using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonControls;
using sTimeKeeping.Model;

namespace sTimeKeeping.WorkItems
{
    public partial class session12 : UserControl
    {
        public session12()
        {
            InitializeComponent();
        }
        /// <summary>
        /// lay du lieu cac controll ngay thu 2 de dong bo cho tat ca cac ngay con lai va dung de save database
        /// </summary>
        /// <returns></returns>
        public List<SessionWorking> GetValueToSyn()
        {

            List<SessionWorking> lstSessionWoking = new List<SessionWorking>();
            SessionWorking sessionWorking = null;

            sessionWorking = new SessionWorking();
            sessionWorking.isCheckSession = chbx1.Checked == true ? chbx2.TabIndex : 0;
            sessionWorking.hoursBegin = (int)hoursBegin1.Value;
            sessionWorking.minuteBegin = (int)muniteBegin1.Value;
            sessionWorking.hoursEnd = (int)hoursEnd1.Value;
            sessionWorking.minuteEnd = (int)muniteEnd1.Value;
            lstSessionWoking.Add(sessionWorking);

            sessionWorking = new SessionWorking();
            sessionWorking.isCheckSession = chbx2.Checked == true ? chbx1.TabIndex : 0;
            sessionWorking.hoursBegin = (int)hoursBegin2.Value;
            sessionWorking.minuteBegin = (int)muniteBegin2.Value;
            sessionWorking.hoursEnd = (int)hoursEnd2.Value;
            sessionWorking.minuteEnd = (int)muniteEnd2.Value;
            lstSessionWoking.Add(sessionWorking);

            sessionWorking = new SessionWorking();
            sessionWorking.isCheckSession = chbx3.Checked == true ? chbx3.TabIndex : 0;
            sessionWorking.hoursBegin = (int)hoursBegin3.Value;
            sessionWorking.minuteBegin = (int)muniteBegin3.Value;
            sessionWorking.hoursEnd = (int)hoursEnd3.Value;
            sessionWorking.minuteEnd = (int)muniteEnd3.Value;
            lstSessionWoking.Add(sessionWorking);

            return lstSessionWoking;
        }
        /// <summary>
        /// Lấy dữ liệu để lưu DB, chi kiem tra nhung ca nao co check moi add vao DB
        /// </summary>
        /// <returns></returns>
        public List<SessionWorking> GetValueToSave()
        {

            List<SessionWorking> lstSessionWoking = new List<SessionWorking>();
            SessionWorking sessionWorking = null;
            if (chbx2.Checked)
            {
                sessionWorking = new SessionWorking();
                sessionWorking.isCheckSession = chbx1.Checked == true ? chbx2.TabIndex : 0;
                sessionWorking.hoursBegin = (int)hoursBegin1.Value;
                sessionWorking.minuteBegin = (int)muniteBegin1.Value;
                sessionWorking.hoursEnd = (int)hoursEnd1.Value;
                sessionWorking.minuteEnd = (int)muniteEnd1.Value;
                lstSessionWoking.Add(sessionWorking);
            }
            if (chbx1.Checked)
            {
                sessionWorking = new SessionWorking();
                sessionWorking.isCheckSession = chbx2.Checked == true ? chbx1.TabIndex : 0;
                sessionWorking.hoursBegin = (int)hoursBegin2.Value;
                sessionWorking.minuteBegin = (int)muniteBegin2.Value;
                sessionWorking.hoursEnd = (int)hoursEnd2.Value;
                sessionWorking.minuteEnd = (int)muniteEnd2.Value;
                lstSessionWoking.Add(sessionWorking);
            }
            if (chbx3.Checked)
            {
                sessionWorking = new SessionWorking();
                sessionWorking.isCheckSession = chbx3.Checked == true ? chbx3.TabIndex : 0;
                sessionWorking.hoursBegin = (int)hoursBegin3.Value;
                sessionWorking.minuteBegin = (int)muniteBegin3.Value;
                sessionWorking.hoursEnd = (int)hoursEnd3.Value;
                sessionWorking.minuteEnd = (int)muniteEnd3.Value;
                lstSessionWoking.Add(sessionWorking);
            }
            return lstSessionWoking;
        }
        /// <summary>
        /// thêm dữ liệu vào giao diện để show cho người dùng
        /// </summary>
        /// <param name="index"></param>
        /// <param name="sessionWorking"></param>
        public void Add(int index, SessionWorking sessionWorking)
        {
            if (index == 0)
            {
                chbx1.Checked = sessionWorking.isCheckSession == 0 ? false : true;
                hoursBegin1.Value = sessionWorking.hoursBegin;
                muniteBegin1.Value = sessionWorking.minuteBegin;
                hoursEnd1.Value = sessionWorking.hoursEnd;
                muniteEnd1.Value = sessionWorking.minuteEnd;
            }
            if (index == 1)
            {
                chbx2.Checked = sessionWorking.isCheckSession == 0 ? false : true;
                hoursBegin2.Value = sessionWorking.hoursBegin;
                muniteBegin2.Value = sessionWorking.minuteBegin;
                hoursEnd2.Value = sessionWorking.hoursEnd;
                muniteEnd2.Value = sessionWorking.minuteEnd;
            }
            if (index == 2)
            {
                chbx3.Checked = sessionWorking.isCheckSession == 0 ? false : true;
                hoursBegin3.Value = sessionWorking.hoursBegin;
                muniteBegin3.Value = sessionWorking.minuteBegin;
                hoursEnd3.Value = sessionWorking.hoursEnd;
                muniteEnd3.Value = sessionWorking.minuteEnd;
            }
        }
        /// <summary>
        /// dua du lieu vao cac controll show len man hinh
        /// </summary>
        /// <param name="sessionWorking"></param>
        public void ToEntity(List<SessionWorking> sessionWorking)
        {
          //do lớp gọi hàm này đã kiểm tra khác null nên qua đây lấy được
                SessionWorking session1 = sessionWorking[0];

                //truong hop nay danh cho list gui qua co 1 phan tu ma checkbox nam o checkbox 2
                if (sessionWorking.Count == 1 && session1.isCheckSession % 2 == 0)
                {
                    chbx1.Checked = session1.isCheckSession == 0 ? false : true;
                    hoursBegin1.Value = session1.hoursBegin;
                    muniteBegin1.Value = session1.minuteBegin;
                    hoursEnd1.Value = session1.hoursEnd;
                    muniteEnd1.Value = session1.minuteEnd;
                }
                else
                {
                    chbx2.Checked = session1.isCheckSession == 0 ? false : true;
                    hoursBegin2.Value = session1.hoursBegin;
                    muniteBegin2.Value = session1.minuteBegin;
                    hoursEnd2.Value = session1.hoursEnd;
                    muniteEnd2.Value = session1.minuteEnd;
                }
            
            //kiem tra neu list co 2 phan moi append vao checbx thu 2
            if (sessionWorking.Count > 1)
            {
                SessionWorking session2 = sessionWorking[1];

                chbx2.Checked = session2.isCheckSession == 0 ? false : true;
                hoursBegin2.Value = session2.hoursBegin;
                muniteBegin2.Value = session2.minuteBegin;
                hoursEnd2.Value = session2.hoursEnd;
                muniteEnd2.Value = session2.minuteEnd;

            }
        }
        /// <summary>
        /// Set dữ liệu mặc định khi server trả về list rông chưa cấu hình với tổ chức
        /// </summary>
        public void SetDefaultValue()
        {
            chbx1.Checked = false;
            hoursBegin1.Value = 0;
            muniteBegin1.Value = 0;
            hoursEnd1.Value = 0;
            muniteEnd1.Value = 0;

            chbx2.Checked = false;
            hoursBegin2.Value = 0;
            muniteBegin2.Value = 0;
            hoursEnd2.Value = 0;
            muniteEnd2.Value = 0;

            chbx3.Checked = false;
            hoursBegin3.Value = 0;
            muniteBegin3.Value = 0;
            hoursEnd3.Value = 0;
            muniteEnd3.Value = 0;
        }
    }
}
