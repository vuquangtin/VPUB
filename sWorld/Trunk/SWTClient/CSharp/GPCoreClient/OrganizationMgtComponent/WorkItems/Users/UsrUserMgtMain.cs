﻿using CommonControls;
using CommonControls.Custom;
using CommonHelper.Config;
using CommonHelper.Constants;
using sWorldModel;
using sWorldModel.Exceptions;
using sWorldModel.Filters;
using sWorldModel.Model;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.Commands;
using Microsoft.Practices.CompositeUI.EventBroker;
using System.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.ServiceModel;
using System.Windows.Forms;
using SystemMgtComponent.Constants;
using SystemMgtComponent.WorkItems.UserAdding;
using JavaCommunication.Factory;
using sWorldModel.TransportData;
using SystemMgtComponent.WorkItems;
using System.Resources;
using CommonHelper.Utils;

namespace SystemMgtComponent.WorkItems.Users
{
    public partial class UsrUserMgtMain : CommonUserControl
    {
        #region Properties

        // Height of filter box when it is hidden
        private int hiddenFilterBoxHeight = 1;
        // The original height of filter box (at startup)
        private int startupFilterBoxHeight;

        private int currentPageIndex = 1;

        // Data table that contains user records
        private DataTable dtbUserList;
        private BackgroundWorker bgwLoadUser;
        private BackgroundWorker bgwLoadGroup;
        private List<UserSworld> UserList;
        private ResourceManager rm;

        // The original font of tree nodes
        private Font startupNodeFont;
        // Selected tree node; cache it to do some effect in UI
        private TreeNode selectedGroupNode;
        private TreeNode rootNode;

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

        public UsrUserMgtMain()
        {
            InitializeComponent();

            dtbUserList = new DataTable();
            dtbUserList.Columns.Add(colUserId.DataPropertyName);
            dtbUserList.Columns.Add(colUserName.DataPropertyName);
            dtbUserList.Columns.Add(colFullName.DataPropertyName);
            dtbUserList.Columns.Add(colGroupId.DataPropertyName);
            dtbUserList.Columns.Add(colGroupName.DataPropertyName);
            dtbUserList.Columns.Add(colSttLocked.DataPropertyName);
            dtbUserList.Columns.Add(colSttCanceled.DataPropertyName);
            dtbUserList.Columns.Add(colIsMember.DataPropertyName);
            dgvUserList.DataSource = dtbUserList;

            bgwLoadUser = new BackgroundWorker();
            bgwLoadUser.WorkerSupportsCancellation = true;
            bgwLoadUser.DoWork += bgwLoadUser_DoWork;
            bgwLoadUser.RunWorkerCompleted += bgwLoadUser_Completed;

            bgwLoadGroup = new BackgroundWorker();
            bgwLoadGroup.WorkerSupportsCancellation = true;
            bgwLoadGroup.DoWork += bgwLoadGroup_DoWork;
            bgwLoadGroup.RunWorkerCompleted += bgwLoadGroup_Completed;



            RegisterEvents();
        }

        /// <summary>
        /// Register events. This method is called by class constructor.
        /// </summary>
        private void RegisterEvents()
        {
            pagerPanel1.LinkLabelClicked += pagerPanel_LinkLabelClicked;

            trvGroupList.BeforeSelect += trvGroups_BeforeSelect;
            trvGroupList.AfterSelect += trvGroups_AfterSelect;

            btnShowHideFilter.Click += btnShowHide_Clicked;

            cbxFilterByUserStatus.CheckedChanged += cbxFilterByUserStatus_CheckedChanged;
            cbxShowInactiveUsers.CheckedChanged += cbxShowInactiveUsers_CheckedChanged;

            btnReloadGroupsAccount.Click += (s, e) => LoadGroupList();
            mniReloadGroups.Click += (s, e) => LoadGroupList();
            btnReloadUsers.Click += (s, e) => LoadUserList();
            mniReloadUsers.Click += (s, e) => LoadUserList();

            dgvUserList.MouseDown += dgvUsers_MouseDown;
            trvGroupList.MouseDown += trvGroups_MouseDown;

            Enter += (s, e) =>
                {
                    if (UserListShown != null)
                    {
                        UserListShown(this, EventArgs.Empty);
                    }
                };
            Leave += (s, e) =>
                {
                    if (UserListHide != null)
                    {
                        UserListHide(this, EventArgs.Empty);
                    }
                };
            Load += OnFormLoad;
        }

