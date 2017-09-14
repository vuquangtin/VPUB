﻿using CommonControls;
using CommonControls.Custom;
using sWorldModel;
using sWorldModel.Exceptions;
using Microsoft.Practices.CompositeUI;
//using sWorldCommunication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ServiceModel;
using System.Windows.Forms;
using JavaCommunication.Factory;
using sWorldModel.TransportData;
using System.Resources;
using CommonHelper.Utils;
using CommonHelper.Constants;
//using WcfServiceCommon;

namespace SystemMgtComponent.WorkItems.Users
{
    public partial class FrmGroupDetail : CommonControls.Custom.CommonDialog
    {
        #region Properties

        public const byte ModeAdding = 1;
        public const byte ModeUpdating = 2;

        private byte operatingMode;
        private long groupId;

        public DialogPostAction PostAction { get; private set; }
        public GroupCustomerDto OriginalGroup { get; private set; }
        public GroupCustomerDto AddedOrEditedGroup { get; private set; }

        private BackgroundWorker bgwLoadGroup;
        private BackgroundWorker bgwUpdateGroup;
        private BackgroundWorker bgwAddGroup;

        private ResourceManager rm;

        private ILocalStorageService storageService;
        [ServiceDependency]
        public ILocalStorageService StorageService
        {
            get { return storageService; }
            set { storageService = value; }
        }

        #endregion

        #region Initialization

        public FrmGroupDetail(byte operationMode, long groupId)
        {
            InitializeComponent();

            this.operatingMode = operationMode;
            this.groupId = groupId;

            trvFunctions.AfterCheck += trvFunctions_AfterCheck;
            trvFunctions.AfterSelect += trvFunctions_AfterSelect;
            trvFunctions.Leave += trvFunctions_Leave;

            Load += OnFormLoad;
            Shown += OnFormShown;
        }

        private void OnFormLoad(object sender, EventArgs e)
        {
            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
            this.Text = MessageValidate.GetMessage(rm, this.Name);

            // Load function list
            List<Function> modules = FunctionExtMethod.GetModuleList();
            List<Function> functions;

            foreach (Function m in modules)
            {
                TreeNode moduleNode = new TreeNode();
                moduleNode.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, m.GetName());
                moduleNode.Name = Convert.ToString((long)m);
                trvFunctions.Nodes.Add(moduleNode);

                functions = m.GetChildList();
                foreach (Function f in functions)
                {
#if !SWT
                    if (f == Function.FUNC_TOOLKIT_WRITE_KEY_CARD ||
                        f == Function.FUNC_TOOLKIT_CLEAR_EMPTY_CARD)
                        continue;
#endif
                    TreeNode functionNode = new TreeNode();
                    functionNode.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, f.GetName());
                    functionNode.Name = Convert.ToString((long)f);
                    moduleNode.Nodes.Add(functionNode);
                }

            }
            trvFunctions.ExpandAll();
        }

        private void OnFormShown(object sender, EventArgs e)
        {
            // Switch view to corresponding mode
            switch (operatingMode)
            {
                case ModeAdding:
                    this.Text = MessageValidate.GetMessage(rm, "creategroup");
                    tbxGroupName.ReadOnly = tbxGroupDescription.ReadOnly = false;
                    btnConfirm.Enabled = btnRefresh.Enabled = true;

                    bgwAddGroup = new BackgroundWorker();
                    bgwAddGroup.WorkerSupportsCancellation = true;
                    bgwAddGroup.DoWork += bgwAddGroup_DoWork;
                    bgwAddGroup.RunWorkerCompleted += bgwAddGroup_RunWorkerCompleted;

                    break;
                case ModeUpdating:
                    this.Text = MessageValidate.GetMessage(rm, "updategroupTillte");
                    tbxGroupName.ReadOnly = tbxGroupDescription.ReadOnly = false;

                    bgwLoadGroup = new BackgroundWorker();
                    bgwLoadGroup.WorkerSupportsCancellation = true;
                    bgwLoadGroup.DoWork += OnLoadGroupWorkerDoWork;
                    bgwLoadGroup.RunWorkerCompleted += OnLoadGroupWorkerRunWorkerCompleted;

                    bgwUpdateGroup = new BackgroundWorker();
                    bgwUpdateGroup.WorkerSupportsCancellation = true;
                    bgwUpdateGroup.DoWork += OnUpdateGroupWorkerDoWork;
                    bgwUpdateGroup.RunWorkerCompleted += OnUpdateGroupWorkerCompleted;

                    LoadGroup();

                    break;
                default:
                    throw new ArgumentException("Invalid operating mode!");
            }
        }

