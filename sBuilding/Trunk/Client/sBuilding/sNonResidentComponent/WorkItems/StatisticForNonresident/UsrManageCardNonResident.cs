using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using CommonControls.Custom;

using Microsoft.Practices.CompositeUI.Commands;
using CommonHelper.Constants;
using CommonHelper.Utils;
using CommonControls;
using sWorldModel.Exceptions;
using System.Resources;
using Microsoft.Practices.CompositeUI;
using sWorldModel;
using System.ServiceModel;
using sNonResidentComponent.Constants;
using JavaCommunication;
using sNonResidentComponent.Factory;
using sNonResidenComponent.WorkItems;
using System.Globalization;
using ClientModel.Model;
using ClientModel.Utils;
using System.IO;
using sMeetingComponent.Constants;
using sExcelExportComponent.ClientModel.Enums;
using sMeetingComponent.Model;
using sNonResidentComponent.Model.CustomObj.Statistic;
using sNonResidentComponent.WorkItems.ManageMeeting;

namespace sNonResidentComponent.WorkItems.StatisticForNonresident
{
    public partial class UsrManageCardNonResident : CommonUserControl
    {
        #region Properties
        public string sysFormatDate;

        private String cardchip = "";
        int take = Enums.TAKE;
        int sum = 0;

        private FrmShiftImage frm = new FrmShiftImage("", "");

        List<NonResidentObj> nonResidentList;
        NonResidentStatisticDetailObj nonResidentStatisticDetailObj;
        private bool checkNotPersoCard = false;
        private NonResident AddOrUpdateNonResident;
        public NonResidentObj OriginalNonResidentObj;
        private BackgroundWorker loadNonResidentList;
        private BackgroundWorker cancelPersoNonResident;
        private DataTable table4Export = null;
        private DataTable dtbNonResidentList;
        String updating = "Updating";
        String cancelled = "Cancelled";

        private int currentPageIndex = 1;
        private const int hiddenFilterBoxHeight = 1;
        private int startupFilterBoxHeight;

        private NonResidentComponentWorkItem workItem;
        private ResourceManager rm;
        public DialogPostAction PostAction { get; private set; }
        [ServiceDependency]
        public NonResidentComponentWorkItem WorkItem
        {
            set { workItem = value; }
        }

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
        #endregion

        #region Contructors
        public UsrManageCardNonResident()
        {
            InitializeComponent();
            InitDataTableNonResidentList();
            sysFormatDate = UsrManageMeeting.formatDateTime();

            RegisterEvent();

        }
        #endregion
        /// <summary>
        /// InitDataTableNonResidentList
        /// </summary>
        private void InitDataTableNonResidentList()
        {
            dtbNonResidentList = new DataTable();
            dtbNonResidentList.Columns.Add(colOrderNum.DataPropertyName);
            dtbNonResidentList.Columns.Add(colMemberId.DataPropertyName);
            dtbNonResidentList.Columns.Add(colSerialNumber.DataPropertyName);
            dtbNonResidentList.Columns.Add(colFullName.DataPropertyName);

            dtbNonResidentList.Columns.Add(colPositionPartaker.DataPropertyName);
            dtbNonResidentList.Columns.Add(colOrgPartaker.DataPropertyName);

            dtbNonResidentList.Columns.Add(colBirthDate.DataPropertyName);
            dtbNonResidentList.Columns.Add(colIdentityCard.DataPropertyName);
            dtbNonResidentList.Columns.Add(colIdentityCardDate.DataPropertyName);
            dtbNonResidentList.Columns.Add(colIdentityCardIssue.DataPropertyName);
            dtbNonResidentList.Columns.Add(colNationality.DataPropertyName);
            dtbNonResidentList.Columns.Add(colPhoneNo.DataPropertyName);
            dtbNonResidentList.Columns.Add(colAddress.DataPropertyName);
            dtbNonResidentList.Columns.Add(colPersoStatus.DataPropertyName);
            dtbNonResidentList.Columns.Add(colToOrg.DataPropertyName);
            dtbNonResidentList.Columns.Add(colDate.DataPropertyName);
            dtbNonResidentList.Columns.Add(colInputTime.DataPropertyName);
            dtbNonResidentList.Columns.Add(colOutTime.DataPropertyName);
            dtbNonResidentList.Columns.Add(colImageFace.DataPropertyName);
            dtbNonResidentList.Columns.Add(colImageIdentityCard.DataPropertyName);
            dgvNonResident.DataSource = dtbNonResidentList;

            //20170304 #Bug Fix- My Nguyen Start
            // for export
            table4Export = new DataTable();

            table4Export.Columns.Add(colOrderNum.DataPropertyName);
            table4Export.Columns.Add(colMemberId.DataPropertyName);
            table4Export.Columns.Add(colSerialNumber.DataPropertyName);
            table4Export.Columns.Add(colFullName.DataPropertyName);

            table4Export.Columns.Add(colPositionPartaker.DataPropertyName);
            table4Export.Columns.Add(colOrgPartaker.DataPropertyName);

            table4Export.Columns.Add(colBirthDate.DataPropertyName);
            table4Export.Columns.Add(colIdentityCard.DataPropertyName);
            table4Export.Columns.Add(colIdentityCardDate.DataPropertyName);
            table4Export.Columns.Add(colIdentityCardIssue.DataPropertyName);
            table4Export.Columns.Add(colNationality.DataPropertyName);
            table4Export.Columns.Add(colPhoneNo.DataPropertyName);
            table4Export.Columns.Add(colAddress.DataPropertyName);
            table4Export.Columns.Add(colPersoStatus.DataPropertyName);
            table4Export.Columns.Add(colToOrg.DataPropertyName);
            table4Export.Columns.Add(colDate.DataPropertyName);
            table4Export.Columns.Add(colInputTime.DataPropertyName);
            table4Export.Columns.Add(colOutTime.DataPropertyName);
            table4Export.Columns.Add(colImageFace.DataPropertyName);
            table4Export.Columns.Add(colImageIdentityCard.DataPropertyName);

            dataGridview4Export.DataSource = table4Export;
            //20170304 #Bug Fix- My Nguyen End
        }

