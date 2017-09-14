﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sTimeKeeping.Model;
using CommonControls;
using Microsoft.Practices.CompositeUI;
using sWorldModel;
using CommonHelper.Constants;
using System.Resources;
using CommonHelper.Utils;
using sTimeKeeping.Factory;

namespace sTimeKeeping.WorkItems
{
    /// <summary>
    ///  class sheet1 : UserControl   
    /// mini sheet for userstatistic & datestatistic
    /// </summary>
    public partial class sheet1 : UserControl
    {
        // khai bao bien
        private FrmShiftImage frmShImage = new FrmShiftImage(0);
        private FrmEventDetail frmEvDetail;
        private int index;
        private string name;
        private ResourceManager rm;
        private List<Event> listEventObj;

        private List<List<TimeDetail>> timeDetailList;
        //private TimeDetail timePre;

        // workItem
        private TimeKeepingComponentWorkItem workItem;
        [ServiceDependency]
        public TimeKeepingComponentWorkItem WorkItem
        {
            set { workItem = value; }
        }

        // storageService
        private ILocalStorageService storageService;

        public ILocalStorageService StorageService
        {
            get
            {
                if (storageService == null)
                {
                    storageService = workItem.Services.Get<ILocalStorageService>();
                }
                return storageService;
            }
        }

        /// <summary>
        /// Constructor nhan 3 list timedetail cho 2 doan thoi gian
        /// </summary>
        /// <param name="index"></param>
        /// <param name="name"></param>
        /// <param name="timeDetailListLeft"></param>
        /// <param name="timeDetailList"></param>
        /// <param name="timeDetailListRight"></param>
        public sheet1(int index, string name, List<List<TimeDetail>> timeDetailList, List<Event> listEventObj)
        {
            InitializeComponent();
            this.index = index;
            this.name = name;
            this.timeDetailList = timeDetailList;
            this.listEventObj = listEventObj;
        }

