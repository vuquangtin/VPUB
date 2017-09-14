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
    public partial class FrmUpdateTimeMeeting : Form
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
        /// FrmUpdateTimeMeeting
        /// </summary>
        /// <param name="meetingId"></param>
        public FrmUpdateTimeMeeting(long meetingId)
        {
            this.meetingId = meetingId;
            InitializeComponent();

            CustomTypeDate();
            RegisterEvent();
            partakerOtherList = new List<PartakerObj>();
            partakerOtherListCheck = new List<PartakerObj>();
        }
        #endregion

        /// <summary>
        /// đăng ký sự kiện
        /// RegisterEvent
        /// </summary>
        private void RegisterEvent()
        {
            CreateBackgroundWorkerEvent();
            btnUpdateInfo.Click += OnButtonPutInClicked;
            btnCancel.Click += OnButtonCancelClicked;

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
            LoadMeetingList();
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
                this.Close();
                return;
            }
            if (e.Result == null)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "SmsNotInforMeetingthis"));
                this.Close();
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
        /// LoadlInfoEventMeeting
        /// Show info meeting
        /// </summary>
        /// <param name="eventMeetingItem"></param>
        private void LoadlInfoEventMeeting(EventMeeting eventMeetingItem)
        {
            List<PartakerObj> jsonListPartaker = new List<PartakerObj>();
            this.txtOrg.Text = eventMeetingItem.organizationMeetingName;
            this.tbxNameMeeting.Text = eventMeetingItem.name;
            this.txtNote.Text = eventMeetingItem.note;

            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            DateTime startDate = start.AddMilliseconds(Convert.ToUInt64(eventMeetingItem.startTime)).ToLocalTime();
            DateTime endDate = start.AddMilliseconds(Convert.ToUInt64(eventMeetingItem.endTime)).ToLocalTime();
            this.dtpDay.Value = startDate;
            this.dtpStartTime.Text = startDate.ToString("hh:mm tt");
            this.dtpEndTime.Text = endDate.ToString("hh:mm tt");

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
                PostAction = DialogPostAction.SUCCESS;
                this.Close();
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
            eventMeeting = OriginalEventMeeting;
            eventMeeting.note = txtNote.Text;

            DateTime dtDate = this.dtpDay.Value.Date;
            DateTime dtpStartTime = this.dtpStartTime.Value.Date;
            DateTime dtpEndTime = this.dtpEndTime.Value.Date;
            String dtDatestr = dtDate.ToString("yyyy-MM-dd 00:00:00");
            String dtStartTimestr = startTimeNew.ToString("yyyy-MM-dd HH:mm:00");
            String dtpEndTimeStr = endTimeNew.ToString("yyyy-MM-dd HH:mm:00");
            eventMeeting.startTime = dtStartTimestr;
            eventMeeting.endTime = dtpEndTimeStr;

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
        /// click putin : bnt add
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

            if (ValidateDate(dtStart, dtEnd, MessageValidate.GetMessage(rm, "lblStartTime"), MessageValidate.GetMessage(rm, "lblEndTime")) && MessageBoxManager.ShowQuestionMessageBox(this, MessageValidate.GetMessage(rm, "smsQuestionYesNoUpdateMeeting")) == System.Windows.Forms.DialogResult.Yes)
            {
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
        /// register : key f10, fey escape
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
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
            dtpDay.CustomFormat = "dd/MM/yyyy";
        }
        #endregion
    }
}


