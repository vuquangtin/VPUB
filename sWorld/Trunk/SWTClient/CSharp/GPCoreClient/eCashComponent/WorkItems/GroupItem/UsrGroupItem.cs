using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;
using sWorldModel.Model;
using sWorldModel.TransportData;
using CommonControls.Custom;
using System.Resources;
using CommonControls;
using JavaCommunication.Factory;
using HomeComponent.WorkItems;
using Microsoft.Practices.CompositeUI;
using sWorldModel;

using Microsoft.Practices.CompositeUI.EventBroker;
using Microsoft.Practices.CompositeUI.Commands;
using sWorldModel.Filters;
using CommonHelper.Config;
using sWorldModel.Exceptions;
using eCashComponent.Contants;
using CommonHelper.Constants;
using JavaCommunication;
using CommonHelper.Utils;
using SystemMgtComponent.Constants;
using eCashComponent;
using System.Globalization;

namespace eCashComponentWorkItems.GroupItem
{
    public partial class UsrGroupItem : CommonUserControl
    {

        #region Properties
        // Height of filter box when it is hidden
        private int hiddenFilterBoxHeight = 0;
        // The original height of filter box (at startup)
        private int startupFilterBoxHeight = 158;
        private int currentPageIndex = 1;
        private ResourceManager rm;

        private DataTable dtbItemList;
        private List<ItemDto> ItemList;

        //partner
        private MasterInfoDTO partnerInfo;
        private long partnerOrgId;

        private BackgroundWorker bgwLoadGroupWorker;
        private BackgroundWorker bgwLoadItemWorker;
        public DialogPostAction PostAction { get; private set; }

        //FILTER
        ItemFilterDto filter;
        private Font startupNodeFont;
        // Selected tree node; cache it to do some effect in UI
        private TreeNode selectedGroupNode;
        private TreeNode selectedGroupParentNode;
        private TreeNode rootNode;

        private eCashWorkItem workItem;

        [ServiceDependency]
        public eCashWorkItem WorkItem
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

        #region CAB events

        [EventPublication(EcashEventTopicName.EcashMgtGroupItemShown)]
        public event EventHandler EcashMgtGroupItemShown;

        [CommandHandler(ECashCommandNames.ShowEcashGroupItem)]
        public void ShowECashGroupMainViewHandler(object s, EventArgs e)
        {
            UsrGroupItem uc = workItem.Items.Get<UsrGroupItem>(ComponentNames.ECashComponentConfigGroupItem);
            if (uc == null)
            {
                uc = workItem.Items.AddNew<UsrGroupItem>(ComponentNames.ECashComponentConfigGroupItem);
            }
            else if (uc.IsDisposed)
            {
                workItem.Items.Remove(uc);
                uc = workItem.Items.AddNew<UsrGroupItem>(ComponentNames.ECashComponentConfigGroupItem);
            }
            workItem.Workspaces[WorkspaceName.MainWorkspace].Show(uc);
            uc.Parent.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm,MenuNames.MenuEcashGroupItem);
        }


        #endregion

        #region Initialization

