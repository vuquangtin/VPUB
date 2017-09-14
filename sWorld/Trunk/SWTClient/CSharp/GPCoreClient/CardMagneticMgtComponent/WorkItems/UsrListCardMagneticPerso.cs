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
using Microsoft.Practices.CompositeUI.EventBroker;
using CardMagneticMgtComponent.Constants;
using Microsoft.Practices.CompositeUI.Commands;
using CommonHelper.Constants;
using JavaCommunication.Factory;
using CommonHelper.Config;
using sWorldModel.TransportData;
using CommonControls;
using System.ServiceModel;
using sWorldModel.Exceptions;
using sWorldModel.Model;
using sWorldModel.Filters;
using CommonControls.Custom;

namespace CardMagneticMgtComponent.WorkItems
{
    public partial class UsrListCardMagneticPerso : CommonUserControl
    {
        #region Properties

        private BackgroundWorker loadSubOrgWorker;

        private int currentPageIndex = 1;
        //  private BackgroundWorker bgwLoadPerso;
        private BackgroundWorker loadMemberWorker;
        private Font startupNodeFont;
        private TreeNode selectedOrgNode;
        private TreeNode subOrgNodeSelected;
        private TreeNode rootNode;
        private int startupFilterBoxHeight;
        private DataTable dtbListMember;
        private List<long> persoIds;
        //private List<MagneticPersonalization> MemberMagneticList;
        // private PartnerInfoDTO partnerInfoSelect;
        private MasterInfoDTO masterInfo;
        private PartnerInfoDTO partnerInfoSelected;
        private List<MagneticPersonalizationDTO> PersoList;

        private CardMagneticFilterDto filter; // Khoi tao ben ngoai cho quy trinh tiep theo

        private const int hiddenFilterBoxHeight = 1;
        private CardMagneticWorkItem workItem;

        [ServiceDependency]
        public CardMagneticWorkItem WorkItem
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

        #region CAB events

        [EventPublication(CardMagneticEventTopicNames.ListCardMagneticPersoMainShown)]
        public event EventHandler ListCardMagneticPersoMainShown;

        [CommandHandler(CardMagneticCommandNames.ShowCardListMagneticMgt)]
        public void ShowCardMgtMainHandler(object s, EventArgs e)
        {
            UsrListCardMagneticPerso uc = workItem.Items.Get<UsrListCardMagneticPerso>(ComponentNames.ListCardMagneticMgtPersoComponent);
            if (uc == null)
            {
                uc = workItem.Items.AddNew<UsrListCardMagneticPerso>(ComponentNames.ListCardMagneticMgtPersoComponent);
            }
            else if (uc.IsDisposed)
            {
                workItem.Items.Remove(uc);
                uc = workItem.Items.AddNew<UsrListCardMagneticPerso>(ComponentNames.ListCardMagneticMgtPersoComponent);
            }

            workItem.Workspaces[WorkspaceName.MainWorkspace].Show(uc);
            uc.Parent.Text = MenuNames.MenuCardPersoManager;
        }

        [CommandHandler(CardMagneticCommandNames.Lock)]
        private void btnLock_Click(object sender, EventArgs e)
        {
            uploadStatus(FrmConfirmChangeStatus.Lock);
            LoadMemberList();
        }

        [CommandHandler(CardMagneticCommandNames.UnLock)]
        private void btnUnLock_Click(object sender, EventArgs e)
        {
            uploadStatus(FrmConfirmChangeStatus.Actived);
            LoadMemberList();
        }

        [CommandHandler(CardMagneticCommandNames.Cancel)]
        private void btnMarkCancel_Click(object sender, EventArgs e)
        {
            uploadStatus(FrmConfirmChangeStatus.Cancel);
            LoadMemberList();
        }

        [CommandHandler(CardMagneticCommandNames.MarkExpired)]
        private void btnMarkExpired_Click(object sender, EventArgs e)
        {
            uploadStatus(FrmConfirmChangeStatus.Expired);
            LoadMemberList();
        }

        #endregion

        #region Constructors

