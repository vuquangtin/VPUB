using CommonControls;
using CommonHelper.Constants;
using CommonHelper.Utils;
using JavaCommunication;
using Microsoft.Practices.CompositeUI;
using sMeetingComponent.Factory;
using sMeetingComponent.Model;
using sMeetingComponent.Model.CustomObj;
using sWorldModel;
using sWorldModel.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Configuration;
using sMeetingComponent.Constants;
using System.Globalization;
using Newtonsoft.Json;

namespace sMeetingComponent.WorkItems
{
    public partial class Frm1DetailInforByCardChip : Form
    {

        #region Properties
        public const byte ModeCardChip = 1;
        private byte OperatingMode;
        private String cardChip { get; set; }

        // String selectedReader = null;

        // User control này không thuộc nhóm overlay do khi nó hiện ra
        private UsrNotification usrNotification = null;
        private ConfigTime configTime;
        private System.Windows.Forms.Timer timer = null;
        private int time = 0;
        private int previousMinutes = 0;

        private DataTable dtbMeetingList;
        private DataTable dtbEventListPartaker;

        private Journalist journalist;
        private List<EventMeeting> meetingObjListAll;//tất cả
        private List<EventMeeting> meetingObjList;//được mời
        private List<EventMeeting> meetingObjListCheck;//check lúc sau
        private List<EventMeeting> meetingNotInvitedsList;//không được mời
        private List<EventMeeting> meetingNotInvitedsListCheck;//check lúc sau của không được mời chính thức

        MeetingInfoJournalistObj listMeetingJournalistObj;
        private MeetingInfoJournalistObj AddOrUpdateListMeetingJournalistObj;
        private BackgroundWorker loadListMeetingJournalistObj;
        private BackgroundWorker bgwAddAttendMeetingJournalist;

        private ResourceManager rm;
        public DialogPostAction PostAction { get; private set; }

        private MeetingComponentWorkItem workItem;
        [ServiceDependency]
        public MeetingComponentWorkItem WorkItem
        {
            set { workItem = value; }
        }

        private ILocalStorageService storageService;
        [ServiceDependency]
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
            set { storageService = value; }
        }

        #endregion

        #region Contructors
        public Frm1DetailInforByCardChip(byte mode, String cardChip)
        {
            InitializeComponent();
            InitDataTableMeetingList();

            CustomTypeDate();
            RegisterEvent();
            this.OperatingMode = mode;
            this.cardChip = cardChip;
            meetingObjListAll = new List<EventMeeting>();

            #region usrNotification
            configTime = new ConfigTime();
            time = configTime.SetTime();

            usrNotification = new UsrNotification();
            usrNotification.Anchor = AnchorStyles.None;
            usrNotification.Visible = false;
            panel1.Controls.Add(usrNotification);
            usrNotification.Location = new Point(
                panel1.ClientSize.Width / 2 - usrNotification.Width / 2,
                panel1.ClientSize.Height / 2 - usrNotification.Height / 2);
            usrNotification.BringToFront();

            previousMinutes = configTime.GetPreviousMinutes();
            #endregion

        }
        #endregion

