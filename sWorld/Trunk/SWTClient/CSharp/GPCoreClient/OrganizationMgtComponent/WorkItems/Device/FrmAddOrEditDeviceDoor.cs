using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sWorldModel.TransportData;
using CommonControls;
using System.ServiceModel;
using sWorldModel.Exceptions;
using JavaCommunication.Factory;
using sWorldModel;
using Microsoft.Practices.CompositeUI;
using JavaCommunication;
using System.Resources;
using CommonHelper.Constants;
using CommonHelper.Utils;
using CommonHelper.Config;
using System.Text.RegularExpressions;

namespace SystemMgtComponent.WorkItems
{
    public partial class FrmAddOrEditDeviceDoor : CommonControls.Custom.CommonDialog
    {
        #region Properties

        public const byte ModeAdding = 1;
        public const byte ModeUpdating = 2;

        private const int SetMaxWightTxtName = 323;

        private byte OperatingMode;
        private long deviceDoorId;
        private ResourceManager rm;

        private DeviceDoor OriginalDeviceDoor;
        private DeviceDoor AddOrUpdateDeviceDoor;

        private BackgroundWorker bgwLoadDeviceDoor;
        private BackgroundWorker bgwAddDeviceDoor;
        private BackgroundWorker bgwUpdateDeviceDoor;

        public DialogPostAction PostAction { get; private set; }

        private ILocalStorageService storageService;
        [ServiceDependency]
        public ILocalStorageService StorageService
        {
            get { return storageService; }
            set { storageService = value; }
        }

        #endregion      

        public FrmAddOrEditDeviceDoor(byte operationMode, long deviceDoorId = 0)
        {
            InitializeComponent();
            RegisterEvent();
            this.deviceDoorId = deviceDoorId;
            this.OperatingMode = operationMode;
            
        }

        private void RegisterEvent()
        {
            btnCancel.Click += OnButtonCancelClicked;
            btnConfirm.Click += OnButtonConfirmClicked;
            btnRefresh.Click += OnButtonRefreshClicked;
            Shown += OnFormShown;
        }
       
