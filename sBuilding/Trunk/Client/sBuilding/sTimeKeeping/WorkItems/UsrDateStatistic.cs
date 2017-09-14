using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Practices.CompositeUI;
using sWorldModel;
using CommonControls.Custom;
using Microsoft.Practices.CompositeUI.Commands;
using sTimeKeeping.Constants;
using CommonHelper.Constants;
using CommonHelper.Utils;
using System.Resources;
using sWorldModel.TransportData;
using CommonHelper.Config;
using JavaCommunication.Factory;
using CommonControls;
using sWorldModel.Exceptions;
using System.ServiceModel;
using sWorldModel.Filters;
using sTimeKeeping.Model;
using sTimeKeeping.Factory;
using System.IO;
using ClientModel.Model;
using ClientModel.Utils;
using System.Threading;
using System.Diagnostics;
using sExcelExportComponent.ClientModel.Enums;

namespace sTimeKeeping.WorkItems
{
    public partial class UsrDateStatistic : CommonUserControl
    {

        #region Properties

        private const int hiddenFilterBoxHeight = 1;

        // 20170307 Bug #660 [TimeKeeping] - Statistical Modules - Trang Vo Start
        private bool isRuning = false;
        // 20170307 Bug #660 [TimeKeeping] - Statistical Modules - Trang Vo End

        private int currentPageIndex = 1;

        // BackgroundWorker
        private BackgroundWorker loadOrgWorker;
        private BackgroundWorker loadMemberWorker;
        private BackgroundWorker loadReport;


        // debug 
        private DateTime timeBegin;
        private DateTime timeEnd;

        // List
        private List<OrgCustomerDto> result = null;
        private List<Member> MemberChipList;

        // ResourceManager
        private ResourceManager rm;

        // 
        private DataTable dtbExportData;
        private DateTime dateCheck = DateTime.Now;

        // TreeNode
        private int startupFilterBoxHeight;
        private Font startupNodeFont;
        private TreeNode rootNode;
        private TreeNode selectedSuborgParentNode;
        private TreeNode subNodeSelected;

        // id to chuc
        private long OrgId = 0;

        // id parent suborg select
        private long SelectParentId = 0;

        // id nguoi dung select in tree
        private long SelectId = 0;

        // 
        private int countPerPage = 6;
        private int sheetWidth = 0;
        private bool checkReport = false;
        private int timeLate = 0, timeHaltDayOff = 0, timeDayOff = 0, timeHaltDayOffNo = 0, timeDayOffNo = 0;
        private int start = 0;
        private int totalRecords = 0;

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
            set { storageService = value; }
        }

        #endregion

        #region init
        /// <summary>
        /// contructor UsrDateStatistic()
        /// </summary>
        public UsrDateStatistic()
        {
            InitializeComponent();

            // cac su kien cua tree
            trvOrganizations.BeforeSelect += trvOrganizations_BeforeSelect;
            trvOrganizations.AfterSelect += trvOrganizations_AfterSelect;
            trvOrganizations.MouseDown += trvOrganizations_MouseDown;

            // load org cho tree
            loadOrgWorker = new BackgroundWorker();
            loadOrgWorker.WorkerSupportsCancellation = true;
            loadOrgWorker.DoWork += OnLoadOrgWorkerDoWork;
            loadOrgWorker.RunWorkerCompleted += OnLoadOrgWorkerCompleted;

            // init to data table
            InitDtbExportData();

            // load member to table
            loadMemberWorker = new BackgroundWorker();
            loadMemberWorker.WorkerSupportsCancellation = true;
            loadMemberWorker.DoWork += bgwMember_DoWork;
            loadMemberWorker.RunWorkerCompleted += bgwMember_WorkerCompleted;

            // load report to total part
            loadReport = new BackgroundWorker();
            loadReport.WorkerSupportsCancellation = true;
            loadReport.DoWork += bgwReport_DoWork;
            loadReport.RunWorkerCompleted += bgwReport_WorkerCompleted;

            // key down enter
            tbxCode.KeyDown += tbxCode_KeyDown;

            // gan su kien cho table
            btnShowHide.Click += btnShowHide_Clicked;
            pagerPanel.LinkLabelClicked += pagerPanel_LinkLabelClicked;
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
           // dtbExportData.Columns.Add(colStatus.DataPropertyName);
            dgvExportData.DataSource = dtbExportData;
        }

        /// <summary>
        /// OnLoad
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            // set Resoucre
            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;