        private void OnFormLoad(object sender, EventArgs e)
        {


            // Assign value
            startupNodeFont = trvGroupList.Font;
            startupFilterBoxHeight = pnlFilterBox.Height;

            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
            SetLanguages();
            pagerPanel1.StorageService = storageService;
            pagerPanel1.LoadLanguage();
            InitTreeList();
            // Load list of group when form loaded
            LoadGroupList();
            //init table and tooltip languages

        }

        private void InitTreeList()
        {
            rootNode = new TreeNode();
            rootNode.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, "All");
            rootNode.Name = "-1";
            trvGroupList.Nodes.Add(rootNode);
        }
        private void SetLanguages()
        {
            this.colUserName.HeaderText = MessageValidate.GetMessage(rm, this.colUserName.Name);
            this.colFullName.HeaderText = MessageValidate.GetMessage(rm, this.colFullName.Name);
            this.colGroupId.HeaderText = MessageValidate.GetMessage(rm, this.colGroupId.Name);
            this.colGroupName.HeaderText = MessageValidate.GetMessage(rm, this.colGroupName.Name);
            this.colIsMember.HeaderText = MessageValidate.GetMessage(rm, this.colIsMember.Name);
            this.colSttCanceled.HeaderText = MessageValidate.GetMessage(rm, this.colSttCanceled.Name);
            this.colSttLocked.HeaderText = MessageValidate.GetMessage(rm, this.colSttLocked.Name);

            //for tooltip text
            this.btnAddGroupAccount.ToolTipText = MessageValidate.GetMessage(rm, this.btnAddGroupAccount.Name);
            this.btnUpdateGroupAccount.ToolTipText = MessageValidate.GetMessage(rm, this.btnUpdateGroupAccount.Name);
            this.btnRemoveGroupAccount.ToolTipText = MessageValidate.GetMessage(rm, this.btnRemoveGroupAccount.Name);
            this.btnReloadGroupsAccount.ToolTipText = MessageValidate.GetMessage(rm, this.btnReloadGroupsAccount.Name);
            this.btnAddUserAccount.ToolTipText = MessageValidate.GetMessage(rm, this.btnAddUserAccount.Name);
            this.btnUpdateUserAccount.ToolTipText = MessageValidate.GetMessage(rm, this.btnUpdateUserAccount.Name);
            this.btnChangeGroup.ToolTipText = MessageValidate.GetMessage(rm, this.btnChangeGroup.Name);
            this.btnResetPassword.ToolTipText = MessageValidate.GetMessage(rm, this.btnResetPassword.Name);
            this.btnLockUser.ToolTipText = MessageValidate.GetMessage(rm, this.btnLockUser.Name);
            this.btnUnLockUser.ToolTipText = MessageValidate.GetMessage(rm, this.btnUnLockUser.Name);
            this.btnRemoveUser.ToolTipText = MessageValidate.GetMessage(rm, this.btnRemoveUser.Name);
            this.btnExportToExcel.ToolTipText = MessageValidate.GetMessage(rm, this.btnExportToExcel.Name);
            this.btnReloadUsers.ToolTipText = MessageValidate.GetMessage(rm, this.btnReloadUsers.Name);
        }
        #endregion Initialization
        public void InvisibleButton(bool visible)
        {
            btnAddGroupAccount.Enabled = visible;
            btnUpdateGroupAccount.Enabled = visible;
            btnRemoveGroupAccount.Enabled = visible;
            btnReloadGroupsAccount.Enabled = visible;
            btnAddUserAccount.Enabled = visible;
            btnUpdateUserAccount.Enabled = visible;
            btnChangeGroup.Enabled = visible;
            btnResetPassword.Enabled = visible;
            btnLockUser.Enabled = visible;
            btnUnLockUser.Enabled = visible;
            btnRemoveUser.Enabled = visible;
            btnExportToExcel.Enabled = visible;
            btnReloadUsers.Enabled = visible;
        }
        #region Functions for group

        private void LoadGroupList()
        {
            // Call background worker if it's not busy
            if (!bgwLoadGroup.IsBusy)
            {
                // Clear current data
                selectedGroupNode = null;
                dtbUserList.Rows.Clear();
                rootNode.Nodes.Clear();
                bgwLoadGroup.RunWorkerAsync();
            }
        }

