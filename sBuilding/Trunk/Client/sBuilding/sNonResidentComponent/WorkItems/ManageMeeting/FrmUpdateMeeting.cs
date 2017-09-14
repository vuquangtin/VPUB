using CommonControls;
using CommonHelper.Constants;
using CommonHelper.Utils;
using JavaCommunication;
using Microsoft.Practices.CompositeUI;
using Newtonsoft.Json;
using sMeetingComponent.Constants;
using sMeetingComponent.Model;
using sNonResidentComponent.Factory;
using sNonResidentComponent.Model;
using sNonResidentComponent.Model.Old;
using sWorldModel;
using sWorldModel.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Resources;
using System.ServiceModel;
using System.Windows.Forms;


namespace sNonResidenComponent.WorkItems.ManageMeeting
{
    public partial class FrmUpdateMeeting : Form
    {
        #region Properties
        private long orgId = 0;
        private long meetingId = 0;
        private int rowUpdate = 0;
        bool clickTable = false;

        DateTime startTimeNew;
        DateTime endTimeNew;

        private DataTable dtbEventListPartaker;
        private EventMeeting AddOrUpdateEventMeeting;
        private EventMeeting OriginalEventMeeting { get; set; }
        public List<OrganizationMg> organizationList;
        public List<OrganizationMg> organizationListCbx;
        public List<Room> roomList;
        List<Partaker> partakerOtherList;
        List<Partaker> partakerOtherListCheck;
        private BackgroundWorker bgwUpdateEventMeeting;
        private BackgroundWorker bgwLoadOrganizationList;
        private BackgroundWorker bgwLoadRoomList;
        private BackgroundWorker bgwLoadMeetingList;

        public DialogPostAction PostAction { get; private set; }
        private ResourceManager rm;
        private NonResidentComponentWorkItem workItem;
        [ServiceDependency]
        public NonResidentComponentWorkItem WorkItem
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
        public FrmUpdateMeeting(long meetingId)
        {
            this.meetingId = meetingId;
            InitializeComponent();
            InitDataTableEventListPartakers();

            CustomTypeDate();
            RegisterEvent();
            partakerOtherList = new List<Partaker>();
            partakerOtherListCheck = new List<Partaker>();
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
        /// RegisterEvent
        /// đăng ký sự kiện
        /// </summary>
        private void RegisterEvent()
        {
            CreateBackgroundWorkerEvent();
            btnUpdateInfo.Click += OnButtonPutInClicked;
            btnCancel.Click += OnButtonCancelClicked;
            dgvListAttend.CellClick += dgvListAttend_CellClick;
            // doi thanh nhan chuot
            //  dgvListAttend.CellMouseClick += ;
            //  dgvListAttend.CellClick += OnButtonDgvListAttendClicked;
            dgvListAttend.KeyDown += OnButtonDgvListAttendKeyPress;
            btnRefresh.Click += OnButtonRefreshClicked;
            btnAddAttend.Click += OnButtonbtnAddAttendClicked;
            btnUpdatePartaker.Click += OnButtonUpdatePartakerCliced;

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

            LoadOrganizationList();
            LoadRoomList();
            LoadMeetingList();
            this.KeyPreview = true;
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
            bgwLoadMeetingList = new BackgroundWorker();
            bgwLoadMeetingList.WorkerSupportsCancellation = true;
            bgwLoadMeetingList.DoWork += OnLoadMeetingWorkerDoWork;
            bgwLoadMeetingList.RunWorkerCompleted += OnLoadMeetingWorkerCompleted;

            //16:UPDATE Cập nhật thông tin cuộc họp
            bgwUpdateEventMeeting = new BackgroundWorker();
            bgwUpdateEventMeeting.WorkerSupportsCancellation = true;
            bgwUpdateEventMeeting.DoWork += LoadUpdateEventMeetingWorkerDoWork;
            bgwUpdateEventMeeting.RunWorkerCompleted += LoadUpdateEventMeetingRunWorkerCompleted;

            bgwLoadOrganizationList = new BackgroundWorker();
            bgwLoadOrganizationList.WorkerSupportsCancellation = true;
            bgwLoadOrganizationList.DoWork += LoadOrganizationListWorkerDoWork;
            bgwLoadOrganizationList.RunWorkerCompleted += LoadOrganizationListRunWorkerCompleted;

            bgwLoadRoomList = new BackgroundWorker();
            bgwLoadRoomList.WorkerSupportsCancellation = true;
            bgwLoadRoomList.DoWork += LoadRoomListWorkerDoWork;
            bgwLoadRoomList.RunWorkerCompleted += LoadRoomListRunWorkerCompleted;
        }
        /// <summary>
        /// LoadOrganizationList
        /// </summary>
        private void LoadOrganizationList()
        {
            if (!bgwLoadOrganizationList.IsBusy)
            {
                bgwLoadOrganizationList.RunWorkerAsync();
            }
        }
        /// <summary>
        /// LoadRoomList
        /// </summary>
        private void LoadRoomList()
        {
            if (!bgwLoadRoomList.IsBusy)
            {
                bgwLoadRoomList.RunWorkerAsync();
            }
        }
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

        #region Gửi yêu cầu lấy thông tin cuộc hop
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
        /// Loadl Info EventMeeting
        /// </summary>
        /// <param name="eventMeetingItem"></param>
        private void LoadlInfoEventMeeting(EventMeeting eventMeetingItem)
        {
            List<Partaker> jsonListPartaker = new List<Partaker>();
            //cbxOrganization.SelectedIndex = (int)eventMeetingItem.organizationMeetingId;
            this.cbxOrganization.Text = eventMeetingItem.organizationMeetingName;
            this.tbxNameMeeting.Text = eventMeetingItem.name;
            // cbxNameRoom.SelectedIndex = (int)eventMeetingItem.roomId;
            this.cbxNameRoom.Text = eventMeetingItem.roomName;
            this.txtNote.Text = eventMeetingItem.note;

            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            DateTime startDate = start.AddMilliseconds(Convert.ToUInt64(eventMeetingItem.startTime)).ToLocalTime();
            DateTime endDate = start.AddMilliseconds(Convert.ToUInt64(eventMeetingItem.endTime)).ToLocalTime();
            this.dtpDay.Value = startDate;
            this.dtpStartTime.Text = startDate.ToString("hh:mm tt");
            this.dtpEndTime.Text = endDate.ToString("hh:mm tt");

            if (null != eventMeetingItem.listNonResident)
                jsonListPartaker = JsonConvert.DeserializeObject<List<Partaker>>(eventMeetingItem.listNonResident);

            if (jsonListPartaker.Count > 0)
            {
                partakerOtherList.AddRange(jsonListPartaker);
                loadPartakersToTable(jsonListPartaker);
            }
        }
        #endregion

        #region Gửi yêu cầu load danh sách đươn vị tổ chức cuộc hop
        /// <summary>
        /// LoadOrganizationListWorkerDoWork
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadOrganizationListWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = organizationList = OrganizationMgFactory.Instance.GetChannel().getOrganization(storageService.CurrentSessionId);
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
        /// LoadOrganizationListRunWorkerCompleted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadOrganizationListRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "SmsNotConnectData"));
                this.Close();
                return;
            }
            if (e.Result == null)
            {
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "smsNotFilter"));