        /// <summary>
        /// RegisterEvent
        /// đăng ký sự kiện
        /// </summary>
        private void RegisterEvent()
        {
            CreateBackgroundWorkerEvent();
            dgvNonResident.MouseDown += dgvNonResident_MouseDown;
            btnReload.Click += OnButtonReloadClicked;
            btnUpdate.Click += btnUpdatePersoCard_Click;
            btnExportToExcel.Click += btnExportToExcel_Click;
            btnCancel.Click += btnCancelPerso_Click;
            btnShowHide.Click += btnShowHide_Clicked;
            tbxMemberName.TextChanged += tbxMeetingNameSearchs_TextChanged;
            rbtnNotPersoCard.CheckedChanged += rbtnNotPerso_CheckChanged;
            rbtnPersoCard.CheckedChanged += rbtnPerso_CheckChanged;
            rbtnAllCard.CheckedChanged += rbtnAllCard_CheckChanged;
            pagerPanel.LinkLabelClicked += pagerPanel_LinkLabelClicked;
            dgvNonResident.CellClick += dgvNonResidentClicked;

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
            startupFilterBoxHeight = pnlFilterBox.Height;
            pagerPanel.StorageService = storageService;
            pagerPanel.LoadLanguage();

            SetLanguages();

            LoadNonResidentList();

        }

