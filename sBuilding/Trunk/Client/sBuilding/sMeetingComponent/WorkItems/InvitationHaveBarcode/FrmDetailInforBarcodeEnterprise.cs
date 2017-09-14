using CommonControls;
using CommonHelper.Constants;
using CommonHelper.Utils;
using JavaCommunication;
using Microsoft.Practices.CompositeUI;
using Newtonsoft.Json;
using sMeetingComponent.Constants;
using sMeetingComponent.Factory;
using sMeetingComponent.Model;
using sMeetingComponent.Model.CustomObj.EnterpriseHaveBarcode;
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

namespace sMeetingComponent.WorkItems.InvitationHaveBarcode
{
    #region CHƯA SỬ DỤNG MÀN HÌNH NÀY
    #endregion
    /// <summary>
    /// FRM NOT USE
    /// </summary>
    public partial class FrmDetailInforBarcodeEnterprise : Form
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
        private DetailInfoEnterpriseOrgOther detailInfo;
        private DataTable dtbEventListPartaker;

        List<PartakerObj> partakerOtherList;//danh sách người tham dự tự thêm vào
        List<PartakerObj> partakerOtherListCheck;//danh sách người tham dự tự thêm vào => được check

        private string EnterpriseAttendMeeting = "Doanh Nghiệp tham dự họp";
        private string NameEnterpriseAttendMeeting = "Thành viên tham dự họp";

        private List<NonResident> AddOrUpdateAttendMeetingObj;
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
        /// <summary>
        /// FrmDetailInforBarcodeEnterprise
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="codeMeetingInvitation"></param>
        public FrmDetailInforBarcodeEnterprise(byte mode, String codeMeetingInvitation)
        {
            InitializeComponent();
            InitDataTableEventListPartakers();
            SetValueNumberric();
            //  CustomTypeDate();
            this.barcode = codeMeetingInvitation;
            this.OperatingMode = mode;

            partakerOtherList = new List<PartakerObj>();
            partakerOtherListCheck = new List<PartakerObj>();

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
        /// <summary>
        ///  // Set the Minimum, Maximum, and initial Value.
        /// </summary>
        private void SetValueNumberric()
        {
            nmrTotal.Value = 1;
            nmrTotal.Maximum = 200;
            nmrTotal.Minimum = 1;
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

        /// <summary>
        /// InitDataTableEventListPartakers
        /// </summary>
        private void InitDataTableEventListPartakers()
        {
            dtbEventListPartaker = new DataTable();
            dtbEventListPartaker.Columns.Add(colSTT.DataPropertyName);
            dtbEventListPartaker.Columns.Add(colNamePartaker.DataPropertyName);
            dtbEventListPartaker.Columns.Add(colPositionPartaker.DataPropertyName);
            dtbEventListPartaker.Columns.Add(colCheck.DataPropertyName);
            dgvListAttend.DataSource = dtbEventListPartaker;

        }

        /// <summary>
        ///  dang ky su kien 
        ///  RegisterEvent
        /// </summary>
        private void RegisterEvent()
        {
            CreateBackgroundWorkerEvent();
            btnAdd.Click += OnButtonbtnAddAttendClicked;
            btnConfirm.Click += OnButtonPutInClicked;
            btnCancel.Click += OnButtonExitClicked;
            btnRefresh.Click += OnButtonRefreshClicked;
            dgvListAttend.KeyDown += OnButtonDgvListAttendKeyPress;
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
        }

        /// <summary>
        ///LoadEventDetailInfo
        /// </summary>
        private void LoadEventDetailInfo()
        {
            if (!loadEventDetailInfo.IsBusy)
            {
                loadEventDetailInfo.RunWorkerAsync();
            }
        }

        #region bgWorker
        /// <summary>
        /// CreateBackgroundWorkerEvent
        /// </summary>
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

        /// <summary>
        /// OnLoadEventDetailInfoWorkerCompleted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                DetailInfoEnterpriseOrgOther result = (DetailInfoEnterpriseOrgOther)e.Result;

                LoadEventDetailInfodata(result);
            }
        }

