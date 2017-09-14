using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonControls.Custom;
using Microsoft.Practices.CompositeUI.Commands;
using VoucherGiftCardComponent.Constants;
using Microsoft.Practices.CompositeUI;
using sWorldModel;
using CommonHelper.Constants;
using CommonControls;
using sWorldModel.Exceptions;
using JavaCommunication.Factory;
using sWorldModel.TransportData;
using CommonHelper.Utils;
using CommonHelper.Config;
using ImageAccessor;
using sWorldModel.Filters;
using System.ServiceModel;
using JavaCommunication;
using Microsoft.Practices.CompositeUI.EventBroker;
using SystemMgtComponent.Constants;
using sWorldModel.TransportData.Constants;
using System.Resources;

namespace VoucherGiftCardComponent.WorkItems
{
    public partial class UcRuleVoucherGift : CommonUserControl
    {
        #region Properties

        // Height of filter box when it is hidden
        private int hiddenFilterBoxHeight = 0;
        // The original height of filter box (at startup)
        private int startupFilterBoxHeight = 105;
        private int currentPageIndex = 1;
        private ResourceManager rm;
 
        // Data table that contains user records
        private DataTable dtbRuleList;
        private List<VoucherGift> VoucherList;
        //private List<VoucherGift> voucherListInfo;

        //private PartnerInfoDTO partner = null;
        private MasterInfoDTO partnerInfo;
        private long partnerOrgId;

        //private BackgroundWorker loadOrgWorker;
        private BackgroundWorker bgwLoadVoucherGift;

        //filter;
        VoucherGiftFilterDto filter;
       
        private VoucherGiftCardWorkItem workItem;

        [ServiceDependency]
        public VoucherGiftCardWorkItem WorkItem
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

        [EventPublication(VoucherEventTopicNames.VoucherRuleMgtMainShown)]
        public event EventHandler VoucherRuleMgtMainShown;

        [CommandHandler(VoucherGiftCardCommandNames.ShowVoucherGiftCardUpdate)]
        public void ShowCardMgtMainHandler(object s, EventArgs e)
        {
            UcRuleVoucherGift uc = workItem.Items.Get<UcRuleVoucherGift>(ComponentNames.VoucherGiftCardComponent);
            if (uc == null)
            {
                uc = workItem.Items.AddNew<UcRuleVoucherGift>(ComponentNames.VoucherGiftCardComponent);
            }
            else if (uc.IsDisposed)
            {
                workItem.Items.Remove(uc);
                uc = workItem.Items.AddNew<UcRuleVoucherGift>(ComponentNames.VoucherGiftCardComponent);
            }
            workItem.Workspaces[WorkspaceName.MainWorkspace].Show(uc);
            uc.Parent.Text = MenuNames.MenuVoucherCardConfigRule;
        }
        #endregion

        #region Initialization

        public UcRuleVoucherGift()
        {
            InitializeComponent();
            RegisterEvent();
            InitDataTableVoucherGift();
        }

        private void RegisterEvent()
        {           
            //Load Voucher
            bgwLoadVoucherGift = new BackgroundWorker();
            bgwLoadVoucherGift.WorkerSupportsCancellation = true;
            bgwLoadVoucherGift.DoWork += OnLoadVoucherWorkerDoWork;
            bgwLoadVoucherGift.RunWorkerCompleted += OnLoadVoucherWorkerCompleted;            

            //Show or hide filter
            btnShowHide.Click += btnShowHide_Click;

            //Add - Update - Deleted Voucher
            btnAddRule.Click += btnAddRule_Click;
            btnUpdateRule.Click += btnUpdateRule_Click;
            btnRemoveRule.Click += btnRemoveRule_Click;

            //reload list         
            btnReloadRule.Click += (s, e) => LoadRuleList();

            pagerPanel1.LinkLabelClicked += pagerPanel_LinkLabelClicked;

            Enter += (s, e) =>
            {
                if (VoucherRuleMgtMainShown != null)
                {
                    VoucherRuleMgtMainShown(this, EventArgs.Empty);
                }
            };

            Load += OnFormLoad;               
        }

