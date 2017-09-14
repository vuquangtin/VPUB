using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Practices.CompositeUI;
using sWorldModel;
using Microsoft.Practices.CompositeUI.EventBroker;
using SystemMgtComponent.Constants;
using Microsoft.Practices.CompositeUI.Commands;
using CommonHelper.Constants;
using sWorldModel.Model;
using sWorldModel.Filters;
using JavaCommunication.Factory;
using CommonControls;
using sWorldModel.Exceptions;
using sWorldModel.TransportData;
using System.ServiceModel;
using JavaCommunication;
using SystemMgtComponent.WorkItems.IntegratingExcel;
using CommonHelper.Config;
using SystemMgtComponent.WorkItems;
using CommonControls.Custom;
using System.Resources;
using CommonHelper.Utils;


namespace SystemMgtComponent.WorkItems.OrgAcquirerManager
{
    public partial class UsrOrgAcquirerManagerMgtMain : CommonUserControl
    {
        #region Properties

        private const string NotMaster = @"NOTMASTER";
        // Height of filter box when it is hidden
        private int hiddenFilterBoxHeight = 0;
        // The original height of filter box (at startup)
        private int startupFilterBoxHeight = 88;

        private int currentPageIndex = 1;

        // Data table that contains user records
        private DataTable dtbMasterList;
        private List<CmsOrgCustomerDto> PartnerList = null;
        private BackgroundWorker loadMasterWorker;
        private BackgroundWorker loadPartnerWorker;

        // The original font of tree nodes
        private Font startupNodeFont;
        // Selected tree node; cache it to do some effect in UI
        private TreeNode selectedOrgNode;
        private TreeNode rootNode;
        private ResourceManager rm;

        private PartnerInfoDTO partner = null;
        private MasterInfoDTO masterInfo;

        private SystemWorkItem workItem;
        [ServiceDependency]
        public SystemWorkItem WorkItem
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

        #endregion Properties

        #region Initialization

        public UsrOrgAcquirerManagerMgtMain()
        {
            InitializeComponent();
            InitPartnerListGrid();
            RegisterEvents();
        }

        private void RegisterEvents()
        {
            //Tree View
            trvMaster.AfterExpand += trvMaster_AfterExpand;
            trvMaster.BeforeSelect += trvMaster_BeforeSelect;
            trvMaster.AfterSelect += trvMaster_AfterSelect;
            //Load Tree View
            loadMasterWorker = new BackgroundWorker();
            loadMasterWorker.WorkerSupportsCancellation = true;
            loadMasterWorker.DoWork += OnLoadMasterWorkerDoWork;
            loadMasterWorker.RunWorkerCompleted += OnLoadMasterWorkerCompleted;
            //Load Member
            loadPartnerWorker = new BackgroundWorker();
            loadPartnerWorker.WorkerSupportsCancellation = true;
            loadPartnerWorker.DoWork += OnLoadPartnerWorkerDoWork;
            loadPartnerWorker.RunWorkerCompleted += OnLoadSubOrgWorkerCompleted;
            //Show or hide filter
            //btnShowHide.Click += btnShowHide_Click;

            //Add - Update - Deleted Master
            btnAddOrgAcquirer.Click += btnAddOrgAcquirer_Click;
            mniAddOrg.Click += btnAddOrgAcquirer_Click;
            btnUpdateOrgAcquirer.Click += btnUpdateOrgAcquirer_Click;
            mniUpdateOrg.Click += btnUpdateOrgAcquirer_Click;
            btnRemoveOrgAcquirer.Click += btnRemoveAllOrgAcquirer_Click;

            //Add - Update - Deleted Partner
            //btnRemoveOrgAcquirer1.Click += btnRemoveOrgAcquirer_Click;

            btnReloadOrgAcquirer.Click += (s, e) => LoadMasterList();
            mniReloadOrgs.Click += (s, e) => LoadMasterList();
            //btnReloadOrgAcquirer1.Click += (s, e) => LoadPartnerList();

            //pagerPanel1.LinkLabelClicked += pagerPanel_LinkLabelClicked;

            Enter += (s, e) =>
            {
                if (OrganiztionMgtMainShown != null)
                {
                    OrganiztionMgtMainShown(this, EventArgs.Empty);
                }
            };

            // Assign startup value
            startupNodeFont = trvMaster.Font;

            Load += OnFormLoad;
        }