#endregion

#region Form events

        private void OnButtonConfirmClicked(object sender, EventArgs e)
        {
            switch (operatingMode)
            {
                case ModeAdding:
                    AddGroup();
                    break;
                case ModeUpdating:
                    UpdateGroup();
                    break;
                default:
                    break;
            }
        }

        private void OnButtonRefreshClicked(object sender, EventArgs e)
        {
            switch (operatingMode)
            {
                case ModeAdding:
                    tbxGroupName.Text = tbxGroupDescription.Text = string.Empty;
                    break;
                case ModeUpdating:
                    PopulateGroupDataToView();
                    break;
                default:
                    throw new ArgumentException("Invalid operating mode!");
            }
        }

        private void OnButtonCancelClicked(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void trvFunctions_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = e.Node;
            lblFunctionDescription.Text = ((Function)Convert.ToInt32(node.Name)).GetDescription();
        }

        private void trvFunctions_Leave(object sender, EventArgs e)
        {
            lblFunctionDescription.Text = string.Empty;
        }

        private void trvFunctions_AfterCheck(object sender, TreeViewEventArgs e)
        {
            TreeNode node = e.Node;
            if (node.Level == 0)
            {
                if (node.Checked)
                {
                    foreach (TreeNode child in node.Nodes)
                    {
                        child.Checked = true;
                    }
                }
                else
                {
                    foreach (TreeNode child in node.Nodes)
                    {
                        child.Checked = false;
                    }
                }
            }
        }

        private void ClearAndFocusGroupNameField()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(ClearAndFocusGroupNameField));
                return;
            }
            tbxGroupName.Text = string.Empty;
            tbxGroupName.Focus();
        }

#endregion

#region Load group

        private void LoadGroup()
        {
            if (!bgwLoadGroup.IsBusy)
            {
                bgwLoadGroup.RunWorkerAsync();
            }
        }

        private void OnLoadGroupWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                OriginalGroup = ManagerSystemFactory.Instance.GetChannel().GetGroupById(StorageService.CurrentSessionId, groupId);
                e.Result = true;
            }
            catch (TimeoutException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm,"TimeOutExceptionMessage"));
            }
            catch (FaultException<WcfServiceFault> ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
            }
            catch (FaultException ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm,"FaultExceptionMessage")
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
            }
            catch (CommunicationException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm,"CommunicationExceptionMessage"));
            }
        }

        private void OnLoadGroupWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if (e.Result != null)
            {
                PopulateGroupDataToView();
                btnConfirm.Enabled = btnRefresh.Enabled = true;
            }
        }

        private void PopulateGroupDataToView()
        {
            if (OriginalGroup != null)
            {
                tbxGroupName.Text = OriginalGroup.Name;
                tbxGroupDescription.Text = OriginalGroup.Description;

                foreach (TreeNode parent in trvFunctions.Nodes)
                {
                    int childCheckedCount = 0;
                    foreach (TreeNode child in parent.Nodes)
                    {
                        int fid = Convert.ToInt32(child.Name);
                        if (OriginalGroup.PolicySworlds != null && OriginalGroup.PolicySworlds.Exists(f => fid == f.ModuleId))
                        {
                            child.Checked = true;
                            childCheckedCount++;
                        }
                        else
                        {
                            child.Checked = false;
                        }
                    }
                    if (childCheckedCount == parent.Nodes.Count)
                    {
                        parent.Checked = true;
                    }
                }
            }
            else
            {
                tbxGroupName.Text = tbxGroupDescription.Text = string.Empty;
                foreach (TreeNode node in trvFunctions.Nodes)
                {
                    node.Checked = false;
                    foreach (TreeNode child in node.Nodes)
                    {
                        node.Checked = false;
                    }
                }
            }
        }

#endregion