        private void OnFormLoad(object sender, EventArgs e)
        {   
            LoadCombobox();
            LoadPartnerInfo();
            LoadRuleList();
            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
        }

        private void LoadCombobox()
        {
            // Loai Card status to combobox
            List<TypeCard> tatusTypeCard = VoucherCombobox.GetVoucherList();
            DataTable dtbVoucher = new DataTable();
            dtbVoucher.Columns.Add("Id");
            dtbVoucher.Columns.Add("Name");
            foreach (TypeCard ct in tatusTypeCard)
            {
                DataRow row = dtbVoucher.NewRow();
                row.BeginEdit();
                row["Id"] = (int)ct;
                row["Name"] = ct.GetName();
                row.EndEdit();
                dtbVoucher.Rows.Add(row);
            }
            cbTypeCard.DataSource = dtbVoucher;
            cbTypeCard.ValueMember = "Id";
            cbTypeCard.DisplayMember = "Name";

            // Vi tri status to combobox
            List<Location> tatusLocation = VoucherCombobox.GetLocationList();
            DataTable dtbLocation = new DataTable();
            dtbLocation.Columns.Add("Id");
            dtbLocation.Columns.Add("Name");
            foreach (Location ct in tatusLocation)
            {
                DataRow row = dtbLocation.NewRow();
                row.BeginEdit();
                row["Id"] = (int)ct;
                row["Name"] = ct.GetName();
                row.EndEdit();
                dtbLocation.Rows.Add(row);
            }
            cbLocation.DataSource = dtbLocation;
            cbLocation.ValueMember = "Id";
            cbLocation.DisplayMember = "Name";

            cbTypeCard.SelectedIndex = cbLocation.SelectedIndex = 0;
        }

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

        #endregion Initialization        

        #region Contructors of Member

        private void InitDataTableVoucherGift()
        {
            dtbRuleList = new DataTable();
            dtbRuleList.Columns.Add(colId.DataPropertyName);
            dtbRuleList.Columns.Add(colTitle.DataPropertyName);
            dtbRuleList.Columns.Add(colTypeCard.DataPropertyName);
            dtbRuleList.Columns.Add(colLocation.DataPropertyName);
            dtbRuleList.Columns.Add(colGender.DataPropertyName);
            dtbRuleList.Columns.Add(colDateBegin.DataPropertyName);
            dtbRuleList.Columns.Add(colDateEnd.DataPropertyName);
            dtbRuleList.Columns.Add(colDescription.DataPropertyName);
            dgvRulesVoucherGift.DataSource = dtbRuleList;
        }

        private void SetShowOrHideButton(bool edit)
        {
            btnAddRule.Enabled = btnUpdateRule.Enabled =
            btnRemoveRule.Enabled = btnReloadRule.Enabled = edit;
        }

        private void LoadRuleList()
        {
            if (!bgwLoadVoucherGift.IsBusy)
            {
                dtbRuleList.Rows.Clear();
                VoucherList = null;
                filter = GetRuleFilter();
                pagerPanel1.ShowMessage("Đang tải dữ liệu, xin hãy chờ...");
                bgwLoadVoucherGift.RunWorkerAsync();
            }
        }

        private void ShowOrHideButtonMemberAction(bool isShow)
        {
            btnUpdateRule.Enabled = btnRemoveRule.Enabled = isShow;
        }
        
        #endregion Contructors of Member

        #region Form events

