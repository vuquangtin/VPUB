using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using Microsoft.Practices.CompositeUI;
using sWorldModel;
using CommonHelper.Constants;
using CommonHelper.Utils;
using JavaCommunication.Factory;
using CommonControls;
using sWorldModel.Exceptions;
using System.ServiceModel;
using sTimeKeeping.Model;
using CommonHelper.Config;
using Microsoft.Practices.CompositeUI.Commands;
using sTimeKeeping.Constants;
using CommonControls.Custom;
using JavaCommunication;
using sTimeKeeping.Factory;
using sWorldModel.TransportData;
using sWorldModel.Filters;

namespace sTimeKeeping.WorkItems
{
    public partial class UsrDeviceConfig : CommonUserControl
    {
        #region Properties
        //load orgList
        private BackgroundWorker bgwLoadOrgList;
        private BackgroundWorker bgwLoadDeviceListByOrg;

        private DataTable dtbDeviceDoorList;
        // Selected tree node; cache it to do some effect in UI
        private Font startupNodeFont;
        private TreeNode selectedOrgNode;
        private TreeNode rootNode;
        private ResourceManager rm;
        private List<OrgCustomerDto> listOrg;
        private TimeKeepingComponentWorkItem workItem;
        [ServiceDependency]
        public TimeKeepingComponentWorkItem WorkItem
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
        #endregion

        #region Contructors

        public UsrDeviceConfig()
        {
            InitializeComponent();
            InitDataTableDeviceConfig();
            RegisterEvent();
        }

