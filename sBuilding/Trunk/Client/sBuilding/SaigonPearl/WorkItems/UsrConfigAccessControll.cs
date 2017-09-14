using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using CommonHelper.Constants;
using sAccessComponent.Constants;
using Microsoft.Practices.CompositeUI.Commands;
using CommonHelper.Utils;
using sBuildingCommunication.Define;
using CommonHelper.Config;
using sWorldModel.TransportData;
using CommonControls;
using System.ServiceModel;
using sWorldModel.Exceptions;
using sBuildingCommunication.Factory;
using JavaCommunication;
using CommonControls.Custom;
using sBuildingCommunication.Model;
using System.Resources;
using sWorldModel;
using Microsoft.Practices.CompositeUI;
using System.Windows.Forms;

namespace sAccessComponent.WorkItems
{
    public partial class UsrConfigAccessControll : CommonUserControl
    {
        #region Properties

        private BackgroundWorker bgwloadRoleWorker;
        private BackgroundWorker bgwloadGroupDeviceWorker;
        private BackgroundWorker bgwloadRoleByIdWorker;

        private int currentPageIndex = 1;
        private DataTable dtbDeviceDoorList;
        private RoleDTO role;
        private List<DeviceDoorGroup> deviceDoorGroupList;
        // Selected tree node; cache it to do some effect in UI
        private Font startupNodeFont;
        private TreeNode selectedOrgNode;
        private TreeNode selectedOrgParentNode;
        private TreeNode rootNode;

        //two list ID group before check and after check;

        private List<long> lstIdGroupBeforeCheck;
        private List<long> lstIdGroupAfterCheck;
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

        public UsrConfigAccessControll()
        {
            InitializeComponent();
            InitDataGridViewDeviceDoor();
            RegisterEvent();
        }
        #endregion
        #region Event's
        private void RegisterEvent()
        {
            //Tree View

            trvOrganizations.BeforeSelect += trvOrganizations_BeforeSelect;
            trvOrganizations.AfterSelect += trvOrganizations_AfterSelect;
            //Load Tree View

            bgwloadRoleWorker = new BackgroundWorker();
            bgwloadRoleWorker.WorkerSupportsCancellation = true;
            bgwloadRoleWorker.DoWork += OnloadRoleWorkerDoWork;
            bgwloadRoleWorker.RunWorkerCompleted += OnloadRoleWorkerCompleted;

            bgwloadRoleByIdWorker = new BackgroundWorker();
            bgwloadRoleByIdWorker.WorkerSupportsCancellation = true;
            bgwloadRoleByIdWorker.DoWork += OnloadRoleByIdWorkerDoWork;
            bgwloadRoleByIdWorker.RunWorkerCompleted += OnloadRoleByIdWorkerCompleted;

            bgwloadGroupDeviceWorker = new BackgroundWorker();
            bgwloadGroupDeviceWorker.WorkerSupportsCancellation = true;
            bgwloadGroupDeviceWorker.DoWork += bgwLoadGroupDeviceDoorList_DoWork;
            bgwloadGroupDeviceWorker.RunWorkerCompleted += bgwLoadGroupDeviceDoorList_RunWorkerCompleted;
            //Add - Update - Deleted SubOrg
            btnReloadGroup.Click += (s, e) => LoadRoleList();

            pagerPanel1.LinkLabelClicked += pagerPanel_LinkLabelClicked;
            startupNodeFont = trvOrganizations.Font;

            Load += OnFormLoad;
        }

