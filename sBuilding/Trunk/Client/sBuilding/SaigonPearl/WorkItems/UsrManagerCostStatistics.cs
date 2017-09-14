using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Practices.CompositeUI;
using sWorldModel;
using Microsoft.Practices.CompositeUI.Commands;
using CommonHelper.Constants;
using sWorldModel.Filters;
using JavaCommunication.Factory;
using CommonControls;
using sWorldModel.Exceptions;
using sWorldModel.TransportData;
using System.ServiceModel;
using CommonHelper.Config;
using CommonControls.Custom;
using System.Resources;
using CommonHelper.Utils;
using sAccessComponent.Constants;


namespace sAccessComponent.WorkItems {
    public partial class UsrManagerCostStatistics : CommonUserControl {
        #region Properties

        // Height of filter box when it is hidden
        private int hiddenFilterBoxHeight = 0;
        // The original height of filter box (at startup)
        private int startupFilterBoxHeight = 88;

        private int currentPageIndex = 1;

        // Data table that contains user records
        private DataTable dtbMemberList;
        private List<ManagerCostApartment> managerCostList;
        private BackgroundWorker loadOrgWorker;
        private BackgroundWorker loadManagerCostWorker;
        private Dictionary<string, string> GroupSubOrgList;
        MemberFilter filter;
        private ResourceManager rm;

        // The original font of tree nodes
        private Font startupNodeFont;
        // Selected tree node; cache it to do some effect in UI
        private TreeNode selectedOrgNode;
        private TreeNode selectedOrgParentNode;
        private TreeNode rootNode;

        private MasterInfoDTO masterInfo;

        private AccessComponentWorkItem workItem;
        [ServiceDependency]
        public AccessComponentWorkItem WorkItem {
            set { workItem = value; }
        }

        private ILocalStorageService storageService;
        public ILocalStorageService StorageService {
            get {
                if (storageService == null) {
                    storageService = workItem.Services.Get<ILocalStorageService>();
                }
                return storageService;
            }
        }

        #endregion Properties

        #region Initialization

        public UsrManagerCostStatistics() {
            InitializeComponent();
            InitOrganizationsGrid();
            RegisterEvents();
        }

        private void RegisterEvents() {
            //Tree View
            trvOrganizations.AfterExpand += trvOrganizations_AfterExpand;
            trvOrganizations.BeforeSelect += trvOrganizations_BeforeSelect;
            trvOrganizations.AfterSelect += trvOrganizations_AfterSelect;
            //Load Tree View
            loadOrgWorker = new BackgroundWorker();
            loadOrgWorker.WorkerSupportsCancellation = true;
            loadOrgWorker.DoWork += OnLoadOrgWorkerDoWork;
            loadOrgWorker.RunWorkerCompleted += OnLoadOrgWorkerCompleted;
            //Load Member
            loadManagerCostWorker = new BackgroundWorker();
            loadManagerCostWorker.WorkerSupportsCancellation = true;
            loadManagerCostWorker.DoWork += OnLoadMemberWorkerDoWork;
            loadManagerCostWorker.RunWorkerCompleted += OnLoadMemberWorkerCompleted;
            //Show or hide filter
            btnShowHide.Click += btnShowHide_Click;
            //reload list
            btnReloadOrgs.Click += (s, e) => LoadOrgList();
            mniReloadOrgs.Click += (s, e) => LoadOrgList();
            btnReloadMembers.Click += (s, e) => LoadMemberList();

            pagerPanel1.LinkLabelClicked += pagerPanel_LinkLabelClicked;

            // Assign startup value
            startupNodeFont = trvOrganizations.Font;

            dgvMembers.SelectionChanged += dgvMembers_SelectionChanged;

            Load += OnFormLoad;
        }


