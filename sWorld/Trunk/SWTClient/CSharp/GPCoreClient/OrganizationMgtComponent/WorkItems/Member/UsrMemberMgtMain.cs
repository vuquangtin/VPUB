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
using SystemMgtComponent.Constants;
using Microsoft.Practices.CompositeUI.Commands;
using CommonHelper.Constants;
using sWorldModel.Model;
using sWorldModel.Filters;
using JavaCommunication.Factory;
using CommonControls;
using sWorldModel.Exceptions;
using sWorldModel.TransportData;
using System.ServiceModel;
using JavaCommunication;
using SystemMgtComponent.WorkItems.IntegratingExcel;
using CommonHelper.Config;
using SystemMgtComponent.WorkItems;
using CommonControls.Custom;
using System.Resources;
using CommonHelper.Utils;


namespace SystemMgtComponent.WorkItems
{
    public partial class UsrMemberMgtMain : CommonUserControl
    {
        #region Properties


        // Height of filter box when it is hidden
        private int hiddenFilterBoxHeight = 0;
        // The original height of filter box (at startup)
        private int startupFilterBoxHeight = 88;

        private int currentPageIndex = 1;

        // Data table that contains user records
        private DataTable dtbMemberList;
        private List<MemberCustomerDTO> MemberList;
        private BackgroundWorker loadOrgWorker;
        private BackgroundWorker loadSubOrgWorker;
        private BackgroundWorker loadMemberWorker;
        private Dictionary<string, string> GroupSubOrgList;
        MemberFilter filter;
        private ResourceManager rm;

        private long OrgId;
        private long parenSelectId;
        private long selectId;
        //private MasterInfoDTO masterInfo;

        private SystemWorkItem workItem;
        [ServiceDependency]
        public SystemWorkItem WorkItem
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

        #endregion Properties

        #region Initialization