        private void OnFormLoad(object sender, EventArgs e)
        {
            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
            pagerPanel1.StorageService = storageService;
            pagerPanel1.LoadLanguage();
            InitTreeList();
            LoadRoleList();
            SetLanguage();
        }
        private void InitTreeList()
        {
            rootNode = new TreeNode();
            rootNode.Text = MessageValidate.GetMessage(rm, "All");
            rootNode.Name = "-1";
            trvOrganizations.Nodes.Add(rootNode);
        }
        private void trvOrganizations_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            // If background worker is running -> restrict selecting another node
            if (bgwloadGroupDeviceWorker.IsBusy)
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
                }else { 
                selectedOrgNode = selectedNode;
                LoadGroupDeviceList();
                LoadRoleById();
                currentPageIndex = 1;
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
            dtbDeviceDoorList.Rows.Clear();
            int take = LocalSettings.Instance.RecordsPerPage;
            int skip = (currentPageIndex - 1) * take;
            List<DeviceDoorGroup> result = deviceDoorGroupList.Skip(skip).Take(take).ToList();
            LoadDeviceDoorDataGridView(result);

            pagerPanel1.ShowNumberOfRecords(deviceDoorGroupList.Count, result != null ? result.Count : 0, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
            pagerPanel1.UpdatePagingLinks(deviceDoorGroupList.Count, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
        }
        #endregion

       

        #region LoadRoleList
        private void LoadRoleList()
        {
            if (!bgwloadRoleWorker.IsBusy)
            {
                dtbDeviceDoorList.Rows.Clear();
                rootNode.Nodes.Clear();
                bgwloadRoleWorker.RunWorkerAsync();
            }
        }

        private void OnloadRoleWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = AccessFactory.Instance.GetChannel().GetRoleList(StorageService.CurrentSessionId);
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

        private void OnloadRoleWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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
            List<RoleDTO> result = (List<RoleDTO>)e.Result;
            if (result != null)
            {
                foreach (RoleDTO DeviceDoorGroup in result)
                {
                    TreeNode role = new TreeNode();
                    role.Text = DeviceDoorGroup.name;
                    role.Name = Convert.ToString(DeviceDoorGroup.roleId);
                    rootNode.Nodes.Add(role);
                }
                trvOrganizations.Sort();
                rootNode.Expand();
            }
        }
        #endregion

       

        #region Set Language
        private void SetLanguage()
        {
            this.lblLeftAreaTitleGroupUser.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.lblLeftAreaTitleGroupUser.Name);
            this.lblRightAreaTitleGroupDevice.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.lblRightAreaTitleGroupDevice.Name);
            this.lblNameGroup.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.lblNameGroup.Name);
            this.lblDescription.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.lblDescription.Name);
            this.colNameGroup.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colNameGroup.Name);
            this.colDescriptionDevice.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colDescriptionDevice.Name);
            this.btnReloadGroup.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnReloadGroup.Name);
            this.btnSaveListDeviceGroup.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnSaveListDeviceGroup.Name);
        }
        #endregion
        #region LoadGroupDeviceList
        private void LoadGroupDeviceList()
        {
            if (!bgwloadGroupDeviceWorker.IsBusy)
            {
                dtbDeviceDoorList.Rows.Clear();
                bgwloadGroupDeviceWorker.RunWorkerAsync();
            }
        }
        /// <summary>
        /// Load group Devicedoor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwLoadGroupDeviceDoorList_DoWork(object sender, DoWorkEventArgs e)
        {
            int totalRecords = 0;
            int take = LocalSettings.Instance.RecordsPerPage;
            int skip = 0;
            currentPageIndex = 1;
            try
            {
                // An cho nay de sua lai dong duoi
                e.Result = deviceDoorGroupList = AccessFactory.Instance.GetChannel().GetDeviceDoorGroupListByRoleId(StorageService.CurrentSessionId, Convert.ToInt64(selectedOrgNode.Name));
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
                if (deviceDoorGroupList != null)
                {
                    deviceDoorGroupList = deviceDoorGroupList.Skip(skip).Take(take).ToList();
                    totalRecords = deviceDoorGroupList.Count;
                    pagerPanel1.ShowNumberOfRecords(totalRecords, deviceDoorGroupList != null ? deviceDoorGroupList.Count : 0, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
                    pagerPanel1.UpdatePagingLinks(totalRecords, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
                }
            }
        }
        /// <summary>
        /// LoadGroupDeviceDoorList after complete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void bgwLoadGroupDeviceDoorList_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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
            //show view
            LoadDeviceDoorDataGridView(result);
        }

        #endregion

        #region Event's Support
        private void InitDataGridViewDeviceDoor()
        {
            dtbDeviceDoorList = new DataTable();
            dtbDeviceDoorList.Columns.Add(colId.DataPropertyName);
            dtbDeviceDoorList.Columns.Add(colNameGroup.DataPropertyName);
            dtbDeviceDoorList.Columns.Add(colDescriptionDevice.DataPropertyName);
            dtbDeviceDoorList.Columns.Add(colCheck.DataPropertyName);
            dgvDeviceDoorList.DataSource = dtbDeviceDoorList;
        }
        /// <summary>
        /// show list  devicedoorgroup for view
        /// </summary>
        /// <param name="result"></param>
        private void LoadDeviceDoorDataGridView(List<DeviceDoorGroup> result)
        {
            lstIdGroupBeforeCheck = new List<long>();
            foreach (DeviceDoorGroup deviceDoorGroup in result)
            {
                DataRow row = dtbDeviceDoorList.NewRow();
                row.BeginEdit();

                row[colId.DataPropertyName] = deviceDoorGroup.deviceDoorGroupId;
                row[colNameGroup.DataPropertyName] = deviceDoorGroup.deviceDoorGroupName;
                row[colDescriptionDevice.DataPropertyName] = deviceDoorGroup.description;
                row[colCheck.DataPropertyName] = deviceDoorGroup.addGroupMember;
                //getlist idgroup check  before add
                if (deviceDoorGroup.addGroupMember)
                {
                    lstIdGroupBeforeCheck.Add(deviceDoorGroup.deviceDoorGroupId);
                }
                row.EndEdit();
                dtbDeviceDoorList.Rows.Add(row);
            }
        }

        #endregion

        #region CAB events

        [CommandHandler(AccessCommandNames.ShowConfigAccessControll)]
        public void ShowConfigAccessControll(object s, EventArgs e)
        {
            UsrConfigAccessControll uc = workItem.Items.Get<UsrConfigAccessControll>(ComponentName.ConfigAccessControll);
            if (uc == null)
            {
                uc = workItem.Items.AddNew<UsrConfigAccessControll>(ComponentName.ConfigAccessControll);
            }
            else if (uc.IsDisposed)
            {
                workItem.Items.Remove(uc);
                uc = workItem.Items.AddNew<UsrConfigAccessControll>(ComponentName.ConfigAccessControll);
            }

            workItem.Workspaces[WorkspaceName.MainWorkspace].Show(uc);
            uc.Parent.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuName.MenuConfigAccessControll);
        }
        #region LoadRoleById
        private void LoadRoleById()
        {
            
            if (!bgwloadRoleByIdWorker.IsBusy)
            {
                bgwloadRoleByIdWorker.RunWorkerAsync();
            }
            
        }
        /// <summary>
        /// Load Object role by Id for view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnloadRoleByIdWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            long roleId = Convert.ToInt64(selectedOrgNode.Name);
            try
            { 
                if(roleId != -1) { 
                    // lay role ve de show thong tin cho nguoi dung xem
                    e.Result = AccessFactory.Instance.GetChannel().GetRoleById(StorageService.CurrentSessionId, Convert.ToInt64(selectedOrgNode.Name));
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
        void OnloadRoleByIdWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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
            RoleDTO result = (RoleDTO)e.Result;
            SetTextShow(result);
        }
        /// <summary>
        /// show for user view
        /// </summary>
        /// <param name="role"></param>
        private void SetTextShow(RoleDTO role)
        {
            txbName.Text = role.name;
            txbDes.Text = role.description;
        }
        #endregion
        #region SaveList
        private void btnSaveListDeviceGroup_Click(object sender, EventArgs e)
        {
            //get 2 list for add and remove
            DeviceDoorGroupPostToServer deviceDoorGroupPostToServer = GetListIdPostServer();
            long roleId = Convert.ToInt64(selectedOrgNode.Name);
            bool resultAdd = false;
            if (null != deviceDoorGroupPostToServer)
            {
                if (MessageBoxManager.ShowQuestionMessageBox(this, MessageValidate.GetMessage(rm, "givepermission"), MessageValidate.GetConfirm(rm)) == DialogResult.Yes)
                {
                    try
                    {
                        resultAdd = (int)Status.SUCCESS == AccessFactory.Instance.GetChannel().InsertRoleDeviceDoorGroup(StorageService.CurrentSessionId, roleId, deviceDoorGroupPostToServer);
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
                        LoadGroupDeviceList();
                    }
                    else
                    {
                        MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "AddGroupFailed"));

                    }
                }
            }
        }
        #endregion
        /// <summary>
        /// Ham nay dung de Get selected device trong table de nguoi dung chon vao gui len server de add theo group device
        /// </summary>
        /// <returns></returns>
        private List<long> GetSelectedDeviceDoor()
        {
            List<long> lstResult = new List<long>();
            dgvDeviceDoorList.EndEdit();
            // Get selected device trong table de nguoi dung chon vao gui len server de add theo group device
            foreach (DataGridViewRow row in dgvDeviceDoorList.Rows)
            {
                //lay ra nhung dong co check cham cong
                bool check = Convert.ToBoolean(row.Cells[colCheck.Name].Value);
                if (check)
                {
                    long idDeviceDoorGroup = Convert.ToInt32(row.Cells[colId.Name].Value.ToString());
                    lstResult.Add(idDeviceDoorGroup);
                }
            }
            return lstResult;
        }
        /// <summary>
        /// Get two list before check and aftercheck send to server process
        /// </summary>
        /// <returns></returns>
        private DeviceDoorGroupPostToServer GetListIdPostServer()
        {
            DeviceDoorGroupPostToServer deviceDoorGroupPostToServer = new DeviceDoorGroupPostToServer();
            lstIdGroupAfterCheck = GetSelectedDeviceDoor();
            if (null != lstIdGroupBeforeCheck)
            {
                for (int i = 0; i < lstIdGroupBeforeCheck.Count; i++)
                {
                    if (null != lstIdGroupAfterCheck)
                    {
                        for (int j = 0; j < lstIdGroupAfterCheck.Count; j++)
                        {
                            if (lstIdGroupBeforeCheck[i] == lstIdGroupAfterCheck[j])
                            {
                                //loại bỏ các phần tử trùng nhau trong 2 list
                                lstIdGroupBeforeCheck.Remove(lstIdGroupBeforeCheck[i]);
                                lstIdGroupAfterCheck.Remove(lstIdGroupAfterCheck[j]);
                            }
                        }
                    }
                }
            }
            //gan lai vao doi tượng để gửi lên server
            deviceDoorGroupPostToServer.lstIdGroupBeforeCheck = lstIdGroupBeforeCheck;
            deviceDoorGroupPostToServer.lstIdGroupAfterCheck = lstIdGroupAfterCheck;
            return deviceDoorGroupPostToServer;
        }
        /// <summary>
        /// LoadGroupDeviceList
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadGroupDeviceList();
        }
    }
    #endregion
}