using CommonControls;
using CommonControls.Custom;
using CommonHelper.Config;
using CommonHelper.Constants;
using CommonHelper.Utils;
using JavaCommunication;
using Microsoft.Practices.CompositeUI;
using sBuildingCommunication.Define;
using sBuildingCommunication.Factory;
using sBuildingCommunication.Model;
using sWorldModel;
using sWorldModel.Exceptions;
using sWorldModel.Filters;
using sWorldModel.TransportData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;

namespace sAccessComponent.WorkItems
{
    /// <summary>
    /// This form use to add or edit group member
    /// </summary>
    public partial class FrmAddOrEditGroupMember : CommonControls.Custom.CommonDialog
    {
        #region Properties
        public const byte ModeAdding = 1;
        public const byte ModeUpdating = 2;


        private byte OperatingMode;
        private long groupId;
        private RoleDTO RoleDTO;
        private RoleDTO AddOrUpdateRole;
        private ResourceManager rm;


        private BackgroundWorker bgwLoadRole;
        private BackgroundWorker bgwAddRole;
        private BackgroundWorker bgwUpdateRole;


        public DialogPostAction PostAction { get; private set; }

        private ILocalStorageService storageService;
        [ServiceDependency]
        public ILocalStorageService StorageService
        {
            get { return storageService; }
            set { storageService = value; }
        }

