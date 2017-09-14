using CommonControls;
using CommonControls.Custom;
using CommonHelper.Constants;
using CommonHelper.Utils;
using JavaCommunication;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.Commands;
using Newtonsoft.Json;
using sMeetingComponent.Factory;
using sMeetingComponent.Model;
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
using System.Windows.Forms;


namespace sMeetingComponent.WorkItems.ScheduleMeeting
{
    public partial class FrmUpdateScheduleMeeting : Form
    {
        #region Properties
        private long meetingId = 0;

        DateTime startTimeNew;
        DateTime endTimeNew;

        private EventMeeting AddOrUpdateEventMeeting;
        private EventMeeting OriginalEventMeeting { get; set; }
        public List<OrganizationMeeting> organizationList;
        public List<OrganizationMeeting> organizationListCbx;
        public List<Room> roomList;
        List<PartakerObj> partakerOtherList;
        List<PartakerObj> partakerOtherListCheck;

        private BackgroundWorker bgwUpdateEventMeeting;
        private BackgroundWorker bgwLoadMeetingList;

        private DataTable dtbEventListPartaker;

        public DialogPostAction PostAction { get; private set; }
        private ResourceManager rm;
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
        /// <summary>
        /// FrmUpdateScheduleMeeting
        /// </summary>
        /// <param name="meetingId"></param>
        public FrmUpdateScheduleMeeting(long meetingId)
        {
            this.meetingId = meetingId;
            InitializeComponent();
            InitDataTableEventListPartakers();

            CustomTypeDate();
            RegisterEvent();
            partakerOtherList = new List<PartakerObj>();
            partakerOtherListCheck = new List<PartakerObj>();
        }
        #endregion
        /// <summary>
        /// InitDataTableEventListPartakers
        /// </summary>
        private void InitDataTableEventListPartakers()
        {
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
        /// RegisterEvent
        /// </summary>
        private void RegisterEvent()
        {
            CreateBackgroundWorkerEvent();
            btnUpdateInfo.Click += OnButtonPutInClicked;
            btnCancel.Click += OnButtonCancelClicked;
            // dgvListAttend.CellClick += dgvListAttend_CellClick;
            //// doi thanh nhan chuot
            ////  dgvListAttend.CellMouseClick += ;
            ////  dgvListAttend.CellClick += OnButtonDgvListAttendClicked;
            //dgvListAttend.KeyDown += OnButtonDgvListAttendKeyPress;
            //btnRefresh.Click += OnButtonRefreshClicked;
            //btnAddAttend.Click += OnButtonbtnAddAttendClicked;
            //btnUpdatePartaker.Click += OnButtonUpdatePartakerCliced;

            Load += OnFormLoad;
        }

        /// <summary>
        /// OnFormLoad
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnFormLoad(object sender, EventArgs e)
        {
            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
            this.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.Name);
            this.KeyPreview = true;
            //LoadOrganizationList();
            //LoadRoomList();
            LoadMeetingList();
            SetLanguages();
        }
        /// <summary>
        /// SetLanguages
        /// </summary>
        private void SetLanguages()
        {
            this.colSTT.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colSTT.Name);
            this.colNamePartaker.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colNamePartaker.Name);
            this.colPositionPartaker.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colPositionPartaker.Name);
            this.colCheck.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colCheck.Name);
            this.colNameOrg.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colNameOrg.Name);
        }

        #region bgWorker
        /// <summary>
        /// CreateBackgroundWorkerEvent
        /// </summary>
        private void CreateBackgroundWorkerEvent()
        {
            //21. Xem thông tin cuộc họp
            bgwLoadMeetingList = new BackgroundWorker();
            bgwLoadMeetingList.WorkerSupportsCancellation = true;
            bgwLoadMeetingList.DoWork += OnLoadMeetingWorkerDoWork;
            bgwLoadMeetingList.RunWorkerCompleted += OnLoadMeetingWorkerCompleted;

            //22. Cập Nhật thời gian cuộc họp
            bgwUpdateEventMeeting = new BackgroundWorker();
            bgwUpdateEventMeeting.WorkerSupportsCancellation = true;
            bgwUpdateEventMeeting.DoWork += LoadUpdateEventMeetingWorkerDoWork;
            bgwUpdateEventMeeting.RunWorkerCompleted += LoadUpdateEventMeetingRunWorkerCompleted;

        }

        #region Gửi yêu cầu lấy thông tin cuộc họp
        /// <summary>
        /// LoadMeetingList
        /// </summary>
        private void LoadMeetingList()
        {
            if (!bgwLoadMeetingList.IsBusy)
            {
                bgwLoadMeetingList.RunWorkerAsync();
            }
        }

        /// <summary>
        /// OnLoadMeetingWorkerDoWork
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoadMeetingWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {

                e.Result = OriginalEventMeeting = MeetingEventFactory.Instance.GetChannel().getEventMeetingById(StorageService.CurrentSessionId, meetingId);
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
        /// OnLoadMeetingWorkerCompleted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoadMeetingWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "SmsNotConnectData"));
                //StartTimer();
                this.Close();
                return;
            }
            if (e.Result == null)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "SmsNotInforMeetingthis"));
                this.Close();
                // StartTimer();
                return;
            }
            else
            {
                EventMeeting result = (EventMeeting)e.Result;
                LoadlInfoEventMeeting(result);
            }
        }
        #endregion

        #region Hiển thị thông tin cuộc họp
        /// <summary>
        /// SHow info meeting
        /// </summary>
        /// <param name="eventMeetingItem"></param>
        private void LoadlInfoEventMeeting(EventMeeting eventMeetingItem)
        {
            List<PartakerObj> jsonListPartaker = new List<PartakerObj>();
            //cbxOrganization.SelectedIndex = (int)eventMeetingItem.organizationMeetingId;
            //this.cbxOrganization.Text = eventMeetingItem.organizationMeetingName;
            this.txtOrg.Text = eventMeetingItem.organizationMeetingName;
            this.tbxNameMeeting.Text = eventMeetingItem.name;
            // cbxNameRoom.SelectedIndex = (int)eventMeetingItem.roomId;
            // this.cbxNameRoom.Text = eventMeetingItem.roomName;
            this.txtNote.Text = eventMeetingItem.note;

            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            DateTime startDate = start.AddMilliseconds(Convert.ToUInt64(eventMeetingItem.startTime)).ToLocalTime();
            DateTime endDate = start.AddMilliseconds(Convert.ToUInt64(eventMeetingItem.endTime)).ToLocalTime();
            this.dtpDay.Value = startDate;
            this.dtpStartTime.Text = startDate.ToString("hh:mm tt");
            this.dtpEndTime.Text = endDate.ToString("hh:mm tt");
            if (null != eventMeetingItem.listNonResident)
                jsonListPartaker = JsonConvert.DeserializeObject<List<PartakerObj>>(eventMeetingItem.listNonResident);

            if (jsonListPartaker.Count > 0)
            {
                partakerOtherList.AddRange(jsonListPartaker);
                loadPartakersToTable(jsonListPartaker);
            }
        }

        /// <summary>
        /// show list partakers
        /// </summary>
        private void loadPartakersToTable(List<PartakerObj> listPartakerNew)
        { //xóa bảng trước khi init
            dtbEventListPartaker.Clear();
            int index = 0;
            //nếu có dữ liệu thêm người tham dự 
            if (listPartakerNew.Count > 0)
            {
                for (int i = 0; i < listPartakerNew.Count; i++)
                {
                    DataRow row = dtbEventListPartaker.NewRow();
                    row.BeginEdit();
                    index = i + 1;
                    row[colSTT.DataPropertyName] = index;
                    row[colNamePartaker.DataPropertyName] = listPartakerNew[i].name;
                    row[colNameOrg.DataPropertyName] = listPartakerNew[i].orgname;
                    row[colPositionPartaker.DataPropertyName] = listPartakerNew[i].position;
                    row[colCheck.DataPropertyName] = true;
                    row.EndEdit();
                    dtbEventListPartaker.Rows.Add(row);
                }
            }

            if (dgvListAttend.Rows.Count > 0)
                //focur the first row in table
                dgvListAttend.Rows[0].Selected = true;
            //   this.btnUpdatePartaker.Enabled = false;
        }

        #endregion

        #region Lưu thông tin Cần dời lịch họp vào hệ thống
        /// <summary>
        /// LoadUpdateEventMeetingWorkerDoWork
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadUpdateEventMeetingWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = (int)Status.SUCCESS == MeetingEventFactory.Instance.GetChannel().updateEventMeeting(storageService.CurrentSessionId, AddOrUpdateEventMeeting);
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
            finally
            {
            }
        }
        /// <summary>
        /// LoadUpdateEventMeetingRunWorkerCompleted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadUpdateEventMeetingRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                partakerOtherListCheck = new List<PartakerObj>();
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "smsErrorUpdateMeeting"));
                return;
            }

            if ((bool)e.Result)
            {
                partakerOtherListCheck = new List<PartakerObj>();
                // ClearEmptyControl();
                //  MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "smsSuccessUpdateMeeting"));
                PostAction = DialogPostAction.SUCCESS;
                this.Close();
                //StartTimer();
            }
            else
            {
                partakerOtherListCheck = new List<PartakerObj>();
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "smsErrorUpdateMeeting"));
                return;
            }
        }
        #endregion

        #endregion

        #region Event's support (ToEntity)
        /// <summary>
        /// tao doi tuong event luu xuong 
        /// ToEntity
        /// </summary>
        /// <returns></returns>
        private EventMeeting ToEntity()
        {
            EventMeeting eventMeeting = new EventMeeting();
            //310317
            eventMeeting = OriginalEventMeeting;
            //end 310317

            // eventMeeting.id = OriginalEventMeeting.id;
            // eventMeeting.name = tbxNameMeeting.Text;
            eventMeeting.note = txtNote.Text;

            //eventMeeting.meetingCode = OriginalEventMeeting.meetingCode;
            //eventMeeting.meetingCodeStatus = OriginalEventMeeting.meetingCodeStatus;
            ////20170307 #Bug Fix- My Nguyen Start
            ////thêm đối tượng để map dữ liệu
            //eventMeeting.meetingCode = -1;
            //eventMeeting.meetingCodeStatus = true;
            ////20170307 #Bug Fix- My Nguyen End

            DateTime dtDate = this.dtpDay.Value.Date;
            DateTime dtpStartTime = this.dtpStartTime.Value.Date;
            DateTime dtpEndTime = this.dtpEndTime.Value.Date;
            String dtDatestr = dtDate.ToString("yyyy-MM-dd 00:00:00");
            String dtStartTimestr = startTimeNew.ToString("yyyy-MM-dd HH:mm:00");
            String dtpEndTimeStr = endTimeNew.ToString("yyyy-MM-dd HH:mm:00");
            eventMeeting.startTime = dtStartTimestr;
            eventMeeting.endTime = dtpEndTimeStr;

            ////310317
            //eventMeeting.organizationMeetingId = OriginalEventMeeting.organizationMeetingId;
            //eventMeeting.organizationMeetingName = OriginalEventMeeting.organizationMeetingName;

            //eventMeeting.roomId = (int)OriginalEventMeeting.roomId;
            //eventMeeting.roomName = OriginalEventMeeting.roomName;

            ////cách xử lí json 1
            ////danh sách người tham dự được thêm vào sau chuyển về json để lưu xuống database
            //string jsonPartaker = JsonConvert.SerializeObject(partakerOtherListCheck);
            //eventMeeting.listNonResident = jsonPartaker;
            //eventMeeting.nonresident = false;//cuộc họp có sẵn
            //eventMeeting.number = partakerOtherListCheck.Count;
            ////end 310317
            return eventMeeting;
        }
        #endregion

        #region ValidateData
        /// <summary>
        /// check data textbox, combobox,...
        /// </summary>
        /// <returns></returns>
        private bool ValidateData()
        {
            String error = "";
            bool check = true;
            if (string.IsNullOrEmpty(tbxNameMeeting.Text))
            {
                error += MessageValidate.GetMessage(rm, "smsNameMeeting") + " ";
                check = false;
            }

            if (check)
            {
                return true;
            }
            else
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessageValidate(rm, "smsNameMeeting"), MessageValidate.GetErrorTitle(rm));
                //  MessageBoxManager.ShowErrorMessageBox(this, String.Format(MessageValidate.GetMessage(rm, "smsValidateData"), error));
                return false;
            }
        }

        /// <summary>
        /// kiểm tra ngày
        /// ValidateDate
        /// </summary>
        /// <param name="dtIn"></param>
        /// <param name="dtIn2"></param>
        /// <param name="dtInstr"></param>
        /// <param name="dtIn2str"></param>
        /// <returns></returns>
        private bool ValidateDate(DateTime dtIn, DateTime dtIn2, String dtInstr, String dtIn2str)
        {
            bool check = false;
            int result = DateTime.Compare(dtIn, dtIn2);
            if (result < 0)
            {
                check = true;
                return check;
            }
            else if (result == 0)
            {
                check = false;
                MessageBoxManager.ShowErrorMessageBox(this, String.Format(MessageValidate.GetMessage(rm, "smsValidateDate"), dtIn2str, dtInstr));
                return check;
            }
            else
            {
                check = false;
                MessageBoxManager.ShowErrorMessageBox(this, String.Format(MessageValidate.GetMessage(rm, "smsValidateDate"), dtIn2str, dtInstr));
                return check;
            }
        }

        #endregion

        #region Button Event's 
        /// <summary>
        /// GetListPartakeCheck
        ///   lấy danh sách người tham dự có chek ô tham dự họp
        /// </summary>
        private void GetListPartakeCheck()
        {
            var selectedRows = dgvListAttend.Rows;
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
                    if (i < partakerOtherList.Count)
                    {
                        partakerOtherListCheck.Add(partakerOtherList[i]);
                    }
                }
            }
        }
        /// <summary>
        /// click putin :btn update
        /// </summary>
        private void PutIn()
        {
            DateTime dtDay = this.dtpDay.Value.Date;

            DateTime dtStart = dtDay;
            int hour = this.dtpStartTime.Value.Hour;
            int minutes = this.dtpStartTime.Value.Minute;
            TimeSpan ts = new TimeSpan(hour, minutes, 0);
            dtStart = dtStart.Date + ts;
            startTimeNew = dtStart;
            DateTime dtEnd = dtDay;
            int hourEnd = this.dtpEndTime.Value.Hour;
            int minutesEnd = this.dtpEndTime.Value.Minute;
            TimeSpan tsEnd = new TimeSpan(hourEnd, minutesEnd, 0);
            dtEnd = dtEnd.Date + tsEnd;
            endTimeNew = dtEnd;

            if (ValidateData() && ValidateDate(dtStart, dtEnd, MessageValidate.GetMessage(rm, "lblStartTime"), MessageValidate.GetMessage(rm, "lblEndTime")) && MessageBoxManager.ShowQuestionMessageBox(this, MessageValidate.GetMessage(rm, "smsQuestionYesNoUpdateMeeting")) == System.Windows.Forms.DialogResult.Yes)
            {
                GetListPartakeCheck();

                if (!bgwUpdateEventMeeting.IsBusy)
                {
                    AddOrUpdateEventMeeting = ToEntity();
                    bgwUpdateEventMeeting.RunWorkerAsync();
                }
            }
        }

        private void OnButtonPutInClicked(object sender, EventArgs e)
        {
            PutIn();
        }

        /// <summary>
        /// Register : key F10, key escape
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
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

        private void OnButtonCancelClicked(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Control
        /// <summary>
        ///  reset data in form to default
        /// </summary>
        private void ClearEmptyControl2()
        {
            tbxNameMeeting.Text = string.Empty;
            txtNote.Text = string.Empty;
            CustomTypeDate();
        }
        #endregion

        #region CustomDesign
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.DarkGray, ButtonBorderStyle.Solid);
        }

        /// <summary>
        /// CustomTypeDate
        /// </summary>
        private void CustomTypeDate()
        {
            // custom date time 
            dtpStartTime.ShowUpDown = true;
            dtpStartTime.CustomFormat = "HH:mm tt";
            dtpEndTime.ShowUpDown = true;
            dtpEndTime.CustomFormat = "HH:mm tt";
            //  dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            //dtpDay.ShowUpDown = true;
            dtpDay.CustomFormat = "dd/MM/yyyy";
            //20170304 #Bug Fix- My Nguyen Start
            //format time
            //DateTime dtDay = this.dtpDay.Value.Date;
            //dtpDay.Value = DateTime.Now;

            //DateTime dtStart = dtDay;
            //int hour = 8;
            //int minutes = 0;
            //TimeSpan ts = new TimeSpan(hour, minutes, 0);
            //dtStart = dtStart.Date + ts;
            //dtpStartTime.Value = dtStart;

            //DateTime dtEnd = dtDay;
            //int hourEnd = 17;
            //int minutesEnd = 0;
            //TimeSpan tsEnd = new TimeSpan(hourEnd, minutesEnd, 0);
            //dtEnd = dtEnd.Date + tsEnd;
            //dtpEndTime.Value = dtEnd;
            //20170304 #Bug Fix- My Nguyen Start
        }
        #endregion
    }
}