            // set ngon ngu coh form
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);

            // init tree
            InitTreeList();

            // load org and suborg
            LoadOrgAndSubOrgList();

            // language
            pagerPanel.StorageService = StorageService;
            pagerPanel.LoadLanguage();
            SetAllLabel();

            // Assign startup value
            startupFilterBoxHeight = pnlFilterBox.Height;
            startupNodeFont = trvOrganizations.Font;

            // set do dai cho usercontrol
            sheetWidth = SystemInformation.VirtualScreen.Width * 7 / 11;
        }

        #region init for languages
        /// <summary>
        /// Set All Label
        /// </summary>
        private void SetAllLabel()
        {
            // ToolTipText
            this.btnReloadMembers.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnReloadMembers.Name);
            this.btnExportToExcel.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnExportToExcel.Name);
            this.btnShowHide.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnShowHide.Name);

            // ten form
            this.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.Name);

            // 20170307 Bug #660 [TimeKeeping] - Statistical Modules - Trang Vo Start
            lblProgress.Text = string.Empty;
            this.tbxCode.MaxLength = ConstantsValue.MAX_LENGTH_TEXT_BOX_VAR_CHAR;
            // 20170307 Bug #660 [TimeKeeping] - Statistical Modules - Trang Vo End
        }

        /// <summary>
        /// InitTreeList
        /// </summary>
        private void InitTreeList()
        {
            rootNode = new TreeNode();
            rootNode.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, "All");

            // set name = -1
            rootNode.Name = "-1";

            // set tag = ROOT_NODE
            rootNode.Tag = ConstantsValue.ROOT_NODE;

            // add root tree vao trvOrganizations
            trvOrganizations.Nodes.Add(rootNode);
        }

        /// <summary>
        /// LoadOrgAndSubOrgList
        /// </summary>
        private void LoadOrgAndSubOrgList()
        {
            //Call background worker if it's not busy
            if (!loadOrgWorker.IsBusy)
            {
                // Clear existing data
                subNodeSelected = null;

                // dtbMemberList.Rows.Clear();
                rootNode.Nodes.Clear();
                loadOrgWorker.RunWorkerAsync();
            }
        }
        #endregion

        #region init for org && suborg

        /// <summary>
        /// OnLoadOrgWorkerDoWork
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

                // GetOrgList
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
                // gan e.Result = result
                e.Result = result;
            }
        }

        /// <summary>
        /// OnLoadOrgWorkerCompleted
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        private void OnLoadOrgWorkerCompleted(object s, RunWorkerCompletedEventArgs e)
        {
            // cancel 
            if (e.Cancelled)
            {
                return;
            }

            // null
            if (e.Result == null || !(e.Result is List<OrgCustomerDto>))
            {
                return;
            }
            // gan bien 
            List<OrgCustomerDto> result = (List<OrgCustomerDto>)e.Result;

            // tao cay
            GetTree(result);
        }

        #endregion

        #endregion

        #region Form event

        /// <summary>
        /// su kien tbxMemberName_KeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxCode_KeyDown(object sender, KeyEventArgs e)
        {
            // kiem tra e.KeyCode == Keys.Enter
            if (e.KeyCode == Keys.Enter)
            {
                start = 0;

                // load member
                LoadMemberList();
            }
        }
        /// <summary>
        /// Event tree after select
        /// </summary>
        /// <param name="orgID"></param>
        /// <param name="parentId"></param>
        /// <param name="selectedOrgId"></param>
        private long GetOrgId(TreeNode node)
        {
            long orgId = -1;
            string tag = (string)node.Tag;

            // kiem tra ROOT_NODE
            while (!tag.Equals(ConstantsValue.ROOT_NODE) && tag != null)
            {
                string names = node.Name;
                orgId = Convert.ToInt64(names);
                node = node.Parent;
                tag = (string)node.Tag;
            }

            // orgid
            return orgId;
        }

        /// <summary>
        /// Tạo tree org 
        /// </summary>
        /// <param name="lstOrgCustomerDto"></param>
        public void GetTree(List<OrgCustomerDto> lstOrgCustomerDto)
        {
            // kiem tra null đây để sử dụng cho đệ quy
            if (lstOrgCustomerDto != null)
            {
                foreach (OrgCustomerDto org in lstOrgCustomerDto)
                {
                    // chi add vao tree cac org khong phai master
                    if (!org.Issuer.Equals(SystemSettings.Instance.Master))
                    {
                        TreeNode orgNode = new TreeNode();
                        orgNode.Text = org.Name;
                        orgNode.Name = Convert.ToString(org.OrgId);
                        orgNode.Tag = ConstantsValue.ORG_TAG;

                        // tạo tree con từ tree con tạo danh sách người
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
            // doi tượng này sử dụng cho vòng lặp đệ quy
            List<SubOrgCustomerDTO> lstSubOrgCustomerDTO = org.SubOrgList;

            // lọc kiểm tra điều kiện 
            if (null != lstSubOrgCustomerDTO)
            {
                List<SubOrgCustomerDTO> lstSubOrgCustomer = lstSubOrgCustomerDTO.Where(key => key.parentOrgId == orgId).ToList();

                // kiem tra lstSubOrgCustomer != null
                if (lstSubOrgCustomer != null)
                {
                    // duyet tren lstSubOrgCustomer
                    foreach (SubOrgCustomerDTO subOrg in lstSubOrgCustomer)
                    {
                        // neu la bao chi thi khong add
                        if (subOrg.OrgCode == ConstantsValue.CODE_BAO_CHI)
                            continue;

                        // con lai adđ vao
                        TreeNode subOrgNode = new TreeNode();
                        subOrgNode.Text = subOrg.Name;
                        subOrgNode.Name = Convert.ToString(subOrg.SubOrgId);
                        subOrgNode.Tag = ConstantsValue.SUB_TAG;

                        // điều kiện để add vào nút cha
                        if (orgId == subOrg.parentOrgId)
                        {
                            node.Nodes.Add(subOrgNode);
                        }

                        // gọi đệ quy
                        GetSubTree(org, subOrg.SubOrgId, subOrgNode);
                    }
                }
            }
        }

        /// <summary>
        /// su kien trvOrganizations_MouseDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trvOrganizations_MouseDown(object sender, MouseEventArgs e)
        {
            // kiem tra MouseButtons.Right
            if (e.Button == MouseButtons.Right)
            {
                TreeNode node = trvOrganizations.GetNodeAt(trvOrganizations.PointToClient(Control.MousePosition));
                if (node == null)
                {
                    // neu != rootNode thi show cmsOrgTree
                    if (node != rootNode)
                    {
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
            if (subNodeSelected != null)
            {
                subNodeSelected.NodeFont = new Font(startupNodeFont, FontStyle.Regular);
                subNodeSelected.Text = subNodeSelected.Text;
            }
        }
        /// <summary>
        /// su kien trvOrganizations_AfterSelect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trvOrganizations_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // 20170307 Bug #660 [TimeKeeping] - Statistical Modules - Trang Vo Start
            timeBegin = DateTime.Now;
            // gan start = 0. load tu page dau tien
            start = 0;

            lblProgress.Text = string.Empty;
            clearPnl();
            progressBarLoading.Value = 0;

            if (!isRuning)
            {
                // 20170307 Bug #660 [TimeKeeping] - Statistical Modules - Trang Vo End
                TreeNode selectedNode = e.Node;
                if (selectedNode != null)
                {
                    // neu la root thi dung lai
                    if (selectedNode.Tag != ConstantsValue.ROOT_NODE)
                    {
                        selectedNode.NodeFont = new Font(startupNodeFont, FontStyle.Bold);
                        selectedNode.Text = selectedNode.Text;

                        // kiem tra return
                        if (subNodeSelected != null && selectedNode == subNodeSelected)
                        {
                            return;
                        }
                        selectedSuborgParentNode = selectedNode.Parent;
                        subNodeSelected = selectedNode;

                        // neu selectedNode.Parent # null
                        if (null != selectedNode.Parent)
                        {
                            this.OrgId = GetOrgId(selectedNode);
                        }
                        else
                        {
                            this.OrgId = Convert.ToInt64(subNodeSelected.Name);
                        }

                        // gan bien SelectParentId va SelectId
                        this.SelectParentId = Convert.ToInt64(selectedSuborgParentNode.Name);
                        this.SelectId = Convert.ToInt64(subNodeSelected.Name);

                        // OrgId != -1 thi load member
                        if (OrgId != -1)
                        {
                            btnReloadMembers.Enabled = true;
                            btnExportToExcel.Enabled = true;
                            checkReport = true;

                            // clear data table
                            dtbExportData.Clear();
                            DisableControl(true);
                            LoadMemberList();
                        }
                    }
                    else
                    {
                        // Clear existing data
                        subNodeSelected = selectedNode;
                    }
                }
            }
        }

        /// <summary>
        /// Dung de show hay an cac button
        /// </summary>
        /// <param name="show"></param>
        private void SetHideToolStrip(bool show)
        {
            btnReloadMembers.Enabled = show;
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
                btnShowHide.Text = btnShowHide.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, btnShowHide.Name);
                btnShowHide.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, btnShowHide.Name);
                btnShowHide.Image = global::CommonControls.Properties.Resources.ArrowDown_16x16;
            }
            else
            {
                // hien khung tim kiem
                pnlFilterBox.Height = startupFilterBoxHeight;
                btnShowHide.Text = btnShowHide.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, btnShowHide.Name);
                btnShowHide.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, btnShowHide.Name);
                btnShowHide.Image = global::CommonControls.Properties.Resources.ArrowUp_16x16;
            }
        }
        /// <summary>
        /// su kien pagerPanel_LinkLabelClicked: khi click vao label so trang (paper index)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pagerPanel_LinkLabelClicked(object sender, LinkLabelClickedArgs e)
        {
            // khoi tao bien i
            int i;

            // enable control 
            DisableControl(true);

            // khi nhan nut <<
            if (e.LabelText.Equals(PagerPanel.LabelBackText))
            {

                // tinh toan load lai cho 6 user control
                // load member
                start = start - countPerPage;
                if (start < 0) start = 0;
                // tinh toan lai monlyreport

                currentPageIndex -= 1;
            }

            // khi nhan nut >>
            else if (e.LabelText.Equals(PagerPanel.LabelNextText))
            {
                // tinh toan load lai cho 6 user control
                // load member
                start = start + countPerPage;
                if (start > totalRecords) start = start - countPerPage;
                // tinh toan lai monlyreport
                currentPageIndex += 1;
            }

            // khi nhan cac label so trang con lai
            else if (int.TryParse(e.LabelText, out i))
            {
                // set currentPageIndex
                currentPageIndex = i;

                // tinh toan vi tri  bat dau
                start = ((i - 1) * countPerPage);

                // kiem tra start
                if (start < 0) start = 0;
                if (start > totalRecords) start = start - countPerPage;
            }
            else
            {
                return;
            }
            // dtbMemberList.Rows.Clear();
            //int take = countPerPage;
            //int skip = (currentPageIndex - 1) * take;
            //List<MemberCustomerDTO> result = MemberChipList.Skip(skip).Take(take).ToList();

            // DisableControl
            DisableControl(true);

            // load memberlist
            LoadMemberList();

            // xoa cao panel cu
            clearPnl();

            // uppdate PagingLinks
            pagerPanel.UpdatePagingLinks(totalRecords, countPerPage, currentPageIndex);
        }

        /// <summary>
        /// btnReloadMembers_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReloadMembers_Click(object sender, EventArgs e)
        {
            checkReport = true;

            // show message
            pagerPanel.ShowMessage(String.Empty);

            // clear data table
            dtbExportData.Clear();
            DisableControl(true);

            // gan start = 0
            start = 0;
            ///load
            LoadMemberList();
        }
        /// <summary>
        /// btnExportToExcel_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            // load report
            DisableControl(true);
            if (!loadReport.IsBusy && checkReport)
            {
                checkReport = false;
                // 20170307 Bug #660 [TimeKeeping] - Statistical Modules - Trang Vo Start
                // progress bar 
                progressBarLoading.Value = 10;
                lblProgress.Text = MessageValidate.GetMessage(rm, "lblIsLoading");

                List<MemberCustomerDTO> memberList = new List<MemberCustomerDTO>();

                // load list member day du
                memberList = OrganizationFactory.Instance.GetChannel().GetMemberList(storageService.CurrentSessionId, SelectId, SelectParentId, GetMemberFilter());

                //20170307 Bug #660 [TimeKeeping] - Statistical Modules - Trang Vo End
                loadReport.RunWorkerAsync(memberList);

            }
            DateTime now = DateTime.Now;
            // file name
            string fileName = MessageValidate.GetMessage(rm, this.lblRightDateStatisticDetail.Name) + "_" + dtpDate.Value.ToString("yyyyMMdd");

            // Show save file dialog
            string filePath = ControlExtMethods.ShowSaveFileDialog(MessageValidate.GetMessage(rm, "smsChooseFileExport"), fileName, "MS Excel (*.xls)|*.xls");

            if (filePath != null)
            {
                
                try
                {
                //    // export excel

                    // xuat file default, khong co tieu de
                //    ConfigExportFileModel configExportFile = new ConfigExportFileModel();
                //    configExportFile.FilePath = filePath;
                //    GemboxUtils.Instance.ExportDataGridToFile(dgvExportData, configExportFile);//tua de, xuat file
                //    GemboxUtils.Instance.ExportDataGridToFile(dgvExportData.Rows.Count);//tua de, xuat file

                //    GemboxUtils.Instance.AutoFix();
                //    try
                //    {
                //        GemboxUtils.Instance.Save();
                //    }
                //    catch (IOException x)
                //    {
                //        MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "fileExcelOpen"));
                //    }
                    // end

                    ConfigExportFileModel configExportFile = new ConfigExportFileModel();
                    configExportFile.FilePath = filePath;
                    GemboxUtils.Instance.SetPortrait(true);

                    GemboxUtils.Instance.ExportDataGridToFileCustom(dgvExportData, configExportFile, 9);//tua de, xuat file //13
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
                    String lbltitleLabelInfoMeetinginout = "THỐNG KÊ THEO NGÀY";
                    GemboxUtils.Instance.AddHeader(lbltitleLabelInfoMeetinginout == null ? string.Empty : lbltitleLabelInfoMeetinginout);

                    // int index = ConstantsEnum.positionIndexCol;//2
                    //int index = ConstantsEnum.Instance.positionIndexForPrint;
                    int index = 5;
                   // String lblGoverningOrganization = MessageValidate.GetMessage(rm, "lblGoverningOrganization");
                    String value = string.Empty;
                   // String value = (lblGoverningOrganization == null ? string.Empty : lblGoverningOrganization) + " " + (tbxOrgName.Text == null ? string.Empty : tbxOrgName.Text.ToString());
                    value = "Đơn vị thống kê: ";
                    GemboxUtils.Instance.AddCellCustom(index, 1, value == null ? string.Empty : value);
                    value = subNodeSelected.Text;
                    GemboxUtils.Instance.AddCellCustom(index, 2, value == null ? string.Empty : value);
                    index++;
                    value = "Ngày thống kê: ";
                    GemboxUtils.Instance.AddCellCustom(index, 1, value == null ? string.Empty : value);
                    value = dtpDate.Value.ToString("dd-MM-yyyy");
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
                    MessageBoxManager.ShowErrorMessageBox(this, ex.Message);
                    DisableControl(false);
                    return;
                }
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "smsLinkFile") + filePath);
                DisableControl(false);
            }
        }

        #endregion

        #region Functions for member

        /// <summary>
        /// Load MemberList
        /// </summary>
        private void LoadMemberList()
        {
            if (!loadMemberWorker.IsBusy)
            {
                MemberChipList = null;

                loadMemberWorker.RunWorkerAsync(GetMemberFilter());
                lblProgress.Text = string.Empty;
            }
        }

        /// <summary>
        /// Get MemberFilter
        /// </summary>
        /// <returns></returns>
        private MemberFilter GetMemberFilter()
        {

            MemberFilter filter = new MemberFilter();
            string strData = FormatCharacterSearch.CheckValue(tbxCode.Text.Trim());

            // neu strData co du lieu =>  set dieu kien loc
            if (strData != String.Empty)
            {
                filter.FilterByMemberName = true;
                filter.MemberName = strData;
            }
            return filter;
        }

        /// <summary>
        /// bgwMember_DoWork
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwMember_DoWork(object sender, DoWorkEventArgs e)
        {
            MemberFilter filter = e.Argument as sWorldModel.Filters.MemberFilter;
            int take = countPerPage;

            // check start 
            if (start == 0)
            {
                currentPageIndex = 1;

                // tinh toan total records
                TotalMemberDTO totalMember = null;

                totalMember = OrganizationFactory.Instance.GetChannel().getTotalMember(storageService.CurrentSessionId, SelectId, SelectParentId, filter);
                if (null != totalMember)
                {
                    totalRecords = (int)totalMember.totalMember;
                }
            }
            try
            {

                // get member list
                // MemberChipList = OrganizationFactory.Instance.GetChannel().GetMemberList(storageService.CurrentSessionId, SelectId, SelectParentId, filter);
                MemberChipList = OrganizationFactory.Instance.GetChannel().getMemberForPerPage(storageService.CurrentSessionId, SelectId, SelectParentId, filter, start, countPerPage);
            }
            catch (TimeoutException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "TimeOutExceptionMessage"));
                MemberChipList = null;
            }
            catch (FaultException<WcfServiceFault> ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
                MemberChipList = null;
            }
            catch (FaultException ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "FaultExceptionMessage")
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
                MemberChipList = null;
            }
            catch (CommunicationException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "CommunicationExceptionMessage"));
                MemberChipList = null;
            }
            finally
            {
                if (MemberChipList != null && MemberChipList.Count > 0)
                {
                    // update load member khong phai cua bao chi start
                    //List<Member> listMember = new List<Member>();
                    //foreach (Member member in MemberChipList)
                    //{
                    //    if (member.Title == ConstantsValue.TITLE_BAO_CHI)
                    //        continue;
                    //    else listMember.Add(member);
                    //}
                    //MemberChipList = listMember;
                    // update load member khong phai cua bao chi end



                    // update PagingLinks
                    pagerPanel.UpdatePagingLinks(totalRecords, countPerPage, currentPageIndex);
                }
                // 20170306 Bug Load member - Trang Vo Start
                else
                {
                    // thong bao loi
                    if (tbxCode.Text.Trim() != string.Empty)
                        MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "SearchNull"));
                    else
                        MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "NotMember"));

                    DisableControl(false);
                }
                // 20170306 Bug Load member - Trang Vo End
                e.Result = MemberChipList;
            }
        }

        /// <summary>
        /// bgwMember_WorkerCompleted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwMember_WorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblProgress.Text = string.Empty;
            if (e.Cancelled)
            {

                DisableControl(false);
                return;

            }
            if (e.Result == null)
            {

                DisableControl(false);
                return;
            }
            List<MemberCustomerDTO> result = e.Result as List<MemberCustomerDTO>;

            // 20170306 Bug Load member - Trang Vo Start

            // load data
            if (MemberChipList != null && MemberChipList.Count > 0)
            {
                lblProgress.Text = MessageValidate.GetMessage(rm, "lblIsLoading");
                LoadMemberDataGridView(MemberChipList);
                this.btnExportToExcel.Enabled = true;

                // loadReport
                //if (!loadReport.IsBusy && checkReport)
                //{
                //    List<MemberCustomerDTO> memList = new List<MemberCustomerDTO>();

                //    // tao list member cus dto
                //    foreach (Member mem in MemberChipList)
                //    {
                //        MemberCustomerDTO memdto = new MemberCustomerDTO();
                //        memdto.Member = new Member();
                //        memdto.Member.Id = mem.Id;
                //        memList.Add(memdto);
                //    }
                //    loadReport.RunWorkerAsync(memList);
                //}
            }
            else
            {
                lblProgress.Text = string.Empty;
                this.btnExportToExcel.Enabled = false;

                DisableControl(false);
            }
            // 20170306 Bug Load member - Trang Vo End
        }

        #endregion

        #region report

        /// <summary>
        /// bgwReport_DoWork: load report 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwReport_DoWork(object sender, DoWorkEventArgs e)
        {
            // chuan bi du lieu
            MonthlyReport month = null;
            List<MonthlyReport> monthList = new List<MonthlyReport>();
            List<MemberCustomerDTO> memList = e.Argument as List<MemberCustomerDTO>;
            List<long> idList = new List<long>();
            int y = dtpDate.Value.Year, m = dtpDate.Value.Month;

            // neu memList co count > 0
            if (null != memList && memList.Count != 0)
                try
                {
                    foreach (MemberCustomerDTO mem in memList)
                    {
                        long memId = mem.Member.Id;
                        string dateString = dtpDate.Value.ToString("yyyy-MM-dd");
                        // GetTimeKeepingMonthlyReport
                        month = TimeKeepingFactory.Instance.GetChannel().GetTimeKeepingMonthlyReport(StorageService.CurrentSessionId,
                                   memId, y, m);

                        // kiem tra ngay dtpDate.Value.Day da duoc tinh toan chua?: ==-1 la chua tinh toan
                        if (null != month && DayOffMonthlyReport(dtpDate.Value.Day, month) == -1)
                        {
                            idList = new List<long>();
                            idList.Add(memId);
                            // chua tinh toan thì goi ham tinh toan lai: insertOrUpdateMonthlyReport
                            TimeKeepingFactory.Instance.GetChannel().insertOrUpdateMonthlyReport(StorageService.CurrentSessionId,
                                  dateString, dateString, idList);
                            // GetTimeKeepingMonthlyReport
                            month = TimeKeepingFactory.Instance.GetChannel().GetTimeKeepingMonthlyReport(StorageService.CurrentSessionId, memId, y, m);
                        }
                        if (null != month)
                        {
                            monthList.Add(month);
                        }
                        else
                        {
                            // chuan bi du lieu
                            // insert -1 xuong thang moi chua duoc tinh toan 
                            int reInsert = TimeKeepingFactory.Instance.GetChannel().insertMonthlyReportDefault(
                                 StorageService.CurrentSessionId, OrgId, SelectId, memId, y, m);
                            // goi ham tinh toan lai: insertOrUpdateMonthlyReport
                            TimeKeepingFactory.Instance.GetChannel().insertOrUpdateMonthlyReport(StorageService.CurrentSessionId,
                                dateString, dateString, idList);
                            // GetTimeKeepingMonthlyReport
                            month = TimeKeepingFactory.Instance.GetChannel().GetTimeKeepingMonthlyReport(
                               StorageService.CurrentSessionId, memId, y, m);
                            if (null != month)
                            {
                                monthList.Add(month);
                            }
                        }
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
                    // load data
                    LoadDataToGridView(memList, monthList);
                    e.Result = monthList;
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

                return;
            }
            if (e.Result == null)
            {

                return;
            }
            List<MonthlyReport> result = e.Result as List<MonthlyReport>;
            // load Report data
            // MonthlyReportresult = result;
            lblProgress.Text = string.Empty;
            progressBarLoading.Value = 100;
            LoadReportToLabel(result);

        }
        /// <summary>
        /// load data to report table
        /// </summary>
        /// <param name="reportList"></param>
        private void LoadReportToLabel(List<MonthlyReport> reportList)
        {
            int y = dtpDate.Value.Year, m = dtpDate.Value.Month, d = dtpDate.Value.Day;
            timeLate = 0; timeHaltDayOff = 0; timeDayOff = 0; timeHaltDayOffNo = 0; timeDayOffNo = 0;
            // tinh toan lai ngay duoc chon
            foreach (MonthlyReport rep in reportList)
            {
                caculTimes(DayOffMonthlyReport(d, rep));
            }
            txtT.Text = timeLate + String.Empty;
            txtP.Text = (timeDayOff + timeHaltDayOff / 2 + (timeHaltDayOff % 2 == 0 ? 0 : 1)) + String.Empty;
            txtK.Text = (timeDayOffNo + timeHaltDayOffNo / 2 + (timeHaltDayOffNo % 2 == 0 ? 0 : 1)) + String.Empty;

            // 20170307 Bug #660 [TimeKeeping] - Statistical Modules - Trang Vo Start
            // progress bar
            progressBarLoading.Value = 100;
            lblProgress.Text = MessageValidate.GetMessage(rm, "done");
            // Thread.Sleep(500);
            DisableControl(false);
            // 20170307 Bug #660 [TimeKeeping] - Statistical Modules - Trang Vo End


            // debug 
            timeEnd = DateTime.Now;
            Debug.WriteLine("------------ <Trang> ---- Caculator for date: report " + timeBegin.ToString("hh:mm:ss.fff tt"));
            Debug.WriteLine("------------ <Trang> ---- Caculator for date: report " + timeEnd.ToString("hh:mm:ss.fff tt"));
            Debug.WriteLine("------------ <Trang> ---- Caculator for date: report " + (timeEnd.ToBinary() - timeBegin.ToBinary()));
        }

        /// <summary>
        /// tính toán vang, tre
        /// </summary>
        /// <param name="dayValue"></param>
        private void caculTimes(int dayValue)
        {
            if (dayValue == (int)TimeKeepingStatus.DI_TRE_VE_SOM) timeLate++;
            if (dayValue == (int)TimeKeepingStatus.VANG_NUA_NGAY_PHEP) timeHaltDayOff++;
            if (dayValue == (int)TimeKeepingStatus.VANG_CA_NGAY_PHEP) timeDayOff++;
            if (dayValue == (int)TimeKeepingStatus.VANG_NUA_NGAY_KO_PHEP) timeHaltDayOffNo++;
            if (dayValue == (int)TimeKeepingStatus.VANG_CA_NGAY_KO_PHEP) timeDayOffNo++;
        }
        /// <summary>
        /// get gia tri cua ngay d trong 1 monthlyreport
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
        /// load du lieu vao datagridview
        /// </summary>
        /// <param name="memList"></param>
        /// <param name="monthList"></param>
        private void LoadDataToGridView(List<MemberCustomerDTO> memList, List<MonthlyReport> monthList)
        {
            dtbExportData.Clear();
            // load data to dtbExportData 
            if (null != monthList && monthList.Count != 0)
            {
                int member_size = memList.Count;

                for (int i = 0; i < member_size; i++)
                {
                    DataRow row = dtbExportData.NewRow();
                    row.BeginEdit();
                    // set du lieu cho cac row
                    row[colCode.DataPropertyName] = memList[i].Member.Code;
                    row[colName.DataPropertyName] = memList[i].Member.LastName + " " + memList[i].Member.FirstName;
                    row[colDate.DataPropertyName] = dtpDate.Value.ToString("dd/MM/yyyy");
                    // get cac du lieu tu server
                    // shift
                    ShiftFilterDto filter = ToShiftFilterDto(memList[i].Member.Id, dtpDate.Value);
                    List<Shift> shiftList = new List<Shift>();
                   // shiftList = TimeKeepingShiftFactory.Instance.GetChannel().getShiftListByShiftFilter(StorageService.CurrentSessionId, filter);
                   shiftList= TimeKeepingShiftFactory.Instance.GetChannel().getShift(StorageService.CurrentSessionId, dtpDate.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                                dtpDate.Value.ToString("yyyy-MM-dd HH:mm:ss "), memList[i].Member.Id+"", 0, 0);
                    if (null == shiftList) shiftList = new List<Shift>();
                    if (shiftList.Count > 0)
                    {
                        // set du lieu gio vao, gio ra
                        DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                        DateTime startDate = start.AddMilliseconds(long.Parse(shiftList[0].dateIn)).ToLocalTime();
                        DateTime endDate = start.AddMilliseconds(long.Parse(shiftList[shiftList.Count - 1].dateIn)).ToLocalTime();
                        if (endDate.Hour - startDate.Hour == 0 && endDate.Minute - startDate.Minute <= 10)
                         {
                            if(startDate.Hour < 12)
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
                   // row[colStatus.DataPropertyName] = GetStatus(GetStatusForMember(dtpDate.Value.Day, monthList, memList[i]));
                    row.EndEdit();
                    dtbExportData.Rows.Add(row);
                }
            }
            DisableControl(false);

          
        }
        /// <summary>
        /// get status cua 1 nguoi trong 1 ngay
        /// </summary>
        /// <param name="day"></param>
        /// <param name="monthList"></param>
        /// <param name="memDTO"></param>
        /// <returns></returns>
        private int GetStatusForMember(int day, List<MonthlyReport> monthList, MemberCustomerDTO memDTO)
        {
            int status = -1;
            MonthlyReport month = null;
            for (int i = 0; i < monthList.Count; i++)
            {
                if (memDTO.Member.Id == monthList[i].memberId)
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
        /// split Shift
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        private Dictionary<long, List<Shift>> splitShift(string memberId)
        {
            List<Shift> lst = TimeKeepingShiftFactory.Instance.GetChannel().getShift(StorageService.CurrentSessionId, dtpDate.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                                dtpDate.Value.ToString("yyyy-MM-dd HH:mm:ss "), memberId, 0, 0);// da co memberid, tim theo memberId va list date

            Dictionary<long, List<Shift>> dic = new Dictionary<long, List<Shift>>();
            if (null != lst)
                // gan vao Dictionary
                foreach (Shift shift in lst)
                {
                    if (!dic.ContainsKey(shift.memberId))
                    {
                        List<Shift> list = new List<Shift>();
                        list.Add(shift);
                        dic.Add(shift.memberId, list);
                    }
                    else
                    {
                        dic[shift.memberId].Add(shift);
                    }

                }

            return dic;
        }

        /// <summary>
        /// Load Member Data Grid View
        /// </summary>
        /// <param name="result"></param>
        private void LoadMemberDataGridView(List<Member> result)
        {
            /////load report
            //if (!loadReport.IsBusy && checkReport)
            //{
            //    checkReport = false;
            //    ///20170307 Bug #660 [TimeKeeping] - Statistical Modules - Trang Vo Start
            //    ///progress bar 
            //    progressBar1.Value = 10;

            //    ///20170307 Bug #660 [TimeKeeping] - Statistical Modules - Trang Vo End
            //    loadReport.RunWorkerAsync(MemberChipList);
            //}

            // progressBarLoading
            progressBarLoading.Value = 10;

            // const cho colorConfigList & timeConfig
            List<ColorConfig> colorConfigList = TimeDetail.getColorConfigList(StorageService.CurrentSessionId, OrgId);
            TimeDetail.colorConfigList = colorConfigList;
            List<TimeConfig> timeConfig = TimeDetail.getTimeConfig(StorageService.CurrentSessionId, OrgId);
            TimeDetail.timeConfig = timeConfig;
            TimeDetail.Session = StorageService.CurrentSessionId;
            TimeDetail.OrgId = OrgId;
            
            // date time
            DateTime date = dtpDate.Value;
            dateCheck = dtpDate.Value;

            // prepare for ListTimeDetail
            string dateString = date.ToString("yyyy-MM-dd HH:mm:ss");
            ConfigForStatisticDTO config;
            List<List<UserTimeConfig>> ListUserTimeConfig = null;
            DayOffConfig dayoff;
            int checkHoliday;
            // listTimeDetail & listEvent
            List<List<TimeDetail>> list = new List<List<TimeDetail>>();
            List<Event> listEvent = new List<Event>();

            int member_size = result.Count;

            clearPnl();

            List<sheet1> listSheet = new List<sheet1>();

            // get list shift
            string memberIdString = string.Empty;
            for (int i = 0; i < member_size; i++)
            {
                memberIdString += result[i].Id + ",";
            }
            memberIdString = memberIdString.Substring(0, memberIdString.Length - 1);// tru dau , cuoi

            Dictionary<long, List<Shift>> dicShift = splitShift(memberIdString);
            List<Shift> listShift = null;

            // get list sheet
            for (int i = 0; i < member_size; i++)
            {
                // CONVERT TO LIST TIMEDETAIL
                if (null != dicShift && dicShift.Count > 0)
                {
                    if (dicShift.ContainsKey(result[i].Id))
                        listShift = dicShift[result[i].Id];
                    else
                        listShift = new List<Shift>();
                }
                else
                {
                    listShift = new List<Shift>();
                }
                // prepare for ListTimeDetail
                // get config of each member 
                List<long> memberList = new List<long>();
                memberList.Add(result[i].Id);

                // Dong lai, khong dung cho VPUB
                //ListUserTimeConfig = TimeKeepingUserTimeConfigFactory.Instance.GetChannel().getListUserTimeConfigByMemberId(StorageService.CurrentSessionId, OrgId, memberList);
                
                // dayoff
                string dateStringDayOff = date.ToString("dd/MM/yyyy");
                dayoff = TimeKeepingDayOffConfigFactory.Instance.GetChannel().getDayOffByMemberIdAndDate(StorageService.CurrentSessionId, result[i].Id, dateStringDayOff);
                
                //checkHoliday = TimeKeepingHolidayConfigFactory.Instance.GetChannel().checkHoliday(StorageService.CurrentSessionId, dateCheck, OrgId);
                checkHoliday = TimeDetail.checkHolidayOfOrg(StorageService.CurrentSessionId, OrgId, dateCheck);

                // get ConfigForStatisticDTO tu server
                config = TimeKeepingTimeConfigFactory.Instance.GetChannel().GetTimeConfigEventConfigByFilter(StorageService.CurrentSessionId, result[i].Id, dateString, OrgId);

                // tinh toan list timedetail
                // list = TimeDetail.ListTimeDetail(StorageService.CurrentSessionId, OrgId, listShift, result[i].Id, dtpDate.Value, dateCheck);
                list = TimeDetail.ListTimeDetailForMiniSheet(listShift, config, ListUserTimeConfig, dayoff, date, checkHoliday);

                // kiem tra ConfigForStatisticDTO tu server
                if (null != config)
                {
                    if (null == config.eventList)
                        listEvent = new List<Event>();
                    else
                        listEvent = config.eventList;

                    // tao control sheet => gan vao panel
                    sheet1 s = new sheet1(i, result[i].LastName + " " + result[i].FirstName, list, listEvent);
                    s.Width = sheetWidth;
                    workItem.SmartParts.Add(s);
                    listSheet.Add(s);
                }
            }
            //add panel
            int len = listSheet.Count;
            if (len > 0) panel5.Controls.Add(listSheet[0]);
            if (len > 1) panel6.Controls.Add(listSheet[1]);
            if (len > 2) panel9.Controls.Add(listSheet[2]);
            if (len > 3) panel10.Controls.Add(listSheet[3]);
            if (len > 4) panel11.Controls.Add(listSheet[4]);
            if (len > 5) panel12.Controls.Add(listSheet[5]);
            if (len > 6) panel13.Controls.Add(listSheet[6]);
            if (len > 7) panel14.Controls.Add(listSheet[7]);
            lblProgress.Text = string.Empty;

            progressBarLoading.Value = 100;
            DisableControl(false);

            // debug
            timeEnd = DateTime.Now;
            Debug.WriteLine("------------ <Trang> ---- Caculator for date: statistic " + timeBegin.ToString("hh:mm:ss.fff tt"));
            Debug.WriteLine("------------ <Trang> ---- Caculator for date: statistic " + timeEnd.ToString("hh:mm:ss.fff tt"));
            Debug.WriteLine("------------ <Trang> ---- Caculator for date: statistic " + (timeEnd.ToBinary() - timeBegin.ToBinary()));
        }
        /// <summary>
        /// clear all panel detail
        /// </summary>
        private void clearPnl()
        {
            panel5.Controls.Clear();
            panel6.Controls.Clear();
            panel9.Controls.Clear();
            panel10.Controls.Clear();
            panel11.Controls.Clear();
            panel12.Controls.Clear();
            panel13.Controls.Clear();
            panel14.Controls.Clear();
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
                btnExportToExcel.Enabled = btnReloadMembers.Enabled
               = dtpDate.Enabled = tbxCode.Enabled = !isRunning;

                trvOrganizations.Enabled = !isRunning;
            }
            catch (Exception e)
            {

            }
           
        }
        //20170307 Bug #660 [TimeKeeping] - Statistical Modules - Trang Vo End
        /// <summary>
        /// Tao ShiftFilterDto
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

        #region CAB events
        [CommandHandler(TimeCommandName.ShowDateStatistic)]
        public void ShowMemberMgtMainHandler(object s, EventArgs e)
        {
            UsrDateStatistic uc = workItem.Items.Get<UsrDateStatistic>(DefineName.DateStatistic);
            if (uc == null)
            {
                uc = workItem.Items.AddNew<UsrDateStatistic>(DefineName.DateStatistic);
            }
            else if (uc.IsDisposed)
            {
                workItem.Items.Remove(uc);
                uc = workItem.Items.AddNew<UsrDateStatistic>(DefineName.DateStatistic);
            }
            workItem.Workspaces[WorkspaceName.MainWorkspace].Show(uc);
            uc.Parent.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, DefineName.MenuDateStatistic);
        }

        #endregion



    }
}
