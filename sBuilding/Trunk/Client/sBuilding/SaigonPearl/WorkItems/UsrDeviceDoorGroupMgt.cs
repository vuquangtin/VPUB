using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sWorldModel.TransportData;
using System.Resources;
using Microsoft.Practices.CompositeUI;
using sWorldModel;
using CommonControls;
using System.ServiceModel;
using sWorldModel.Exceptions;
using CommonHelper.Constants;
using CommonHelper.Utils;
using sBuildingCommunication.Model;
using sBuildingCommunication.Factory;
using JavaCommunication;
using CommonControls.Custom;
using CommonHelper.Config;
using Microsoft.Practices.CompositeUI.Commands;
using sAccessComponent.Constants;
using sBuildingCommunication.Define;

namespace sAccessComponent.WorkItems
{
    public partial class UsrDeviceDoorGroupMgt : CommonUserControl
    {
        #region Properties
        //load devicedoorlist
        private BackgroundWorker bgwLoadDeviceDoorList;
        //get devicedoor group list for show tree
        private BackgroundWorker bgwloadDeviceDoorGroupWorker;
        //load object devicedoorGroup by id
        private BackgroundWorker bgwloadDeviceDoorGroupByIdWorker;
        private int currentPageIndex = 1;
        private DataTable dtbDeviceDoorList;
        private List<DeviceDoor> DeviceDoorList;
        // Selected tree node; cache it to do some effect in UI
        private List<long> lstIdGroupBeforeCheck;
        private List<DeviceDoorGroupDeviceDoorDTO> lstIdGroupAfterCheck;


        private Font startupNodeFont;
        private TreeNode selectedOrgNode;
        private TreeNode selectedOrgParentNode;
        private TreeNode rootNode;
        private MasterInfoDTO masterInfo;
        private ResourceManager rm;

        private AccessComponentWorkItem workItem;
        [ServiceDependency]
        public AccessComponentWorkItem WorkItem
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

        public UsrDeviceDoorGroupMgt()
        {
            InitializeComponent();
            InitDataGridViewDeviceDoor();
            RegisterEvent();
        }

        private void RegisterEvent()
        {
            //Tree View
            trvOrganizations.BeforeSelect += trvOrganizations_BeforeSelect;
            trvOrganizations.AfterSelect += trvOrganizations_AfterSelect;
           //load devicedoor list
            bgwLoadDeviceDoorList = new BackgroundWorker();
            bgwLoadDeviceDoorList.WorkerSupportsCancellation = true;
            bgwLoadDeviceDoorList.DoWork += bgwLoadDeviceDoorList_DoWork;
            bgwLoadDeviceDoorList.RunWorkerCompleted += bgwLoadDeviceDoorList_RunWorkerCompleted;
            //load list devicedoorgroup
            bgwloadDeviceDoorGroupWorker = new BackgroundWorker();
            bgwloadDeviceDoorGroupWorker.WorkerSupportsCancellation = true;
            bgwloadDeviceDoorGroupWorker.DoWork += OnloadGroupDeviceWorkerDoWork;
            bgwloadDeviceDoorGroupWorker.RunWorkerCompleted += OnloadGroupDeviceWorkerCompleted;
            //load devicedoorgroup by id
            bgwloadDeviceDoorGroupByIdWorker = new BackgroundWorker();
            bgwloadDeviceDoorGroupByIdWorker.WorkerSupportsCancellation = true;
            bgwloadDeviceDoorGroupByIdWorker.DoWork += OnloadGroupDeviceByIdWorkerDoWork;
            bgwloadDeviceDoorGroupByIdWorker.RunWorkerCompleted += OnloadGroupDeviceByIdWorkerCompleted;
            //Add - Update - Deleted SubOrg
            btnAddGroup.Click += btnAddGroup_Click;
            btnEditGroup.Click += btnUpdateDeviceDoorGroup_Click;
            btnRemoveGroup.Click += btnRemoveRole_Click;

            btnReloadGroup.Click += (s, e) => LoadDeviceDoorGroupList();

            pagerPanel1.LinkLabelClicked += pagerPanel_LinkLabelClicked;
            startupNodeFont = trvOrganizations.Font;

            Load += OnFormLoad;
        }
        private void OnFormLoad(object sender, EventArgs e)
        {
            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
            //get storageService for pagerPanel loadlanguage
            pagerPanel1.StorageService = storageService;
            pagerPanel1.LoadLanguage();
            InitTreeList();
            LoadDeviceDoorGroupList();
            // Set Language
            SetLanguage();

        }
        private void InitTreeList()
        {
            rootNode = new TreeNode();
            rootNode.Text = MessageValidate.GetMessage(rm, "All");
            rootNode.Name = "-1";
            trvOrganizations.Nodes.Add(rootNode);
        }
        /// <summary>
        /// Get devicedoorgroup list for tree
        /// </summary>
        private void LoadDeviceDoorGroupList()
        {
            SetEmptyControll();
            if (!bgwloadDeviceDoorGroupWorker.IsBusy)
            {
                dtbDeviceDoorList.Rows.Clear();
                rootNode.Nodes.Clear();
                bgwloadDeviceDoorGroupWorker.RunWorkerAsync();
            }
        }
        /// <summary>
        /// get Object devicedoorgroup show guide
        /// </summary>
        private void LoadDeviceDoorGroupById()
        {
            if (!bgwloadDeviceDoorGroupByIdWorker.IsBusy)
            {
                bgwloadDeviceDoorGroupByIdWorker.RunWorkerAsync();
            }
        }
        /// <summary>
        /// Load devicedoorlist for user
        /// </summary>
        private void LoadDeviceDoorList()
        {
            if (!bgwLoadDeviceDoorList.IsBusy)
            {
                dtbDeviceDoorList.Rows.Clear();
                bgwLoadDeviceDoorList.RunWorkerAsync();
            }
        }
        private void OnloadGroupDeviceWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            List<DeviceDoorGroup> result = null;
            try
            {
                //load devicedoorgroup show tree
              e.Result =  result = AccessFactory.Instance.GetChannel().GetDeviceDoorGroupList(StorageService.CurrentSessionId);
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

        private void OnloadGroupDeviceWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }

