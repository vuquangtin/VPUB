using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.EventBroker;
using Microsoft.Practices.CompositeUI.Commands;
using CommonHelper.Constants;
using JavaCommunication.Factory;
using CommonControls;
using System.ServiceModel;
using JavaCommunication;
using CommonHelper.Config;
using CommonControls.Custom;
using System.Resources;
using CommonHelper.Utils;
using sTimeKeeping.WorkItems;
using sTimeKeeping.Constants;
using sTimeKeeping.Model;
using sWorldModel.TransportData;
using sWorldModel;
using sWorldModel.Exceptions;
using sWorldModel.Filters;
using sTimeKeeping.Factory;
using System.IO;
using ClientModel.Model;
using ClientModel.Utils;
using System.Threading;
using System.Diagnostics;
using sExcelExportComponent.ClientModel.Enums;

namespace sTimeKeeping.WorkItems
{
    public partial class UsrUserStatistic : CommonUserControl
    {
        #region Properties

        private const int hiddenFilterBoxHeight = 1;

        // debug 
        private DateTime timeBegin;
        private DateTime timeEnd;

        // BackgroundWorker
        private BackgroundWorker loadOrgWorker;
        private BackgroundWorker bgwloadReport;

        // currentPageIndex
        private int currentPageIndex = 1;

        //20170307 Bug #660 [TimeKeeping] - Statistical Modules - Trang Vo Start
        private bool isRuning = false;
        //20170307 Bug #660 [TimeKeeping] - Statistical Modules - Trang Vo End

        // DataTable
        private DataTable dtbExportData;

        // date
        private DateTime dBegin;
        private DateTime dEnd;

        // ResourceManager
        private ResourceManager rm;

        private List<OrgCustomerDto> result = null;

        private Font startupNodeFont;

        // TreeNode
        private TreeNode selectedSuborgParentNode;
        private TreeNode memberNodeSelected;
        private TreeNode rootNode;

        // DateTime
        private DateTime dateBegin;
        private DateTime dateEnd;
        private DateTime dateCheck = DateTime.Now;

        // int
        private int totalDayPerLoad = 30;
        private int startupFilterBoxHeight;
        private int countPerPage = 6;
        private int totalPerPage = 0;
        private int sheetWidth = 0;
        private int timeLate = 0, timeHaltDayOff = 0, timeDayOff = 0, timeHaltDayOffNo = 0, timeDayOffNo = 0;

        // workItem
        private TimeKeepingComponentWorkItem workItem;
        [ServiceDependency]
        public TimeKeepingComponentWorkItem WorkItem
        {
            set { workItem = value; }
        }

        // storageService
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

        #endregion Properties

        #region Initialization

        public UsrUserStatistic()
        {
            InitializeComponent();
            //init to data table
            InitDtbExportData();

            //load org cho tree
            loadOrgWorker = new BackgroundWorker();
            loadOrgWorker.WorkerSupportsCancellation = true;
            loadOrgWorker.DoWork += OnLoadOrgWorkerDoWork;
            loadOrgWorker.RunWorkerCompleted += OnLoadOrgWorkerCompleted;

            //cac su kien cua tree
            trvOrganizations.BeforeSelect += trvOrganizations_BeforeSelect;
            trvOrganizations.AfterSelect += trvOrganizations_AfterSelect;
            trvOrganizations.MouseDown += trvOrganizations_MouseDown;

            //load report to total part
            bgwloadReport = new BackgroundWorker();
            bgwloadReport.WorkerSupportsCancellation = true;
            bgwloadReport.DoWork += bgwReport_DoWork;
            bgwloadReport.RunWorkerCompleted += bgwReport_WorkerCompleted;

            //gan su kien cho table
            btnShowHideFilter.Click += btnShowHide_Clicked;
            pagerPanel.LinkLabelClicked += pagerPanel_LinkLabelClicked;
            btnExportToExcel.Click += btnExportToExcel_Click;

            //gan su kien bat ngay, chi hien thi trong khoang thoi gian >= thang
            dtpDateBegin.ValueChanged += dtpDateBegin_ValueChanged;
            dtpDateEnd.ValueChanged += dtpDateEnd_ValueChanged;
        }

        /// <summary>
        /// tao data grid view va data table
        /// </summary>
        private void InitDtbExportData()
        {
            dgvExportData.Visible = false;

            dtbExportData = new DataTable();
            dtbExportData.Columns.Add(colCode.DataPropertyName);
            dtbExportData.Columns.Add(colName.DataPropertyName);
            dtbExportData.Columns.Add(colDate.DataPropertyName);
            dtbExportData.Columns.Add(colDateIn.DataPropertyName);
            dtbExportData.Columns.Add(colDateOut.DataPropertyName);
            dtbExportData.Columns.Add(colStatus.DataPropertyName);
            dgvExportData.DataSource = dtbExportData;
        }

        #endregion
        #region Form events
        /// <summary>
        /// OnLoad
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            // set resoucre
            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);

            pagerPanel.StorageService = StorageService;
            pagerPanel.LoadLanguage();

            // set label
            SetAllLabel();

            // Assign startup value
            startupNodeFont = trvOrganizations.Font;
            startupFilterBoxHeight = pnlFilterBox.Height;

            // Load Partner
            InitTreeList();
            LoadOrgAndSubOrgList();

