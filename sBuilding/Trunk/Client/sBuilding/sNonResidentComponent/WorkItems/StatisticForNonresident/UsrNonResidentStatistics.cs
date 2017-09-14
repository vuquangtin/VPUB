using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Practices.CompositeUI.Commands;
using CommonHelper.Constants;
using CommonHelper.Utils;
using sWorldModel.Exceptions;
using System.Resources;
using Microsoft.Practices.CompositeUI;
using sWorldModel;
using System.ServiceModel;
using sNonResidentComponent.Constants;
using sNonResidentComponent.Factory;
using sNonResidenComponent.WorkItems;
using CommonControls;
using CommonControls.Custom;
using CommonHelper.Config;
using ClientModel.Model;
using ClientModel.Utils;
using System.IO;
using sExcelExportComponent.ClientModel.Enums;
using sNonResidentComponent.Model.CustomObj.Statistic;
using sMeetingComponent.Constants;

namespace sNonResidentComponent.WorkItems.StatisticForNonresident
{
    public partial class UsrNonResidentStatistics : CommonUserControl
    {
        #region Properties
        int take = Enums.TAKE;

        private DateTime dateFroms;
        private DateTime dateTos;
        int sum = 0;

        //List<NonResidentStatistic> nonResidentStatisticList;
        NonResidentStatisticObj nonResidentStatisticObj;
        private BackgroundWorker loadNonResidentStatistic;
        private DataTable table4Export = null;
        private DataTable dtbNonResidentList;

        private int currentPageIndex = 1;
        private const int hiddenFilterBoxHeight = 1;
        private int startupFilterBoxHeight;

        private ResourceManager rm;
        private NonResidentComponentWorkItem workItem;
        public DialogPostAction PostAction { get; private set; }
        [ServiceDependency]
        public NonResidentComponentWorkItem WorkItem
        {
            set { workItem = value; }
        }
        private ILocalStorageService storageService;
        [ServiceDependency]
        public ILocalStorageService StorageService
        {
            get { return storageService; }
            set { storageService = value; }
        }
        #endregion

        #region Contructors
        public UsrNonResidentStatistics()
        {
            InitializeComponent();
            InitDataTableNonResidentList();
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
            dtbNonResidentList.Columns.Add(colOrgId.DataPropertyName);
            dtbNonResidentList.Columns.Add(colNameOrg.DataPropertyName);
            dtbNonResidentList.Columns.Add(colNumberPeople.DataPropertyName);
            dgvNonResidentNew.DataSource = dtbNonResidentList;

            //20170304 #Bug Fix- My Nguyen Start
            // for export
            table4Export = new DataTable();

            table4Export.Columns.Add(colOrderNum.DataPropertyName);
            table4Export.Columns.Add(colOrgId.DataPropertyName);
            table4Export.Columns.Add(colNameOrg.DataPropertyName);
            table4Export.Columns.Add(colNumberPeople.DataPropertyName);

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
            dgvNonResidentNew.MouseDown += dgvNonResident_MouseDown;
            dgvNonResidentNew.CellClick += dgvNonResident_Clicked;
            btnReload.Click += OnButtonReloadClicked;
            btnExportToExcel.Click += btnExportToExcel_Click;
            btnShowHide.Click += btnShowHide_Clicked;
            tbxOrgName.TextChanged += tbxOrgName_TextChanged;
            pagerPanel.LinkLabelClicked += pagerPanel_LinkLabelClicked;
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

            LoadNonResidentStatisticList();
            dateFroms = this.dtpDateIn.Value.Date;
            dateTos = this.dtpDateIn2.Value.Date;
        }