        #region Set Language
        private void SetLanguage() {
            this.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.Name);
            this.lblAddDeviceIO.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.lblAddDeviceIO.Name);
            this.lblNoteAddDeviceIO.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.lblNoteAddDeviceIO.Name);
            this.lblInfoAddDeviceIO.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.lblInfoAddDeviceIO.Name);
            this.btnConfirm.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnConfirm.Name);
            this.btnRefresh.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnRefresh.Name);
            this.btnCancel.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnCancel.Name);
            this.lblDeviceName.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.lblDeviceName.Name);
            this.lblIP.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.lblIP.Name);
            this.lblBuilding.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.lblBuilding.Name);
            this.lblDescription.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.lblDescription.Name);
        }
        #endregion

        #region Event's

        private void OnFormShown(object sender, EventArgs e)
        {
            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
           
            // Set Language
            SetLanguage();
            // btnConfirm.Enabled = btnRefresh.Enabled = true;
            //  Switch view to corresponding mode
            switch (OperatingMode)
            {
                case ModeAdding:
                    InitFormAddDeviceDoor();
                    break;
                case ModeUpdating:
                    InitFormUpdateDeviceDoor();
                    LoadDeviceDoor();
                    break;
                default:
                    throw new ArgumentException("Invalid operating mode!");
            }
            GetOrgList();
        }

        #region DeviceDoorlication

        private void OnLoadDeviceDoorWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                OriginalDeviceDoor = AccessFactory.Instance.GetChannel().GetDeviceDoorById(StorageService.CurrentSessionId, deviceDoorId);
                e.Result = true;
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

        private void OnLoadDeviceDoorWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if (e.Result != null)
            {
                ToModel(OriginalDeviceDoor);
                //PopulateGroupDataToView();
                //btnConfirm.Enabled = btnRefresh.Enabled = true;
            }
        }

        private void OnLoadAddOrgWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = OriginalDeviceDoor = AccessFactory.Instance.GetChannel().InsertDeviceDoor(StorageService.CurrentSessionId, AddOrUpdateDeviceDoor);
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

        private void OnLoadAddDeviceDoorWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

        private void OnLoadUpdateDeviceDoorWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = (int)Status.SUCCESS == AccessFactory.Instance.GetChannel().UpdateDeviceDoor(StorageService.CurrentSessionId, AddOrUpdateDeviceDoor);
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
        private void OnLoadUpdateDeviceDoorWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

        #region Buttons

        private void OnButtonConfirmClicked(object sender, EventArgs e)
        {
            switch (OperatingMode)
            {
                case ModeAdding:
                    AddDeviceDoor();
                    break;
                case ModeUpdating:
                    UpdateDeviceDoor();
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

        #endregion

        #region Event's support

        #region Binding Data

        private void ToModel(DeviceDoor deviceDoor)
        {
            //txtDeviceDoorCode.Text = DeviceDoor.DeviceDoorCode;
            txtDeviceDoorName.Text = deviceDoor.Name;
            tbxIP.Text = deviceDoor.Ip;
            cbxOrgCode.SelectedItem = deviceDoor.Port;
            txtDescription.Text = deviceDoor.Status;

            dtpOpenDoor.Value = string.IsNullOrEmpty(deviceDoor.TimeOpen) ? DateTime.Now : Convert.ToDateTime(deviceDoor.TimeOpen);
            dtpCloseDoor.Value = string.IsNullOrEmpty(deviceDoor.TimeClose) ? DateTime.Now : Convert.ToDateTime(deviceDoor.TimeClose);
            cbxLocked.Checked = deviceDoor.Locked;
            txtDescription.Text = deviceDoor.Description;
        }

        private DeviceDoor ToEntity()
        {
            DeviceDoor deviceDoor = new DeviceDoor();
            deviceDoor = OriginalDeviceDoor != null ? OriginalDeviceDoor : deviceDoor;

            deviceDoor.Name = txtDeviceDoorName.Text.Trim();
            deviceDoor.Ip = tbxIP.Text.Trim();
            deviceDoor.Port = cbxOrgCode.SelectedValue.ToString();
            deviceDoor.Status = txtDescription.Text.Trim();
            deviceDoor.TimeOpen = dtpOpenDoor.Checked ? dtpOpenDoor.Value.ToString("HH:mm:ss") : string.Empty;
            deviceDoor.TimeClose = dtpCloseDoor.Checked ? dtpCloseDoor.Value.ToString("HH:mm:ss") : string.Empty;
            deviceDoor.Locked = cbxLocked.Checked;
            deviceDoor.Description = txtDescription.Text.Trim();

            return deviceDoor;
        }

        #endregion

        #region SetControl

        private void ClearEmptyControl()
        {
            txtDeviceDoorName.Text =
            tbxIP.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtDeviceDoorName.Focus();
        }

        private void SetControl(bool isView)
        {
            //txtDeviceDoorCode.ReadOnly =
            txtDeviceDoorName.ReadOnly =
            tbxIP.ReadOnly = isView;
        }

        private void SetShowOrHideButton(bool isView)
        {
            btnConfirm.Enabled = btnRefresh.Enabled = isView;
        }

        #endregion

        #region ValidateData

        private bool ValidateData()
        {
            if (string.IsNullOrEmpty(tbxIP.Text))
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm,"pleaseenterip"));
                return false;
            }

            if (string.IsNullOrEmpty(txtDeviceDoorName.Text))
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessageValidate(rm, MessageValidate.DeviceDoorName), MessageValidate.GetErrorTitle(rm));
                return false;
            }
            if (!ValidaIp(tbxIP.Text))
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "formatIp"));
                return false;
            }
            return true;
        }

        #endregion
        /// <summary>
        /// Ham kiểm tra hợp lệ IP
        ///
        /// </summary>
        /// <param name="ipStr"></param>
        /// <returns></returns>
        public bool ValidaIp(string ipStr)
        {
            string pattern = @"^([1-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])(\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])){3}$";
            Regex check = new Regex(pattern);
            bool valid = false;
            if (ipStr == "")
            {
                valid = false;
            }
            else
            {
                valid = check.IsMatch(ipStr, 0);
            }
            return valid;
        }
        #region DeviceDoorlication

        private void InitFormAddDeviceDoor()
        {
            this.Text = lblAddDeviceIO.Text = MessageValidate.GetMessage(rm, "lblAddDeviceIO");
            lblNoteAddDeviceIO.Text = MessageValidate.GetMessage(rm, "lblNoteAddDeviceIO");
            SetControl(false);
            SetShowOrHideButton(true);
            ClearEmptyControl();

            bgwAddDeviceDoor = new BackgroundWorker();
            bgwAddDeviceDoor.WorkerSupportsCancellation = true;
            bgwAddDeviceDoor.DoWork += OnLoadAddOrgWorkerDoWork;
            bgwAddDeviceDoor.RunWorkerCompleted += OnLoadAddDeviceDoorWorkerRunWorkerCompleted;
        }

        private void InitFormUpdateDeviceDoor()
        {
            this.Text = lblAddDeviceIO.Text = MessageValidate.GetMessage(rm, "lblupdateDeviceIO");
            lblNoteAddDeviceIO.Text = MessageValidate.GetMessage(rm, "lblNoteUpdateDeviceIO");
            SetControl(false);
            SetShowOrHideButton(true);

            bgwLoadDeviceDoor = new BackgroundWorker();
            bgwLoadDeviceDoor.WorkerSupportsCancellation = true;
            bgwLoadDeviceDoor.DoWork += OnLoadDeviceDoorWorkerDoWork;
            bgwLoadDeviceDoor.RunWorkerCompleted += OnLoadDeviceDoorWorkerRunWorkerCompleted;

            bgwUpdateDeviceDoor = new BackgroundWorker();
            bgwUpdateDeviceDoor.WorkerSupportsCancellation = true;
            bgwUpdateDeviceDoor.DoWork += OnLoadUpdateDeviceDoorWorkerDoWork;
            bgwUpdateDeviceDoor.RunWorkerCompleted += OnLoadUpdateDeviceDoorWorkerRunWorkerCompleted;
        }

        private void LoadDeviceDoor()
        {
            if (!bgwLoadDeviceDoor.IsBusy && deviceDoorId > 0)
            {
                bgwLoadDeviceDoor.RunWorkerAsync();
            }
        }

        private void AddDeviceDoor()
        {
            if (ValidateData() && MessageBoxManager.ShowQuestionMessageBox(this, MessageValidate.GetQuestionAdd(rm,MessageValidate.Device)) == System.Windows.Forms.DialogResult.Yes)
            {
                if (!bgwAddDeviceDoor.IsBusy)
                {
                    AddOrUpdateDeviceDoor = ToEntity();
                    bgwAddDeviceDoor.RunWorkerAsync();
                }
            }
        }

        private void UpdateDeviceDoor()
        {
            if (ValidateData() && MessageBoxManager.ShowQuestionMessageBox(this, MessageValidate.GetQuestionUpdate(rm,MessageValidate.Device)) == System.Windows.Forms.DialogResult.Yes)
            {
                if (!bgwUpdateDeviceDoor.IsBusy)
                {
                    AddOrUpdateDeviceDoor = ToEntity();
                    bgwUpdateDeviceDoor.RunWorkerAsync();
                }
            }
        }

        #endregion

        private void GetOrgList()
        {
            List<CmsOrgCustomerDto> result = new List<CmsOrgCustomerDto>();
            try
            {
                result = OrganizationFactory.Instance.GetChannel().GetAllOrgList(StorageService.CurrentSessionId);
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
            finally
            {
                cbxOrgCode.DataSource = result.Where(o => !o.Issuer.Equals(SystemSettings.Instance.Master)).ToList();
                cbxOrgCode.ValueMember = "OrgCode";
                cbxOrgCode.DisplayMember = "Name";
                cbxOrgCode.SelectedIndex = 0;
            }
        }

        #endregion

        
    }
}
