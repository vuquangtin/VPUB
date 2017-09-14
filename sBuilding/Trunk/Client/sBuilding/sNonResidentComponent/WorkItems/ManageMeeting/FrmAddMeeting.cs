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
using System.Drawing;
using System.Linq;
using System.Resources;
using System.ServiceModel;
using System.Windows.Forms;


namespace sNonResidenComponent.WorkItems.ManageMeeting
{
    public partial class FrmAddMeeting : Form
    {
        #region Properties
        DateTime startTimeNew;
        DateTime endTimeNew;

        private DataTable dtbEventListPartaker;

        List<Partaker> partakerOtherList;//danh sách thêm vào
        List<Partaker> partakerOtherListCheck;//danh sách thêm vào mà được check
        private EventMeeting AddOrUpdateEventMeeting;
        private EventMeeting OriginalEventMeeting { get; set; }
        public List<OrganizationMg> organizationList;
        public List<OrganizationMg> organizationListCbx;
        public List<Room> roomList;
        public List<Room> roomListCbx;

        private BackgroundWorker bgwAddEventMeeting;
        private BackgroundWorker bgwLoadOrganizationList;
        private BackgroundWorker bgwLoadRoomList;

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
        /// <summary>
        /// FrmAddMeeting
        /// </summary>
        public FrmAddMeeting()
        {
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
            btnAdd.Click += OnButtonPutInClicked;
            btnRefresh1.Click += OnButtonRefresh2Clicked;
            btnCancel.Click += OnButtonCancelClicked;
            btnRefresh.Click += OnButtonRefreshClicked;
            btnAddAttend.Click += OnButtonbtnAddAttendClicked;
            // doi thanh nhan chuot
            //  dgvListAttend.CellMouseClick += ;
            //  dgvListAttend.CellClick += OnButtonDgvListAttendClicked;
            dgvListAttend.KeyDown += OnButtonDgvListAttendKeyPress;
            dgvListAttend.CellMouseClick += dgvListAttend_CellMouseClick;
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
            LoadOrganizationList();
            LoadRoomList();
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
            //14: ADD THêm cuộc họp nội bộ
            bgwAddEventMeeting = new BackgroundWorker();
            bgwAddEventMeeting.WorkerSupportsCancellation = true;
            bgwAddEventMeeting.DoWork += AddEventMeetingWorkerDoWork;
            bgwAddEventMeeting.RunWorkerCompleted += AddEventMeetingRunWorkerCompleted;

            bgwLoadOrganizationList = new BackgroundWorker();
            bgwLoadOrganizationList.WorkerSupportsCancellation = true;
            bgwLoadOrganizationList.DoWork += LoadOrganizationListWorkerDoWork;
            bgwLoadOrganizationList.RunWorkerCompleted += LoadOrganizationListRunWorkerCompleted;

            //15:GET Lấy danh sách các phòng
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
            //OrganizationMg organizationMeetingItem = new OrganizationMg();
            //organizationMeetingItem.name = "-Tất cả-";
            //organizationMeetingItem.id = -1;
            //OrganizationMg organizationMeetingItemOther = new OrganizationMg();
            //organizationMeetingItemOther.name = "-Khác-";
            //organizationMeetingItemOther.id = 0;
            organizationListCbx = new List<OrganizationMg>();
            //organizationListCbx.Add(organizationMeetingItemOther);//khác
            //organizationListCbx.Add(organizationMeetingItem);//tất cả
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
                if (result.Count != 0)
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        if (result[i].typeOrg == OrgEnum.ORG_SUB_ORG || result[i].typeOrg == OrgEnum.ORG_ORG)
                        {
                            organizationListCbx.Add(result[i]);
                        }
                    }
                    //  organizationListCbx.AddRange(result);
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
        /// add list org 
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
            roomListCbx = new List<Room>();

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
                    roomListCbx.AddRange(result);
                    cbxNameRoom.DataSource = roomListCbx.ToList();
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

