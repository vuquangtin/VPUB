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
using MemberMgtComponent.Constants;
using Microsoft.Practices.CompositeUI.Commands;
using CommonControls;
//using WcfServiceCommon;
using sWorldModel.Exceptions;
using sWorldModel.Filters;
using sWorldModel.Model;
using sWorldModel;
using sWorldModel.TransportData;
using JavaCommunication.Factory;
using MemberMgtComponent.WorkItems.IntegratingExcel;

namespace MemberMgtComponent.WorkItems
{
    public partial class UsrMemberMgtMain : CommonUserControl
    {
        #region Properties

        private BackgroundWorker loadSubOrgWorker;

        private int currentPageIndex = -1;
        private DataTable dtbMemberList;
        private BackgroundWorker loadMemberWorker;
        private List<MemberCustomerDTO> MemberChipList;
        private MasterInfoDTO masterInfo;
        private List<PartnerInfoDTO> partnerInfoList;
        private PartnerInfoDTO partnerInfoSelected;

        private Font startupNodeFont;
        private TreeNode subOrgNodeSelected;
        private TreeNode rootNode;
        private int startupFilterBoxHeight;
        private const int hiddenFilterBoxHeight = 1;

        private MemberWorkItem workItem;
        [ServiceDependency]
        public MemberWorkItem WorkItem
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

        #region Initialization

        public UsrMemberMgtMain()
        {
            InitializeComponent();
            InitOrganizationsGrid();

            loadSubOrgWorker = new BackgroundWorker();
            loadSubOrgWorker.WorkerSupportsCancellation = true;
            loadSubOrgWorker.DoWork += OnLoadOrgWorkerDoWork;
            loadSubOrgWorker.RunWorkerCompleted += OnLoadOrgWorkerCompleted;

            trvOrganizations.AfterExpand += trvOrganizations_AfterExpand;
            trvOrganizations.BeforeSelect += trvOrganizations_BeforeSelect;
            trvOrganizations.AfterSelect += trvOrganizations_AfterSelect;

            dgvMembers.MouseDown += dgvMembers_MouseDown;
            trvOrganizations.MouseDown += trvOrganizations_MouseDown;

            Enter += (s, e) =>
            {
                if (MemberMgtMainShown != null)
                {
                    MemberMgtMainShown(this, EventArgs.Empty);
                }
            };
            Leave += (s, e) =>
            {
                if (MemberMgtMainHide != null)
                {
                    MemberMgtMainHide(this, EventArgs.Empty);
                }
            };

            Load += OnFormLoad;

            loadMemberWorker = new BackgroundWorker();
            loadMemberWorker.WorkerSupportsCancellation = true;
            loadMemberWorker.DoWork += bgwMember_DoWork;
            loadMemberWorker.RunWorkerCompleted += bgwMember_WorkerCompleted;

            btnShowHide.Click += btnShowHide_Clicked;
            pagerPanel.LinkLabelClicked += pagerPanel_LinkLabelClicked;

            btnPersoCard.Click += btnPersoCard_Clicked;

            btnReloadOrgs.Click += (s, e) => LoadSubOrgList();
            mniReloadOrgs.Click += (s, e) => LoadSubOrgList();
            btnReloadMembers.Click += (s, e) => LoadMemberList();
            mniReloadMembers.Click += (s, e) => LoadMemberList();

            cbxFilterByPersoStatusMember.CheckedChanged += cbxFilterByPersoStatus_CheckChanged;
            cbxFilterByMemberCode.CheckedChanged += cbxFilterByMemberCode_CheckChanged;
            cbxFilterByMemberName.CheckedChanged += cbxFilterByMemberName_CheckChanged;
            cbxFilterByWorkingStatus.CheckedChanged += cbxFilterByWorkingStatus_CheckChanged;
            cbxFilterByDegree.CheckedChanged += cbxFilterByDegree_CheckChanged;

            cmbPartnerInfo.SelectedIndexChanged += cmbPartnerInfo_SelectedIndexChanged;
        }

