using System;
using System.Data;
using Microsoft.Practices.CompositeUI.Commands;
using CommonHelper.Constants;
using CommonHelper.Utils;
using CommonControls;
using sWorldModel.Exceptions;
using CommonControls.Custom;
using System.Resources;
using Microsoft.Practices.CompositeUI;
using sWorldModel;
using sMeetingComponent.Constants;
using sMeetingComponent.Model;
using sMeetingComponent.Factory;
using System.ServiceModel;
using System.ComponentModel;
using System.Linq;
using System.Collections.Generic;
using CommonHelper.Config;
using System.Windows.Forms;
using System.Drawing;
using ClientModel.Utils;
using ClientModel.Model;
using System.IO;
using sMeetingComponent.Model.CustomObj.ContactForWorkObj;

namespace sMeetingComponent.WorkItems.ContactForWork
{
    public partial class UsrContactForWordStatistics : CommonUserControl
    {

        #region Properties
        public string sysFormatDate;
        int take = Enums.TAKE;
        int sum = 0;

        private DateTime dateto;
        private DateTime dateTos;
        private int currentPageIndex = 1;
        private const int hiddenFilterBoxHeight = 1;
        private int startupFilterBoxHeight;
        public static long meetingId = long.MinValue;

        SmeetingContactStatisticObj smeetingContactStatisticObj;
        List<SmeetingContactCount> smeetingContactCountList;
        List<SmeetingContactCount> SmeetingContactCountExlist;

        private DataTable dtbSmeetingContactStatisticObjList;
        private DataTable table4Export = null;

        private BackgroundWorker loadSmeetingContactStatisticObjList;
        private BackgroundWorker bgwLoadOrganizationList;

        public List<OrganizationMeeting> organizationList;
        public List<OrganizationMeeting> organizationListCbx;
        long organizationMeetingId = -1;
        String nameMeeting = "all";
        String updating = "updating";

        private MeetingComponentWorkItem workItem;
        private ResourceManager rm;
        public DialogPostAction PostAction { get; private set; }
        [ServiceDependency]
        public MeetingComponentWorkItem WorkItem
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
        /// <summary>
        /// UsrContactForWordStatistics
        /// </summary>
        public UsrContactForWordStatistics()
        {
            InitializeComponent();
            InitDataTableSmeetingContactStatisticObjList();
            sysFormatDate = UsrListMeeting.formatDateTime();
            RegisterEvent();
        }
        #endregion

        /// <summary>
        /// InitDataTableSmeetingContactStatisticObjList
        /// </summary>
        private void InitDataTableSmeetingContactStatisticObjList()
        {
            dtbSmeetingContactStatisticObjList = new DataTable();
            dtbSmeetingContactStatisticObjList.Columns.Add(colSTT.DataPropertyName);
            dtbSmeetingContactStatisticObjList.Columns.Add(colOrgMeetingId.DataPropertyName);
            dtbSmeetingContactStatisticObjList.Columns.Add(colOrganizationMeetingName.DataPropertyName);
            dtbSmeetingContactStatisticObjList.Columns.Add(colNumberPeopleInvation.DataPropertyName);
            dgvAttendMeetingStatisticList.DataSource = dtbSmeetingContactStatisticObjList;

            //20170304 #Bug Fix- My Nguyen Start
            // for export
            table4Export = new DataTable();
            table4Export.Columns.Add(colSTT.DataPropertyName);
            table4Export.Columns.Add(colOrgMeetingId.DataPropertyName);
            table4Export.Columns.Add(colOrganizationMeetingName.DataPropertyName);
            table4Export.Columns.Add(colNumberPeopleInvation.DataPropertyName);
            dataGridview4Export.DataSource = table4Export;
            //20170304 #Bug Fix- My Nguyen End

        }