        private void OnFormLoad(object sender, EventArgs e)
        {
            try
            {
                this.masterInfo = OrganizationFactory.Instance.GetChannel().GetMasterInfo(StorageService.CurrentSessionId, SystemSettings.Instance.Partner);
            }
            catch (TimeoutException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "TimeOutExceptionMessage"));
                PartnerList = null;
            }
            catch (FaultException<WcfServiceFault> ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
                PartnerList = null;
            }
            catch (FaultException ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "FaultExceptionMessage")
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
                PartnerList = null;
            }
            catch (CommunicationException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "CommunicationExceptionMessage"));
                PartnerList = null;
            }
            InitTreeList();
            LoadMasterList();

            rm = storageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
        }

        #endregion Initialization

        #region CAB events

        [EventPublication(OrganizationEventTopicNames.MasterAndPartnerLinkMgtMainShown)]
        public event EventHandler OrganiztionMgtMainShown;

        [CommandHandler(OrganizationCommandNames.ShowOrgAcquirerMgtMain)]
        public void ShowOrgMgtMainHandler(object s, EventArgs e)
        {
            UsrOrgAcquirerManagerMgtMain uc = workItem.Items.Get<UsrOrgAcquirerManagerMgtMain>(ComponentNames.OrgAcquirerMgtComponent);
            if (uc == null)
            {
                uc = workItem.Items.AddNew<UsrOrgAcquirerManagerMgtMain>(ComponentNames.OrgAcquirerMgtComponent);
            }
            else if (uc.IsDisposed)
            {
                workItem.Items.Remove(uc);
                uc = workItem.Items.AddNew<UsrOrgAcquirerManagerMgtMain>(ComponentNames.OrgAcquirerMgtComponent);
            }

            workItem.Workspaces[WorkspaceName.MainWorkspace].Show(uc);
            uc.Parent.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuOrgAcquirerManager);
        }

        #endregion CAB events

        #region Form events

        private void btnShowHide_Click(object sender, EventArgs e)
        {
            //if (pnlFilterBox.Height == hiddenFilterBoxHeight)
            //{
            //    pnlFilterBox.Height = startupFilterBoxHeight;
            //    pnlFilterBox.Height = startupFilterBoxHeight;
            //    btnShowHide.Text = btnShowHide.ToolTipText = "Ẩn Khung Tìm Kiếm";
            //    btnShowHide.ToolTipText = "Ẩn khung tìm kiếm";
            //    btnShowHide.Image = global::CommonControls.Properties.Resources.ArrowUp_16x16;
            //}
            //else
            //{
            //    pnlFilterBox.Height = hiddenFilterBoxHeight;
            //    btnShowHide.Text = btnShowHide.ToolTipText = "Hiện Khung Tìm Kiếm";
            //    btnShowHide.ToolTipText = "Hiện khung tìm kiếm";
            //    btnShowHide.Image = global::CommonControls.Properties.Resources.ArrowDown_16x16;
            //}
        }

        private void trvGroups_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeNode node = trvMaster.GetNodeAt(trvMaster.PointToClient(Control.MousePosition));
                if (node != null)
                {
                    trvMaster.SelectedNode = node;
                    if (node != rootNode)
                    {
                        cmsOrgRecord.Show((Control)sender, e.Location.X, e.Location.Y);
                    }
                }
                else
                {
                    cmsOrgTree.Show((Control)sender, e.Location.X, e.Location.Y);
                }
            }
        }

        private void trvMaster_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if (chkAutoCloseNode.Checked)
            {
                foreach (TreeNode node in rootNode.Nodes)
                {
                    if (node.IsExpanded && node != e.Node)
                    {
                        node.Collapse();
                    }
                }
                trvMaster.SelectedNode = null;
            }
        }

        private void trvMaster_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            // If background worker is running -> restrict selecting another node
            if (loadPartnerWorker.IsBusy)
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

        private void trvMaster_AfterSelect(object sender, TreeViewEventArgs e)
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
                if (selectedOrgNode.Level > 0)
                {
                    LoadPartnerList();
                    SetShowOrHideUpdateOrg();
                }
                else
                    ClearEmptyControl();

                currentPageIndex = 1;
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
            //dgvPartnerList.Rows.Clear();
            int take = LocalSettings.Instance.RecordsPerPage;
            int skip = (currentPageIndex -1) * take;

            List<CmsOrgCustomerDto> result = PartnerList.Skip(skip).Take(take).ToList();
            LoadPartnerDataGridView(result);

            //pagerPanel1.ShowNumberOfRecords(PartnerList.Count, result != null ? result.Count : 0, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
            //pagerPanel1.UpdatePagingLinks(PartnerList.Count, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
        }

        #region Master

        private void OnLoadMasterWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            List<CmsOrgCustomerDto> result = null;
            OrgFilterDto filter = new OrgFilterDto();

            try
            {
                result = OrganizationFactory.Instance.GetChannel().GetPartnerAcquirerList(storageService.CurrentSessionId, masterInfo.code, filter);
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

        private void OnLoadMasterWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }

            // Get result from DoWork method
            List<CmsOrgCustomerDto> result = (List<CmsOrgCustomerDto>)e.Result;
            PartnerList = result;
            if (PartnerList != null && PartnerList.Count > 0)
            {
                foreach (CmsOrgCustomerDto master in PartnerList)
                {
                    if (master.OrgId == masterInfo.MasterId)
                        continue;
                    TreeNode orgNode = new TreeNode();
                    orgNode.Text = master.Name;
                    orgNode.Name = Convert.ToString(master.OrgCode);
                    rootNode.Nodes.Add(orgNode);
                }
                trvMaster.Sort();
                rootNode.Expand();
            }
        }

        //[CommandHandler(OrganizationCommandNames.AddOrg)]
        private void btnAddOrgAcquirer_Click(object sender, EventArgs e)
        {
            // Show GroupDetail dialog and delegate this task to it
            FrmAddOrEditOrgAcquirerManager dialog = new FrmAddOrEditOrgAcquirerManager(FrmAddOrEditOrgAcquirerManager.ModeAdding, masterInfo.code, GetPartnerId());
            workItem.SmartParts.Add(dialog);
            dialog.ShowDialog();
            workItem.SmartParts.Remove(dialog);
            dialog.Dispose();
            LoadMasterList();
        }

        //[CommandHandler(OrganizationCommandNames.UpdateOrg)]
        private void btnUpdateOrgAcquirer_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedOrgNode.Name))
            {
                // Show GroupDetail dialog and delegate this task to it
                FrmAddOrEditOrgAcquirerManager dialog = new FrmAddOrEditOrgAcquirerManager(FrmAddOrEditOrgAcquirerManager.ModeUpdating, masterInfo.code, GetPartnerId());
                workItem.SmartParts.Add(dialog);
                dialog.ShowDialog();
                workItem.SmartParts.Remove(dialog);
                dialog.Dispose();
                LoadMasterList();
            }
        }

        private void btnRemoveAllOrgAcquirer_Click(object sender, EventArgs e)
        {
            bool result;
            if (selectedOrgNode == null && selectedOrgNode.Level < 1)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessSelect(rm, MessageValidate.CancelAcceptOrg), MessageValidate.GetErrorTitle(rm));
                return;
            }
            //if (dgvPartnerList.Rows.Count == 0)
            //{
            //    MessageBoxManager.ShowErrorMessageBox(this, "Tổ chức này không có tổ chức chấp nhận thẻ nên không thực hiện thao tác hủy được!", "Thao Tác Sai");
            //    return;
            //}
            //Show confirmation message box
            if (MessageBoxManager.ShowQuestionMessageBox(this, string.Format("Hủy tổ chức sẽ làm hủy luôn các tổ chức chấp nhận thẻ thuộc tổ chức đó. Bạn có chắc muốn hủy tổ chức này không?", selectedOrgNode.Text)) == DialogResult.Yes)
            {
                try
                {
                    result = (int)Status.SUCCESS == OrganizationFactory.Instance.GetChannel().DeleteOrgAcquirer(StorageService.CurrentSessionId, masterInfo.code, GetPartnerIdSelected());
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
                if (result)
                {
                    LoadMasterList();
                    MessageBoxManager.ShowInfoMessageBox(this, "Đã hủy tổ chức chấp nhận thẻ thành công!");
                }
            }
        }

        private void btnRemoveOrgAcquirer_Click(object sender, EventArgs e)
        {
            bool result;
            if (selectedOrgNode == null && selectedOrgNode.Level < 1)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessSelect(rm, MessageValidate.CancelAcceptOrg), MessageValidate.GetErrorTitle(rm));
                return;
            }
            //if (dgvPartnerList.Rows.Count == 0)
            //{
            //    MessageBoxManager.ShowErrorMessageBox(this, "Tổ chức này không có tổ chức chấp nhận thẻ nên không thực hiện thao tác hủy được!", "Thao Tác Sai");
            //    return;
            //}
            //Show confirmation message box
            if (MessageBoxManager.ShowQuestionMessageBox(this, string.Format("Bạn có chắc muốn hủy tổ chức này liên kết không?", selectedOrgNode.Text)) == DialogResult.Yes)
            {
                try
                {
                    result = (int)Status.SUCCESS == OrganizationFactory.Instance.GetChannel().DeleteOrgAcquirer(StorageService.CurrentSessionId, masterInfo.code, GetPartnerIdSelected());
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
                if (result)
                {
                    LoadMasterList();
                    MessageBoxManager.ShowInfoMessageBox(this, "Đã hủy tổ chức chấp nhận thẻ thành công!");
                }
            }
        }

        #endregion

        #region Partner

        private void dgvMembers_SelectionChanged(object sender, EventArgs e)
        {
            SetShowOrHideUpdateSubOrg();
        }

        private void OnLoadPartnerWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            //if (e.Argument == null || !(e.Argument is OrgFilterDto))
            //{
            //    return;
            //}
            //OrgFilterDto filter = e.Argument as OrgFilterDto;
            //List<CmsOrgCustomerDto> result = null;
            //int totalRecords = 0;
            //int take = LocalSettings.Instance.RecordsPerPage;
            //int skip = 0;
            //currentPageIndex = 1;
            //try
            //{
            //    //PartnerList = OrganizationFactory.Instance.GetChannel().GetPartnerAcquirerList(storageService.CurrentSessionId, selectedOrgNode.Name, filter);

            //}
            //catch (TimeoutException)
            //{
            //    MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.TimeOutExceptionMessage);
            //    PartnerList = null;
            //}
            //catch (FaultException<WcfServiceFault> ex)
            //{
            //    MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
            //    PartnerList = null;
            //}
            //catch (FaultException ex)
            //{
            //    MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.FaultExceptionMessage
            //            + Environment.NewLine + Environment.NewLine
            //            + ex.Message);
            //    PartnerList = null;
            //}
            //catch (CommunicationException)
            //{
            //    MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.CommunicationExceptionMessage);
            //    PartnerList = null;
            //}
            //finally
            //{
            //    if (PartnerList != null)
            //    {
            //        result = PartnerList.Skip(skip).Take(take).ToList();
            //        totalRecords = PartnerList.Count;
            //        //pagerPanel1.ShowNumberOfRecords(totalRecords, result != null ? result.Count : 0, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
            //        //pagerPanel1.UpdatePagingLinks(totalRecords, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
            //    }

            //     = result;
            //}
            e.Result = PartnerList.FirstOrDefault(p => p.OrgCode.Equals(selectedOrgNode.Name));
        }

        private void OnLoadSubOrgWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if (e.Result == null && e.Result is CmsOrgCustomerDto)
            {
                return;
            }
            ToOrgModel((CmsOrgCustomerDto)e.Result);
        }

        private void LoadPartnerDataGridView(List<CmsOrgCustomerDto> result)
        {
            //foreach (CmsOrgCustomerDto partner in result)
            //{
            //    DataRow row = dtbMasterList.NewRow();
            //    row.BeginEdit();

            //    row[colOrgId.DataPropertyName] = partner.OrgId;
            //    row[colOrgCode.DataPropertyName] = partner.OrgCode;
            //    row[colName.DataPropertyName] = partner.Name;
            //    row[colOrgShortName.DataPropertyName] = partner.OrgShortName;
            //    row[colState.DataPropertyName] = partner.State;
            //    row[colCity.DataPropertyName] = partner.City;
            //    row[colCountryCount.DataPropertyName] = partner.CountryCode;
            //    row[colZipCode.DataPropertyName] = partner.ZipCode;
            //    row[colPhoneNo.DataPropertyName] = partner.Phone;
            //    row[colFax.DataPropertyName] = partner.Fax;
            //    row[colEmail.DataPropertyName] = partner.Email;
            //    row[colWebsite.DataPropertyName] = partner.WebSite;
            //    row[colAddress.DataPropertyName] = partner.Address;

            //    row[colContactName.DataPropertyName] = partner.ContactName;
            //    row[colContactEmail.DataPropertyName] = partner.ContactEmail;
            //    row[colContactPhone.DataPropertyName] = partner.ContactPhone;
            //    row[colContactMobile.DataPropertyName] = partner.ContactMobile;
            //    row[colContactFax.DataPropertyName] = partner.ContactFax;
            //    row[colNotes.DataPropertyName] = partner.Notes;

            //    row.EndEdit();
            //    dtbMasterList.Rows.Add(row);
            //}
        }

        #endregion

        #endregion

        #region Event's support

        #region Master

        private void InitTreeList()
        {
            rootNode = new TreeNode();
            rootNode.Text = masterInfo.Name;
            rootNode.Name = "-1";
            trvMaster.Nodes.Add(rootNode);
        }

        private void LoadMasterList()
        {
            if (!loadMasterWorker.IsBusy)
            {
                //dtbMasterList.Rows.Clear();
                rootNode.Nodes.Clear();
                loadMasterWorker.RunWorkerAsync();
            }
        }

        private void SetShowOrHideUpdateOrg()
        {
            bool checkUpdate = selectedOrgNode != null && !String.IsNullOrEmpty(selectedOrgNode.Name);
            btnAddOrgAcquirer.Enabled = btnUpdateOrgAcquirer.Enabled = btnRemoveOrgAcquirer.Enabled = checkUpdate;
        }
        #endregion

        #region Partner

        private void InitPartnerListGrid()
        {
            //dtbMasterList = new DataTable();
            //dtbMasterList.Columns.Add(colOrgId.DataPropertyName);
            //dtbMasterList.Columns.Add(colOrgCode.DataPropertyName);
            //dtbMasterList.Columns.Add(colName.DataPropertyName);
            //dtbMasterList.Columns.Add(colOrgShortName.DataPropertyName);
            //dtbMasterList.Columns.Add(colState.DataPropertyName);
            //dtbMasterList.Columns.Add(colCity.DataPropertyName);
            //dtbMasterList.Columns.Add(colCountryCount.DataPropertyName);
            //dtbMasterList.Columns.Add(colZipCode.DataPropertyName);
            //dtbMasterList.Columns.Add(colPhoneNo.DataPropertyName);
            //dtbMasterList.Columns.Add(colFax.DataPropertyName);
            //dtbMasterList.Columns.Add(colEmail.DataPropertyName);
            //dtbMasterList.Columns.Add(colWebsite.DataPropertyName);
            //dtbMasterList.Columns.Add(colAddress.DataPropertyName);

            //dtbMasterList.Columns.Add(colContactName.DataPropertyName);
            //dtbMasterList.Columns.Add(colContactEmail.DataPropertyName);
            //dtbMasterList.Columns.Add(colContactPhone.DataPropertyName);
            //dtbMasterList.Columns.Add(colContactMobile.DataPropertyName);
            //dtbMasterList.Columns.Add(colContactFax.DataPropertyName);
            //dtbMasterList.Columns.Add(colNotes.DataPropertyName);

            //dgvPartnerList.DataSource = dtbMasterList;
        }

        private void SetShowOrHideUpdateSubOrg()
        {
            //btnRemoveOrgAcquirer1.Enabled = selectedOrgNode != null && !String.IsNullOrEmpty(selectedOrgNode.Name)
            //    && dgvPartnerList.SelectedRows.Count > 0
            //    && Convert.ToInt64(dgvPartnerList.SelectedRows[0].Cells[0].Value.ToString()) > 0;
        }

        private void LoadPartnerList()
        {
            if (!loadPartnerWorker.IsBusy && selectedOrgNode != null)
            {
                //dtbMasterList.Rows.Clear();
                //PartnerList = null;

                //pagerPanel1.ShowMessage("Đang tải dữ liệu, xin hãy chờ...");
                loadPartnerWorker.RunWorkerAsync(GetOrgFilter());
            }
        }

        private OrgFilterDto GetOrgFilter()
        {
            OrgFilterDto filter = new OrgFilterDto();

            //if (cbxFilterBySubOrgName.Checked)
            //{
            //    filter.FilterByOrgName = true;
            //    filter.OrgName = tbxOrgName.Text.Trim();
            //}

            //if (cbxFilterBySubOrgCode.Checked)
            //{
            //    filter.FilterByOrgCode = true;
            //    filter.OrgCode = tbxOrgCode.Text.Trim();
            //}

            return filter;
        }

        private List<long> GetPartnerId()
        {
            List<long> partnerIds = new List<long>();

            foreach (CmsOrgCustomerDto partner in PartnerList)
            {
                partnerIds.Add(partner.OrgId);
            }

            return partnerIds;
        }

        private List<long> GetPartnerIdSelected()
        {
            long orgId = PartnerList.FirstOrDefault(p => p.OrgCode.Equals(selectedOrgNode.Name)).OrgId;
            List<long> partnerIds = new List<long>() { orgId };

            return partnerIds;
        }

        private void ToOrgModel(CmsOrgCustomerDto org)
        {
            txtCode.Text = org.OrgCode;
            txtName.Text = org.Name;
            txtOrgShortName.Text = org.OrgShortName;
            txtState.Text = org.State;
            txtCity.Text = org.City;
            txtCountryCode.Text = org.CountryCode;
            txtZipCode.Text = org.ZipCode;
            txtPhone.Text = org.Phone;
            txtFax.Text = org.Fax;
            txtEmail.Text = org.Email;
            txtWebsite.Text = org.WebSite;
            txtAddress.Text = org.Address;
            txtContactName.Text = org.ContactName;
            txtContactEmail.Text = org.ContactEmail;
            txtContactPhone.Text = org.ContactPhone;
            txtContactPhoneMobile.Text = org.ContactMobile;
            txtNote.Text = org.Notes;

            lbIssuer.Visible = !org.Issuer.Contains(NotMaster);
        }

        private void ClearEmptyControl()
        {
            txtCode.Text =
            txtName.Text =
            txtOrgShortName.Text =
            txtState.Text =
            txtCity.Text =
            txtCountryCode.Text =
            txtZipCode.Text =
            txtPhone.Text =
            txtFax.Text =
            txtEmail.Text =
            txtWebsite.Text =
            txtAddress.Text =
            txtContactName.Text =
            txtContactEmail.Text =
            txtContactPhone.Text =
            txtContactPhoneMobile.Text =
            txtNote.Text = string.Empty;
        }

        #endregion

        private void cbxFilterBySubOrgName_CheckedChanged(object sender, EventArgs e)
        {
            //tbxOrgName.Enabled = cbxFilterBySubOrgName.Checked;
        }

        private void cbxFilterBySubOrgCode_CheckedChanged(object sender, EventArgs e)
        {
            //tbxOrgCode.Enabled = cbxFilterBySubOrgCode.Checked;
        }
        #endregion


    }
}