        private void OnFormLoad(object sender, EventArgs e)
        {
            // Check permissions
            ILocalStorageService storageService = workItem.Services.Get<ILocalStorageService>();
            List<Function> permissions = storageService.GetObject(CacheKeyNames.CurrentUserPermissions) as List<Function>;
            SessionDTO currentSession = storageService.GetObject(CacheKeyNames.CurrentSession) as SessionDTO;

            if (!currentSession.IsRoot)
            {
                btnSyncData.Enabled = mniSyncData.Enabled = false;
                btnSyncData.Visible = mniSyncData.Visible = false;
            }
            if (!permissions.Exists(p => p == Function.FUNC_PERSO_PERSO_CARD))
            {
                btnPersoCard.Enabled = mniPersoCard.Enabled = false;
                btnPersoCard.Visible = mniPersoCard.Visible = false;
            }

            // Assign startup value
            startupNodeFont = trvOrganizations.Font;
            startupFilterBoxHeight = pnlFilterBox.Height;

            // Add root node
            rootNode = new TreeNode();
            rootNode.Text = "Tất Cả";
            rootNode.Name = "-1";
            trvOrganizations.Nodes.Add(rootNode);

            //Load Partner
            LoadPartnerInfo();
            HideOrShowOrg();

            // Load faculty/department list
            //LoadOrgList();
        }

        #endregion

        #region Form event

        private void cmbPartnerInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            partnerInfoSelected = cmbPartnerInfo.SelectedItem as PartnerInfoDTO;
            LoadSubOrgList();
        }

