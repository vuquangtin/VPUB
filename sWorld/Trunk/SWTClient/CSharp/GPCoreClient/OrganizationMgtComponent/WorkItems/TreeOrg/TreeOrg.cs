using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sWorldModel;
using sWorldModel.TransportData;
using CommonHelper.Config;
using System.ServiceModel;
using CommonHelper.Constants;
using sWorldModel.Exceptions;
using JavaCommunication.Factory;
using sWorldModel.Filters;
using System.Resources;
using CommonHelper.Utils;
using CommonControls.Custom;
using CommonControls;
using Microsoft.Practices.CompositeUI;
using JavaCommunication;

namespace SystemMgtComponent.WorkItems
{
    public delegate void AfterSelect(long orgId, long parentNode, long selectOrgNode);
    public partial class TreeOrg : CommonUserControl
    {
        // The original font of tree nodes
        private Font startupNodeFont;
        public ResourceManager rm;
        // Selected tree node; cache it to do some effect in UI
        private TreeNode selectedOrgNode;
        private TreeNode rootNode;
        private TreeNode parentNode;
        public event AfterSelect AfterSelect;
        private BackgroundWorker loadOrgWorker;
        private BackgroundWorker removeOrgWorker;
        private BackgroundWorker removeSubOrgWorker;
        List<OrgCustomerDto> result = null;

        private ILocalStorageService storageService;
        public ILocalStorageService StorageService
        {
            set
            {
                storageService = value;
            }
        }

        public TreeOrg()
        {
            InitializeComponent();

        }
        public void InitializeData()
        {
            LoadLanguage();
            RegisterEvents();
            InitTreeList();
            LoadOrgList();
        }
        /// <summary>
        /// load language for all controls in control
        /// </summary>
        private void LoadLanguage()
        {
            rm = storageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
            SetLanguage();
        }

        private void SetLanguage()
        {
            this.btnAddOrg.ToolTipText = MessageValidate.GetMessage(rm, btnAddOrg.Name);
            this.btnUpdateOrg.ToolTipText = MessageValidate.GetMessage(rm, btnUpdateOrg.Name);
            this.btnRemoveOrg.ToolTipText = MessageValidate.GetMessage(rm, btnRemoveOrg.Name);
            this.btnReloadOrgs.ToolTipText = MessageValidate.GetMessage(rm, btnReloadOrgs.Name);
        }

        private void InitTreeList()
        {
            rootNode = new TreeNode();
            rootNode.Text = MessageValidate.GetMessage(rm, "All");
            rootNode.Name = "-1";
            trvOrganizations.Nodes.Add(rootNode);
        }

        public void SetHideButton()
        {
            btnAddOrg.Visible = false;
            btnUpdateOrg.Visible = false;
            btnRemoveOrg.Visible = false;
        }
        private void LoadOrgList()
        {
            if (!loadOrgWorker.IsBusy)
            {
                rootNode.Nodes.Clear();
                loadOrgWorker.RunWorkerAsync();
            }
        }
        private void RegisterEvents()
        {
            //Tree View
            trvOrganizations.BeforeSelect += trvOrganizations_BeforeSelect;
            trvOrganizations.AfterSelect += trvOrganizations_AfterSelect;
            //Load Tree View
            loadOrgWorker = new BackgroundWorker();
            loadOrgWorker.WorkerSupportsCancellation = true;
            loadOrgWorker.DoWork += OnLoadOrgWorkerDoWork;
            loadOrgWorker.RunWorkerCompleted += OnLoadOrgWorkerCompleted;

            //remove org
            removeOrgWorker = new BackgroundWorker();
            removeOrgWorker.WorkerSupportsCancellation = true;
            removeOrgWorker.DoWork += OnRemoveOrgWorkerDoWork;
            removeOrgWorker.RunWorkerCompleted += OnRemoveOrgWorkerCompleted;
            //removeSuborg
            removeSubOrgWorker = new BackgroundWorker();
            removeSubOrgWorker.WorkerSupportsCancellation = true;
            removeSubOrgWorker.DoWork += OnRemoveSubOrgWorkerDoWork;
            removeSubOrgWorker.RunWorkerCompleted += OnRemoveSubOrgWorkerCompleted;


            //Show or hide filter
            //btnShowHide.Click += btnShowHide_Click;

            //Add - Update - Deleted Org
            btnAddOrg.Click += btnAddOrg_Click;
            btnUpdateOrg.Click += btnUpdateOrg_Click;
            //mniUpdateOrg.Click += btnUpdateOrg_Click;
            btnRemoveOrg.Click += btnRemoveOrg_Click;

            
            btnReloadOrgs.Click += (s, e) => LoadOrgList();

            // Assign startup value
            startupNodeFont = trvOrganizations.Font;

        }