        #region language
        /// <summary>
        /// SetLanguages
        /// </summary>
        private void SetLanguages()
        {
            this.colOrderNum.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colOrderNum.Name);
            this.colNameOrg.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colNameOrg.Name);
            this.colDate.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colDate.Name);
            this.colNumberPeople.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colNumberPeople.Name);
            this.colInfo.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colInfo.Name);

            //
            this.dataGridViewTextBoxColumn1.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colOrderNum.Name);
            this.dataGridViewTextBoxColumn3.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colNameOrg.Name);
            this.dataGridViewTextBoxColumn5.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colNumberPeople.Name);
            //

            this.btnShowHide.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnShowHide.Name);
            this.btnExportToExcel.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnExportToExcel.Name);
            this.btnReload.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnReload.Name);
            this.mniInfor.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.mniInfor.Name);
        }
        #endregion
        /// <summary>
        /// LoadNonResidentStatisticList
        /// </summary>
        private void LoadNonResidentStatisticList()
        {
            dateFroms = this.dtpDateIn.Value.Date;
            dateTos = this.dtpDateIn2.Value.Date;
            if (ValidateData(dateFroms, dateTos))
            {
                if (!loadNonResidentStatistic.IsBusy)
                {
                    dtbNonResidentList.Rows.Clear();
                    pagerPanel.ShowMessage(MessageValidate.GetMessage(rm, "smsLoading"));
                    loadNonResidentStatistic.RunWorkerAsync();
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
                return false;
            }
        }

        public void AutoRefreshWhenChangeTab() {
            LoadNonResidentStatisticList();
        }

        #region bgWorker
        /// <summary>
        /// CreateBackgroundWorkerEvent
        /// </summary>
        private void CreateBackgroundWorkerEvent()
        {
            //:8 STATICTIS THỐNG KÊ số lượng khách vãng lai đến
            loadNonResidentStatistic = new BackgroundWorker();
            loadNonResidentStatistic.WorkerSupportsCancellation = true;
            loadNonResidentStatistic.DoWork += OnLoadNonResidentStatisticWorkerDoWork;
            loadNonResidentStatistic.RunWorkerCompleted += OnLoadNonResidentStatisticWorkerCompleted;
        }

        #region LoadNonResidentAtPage : lấy danh sách số lượng khách vãng lai tham dự cuộc họp
        /// <summary>
        /// LoadNonResidentAtPage
        /// statictis : get list nonresident based on (start, end, dateFrom, dateTo);
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public NonResidentStatisticObj LoadNonResidentAtPage(int start, int end)
        {
            String dateFrom = dateFroms.ToString("yyyy-MM-dd HH:mm:ss");
            String dateTo = dateTos.ToString("yyyy-MM-dd HH:mm:ss");
            NonResidentStatisticObj nonResidentStatisticObjNew = new NonResidentStatisticObj();
            try
            {
                nonResidentStatisticObjNew = NonResidentStatisticsFactory.Instance.GetChannel().getListNonresidentStatisticByDate(StorageService.CurrentSessionId, start, end, dateFrom, dateTo);
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
            return nonResidentStatisticObjNew;
        }
        #endregion

        #region Gửi yêu cầu thống kê số lượng khách vãng lai
        /// <summary>
        /// get nonresident list based on from date to date
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoadNonResidentStatisticWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            int totalRecords = 0;
            int skip = 0;
            currentPageIndex = 1;
            List<NonResidentStatistic> result = null;
            try
            {
                e.Result = nonResidentStatisticObj = LoadNonResidentAtPage(skip, take);
            }
            catch (Exception ex) { }
            finally
            {
                if (nonResidentStatisticObj != null)
                {
                    sum = totalRecords = Convert.ToInt32(nonResidentStatisticObj.sum);
                    result = nonResidentStatisticObj.nonResidentStatistics;
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
            btnExportToExcel.Enabled = false;
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
        /// OnLoadNonResidentStatisticWorkerCompleted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoadNonResidentStatisticWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                UploadStatusBar();
                return;
            }
            if (e.Result == null)
            {
                UploadStatusBar();
                return;
            }
            else
            {
                List<NonResidentStatistic> result = (List<NonResidentStatistic>)e.Result;

                if (result.Count != 0)
                {
                    LoadNonResidentStatisticListdata(result);
                }
                else
                {
                    UploadStatusBar();
                    return;
                }
            }
        }
        #endregion

        #endregion

        #region HIển thị thông tin danh sách số lượng tham dự của khách vãng lai
        /// <summary>
        /// show nonresident list
        /// </summary>
        /// <param name="result"></param>
        public void LoadNonResidentStatisticListdata(List<NonResidentStatistic> result)
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
                row[colOrgId.DataPropertyName] = result[i].orgId;
                row[colNameOrg.DataPropertyName] = result[i].orgName;
                row[colNumberPeople.DataPropertyName] = result[i].number;
                row.EndEdit();
                dtbNonResidentList.Rows.Add(row);
            }
            if (dgvNonResidentNew.Rows.Count > 0)
            {
                btnExportToExcel.Enabled = true;
                //focur the first row in table
                dgvNonResidentNew.Rows[0].Selected = true;
            }
            else
            {
                UploadStatusBarHavePagePanel();
            }
        }
        #endregion

        #region CAB events
        [CommandHandler(NonResidentCommandName.ShowNonResidentStatistic)]
        public void ShowNonResidentStatisticMainHandler(object s, EventArgs e)
        {
            UsrNonResidentStatistics uc = workItem.Items.Get<UsrNonResidentStatistics>(NonResidentCommandName.MenuNonResidentStatisticItem);
            if (uc == null)
            {
                uc = workItem.Items.AddNew<UsrNonResidentStatistics>(NonResidentCommandName.MenuNonResidentStatisticItem);
            }
            else if (uc.IsDisposed)
            {
                workItem.Items.Remove(uc);
                uc = workItem.Items.AddNew<UsrNonResidentStatistics>(NonResidentCommandName.MenuNonResidentStatisticItem);
            }

            workItem.Workspaces[WorkspaceName.MainWorkspace].Show(uc);
            uc.Parent.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(uc.rm, MenuNames.MenuNonResidentStatisticItem);
        }
        #endregion

        #region  Event's 
        /// <summary>
        /// click btn reload
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButtonReloadClicked(object sender, EventArgs e)
        {
            LoadNonResidentStatisticList();
        }

        /// <summary>
        /// click btn info
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnInfo_Click(object sender, EventArgs e)
        {
            // Get selected rows
            var selectedRows = dgvNonResidentNew.SelectedRows;
            int rowsCount = selectedRows.Count;
            if (rowsCount == 0)
            {
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessSelect(rm, "smsPleaseClickChooseInfo"));
                return;
            }
            else
            {
                try
                {
                    //lấy tên khách vãng lai cần hủy thẻ
                    String name = selectedRows[0].Cells[colNameOrg.Name].Value.ToString();
                    String orgIdStr = selectedRows[0].Cells[colOrgId.Name].Value.ToString();
                    long orgId = Convert.ToInt64(orgIdStr);
                    String totalStr = selectedRows[0].Cells[colNumberPeople.Name].Value.ToString();
                    int total = Convert.ToInt32(totalStr);

                    //hien thi thong tin len from 
                    FrmInfoNonResidentStatistics dialog = new FrmInfoNonResidentStatistics(dateFroms, dateTos, orgId, total);
                    workItem.SmartParts.Add(dialog);
                    dialog.ShowDialog();
                    //workItem.SmartParts.Remove(dialog);
                    //dialog.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "smsPleaseClickChooseInfo"));
                }
            }
        }
        /// <summary>
        /// click dgv
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvNonResident_Clicked(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex != -1)
            {
                int colInfoClickIndex = dgvNonResidentNew.Columns[colInfo.Name].Index;
                //5
                if (e.ColumnIndex == colInfoClickIndex)
                    btnInfo_Click(sender, e);
            }
        }
        /// <summary>
        /// mousse down dgv
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvNonResident_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo info = dgvNonResidentNew.HitTest(e.X, e.Y);
                if (info.RowIndex != -1)
                {
                    if (info.RowIndex >= 0 && info.ColumnIndex >= 0)
                    {
                        if (!dgvNonResidentNew.SelectedRows.Contains(dgvNonResidentNew.Rows[info.RowIndex]))
                        {
                            foreach (DataGridViewRow row in dgvNonResidentNew.SelectedRows)
                            {
                                row.Selected = false;
                            }
                            dgvNonResidentNew.Rows[info.RowIndex].Selected = true;
                        }
                    }
                    Rectangle r = dgvNonResidentNew.GetCellDisplayRectangle(info.ColumnIndex, info.RowIndex, true);
                    cmsPersoRecord.Show((Control)sender, e.X, e.Y);
                }
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
        /// search name org
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxOrgName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataView dv = new DataView(dtbNonResidentList);

                //20170307 #Bug Fix- My Nguyen Start
                string data = FormatCharacterSearch.CheckValue(tbxOrgName.Text.Trim());

                dv.RowFilter = string.Format("NameOrg LIKE'%{0}%'", data);
                dgvNonResidentNew.DataSource = dv;

                int record = dgvNonResidentNew.Rows.Count;
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
                //dgvNonResidentNew.DataSource = new DataView();
            }
        }

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
            NonResidentStatisticObj nonResidentStatisticObjNew = LoadNonResidentAtPage(skip, take);
            if (nonResidentStatisticObjNew != null)
            {
                List<NonResidentStatistic> result = nonResidentStatisticObjNew.nonResidentStatistics;
                LoadNonResidentStatisticListdata(result);
                pagerPanel.ShowNumberOfRecords(sum, result != null ? result.Count : 0, take, currentPageIndex);
                pagerPanel.UpdatePagingLinks(sum, take, currentPageIndex);
            }
            else
            {
                UploadStatusBarHavePagePanel();
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
            String dateFrom = dateFroms.ToString("yyyy-MM-dd HH:mm:ss");
            String dateTo = dateTos.ToString("yyyy-MM-dd HH:mm:ss");
            NonResidentStatisticObj nonResidentStatisticObjNew = new NonResidentStatisticObj();
            try
            {
                int start = 0;
                int end = take;
                nonResidentStatisticObjNew = NonResidentStatisticsFactory.Instance.GetChannel().getListNonresidentStatisticByDate(StorageService.CurrentSessionId, start, end, dateFrom, dateTo);
            }
            catch (Exception ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "TimeOutExceptionMessage"));
            }

            //   CommonDataGridView dataExport = new CommonDataGridView();
            if (nonResidentStatisticObjNew != null)
            {

                // add data lan dau tien
                PrepareDataToExport(nonResidentStatisticObjNew.nonResidentStatistics);

                //phân trang
                int totalRecords = Convert.ToInt32(nonResidentStatisticObjNew.sum);

                //lay them du lieu neu khong du vi tong so record lon hon so take (take = 20) trong 1 trang
                if (totalRecords > take)
                {
                    int numberPage = (totalRecords / take) + ((totalRecords % take > 0) ? 1 : 0);
                    for (int i = 1; i < numberPage; i++)
                    {
                        int start = i * take;
                        int end = take;
                        nonResidentStatisticObjNew = NonResidentStatisticsFactory.Instance.GetChannel().getListNonresidentStatisticByDate(StorageService.CurrentSessionId, start, end, dateFrom, dateTo);
                        PrepareDataToExport(nonResidentStatisticObjNew.nonResidentStatistics);
                    }
                }

            }
        }

        /// <summary>
        ///  add du lieu vao datagridview
        /// </summary>
        /// <param name="datagridview"></param>
        /// <param name="data"></param>
        private void PrepareDataToExport(List<NonResidentStatistic> result)
        {
            int index = table4Export.Rows.Count;
            for (int i = 0; i < result.Count; i++)
            {
                DataRow row = table4Export.NewRow();
                row.BeginEdit();
                index += 1;
                row[colOrderNum.DataPropertyName] = index;
                row[colOrgId.DataPropertyName] = result[i].orgId;
                row[colNameOrg.DataPropertyName] = result[i].orgName;
                row[colNumberPeople.DataPropertyName] = result[i].number;
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
            String name = MessageValidate.GetMessage(rm, "lbltititeStatisticNonrisedentinout") + "_" + dateFroms.ToString("dd-MM-yyyy") + "_" + dateTos.ToString("dd-MM-yyyy");

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
                    GemboxUtils.Instance.AutoFixWidthColIndexEnd(1, configExportFile.GetSizePageA4Width());//21000:29700


                    String lbltititeStatisticNonrisedentinout = MessageValidate.GetMessage(rm, "lbltititeStatisticNonrisedentinout");
                    GemboxUtils.Instance.AddHeader(lbltititeStatisticNonrisedentinout == null ? string.Empty : lbltititeStatisticNonrisedentinout);
                    int index = 3;
                    String value = "";
                    String cbxFilterByDate = MessageValidate.GetMessage(rm, "cbxFilterByDate");
                    String lblTo = MessageValidate.GetMessage(rm, "lblTo");
                    String filterday = dateFroms.ToString("dd-MM-yyyy");
                    String filterday2 = dateTos.ToString("dd-MM-yyyy");
                    String fitler = cbxFilterByDate + " " + filterday;
                    String fitler2 = lblTo + " " + filterday2;

                    value = (fitler == null ? string.Empty : fitler) + " " + (fitler2 == null ? string.Empty : fitler2);
                    GemboxUtils.Instance.AddCellCustom(index, 0, value == null ? string.Empty : value);
                    value = "";
                    //end custom

                    //GemboxUtils.Instance.AutoFix();

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

    }
}