        private void tbxMemberName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadMemberList();
            }
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            string filePath = ControlExtMethods.ShowSaveFileDialog("Chọn tập tin chứa dữ liệu cần xuất", "MS Excel (*.xls)|*.xls");
            if (filePath != null)
            {
                try
                {
                    dgvMembers.ExportToExcel(filePath);
                }
                catch (Exception ex)
                {
                    MessageBoxManager.ShowErrorMessageBox(this, ex.Message);
                    return;
                }
                MessageBoxManager.ShowInfoMessageBox(this, "Đã xuất dữ liệu ra tập tin tại đường dẫn: " + filePath);
            }
        }

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

        private void dgvMembers_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo info = dgvMembers.HitTest(e.X, e.Y);
                if (info.RowIndex != -1)
                {
                    if (info.RowIndex >= 0 && info.ColumnIndex >= 0)
                    {
                        if (!dgvMembers.SelectedRows.Contains(dgvMembers.Rows[info.RowIndex]))
                        {
                            foreach (DataGridViewRow row in dgvMembers.SelectedRows)
                            {
                                row.Selected = false;
                            }
                            dgvMembers.Rows[info.RowIndex].Selected = true;
                        }
                    }
                    Rectangle r = dgvMembers.GetCellDisplayRectangle(info.ColumnIndex, info.RowIndex, true);
                    cmsMemberRecord.Show((Control)sender, e.X, e.Y);
                }
                else
                {
                    cmsMemberTable.Show((Control)sender, e.X, e.Y);
                }
            }
        }

        private void trvOrganizations_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if (chkAutoCloseNode.Checked)
            {
                foreach (TreeNode node in rootNode.Nodes)
                {
                    if (node.IsExpanded && node != e.Node)
                    {
                        node.Collapse();
                    }
                }
                trvOrganizations.SelectedNode = null;
            }
        }

        private void trvOrganizations_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            // If background worker is running -> restrict selecting another node
            if (loadMemberWorker.IsBusy)
            {
                e.Cancel = true;
                return;
            }

            // Change node font style to normal
            if (subOrgNodeSelected != null)
            {
                subOrgNodeSelected.NodeFont = new Font(startupNodeFont, FontStyle.Regular);
                subOrgNodeSelected.Text = subOrgNodeSelected.Text;
            }
        }

        private void trvOrganizations_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectedNode = e.Node;
            if (selectedNode != null)
            {
                selectedNode.NodeFont = new Font(startupNodeFont, FontStyle.Bold);
                selectedNode.Text = selectedNode.Text;

                if (subOrgNodeSelected != null && selectedNode == subOrgNodeSelected)
                {
                    return;
                }
                subOrgNodeSelected = selectedNode;

                currentPageIndex = 1;
                LoadMemberList();
            }
        }

        private void cbxFilterByWorkingStatus_CheckChanged(object sender, EventArgs e)
        {
            if (cbxFilterByWorkingStatus.Checked)
            {
                rbtnWorking.Enabled = rbtnWorkingAbroad.Enabled = rbtnNotWorking.Enabled = true;
            }
            else
            {
                rbtnWorking.Checked = true;
                rbtnWorking.Enabled = rbtnWorkingAbroad.Enabled = rbtnNotWorking.Enabled = false;
            }
        }

        private void cbxFilterByMemberName_CheckChanged(object sender, EventArgs e)
        {
            tbxMemberName.Enabled = cbxFilterByMemberName.Checked;
            lblNotification1.Visible = false;
        }

        private void cbxFilterByMemberCode_CheckChanged(object sender, EventArgs e)
        {
            tbxMemberCode.Enabled = cbxFilterByMemberCode.Checked;
            lblNotification2.Visible = false;
        }

        private void cbxFilterByDegree_CheckChanged(object sender, EventArgs e)
        {
            txtDegreeCode.Enabled = cbxFilterByDegree.Checked;
            //lblNotification2.Visible = false;
        }
        private void cbxFilterByPersoStatus_CheckChanged(object sender, EventArgs e)
        {
            if (cbxFilterByPersoStatusMember.Checked)
            {
                rbtnPerso.Enabled = rbtnNotPerso.Enabled = true;
            }
            else
            {
                rbtnNotPerso.Checked = true;
                rbtnPerso.Enabled = rbtnNotPerso.Enabled = false;
            }
        }

        private void btnShowHide_Clicked(object sender, EventArgs e)
        {
            if (pnlFilterBox.Height > hiddenFilterBoxHeight)
            {
                pnlFilterBox.Height = hiddenFilterBoxHeight;
                btnShowHide.Text = btnShowHide.ToolTipText = "Hiện Khung Tìm Kiếm";
                btnShowHide.ToolTipText = "Hiện khung tìm kiếm";
                btnShowHide.Image = global::CommonControls.Properties.Resources.ArrowDown_16x16;
            }
            else
            {
                pnlFilterBox.Height = startupFilterBoxHeight;
                btnShowHide.Text = btnShowHide.ToolTipText = "Ẩn Khung Tìm Kiếm";
                btnShowHide.ToolTipText = "Ẩn khung tìm kiếm";
                btnShowHide.Image = global::CommonControls.Properties.Resources.ArrowUp_16x16;
            }
        }

        private void pagerPanel_LinkLabelClicked(object sender, LinkLabelClickedArgs e)
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
            LoadMemberList();
        }

        [EventPublication(MemberEventTopicNames.MemberListShown)]
        public event EventHandler MemberMgtMainShown;

        [EventPublication(MemberEventTopicNames.MemberListHide)]
        public event EventHandler MemberMgtMainHide;

        [CommandHandler(MemberCommandNames.ShowTMemberMgtMain)]
        public void ShowMemberMgtMainHandler(object s, EventArgs e)
        {
            UsrMemberMgtMain uc = workItem.Items.Get<UsrMemberMgtMain>(ComponentNames.MemberMgtComponent);
            if (uc == null)
            {
                uc = workItem.Items.AddNew<UsrMemberMgtMain>(ComponentNames.MemberMgtComponent);
            }
            else if (uc.IsDisposed)
            {
                workItem.Items.Remove(uc);
                uc = workItem.Items.AddNew<UsrMemberMgtMain>(ComponentNames.MemberMgtComponent);
            }
            workItem.Workspaces[WorkspaceName.MainWorkspace].Show(uc);
            uc.Parent.Text = "Danh Sách Thành Viên";
        }

        #endregion

        #region Event's support

        #region PartnerInfo

        private void LoadPartnerInfo()
        {
            try
            {
                this.masterInfo = OrganizationFactory.Instance.GetChannel().GetMasterInfo(StorageService.CurrentSessionId, SystemSettings.Instance.Master);
                this.partnerInfoList = OrganizationFactory.Instance.GetChannel().GetPartnerInfo(StorageService.CurrentSessionId, masterInfo.MasterId, SystemSettings.Instance.Partner);
                cmbPartnerInfo.ValueMember = "PartnerId";
                cmbPartnerInfo.DisplayMember = "Name";
                cmbPartnerInfo.DataSource = this.partnerInfoList;
            }
            catch (TimeoutException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.TimeOutExceptionMessage);
                this.Hide();
            }
            catch (FaultException<WcfServiceFault> ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
                this.Hide();
            }
            catch (FaultException ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.FaultExceptionMessage
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
                this.Hide();
            }
            catch (CommunicationException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.CommunicationExceptionMessage);
                this.Hide();
            }
            //aes = new AesEncryption(this.masterInfo.MasterKey);
        }

        private void HideOrShowOrg()
        {
            if (partnerInfoList.Count <= 1)
                plHideShowOrg.Height = 0;
            else
                plHideShowOrg.Height = 55;
        }

        #endregion

        #region Functions for organization

        private void InitOrganizationsGrid()
        {
            dtbMemberList = new DataTable();
            dtbMemberList.Columns.Add(colMemberId.DataPropertyName);
            dtbMemberList.Columns.Add(colMemberCode.DataPropertyName);
            dtbMemberList.Columns.Add(colLastName.DataPropertyName);
            dtbMemberList.Columns.Add(colFirstName.DataPropertyName);
            dtbMemberList.Columns.Add(colTitle.DataPropertyName);
            dtbMemberList.Columns.Add(colPosition.DataPropertyName);
            dtbMemberList.Columns.Add(colBirthDate.DataPropertyName);
            dtbMemberList.Columns.Add(colPermanentAddress.DataPropertyName);
            dtbMemberList.Columns.Add(colTemporaryAddress.DataPropertyName);
            dtbMemberList.Columns.Add(colPhoneNo.DataPropertyName);
            dtbMemberList.Columns.Add(colPersoStatus.DataPropertyName);
            dtbMemberList.Columns.Add(colActive.DataPropertyName);
            dtbMemberList.Columns.Add(colDegree.DataPropertyName);
            dtbMemberList.Columns.Add(colEmail.DataPropertyName);
            dgvMembers.DataSource = dtbMemberList;
        }

        private void LoadSubOrgList()
        {
            // Call background worker if it's not busy
            if (!loadSubOrgWorker.IsBusy)
            {
                // Clear existing data
                subOrgNodeSelected = null;
                dtbMemberList.Rows.Clear();
                rootNode.Nodes.Clear();
                loadSubOrgWorker.RunWorkerAsync();
            }
        }

        private void OnLoadOrgWorkerDoWork(object s, DoWorkEventArgs e)
        {
            List<SubOrgCustomerDTO> result = null;
            SubOrgFilterDto filter = new SubOrgFilterDto();
            try
            {
                result = OrganizationFactory.Instance.GetChannel().GetSubOrgList(storageService.CurrentSessionId, partnerInfoSelected.PartnerId, filter);
            }
            catch (TimeoutException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.TimeOutExceptionMessage);
            }
            catch (FaultException<WcfServiceFault> ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
            }
            catch (FaultException ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.FaultExceptionMessage
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
            }
            catch (CommunicationException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.CommunicationExceptionMessage);
            }
            finally
            {
                e.Result = result;
            }
        }

        private void OnLoadOrgWorkerCompleted(object s, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }

            if (e.Result == null || !(e.Result is List<SubOrgCustomerDTO>))
            {
                return;
            }

            List<SubOrgCustomerDTO> result = e.Result as List<SubOrgCustomerDTO>;
            foreach (SubOrgCustomerDTO subOrg in result)
            {
                TreeNode facultyNode = new TreeNode();
                facultyNode.Text = subOrg.Name;
                facultyNode.Name = Convert.ToString(subOrg.SubOrgId);
                rootNode.Nodes.Add(facultyNode);

                //foreach (DepartmentDto department in faculty.ListOfDepartments)
                //{
                //    TreeNode departmentNode = new TreeNode();
                //    departmentNode.Text = department.Name;
                //    departmentNode.Name = Convert.ToString(department.Id);
                //    facultyNode.Nodes.Add(departmentNode);
                //}
                facultyNode.Collapse();
            }
            trvOrganizations.Sort();
            rootNode.Expand();
        }

        #endregion

        #region Functions for member

        private void LoadMemberList()
        {
            if (!loadMemberWorker.IsBusy && subOrgNodeSelected != null)
            {
                dtbMemberList.Rows.Clear();
                MemberChipList = null;

                pagerPanel.ShowMessage("Đang tải dữ liệu, xin hãy chờ...");
                loadMemberWorker.RunWorkerAsync();
            }
        }

        private PersoChipFilter GetMemberFilter()
        {
            PersoChipFilter filter = new PersoChipFilter();

            if (cbxFilterByMemberName.Checked)
            {
                tbxMemberName.Text = tbxMemberName.Text.Trim();
                if (tbxMemberName.Text.Length < 2)
                {
                    Invoke(new Action(() => { lblNotification1.Visible = true; }));
                    return null;
                }
                else
                {
                    Invoke(new Action(() => { lblNotification1.Visible = false; }));
                }
                filter.FilterByMemberName = true;
                filter.MemberName = tbxMemberName.Text;
            }
            //if (cbxFilterByMemberCode.Checked)
            //{
            //    tbxMemberCode.Text = tbxMemberCode.Text.Trim();
            //    if (tbxMemberCode.Text.Length < 2)
            //    {
            //        Invoke(new Action(() => { lblNotification2.Visible = true; }));
            //        return null;
            //    }
            //    else
            //    {
            //        Invoke(new Action(() => { lblNotification2.Visible = false; }));
            //    }
            //    filter.FilterByCode = true;
            //    filter.Code = tbxMemberCode.Text;
            //}
            //if (cbxFilterByPersoStatusMember.Checked)
            //{
            //    filter.FilterByPersoStatus = true;
            //    filter.Personalized = rbtnPerso.Checked;
            //}
            //if (cbxFilterByWorkingStatus.Checked)
            //{
            //    filter.FilterByWorkingStatus = true;
            //    if (rbtnNotWorking.Checked)
            //    {
            //        filter.WorkingStatus = (int)TeacherWorkingStatus.NotWorking;
            //    }
            //    else if (rbtnWorkingAbroad.Checked)
            //    {
            //        filter.WorkingStatus = (int)TeacherWorkingStatus.WorkingAbroad;
            //    }
            //    else
            //    {
            //        filter.WorkingStatus = (int)TeacherWorkingStatus.Working;
            //    }
            //}
            //if (selectedOrgNode != null)
            //{
            //    if (selectedOrgNode.Level == 1)
            //    {
            //        filter.FilterByFaculty = true;
            //        filter.FacultyId = Convert.ToInt64(selectedOrgNode.Name);
            //    }
            //    else if (selectedOrgNode.Level == 2)
            //    {
            //        filter.FilterByDepartment = true;
            //        filter.DepartmentId = Convert.ToInt64(selectedOrgNode.Name);
            //    }
            //}
            //if (cbxFilterByDegree.Checked)
            //{
            //    filter.FilterByDegreeCode = true;
            //    filter.DegreeCode = txtDegreeCode.Text;
            //}

            return filter;
        }

        private void bgwMember_DoWork(object sender, DoWorkEventArgs e)
        {
            int totalRecords = 0;
            int take = LocalSettings.Instance.RecordsPerPage;
            int skip = (currentPageIndex - 1) * take;

            PersoChipFilter filter = GetMemberFilter();
            if (filter == null)
            {
                return;
            }

            try
            {
                MemberChipList = OrganizationFactory.Instance.GetChannel().GetMemberList(storageService.CurrentSessionId, partnerInfoSelected.PartnerId, Convert.ToInt64(subOrgNodeSelected.Name), filter);
            }
            catch (TimeoutException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.TimeOutExceptionMessage);
                MemberChipList = null;
            }
            catch (FaultException<WcfServiceFault> ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
                MemberChipList = null;
            }
            catch (FaultException ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.FaultExceptionMessage
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
                MemberChipList = null;
            }
            catch (CommunicationException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.CommunicationExceptionMessage);
                MemberChipList = null;
            }
            finally
            {
                pagerPanel.ShowNumberOfRecords(totalRecords, MemberChipList != null ? MemberChipList.Count : 0, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
                pagerPanel.UpdatePagingLinks(totalRecords, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
            }
        }

        private void bgwMember_WorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if (MemberChipList == null)
            {
                return;
            }
            foreach (MemberCustomerDTO mc in MemberChipList)
            {
                DataRow row = dtbMemberList.NewRow();
                row.BeginEdit();

                row[colMemberId.DataPropertyName] = mc.Member.Id;
                row[colMemberCode.DataPropertyName] = mc.Member.Code;
                row[colLastName.DataPropertyName] = mc.Member.LastName;
                row[colFirstName.DataPropertyName] = mc.Member.FirstName;
                row[colBirthDate.DataPropertyName] = string.Format("{0:MM/dd/yyyy}", mc.Member.BirthDate);
                row[colPermanentAddress.DataPropertyName] = mc.Member.PermanentAddress;
                row[colTemporaryAddress.DataPropertyName] = mc.Member.TemporaryAddress;
                row[colTitle.DataPropertyName] = mc.Member.Title;
                row[colPosition.DataPropertyName] = mc.Member.Position;
                row[colDegree.DataPropertyName] = mc.Member.Degree;
                row[colPhoneNo.DataPropertyName] = mc.Member.PhoneNo;
                row[colEmail.DataPropertyName] = mc.Member.Email;
                row[colTemporaryAddress.DataPropertyName] = mc.Member.TemporaryAddress;
                row[colActive.DataPropertyName] = mc.Member.Active ? string.Empty : LocalSettings.Instance.CheckSymbol;
                row[colPersoStatus.DataPropertyName] = mc.PersoCard== null ? string.Empty : LocalSettings.Instance.CheckSymbol;

                row.EndEdit();
                dtbMemberList.Rows.Add(row);
            }
        }

        [CommandHandler(MemberCommandNames.PersoCard)]
        public void btnPersoCard_Clicked(object sender, EventArgs e)
        {
            // Get selected rows
            var selectedRows = dgvMembers.SelectedRows;
            int rowsCount = selectedRows.Count;
            if (rowsCount == 0)
            {
                MessageBoxManager.ShowErrorMessageBox(this, "Bạn chưa chọn thành viên cần cấp thẻ!", "Thao Tác Sai");
                return;
            }

            // Get selected teachers
            List<Member> selectedMembers = new List<Member>();
            for (int i = 0; i < rowsCount; i++)
            {
                long id = Convert.ToInt64(selectedRows[i].Cells[colMemberId.Name].Value.ToString());
                selectedMembers.Add(MemberChipList.Find(t => t.Member.Id == id).Member);
            }

            FrmPersoProcess dialog = new FrmPersoProcess(selectedMembers, masterInfo.MasterId == partnerInfoSelected.PartnerId);
            workItem.SmartParts.Add(dialog);
            dialog.ShowDialog();

            workItem.SmartParts.Remove(dialog);
            dialog.Dispose();
            LoadMemberList();
        }

        #endregion


        #endregion


    }
}