                this.Close();
                return;
            }
            else
            {
                List<OrganizationMg> result = (List<OrganizationMg>)e.Result;

                //OrganizationMg organizationMeetingItem = new OrganizationMg();
                //organizationMeetingItem.name = "-Tất cả-";
                //organizationMeetingItem.id = -1;
                //OrganizationMg organizationMeetingItemOther = new OrganizationMg();
                //organizationMeetingItemOther.name = "-Khác-";
                //organizationMeetingItemOther.id = 0;
                organizationListCbx = new List<OrganizationMg>();
                //organizationListCbx.Add(organizationMeetingItemOther);//khác
                //organizationListCbx.Add(organizationMeetingItem);//tất cả
                if (result.Count != 0)
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        if (result[i].typeOrg == OrgEnum.ORG_SUB_ORG || result[i].typeOrg == OrgEnum.ORG_ORG)
                        {
                            organizationListCbx.Add(result[i]);
                        }
                    }
                    AutoComplete(organizationListCbx);
                    cbxOrganization.Enabled = true;
                    cbxOrganization.DataSource = organizationListCbx.ToList();
                    cbxOrganization.ValueMember = "id";
                    cbxOrganization.DisplayMember = "name";//hiển thị
                    cbxOrganization.SelectedIndex = 0;
                    return;
                }
                else
                {
                    MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "smsNotFilter"));
                    this.Close();
                    return;
                }
            }
        }

        /// <summary>
        /// gán danh sách tên khách vãng lai cho ô tìm kiếm theo tên
        /// </summary>
        /// <param name="nonResidentList"></param>
        public void AutoComplete(List<OrganizationMg> organizationlist)
        {
            txtOrg.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtOrg.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
            for (int i = 0; i < organizationlist.Count; i++)
            {
                coll.Add(organizationlist[i].name);
            }
            txtOrg.AutoCompleteCustomSource = coll;
        }
        #endregion

        #region Gửi yêu cầu load danh sách phòng hop
        /// <summary>
        /// LoadRoomListWorkerDoWork
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadRoomListWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = roomList = RoomFactory.Instance.GetChannel().getListRoom(storageService.CurrentSessionId);
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
        /// LoadRoomListRunWorkerCompleted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadRoomListRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "SmsNotConnectData"));
                this.Close();
                return;
            }
            if (e.Result == null)
            {
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "smsNotFilter"));
                this.Close();
                return;
            }
            else
            {
                //20170305 #Bug Fix- My Nguyen Start
                List<Room> result = (List<Room>)e.Result;
                if (result.Count != 0)
                {
                    // roomListCbx.AddRange(roomList);
                    cbxNameRoom.DataSource = result.ToList();
                    cbxNameRoom.ValueMember = "id";
                    cbxNameRoom.DisplayMember = "name";
                    cbxNameRoom.SelectedIndex = 0;
                    return;
                }
                //20170305 #Bug Fix- My Nguyen Start


                else
                {
                    MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "smsNotFilter"));
                    this.Close();
                    return;
                }
            }
        }
        #endregion

        #region Gửi yêu cầu cập nhật thông tin cuộc họp
        /// <summary>
        /// LoadUpdateEventMeetingWorkerDoWork
        /// upload info meeting
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
                partakerOtherListCheck = new List<Partaker>();
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "smsErrorUpdateMeeting"));
                return;
            }

            if ((bool)e.Result)
            {
                partakerOtherListCheck = new List<Partaker>();
                ClearEmptyControl();
                //  MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "smsSuccessUpdateMeeting"));
                PostAction = DialogPostAction.SUCCESS;
                this.Close();
            }
            else
            {
                partakerOtherListCheck = new List<Partaker>();
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "smsErrorUpdateMeeting"));
                return;
            }
        }
        #endregion

        #endregion

        #region Event's support (ToEntity)
        /// <summary>
        /// ToEntity
        /// tao doi tuong event luu xuong 
        /// </summary>
        /// <returns></returns>
        private EventMeeting ToEntity()
        {
            EventMeeting eventMeeting = new EventMeeting();
            //310317
            eventMeeting = OriginalEventMeeting;
            //end 310317

            eventMeeting.id = OriginalEventMeeting.id;
            eventMeeting.name = tbxNameMeeting.Text;
            eventMeeting.note = txtNote.Text;

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
            //org
            try
            {
                OrganizationMg organizationItem = (OrganizationMg)cbxOrganization.SelectedItem;
                eventMeeting.organizationMeetingId = organizationItem.id;
                eventMeeting.organizationMeetingName = organizationItem.name;
            }
            catch (Exception ex)
            {
            }

            //room
            try
            {
                Room roomItem = (Room)cbxNameRoom.SelectedItem;
                eventMeeting.roomId = (int)roomItem.id;
                eventMeeting.roomName = roomItem.name;
            }
            catch (Exception ex)
            {
                //eventMeeting.roomId = 0;
                //eventMeeting.roomName = "Khác";
            }

            //cách xử lí json 1
            //danh sách người tham dự được thêm vào sau chuyển về json để lưu xuống database
            string jsonPartaker = JsonConvert.SerializeObject(partakerOtherListCheck);
            eventMeeting.listNonResident = jsonPartaker;

            //310317
            //eventMeeting.nonresident = true;
            //end 310317

            // eventMeeting.number = partakerOtherListCheck.Count;//côt này là số lượng đơn vị tổ chức được mời chứ không phải số người được mời
            return eventMeeting;
        }
        #endregion

        #region ValidateData
        /// <summary>
        /// ValidateData
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
        /// ValidateDate
        /// kiểm tra ngày
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

        /// <summary>
        /// ValidateDataPartaker
        /// kiểm tra dữ liệu nhập vào form
        /// </summary>
        /// <returns></returns>
        private bool ValidateDataPartaker()
        {
            if (string.IsNullOrEmpty(txtOrg.Text))
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessageValidate(rm, "smsNameOrg"), MessageValidate.GetErrorTitle(rm));
                return false;
            }
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessageValidate(rm, "smsNameAttend"), MessageValidate.GetErrorTitle(rm));
                return false;
            }
            if (string.IsNullOrEmpty(txtPositionAttend.Text))
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessageValidate(rm, "smsPosition"), MessageValidate.GetErrorTitle(rm));
                return false;
            }

            return true;
        }
        #endregion

        #region Button Event's 
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
                partaker.name = txtName.Text;
                partaker.position = txtPositionAttend.Text;
                partaker.orgname = txtOrg.Text;
                partakerOtherList.Add(partaker);
                loadPartakersToTable(partakerOtherList);
                ClearEmptyControl();
            }
        }

        /// <summary>
        /// click btn  update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButtonUpdatePartakerCliced(object sender, EventArgs e)
        {
            if (ValidateDataPartaker() && clickTable == true)//&& MessageBoxManager.ShowQuestionMessageBox(this, MessageValidate.GetMessage(rm, "smsQuestionYesNoPersonalAttendMeeting")) == System.Windows.Forms.DialogResult.Yes)
            {
                partakerOtherList[rowUpdate].name = txtName.Text;
                partakerOtherList[rowUpdate].position = txtPositionAttend.Text;
                partakerOtherList[rowUpdate].orgname = txtOrg.Text;
                loadPartakersToTable(partakerOtherList);
                ClearEmptyControl();
            }
        }

        /// <summary>
        /// show list partakers
        /// </summary>
        private void loadPartakersToTable(List<Partaker> listPartakerNew)
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

        //20170305 #Bug Fix- My Nguyen Start
        //luôn luôn bắt sự kiện Enter nút cho vào
        //protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        //{
        //    if (msg.WParam.ToInt32() == (int)Keys.Enter)
        //    {
        //        PutIn();
        //    }
        //    else
        //    {
        //        return base.ProcessCmdKey(ref msg, keyData);
        //    }
        //    return false;
        //}
        //20170305 #Bug Fix- My Nguyen End

        /// <summary>
        /// click btn add
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
        /// register key f10, key escape
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
        /// <summary>
        /// click dgv
        /// hiển thị thông tin của cuộc họp khi click vào 1 dòng trong table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvListAttend_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int rowIndex = e.RowIndex;
            if (rowIndex != -1)
            {
                int colCheckIndex = dgvListAttend.Columns[colCheck.Name].Index;
                //4
                if (e.ColumnIndex == colCheckIndex)
                {
                    clickTable = false;
                    //bool check = Convert.ToBoolean(dgvListAttend.Rows[e.RowIndex].Cells[5].Value);
                    //dgvListAttend.Rows[e.RowIndex].Cells[5].Value = !check;
                }
                else
                {
                    rowUpdate = rowIndex;
                    clickTable = true;
                    DataGridViewRow row = dgvListAttend.Rows[rowIndex];
                    txtName.Text = dgvListAttend.Rows[e.RowIndex].Cells[colNamePartaker.Name].Value.ToString();
                    txtOrg.Text = dgvListAttend.Rows[e.RowIndex].Cells[colNameOrg.Name].Value.ToString();
                    txtPositionAttend.Text = dgvListAttend.Rows[e.RowIndex].Cells[colPositionPartaker.Name].Value.ToString();
                    this.btnUpdatePartaker.Enabled = true;
                }
            }
        }

        /// <summary>
        /// key press dgv
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButtonDgvListAttendKeyPress(object sender, KeyEventArgs e)
        {
            var selectedRows = dgvListAttend.SelectedRows;
            int rowsCount = selectedRows.Count;
            //so dong duoc chon
            if (rowsCount == 0)
            {
            }
            else
            {
                int rowindex = dgvListAttend.CurrentRow.Index;
                if (e.KeyCode == Keys.Space)
                {
                    bool check = Convert.ToBoolean(selectedRows[0].Cells[colCheck.Name].Value);
                    dgvListAttend.Rows[rowindex].Cells[4].Value = !check;
                    ClearEmptyControl();
                }
            }
        }

        /// <summary>
        /// mouse click dgv
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvListAttend_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex != -1)
            {
                int colCheckIndex = dgvListAttend.Columns[colCheck.Name].Index;
                //4
                if (e.ColumnIndex == colCheckIndex)
                {
                    clickTable = false;
                    bool check = Convert.ToBoolean(dgvListAttend.Rows[e.RowIndex].Cells[4].Value);
                    dgvListAttend.Rows[e.RowIndex].Cells[4].Value = !check;
                    ClearEmptyControl();
                }
            }

        }
        private void OnButtonCancelClicked(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OnButtonRefresh2Clicked(object sender, EventArgs e)
        {
            ClearEmptyControl2();
        }

        private void OnButtonRefreshClicked(object sender, EventArgs e)
        {
            ClearEmptyControl();
        }

        /// <summary>
        /// ClearEmptyControl
        /// </summary>
        private void ClearEmptyControl()
        {
            txtName.Text = string.Empty;
            txtOrg.Text = "";
            txtPositionAttend.Text = string.Empty;
            this.btnAddAttend.Enabled = true;
            this.btnUpdatePartaker.Enabled = false;
            clickTable = false;

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