        public UsrMemberMgtMain()
        {
            InitializeComponent();
            InitOrganizationsGrid();
            RegisterEvents();
        }
        private void ChangeLanguages()
        {
            btnAddMember.ToolTipText = MessageValidate.GetMessage(rm, btnAddMember.Name);
            btnUpdateMember.ToolTipText = MessageValidate.GetMessage(rm, btnUpdateMember.Name);
            btnRemoveMember.ToolTipText = MessageValidate.GetMessage(rm, btnRemoveMember.Name);
            btnSyncData.ToolTipText = MessageValidate.GetMessage(rm, btnSyncData.Name);
            btnExportToExcel.ToolTipText = MessageValidate.GetMessage(rm, btnExportToExcel.Name);
            btnReloadMembers.ToolTipText = MessageValidate.GetMessage(rm, btnReloadMembers.Name);
            btnShowHide.ToolTipText = MessageValidate.GetMessage(rm, btnShowHide.Name);
            this.colMemberId.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colMemberId.Name);
            this.colMemberCode.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colMemberCode.Name);
            this.colTitle.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colTitle.Name);
            this.colIdentityCard.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colIdentityCard.Name);
            this.colFullName.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colFullName.Name);
            this.colIdentityCardDate.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colIdentityCardDate.Name);
            this.colPermanentAddress.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colPermanentAddress.Name);
            this.colTemporaryAddress.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colTemporaryAddress.Name);
            this.colPhoneNo.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colPhoneNo.Name);
            this.colPersoStatus.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colPersoStatus.Name);
            this.colActive.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colActive.Name);
            this.colIdentityCardIssue.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colIdentityCardIssue.Name);
            this.colEmail.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colEmail.Name);

        }

        private void RegisterEvents()
        {
            //Tree View
            //loadSubOrgWorker
            loadSubOrgWorker = new BackgroundWorker();
            loadSubOrgWorker.WorkerSupportsCancellation = true;
            loadSubOrgWorker.DoWork += OnLoadSubOrgWorkerDoWork;
            loadSubOrgWorker.RunWorkerCompleted += OnLoadSubOrgWorkerCompleted;
            //loadOrgWorker
            loadOrgWorker = new BackgroundWorker();
            loadOrgWorker.WorkerSupportsCancellation = true;
            loadOrgWorker.DoWork += OnLoadOrgWorkerDoWork;
            loadOrgWorker.RunWorkerCompleted += OnLoadOrgWorkerCompleted;

            //Load Member
            loadMemberWorker = new BackgroundWorker();
            loadMemberWorker.WorkerSupportsCancellation = true;
            loadMemberWorker.DoWork += OnLoadMemberWorkerDoWork;
            loadMemberWorker.RunWorkerCompleted += OnLoadMemberWorkerCompleted;
            //Show or hide filter
            btnShowHide.Click += btnShowHide_Click;

            //Import Member Data
            btnSyncData.Click += btnSyncMemberData_Clicked;

            //Add - Update - Deleted Member
            btnAddMember.Click += btnAddMember_Click;
            btnUpdateMember.Click += btnUpdateMember_Click;
            btnRemoveMember.Click += btnRemoveMember_Click;

            btnReloadMembers.Click += (s, e) => LoadMemberList();

            pagerPanel1.LinkLabelClicked += pagerPanel_LinkLabelClicked;

            Enter += (s, e) =>
            {
                if (MemberMgtMainShown != null)
                {
                    MemberMgtMainShown(this, EventArgs.Empty);
                }
            };

            // Assign startup value

            dgvMembers.SelectionChanged += dgvMembers_SelectionChanged;

            Load += OnFormLoad;
        }


        private void OnFormLoad(object sender, EventArgs e)
        {
            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
            ChangeLanguages();
            treeOrg.StorageService = storageService;
            treeOrg.AfterSelect += TreeOrgAfterSelect;
            treeOrg.InitializeData();
            pagerPanel1.StorageService = storageService;
            pagerPanel1.LoadLanguage();
            // ko biet de lam gi
            //try
            //{
            //    //this.masterInfo = OrganizationFactory.Instance.GetChannel().GetMasterInfo(StorageService.CurrentSessionId, SystemSettings.Instance.Partner);
            //}
            //catch (TimeoutException)
            //{
            //    MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "TimeOutExceptionMessage"));
            //}
            //catch (FaultException<WcfServiceFault> ex)
            //{
            //    MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
            //}
            //catch (FaultException ex)
            //{
            //    MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "FaultExceptionMessage")
            //            + Environment.NewLine + Environment.NewLine
            //            + ex.Message);
            //}
            //catch (CommunicationException)
            //{
            //    MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "CommunicationExceptionMessage"));
            //}
            //LoadGroupSubOrg();
        }

        #endregion Initialization
        #region Event after tree select
        private void TreeOrgAfterSelect(long orgId, long parentId, long selectedOrgId)
        {
            //gan 2 giá trị từ event hander
            this.OrgId = orgId;
            this.parenSelectId = parentId;
            this.selectId = selectedOrgId;
            //20170603 #Bug 747 Sửa lỗi ẩn hiện các button - Ten Nguyen Start
            if (parentId == -1 || orgId == -1 || selectedOrgId == -1)
            {
                InvisibleButton(false);
                //20170307 #Bug 833 Fix Quản lý - Thành viên_nhập thông tin - Minh Nguyen Start
                ClearControl();
                //20170307 #Bug 833 Fix Quản lý - Thành viên_nhập thông tin - Minh Nguyen End
            }
            else
            {
                InvisibleButton(true);
            }
            if (selectedOrgId != -1)
            {
                if (parentId == -1)
                {
                    LoadOrgById();
                }
                else
                {
                    LoadSubOrgById();
                }
            }
            //20170603 #Bug 747 Sửa lỗi ẩn hiện các button - Ten Nguyen End
            LoadMemberList();
        }
        #endregion
        #region Organization

        private void LoadOrgById()
        {
            if (!loadOrgWorker.IsBusy)
            {
                loadOrgWorker.RunWorkerAsync();
            }
        }
        private void LoadSubOrgById()
        {
            if (!loadSubOrgWorker.IsBusy)
            {
                loadSubOrgWorker.RunWorkerAsync();
            }
        }


        #endregion
        #region Load Org
        private void OnLoadOrgWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = OrganizationFactory.Instance.GetChannel().GetOrgById(StorageService.CurrentSessionId, OrgId);
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

        private void OnLoadOrgWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if (e.Result == null)
            {
                return;
            }
            ToOrgModel((Organization)e.Result);
        }
        #endregion
        #region Load SubOrg
        private void OnLoadSubOrgWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = OrganizationFactory.Instance.GetChannel().GetSubOrgById(StorageService.CurrentSessionId, selectId);
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

        private void OnLoadSubOrgWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if (e.Result == null)
            {
                return;
            }
            ToSubOrgModel((SubOrganization)e.Result);
        }
        #endregion
        #region Bind Data
        private void ToSubOrgModel(SubOrganization subOrg)
        {
            txtCode.Text = subOrg.orgcode;
            txtName.Text = subOrg.names;
            txtPhone.Text = subOrg.phone;
            txtEmail.Text = subOrg.email;

        }
        #endregion
        #region Bind Data
        private void ToOrgModel(Organization org)
        {
            txtCode.Text = org.OrgCode;
            txtName.Text = org.Name;
            txtPhone.Text = org.Phone;
            txtEmail.Text = org.Email;

        }
        #endregion
        #region CAB events

        [EventPublication(OrganizationEventTopicNames.MemberMgtMainShown)]
        public event EventHandler MemberMgtMainShown;

        [CommandHandler(OrganizationCommandNames.ShowMemberMgtMain)]
        public void ShowOrgMgtMainHandler(object s, EventArgs e)
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
            uc.Parent.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuMemberManager);
        }

        #endregion CAB events

        #region Form events

        private void cbxFilterByMemberName_CheckedChanged(object sender, EventArgs e)
        {
            tbxMemberName.Enabled = cbxFilterByMemberName.Checked;
        }

        private void cbxFilterByMemberCode_CheckedChanged(object sender, EventArgs e)
        {
            tbxMemberCode.Enabled = cbxFilterByMemberCode.Checked;
        }

        private void btnShowHide_Click(object sender, EventArgs e)
        {
            if (pnlFilterBox.Height == hiddenFilterBoxHeight)
            {
                pnlFilterBox.Height = startupFilterBoxHeight;
                pnlFilterBox.Height = startupFilterBoxHeight;
                btnShowHide.Text = btnShowHide.ToolTipText = MessageValidate.GetMessage(rm, MessageValidate.ShowTextSearch);
                btnShowHide.ToolTipText = MessageValidate.GetMessage(rm, MessageValidate.HideTextSearch);
                btnShowHide.Image = global::CommonControls.Properties.Resources.ArrowUp_16x16;
            }
            else
            {
                pnlFilterBox.Height = hiddenFilterBoxHeight;
                btnShowHide.Text = btnShowHide.ToolTipText = MessageValidate.GetMessage(rm, MessageValidate.ShowTextSearch);
                btnShowHide.ToolTipText = MessageValidate.GetMessage(rm, MessageValidate.HideTextSearch);
                btnShowHide.Image = global::CommonControls.Properties.Resources.ArrowDown_16x16;
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
            dtbMemberList.Rows.Clear();
            int take = LocalSettings.Instance.RecordsPerPage;
            int skip = (currentPageIndex - 1) * take;

            List<MemberCustomerDTO> result = MemberList.Skip(skip).Take(take).ToList();
            LoadMemberDataGridView(result);

            pagerPanel1.ShowNumberOfRecords(MemberList.Count, result != null ? result.Count : 0, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
            pagerPanel1.UpdatePagingLinks(MemberList.Count, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
        }

        private MemberFilter GetMemberFilter()
        {
            MemberFilter filter = new MemberFilter();
            //20170703 #Bug 675 lỗi này khi người dùng không nhập dữ liệu search - Ten Nguyen Start                    
            if (cbxFilterByMemberName.Checked)
            {
                string dataSearchName = FormatCharacterSearch.CheckValue(tbxMemberName.Text.Trim());
                if (dataSearchName.Length < 2)
                {
                    Invoke(new Action(() => { lblentermorthan2letter.Visible = true; }));
                    //return null;
                }
                else
                {
                    Invoke(new Action(() => { lblentermorthan2letter.Visible = false; }));
                }
                filter.FilterByMemberName = true;
                filter.MemberName = tbxMemberName.Text;
            }
            if (cbxFilterByMemberCode.Checked)
            {
                string dataSearchCode = FormatCharacterSearch.CheckValue(tbxMemberCode.Text.Trim());
                if (dataSearchCode.Length < 2)
                {
                    Invoke(new Action(() => { lblNotification22.Visible = true; }));
                    //20170703 #Bug 675 lỗi này khi người dùng không nhập dữ liệu search - Ten Nguyen Start                    
                    //return null;
                    //20170703 #Bug 675 lỗi này khi người dùng không nhập dữ liệu search - Ten Nguyen End
                }
                else
                {
                    Invoke(new Action(() => { lblNotification22.Visible = false; }));
                }
                filter.FilterByCode = true;
                filter.Code = tbxMemberCode.Text;
            }
            //20170703 #Bug 675 lỗi này khi người dùng không nhập dữ liệu search - Ten Nguyen End
            return filter;
        }


        #region Member

        private void dgvMembers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMembers.CurrentRow != null)
                ShowOrHideButtonMemberAction(string.IsNullOrEmpty(dgvMembers.CurrentRow.Cells[colActive.Index].Value.ToString()));
        }

        private void OnLoadMemberWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            int totalRecords = 0;
            int take = LocalSettings.Instance.RecordsPerPage;
            int skip = 0;
            currentPageIndex = 1;
            List<MemberCustomerDTO> result = null;
            try
            {
                MemberList = OrganizationFactory.Instance.GetChannel().GetMemberList(storageService.CurrentSessionId, selectId, parenSelectId, filter);
            }
            catch (TimeoutException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "TimeOutExceptionMessage"));
                MemberList = null;
            }
            catch (FaultException<WcfServiceFault> ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
                MemberList = null;
            }
            catch (FaultException ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "FaultExceptionMessage")
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
                MemberList = null;
            }
            catch (CommunicationException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "CommunicationExceptionMessage"));
                MemberList = null;
            }
            finally
            {
                if (MemberList != null)
                {
                    result = MemberList.Skip(skip).Take(take).ToList();
                    totalRecords = MemberList.Count;
                    pagerPanel1.ShowNumberOfRecords(totalRecords, result != null ? result.Count : 0, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
                    pagerPanel1.UpdatePagingLinks(totalRecords, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
                }
                e.Result = result;
            }
        }

        private void OnLoadMemberWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if (e.Result == null)
            {
                return;
            }
            List<MemberCustomerDTO> result = (List<MemberCustomerDTO>)e.Result;
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
                row[colFullName.DataPropertyName] = mc.Member.GetFullName();
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

        //[CommandHandler(MemberCommandNames.SyncMemberData)]
        public void btnSyncMemberData_Clicked(object sender, EventArgs e)
        {
            FrmConnectionConfig frmConnConfig = new FrmConnectionConfig(OrgId, selectId, rm);
            frmConnConfig.ShowDialog();

            if (frmConnConfig.DialogResult == DialogResult.OK)
            {
                FrmReadExcelData frmReadData = new FrmReadExcelData();
                workItem.SmartParts.Add(frmReadData);
                frmReadData.FilePath = frmConnConfig.FilePath;

                frmReadData.OrgId = frmConnConfig.OrgId;
                frmReadData.SubOrgId = frmConnConfig.SubOrgId;
                frmReadData.ColCodeIndex = frmConnConfig.CodeIndex;

                frmReadData.Title = frmConnConfig.Title;

                frmReadData.ColFirstNameIndex = frmConnConfig.FirstNameIndex;
                frmReadData.ColLastNameIndex = frmConnConfig.LastNameIndex;
                frmReadData.ColBirthDateIndex = frmConnConfig.BirthDateIndex;
                frmReadData.ColGenderIndex = frmConnConfig.GenderIndex;
                frmReadData.ColCompanynameIndex = frmConnConfig.CompanyNameIndex;
                frmReadData.ColDegreeIndex = frmConnConfig.DegreeIndex;
                frmReadData.ColPositionIndex = frmConnConfig.PositionIndex;
                frmReadData.ColPermanentAddressIndex = frmConnConfig.PermanentAddressIndex;
                frmReadData.ColTemporaryAddressIndex = frmConnConfig.TemporaryAddressIndex;
                frmReadData.ColPhoneNoIndex = frmConnConfig.PhoneNoIndex;
                frmReadData.ColEmailIndex = frmConnConfig.EmailIndex;
                frmReadData.ColNationalityIndex = frmConnConfig.NationalityIndex;

                frmReadData.ColIdentityCardIndex = frmConnConfig.IdentityCardIndex;
                frmReadData.ColIdentityCardDateIndex = frmConnConfig.IdentityCardDateIndex;
                frmReadData.ColIdentityCardIssueIndex = frmConnConfig.IdentityCardIssueIndex;


                frmReadData.FirstRowIndex = frmConnConfig.FirstRowIndex;
                frmReadData.rm = rm;
                frmReadData.ShowDialog();

                frmReadData.Dispose();
                workItem.SmartParts.Remove(frmReadData);
            }

            frmConnConfig.Dispose();
            workItem.SmartParts.Remove(frmConnConfig);

            LoadMemberList();

        }

        private void btnAddMember_Click(object sender, EventArgs e)
        {
            FrmAddOrUpdateMember dialog = new FrmAddOrUpdateMember(FrmAddOrUpdateMember.ModeAdding, OrgId, selectId);
            workItem.SmartParts.Add(dialog);
            dialog.ShowDialog();
            workItem.SmartParts.Remove(dialog);
            dialog.Dispose();
            //20170403 #Bug 683 Fix lưu xong không load lại dữ liệu- Thêm hàm này -Ten Nguyen Start
            LoadMemberList();
            //20170403 #Bug 683 Fix lưu xong không load lại dữ liệu -Ten Nguyen End
        }
        /// <summary>
        /// visible and invisible button
        /// </summary>
        /// <param name="visible"></param>
        /// //20170603 #Bug 747 Sửa lỗi ẩn hiện các button - Ten Nguyen Start
        private void InvisibleButton(bool enabled)
        {
            btnAddMember.Enabled = enabled;
            btnUpdateMember.Enabled = enabled;
            btnRemoveMember.Enabled = enabled;
            btnSyncData.Enabled = enabled;
            btnExportToExcel.Enabled = enabled;
            btnReloadMembers.Enabled = enabled;
            btnShowHide.Enabled = enabled;
            //20170603 #Bug 747 Sửa lỗi ẩn hiện các button - Ten Nguyen End
        }

        //20170307 #Bug 833 Fix Quản lý - Thành viên_nhập thông tin - Minh Nguyen Start
        private void ClearControl()
        {
            cbxFilterByMemberName.Checked = false;
            cbxFilterByMemberCode.Checked = false;
            tbxMemberName.Text = String.Empty;
            tbxMemberCode.Text = String.Empty;
            txtCode.Text = String.Empty;
            txtPhone.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtName.Text = String.Empty;
        }
        //20170307 #Bug 833 Fix Quản lý - Thành viên_nhập thông tin - Minh Nguyen End

        private void btnUpdateMember_Click(object sender, EventArgs e)
        {
            if (dgvMembers.SelectedRows.Count == 0)
            {
                return;
            }
            long memberId = Convert.ToInt64(dgvMembers.SelectedRows[0].Cells[0].Value.ToString());

            FrmAddOrUpdateMember dialog = new FrmAddOrUpdateMember(FrmAddOrUpdateMember.ModeUpdating, OrgId, selectId, memberId);
            // Show GroupDetail dialog and delegate this task to it
            workItem.SmartParts.Add(dialog);
            dialog.ShowDialog();
            workItem.SmartParts.Remove(dialog);
            dialog.Dispose();
            LoadMemberList();
        }

        private void btnRemoveMember_Click(object sender, EventArgs e)
        {
            bool result;
            if (dgvMembers.SelectedRows.Count == 0)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessSelect(rm, MessageValidate.CancelMem), MessageValidate.GetErrorTitle(rm));
                return;
            }

            //Show confirmation message box
            if (MessageBoxManager.ShowQuestionMessageBox(this, MessageValidate.GetMessageRemove(rm, MessageValidate.Member)) == DialogResult.Yes)
            {
                try
                {
                    result = (int)Status.SUCCESS == OrganizationFactory.Instance.GetChannel().RemoveMember(StorageService.CurrentSessionId, Convert.ToInt64(dgvMembers.SelectedRows[0].Cells[0].Value.ToString()));
                }
                catch (TimeoutException)
                {
                    MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "TimeOutExceptionMessage"));
                    return;
                }
                catch (FaultException<WcfServiceFault> ex)
                {
                    MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
                    return;
                }
                catch (FaultException ex)
                {
                    MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "FaultExceptionMessage")
                            + Environment.NewLine + Environment.NewLine
                            + ex.Message);
                    return;
                }
                catch (CommunicationException)
                {
                    MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "CommunicationExceptionMessage"));
                    return;
                }
                // Check return result
                if (result)
                {
                    LoadMemberList();
                }
                else
                {
                    MessageBoxManager.ShowErrorMessageBox(this, ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MessageValidate.MemCancelFail));
                }
            }
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            string filePath = ControlExtMethods.ShowSaveFileDialog(MessageValidate.GetMessage(rm, "smsChooseFileExport"), "DanhSachThanhVien", "MS Excel (*.xls)|*.xls");
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
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "smsLinkFile") + filePath);
            }
        }

        #endregion

        #endregion

        #region Event's support

        #region Organization

        #endregion

        #region Member

        private void InitOrganizationsGrid()
        {
            dtbMemberList = new DataTable();
            dtbMemberList.Columns.Add(colMemberId.DataPropertyName);
            dtbMemberList.Columns.Add(colMemberCode.DataPropertyName);
            dtbMemberList.Columns.Add(colFullName.DataPropertyName);
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

        private void LoadMemberList()
        {
            if (!loadMemberWorker.IsBusy)
            {
                dtbMemberList.Rows.Clear();
                MemberList = null;
                filter = GetMemberFilter();
                //pagerPanel1.ShowMessage("Đang tải dữ liệu, xin hãy chờ...");
                pagerPanel1.ShowMessage(MessageValidate.GetMessage(rm, "waitLoadData"));
                loadMemberWorker.RunWorkerAsync();
            }
        }

        private void ShowOrHideButtonMemberAction(bool isShow)
        {
            if (parenSelectId == -1 && OrgId == -1)
            {
                btnUpdateMember.Enabled = btnRemoveMember.Enabled = isShow;
            }
        }

        #endregion

        //#region Group

        //private void LoadGroupSubOrg()
        //{
        //    GroupSubOrgList = new Dictionary<string, string>();
        //    String[] result = MemberTitle.Instance.Values.Split(',');

        //    foreach (String group in result)
        //    {
        //        string[] item = group.Split('-');
        //        if (item.Length > 0)
        //            GroupSubOrgList.Add(item.FirstOrDefault(), item.LastOrDefault());
        //    }
        //    GroupSubOrgList.GroupBy(g => g.Value);
        //}


        //#endregion

        #endregion
        /// <summary>
        /// Chuyển thành search auto cho các text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxMemberName_TextChanged(object sender, EventArgs e)
        {
            LoadMemberList();
        }
        /// <summary>
        ///  Chuyển thành search auto cho các text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxMemberCode_TextChanged(object sender, EventArgs e)
        {
            LoadMemberList();
        }
    }
}