            // Get result from DoWork method
            List<DeviceDoorGroup> result = (List<DeviceDoorGroup>)e.Result;
            if (result != null)
            {
                foreach (DeviceDoorGroup DeviceDoorGroup in result)
                {
                    //add tree
                    TreeNode DeviceDoorGroupNode = new TreeNode();
                    DeviceDoorGroupNode.Text = DeviceDoorGroup.deviceDoorGroupName;
                    DeviceDoorGroupNode.Name = Convert.ToString(DeviceDoorGroup.deviceDoorGroupId);
                    rootNode.Nodes.Add(DeviceDoorGroupNode);
                }
                trvOrganizations.Sort();
                rootNode.Expand();
            }
        }
        private void OnloadGroupDeviceByIdWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            DeviceDoorGroup result = null;
            long groupId = Convert.ToInt64(selectedOrgNode.Name);
            try
            {
                if (groupId != -1)
                {
                    //get object devicedoorgroup by id
                   e.Result= result = AccessFactory.Instance.GetChannel().GetDeviceDoorGroupById(StorageService.CurrentSessionId, groupId);
                }
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

        private void OnloadGroupDeviceByIdWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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
            DeviceDoorGroup result = (DeviceDoorGroup)e.Result;
            SetTextShow(result);
        }
        /// <summary>
        /// Show information devicedoorgroup for user 
        /// </summary>
        /// <param name="group"></param>
        private void SetTextShow(DeviceDoorGroup group)
        {
            txbNameGroup.Text = group.deviceDoorGroupName;
            txbDescription.Text = group.description;
        }
        /// <summary>
        /// Set all value in textbox empty
        /// </summary>
        /// <param name="group"></param>
        private void SetEmptyControll()
        {
            txbNameGroup.Text =
            txbDescription.Text = "";
        }

        private void trvOrganizations_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            // If background worker is running -> restrict selecting another node
            if (bgwLoadDeviceDoorList.IsBusy)
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

