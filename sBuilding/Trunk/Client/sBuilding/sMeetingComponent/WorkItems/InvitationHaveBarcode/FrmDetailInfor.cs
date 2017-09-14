using CommonControls;
using CommonHelper.Constants;
using CommonHelper.Utils;
using JavaCommunication;
using Microsoft.Practices.CompositeUI;
using Newtonsoft.Json;
using sMeetingComponent.Constants;
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

namespace sMeetingComponent.WorkItems
{
    public partial class FrmDetailInfor : Form
    {

        #region Properties
        public const byte ModeBarcode = 1;
        private byte OperatingMode;

        // User control này thông báo tin nhắn tự động tắt theo thời gian
        private UsrNotification usrNotification = null;
        private ConfigTime configTime;
        private System.Windows.Forms.Timer timer = null;
        private int time = 0;

        private String barcode { get; set; }
        private MeetingInfoPartakerObj detailInfo;
        private DataTable dtbEventListPartaker;
        private DataTable dtbEventListPartakerInvation;

        List<Partaker> partakerOtherList;//danh sách người tham dự tự thêm vào
        List<Partaker> partakerOtherListCheck;//danh sách người tham dự tự thêm vào => được check
        List<Partaker> ePartakerList;//danh sách người tham dự được mời
        List<Partaker> ePartakerListCheck;//danh sách người tham dự được mời => đx check = tham dự

        private List<EventAttendMeeting> AddOrUpdateAttendMeetingObj;
        private List<EventAttendMeeting> OriginalAttendMeetingObj { get; set; }
        private BackgroundWorker loadEventDetailInfo;
        private BackgroundWorker bgwAddAttendMeetingObj;

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
        public FrmDetailInfor(byte mode, String codeMeetingInvitation)
        {
            InitializeComponent();
            InitDataTableEventListPartakers();
            //  CustomTypeDate();
            this.barcode = codeMeetingInvitation;
            this.OperatingMode = mode;

            partakerOtherList = new List<Partaker>();
            partakerOtherListCheck = new List<Partaker>();
            ePartakerList = new List<Partaker>();
            ePartakerListCheck = new List<Partaker>();

            RegisterEvent();

            #region usrNotification
            configTime = new ConfigTime();
            time = configTime.SetTime();

            usrNotification = new UsrNotification();
            usrNotification.Anchor = AnchorStyles.None;
            usrNotification.Visible = false;
            panel2.Controls.Add(usrNotification);
            usrNotification.Location = new Point(
                panel2.ClientSize.Width / 2 - usrNotification.Width / 2,
                panel2.ClientSize.Height / 2 - usrNotification.Height / 2);
            usrNotification.BringToFront();
            #endregion

        }

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

        #endregion

        private void InitDataTableEventListPartakers()
        {
            dtbEventListPartaker = new DataTable();
            dtbEventListPartaker.Columns.Add(colSTT.DataPropertyName);
            dtbEventListPartaker.Columns.Add(colNamePartaker.DataPropertyName);
            dtbEventListPartaker.Columns.Add(colPositionPartaker.DataPropertyName);
            dtbEventListPartaker.Columns.Add(colCheck.DataPropertyName);
            dgvListAttend.DataSource = dtbEventListPartaker;

            //htmynguyen
            //danh sach thứ 2
            dtbEventListPartakerInvation = new DataTable();
            dtbEventListPartakerInvation.Columns.Add(colSTTinfo.DataPropertyName);
            dtbEventListPartakerInvation.Columns.Add(colNamePartakerInfo.DataPropertyName);
            dtbEventListPartakerInvation.Columns.Add(colNameOrg.DataPropertyName);
            dtbEventListPartakerInvation.Columns.Add(colPositionPartakerInfo.DataPropertyName);
            dtbEventListPartakerInvation.Columns.Add(colCheckInfo.DataPropertyName);
            dgvListAttendInvation.DataSource = dtbEventListPartakerInvation;
        }

