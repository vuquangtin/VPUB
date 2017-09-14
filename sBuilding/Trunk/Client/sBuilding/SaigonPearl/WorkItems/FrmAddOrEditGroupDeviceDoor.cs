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
using sWorldModel.TransportData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Resources;
using System.ServiceModel;

namespace sAccessComponent.WorkItems {
    public partial class FrmAddOrEditGroupDeviceDoor : CommonControls.Custom.CommonDialog {
        #region Properties
        private int currentPageIndex = 1;
        public const byte ModeAdding = 1;
        public const byte ModeUpdating = 2;

        private const int SetMaxWightTxtName = 323;

        private byte OperatingMode;
        private long deviceDoorGroupId;
        private List<DeviceDoor> lstDevice;
        private DataTable dtbDeviceDoorList;
        private ResourceManager rm;
        private List<DeviceDoor> DeviceDoorList;

        private DeviceDoorGroup DeviceDoorGroup;
        private DeviceDoorGroupDeviceDoorDTO DeviceDoorGroupDeviceDoor;
        private DeviceDoorGroup AddOrUpdateDeviceDoorGroup;


        private BackgroundWorker bgwLoadDeviceDoorGroup;
        private BackgroundWorker bgwAddDeviceDoorGroup;
        private BackgroundWorker bgwUpdateDeviceDoorGroup;

        public DialogPostAction PostAction { get; private set; }

        private ILocalStorageService storageService;
        [ServiceDependency]
        public ILocalStorageService StorageService {
            get { return storageService; }
            set { storageService = value; }
        }