        public UsrListCardMagneticPerso()
        {
            InitializeComponent();
            InitOrganizationsGrid();
            Load += UsrListCardMagneticPerso_Load;

            loadSubOrgWorker = new BackgroundWorker();
            loadSubOrgWorker.WorkerSupportsCancellation = true;
            loadSubOrgWorker.DoWork += bgwLoadOrganizations_DoWork;
            loadSubOrgWorker.RunWorkerCompleted += bgwLoadOrganizations_Completed;

            loadMemberWorker = new BackgroundWorker();
            loadMemberWorker.WorkerSupportsCancellation = true;
            loadMemberWorker.DoWork += bgwMember_DoWork;
            loadMemberWorker.RunWorkerCompleted += bgwMember_WorkerCompleted;

            this.cbxFilterByCardType.CheckedChanged += cbxFilterByCardType_CheckedChanged;
            this.cbxFilterByMemberName.CheckedChanged += cbxFilterByTeacherName_CheckedChanged;
            this.cbxFilterByPersoDate.CheckedChanged += cbxFilterByPersoDate_CheckedChanged;
            this.cbxFilterByCardStatus.CheckedChanged += cbxFilterByCardStatus_CheckedChanged;
          //  this.cbxFilterByCardLogicalStatus.CheckedChanged += cbxFilterByCardLogicalStatus_CheckedChanged;
            this.cbxFilterByPhoneNumber.CheckedChanged += cbxFilterByPhoneNumber_CheckedChanged;

            this.btnShowHide.Click += btnShowHide_Clicked;

            btnReloadOrgs.Click += (s, e) => LoadSubOrgList();
            mniReloadOrgs.Click += (s, e) => LoadSubOrgList();
            btnReloadPersoes.Click += (s, e) => LoadMemberList();
            //mniReloadMembers.Click += (s, e) => LoadMemberList();

            pagerPanel.LinkLabelClicked += pagerPanel_LinkLabelClicked;

            //   dtpPersoDateFrom.Value = dtpPersoDateFrom.MaxDate = dtpPersoDateTo.Value = dtpPersoDateTo.MinDate = DateTime.Now;

            dtpPersoDateFrom.Value = dtpPersoDateFrom.MaxDate = dtpPersoDateTo.Value = DateTime.Now;

            trvOrganizations.AfterExpand += trvOrganizations_AfterExpand;
            trvOrganizations.BeforeSelect += trvOrganizations_BeforeSelect;
            trvOrganizations.AfterSelect += trvOrganizations_AfterSelect;

            dgvPersoes.MouseDown += dgvPersoes_MouseDown;
            trvOrganizations.MouseDown += trvOrganizations_MouseDown;

            //cbxShowCanceledPersoes.CheckedChanged += cbxShowCanceledPersoes_CheckedChanged;

            this.Enter += (s, e) =>
            {
                if (ListCardMagneticPersoMainShown != null)
                {
                    ListCardMagneticPersoMainShown(this, new CabEventArgs(new object[] { CardMagneticCommandNames.ShowCardMagneticMgtMain }));
                }
            };
        }

        #endregion

        #region Form events

        private void UsrListCardMagneticPerso_Load(object sender, EventArgs e)
        {
            // Assign startup value
            startupNodeFont = trvOrganizations.Font;
            startupFilterBoxHeight = pnlFilterBox.Height;

            // Add root node
            rootNode = new TreeNode();
            rootNode.Text = "Tất Cả";
            rootNode.Name = "-1";
            trvOrganizations.Nodes.Add(rootNode);

            //Load PartnerInfo
            //neu co 1 partner thi hidden combobox
            LoadPartnerInfo();
            HideOrShowOrg();

            // Check permissions
            ILocalStorageService storageService = workItem.Services.Get<ILocalStorageService>();
            List<Function> permissions = storageService.GetObject(CacheKeyNames.CurrentUserPermissions) as List<Function>;
            // Populate card Physical status to combobox
            List<CardMagneticStatus> cardphysicalstatus = CardMagneticStatusExtMethod.GetCardStatusList();
            DataTable dtbcardphysicalstatus = new DataTable();
            dtbcardphysicalstatus.Columns.Add("Id");
            dtbcardphysicalstatus.Columns.Add("Name");
            foreach (CardMagneticStatus ct in cardphysicalstatus)
            {
                DataRow row = dtbcardphysicalstatus.NewRow();
                row.BeginEdit();
                row["Id"] = (int)ct;
                row["Name"] = ct.GetName();
                row.EndEdit();
                dtbcardphysicalstatus.Rows.Add(row);
            }

            cmbCardStatus.DataSource = dtbcardphysicalstatus;
            cmbCardStatus.ValueMember = "Id";
            cmbCardStatus.DisplayMember = "Name";

            // Populate card Logical status to combobox
            List<CardMagneticStatus> cardlogicalstatus = CardMagneticStatusExtMethod.GetCardStatusList();
            DataTable dtbcardlogicalstatus = new DataTable();
            dtbcardlogicalstatus.Columns.Add("Id");
            dtbcardlogicalstatus.Columns.Add("Name");
            foreach (CardMagneticStatus ct in cardlogicalstatus)
            {
                DataRow row = dtbcardlogicalstatus.NewRow();
                row.BeginEdit();
                row["Id"] = (int)ct;
                row["Name"] = ct.GetName();
                row.EndEdit();
                dtbcardlogicalstatus.Rows.Add(row);
            }

            //cmbCardLogicalStatus.DataSource = dtbcardlogicalstatus;
            //cmbCardLogicalStatus.ValueMember = "Id";
            //cmbCardLogicalStatus.DisplayMember = "Name";
        }