        /// <summary>
        /// show time Detail
        /// </summary>
        /// <param name="timeDetailList"></param>
        private void SetTimeDetail(string name, List<TimeDetail> timeDetailList)
        {
            //set member name
            lblMemberName.Text = name;

            if (null != timeDetailList && timeDetailList.Count != 0)
            {
                TimeDetail timeBegin = timeDetailList[0], timeEnd = timeDetailList[timeDetailList.Count - 1];

                // set cho lable dau tien
                Label lblBegin = new Label();
                lblBegin.Font = new Font(lblBegin.Font.FontFamily, 7, FontStyle.Bold);
                lblBegin.Width = 30;
                lblBegin.Height = 10;
                lblBegin.Name = timeBegin.idBegin.ToString();
                int minuteBegin = timeBegin.MinuteBegin;

                // tinh toan lblBegin
                lblBegin.Text = timeBegin.HourBegin + ":" + (minuteBegin == 0 ? "00"
                    : (minuteBegin < 10) ? "0" + minuteBegin : "" + minuteBegin);
                lblBegin.Location = new Point(pnlDetailLeft.Location.X + pnlDetailLeft.Width - 20, pnlDetailLeft.Location.Y);

                // add vao pnlTime
                pnlTime.Controls.Add(lblBegin);

                //set hover event 
                if (timeBegin.idBegin != Straight.Session1 && timeBegin.idBegin != Straight.Session2
                    && timeBegin.idBegin != Straight.Stripe && timeBegin.idBegin != Straight.Quitting)
                {
                    // MouseHover && MouseLeave
                    lblBegin.MouseHover += lbl_MouseHover;
                    lblBegin.MouseLeave += lbl_MouseLeave;
                }

                // add lable & add time
                int sumHourConfig = (timeEnd.HourEnd * 60 + timeEnd.MinuteEnd) - (timeBegin.HourBegin * 60 + timeBegin.MinuteBegin);
                int yFill = 0;
                int sizeWF = pnlDetailFill.Width;

               // khai bao bien 
                int xTmp = 0, xTimeDetail = 0;
                int xSizeTmp = 0;
                string color = String.Empty;

                Label lbl = new Label();

               // PictureBox pkb = null;// new PictureBox();
                //pkb.Height = sizeHF;
                int cnt = timeDetailList.Count();
                for (int i = 0; i < cnt; i++)
                {
                    // xTimeDetail:  số phút của timeDetailList[i]
                    xTimeDetail = (timeDetailList[i].HourEnd * 60 + timeDetailList[i].MinuteEnd)
                        - (timeDetailList[i].HourBegin * 60 + timeDetailList[i].MinuteBegin);
                    xSizeTmp = (xTimeDetail * sizeWF) / sumHourConfig;

                    // pictureBox
                    PictureBox pkb = new PictureBox();
                    pkb.BackColor = timeDetailList[i].Color;
                    pkb.BorderStyle = BorderStyle.FixedSingle;

                    //gan gia tri vi tri index de su dung cho ham mouse hover
                    pkb.Name = i + String.Empty;

                    // location
                    pkb.Width = xSizeTmp + 3;
                    pkb.Location = new Point(xTmp, yFill);

                    // add
                    pnlDetailFill.Controls.Add(pkb);

                    // kiem tra id, neu là event, gan su kien mouse hover cho pkb 
                    if (timeDetailList[i].idEnd == Straight.Event2 || ((i > 0) && (timeDetailList[i - 1].idEnd == Straight.Event1))
                        || (timeDetailList[i].Color == TimeDetail.getColor(TimeDetail.colorConfigListRight, (long)ColorEventId.event_day)))
                    {
                        // MouseHover && MouseLeave
                        pkb.MouseHover += pkb_MouseHover;
                        pkb.MouseLeave += pkb_MouseLeave;
                    }
                    // tang vị trí x của pkb
                    xTmp = xTmp + xSizeTmp;

                    // label
                    if (!(i > 0 && cnt > 1 && checkDeviation(timeDetailList[i])))
                    {
                        if (timeDetailList[i].idEnd != Straight.Event1 && timeDetailList[i].idEnd != Straight.Event2 && timeDetailList[i].idEnd != Straight.Stripe)
                        {
                            //timePre = timeDetailList[i];
                            lbl = new Label();
                            lbl.Font = new Font(lbl.Font.FontFamily, 7);
                            lbl.Width = 31;
                            lbl.Height = 10;

                            // dat shift id cho bien name cua label
                            int t = yFill + 10;
                            lbl.Name = timeDetailList[i].idEnd.ToString();

                            // Stripe
                            if (timeDetailList[i].idEnd == Straight.Session1 || timeDetailList[i].idEnd == Straight.Session2
                                || timeDetailList[i].idEnd == Straight.Stripe)
                            {
                                t = yFill;
                                lbl.Font = new Font(lbl.Font.FontFamily, 7, FontStyle.Bold);
                            }
                            //ngay nghi
                            if (cnt == 1)
                            {
                                t = yFill;
                                lbl.Font = new Font(lbl.Font.FontFamily, 7, FontStyle.Bold);
                            }

                            // location
                            lbl.Location = new Point(xTmp + 2 + 10, t);

                            // minute
                            int minute = timeDetailList[i].MinuteEnd;

                            // set text cho lable
                            lbl.Text = timeDetailList[i].HourEnd + ":" + (minute == 0 ? "00" : (minute < 10) ? "0" + minute : "" + minute);

                            // add
                            pnlTime.Controls.Add(lbl);

                            //set hover event 
                            if (timeDetailList[i].idEnd != Straight.Session1 && timeDetailList[i].idEnd != Straight.Session2
                                && timeDetailList[i].idEnd != Straight.Stripe && timeDetailList[i].idEnd != Straight.Quitting)
                            {
                                // MouseHover && MouseLeave
                                lbl.MouseHover += lbl_MouseHover;
                                lbl.MouseLeave += lbl_MouseLeave;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// for panel left 
        /// </summary>
        /// <param name="timeDetailList"></param>
        private void SetTimeDetailLeft(List<TimeDetail> timeDetailList)
        {
            if (null != timeDetailList && timeDetailList.Count != 0)
            {
                // cho list time detail chi co 1 item => item dau tien
                int countShift = timeDetailList.Count;
                TimeDetail detail1 = timeDetailList[0];
                TimeDetail detail2 = timeDetailList[timeDetailList.Count - 1];

                // add detail1 vao timeDetailList
                timeDetailList = new List<TimeDetail>();
                timeDetailList.Add(detail1);

                // add time detail
                if (countShift > 1)
                {
                    timeDetailList.Add(detail2);
                }

                // tao object timeBegin
                TimeDetail timeBegin = timeDetailList[0], timeEnd = timeDetailList[timeDetailList.Count - 1];

                // add lable & add time
                int sumHourConfig = (timeEnd.HourEnd * 60 + timeEnd.MinuteEnd) - (6 * 60);
                int yFill = 0;
                int sizeWF = pnlDetailLeft.Width;
                int sizeHF = pnlDetailLeft.Height;
                int xTmp = 0, xTimeDetail = 0;
                int xSizeTmp = 0;
                string color = String.Empty;

                // set gia tri
                Label lbl = new Label();
                PictureBox pkb = new PictureBox();
                pkb.Height = sizeHF;
                int cnt = timeDetailList.Count();
                for (int i = 0; i < cnt - 1; i++)
                {
                    // xTimeDetail:  số phút của timeDetailList[i]
                    xTimeDetail = (timeDetailList[i].HourEnd * 60 + timeDetailList[i].MinuteEnd)
                   - (timeDetailList[i].HourBegin * 60 + timeDetailList[i].MinuteBegin);

                    /** // truong hop chia dung theo % gio
                        xSizeTmp = (xTimeDetail * sizeWF) / sumHourConfig;
                    **/
                    // truong hop chia khong dung theo % gio, hien thi thanh gach o vị tri giua panel left
                    xSizeTmp = sizeWF / 2;
                    // tang vị trí x của pkb
                    xTmp = xTmp + xSizeTmp;

                    // label
                    if (!(i > 0 && cnt > 1 && checkDeviation(timeDetailList[i])))
                    {
                        if (timeDetailList[i].Color != ColorTranslator.FromHtml(ColorValue.getColorValue((ColorValueName)ColorValueName.black)))
                        {
                            if (timeDetailList[i].idBegin != Straight.Event1)
                            {
                                lbl = new Label();
                                lbl.Font = new Font(lbl.Font.FontFamily, 7);
                                lbl.Width = 31;
                                lbl.Height = 10;

                                // dat shift id cho bien name cua label
                                int t = yFill + 10;
                                lbl.Name = timeDetailList[i].idBegin.ToString();
                                if (timeDetailList[i].idBegin == Straight.Session1 || timeDetailList[i].idBegin == Straight.Session2
                                    || timeDetailList[i].idBegin == Straight.Stripe)
                                {
                                    t = yFill;
                                    lbl.Font = new Font(lbl.Font.FontFamily, 7, FontStyle.Bold);
                                }

                                /** // truong hop chia dung theo % gio
                                lbl.Location = new Point(xTmp + 2 - 10, t);
                                **/
                                // truong hop chia khong dung theo % gio, hien thi thanh gach o vị tri giua panel left
                                lbl.Location = new Point(xTmp - 10, t);
                                int minute = timeDetailList[i].MinuteBegin;

                                // text
                                lbl.Text = timeDetailList[i].HourBegin + ":" + (minute == 0 ? "00" : (minute < 10) ? "0" + minute : "" + minute);
                                pnlTime.Controls.Add(lbl);

                                //set hover event 
                                if (timeDetailList[i].idBegin != Straight.Session1 && timeDetailList[i].idBegin != Straight.Session2
                                    && timeDetailList[i].idBegin != Straight.Stripe && timeDetailList[i].idBegin != Straight.Quitting)
                                {
                                    // MouseHover && MouseLeave
                                    lbl.MouseHover += lbl_MouseHover;
                                    lbl.MouseLeave += lbl_MouseLeave;
                                }
                            }
                            // pictureBox

                            pkb = new PictureBox();
                            /** // truong hop chia dung theo % gio
                                pkb.BackColor = timeDetailList[i].Color;
                                **/

                            // truong hop chia khong dung theo % gio, hien thi thanh gach o vị tri giua panel left
                            pkb.BackColor = timeDetailList[i].Color;
                            pkb.BorderStyle = BorderStyle.FixedSingle;
                            pkb.Width = xSizeTmp;
                            pkb.Location = new Point(pnlDetailLeft.Location.X + (sizeWF - xTmp), yFill);
                            pnlDetailLeft.Controls.Add(pkb);

                            //// kiem tra id, neu là event, gan su kien mouse hover cho pkb 
                            //if (timeDetailList[i - 1].idBegin == Straight.Event1)
                            //{
                            //    pkb.MouseHover += pkb_MouseHover;
                            //    pkb.MouseLeave += pkb_MouseLeave;
                            //}
                        }
                    }
                }
            }
        }

        /// <summary>
        /// for panel right
        /// </summary>
        /// <param name="timeDetailList"></param>
        private void SetTimeDetailRight(List<TimeDetail> timeDetailList)
        {
            if ((null != timeDetailList && timeDetailList.Count != 0) && ((timeDetailList.Count > 1) || 
                (timeDetailList[timeDetailList.Count - 1].idBegin == Straight.Stripe )))
            {
                // cho list time detail chi co 1 item => item dau tien
                TimeDetail detail2 = timeDetailList[timeDetailList.Count - 1];
                timeDetailList = new List<TimeDetail>();
                timeDetailList.Add(detail2);
                //

                TimeDetail timeBegin = timeDetailList[0], timeEnd = timeDetailList[timeDetailList.Count - 1];

                // add lable & add time
                int sumHourConfig = (19 * 60 + 0) - (timeBegin.HourBegin * 60 + timeBegin.MinuteBegin);
                int yFill = 0;
                int sizeWF = pnlDetailRight.Width;
                int sizeHF = pnlDetailRight.Height;
                int xTmp = 0, xTimeDetail = 0;
                int xSizeTmp = 0;
                string color = String.Empty;

                // khai bao bien
                Label lbl = new Label();
                PictureBox pkb = new PictureBox();
                pkb.Height = sizeHF;
                int cnt = timeDetailList.Count();
                for (int i = 0; i < cnt; i++)
                {
                    // xTimeDetail:  số phút của timeDetailList[i]
                    xTimeDetail = (timeDetailList[i].HourEnd * 60 + timeDetailList[i].MinuteEnd)
                   - (timeDetailList[i].HourBegin * 60 + timeDetailList[i].MinuteBegin);

                    /** // truong hop chia dung theo % gio
                        xSizeTmp = (xTimeDetail * sizeWF) / sumHourConfig;
                    **/
                    // truong hop chia khong dung theo % gio, hien thi thanh gach o vị tri giua panel right
                    xSizeTmp = sizeWF / 2;

                    // pictureBox
                    pkb = new PictureBox();
                    pkb.BackColor = timeDetailList[i].Color;
                    pkb.BorderStyle = BorderStyle.FixedSingle;
                    pkb.Width = xSizeTmp + 3;
                    pkb.Location = new Point(xTmp, yFill);
                    pnlDetailRight.Controls.Add(pkb);

                    //// kiem tra id, neu là event, gan su kien mouse hover cho pkb 
                    //if (timeDetailList[i].idEnd == Straight.Event2)
                    //{
                    //    pkb.MouseHover += pkb_MouseHover;
                    //    pkb.MouseLeave += pkb_MouseLeave;
                    //}

                    // tang vị trí x của pkb
                    xTmp = xTmp + xSizeTmp + 2;

                    // label
                    if (!(i > 0 && cnt > 1 && checkDeviation(timeDetailList[i])))
                    {
                        // Event
                        if (timeDetailList[i].idEnd != Straight.Event1 && timeDetailList[i].idEnd != Straight.Event2 && timeDetailList[i].idEnd != Straight.Stripe)
                        {
                            lbl = new Label();
                            lbl.Font = new Font(lbl.Font.FontFamily, 7);
                            lbl.Width = 31;
                            lbl.Height = 10;

                            // dat shift id cho bien name cua label
                            int t = yFill + 10;

                            // lbl.Name
                            lbl.Name = timeDetailList[i].idEnd.ToString();

                            // Stripe
                            if (timeDetailList[i].idEnd == Straight.Session1 || timeDetailList[i].idEnd == Straight.Session2
                                    || timeDetailList[i].idEnd == Straight.Stripe)
                            {
                                t = yFill;
                                lbl.Font = new Font(lbl.Font.FontFamily, 7, FontStyle.Bold);
                            }

                            // location
                            lbl.Location = new Point(pnlDetailFill.Location.X + pnlDetailFill.Width + xTmp - 12, t);

                            int minute = timeDetailList[i].MinuteEnd;
                            lbl.Text = timeDetailList[i].HourEnd + ":" + (minute == 0 ? "00" : (minute < 10) ? "0" + minute : "" + minute);
                            
                            //lbl.Location = new Point(xTmp, yFill);
                            pnlTime.Controls.Add(lbl);

                            //set hover event 
                            if (timeDetailList[i].idEnd != Straight.Session1 && timeDetailList[i].idEnd != Straight.Session2
                                && timeDetailList[i].idEnd != Straight.Stripe && timeDetailList[i].idEnd != Straight.Quitting)
                            {
                                // MouseHover && MouseLeave
                                lbl.MouseHover += lbl_MouseHover;
                                lbl.MouseLeave += lbl_MouseLeave;
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// lbl_MouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_MouseLeave(object sender, EventArgs e)
        {
            workItem.SmartParts.Remove(frmShImage);
            frmShImage.Hide();
        }
        /// <summary>
        /// lbl_MouseHover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_MouseHover(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            try
            {
                frmShImage = new FrmShiftImage(long.Parse(lbl.Name));
            }
            catch (Exception ex)
            {
                frmShImage = new FrmShiftImage(0);
            }
            workItem.SmartParts.Add(frmShImage);

            // x, y
            int y = lbl.Location.Y + index == 0 ? 0 : index * 70;
            frmShImage.Location = new Point(lbl.Location.X + 50, y);

            // show
            frmShImage.Show();
        }
        /// <summary>
        /// pkb_MouseHover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pkb_MouseHover(object sender, EventArgs e)
        {
            // set resoucre
            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);

            // PictureBox
            PictureBox pk = (PictureBox)sender;
            TimeDetail detail = null;

            // set gai tri cho timeDetailList
            if (timeDetailList.Count == 1)
                detail = timeDetailList[0][int.Parse(pk.Name)];
            else
            {
                detail = timeDetailList[1][int.Parse(pk.Name)];
            }

            // set gia tri cho frmEvDetail
            frmEvDetail = new FrmEventDetail(rm, GetEvent(listEventObj, detail));
            workItem.SmartParts.Add(frmEvDetail);

            // set x, y
            int x = pk.Location.X + (SystemInformation.VirtualScreen.Width / 7) ;
            int y = (index + 1 ) * (SystemInformation.VirtualScreen.Height / 11);
            frmEvDetail.Location = new Point(x, y);

            // show
            frmEvDetail.Show();
            //set member name
            lblMemberName.Text = name;
        }
        /// <summary>
        /// pkb_MouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pkb_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                workItem.SmartParts.Remove(frmEvDetail);
                frmEvDetail.Hide();
            }
            catch (Exception ex) { }
            //set member name
            lblMemberName.Text = name;
        }

        /// <summary>
        /// checkDeviation
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        private bool checkDeviation(TimeDetail time)
        {
            //if (time.HourBegin == time.HourEnd)
            //    if (time.MinuteEnd - time.MinuteBegin < 20)
            //        return true;
            return false;
        }

        /// <summary>
        /// get event chuan bi cho hover
        /// </summary>
        /// <param name="listEvent"></param>
        /// <param name="detail"></param>
        /// <returns></returns>
        public Event GetEvent(List<Event> listEvent, TimeDetail detail)
        {
            Event eventObj = null;
            int h, m, h1;

            // duyet
            for (int i = 0; i < listEvent.Count; i++)
            {
                // h && m
                string[] time = listEvent[i].hourEventBegin.Split(':');
                h = int.Parse(time[0]);
                m = int.Parse(time[1]);
                h1 = h + listEvent[i].hourEventKeeping;

                // event thuoc khoang time detail
                if (((detail.HourBegin * 60 + detail.MinuteBegin) >= (h * 60 + m)) &&
                    ((detail.HourEnd * 60 + detail.MinuteEnd) <= (h1 * 60 + m)))
                {
                    eventObj = listEvent[i];
                }
            }

            // tra ve event object
            return eventObj;
        }

        /// <summary>
        /// load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sheet1_Load(object sender, EventArgs e)
        {
            // set timedetail
            if (timeDetailList.Count == 1)
                SetTimeDetail(name, timeDetailList[0]);
            else
            {
                SetTimeDetailLeft(timeDetailList[0]);
                SetTimeDetail(name, timeDetailList[1]);
                SetTimeDetailRight(timeDetailList[2]);
            }

        }
    }
}