        public UsrGroupItem()
        {
            InitializeComponent();
            RegistryEvent();
        }
        public void RegistryEvent()
        {
            //Show or hide filter
            btnShowHide.Click += btnShowHide_Click;

            //reload list
            btnReloadGroup.Click += (s, e) => LoadGroupList();
            btnReloadItem.Click += (s, e) => LoadItemList();

            //Tree View
            trvGroup.AfterExpand += trvGroup_AfterExpand;
            trvGroup.BeforeSelect += trvGroup_BeforeSelect;
            trvGroup.AfterSelect += trvGroup_AfterSelect;

            //Load Tree View
            bgwLoadGroupWorker = new BackgroundWorker();
            bgwLoadGroupWorker.WorkerSupportsCancellation = true;
            bgwLoadGroupWorker.DoWork += bgwLoadGroupWorker_DoWork;
            bgwLoadGroupWorker.RunWorkerCompleted += bgwLoadGroupWorker_RunWorkerCompleted;

            //Load Phiếu
            bgwLoadItemWorker = new BackgroundWorker();
            bgwLoadItemWorker.WorkerSupportsCancellation = true;
            bgwLoadItemWorker.DoWork += bgwLoadItemWorker_DoWork;
            bgwLoadItemWorker.RunWorkerCompleted += bgwLoadItemWorker_RunWorkerCompleted;

            //Add - Update - Deleted Group
            btnAddGroup.Click += btnAddGroup_Click;
            btnUpdateGroup.Click += btnUpdateGroup_Click;
            btnRemoveGroup.Click += btnRemoveGroup_Click;

            //Add - Update - Deleted Item
            btnAddItem.Click += btnAddItem_Click;
            btnUpdateItem.Click += btnUpdateItem_Click;
            btnRemoveItem.Click += btnRemoveItem_Click;

            Enter += (s, e) =>
            {
                if (EcashMgtGroupItemShown != null)
                {
                    EcashMgtGroupItemShown(this, EventArgs.Empty);
                }
            };
            // Assign startup value
            startupNodeFont = trvGroup.Font;
            //dgvItem.SelectionChanged += dgvGroup_SelectionChanged;

            Load += OnFormLoad;
        }

        private void OnFormLoad(object sender, EventArgs e)
        {
            LoadPartnerInfo();
            InitTreeList();
            InitItemGrid();
            LoadGroupList();
            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
        }

        #endregion Initialization

        #region Event's

        #region Group

        private void bgwLoadGroupWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = EcashConfigFactory.Instance.GetChannel().GetAllGroupItem(StorageService.CurrentSessionId);
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