        private void OnLoadVoucherWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            int totalRecords = 0;
            int take = LocalSettings.Instance.RecordsPerPage;
            int skip = 0;
            currentPageIndex = 1;
            List<VoucherGift> result = null;
            try
            {
                VoucherList = VoucherGiftFactory.Instance.GetChannel().GetVoucherFilterListByOrgID(StorageService.CurrentSessionId, partnerInfo.MasterId, filter);
            }
            catch (NullReferenceException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.InformNotExistData);
                VoucherList = null;
            }
            catch (TimeoutException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.TimeOutExceptionMessage);
                VoucherList = null;
            }
            catch (FaultException<WcfServiceFault> ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
                VoucherList = null;
            }
            catch (FaultException ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.FaultExceptionMessage
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
                VoucherList = null;
            }
            catch (CommunicationException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.CommunicationExceptionMessage);
                VoucherList = null;
            }
            finally
            {
                if (VoucherList != null)
                {
                    result = VoucherList.Skip(skip).Take(take).ToList();
                    totalRecords = VoucherList.Count;
                    pagerPanel1.ShowNumberOfRecords(totalRecords, result != null ? result.Count : 0, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
                    pagerPanel1.UpdatePagingLinks(totalRecords, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
                }
                e.Result = result;
            }
        }

        private void OnLoadVoucherWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if (e.Result == null)
            {
                return;
            }
            List<VoucherGift> result = (List<VoucherGift>)e.Result;
            LoadRuleDataGridView(result);
        }

        private void LoadRuleDataGridView(List<VoucherGift> result)
        {
            foreach (VoucherGift mc in result)
            {
                DataRow row = dtbRuleList.NewRow();
                row.BeginEdit();

                row[colId.DataPropertyName] = mc.id;
                row[colTitle.DataPropertyName] = mc.title;
 
                row[colTypeCard.DataPropertyName] = VoucherCombobox.ToTypeCardStatus(Convert.ToInt32(mc.type)).GetName();
 
                row[colLocation.DataPropertyName] = VoucherCombobox.ToLocationStatus(Convert.ToInt32(mc.area)).GetName();

                string s = mc.gender.ToString();
                if (s.Length > 1)
                {
                    string s1 = GenderExtMethod.ToGender(1).GetName();
                    string s2 = GenderExtMethod.ToGender(2).GetName();
                    row[colGender.DataPropertyName] = s1 + "; " + s2;
                }
                else
                    row[colGender.DataPropertyName] = GenderExtMethod.ToGender(mc.gender).GetName();
                //row[colGender.DataPropertyName] = GenderExtMethod.ToGender(Convert.ToInt32(mc.gender)).GetName();

                row[colDateBegin.DataPropertyName] = mc.dateBegin;
                row[colDateEnd.DataPropertyName] = mc.dateEnd;
                row[colDescription.DataPropertyName] = mc.description;

                row.EndEdit();
                dtbRuleList.Rows.Add(row);
            }
        }
        
        [CommandHandler(OrganizationCommandNames.AddOrg)]
        private void btnAddRule_Click(object sender, EventArgs e)
        {
            // Show GroupDetail dialog and delegate this task to it
            FrmAddOrUpdateRuleVoucherGift dialog = new FrmAddOrUpdateRuleVoucherGift(FrmAddOrUpdateRuleVoucherGift.ModeAdding, partnerInfo.MasterId);//masterInfo.MasterId, Convert.ToInt64(selectedOrgNode.Name)
            workItem.SmartParts.Add(dialog);
            dialog.ShowDialog();
            workItem.SmartParts.Remove(dialog);
            LoadRuleList();
        }

        [CommandHandler(OrganizationCommandNames.UpdateOrg)]
        private void btnUpdateRule_Click(object sender, EventArgs e)
        {        
            if (dgvRulesVoucherGift.SelectedRows.Count > 0)
            {
                long voucherId = Convert.ToInt64(dgvRulesVoucherGift.SelectedRows[0].Cells[0].Value.ToString());
                // Show GroupDetail dialog and delegate this task to it
                FrmAddOrUpdateRuleVoucherGift dialog = new FrmAddOrUpdateRuleVoucherGift(FrmAddOrUpdateRuleVoucherGift.ModeUpdating, partnerInfo.MasterId, voucherId);//masterInfo.MasterId, Convert.ToInt64(selectedOrgNode.Name), memberId
                workItem.SmartParts.Add(dialog);
                dialog.ShowDialog();
                workItem.SmartParts.Remove(dialog);
                dialog.Dispose();
            }
            LoadRuleList();
        }

        [CommandHandler(OrganizationCommandNames.RemoveOrg)]
        private void btnRemoveRule_Click(object sender, EventArgs e)
        {
            bool result;
            if (dgvRulesVoucherGift.SelectedRows.Count == 0)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessSelect(rm, MessageValidate.CancelCoupon), MessageValidate.GetErrorTitle(rm));
                return;
            }

            //Show confirmation message box
            if (MessageBoxManager.ShowQuestionMessageBox(this, "Bạn có chắc muốn hủy cấu hình phiếu này không?") == System.Windows.Forms.DialogResult.Yes)
            {
                long voucherId = Convert.ToInt64(dgvRulesVoucherGift.SelectedRows[0].Cells[0].Value.ToString());
                try
                {
                    result = (int)Status.SUCCESS == VoucherGiftFactory.Instance.GetChannel().RemoveVoucherGift(StorageService.CurrentSessionId, voucherId);
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
                if (result)
                {
                    LoadRuleList();
                    MessageBoxManager.ShowInfoMessageBox(this, "Đã hủy cấu hình phiếu thành công!");
                }
                else
                {
                    MessageBoxManager.ShowErrorMessageBox(this, ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MessageValidate.GiftVoucher_CancelVoucher));
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
            dtbRuleList.Rows.Clear();
            int take = LocalSettings.Instance.RecordsPerPage;
            int skip = (currentPageIndex - 1) * take;

            List<VoucherGift> result = VoucherList.Skip(skip).Take(take).ToList();
            LoadRuleDataGridView(result);

            pagerPanel1.ShowNumberOfRecords(VoucherList.Count, result != null ? result.Count : 0, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
            pagerPanel1.UpdatePagingLinks(VoucherList.Count, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
        }

        private VoucherGiftFilterDto GetRuleFilter()
        {
            VoucherGiftFilterDto filter = new VoucherGiftFilterDto();

            if (cbxFilterByTitle.Checked)
            {
                tbxMemberTitle.Text = tbxMemberTitle.Text.Trim();
                if (tbxMemberTitle.Text.Length < 2)
                {
                    Invoke(new Action(() => { lblNotification1.Visible = true; }));
                    return null;
                }
                else
                {
                    Invoke(new Action(() => { lblNotification1.Visible = false; }));
                }
                filter.FilterByTitle = true;
                filter.Title = tbxMemberTitle.Text;
            }
            if (cbxFilterByVoucherGift.Checked)
            {
                filter.FilterByTypeCard = true;
                filter.TypeCard = cbTypeCard.SelectedValue.ToString();
            }
            if (cbxFilterByLocation.Checked)
            {
                //if (cbMemberLocation.SelectedIndex != -1)
                //{
                //    Invoke(new Action(() => { lblNotification1.Visible = false; }));
                //}
                filter.FilterByLocation = true;
                filter.Location = cbLocation.SelectedValue.ToString();
            }

            return filter;
        }     

        #region Control

        private void btnShowHide_Click(object sender, EventArgs e)
        {
            if (pnlFilterBox.Height == hiddenFilterBoxHeight)
            {
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
        
        # endregion

        private void cbxFilterByMemberTitle_CheckedChanged(object sender, EventArgs e)
        {
            tbxMemberTitle.Enabled = cbxFilterByTitle.Checked;
        }

        private void cbxFilterByMemberVoucherGift_CheckedChanged(object sender, EventArgs e)
        {
            cbTypeCard.Enabled = cbxFilterByVoucherGift.Checked;
        }

        private void cbxFilterByMemberLocation_CheckedChanged(object sender, EventArgs e)
        {
            cbLocation.Enabled = cbxFilterByLocation.Checked;
        }
 
        #endregion
    }
}
