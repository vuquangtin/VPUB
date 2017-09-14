using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Microsoft.Practices.CompositeUI;
using System.ServiceModel;
using CommonHelper.Constants;
using Microsoft.Practices.CompositeUI.EventBroker;
using CommonHelper.Config;
using CommonControls.Custom;
using Microsoft.Practices.CompositeUI.Commands;
using CommonControls;
using System.Linq;
using sWorldModel.Exceptions;
using sWorldModel.Filters;
using sWorldModel;
using sWorldModel.TransportData;
using JavaCommunication.Factory;
using CommonHelper.Utils;
using System.Resources;
using sTimeKeeping.Constants;
using sTimeKeeping.Model;
using sTimeKeeping.Factory;
using System.IO;
using ClientModel.Model;
using ClientModel.Utils;
using System.Diagnostics;

namespace sTimeKeeping.WorkItems
{
    public partial class UsrMonthStatistic : CommonUserControl
    {
        #region Properties


        private int currentPageIndex = 1;
        private DataTable dtbMemberList;
        private BackgroundWorker loadOrgWorker;
        private BackgroundWorker loadMemberWorker;
        private List<MemberCustomerDTO> MemberChipList;
        private List<OrgCustomerDto> result = null;
        private Font startupNodeFont;
        private TreeNode rootNode;
        private TreeNode selectedSuborgParentNode;
        private TreeNode subNodeSelected;
        private ResourceManager rm;

        // id to chuc
        private long OrgId = 0;
        // id parent suborg select
        private long SelectParentId = 0;
        // id nguoi dung select in tree
        private long SelectId = 0;

        // debug 
        private DateTime timeBegin;
        private DateTime timeEnd;


        private int startupFilterBoxHeight;
        private const int hiddenFilterBoxHeight = 1;

        private TimeKeepingComponentWorkItem workItem;

        [ServiceDependency]
        public TimeKeepingComponentWorkItem WorkItem
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
            set { storageService = value; }
        }

        #endregion

        #region Initialization

        public UsrMonthStatistic()
        {
            // init
            InitializeComponent();
            InitOrganizationsGrid();
            // cac su kien cua tree
            trvOrganizations.BeforeSelect += trvOrganizations_BeforeSelect;
            trvOrganizations.AfterSelect += trvOrganizations_AfterSelect;
            trvOrganizations.MouseDown += trvOrganizations_MouseDown;
            // load org cho tree
            loadOrgWorker = new BackgroundWorker();
            loadOrgWorker.WorkerSupportsCancellation = true;
            loadOrgWorker.DoWork += OnLoadOrgWorkerDoWork;
            loadOrgWorker.RunWorkerCompleted += OnLoadOrgWorkerCompleted;
            // load member to table
            loadMemberWorker = new BackgroundWorker();
            loadMemberWorker.WorkerSupportsCancellation = true;
            loadMemberWorker.DoWork += bgwMember_DoWork;
            loadMemberWorker.RunWorkerCompleted += bgwMember_WorkerCompleted;
            // gan su kien cho control
            btnShowHide.Click += btnShowHide_Clicked;
            pagerPanel.LinkLabelClicked += pagerPanel_LinkLabelClicked;
            dgvShiftList.CellDoubleClick += dgvShiftList_CellDoubleClick;
            // key down enter
            tbxCode.TextChanged += tbxCode_TextChanged;
        }

        /// <summary>
        /// load form
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
            InitTreeList();
            LoadOrgAndSubOrgList();
            pagerPanel.StorageService = StorageService;
            pagerPanel.LoadLanguage();
            SetAllLabel();

            // Assign startup value
            startupFilterBoxHeight = pnlFilterBox.Height;
            startupNodeFont = trvOrganizations.Font;