        private void btnRemoveOrg_Click(object sender, EventArgs e)
        {
            if (selectedOrgNode.Level == 0)
            {
                return;
            }
            if (selectedOrgNode.Level == 1)
            {
                RemoveOrg();
            }
            else
            {
                RemoveSuborg();
            }
        }
        private void RemoveOrg()
        {
            if (MessageBoxManager.ShowQuestionMessageBox(this, MessageValidate.GetMessageRemove(rm, MessageValidate.Organization)) == DialogResult.Yes)
            {
                if (!removeOrgWorker.IsBusy)
                {
                    removeOrgWorker.RunWorkerAsync();
                }
            }
        }
        private void RemoveSuborg()
        {
            if (MessageBoxManager.ShowQuestionMessageBox(this, MessageValidate.GetMessageRemove(rm, MessageValidate.Organization)) == DialogResult.Yes)
            {
                if (!removeSubOrgWorker.IsBusy)
                {
                    removeSubOrgWorker.RunWorkerAsync();
                }
            }
        }

        private void trvOrganizations_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            // Change node font style to normal
            if (selectedOrgNode != null)
            {
                selectedOrgNode.NodeFont = new Font(startupNodeFont, FontStyle.Regular);
                selectedOrgNode.Text = selectedOrgNode.Text;
            }
        }

