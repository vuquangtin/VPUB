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
using CardChipMgtComponent.Constants;
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

namespace CardChipMgtComponent.WorkItems
{
    public partial class UsrMemberMgtMain : CommonUserControl
    {
        #region Properties

        private BackgroundWorker loadSubOrgWorker;

        private int currentPageIndex = 1;
        private DataTable dtbMemberList;
        private BackgroundWorker loadMemberWorker;
        private List<MemberCustomerDTO> MemberChipList;
        private MasterInfoDTO masterInfo;
        private List<PartnerInfoDTO> partnerInfoList;
        private PartnerInfoDTO partnerInfoSelected;
        private ResourceManager rm;

        private long OrgId;
        private long parenSelectId;
        private long selectId;

        private int startupFilterBoxHeight;
        private const int hiddenFilterBoxHeight = 1;

        private Dictionary<string, string> GroupSubOrgList;

        private CardWorkItem workItem;
        [ServiceDependency]
        public CardWorkItem WorkItem
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

            dgvMembers.MouseDown += dgvMembers_MouseDown;

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

            btnReloadMembers.Click += (s, e) => LoadMemberList();

            cbxFilterByPersoStatusMember.CheckedChanged += cbxFilterByPersoStatus_CheckChanged;
            cbxFilterByMemberCode.CheckedChanged += cbxFilterByMemberCode_CheckChanged;
            cbxFilterByMemberName.CheckedChanged += cbxFilterByMemberName_CheckChanged;
            cbxFilterByWorkingStatus.CheckedChanged += cbxFilterByWorkingStatus_CheckChanged;
            cbxFilterByDegree.CheckedChanged += cbxFilterByDegree_CheckChanged;

            //cmbPartnerInfo.SelectedIndexChanged += cmbPartnerInfo_SelectedIndexChanged;
        }

        private void OnFormLoad(object sender, EventArgs e)
        {
            // Check permissions
            ILocalStorageService storageService = workItem.Services.Get<ILocalStorageService>();
            List<Function> permissions = storageService.GetObject(CacheKeyNames.CurrentUserPermissions) as List<Function>;
            SessionDTO currentSession = storageService.GetObject(CacheKeyNames.CurrentSession) as SessionDTO;
            rm = storageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
            treeOrg.StorageService = storageService;
            treeOrg.AfterSelect += TreeOrgAfterSelect;
            treeOrg.InitializeData();
            treeOrg.SetHideButton();
            pagerPanel.StorageService = storageService;
            pagerPanel.LoadLanguage();

            //if (!permissions.Exists(p => p == Function.FUNC_PERSO_PERSO_CARD))
            //{
            //    btnPersoCard.Enabled = mniPersoCard.Enabled = false;
            //    btnPersoCard.Visible = mniPersoCard.Visible = false;
            //}

            // Assign startup value
            startupFilterBoxHeight = pnlFilterBox.Height;

            //Load Partner
            LoadPartnerInfo();
            HideOrShowOrg();

            // Load faculty/department list
            //LoadOrgList();


            // set table languages 
            SetLanguages();
        }