        private void OnFormLoad(object sender, EventArgs e) {
            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
            try {
                this.masterInfo = OrganizationFactory.Instance.GetChannel().GetMasterInfo(StorageService.CurrentSessionId, SystemSettings.Instance.Partner);
            } catch (TimeoutException) {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "TimeOutExceptionMessage"));
            } catch (FaultException<WcfServiceFault> ex) {
                MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
            } catch (FaultException ex) {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "FaultExceptionMessage")
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
            } catch (CommunicationException) {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "CommunicationExceptionMessage"));
            }

            LoadGroupSubOrg();
            InitTreeList();
            LoadOrgList();
            SetShowOrHideButton(false);
            // Set Language
            SetLanguage();
        }

        #endregion Initialization

        #region Set Language
        private void SetLanguage() {
            this.lblLeftAreaTitleOrg.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.lblLeftAreaTitleOrg.Name);
            this.lblLeftAreaTitleUser.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.lblLeftAreaTitleUser.Name);
            this.btnReloadOrgs.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnReloadOrgs.Name);
            this.btnExportToExcel.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnExportToExcel.Name);
            this.btnReloadMembers.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnReloadMembers.Name);
            this.lblInfoApartment.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.lblInfoApartment.Name);
            this.lblApartmentCode.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.lblApartmentCode.Name);
            this.lblApartmentName.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.lblApartmentName.Name);
            this.lblOldManageOwe.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.lblOldManageOwe.Name);
            this.lblManageFee.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.lblManageFee.Name);
            this.lblWaterFee.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.lblWaterFee.Name);
            this.lblOweDate.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.lblOweDate.Name);
            this.lblPhone.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.lblPhone.Name);
            this.lblEmail.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.lblEmail.Name);
            this.colOldManageOwe.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colOldManageOwe.Name);
            this.colManageFee.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colManageFee.Name);
            this.colWaterFee.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colWaterFee.Name);
            this.colOweDate.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colOweDate.Name);
            this.colActive.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colActive.Name);
        }
        #endregion

        #region CAB events

        [CommandHandler(AccessCommandNames.ShowManagerCostStatistics)]
        public void ShowCardMgtMainHandler(object s, EventArgs e) {
            UsrManagerCostStatistics uc = workItem.Items.Get<UsrManagerCostStatistics>(ComponentNames.ManagerCostStatistics);
            if (uc == null) {
                uc = workItem.Items.AddNew<UsrManagerCostStatistics>(ComponentNames.ManagerCostStatistics);
            } else if (uc.IsDisposed) {
                workItem.Items.Remove(uc);
                uc = workItem.Items.AddNew<UsrManagerCostStatistics>(ComponentNames.ManagerCostStatistics);
            }

            workItem.Workspaces[WorkspaceName.MainWorkspace].Show(uc);
            uc.Parent.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuDoorInStatistics);
        }

        #endregion CAB events

        #region Form events

        private void cbxFilterByMemberName_CheckedChanged(object sender, EventArgs e) {
            tbxMemberName.Enabled = cbxFilterByMemberName.Checked;
        }

        private void cbxFilterByMemberCode_CheckedChanged(object sender, EventArgs e) {
            tbxMemberCode.Enabled = cbxFilterByMemberCode.Checked;
        }

        private void btnShowHide_Click(object sender, EventArgs e) {
            if (pnlFilterBox.Height == hiddenFilterBoxHeight) {
                pnlFilterBox.Height = startupFilterBoxHeight;
                pnlFilterBox.Height = startupFilterBoxHeight;
                btnShowHide.Text = btnShowHide.ToolTipText = "Ẩn Khung Tìm Kiếm";
                btnShowHide.ToolTipText = "Ẩn khung tìm kiếm";
                btnShowHide.Image = global::CommonControls.Properties.Resources.ArrowUp_16x16;
            } else {
                pnlFilterBox.Height = hiddenFilterBoxHeight;
                btnShowHide.Text = btnShowHide.ToolTipText = "Hiện Khung Tìm Kiếm";
                btnShowHide.ToolTipText = "Hiện khung tìm kiếm";
                btnShowHide.Image = global::CommonControls.Properties.Resources.ArrowDown_16x16;
            }
        }

        private void trvGroups_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                TreeNode node = trvOrganizations.GetNodeAt(trvOrganizations.PointToClient(Control.MousePosition));
                if (node != null) {
                    trvOrganizations.SelectedNode = node;
                    if (node != rootNode) {
                        cmsOrgRecord.Show((Control) sender, e.Location.X, e.Location.Y);
                    }
                } else {
                    cmsOrgTree.Show((Control) sender, e.Location.X, e.Location.Y);
                }
            }
        }

        private void trvOrganizations_AfterExpand(object sender, TreeViewEventArgs e) {
            if (chkAutoCloseNode.Checked) {
                foreach (TreeNode node in rootNode.Nodes) {
                    if (node.IsExpanded && node != e.Node) {
                        node.Collapse();
                    }
                }
                trvOrganizations.SelectedNode = null;
            }
        }

        private void trvOrganizations_BeforeSelect(object sender, TreeViewCancelEventArgs e) {
            // If background worker is running -> restrict selecting another node
            if (loadManagerCostWorker.IsBusy) {
                e.Cancel = true;
                return;
            }

            // Change node font style to normal
            if (selectedOrgNode != null) {
                selectedOrgNode.NodeFont = new Font(startupNodeFont, FontStyle.Regular);
                selectedOrgNode.Text = selectedOrgNode.Text;
            }

        }

        private void trvOrganizations_AfterSelect(object sender, TreeViewEventArgs e) {
            TreeNode selectedNode = e.Node;
            TreeNode parentNode = new TreeNode();
            if (selectedNode != null) {
                parentNode = selectedNode.Parent;
                selectedNode.NodeFont = new Font(startupNodeFont, FontStyle.Bold);
                selectedNode.Text = selectedNode.Text;

                if (selectedOrgNode != null && selectedNode == selectedOrgNode) {
                    return;
                }

                selectedOrgParentNode = selectedNode.Parent;
                selectedOrgNode = selectedNode;

                if (selectedOrgNode.Level == 2) {
                    LoadSubOrg();
                    LoadManagerCost();
                    LoadMemberList();
                    SetShowOrHideButton(true);
                } else
                    SetShowOrHideButton(false);

                currentPageIndex = 1;
            }
        }

        private void LoadSubOrg() {
            try {
                SubOrganization subOrg = OrganizationFactory.Instance.GetChannel().GetSubOrgById(StorageService.CurrentSessionId, Convert.ToInt64(selectedOrgNode.Name));
                txtCode.Text = subOrg.orgcode;
                txtName.Text = subOrg.names;
                txtPhone.Text = subOrg.phone;
                txtEmail.Text = subOrg.email;
            } catch (TimeoutException) {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "TimeOutExceptionMessage"));
            } catch (FaultException<WcfServiceFault> ex) {
                MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
            } catch (FaultException ex) {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "FaultExceptionMessage")
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
            } catch (CommunicationException) {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "CommunicationExceptionMessage"));
            }
        }

        private void LoadManagerCost() {
            try {
                ManagerCostApartment mc = ManagerCostsFactory.Instance.GetChannel().GetManagerCostBySubOrgId(StorageService.CurrentSessionId, Convert.ToInt64(selectedOrgNode.Name));
                if (mc != null) {
                    tbxManagerCostOld.Text = mc.ManagerCostOld.ToString("N0");
                    tbxManagerCost.Text = mc.PayManager.ToString("N0");
                    tbxWaterCost.Text = mc.PayWater.ToString("N0");
                    tbxDateCost.Text = mc.DayPay;
                }
            } catch (TimeoutException) {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "TimeOutExceptionMessage"));
            } catch (FaultException<WcfServiceFault> ex) {
                MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
            } catch (FaultException ex) {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "FaultExceptionMessage")
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
            } catch (CommunicationException) {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "CommunicationExceptionMessage"));
            }
        }

        private void pagerPanel_LinkLabelClicked(object s, LinkLabelClickedArgs e) {
            int i;
            if (e.LabelText.Equals(PagerPanel.LabelBackText)) {
                currentPageIndex -= 1;
            } else if (e.LabelText.Equals(PagerPanel.LabelNextText)) {
                currentPageIndex += 1;
            } else if (int.TryParse(e.LabelText, out i)) {
                currentPageIndex = i;
            } else {
                return;
            }
            dtbMemberList.Rows.Clear();
            int take = LocalSettings.Instance.RecordsPerPage;
            int skip = (currentPageIndex - 1) * take;

            List<ManagerCostApartment> result = managerCostList.Skip(skip).Take(take).ToList();
            LoadMemberDataGridView(result);

            pagerPanel1.ShowNumberOfRecords(managerCostList.Count, result != null ? result.Count : 0, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
            pagerPanel1.UpdatePagingLinks(managerCostList.Count, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
        }

        private MemberFilter GetMemberFilter() {
            MemberFilter filter = new MemberFilter();

            if (cbxFilterByMemberName.Checked) {
                tbxMemberName.Text = tbxMemberName.Text.Trim();
                if (tbxMemberName.Text.Length < 2) {
                    Invoke(new Action(() => { lblNotification1.Visible = true; }));
                    return null;
                } else {
                    Invoke(new Action(() => { lblNotification1.Visible = false; }));
                }
                filter.FilterByMemberName = true;
                filter.MemberName = tbxMemberName.Text;
            }
            if (cbxFilterByMemberCode.Checked) {
                tbxMemberCode.Text = tbxMemberCode.Text.Trim();
                if (tbxMemberCode.Text.Length < 2) {
                    Invoke(new Action(() => { lblNotification2.Visible = true; }));
                    return null;
                } else {
                    Invoke(new Action(() => { lblNotification2.Visible = false; }));
                }
                filter.FilterByCode = true;
                filter.Code = tbxMemberCode.Text;
            }

            return filter;
        }

        #region Organization

        private void OnLoadOrgWorkerDoWork(object sender, DoWorkEventArgs e) {
            List<OrgCustomerDto> result = null;
            OrgFilterDto filter = new OrgFilterDto();

            try {
                result = OrganizationFactory.Instance.GetChannel().GetOrgList(StorageService.CurrentSessionId, filter);
            } catch (TimeoutException) {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "TimeOutExceptionMessage"));
            } catch (FaultException<WcfServiceFault> ex) {
                MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
            } catch (FaultException ex) {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "FaultExceptionMessage")
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
            } catch (CommunicationException) {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "CommunicationExceptionMessage"));
            } finally {
                e.Result = result;
            }
        }

        private void OnLoadOrgWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (e.Cancelled) {
                return;
            }

            // Get result from DoWork method
            List<OrgCustomerDto> result = (List<OrgCustomerDto>) e.Result;
            if (result != null) {

                foreach (OrgCustomerDto org in result) {
                    if (!org.Issuer.Equals(SystemSettings.Instance.Master)) {
                        TreeNode orgNode = new TreeNode();
                        orgNode.Text = org.Name;
                        orgNode.Name = Convert.ToString(org.OrgId);

                        if (org.SubOrgList != null) {
                            foreach (SubOrgCustomerDTO subOrg in org.SubOrgList) {
                                TreeNode subOrgNode = new TreeNode();
                                subOrgNode.Text = subOrg.Name;
                                subOrgNode.Name = Convert.ToString(subOrg.SubOrgId);
                                orgNode.Nodes.Add(subOrgNode);
                            }
                        }

                        rootNode.Nodes.Add(orgNode);
                    }

                }
                trvOrganizations.Sort();
                rootNode.Expand();
            }
        }

        #endregion

        #region Member

        private void dgvMembers_SelectionChanged(object sender, EventArgs e) {
            if (dgvMembers.CurrentRow != null)
                ShowOrHideButtonMemberAction(string.IsNullOrEmpty(dgvMembers.CurrentRow.Cells[colActive.Index].Value.ToString()));
        }

        private void OnLoadMemberWorkerDoWork(object sender, DoWorkEventArgs e) {
            int totalRecords = 0;
            int take = LocalSettings.Instance.RecordsPerPage;
            int skip = 0;
            currentPageIndex = 1;
            List<ManagerCostApartment> result = null;
            try {
                managerCostList = ManagerCostsFactory.Instance.GetChannel().GetManagerCostListBySubOrgId(storageService.CurrentSessionId, Convert.ToInt64(selectedOrgNode.Name));
            } catch (TimeoutException) {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "TimeOutExceptionMessage"));
                managerCostList = null;
            } catch (FaultException<WcfServiceFault> ex) {
                MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
                managerCostList = null;
            } catch (FaultException ex) {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "FaultExceptionMessage")
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
                managerCostList = null;
            } catch (CommunicationException) {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "CommunicationExceptionMessage"));
                managerCostList = null;
            } finally {
                if (managerCostList != null) {
                    result = managerCostList.Skip(skip).Take(take).ToList();
                    totalRecords = managerCostList.Count;
                    pagerPanel1.ShowNumberOfRecords(totalRecords, result != null ? result.Count : 0, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
                    pagerPanel1.UpdatePagingLinks(totalRecords, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
                }
                e.Result = result;
            }
        }

        private void OnLoadMemberWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (e.Cancelled) {
                return;
            }
            if (e.Result == null) {
                return;
            }
            List<ManagerCostApartment> result = (List<ManagerCostApartment>) e.Result;
            LoadMemberDataGridView(result);
        }

        private void LoadMemberDataGridView(List<ManagerCostApartment> result) {
            foreach (ManagerCostApartment mc in result) {
                DataRow row = dtbMemberList.NewRow();
                row.BeginEdit();

                //row[colManagerCostId.DataPropertyName] = mc.;
                row[colManagerCostId.DataPropertyName] = mc.ManagerCostOld;
                row[colManageFee.DataPropertyName] = mc.PayManager;
                row[colWaterFee.DataPropertyName] = mc.PayWater;
                row[colOweDate.DataPropertyName] = mc.DayPay;
                row[colActive.DataPropertyName] = mc.Active.HasValue && mc.Active.Value ? LocalSettings.Instance.CheckSymbol : string.Empty;

                row.EndEdit();
                dtbMemberList.Rows.Add(row);
            }
        }

        private void btnExportToExcel_Click(object sender, EventArgs e) {
            string filePath = ControlExtMethods.ShowSaveFileDialog(MessageValidate.GetMessage(rm, "smsChooseFileExport"), selectedOrgNode.Text, "MS Excel (*.xls)|*.xls");
            if (filePath != null) {
                try {
                    dgvMembers.ExportToExcel(filePath);
                } catch (Exception ex) {
                    MessageBoxManager.ShowErrorMessageBox(this, ex.Message);
                    return;
                }
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "smsLinkFile") + filePath);
            }
        }

        #endregion

        #endregion

        #region Event's support

        #region Organization

        private void InitTreeList() {
            rootNode = new TreeNode();
            rootNode.Text = "Tất cả";
            rootNode.Name = "-1";
            trvOrganizations.Nodes.Add(rootNode);
        }

        private void LoadOrgList() {
            if (!loadOrgWorker.IsBusy) {
                dtbMemberList.Rows.Clear();
                rootNode.Nodes.Clear();
                loadOrgWorker.RunWorkerAsync();
            }
        }

        #endregion

        #region Member

        private void InitOrganizationsGrid() {
            dtbMemberList = new DataTable();
            dtbMemberList.Columns.Add(colManagerCostId.DataPropertyName);
            dtbMemberList.Columns.Add(colOldManageOwe.DataPropertyName);
            dtbMemberList.Columns.Add(colManageFee.DataPropertyName);
            dtbMemberList.Columns.Add(colWaterFee.DataPropertyName);
            dtbMemberList.Columns.Add(colOweDate.DataPropertyName);
            dtbMemberList.Columns.Add(colActive.DataPropertyName);
            dgvMembers.DataSource = dtbMemberList;
        }

        private void SetShowOrHideButton(bool edit) {
            btnExportToExcel.Enabled = btnReloadMembers.Enabled = edit;
        }

        private void LoadMemberList() {
            if (!loadManagerCostWorker.IsBusy && selectedOrgNode != null) {
                dtbMemberList.Rows.Clear();
                managerCostList = null;
                filter = GetMemberFilter();
                pagerPanel1.ShowMessage("Đang tải dữ liệu, xin hãy chờ...");
                loadManagerCostWorker.RunWorkerAsync();
            }
        }

        private void ShowOrHideButtonMemberAction(bool isShow) {
        }

        #endregion

        #region Group

        private void LoadGroupSubOrg() {
            //GroupSubOrgList = new Dictionary<string, string>();
            //String[] result = GroupSettings.Instance.Group.Split(',');

            //foreach (String group in result) {
            //    string[] item = group.Split('-');
            //    if (item.Length > 0)
            //        GroupSubOrgList.Add(item.FirstOrDefault(), item.LastOrDefault());
            //}
            //GroupSubOrgList.GroupBy(g => g.Value);
        }

        #endregion

        #endregion


    }
}