        #endregion
        #region Contructor
        public FrmAddOrEditGroupMember(byte operationMode, long groupId = 0)
        {
            InitializeComponent();
            RegisterEvent();
            this.groupId = groupId;
            this.OperatingMode = operationMode;
        }
        #endregion
        #region Event's
        private void RegisterEvent()
        {
            bgwLoadRole = new BackgroundWorker();
            bgwLoadRole.WorkerSupportsCancellation = true;
            bgwLoadRole.DoWork += OnLoadGroupMemberWorkerDoWork;
            bgwLoadRole.RunWorkerCompleted += OnLoadGroupMemberrRunWorkerCompleted;


            btnConfirm.Click += OnButtonConfirmClicked;
            btnCancel.Click += OnButtonCancelClicked;
            btnRefresh.Click += OnButtonRefreshClicked;
            Shown += OnFormShown;
        }
        private void OnFormShown(object sender, EventArgs e)
        {
            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
            // Set Language
            SetLanguage();
            switch (OperatingMode)
            {
                case ModeAdding:
                    InitFormAddRole();
                    break;

                case ModeUpdating:
                    LoadRole();
                    InitFormUpdateRole();
                    break;
                default:
                    throw new ArgumentException("Invalid operating mode!");
            }

        }
        #endregion
        #region Set Language
        private void SetLanguage()
        {
            this.lblNameGroup.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.lblNameGroup.Name);
            this.lblDescription.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.lblDescription.Name);
            this.btnRefresh.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnRefresh.Name);
            this.btnCancel.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnCancel.Name);
            this.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.Name);
        }
        #endregion
        #region AddRole

        private void LoadRole()
        {
            if (!bgwLoadRole.IsBusy && groupId > 0)
            {
                bgwLoadRole.RunWorkerAsync();
            }
        }
        private void OnLoadAddRoleWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                // InsertRole in database
                e.Result = AccessFactory.Instance.GetChannel().InsertRole(StorageService.CurrentSessionId, AddOrUpdateRole);
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
        private void OnLoadAddRoleWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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
            else
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "addgroupmemberfailed"));

            }
        }

        #endregion

        #region Buttons

        private void OnButtonConfirmClicked(object sender, EventArgs e)
        {
            switch (OperatingMode)
            {
                case ModeAdding:
                    Validate();
                    AddRole();
                    break;
                case ModeUpdating:
                    UpdateRole();
                    break;
                default:
                    break;
            }
        }
        private void OnButtonRefreshClicked(object sender, EventArgs e)
        {
            ClearEmptyControl();
        }

        private void OnButtonCancelClicked(object sender, EventArgs e)
        {
            this.Hide();
        }

        #endregion
        #region Binding Data

        private void ToModel(RoleDTO role)
        {
            txtName.Text = role.name;
            txtDes.Text = role.description;

        }

        private RoleDTO ToEntity()
        {
            RoleDTO roleDTO = new RoleDTO();
            roleDTO = RoleDTO != null ? RoleDTO : roleDTO;
            roleDTO.name = txtName.Text.Trim();
            roleDTO.description = txtDes.Text.Trim();


            return roleDTO;
        }

        #endregion

        #region SetControl

        private void ClearEmptyControl()
        {
            txtName.Text =
            txtDes.Text = string.Empty;
            txtName.Focus();
        }

        private void SetShowOrHideButton(bool isView)
        {
            btnConfirm.Enabled = btnRefresh.Enabled = isView;
        }

        #endregion

        #region ValidateData

        private bool ValidateData()
        {

            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessageValidate(rm, MessageValidate.GetMessage(rm, "namevalidate")), MessageValidate.GetErrorTitle(rm));
                return false;
            }
            return true;
        }

        #endregion

        #region InitFormAddRole

        private void InitFormAddRole()
        {
            SetShowOrHideButton(true);

            // add group
            bgwAddRole = new BackgroundWorker();
            bgwAddRole.WorkerSupportsCancellation = true;
            bgwAddRole.DoWork += OnLoadAddRoleWorkerDoWork;
            bgwAddRole.RunWorkerCompleted += OnLoadAddRoleWorkerRunWorkerCompleted;
        }

        #endregion
        #region InitFormUpdateRole
        private void InitFormUpdateRole()
        {
            SetShowOrHideButton(true);
            // update group member
            bgwUpdateRole = new BackgroundWorker();
            bgwUpdateRole.WorkerSupportsCancellation = true;
            bgwUpdateRole.DoWork += OnLoadUpdateRoleWorkerDoWork;
            bgwUpdateRole.RunWorkerCompleted += OnLoadUpdateRoleWorkerRunWorkerCompleted;


        }
        #endregion
        #region LoadRole
        private void OnLoadGroupMemberWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = AccessFactory.Instance.GetChannel().GetRoleById(StorageService.CurrentSessionId, groupId);
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
        private void OnLoadGroupMemberrRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if (e.Result == null)
            {
                return;
            }
            RoleDTO = (RoleDTO)e.Result;
            ToModel(RoleDTO);
        }
        #endregion
        #region Updaterole
        private void OnLoadUpdateRoleWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = (int)Status.SUCCESS == AccessFactory.Instance.GetChannel().UpdateRole(StorageService.CurrentSessionId, AddOrUpdateRole);
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

        private void OnLoadUpdateRoleWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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
            else
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "UpdateGroupMemberfaieled"));

            }
        }
        #endregion
        #region AddroleMethod
        private void AddRole()
        {
            if (ValidateData() && MessageBoxManager.ShowQuestionMessageBox(this, MessageValidate.GetQuestionAdd(rm, "groupmember"), MessageValidate.GetConfirm(rm)) == DialogResult.Yes)
            {
                if (!bgwAddRole.IsBusy)
                {
                    AddOrUpdateRole = ToEntity();
                    bgwAddRole.RunWorkerAsync();
                }
            }
        }
        #endregion
        #region UpdateRoleMethod
        private void UpdateRole()
        {
            if (MessageBoxManager.ShowQuestionMessageBox(this, MessageValidate.GetQuestionUpdate(rm, "groupmember"), MessageValidate.GetConfirm(rm)) == DialogResult.Yes)
            {
                if (!bgwUpdateRole.IsBusy)
                {
                    AddOrUpdateRole = ToEntity();
                    bgwUpdateRole.RunWorkerAsync();
                }

            }
            #endregion
        }
    }
    }