        /// <summary>
        ///  dang ky su kien 
        /// </summary>
        private void RegisterEvent()
        {
            CreateBackgroundWorkerEvent();
            btnAdd.Click += OnButtonbtnAddAttendClicked;
            btnConfirm.Click += OnButtonPutInClicked;
            btnCancel.Click += OnButtonExitClicked;
            btnRefresh.Click += OnButtonRefreshClicked;

            // doi thanh nhan chuot
            //   dgvListAttend.CellClick += OnButtonDgvListAttendClicked;
            dgvListAttend.KeyDown += OnButtonDgvListAttendKeyPress;
            Load += OnFormLoad;
        }

        private void OnFormLoad(object sender, EventArgs e)
        {
            switch (OperatingMode)
            {
                case ModeBarcode:
                    LoadEventDetailInfo();
                    break;
                default:
                    throw new ArgumentException("Invalid operating mode!");
            }

            this.KeyPreview = true;

            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
            this.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.Name);
            //pagerPanel1.StorageService = storageService;
            //  pagerPanel1.LoadLanguage();

            //cho focus vao nut huy
            btnCancel.Select();
            SetLanguages();
        }

        /// <summary>
        /// set languages for datagridview
        /// </summary>
        private void SetLanguages()
        {
            this.colSTT.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colSTT.Name);
            this.colNamePartaker.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colNamePartaker.Name);
            this.colPositionPartaker.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colPositionPartaker.Name);
            this.colCheck.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colCheck.Name);

            this.colSTTinfo.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colSTTinfo.Name);
            this.colNamePartakerInfo.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colNamePartakerInfo.Name);
            this.colPositionPartakerInfo.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colPositionPartakerInfo.Name);
            this.colNameOrg.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colNameOrg.Name);

            this.colCheckInfo.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colCheckInfo.Name);
        }

        /// <summary>
        /// Load info AttendMeeting
        /// </summary>
        private void LoadEventDetailInfo()
        {
            if (!loadEventDetailInfo.IsBusy)
            {
                loadEventDetailInfo.RunWorkerAsync();
            }
        }

        #region bgWorker
        private void CreateBackgroundWorkerEvent()
        {
            loadEventDetailInfo = new BackgroundWorker();
            loadEventDetailInfo.WorkerSupportsCancellation = true;
            loadEventDetailInfo.DoWork += OnLoadEventDetailInfoWorkerDoWork;
            loadEventDetailInfo.RunWorkerCompleted += OnLoadEventDetailInfoWorkerCompleted;

            bgwAddAttendMeetingObj = new BackgroundWorker();
            bgwAddAttendMeetingObj.WorkerSupportsCancellation = true;
            bgwAddAttendMeetingObj.DoWork += OnLoadAddAttendMeetingObjWorkerDoWork;
            bgwAddAttendMeetingObj.RunWorkerCompleted += OnLoadAddAttendMeetingObjRunWorkerCompleted;
        }


        private void OnLoadEventDetailInfoWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Failed, MessageValidate.GetMessage(rm, "SmsNotConnectData"))));
                StartTimer();
                return;
            }
            if (e.Result == null)
            {
                Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Failed, MessageValidate.GetMessage(rm, "SmsNotInforMeetingRetry"))));
                StartTimer();
                return;
            }
            else
            {
                MeetingInfoPartakerObj result = (MeetingInfoPartakerObj)e.Result;

                LoadEventDetailInfodata(result);
            }
        }

        /// <summary>
        /// get info attendmeeting by barcode
        /// OnLoadEventDetailInfoWorkerDoWork
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoadEventDetailInfoWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = detailInfo = DetailInfoFactory.Instance.GetChannel().getDetailInfoByBarcode(storageService.CurrentSessionId, barcode);
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

        private void OnLoadAddAttendMeetingObjRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                partakerOtherListCheck = new List<Partaker>();
                ePartakerListCheck = new List<Partaker>();
                Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Failed, MessageValidate.GetMessage(rm, "smsErrorInsertPersonal"))));
                return;
            }
            if (e.Result == null)
            {
                partakerOtherListCheck = new List<Partaker>();
                ePartakerListCheck = new List<Partaker>();
                Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Failed, MessageValidate.GetMessage(rm, "smsErrorInsertPersonal"))));
                return;
            }
            if ((bool)e.Result)
            {
                PostAction = DialogPostAction.SUCCESS;
                // Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Succeed, MessageValidate.GetMessage(rm, "smsSuccessPersonal"))));
                // StartTimer();
                UsrListMeeting.getStatus(1);
                this.Close();
            }
            else
            {
                Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Failed, MessageValidate.GetMessage(rm, "smsErrorInsertPersonal"))));
            }
        }

        /// <summary>
        /// insert list Partaker of attendmeeting
        /// OnLoadAddAttendMeetingObjWorkerDoWork
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoadAddAttendMeetingObjWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = (int)Status.SUCCESS == AttendMeetingFactory.Instance.GetChannel().insertEventAttendMeeting(storageService.CurrentSessionId, AddOrUpdateAttendMeetingObj);
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

        /// <summary>
        /// show info attendmeeting
        /// </summary>
        /// <param name="detailInfo"></param>
        private void LoadEventDetailInfodata(MeetingInfoPartakerObj detailInfo)
        {
            try
            {
                this.txtMeetingName.Text = detailInfo.meeting.name;
                this.txtOrg.Text = detailInfo.meeting.organizationMeetingName;//đơn vị tổ chức cuộc họp
                this.txtRoom.Text = detailInfo.meeting.roomName;//htmynguyen?
                                                                // this.txtNote.Text = "Đăng ký tham dự họp";
                                                                // this.txtNote.Text = "";

                //  this.txtnumericNumber.Text = ""+detailInfo.meeting.number;
                this.txtOrganization.Text = detailInfo.organizationAttend.name;//đơn vị được mời

                DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                DateTime startDate = start.AddMilliseconds(Convert.ToUInt64(detailInfo.meeting.startTime)).ToLocalTime();
                DateTime endDate = start.AddMilliseconds(Convert.ToUInt64(detailInfo.meeting.endTime)).ToLocalTime();
                this.dtpDay.Value = startDate;
                this.dtpStartTime.Text = startDate.ToString("hh:mm tt");
                this.dtpEndTime.Text = endDate.ToString("hh:mm tt");

                ePartakerList = detailInfo.partakers;

                loadPartakersToTable();

                //hiển thị danh sách thông tin của cuộc họp được mời chỉ có thể xem không làm gì hết
                List<Partaker> jsonListPartaker = new List<Partaker>();
                jsonListPartaker = JsonConvert.DeserializeObject<List<Partaker>>(detailInfo.meeting.listNonResident);
                if (jsonListPartaker != null)
                {
                    loadPartakersToTableInfoMeeting(jsonListPartaker);
                }
            }
            catch(Exception ex) {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "TimeOutExceptionMessage"));
            }

        }

        /// <summary>
        /// hiển thị thông tin danh sách tất cả người tham dự của cuộc hop
        /// </summary>
        /// <param name="partakerOtherList"></param>
        private void loadPartakersToTableInfoMeeting(List<Partaker> partakerOtherList)
        {
            //xóa bảng trước khi init
            dtbEventListPartakerInvation.Clear();
            int index = 0;
            //nếu có dữ liệu thêm người tham dự 
            if (partakerOtherList.Count > 0)
            {
                for (int i = 0; i < partakerOtherList.Count; i++)
                {
                    DataRow row = dtbEventListPartakerInvation.NewRow();
                    row.BeginEdit();
                    index = i + 1;
                    row[colSTTinfo.DataPropertyName] = index;
                    row[colNamePartakerInfo.DataPropertyName] = partakerOtherList[i].name;
                    row[colNameOrg.DataPropertyName] = partakerOtherList[i].orgname;

                    row[colPositionPartakerInfo.DataPropertyName] = partakerOtherList[i].position;
                    row[colCheckInfo.DataPropertyName] = true;
                    row.EndEdit();
                    dtbEventListPartakerInvation.Rows.Add(row);
                }
            }

            //// set font size header
            //foreach (DataGridViewColumn col in this.dgvListAttendInvation.Columns)
            //{
            //    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //    col.HeaderCell.Style.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            //}

            //// set font size
            //this.dgvListAttendInvation.DefaultCellStyle.Font = new Font("Tahoma", 12F);
            //this.dgvListAttendInvation.DefaultCellStyle.Padding = new Padding(0, 3, 0, 3);
            //this.dgvListAttendInvation.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;


            if (dgvListAttendInvation.Rows.Count > 0)
                //focur the first row in table
                dgvListAttendInvation.Rows[0].Selected = true;
        }

        /// <summary>
        /// show list partakers
        /// </summary>
        private void loadPartakersToTable()
    {//xóa bảng trước khi init
            dtbEventListPartaker.Clear();
            int index = 0;
            for (int i = 0; i < ePartakerList.Count; i++)
            {
                DataRow row = dtbEventListPartaker.NewRow();
                row.BeginEdit();
                index = i + 1;
                row[colSTT.DataPropertyName] = index;
                row[colNamePartaker.DataPropertyName] = ePartakerList[i].name;
                row[colPositionPartaker.DataPropertyName] = ePartakerList[i].position;
                row[colCheck.DataPropertyName] = true;
                row.EndEdit();
                dtbEventListPartaker.Rows.Add(row);
            }

            //nếu có dữ liệu thêm người tham dự 
            if (partakerOtherList.Count > 0)
            {
                // thieu thong tin het 1 truong du lieu???
                int positionList = 0;
                //for (int i = ePartakerList.Count; i < (ePartakerList.Count + partakerOtherList.Count + 1); i++)
                for (int i = ePartakerList.Count; i < (ePartakerList.Count + partakerOtherList.Count); i++)
                {
                    DataRow row = dtbEventListPartaker.NewRow();
                    row.BeginEdit();
                    //index = i + 1;
                    index = index + 1;
                    row[colSTT.DataPropertyName] = index;
                    positionList = i - ePartakerList.Count;
                    // positionList = i - ePartakerList.Count - 1;
                    row[colNamePartaker.DataPropertyName] = partakerOtherList[positionList].name;
                    row[colPositionPartaker.DataPropertyName] = partakerOtherList[positionList].position;
                    row[colCheck.DataPropertyName] = true; //có dấu check ban đầu 
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
            //this.dgvListAttend.DefaultCellStyle.Font = new Font("Tahoma", 14F);
            //this.dgvListAttend.DefaultCellStyle.Padding = new Padding(0, 3, 0, 3);
            //this.dgvListAttend.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            if (dgvListAttend.Rows.Count > 0)
                //focur the first row in table
                dgvListAttend.Rows[0].Selected = true;

            ValidateStartTime();

        }

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
                    if (i < detailInfo.partakers.Count)
                    {
                        //người tham dự có trong danh sách ban đầu
                        ePartakerListCheck.Add(detailInfo.partakers[i]);
                    }
                    else
                    {
                        //người tham dự trong danh sách tự thêm vào sau
                        partakerOtherListCheck.Add(partakerOtherList[i - detailInfo.partakers.Count]);
                        //  partakerOtherListCheck.Add(partakerOtherList[i - detailInfo.partakers.Count-1]);
                    }
                }
            }
        }

        #region Event's support
        /// <summary>
        /// tao doi tuong attendmeeting
        /// </summary>
        /// <returns></returns>
        private List<EventAttendMeeting> ToEntity(bool status)
        {
            List<EventAttendMeeting> attendMeetingList = new List<EventAttendMeeting>();
            DateTime dateStart = DateTime.Now;
            String startDate = dateStart.ToString("yyyy-MM-dd HH:mm");
            DateTime dateEnd = new DateTime(1971, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            String endDate = dateEnd.ToString("yyyy-MM-dd HH:mm");
            int countePartakerListCheck = ePartakerListCheck.Count;
            if (countePartakerListCheck > 0)
            {
                for (int i = 0; i < countePartakerListCheck; i++)
                {
                    EventAttendMeeting attendMeetingitem = new EventAttendMeeting();
                    attendMeetingitem.meetingBarcode = barcode;
                    attendMeetingitem.meetingId = detailInfo.meeting.id;
                    attendMeetingitem.meetingName = detailInfo.meeting.name;
                    attendMeetingitem.organizationMeetingId = detailInfo.meeting.organizationMeetingId;
                    attendMeetingitem.organizationMeetingName = detailInfo.meeting.organizationMeetingName;
                    attendMeetingitem.note = txtNote.Text;
                    attendMeetingitem.status = status;
                    attendMeetingitem.inputTime = startDate;
                    attendMeetingitem.outputTime = endDate;

                    attendMeetingitem.organizationAttendId = detailInfo.organizationAttend.id;
                    attendMeetingitem.organizationAttendName = detailInfo.organizationAttend.name;
                    attendMeetingitem.partakerId = ePartakerListCheck[i].id;
                    attendMeetingitem.partakerName = ePartakerListCheck[i].name;
                    attendMeetingitem.invited = true;
                    attendMeetingList.Add(attendMeetingitem);
                }
            }

            int countepartakerOtherListCheck = partakerOtherListCheck.Count;
            if (countepartakerOtherListCheck > 0)
            {
                for (int i = 0; i < countepartakerOtherListCheck; i++)
                {
                    EventAttendMeeting attendMeetingitem = new EventAttendMeeting();
                    attendMeetingitem.meetingBarcode = barcode;
                    attendMeetingitem.meetingId = detailInfo.meeting.id;
                    attendMeetingitem.meetingName = detailInfo.meeting.name;
                    attendMeetingitem.organizationMeetingId = detailInfo.meeting.organizationMeetingId;
                    attendMeetingitem.organizationMeetingName = detailInfo.meeting.organizationMeetingName;
                    attendMeetingitem.note = txtNote.Text;
                    attendMeetingitem.status = status;
                    attendMeetingitem.inputTime = startDate;
                    attendMeetingitem.outputTime = endDate;

                    attendMeetingitem.organizationAttendId = detailInfo.organizationAttend.id;
                    attendMeetingitem.organizationAttendName = detailInfo.organizationAttend.name;
                    attendMeetingitem.partakerId = partakerOtherListCheck[i].id;
                    attendMeetingitem.partakerName = partakerOtherListCheck[i].name;
                    attendMeetingitem.invited = false;
                    attendMeetingList.Add(attendMeetingitem);
                }
            }
            return attendMeetingList;
        }
        #endregion

        #region Button Event's 
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
        //                this.dgvListAttend.Select();
        //            }
        //            else
        //            {
        //                this.dgvListAttend.Select();
        //            }
        //            break;
        //    }
        //}

        private void PutIn()
        {
            String note = txtNote.Text;
            GetListPartakeCheck();


            if (ValidateStartTime() && ValidateData())//&& MessageBoxManager.ShowQuestionMessageBox(this, MessageValidate.GetMessage(rm, "smsQuestionYesNoInsertPersonalAttendMeeting")) == System.Windows.Forms.DialogResult.Yes)
            {
                if (!bgwAddAttendMeetingObj.IsBusy)
                {
                    AddOrUpdateAttendMeetingObj = ToEntity(true);
                    bgwAddAttendMeetingObj.RunWorkerAsync();
                }
            }
        }

        /// <summary>
        /// click button add 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButtonbtnAddAttendClicked(object sender, EventArgs e)
        {
            if (ValidateDataPartaker())//&& MessageBoxManager.ShowQuestionMessageBox(this, MessageValidate.GetMessage(rm, "smsQuestionYesNoPersonalAttendMeeting")) == System.Windows.Forms.DialogResult.Yes)
            {
                Partaker partaker = new Partaker();
                partaker.name = txtNameAttend.Text;
                partaker.position = txtPositionAttend.Text;
                partaker.orgId = detailInfo.meeting.organizationMeetingId;
                partaker.orgname = detailInfo.meeting.organizationMeetingName;
                partakerOtherList.Add(partaker);
                loadPartakersToTable();
                ClearEmptyControl();
            }
        }

        private void OnButtonPutInClicked(object sender, EventArgs e)

        {
            PutIn();
        }

        /// <summary>
        /// kiểm tra dữ liệu nhập vào form
        /// </summary>
        private bool ValidateData()
        {
            if (partakerOtherListCheck.Count == 0 && ePartakerListCheck.Count == 0)
            {
                Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Failed, MessageValidate.GetMessage(rm, "smsEmptyListPersonalMeeting"))));
                return false;
            }
            return true;
        }

        /// <summary>
        ///  kiểm tra dữ liệu nhập vào form
        /// </summary>
        private bool ValidateStartTime()
        {
            //20170307 #Bug Fix- quet barcode lien tuc, phia server gui detailinfo chua kip TaiMai Start
            if (detailInfo == null)
            {
                return false;
            }
            //20170307 #Bug Fix- quet barcode lien tuc, phia server gui detailinfo chua kip TaiMai end
            //ngay hien tai
            DateTime dateTime = DateTime.UtcNow.Date;
            String dateNowStr = dateTime.ToString("yyyy-MM-dd");
            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
           
            DateTime startDate = start.AddMilliseconds(Convert.ToUInt64(detailInfo.meeting.startTime)).ToLocalTime();
            String dateStartStr = startDate.ToString("yyyy-MM-dd");

            if (!dateNowStr.Equals(dateStartStr))
            {
                Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Failed, MessageValidate.GetMessage(rm, "smsStartTimeMeeting") + " " + dateStartStr.ToString())));
                return false;
            }
            return true;
        }

        /// <summary>
        /// 
        /// kiểm tra dữ liệu nhập vào form
        /// </summary>
        /// <returns></returns>
        private bool ValidateDataPartaker()
        {
            if (string.IsNullOrEmpty(txtNameAttend.Text))
            {
              //  MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessageValidate(rm, "smsNameAttend"), MessageValidate.GetErrorTitle(rm));
                Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Failed, MessageValidate.GetMessageValidate(rm, "smsNameAttend"))));

               // Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Failed, MessageValidate.GetMessage(rm, "smswordcompletionNamePersonal"))));
                return false;
            }
            if (string.IsNullOrEmpty(txtPositionAttend.Text))
            {
               // MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessageValidate(rm, "smsPosition"), MessageValidate.GetErrorTitle(rm));

                Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Failed, MessageValidate.GetMessageValidate(rm, "smsPosition"))));

               // Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Failed, MessageValidate.GetMessage(rm, "smswordcompletionOrg"))));
                return false;
            }
            return true;
        }

        private void OnButtonDgvListAttendClicked(object sender, DataGridViewCellEventArgs e)
        {
            //int rowIndex = e.RowIndex;
            //if (rowIndex != -1)
            //{
            //    if (e.ColumnIndex == 3)
            //    {
            //        bool check = Convert.ToBoolean(dgvListAttend.Rows[e.RowIndex].Cells[3].Value);
            //        dgvListAttend.Rows[e.RowIndex].Cells[3].Value = !check;
            //    }
            //}
        }

        private void OnButtonDgvListAttendKeyPress(object sender, KeyEventArgs e)
        {
            var selectedRows = dgvListAttend.SelectedRows;
            int rowsCount = selectedRows.Count;
            //so dong duoc chon
            if (rowsCount == 0)
            {
              //  Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Failed, MessageValidate.GetMessage(rm, "smsPleaseClickChooseInfo"))));
            }
            else
            {
                int rowindex = dgvListAttend.CurrentRow.Index;
                if (e.KeyCode == Keys.Space)
                {
                    bool check = Convert.ToBoolean(selectedRows[0].Cells[colCheck.Name].Value);
                    dgvListAttend.Rows[rowindex].Cells[3].Value = !check;
                }
            }
        }

        private void OnButtonExitClicked(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OnButtonRefreshClicked(object sender, EventArgs e)
        {
            ClearEmptyControl();
        }

        #endregion

        #region Control
        /// <summary>
        ///  reset data in form to default
        /// </summary>
        private void ClearEmptyControl()
        {
            txtNameAttend.Text = string.Empty;
            txtPositionAttend.Text = string.Empty;
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
            dtpDay.ShowUpDown = true;
            dtpDay.CustomFormat = "dd/MM/yyyy";
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.DarkGray, ButtonBorderStyle.Solid);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.DarkGray, ButtonBorderStyle.Solid);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.DarkGray, ButtonBorderStyle.Solid);
        }

        private void txt6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnConfirm.Select();
            }
        }
        private void txt9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnCancel.Enter += OnButtonExitClicked;
            }
        }
        #endregion

        private void dgvListAttend_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex != -1)
            {
                if (e.ColumnIndex == 3)
                {
                    bool check = Convert.ToBoolean(dgvListAttend.Rows[e.RowIndex].Cells[3].Value);
                    dgvListAttend.Rows[e.RowIndex].Cells[3].Value = !check;
                }
            }
        }
    }
}