        /// <summary>
        /// Đăng ký sự kiện
        /// </summary>
        private void RegisterEvent()
        {
            //Tree View
            trvOrganizations.BeforeSelect += trvOrganizations_BeforeSelect;
            trvOrganizations.AfterSelect += trvOrganizations_AfterSelect;

            //Load Tree View
            bgwLoadOrgList = new BackgroundWorker();
            bgwLoadOrgList.WorkerSupportsCancellation = true;
            bgwLoadOrgList.DoWork += bgwLoadOrgList_DoWork;
            bgwLoadOrgList.RunWorkerCompleted += bgwLoadOrgList_RunWorkerCompleted;

            //Load DeviceList by orgId
            bgwLoadDeviceListByOrg = new BackgroundWorker();
            bgwLoadDeviceListByOrg.WorkerSupportsCancellation = true;
            bgwLoadDeviceListByOrg.DoWork += bgwLoadDeviceDoorListByOrg_DoWork;
            bgwLoadDeviceListByOrg.RunWorkerCompleted += bgwLoadDeviceDoorListByOrg_RunWorkerCompleted;


            //Add - Update - Deleted 
            tsbcheck.Click += btnSaveDeviceConfig_Click;
            //chuot phai reload item tree
            btnRefreshOrg.Click += (s, e) => LoadOrgList();
            mniReloadOrgs.Click += (s, e) => LoadOrgList();
            //btnAdd
            startupNodeFont = trvOrganizations.Font;

            Load += OnFormLoad;
        }
        /// <summary>
        /// load device door list when load usercontroll
        /// </summary>
        private void LoadDeviceDoorListByOrg()
        {
            if (!bgwLoadDeviceListByOrg.IsBusy)
            {
                dtbDeviceDoorList.Rows.Clear();
                bgwLoadDeviceListByOrg.RunWorkerAsync();
            }
        }
        /// <summary>
        /// Override hàm onFormLoad 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnFormLoad(object sender, EventArgs e)
        {
            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
            //pagerPanel1.StorageService = storageService;
            //pagerPanel1.LoadLanguage();
            InitTreeList();
            LoadOrgList();
            SetAllLabel();
        }
        #region init for languages
        private void SetAllLabel()
        {
            this.btnAddDevice.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnAddDevice.Name);
            this.btnUpdateDevice.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnUpdateDevice.Name);
            this.tsbcheck.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.tsbcheck.Name);
            this.btnReloadConfig.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnReloadConfig.Name);
            this.btnRemoveDevice.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnRemoveDevice.Name);
            this.btnShowHideFilter.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnShowHideFilter.Name);
            this.btnReload.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnRefreshOrg.Name);
            this.mniReloadOrgs.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.mniReloadOrgs.Name);
            this.btnExportToExcel.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnExportToExcel.Name);
            this.btnRefreshOrg.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnRefreshOrg.Name);
            this.lblLeftAreaTitleOrg.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.lblLeftAreaTitleOrg.Name);

            this.colDeviceNameConfig.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colDeviceNameConfig.Name);
            this.colIPConfig.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colIPConfig.Name);
            this.colDesConfig.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colDesConfig.Name);
            this.colTimeKeeping.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colTimeKeeping.Name);

            this.lblRightAreaTitle_DeviceInOut.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.lblRightAreaTitle_DeviceInOut.Name);
            this.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.Name);
        }
        #endregion
        //20170603 #Bug 735 Các nút chưa ẩn hiện đúng và load không đúng logic - Ten Nguyen Start
        /// <summary>
        /// Set visible button toolstrip
        /// </summary>
        /// <param name="visible"></param>
        private void InvisibleButton(bool visible)
        {
            tsbcheck.Enabled =
            btnReloadConfig.Enabled = visible;
        }
        //20170603 #Bug 735 Viết hàm check và xử lý lại các thao tác người dùng- Ten Nguyen Start
        /// <summary>
        /// Khởi tạo tree
        /// </summary>
        private void InitTreeList()
        {
            rootNode = new TreeNode();
            rootNode.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, "All");
            rootNode.Name = "-1";
            trvOrganizations.Nodes.Add(rootNode);
        }

        /// <summary>
        /// Ham nay load danh sach cac to chuc vao tree, ham nay duoc load sau khi usercontroll duoc load
        /// </summary>
        private void LoadOrgList()
        {
            if (!bgwLoadOrgList.IsBusy)
            {
                rootNode.Nodes.Clear();
                bgwLoadOrgList.RunWorkerAsync();
            }
        }
        /// <summary>
        /// bgwLoadOrgList_DoWork
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwLoadOrgList_DoWork(object sender, DoWorkEventArgs e)
        {
            List<OrgCustomerDto> result = null;
            // filter khong xet du lieu, dung mac dinh
            OrgFilterDto filter = new OrgFilterDto();
            try
            {
                // kiem tra org co duoc hien thi hay khong
                if (!((SystemSettings.Instance.OrgCode).Equals("") || (SystemSettings.Instance.OrgCode).Equals("ALL")))
                {
                    filter.OrgCode = SystemSettings.Instance.OrgCode;
                    filter.FilterByOrgCode = true;
                }
                //lay tat ca org ve bo vao tree
                listOrg = result = OrganizationFactory.Instance.GetChannel().GetOrgList(StorageService.CurrentSessionId, filter);
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
                e.Result = result;
            }
        }
        /// <summary>
        /// bgwLoadOrgList_RunWorkerCompleted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwLoadOrgList_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }

            // Get result from DoWork method
            List<OrgCustomerDto> result = (List<OrgCustomerDto>)e.Result;
            if (result != null)
            {
                foreach (OrgCustomerDto org in result)
                {
                    // kiem tra neu khong phai to chuc phat hanh the moi add vao tree
                    if (!org.Issuer.Equals(SystemSettings.Instance.Master))
                    {

                        TreeNode DeviceDoorGroupNode = new TreeNode();
                        DeviceDoorGroupNode.Text = org.Name;
                        DeviceDoorGroupNode.Name = Convert.ToString(org.OrgId);
                        rootNode.Nodes.Add(DeviceDoorGroupNode);
                    }
                }
                trvOrganizations.Sort();
                rootNode.Expand();
            }
        }
        /// <summary>
        /// bgwTimeconfigList_DoWork
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwLoadDeviceDoorListByOrg_DoWork(object sender, DoWorkEventArgs e)
        {
            List<DeviceDoor> result = null;
            int totalRecords = 0;
            int take = LocalSettings.Instance.RecordsPerPage;
            int skip = 0;
            try
            {
                //ham lay ve list deviceConfig
                e.Result = TimeKeepingDeviceConfigFactory.Instance.GetChannel().GetListDeviceConfigByOrgId(StorageService.CurrentSessionId, Convert.ToInt64(selectedOrgNode.Name));//GetListDeviceConfigByOrgId(StorageService.CurrentSessionId, Convert.ToInt64(selectedOrgNode.Name));
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
                result = (List<DeviceDoor>)e.Result;

            }
        }
        /// <summary>
        /// bgwTimeConfigList_RunWorkerCompleted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwLoadDeviceDoorListByOrg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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
            List<DeviceDoor> result = (List<DeviceDoor>)e.Result;
            LoadDeviceDoorListToDataGirdView(result);
        }

        /// <summary>
        /// trvOrganizations_BeforeSelect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trvOrganizations_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            // If background worker is running -> restrict selecting another node
            if (bgwLoadOrgList.IsBusy)
            {
                e.Cancel = true;
                return;
            }
            // Change node font style to normal
            if (selectedOrgNode != null)
            {
                selectedOrgNode.NodeFont = new Font(startupNodeFont, FontStyle.Regular);
                selectedOrgNode.Text = selectedOrgNode.Text;
            }
        }
        /// <summary>
        /// trvOrganizations_AfterSelect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trvOrganizations_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectedNode = e.Node;
            TreeNode parentNode = new TreeNode();
            if (selectedNode != null)
            {
                parentNode = selectedNode.Parent;
                selectedNode.NodeFont = new Font(startupNodeFont, FontStyle.Bold);
                selectedNode.Text = selectedNode.Text;
                //20170603 #Bug 735 Các nút chưa ẩn hiện đúng và load không đúng logic - Ten Nguyen Start
                if (selectedNode.Level == 0)
                {
                    InvisibleButton(false);
                    dtbDeviceDoorList.Rows.Clear();
                    
                }
                //20170603 #Bug 735 Các nút chưa ẩn hiện đúng và load không đúng logic - Ten Nguyen Start
                else
                {
                    selectedOrgNode = selectedNode;
                    LoadDeviceDoorListByOrg();
                    lblTimeKeeping.Text = MessageValidate.GetMessage(rm, "lblTimeKeepingChoose");
                    SetShowOrHideUpdateOrg();
                    InvisibleButton(true);
                }
            }
        }
        /// <summary>
        /// InitDataTableTimeConfig
        /// </summary>
        private void InitDataTableDeviceConfig()
        {
            dtbDeviceDoorList = new DataTable();
            dtbDeviceDoorList.Columns.Add(colDeviceDoorId.DataPropertyName);
            dtbDeviceDoorList.Columns.Add(colDeviceNameConfig.DataPropertyName);
            dtbDeviceDoorList.Columns.Add(colIPConfig.DataPropertyName);
            dtbDeviceDoorList.Columns.Add(colTimeKeeping.DataPropertyName);
            dtbDeviceDoorList.Columns.Add(colDesConfig.DataPropertyName);

            dgvDeviceDoorList.DataSource = dtbDeviceDoorList;
        }

        /// <summary>
        /// Load danh sach cac cau thiet bi dua vao orgId
        /// </summary>
        /// <param name="orgId"></param>
        private void LoadDeviceDoorListToDataGirdView(List<DeviceDoor> listDevice)
        {
            foreach (DeviceDoor deviceDoor in listDevice)
            {
                DataRow row = dtbDeviceDoorList.NewRow();
                row.BeginEdit();
                row[colDeviceDoorId.DataPropertyName] = deviceDoor.Id;
                row[colDeviceNameConfig.DataPropertyName] = deviceDoor.Name;
                row[colIPConfig.DataPropertyName] = deviceDoor.Ip;
                row[colDesConfig.DataPropertyName] = deviceDoor.Description;
                row[colTimeKeeping.DataPropertyName] = deviceDoor.deviceTimekeeping;
                row.EndEdit();
                dtbDeviceDoorList.Rows.Add(row);
            }
        }
        /// <summary>
        /// Set an hoac hien cac button add va update
        /// </summary>
        private void SetShowOrHideUpdateOrg()
        {
            bool checkUpdate = selectedOrgNode != null && Convert.ToInt64(selectedOrgNode.Name) > 0;
        }

        /// <summary>
        /// Ham nay dung de Get selected device trong table de nguoi dung chon vao gui len server de add theo group device
        /// </summary>
        /// <returns></returns>
        private List<DeviceConfig> GetSelectedDeviceDoor()
        {
            List<DeviceConfig> selectedDevice = new List<DeviceConfig>();
            //truoc khi su dung datagriview nen them dong lenh nay vao de dam bao viec\
            //thao tac tren datagridview da hoan tat
            dgvDeviceDoorList.EndEdit();
            foreach (DataGridViewRow row in dgvDeviceDoorList.Rows)
            {
                //lay ra nhung dong co check cham cong
                bool check = Convert.ToBoolean(row.Cells[colTimeKeeping.Name].Value);
                if (check)
                {
                    DeviceConfig deviceConfig = new DeviceConfig();
                    deviceConfig.deviceDoorId = Convert.ToInt32(row.Cells[colDeviceDoorId.Name].Value.ToString());
                    deviceConfig.deviceName = row.Cells[colDeviceNameConfig.Name].Value.ToString();
                    deviceConfig.ip = row.Cells[colIPConfig.Name].Value.ToString();
                    deviceConfig.deviceDescription = row.Cells[colDesConfig.Name].Value.ToString();
                    selectedDevice.Add(deviceConfig);
                }
            }
            return selectedDevice;
        }

        /// <summary>
        /// Ham nay dung de them cac thiet bi nguoi dung chon vao nhom
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveDeviceConfig_Click(object sender, EventArgs e)
        {
            List<DeviceConfig> lstDevice = GetSelectedDeviceDoor();

            long orgId = Convert.ToInt64(selectedOrgNode.Name);
            bool resultAdd = false;
            if (MessageBoxManager.ShowQuestionMessageBox(this, MessageValidate.GetMessage(rm, "deviceconfigTimekeeping"), MessageValidate.GetConfirm(rm)) == DialogResult.Yes)
            {
                if (orgId != -1)
                {
                    try
                    {
                        //neu co chon to chuc moi add
                        resultAdd = (int)Status.SUCCESS == TimeKeepingDeviceConfigFactory.Instance.GetChannel().InsertDeviceByOrgId(StorageService.CurrentSessionId, orgId, lstDevice);//InsertDeviceByOrgId(StorageService.CurrentSessionId, orgId, lstDevice);
                    }
                    catch (TimeoutException)
                    {
                        MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "TimeOutExceptionMessage"));
                    }
                    catch (FaultException<WcfServiceFault> ex)
                    {
                        //    MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
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
                if (resultAdd)
                {
                    LoadDeviceDoorListByOrg();
                }
                else
                {
                    MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "AddDeviceFail"));
                    LoadDeviceDoorListByOrg();
                }
            }
        }

        #region CAB events
        [CommandHandler(TimeCommandName.ShowDeviceConfig)]
        public void ShowDeviceConfig(object s, EventArgs e)
        {
            UsrDeviceConfig ucConfig = workItem.Items.Get<UsrDeviceConfig>(DefineName.DeviceConfig);
            if (ucConfig == null)
            {
                ucConfig = workItem.Items.AddNew<UsrDeviceConfig>(DefineName.DeviceConfig);
            }
            else if (ucConfig.IsDisposed)
            {
                workItem.Items.Remove(ucConfig);
                ucConfig = workItem.Items.AddNew<UsrDeviceConfig>(DefineName.DeviceConfig);
            }
            workItem.Workspaces[WorkspaceName.MainWorkspace].Show(ucConfig);
            ucConfig.Parent.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, DefineName.DeviceConfig);
        }
        #endregion
        private void btnReloadConfig_Click(object sender, EventArgs e)
        {
            LoadDeviceDoorListByOrg();
        }
    }
    #endregion
}