        #endregion
        #region Contrustor
        public FrmAddOrEditGroupDeviceDoor(byte operationMode, long deviceDoorGroupId = 0) {
            InitializeComponent();
            RegisterEvent();
            this.deviceDoorGroupId = deviceDoorGroupId;
            this.OperatingMode = operationMode;

        }
        #endregion
        #region Event's
        private void RegisterEvent() {

            btnConfirm.Click += OnButtonConfirmClicked;
            btnCancel.Click += OnButtonCancelClicked;
            btnRefresh.Click += OnButtonRefreshClicked;
            Shown += OnFormShown;
        }
        private void OnFormShown(object sender, EventArgs e) {
            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
            // Set Language
            SetLanguage();
            //  Switch view to corresponding mode
            switch (OperatingMode) {
                case ModeAdding:
                    InitFormAddGroupDeviceDoor();
                    break;
                case ModeUpdating:
                    InitFormUpdateDeviceDoor();
                    LoadGroupDeviceDoor();
                    break;
                default:
                    throw new ArgumentException("Invalid operating mode!");
            }
           
        }
        #endregion
        #region Set Language
        private void SetLanguage() {
            this.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.Name);
            this.lblNameGroupDevice.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.lblNameGroupDevice.Name);
            this.lblDescription.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.lblDescription.Name);
            this.btnConfirm.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnConfirm.Name);
            this.btnRefresh.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnRefresh.Name);
            this.btnCancel.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnCancel.Name);
        }
        #endregion

        #region LoadGroupDeviceDoor
        private void LoadGroupDeviceDoor() {
            if (!bgwLoadDeviceDoorGroup.IsBusy && deviceDoorGroupId > 0) {
                bgwLoadDeviceDoorGroup.RunWorkerAsync();
            }
        }
        private void OnLoadDeviceDoorGroupWorkerDoWork(object sender, DoWorkEventArgs e) {
            try {
              e.Result =  DeviceDoorGroup = AccessFactory.Instance.GetChannel().GetDeviceDoorGroupById(StorageService.CurrentSessionId, deviceDoorGroupId);
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

        private void OnLoadDeviceDoorGroupWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (e.Cancelled) {
                return;
            }
            if (DeviceDoorGroup == null) {
                return;
            }
            // Get result from DoWork method
            ToModel(DeviceDoorGroup);
        }
        #endregion
        #region Add group device
        private void AddGroupDeviceDoor()
        {
            if (ValidateData() && MessageBoxManager.ShowQuestionMessageBox(this, MessageValidate.GetQuestionAdd(rm, "groupDevice")) == System.Windows.Forms.DialogResult.Yes)
            {
                if (!bgwAddDeviceDoorGroup.IsBusy)
                {
                    AddOrUpdateDeviceDoorGroup = ToEntity();
                    bgwAddDeviceDoorGroup.RunWorkerAsync();
                }
            }
        }
      
        private void OnLoadAddGroupDeviceWorkerDoWork(object sender, DoWorkEventArgs e) {
            try {
                e.Result = DeviceDoorGroup = AccessFactory.Instance.GetChannel().InsertDeviceDoorGroup(StorageService.CurrentSessionId, AddOrUpdateDeviceDoorGroup);
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


        private void OnLoadAddGroupDeviceDoorWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (e.Cancelled) {
                return;
            }
            if (e.Result != null) {
                PostAction = DialogPostAction.SUCCESS;
                Hide();
            }else
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "addgroupfailed"));
            }
        }
        #endregion
        #region Update group device
        private void UpdateDeviceDoor()
        {
            if (ValidateData() && MessageBoxManager.ShowQuestionMessageBox(this, MessageValidate.GetQuestionUpdate(rm, "groupDevice")) == System.Windows.Forms.DialogResult.Yes)
            {
                if (!bgwUpdateDeviceDoorGroup.IsBusy)
                {
                    AddOrUpdateDeviceDoorGroup = ToEntity();
                    bgwUpdateDeviceDoorGroup.RunWorkerAsync();
                }
            }
        }
        
        private void OnLoadUpdateDeviceDoorWorkerDoWork(object sender, DoWorkEventArgs e) {
            try {
                e.Result = (int) Status.SUCCESS == AccessFactory.Instance.GetChannel().UpdateDeviceDoorGroup(StorageService.CurrentSessionId, AddOrUpdateDeviceDoorGroup);
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

        private void OnLoadUpdateDeviceDoorWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (e.Cancelled) {
                return;
            }
            if ((bool) e.Result) {
                PostAction = DialogPostAction.SUCCESS;
                Hide();
            }else
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, " updatefaield"));

            }
        }
        #endregion
        #region Buttons

        private void OnButtonConfirmClicked(object sender, EventArgs e) {
            switch (OperatingMode) {
                case ModeAdding:
                    AddGroupDeviceDoor();
                    break;
                case ModeUpdating:
                    UpdateDeviceDoor();
                    break;
                default:
                    break;
            }
        }

        private void OnButtonRefreshClicked(object sender, EventArgs e) {
            ClearEmptyControl();
        }

        private void OnButtonCancelClicked(object sender, EventArgs e) {
            this.Hide();
        }

        #endregion
        #region Binding Data

        private void ToModel(DeviceDoorGroup deviceDoorGroup) {
            //txtDeviceDoorCode.Text = DeviceDoor.DeviceDoorCode;
            txtName.Text = deviceDoorGroup.deviceDoorGroupName;
            txtDes.Text = deviceDoorGroup.description;

        }
     
        private DeviceDoorGroup ToEntity() {
            DeviceDoorGroup deviceDoorGroup = new DeviceDoorGroup();
            deviceDoorGroup = DeviceDoorGroup != null ? DeviceDoorGroup : deviceDoorGroup;

            deviceDoorGroup.deviceDoorGroupName = txtName.Text.Trim();
            deviceDoorGroup.description = txtDes.Text.Trim();
            return deviceDoorGroup;
        }

        #endregion

        #region SetControl

        private void ClearEmptyControl() {
            txtName.Text =
            txtDes.Text = string.Empty;
            txtName.Focus();
        }

      
        private void SetShowOrHideButton(bool isView) {
            btnConfirm.Enabled = btnRefresh.Enabled = isView;
        }

        #endregion

        #region ValidateData

        private bool ValidateData() {

            if (string.IsNullOrEmpty(txtName.Text)) {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessageValidate(rm, MessageValidate.DeviceDoorName), MessageValidate.GetErrorTitle(rm));
                return false;
            }
            return true;
        }

        #endregion

        #region Init Form Add Group device

        private void InitFormAddGroupDeviceDoor() { 
            SetShowOrHideButton(true);
            // add group
            bgwAddDeviceDoorGroup = new BackgroundWorker();
            bgwAddDeviceDoorGroup.WorkerSupportsCancellation = true;
            bgwAddDeviceDoorGroup.DoWork += OnLoadAddGroupDeviceWorkerDoWork;
            bgwAddDeviceDoorGroup.RunWorkerCompleted += OnLoadAddGroupDeviceDoorWorkerRunWorkerCompleted;
        }
        #endregion
        #region Init form update group device
        private void InitFormUpdateDeviceDoor() {
            SetShowOrHideButton(true);
            // get deviceDoorGroup to update
            bgwLoadDeviceDoorGroup = new BackgroundWorker();
            bgwLoadDeviceDoorGroup.WorkerSupportsCancellation = true;
            bgwLoadDeviceDoorGroup.DoWork += OnLoadDeviceDoorGroupWorkerDoWork;
            bgwLoadDeviceDoorGroup.RunWorkerCompleted += OnLoadDeviceDoorGroupWorkerRunWorkerCompleted;
            // update deviceDoorGroup
            bgwUpdateDeviceDoorGroup = new BackgroundWorker();
            bgwUpdateDeviceDoorGroup.WorkerSupportsCancellation = true;
            bgwUpdateDeviceDoorGroup.DoWork += OnLoadUpdateDeviceDoorWorkerDoWork;
            bgwUpdateDeviceDoorGroup.RunWorkerCompleted += OnLoadUpdateDeviceDoorWorkerRunWorkerCompleted;
        }
        #endregion
    }
}