        #region language
        /// <summary>
        /// SetLanguages
        /// </summary>
        private void SetLanguages()
        {
            this.colOrderNum.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colOrderNum.Name);
            this.colFullName.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colFullName.Name);
            this.colPositionPartaker.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colPositionPartaker.Name);
            this.colOrgPartaker.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colOrgPartaker.Name);

            this.colBirthDate.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colBirthDate.Name);
            this.colIdentityCard.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colIdentityCard.Name);
            this.colNationality.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colNationality.Name);
            this.colPhoneNo.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colPhoneNo.Name);
            this.colToOrg.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colToOrg.Name);
            this.colDate.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colDate.Name);
            this.colInputTime.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colInputTime.Name);
            this.colPersoStatus.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colPersoStatus.Name);
            this.colOutTime.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colOutTime.Name);
            this.colAddress.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colAddress.Name);
            this.colViewImage.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colViewImage.Name);

            //
            this.dataGridViewTextBoxColumn2.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colOrderNum.Name);
            this.dataGridViewTextBoxColumn4.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colFullName.Name);
            this.colPositionPartakerEx.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colPositionPartaker.Name);
            this.colOrgPartakerEx.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colOrgPartaker.Name);

            this.dataGridViewTextBoxColumn5.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colBirthDate.Name);
            this.dataGridViewTextBoxColumn6.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colIdentityCard.Name);
            this.dataGridViewTextBoxColumn10.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colPhoneNo.Name);
            this.dataGridViewTextBoxColumn11.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colPersoStatus.Name);
            this.dataGridViewTextBoxColumn12.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colToOrg.Name);
            this.dataGridViewTextBoxColumn13.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colDate.Name);
            this.dataGridViewTextBoxColumn14.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colInputTime.Name);
            this.dataGridViewTextBoxColumn15.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colOutTime.Name);
            this.dataGridViewTextBoxColumn18.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colAddress.Name);
            //

            this.btnUpdate.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.mniUpdate.Name);
            this.btnExportToExcel.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnExportToExcel.Name);
            this.btnCancel.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.mniCancelPerso.Name);
            this.btnShowHide.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnShowHide.Name);
            this.btnReload.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnReload.Name);
            this.mniCancelPerso.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.mniCancelPerso.Name);
            this.mniUpdate.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.mniUpdate.Name);

            string updatestr = MessageValidate.GetMessage(rm, "updating");
            if (updatestr != null)
            {
                updating = updatestr;

                if (updating.Equals("") || updating.Equals("LanguagesError"))
                {
                    updating = "updating";
                }
            }
            string cancelledstr = MessageValidate.GetMessage(rm, "cancelled");
            if (cancelledstr != null)
            {
                cancelled = cancelledstr;

                if (cancelled.Equals("") || cancelled.Equals("LanguagesError"))
                {
                    cancelled = "Cancelled";
                }
            }
        }
        #endregion

        #region LoadNonResidentList
        /// <summary>
        /// LoadNonResidentList
        /// </summary>
        private void LoadNonResidentList()
        {
            DateTime dtIn = this.dtpDateIn.Value.Date;
            DateTime dtIn2 = this.dtpDateIn2.Value.Date;
            if (ValidateData(dtIn, dtIn2))
            {
                if (!loadNonResidentList.IsBusy)
                {
                    dtbNonResidentList.Rows.Clear();
                    pagerPanel.ShowMessage(MessageValidate.GetMessage(rm, "smsLoading"));
                    loadNonResidentList.RunWorkerAsync();
                }
            }
            else
            {
                dtbNonResidentList.Rows.Clear();
            }
        }

        /// <summary>
        /// ValidateData
        ///         kiểm tra dữ liệu nhập vào form
        /// </summary>
        private bool ValidateData(DateTime dtIn, DateTime dtIn2)
        {
            int result = DateTime.Compare(dtIn, dtIn2);
            if (result < 0)
                return true;
            else if (result == 0)
                return true;
            else
            {
                UploadStatusBar();
                //MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "smsFilterDateSmeeting"));
                return false;
            }
        }
        #endregion

        #region bgWorker
        /// <summary>
        /// CreateBackgroundWorkerEvent
        /// </summary>
        private void CreateBackgroundWorkerEvent()
        {
            //11:MANAGE Lấy thông tin khách vãng lai
            loadNonResidentList = new BackgroundWorker();
            loadNonResidentList.WorkerSupportsCancellation = true;
            loadNonResidentList.DoWork += OnLoadNonResidentWorkerDoWork;
            loadNonResidentList.RunWorkerCompleted += OnLoadNonResidentWorkerCompleted;

            //12:DELETE Hủy thẻ
            cancelPersoNonResident = new BackgroundWorker();
            cancelPersoNonResident.WorkerSupportsCancellation = true;
            cancelPersoNonResident.DoWork += OnCancelPersoNonResidentWorkerDoWork;
            cancelPersoNonResident.RunWorkerCompleted += OnCancelPersoNonResidentWorkerCompleted;
        }

        #region Lấy thông tin quản lí thông tin tình trạng thẻ khách vãng lai
        /// <summary>
        /// Get list info nonresident based on start, end, theDateIn, theDateIn2);
        ///  //11:GET Lấy thông tin khách vãng lai
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public NonResidentStatisticDetailObj LoadNonResidentListAtPage(int start, int end)
        {
            string theDateIn = dtpDateIn.Value.ToString("yyyy-MM-dd");
            string theDateIn2 = dtpDateIn2.Value.ToString("yyyy-MM-dd");
            NonResidentStatisticDetailObj nonResidentStatisticDetailObjNew = new NonResidentStatisticDetailObj();
            try
            {
                nonResidentStatisticDetailObjNew = NonResidentStatisticsFactory.Instance.GetChannel().getListNonresidentByDate(StorageService.CurrentSessionId, start, end, theDateIn, theDateIn2);
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
            return nonResidentStatisticDetailObjNew;
        }
        #endregion

        #region Gửi yêu cầu lấy thông tin thẻ khách vãng lai
        /// <summary>
        /// get nonresident list based on from date to date
        /// OnLoadNonResidentWorkerDoWork
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoadNonResidentWorkerDoWork(object sender, DoWorkEventArgs e)
        {

            int totalRecords = 0;
            int skip = 0;
            currentPageIndex = 1;
            List<NonResidentObj> result = null;
            try
            {
                e.Result = nonResidentStatisticDetailObj = LoadNonResidentListAtPage(skip, take);
            }
            catch (Exception ex) { }

            finally
            {
                if (nonResidentStatisticDetailObj != null)
                {
                    sum = totalRecords = Convert.ToInt32(nonResidentStatisticDetailObj.sum);
                    nonResidentList = result = nonResidentStatisticDetailObj.nonResidentObjs;
                    pagerPanel.ShowNumberOfRecords(totalRecords, result != null ? result.Count : 0, take, currentPageIndex);
                    pagerPanel.UpdatePagingLinks(totalRecords, take, currentPageIndex);
                }
                e.Result = result;
            }
        }

        /// <summary>
        /// không cho phân trang thi vẫn còn hiển thị thanh link, và không cho xuất exccel
        /// Change statusbar : message not data
        /// </summary>
        private void UploadStatusBar()
        {
            btnUpdate.Enabled = btnCancel.Enabled = btnExportToExcel.Enabled = false;
            pagerPanel.ShowMessage(MessageValidate.GetMessage(rm, "lblMessageNotData"));
            pagerPanel.UpdatePagingLinks(0, 1, 0);
        }

        /// <summary>
        ///  change status bar: have pagepanel , but not data
        ///  cho phân trang thi vẫn còn hiển thị thanh link, và cho xuất exccel
        /// </summary>
        private void UploadStatusBarHavePagePanel()
        {
            pagerPanel.ShowMessage(MessageValidate.GetMessage(rm, "lblMessageNotData"));
        }
        /// <summary>
        /// OnLoadNonResidentWorkerCompleted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoadNonResidentWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                UploadStatusBar();
            }
            if (e.Result == null)
            {
                UploadStatusBar();
            }
            else
            {
                List<NonResidentObj> result = (List<NonResidentObj>)e.Result;
                if (result.Count != 0)
                {
                    LoadNonResidentListdata(result);
                    AutoComplete(result);
                }
                else
                {
                    UploadStatusBar();
                    //MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "smsNotFilter"));
                    //return;
                }
            }
        }
        #endregion

        #region Gửi yêu cầu Hủy thẻ
        /// <summary>
        /// CancelPersoNonResident
        /// hủy thẻ
        /// </summary>
        /// <param name="nonResident"></param>
        private void CancelPersoNonResident(NonResident nonResident)
        {
            if (MessageBoxManager.ShowQuestionMessageBox(this, MessageValidate.GetMessage(rm, "smsQuestionYesNoDeletePersoNonResident")) == System.Windows.Forms.DialogResult.Yes)
            {
                if (!cancelPersoNonResident.IsBusy)
                {
                    AddOrUpdateNonResident = ToEntity(nonResident);
                    cancelPersoNonResident.RunWorkerAsync();
                }
            }

        }
        /// <summary>
        /// OnCancelPersoNonResidentWorkerDoWork
        /// hủy thẻ,
        /// cập nhật serialnumber=default
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCancelPersoNonResidentWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = (int)Status.SUCCESS == NonResidentFactory.Instance.GetChannel().updateNonResidentBySerialnumberAndDateTime(storageService.CurrentSessionId, AddOrUpdateNonResident);
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
        /// OnCancelPersoNonResidentWorkerCompleted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCancelPersoNonResidentWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "smsErrorCancelCard"));
                return;
            }
            if ((bool)e.Result)
            {
                PostAction = DialogPostAction.SUCCESS;
                LoadNonResidentList();
                return;
            }
            else
            {
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "smsErrorCancelCard"));
                return;
            }
        }
        #endregion

        #endregion
        /// <summary>
        /// ToEntity
        /// </summary>
        /// <param name="nonResident"></param>
        /// <returns></returns>
        private NonResident ToEntity(NonResident nonResident)
        {
            NonResident nonResidentNew = new NonResident();
            nonResidentNew.serialNumber = nonResident.serialNumber;
            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            //try
            //{
                DateTime inputtime = start.AddMilliseconds(Convert.ToUInt64(nonResident.inputTime)).ToLocalTime();
                String dtinPutStr = inputtime.ToString("yyyy-MM-dd HH:mm:ss");
                nonResidentNew.inputTime = dtinPutStr;
            //}catch(Exception e)
            //{
            //    nonResidentNew.inputTime = nonResident.inputTime;
            //}

            DateTime dateEnd = new DateTime(1972, 2, 2, 0, 0, 0, DateTimeKind.Utc);//hủy thẻ
            String dtOutPutStr = dateEnd.ToString("yyyy-MM-dd HH:mm:ss");
            nonResidentNew.outputTime = dtOutPutStr;
            return nonResidentNew;
        }

        /// <summary>
        /// add list nonresident
        /// gán danh sách tên khách vãng lai cho ô tìm kiếm theo tên
        /// </summary>
        /// <param name="nonResidentList"></param>
        public void AutoComplete(List<NonResidentObj> nonResidentList)
        {
            tbxMemberName.AutoCompleteMode = AutoCompleteMode.Suggest;
            tbxMemberName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
            for (int i = 0; i < nonResidentList.Count; i++)
            {
                coll.Add(nonResidentList[i].nonResident.name);
            }
            tbxMemberName.AutoCompleteCustomSource = coll;
        }

       
        /// <summary>
        /// check status card nonresident
        /// kiểm tra trạng thái của thẻ
        /// </summary>
        /// <param name="nonResidentList"></param>
        /// <param name="status"></param>
        private void CheckLoadNonResident(List<NonResidentObj> nonResidentList, bool status)
        {
            if (nonResidentList == null)
            {
                return;
            }
            else
            {
                List<NonResidentObj> nonResidentListnew = new List<NonResidentObj>();
                if (status)
                {
                    //chưa hủy thẻ
                    for (int i = 0; i < nonResidentList.Count; i++)
                    {
                        if (!nonResidentList[i].nonResident.serialNumber.Equals("00000000"))
                        {
                            nonResidentListnew.Add(nonResidentList[i]);
                        }
                    }
                }
                else
                {
                    //đã hủy thẻ
                    for (int i = 0; i < nonResidentList.Count; i++)
                    {
                        if (nonResidentList[i].nonResident.serialNumber.Equals("00000000"))
                        {
                            nonResidentListnew.Add(nonResidentList[i]);
                        }
                    }
                }
                AutoComplete(nonResidentListnew);
                LoadNonResidentListdata(nonResidentListnew);
            }
        }

        public void AutoRefreshWhenChangeTab() {
            rbtnNotPersoCard.Enabled = rbtnPersoCard.Enabled = rbtnAllCard.Enabled = this.tbxMemberName.Enabled = true;
            rbtnAllCard.Checked = true;
            LoadNonResidentList();
        }

        #region Hiển thị thông tin của khách vãng lai
        /// <summary>
        /// show nonresident list
        /// </summary>
        /// <param name="result"></param>
        public void LoadNonResidentListdata(List<NonResidentObj> result)
        {
            dtbNonResidentList.Clear();
            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            int index = 0;

            for (int i = 0; i < result.Count; i++)
            {
                DataRow row = dtbNonResidentList.NewRow();
                row.BeginEdit();
                index = i + 1;
                row[colOrderNum.DataPropertyName] = index;
                row[colMemberId.DataPropertyName] = result[i].nonResident.id;
                row[colSerialNumber.DataPropertyName] = result[i].nonResident.serialNumber;
                row[colFullName.DataPropertyName] = result[i].nonResident.name;

                row[colPositionPartaker.DataPropertyName] = result[i].nonResident.nonResidentPosition;
                row[colOrgPartaker.DataPropertyName] = result[i].nonResident.nonResidentOrganization;

                row[colIdentityCard.DataPropertyName] = result[i].nonResident.identityCard;
                row[colIdentityCardIssue.DataPropertyName] = result[i].nonResident.identitycardIssue;
                row[colPhoneNo.DataPropertyName] = result[i].nonResident.phonenumber;

                //hinh
                if (result[i].dataImageFace != null)
                {
                    row[colImageFace.DataPropertyName] = result[i].dataImageFace;
                }
                if (result[i].dataImageIdentityCard != null)
                {
                    row[colImageIdentityCard.DataPropertyName] = result[i].dataImageIdentityCard;
                }

                row[colAddress.DataPropertyName] = result[i].nonResident.temporaryAddress;
                row[colToOrg.DataPropertyName] = result[i].nonResident.orgName;
                if (result[i].nonResident.birthday != null && result[i].nonResident.birthday != "")
                {
                    DateTime birthday = start.AddMilliseconds(Convert.ToUInt64(result[i].nonResident.birthday)).ToLocalTime();
                   // string sysFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;

                    row[colBirthDate.DataPropertyName] = birthday.ToString(sysFormatDate);
                }
                if (result[i].nonResident.identityCardIssueDate != null && result[i].nonResident.identityCardIssueDate != "")
                {
                    DateTime identityCardIssueDate = start.AddMilliseconds(Convert.ToUInt64(result[i].nonResident.identityCardIssueDate)).ToLocalTime();
                    //string sysFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;

                    row[colIdentityCardDate.DataPropertyName] = identityCardIssueDate.ToString(sysFormatDate);
                }

                DateTime endDate = start.AddMilliseconds(Convert.ToUInt64(result[i].nonResident.outputTime)).ToLocalTime();
                DateTime datedefault = new DateTime(1971, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                DateTime datedefault2 = new DateTime(1972, 2, 2, 0, 0, 0, DateTimeKind.Utc);
                int compareDateEnd = DateTime.Compare(endDate, datedefault);
                int compareDateEnd2 = DateTime.Compare(endDate, datedefault2);
                if (compareDateEnd == 0)
                {
                    row[colOutTime.DataPropertyName] = updating;
                }
                else
                {
                    row[colOutTime.DataPropertyName] = endDate.ToString("HH:mm");
                }

                if (compareDateEnd2 == 0)
                {
                    row[colOutTime.DataPropertyName] = cancelled;
                }
                if (result[i].nonResident.serialNumber.Equals("00000000"))
                {
                    row[colPersoStatus.DataPropertyName] = cancelled;
                }
                else
                {
                    row[colPersoStatus.DataPropertyName] = updating;
                }

                if (result[i].nonResident.inputTime != null && result[i].nonResident.inputTime != "")
                {
                    DateTime inputtime = start.AddMilliseconds(Convert.ToUInt64(result[i].nonResident.inputTime)).ToLocalTime();
                    //  row[colPersoStatus.DataPropertyName] = "Đang hoạt động";
                    //string sysFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;

                    row[colDate.DataPropertyName] = inputtime.ToString(sysFormatDate);
                    row[colInputTime.DataPropertyName] = inputtime.ToString("HH:mm");
                }
                row.EndEdit();
                dtbNonResidentList.Rows.Add(row);
            }
            if (dgvNonResident.Rows.Count > 0)
            {
                //focur the first row in table
                //20170304 #Bug Fix- My Nguyen Start
                //có dữ liệu moi hiene thị nút xóa 
                // btnUpdate.Enabled =  btnCancel.Enabled = 
                SetEnableds(false);
                btnExportToExcel.Enabled = true;
                //20170304 #Bug Fix- My Nguyen End
                dgvNonResident.Rows[0].Selected = true;


                int record = dgvNonResident.Rows.Count;

                pagerPanel.ShowNumberOfRecords(sum, record, take, currentPageIndex);

                //20170307 #Bug Fix- My Nguyen End

            }
            else
            {
                UploadStatusBarHavePagePanel();
            }
        }
        #endregion

        #region CAB events
        [CommandHandler(NonResidentCommandName.ShowManageCardNonResident)]
        public void ShowManageCardNonResidentMainHandler(object s, EventArgs e)
        {
            UsrManageCardNonResident uc = workItem.Items.Get<UsrManageCardNonResident>(NonResidentCommandName.MenuManageCardNonResidentItem);
            if (uc == null)
            {
                uc = workItem.Items.AddNew<UsrManageCardNonResident>(NonResidentCommandName.MenuManageCardNonResidentItem);
            }
            else if (uc.IsDisposed)
            {
                workItem.Items.Remove(uc);
                uc = workItem.Items.AddNew<UsrManageCardNonResident>(NonResidentCommandName.MenuManageCardNonResidentItem);
            }

            workItem.Workspaces[WorkspaceName.MainWorkspace].Show(uc);
            uc.Parent.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(uc.rm, MenuNames.MenuManageCardNonResidentItem);
        }
        #endregion

        #region  Button Event's 
        /// <summary>
        /// click btn reload
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButtonReloadClicked(object sender, EventArgs e)
        {
            rbtnNotPersoCard.Enabled = rbtnPersoCard.Enabled = rbtnAllCard.Enabled = this.tbxMemberName.Enabled = true;
            rbtnAllCard.Checked = true;
            LoadNonResidentList();

        }
        /// <summary>
        /// get info nonresident
        /// </summary>
        /// <returns></returns>
        public NonResidentObj getNonResident()
        {
            NonResidentObj nonResidentNew = new NonResidentObj();

            // Get selected rows
            var selectedRows = dgvNonResident.SelectedRows;
            int rowsCount = selectedRows.Count;

            if (rowsCount == 0)
            {
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessSelect(rm, "smsPleaseClickChooseInfo"));
                return nonResidentNew;
            }
            else
            {
                //lấy tên khách vãng lai cần hủy thẻ
                String name = selectedRows[0].Cells[colFullName.Name].Value.ToString();
                String serialNumber = selectedRows[0].Cells[colSerialNumber.Name].Value.ToString();
                cardchip = serialNumber;

                for (int i = 0; i < nonResidentList.Count; i++)
                {
                    if (nonResidentList[i].nonResident.name.Equals(name))
                    {
                        nonResidentNew = nonResidentList[i];
                        break;
                    }
                }
                return nonResidentNew;
            }
        }

        /// <summary>
        /// click btn update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnUpdatePersoCard_Click(object sender, EventArgs e)
        {
            //NonResident nonResidentNew = getNonResident();
            NonResidentObj nonResidentNew = getNonResident();
            if (cardchip.Equals("00000000"))
            {//thẻ này đã được hủy vui lòng chọn thẻ khác
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "canceledCardNonresident"));
                return;
            }
            else if (nonResidentNew != null)
            {
                NonResidentObj nonResidentObjnew = new NonResidentObj();
                nonResidentObjnew = nonResidentNew;
                FrmUpdateNonResident frmUpdateNonResident = new FrmUpdateNonResident(nonResidentObjnew, true);
                workItem.SmartParts.Add(frmUpdateNonResident);
                frmUpdateNonResident.ShowDialog();
                workItem.SmartParts.Remove(frmUpdateNonResident);

                LoadNonResidentList();
            }
            else
            {
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "smsErrorOveriewInfoCard"));
            }
        }
        /// <summary>
        /// click btn cancelperso
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnCancelPerso_Click(object sender, EventArgs e)
        {
            NonResidentObj nonResidentNewObj = getNonResident();

            if (cardchip.Equals("00000000"))
            {//thẻ này đã được hủy vui lòng chọn thẻ khác
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "canceledCardNonresident"));
                return;
            }
            else if (nonResidentNewObj != null)
            {
                NonResident nonResidentNew = nonResidentNewObj.nonResident;
                if (nonResidentNew != null)
                    CancelPersoNonResident(nonResidentNew);
                else
                    MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "smsErrorCancelCard"));
            }
        
            else
            {
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "smsErrorCancelCard"));
            }
        }
        #endregion

        #region Chuẩn bị dữ liệu xuất file excel
        //20170304 #Bug Fix- My Nguyen Start
        /// <summary>
        /// lay du dlieu tu server cho export data
        /// </summary>
        /// <param name="totalpage">tong so trang</param>
        /// <returns></returns>
        private void GetDataFOrExport()
        {

            // query lan dau de lay du lieu va so luong records
            string theDateIn = dtpDateIn.Value.ToString("yyyy-MM-dd");
            string theDateIn2 = dtpDateIn2.Value.ToString("yyyy-MM-dd");
            NonResidentStatisticDetailObj nonResidentStatisticDetailObjNew = new NonResidentStatisticDetailObj();
            try
            {
                int start = 0;
                int end = take;
                nonResidentStatisticDetailObjNew = NonResidentStatisticsFactory.Instance.GetChannel().getListNonresidentByDate(StorageService.CurrentSessionId, start, end, theDateIn, theDateIn2);
            }
            catch (Exception ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "TimeOutExceptionMessage"));
            }

            //   CommonDataGridView dataExport = new CommonDataGridView();
            if (nonResidentStatisticDetailObjNew != null)
            {

                // add data lan dau tien
                PrepareDataToExport(nonResidentStatisticDetailObjNew.nonResidentObjs);

                //phân trang
                int totalRecords = Convert.ToInt32(nonResidentStatisticDetailObjNew.sum);

                //lay them du lieu neu khong du vi tong so record lon hon so take (take = 20) trong 1 trang
                if (totalRecords > take)
                {
                    int numberPage = (totalRecords / take) + ((totalRecords % take > 0) ? 1 : 0);
                    for (int i = 1; i < numberPage; i++)
                    {
                        int start = i * take;
                        int end = take;
                        nonResidentStatisticDetailObjNew = NonResidentStatisticsFactory.Instance.GetChannel().getListNonresidentByDate(StorageService.CurrentSessionId, start, end, theDateIn, theDateIn2);
                        PrepareDataToExport(nonResidentStatisticDetailObjNew.nonResidentObjs);
                    }
                }

            }

        }

        /// <summary>
        ///  add du lieu vao datagridview
        /// </summary>
        /// <param name="datagridview"></param>
        /// <param name="data"></param>
        private void PrepareDataToExport(List<NonResidentObj> result)
        {
            int index = table4Export.Rows.Count;
            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            for (int i = 0; i < result.Count; i++)
            {
                DataRow row = table4Export.NewRow();
                row.BeginEdit();
                index += 1;
                row[colOrderNum.DataPropertyName] = index;
                row[colMemberId.DataPropertyName] = result[i].nonResident.id;
                row[colSerialNumber.DataPropertyName] = result[i].nonResident.serialNumber;
                row[colFullName.DataPropertyName] = result[i].nonResident.name;

                row[colPositionPartaker.DataPropertyName] = result[i].nonResident.nonResidentPosition;
                row[colOrgPartaker.DataPropertyName] = result[i].nonResident.nonResidentOrganization;

                row[colIdentityCard.DataPropertyName] = result[i].nonResident.identityCard;
                row[colIdentityCardIssue.DataPropertyName] = result[i].nonResident.identitycardIssue;
                row[colPhoneNo.DataPropertyName] = result[i].nonResident.phonenumber;

                //hinh
                if (result[i].dataImageFace != null)
                {
                    row[colImageFace.DataPropertyName] = result[i].dataImageFace;
                }
                if (result[i].dataImageIdentityCard != null)
                {
                    row[colImageIdentityCard.DataPropertyName] = result[i].dataImageIdentityCard;
                }

                row[colAddress.DataPropertyName] = result[i].nonResident.temporaryAddress;
                row[colToOrg.DataPropertyName] = result[i].nonResident.orgName;
                if (result[i].nonResident.birthday != null && result[i].nonResident.birthday != "")
                {
                    DateTime birthday = start.AddMilliseconds(Convert.ToUInt64(result[i].nonResident.birthday)).ToLocalTime();
                    string sysFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;

                    row[colBirthDate.DataPropertyName] = birthday.ToString(sysFormat);
                }
                if (result[i].nonResident.identityCardIssueDate != null && result[i].nonResident.identityCardIssueDate != "")
                {
                    DateTime identityCardIssueDate = start.AddMilliseconds(Convert.ToUInt64(result[i].nonResident.identityCardIssueDate)).ToLocalTime();
                    string sysFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;

                    row[colIdentityCardDate.DataPropertyName] = identityCardIssueDate.ToString(sysFormat);
                }

                DateTime endDate = start.AddMilliseconds(Convert.ToUInt64(result[i].nonResident.outputTime)).ToLocalTime();
                DateTime datedefault = new DateTime(1971, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                DateTime datedefault2 = new DateTime(1972, 2, 2, 0, 0, 0, DateTimeKind.Utc);
                int compareDateEnd = DateTime.Compare(endDate, datedefault);
                int compareDateEnd2 = DateTime.Compare(endDate, datedefault2);
                if (compareDateEnd == 0)
                {
                    row[colOutTime.DataPropertyName] = updating;
                }
                else
                {
                    row[colOutTime.DataPropertyName] = endDate.ToString("HH:mm");
                }

                if (compareDateEnd2 == 0)
                {
                    row[colOutTime.DataPropertyName] = cancelled;
                }
                if (result[i].nonResident.serialNumber.Equals("00000000"))
                {
                    row[colPersoStatus.DataPropertyName] = cancelled;
                }
                else
                {
                    row[colPersoStatus.DataPropertyName] = updating;
                }

                if (result[i].nonResident.inputTime != null && result[i].nonResident.inputTime != "")
                {
                    DateTime inputtime = start.AddMilliseconds(Convert.ToUInt64(result[i].nonResident.inputTime)).ToLocalTime();
                    //  row[colPersoStatus.DataPropertyName] = "Đang hoạt động";
                    string sysFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;

                    row[colDate.DataPropertyName] = inputtime.ToString(sysFormat);
                    row[colInputTime.DataPropertyName] = inputtime.ToString("HH:mm");
                }
                row.EndEdit();
                table4Export.Rows.Add(row);
            }
        }
        //20170304 #Bug Fix  - My Nguyen End
        /// <summary>
        /// click export excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            DateTime datefrom = dtpDateIn.Value.Date;
            DateTime dateto = dtpDateIn2.Value.Date;

            String name = MessageValidate.GetMessage(rm, "lbltitleLabelManegaNonrisedentinout") + "_" + datefrom.ToString("dd-MM-yyyy") + "_" + dateto.ToString("dd-MM-yyyy");

            string filePath = ControlExtMethods.ShowSaveFileDialog(MessageValidate.GetMessage(rm, "smsChooseFileExport"), name, CategorizeExcel.Categorize);
            if (filePath != null)
            {
                try
                {
                    // show du lieu truoc do trong table
                    table4Export.Rows.Clear();
                    // tao du lieu moi
                    GetDataFOrExport();

                    //export excel
                    ConfigExportFileModel configExportFile = new ConfigExportFileModel();
                    configExportFile.FilePath = filePath;
                    GemboxUtils.Instance.ExportDataGridToFileCustom(dataGridview4Export, configExportFile, 4);//tua de, xuat file
                    GemboxUtils.Instance.ExportDataGridToFile(dataGridview4Export.Rows.Count);//tua de, xuat file
                    GemboxUtils.Instance.AutoFix();

                    String lbltitleLabelManegaNonrisedentinout = MessageValidate.GetMessage(rm, "lbltitleLabelManegaNonrisedentinout");
                    GemboxUtils.Instance.AddHeader(lbltitleLabelManegaNonrisedentinout == null ? string.Empty : lbltitleLabelManegaNonrisedentinout);
                    int index = 3;

                    String value = "";
                    String cbxFilterByDate = MessageValidate.GetMessage(rm, "cbxFilterByDate");
                    String lblTo = MessageValidate.GetMessage(rm, "lblTo");
                    String filterday = datefrom.ToString("dd-MM-yyyy");
                    String filterday2 = dateto.ToString("dd-MM-yyyy");
                    String fitler = cbxFilterByDate + " " + filterday;
                    String fitler2 = lblTo + " " + filterday2;

                    value = (fitler == null ? string.Empty : fitler) + " " + (fitler2 == null ? string.Empty : fitler2);
                    GemboxUtils.Instance.AddCellCustom(index, 0, value == null ? string.Empty : value);
                    value = "";
                    try
                    {
                        GemboxUtils.Instance.Save();
                    }
                    catch (IOException x)
                    {
                        MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "fileExcelOpen"));
                    }
                    //end

                }
                catch (Exception ex)
                {
                    MessageBoxManager.ShowErrorMessageBox(this, ex.Message);
                    return;
                }
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "smsLinkFile") + filePath);
            }
        }
        #endregion

        #region Lọc theo tình trạng thẻ
        /// <summary>
        /// rbtnNotPerso_CheckChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnNotPerso_CheckChanged(object sender, EventArgs e)
        {
            if (rbtnNotPersoCard.Checked)
            {
                checkNotPersoCard = true;
                CheckLoadNonResident(nonResidentList, checkNotPersoCard);
            }
        }
        /// <summary>
        /// rbtnPerso_CheckChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnPerso_CheckChanged(object sender, EventArgs e)
        {
            if (rbtnPersoCard.Checked)
            {
                checkNotPersoCard = false;
                CheckLoadNonResident(nonResidentList, checkNotPersoCard);
            }
        }
        /// <summary>
        /// rbtnAllCard_CheckChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnAllCard_CheckChanged(object sender, EventArgs e)
        {
            if (rbtnAllCard.Checked)
            {
                //load danh sách mới
                //LoadNonResidentList();
                //hiển thị danh sách có sẵn

                if (nonResidentList != null)
                {
                    if (nonResidentList.Count != 0)
                    {
                        LoadNonResidentListdata(nonResidentList);
                    }
                }
                //else
                //{
                //    UploadStatusBar();
                //    //  MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "smsNotFilter"));
                //}
            }
        }
        #endregion

        #region Sự kiện với dgv
        /// <summary>
        /// set status showhide of bnt update, cancel
        /// </summary>
        /// <param name="status"></param>
        private void SetEnableds(bool status)
        {
            mniUpdate.Enabled = status;
            mniCancelPerso.Enabled = status;
            btnUpdate.Enabled = status;
            btnCancel.Enabled = status;
        }
        /// <summary>
        /// mouse down dgv
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvNonResident_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo info = dgvNonResident.HitTest(e.X, e.Y);
                if (info.RowIndex != -1)
                {
                    if (info.RowIndex >= 0 && info.ColumnIndex >= 0)
                    {
                        if (!dgvNonResident.SelectedRows.Contains(dgvNonResident.Rows[info.RowIndex]))
                        {
                            foreach (DataGridViewRow row in dgvNonResident.SelectedRows)
                            {
                                row.Selected = false;
                            }
                            dgvNonResident.Rows[info.RowIndex].Selected = true;

                            //20170307 #Bug Fix- My Nguyen Start
                            //nếu là cuộc họp tự thêm mới cho chỉnh sửa, xóa
                            String serialNumber = "";
                            try
                            {
                                serialNumber = dgvNonResident.Rows[info.RowIndex].Cells[colSerialNumber.Name].Value.ToString();
                            }
                            catch (Exception exc) { }
                            if (!serialNumber.Equals("00000000"))
                            {
                                SetEnableds(true);
                            }
                            else
                            {
                                SetEnableds(false);
                            }

                            //20170307 #Bug Fix- My Nguyen End
                        }
                    }
                    Rectangle r = dgvNonResident.GetCellDisplayRectangle(info.ColumnIndex, info.RowIndex, true);
                    cmsPersoRecord.Show((Control)sender, e.X, e.Y);
                }
            }
        }

        /// <summary>
        /// click dgv
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvNonResidentClicked(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex != -1)
            {
                workItem.SmartParts.Remove(frm);
                frm.Close();
                //// Get selected rows
                var selectedRows = dgvNonResident.SelectedRows;
                //int rowsCount = selectedRows.Count;
                //if (rowsCount == 0)
                //{
                //    //Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Failed, MessageValidate.GetMessSelect(rm, "cancelNonresident"))));
                //    return;
                //}
                //else 
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    int colViewImageClickIndex = dgvNonResident.Columns[colViewImage.Name].Index;
                    //18
                    if (e.ColumnIndex == colViewImageClickIndex)
                    {
                        try
                        {
                            //lấy tên khách vãng lai cần hủy thẻ
                            String ImageFace = selectedRows[0].Cells[colImageFace.Name].Value.ToString();
                            String ImageIdentityCard = selectedRows[0].Cells[colImageIdentityCard.Name].Value.ToString();
                            try
                            {
                                frm = new FrmShiftImage(ImageFace, ImageIdentityCard);
                            }
                            catch (Exception ex)
                            {
                                frm = new FrmShiftImage(ImageFace, ImageIdentityCard);
                            }
                            workItem.SmartParts.Add(frm);
                            int x = cbxFilterByPersoCardStatus.Parent.Location.X + cbxFilterByPersoCardStatus.Location.X;
                            int y = cbxFilterByPersoCardStatus.Parent.Location.Y + cbxFilterByPersoCardStatus.Parent.Height + 100;

                            frm.Location = new Point(x, y);
                            frm.Show();

                        }
                        catch (Exception ex)
                        {
                            // MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "cancelNonresident"))));
                        }
                    }
                    else
                    {
                        //20170307 #Bug Fix- My Nguyen Start
                        //nếu là cuộc họp tự thêm mới cho chỉnh sửa, xóa
                        String serialNumber = "";
                        try
                        {
                            serialNumber = dgvNonResident.Rows[rowIndex].Cells[colSerialNumber.Name].Value.ToString();
                        }
                        catch (Exception exc) { }
                        if (!serialNumber.Equals("00000000"))
                        {
                            SetEnableds(true);
                        }
                        else
                        {
                            SetEnableds(false);
                        }
                        //20170307 #Bug Fix- My Nguyen End
                    }
                }
            }
        }

        private void dgvNonResidentMouseLeave(object sender, EventArgs e)
        {
            workItem.SmartParts.Remove(frm);
            frm.Hide();
        }
        #endregion

        #region Sự kiện search
        /// <summary>
        /// click pagerpanel
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        private void pagerPanel_LinkLabelClicked(object s, LinkLabelClickedArgs e)
        {
            int i;
            if (e.LabelText.Equals(PagerPanel.LabelBackText))
            {
                currentPageIndex -= 1;
            }
            else if (e.LabelText.Equals(PagerPanel.LabelNextText))
            {
                currentPageIndex += 1;
            }
            else if (int.TryParse(e.LabelText, out i))
            {
                currentPageIndex = i;
            }
            else
            {
                return;
            }

            dtbNonResidentList.Rows.Clear();
            int skip = (currentPageIndex - 1) * take;
            rbtnAllCard.Checked = true;
            NonResidentStatisticDetailObj nonResidentStatisticDetailObjNew = LoadNonResidentListAtPage(skip, take);
            if (nonResidentStatisticDetailObjNew != null)
            {
                List<NonResidentObj> result = nonResidentStatisticDetailObjNew.nonResidentObjs;
                nonResidentList = result;
                LoadNonResidentListdata(result);
                pagerPanel.ShowNumberOfRecords(sum, result != null ? result.Count : 0, take, currentPageIndex);
                pagerPanel.UpdatePagingLinks(sum, take, currentPageIndex);
            }
            else
            {
                UploadStatusBarHavePagePanel();
                return;
            }
        }
        /// <summary>
        /// click btn showhide
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShowHide_Clicked(object sender, EventArgs e)
        {
            if (pnlFilterBox.Height > hiddenFilterBoxHeight)
            {
                pnlFilterBox.Height = hiddenFilterBoxHeight;
                btnShowHide.Text = btnShowHide.ToolTipText = MessageValidate.GetMessage(rm, "showSearchBox");
                btnShowHide.ToolTipText = MessageValidate.GetMessage(rm, "showSearchBox");
                btnShowHide.Image = global::CommonControls.Properties.Resources.ArrowDown_16x16;
            }
            else
            {
                pnlFilterBox.Height = startupFilterBoxHeight;
                btnShowHide.Text = btnShowHide.ToolTipText = MessageValidate.GetMessage(rm, "hiddenSearchBox");
                btnShowHide.ToolTipText = MessageValidate.GetMessage(rm, "hiddenSearchBox");
                btnShowHide.Image = global::CommonControls.Properties.Resources.ArrowUp_16x16;
            }
        }
        /// <summary>
        /// search name meeting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxMeetingNameSearchs_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataView dv = new DataView(dtbNonResidentList);
                //20170307 #Bug Fix- My Nguyen Start
                string data = FormatCharacterSearch.CheckValue(tbxMemberName.Text.Trim());
                dv.RowFilter = string.Format("FullName LIKE'%{0}%'", data);
                dgvNonResident.DataSource = dv;

                int record = dgvNonResident.Rows.Count;
                if (record > 0)
                {
                    pagerPanel.ShowNumberOfRecords(sum, record, take, currentPageIndex);
                }
                else
                {
                    UploadStatusBarHavePagePanel();
                }
                //20170307 #Bug Fix- My Nguyen End
            }
            catch (Exception ex)
            {
            }
        }
        #endregion
    }
}