        /// <summary>
        /// insert meeting other
        /// AddEventMeetingWorkerDoWork
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddEventMeetingWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = (int)Status.SUCCESS == MeetingEventFactory.Instance.GetChannel().insertEventMeeting(storageService.CurrentSessionId, AddOrUpdateEventMeeting);
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
        /// AddEventMeetingRunWorkerCompleted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddEventMeetingRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                partakerOtherListCheck = new List<Partaker>();
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "smsErrorInsertAddMeeting"));
                return;
            }
            if ((bool)e.Result)
            {
                partakerOtherListCheck = new List<Partaker>();
                ClearEmptyControl();
                //  MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "smsSuccessAddMeeting"));
                PostAction = DialogPostAction.SUCCESS;
                this.Close();
            }
            else
            {
                partakerOtherListCheck = new List<Partaker>();
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "smsErrorInsertAddMeeting"));

                return;
            }
        }

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
            eventMeeting.name = tbxNameMeeting.Text;
            eventMeeting.note = txtNote.Text;
            //int number = Convert.ToInt32(numericNumber.Value.ToString(), 16);

            DateTime dtDate = this.dtpDay.Value.Date;
            DateTime dtpStartTime = this.dtpStartTime.Value.Date;
            DateTime dtpEndTime = this.dtpEndTime.Value.Date;
            String dtDatestr = dtDate.ToString("yyyy-MM-dd 00:00:00");
            String dtStartTimestr = startTimeNew.ToString("yyyy-MM-dd HH:mm:00");
            String dtpEndTimeStr = endTimeNew.ToString("yyyy-MM-dd HH:mm:00");
            eventMeeting.startTime = dtStartTimestr;
            eventMeeting.endTime = dtpEndTimeStr;
            //20170306 #Bug Fix- My Nguyen Start
            //thêm đối tượng để map dữ liệu
            eventMeeting.meetingCode = -1;
            eventMeeting.meetingCodeStatus = true;
            //20170306 #Bug Fix- My Nguyen End

            //org
            try
            {
                OrganizationMg organizationItem = (OrganizationMg)cbxOrganization.SelectedItem;
                eventMeeting.organizationMeetingId = organizationItem.id;
                eventMeeting.organizationMeetingName = organizationItem.name;
            }
            catch (Exception ex)
            {
                //eventMeeting.organizationMeetingId = 0;//id=0 other
                //eventMeeting.organizationMeetingName = "Khác";
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
            eventMeeting.nonresident = true;
            //  eventMeeting.number = partakerOtherListCheck.Count;//côt này là số lượng đơn vị tổ chức được mời chứ không phải số người được mời
            return eventMeeting;
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
                loadPartakersToTable();
                ClearEmptyControl();
            }
        }

        /// <summary>
        /// show list partakers
        /// </summary>
        private void loadPartakersToTable()
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

            if (dgvListAttend.Rows.Count > 0)
                //focur the first row in table
                dgvListAttend.Rows[0].Selected = true;
        }

        /// <summary>
        /// keypress: dgv
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
                }
            }
        }

        /// <summary>
        /// mouse click: dgv
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
                    bool check = Convert.ToBoolean(dgvListAttend.Rows[e.RowIndex].Cells[4].Value);
                    dgvListAttend.Rows[e.RowIndex].Cells[4].Value = !check;
                }
            }
        }

        /// <summary>
        /// GetListPartakeCheck
        ///   lấy danh sách người tham dự có chek ô tham dự họp
        /// </summary>
        private void GetListPartakeCheck()
        {
            partakerOtherListCheck = new List<Partaker>();
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
            //String error = "";
            //bool check = true;
            //if (string.IsNullOrEmpty(txtName.Text))
            //{
            //    error += MessageValidate.GetMessage(rm, "smsNameAttend");
            //    check = false;
            //}
            //if (!error.Equals("")) error += ", ";
            //if (string.IsNullOrEmpty(txtPositionAttend.Text))
            //{
            //    error += MessageValidate.GetMessage(rm, "smsPosition");
            //    check = false;
            //}
            //if (!error.Equals("")) error += ", ";
            //if (string.IsNullOrEmpty(txtOrg.Text))
            //{
            //    error += MessageValidate.GetMessage(rm, "smsNameOrg") + ". ";
            //    check = false;
            //}
            //if (check)
            //{
            //    return true;
            //}
            //else
            //{
            //    //   MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessageValidate(rm, error), MessageValidate.GetErrorTitle(rm));
            //    MessageBoxManager.ShowErrorMessageBox(this, String.Format(MessageValidate.GetMessage(rm, "smsValidateData"), error));
            //    return false;
            //}
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

        //20170305 #Bug Fix- My Nguyen Start

        //luôn luôn bắt sự kiện Enter nút cho vào
        //protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        //{
        //    //if (msg.WParam.ToInt32() == (int)Keys.Enter)
        //    //{
        //    //    PutIn();
        //    //}
        //    //else
        //    //{
        //    //   return base.ProcessCmdKey(ref msg, keyData);
        //    //}
        //   return false;
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

            if (ValidateData() && ValidateDate(dtStart, dtEnd, MessageValidate.GetMessage(rm, "smsStartTime"), MessageValidate.GetMessage(rm, "smsEndTime")) && MessageBoxManager.ShowQuestionMessageBox(this, MessageValidate.GetMessage(rm, "smsQuestionYesNoAddMeeting")) == System.Windows.Forms.DialogResult.Yes)
            {
                GetListPartakeCheck();
                if (partakerOtherListCheck.Count > 0)
                {
                    if (!bgwAddEventMeeting.IsBusy)
                    {
                        AddOrUpdateEventMeeting = ToEntity();
                        bgwAddEventMeeting.RunWorkerAsync();
                        //autoNumber++;
                    }
                }
                else
                {
                    MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "smsEmptyListPersonalMeeting"));
                }
            }
        }

        private void OnButtonPutInClicked(object sender, EventArgs e)
        {
            PutIn();
        }
        /// <summary>
        /// register key f10, key  escape
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

        private void OnButtonRefresh2Clicked(object sender, EventArgs e)
        {
            ClearEmptyControl2();
            ClearEmptyControl();
            partakerOtherList = new List<Partaker>();
            loadPartakersToTable();
            CustomTypeDate();
        }

        private void OnButtonRefreshClicked(object sender, EventArgs e)
        {
            ClearEmptyControl();
        }

        private void ClearEmptyControl()
        {
            txtName.Text = string.Empty;
            txtOrg.Text = "";
            txtPositionAttend.Text = string.Empty;
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
            // dtpDay.ShowUpDown = true;
            dtpDay.CustomFormat = "dd/MM/yyyy";
            //20170304 #Bug Fix- My Nguyen Start
            //format time
            DateTime dtDay = this.dtpDay.Value.Date;
            dtpDay.Value = DateTime.Now;

            DateTime dtStart = dtDay;
            int hour = 8;
            int minutes = 0;
            TimeSpan ts = new TimeSpan(hour, minutes, 0);
            dtStart = dtStart.Date + ts;
            dtpStartTime.Value = dtStart;

            DateTime dtEnd = dtDay;
            int hourEnd = 17;
            int minutesEnd = 0;
            TimeSpan tsEnd = new TimeSpan(hourEnd, minutesEnd, 0);
            dtEnd = dtEnd.Date + tsEnd;
            dtpEndTime.Value = dtEnd;
        }
        #endregion

    }
}


