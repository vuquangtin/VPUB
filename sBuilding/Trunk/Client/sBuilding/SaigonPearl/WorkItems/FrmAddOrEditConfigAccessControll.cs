using CommonControls;
using CommonHelper.Config;
using CommonHelper.Constants;
using CommonHelper.Utils;
using Microsoft.Practices.CompositeUI;
using sBuildingCommunication.Factory;
using sBuildingCommunication.Model;
using sWorldModel;
using sWorldModel.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Resources;
using System.ServiceModel;

namespace sAccessComponent.WorkItems {
    public partial class FrmAddOrEditConfigAccessControll : CommonControls.Custom.CommonDialog
    {
        #region Properties
        private int currentPageIndex = 1;
        public const byte ModeAdding = 1;
        public const byte ModeUpdating = 2;

        private const int SetMaxWightTxtName = 323;

        private byte OperatingMode;
        private long deviceDoorId;
        private List<RoleDTO> lstRole;
        private DataTable dtbDeviceDoorList;
        private ResourceManager rm;
        private List<DeviceDoorGroup> DeviceDoorGroupList;

        private DeviceDoorGroup DeviceDoorGroup;
        private DeviceDoorGroup AddOrUpdateDeviceDoorGroup;

        private BackgroundWorker bgwloadRoleWorker;
        private BackgroundWorker bgwLoadGroupList;
        private BackgroundWorker bgwLoadGroupDeviceDoor;
        private BackgroundWorker bgwAddDeviceDoorGroup;
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

        public FrmAddOrEditConfigAccessControll(byte operationMode, long deviceDoorId = 0)
        {
            InitializeComponent();
            RegisterEvent();
            InitDataGridViewDeviceDoor();
            this.deviceDoorId = deviceDoorId;
            this.OperatingMode = operationMode;

        }

        private void RegisterEvent()
        {
            //load list Group
            bgwLoadGroupList = new BackgroundWorker();
            bgwLoadGroupList.WorkerSupportsCancellation = true;
            bgwLoadGroupList.DoWork += bgwLoadGroupList_DoWork;
            bgwLoadGroupList.RunWorkerCompleted += bgwLoadGroup_RunWorkerCompleted;

            bgwloadRoleWorker = new BackgroundWorker();
            bgwloadRoleWorker.WorkerSupportsCancellation = true;
            bgwloadRoleWorker.DoWork += OnloadRoleWorkerDoWork;
            bgwloadRoleWorker.RunWorkerCompleted += OnloadRoleWorkerCompleted;

            btnConfirm.Click += OnButtonConfirmClicked;
            btnCancel.Click += OnButtonCancelClicked;
            btnRefresh.Click += OnButtonRefreshClicked;
            //pagerPanel1.LinkLabelClicked += pagerPanel_LinkLabelClicked;
            Shown += OnFormShown;
        }
        protected override void OnLoad(EventArgs e) {
            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);

            LoadDeviceDoorList();
            // Set Language
            SetLanguage();
        }