        /// <summary>
        /// get info invation by barcode of enterprise
        /// OnLoadEventDetailInfoWorkerDoWork
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoadEventDetailInfoWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = detailInfo = DetailInfoFactory.Instance.GetChannel().getDetailInfoByBarcodeOfEnterprise(storageService.CurrentSessionId, barcode);
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
        /// OnLoadAddAttendMeetingObjRunWorkerCompleted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoadAddAttendMeetingObjRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                partakerOtherListCheck = new List<PartakerObj>();
                Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Failed, MessageValidate.GetMessage(rm, "smsErrorInsertPersonal"))));
                return;
            }
            if (e.Result == null)
            {
                partakerOtherListCheck = new List<PartakerObj>();
                Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Failed, MessageValidate.GetMessage(rm, "smsErrorInsertPersonal"))));
                return;
            }
            if ((bool)e.Result)
            {
                PostAction = DialogPostAction.SUCCESS;
                UsrListMeeting.SetIndexStatus(1);
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
                e.Result = (int)Status.SUCCESS == AttendMeetingFactory.Instance.GetChannel().insertEventAttendMeetingEnterprise(storageService.CurrentSessionId, AddOrUpdateAttendMeetingObj);
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
        /// show info invation of enterprise
        /// </summary>
        /// <param name="detailInfo"></param>
        private void LoadEventDetailInfodata(DetailInfoEnterpriseOrgOther detailInfo)
        {
            try
            {
                this.txtMeetingName.Text = detailInfo.meetingname;
                this.txtOrg.Text = detailInfo.organizationMeetingName;//đơn vị tổ chức cuộc họp

                this.txtOrganization.Text = detailInfo.organizationAttendName;//đơn vị được mời
                this.txtCode.Text = detailInfo.organizationAttendCode;//mã  đơn vị được mời đơn vị được mời

                DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                DateTime startDate = start.AddMilliseconds(Convert.ToUInt64(detailInfo.startTime)).ToLocalTime();
                //DateTime endDate = start.AddMilliseconds(Convert.ToUInt64(detailInfo.detailInfoOnlyPerson.endTime)).ToLocalTime();
                this.dtpDay.Value = startDate;
                this.dtpStartTime.Text = startDate.ToString("hh:mm tt");
                // this.dtpEndTime.Text = endDate.ToString("hh:mm tt");
                txtNoteMeeting.Text = detailInfo.note;
                // txtNameAttends.Text = detailInfo.partakerName;
                // txtPositionAttends.Text = detailInfo.position;
                tbxReason.Text = EnterpriseAttendMeeting;

            }
            catch (Exception ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "TimeOutExceptionMessage"));
            }

        }

        /// <summary>
        /// show list partakers
        /// </summary>
        private void loadPartakersToTable()
        {//xóa bảng trước khi init
            dtbEventListPartaker.Clear();
            int index = 0;

            //nếu có dữ liệu thêm người tham dự 
            if (partakerOtherList.Count > 0)
            {
                for (int i = 0; i < partakerOtherList.Count; i++)
                {
                    DataRow row = dtbEventListPartaker.NewRow();
                    row.BeginEdit();
                    index = index + 1;
                    row[colSTT.DataPropertyName] = index;
                    row[colNamePartaker.DataPropertyName] = partakerOtherList[i].name;
                    row[colPositionPartaker.DataPropertyName] = partakerOtherList[i].position;
                    row[colCheck.DataPropertyName] = true; //có dấu check ban đầu 
                    row.EndEdit();
                    dtbEventListPartaker.Rows.Add(row);
                }
            }

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
                    partakerOtherListCheck.Add(partakerOtherList[i]);
                }
            }
        }

        #region Event's support
        /// <summary>
        /// tao doi tuong attendmeeting
        /// toentity
        /// </summary>
        /// <returns></returns>
        private List<NonResident> ToEntity()
        {
            List<NonResident> attendMeetingList = new List<NonResident>();
            DateTime dateStart = DateTime.Now;
            String startDate = dateStart.ToString("yyyy-MM-dd HH:mm");
            DateTime dateEnd = new DateTime(1971, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            String endDate = dateEnd.ToString("yyyy-MM-dd HH:mm");

            int countepartakerOtherListCheck = partakerOtherListCheck.Count;
            if (countepartakerOtherListCheck > 0)
            {
                for (int i = 0; i < countepartakerOtherListCheck; i++)
                {
                    NonResident attendMeetingitem = new NonResident();

                    attendMeetingitem.meetingId = detailInfo.meetingId;
                    attendMeetingitem.meetingName = detailInfo.meetingname;
                    attendMeetingitem.orgId = detailInfo.organizationMeetingId;
                    attendMeetingitem.orgName = detailInfo.organizationMeetingName;

                    attendMeetingitem.note = tbxReason.Text;
                    attendMeetingitem.inputTime = startDate;
                    attendMeetingitem.outputTime = endDate;

                    attendMeetingitem.orgName = detailInfo.organizationAttendName;

                    //thông tin người tham dự
                    attendMeetingitem.serialNumber = "00000000";
                    attendMeetingitem.name = partakerOtherListCheck[i].name;
                    attendMeetingitem.nonResidentOrganization = txtOrganization.Text;
                    attendMeetingitem.nonResidentPosition = partakerOtherListCheck[i].position;

                    //xác định cho doanh nghiệp vào
                    attendMeetingitem.isOrgOther = true;

                    attendMeetingitem.status = true;

                    attendMeetingList.Add(attendMeetingitem);
                }
            }
            int numberAttendEnterprise = 1;
            try
            {
                numberAttendEnterprise = (int)nmrTotal.Value;
            }
            catch (Exception e) { }
            int countNotInfo = numberAttendEnterprise - countepartakerOtherListCheck;
            if (countNotInfo > 0)
            {
                for (int i = 1; i <= countNotInfo; i++)
                {
                    NonResident attendMeetingitem = new NonResident();

                    attendMeetingitem.meetingId = detailInfo.meetingId;
                    attendMeetingitem.meetingName = detailInfo.meetingname;
                    attendMeetingitem.orgId = detailInfo.organizationMeetingId;
                    attendMeetingitem.orgName = detailInfo.organizationMeetingName;

                    attendMeetingitem.note = tbxReason.Text;
                    attendMeetingitem.inputTime = startDate;
                    attendMeetingitem.outputTime = endDate;

                    attendMeetingitem.orgName = detailInfo.organizationAttendName;

                    //thông tin người tham dự
                    attendMeetingitem.serialNumber = "00000000";
                    attendMeetingitem.name = txtCode.Text + " " + NameEnterpriseAttendMeeting + " " + i;
                    attendMeetingitem.nonResidentOrganization = txtOrganization.Text;

                    //xác định cho doanh nghiệp vào
                    attendMeetingitem.isOrgOther = true;

                    attendMeetingitem.status = true;

                    attendMeetingList.Add(attendMeetingitem);
                }

            }

            return attendMeetingList;
        }
        #endregion

        #region Button Event's 
        /// <summary>
        /// register btn f10, escape
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
        /// click btn add: putin
        /// </summary>
        private void PutIn()
        {
            String note = tbxReason.Text;
            GetListPartakeCheck();


            if (ValidateStartTime())
            {
                if (!bgwAddAttendMeetingObj.IsBusy)
                {
                    AddOrUpdateAttendMeetingObj = ToEntity();
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
            if (ValidateDataPartaker())
            {
                PartakerObj partaker = new PartakerObj();
                partaker.name = txtNameAttends.Text;
                partaker.position = txtPositionAttends.Text;

                partaker.orgname = txtOrganization.Text;

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
        /// ValidateData
        /// kiểm tra dữ liệu nhập vào form
        /// </summary>
        private bool ValidateData()
        {
            if (partakerOtherListCheck.Count == 0)
            {
                Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Failed, MessageValidate.GetMessage(rm, "smsEmptyListPersonalMeeting"))));
                return false;
            }
            return true;
        }

        /// <summary>
        /// ValidateStartTime
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

            DateTime startDate = start.AddMilliseconds(Convert.ToUInt64(detailInfo.startTime)).ToLocalTime();

            String dateStartStr = startDate.ToString("yyyy-MM-dd");

            if (!dateNowStr.Equals(dateStartStr))
            {
                Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Failed, MessageValidate.GetMessage(rm, "smsStartTimeMeeting") + " " + dateStartStr.ToString())));
                return false;
            }
            return true;
        }

        /// <summary>
        /// ValidateDataPartaker
        /// kiểm tra dữ liệu nhập vào form
        /// </summary>
        /// <returns></returns>
        private bool ValidateDataPartaker()
        {
            if (string.IsNullOrEmpty(txtNameAttends.Text))
            {
                Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Failed, MessageValidate.GetMessageValidate(rm, "smsNameAttend"))));
                return false;
            }
            if (string.IsNullOrEmpty(txtPositionAttends.Text))
            {
                Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Failed, MessageValidate.GetMessageValidate(rm, "smsPosition"))));
                return false;
            }
            return true;
        }

        /// <summary>
        /// OnButtonDgvListAttendKeyPress
        /// keyoress dgv
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
                if (e.ColumnIndex == 3)
                {
                    bool check = Convert.ToBoolean(dgvListAttend.Rows[e.RowIndex].Cells[3].Value);
                    dgvListAttend.Rows[e.RowIndex].Cells[3].Value = !check;
                }
            }
        }

        private void OnButtonExitClicked(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// click btn refesh
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            txtNameAttends.Text = string.Empty;
            txtPositionAttends.Text = string.Empty;
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
            dtpStartTime.CustomFormat = "hh:mm tt";
            //dtpEndTime.ShowUpDown = true;
            //dtpEndTime.CustomFormat = "hh:mm tt";
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

     
    }
}