        // Lấy về danh sách partner 
        private void cmbPartnerInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void dgvPersoes_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo info = dgvPersoes.HitTest(e.X, e.Y);
                if (info.RowIndex != -1)
                {
                    if (info.RowIndex >= 0 && info.ColumnIndex >= 0)
                    {
                        if (!dgvPersoes.SelectedRows.Contains(dgvPersoes.Rows[info.RowIndex]))
                        {
                            foreach (DataGridViewRow row in dgvPersoes.SelectedRows)
                            {
                                row.Selected = false;
                            }
                            dgvPersoes.Rows[info.RowIndex].Selected = true;
                        }
                    }
                    Rectangle r = dgvPersoes.GetCellDisplayRectangle(info.ColumnIndex, info.RowIndex, true);
                    cmsPersoRecord.Show((Control)sender, e.X, e.Y);
                }
                else
                {
                    cmsPersoTable.Show((Control)sender, e.X, e.Y);
                }
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
            dtbListMember.Rows.Clear();
            int take = LocalSettings.Instance.RecordsPerPage;
            int skip = (currentPageIndex -1) * take;

            List<MagneticPersonalizationDTO> result = PersoList.Skip(skip).Take(take).ToList();
            LoadPersoDataGridView(result);

            pagerPanel.ShowNumberOfRecords(PersoList.Count, result != null ? result.Count : 0, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
            pagerPanel.UpdatePagingLinks(PersoList.Count, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            string filePath = ControlExtMethods.ShowSaveFileDialog("Chọn tập tin chứa dữ liệu cần xuất", "MS Excel (*.xls)|*.xls");
            if (filePath != null)
            {
                try
                {
                    dgvPersoes.ExportToExcel(filePath);
                }
                catch (Exception ex)
                {
                    MessageBoxManager.ShowErrorMessageBox(this, ex.Message);
                    return;
                }
                MessageBoxManager.ShowInfoMessageBox(this, "Đã xuất dữ liệu ra tập tin tại đường dẫn: " + filePath);
            }
        }

        #endregion

        #region Form Controls

        #region PartnerInfo


        private void LoadSubOrgList()
        {
            // Call background worker if it's not busy
            if (!loadSubOrgWorker.IsBusy)
            {
                // Clear existing data
                subOrgNodeSelected = null;
                dtbListMember.Rows.Clear();
                rootNode.Nodes.Clear();
                loadSubOrgWorker.RunWorkerAsync();
            }
        }

        private void LoadPartnerInfo()
        {
            try
            {
                masterInfo = OrganizationFactory.Instance.GetChannel().GetMasterInfo(StorageService.CurrentSessionId, SystemSettings.Instance.Partner);
                LoadSubOrgList();
                LoadCardTypeOfPartner(masterInfo);
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

        private void LoadCardTypeOfPartner(MasterInfoDTO partner)
        {
            if (partner.cardtypes != null && partner.cardtypes.Count > 0)
            {
                cmbCardTypes.DataSource = partner.cardtypes;
                cmbCardTypes.DisplayMember = "cardTypeName";
                cmbCardTypes.ValueMember = "prefix";
                cmbCardTypes.SelectedIndex = 0;
            }
        }

        private void HideOrShowOrg()
        {
            //if (partnerInfoList.Count <= 1)
            //    plHideShowOrg.Height = 0;
            //else
            //    plHideShowOrg.Height = 55;
        }

        #endregion

        #region Load OrgPartner

        private void InitOrganizationsGrid()
        {
            dtbListMember = new DataTable();
            dtbListMember.Columns.Add(colMagneticId.DataPropertyName);
            dtbListMember.Columns.Add(colCardMagneticId.DataPropertyName);
            dtbListMember.Columns.Add(colMemberId.DataPropertyName);
            dtbListMember.Columns.Add(colMemberName.DataPropertyName);
            dtbListMember.Columns.Add(colOrgName.DataPropertyName);
            dtbListMember.Columns.Add(colSubOrgName.DataPropertyName);
            dtbListMember.Columns.Add(colPhoneNo.DataPropertyName);
            dtbListMember.Columns.Add(colSerialCard.DataPropertyName);
            dtbListMember.Columns.Add(colPersoStatus.DataPropertyName);
            dtbListMember.Columns.Add(colCardType.DataPropertyName);
            dtbListMember.Columns.Add(colNotes.DataPropertyName);
            dtbListMember.Columns.Add(colEmail.DataPropertyName);
            dtbListMember.Columns.Add(colPersoDate.DataPropertyName);
            dtbListMember.Columns.Add(colExpirationDate.DataPropertyName);
            dtbListMember.Columns.Add(colPinCodeNew.DataPropertyName);
            dtbListMember.Columns.Add(colActiveCodeNew.DataPropertyName);
            dgvPersoes.DataSource = dtbListMember;
        }

        private void trvOrganizationList_AfterExpand(object sender, TreeViewEventArgs e)
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

        private void trvOrganizationList_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            //// If background worker is running -> restrict selecting another node
            //if (loadMemberWorker.IsBusy)
            //{
            //    e.Cancel = true;
            //    return;
            //}

            //// Change node font style to normal
            //if (selectedOrgNode != null)
            //{
            //    selectedOrgNode.NodeFont = new Font(startupNodeFont, FontStyle.Regular);
            //    selectedOrgNode.Text = selectedOrgNode.Text;
            //}
        }

        private void trvOrganizationList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectedNode = e.Node;
            if (selectedNode != null)
            {
                selectedNode.NodeFont = new Font(startupNodeFont, FontStyle.Bold);
                selectedNode.Text = selectedNode.Text;

                if (selectedOrgNode != null && selectedNode == selectedOrgNode)
                {
                    return;
                }
                selectedOrgNode = selectedNode;
                currentPageIndex = 1;
                LoadMemberList();
            }
        }

        private void trvOrganizations_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeNode node = trvOrganizations.GetNodeAt(trvOrganizations.PointToClient(Control.MousePosition));
                if (node == null)
                {
                    cmsOrgTree.Show((Control)sender, e.Location.X, e.Location.Y);
                }
            }
        }