#region Update group

        private void UpdateGroup()
        {
            //Chuẩn bị dữ liệu
            List<PolicySworld> newPolicyList = new List<PolicySworld>();
            foreach (TreeNode parent in trvFunctions.Nodes)
            {
                foreach (TreeNode child in parent.Nodes)
                {
                    if (child.Checked)
                    {
                        newPolicyList.Add(new PolicySworld() { GroupId = groupId, ModuleId = Convert.ToInt32(child.Name) });
                    }
                }
            }
            tbxGroupName.Text = tbxGroupName.Text.Trim();
            tbxGroupDescription.Text = tbxGroupDescription.Text.Trim();

            //Kiểm tra xem có gì thay đổi không
            string newName = tbxGroupName.Text;
            string newDescription = tbxGroupDescription.Text;

            if (newName.Equals(OriginalGroup.Name))
            {
                newName = null;
            }
            if (newDescription.Equals(OriginalGroup.Description))
            {
                newDescription = null;
            }
            if (newPolicyList.Equals(OriginalGroup.PolicySworlds))
            {
                newPolicyList = null;
            }
            if (newName == null && newDescription == null && newPolicyList == null)
            {
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "notInfoChange"));
                return;
            }
            AddedOrEditedGroup = new GroupCustomerDto
            {
                Id = OriginalGroup.Id,
                Name = tbxGroupName.Text,
                Description = tbxGroupDescription.Text,
                PolicySworlds = newPolicyList,
            };

            if (MessageBoxManager.ShowQuestionMessageBox(this, MessageValidate.GetQuestionUpdate(rm, "GroupAcc")) == System.Windows.Forms.DialogResult.Yes)
            {
                if (!bgwUpdateGroup.IsBusy)
                {
                    bgwUpdateGroup.RunWorkerAsync();
                }
            }
        }

        private void OnUpdateGroupWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                ManagerSystemFactory.Instance.GetChannel().UpdateGroup(StorageService.CurrentSessionId, AddedOrEditedGroup);
                e.Result = true;
            }
            catch (TimeoutException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm,"TimeOutExceptionMessage"));
            }
            catch (FaultException<WcfServiceFault> ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
                switch (ex.Detail.Code)
                {
                    case ErrorCodes.GROUPNAME_TAKEN:
                        ClearAndFocusGroupNameField();
                        break;
                    default:
                        break;
                }
            }
            catch (FaultException ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm,"FaultExceptionMessage")
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
            }
            catch (CommunicationException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm,"CommunicationExceptionMessage"));
            }
        }

        private void OnUpdateGroupWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if (e.Result != null)
            {
                PostAction = DialogPostAction.SUCCESS;
                Hide();
            }
        }

#endregion

#region Add group

        private void AddGroup()
        {
            tbxGroupName.Text = tbxGroupName.Text.Trim();
            if (tbxGroupName.Text.Length == 0)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessageValidate(rm, MessageValidate.GroupName), MessageValidate.GetErrorTitle(rm));
                return;
            }
            if (MessageBoxManager.ShowQuestionMessageBox(this, MessageValidate.GetQuestionAdd(rm, "GroupAcc")) == System.Windows.Forms.DialogResult.Yes)
            {
                if (!bgwAddGroup.IsBusy)
                {
                    AddedOrEditedGroup = new GroupCustomerDto();
                    AddedOrEditedGroup.Name = tbxGroupName.Text;
                    AddedOrEditedGroup.Description = tbxGroupDescription.Text;
                    List<PolicySworld> PolicyList = new List<PolicySworld>();
                    foreach (TreeNode parent in trvFunctions.Nodes)
                    {
                        foreach (TreeNode child in parent.Nodes)
                        {
                            if (child.Checked)
                            {
                                PolicyList.Add(new PolicySworld() { GroupId = groupId, ModuleId = Convert.ToInt32(child.Name) });
                            }
                        }
                    }
                    AddedOrEditedGroup.PolicySworlds = PolicyList;
                    bgwAddGroup.RunWorkerAsync();
                }
            }
        }

        private void bgwAddGroup_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                AddedOrEditedGroup = ManagerSystemFactory.Instance.GetChannel().AddGroup(StorageService.CurrentSessionId, AddedOrEditedGroup);
            }
            catch (TimeoutException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm,"TimeOutExceptionMessage"));
            }
            catch (FaultException<WcfServiceFault> ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
                switch (ex.Detail.Code)
                {
                    case ErrorCodes.GROUPNAME_TAKEN:
                        ClearAndFocusGroupNameField();
                        break;
                    default:
                        break;
                }
            }
            catch (FaultException ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm,"FaultExceptionMessage")
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
            }
            catch (CommunicationException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm,"CommunicationExceptionMessage"));
            }
            finally
            {
                e.Result = true;
            }
        }

        private void bgwAddGroup_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if ((bool)e.Result)
            {
                PostAction = DialogPostAction.SUCCESS;
                Hide();
            }
        }

#endregion


    }
}