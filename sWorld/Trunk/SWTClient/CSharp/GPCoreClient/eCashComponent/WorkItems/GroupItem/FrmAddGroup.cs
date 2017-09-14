using CommonControls;
using CommonHelper.Constants;
using CommonHelper.Utils;
using JavaCommunication.Factory;
using Microsoft.Practices.CompositeUI;
using sWorldModel;
using sWorldModel.Exceptions;
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

namespace eCashComponent
{
    public partial class FrmAddGroup : CommonControls.Custom.CommonDialog
    {
        #region Properties

        public const byte ModeAdding = 1;
        public const byte ModeUpdating = 2;
        private byte OperatingMode;

        private GroupDto group;
        private GroupDto AddOrUpdateGroup;
        private ResourceManager rm;

        //private long Id;
        private long OrgId;
        //private long SubOrgId;
        private long GroupId;

        private BackgroundWorker bgwLoadEcashGroup;
        private BackgroundWorker bgwAddEcashGroup;
        private BackgroundWorker bgwUpdateEcashGroup;

        public DialogPostAction PostAction { get; private set; }

        private ILocalStorageService storageService;
        [ServiceDependency]
        public ILocalStorageService StorageService
        {
            get { return storageService; }
            set { storageService = value; }
        }

        #endregion

        #region Event
        private void RegisterEvent()
        {
            btnConfirm.Click += OnButtonConfirmClicked;
            btnRefresh.Click += btnRefresh_Click;
            btnCancel.Click += btnCancel_Click;
            Shown += OnFormShown;
        }

        private void OnFormShown(object sender, EventArgs e)
        {
            switch (OperatingMode)
            {
                case ModeAdding:
                    InitFormAddEcashGroup();
                    break;
                case ModeUpdating:
                    InitFormUpdateEcashGroup();
                    LoadEcashGroup();
                    break;
                default:
                    throw new ArgumentException("Invalid operating mode!");
            }
            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
        }
        #endregion Event
          
        #region Ecash