        //private void LoadOrganizations()
        //{
        //    // Call background worker if it's not busy

        //    if (!loadFacultyWorker.IsBusy)
        //    {
        //        // Clear existing data
        //        rootNode.Nodes.Clear();
        //        loadFacultyWorker.RunWorkerAsync();
        //    }
        //}

        private void bgwLoadOrganizations_DoWork(object s, DoWorkEventArgs e)
        {
            List<SubOrgCustomerDTO> result = null;
            SubOrgFilterDto filter = new SubOrgFilterDto();
            try
            {
                result = OrganizationFactory.Instance.GetChannel().GetSubOrgList(storageService.CurrentSessionId, masterInfo.MasterId, filter);
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

        private void bgwLoadOrganizations_Completed(object s, RunWorkerCompletedEventArgs e)
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
            //rootNode.Nodes.Clear();
            foreach (SubOrgCustomerDTO subOrg in result)
            {
                TreeNode subOrgNode = new TreeNode();
                subOrgNode.Text = subOrg.Name;
                subOrgNode.Name = Convert.ToString(subOrg.SubOrgId);
                rootNode.Nodes.Add(subOrgNode);
                //  subOrgNode.Collapse();

                //foreach (DepartmentDto department in subOrg.ListOfDepartments)
                //{
                //    TreeNode departmentNode = new TreeNode();
                //    departmentNode.Text = department.Name;
                //    departmentNode.Name = Convert.ToString(department.Id);
                //    subOrgNode.Nodes.Add(departmentNode);
                //}
                subOrgNode.Collapse();
            }
            trvOrganizations.Sort();
            rootNode.Expand();
        }

        private void cbxFilterByCardType_CheckedChanged(object sender, EventArgs e)
        {
            cmbCardTypes.Enabled = cbxFilterByCardType.Checked;
        }

        private void cbxFilterByTeacherName_CheckedChanged(object sender, EventArgs e)
        {
            tbxMemberName.Enabled = cbxFilterByMemberName.Checked;
            lblNotification1.Visible = false;
        }

        private void cbxFilterByPhoneNumber_CheckedChanged(object sender, EventArgs e)
        {
            txtPhoneNumber.Enabled = cbxFilterByPhoneNumber.Checked;
            lblNotification2.Visible = false;
        }

        private void cbxFilterByPersoDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpPersoDateFrom.Enabled = dtpPersoDateTo.Enabled = cbxFilterByPersoDate.Checked;
        }