        private void trvOrganizations_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                TreeNode selectedNode = e.Node;
                parentNode = new TreeNode();
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
                    long selectedID = Convert.ToInt64(selectedOrgNode.Name);
                    //20170603 #Bug 747 Sửa lỗi ẩn hiện các button - Ten Nguyen Start
                    //hien tai 2 tham so dau khong su dung trong chức năng này nên set -1
                    if (selectedID == -1)
                    {
                        AfterSelect(-1, -1, selectedID);
                        EbnableButton(false);
                    }
                    //20170603 #Bug 747 Sửa lỗi ẩn hiện các button - Ten Nguyen End
                    if (selectedID != -1)
                    {
                        EbnableButton(true);
                        long parentID = Convert.ToInt64(parentNode.Name);
                        AfterSelect(getOrgIdByParentId(parentID, selectedID), parentID, selectedID);
                    }

                }
            }
            catch
            {
            }

        }
        private void EbnableButton(bool ebnable)
        {
            btnAddOrg.Enabled =
            btnUpdateOrg.Enabled = 
            btnRemoveOrg.Enabled = ebnable;
        }
        #region Organization

        private void OnLoadOrgWorkerDoWork(object sender, DoWorkEventArgs e)
        {

            OrgFilterDto filter = new OrgFilterDto();

            try
            {
                // nam.nguyen
                //if (!"".Equals(SystemSettings.Instance.OrgCode)) {
                //    filter.OrgCode = SystemSettings.Instance.OrgCode;
                //    filter.FilterByOrgCode = true;
                //} else if (!"ALL".Equals(SystemSettings.Instance.OrgCode)) {
                //    filter.OrgCode = SystemSettings.Instance.OrgCode;
                //    filter.FilterByOrgCode = true;
                //}
                // end nam.nguyen

                // minh.nguyen
                if (!((SystemSettings.Instance.OrgCode).Equals("") || (SystemSettings.Instance.OrgCode).Equals("ALL"))) {
                    filter.OrgCode = SystemSettings.Instance.OrgCode;
                    filter.FilterByOrgCode = true;
                }
                // end minh.nguyen

                result = OrganizationFactory.Instance.GetChannel().GetOrgList(storageService.CurrentSessionId, filter);
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

        private void OnLoadOrgWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            // Get result from DoWork method
            List<OrgCustomerDto> result = (List<OrgCustomerDto>)e.Result;

            
            GetTree(result);
        }
        #endregion
        #region Organization

        private void OnRemoveOrgWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = (int)Status.SUCCESS == OrganizationFactory.Instance.GetChannel().RemoveOrg(storageService.CurrentSessionId, Convert.ToInt64(selectedOrgNode.Name));
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

        private void OnRemoveOrgWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if (e.Result == null)
            {
                return;
            }
            if (e.Result != null && (bool)e.Result)
            {
                LoadOrgList();
            }
            else
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "removeFail"));
            }
        }
        #endregion
       
        #region Remove Suborg

        private void OnRemoveSubOrgWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = (int)Status.SUCCESS == OrganizationFactory.Instance.GetChannel().RemoveSubOrg(storageService.CurrentSessionId, Convert.ToInt64(selectedOrgNode.Name));
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

        private void OnRemoveSubOrgWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if (e.Result == null)
            {
                return;
            }
            if (e.Result != null && (bool)e.Result)
            {
                LoadOrgList();
            }
            else
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "removeFail"));
            }
        }
        #endregion
        
        #region Add Org
        private void btnAddOrg_Click(object sender, EventArgs e)
        {
            if (selectedOrgNode == null)
            {
                return;
            }
            if (selectedOrgNode.Level == 0)
            {
                // Show GroupDetail dialog and delegate this task to it
                FrmAddOrEditOrg dialog = new FrmAddOrEditOrg(FrmAddOrEditOrg.ModeAddingOrg);
                dialog.rm = rm;
                dialog.StorageService = storageService;
                dialog.ShowDialog();
                dialog.Dispose();
                LoadOrgList();
            }
            else
            {
                long selectedID = Convert.ToInt64(selectedOrgNode.Name);
                long parentID = Convert.ToInt64(parentNode.Name);
                long orgId = getOrgIdByParentId(parentID, selectedID);
                FrmAddOrEditOrg dialog = new FrmAddOrEditOrg(FrmAddOrEditOrg.ModeAddingSubOrg, orgId, 0/*suborg khong su dụng,*/, selectedID);
                dialog.rm = rm;
                dialog.StorageService = storageService;
                dialog.ShowDialog();
                dialog.Dispose();
                LoadOrgList();
            }
        }
        #endregion
        private long getOrgIdByParentId(long parentID, long selectedID)
        {
            if (parentID == -1)
            {
                return selectedID;
            }
            if (null != result)
            {
                foreach (OrgCustomerDto item in result)
                {
                    if (item.SubOrgList != null)
                    {
                        List<SubOrgCustomerDTO> SubOrgCustomerDTO = item.SubOrgList.Where(key => key.SubOrgId == selectedID).ToList();
                        if (SubOrgCustomerDTO.Count > 0)
                        {
                            SubOrgCustomerDTO SubOrgCustomer = SubOrgCustomerDTO[0];
                            return SubOrgCustomer.OrgId;
                        }
                    }
                }
            }
            return -1;
        }
        private void btnUpdateOrg_Click(object sender, EventArgs e)
        {
            long selectedID = Convert.ToInt64(selectedOrgNode.Name);
            long parentID = Convert.ToInt64(parentNode.Name);
            if (parentID != 0)
            {
                long orgId = getOrgIdByParentId(parentID, selectedID);
            }
            if (selectedOrgNode.Level == 0)
            {
                return;
            }
            if (selectedOrgNode.Level == 1)
            {
                // Show GroupDetail dialog and delegate this task to it
                FrmAddOrEditOrg dialog = new FrmAddOrEditOrg(FrmAddOrEditOrg.ModeUpdatingOrg, Convert.ToInt64(selectedOrgNode.Name));
                dialog.rm = rm;
                dialog.StorageService = storageService;
                dialog.ShowDialog();
                dialog.Dispose();
                LoadOrgList();
                EbnableButton(false);
            }
            else
            {
                FrmAddOrEditOrg dialog = new FrmAddOrEditOrg(FrmAddOrEditOrg.ModeUpdatingSubOrg, 0/*khong can su dụng*/, Convert.ToInt64(selectedOrgNode.Name), Convert.ToInt64(parentNode.Parent.Name));
                dialog.rm = rm;
                dialog.StorageService = storageService;
                dialog.ShowDialog();
                dialog.Dispose();
                EbnableButton(false);
                LoadOrgList();
            }
        }

        public void GetTree(List<OrgCustomerDto> lstOrgCustomerDto)
        {
            //kiem tra null đây để sử dụng cho đệ quy
            if (lstOrgCustomerDto != null)
            {
                foreach (OrgCustomerDto org in lstOrgCustomerDto)
                {
                    if (!org.Issuer.Equals(SystemSettings.Instance.Master))
                    {
                        TreeNode orgNode = new TreeNode();
                        orgNode.Text = org.Name;
                        orgNode.Name = Convert.ToString(org.OrgId);
                        GetSubTree(org, org.OrgId, orgNode);
                        rootNode.Nodes.Add(orgNode);
                    }
                }

            }
        }
        /// <summary>
        /// build sub organization
        /// </summary>
        /// <param name="org"></param>
        /// <param name="orgId"></param>
        /// <param name="node"></param>
        public void GetSubTree(OrgCustomerDto org, long orgId, TreeNode node)
        {
            List<SubOrgCustomerDTO> lstSubOrgCustomerDTO = org.SubOrgList;
            // does not have sub organization
            if (null != lstSubOrgCustomerDTO)
            {
                List<SubOrgCustomerDTO> lstSubOrgCustomer = lstSubOrgCustomerDTO.Where(key => key.parentOrgId == orgId).ToList();
                if (lstSubOrgCustomer != null)
                {
                    foreach (SubOrgCustomerDTO subOrg in lstSubOrgCustomer)
                    {
                        TreeNode subOrgNode = new TreeNode();
                        subOrgNode.Text = subOrg.Name;
                        subOrgNode.Name = Convert.ToString(subOrg.SubOrgId);
                        if (orgId == subOrg.parentOrgId)
                        {
                            node.Nodes.Add(subOrgNode);
                        }
                        GetSubTree(org, subOrg.SubOrgId, subOrgNode);
                    }
                }
            }
        }
    }

}