        public FrmAddGroup(byte operationMode, long orgId = 0, long groupId = 0)
        {

            InitializeComponent();
            RegisterEvent();
            this.OperatingMode = operationMode;
            this.GroupId = groupId;
            this.OrgId = orgId;

        }
        private void OnLoadAddEcashGroupWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = group = EcashConfigFactory.Instance.GetChannel().InsertGroupItem(StorageService.CurrentSessionId, AddOrUpdateGroup);
               
            }
            catch (NullReferenceException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.CantNotInsertData);
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
        }
        private void OnLoadAddEcashGroupWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if (e.Result != null)
            {
                MessageBoxManager.ShowInfoMessageBox(this, CommonMessages.InsertSuccess);
                PostAction = DialogPostAction.SUCCESS;
                Hide();
            }
        }
        private void OnLoadEcashGroupWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = group = EcashConfigFactory.Instance.GetChannel().GetGroupItemByGroupItemId(StorageService.CurrentSessionId, GroupId);
           //     e.Result = true;
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
        }
        private void OnLoadEcashGroupWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if (e.Result != null)
            {
                ToModel(group);
            }
        }
        private void OnLoadUpdateEcashGroupWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                //e.Result = (int)Status.SUCCESS = VoucherGiftFactory.Instance.GetChannel().UpdateVoucherGift(StorageService.CurrentSessionId, AddOrUpdateVoucher);
                e.Result = group = EcashConfigFactory.Instance.GetChannel().UpdateGroupItem(StorageService.CurrentSessionId, AddOrUpdateGroup);

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
        }
        private void OnLoadUpdateEcashGroupWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if (e.Result != null)
            {
                MessageBoxManager.ShowInfoMessageBox(this, CommonMessages.UpdateSuccess);
                PostAction = DialogPostAction.SUCCESS;
                Hide();
            }
        }
    
                      
        #endregion Ecash

        #region Validate Data

        private bool ValidateData()
        {
            if (string.IsNullOrEmpty(tbxGroupName.Text))
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessageValidate(rm, MessageValidate.GroupName), MessageValidate.GetErrorTitle(rm));
                return false;
            }

            if (tbxDescriptionGroup.Text.Length >= 255)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessCharOverLoad(rm, MessageValidate.Description, 255), MessageValidate.GetErrorTitle(rm));
                return false;
            }
            if (tbxGroupName.Text.Length >= 50)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessCharOverLoad(rm, MessageValidate.CancelCardNameGroup, 50), MessageValidate.GetErrorTitle(rm));
                return false;
            }      
             return true;
        }

        #endregion

        #region Binding Data

        private void ToModel(GroupDto group)
        {
            tbxGroupName.Text = group.Name;
            tbxDescriptionGroup.Text = group.Description;
        }

        private GroupDto ToEntity()
        {
            GroupDto groupitem = new GroupDto();
            groupitem = group != null ? group : groupitem;

            groupitem.Id = GroupId;
            groupitem.OrgId = OrgId;
            groupitem.Name = tbxGroupName.Text.Trim();
          


            groupitem.Description = tbxDescriptionGroup.Text.Trim();

            

            return groupitem;
        }

      

     
        #endregion Ecash
        
        #region SetControl
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearEmptyControl();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void OnButtonConfirmClicked(object sender, EventArgs e)
        {
            switch (OperatingMode)
            {
                case ModeAdding:
                    AddEcashGroup();
                    break;
                case ModeUpdating:
                    UpdateEcashGroup();
                    break;
                default:
                    break;
            }

        }
        private void ClearEmptyControl()
        {
            tbxGroupName.Text = "";
         
            tbxDescriptionGroup.Text = "";

        }


        private void SetControl(bool isView)
        {
           tbxDescriptionGroup.ReadOnly = isView;

                       
        }

        private void SetShowOrHideButton(bool isView)
        {
            btnConfirm.Enabled = btnRefresh.Enabled = isView;
        }

        #endregion SetControl

        #region Load-Add-Update-Ecash Group

        private void AddEcashGroup()
        {
            if (ValidateData() && MessageBoxManager.ShowQuestionMessageBox(this, MessageValidate.GetBaseMessAddGroup(rm, MessageValidate.CancelCardGroup)) == System.Windows.Forms.DialogResult.Yes)
            {
                if (!bgwAddEcashGroup.IsBusy)
                {
                    AddOrUpdateGroup = ToEntity();
                    bgwAddEcashGroup.RunWorkerAsync();
                }
            }
        }
        private void InitFormAddEcashGroup()
        {
            this.Text = lbTitle.Text = "Thêm Thông Tin Nhóm Mới";
            lbNote.Text = "Thêm thông tin nhóm mới vào hệ thống.";
            SetControl(false);
            SetShowOrHideButton(true);
            ClearEmptyControl();

            bgwAddEcashGroup = new BackgroundWorker();
            bgwAddEcashGroup.WorkerSupportsCancellation = true;
            bgwAddEcashGroup.DoWork += OnLoadAddEcashGroupWorkerDoWork;
            bgwAddEcashGroup.RunWorkerCompleted += OnLoadAddEcashGroupWorkerRunWorkerCompleted;


        }

        private void InitFormUpdateEcashGroup()
        {
            this.Text = lbTitle.Text = "Cập Nhật Thông Tin Nhóm Mới";
            lbNote.Text = "Cập nhật thông tin nhóm mới trong hệ thống.";
            SetControl(false);
            SetShowOrHideButton(true);

            bgwLoadEcashGroup = new BackgroundWorker();
            bgwLoadEcashGroup.WorkerSupportsCancellation = true;
            bgwLoadEcashGroup.DoWork += OnLoadEcashGroupWorkerDoWork;
            bgwLoadEcashGroup.RunWorkerCompleted += OnLoadEcashGroupWorkerRunWorkerCompleted;

            bgwUpdateEcashGroup = new BackgroundWorker();
            bgwUpdateEcashGroup.WorkerSupportsCancellation = true;
            bgwUpdateEcashGroup.DoWork += OnLoadUpdateEcashGroupWorkerDoWork;
            bgwUpdateEcashGroup.RunWorkerCompleted += OnLoadUpdateEcashGroupWorkerRunWorkerCompleted;
        }
        private void LoadEcashGroup()
        {
            if (!bgwLoadEcashGroup.IsBusy && GroupId > 0)
            {
                bgwLoadEcashGroup.RunWorkerAsync();
            }
        }
        private void UpdateEcashGroup()
        {
            if (ValidateData() && MessageBoxManager.ShowQuestionMessageBox(this, MessageValidate.GetBaseMessAddGroup(rm, MessageValidate.UpdateCardGroup)) == System.Windows.Forms.DialogResult.Yes)
            {
                if (!bgwUpdateEcashGroup.IsBusy)
                {
                    AddOrUpdateGroup = ToEntity();
                    bgwUpdateEcashGroup.RunWorkerAsync();
                }
            }
        }
        #endregion Load-Add-Update
    }
}
