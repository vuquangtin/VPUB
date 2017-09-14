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
using System.Resources;
using System.ServiceModel;
using System.Windows.Forms;
using sMeetingComponent.Constants;
using System.Globalization;
using sMeetingComponent.Model.CustomObj.ContactForWorkObj;
using sMeetingComponent.Model.CustomObj.InfoJournalistObj;

namespace sMeetingComponent.WorkItems
{
    public partial class FrmDetailBySerialNumberInfo : Form
    {

        #region Properties
        public string sysFormatDate;

        public const byte ModeCardChip = 1;
        private byte OperatingMode;
        private String cardChip { get; set; }
        private bool isHaveJournalist { get; set; }
        //private bool checkAttendMeeeting = false;

        private bool CheckContact = false;
        private const string ORG_NAME_WORK_CONTACT = "-";
        private const string DATE_WORK_CONTACT = "-";
        private const string TIME_WORK_CONTACT = "-";

        // User control này không thuộc nhóm overlay do khi nó hiện ra
        private UsrNotification usrNotification = null;
        private ConfigTime configTime;
        private System.Windows.Forms.Timer timer = null;
        private int time = 0;
        private int previousMinutes = 0;

        private DataTable dtbMeetingList;
        //private DataTable dtbEventListPartaker;
        private DataTable dtbOrgList;

        //private Member journalist;

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

        //luu thông tin liên hệ công tác
        private BackgroundWorker bgwAddContactForWork;
        private SmeetingContactStatistic AddOrUpdateSmeetingContactStatistic;

        //lấy thông tin đơn vị
        private BackgroundWorker bgwLoadOrganizationList;
        public List<OrganizationMeeting> organizationList;

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
        /// <summary>
        /// FrmDetailBySerialNumberInfo
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="cardChip"></param>
        /// <param name="isHaveJournalist"></param>
        public FrmDetailBySerialNumberInfo(byte mode, String cardChip, bool isHaveJournalist)
        {
            InitializeComponent();
            InitDataTableMeetingList();
            //  sysFormatDate = UsrListMeeting.formatDateTime();
            sysFormatDate = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;

            // CustomTypeDate();
            RegisterEvent();
            this.OperatingMode = mode;
            this.cardChip = cardChip;

            this.isHaveJournalist = isHaveJournalist;

            meetingObjListAll = new List<EventMeeting>();

            #region usrNotification
            configTime = new ConfigTime();
            time = configTime.SetTime();

            usrNotification = new UsrNotification();
            usrNotification.Anchor = AnchorStyles.None;
            usrNotification.Visible = false;
            panel2Meeting.Controls.Add(usrNotification);
            usrNotification.Location = new Point(
                panel2Meeting.ClientSize.Width / 2 - usrNotification.Width / 2,
                panel2Meeting.ClientSize.Height / 2 - usrNotification.Height / 2);
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

        /// <summary>
        /// InitDataTableMeetingList
        /// </summary>
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

            //dtbEventListPartaker = new DataTable();
            //dtbEventListPartaker.Columns.Add(colSTT.DataPropertyName);
            //dtbEventListPartaker.Columns.Add(colNamePartaker.DataPropertyName);
            //dtbEventListPartaker.Columns.Add(colNameOrg.DataPropertyName);
            //dtbEventListPartaker.Columns.Add(colPositionPartaker.DataPropertyName);
            //dtbEventListPartaker.Columns.Add(colCheck.DataPropertyName);
            //dgvListAttend.DataSource = dtbEventListPartaker;

            dtbOrgList = new DataTable();
            dtbOrgList.Columns.Add(colOrgNo.DataPropertyName);
            dtbOrgList.Columns.Add(colOrgId.DataPropertyName);
            dtbOrgList.Columns.Add(colOrgName.DataPropertyName);
            dtbOrgList.Columns.Add(colCheckOrg.DataPropertyName);

            dgvOrgList.DataSource = dtbOrgList;
        }

        /// <summary>
        /// đăng ký sự kiện
        /// RegisterEvent
        /// </summary>
        private void RegisterEvent()
        {
            CreateBackgroundWorkerEvent();
            btnConfirm.Click += OnButtonPutInClicked;
            btnCancel.Click += OnButtonExitClicked;
            //dgvListMeetingToday.CellClick += dgvListMeetingToday_CellClick;
            dgvListMeetingToday.CellMouseClick += dgvListMeetingToday_CellMouseClick;
            dgvListMeetingToday.KeyDown += OnButtondgvListMeetingTodayKeyPress;

            //don vi lien he
            dgvOrgList.KeyDown += dgvOrgList_KeyDown;
            dgvOrgList.CellMouseClick += dgvOrgList_CellMouseClick;

            Load += OnFormLoad;
        }

        /// <summary>
        /// OnFormLoad
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            // LoadOrganizationList();

            //để dùng phím tắt lên xuống
            this.KeyPreview = true;
            this.dgvListMeetingToday.Select();
            this.dgvListMeetingToday.Focus();

            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);