        /// <summary>
        /// đăng ký sự kiện
        /// RegisterEvent
        /// </summary>
        private void RegisterEvent()
        {
            CreateBackgroundWorkerEvent();

            btnShowHide.Click += btnShowHide_Clicked;
            btnReload.Click += OnButtonReloadClicked;
            dgvAttendMeetingStatisticList.MouseDown += dgvAttendMeetingStatisticLists_MouseDown;
            dgvAttendMeetingStatisticList.CellClick += dgvAttendMeetingStatisticLists_Clicked;
            btnExportToExcel.Click += btnExportToExcel_Click;
            pagerPanel1.LinkLabelClicked += pagerPanel_LinkLabelClicked;

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
            pagerPanel1.StorageService = storageService;
            startupFilterBoxHeight = pnlFilterBox.Height;
            pagerPanel1.LoadLanguage();

            SetLanguages();

            LoadOrganizationList();

            //20170304 #Bug Fix- My Nguyen Start
            LoadSmeetingContactStatisticObjList();
            dateto = this.dtpDateIn.Value.Date;
            dateTos = this.dtpDateIn2.Value.Date;
            //20170304 #Bug Fix- My Nguyen End
        }

        #region Language
        /// <summary>
        /// SetLanguages
        /// </summary>
        private void SetLanguages()
        {
            this.colSTT.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colSTT.Name);
            this.colOrgMeetingId.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colOrgMeetingId.Name);
            this.colOrganizationMeetingName.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colOrganizationMeetingName.Name);
            this.colInfo.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colInfo.Name);
            //20170307 #Bug Fix- My Nguyen start
            this.dataGridViewTextBoxColumn2.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colSTT.Name);
            this.dataGridViewTextBoxColumn3.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colOrganizationMeetingName.Name);

            //20170307 #Bug Fix- My Nguyen End
            this.btnShowHide.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnShowHide.Name);
            this.btnExportToExcel.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnExportToExcel.Name);
            this.btnReload.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnReload.Name);

            string updatestr = MessageValidate.GetMessage(rm, "updating");
            if (updatestr != null)
            {
                updating = updatestr;

                if (updating.Equals("") || updating.Equals("LanguagesError"))
                {
                    updating = "updating";
                }
            }
        }
        #endregion

        #region bgWorker
        /// <summary>
        /// CreateBackgroundWorkerEvent
        /// </summary>
        private void CreateBackgroundWorkerEvent()
        {
            bgwLoadOrganizationList = new BackgroundWorker();
            bgwLoadOrganizationList.WorkerSupportsCancellation = true;
            bgwLoadOrganizationList.DoWork += LoadOrganizationListWorkerDoWork;
            bgwLoadOrganizationList.RunWorkerCompleted += LoadOrganizationListRunWorkerCompleted;

            //18: Thống kê LIÊN HỆ CÔNG TÁC Lấy số lượng người đến liên hệ
            loadSmeetingContactStatisticObjList = new BackgroundWorker();
            loadSmeetingContactStatisticObjList.WorkerSupportsCancellation = true;
            loadSmeetingContactStatisticObjList.DoWork += OnLoadSmeetingContactStatisticObjWorkerDoWork;
            loadSmeetingContactStatisticObjList.RunWorkerCompleted += OnLoadSmeetingContactStatisticObjWorkerCompleted;
        }

        #region Load danh sách đơn vị
        /// <summary>
        /// CreateBackgroundWorkerEvent
        /// </summary>
        private void LoadOrganizationList()
        {
            if (!bgwLoadOrganizationList.IsBusy)
            {
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
                e.Result = organizationList = OrganizationMeetingFactory.Instance.GetChannel().getOrganization(storageService.CurrentSessionId);
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
                //personAttendObjItem.meetingName = "-Tất cả-";
                //personAttendObjItem.meetingId = -1;
                organizationListCbx = new List<OrganizationMeeting>();
                organizationListCbx.Add(organizationMeetingItem);

                List<OrganizationMeeting> result = (List<OrganizationMeeting>)e.Result;
                if (result.Count != 0)
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        if (result[i].typeOrg == OrgEnum.ORG_SUB_ORG || result[i].typeOrg == OrgEnum.ORG_ORG)
                        {
                            organizationListCbx.Add(result[i]);
                        }
                    }
                }

                cbxNameOrgSearch.Enabled = true;
                cbxNameOrgSearch.DataSource = organizationListCbx.ToList();
                cbxNameOrgSearch.ValueMember = "id";
                cbxNameOrgSearch.DisplayMember = "name";//hiển thị
                cbxNameOrgSearch.SelectedIndex = 0;
            }
        }
        #endregion

        #region Load danh sách thống kê số lượng người tham dự cuộc họp
        /// <summary>
        /// load list statictis based on (start, end, dateFrom, dateTo, organizationMeetingId);
        /// danh sách thống kê
        /// dự vào vị trí bắt đầu, số record cần hiển thị
        /// orgid : đơn vị cần lọc
        /// namemeeting ? all : name
        /// nếu all: hiển thị tất cả các cuộc họp của đơn vị đó
        /// Hiện tại không lọc theo name
        /// nên để mặc định namemeeting = all
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public SmeetingContactStatisticObj LoadSmeetingContactStatisticObjAtPage(int start, int end)
        {
            String dateFrom = dateto.ToString("yyyy-MM-dd 00:00:00");
            String dateTo = dateTos.ToString("yyyy-MM-dd 00:00:00");

            SmeetingContactStatisticObj smeetingContactStatisticObjNew = new SmeetingContactStatisticObj();
            try
            {
                smeetingContactStatisticObjNew = ContactForWorkFactory.Instance.GetChannel().getListSmeetingContactStatisticStatisticByDateAndOrgId(StorageService.CurrentSessionId, start, end, dateFrom, dateTo, organizationMeetingId);
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
            return smeetingContactStatisticObjNew;
        }
        #endregion

        #region Gửi yêu cầu lấy danh sách thống kê số lượng người tham dự cuộc họp
        /// <summary>
        /// LoadSmeetingContactStatisticObjList
        /// </summary>
        private void LoadSmeetingContactStatisticObjList()
        {
            if (ValidateData())
            {
                if (!loadSmeetingContactStatisticObjList.IsBusy)
                {
                    dtbSmeetingContactStatisticObjList.Rows.Clear();
                    pagerPanel1.ShowMessage(MessageValidate.GetMessage(rm, "smsLoading"));
                    loadSmeetingContactStatisticObjList.RunWorkerAsync();
                }
            }
            else
            {
                dtbSmeetingContactStatisticObjList.Rows.Clear();
            }
        }

        /// <summary>
        /// kiểm tra điều kiện lọc từ ngày đến ngày
        /// Validate Datatime : Starttime : EndTime 
        /// </summary>
        /// <returns></returns>
        private bool ValidateData()
        {
            dateto = this.dtpDateIn.Value.Date;
            dateTos = this.dtpDateIn2.Value.Date;
            int result = DateTime.Compare(dateto, dateTos);
            if (result < 0)
                return true;
            else if (result == 0)
                return true;
            else
            {
                //20170304 #Bug Fix- My Nguyen Start
                // MessageBoxManager.ShowErrorMessageBox(this, String.Format(MessageValidate.GetMessage(rm, "smsValidateDate"), MessageValidate.GetMessage(rm, "lblStartTime"), MessageValidate.GetMessage(rm, "lblEndTime")))));
                // MessageBoxManager.ShowErrorMessageBox(this, String.Format(MessageValidate.GetMessage(rm, "smsValidateDate"), MessageValidate.GetMessage(rm, "smsStartTime"), MessageValidate.GetMessage(rm, "smsEndTime")))));
                //khoong hien thi tin nhan thong bao ma hien thi o thanh pannelpage
                // MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "smsFilterDateSmeeting"));
                UploadStatusBar();
                //20170304 #Bug Fix- My Nguyen End
                return false;
            }
        }

        /// <summary>
        ///  get list number contact based on from Date to date
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoadSmeetingContactStatisticObjWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            int totalRecords = 0;
            int skip = 0;
            currentPageIndex = 1;
            List<SmeetingContactCount> result = new List<SmeetingContactCount>();

            try
            {
                e.Result = smeetingContactStatisticObj = LoadSmeetingContactStatisticObjAtPage(skip, take);
            }
            catch (Exception ex) { }
            finally
            {
                if (smeetingContactStatisticObj != null)
                {
                    //phân trang
                    sum = totalRecords = Convert.ToInt32(smeetingContactStatisticObj.sum);
                    result = smeetingContactCountList = smeetingContactStatisticObj.contactStatistics;
                    pagerPanel1.ShowNumberOfRecords(totalRecords, result != null ? result.Count : 0, take, currentPageIndex);
                    pagerPanel1.UpdatePagingLinks(totalRecords, take, currentPageIndex);
                }
                e.Result = result;
            }
        }

        //20170304 #Bug Fix- My Nguyen Start
        /// <summary>
        ///  Change statusbar : message not data
        /// không cho phân trang thi vẫn còn hiển thị thanh link, và không cho xuất exccel
        /// </summary>
        private void UploadStatusBar()
        {
            btnExportToExcel.Enabled = false;
            pagerPanel1.ShowMessage(MessageValidate.GetMessage(rm, "lblMessageNotData"));
            pagerPanel1.UpdatePagingLinks(0, 1, 0);
        }

        /// <summary>
        ///  change status bar: have pagepanel , but not data
        ///  cho phân trang thi vẫn còn hiển thị thanh link, và cho xuất exccel
        /// </summary>
        private void UploadStatusBarHavePagePanel()
        {
            pagerPanel1.ShowMessage(MessageValidate.GetMessage(rm, "lblMessageNotData"));
        }

        /// <summary>
        /// OnLoadSmeetingContactStatisticObjWorkerCompleted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoadSmeetingContactStatisticObjWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            if (e.Cancelled)
            {
                UploadStatusBar();
                // MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "SmsNotConnectData"));
                return;
            }
            if (e.Result == null)
            {
                UploadStatusBar();
                //  MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "smsNotFilter"));
                return;
            }
            else
            {
                List<SmeetingContactCount> result = (List<SmeetingContactCount>)e.Result;

                if (result.Count != 0)
                {
                    LoadSmeetingContactStatisticObjListdata(result);
                    // AutoComplete(result);
                }
                else
                {
                    UploadStatusBar();
                    //MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "smsNotFilter")); return;
                }
            }
        }
        //20170304 #Bug Fix- My Nguyen End
        #endregion

        #endregion

        #region Hiển thị thông tin số lượng người tham dự cuộc họp
        /// <summary>
        /// show info contact
        /// </summary>
        /// <param name="result"></param>
        public void LoadSmeetingContactStatisticObjListdata(List<SmeetingContactCount> result)
        {
            int index = 0;
            dtbSmeetingContactStatisticObjList.Clear();
            for (int i = 0; i < result.Count; i++)
            {
                DataRow row = dtbSmeetingContactStatisticObjList.NewRow();
                row.BeginEdit();
                index = i + 1;
                row[colSTT.DataPropertyName] = index;
                row[colOrgMeetingId.DataPropertyName] = result[i].orgId;
                row[colOrganizationMeetingName.DataPropertyName] = result[i].orgName;
                row[colNumberPeopleInvation.DataPropertyName] = result[i].sum;

                row.EndEdit();
                dtbSmeetingContactStatisticObjList.Rows.Add(row);
            }
            if (dgvAttendMeetingStatisticList.Rows.Count > 0)
            {
                btnExportToExcel.Enabled = true;
                //focur the first row in table
                dgvAttendMeetingStatisticList.Rows[0].Selected = true;
            }
            else
            {
                UploadStatusBarHavePagePanel();
                //  UploadStatusBar();
                //MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "smsNotFilter")); 
            }
        }
        #endregion

        #region CAB events
        [CommandHandler(MeetingCommandName.ShowMenuMeetingItemStatisticContactWork)]
        public void ShowSmeetingContactStatisticMainHandler(object s, EventArgs e)
        {
            UsrContactForWordStatistics uc = workItem.Items.Get<UsrContactForWordStatistics>(MeetingCommandName.MenuMeetingItemStatisticContactWork);
            if (uc == null)
            {
                uc = workItem.Items.AddNew<UsrContactForWordStatistics>(MeetingCommandName.MenuMeetingItemStatisticContactWork);
            }
            else if (uc.IsDisposed)
            {
                workItem.Items.Remove(uc);
                uc = workItem.Items.AddNew<UsrContactForWordStatistics>(MeetingCommandName.MenuMeetingItemStatisticContactWork);
            }
            workItem.Workspaces[WorkspaceName.MainWorkspace].Show(uc);
            uc.Parent.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(uc.rm, MenuNames.MenuMeetingItemStatisticContactWork);
        }
        #endregion

        #region  Event's 
        /// <summary>
        /// Event click : btn showhide
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
        /// Event click: dgv
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvAttendMeetingStatisticLists_Clicked(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int colInfoClicked = dgvAttendMeetingStatisticList.Columns[colInfo.Name].Index;
            if (rowIndex != -1)
            {
                //13
                if (e.ColumnIndex == colInfoClicked)
                {
                    btnInfo_Click(sender, e);
                }
            }
        }

        /// <summary>
        /// click btbInfo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnInfo_Click(object sender, EventArgs e)
        {
            // Get selected rows
            var selectedRows = dgvAttendMeetingStatisticList.SelectedRows;
            int rowsCount = selectedRows.Count;
            if (rowsCount == 0)
            {
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessSelect(rm, "smsPleaseClickChooseInfo"), MessageValidate.GetErrorTitle(rm));
                return;
            }
            else
            {
                try
                {
                    SmeetingContactCount SmeetingContactCountNew = new SmeetingContactCount();
                    //5/4/17 don vi to chuc lien he
                    String meetingIdStr = selectedRows[0].Cells[colOrgMeetingId.Name].Value.ToString();
                    long meetingId = Convert.ToInt64(meetingIdStr);

                    for (int i = 0; i < smeetingContactCountList.Count; i++)
                    {
                        if (smeetingContactCountList[i].orgId == meetingId)
                        {
                            SmeetingContactCountNew = smeetingContactCountList[i];
                            break;
                        }
                    }

                    //int total = Convert.ToInt32(personAttendObjNew.sum);

                    //hien thi thong tin len from 
                    FrmInfoContactForWordStatistics dialog = new FrmInfoContactForWordStatistics(dateto, dateTos, SmeetingContactCountNew);
                    workItem.SmartParts.Add(dialog);
                    dialog.ShowDialog();
                    //workItem.SmartParts.Remove(dialog);
                    //dialog.Dispose();
                }
                catch (Exception ex)
                {
                    // MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "smsPleaseClickChooseInfo"));
                }
            }
        }
        /// <summary>
        ///  mouse down : dgv
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvAttendMeetingStatisticLists_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo info = dgvAttendMeetingStatisticList.HitTest(e.X, e.Y);
                if (info.RowIndex != -1)
                {
                    if (info.RowIndex >= 0 && info.ColumnIndex >= 0)
                    {
                        if (!dgvAttendMeetingStatisticList.SelectedRows.Contains(dgvAttendMeetingStatisticList.Rows[info.RowIndex]))
                        {
                            foreach (DataGridViewRow row in dgvAttendMeetingStatisticList.SelectedRows)
                            {
                                row.Selected = false;
                            }
                            dgvAttendMeetingStatisticList.Rows[info.RowIndex].Selected = true;
                        }
                    }
                    Rectangle r = dgvAttendMeetingStatisticList.GetCellDisplayRectangle(info.ColumnIndex, info.RowIndex, true);
                    cmsPersoRecord.Show((Control)sender, e.X, e.Y);
                }
            }
        }

        /// <summary>
        /// click btn reload
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButtonReloadClicked(object sender, EventArgs e)
        {
            try
            {
                OrganizationMeeting organizationMeetingClick = (OrganizationMeeting)cbxNameOrgSearch.SelectedItem;
                organizationMeetingId = organizationMeetingClick.id;
            }
            catch (Exception er)
            {
                organizationMeetingId = -1;
            }
            nameMeeting = "";
            if (nameMeeting.Equals(""))
            {
                nameMeeting = "all";
            }
            LoadSmeetingContactStatisticObjList();
        }

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
            dtbSmeetingContactStatisticObjList.Rows.Clear();
            int skip = (currentPageIndex - 1) * take;
            int totalRecords = 0;

            SmeetingContactStatisticObj smeetingContactStatisticObjNew = LoadSmeetingContactStatisticObjAtPage(skip, take);
            if (smeetingContactStatisticObjNew != null)
            {
                List<SmeetingContactCount> result = smeetingContactStatisticObjNew.contactStatistics;
                LoadSmeetingContactStatisticObjListdata(result);

                // AutoComplete(result);
                smeetingContactCountList = result;
                totalRecords = Convert.ToInt32(sum);
                pagerPanel1.ShowNumberOfRecords(totalRecords, result != null ? result.Count : 0, take, currentPageIndex);
                pagerPanel1.UpdatePagingLinks(totalRecords, take, currentPageIndex);
            }
            else
            {
                //  pagerPanel1.ShowMessage(MessageValidate.GetMessage(rm, "lblMessageNotData"));
                //UploadStatusBar();
                UploadStatusBarHavePagePanel();
                //MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "smsNotFilter")); return; 
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
            String dateFrom = dateto.ToString("yyyy-MM-dd 00:00:00");
            String dateTo = dateTos.ToString("yyyy-MM-dd 00:00:00");

            // query lan dau de lay du lieu va so luong records
            SmeetingContactStatisticObj SmeetingContactStatisticObjnew = new SmeetingContactStatisticObj();
            try
            {
                int start = 0;
                int end = take;

                SmeetingContactStatisticObjnew = ContactForWorkFactory.Instance.GetChannel().getListSmeetingContactStatisticStatisticByDateAndOrgId(StorageService.CurrentSessionId, start, end, dateFrom, dateTo, organizationMeetingId);
            }
            catch (Exception ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "TimeOutExceptionMessage"));
            }

            //   CommonDataGridView dataExport = new CommonDataGridView();
            if (SmeetingContactStatisticObjnew != null)
            {
                //thông tin khách vãng lai tham dự họp
                SmeetingContactCountExlist = new List<SmeetingContactCount>();

                if (SmeetingContactStatisticObjnew.contactStatistics != null)
                    SmeetingContactCountExlist = SmeetingContactStatisticObjnew.contactStatistics;

                // add data lan dau tien
                PrepareDataToExport(SmeetingContactCountExlist);

                //phân trang
                int totalRecords = Convert.ToInt32(SmeetingContactStatisticObjnew.sum);

                //lay them du lieu neu khong du vi tong so record lon hon so take (take = 20) trong 1 trang
                if (totalRecords > take)
                {
                    int numberPage = (totalRecords / take) + ((totalRecords % take > 0) ? 1 : 0);
                    for (int i = 1; i < numberPage; i++)
                    {
                        //int start = i * take + 1;
                        int start = i * take;
                        int end = take;
                        SmeetingContactStatisticObjnew = ContactForWorkFactory.Instance.GetChannel().getListSmeetingContactStatisticStatisticByDateAndOrgId(StorageService.CurrentSessionId, start, end, dateFrom, dateTo, organizationMeetingId);
                        if (SmeetingContactStatisticObjnew != null)
                        {
                            //PrepareDataToExport(SmeetingContactStatisticObjnew.contactStatistics);

                            //thông tin khách vãng lai tham dự họp
                            SmeetingContactCountExlist = new List<SmeetingContactCount>();

                            if (SmeetingContactStatisticObjnew.contactStatistics != null)
                                SmeetingContactCountExlist = SmeetingContactStatisticObjnew.contactStatistics;

                            PrepareDataToExport(SmeetingContactCountExlist);
                        }
                    }
                }
            }
        }

        /// <summary>
        ///  add du lieu vao datagridview
        /// </summary>
        /// <param name="datagridview"></param>
        /// <param name="data"></param>
        private void PrepareDataToExport(List<SmeetingContactCount> result)
        {
            int index = table4Export.Rows.Count;
            for (int i = 0; i < result.Count; i++)
            {
                DataRow row = table4Export.NewRow();
                row.BeginEdit();
                index += 1;
                row[colSTT.DataPropertyName] = index;

                row[colOrgMeetingId.DataPropertyName] = result[i].orgId;
                row[colOrganizationMeetingName.DataPropertyName] = result[i].orgName;
                row[colNumberPeopleInvation.DataPropertyName] = result[i].sum;
                row.EndEdit();
                table4Export.Rows.Add(row);
            }
        }
        //20170304 #Bug Fix  - My Nguyen End

        /// <summary>
        /// EXPORT FILE EXCEL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            String organizationMeetingName = "";
            long organizationMeetingid = -1;
            try
            {
                OrganizationMeeting organizationMeetingClick = (OrganizationMeeting)cbxNameOrgSearch.SelectedItem;
                organizationMeetingid = organizationMeetingClick.id;
                organizationMeetingName = organizationMeetingClick.name;
            }
            catch (Exception ex) { }
            if (organizationMeetingid == -1)
                organizationMeetingName = "";
            String name = MessageValidate.GetMessage(rm, "lblRightAreaTitleListAttendaceContactForWork") + "_" + organizationMeetingName + "_" + dateto.ToString("dd-MM-yyyy") + "_" + dateTos.ToString("dd-MM-yyyy");
            string filePath = ControlExtMethods.ShowSaveFileDialog(MessageValidate.GetMessage(rm, "smsChooseFileExport"), name, "MS Excel (*.xls)|*.xls");
            if (filePath != null)
            {
                try
                {
                    // dgvAttendMeetingStatisticList.ExportToExcel(filePath);

                    // show du lieu truoc do trong table
                    table4Export.Rows.Clear();
                    // tao du lieu moi
                    GetDataFOrExport();

                    //excel cach 1
                    //dataGridview4Export.ExportToExcel(filePath);
                    //dataGridview4Export của commoncontrols custom

                    ////excel cach 3 dung thu vien ho tro
                    //NpoiUtilsExportExcel npoiUtils = new NpoiUtilsExportExcel();
                    //npoiUtils.CreateExcelFile(dataGridview4Export, filePath);

                    //excel cach 2
                    ConfigExportFileModel configExportFile = new ConfigExportFileModel();
                    configExportFile.FilePath = filePath;
                    if (organizationMeetingid == -1)
                    {
                        GemboxUtils.Instance.ExportDataGridToFileCustom(dataGridview4Export, configExportFile, 4);//tua de, xuat file

                    }
                    else
                        GemboxUtils.Instance.ExportDataGridToFileCustom(dataGridview4Export, configExportFile, 5);

                    GemboxUtils.Instance.AutoFixA4();
                    GemboxUtils.Instance.ExportDataGridToFile(dataGridview4Export.Rows.Count);
                    //GemboxUtils.Instance.ExportDataTableToFile(table4Export, configExportFile);//tua de, xuat file nhung file ngon ngu khong duoc
                    //GemboxUtils.Instance.ExportDataTableToFile(table4Export);//du lieu
                    //GemboxUtils.Instance.AddFooter();
                    //GemboxUtils.Instance.AutoFix();

                    GemboxUtils.Instance.AutoFitAdvancedColIndex(2);
                    int widthA4 = configExportFile.GetSizePageA4Height();

                    GemboxUtils.Instance.AutoFixWidthColIndexEnd(1, configExportFile.GetSizePageA4Height());//21000:29700 SizePageA4Width = 21000;

                    //custom
                    //export general information
                    String lblRightAreaTitleListAttendaceContactForWork = MessageValidate.GetMessage(rm, "lblRightAreaTitleListAttendaceContactForWork");
                    GemboxUtils.Instance.AddHeader(lblRightAreaTitleListAttendaceContactForWork == null ? string.Empty : lblRightAreaTitleListAttendaceContactForWork);
                    int index = 3;
                    String value = "";
                    if (organizationMeetingid != -1)
                    {
                        String lblGoverningOrganization = MessageValidate.GetMessage(rm, "lblGoverningOrganization");
                        value = (lblGoverningOrganization == null ? string.Empty : lblGoverningOrganization) + " " + (organizationMeetingName == null ? string.Empty : organizationMeetingName);
                        GemboxUtils.Instance.AddCellCustom(index, 0, value == null ? string.Empty : value);
                        value = "";
                        index++;
                    }

                    String cbxFilterByDate = MessageValidate.GetMessage(rm, "cbxFilterByDate");
                    String lblTo = MessageValidate.GetMessage(rm, "lblTo");
                    String filterday = dateto.ToString("dd-MM-yyyy");
                    String filterday2 = dateTos.ToString("dd-MM-yyyy");
                    String fitler = cbxFilterByDate + " " + filterday;
                    String fitler2 = lblTo + " " + filterday2;

                    value = (fitler == null ? string.Empty : fitler) + " " + (fitler2 == null ? string.Empty : fitler2);
                    GemboxUtils.Instance.AddCellCustom(index, 0, value == null ? string.Empty : value);
                    value = "";
                    //end custom
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
        //20170304 #Bug Fix- My Nguyen eND
        #endregion

    }
}