            // InitializaCombobox
            InitializaCombobox();
        }

        #region init for languages

        /// <summary>
        /// set label
        /// </summary>
        private void SetAllLabel()
        {
            this.btnShowHide.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnShowHide.Name);
            this.btnReloadMembers.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnReloadMembers.Name);
            this.btnExportToExcel.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnExportToExcel.Name);
            this.colMCode1.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colMCode1.Name);
            this.colName.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colName.Name);
            this.colVP.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colVP.Name);
            this.colVP1.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colVP1.Name);
            this.colVKP.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colVKP.Name);
            this.colVKP1.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colVKP1.Name);
            this.colLate.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colLate.Name);

            this.tbxCode.MaxLength = ConstantsValue.MAX_LENGTH_TEXT_BOX_VAR_CHAR;
        }
        #endregion

        #region event for tree org
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

        /// <summary>
        /// Load Org And SubOrg List
        /// </summary>
        private void LoadOrgAndSubOrgList()
        {
            // Call background worker if it's not busy
            if (!loadOrgWorker.IsBusy)
            {
                // Clear existing data
                subNodeSelected = null;
                // dtbMemberList.Rows.Clear();
                rootNode.Nodes.Clear();
                loadOrgWorker.RunWorkerAsync();
            }
        }

        /// <summary>
        /// su kien OnLoadOrgWorkerDoWork
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

                // get org
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
        /// su kien OnLoadOrgWorkerCompleted
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

            // get tree
            GetTree(result);
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
            while (node.Tag != ConstantsValue.ROOT_NODE)
            {
                orgId = Convert.ToInt64(node.Name);
                node = node.Parent;
            }

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
            if (e.Button == MouseButtons.Right)
            {
                TreeNode node = trvOrganizations.GetNodeAt(trvOrganizations.PointToClient(Control.MousePosition));
                if (node == null)
                {
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
            //20170307 Bug #660 [TimeKeeping] - Statistical Modules - Trang Vo End
            /// show message
            pagerPanel.ShowMessage(String.Empty);

            /// debug
            timeBegin = DateTime.Now;

            //progress bar 
            progressBarLoading.Value = 0;
            // show message
            pagerPanel.ShowMessage(MessageValidate.GetMessage(rm, "lblIsLoading"));

            TreeNode selectedNode = e.Node;
            if (selectedNode != null)
            {
                selectedNode.NodeFont = new Font(startupNodeFont, FontStyle.Bold);
                selectedNode.Text = selectedNode.Text;
                selectedSuborgParentNode = selectedNode;
                if (subNodeSelected != null && selectedNode == subNodeSelected)
                {
                    return;
                }

                // gan gia tri cho selectedSuborgParentNode
                if (null == selectedNode.Parent)
                {
                    selectedSuborgParentNode.Name = -1 + string.Empty;
                }
                else
                {
                    selectedSuborgParentNode = selectedNode.Parent;
                }
                subNodeSelected = selectedNode;

                // get orgId
                if (null != selectedNode.Parent)
                    this.OrgId = GetOrgId(selectedNode);
                else this.OrgId = Convert.ToInt64(subNodeSelected.Name);

                this.SelectParentId = Convert.ToInt64(selectedSuborgParentNode.Name);
                this.SelectId = Convert.ToInt64(subNodeSelected.Name);

                // org # -1: load member list
                if (OrgId != -1)
                {
                    // progress bar 
                    progressBarLoading.Value = 5;
                    // show message
                    pagerPanel.ShowMessage(MessageValidate.GetMessage(rm, "lblIsLoading"));

                    this.btnExportToExcel.Enabled = btnReloadMembers.Enabled = true;
                    LoadMemberList();
                }
            }

        }
        #endregion

        #endregion

        #region Form event

        /// <summary>
        /// su kien tbxMemberName_KeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxMemberName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadMemberList();
            }
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
                btnShowHide.Text = btnShowHide.ToolTipText = MessageValidate.GetMessage(rm, "btnShowHide");
                btnShowHide.ToolTipText = MessageValidate.GetMessage(rm, "btnShowHide");
                btnShowHide.Image = global::CommonControls.Properties.Resources.ArrowDown_16x16;
            }
            else
            {
                // hien khung tim kiem
                pnlFilterBox.Height = startupFilterBoxHeight;
                btnShowHide.Text = btnShowHide.ToolTipText = MessageValidate.GetMessage(rm, "btnShowHide");
                btnShowHide.ToolTipText = MessageValidate.GetMessage(rm, "btnShowHide");
                btnShowHide.Image = global::CommonControls.Properties.Resources.ArrowUp_16x16;
            }
        }
        /// <summary>
        /// su kien pagerPanel_LinkLabelClicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pagerPanel_LinkLabelClicked(object sender, LinkLabelClickedArgs e)
        {
            //progress bar 
            progressBarLoading.Value = 5;
            // show message
            pagerPanel.ShowMessage(MessageValidate.GetMessage(rm, "lblIsLoading"));

            int i;
            // khi nhan vao label <<
            if (e.LabelText.Equals(PagerPanel.LabelBackText))
            {
                currentPageIndex -= 1;
            }
            // khi nhan vao >>
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
            dtbMemberList.Rows.Clear();
            int take = LocalSettings.Instance.RecordsPerPage;
            int skip = (currentPageIndex - 1) * take;

            // Load Member to DataGridView 
            List<MemberCustomerDTO> result = MemberChipList.Skip(skip).Take(take).ToList();
            LoadMemberDataGridView(result);

            // ShowNumberOfRecords and UpdatePagingLinks
            pagerPanel.UpdatePagingLinks(MemberChipList.Count, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
            pagerPanel.ShowMessage(MessageValidate.GetMessage(rm, "done"));
        }

        /// <summary>
        /// su kien dgvShiftList_CellDoubleClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvShiftList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                // neu column khong phai colName, colMCode1, colVP, colVP1, colVKP, colVKP1, colLate thi thuc hien CellDoubleClick
                if (e.ColumnIndex != colName.Index && e.ColumnIndex != colMCode1.Index && e.ColumnIndex != colVP.Index && e.ColumnIndex != colVP1.Index
                    && e.ColumnIndex != colVKP.Index && e.ColumnIndex != colVKP1.Index && e.ColumnIndex != colLate.Index)
                {
                    // chuan bi du lieu
                    long memId = long.Parse(dgvShiftList.Rows[e.RowIndex].Cells[colId.Index].Value.ToString());
                    string memName = dgvShiftList.Rows[e.RowIndex].Cells[colName.Index].Value.ToString();
                    string memCode = dgvShiftList.Rows[e.RowIndex].Cells[colMCode1.Index].Value.ToString();
                    string strdate = cbxYear.SelectedItem.ToString() + "-" + cbxMonth.SelectedItem.ToString() + "-" + (e.ColumnIndex - 7);
                    DateTime date = new DateTime(int.Parse(cbxYear.SelectedItem.ToString()), int.Parse(cbxMonth.SelectedItem.ToString()), e.ColumnIndex - 7);
                    // show form
                    FrmTimeStatisticDetail frmdetail = new FrmTimeStatisticDetail(memCode, memName, date, memId, OrgId);
                    //frmdetail.ShowDialog();
                    workItem.SmartParts.Add(frmdetail);
                    frmdetail.Show();
                    //workItem.SmartParts.Remove(frmdetail);
                    // frmdetail.Hide();
                }
            }

        }
        /// <summary>
        /// btnReloadMembers_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReloadMembers_Click(object sender, EventArgs e)
        {
            //progress bar 
            progressBarLoading.Value = 5;
            // show message
            pagerPanel.ShowMessage(MessageValidate.GetMessage(rm, "lblIsLoading"));

            if (SelectId == -1) SelectId = OrgId;
            LoadMemberList();
        }
        /// <summary>
        /// tbxCode_KeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxCode_TextChanged(object sender, EventArgs e)
        {
            LoadMemberList();
        }
        #endregion

        #region Event's support

        #region PartnerInfo and initializaCombobox

        /// <summary>
        /// InitializaCombobox
        /// </summary>
        private void InitializaCombobox()
        {
            DateTime date = DateTime.Now;

            List<int> dataSource = new List<int>();
            int numYear = 5; // tong so nam
            int numBegin = 2014; // nam bat dau
            for (int i = 0; i < numYear; i++)
            {
                // tao datasource
                dataSource.Add(numBegin + i);
            }
            // gan datasource
            cbxYear.DataSource = dataSource;
            cbxYear.SelectedItem = dataSource[dataSource.IndexOf(date.Year)];

            dataSource = new List<int>();
            int numMonth = 12; // tong so thang
            for (int i = 1; i <= numMonth; i++)
            {
                //  tao datasource
                dataSource.Add(i);
            }
            // gan datasource
            cbxMonth.DataSource = dataSource;
            cbxMonth.SelectedItem = dataSource[dataSource.IndexOf(date.Month)];
        }

        #endregion

        #region Functions for organization
        /// <summary>
        /// init data source cho gridview
        /// </summary>
        private void InitOrganizationsGrid()
        {
            dtbMemberList = new DataTable();
            dtbMemberList.Columns.Add(colId.DataPropertyName);
            dtbMemberList.Columns.Add(colName.DataPropertyName);
            dtbMemberList.Columns.Add(colMCode1.DataPropertyName);
            dtbMemberList.Columns.Add(colVP.DataPropertyName);
            dtbMemberList.Columns.Add(colVP1.DataPropertyName);
            dtbMemberList.Columns.Add(colVKP.DataPropertyName);
            dtbMemberList.Columns.Add(colVKP1.DataPropertyName);
            dtbMemberList.Columns.Add(colLate.DataPropertyName);
            dtbMemberList.Columns.Add(col1.DataPropertyName);
            dtbMemberList.Columns.Add(col2.DataPropertyName);
            dtbMemberList.Columns.Add(col3.DataPropertyName);
            dtbMemberList.Columns.Add(col4.DataPropertyName);
            dtbMemberList.Columns.Add(col5.DataPropertyName);
            dtbMemberList.Columns.Add(col6.DataPropertyName);
            dtbMemberList.Columns.Add(col7.DataPropertyName);
            dtbMemberList.Columns.Add(col8.DataPropertyName);
            dtbMemberList.Columns.Add(col9.DataPropertyName);
            dtbMemberList.Columns.Add(col10.DataPropertyName);
            dtbMemberList.Columns.Add(col11.DataPropertyName);
            dtbMemberList.Columns.Add(col12.DataPropertyName);
            dtbMemberList.Columns.Add(col13.DataPropertyName);
            dtbMemberList.Columns.Add(col14.DataPropertyName);
            dtbMemberList.Columns.Add(col15.DataPropertyName);
            dtbMemberList.Columns.Add(col16.DataPropertyName);
            dtbMemberList.Columns.Add(col17.DataPropertyName);
            dtbMemberList.Columns.Add(col18.DataPropertyName);
            dtbMemberList.Columns.Add(col19.DataPropertyName);
            dtbMemberList.Columns.Add(col20.DataPropertyName);
            dtbMemberList.Columns.Add(col21.DataPropertyName);
            dtbMemberList.Columns.Add(col22.DataPropertyName);
            dtbMemberList.Columns.Add(col23.DataPropertyName);
            dtbMemberList.Columns.Add(col24.DataPropertyName);
            dtbMemberList.Columns.Add(col25.DataPropertyName);
            dtbMemberList.Columns.Add(col26.DataPropertyName);
            dtbMemberList.Columns.Add(col27.DataPropertyName);
            dtbMemberList.Columns.Add(col28.DataPropertyName);
            dtbMemberList.Columns.Add(col29.DataPropertyName);
            dtbMemberList.Columns.Add(col30.DataPropertyName);
            dtbMemberList.Columns.Add(col31.DataPropertyName);
            dgvShiftList.DataSource = dtbMemberList;
        }

        #endregion

        #region Functions for member
        /// <summary>
        /// Load Member List
        /// </summary>
        private void LoadMemberList()
        {
            if (!loadMemberWorker.IsBusy)
            {
                dtbMemberList.Rows.Clear();
                MemberChipList = null;

                loadMemberWorker.RunWorkerAsync(GetMemberFilter());
            }
        }
        /// <summary>
        /// Get Member Filter
        /// </summary>
        /// <returns></returns>
        private MemberFilter GetMemberFilter()
        {
            MemberFilter filter = new MemberFilter();
            string strData = FormatCharacterSearch.CheckValue(tbxCode.Text.Trim());
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
            int totalRecords = 0;
            int take = LocalSettings.Instance.RecordsPerPage;
            int skip = 0;
            currentPageIndex = 1;
            List<MemberCustomerDTO> result = null;
            MemberFilter filter = e.Argument as sWorldModel.Filters.MemberFilter;
            // tim orgId
            try
            {
                // get member list
                MemberChipList = OrganizationFactory.Instance.GetChannel().GetMemberList(StorageService.CurrentSessionId, SelectId, SelectParentId, filter);

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
                    List<MemberCustomerDTO> listMember = new List<MemberCustomerDTO>();
                    foreach (MemberCustomerDTO member in MemberChipList)
                    {
                        if (member.Member.Title == ConstantsValue.TITLE_BAO_CHI)
                            continue;
                        else listMember.Add(member);
                    }
                    MemberChipList = listMember;
                    // update load member khong phai cua bao chi end

                    result = MemberChipList.Skip(skip).Take(take).ToList();
                    totalRecords = MemberChipList.Count;
                    // pagerPanel.ShowNumberOfRecords(totalRecords, result != null ? result.Count : 0, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
                    pagerPanel.UpdatePagingLinks(totalRecords, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
                    this.btnExportToExcel.Enabled = true;
                }
                //20170306 Bug Load member - Trang Vo Start
                else
                {
                    // thong bao loi
                    if (tbxCode.Text.Trim() != string.Empty)
                        MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "SearchNull"));
                    else
                        MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "NotMember"));

                }
                //20170306 Bug Load member - Trang Vo End
                e.Result = result;
            }
        }
        /// <summary>
        /// bgwMember_WorkerCompleted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwMember_WorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                this.btnExportToExcel.Enabled = false;
                // progress bar 
                progressBarLoading.Value = 100;

                // show message
                pagerPanel.ShowMessage(MessageValidate.GetMessage(rm, "done"));
                return;
            }
            if (e.Result == null)
            {
                this.btnExportToExcel.Enabled = false;
                // progress bar 
                progressBarLoading.Value = 100;

                // show message
                pagerPanel.ShowMessage(MessageValidate.GetMessage(rm, "done"));
                return;
            }
            List<MemberCustomerDTO> result = e.Result as List<MemberCustomerDTO>;
            //20170306 Bug Load member - Trang Vo Start
            // load data
            if (MemberChipList != null && MemberChipList.Count > 0)
            {
                LoadMemberDataGridView(result);
            }
            else
            {
                // Invisible bang du lieu
                dgvShiftList.Visible = false;

                // progress bar 
                progressBarLoading.Value = 100;

                // show message
                pagerPanel.ShowMessage(MessageValidate.GetMessage(rm, "done"));
            }
            //20170306 Bug Load member - Trang Vo End
        }
        /// <summary>
        /// LoadMemberDataGridView
        /// </summary>
        /// <param name="result"></param>
        private void LoadMemberDataGridView(List<MemberCustomerDTO> result)
        {
            #region tinh toan status
            //progress bar 
            progressBarLoading.Value = 20;

            int m = int.Parse(cbxMonth.Text);
            int y = int.Parse(cbxYear.Text);
            // tim orgId
            // GetTimeKeepingMonthlyReportList 
            if (SelectId == OrgId) SelectId = -1;
            List<MonthlyReport> report = TimeKeepingFactory.Instance.GetChannel().GetTimeKeepingMonthlyReportList(
                StorageService.CurrentSessionId, OrgId, SelectId, y, m);
            dtbMemberList.Clear();
            // chuan bi du lieu
            List<TimeDetail> list = new List<TimeDetail>();
            dgvShiftList.SelectionMode = DataGridViewSelectionMode.CellSelect;
            int member_size = result.Count, cnt = 0;
            int days = DateTime.DaysInMonth(y, m);
            VisibleColumns();
            string dateBegin = y + "-" + m + "-01";
            string dateEnd = y + "-" + m + "-" + days;
            MonthlyReport month;
            if (null == report || report.Count == 0)
            {
                // insert thang hien tai or thang khong co du lieu report tu truoc den gio
                // check day of month today 
                int curDay = updateCurDate(y, m, days);
                List<long> listMember = getLisLongMember(MemberChipList);
                TimeKeepingFactory.Instance.GetChannel().insertOrUpdateMonthlyReport(StorageService.CurrentSessionId, dateBegin, y + "-" + m + "-" + curDay, listMember);

                report = TimeKeepingFactory.Instance.GetChannel().GetTimeKeepingMonthlyReportList(
                StorageService.CurrentSessionId, OrgId, SelectId, y, m);
                if (null == report || report.Count == 0)
                {
                    //progress bar 
                    progressBarLoading.Value = 100;

                    // show message
                    pagerPanel.ShowMessage(MessageValidate.GetMessage(rm, "done"));

                    return;
                }
            }
            #endregion

            #region hien thi thong tin vao table

            // duyet tren member_size
            for (int i = 0; i < member_size; i++)
            {
                DataRow row = dtbMemberList.NewRow();
                row.BeginEdit();

                row[colId.DataPropertyName] = result[i].Member.Id;
                row[colMCode1.DataPropertyName] = result[i].Member.Code;
                row[colName.DataPropertyName] = result[i].Member.LastName + " " + result[i].Member.FirstName;

                month = TimeKeepingStatusValue.getMonthlyReport(report, result[i].Member.Id);
                if (null == month)
                {

                    month = updateAndGetMonthlyReport(result[i].Member.Id, dateBegin, dateEnd);
                    if (null == month) continue;
                }
                // for all day
                // check day of month today 
                int curDay = updateCurDate(y, m, days);
                // bien dem tang dan

                // day1
                int cntDay = 1;
                if (month.day1 == -1 && cntDay <= curDay)
                {
                    dateBegin = dateEnd = y + "-" + (m > 9 ? m + "-01" : "0" + m + "-01");
                    month = updateAndGetMonthlyReport(result[i].Member.Id, dateBegin, dateEnd);

                }
                row[col1.DataPropertyName] = TimeKeepingStatusValue.GetTypeName(month.day1);

                // day2
                cntDay = 2;
                if (month.day2 == -1 && cntDay <= curDay)
                {
                    dateBegin = dateEnd = y + "-" + (m > 9 ? m + "-02" : "0" + m + "-02");
                    month = updateAndGetMonthlyReport(result[i].Member.Id, dateBegin, dateEnd);

                }
                row[col2.DataPropertyName] = TimeKeepingStatusValue.GetTypeName(month.day2);

                // day3
                cntDay = 3;
                if (month.day3 == -1 && cntDay <= curDay)
                {
                    dateBegin = dateEnd = y + "-" + (m > 9 ? m + "-03" : "0" + m + "-03");
                    month = updateAndGetMonthlyReport(result[i].Member.Id, dateBegin, dateEnd);

                }
                row[col3.DataPropertyName] = TimeKeepingStatusValue.GetTypeName(month.day3);

                // day4
                cntDay = 4;
                if (month.day4 == -1 && cntDay <= curDay)
                {
                    dateBegin = dateEnd = y + "-" + (m > 9 ? m + "-04" : "0" + m + "-04");
                    month = updateAndGetMonthlyReport(result[i].Member.Id, dateBegin, dateEnd);

                }
                row[col4.DataPropertyName] = TimeKeepingStatusValue.GetTypeName(month.day4);

                // day5
                cntDay = 5;
                if (month.day5 == -1 && cntDay <= curDay)
                {
                    dateBegin = dateEnd = y + "-" + (m > 9 ? m + "-05" : "0" + m + "-05");
                    month = updateAndGetMonthlyReport(result[i].Member.Id, dateBegin, dateEnd);

                }
                row[col5.DataPropertyName] = TimeKeepingStatusValue.GetTypeName(month.day5);

                // day6
                cntDay = 6;
                if (month.day6 == -1 && cntDay <= curDay)
                {
                    dateBegin = dateEnd = y + "-" + (m > 9 ? m + "-06" : "0" + m + "-06");
                    month = updateAndGetMonthlyReport(result[i].Member.Id, dateBegin, dateEnd);

                }
                row[col6.DataPropertyName] = TimeKeepingStatusValue.GetTypeName(month.day6);

                // day7
                cntDay = 7;
                if (month.day7 == -1 && cntDay <= curDay)
                {
                    dateBegin = dateEnd = y + "-" + (m > 9 ? m + "-07" : "0" + m + "-07");
                    month = updateAndGetMonthlyReport(result[i].Member.Id, dateBegin, dateEnd);

                }
                row[col7.DataPropertyName] = TimeKeepingStatusValue.GetTypeName(month.day7);

                // day8
                cntDay = 8;
                if (month.day8 == -1 && cntDay <= curDay)
                {
                    dateBegin = dateEnd = y + "-" + (m > 9 ? m + "-08" : "0" + m + "-08");
                    month = updateAndGetMonthlyReport(result[i].Member.Id, dateBegin, dateEnd);

                }
                row[col8.DataPropertyName] = TimeKeepingStatusValue.GetTypeName(month.day8);

                // day9
                cntDay = 9;
                if (month.day9 == -1 && cntDay <= curDay)
                {
                    dateBegin = dateEnd = y + "-" + (m > 9 ? m + "-09" : "0" + m + "-09");
                    month = updateAndGetMonthlyReport(result[i].Member.Id, dateBegin, dateEnd);

                }
                row[col9.DataPropertyName] = TimeKeepingStatusValue.GetTypeName(month.day9);

                // day10
                cntDay = 10;
                if (month.day10 == -1 && cntDay <= curDay)
                {
                    dateBegin = dateEnd = y + "-" + (m > 9 ? m + "-10" : "0" + m + "-10");
                    month = updateAndGetMonthlyReport(result[i].Member.Id, dateBegin, dateEnd);

                }
                row[col10.DataPropertyName] = TimeKeepingStatusValue.GetTypeName(month.day10);

                // day11
                cntDay = 11;
                if (month.day11 == -1 && cntDay <= curDay)
                {
                    dateBegin = dateEnd = y + "-" + (m > 9 ? m + "-11" : "0" + m + "-11");
                    month = updateAndGetMonthlyReport(result[i].Member.Id, dateBegin, dateEnd);

                }
                row[col11.DataPropertyName] = TimeKeepingStatusValue.GetTypeName(month.day11);

                // day12
                cntDay = 12;
                if (month.day12 == -1 && cntDay <= curDay)
                {
                    dateBegin = dateEnd = y + "-" + (m > 9 ? m + "-12" : "0" + m + "-12");
                    month = updateAndGetMonthlyReport(result[i].Member.Id, dateBegin, dateEnd);

                }
                row[col12.DataPropertyName] = TimeKeepingStatusValue.GetTypeName(month.day12);

                // day13
                cntDay = 13;
                if (month.day13 == -1 && cntDay <= curDay)
                {

                    dateBegin = dateEnd = y + "-" + (m > 9 ? m + "-13" : "0" + m + "-13");
                    month = updateAndGetMonthlyReport(result[i].Member.Id, dateBegin, dateEnd);

                }
                row[col13.DataPropertyName] = TimeKeepingStatusValue.GetTypeName(month.day13);

                // day14
                cntDay = 14;
                if (month.day14 == -1 && cntDay <= curDay)
                {
                    dateBegin = dateEnd = y + "-" + (m > 9 ? m + "-14" : "0" + m + "-14");
                    month = updateAndGetMonthlyReport(result[i].Member.Id, dateBegin, dateEnd);

                }
                row[col14.DataPropertyName] = TimeKeepingStatusValue.GetTypeName(month.day14);

                // day15
                cntDay = 15;
                if (month.day15 == -1 && cntDay <= curDay)
                {
                    dateBegin = dateEnd = y + "-" + (m > 9 ? m + "-15" : "0" + m + "-15");
                    month = updateAndGetMonthlyReport(result[i].Member.Id, dateBegin, dateEnd);

                }
                row[col15.DataPropertyName] = TimeKeepingStatusValue.GetTypeName(month.day15);

                // day16
                cntDay = 16;
                if (month.day16 == -1 && cntDay <= curDay)
                {
                    dateBegin = dateEnd = y + "-" + (m > 9 ? m + "-16" : "0" + m + "-16");
                    month = updateAndGetMonthlyReport(result[i].Member.Id, dateBegin, dateEnd);
                }
                row[col16.DataPropertyName] = TimeKeepingStatusValue.GetTypeName(month.day16);

                // day17
                cntDay = 17;
                if (month.day17 == -1 && cntDay <= curDay)
                {
                    dateBegin = dateEnd = y + "-" + (m > 9 ? m + "-17" : "0" + m + "-17");
                    month = updateAndGetMonthlyReport(result[i].Member.Id, dateBegin, dateEnd);

                }
                row[col17.DataPropertyName] = TimeKeepingStatusValue.GetTypeName(month.day17);

                // day18
                cntDay = 18;
                if (month.day18 == -1 && cntDay <= curDay)
                {
                    dateBegin = dateEnd = y + "-" + (m > 9 ? m + "-18" : "0" + m + "-18");
                    month = updateAndGetMonthlyReport(result[i].Member.Id, dateBegin, dateEnd);

                }
                row[col18.DataPropertyName] = TimeKeepingStatusValue.GetTypeName(month.day18);

                // day19
                cntDay = 19;
                if (month.day19 == -1 && cntDay <= curDay)
                {
                    dateBegin = dateEnd = y + "-" + (m > 9 ? m + "-19" : "0" + m + "-19");
                    month = updateAndGetMonthlyReport(result[i].Member.Id, dateBegin, dateEnd);

                }
                row[col19.DataPropertyName] = TimeKeepingStatusValue.GetTypeName(month.day19);

                // day20
                cntDay = 20;
                if (month.day20 == -1 && cntDay <= curDay)
                {
                    dateBegin = dateEnd = y + "-" + (m > 9 ? m + "-20" : "0" + m + "-20");
                    month = updateAndGetMonthlyReport(result[i].Member.Id, dateBegin, dateEnd);

                }
                row[col20.DataPropertyName] = TimeKeepingStatusValue.GetTypeName(month.day20);

                // day21
                cntDay = 21;
                if (month.day21 == -1 && cntDay <= curDay)
                {
                    dateBegin = dateEnd = y + "-" + (m > 9 ? m + "-21" : "0" + m + "-21");
                    month = updateAndGetMonthlyReport(result[i].Member.Id, dateBegin, dateEnd);

                }
                row[col21.DataPropertyName] = TimeKeepingStatusValue.GetTypeName(month.day21);

                // day22
                cntDay = 22;
                if (month.day22 == -1 && cntDay <= curDay)
                {
                    dateBegin = dateEnd = y + "-" + (m > 9 ? m + "-22" : "0" + m + "-22");
                    month = updateAndGetMonthlyReport(result[i].Member.Id, dateBegin, dateEnd);

                }
                row[col22.DataPropertyName] = TimeKeepingStatusValue.GetTypeName(month.day22);

                // day23
                cntDay = 23;
                if (month.day23 == -1 && cntDay <= curDay)
                {
                    dateBegin = dateEnd = y + "-" + (m > 9 ? m + "-23" : "0" + m + "-23");
                    month = updateAndGetMonthlyReport(result[i].Member.Id, dateBegin, dateEnd);

                }
                row[col23.DataPropertyName] = TimeKeepingStatusValue.GetTypeName(month.day23);

                // day24
                cntDay = 24;
                if (month.day24 == -1 && cntDay <= curDay)
                {
                    dateBegin = dateEnd = y + "-" + (m > 9 ? m + "-24" : "0" + m + "-24");
                    month = updateAndGetMonthlyReport(result[i].Member.Id, dateBegin, dateEnd);

                }
                row[col24.DataPropertyName] = TimeKeepingStatusValue.GetTypeName(month.day24);

                // day25
                cntDay = 25;
                if (month.day25 == -1 && cntDay <= curDay)
                {
                    dateBegin = dateEnd = y + "-" + (m > 9 ? m + "-25" : "0" + m + "-25");
                    month = updateAndGetMonthlyReport(result[i].Member.Id, dateBegin, dateEnd);

                }
                row[col25.DataPropertyName] = TimeKeepingStatusValue.GetTypeName(month.day25);

                // day26                
                cntDay = 26;
                if (month.day26 == -1 && cntDay <= curDay)
                {
                    dateBegin = dateEnd = y + "-" + (m > 9 ? m + "-26" : "0" + m + "-26");
                    month = updateAndGetMonthlyReport(result[i].Member.Id, dateBegin, dateEnd);

                }
                row[col26.DataPropertyName] = TimeKeepingStatusValue.GetTypeName(month.day26);

                // day27
                cntDay = 27;
                if (month.day27 == -1 && cntDay <= curDay)
                {
                    dateBegin = dateEnd = y + "-" + (m > 9 ? m + "-27" : "0" + m + "-27");
                    month = updateAndGetMonthlyReport(result[i].Member.Id, dateBegin, dateEnd);

                }
                row[col27.DataPropertyName] = TimeKeepingStatusValue.GetTypeName(month.day27);

                // day 28
                cntDay = 28;
                if (month.day28 == -1 && cntDay <= curDay)
                {
                    dateBegin = dateEnd = y + "-" + (m > 9 ? m + "-28" : "0" + m + "-28");
                    month = updateAndGetMonthlyReport(result[i].Member.Id, dateBegin, dateEnd);

                }
                row[col28.DataPropertyName] = TimeKeepingStatusValue.GetTypeName(month.day28);

                // day29
                cntDay = 29;
                if (month.day29 == -1 && cntDay <= curDay)
                {
                    dateBegin = dateEnd = y + "-" + (m > 9 ? m + "-29" : "0" + m + "-29");
                    month = updateAndGetMonthlyReport(result[i].Member.Id, dateBegin, dateEnd);

                }
                row[col29.DataPropertyName] = TimeKeepingStatusValue.GetTypeName(month.day29);

                // day03
                cntDay = 30;
                if (month.day30 == -1 && cntDay <= curDay)
                {
                    dateBegin = dateEnd = y + "-" + (m > 9 ? m + "-30" : "0" + m + "-30");
                    month = updateAndGetMonthlyReport(result[i].Member.Id, dateBegin, dateEnd);

                }
                row[col30.DataPropertyName] = TimeKeepingStatusValue.GetTypeName(month.day30);

                // day31
                cntDay = 31;
                if (month.day31 == -1 && cntDay <= curDay)
                {
                    dateBegin = dateEnd = y + "-" + (m > 9 ? m + "-31" : "0" + m + "-31");
                    month = updateAndGetMonthlyReport(result[i].Member.Id, dateBegin, dateEnd);
                }
                row[col31.DataPropertyName] = TimeKeepingStatusValue.GetTypeName(month.day31);

                // for total
                row[colVP.DataPropertyName] = TimeKeepingStatusValue.getTotal((int)TimeKeepingStatus.VANG_CA_NGAY_PHEP, month, days);
                row[colVP1.DataPropertyName] = TimeKeepingStatusValue.getTotal((int)TimeKeepingStatus.VANG_NUA_NGAY_PHEP, month, days);
                row[colVKP.DataPropertyName] = TimeKeepingStatusValue.getTotal((int)TimeKeepingStatus.VANG_CA_NGAY_KO_PHEP, month, days);
                row[colVKP1.DataPropertyName] = TimeKeepingStatusValue.getTotal((int)TimeKeepingStatus.VANG_NUA_NGAY_KO_PHEP, month, days);
                row[colLate.DataPropertyName] = TimeKeepingStatusValue.getTotal((int)TimeKeepingStatus.DI_TRE_VE_SOM, month, days);

                row.EndEdit();
                dtbMemberList.Rows.Add(row);

            #endregion

                #region set color
                for (int j = 0; j < days; j++)
                {
                    dgvShiftList.Columns[j + 8].Visible = true;

                    // To do for each list Time Detail
                    DateTime dt = new DateTime(int.Parse(cbxYear.SelectedValue.ToString()), int.Parse(cbxMonth.SelectedValue.ToString()), j + 1);
                    if (dt.DayOfWeek != DayOfWeek.Sunday && dt.DayOfWeek != DayOfWeek.Saturday)
                    {
                        var v = dgvShiftList.Rows[cnt].Cells[j + 8].Value;
                        //if ((int)dgvShiftList.Rows[i].Cells[j + 8].Value == -1)
                        //    dgvShiftList.Rows[i].Cells[j + 8].Style.BackColor = System.Drawing.Color.OrangeRed;
                        dgvShiftList.Rows[cnt].Cells[j + 8].Style.BackColor = System.Drawing.Color.Yellow;
                    }
                }
                // cong them vao bien cnt
                cnt++;
            }

            //progress bar 
            progressBarLoading.Value = 100;

            // show message
            pagerPanel.ShowMessage(MessageValidate.GetMessage(rm, "done"));
                #endregion

            timeEnd = DateTime.Now;
            Debug.WriteLine("------------ <Trang> ---- Caculator for month: statistic " + timeBegin.ToString("hh:mm:ss.fff tt"));
            Debug.WriteLine("------------ <Trang> ---- Caculator for month: statistic " + timeEnd.ToString("hh:mm:ss.fff tt"));
            Debug.WriteLine("------------ <Trang> ---- Caculator for month: statistic " + (timeEnd.ToBinary() - timeBegin.ToBinary()));
        }
        /// <summary>
        /// check day of month today
        /// </summary>
        /// <param name="y"></param>
        /// <param name="m"></param>
        /// <param name="days"></param>
        /// <returns></returns>
        private int updateCurDate(int y, int m, int days)
        {
            // check day of month today 
            DateTime date = DateTime.Now;
            int curDay = 0;
            if (date.Year <= y && date.Month > m)
            {
                curDay = days;
            }
            else
                if (date.Year == y && date.Month == m)
                {
                    curDay = date.Day - 1;
                }
                else curDay = 0;
            return curDay;
        }
        /// <summary>
        /// updateAndGetMonthlyReport
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dateB"></param>
        /// <param name="dateE"></param>
        /// <returns></returns>
        private MonthlyReport updateAndGetMonthlyReport(long id, string dateB, string dateE)
        {
            List<long> idList = new List<long>();
            idList.Add(id);
            // insertOrUpdateMonthlyReport
            TimeKeepingFactory.Instance.GetChannel().insertOrUpdateMonthlyReport(StorageService.CurrentSessionId, dateB, dateE, idList);
            // GetTimeKeepingMonthlyReport 
            MonthlyReport month = TimeKeepingFactory.Instance.GetChannel().GetTimeKeepingMonthlyReport(StorageService.CurrentSessionId,
                         id, int.Parse(cbxYear.SelectedValue.ToString()), int.Parse(cbxMonth.SelectedValue.ToString()));
            return month;
        }

        /// <summary>
        /// get list id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dateB"></param>
        /// <param name="dateE"></param>
        /// <returns></returns>
        private List<long> getLisLongMember(List<MemberCustomerDTO> list)
        {
            List<long> idList = new List<long>();
            foreach (MemberCustomerDTO mem in list)
            {
                idList.Add(mem.Member.Id);
            }
            return idList;
        }


        /// <summary>
        /// Visible
        /// Columns
        /// </summary>
        private void VisibleColumns()
        {
            for (int i = 0; i < 31; i++)
            {
                dgvShiftList.Columns[i + 8].Visible = false;
            }
        }

        #endregion

        #endregion

        #region CAB events
        [CommandHandler(TimeCommandName.ShowMonthStatistic)]
        public void ShowMemberMgtMainHandler(object s, EventArgs e)
        {
            UsrMonthStatistic uc = workItem.Items.Get<UsrMonthStatistic>(DefineName.MonthStatistic);
            if (uc == null)
            {
                uc = workItem.Items.AddNew<UsrMonthStatistic>(DefineName.MonthStatistic);
            }
            else if (uc.IsDisposed)
            {
                workItem.Items.Remove(uc);
                uc = workItem.Items.AddNew<UsrMonthStatistic>(DefineName.MonthStatistic);
            }
            workItem.Workspaces[WorkspaceName.MainWorkspace].Show(uc);
            uc.Parent.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, DefineName.MenuMonthStatistic);
        }


        #endregion
        /// <summary>
        /// btnExportToExcel_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            // file name
            string fileName = MessageValidate.GetMessage(rm, this.lblMonthDetail.Name) + "_" + cbxYear.Text + cbxMonth.Text;
            // ShowSaveFileDialog
            string filePath = ControlExtMethods.ShowSaveFileDialog(MessageValidate.GetMessage(rm, "smsChooseFileExport"), fileName, "MS Excel (*.xls)|*.xls");

            if (filePath != null)
            {
                try
                {
                    // export data
                    // dgvShiftList.ExportToExcel(filePath);

                    // export excel
                    ConfigExportFileModel configExportFile = new ConfigExportFileModel();
                    configExportFile.FilePath = filePath;
                    GemboxUtils.Instance.ExportDataGridToFile(dgvShiftList, configExportFile);//tua de, xuat file
                    GemboxUtils.Instance.ExportDataGridToFile(dgvShiftList.Rows.Count);//tua de, xuat file

                    GemboxUtils.Instance.AutoFix();
                    try
                    {
                        GemboxUtils.Instance.Save();
                    }
                    catch (IOException x)
                    {
                        MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "fileExcelOpen"));
                    }
                    // end
                }
                catch (Exception ex)
                {
                    MessageBoxManager.ShowErrorMessageBox(this, ex.Message);
                    return;
                }
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "smsLinkFile") + filePath);
            }
        }


        /// <summary>
        /// su kien nut enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvShiftList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dgvShiftList.SelectedCells.Count == 1)
                {
                    DataGridViewCell cell = dgvShiftList.SelectedCells[0];
                    // neu column khong phai colName, colMCode1, colVP, colVP1, colVKP, colVKP1, colLate thi thuc hien dgvShiftList_KeyDown
                    if (cell.ColumnIndex != colName.Index && cell.ColumnIndex != colMCode1.Index && cell.ColumnIndex != colVP.Index && cell.ColumnIndex != colVP1.Index
                        && cell.ColumnIndex != colVKP.Index && cell.ColumnIndex != colVKP1.Index && cell.ColumnIndex != colLate.Index)
                    {
                        // chuan bi du lieu
                        long memId = long.Parse(dgvShiftList.Rows[cell.RowIndex].Cells[colId.Index].Value.ToString());
                        string memName = dgvShiftList.Rows[cell.RowIndex].Cells[colName.Index].Value.ToString();
                        string memCode = dgvShiftList.Rows[cell.RowIndex].Cells[colMCode1.Index].Value.ToString();
                        string strdate = cbxYear.SelectedItem.ToString() + "-" + cbxMonth.SelectedItem.ToString() + "-" + (cell.ColumnIndex - 7);
                        DateTime date = new DateTime(int.Parse(cbxYear.SelectedItem.ToString()), int.Parse(cbxMonth.SelectedItem.ToString()), cell.ColumnIndex - 7);
                        // tao form
                        FrmTimeStatisticDetail frmdetail = new FrmTimeStatisticDetail(memCode, memName, date, memId, OrgId);
                        workItem.SmartParts.Add(frmdetail);
                        frmdetail.Show();
                    }
                }
                else
                {
                    MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "rowNotOne"));
                }

            }

        }


    }
}