            if (isHaveJournalist)//FrmDetailBySerialNumberInfoOfJournalist
                this.Text = MessageValidate.GetMessage(rm, "FrmDetailBySerialNumberInfoOfJournalist");
            else
                this.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.Name);

            //cho focus vao nut huy
            // btnCancel.Select();

            SetLanguages();
        }

        /// <summary>
        /// SetLanguages
        /// </summary>
        private void SetLanguages()
        {
            this.colSttnew.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colSttnew.Name);
            this.colMeetingId.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colMeetingId.Name);
            this.colMeetingName.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colMeetingName.Name);
            this.colOrganizationMeeting.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colOrganizationMeeting.Name);
            this.colCheck.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colCheck.Name);
            this.colDateTime.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colDateTime.Name);
            this.colStartTime.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colStartTime.Name);
            this.colEndTime.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colEndTime.Name);

            //this.colSTT.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colSTT.Name);
            //this.colNamePartaker.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colNamePartaker.Name);
            //this.colPositionPartaker.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colPositionPartaker.Name);
            //this.colCheck.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colCheck.Name);
            //this.colNameOrg.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colNameOrg.Name);

            this.colOrgNo.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colOrgNo.Name);
            this.colOrgId.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colOrgId.Name);
            this.colOrgName.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colOrgName.Name);
            this.colCheckOrg.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colCheckOrg.Name);
        }

        #region bgWorker
        /// <summary>
        /// CreateBackgroundWorkerEvent
        /// </summary>
        private void CreateBackgroundWorkerEvent()
        {
            //6: lấy thông tin đơn vị
            bgwLoadOrganizationList = new BackgroundWorker();
            bgwLoadOrganizationList.WorkerSupportsCancellation = true;
            bgwLoadOrganizationList.DoWork += LoadOrganizationListWorkerDoWork;
            bgwLoadOrganizationList.RunWorkerCompleted += LoadOrganizationListRunWorkerCompleted;

            //7: lấy thông tin các cuộc họp hôm nay, các cuộc họp nhà báo được vào
            loadListMeetingJournalistObj = new BackgroundWorker();
            loadListMeetingJournalistObj.WorkerSupportsCancellation = true;
            loadListMeetingJournalistObj.DoWork += OnLoadListMeetingJournalistObjWorkerDoWork;
            loadListMeetingJournalistObj.RunWorkerCompleted += OnLoadListMeetingJournalistObjWorkerCompleted;

            //8: Thêm danh sách các cuộc họp người đó tham dự
            bgwAddAttendMeetingJournalist = new BackgroundWorker();
            bgwAddAttendMeetingJournalist.WorkerSupportsCancellation = true;
            bgwAddAttendMeetingJournalist.DoWork += OnLoadAddAttendMeetingJournalistWorkerDoWork;
            bgwAddAttendMeetingJournalist.RunWorkerCompleted += OnLoadAddAttendMeetingJournalistRunWorkerCompleted;

            //9: Lưu thông tin liên hệ công tác
            bgwAddContactForWork = new BackgroundWorker();
            bgwAddContactForWork.WorkerSupportsCancellation = true;
            bgwAddContactForWork.DoWork += OnLoadAddAddContactForWorkWorkerDoWork;
            bgwAddContactForWork.RunWorkerCompleted += OnLoadAddAddContactForWorkRunWorkerCompleted;
        }

        #region Lấy thông tin đơn vị tổ chức liên hệ
        /// <summary>
        /// LoadOrganizationList
        /// </summary>
        private void LoadOrganizationList()
        {
            if (!bgwLoadOrganizationList.IsBusy)
            {
                dtbOrgList.Rows.Clear();
                bgwLoadOrganizationList.RunWorkerAsync();
            }
        }

        /// <summary>
        /// LoadOrganizationListWorkerDoWork
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadOrganizationListWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = organizationList = OrganizationMeetingFactory.Instance.GetChannel().getOrganization_ASC(storageService.CurrentSessionId);
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
            //phai kiem tra truong hop khong load dx don vi
            if (e.Cancelled)
            {
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "SmsNotConnectData"));
                return;
            }
            //if (e.Result == null)
            //{
            //   // MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "smsNotFilter"));
            //    return;
            //}
            else
            {
                //QUAN TRỌNG *
                //đơn vị tổ chức lúc nào cũng hiển thị dòng tất cả
                //nên không kiểm tra null

                OrganizationMeeting organizationMeetingItem = new OrganizationMeeting();
                string All = MessageValidate.GetMessage(rm, "All");
                organizationMeetingItem.name = All;
                organizationMeetingItem.id = -1;

                List<OrganizationMeeting> result = (List<OrganizationMeeting>)e.Result;
                List<OrganizationMeeting> listOrg = new List<OrganizationMeeting>();
                if (result.Count != 0)
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        if (result[i].typeOrg == OrgEnum.ORG_SUB_ORG || result[i].typeOrg == OrgEnum.ORG_ORG)//những đơn vị đến liên hệ công tác là = 1
                        {
                            listOrg.Add(result[i]);
                        }
                    }
                }
                if (listOrg.Count > 0)
                {
                    LoadOrganizationListData(listOrg);
                }
            }
        }

        /// <summary>
        /// hiển thị thông tin đơn vị tổ chức liên hệ
        /// GET LIST ORG 
        /// </summary>
        /// <param name="listShow"></param>
        public void LoadOrganizationListData(List<OrganizationMeeting> listShow)
        {

            dtbOrgList.Clear();
            int index = 0;
            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            //hiển thị danh sách meetingObjList có check trước
            if (listShow.Count > 0)
            {
                for (int i = 0; i < listShow.Count; i++)
                {
                    DataRow row = dtbOrgList.NewRow();
                    row.BeginEdit();
                    index = i + 1;
                    row[colOrgNo.DataPropertyName] = index;
                    row[colOrgId.DataPropertyName] = listShow[i].id;
                    row[colOrgName.DataPropertyName] = listShow[i].name;
                    row[colCheckOrg.DataPropertyName] = false;
                    row.EndEdit();
                    dtbOrgList.Rows.Add(row);
                }
            }

            if (dgvOrgList.Rows.Count > 0)
            {
                //focur the first row in table
                dgvOrgList.Rows[0].Selected = true;
                // dgvOrgList.ClearSelection();//htmynguyen 310317 bỏ đi
            }
            // else { Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Failed, MessageValidate.GetMessage(rm, "SmsNotInforMeeting")))); }

        }
        #endregion

        #region Gửi yêu cầu lấy thông tin liên quan đến cardchip / serialnumber : để lấy thông của người dùng , thông tin cuộc họp được mời, cuộc họp trong ngày hôm nay
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
                e.Result = listMeetingJournalistObj = JournalistFactory.Instance.GetChannel().getListMeetingJournalistObjByCardChip(storageService.CurrentSessionId, cardChip, dateStr);
                //e.Result = listMeetingJournalistObj = JournalistFactory.Instance.GetChannel().getListMeetingJournalistObjByCardChip(storageService.CurrentSessionId, cardChip, dateStr, previousMinutes);
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
                    
                    //org id = 0 thì không view orgname

                    //if (result.orgId != 0)
                    //{
                        journalist.OrgId = result.orgId;
                    //}

                    if (result.orgName != null)
                    {
                        journalist.OrgName = result.orgName;
                    }
                    else
                    {
                        journalist.OrgName = "";
                    }

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
                        //// #240327 lấy danh sách cuoc hop nha báo được tham dự
                        //if(isHaveJournalist)
                        //meetingObjList = GetListHaveJournalist(result.meetingInviteds);
                        //else

                        meetingObjList = result.meetingInviteds;
                    }
                    else
                    {
                        meetingObjList = new List<EventMeeting>();
                    }

                    if (result.meetingNotInviteds != null)
                    {
                        //// #240327 lấy danh sách cuoc hop nha báo được tham dự
                        if (isHaveJournalist)
                        {

                            meetingNotInvitedsList = UsrListMeeting.GetListNotNonresident(result.meetingNotInviteds);

                            #region để sử dụng khi có biết được cuộc họp nào nhà báo được tham dự
                            //meetingNotInvitedsList = UsrJournalistAttendMeeting.GetListHaveJournalist(result.meetingNotInviteds);
                            #endregion

                        }
                        else
                            meetingNotInvitedsList = UsrListMeeting.GetListNotNonresident(result.meetingNotInviteds);
                        //end

                        ////290317 bỏ đi những cuộc họp nội bộ
                        ////lấy các cuộc họp không có cuộc họp nội bộ
                        //List<EventMeeting> tempListMeeting = new List<EventMeeting>();
                        //tempListMeeting = UsrListMeeting.GetListNotNonresident(result.meetingNotInviteds);
                        //if (tempListMeeting.Count > 0)
                        //    meetingNotInvitedsList = tempListMeeting;
                        //else
                        //    meetingNotInvitedsList = new List<EventMeeting>();
                        ////end

                        // meetingNotInvitedsList = result.meetingNotInviteds;
                    }
                    else
                    {
                        meetingNotInvitedsList = new List<EventMeeting>();
                    }

                    if (meetingObjList.Count == 0 && meetingNotInvitedsList.Count == 0)
                    {
                        // #240317 trường họp không có thông tin cuoc hop nao
                        //nếu không có cuộc họp nào thì có thể đến để liên hệ 
                        LoadMeetingObjContact();
                        if (dgvListMeetingToday.Rows.Count > 0)
                        {
                            //focur the first row in table
                            dgvListMeetingToday.Rows[0].Selected = true;
                        }
                        else { Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Failed, MessageValidate.GetMessage(rm, "SmsNotInforMeeting")))); }
                        //end #240317 trường họp không có thông tin cuoc hop nao

                        //Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Failed, MessageValidate.GetMessage(rm, "smsNotInforTodayMeetingCard"))));
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

        //private List<EventMeeting> GetListHaveJournalist(List<EventMeeting> listMeetingAll)
        //{
        //    List<EventMeeting> listMeetingHaveJournalist = new List<EventMeeting>();
        //    for (int i = 0; i < listMeetingAll.Count; i++)
        //    {
        //        if (listMeetingAll[i].journalist)
        //        {
        //            listMeetingHaveJournalist.Add(listMeetingAll[i]);
        //        }
        //    }
        //    return listMeetingHaveJournalist;
        //}

        #endregion

        #region Lưu thông tin liên hệ công tác
        /// <summary>
        /// AddContactForWork
        /// </summary>
        public void AddContactForWork()
        {

            if (!bgwAddContactForWork.IsBusy)
            {
                AddOrUpdateSmeetingContactStatistic = ToEntityContact(true);
                bgwAddContactForWork.RunWorkerAsync();
            }
        }

        /// <summary>
        /// OnLoadAddAddContactForWorkRunWorkerCompleted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoadAddAddContactForWorkRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            bool checkUpdate = (bool)e.Result;
            if (checkUpdate)
            {
                // Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Succeed, MessageValidate.GetMessage(rm, "SmsSuccessMeetingCard"))));
                PostAction = DialogPostAction.SUCCESS;

                if (isHaveJournalist)
                    UsrJournalistAttendMeeting.SetIndexStatus(1);
                else
                    UsrJournalistAttendMeeting.SetIndexStatus(1);

                this.Close();
            }
            else
            {
                Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Failed, MessageValidate.GetMessage(rm, "smsErrorInsertMeetingCard"))));
                return;
            }
        }

        /// <summary>
        /// OnLoadAddAddContactForWorkWorkerDoWork
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoadAddAddContactForWorkWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = (int)Status.SUCCESS == ContactForWorkFactory.Instance.GetChannel().insertContactForWork(storageService.CurrentSessionId, AddOrUpdateSmeetingContactStatistic);
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

        #region Lưu thông tin người tham dự cuộc họp vào database
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

                if (isHaveJournalist)
                    UsrJournalistAttendMeeting.SetIndexStatus(1);
                else
                    UsrListMeeting.SetIndexStatus(1);

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

        #endregion

        #region Hiển thị thông tin của thẻ : thông tin người dùng, thông tin cuộc họp
        /// <summary>
        /// hiển thị thông tin nhà báo
        /// Show info card of journalist
        /// </summary>
        /// <param name="journalist"></param>
        private void LoadJournalist(Journalist journalist)
        {
            if (journalist.BirthDate != null && journalist.BirthDate != "")
            {
                DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

                //không hiển thị ngày sinh của báo chí, do bảng dữ liệu member kiểu String
                try
                {
                    //DÙNG SWORLD
                    DateTime startDate = journalist.BirthDate.ToDateFormatString();
                    journalist.BirthDate = startDate.ToString("dd-MM-yyyy 00:00");
                }
                catch (Exception x)
                {
                    journalist.BirthDate = start.ToString("dd-MM-yyyy 00:00");
                }
                //end

                // DateTime startDate = start.AddMilliseconds(Convert.ToUInt64(journalist.BirthDate)).ToLocalTime();
                // journalist.BirthDate = startDate.ToString("dd-MM-yyyy 00:00");
                //this.dtpBirthDate.Value = startDate;

            }
            this.txtOrg.Text = journalist.OrgName;
            this.txtLowerFullName.Text = journalist.LastName + " " + journalist.FirstName;

            this.txtPosition.Text = journalist.Position;

            if (this.txtPosition.Text.Equals(""))
            {
                this.txtPosition.Text = Enums.JOURNALIST;
            }

            // this.txtEmail.Text = journalist.Email;
            this.txtPhoneNo.Text = journalist.PhoneNo;
            this.txtIdentityCard.Text = journalist.IdentityCard;
            //  this.txtNote.Text = "Đăng ký tham dự họp";
            //this.txtNote.Text = "";

            //  SetControl(false);
        }
        /// <summary>
        /// đến để liên hê
        /// ADD ROW CONTACT
        /// </summary>
        private void LoadMeetingObjContact()
        {
            //xóa bảng trước khi init
            dtbMeetingList.Clear();
            int index = 0;

            #region  cach 2 thêm 1 dòng dữ liệu "LIÊN HỆ CONG TÁC"
            DataRow rowOther = dtbMeetingList.NewRow();
            rowOther.BeginEdit();
            index++;
            // Add một dòng mới vào DataTable
            EventMeeting contactOrg = new EventMeeting();
            contactOrg.id = -1;
            contactOrg.name = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, "workContact");
            //thoi gian cho vao
            DateTime dateStartNow = DateTime.Now;
            String startDateNew = dateStartNow.ToString("yyyy-MM-dd HH:mm");
            contactOrg.startTime = startDateNew;
            contactOrg.endTime = startDateNew;

            rowOther[colMeetingId.DataPropertyName] = -1;
            rowOther[colSttnew.DataPropertyName] = index;
            rowOther[colOrganizationMeeting.DataPropertyName] = ORG_NAME_WORK_CONTACT;
            //rowOther[colOrg.DataPropertyName] = -1;
            rowOther[colMeetingName.DataPropertyName] = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, "workContact");
            //rowOther[colMeetingDate.DataPropertyName] = DATE_WORK_CONTACT;
            //rowOther[colTimeStart.DataPropertyName] = TIME_WORK_CONTACT;

            rowOther[colStartTime.DataPropertyName] = dateStartNow.ToString("HH:mm");
            //string sysFormatDate = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
            rowOther[colDateTime.DataPropertyName] = dateStartNow.ToString(sysFormatDate);
            rowOther[colCheck.DataPropertyName] = false;
            rowOther.EndEdit();
            dtbMeetingList.Rows.Add(rowOther);
            #endregion

        }

        /// <summary>
        /// SHow info meeting 
        /// hiển thị danh sách các cuộc họp lên
        /// nếu meetingObjList thì có dấu check trước (cuộc họp nhà báo được mời trước)
        /// nếu meetingObjOthersShowList thì không có dấu check trước (các cuộc họp trong hôm nay mà không được mời trước)
        /// </summary>
        /// <param name="meetingObjList"></param>
        /// <param name="meetingObjOthersList"></param>
        private void LoadMeetingObjListdata(List<EventMeeting> listShow)
        {
            //xóa bảng trước khi init
            dtbMeetingList.Clear();
            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            int index = 0;

            //#region  cach 2 thêm 1 dòng dữ liệu "LIÊN HỆ COOGN TÁC"
            //DataRow rowOther = dtbMeetingList.NewRow();
            //rowOther.BeginEdit();
            //index++;
            //// Add một dòng mới vào DataTable
            //EventMeeting contactOrg = new EventMeeting();
            //contactOrg.id = -1;
            //contactOrg.name = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, "workContact");
            ////thoi gian cho vao
            //DateTime dateStartNow = DateTime.Now;
            //String startDateNew = dateStartNow.ToString("yyyy-MM-dd HH:mm");
            //contactOrg.startTime = startDateNew;
            //contactOrg.endTime = startDateNew;

            //rowOther[colMeetingId.DataPropertyName] = -1;
            //rowOther[colSttnew.DataPropertyName] = index;
            //rowOther[colOrganizationMeeting.DataPropertyName] = ORG_NAME_WORK_CONTACT;
            ////rowOther[colOrg.DataPropertyName] = -1;
            //rowOther[colMeetingName.DataPropertyName] = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, "workContact");
            ////rowOther[colMeetingDate.DataPropertyName] = DATE_WORK_CONTACT;
            ////rowOther[colTimeStart.DataPropertyName] = TIME_WORK_CONTACT;

            //rowOther[colStartTime.DataPropertyName] = dateStartNow.ToString("HH:mm");
            //string sysFormatDate = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
            //rowOther[colDateTime.DataPropertyName] = dateStartNow.ToString(sysFormatDate);
            //rowOther[colCheck.DataPropertyName] = false;
            //rowOther.EndEdit();
            //dtbMeetingList.Rows.Add(rowOther);
            //#endregion

            LoadMeetingObjContact();
            index++;


            //hiển thị danh sách meetingObjList có check trước
            if (listShow.Count > 0)
            {
                for (int i = 0; i < listShow.Count; i++)
                {
                    DataRow row = dtbMeetingList.NewRow();
                    row.BeginEdit();
                    //index =index+ i + 1;
                    index = index + 1;
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
                        //string sysFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
                        row[colDateTime.DataPropertyName] = startDate.ToString(sysFormatDate);
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

            if (dgvListMeetingToday.Rows.Count > 0)
            {
                //focur the first row in table
                dgvListMeetingToday.Rows[0].Selected = true;
            }
            else { Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Failed, MessageValidate.GetMessage(rm, "SmsNotInforMeeting")))); }
            // int count = meetingObjList.Count;
        }
        #endregion

        #region GetMeetingObjListCheck phân loại danh sách cuộc họp  nào được mời chính mà tham dự / cuộc họp nào diễn ra hôm nay mà tham dự
        /// <summary>
        /// get meeting checked
        ///  lấy danh sách cuộc họp có dấu check ở ô tham dự
        /// GetMeetingObjListCheck
        /// </summary>
        private void GetMeetingObjListCheck()
        {
            meetingObjListCheck = new List<EventMeeting>();
            meetingNotInvitedsListCheck = new List<EventMeeting>();
            //nếu liên hệ công tác thì không quan tâm cuộc họp tham dự là gì
            if (CheckContact) { }
            else
            {
                var selectedRows = dgvListMeetingToday.Rows;
                int rowsCount = selectedRows.Count;
                string checkPerso = string.Empty;
                if (rowsCount == 0)
                {
                    //  Console.WriteLine("Không có dữ liệu");
                }

                //bỏ dòng dữ liệu liên hệ công tác
                for (int i = 1; i < rowsCount; i++)
                {
                    //bỏ dòng dữ liệu liên hệ công tác
                    int positon = i - 1;//để lấy vị trí của cuộc họp trong meetingObjListAll, do có dòng liên hệ công tác nên bị lên 1 dòng

                    //lấy giá trị : nếu có check = true, không có check=false
                    bool check = Convert.ToBoolean(selectedRows[i].Cells[colCheck.Name].Value);
                    if (check)
                    {
                        if (i < meetingObjList.Count)
                        {
                            string startDay = dgvListMeetingToday.Rows[i].Cells[colDateTime.Name].Value.ToString();
                            //string sysFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
                            DateTime dt = DateTime.ParseExact(startDay, sysFormatDate, CultureInfo.InvariantCulture);
                            String startDayFormat = dt.ToString("dd-MM-yyyy");
                            string scolStartTime = dgvListMeetingToday.Rows[i].Cells[colStartTime.Name].Value.ToString();
                            string scolEndTime = dgvListMeetingToday.Rows[i].Cells[colEndTime.Name].Value.ToString();
                            // các cuộc họp  có trong danh sách được chọn
                            meetingObjListAll[positon].startTime = startDayFormat + " " + scolStartTime;
                            meetingObjListAll[positon].endTime = startDayFormat + " " + scolEndTime;
                            meetingObjListCheck.Add(meetingObjListAll[positon]);
                        }
                        else
                        {

                            string startDay = dgvListMeetingToday.Rows[i].Cells[colDateTime.Name].Value.ToString();
                            // string sysFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
                            DateTime dt = DateTime.ParseExact(startDay, sysFormatDate, CultureInfo.InvariantCulture);
                            String startDayFormat = dt.ToString("dd-MM-yyyy");
                            string scolStartTime = dgvListMeetingToday.Rows[i].Cells[colStartTime.Name].Value.ToString();
                            string scolEndTime = dgvListMeetingToday.Rows[i].Cells[colEndTime.Name].Value.ToString();
                            // các cuộc họp  có trong danh sách được chọn
                            meetingObjListAll[positon].startTime = startDayFormat + " " + scolStartTime;
                            meetingObjListAll[positon].endTime = startDayFormat + " " + scolEndTime;
                            meetingNotInvitedsListCheck.Add(meetingObjListAll[positon]);
                        }
                    }
                }
            }
        }
        #endregion

        #region Event's support
        /// <summary>
        /// tao doi tuong luu xuong 
        /// ToEntityContact
        /// </summary>
        /// <returns></returns>
        private SmeetingContactStatistic ToEntityContact(bool status)
        {
            SmeetingContactStatistic listMeetingJournalistObj = new SmeetingContactStatistic();
            listMeetingJournalistObj.note = tbxReason.Text.Trim();
            //thoi gian cho vao
            DateTime dateStart = DateTime.Now;
            String startDate = dateStart.ToString("yyyy-MM-dd HH:mm");
            listMeetingJournalistObj.inputTime = startDate;
            //dat ngay mat dinh, neu ve ma quen tag the thi lay ngay nay
            //muc dich thong ke
            DateTime dateEnd = new DateTime(1971, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            String endDate = dateEnd.ToString("yyyy-MM-dd HH:mm");
            listMeetingJournalistObj.outputTime = endDate;

            listMeetingJournalistObj.status = status;

            listMeetingJournalistObj.organizationAttendName = this.txtOrg.Text;
            listMeetingJournalistObj.partakerName = this.txtLowerFullName.Text;
            listMeetingJournalistObj.position = this.txtPosition.Text;
            listMeetingJournalistObj.phonenumber = this.txtPhoneNo.Text;
            listMeetingJournalistObj.identityCard = this.txtIdentityCard.Text;

            //v1
            //bat buoc tham du cuoc hop
            // listMeetingJournalistObj.meetingInviteds = meetingObjListCheck;
            //listMeetingJournalistObj.meetingNotInviteds = meetingNotInvitedsListCheck;

            //v2 có thể đến liên hệ tổ chức, ko phải đến họp
            //org
            try
            {
                if (CheckContact)
                //  if (dgvOrgList.Enabled == true)
                { // Khách vãng lại tới liên hệ công tác
                    //nonResident.orgId = Convert.ToInt64(dgvOrgList.Rows[dgvOrgList.CurrentRow.Index]
                    //    .Cells[colOrgId.Name].Value.ToString());
                    //nonResident.orgName = dgvOrgList.Rows[dgvOrgList.CurrentRow.Index]
                    //    .Cells[colOrgName.Name].Value.ToString();

                    List<EventMeeting> OrgCheckList = new List<EventMeeting>();
                    EventMeeting OrgCheck = new EventMeeting();
                    OrgCheck.organizationMeetingId = Convert.ToInt64(dgvOrgList.Rows[dgvOrgList.CurrentRow.Index]
                     .Cells[colOrgId.Name].Value.ToString());
                    OrgCheck.organizationMeetingName = dgvOrgList.Rows[dgvOrgList.CurrentRow.Index]
                    .Cells[colOrgName.Name].Value.ToString();
                    OrgCheckList.Add(OrgCheck);

                    //đơn vị đến liên hệ công tác
                    listMeetingJournalistObj.organizationMeetingId = OrgCheck.organizationMeetingId;
                    listMeetingJournalistObj.organizationMeetingName = OrgCheck.organizationMeetingName;
                    //nên có một trường thông tin cho biết đến liên hệ công tác là true
                }

            }
            catch (Exception e) { }

            return listMeetingJournalistObj;
        }
        /// <summary>
        /// tao doi tuong luu xuong 
        /// toentity
        /// </summary>
        /// <returns></returns>
        private MeetingInfoJournalistObj ToEntity(bool status)
        {
            MeetingInfoJournalistObj listMeetingJournalistObj = new MeetingInfoJournalistObj();
            AttendMeetingJournalist attendMeetingJournalist = new AttendMeetingJournalist();
            attendMeetingJournalist.serialNumber = cardChip;
            attendMeetingJournalist.note = tbxReason.Text.Trim();
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

            //280417 thêm dữ liệu orgID, OrgName của người tham dự
            listMeetingJournalistObj.orgId = journalist.OrgId;
            listMeetingJournalistObj.orgName = journalist.OrgName;
            //end 280417

            //v1
            //bat buoc tham du cuoc hop
            // listMeetingJournalistObj.meetingInviteds = meetingObjListCheck;
            //listMeetingJournalistObj.meetingNotInviteds = meetingNotInvitedsListCheck;

            //v2 có thể đến liên hệ tổ chức, ko phải đến họp
            //org
            try
            {
                if (CheckContact)
                //  if (dgvOrgList.Enabled == true)
                { // Khách vãng lại tới liên hệ công tác
                    //nonResident.orgId = Convert.ToInt64(dgvOrgList.Rows[dgvOrgList.CurrentRow.Index]
                    //    .Cells[colOrgId.Name].Value.ToString());
                    //nonResident.orgName = dgvOrgList.Rows[dgvOrgList.CurrentRow.Index]
                    //    .Cells[colOrgName.Name].Value.ToString();

                    listMeetingJournalistObj.meetingInviteds = meetingObjListCheck;

                    List<EventMeeting> OrgCheckList = new List<EventMeeting>();
                    EventMeeting OrgCheck = new EventMeeting();
                    OrgCheck.organizationMeetingId = Convert.ToInt64(dgvOrgList.Rows[dgvOrgList.CurrentRow.Index]
                     .Cells[colOrgId.Name].Value.ToString());
                    OrgCheck.organizationMeetingName = dgvOrgList.Rows[dgvOrgList.CurrentRow.Index]
                    .Cells[colOrgName.Name].Value.ToString();
                    OrgCheckList.Add(OrgCheck);
                    //đơn vị đến liên hệ công tác
                    listMeetingJournalistObj.meetingNotInviteds = OrgCheckList;
                    //nên có một trường thông tin cho biết đến liên hệ công tác là true
                }
                else
                {
                    // Khách vãng lai đi họp
                    //nonResident.orgId = Convert.ToInt64(dgvMeetingList.Rows[dgvOrgList.CurrentRow.Index]
                    //    .Cells[colOrganizationId.Name].Value.ToString());
                    //nonResident.orgName = dgvOrgList.Rows[dgvMeetingList.CurrentRow.Index]
                    //    .Cells[colOrg.Name].Value.ToString();

                    listMeetingJournalistObj.meetingInviteds = meetingObjListCheck;
                    listMeetingJournalistObj.meetingNotInviteds = meetingNotInvitedsListCheck;//v2: cuộc họp ko được mời mà tham dự
                }
            }
            catch (Exception e) { }

            return listMeetingJournalistObj;
        }
        #endregion

        #region Button Event's 
        /// <summary>
        /// hiển thị thông tin của cuộc họp khi click vào 1 dòng trong table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void dgvListMeetingToday_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    int rowIndex = e.RowIndex;
        //    if (rowIndex != -1)
        //    {

        //        if (e.ColumnIndex == 7)
        //        {
        //            //bool check = Convert.ToBoolean(dgvListMeetingToday.Rows[e.RowIndex].Cells[colCheck.Name].Value);
        //            //dgvListMeetingToday.Rows[e.RowIndex].Cells[colCheck.Name].Value = !check;
        //        }
        //        else
        //        {
        //            //DataGridViewRow row = dgvListMeetingToday.Rows[rowIndex];
        //            //txtMeetingName.Text = dgvListMeetingToday.Rows[e.RowIndex].Cells[colMeetingName.Name].Value.ToString();
        //            //txtOrganizationMeeting.Text = dgvListMeetingToday.Rows[e.RowIndex].Cells[colOrganizationMeeting.Name].Value.ToString();
        //            //txtRoom.Text = dgvListMeetingToday.Rows[e.RowIndex].Cells[colRoomName.Name].Value.ToString();

        //            //string startDay = dgvListMeetingToday.Rows[e.RowIndex].Cells[colDateTime.Name].Value.ToString();
        //            //string sysUIFormat = CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern;
        //            //string sysFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
        //            //DateTime dt = DateTime.ParseExact(startDay, sysFormat, CultureInfo.InvariantCulture);
        //            //this.dtpDay.Value = dt;
        //            //dtpStartTime.Text = dgvListMeetingToday.Rows[e.RowIndex].Cells[colStartTime.Name].Value.ToString();
        //            //dtpEndTime.Text = dgvListMeetingToday.Rows[e.RowIndex].Cells[colEndTime.Name].Value.ToString();

        //            ////hiển thị danh sách thông tin của cuộc họp được mời chỉ có thể xem không làm gì hết
        //            //List<Partaker> jsonListPartaker = new List<Partaker>();
        //            //String listAttend = dgvListMeetingToday.Rows[e.RowIndex].Cells[colListAttend.Name].Value.ToString();
        //            //jsonListPartaker = JsonConvert.DeserializeObject<List<Partaker>>(listAttend);
        //            //if (jsonListPartaker != null)
        //            //{
        //            //    loadPartakersToTable(jsonListPartaker);
        //            //}
        //            ////txtnumericNumber.Text = ""+Convert.ToInt32(dgvListMeetingToday.Rows[e.RowIndex].Cells[colNumber.Name].Value.ToString());
        //        }
        //    }
        //}
        /// <summary>
        /// show list partakers
        /// </summary>
        //private void loadPartakersToTable(List<Partaker> partakerOtherList)
        //{ //xóa bảng trước khi init
        //    dtbEventListPartaker.Clear();
        //    int index = 0;
        //    //nếu có dữ liệu thêm người tham dự 
        //    if (partakerOtherList.Count > 0)
        //    {
        //        for (int i = 0; i < partakerOtherList.Count; i++)
        //        {
        //            DataRow row = dtbEventListPartaker.NewRow();
        //            row.BeginEdit();
        //            index = i + 1;
        //            row[colSTT.DataPropertyName] = index;
        //            row[colNamePartaker.DataPropertyName] = partakerOtherList[i].name;
        //            row[colNameOrg.DataPropertyName] = partakerOtherList[i].orgname;

        //            row[colPositionPartaker.DataPropertyName] = partakerOtherList[i].position;
        //            row[colCheck.DataPropertyName] = true;
        //            row.EndEdit();
        //            dtbEventListPartaker.Rows.Add(row);
        //        }
        //    }
        //    //// set font size header
        //    //foreach (DataGridViewColumn col in this.dgvListAttend.Columns)
        //    //{
        //    //    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    //    col.HeaderCell.Style.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
        //    //}

        //    //// set font size
        //    //this.dgvListAttend.DefaultCellStyle.Font = new Font("Tahoma", 12F);
        //    //this.dgvListAttend.DefaultCellStyle.Padding = new Padding(0, 3, 0, 3);
        //    //this.dgvListAttend.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

        //    if (dgvListAttend.Rows.Count > 0)
        //        //focur the first row in table
        //        dgvListAttend.Rows[0].Selected = true;
        //}


        /// <summary>
        /// ketpress : dgv
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                int selectedMeetingRowIndex = dgvListMeetingToday.CurrentRow.Index;

                if (e.KeyCode == Keys.Space)
                {
                    //bool check = Convert.ToBoolean(selectedRows[0].Cells[colCheck.Name].Value);
                    //dgvListMeetingToday.Rows[rowindex].Cells[colCheck.Name].Value = !check;

                    //for (int i = 0; i < dgvListMeetingToday.Rows.Count; i++)
                    //{
                    //    dgvListMeetingToday.Rows[i].Cells[colCheck.Name].Value = false;
                    //}

                    for (int i = 0; i < dgvOrgList.Rows.Count; i++)
                    {
                        dgvOrgList.Rows[i].Cells[colCheckOrg.Name].Value = false;
                    }
                    bool check = Convert.ToBoolean(selectedRows[0].Cells[colCheck.Name].Value);
                    dgvListMeetingToday.Rows[rowindex].Cells[colCheck.Name].Value = !check;

                    //kiem tra dong moi chon co phai la "lien he cong tac khong
                    //bool checkMeetingContact = false;
                    //try
                    //{
                    //    //checkMeetingContact = Convert.ToBoolean(dgvListMeetingToday.Rows[dgvListMeetingToday.CurrentRow.Index].Cells[colCheck.Name].Value);
                    //    checkMeetingContact = Convert.ToBoolean(dgvListMeetingToday.Rows[0].Cells[colCheck.Name].Value);
                    //}
                    //catch (Exception x) { }

                    ////kiem tra dong moi chon co phai la "lien he cong tac khong
                    //bool checkMeetingAttend= false;
                    //try
                    //{
                    //    checkMeetingAttend = Convert.ToBoolean(dgvListMeetingToday.Rows[dgvListMeetingToday.CurrentRow.Index].Cells[colCheck.Name].Value);
                    //    //checkMeetingContact = Convert.ToBoolean(dgvListMeetingToday.Rows[0].Cells[colCheck.Name].Value);
                    //}
                    //catch (Exception x) { }

                    long checkMeeting = 0;
                    try
                    {
                        checkMeeting = Convert.ToInt64(dgvListMeetingToday.Rows[dgvListMeetingToday.CurrentRow.Index].Cells[colMeetingId.Name].Value.ToString());
                    }
                    catch (Exception x) { }


                    if (checkMeeting == -1)
                    {
                        for (int i = 1; i < dgvListMeetingToday.Rows.Count; i++)
                        {
                            dgvListMeetingToday.Rows[i].Cells[colCheck.Name].Value = false;
                        }
                    }
                    else
                    {
                        dgvListMeetingToday.Rows[0].Cells[colCheck.Name].Value = false;
                    }

                    // nếu dòng hiện tại là "Liên hệ công tác"
                    if (Convert.ToInt32(dgvListMeetingToday.Rows[dgvListMeetingToday.CurrentRow.Index]
                        .Cells[colSttnew.Name].Value.ToString()) == 1)
                    {
                        //hiển thị danh sách đơn vị liên hệ chưa có nên ẩn đi
                        LoadOrganizationList();//htmynguyen 310317
                        CheckContact = true;
                        // Enabled vùng danh sách đơn vị và cho nhập lý do
                        dgvOrgList.Enabled = true;
                        tbxReason.Enabled = true;
                        //lblReason.Enabled = true;
                        dgvOrgList.Select();
                        // dgvOrgList.Rows[0].Selected = true;//htmynguyen 310317 bỏ đi
                        dgvListMeetingToday.TabStop = false;
                    }
                    else
                    {
                        CheckContact = false;
                        dtbOrgList.Clear();//htmynguyen 310317
                        dgvOrgList.Enabled = false;
                        // tbxReason.Enabled = false;
                        //lblReason.Enabled = false;
                        //dgvListMeetingToday.TabStop = true;//TEST
                        //dgvListMeetingToday.Select();
                        //dgvListMeetingToday.Rows[0].Selected = true;
                        dgvOrgList.ClearSelection();

                        //tbxReason.Select();
                    }

                }
                else if (e.KeyCode == Keys.Tab)
                { // 9 là keychar tab
                    if (selectedMeetingRowIndex != -1)
                    {
                        dgvListMeetingToday.TabStop = false;
                        tbxReason.Select();
                    }
                }
            }
        }

        /// <summary>
        /// mouseclick: dgv
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvListMeetingToday_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex != -1)
            {
                int colCheckIndex = dgvListMeetingToday.Columns[colCheck.Name].Index;
                //7
                if (e.ColumnIndex == colCheckIndex)
                {
                    //bool check = Convert.ToBoolean(dgvListMeetingToday.Rows[e.RowIndex].Cells[colCheck.Name].Value);
                    //dgvListMeetingToday.Rows[e.RowIndex].Cells[colCheck.Name].Value = !check;

                    //for (int i = 0; i < dgvListMeetingToday.Rows.Count; i++)
                    //{
                    //    dgvListMeetingToday.Rows[i].Cells[colCheck.Name].Value = false;
                    //}

                    for (int i = 0; i < dgvOrgList.Rows.Count; i++)
                    {
                        dgvOrgList.Rows[i].Cells[colCheckOrg.Name].Value = false;
                    }

                    bool check = Convert.ToBoolean(dgvListMeetingToday.Rows[e.RowIndex].Cells[colCheck.Name].Value);
                    dgvListMeetingToday.Rows[e.RowIndex].Cells[colCheck.Name].Value = !check;

                    //kiem tra dong moi chon co phai la "lien he cong tac khong
                    //bool checkMeetingContact = false;
                    //try
                    //{
                    //    //checkMeetingContact = Convert.ToBoolean(dgvListMeetingToday.Rows[dgvListMeetingToday.CurrentRow.Index].Cells[colCheck.Name].Value);
                    //    checkMeetingContact = Convert.ToBoolean(dgvListMeetingToday.Rows[0].Cells[colCheck.Name].Value);
                    //}
                    //catch (Exception x) { }

                    ////kiem tra dong moi chon co phai la "lien he cong tac khong
                    //bool checkMeetingAttend= false;
                    //try
                    //{
                    //    checkMeetingAttend = Convert.ToBoolean(dgvListMeetingToday.Rows[dgvListMeetingToday.CurrentRow.Index].Cells[colCheck.Name].Value);
                    //    //checkMeetingContact = Convert.ToBoolean(dgvListMeetingToday.Rows[0].Cells[colCheck.Name].Value);
                    //}
                    //catch (Exception x) { }

                    long checkMeeting = 0;
                    try
                    {
                        checkMeeting = Convert.ToInt64(dgvListMeetingToday.Rows[dgvListMeetingToday.CurrentRow.Index].Cells[colMeetingId.Name].Value.ToString());
                    }
                    catch (Exception x) { }


                    if (checkMeeting == -1)
                    {
                        for (int i = 1; i < dgvListMeetingToday.Rows.Count; i++)
                        {
                            dgvListMeetingToday.Rows[i].Cells[colCheck.Name].Value = false;
                        }
                    }
                    else
                    {
                        dgvListMeetingToday.Rows[0].Cells[colCheck.Name].Value = false;
                    }

                    // nếu dòng hiện tại là "Liên hệ công tác"
                    if (Convert.ToInt32(dgvListMeetingToday.Rows[dgvListMeetingToday.CurrentRow.Index]
                        .Cells[colSttnew.Name].Value.ToString()) == 1)
                    {
                        //hiển thị danh sách đơn vị liên hệ chưa có nên ẩn đi
                        LoadOrganizationList();//htmynguyen 310317
                        CheckContact = true;
                        // Enabled vùng danh sách đơn vị và cho nhập lý do
                        dgvOrgList.Enabled = true;
                        tbxReason.Enabled = true;
                        //lblReason.Enabled = true;
                        dgvOrgList.Select();
                        //  dgvOrgList.Rows[0].Selected = true;//htmynguyen 310317 bỏ đi
                        dgvListMeetingToday.TabStop = false;
                    }
                    else
                    {
                        CheckContact = false;
                        dtbOrgList.Clear();//htmynguyen 310317
                        dgvOrgList.Enabled = false;
                        // tbxReason.Enabled = false;
                        //lblReason.Enabled = false;
                        // dgvListMeetingToday.TabStop = true;//TEST
                        //dgvListMeetingToday.Select();
                        //dgvListMeetingToday.Rows[0].Selected = true;
                        dgvOrgList.ClearSelection();

                        //tbxReason.Select();
                    }

                }
            }
        }
        /// <summary>
        /// keydown : dgv org
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvOrgList_KeyDown(object sender, KeyEventArgs e)
        {
            var selectedRows = dgvOrgList.SelectedRows;

            int rowsCount = selectedRows.Count;
            //so dong duoc chon
            if (rowsCount == 0)
            {
                // Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Failed, MessageValidate.GetMessage(rm, "smsPleaseClickChooseInfo"))));
            }
            else
            {
                int rowindex = dgvOrgList.CurrentRow.Index;
                int selectedMeetingRowIndex = dgvOrgList.CurrentRow.Index;

                if (e.KeyCode == Keys.Space)
                {
                    for (int i = 0; i < dgvOrgList.Rows.Count; i++)
                    {
                        dgvOrgList.Rows[i].Cells[colCheckOrg.Name].Value = false;
                    }

                    bool check = Convert.ToBoolean(selectedRows[0].Cells[colCheckOrg.Name].Value);
                    dgvOrgList.Rows[rowindex].Cells[colCheckOrg.Name].Value = !check;

                    tbxReason.Select();
                }
                else if (e.KeyCode == Keys.Tab)
                { // 9 là keychar tab
                    if (selectedMeetingRowIndex != -1)
                    {
                        dgvOrgList.TabStop = false;
                        tbxReason.Select();
                    }
                }
            }
        }
        /// <summary>
        /// mouse click: dgv org
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvOrgList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex != -1)
            {
                int colCheckIndex = dgvOrgList.Columns[colCheckOrg.Name].Index;
                //3
                if (e.ColumnIndex == colCheckIndex)
                {
                    for (int i = 0; i < dgvOrgList.Rows.Count; i++)
                    {
                        dgvOrgList.Rows[i].Cells[colCheckOrg.Name].Value = false;
                    }

                    bool check = Convert.ToBoolean(dgvOrgList.Rows[e.RowIndex].Cells[colCheckOrg.Name].Value);
                    dgvOrgList.Rows[e.RowIndex].Cells[colCheckOrg.Name].Value = !check;

                    tbxReason.Select();
                }
            }
        }

        /// <summary>
        /// register: btn f10, escape
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

        /// <summary>
        /// click putin 
        /// </summary>
        private void PutIn()
        {
            int counts = meetingObjList.Count;
            String note = tbxReason.Text;

            GetMeetingObjListCheck();
            bool checkOrg = false;
            try
            {
                checkOrg = Convert.ToBoolean(dgvOrgList.Rows[dgvOrgList.CurrentRow.Index].Cells[colCheckOrg.Name].Value);
            }
            catch (Exception x) { }
            //long checkMeeting = 0;
            //try
            //{
            //    checkMeeting = Convert.ToInt64(dgvListMeetingToday.Rows[dgvListMeetingToday.CurrentRow.Index].Cells[colMeetingId.Name].Value.ToString());
            //}
            //catch (Exception x) { }

            bool checkMeetingContact = false;
            try
            {
                //checkMeetingContact = Convert.ToBoolean(dgvListMeetingToday.Rows[dgvOrgList.CurrentRow.Index].Cells[colCheckOrg.Name].Value);
                checkMeetingContact = Convert.ToBoolean(dgvListMeetingToday.Rows[0].Cells[colCheck.Name].Value);
            }
            catch (Exception x) { }

            // #240317 trường họp không có thông tin cuoc hop nao
            //chỉ còn trường họp đén văn phòng liên hệ
            if (meetingObjList.Count == 0 && meetingNotInvitedsList.Count == 0)
            {
                if (checkMeetingContact == false)
                {
                    // Thông báo chưa chọn liên hệ công tác
                    Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Failed, MessageValidate.GetMessage(rm, "smsErrorNullContact"))));
                    return;
                }
                else if (checkMeetingContact == true)
                {
                    if (checkOrg == false)
                    {
                        Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Failed, MessageValidate.GetMessage(rm, "smsErrorNullOrganization"))));
                        return;
                    }
                    else
                    {
                        AddContactForWork();
                        //if (ValidateData())
                        //{
                        //    if (!bgwAddAttendMeetingJournalist.IsBusy)
                        //    {
                        //        AddOrUpdateListMeetingJournalistObj = ToEntity(true);
                        //        bgwAddAttendMeetingJournalist.RunWorkerAsync();
                        //    }
                        //}
                    }
                }
            }
            //end  #240317 trường họp không có thông tin cuoc hop nao

            else
            {
                ////Nếu đang chọn "Liên hệ công tác" nhưng chưa chọn đơn vị liên hệ
                // if (checkMeeting != -1 && checkOrg == false)
                if (checkMeetingContact == true && checkOrg == false)
                // && dgvOrgList.Enabled == false)
                {
                    // Thông báo chưa chọn đơn vị liên hệ
                    Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Failed, MessageValidate.GetMessage(rm, "smsErrorNullOrganization"))));
                }
                else if (checkMeetingContact == true && checkOrg == true)
                {
                    AddContactForWork();
                }
                else
                {
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

        /// <summary>
        /// kiểm tra dữ liệu
        /// ValidateData
        /// </summary>
        private bool ValidateData()
        {

            //nếu chọn công tác liên hệ
            if (CheckContact)
            {
                return true;
            }

            if (meetingObjListCheck.Count == 0 && meetingNotInvitedsListCheck.Count == 0)
            {
                Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Failed, MessageValidate.GetMessage(rm, "smsEmptyListMeeting"))));
                return false;
            }
            return true;
        }
        #endregion

        #region Control
        /// <summary>
        /// SetControl
        /// </summary>
        /// <param name="isView"></param>
        private void SetControl(bool isView)
        {
            this.txtOrg.Enabled = isView;
            this.txtLowerFullName.Enabled = isView;
            this.txtPosition.Enabled = isView;
            // this.txtEmail.Enabled = isView;
            this.txtPhoneNo.Enabled = isView;
            // this.dtpBirthDate.Enabled = isView;
            this.txtIdentityCard.Enabled = isView;
            // this.txtOrganizationMeeting.Enabled = isView;
            // this.txtMeetingName.Enabled = isView;
            // this.txtOrganizationMeeting.Enabled = isView;
            // this.txtRoom.Enabled = isView;
            //// this.txtnumericNumber.Enabled = isView;
            // this.dtpDay.Enabled = isView;
            // this.dtpStartTime.Enabled = isView;
            // this.dtpEndTime.Enabled = isView;
        }

        //#region CustomDesign
        ////private void CustomTypeDate()
        ////{
        ////    // custom date time 
        ////    dtpStartTime.ShowUpDown = true;
        ////    dtpStartTime.CustomFormat = "hh:mm tt";

        ////    dtpEndTime.ShowUpDown = true;
        ////    dtpEndTime.CustomFormat = "hh:mm tt";

        ////    dtpDay.CustomFormat = "dd/MM/yyyy";
        ////    dtpBirthDate.CustomFormat = "dd/MM/yyyy";
        ////}
        //#endregion
        #endregion

    }
}