        private void trvOrganizations_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectedNode = e.Node;
            TreeNode parentNode = new TreeNode();
            if (selectedNode != null)
            {
                parentNode = selectedNode.Parent;
                selectedNode.NodeFont = new Font(startupNodeFont, FontStyle.Bold);
                selectedNode.Text = selectedNode.Text;

                if (selectedOrgNode != null && selectedNode == selectedOrgNode)
                {
                    return;
                }

                selectedOrgNode = selectedNode;
                LoadDeviceDoorList();
                LoadDeviceDoorGroupById();
                SetShowOrHideUpdateOrg();

                currentPageIndex = 1;
            }
        }

        #endregion

        #region Set Language
        /// <summary>
        /// set language for all headertext and toolstrip
        /// </summary>
        private void SetLanguage()
        {
            this.lblLeftAreaTitleGroup.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.lblLeftAreaTitleGroup.Name);
            this.lblRightAreaTitlegGroupDevice.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.lblRightAreaTitlegGroupDevice.Name);
            this.btnAddGroup.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnAddGroup.Name);
            this.btnEditGroup.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnEditGroup.Name);
            this.btnRemoveGroup.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnRemoveGroup.Name);
            this.btnReloadGroup.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnReloadGroup.Name);
            this.btnAddDeviceDoor.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnAddDeviceDoor.Name);
            this.lblNameGroup.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.lblNameGroup.Name);
            this.lblDescription.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.lblDescription.Name);
            this.colDeviceName.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colDeviceName.Name);
            this.colIP.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colIP.Name);
            this.colDeviceDescription.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colDeviceDescription.Name);
            this.colAddDevice.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colAddDevice.Name);
            this.btnReload.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnReload.Name);

        }
        #endregion

        #region Event's

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
            dtbDeviceDoorList.Rows.Clear();
            int take = LocalSettings.Instance.RecordsPerPage;
            int skip = (currentPageIndex - 1) * take;
            List<DeviceDoor> result = DeviceDoorList.Skip(skip).Take(take).ToList();
            LoadDeviceDoorDataGridView(result);

            pagerPanel1.ShowNumberOfRecords(DeviceDoorList.Count, result != null ? result.Count : 0, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
            pagerPanel1.UpdatePagingLinks(DeviceDoorList.Count, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
        }

        void bgwLoadDeviceDoorList_DoWork(object sender, DoWorkEventArgs e)
        {
            List<DeviceDoor> result = null;
            int totalRecords = 0;
            int take = LocalSettings.Instance.RecordsPerPage;
            int skip = 0;
            currentPageIndex = 1;
            try
            {
                //ham nay lay ve danh sach cac thiet bi thuoc group de show trong datatable get tu bang DeviceDoorGroupDeviceDoorDTO
                e.Result = DeviceDoorList = AccessFactory.Instance.GetChannel().GetDeviceDoorListByGroupId(storageService.CurrentSessionId, Convert.ToInt64(selectedOrgNode.Name));
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
                if (DeviceDoorList != null)
                {
                    result = DeviceDoorList.Skip(skip).Take(take).ToList();
                    totalRecords = DeviceDoorList.Count;
                    pagerPanel1.ShowNumberOfRecords(totalRecords, result != null ? result.Count : 0, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
                    pagerPanel1.UpdatePagingLinks(totalRecords, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
                }
            }
        }

        void bgwLoadDeviceDoorList_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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
            LoadDeviceDoorDataGridView(result);



        }
        /// <summary>
        /// Ham nay dung de them mot nhom thiet bi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        ///
        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            FrmAddOrEditGroupDeviceDoor dialog = new FrmAddOrEditGroupDeviceDoor(FrmAddOrEditGroupDeviceDoor.ModeAdding);
            workItem.SmartParts.Add(dialog);
            dialog.ShowDialog();
            workItem.SmartParts.Remove(dialog);
            dialog.Dispose();
            LoadDeviceDoorGroupList();
        }

        /// <summary>
        /// Ham nay dung de update mot group
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateDeviceDoorGroup_Click(object sender, EventArgs e)
        {
            if (selectedOrgNode.Level == 1)
            {
                FrmAddOrEditGroupDeviceDoor dialog = new FrmAddOrEditGroupDeviceDoor(FrmAddOrEditGroupDeviceDoor.ModeUpdating, Convert.ToInt64(selectedOrgNode.Name));
                workItem.SmartParts.Add(dialog);
                dialog.ShowDialog();
                workItem.SmartParts.Remove(dialog);
                dialog.Dispose();
                LoadDeviceDoorGroupList();
            }

        }
        /// <summary>
        /// Ham nay remove mot nhom thiet bi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveRole_Click(object sender, EventArgs e)
        {
            bool result;
            //Show confirmation message box
            if (selectedOrgNode == null && selectedOrgNode.Level < 1)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessSelect(rm, "CancelGroup"), MessageValidate.GetErrorTitle(rm));
                return;
            }
            //Show confirmation message box
            if (MessageBoxManager.ShowQuestionMessageBox(this, MessageValidate.GetMessage(rm, "AreYouCancelGroup"), MessageValidate.GetConfirm(rm)) == DialogResult.Yes)
            {
                try
                {
                    //xoa 1 groupdevice
                    result = (int)Status.SUCCESS == AccessFactory.Instance.GetChannel().RemoveDeviceDoorGroup(StorageService.CurrentSessionId, Convert.ToInt64(selectedOrgNode.Name));
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
                if (result != null && result)
                {
                    trvOrganizations.Nodes.Remove(selectedOrgNode);
                    LoadDeviceDoorGroupList();
                }
                else
                {
                    MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "CancelGroupFail"));
                }
            }
        }

        #endregion

        #region Event's Support
        /// <summary>
        /// Init datagidview
        /// </summary>
        private void InitDataGridViewDeviceDoor()
        {
            dtbDeviceDoorList = new DataTable();
            dtbDeviceDoorList.Columns.Add(colDeviceDoorId.DataPropertyName);
            dtbDeviceDoorList.Columns.Add(colId.DataPropertyName);
            dtbDeviceDoorList.Columns.Add(colDeviceName.DataPropertyName);
            dtbDeviceDoorList.Columns.Add(colIP.DataPropertyName);
            dtbDeviceDoorList.Columns.Add(colDeviceDescription.DataPropertyName);
            dtbDeviceDoorList.Columns.Add(colAddDevice.DataPropertyName);

            dgvDeviceDoorList.DataSource = dtbDeviceDoorList;
        }
        /// <summary>
        /// Load date for datagidview
        /// </summary>
        /// <param name="result"></param>
        private void LoadDeviceDoorDataGridView(List<DeviceDoor> result)
        {
            lstIdGroupBeforeCheck = new List<long>();
            foreach (DeviceDoor deviceDoor in result)
            {
                DataRow row = dtbDeviceDoorList.NewRow();
                row.BeginEdit();
                row[colId.DataPropertyName] = deviceDoor.Id;
                row[colDeviceName.DataPropertyName] = deviceDoor.Name;
                row[colIP.DataPropertyName] = deviceDoor.Ip;
                row[colDeviceDescription.DataPropertyName] = deviceDoor.Description;
                bool isCheck = deviceDoor.deviceOfGroup;
                if (isCheck)
                {
                    lstIdGroupBeforeCheck.Add(deviceDoor.Id);
                }
                row[colAddDevice.DataPropertyName] = isCheck;

                row.EndEdit();
                dtbDeviceDoorList.Rows.Add(row);
            }

        }

        #endregion

        #region CAB events

        [CommandHandler(AccessCommandNames.ShowGroupDeviceDoorMgtMain)]
        public void ShowGroupDeviceMainHandler(object s, EventArgs e)
        {
            UsrDeviceDoorGroupMgt uc = workItem.Items.Get<UsrDeviceDoorGroupMgt>(ComponentName.DeviceDoorGroupMgt);
            if (uc == null)
            {
                uc = workItem.Items.AddNew<UsrDeviceDoorGroupMgt>(ComponentName.DeviceDoorGroupMgt);
            }
            else if (uc.IsDisposed)
            {
                workItem.Items.Remove(uc);
                uc = workItem.Items.AddNew<UsrDeviceDoorGroupMgt>(ComponentName.DeviceDoorGroupMgt);
            }

            workItem.Workspaces[WorkspaceName.MainWorkspace].Show(uc);
            uc.Parent.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuName.MenugGroupDeviceDoorManager);
        }
        private void SetShowOrHideUpdateOrg()
        {
            bool checkUpdate = selectedOrgNode != null && Convert.ToInt64(selectedOrgNode.Name) > 0;
            btnAddGroup.Enabled = selectedOrgNode != null;
            btnEditGroup.Enabled = btnRemoveGroup.Enabled = btnAddDeviceDoor.Enabled = checkUpdate;
        }

        #endregion
        /// <summary>
        /// Ham nay dung de them cac thiet bi nguoi dung chon vao nhom
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddDeviceDoor_Click(object sender, EventArgs e)
        {
            DeviceDoorPostToServer deviceDoorPostToServer = GetDeviceDoorPostToServer();
            long idGroup = Convert.ToInt64(selectedOrgNode.Name);
            bool resultAdd = false;
            if (MessageBoxManager.ShowQuestionMessageBox(this, MessageValidate.GetMessage(rm, "updateGroupDevice"), MessageValidate.GetConfirm(rm)) == DialogResult.Yes)
            {
                try
                {
                    resultAdd = (int)Status.SUCCESS == AccessFactory.Instance.GetChannel().InsertListDeviceDoorByGroupId(StorageService.CurrentSessionId, idGroup, deviceDoorPostToServer);
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
                if (resultAdd != null && resultAdd)
                {
                    LoadDeviceDoorList();
                }
                else
                {
                    MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "adddevicedoorgroupfailed"));
                }
            }

        }

        /// <summary>
        /// Ham nay dung de Get selected device trong table de nguoi dung chon vao gui len server de add theo group device
        /// </summary>
        /// <returns></returns>
        private List<DeviceDoorGroupDeviceDoorDTO> GetSelectedDeviceDoor()
        {
            lstIdGroupAfterCheck = new List<DeviceDoorGroupDeviceDoorDTO>();
            dgvDeviceDoorList.EndEdit();
            // Get selected device trong table de nguoi dung chon vao gui len server de add theo group device
            foreach (DataGridViewRow row in dgvDeviceDoorList.Rows)
            {
                //lay ra nhung dong co check cham cong
                bool check = Convert.ToBoolean(row.Cells[colAddDevice.Name].Value);
                if (check)
                {
                    DeviceDoorGroupDeviceDoorDTO deviceDoorGroupDeviceDoor = new DeviceDoorGroupDeviceDoorDTO();
                    long id = Convert.ToInt32(row.Cells[colId.Name].Value.ToString());
                    string name = row.Cells[colDeviceName.Name].Value.ToString();
                    string ip = row.Cells[colIP.Name].Value.ToString();
                    string description = row.Cells[colDeviceDescription.Name].Value.ToString();
                    deviceDoorGroupDeviceDoor.deviceDoorId = id;
                    deviceDoorGroupDeviceDoor.deviceDoorName = name;
                    deviceDoorGroupDeviceDoor.ip = ip;
                    deviceDoorGroupDeviceDoor.deviceDoordesription = description;

                    lstIdGroupAfterCheck.Add(deviceDoorGroupDeviceDoor);
                }
            }
            return lstIdGroupAfterCheck;

        }
        /// <summary>
        /// Get two list before check and aftercheck send to server process
        /// </summary>
        /// <returns></returns>
        private DeviceDoorPostToServer GetDeviceDoorPostToServer()
        {
            //this object contain 2 list check and uncheck
            DeviceDoorPostToServer deviceDoorPostToServer = new DeviceDoorPostToServer();
            lstIdGroupAfterCheck = GetSelectedDeviceDoor();
            if (null != lstIdGroupBeforeCheck && lstIdGroupBeforeCheck.Count != 0)
            {
                for (int i = 0; i < lstIdGroupBeforeCheck.Count; i++)
                {
                    if (null != lstIdGroupAfterCheck)
                    {
                        for (int j = 0; j < lstIdGroupAfterCheck.Count; j++)
                        {
                            if (lstIdGroupBeforeCheck[i] == lstIdGroupAfterCheck[j].deviceDoorId)
                            {
                                //xóa các phần tử trùng nhau
                                lstIdGroupBeforeCheck.Remove(lstIdGroupBeforeCheck[i]);
                                lstIdGroupAfterCheck.Remove(lstIdGroupAfterCheck[j]);
                            }
                        }
                    }
                }
            }
            //gan vao doi tương để gửi lên server
            deviceDoorPostToServer.deviceBeforeSelect = lstIdGroupBeforeCheck;
            deviceDoorPostToServer.deviceAfterSelect = lstIdGroupAfterCheck;
            return deviceDoorPostToServer;
        }
        /// <summary>
        /// LoadDeviceDoorList
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReload_Click(object sender, EventArgs e)
        {
            //gọi lại hàm
            LoadDeviceDoorList();
        }
    }
}