        private void cbxFilterByCardStatus_CheckedChanged(object sender, EventArgs e)
        {
            cmbCardStatus.Enabled = cbxFilterByCardStatus.Checked;
        }

        #endregion

        #region Filter functions

        private CardMagneticFilterDto GetFilterMagnetic()
        {
            CardMagneticFilterDto filter = new CardMagneticFilterDto();

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

            if (cbxFilterByPhoneNumber.Checked)
            {
                txtPhoneNumber.Text = txtPhoneNumber.Text.Trim();
                if (txtPhoneNumber.Text.Length < 3)
                {
                    Invoke(new Action(() => { lblNotification2.Visible = true; }));
                    return null;
                }
                else
                {
                    Invoke(new Action(() => { lblNotification2.Visible = false; }));
                }
                filter.FilterByPhoneNumber = true;
                filter.PhoneNumber = txtPhoneNumber.Text;
            }

            if (cbxFilterByCardType.Checked && cmbCardTypes.SelectedIndex > -1)
            {
                filter.FilterByCardType = true;
                filter.Prefix = cmbCardTypes.SelectedValue.ToString();
            }

            if (cbxFilterByCardStatus.Checked && cmbCardStatus.SelectedIndex > -1)
            {
                filter.FilterByCardStatus = true;
                filter.CardStatus = Convert.ToInt32(cmbCardStatus.SelectedValue);
            }

            if (selectedOrgNode != null)
            {
                if (selectedOrgNode.Level == 1)
                {
                    filter.FilterByOrgPartner = true;
                    filter.OrgPartnerId = Convert.ToInt32(selectedOrgNode.Name);
                }
                //else if (selectedOrgNode.Level == 2)
                //{
                //    filter.FilterByDepartmentId = true;
                //    filter.DepartmentId = Convert.ToInt32(selectedOrgNode.Name);
                //}
            }

            if (cbxFilterByPersoDate.Checked)
            {
                TimePeriodDto period = new TimePeriodDto();
                period.Start = dtpPersoDateFrom.Value.Date.ToString("dd/MM/yyyy");
                period.End = dtpPersoDateTo.Value.Date.ToString("dd/MM/yyyy"); //String.Format("dd/MM/yyyy", dtpPersoDateTo.Value.Date);//ersoDateTo.Value.Date.Add(new TimeSpan(23, 59, 59)).ToShortDateString();
                filter.PersoDatePeriod = period;
                filter.FilterByPersoDate = true;
            }
            return filter;
        }

        #endregion

        #endregion

        #region Functions for member