        private void bgwLoadGroup_DoWork(object sender, DoWorkEventArgs e)
        {
            List<GroupDto> result = null;
            GroupFilterDto filter = new GroupFilterDto();

            try
            {
                result = ManagerSystemFactory.Instance.GetChannel().GetGroupList(StorageService.CurrentSessionId, filter);
            }
            catch (TimeoutException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, "TimeOutExceptionMessage"));
            }
            catch (FaultException<WcfServiceFault> ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
            }
            catch (FaultException ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, "FaultExceptionMessage")
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
            }
            catch (CommunicationException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, "CommunicationExceptionMessage"));
            }
            finally
            {
                e.Result = result;
            }
        }

        private void bgwLoadGroup_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }

            // Get result from DoWork method
            List<GroupDto> result = (List<GroupDto>)e.Result;
            if (result != null)
            {
                foreach (GroupDto r in result)
                {
                    if (r.isAdmin != 1)
                    {
                        TreeNode groupNode = new TreeNode();
                        groupNode.Text = r.Name;
                        groupNode.Name = Convert.ToString(r.Id);
                        rootNode.Nodes.Add(groupNode);
                    }
                }
                trvGroupList.Sort();
                rootNode.Expand();
            }
        }

        [CommandHandler(UserCommandNames.AddGroup)]
        public void btnAddGroup_Clicked(object sender, EventArgs e)
        {
            // Show GroupDetail dialog and delegate this task to it
            FrmGroupDetail dialog = new FrmGroupDetail(FrmGroupDetail.ModeAdding, -1);
            workItem.SmartParts.Add(dialog);
            dialog.ShowDialog();
            workItem.SmartParts.Remove(dialog);
            dialog.Dispose();
            LoadGroupList();
        }

        [CommandHandler(UserCommandNames.UpdateGroup)]
        public void btnUpdateGroup_Clicked(object sender, EventArgs e)
        {
            // Get selected group node
            TreeNode selectedNode = trvGroupList.SelectedNode;
            if (selectedNode == null)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessSelect(rm, MessageValidate.UpdateGroup), MessageValidate.GetErrorTitle(rm));
                return;
            }

            // Show GroupDetail dialog and delegate this task to it
            FrmGroupDetail dialog = new FrmGroupDetail(FrmGroupDetail.ModeUpdating, Convert.ToInt64(selectedNode.Name));
            workItem.SmartParts.Add(dialog);
            dialog.ShowDialog();

            // If task completed successfully and group's name has been changed -> update tree view
            GroupCustomerDto updatedGroup = dialog.AddedOrEditedGroup;
            if (dialog.PostAction == DialogPostAction.SUCCESS)
            {
                if (updatedGroup.Name != null && !updatedGroup.Name.Equals(selectedNode.Text))
                {
                    selectedNode.Text = updatedGroup.Name;
                    trvGroupList.Sort();

                    // After sort method, attribute SelectedNode of TreeView will be null
                    trvGroupList.SelectedNode = selectedGroupNode;
                }
            }

            workItem.SmartParts.Remove(dialog);
            dialog.Dispose();
            LoadGroupList();
        }

        [CommandHandler(UserCommandNames.RemoveGroup)]
        public void btnRemoveGroup_Clicked(object sender, EventArgs e)
        {
            // Get selected group node
            TreeNode selectedNode = trvGroupList.SelectedNode;
            if (selectedNode == null)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessSelect(rm, MessageValidate.CancelGroup), MessageValidate.GetErrorTitle(rm));
                return;
            }
            string message = string.Empty;
            if (UserList.Count == 0)
                message = MessageValidate.GetMessageRemove(rm, "GroupAcc");
            else
                message = MessageValidate.GetMessageRemove(rm, "GroupAccAndAcc");

            //Show confirmation message box
            if (MessageBoxManager.ShowQuestionMessageBox(this, message) == DialogResult.Yes)
            {
                long groupId = Convert.ToInt64(selectedNode.Name);
                List<MethodResultDto> result = null;

                try
                {
                    result = ManagerSystemFactory.Instance.GetChannel().RemoveGroups(StorageService.CurrentSessionId, groupId);
                }
                catch (TimeoutException)
                {
                    MessageBoxManager.ShowErrorMessageBox(this, ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, "TimeOutExceptionMessage"));
                    return;
                }
                catch (FaultException<WcfServiceFault> ex)
                {
                    MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
                    return;
                }
                catch (FaultException ex)
                {
                    MessageBoxManager.ShowErrorMessageBox(this, ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, "FaultExceptionMessage")
                            + Environment.NewLine + Environment.NewLine
                            + ex.Message);
                    return;
                }
                catch (CommunicationException)
                {
                    MessageBoxManager.ShowErrorMessageBox(this, ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, "CommunicationExceptionMessage"));
                    return;
                }
                // Check return result
                if (result != null && result.Count > 0)
                {
                    MethodResultDto r = result[0];
                    if (r.Result)
                    {
                        trvGroupList.Nodes.Remove(selectedNode);
                    }
                    else
                    {
                        MessageBoxManager.ShowErrorMessageBox(this, r.Subject + " | " + r.Detail);
                    }
                }
            }
        }

        #endregion

        #region Function for user

        private void LoadUserList()
        {
            if (selectedGroupNode == null)
            {
                return;
            }
            if (!bgwLoadUser.IsBusy)
            {
                // Create user filter base on the selected group node and the state of radio buttons
                UserFilterDto userFilter = new UserFilterDto();

                userFilter.FilterByGroupId = true;
                userFilter.GroupId = Convert.ToInt64(selectedGroupNode.Name);

                if (cbxFilterByUserStatus.Checked)
                {
                    userFilter.FilterByUserStatus = true;
                    if (rbtnStatusNormal.Checked)
                    {
                        userFilter.UserStatus = (int)UserStatus.NORMAL;
                    }
                    else if (rbtnStatusLocked.Checked)
                    {
                        userFilter.UserStatus = (int)UserStatus.LOCKED;
                    }
                    else if (rbtnStatusCanceled.Checked)
                    {
                        userFilter.UserStatus = (int)UserStatus.CANCELED;
                    }
                    else
                    {
                        userFilter.FilterByUserStatus = false;
                    }
                }

                // Clear current data
                dtbUserList.Rows.Clear();

                // Call background worker
                pagerPanel1.ShowMessage(MessageValidate.GetMessage(rm, "lblLoading"));
                bgwLoadUser.RunWorkerAsync(userFilter);
            }
        }

        private void bgwLoadUser_DoWork(object s, DoWorkEventArgs e)
        {
            if (e.Argument == null || !(e.Argument is UserFilterDto))
            {
                return;
            }

            UserFilterDto filter = e.Argument as UserFilterDto;
            List<UserSworld> result = null;
            int totalRecords = 0;
            int take = LocalSettings.Instance.RecordsPerPage;
            int skip = 0;
            currentPageIndex = 1;

            try
            {
                UserList = ManagerSystemFactory.Instance.GetChannel().GetUserList(StorageService.CurrentSessionId, filter);

            }
            catch (TimeoutException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, "TimeOutExceptionMessage"));
            }
            catch (FaultException<WcfServiceFault> ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
            }
            catch (FaultException ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, "FaultExceptionMessage")
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
            }
            catch (CommunicationException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, "CommunicationExceptionMessage"));
            }
            finally
            {
                if (UserList != null)
                {
                    result = UserList.Skip(skip).Take(take).ToList();
                    totalRecords = UserList.Count;
                    pagerPanel1.ShowNumberOfRecords(totalRecords, result != null ? result.Count : 0, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
                    pagerPanel1.UpdatePagingLinks(totalRecords, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
                }

                e.Result = result;
            }
        }

        private void bgwLoadUser_Completed(object s, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if (e.Result == null)
            {
                return;
            }
            List<UserSworld> result = (List<UserSworld>)e.Result;
            LoadUserDataGridView(result);
            cbxShowInactiveUsers_CheckedChanged(this, EventArgs.Empty);
        }

        private void LoadUserDataGridView(List<UserSworld> result)
        {
            foreach (UserSworld r in result)
            {
                DataRow row = dtbUserList.NewRow();
                row.BeginEdit();

                row[colUserId.DataPropertyName] = r.id;
                row[colUserName.DataPropertyName] = r.UserName;
                row[colFullName.DataPropertyName] = r.GetFullName();
                row[colGroupId.DataPropertyName] = r.GroupId;
                //row[colGroupName.DataPropertyName] = r.GroupName;
                //row[colIsTeacher.DataPropertyName] = r.IsTeacher ? LocalSettings.Instance.CheckSymbol : string.Empty;

                switch (r.Status)
                {
                    case (int)UserStatus.LOCKED:
                        row[colSttLocked.DataPropertyName] = LocalSettings.Instance.CheckSymbol;
                        break;
                    case (int)UserStatus.CANCELED:
                        row[colSttCanceled.DataPropertyName] = LocalSettings.Instance.CheckSymbol;
                        break;
                    default:
                        break;
                }

                row.EndEdit();
                dtbUserList.Rows.Add(row);
            }
        }

        [CommandHandler(UserCommandNames.AddUser)]
        public void btnAddUser_Clicked(object sender, EventArgs e)
        {
            // Re-create group list from tree nodes. This list will be shown
            // in group combobox of AddUser dialog. By doing this, we'll not
            // have to re-call //WcfServiceClient<IGPCoreService>.GetChannel() to get group data.
            List<GroupDto> groups = new List<GroupDto>();
            foreach (TreeNode node in trvGroupList.Nodes)
            {
                groups.Add(new GroupDto
                {
                    Id = Convert.ToInt64(node.Name),
                    Name = node.Text,
                });
            }

            // Show AddUser dialog and delegate this task to it
            FrmAddAccount dlg  =new FrmAddAccount(Convert.ToInt64(selectedGroupNode.Name));
            workItem.SmartParts.Add(dlg);
            dlg.ShowDialog();

            workItem.Items.Remove(dlg);
            dlg.Dispose();
            LoadUserList();
        }

        [CommandHandler(UserCommandNames.UpdateUser)]
        public void btnUpdateUser_Clicked(object sender, EventArgs e)
        {
            var selectedRows = dgvUserList.SelectedRows;
            int rowsCount = selectedRows.Count;

            if (rowsCount == 0)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessSelect(rm, MessageValidate.UpdateAcc), MessageValidate.GetErrorTitle(rm));
                return;
            }
            if (rowsCount > 1)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessProgram(rm, MessageValidate.UpdateProfile), MessageValidate.GetErrorTitle(rm));
                return;
            }

            FrmUpdatePersonalInfo dlg = workItem.Items.AddNew<FrmUpdatePersonalInfo>();
            long userId = Convert.ToInt64(selectedRows[0].Cells[colUserId.Name].Value);
            dlg.UserId = userId;
            dlg.ShowDialog();

            if (dlg.PostAction == DialogPostAction.SUCCESS)
            {
                string newFullName = dlg.UpdatedUser.GetFullName();
                for (int i = 0; i < dtbUserList.Rows.Count; i++)
                {
                    DataRow row = dtbUserList.Rows[i];
                    if (Convert.ToInt64(row[colUserId.DataPropertyName]) == userId)
                    {
                        row[colFullName.DataPropertyName] = newFullName;
                        break;
                    }
                }
            }

            workItem.Items.Remove(dlg);
            dlg.Dispose();
            LoadUserList();
        }

        [CommandHandler(UserCommandNames.ChangeGroup)]
        public void btnChangeGroup_Clicked(object sender, EventArgs e)
        {
            var selectedRows = dgvUserList.SelectedRows;
            int rowsCount = selectedRows.Count;
            if (rowsCount == 0)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessSelect(rm, MessageValidate.ChangeGroupAcc), MessageValidate.GetErrorTitle(rm));
                return;
            }
            if (rowsCount > 1)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessProgram(rm, MessageValidate.ChangeGroup), MessageValidate.GetErrorTitle(rm));
                return;
            }

            long userId = Convert.ToInt64(selectedRows[0].Cells[colUserId.Name].Value);
            List<GroupDto> groups = new List<GroupDto>();
            foreach (TreeNode node in rootNode.Nodes)
            {
                if (node == selectedGroupNode)
                    continue;
                groups.Add(new GroupDto
                {
                    Id = Convert.ToInt64(node.Name),
                    Name = node.Text,
                });
            }

            FrmChangeUserGroup dlg = new FrmChangeUserGroup(userId, groups);
            workItem.SmartParts.Add(dlg);
            dlg.ShowDialog();

            if (dlg.PostAction == DialogPostAction.SUCCESS && selectedGroupNode != null)
            {
                if (dlg.SelectedGroupId != Convert.ToInt64(selectedGroupNode.Name))
                {
                    for (int i = 0; i < dtbUserList.Rows.Count; i++)
                    {
                        DataRow row = dtbUserList.Rows[i];
                        if (Convert.ToInt64(row[colUserId.DataPropertyName].ToString()) == userId)
                        {
                            row.Delete();
                            break;
                        }
                    }
                }
            }

            workItem.SmartParts.Remove(dlg);
            dlg.Dispose();
        }

        [CommandHandler(UserCommandNames.ResetPassword)]
        public void btnResetPassword_Clicked(object sender, EventArgs e)
        {
            var selectedRows = dgvUserList.SelectedRows;
            int rowsCount = selectedRows.Count;
            if (rowsCount == 0)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessSelect(rm, MessageValidate.ChangePassAcc), MessageValidate.GetErrorTitle(rm));
                return;
            }
            if (rowsCount > 1)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessFunction(rm, MessageValidate.AccActionSupport), MessageValidate.GetErrorTitle(rm));
                return;
            }

            FrmResetPassword dlg = workItem.Items.AddNew<FrmResetPassword>();
            dlg.UserId = Convert.ToInt64(selectedRows[0].Cells[colUserId.Name].Value);
            dlg.ShowDialog();
            workItem.Items.Remove(dlg);
            dlg.Dispose();
        }

        [CommandHandler(UserCommandNames.LockUser)]
        public void btnLockUser_Clicked(object sender, EventArgs e)
        {
            var selectedRows = dgvUserList.SelectedRows;
            int rowsCount = selectedRows.Count;
            if (rowsCount == 0)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessSelect(rm, MessageValidate.LockAcc), MessageValidate.GetErrorTitle(rm));
                return;
            }

            string message = string.Format(MessageValidate.GetMessage(rm, "lockAccount"), rowsCount == 1 ? string.Empty : string.Empty);
            if (MessageBoxManager.ShowQuestionMessageBox(this, message) == DialogResult.Yes)
            {
                long[] userIds = new long[rowsCount];
                for (int i = 0; i < rowsCount; i++)
                {
                    userIds[i] = Convert.ToInt64(selectedRows[i].Cells[colUserId.Name].Value.ToString());
                }
                DoLockUsers(userIds);
            }
        }

        private void DoLockUsers(long[] userIds)
        {
            List<MethodResultDto> result = null;
            try
            {
                result = ManagerSystemFactory.Instance.GetChannel().LockUsers(StorageService.CurrentSessionId, userIds);
            }
            catch (TimeoutException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, "TimeOutExceptionMessage"));
                return;
            }
            catch (FaultException<WcfServiceFault> ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
                return;
            }
            catch (FaultException ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, "FaultExceptionMessage")
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
                return;
            }
            catch (CommunicationException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, "CommunicationExceptionMessage"));
                return;
            }
            if (result != null && result.Count > 0)
            {
                ResultDialog dlg = ResultDialog.Instance;
                dlg.ChageColumnTitle(0, MessageValidate.GetMessSelect(rm, "lblUserName"));
                dlg.ChangeColumnWidth(0, 125);
                dlg.ChangeDataSource(result);
                dlg.ShowDialog();
                LoadUserList();
            }
        }

        [CommandHandler(UserCommandNames.UnLockUser)]
        public void btnUnLockUser_Clicked(object sender, EventArgs e)
        {
            var selectedRows = dgvUserList.SelectedRows;
            int rowsCount = selectedRows.Count;
            if (rowsCount == 0)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessSelect(rm, MessageValidate.UnLockAcc), MessageValidate.GetErrorTitle(rm));
                return;
            }

            string message = string.Format(MessageValidate.GetMessage(rm, "unlockAccount"), rowsCount == 1 ? string.Empty : string.Empty);
            if (MessageBoxManager.ShowQuestionMessageBox(this, message) == DialogResult.Yes)
            {
                long[] userIds = new long[rowsCount];
                for (int i = 0; i < rowsCount; i++)
                {
                    userIds[i] = Convert.ToInt64(selectedRows[i].Cells[colUserId.Name].Value.ToString());
                }
                DoUnLockUsers(userIds);
            }
        }

        private void DoUnLockUsers(long[] userIds)
        {
            List<MethodResultDto> result = null;
            try
            {
                result = ManagerSystemFactory.Instance.GetChannel().UnLockUsers(StorageService.CurrentSessionId, userIds);
            }
            catch (TimeoutException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, "TimeOutExceptionMessage"));
                return;
            }
            catch (FaultException<WcfServiceFault> ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
                return;
            }
            catch (FaultException ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, "FaultExceptionMessage")
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
                return;
            }
            catch (CommunicationException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, "CommunicationExceptionMessage"));
                return;
            }
            if (result != null && result.Count > 0)
            {
                ResultDialog dlg = ResultDialog.Instance;
                dlg.ChageColumnTitle(0, "Tài Khoản");
                dlg.ChangeColumnWidth(0, 125);
                dlg.ChangeDataSource(result);
                dlg.ShowDialog();
                LoadUserList();
            }
        }

        [CommandHandler(UserCommandNames.RemoveUser)]
        public void btnRemoveUser_Clicked(object sender, EventArgs e)
        {
            var selectedRows = dgvUserList.SelectedRows;
            int rowsCount = selectedRows.Count;

            if (rowsCount == 0)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessSelect(rm, MessageValidate.CancelAcc), MessageValidate.GetErrorTitle(rm));
                return;
            }
            string message = string.Format(MessageValidate.GetMessageRemove(rm, "account"), rowsCount == 1 ? string.Empty : string.Empty);
            if (MessageBoxManager.ShowQuestionMessageBox(this, message) == DialogResult.Yes)
            {
                long[] userIds = new long[rowsCount];
                for (int i = 0; i < rowsCount; i++)
                {
                    userIds[i] = Convert.ToInt64(selectedRows[i].Cells[colUserId.Name].Value.ToString());
                }
                DoRemoveUsers(userIds);
            }
        }

        private void DoRemoveUsers(long[] userIds)
        {
            List<MethodResultDto> result = null;
            try
            {
                result = ManagerSystemFactory.Instance.GetChannel().RemoveUsers(StorageService.CurrentSessionId, userIds);
            }
            catch (TimeoutException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, "TimeOutExceptionMessage"));
                return;
            }
            catch (FaultException<WcfServiceFault> ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
                return;
            }
            catch (FaultException ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, "FaultExceptionMessage")
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
                return;
            }
            catch (CommunicationException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, "CommunicationExceptionMessage"));
                return;
            }
            if (result != null && result.Count > 0)
            {
                ResultDialog dlg = ResultDialog.Instance;
                dlg.ChageColumnTitle(0, MessageValidate.GetMessSelect(rm, "Acc"));
                dlg.ChangeColumnWidth(0, 125);
                dlg.ChangeDataSource(result);
                dlg.ShowDialog();
                LoadUserList();
            }
        }

        #endregion

        #region Form events

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            string filePath = ControlExtMethods.ShowSaveFileDialog(MessageValidate.GetMessage(rm, "smsChooseFileExport"), selectedGroupNode.Text, "MS Excel (*.xls)|*.xls");
            if (filePath != null)
            {
                try
                {
                    dgvUserList.ExportToExcel(filePath);
                }
                catch (Exception ex)
                {
                    MessageBoxManager.ShowErrorMessageBox(this, ex.Message);
                    return;
                }
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "smsLinkFile") + filePath);
            }
        }

        private void dgvUsers_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo info = dgvUserList.HitTest(e.X, e.Y);
                if (info.RowIndex != -1)
                {
                    if (info.RowIndex >= 0 && info.ColumnIndex >= 0)
                    {
                        if (!dgvUserList.SelectedRows.Contains(dgvUserList.Rows[info.RowIndex]))
                        {
                            foreach (DataGridViewRow row in dgvUserList.SelectedRows)
                            {
                                row.Selected = false;
                            }
                            dgvUserList.Rows[info.RowIndex].Selected = true;
                        }
                    }
                    Rectangle r = dgvUserList.GetCellDisplayRectangle(info.ColumnIndex, info.RowIndex, true);
                    cmsUserRecord.Show((Control)sender, e.X, e.Y);
                }
                else
                {
                    cmsUserTable.Show((Control)sender, e.X, e.Y);
                }
            }
        }

        private void trvGroups_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeNode node = trvGroupList.GetNodeAt(trvGroupList.PointToClient(Control.MousePosition));
                if (node != null)
                {
                    trvGroupList.SelectedNode = node;
                    if (node != rootNode)
                    {
                        cmsGroupRecord.Show((Control)sender, e.Location.X, e.Location.Y);
                    }
                }
                else
                {
                    cmsGroupTree.Show((Control)sender, e.Location.X, e.Location.Y);
                }
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
            dtbUserList.Rows.Clear();
            int take = LocalSettings.Instance.RecordsPerPage;
            int skip = (currentPageIndex - 1) * take;

            List<UserSworld> result = UserList.Skip(skip).Take(take).ToList();
            LoadUserDataGridView(result);

            pagerPanel1.ShowNumberOfRecords(UserList.Count, result != null ? result.Count : 0, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
            pagerPanel1.UpdatePagingLinks(UserList.Count, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
        }

        private void btnShowHide_Clicked(object sender, EventArgs e)
        {
            if (pnlFilterBox.Height > hiddenFilterBoxHeight)
            {
                pnlFilterBox.Height = hiddenFilterBoxHeight;
                btnShowHideFilter.Text = btnShowHideFilter.ToolTipText = MessageValidate.GetMessSelect(rm, "showHideFrm");
                btnShowHideFilter.ToolTipText = MessageValidate.GetMessSelect(rm, "showHideFrm");
                btnShowHideFilter.Image = global::CommonControls.Properties.Resources.ArrowDown_16x16;
            }
            else
            {
                pnlFilterBox.Height = startupFilterBoxHeight;
                btnShowHideFilter.Text = btnShowHideFilter.ToolTipText = MessageValidate.GetMessSelect(rm, "btnShowHide");
                btnShowHideFilter.ToolTipText = MessageValidate.GetMessSelect(rm, "btnShowHide");
                btnShowHideFilter.Image = global::CommonControls.Properties.Resources.ArrowUp_16x16;
            }
        }

        private void trvGroups_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            // If backgound worker is running -> restrict selecting another node
            if (bgwLoadUser.IsBusy)
            {
                e.Cancel = true;
                return;
            }

            // Change node font to normal
            if (selectedGroupNode != null)
            {
                selectedGroupNode.NodeFont = new Font(startupNodeFont, FontStyle.Regular);
                selectedGroupNode.Text = selectedGroupNode.Text;
            }
        }

        private void trvGroups_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectedNode = e.Node;
            if (selectedNode != null)
            {
                selectedNode.NodeFont = new Font(startupNodeFont, FontStyle.Bold);
                selectedNode.Text = selectedNode.Text;

                if (selectedGroupNode != null && selectedNode == selectedGroupNode)
                {
                    return;
                }
                selectedGroupNode = selectedNode;
                currentPageIndex = 1;
                LoadUserList();
            }
            if (selectedNode.Level == 1)
            {
                InvisibleButton(true);
            }
        }

        private void cbxFilterByUserStatus_CheckedChanged(object sender, EventArgs e)
        {
            rbtnStatusCanceled.Enabled = rbtnStatusLocked.Enabled = rbtnStatusNormal.Enabled = cbxFilterByUserStatus.Checked;
        }

        private void cbxShowInactiveUsers_CheckedChanged(object sender, EventArgs e)
        {
            colSttCanceled.Visible = cbxShowInactiveUsers.Checked;
            dgvUserList.CurrentCell = null;
            foreach (DataGridViewRow r in dgvUserList.Rows)
            {
                if (r.Cells[colSttCanceled.Index].Value.ToString().Length > 0)
                {
                    r.Visible = cbxShowInactiveUsers.Checked;
                }
            }
        }

        #endregion Form events

        #region CAB events/handlers

        [CommandHandler(UserCommandNames.ShowUserMgtMain)]
        public void ShowUserMainHandler(object s, EventArgs e)
        {
            UsrUserMgtMain uc = workItem.Items.Get<UsrUserMgtMain>(ComponentNames.UserMgtComponent);
            if (uc == null)
            {
                uc = workItem.Items.AddNew<UsrUserMgtMain>(ComponentNames.UserMgtComponent);
            }
            else if (uc.IsDisposed)
            {
                workItem.Items.Remove(uc);
                uc = workItem.Items.AddNew<UsrUserMgtMain>(ComponentNames.UserMgtComponent);
            }
            workItem.Workspaces[WorkspaceName.MainWorkspace].Show(uc);
            uc.Parent.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuUserManager);
        }

        [EventPublication(UserEventTopicNames.UserListShown)]
        public event EventHandler UserListShown;

        [EventPublication(UserEventTopicNames.UserListHide)]
        public event EventHandler UserListHide;

        #endregion
    }
}