        private void SetLanguages()
        {



            this.colMemberId.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colMemberId.Name);
            this.colMemberCode.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colMemberCode.Name);
            this.colFirstName.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colFirstName.Name);
            this.colLastName.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colLastName.Name);
            this.colTitle.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colTitle.Name);
            this.colIdentityCard.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colIdentityCard.Name);
            this.colIdentityCardDate.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colIdentityCardDate.Name);
            this.colPermanentAddress.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colPermanentAddress.Name);
            this.colTemporaryAddress.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colTemporaryAddress.Name);
            this.colPhoneNo.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colPhoneNo.Name);
            this.colPersoStatus.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colPersoStatus.Name);
            this.colActive.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colActive.Name);
            this.colIdentityCardIssue.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colIdentityCardIssue.Name);
            this.colEmail.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colEmail.Name);

            this.btnPersoCard.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnPersoCard.Name);
            this.btnExportToExcel.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnExportToExcel.Name);
            this.btnReloadMembers.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnReloadMembers.Name);
            this.btnShowHide.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnShowHide.Name);

            this.mniPersoCard.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.mniPersoCard.Name);
            this.mniReloadOrgs.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.mniReloadOrgs.Name);

        }

        #endregion

        #region Form event

        //private void cmbPartnerInfo_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //partnerInfoSelected = cmbPartnerInfo.SelectedItem as PartnerInfoDTO;
        //}

        private void tbxMemberName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadMemberList();
            }
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            string filePath = ControlExtMethods.ShowSaveFileDialog(
MessageValidate.GetMessage(rm, "smsChooseFileExport"), "DanhSachThanhVien", "MS Excel (*.xls)|*.xls");
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
                MessageBoxManager.ShowInfoMessageBox(this,
MessageValidate.GetMessage(rm, "Exportdata") + filePath);
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
                }
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
                btnShowHide.Text = btnShowHide.ToolTipText = MessageValidate.GetMessage(rm, MessageValidate.ShowTextSearch);
                btnShowHide.ToolTipText = MessageValidate.GetMessage(rm, MessageValidate.HideTextSearch);
                btnShowHide.Image = global::CommonControls.Properties.Resources.ArrowDown_16x16;
            }
            else
            {
                pnlFilterBox.Height = startupFilterBoxHeight;
                btnShowHide.Text = btnShowHide.ToolTipText = MessageValidate.GetMessage(rm, MessageValidate.ShowTextSearch);
                btnShowHide.ToolTipText = MessageValidate.GetMessage(rm, MessageValidate.HideTextSearch);
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
            dtbMemberList.Rows.Clear();
            int take = LocalSettings.Instance.RecordsPerPage;
            int skip = (currentPageIndex - 1) * take;

            List<MemberCustomerDTO> result = MemberChipList.Skip(skip).Take(take).ToList();
            LoadMemberDataGridView(result);

            pagerPanel.ShowNumberOfRecords(MemberChipList.Count, result != null ? result.Count : 0, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
            pagerPanel.UpdatePagingLinks(MemberChipList.Count, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
        }

        [EventPublication(MemberEventTopicNames.MemberListShown)]
        public event EventHandler MemberMgtMainShown;

        [EventPublication(MemberEventTopicNames.MemberListHide)]
        public event EventHandler MemberMgtMainHide;

        [CommandHandler(MemberCommandNames.ShowMemberMgtMain)]
        public void ShowMemberMgtMainHandler(object s, EventArgs e)
        {
            UsrMemberMgtMain uc = workItem.Items.Get<UsrMemberMgtMain>(ComponentNames.PersoMemberMgtComponent);
            if (uc == null)
            {
                uc = workItem.Items.AddNew<UsrMemberMgtMain>(ComponentNames.PersoMemberMgtComponent);
            }
            else if (uc.IsDisposed)
            {
                workItem.Items.Remove(uc);
                uc = workItem.Items.AddNew<UsrMemberMgtMain>(ComponentNames.PersoMemberMgtComponent);
            }
            workItem.Workspaces[WorkspaceName.MainWorkspace].Show(uc);
            uc.Parent.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuCardPerso);
        }

        #endregion

        #region Event's support

        #region PartnerInfo

        private void LoadPartnerInfo()
        {
            try
            {
                this.masterInfo = OrganizationFactory.Instance.GetChannel().GetMasterInfo(StorageService.CurrentSessionId, SystemSettings.Instance.Partner);
                // Add root node
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
            //aes = new AesEncryption(this.masterInfo.MasterKey);
        }

        private void HideOrShowOrg()
        {
            //if (partnerInfoList.Count <= 1)
            //    plHideShowOrg.Height = 0;
            //else
            // plHideShowOrg.Height = 55;
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
            dtbMemberList.Columns.Add(colIdentityCard.DataPropertyName);
            dtbMemberList.Columns.Add(colIdentityCardDate.DataPropertyName);
            dtbMemberList.Columns.Add(colPermanentAddress.DataPropertyName);
            dtbMemberList.Columns.Add(colTemporaryAddress.DataPropertyName);
            dtbMemberList.Columns.Add(colPhoneNo.DataPropertyName);
            dtbMemberList.Columns.Add(colPersoStatus.DataPropertyName);
            dtbMemberList.Columns.Add(colActive.DataPropertyName);
            dtbMemberList.Columns.Add(colIdentityCardIssue.DataPropertyName);
            dtbMemberList.Columns.Add(colEmail.DataPropertyName);
            dgvMembers.DataSource = dtbMemberList;
        }



        #endregion

        #region Functions for member

        private void LoadMemberList()
        {
            if (!loadMemberWorker.IsBusy && selectId > 0)
            {
                dtbMemberList.Rows.Clear();
                MemberChipList = null;
                pagerPanel.ShowMessage(MessageValidate.GetMessage(rm, "waitLoadData"));
                loadMemberWorker.RunWorkerAsync(GetMemberFilter());
            }
        }

        private MemberFilter GetMemberFilter()
        {
            MemberFilter filter = new MemberFilter();


            if (cbxFilterByMemberName.Checked)
            {
                string dataSearchName = FormatCharacterSearch.CheckValue(tbxMemberName.Text.Trim());
                //tbxMemberName.Text = tbxMemberName.Text.Trim();
                if (dataSearchName.Length < 2)
                {
                    Invoke(new Action(() => { lblNotification1.Visible = true; }));
                    //20170603 BUG #705 do return null nên không lộc dữ liệu đúng Ten Nguyễn Start          
                    //return null;
                    //20170603 BUG #705 do return null nên không lộc dữ liệu đúng Ten Nguyễn End  
                }
                else
                {
                    Invoke(new Action(() => { lblNotification1.Visible = false; }));
                }
                filter.FilterByMemberName = cbxFilterByMemberName.Checked;
                filter.MemberName = dataSearchName;
            }
            if (cbxFilterByMemberCode.Checked)
            {
                string dataSearchCode = FormatCharacterSearch.CheckValue(tbxMemberCode.Text.Trim());
                //tbxMemberCode.Text = tbxMemberCode.Text.Trim();
                if (dataSearchCode.Length < 2)
                {
                    Invoke(new Action(() => { lblNotification2.Visible = true; }));

                }
                else
                {
                    Invoke(new Action(() => { lblNotification2.Visible = false; }));
                }
                filter.FilterByCode = cbxFilterByMemberCode.Checked;
                filter.Code = dataSearchCode;
            }

            //check member đã bị hủy
            filter.FilterByActive = true;
            filter.Active = true;

            return filter;
        }
        #region Event after tree select
        private void TreeOrgAfterSelect(long orgId, long parentId, long selectedOrgId)
        {
            //gan 2 giá trị từ event hander
            this.OrgId = orgId;
            this.parenSelectId = parentId;
            this.selectId = selectedOrgId;
            if (orgId == -1 || selectedOrgId == -1)
            {
                ShowHideButton(false);
            }
            else
            {
                ShowHideButton(true);
            }
            LoadMemberList();
        }
        #endregion
        private void ShowHideButton(bool visible)
        {
            btnPersoCard.Enabled =
                btnExportToExcel.Enabled =
                btnReloadMembers.Enabled = visible;
        }
        private void bgwMember_DoWork(object sender, DoWorkEventArgs e)
        {
            int totalRecords = 0;
            int take = LocalSettings.Instance.RecordsPerPage;
            int skip = 0;
            currentPageIndex = 1;
            List<MemberCustomerDTO> result = null;
            MemberFilter filter = e.Argument as MemberFilter;

            try
            {
                MemberChipList = OrganizationFactory.Instance.GetChannel().GetMemberList(storageService.CurrentSessionId, selectId, parenSelectId, filter);

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
                if (MemberChipList != null)
                {
                    result = MemberChipList.Skip(skip).Take(take).ToList();
                    totalRecords = MemberChipList.Count;
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
            List<MemberCustomerDTO> result = e.Result as List<MemberCustomerDTO>;
            if (cbxFilterByPersoStatusMember.Checked)
            {
                if (rbtnNotPerso.Checked)
                    LoadMemberDataGridView(result.Where(m => m.PersoCard == null).ToList());
                else
                    LoadMemberDataGridView(result.Where(m => m.PersoCard != null).ToList());
            }
            else
                LoadMemberDataGridView(result);

        }

        private void LoadMemberDataGridView(List<MemberCustomerDTO> result)
        {
            foreach (MemberCustomerDTO mc in result)
            {
                DataRow row = dtbMemberList.NewRow();
                row.BeginEdit();

                row[colMemberId.DataPropertyName] = mc.Member.Id;
                row[colMemberCode.DataPropertyName] = mc.Member.Code;
                row[colLastName.DataPropertyName] = mc.Member.LastName;
                row[colFirstName.DataPropertyName] = mc.Member.FirstName;
                row[colIdentityCard.DataPropertyName] = mc.Member.IdentityCard;
                row[colPermanentAddress.DataPropertyName] = mc.Member.PermanentAddress;
                row[colTemporaryAddress.DataPropertyName] = mc.Member.TemporaryAddress;
                row[colTitle.DataPropertyName] = mc.Member.Title;
                row[colIdentityCardDate.DataPropertyName] = mc.Member.IdentityCardIssueDate;
                row[colIdentityCardIssue.DataPropertyName] = mc.Member.IdentityCardIssue;
                row[colPhoneNo.DataPropertyName] = mc.Member.PhoneNo;
                row[colEmail.DataPropertyName] = mc.Member.Email;
                row[colTemporaryAddress.DataPropertyName] = mc.Member.TemporaryAddress;
                row[colActive.DataPropertyName] = mc.Member.Active ? string.Empty : LocalSettings.Instance.CheckSymbol;
                row[colPersoStatus.DataPropertyName] = mc.PersoCard == null ? string.Empty : LocalSettings.Instance.CheckSymbol;

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
            string checkPerso = string.Empty;
            if (rowsCount == 0)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessSelect(rm, MessageValidate.CardRequiredMem), MessageValidate.GetErrorTitle(rm));
                return;
            }

            // Get selected teachers
            List<Member> selectedMembers = new List<Member>();
            for (int i = 0; i < rowsCount; i++)
            {
                long id = Convert.ToInt64(selectedRows[i].Cells[colMemberId.Name].Value.ToString());
                checkPerso = selectedRows[i].Cells[colPersoStatus.Name].Value.ToString();
                if (string.IsNullOrEmpty(checkPerso))
                    selectedMembers.Add(MemberChipList.Find(t => t.Member.Id == id).Member);
            }

            if (selectedMembers.Count == 0)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "PersoIsMember"));
            }
            else
            {
                FrmPersoProcess dialog = new FrmPersoProcess(selectedMembers, false);
                workItem.SmartParts.Add(dialog);
                dialog.ShowDialog();

                workItem.SmartParts.Remove(dialog);
                dialog.Dispose();
                LoadMemberList();

            }

        }

        #endregion

        #region Group

        //private void LoadGroupSubOrg()
        //{
        //    GroupSubOrgList = new Dictionary<string, string>();
        //    String[] result = GroupSettings.Instance.Group.Split(',');

        //    foreach (String group in result)
        //    {
        //        string[] item = group.Split('-');
        //        if (item.Length > 0)
        //            GroupSubOrgList.Add(item.FirstOrDefault(), item.LastOrDefault());
        //    }
        //    GroupSubOrgList.GroupBy(g => g.Value);
        //}

        #endregion

        #endregion

        private void tbxMemberName_TextChanged(object sender, EventArgs e)
        {
            LoadMemberList();
        }

        private void tbxMemberCode_TextChanged(object sender, EventArgs e)
        {
            LoadMemberList();
        }
    }
}