        private void bgwLoadGroupWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }

            // Get result from DoWork method

            if (e.Result != null)
            {
                int i = 0;
                List<GroupDto> result = (List<GroupDto>)e.Result;
                foreach (GroupDto group in result)
                {
                    i++;
                    TreeNode groupNode = new TreeNode();
                    groupNode.Text = group.Name;
                    groupNode.Name = Convert.ToString(group.Id);

                    rootNode.Nodes.Add(groupNode);
                }
            }
        }

        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            FrmAddGroup dialog = new FrmAddGroup(FrmAddGroup.ModeAdding, partnerInfo.MasterId);
            workItem.SmartParts.Add(dialog);
            dialog.ShowDialog();
            workItem.SmartParts.Remove(dialog);
            dialog.Dispose();
            LoadGroupList();
        }

        private void btnUpdateGroup_Click(object sender, EventArgs e)
        {
            if (selectedGroupNode == null && string.IsNullOrEmpty(selectedGroupNode.Name) && Convert.ToInt64(selectedGroupNode.Name) > 0)
                return;

            FrmAddGroup dialog = new FrmAddGroup(FrmAddGroup.ModeUpdating, partnerInfo.MasterId, Convert.ToInt64(selectedGroupNode.Name));
            workItem.SmartParts.Add(dialog);
            dialog.ShowDialog();
            workItem.SmartParts.Remove(dialog);
            dialog.Dispose();
            LoadGroupList();
        }

        private void btnRemoveGroup_Click(object sender, EventArgs e)
        {
            bool result;

            //Show confirmation message box
            if (MessageBoxManager.ShowQuestionMessageBox(this, MessageValidate.GetMessCancelRequest(rm, MessageValidate.CancelCardGroup)) == DialogResult.Yes)
            {
                try
                {
                    result = (int)Status.SUCCESS == EcashConfigFactory.Instance.GetChannel().DeleteGroupItem(StorageService.CurrentSessionId, Convert.ToInt64(selectedGroupNode.Name));
                }
                catch (TimeoutException)
                {
                    MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.TimeOutExceptionMessage);
                    return;
                }
                catch (FaultException<WcfServiceFault> ex)
                {
                    MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
                    return;
                }
                catch (FaultException ex)
                {
                    MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.FaultExceptionMessage
                            + Environment.NewLine + Environment.NewLine
                            + ex.Message);
                    return;
                }
                catch (CommunicationException)
                {
                    MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.CommunicationExceptionMessage);
                    return;
                }
                // Check return result
                if (result != null && result)
                {
                    LoadGroupList();
                    MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetRemoveMessageSuccess(rm, MessageValidate.CancelCardGroup));
                }
                else
                {
                    MessageBoxManager.ShowErrorMessageBox(this, ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MessageValidate.MemCancelFail));
                }
            }
        }

        #endregion

        #region Item

        void bgwLoadItemWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = EcashConfigFactory.Instance.GetChannel().GetItemFilterListByGroupId(StorageService.CurrentSessionId, Convert.ToInt64(selectedGroupNode.Name),filter);
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

        void bgwLoadItemWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if (e.Result == null)
            {
                return;
            }
            List<ItemDto> result = (List<ItemDto>)e.Result;
            LoadItemDataGridView(result);
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (selectedGroupNode != null && selectedGroupNode.Level == 1) 
            {
                long groupItemId = Convert.ToInt64(selectedGroupNode.Name);
                FrmAddItem dialog = new FrmAddItem(FrmAddItem.ModeAdding, groupItemId);
                workItem.SmartParts.Add(dialog);
                dialog.ShowDialog();
                workItem.SmartParts.Remove(dialog);
                dialog.Dispose();
                LoadItemList();
            }
        }

        private void btnUpdateItem_Click(object sender, EventArgs e)
        {
            if (selectedGroupNode != null && selectedGroupNode.Level == 1 && dgvItem.SelectedRows.Count > 0)
            {
                long groupItemId = Convert.ToInt64(selectedGroupNode.Name);
                long itemId = Convert.ToInt64(dgvItem.SelectedRows[0].Cells[colId.Index].Value);
                FrmAddItem dialog = new FrmAddItem(FrmAddItem.ModeUpdating, groupItemId, itemId);
                workItem.SmartParts.Add(dialog);
                dialog.ShowDialog();
                workItem.SmartParts.Remove(dialog);
                dialog.Dispose();
                LoadItemList();
            }
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            bool result;
            if (dgvItem.SelectedRows.Count == 0) 
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessSelect(rm, MessageValidate.CancelMem), MessageValidate.GetErrorTitle(rm));
                return;
            }

            //Show confirmation message box
            if (MessageBoxManager.ShowQuestionMessageBox(this, MessageValidate.GetMessCancelRequest(rm, MessageValidate.CancelCardItem)) == DialogResult.Yes)
            {
                try
                {
                    result = (int)Status.SUCCESS == EcashConfigFactory.Instance.GetChannel().DeleteItem(StorageService.CurrentSessionId, Convert.ToInt64(dgvItem.SelectedRows[0].Cells[colId.Index].Value));
                }
                catch (TimeoutException)
                {
                    MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.TimeOutExceptionMessage);
                    return;
                }
                catch (FaultException<WcfServiceFault> ex)
                {
                    MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
                    return;
                }
                catch (FaultException ex)
                {
                    MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.FaultExceptionMessage
                            + Environment.NewLine + Environment.NewLine
                            + ex.Message);
                    return;
                }
                catch (CommunicationException)
                {
                    MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.CommunicationExceptionMessage);
                    return;
                }
                // Check return result
                if (result != null && result)
                {
                    LoadItemList();
                    MessageBoxManager.ShowInfoMessageBox(this, "Đã hủy danh mục thành công!");
                }
                else
                {
                    MessageBoxManager.ShowErrorMessageBox(this, ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MessageValidate.MemCancelFail));
                }
            }
        }

        #endregion

        private void btnShowHide_Click(object sender, EventArgs e)
        {
            if (pnlFilterBox.Height == hiddenFilterBoxHeight)
            {
                pnlFilterBox.Height = startupFilterBoxHeight;
                pnlFilterBox.Height = startupFilterBoxHeight;
                btnShowHide.Text = btnShowHide.ToolTipText = "Ẩn Khung Tìm Kiếm";
                btnShowHide.ToolTipText = "Ẩn khung tìm kiếm";
                btnShowHide.Image = global::CommonControls.Properties.Resources.ArrowUp_16x16;
            }
            else
            {
                pnlFilterBox.Height = hiddenFilterBoxHeight;
                btnShowHide.Text = btnShowHide.ToolTipText = "Hiện Khung Tìm Kiếm";
                btnShowHide.ToolTipText = "Hiện khung tìm kiếm";
                btnShowHide.Image = global::CommonControls.Properties.Resources.ArrowDown_16x16;
            }
        }

        private void trvGroups_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeNode node = trvGroup.GetNodeAt(trvGroup.PointToClient(Control.MousePosition));
                if (node != null)
                {
                    trvGroup.SelectedNode = node;
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

        private void trvGroup_AfterExpand(object sender, TreeViewEventArgs e)
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
                trvGroup.SelectedNode = null;
            }
        }

        private void trvGroup_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            // If background worker is running -> restrict selecting another node
            if (bgwLoadGroupWorker.IsBusy)
            {
                e.Cancel = true;
                return;
            }

            // Change node font style to normal
            if (selectedGroupNode != null)
            {
                selectedGroupNode.NodeFont = new Font(startupNodeFont, FontStyle.Regular);
                selectedGroupNode.Text = selectedGroupNode.Text;
            }
        }

        private void trvGroup_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectedNode = e.Node;
            TreeNode parentNode = new TreeNode();
            if (selectedNode != null)
            {
                parentNode = selectedNode.Parent;
                selectedNode.NodeFont = new Font(startupNodeFont, FontStyle.Bold);
                selectedNode.Text = selectedNode.Text;

                if (selectedGroupNode != null && selectedNode == selectedGroupNode)
                {
                    return;
                }

                selectedGroupNode = selectedNode;
                if (selectedGroupNode.Level == 1)
                    LoadItemList();

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
            dtbItemList.Rows.Clear();
            int take = LocalSettings.Instance.RecordsPerPage;
            int skip = (currentPageIndex - 1) * take;

            List<ItemDto> result = ItemList.Skip(skip).Take(take).ToList();
            LoadItemDataGridView(result);

            pagerPanel1.ShowNumberOfRecords(ItemList.Count, result != null ? result.Count : 0, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
            pagerPanel1.UpdatePagingLinks(ItemList.Count, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
        }


        private void cbxFilterByItemName_CheckedChanged_1(object sender, EventArgs e)
        {
            tbxItemName.Enabled = cbxFilterByItemName.Checked;
        }

        private void cbxFilterByPriceCode_CheckedChanged_1(object sender, EventArgs e)
        {
            tbxMemberPrice.Enabled = cbxFilterByPriceCode.Checked;
        }

        private void cbxFilterByApplyTime_CheckedChanged(object sender, EventArgs e)
        {
            dtpApplyTimeFrom.Enabled = dtpApplyTimeTo.Enabled = cbxFilterByApplyTime.Checked;
        }

        private void dtpApplyTimeFrom_ValueChanged(object sender, EventArgs e)
        {
            dtpApplyTimeTo.MinDate = dtpApplyTimeFrom.Value.Date;
        }

        private void dtpApplyTimeTo_ValueChanged(object sender, EventArgs e)
        {
            dtpApplyTimeFrom.MaxDate = dtpApplyTimeTo.Value.Date;
        }
        #endregion

        #region Event's Support

        #region Group

        private void InitTreeList()
        {
            rootNode = new TreeNode();
            rootNode.Text = partnerInfo.Name;
            rootNode.Name = "-1";
            trvGroup.Nodes.Add(rootNode);
        }

        private void LoadGroupList()
        {
            if (!bgwLoadGroupWorker.IsBusy)
            {
                dtbItemList.Rows.Clear();
                rootNode.Nodes.Clear();
                bgwLoadGroupWorker.RunWorkerAsync();
            }
        }

        #endregion

        #region Item

        private ItemFilterDto GetRuleFilter()
        {
            ItemFilterDto filter = new ItemFilterDto();

            if (cbxFilterByItemName.Checked)
            {
                tbxItemName.Text = tbxItemName.Text.Trim();
                if (tbxItemName.Text.Length < 2)
                {
                    Invoke(new Action(() => { lblNotification1.Visible = true; }));
                    return null;
                }
                else
                {
                    Invoke(new Action(() => { lblNotification1.Visible = false; }));
                }
                filter.FilterByName = true;
                filter.Name = tbxItemName.Text;
            }
            if (cbxFilterByPriceCode.Checked)
            {
                tbxMemberPrice.Text = tbxMemberPrice.Text.Trim();
                if (tbxMemberPrice.Text.Length < 2)
                {
                    Invoke(new Action(() => { lblNotification2.Visible = true; }));
                    return null;
                }
                else
                {
                    Invoke(new Action(() => { lblNotification2.Visible = false; }));
                }
                filter.FilterByPrice = true;
                filter.Price = Convert.ToDouble(tbxMemberPrice.Text);
            }
            if (cbxFilterByApplyTime.Checked)
            {
                filter.FilterBystatisticItemDate = true;

                StatisticPayInDate payinFromTo = new StatisticPayInDate();
                payinFromTo.DateIn = dtpApplyTimeFrom.Value.ToStringFormatDateServeryyyyMMdd().Trim();
                payinFromTo.DateOut = dtpApplyTimeTo.Value.ToStringFormatDateServeryyyyMMdd().Trim();
                filter.statisticItemDate = payinFromTo;


            }

            return filter;
        }
        //private void LoadRuleList()
        //{
        //    if (!bgwLoadItemWorker.IsBusy)
        //    {
        //        dtbItemList.Rows.Clear();
        //        ItemList = null;
        //        filter = GetRuleFilter();
        //        pagerPanel1.ShowMessage("Đang tải dữ liệu, xin hãy chờ...");
        //        bgwLoadItemWorker.RunWorkerAsync();
        //    }
        //}
        private void InitItemGrid()
        {
            dtbItemList = new DataTable();
            dtbItemList.Columns.Add(colId.DataPropertyName);
            dtbItemList.Columns.Add(colItemName.DataPropertyName);
            dtbItemList.Columns.Add(colprice.DataPropertyName);
            dtbItemList.Columns.Add(colStatus.DataPropertyName);
            dtbItemList.Columns.Add(colStartDate.DataPropertyName);
            dtbItemList.Columns.Add(colEndDate.DataPropertyName);
            dtbItemList.Columns.Add(colDescription.DataPropertyName);
            dgvItem.DataSource = dtbItemList;
        }

        private void LoadItemDataGridView(List<ItemDto> result)
        {
            foreach (ItemDto item in result)
            {
                DataRow row = dtbItemList.NewRow();
                row.BeginEdit();

                row[colId.DataPropertyName] = item.Id;
                row[colItemName.DataPropertyName] = item.Name;
                row[colprice.DataPropertyName] = item.Price.ToString("N0", CultureInfo.InvariantCulture);
                row[colStartDate.DataPropertyName] = item.StartDate;
                row[colEndDate.DataPropertyName] = item.EndDate;
                row[colStatus.DataPropertyName] = item.Status;
                row[colDescription.DataPropertyName] = item.Description;

                row.EndEdit();
                dtbItemList.Rows.Add(row);
            }
        }

        private void LoadItemList()
        {
            if (!bgwLoadItemWorker.IsBusy && selectedGroupNode != null)
            {
                dtbItemList.Rows.Clear();
                filter = GetRuleFilter();
                ItemList = null;
                pagerPanel1.ShowMessage("Đang tải dữ liệu, xin hãy chờ...");
                bgwLoadItemWorker.RunWorkerAsync();
            }
        }

        #endregion

        private void LoadPartnerInfo()
        {
            try
            {
                this.partnerInfo = OrganizationFactory.Instance.GetChannel().GetMasterInfo(StorageService.CurrentSessionId, SystemSettings.Instance.Partner);
                this.partnerOrgId = partnerInfo.MasterId;
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

        #endregion

      
       
    }
}