            // set do dai cho usercontrol
            sheetWidth = SystemInformation.VirtualScreen.Width * 7 / 11;
        }
        #region init for languages
        /// <summary>
        /// SetAllLabel of ToolTipText
        /// </summary>
        private void SetAllLabel()
        {
            this.btnRefreshOrg.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnRefreshOrg.Name);
            this.btnExportToExcel.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnExportToExcel.Name);
            this.btnShowHideFilter.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnShowHideFilter.Name);
            this.btnReloadDetail.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnReloadDetail.Name);
            this.mniReloadOrgs.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.mniReloadOrgs.Name);

            //20170307 Bug #660 [TimeKeeping] - Statistical Modules - Trang Vo Start
            lblProgress.Text = string.Empty;
            //20170307 Bug #660 [TimeKeeping] - Statistical Modules - Trang Vo End

        }
        #endregion

        /// <summary>
        /// su kien trvOrganizations_MouseDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trvOrganizations_MouseDown(object sender, MouseEventArgs e)
        {
            // kiem tra e.Button = Right
            if (e.Button == MouseButtons.Right)
            {
                TreeNode node = trvOrganizations.GetNodeAt(trvOrganizations.PointToClient(Control.MousePosition));

                // kiem tra null
                if (node == null)
                {
                    if (node != rootNode)
                    {
                        // show cmsOrgTree
                        cmsOrgTree.Show((Control)sender, e.Location.X, e.Location.Y);
                    }
                }
            }
        }
        /// <summary>
        /// su kien trvOrganizations_BeforeSelect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trvOrganizations_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {

            // Change node font style to normal
            if (memberNodeSelected != null)
            {
                memberNodeSelected.NodeFont = new Font(startupNodeFont, FontStyle.Regular);
                memberNodeSelected.Text = memberNodeSelected.Text;
            }
        }

        /// <summary>
        /// su kien trvOrganizations_AfterSelect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trvOrganizations_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // debug
            timeBegin = DateTime.Now;

            SetHideToolStrip(false);

            //20170307 Bug #660 [TimeKeeping] - Statistical Modules - Trang Vo Start
            lblProgress.Text = string.Empty;
            clearPnl();
            progressBarLoading.Value = 0;

            if (!isRuning)
            {
                //20170307 Bug #660 [TimeKeeping] - Statistical Modules - Trang Vo End
                TreeNode selectedNode = e.Node;

                // kiem tra selectedNode khong null 
                if (selectedNode != null)
                {
                    // kiem tra ROOT_NODE
                    if (selectedNode.Tag != ConstantsValue.ROOT_NODE)
                    {
                        selectedNode.NodeFont = new Font(startupNodeFont, FontStyle.Bold);
                        selectedNode.Text = selectedNode.Text;

                        // kiem tra return
                        if (memberNodeSelected != null && selectedNode == memberNodeSelected)
                        {
                            return;
                        }

                        // set gia tri cho selectedSuborgParentNode va memberNodeSelected
                        selectedSuborgParentNode = selectedNode.Parent;
                        memberNodeSelected = selectedNode;

                        // kiem tra neu click vao member thi xu ly
                        if (selectedNode.Tag.Equals(ConstantsValue.MEMBER_TAG))
                        {
                            lblProgress.Text = MessageValidate.GetMessage(rm, "lblIsLoading");

                            // Level == 3: Enabled btnReloadDetail, btnExportToExcel, LoadMemberList, run Report
                            SetHideToolStrip(true);
                            currentPageIndex = 1;

                            // check datebegin vs dateend
                            if (CheckDate())
                            {
                                DisableControl(true);

                                // LoadData
                                LoadData();
                            }
                            else
                            {
                                MessageBoxManager.ShowInfoMessageBox(this, ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, "lblDateB>DateE"));
                            }
                        }
                        currentPageIndex = 1;
                    }
                }
            }
        }

        /// <summary>
        /// su kien ValueChanged cua dtpDateBegin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpDateBegin_ValueChanged(object sender, EventArgs e)
        {
            dateValueChanged(true);
        }

        /// <summary>
        /// su kien ValueChanged cua dtpDateEnd
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpDateEnd_ValueChanged(object sender, EventArgs e)
        {
            dateValueChanged(false);
        }

        /// <summary>
        /// dateValueChanged
        /// </summary>
        /// <param name="isBeginDateChange"></param>
        private void dateValueChanged(bool isBeginDateChange)
        {
            DateTime dateBegin = dtpDateBegin.Value;
            DateTime dateEnd = dtpDateEnd.Value;
            TimeSpan ts = dateEnd - dateBegin;
            int totalDays = (int)ts.TotalDays + 1; // = 1 khi dateBegin == dateEnd
            if (totalDays > totalDayPerLoad)
            {
                int deviant = totalDays - totalDayPerLoad;
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "TotalDaysFalse"));

                // neu date begin bi thay doi
                if (isBeginDateChange)
                {
                    dateBegin = dateBegin.AddDays(deviant);
                    dtpDateBegin.Value = dateBegin;
                }
                // neu date end bi thay doi
                else
                {
                    dateEnd = dateEnd.AddDays(-deviant);
                    dtpDateEnd.Value = dateEnd;
                }
            }
        }

        /// <summary>
        /// load data
        /// </summary>
        private void LoadData()
        {
            dtbExportData.Rows.Clear();

            //progress bar 
            progressBarLoading.Value = 10;

            // load member
            Member member = LoadMember(Convert.ToInt32(memberNodeSelected.Name));

            // load data
            if (null != member)
            {
                LoadMemberDataGridView(member.Id, member.OrgId);
            }
            else
            {
                //progress bar 
                progressBarLoading.Value = 100;
            }
        }

        /// <summary>
        /// load report
        /// </summary>
        private void LoadReport()
        {
            DisableControl(true);
            if (!bgwloadReport.IsBusy)
            {

                // progress bar 
                progressBarLoading.Value = 10;

                // load
                Member member = LoadMember(Convert.ToInt32(memberNodeSelected.Name));
                bgwloadReport.RunWorkerAsync(member);
            }
        }

        /// <summary>
        /// Dung de show hay an cac button
        /// </summary>
        /// <param name="show"></param>
        private void SetHideToolStrip(bool show)
        {
            btnReloadDetail.Enabled = show;
            btnExportToExcel.Enabled = show;
        }

        /// <summary>
        /// su kien btnShowHide_Clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShowHide_Clicked(object sender, EventArgs e)
        {
            if (pnlFilterBox.Height > hiddenFilterBoxHeight)
            {
                // an khung tim kiem
                pnlFilterBox.Height = hiddenFilterBoxHeight;
                btnShowHideFilter.Text = btnShowHideFilter.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, btnShowHideFilter.Name);
                btnShowHideFilter.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, btnShowHideFilter.Name);
                btnShowHideFilter.Image = global::CommonControls.Properties.Resources.ArrowDown_16x16;
            }
            else
            {
                // hien khung tim kiem
                pnlFilterBox.Height = startupFilterBoxHeight;
                btnShowHideFilter.Text = btnShowHideFilter.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, btnShowHideFilter.Name);
                btnShowHideFilter.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, btnShowHideFilter.Name);
                btnShowHideFilter.Image = global::CommonControls.Properties.Resources.ArrowUp_16x16;
            }
        }
        /// <summary>
        /// su kien pagerPanel_LinkLabelClicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pagerPanel_LinkLabelClicked(object sender, LinkLabelClickedArgs e)
        {
            int i;
            if (e.LabelText.Equals(PagerPanel.LabelBackText))
            {
                // khi nhan vao <<
                currentPageIndex -= 1;
                dateBegin = dateBegin.AddDays(-countPerPage);
            }
            else if (e.LabelText.Equals(PagerPanel.LabelNextText))
            {
                // khi nhan vao >>
                currentPageIndex += 1;
                dateBegin = dateBegin.AddDays(countPerPage);
            }
            // khi nhan vao cac label con lai
            else if (int.TryParse(e.LabelText, out i))
            {
                currentPageIndex = i;
                dateBegin = dtpDateBegin.Value;
                dateBegin = dateBegin.AddDays((i - 1) == 0 ? 0 : (i - 1) * countPerPage);
            }
            else
            {
                return;
            }

            // get member
            Member member = LoadMember(Convert.ToInt32(memberNodeSelected.Name));

            // load member
            if (null != member)
            {
                // DisableControl
                DisableControl(true);

                // load member
                LoadMemberDataGridView(member.Id, member.OrgId);
            }

        }
        /// <summary>
        /// su kien btnExportToExcel_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            // date
            dBegin = dtpDateBegin.Value;
            dEnd = dtpDateEnd.Value;

            // load report
            LoadReport();

            long memId = Convert.ToInt32(memberNodeSelected.Name);
            Member member = LoadMember(memId);
            DateTime now = DateTime.Now;
            if (null != member)
            {
                // file name
                string fileName = MessageValidate.GetMessage(rm, this.lblRightUserStatistics.Name) + "_" + member.LastName + " " + member.FirstName + "_"
                    + dtpDateBegin.Value.ToString("yyyyMMdd") + "_" + dtpDateEnd.Value.ToString("yyyyMMdd");

                // ShowSaveFileDialog
                string filePath = ControlExtMethods.ShowSaveFileDialog(MessageValidate.GetMessage(rm, "smsChooseFileExport"), fileName, "MS Excel (*.xls)|*.xls");
                if (filePath != null)
                {
                    try
                    {
                        //export excel
                        // xuat file default, khong co tieu de
                        //ConfigExportFileModel configExportFile = new ConfigExportFileModel();
                        //configExportFile.FilePath = filePath;
                        //GemboxUtils.Instance.ExportDataGridToFile(dgvExportData, configExportFile);//tua de, xuat file
                        //GemboxUtils.Instance.ExportDataGridToFile(dgvExportData.Rows.Count);//tua de, xuat file

                        //GemboxUtils.Instance.AutoFix();
                        //try
                        //{
                        //    GemboxUtils.Instance.Save();
                        //}
                        //catch (IOException x)
                        //{
                        //    MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "fileExcelOpen"));
                        //}
                        //end

                        ConfigExportFileModel configExportFile = new ConfigExportFileModel();
                        configExportFile.FilePath = filePath;
                        GemboxUtils.Instance.SetPortrait(true);

                        GemboxUtils.Instance.ExportDataGridToFileCustom(dgvExportData, configExportFile, 10);//tua de, xuat file //13
                        GemboxUtils.Instance.AutoFixA4();
                        GemboxUtils.Instance.ExportDataGridToFile(dgvExportData.Rows.Count);//dữ liệu

                        int widthA4 = configExportFile.GetSizePageA4Width();
                        WidthA4Percent withA4Percent = new WidthA4Percent(widthA4);

                        //int widthCol = withA4Percent.GetWidth9();
                        //GemboxUtils.Instance.SetWidthColIndex(3, widthCol);


                        int widthColOrg = withA4Percent.SetWidth(WidthA4Percent.size13);
                        GemboxUtils.Instance.SetWidthColIndex(2, widthColOrg);
                        GemboxUtils.Instance.SetWidthColIndex(3, widthColOrg);
                        GemboxUtils.Instance.SetWidthColIndex(4, widthColOrg);

                        int widthColAttend = withA4Percent.SetWidth(WidthA4Percent.size20);
                        GemboxUtils.Instance.SetWidthColIndex(0, widthColAttend);

                        GemboxUtils.Instance.AutoFixWidthColIndexEnd(1, configExportFile.GetSizePageA4Width());

                        //custom
                        GemboxUtils.Instance.AddTemplateHeader();
                        //export general information
                        String lbltitleLabelInfoMeetinginout = "THỐNG KÊ THEO CÁ NHÂN";
                        GemboxUtils.Instance.AddHeader(lbltitleLabelInfoMeetinginout == null ? string.Empty : lbltitleLabelInfoMeetinginout);

                        // int index = ConstantsEnum.positionIndexCol;//2
                        //int index = ConstantsEnum.Instance.positionIndexForPrint;
                        int index = 5;
                        // String lblGoverningOrganization = MessageValidate.GetMessage(rm, "lblGoverningOrganization");
                        String value = string.Empty;
                        // String value = (lblGoverningOrganization == null ? string.Empty : lblGoverningOrganization) + " " + (tbxOrgName.Text == null ? string.Empty : tbxOrgName.Text.ToString());
                        value = "Đơn vị : ";
                        GemboxUtils.Instance.AddCellCustom(index, 1, value == null ? string.Empty : value);
                        value = selectedSuborgParentNode.Text;
                        GemboxUtils.Instance.AddCellCustom(index, 2, value == null ? string.Empty : value);
                        index++;
                        value = "Chuyên viên đưuọc thống kê: ";
                        GemboxUtils.Instance.AddCellCustom(index, 1, value == null ? string.Empty : value);
                        value = memberNodeSelected.Text;
                        GemboxUtils.Instance.AddCellCustom(index, 2, value == null ? string.Empty : value);
                        index++;
                        value = "Ngày thống kê: ";
                        GemboxUtils.Instance.AddCellCustom(index, 1, value == null ? string.Empty : value);
                        value = "Từ ngày: " + dtpDateBegin.Value.ToString("dd-MM-yyyy") + "  đến ngày;" + dtpDateEnd.Value.ToString("dd-MM-yyyy");
                        GemboxUtils.Instance.AddCellCustom(index, 2, value == null ? string.Empty : value);
                        index++;

                        index = 2;
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
                        DisableControl(false);
                        MessageBoxManager.ShowErrorMessageBox(this, ex.Message);
                        return;
                    }
                    MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "smsLinkFile") + filePath);
                }
            }

            DisableControl(false);
        }
        #endregion

        /// <summary>
        /// Init Tree List
        /// </summary>
        private void InitTreeList()
        {
            rootNode = new TreeNode();
            rootNode.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, "All");
            rootNode.Name = "-1";
            rootNode.Tag = ConstantsValue.ROOT_NODE;
            trvOrganizations.Nodes.Add(rootNode);
        }
        #region Event's support

        #region Functions for organization

        /// <summary>
        /// Load Org And SubOrg List
        /// </summary>
        private void LoadOrgAndSubOrgList()
        {
            //Call background worker if it's not busy
            if (!loadOrgWorker.IsBusy)
            {
                // Clear existing data
                memberNodeSelected = null;
                //dtbMemberList.Rows.Clear();
                rootNode.Nodes.Clear();
                loadOrgWorker.RunWorkerAsync();
            }
        }
        /// <summary>
        /// On Load Org Worker DoWork
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        private void OnLoadOrgWorkerDoWork(object s, DoWorkEventArgs e)
        {

            OrgFilterDto filter = new OrgFilterDto();
            try
            {
                // kiem tra org co duoc hien thi hay khong
                if (!((SystemSettings.Instance.OrgCode).Equals("") || (SystemSettings.Instance.OrgCode).Equals("ALL")))
                {
                    filter.OrgCode = SystemSettings.Instance.OrgCode;
                    filter.FilterByOrgCode = true;
                }

                result = OrganizationFactory.Instance.GetChannel().GetOrgList(storageService.CurrentSessionId, filter);
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
                e.Result = result;
            }
        }
        /// <summary>
        /// On Load Org Worker Completed
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        private void OnLoadOrgWorkerCompleted(object s, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }

            if (e.Result == null || !(e.Result is List<OrgCustomerDto>))
            {
                return;
            }
            List<OrgCustomerDto> result = (List<OrgCustomerDto>)e.Result;
            GetTree(result);
        }
        /// <summary>
        /// Tạo tree org 
        /// </summary>
        /// <param name="lstOrgCustomerDto"></param>
        public void GetTree(List<OrgCustomerDto> lstOrgCustomerDto)
        {
            //kiem tra null đây để sử dụng cho đệ quy
            if (lstOrgCustomerDto != null)
            {
                foreach (OrgCustomerDto org in lstOrgCustomerDto)
                {
                    if (!org.Issuer.Equals(SystemSettings.Instance.Master))
                    {
                        TreeNode orgNode = new TreeNode();
                        orgNode.Text = org.Name;
                        orgNode.Name = Convert.ToString(org.OrgId);
                        orgNode.Tag = ConstantsValue.ORG_TAG;

                        //tạo tree con từ tree con tạo danh sách người
                        GetSubTree(org, org.OrgId, orgNode);
                        rootNode.Nodes.Add(orgNode);
                    }
                }
            }
        }
        /// <summary>
        /// Tạo tree con
        /// </summary>
        /// <param name="org">object org</param>
        /// <param name="orgId">orgid</param>
        /// <param name="node">node từ parent gui qua để add</param>
        public void GetSubTree(OrgCustomerDto org, long orgId, TreeNode node)
        {
            //doi tượng này sử dụng cho vòng lặp đệ quy
            List<SubOrgCustomerDTO> lstSubOrgCustomerDTO = org.SubOrgList;

            //lọc kiểm tra điều kiện 
            if (null != lstSubOrgCustomerDTO)
            {
                List<SubOrgCustomerDTO> lstSubOrgCustomer = lstSubOrgCustomerDTO.Where(key => key.parentOrgId == orgId).ToList();
                if (lstSubOrgCustomer != null)
                {
                    foreach (SubOrgCustomerDTO subOrg in lstSubOrgCustomer)
                    {
                        if (subOrg.OrgCode == ConstantsValue.CODE_BAO_CHI)
                            continue;
                        TreeNode subOrgNode = new TreeNode();
                        subOrgNode.Text = subOrg.Name;
                        subOrgNode.Name = Convert.ToString(subOrg.SubOrgId);
                        subOrgNode.Tag = ConstantsValue.SUB_TAG;

                        //điều kiện để add vào nút cha
                        if (orgId == subOrg.parentOrgId)
                        {
                            node.Nodes.Add(subOrgNode);
                            SetMemberInTree(subOrg.SubOrgId, subOrgNode);
                        }
                        //gọi đệ quy
                        GetSubTree(org, subOrg.SubOrgId, subOrgNode);
                    }
                }
            }
        }
        /// <summary>
        /// Add tất cả các member thuộc suborg để add vào tree
        /// </summary>
        /// <param name="subOrgId"></param>
        /// <param name="node"></param>
        private void SetMemberInTree(long subOrgId, TreeNode node)
        {
            List<Member> lstMember = new List<Member>();

            //get all member of suborg
            lstMember = OrganizationFactory.Instance.GetChannel().GetMemberListBySubOrg(storageService.CurrentSessionId, subOrgId);
            if (null != lstMember)
            {
                foreach (Member item in lstMember)
                {
                    if (item.Active)
                    {
                        TreeNode memberNode = new TreeNode();
                        memberNode.Text = item.LastName + " " + item.FirstName;
                        memberNode.Name = Convert.ToString(item.Id);

                        // để phân biệt node của người hoặc của suborg
                        memberNode.Tag = ConstantsValue.MEMBER_TAG;
                        node.Nodes.Add(memberNode);
                    }
                }
            }
        }

        #endregion

        #region Functions for member

        /// <summary>
        /// Get Member Filter
        /// </summary>
        /// <returns></returns>
        private MemberFilter GetMemberFilter()
        {
            MemberFilter filter = new MemberFilter();
            return filter;
        }
        /// <summary>
        /// bgwReport_DoWork: load report 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwReport_DoWork(object sender, DoWorkEventArgs e)
        {
            Member member = (Member)e.Argument;
            MonthlyReport month = null;

            // chuan bi du lieu
            List<MonthlyReport> monthList = new List<MonthlyReport>();

            TimeSpan tsp = dEnd - dBegin;
            DateTime dTmp = dBegin;
            int toTalDayReport = (int)tsp.TotalDays + 1;
            List<long> idList = new List<long>();
            int year = dBegin.Year, monthOfYear = 0, curMonth = 0;
            if (null != member)
                idList.Add(member.Id);
            try
            {
                // for tren tong so ngay
                for (int i = 0; i < toTalDayReport; i++)
                {
                    // meu m khac month cua dBegin
                    if (monthOfYear != dTmp.Month)
                    {
                        // update lai y, m
                        year = dTmp.Year; monthOfYear = dTmp.Month;

                        // GetTimeKeepingMonthlyReport
                        month = TimeKeepingFactory.Instance.GetChannel().GetTimeKeepingMonthlyReport(StorageService.CurrentSessionId,
                                                       member.Id, year, monthOfYear);
                        if (null == month)
                        {
                            // insertMonthlyReportDefault
                            TimeKeepingFactory.Instance.GetChannel().insertMonthlyReportDefault(StorageService.CurrentSessionId, member.OrgId, member.SubOrgId, member.Id, year, monthOfYear);

                            // GetTimeKeepingMonthlyReport
                            month = TimeKeepingFactory.Instance.GetChannel().GetTimeKeepingMonthlyReport(StorageService.CurrentSessionId, member.Id, year, monthOfYear);
                        }
                    }
                    DateTime curDate = DateTime.Now;

                    // neu null != month va status cua ngay hom do bang -1 
                    if (null != month && DayOffMonthlyReport(dTmp.Day, month) == -1 && curDate.CompareTo(dTmp) >= 0)
                    {
                        // insertOrUpdateMonthlyReport
                        TimeKeepingFactory.Instance.GetChannel().insertOrUpdateMonthlyReport(StorageService.CurrentSessionId,
                               dTmp.ToString("yyyy-MM-dd"), dTmp.ToString("yyyy-MM-dd"), idList);

                        // GetTimeKeepingMonthlyReport
                        month = TimeKeepingFactory.Instance.GetChannel().GetTimeKeepingMonthlyReport(StorageService.CurrentSessionId, member.Id, year, monthOfYear);
                    }
                    if (null != month)
                    {
                        // neu month != null & curMonth != monthOfYear thi add month vao monthList
                        if (curMonth != monthOfYear)
                        {
                            monthList.Add(month);
                            curMonth = monthOfYear;
                        }
                    }
                    dTmp = dTmp.AddDays(1);
                }
            }
            catch (TimeoutException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "TimeOutExceptionMessage"));
                monthList = null;
            }
            catch (FaultException<WcfServiceFault> ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
                monthList = null;
            }
            catch (FaultException ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "FaultExceptionMessage")
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
                monthList = null;
            }
            catch (CommunicationException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "CommunicationExceptionMessage"));
                monthList = null;
            }
            finally
            {
                e.Result = monthList;
                LoadDataToGridView(dtpDateBegin.Value, toTalDayReport, member.Id, monthList);
            }
        }

        /// <summary>
        /// bgwReport_WorkerCompleted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwReport_WorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                progressBarLoading.Value = 100;
                DisableControl(false);
                return;
            }
            if (e.Result == null)
            {
                progressBarLoading.Value = 100;
                DisableControl(false);
                return;
            }
            List<MonthlyReport> result = e.Result as List<MonthlyReport>;

            // load data
            LoadReportToLabel(result);


        }
        /// <summary>
        /// LoadMemberDataGridView
        /// </summary>
        /// <param name="result"></param>
        private void LoadMemberDataGridView(long memberId, long orgId)
        {
            #region caculator date
            List<List<TimeDetail>> list = new List<List<TimeDetail>>();
            List<Event> listEvent = new List<Event>();

            TimeSpan ts = dateEnd - dateBegin;
            int totalRecords = (int)ts.TotalDays + 1;
            int day_size = 0, lenMin = totalRecords - (currentPageIndex * countPerPage);
            //
            if (totalRecords >= countPerPage) day_size = countPerPage;
            //
            if (totalRecords < countPerPage && totalRecords > 0) day_size = totalRecords;

            //pagerPanel.ShowNumberOfRecords(day_size%countPerPage, day_size, countPerPage, currentPageIndex);
            pagerPanel.UpdatePagingLinks(totalPerPage, countPerPage, currentPageIndex);

            // clearPnl
            clearPnl();

            List<sheet1> listSheet = new List<sheet1>();

            //split
            DateTime dateStart = dateBegin;
            DateTime dateFinish = dateBegin.AddDays(day_size - 1);
            Dictionary<string, List<Shift>> dicShift = splitShift(memberId, dateStart, dateFinish);// da co memberid, tim theo memberId va list date
            List<Shift> listShift = null;

            #endregion

            #region tao timedetailist cho cac sheet

            // TimeDetail
            // const cho colorConfigList & timeConfig
            List<ColorConfig> colorConfigList = TimeDetail.getColorConfigList(StorageService.CurrentSessionId, orgId);
            TimeDetail.colorConfigList = colorConfigList;
            List<TimeConfig> timeConfig = TimeDetail.getTimeConfig(StorageService.CurrentSessionId, orgId);
            TimeDetail.timeConfig = timeConfig;
            TimeDetail.Session = StorageService.CurrentSessionId;
            TimeDetail.OrgId = orgId;

            // prepare for ListTimeDetail
            string dateString;
            ConfigForStatisticDTO config;
            List<List<UserTimeConfig>> ListUserTimeConfig = null;
            DayOffConfig dayoff;
            int checkHoliday;


            for (int i = 0; i < day_size; i++)
            {
                //set sheet vao userControl
                //TO DO CONVERT TO LIST TIMEDETAIL
                DateTime date = dateBegin.AddDays(i);
                string strDate = date.ToString("yyyy-MM-dd");
                if (null != dicShift && dicShift.Count > 0)
                {
                    if (dicShift.ContainsKey(strDate))
                        listShift = dicShift[strDate];
                    else
                        listShift = new List<Shift>();
                }
                else
                {
                    listShift = new List<Shift>();
                }


                // prepare for ListTimeDetail
                // get config of each member 
                //List<long> memberList = new List<long>();
                //memberList.Add(memberId);

                // Dong lai, khong dung cho VPUB
                //ListUserTimeConfig = TimeKeepingUserTimeConfigFactory.Instance.GetChannel().getListUserTimeConfigByMemberId(StorageService.CurrentSessionId, orgId, memberList);

                // dayoff
                string dateStringDayOff = date.ToString("dd/MM/yyyy");
                dayoff = TimeKeepingDayOffConfigFactory.Instance.GetChannel().getDayOffByMemberIdAndDate(StorageService.CurrentSessionId, memberId, dateStringDayOff);

                dateCheck = date;
                //checkHoliday = TimeKeepingHolidayConfigFactory.Instance.GetChannel().checkHoliday(StorageService.CurrentSessionId, dateCheck, orgId);
                checkHoliday = TimeDetail.checkHolidayOfOrg(StorageService.CurrentSessionId, orgId, dateCheck);

                //get ConfigForStatisticDTO tu server
                dateString = date.ToString("yyyy-MM-dd HH:mm:ss");
                config = TimeKeepingTimeConfigFactory.Instance.GetChannel().GetTimeConfigEventConfigByFilter(StorageService.CurrentSessionId, memberId, dateString, orgId);

                // tinh toan list timedetail
                //list = TimeDetail.ListTimeDetail(StorageService.CurrentSessionId, orgId, listShift, memberId, date, dateCheck);
                list = TimeDetail.ListTimeDetailForMiniSheet(listShift, config, ListUserTimeConfig, dayoff, date, checkHoliday);

                //get listEvent
                if (null != config)
                {
                    if (null == config.eventList)
                        listEvent = new List<Event>();
                    else
                        listEvent = config.eventList;

                    // tao sheet => gan sheet vao panel
                    sheet1 s = new sheet1(i, date.ToString("dd/MM/yyyy"), list, listEvent);
                    s.Width = sheetWidth;
                    workItem.SmartParts.Add(s);
                    listSheet.Add(s);
                }
            }

            #endregion

            #region add sheet & tinh toan tong cong

            //add panel
            int len = listSheet.Count;
            if (len > 0) panel8.Controls.Add(listSheet[0]);
            if (len > 1) panel9.Controls.Add(listSheet[1]);
            if (len > 2) panel10.Controls.Add(listSheet[2]);
            if (len > 3) panel11.Controls.Add(listSheet[3]);
            if (len > 4) panel12.Controls.Add(listSheet[4]);
            if (len > 5) panel13.Controls.Add(listSheet[5]);
            if (len > 6) panel14.Controls.Add(listSheet[6]);
            if (len > 7) panel15.Controls.Add(listSheet[7]);

            if (totalRecords >= 1)
                this.btnExportToExcel.Enabled = true;
            else
                this.btnExportToExcel.Enabled = false;

            //progress bar 
            progressBarLoading.Value = 100;
            DisableControl(false);

            timeEnd = DateTime.Now;
            Debug.WriteLine("------------ <Trang> ---- Caculator for member: statistic " + timeBegin.ToString("hh:mm:ss.fff tt"));
            Debug.WriteLine("------------ <Trang> ---- Caculator for member: statistic " + timeEnd.ToString("hh:mm:ss.fff tt"));
            Debug.WriteLine("------------ <Trang> ---- Caculator for member: statistic " + (timeEnd.ToBinary() - timeBegin.ToBinary()));

            // date
            dBegin = dateStart;
            dEnd = dateFinish;

            // load report
          //  LoadReport();

            #endregion
        }
        #endregion

        #region report
        /// <summary>
        /// load data to report of 1 page
        /// </summary>
        /// <param name="reportList"></param>
        private void LoadReportToLabel(List<MonthlyReport> reportList)
        {
            // tim date bat dau va dat ket thuc
            timeLate = 0; timeHaltDayOff = 0; timeDayOff = 0; timeHaltDayOffNo = 0; timeDayOffNo = 0;
            TimeSpan tsp = dEnd - dBegin;
            int toTalDayReport = (int)tsp.TotalDays + 1;
            int y = dBegin.Year, m = dBegin.Month, d = dBegin.Day, index = 0;
            MonthlyReport rep = reportList[index++];

            //persent 
            int persent = toTalDayReport > 85 ? 1 : 85 / toTalDayReport;

            for (int i = 0; i < toTalDayReport; i++)
            {
                if (m != dBegin.Month)
                {
                    // neu m != dBegin.Month thi lay reportList thu index + 1
                    rep = reportList[index++];
                }
                d = dBegin.Day;
                m = dBegin.Month;
                // tinh toan tre, vang 
                CaculTimes(DayOffMonthlyReport(d, rep));
                dBegin = dBegin.AddDays(1);

                // persent
                if (progressBarLoading.Value < 99)
                    progressBarLoading.Value = progressBarLoading.Value + persent;
            }
            txtT.Text = timeLate + String.Empty;
            txtP.Text = (timeDayOff + timeHaltDayOff / 2 + (timeHaltDayOff % 2 == 0 ? 0 : 1)) + String.Empty;
            txtK1.Text = (timeDayOffNo + timeHaltDayOffNo / 2 + (timeHaltDayOffNo % 2 == 0 ? 0 : 1)) + String.Empty;

            //20170307 Bug #660 [TimeKeeping] - Statistical Modules - Trang Vo Start

            //progress bar
            progressBarLoading.Value = 100;
            lblProgress.Text = MessageValidate.GetMessage(rm, "done");
            //Thread.Sleep(500);
            DisableControl(false);
            //20170307 Bug #660 [TimeKeeping] - Statistical Modules - Trang Vo End

            timeEnd = DateTime.Now;
            Debug.WriteLine("------------ <Trang> ---- Caculator for member: report " + timeBegin.ToString("hh:mm:ss.fff tt"));
            Debug.WriteLine("------------ <Trang> ---- Caculator for member: report " + timeEnd.ToString("hh:mm:ss.fff tt"));
            Debug.WriteLine("------------ <Trang> ---- Caculator for member: report " + (timeEnd.ToBinary() - timeBegin.ToBinary()));
        }
        /// <summary>
        /// caculTimes tinh toan tre, vang
        /// </summary>
        /// <param name="dayValue"></param>
        private void CaculTimes(int dayValue)
        {
            if (dayValue == (int)TimeKeepingStatus.DI_TRE_VE_SOM) timeLate++;
            if (dayValue == (int)TimeKeepingStatus.VANG_NUA_NGAY_PHEP) timeHaltDayOff++;
            if (dayValue == (int)TimeKeepingStatus.VANG_CA_NGAY_PHEP) timeDayOff++;
            if (dayValue == (int)TimeKeepingStatus.VANG_NUA_NGAY_KO_PHEP) timeHaltDayOffNo++;
            if (dayValue == (int)TimeKeepingStatus.VANG_CA_NGAY_KO_PHEP) timeDayOffNo++;
        }

        /// <summary>
        /// get gia tri cua ngay d trong 1 monthly report
        /// </summary>
        /// <param name="day"></param>
        /// <param name="monthly"></param>
        /// <returns></returns>
        private int DayOffMonthlyReport(int day, MonthlyReport monthly)
        {
            switch (day)
            {
                case 1:
                    return monthly.day1;
                case 2:
                    return monthly.day2;
                case 3:
                    return monthly.day3;
                case 4:
                    return monthly.day4;
                case 5:
                    return monthly.day5;
                case 6:
                    return monthly.day6;
                case 7:
                    return monthly.day7;
                case 8:
                    return monthly.day8;
                case 9:
                    return monthly.day9;
                case 10:
                    return monthly.day10;
                case 11:
                    return monthly.day11;
                case 12:
                    return monthly.day12;
                case 13:
                    return monthly.day13;
                case 14:
                    return monthly.day14;
                case 15:
                    return monthly.day15;
                case 16:
                    return monthly.day16;
                case 17:
                    return monthly.day17;
                case 18:
                    return monthly.day18;
                case 19:
                    return monthly.day19;
                case 20:
                    return monthly.day20;
                case 21:
                    return monthly.day21;
                case 22:
                    return monthly.day22;
                case 23:
                    return monthly.day23;
                case 24:
                    return monthly.day24;
                case 25:
                    return monthly.day25;
                case 26:
                    return monthly.day26;
                case 27:
                    return monthly.day27;
                case 28:
                    return monthly.day28;
                case 29:
                    return monthly.day29;
                case 30:
                    return monthly.day30;
                case 31:
                    return monthly.day31;
            }
            return -1;
        }
        /// <summary>
        /// CheckDate: kiem tra ngay bat dau nho hon ngay ket thuc
        /// </summary>
        /// <returns></returns>
        private bool CheckDate()
        {
            //lay gia tri ngay thang 1 lan
            dateBegin = dtpDateBegin.Value;
            dateEnd = dtpDateEnd.Value;
            TimeSpan ts = dateEnd - dateBegin;
            totalPerPage = (int)ts.TotalDays + 1;
            if (dateBegin.Year == dateEnd.Year && dateBegin.Month == dateEnd.Month && dateBegin.Day == dateEnd.Day)
                return true;
            if (dateBegin.CompareTo(dateEnd) > 0)
                return false;
            return true;
        }

        /// <summary>
        /// load du lieu vao datagridview
        /// </summary>
        /// <param name="memList"></param>
        /// <param name="monthList"></param>
        private void LoadDataToGridView(DateTime dateBegin, int toTalDayReport, long memId, List<MonthlyReport> monthList)
        {
            dtbExportData.Clear();
            // load data to dtbExportData 
            if (null != monthList && monthList.Count != 0)
            {
                for (int i = 0; i < toTalDayReport; i++)
                {
                    // load data to dtbExportData 
                    // load member dua vao member id
                    Member memberObj = LoadMember(memId);
                    if (null != memberObj)
                    {
                        DataRow row = dtbExportData.NewRow();
                        row.BeginEdit();
                        row[colCode.DataPropertyName] = memberObj.Code;
                        row[colName.DataPropertyName] = memberObj.LastName + " " + memberObj.FirstName;
                        row[colDate.DataPropertyName] = dateBegin.ToString("dd/MM/yyyy");

                        //get cac du lieu tu server
                        //shift
                        ShiftFilterDto filter = ToShiftFilterDto(memId, dateBegin);
                        List<Shift> shiftList = new List<Shift>();
                       // shiftList = TimeKeepingShiftFactory.Instance.GetChannel().getShiftListByShiftFilter(StorageService.CurrentSessionId, filter);
                        shiftList = TimeKeepingShiftFactory.Instance.GetChannel().getShift(StorageService.CurrentSessionId, dateBegin.ToString("yyyy-MM-dd HH:mm:ss"),
                                dateBegin.ToString("yyyy-MM-dd HH:mm:ss "), memId + "", 0, 0);
                        if (null == shiftList) shiftList = new List<Shift>();
                        if (shiftList.Count > 0)
                        {
                            // set gio vao bang
                            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                            DateTime startDate = start.AddMilliseconds(long.Parse(shiftList[0].dateIn)).ToLocalTime();
                            DateTime endDate = start.AddMilliseconds(long.Parse(shiftList[shiftList.Count - 1].dateIn)).ToLocalTime();

                            if (endDate.Hour - startDate.Hour == 0 && endDate.Minute - startDate.Minute <= 10)
                            {
                                if (startDate.Hour < 12)
                                {
                                    row[colDateIn.DataPropertyName] = (startDate.Hour < 10 ? "0" : "") + startDate.Hour + ":" + (startDate.Minute < 10 ? "0" : "") + startDate.Minute + ":" + (startDate.Second < 10 ? "0" : "") + startDate.Second;
                                }
                                else
                                {
                                    row[colDateOut.DataPropertyName] = (endDate.Hour < 10 ? "0" : "") + endDate.Hour + ":" + (endDate.Minute < 10 ? "0" : "") + endDate.Minute + ":" + (endDate.Second < 10 ? "0" : "") + endDate.Second;
                                }
                            }
                            else
                            {
                                row[colDateIn.DataPropertyName] = (startDate.Hour < 10 ? "0" : "") + startDate.Hour + ":" + (startDate.Minute < 10 ? "0" : "") + startDate.Minute + ":" + (startDate.Second < 10 ? "0" : "") + startDate.Second;
                                row[colDateOut.DataPropertyName] = (endDate.Hour < 10 ? "0" : "") + endDate.Hour + ":" + (endDate.Minute < 10 ? "0" : "") + endDate.Minute + ":" + (endDate.Second < 10 ? "0" : "") + endDate.Second;
                            }
                        }
                        row[colStatus.DataPropertyName] = GetStatus(GetStatusForMember(dateBegin.Day, monthList, memId));
                        row.EndEdit();
                        dtbExportData.Rows.Add(row);
                        dateBegin = dateBegin.AddDays(1);
                    }
                }
            }
        }
        /// <summary>
        /// get status cua 1 nguoi trong 1 ngay
        /// </summary>
        /// <param name="day"></param>
        /// <param name="monthList"></param>
        /// <param name="memDTO"></param>
        /// <returns></returns>
        private int GetStatusForMember(int day, List<MonthlyReport> monthList, long memId)
        {
            int status = -1;
            MonthlyReport month = null;
            for (int i = 0; i < monthList.Count; i++)
            {
                if (memId == monthList[i].memberId)
                    month = monthList[i];
            }
            // get status
            if (null != month) status = DayOffMonthlyReport(day, month);
            return status;
        }
        /// <summary>
        /// get status cua 1 gia tri status
        /// </summary>
        /// <param name="day"></param>
        /// <param name="monthList"></param>
        /// <param name="memDTO"></param>
        /// <returns></returns>
        private String GetStatus(int dayValue)
        {
            if (dayValue == (int)TimeKeepingStatus.DI_TRE_VE_SOM) return MessageValidate.GetMessage(rm, "colLate");//"Trễ"
            if (dayValue == (int)TimeKeepingStatus.VANG_NUA_NGAY_PHEP) return MessageValidate.GetMessage(rm, "ExcelEventNameHalftDayOffP");//"Vắng nửa ngày có phép";
            if (dayValue == (int)TimeKeepingStatus.VANG_CA_NGAY_PHEP) return MessageValidate.GetMessage(rm, "ExcelEventNameFullDayOffP");//"Vắng cả ngày có phép";
            if (dayValue == (int)TimeKeepingStatus.VANG_NUA_NGAY_KO_PHEP) return MessageValidate.GetMessage(rm, "ExcelEventNameHalftDayOffNoP");//"Vắng nửa ngày không phép";
            if (dayValue == (int)TimeKeepingStatus.VANG_CA_NGAY_KO_PHEP) return MessageValidate.GetMessage(rm, "ExcelEventNameFullDayOffNoP");//"Vắng cả ngày không phép";
            return MessageValidate.GetMessage(rm, "ExcelEventNameDayWork"); //"Đi làm Bình thường";
        }

        /// <summary>
        /// split Shift tao Dictionary
        /// </summary>
        /// <param name="memberId"></param>
        /// <param name="dateStart"></param>
        /// <param name="dateEnd"></param>
        /// <returns></returns>
        private Dictionary<string, List<Shift>> splitShift(long memberId, DateTime dateStart, DateTime dateEnd)
        {
            List<Shift> lst = TimeKeepingShiftFactory.Instance.GetChannel().getShift(StorageService.CurrentSessionId, dateStart.ToString("yyyy-MM-dd HH:mm:ss"),
                                dateEnd.ToString("yyyy-MM-dd HH:mm:ss"), memberId + string.Empty, 0, 0);// da co memberid, tim theo memberId va list date
            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            // Dictionary
            Dictionary<String, List<Shift>> dic = new Dictionary<String, List<Shift>>();
            if (null != lst)
                foreach (Shift shift in lst)
                {
                    DateTime startDate = start.AddMilliseconds(Convert.ToUInt64(shift.dateIn)).ToLocalTime();
                    string date = startDate.ToString("yyyy-MM-dd HH:mm:ss");
                    string[] strDate = date.Split(' ');
                    if (strDate.Length == 2)
                    {
                        // add
                        if (!dic.ContainsKey(strDate[0]))
                        {
                            List<Shift> list = new List<Shift>();
                            list.Add(shift);
                            dic.Add(strDate[0], list);
                        }
                        else
                        {
                            dic[strDate[0]].Add(shift);
                        }
                    }
                }

            return dic;
        }
       

        //20170307 Bug #660 [TimeKeeping] - Statistical Modules - Trang Vo Start
        /// <summary>
        /// disable khi dang runing
        /// </summary>
        private void DisableControl(bool isRunning)
        {
            isRuning = isRunning;
            try
            {
                trvOrganizations.Enabled = !isRunning;
                btnRefreshOrg.Enabled = btnExportToExcel.Enabled = btnReloadDetail.Enabled
                    = dtpDateBegin.Enabled = dtpDateEnd.Enabled = !isRunning;
            }
            catch (Exception e)
            {

            }
        }

        //20170307 Bug #660 [TimeKeeping] - Statistical Modules - Trang Vo End
        /// <summary>
        /// clear all panel detail
        /// </summary>
        private void clearPnl()
        {
            panel8.Controls.Clear();
            panel9.Controls.Clear();
            panel10.Controls.Clear();
            panel11.Controls.Clear();
            panel12.Controls.Clear();
            panel13.Controls.Clear();
            panel14.Controls.Clear();
            panel15.Controls.Clear();
        }
        /// <summary>
        /// To Shift Filter Dto
        /// </summary>
        /// <returns></returns>
        private ShiftFilterDto ToShiftFilterDto(long memberId, DateTime date)
        {
            ShiftFilterDto filter = new ShiftFilterDto();
            filter.FilterByDateIn = true;
            filter.DateIn = date.ToString("yyyy-MM-dd HH:mm:ss");
            filter.FilterByMemberId = true;
            filter.MemberId = memberId;
            return filter;
        }
        #endregion

        #endregion

        #region CAB events

        [CommandHandler(TimeCommandName.ShowUserStatistic)]
        public void ShowCardMgtMainHandler(object s, EventArgs e)
        {
            UsrUserStatistic uc = workItem.Items.Get<UsrUserStatistic>(DefineName.UserStatistic);
            if (uc == null)
            {
                uc = workItem.Items.AddNew<UsrUserStatistic>(DefineName.UserStatistic);
            }
            else if (uc.IsDisposed)
            {
                workItem.Items.Remove(uc);
                uc = workItem.Items.AddNew<UsrUserStatistic>(DefineName.UserStatistic);
            }

            workItem.Workspaces[WorkspaceName.MainWorkspace].Show(uc);
            uc.Parent.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, DefineName.MenuUserStatistic);
        }
        #endregion

        #region event load
        /// <summary>
        /// ReLoadTrvOrganizations: reload suborg => bo phan tree cua member
        /// </summary>
        private void ReLoadTrvOrganizations()
        {
            TreeNode root = trvOrganizations.Nodes[0];
            foreach (TreeNode orgNode in root.Nodes)
            {
                foreach (TreeNode subNode in orgNode.Nodes)
                {
                    if (subNode.Equals(selectedSuborgParentNode))
                    {
                        continue;
                    }
                    subNode.Nodes.Clear();
                }
            }
        }
        /// <summary>
        /// btnReloadDetail_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReloadDetail_Click(object sender, EventArgs e)
        {
            //20170307 Bug #660 [TimeKeeping] - Statistical Modules - Trang Vo Start
            lblProgress.Text = MessageValidate.GetMessage(rm, "lblIsLoading");
            //20170307 Bug #660 [TimeKeeping] - Statistical Modules - Trang Vo End
            currentPageIndex = 1;

            //set total per page
            if (CheckDate())
            {
                // clear data table
                DisableControl(true);

                // load data
                LoadData();

            }
            else
            {
                MessageBoxManager.ShowInfoMessageBox(this, ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, "lblDateB>DateE"));
            }
        }
        /// <summary>
        /// btnReloadOrg_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReloadOrg_Click(object sender, EventArgs e)
        {
            trvOrganizations.Nodes.Clear();
            btnReloadDetail.Enabled = false;

            //Load Partner
            LoadOrgAndSubOrgList();
        }
        /// <summary>
        /// load member dua vao memberid
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        private Member LoadMember(long memberId)
        {
            Member member = new Member();
            try
            {
                // GetMemberById 
                member = OrganizationFactory.Instance.GetChannel().GetMemberById(StorageService.CurrentSessionId, memberId);
                
            }
            catch (TimeoutException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "TimeOutExceptionMessage"));
                this.Hide();
            }
            catch (FaultException<WcfServiceFault> ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
                this.Hide();
            }
            catch (FaultException ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "FaultExceptionMessage")
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
                this.Hide();
            }
            catch (CommunicationException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "CommunicationExceptionMessage"));
                this.Hide();
            }
            return member;
        }
        #endregion


    }
}