        #region Setting timer
        private void StartTimer()
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = time;
            timer.Tick += timer_Tick;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            this.Close();
        }
        #endregion

        private void InitDataTableMeetingList()
        {
            dtbMeetingList = new DataTable();
            dtbMeetingList.Columns.Add(colSttnew.DataPropertyName);
            dtbMeetingList.Columns.Add(colMeetingId.DataPropertyName);
            dtbMeetingList.Columns.Add(colMeetingName.DataPropertyName);
            dtbMeetingList.Columns.Add(colOrganizationMeeting.DataPropertyName);
            dtbMeetingList.Columns.Add(colCheck.DataPropertyName);
            dtbMeetingList.Columns.Add(colDateTime.DataPropertyName);
            dtbMeetingList.Columns.Add(colStartTime.DataPropertyName);
            dtbMeetingList.Columns.Add(colEndTime.DataPropertyName);
            dtbMeetingList.Columns.Add(colRoomName.DataPropertyName);
            dtbMeetingList.Columns.Add(colNumber.DataPropertyName);
            dtbMeetingList.Columns.Add(colListAttend.DataPropertyName);
            dgvListMeetingToday.DataSource = dtbMeetingList;

            dtbEventListPartaker = new DataTable();
            dtbEventListPartaker.Columns.Add(colSTT.DataPropertyName);
            dtbEventListPartaker.Columns.Add(colNamePartaker.DataPropertyName);
            dtbEventListPartaker.Columns.Add(colNameOrg.DataPropertyName);
            dtbEventListPartaker.Columns.Add(colPositionPartaker.DataPropertyName);
            dtbEventListPartaker.Columns.Add(colCheck.DataPropertyName);
            dgvListAttend.DataSource = dtbEventListPartaker;
        }

        /// <summary>
        /// đăng ký sự kiện
        /// </summary>
        private void RegisterEvent()
        {
            CreateBackgroundWorkerEvent();
            btnConfirm.Click += OnButtonPutInClicked;
            btnCancel.Click += OnButtonExitClicked;
            dgvListMeetingToday.CellClick += dgvListMeetingToday_CellClick;
            dgvListMeetingToday.KeyDown += OnButtondgvListMeetingTodayKeyPress;

            Load += OnFormLoad;
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        private void Frm1DetailInforByCardChip_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        #region bgWorker
        private void CreateBackgroundWorkerEvent()
        {
            loadListMeetingJournalistObj = new BackgroundWorker();
            loadListMeetingJournalistObj.WorkerSupportsCancellation = true;
            loadListMeetingJournalistObj.DoWork += OnLoadListMeetingJournalistObjWorkerDoWork;
            loadListMeetingJournalistObj.RunWorkerCompleted += OnLoadListMeetingJournalistObjWorkerCompleted;
            //thêm danh sách các cuộc họp người đó tham dự
            bgwAddAttendMeetingJournalist = new BackgroundWorker();
            bgwAddAttendMeetingJournalist.WorkerSupportsCancellation = true;
            bgwAddAttendMeetingJournalist.DoWork += OnLoadAddAttendMeetingJournalistWorkerDoWork;
            bgwAddAttendMeetingJournalist.RunWorkerCompleted += OnLoadAddAttendMeetingJournalistRunWorkerCompleted;
        }

        /// <summary>
        /// OnLoadListMeetingJournalistObjWorkerDoWork
        /// lấy thông tin cuộc họp nhà báo được mời và các cuộc họp diễn ra hôm nay (yyyy-MM-dd HH:mm)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoadListMeetingJournalistObjWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            int hour = dateTime.Hour;
            int minute = dateTime.Minute;
            TimeSpan ts = new TimeSpan(hour, minute, 0);
            dateTime = dateTime.Date + ts;
            String dateStr = dateTime.ToString("yyyy-MM-dd HH:mm");
            try
            {
                e.Result = listMeetingJournalistObj = JournalistFactory.Instance.GetChannel().getListMeetingJournalistObjByCardChip(storageService.CurrentSessionId, cardChip, dateStr, previousMinutes);
            }
            catch (TimeoutException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "TimeOutExceptionMessage"));
            }
            catch (FaultException<WcfServiceFault> ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
            }
            catch (FaultException ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "FaultExceptionMessage")
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
            }
            catch (CommunicationException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "CommunicationExceptionMessage"));
            }
        }

        /// <summary>
        /// OnLoadListMeetingJournalistObjWorkerCompleted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoadListMeetingJournalistObjWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Failed, MessageValidate.GetMessage(rm, "SmsNotConnectData"))));
                StartTimer();
                return;
            }
            if (e.Result == null)
            {
                Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Failed, MessageValidate.GetMessage(rm, "smsNotInforCardRetry"))));
                StartTimer();
                return;
            }
            else
            {
                MeetingInfoJournalistObj result = (MeetingInfoJournalistObj)e.Result;
                if (result.journalist != null)
                {
                    journalist = result.journalist;
                    //hiển thị thông tin nhà báo lên 
                    if (journalist.serialNumber != null && journalist.serialNumber != "")
                    {
                        LoadJournalist(journalist);
                    }
                    else
                    {
                        journalist.serialNumber = cardChip;
                        LoadJournalist(journalist);
                    }

                    //meetingObjList danh sách các cuộc họp nhà báo được mời
                    if (result.meetingInviteds != null)
                    {
                        meetingObjList = result.meetingInviteds;
                    }
                    else
                    {
                        meetingObjList = new List<EventMeeting>();
                    }

                    if (result.meetingNotInviteds != null)
                    {
                        meetingNotInvitedsList = result.meetingNotInviteds;
                    }
                    else
                    {
                        meetingNotInvitedsList = new List<EventMeeting>();
                    }

                    if (meetingObjList.Count == 0 && meetingNotInvitedsList.Count == 0)
                    {
                        Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Failed, MessageValidate.GetMessage(rm, "smsNotInforTodayMeetingCard"))));
                    }
                    //hiển thị thông tin danh sách các cuộc họp
                    else
                    {
                        meetingObjListAll.AddRange(meetingObjList);
                        meetingObjListAll.AddRange(meetingNotInvitedsList);
                        LoadMeetingObjListdata(meetingObjListAll);
                    }
                }
                else
                {
                    Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Failed, MessageValidate.GetMessage(rm, "smsNotInforPersonalCardRetry"))));
                    StartTimer();
                }
            }
        }

        /// <summary>
        /// OnLoadAddAttendMeetingJournalistObjRunWorkerCompleted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoadAddAttendMeetingJournalistRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Failed, MessageValidate.GetMessage(rm, "smsErrorInsertMeetingCard"))));
                return;
            }
            bool checkUpdate = (bool)e.Result;
            if (checkUpdate)
            {
                // Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Succeed, MessageValidate.GetMessage(rm, "SmsSuccessMeetingCard"))));
                PostAction = DialogPostAction.SUCCESS;
                UsrListMeeting.getStatus(1);
                this.Close();
            }
            else
            {
                Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Failed, MessageValidate.GetMessage(rm, "smsErrorInsertMeetingCard"))));
                return;
            }
        }

        /// <summary>
        /// insert attendmeeting of journalist  
        /// OnLoadAddAttendMeetingJournalistWorkerDoWork
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoadAddAttendMeetingJournalistWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = (int)Status.SUCCESS == JournalistFactory.Instance.GetChannel().insertAttendMeetingJournalist(storageService.CurrentSessionId, AddOrUpdateListMeetingJournalistObj);
            }
            catch (TimeoutException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "TimeOutExceptionMessage"));
            }
            catch (FaultException<WcfServiceFault> ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
            }
            catch (FaultException ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "FaultExceptionMessage")
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
            }
            catch (CommunicationException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "CommunicationExceptionMessage"));
            }
        }

        #endregion

        private void OnFormLoad(object sender, EventArgs e)
        {
            switch (OperatingMode)
            {
                case ModeCardChip:
                    LoadListMeetingJournalistObj();
                    break;
                default:
                    throw new ArgumentException("Invalid operating mode!");
            }

            //để dùng phím tắt lên xuống
            this.KeyPreview = true;
            this.dgvListMeetingToday.Select();
            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
            this.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.Name);

            //cho focus vao nut huy
            btnCancel.Select();

            SetLanguages();
        }

        private void SetLanguages()
        {
            this.colSttnew.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colSttnew.Name);
            this.colMeetingId.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colMeetingId.Name);
            this.colMeetingName.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colMeetingName.Name);
            this.colOrganizationMeeting.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colOrganizationMeeting.Name);
            this.colCheck.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colCheck.Name);
            this.colDateTime.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colDateTime.Name);

            this.colSTT.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colSTT.Name);
            this.colNamePartaker.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colNamePartaker.Name);
            this.colPositionPartaker.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colPositionPartaker.Name);
            this.colCheck.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colCheck.Name);
            this.colNameOrg.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colNameOrg.Name);
        }

        /// <summary>
        /// load info Journalist by cardchip
        /// </summary>
        private void LoadListMeetingJournalistObj()
        {
            if (!loadListMeetingJournalistObj.IsBusy)
            {
                loadListMeetingJournalistObj.RunWorkerAsync();
            }
        }

        /// <summary>
        /// hiển thị thông tin nhà báo
        /// </summary>
        /// <param name="journalist"></param>
        private void LoadJournalist(Journalist journalist)
        {
            if (journalist.BirthDate != null && journalist.BirthDate != "")
            {
                DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                DateTime startDate = start.AddMilliseconds(Convert.ToUInt64(journalist.BirthDate)).ToLocalTime();
                journalist.BirthDate = startDate.ToString("dd-MM-yyyy 00:00");
                this.dtpBirthDate.Value = startDate;
            }
            this.txtOrg.Text = journalist.OrgName;
            this.txtLowerFullName.Text = journalist.LowerFullName;
            this.txtPosition.Text = journalist.Position;
            this.txtEmail.Text = journalist.Email;
            this.txtPhoneNo.Text = journalist.PhoneNo;
            this.txtIdentityCard.Text = journalist.IdentityCard;
          //  this.txtNote.Text = "Đăng ký tham dự họp";
            //this.txtNote.Text = "";

            //  SetControl(false);

        }

        /// <summary>
        /// hiển thị danh sách các cuộc họp lên
        /// nếu meetingObjList thì có dấu check trước (cuộc họp nhà báo được mời trước)
        /// nếu meetingObjOthersShowList thì không có dấu check trước (các cuộc họp trong hôm nay mà không được mời trước)
        /// </summary>
        /// <param name="meetingObjList"></param>
        /// <param name="meetingObjOthersList"></param>
        private void LoadMeetingObjListdata(List<EventMeeting> listShow)
        {
            int counts = meetingObjList.Count;
            //xóa bảng trước khi init
            dtbMeetingList.Clear();
            int index = 0;
            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            //hiển thị danh sách meetingObjList có check trước
            if (listShow.Count > 0)
            {
                for (int i = 0; i < listShow.Count; i++)
                {
                    DataRow row = dtbMeetingList.NewRow();
                    row.BeginEdit();
                    index = i + 1;
                    row[colSttnew.DataPropertyName] = index;
                    row[colMeetingName.DataPropertyName] = listShow[i].id;
                    row[colMeetingName.DataPropertyName] = listShow[i].name;
                    row[colOrganizationMeeting.DataPropertyName] = listShow[i].organizationMeetingName;
                    row[colRoomName.DataPropertyName] = listShow[i].roomName;
                    row[colNumber.DataPropertyName] = listShow[i].number;
                    row[colListAttend.DataPropertyName] = listShow[i].listNonResident;

                    if (listShow[i].startTime != null && listShow[i].startTime != "")
                    {
                        DateTime startDate = start.AddMilliseconds(Convert.ToUInt64(listShow[i].startTime)).ToLocalTime();
                        row[colStartTime.DataPropertyName] = startDate.ToString("HH:mm");
                        string sysFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
                        row[colDateTime.DataPropertyName] = startDate.ToString(sysFormat);
                    }
                    if (listShow[i].endTime != null && listShow[i].endTime != "")
                    {
                        DateTime endDate = start.AddMilliseconds(Convert.ToUInt64(listShow[i].endTime)).ToLocalTime();
                        row[colEndTime.DataPropertyName] = endDate.ToString("HH:mm");
                    }

                    //danh sách được mời mới check
                    if (i < meetingObjList.Count)
                    {
                        row[colCheck.DataPropertyName] = true;
                    }
                    else
                    {
                        row[colCheck.DataPropertyName] = false;
                    }
                    row.EndEdit();

                    dtbMeetingList.Rows.Add(row);
                }
            }

            //// set font size header
            //foreach (DataGridViewColumn col in this.dgvListMeetingToday.Columns)
            //{
            //    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //    col.HeaderCell.Style.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            //}

            //// set font size
            //this.dgvListMeetingToday.DefaultCellStyle.Font = new Font("Tahoma", 12F);
            //this.dgvListMeetingToday.DefaultCellStyle.Padding = new Padding(0, 3, 0, 3);
            //this.dgvListMeetingToday.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            if (dgvListMeetingToday.Rows.Count > 0)
            {
                //focur the first row in table
                dgvListMeetingToday.Rows[0].Selected = true;
            }
            else { Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Failed, MessageValidate.GetMessage(rm, "SmsNotInforMeeting")))); }
            // int count = meetingObjList.Count;
        }

        /// <summary>
        ///  lấy danh sách cuộc họp có dấu check ở ô tham dự
        /// GetMeetingObjListCheck
        /// </summary>
        private void GetMeetingObjListCheck()
        {
            meetingObjListCheck = new List<EventMeeting>();
            meetingNotInvitedsListCheck = new List<EventMeeting>();

            var selectedRows = dgvListMeetingToday.Rows;
            int rowsCount = selectedRows.Count;
            string checkPerso = string.Empty;
            if (rowsCount == 0)
            {
                //  Console.WriteLine("Không có dữ liệu");
            }
            for (int i = 0; i < rowsCount; i++)
            {
                //lấy giá trị : nếu có check = true, không có check=false
                bool check = Convert.ToBoolean(selectedRows[i].Cells[colCheck.Name].Value);
                if (check)
                {
                    if (i < meetingObjList.Count)
                    {
                        string startDay = dgvListMeetingToday.Rows[i].Cells[colDateTime.Name].Value.ToString();
                        string sysFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
                        DateTime dt = DateTime.ParseExact(startDay, sysFormat, CultureInfo.InvariantCulture);
                        String startDayFormat = dt.ToString("dd-MM-yyyy");
                        string scolStartTime = dgvListMeetingToday.Rows[i].Cells[colStartTime.Name].Value.ToString();
                        string scolEndTime = dgvListMeetingToday.Rows[i].Cells[colEndTime.Name].Value.ToString();
                        // các cuộc họp  có trong danh sách được chọn
                        meetingObjListAll[i].startTime = startDayFormat + " " + scolStartTime;
                        meetingObjListAll[i].endTime = startDayFormat + " " + scolEndTime;
                        meetingObjListCheck.Add(meetingObjListAll[i]);
                    }
                    else
                    {

                        string startDay = dgvListMeetingToday.Rows[i].Cells[colDateTime.Name].Value.ToString();
                        string sysFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
                        DateTime dt = DateTime.ParseExact(startDay, sysFormat, CultureInfo.InvariantCulture);
                        String startDayFormat = dt.ToString("dd-MM-yyyy");
                        string scolStartTime = dgvListMeetingToday.Rows[i].Cells[colStartTime.Name].Value.ToString();
                        string scolEndTime = dgvListMeetingToday.Rows[i].Cells[colEndTime.Name].Value.ToString();
                        // các cuộc họp  có trong danh sách được chọn
                        meetingObjListAll[i].startTime = startDayFormat + " " + scolStartTime;
                        meetingObjListAll[i].endTime = startDayFormat + " " + scolEndTime;
                        meetingNotInvitedsListCheck.Add(meetingObjListAll[i]);
                    }
                }
            }
        }

        #region Event's support
        /// <summary>
        /// tao doi tuong luu xuong 
        /// </summary>
        /// <returns></returns>
        private MeetingInfoJournalistObj ToEntity(bool status)
        {
            MeetingInfoJournalistObj listMeetingJournalistObj = new MeetingInfoJournalistObj();
            AttendMeetingJournalist attendMeetingJournalist = new AttendMeetingJournalist();
            attendMeetingJournalist.serialNumber = cardChip;
            attendMeetingJournalist.note = txtNote.Text.Trim();
            //thoi gian cho vao
            DateTime dateStart = DateTime.Now;
            String startDate = dateStart.ToString("yyyy-MM-dd HH:mm");
            attendMeetingJournalist.inputTime = startDate;
            //dat ngay mat dinh, neu ve ma quen tag the thi lay ngay nay
            //muc dich thong ke
            DateTime dateEnd = new DateTime(1971, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            String endDate = dateEnd.ToString("yyyy-MM-dd HH:mm");
            attendMeetingJournalist.outputTime = endDate;
            attendMeetingJournalist.status = status;
            attendMeetingJournalist.numberOfParticipants = meetingObjListCheck.Count;
            listMeetingJournalistObj.attendMeetingJournalist = attendMeetingJournalist;
            listMeetingJournalistObj.journalist = journalist;
            listMeetingJournalistObj.meetingInviteds = meetingObjListCheck;
            listMeetingJournalistObj.meetingNotInviteds = meetingNotInvitedsListCheck;
            return listMeetingJournalistObj;
        }
        #endregion

        #region Button Event's 
        /// <summary>
        /// hiển thị thông tin của cuộc họp khi click vào 1 dòng trong table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvListMeetingToday_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex != -1)
            {
                if (e.ColumnIndex == 4)
                {
                    //bool check = Convert.ToBoolean(dgvListMeetingToday.Rows[e.RowIndex].Cells[colCheck.Name].Value);
                    //dgvListMeetingToday.Rows[e.RowIndex].Cells[colCheck.Name].Value = !check;
                }
                else
                { 
                    DataGridViewRow row = dgvListMeetingToday.Rows[rowIndex];
                    txtMeetingName.Text = dgvListMeetingToday.Rows[e.RowIndex].Cells[colMeetingName.Name].Value.ToString();
                    txtOrganizationMeeting.Text = dgvListMeetingToday.Rows[e.RowIndex].Cells[colOrganizationMeeting.Name].Value.ToString();
                    txtRoom.Text = dgvListMeetingToday.Rows[e.RowIndex].Cells[colRoomName.Name].Value.ToString();

                    string startDay = dgvListMeetingToday.Rows[e.RowIndex].Cells[colDateTime.Name].Value.ToString();
                    string sysUIFormat = CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern;
                    string sysFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
                    DateTime dt = DateTime.ParseExact(startDay, sysFormat, CultureInfo.InvariantCulture);
                    this.dtpDay.Value = dt;
                    dtpStartTime.Text = dgvListMeetingToday.Rows[e.RowIndex].Cells[colStartTime.Name].Value.ToString();
                    dtpEndTime.Text = dgvListMeetingToday.Rows[e.RowIndex].Cells[colEndTime.Name].Value.ToString();

                    //hiển thị danh sách thông tin của cuộc họp được mời chỉ có thể xem không làm gì hết
                    List<Partaker> jsonListPartaker = new List<Partaker>();
                    String listAttend = dgvListMeetingToday.Rows[e.RowIndex].Cells[colListAttend.Name].Value.ToString();
                    jsonListPartaker = JsonConvert.DeserializeObject<List<Partaker>>(listAttend);
                    if (jsonListPartaker != null)
                    {
                        loadPartakersToTable(jsonListPartaker);
                    }
                    //txtnumericNumber.Text = ""+Convert.ToInt32(dgvListMeetingToday.Rows[e.RowIndex].Cells[colNumber.Name].Value.ToString());
                }
            }
        }
        /// <summary>
        /// show list partakers
        /// </summary>
        private void loadPartakersToTable(List<Partaker> partakerOtherList)
        { //xóa bảng trước khi init
            dtbEventListPartaker.Clear();
            int index = 0;
            //nếu có dữ liệu thêm người tham dự 
            if (partakerOtherList.Count > 0)
            {
                for (int i = 0; i < partakerOtherList.Count; i++)
                {
                    DataRow row = dtbEventListPartaker.NewRow();
                    row.BeginEdit();
                    index = i + 1;
                    row[colSTT.DataPropertyName] = index;
                    row[colNamePartaker.DataPropertyName] = partakerOtherList[i].name;
                    row[colNameOrg.DataPropertyName] = partakerOtherList[i].orgname;

                    row[colPositionPartaker.DataPropertyName] = partakerOtherList[i].position;
                    row[colCheck.DataPropertyName] = true;
                    row.EndEdit();
                    dtbEventListPartaker.Rows.Add(row);
                }
            }
            //// set font size header
            //foreach (DataGridViewColumn col in this.dgvListAttend.Columns)
            //{
            //    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //    col.HeaderCell.Style.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            //}

            //// set font size
            //this.dgvListAttend.DefaultCellStyle.Font = new Font("Tahoma", 12F);
            //this.dgvListAttend.DefaultCellStyle.Padding = new Padding(0, 3, 0, 3);
            //this.dgvListAttend.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            if (dgvListAttend.Rows.Count > 0)
                //focur the first row in table
                dgvListAttend.Rows[0].Selected = true;
        }
        private void OnButtondgvListMeetingTodayKeyPress(object sender, KeyEventArgs e)
        {
            var selectedRows = dgvListMeetingToday.SelectedRows;
            int rowsCount = selectedRows.Count;
            //so dong duoc chon
            if (rowsCount == 0)
            {
               // Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Failed, MessageValidate.GetMessage(rm, "smsPleaseClickChooseInfo"))));
            }
            else
            {
                int rowindex = dgvListMeetingToday.CurrentRow.Index;
                if (e.KeyCode == Keys.Space)
                {
                    bool check = Convert.ToBoolean(selectedRows[0].Cells[colCheck.Name].Value);
                    dgvListMeetingToday.Rows[rowindex].Cells[colCheck.Name].Value = !check;
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //if (msg.WParam.ToInt32() == (int)Keys.Enter)
            //{
            //    PutIn();
            //}
            if (msg.WParam.ToInt32() == (int)Keys.F10)
            {
                PutIn();
            }
            if (msg.WParam.ToInt32() == (int)Keys.Escape)
            {
                this.Close();
            }
            else
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
            return false;
        }

        //protected override void OnKeyDown(KeyEventArgs e)
        //{

        //    base.OnKeyDown(e);
        //    switch (e.KeyCode)
        //    {
        //        case Keys.Left:
        //        case Keys.Right:
        //        case Keys.Up:
        //        case Keys.Down:
        //            if (e.Shift)
        //            {
        //                this.dgvListMeetingToday.Select();
        //            }
        //            else
        //            {
        //                this.dgvListMeetingToday.Select();
        //            }
        //            break;
        //    }
        //}

        private void PutIn()
        {
            int counts = meetingObjList.Count;
            String note = txtNote.Text;

            GetMeetingObjListCheck();

            // if (ValidateData() && MessageBoxManager.ShowQuestionMessageBox(this, MessageValidate.GetMessage(rm, "smsQuestionYesNoAttendMeeting")) == System.Windows.Forms.DialogResult.Yes)
            if (ValidateData())
            {
                if (!bgwAddAttendMeetingJournalist.IsBusy)
                {
                    AddOrUpdateListMeetingJournalistObj = ToEntity(true);
                    bgwAddAttendMeetingJournalist.RunWorkerAsync();
                }
            }
        }

        private void OnButtonPutInClicked(object sender, EventArgs e)
        {
            PutIn();
        }

        private void OnButtonExitClicked(object sender, EventArgs e)
        {
            this.Close();
        }

        //kiểm tra dữ liệu
        private bool ValidateData()
        {
            if (meetingObjListCheck.Count == 0 && meetingNotInvitedsListCheck.Count == 0)
            {
                Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Failed, MessageValidate.GetMessage(rm, "smsEmptyListMeeting"))));
                return false;
            }
            return true;
        }
        #endregion

        #region Control
        private void SetControl(bool isView)
        {
            this.txtOrg.Enabled = isView;
            this.txtLowerFullName.Enabled = isView;
            this.txtPosition.Enabled = isView;
            this.txtEmail.Enabled = isView;
            this.txtPhoneNo.Enabled = isView;
            this.dtpBirthDate.Enabled = isView;
            this.txtIdentityCard.Enabled = isView;
            this.txtOrganizationMeeting.Enabled = isView;
            this.txtMeetingName.Enabled = isView;
            this.txtOrganizationMeeting.Enabled = isView;
            this.txtRoom.Enabled = isView;
           // this.txtnumericNumber.Enabled = isView;
            this.dtpDay.Enabled = isView;
            this.dtpStartTime.Enabled = isView;
            this.dtpEndTime.Enabled = isView;
        }
        #endregion

        #region CustomDesign
        private void CustomTypeDate()
        {
            // custom date time 
            dtpStartTime.ShowUpDown = true;
            dtpStartTime.CustomFormat = "hh:mm tt";

            dtpEndTime.ShowUpDown = true;
            dtpEndTime.CustomFormat = "hh:mm tt";

            dtpDay.CustomFormat = "dd/MM/yyyy";
            dtpBirthDate.CustomFormat = "dd/MM/yyyy";
        }
        #endregion

        private void dgvListMeetingToday_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex != -1)
            {
                if (e.ColumnIndex == 4)
                {
                    bool check = Convert.ToBoolean(dgvListMeetingToday.Rows[e.RowIndex].Cells[colCheck.Name].Value);
                    dgvListMeetingToday.Rows[e.RowIndex].Cells[colCheck.Name].Value = !check;
                }
            }
        }
    }
}