        private void LoadMemberList()
        {
            if (!loadMemberWorker.IsBusy && subOrgNodeSelected != null)
            {
                dtbListMember.Rows.Clear();
                filter = GetFilterMagnetic();// quy trinh  A, B
                pagerPanel.ShowMessage("Đang tải dữ liệu, xin hãy chờ...");
                loadMemberWorker.RunWorkerAsync();
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

        private void bgwMember_DoWork(object sender, DoWorkEventArgs e)
        {
            int totalRecords = 0;
            int take = LocalSettings.Instance.RecordsPerPage;
            int skip = 0;
            currentPageIndex = 1;

            List<MagneticPersonalizationDTO> result = null;
            if (filter == null)
            {
                return;
            }
            try
            {
                PersoList = MagneticPersonalizationFactory.Instance.GetChannel().GetMemberMagneticList(storageService.CurrentSessionId, masterInfo.MasterId, Convert.ToInt64(subOrgNodeSelected.Name), filter);
            }
            catch (TimeoutException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.TimeOutExceptionMessage);
                result = null;
            }
            catch (FaultException<WcfServiceFault> ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
                result = null;
            }
            catch (FaultException ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.FaultExceptionMessage
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
                result = null;
            }
            catch (CommunicationException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.CommunicationExceptionMessage);
                result = null;
            }
            finally
            {
                if (PersoList != null)
                {
                    result = PersoList.Skip(skip).Take(take).ToList();
                    totalRecords = PersoList.Count;
                    pagerPanel.ShowNumberOfRecords(totalRecords, result != null ? result.Count : 0, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
                    pagerPanel.UpdatePagingLinks(totalRecords, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
                }
                e.Result = result;
            }
        }

        private void bgwMember_WorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if (e.Result == null)
            {
                return;
            }

            List<MagneticPersonalizationDTO> result = e.Result as List<MagneticPersonalizationDTO>;
            DateTime today = DateTime.Today;
            LoadPersoDataGridView(result);
        }

        private void LoadPersoDataGridView(List<MagneticPersonalizationDTO> result)
        {
            foreach (MagneticPersonalizationDTO mm in result)
            {
                DataRow row = dtbListMember.NewRow();
                row.BeginEdit();
                row[colMagneticId.DataPropertyName] = mm.MagneticPersId;
                row[colCardMagneticId.DataPropertyName] = mm.CardMagneticId;
                row[colOrgName.DataPropertyName] = mm.OrgName;
                row[colSubOrgName.DataPropertyName] = mm.SubOrgName;
                row[colMemberId.DataPropertyName] = mm.MemberId;
                row[colMemberName.DataPropertyName] = mm.FullName;
                row[colPhoneNo.DataPropertyName] = mm.PhoneNumber;
                row[colSerialCard.DataPropertyName] = mm.SerialCard;
                row[colCardType.DataPropertyName] = mm.cardtypes;
                row[colPersoStatus.DataPropertyName] = ((CardMagneticStatus)mm.Status).GetName();
                row[colPhoneNo.DataPropertyName] = mm.PhoneNumber;
                row[colPersoDate.DataPropertyName] = mm.PersoDate;
                row[colExpirationDate.DataPropertyName] = mm.ExpirationDate;
                //  row[colExpirationDate.DataPropertyName] = string.Format("{0:dd/MM/yyyy}", mm.PersoCardMagnetic.ExpirationDate);
                row[colPinCodeNew.DataPropertyName] = mm.PinCodeNew;
                row[colActiveCodeNew.DataPropertyName] = mm.ActiveCodeNew;
                row[colNotes.DataPropertyName] = mm.Notes;
                row.EndEdit();
                dtbListMember.Rows.Add(row);
            }
        }

        #endregion

        #region Thay đổi trạng thái thẻ

        private void DoActionChangeStatusPersoes(byte status, string Reason, List<long> persoIds)
        {

            List<MagneticPersonalizationDTO> result = null;
            try
            {
                //TODO: implement call server update status
                result = MagneticPersonalizationFactory.Instance.GetChannel().GetChangeStatusMagnetic(storageService.CurrentSessionId, status, Reason, persoIds);

            }
            catch (TimeoutException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.TimeOutExceptionMessage);
                return;
            }
            catch (FaultException<WcfServiceFault> ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
                return;
            }
            catch (FaultException ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.FaultExceptionMessage
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
                return;
            }
            catch (CommunicationException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.CommunicationExceptionMessage);
                return;
            }
            if (result != null && result.Count > 0)
            {
                LoadMemberList();
            }
        }

        /// <summary>
        /// upload status of list
        /// </summary>
        /// <param name="status"> byte Lock = 1;  Unlock = 2; Cancel = 3;</param>
        private void uploadStatus(byte status)
        {
            persoIds = new List<long>();
            int count = dgvPersoes.SelectedRows.Count;
            if (count == 0)
            {
                MessageBoxManager.ShowErrorMessageBox(this, "Bạn chưa chọn lượt phát hành cho thao tác này!", "Thao Tác Sai");
                return;
            }

            var confirmDialog = FrmConfirmChangeStatus.GetInstance(status);
            confirmDialog.ShowDialog();

            if (confirmDialog.DialogResult == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dgvPersoes.SelectedRows)
                {
                    persoIds.Add(Convert.ToInt64(row.Cells[colMagneticId.Name].Value.ToString()));
                }
                DoActionChangeStatusPersoes(status, confirmDialog.Reason, persoIds);
            }
        }

        #endregion



    }
}