        #region Set Language
        private void SetLanguage() {
            this.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.Name);
            this.lblGroupDevice.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.lblGroupDevice.Name);
            this.btnConfirm.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnConfirm.Name);
            this.btnRefresh.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnRefresh.Name);
            this.btnCancel.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnCancel.Name);
            this.colNameGroup.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colNameGroup.Name);
            this.colDescription.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colDescription.Name);
            this.colStatus.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colStatus.Name);
        }
        #endregion

        #region Event's

        private void OnFormShown(object sender, EventArgs e)
        {
            // btnConfirm.Enabled = btnRefresh.Enabled = true;
            //  Switch view to corresponding mode
            switch (OperatingMode)
            {
                case ModeAdding:
                    InitFormAddGroupDeviceDoor();
                    break;
                case ModeUpdating:
                    InitFormUpdateDeviceDoor();
                    //LoadDeviceDoor();
                    break;
                default:
                    throw new ArgumentException("Invalid operating mode!");
            }
            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
        }

        #region DeviceDoorlication

       public void loadGroupDevice()
        {
            if (!bgwloadRoleWorker.IsBusy)
            {
                bgwloadRoleWorker.RunWorkerAsync();
            }
        }
        private void InitDataGridViewDeviceDoor()
        {
            dtbDeviceDoorList = new DataTable();
            dtbDeviceDoorList.Columns.Add(colIdGroup.DataPropertyName);
            dtbDeviceDoorList.Columns.Add(colNameGroup.DataPropertyName);
            dtbDeviceDoorList.Columns.Add(colDescription.DataPropertyName);
            dgvDeviceDoorList.DataSource = dtbDeviceDoorList;
        }
        private void OnloadRoleWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            List<RoleDTO> result = null;

            try
            {
                lstRole = AccessFactory.Instance.GetChannel().GetRoleList(StorageService.CurrentSessionId);
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
                e.Result = lstRole;
            }
        }

        private void OnloadRoleWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }

            // Get result from DoWork method
            List<RoleDTO> result = (List<RoleDTO>)e.Result;
            if (result != null)
            {
            }
        }
        private void LoadDeviceDoorList()
        {
            if (!bgwLoadGroupList.IsBusy)
            {
                dtbDeviceDoorList.Rows.Clear();
                pagerPanel1.ShowMessage("Đang tải dữ liệu, xin hãy chờ...");
                bgwLoadGroupList.RunWorkerAsync();
            }
        }

        private void LoadDeviceDoorDataGridView(List<DeviceDoorGroup> result)
        {
            foreach (DeviceDoorGroup deviceDoorGroup in result)
            {
                DataRow row = dtbDeviceDoorList.NewRow();
                row.BeginEdit();

                row[colIdGroup.DataPropertyName] = deviceDoorGroup.deviceDoorGroupId;
                row[colNameGroup.DataPropertyName] = deviceDoorGroup.deviceDoorGroupName;
                row[colDescription.DataPropertyName] = deviceDoorGroup.description;
                row.EndEdit();
                dtbDeviceDoorList.Rows.Add(row);
            }
        }

        #endregion
        private void OnLoadAddGroupDeviceWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            List<DeviceDoorGroup> lstDeviceDoorGroup = new List<DeviceDoorGroup>();
            try
            {
                //e.Result = DeviceDoorGroup = AccessFactory.Instance.GetChannel().InsertDeviceDoorGroup(StorageService.CurrentSessionId, lstDeviceDoorGroup);
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
            if (null != e.Result)
            {
                //new khac null moi lam tiep o day
            }
        }

        private void OnLoadAddGroupDeviceDoorWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if (e.Result != null)
            {
                MessageBoxManager.ShowInfoMessageBox(this, "Đã thêm thiết bị vào/ra cửa mới thành công!");
                PostAction = DialogPostAction.SUCCESS;
                Hide();
            }
        }

        private void OnLoadUpdateDeviceDoorWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                //e.Result = (int)Status.SUCCESS == AccessFactory.Instance.GetChannel().UpdateDeviceDoor(StorageService.CurrentSessionId, AddOrUpdateDeviceDoorGroup);
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
                MessageBoxManager.ShowInfoMessageBox(this, "Đã cập nhật thiết bị vào/ra cửa thành công!");
                PostAction = DialogPostAction.SUCCESS;
                Hide();
            }
        }
        private List<DeviceDoorGroup> getSelectDeviceDoor()
        {
            var selectedRows = dgvDeviceDoorList.SelectedRows;
            int rowsCount = selectedRows.Count;
            string checkPerso = string.Empty;
            if (rowsCount == 0)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessSelect(rm, MessageValidate.CardRequiredMem), MessageValidate.GetErrorTitle(rm));
            }

            // Get selected device
            List<DeviceDoorGroup> selectedDevice = new List<DeviceDoorGroup>();
            for (int i = 0; i < rowsCount; i++)
            {
                DeviceDoorGroup deviceDoorGroup = new DeviceDoorGroup();
                long id = Convert.ToInt32(selectedRows[i].Cells[colIdGroup.Name].Value.ToString());
                string deviceDoorName = selectedRows[i].Cells[colNameGroup.Name].Value.ToString();
                deviceDoorGroup.deviceDoorGroupId = id;
                deviceDoorGroup.deviceDoorGroupName = deviceDoorName;
                selectedDevice.Add(deviceDoorGroup);
            }
            return selectedDevice;
        }
        #endregion

        #region Buttons

        private void OnButtonConfirmClicked(object sender, EventArgs e)
        {
            switch (OperatingMode)
            {
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

        private void OnButtonRefreshClicked(object sender, EventArgs e)
        {
            ClearEmptyControl();
        }

        private void OnButtonCancelClicked(object sender, EventArgs e)
        {
            this.Hide();
        }

        #endregion

        #region Event's support

        #region Binding Data

        private void ToModel(DeviceDoorGroup deviceDoorGroup)
        {
            //txtDeviceDoorCode.Text = DeviceDoor.DeviceDoorCode;
            //txtName.Text = deviceDoorGroup.deviceDoorGroupName;

        }

        private DeviceDoorGroup ToEntity()
        {
            DeviceDoorGroup deviceDoorGroup = new DeviceDoorGroup();
            deviceDoorGroup = DeviceDoorGroup != null ? DeviceDoorGroup : deviceDoorGroup;

            //deviceDoorGroup.deviceDoorGroupName = txtName.Text.Trim();


            return deviceDoorGroup;
        }

        #endregion

        #region SetControl

        private void ClearEmptyControl()
        {
            //txtName.Text =
            //txtName.Focus();
        }

        //private void SetControl(bool isView)
        //{
        //    //txtDeviceDoorCode.ReadOnly =
        //    txtDeviceDoorName.ReadOnly =
        //    tbxIP.ReadOnly = isView;
        //}
        //private void pagerPanel_LinkLabelClicked(object s, LinkLabelClickedArgs e)
        //{
        //    int i;
        //    if (e.LabelText.Equals(PagerPanel.LabelBackText))
        //    {
        //        currentPageIndex -= 1;
        //    }
        //    else if (e.LabelText.Equals(PagerPanel.LabelNextText))
        //    {
        //        currentPageIndex += 1;
        //    }
        //    else if (int.TryParse(e.LabelText, out i))
        //    {
        //        currentPageIndex = i;
        //    }
        //    else
        //    {
        //        return;
        //    }
        //    dtbDeviceDoorList.Rows.Clear();
        //    int take = LocalSettings.Instance.RecordsPerPage;
        //    int skip = (currentPageIndex - 1) * take;

            //List<DeviceDoorGroupList> result = DeviceDoorGroupList.Skip(skip).Take(take).ToList();
            //LoadDeviceDoorDataGridView(result);

            //pagerPanel1.ShowNumberOfRecords(DeviceDoorGroupList.Count, result != null ? result.Count : 0, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
            //pagerPanel1.UpdatePagingLinks(DeviceDoorGroupList.Count, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
        //}
        private void SetShowOrHideButton(bool isView)
        {
            btnConfirm.Enabled = btnRefresh.Enabled = isView;
        }

        #endregion

        #region ValidateData

        private bool ValidateData()
        {
            //if (string.IsNullOrEmpty(txtDeviceDoorCode.Text))
            //{
            //    MessageBoxManager.ShowErrorMessageBox(this, "Bạn chưa nhập mã thiết bị vào/ra cửa!", "Thao Tác Sai");
            //    return false;
            //}

            ////if (string.IsNullOrEmpty(txtName.Text))
            ////{
            ////    MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessageValidate(rm, MessageValidate.DeviceDoorName), MessageValidate.GetErrorTitle(rm));
            ////    return false;
            ////}
            return true;
        }

        #endregion

        #region DeviceDoorlication

        private void InitFormAddGroupDeviceDoor()
        {
            //this.Text = lblThemUngDung.Text = "Thêm Thiết Bị Vào/Ra Cửa Mới";
            //lbNote.Text = "Thêm một thiết bị vào/ra cửa mới vào hệ thống.";
            //SetControl(false);
            SetShowOrHideButton(true);
            loadGroupDevice();
            LoadDeviceDoorList();
            //ClearEmptyControl();



            // add group
            bgwAddDeviceDoorGroup = new BackgroundWorker();
            bgwAddDeviceDoorGroup.WorkerSupportsCancellation = true;
            bgwAddDeviceDoorGroup.DoWork += OnLoadAddGroupDeviceWorkerDoWork;
            bgwAddDeviceDoorGroup.RunWorkerCompleted += OnLoadAddGroupDeviceDoorWorkerRunWorkerCompleted;
        }
        void bgwLoadGroupList_DoWork(object sender, DoWorkEventArgs e)
        {
            List<DeviceDoorGroup> result = null;
            int totalRecords = 0;
            int take = LocalSettings.Instance.RecordsPerPage;
            int skip = 0;
            currentPageIndex = 1;
            try
            {
                DeviceDoorGroupList = AccessFactory.Instance.GetChannel().GetDeviceDoorGroupList(StorageService.CurrentSessionId);
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
                if (DeviceDoorGroupList != null)
                {
                    result = DeviceDoorGroupList.Skip(skip).Take(take).ToList();
                    totalRecords = DeviceDoorGroupList.Count;
                    pagerPanel1.ShowNumberOfRecords(totalRecords, result != null ? result.Count : 0, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
                    pagerPanel1.UpdatePagingLinks(totalRecords, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
                }
                e.Result = result;
            }
        }

        void bgwLoadGroup_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if (e.Result == null)
            {
                return;
            }
            // Get result from DoWork method
            List<DeviceDoorGroup> result = (List<DeviceDoorGroup>)e.Result;
            LoadDeviceDoorDataGridView(result);
        }

        #endregion
        private void InitFormUpdateDeviceDoor()
        {
            //this.Text = lblThemUngDung.Text = "Cập Nhật Thông Tin Thiết Bị Vào/Ra Cửa";
            //lbNote.Text = "Cập nhật thiết bị vào/ra cửa trong hệ thống.";
            //SetControl(false);
            SetShowOrHideButton(true);
            // get device to update
            //bgwLoadGroupDeviceDoor = new BackgroundWorker();
            //bgwLoadGroupDeviceDoor.WorkerSupportsCancellation = true;
            //bgwLoadGroupDeviceDoor.DoWork += OnLoadDeviceDoorWorkerDoWork;
            //bgwLoadGroupDeviceDoor.RunWorkerCompleted += OnLoadDeviceDoorWorkerRunWorkerCompleted;
            // update group device
            bgwUpdateDeviceDoor = new BackgroundWorker();
            bgwUpdateDeviceDoor.WorkerSupportsCancellation = true;
            bgwUpdateDeviceDoor.DoWork += OnLoadUpdateDeviceDoorWorkerDoWork;
            bgwUpdateDeviceDoor.RunWorkerCompleted += OnLoadUpdateDeviceDoorWorkerRunWorkerCompleted;
        }



        private void AddGroupDeviceDoor()
        {
            if (ValidateData() && MessageBoxManager.ShowQuestionMessageBox(this, "Bạn có chắc muốn thực hiện thao tác này không?") == System.Windows.Forms.DialogResult.Yes)
            {
                if (!bgwAddDeviceDoorGroup.IsBusy)
                {
                    AddOrUpdateDeviceDoorGroup = ToEntity();
                    bgwAddDeviceDoorGroup.RunWorkerAsync();
                }
            }
        }

        private void UpdateDeviceDoor()
        {
            if (ValidateData() && MessageBoxManager.ShowQuestionMessageBox(this, "Bạn có chắc muốn cập nhật thiết bị vào/ra cửa này không?") == System.Windows.Forms.DialogResult.Yes)
            {
                if (!bgwUpdateDeviceDoor.IsBusy)
                {
                    AddOrUpdateDeviceDoorGroup = ToEntity();
                    bgwUpdateDeviceDoor.RunWorkerAsync();
                }
            }
        }

        #endregion

    }
}

