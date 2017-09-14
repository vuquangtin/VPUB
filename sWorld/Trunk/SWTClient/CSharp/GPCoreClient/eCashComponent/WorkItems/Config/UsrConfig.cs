using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using CommonHelper.Utils;
using System.Windows.Forms;
using CommonControls.Custom;
using System.Resources;
using sWorldModel.Filters;
using CommonHelper.Constants;
using sWorldModel.TransportData;
using Microsoft.Practices.CompositeUI.Commands;
using Microsoft.Practices.CompositeUI;
using HomeComponent.WorkItems;
using sWorldModel;
using Microsoft.Practices.CompositeUI.EventBroker;
using CommonHelper.Constants;
using CommonHelper.Config;
using JavaCommunication.Factory;
using CommonControls;
using System.ServiceModel;
using SystemMgtComponent.Constants;
using eCashComponent.Contants;
using sWorldModel.Exceptions;
using JavaCommunication;
using System.Globalization;

namespace eCashComponent.WorkItems.Config
{
    public partial class UsrConfig : CommonUserControl
    {
        #region Properties

        // Height of filter box when it is hidden
        private int hiddenFilterBoxHeight = 0;
        // The original height of filter box (at startup)
        private int startupFilterBoxHeight = 105;
        private int currentPageIndex = 1;
        private ResourceManager rm;

        // Data table that contains user records
        private DataTable dtbConfigList;
        private List<Config_card> EcashList;

        private MasterInfoDTO partnerInfo;
        private long partnerOrgId;

        //private BackgroundWorker loadOrgWorker;
        private BackgroundWorker bgwLoadEcashConfig;

        //filter;
        EcashConfigFilterDto filter;

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

        #region Contructors

        public UsrConfig()
        {
            InitializeComponent();
            RegisterEvent();
            InitDataTableEcashConfig();
        }
        private void InitDataTableEcashConfig()
        {
            dtbConfigList = new DataTable();
            dtbConfigList.Columns.Add(colId.DataPropertyName);
            dtbConfigList.Columns.Add(colName.DataPropertyName);
            dtbConfigList.Columns.Add(colStartDate.DataPropertyName);
            dtbConfigList.Columns.Add(colAmount.DataPropertyName);
            dtbConfigList.Columns.Add(colEndDate.DataPropertyName);
            dtbConfigList.Columns.Add(colDescription.DataPropertyName);
            dgvEcashConfig.DataSource = dtbConfigList;
        }

        #endregion Contructors

        #region CAB events

        [EventPublication(ECashCommandNames.ShowEcashConfig)]
        public event EventHandler ShowEcashConfig;

        [CommandHandler(ECashCommandNames.ShowEcashConfig)]
        public void ShowECashConfigMainViewHandler(object s, EventArgs e)
        {
            UsrConfig uc = workItem.Items.Get<UsrConfig>(ComponentNames.ECashComponentConfig);
            if (uc == null)
            {
                uc = workItem.Items.AddNew<UsrConfig>(ComponentNames.ECashComponentConfig);
            }
            else if (uc.IsDisposed)
            {
                workItem.Items.Remove(uc);
                uc = workItem.Items.AddNew<UsrConfig>(ComponentNames.ECashComponentConfig);
            }
            workItem.Workspaces[WorkspaceName.MainWorkspace].Show(uc);
            uc.Parent.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuEcashConfig);
        }

        #endregion

        #region Initialization
        private void RegisterEvent()
        {
            //Load EcashConfig
            bgwLoadEcashConfig = new BackgroundWorker();
            bgwLoadEcashConfig.WorkerSupportsCancellation = true;
            bgwLoadEcashConfig.DoWork += OnLoadEcashConfigWorkerDoWork;
            bgwLoadEcashConfig.RunWorkerCompleted += OnLoadEcashConfigWorkerCompleted;

            //Show or hide filter
            btnShowHide.Click += btnShowHide_Click;

            //Add - Update - Deleted Voucher
            btnAddConfig.Click += btnAddConfig_Click;
            btnUpdateConfig.Click += btnUpdateConfig_Click;
            btnRemoveConfig.Click += btnRemoveConfig_Click;

            //reload list         
            btnReloadConfig.Click += (s, e) => LoadRuleList();

            pagerPanel1.LinkLabelClicked += pagerPanel_LinkLabelClicked;

            Enter += (s, e) =>
            {
                if (ShowEcashConfig != null)
                {
                    ShowEcashConfig(this, EventArgs.Empty);
                }
            };

            Load += OnFormLoad;
        }

        #endregion Initialization

        #region Form events

        private void OnFormLoad(object sender, EventArgs e)
        {
            LoadPartnerInfo();
            LoadRuleList();
            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
        }
        private void OnLoadEcashConfigWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            int totalRecords = 0;
            int take = LocalSettings.Instance.RecordsPerPage;
            int skip = 0;
            currentPageIndex = 1;
            List<Config_card> result = null;
            try
            {
                EcashList = EcashConfigFactory.Instance.GetChannel().GetConfigFilterListByConfigId(StorageService.CurrentSessionId,0,filter);
            }
            catch (NullReferenceException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.InformNotExistData);
                EcashList = null;
            }
            catch (TimeoutException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.TimeOutExceptionMessage);
                EcashList = null;
            }
            catch (FaultException<WcfServiceFault> ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
                EcashList = null;
            }
            catch (FaultException ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.FaultExceptionMessage
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
                EcashList = null;
            }
            catch (CommunicationException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.CommunicationExceptionMessage);
                EcashList = null;
            }
            finally
            {
                if (EcashList != null)
                {
                    result = EcashList.Skip(skip).Take(take).ToList();
                    totalRecords = EcashList.Count;
                    pagerPanel1.ShowNumberOfRecords(totalRecords, result != null ? result.Count : 0, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
                    pagerPanel1.UpdatePagingLinks(totalRecords, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
                }
                e.Result = result;
            }
        }

        private void OnLoadEcashConfigWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if (e.Result == null)
            {
                return;
            }
            List<Config_card> result = (List<Config_card>)e.Result;
            LoadDataGridView(result);
        }
        private void LoadDataGridView(List<Config_card> result)
        {
            foreach (Config_card mc in result)
            {
                DataRow row = dtbConfigList.NewRow();
                row.BeginEdit();

                row[colId.DataPropertyName] = mc.Id;
                row[colName.DataPropertyName] = mc.Name;

                row[colStartDate.DataPropertyName] = mc.StartDate;
                row[colEndDate.DataPropertyName] = mc.EndDate;
                row[colAmount.DataPropertyName] = mc.Amount.ToString("N0", CultureInfo.InvariantCulture);
                row[colDescription.DataPropertyName] = mc.Description;

                row.EndEdit();
                dtbConfigList.Rows.Add(row);
            }
        }

        private EcashConfigFilterDto GetRuleFilter()
        {
            EcashConfigFilterDto filter = new EcashConfigFilterDto();

            if (cbxFilterByCardConfigName.Checked)
            {
                tbxConfigTypeTransaction.Text = tbxConfigTypeTransaction.Text.Trim();
                if (cbxFilterByCardConfigName.Text.Length < 2)
                {
                    Invoke(new Action(() => { lblNotification1.Visible = true; }));
                    return null;
                }
                else
                {
                    Invoke(new Action(() => { lblNotification1.Visible = false; }));
                }
                filter.FilterByName = true;
                filter.Name = tbxConfigTypeTransaction.Text;
            }
            if (cbxFilterByAmount.Checked)
            {
                tbxConfigAmount.Text = tbxConfigAmount.Text.Trim();
                if (cbxFilterByAmount.Text.Length < 2)
                {
                    Invoke(new Action(() => { lblNotification1.Visible = true; }));
                    return null;
                }
                else
                {
                    Invoke(new Action(() => { lblNotification1.Visible = false; }));
                }
                filter.FilterByAmount = true;
                filter.Amount = Convert.ToDouble(tbxConfigAmount.Text);
            }
            if (cbxFilterByApplyTime.Checked)
            {
                filter.FilterBystatisticPayInDate = true;

                StatisticPayInDate payinFromTo = new StatisticPayInDate();
                payinFromTo.DateIn = dtpApplyTimeFrom.Value.ToStringFormatDateServeryyyyMMdd().Trim();
                payinFromTo.DateOut = dtpApplyTimeTo.Value.ToStringFormatDateServeryyyyMMdd().Trim();
                filter.statisticPayInDate = payinFromTo;
             

            }

            return filter;
        }

        private void LoadRuleList()
        {
            if (!bgwLoadEcashConfig.IsBusy)
            {
                dtbConfigList.Rows.Clear();
                EcashList = null;
                filter = GetRuleFilter();
                pagerPanel1.ShowMessage("Đang tải dữ liệu, xin hãy chờ...");
                bgwLoadEcashConfig.RunWorkerAsync();
            }
        }
        [CommandHandler(EcashConfigCommandNames.AddConfig)]
        private void btnAddConfig_Click(object sender, EventArgs e)
        {
            // Show GroupDetail dialog and delegate this task to it
            FrmAddConfig dialog = new FrmAddConfig(FrmAddConfig.ModeAdding, partnerInfo.MasterId);//masterInfo.MasterId, Convert.ToInt64(selectedOrgNode.Name)
            workItem.SmartParts.Add(dialog);
            dialog.ShowDialog();
            workItem.SmartParts.Remove(dialog);
            LoadRuleList();
        }

        [CommandHandler(EcashConfigCommandNames.UpdatConfig)]
        private void btnUpdateConfig_Click(object sender, EventArgs e)
        {
            if (dgvEcashConfig.SelectedRows.Count > 0)
            {
                long EcashConfigId = Convert.ToInt64(dgvEcashConfig.SelectedRows[0].Cells[0].Value.ToString());
                // Show GroupDetail dialog and delegate this task to it
                FrmAddConfig dialog = new FrmAddConfig(FrmAddConfig.ModeUpdating, partnerInfo.MasterId, EcashConfigId);//masterInfo.MasterId, Convert.ToInt64(selectedOrgNode.Name), memberId
                workItem.SmartParts.Add(dialog);
                dialog.ShowDialog();
                workItem.SmartParts.Remove(dialog);
                dialog.Dispose();
            }
            LoadRuleList();
        }

        [CommandHandler(EcashConfigCommandNames.RemoveConfig)]
        private void btnRemoveConfig_Click(object sender, EventArgs e)
        {
            bool result;
            if (dgvEcashConfig.SelectedRows.Count == 0)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessSelect(rm, MessageValidate.CancelCardConfig), MessageValidate.GetErrorTitle(rm));
                return;
            }

            //Show confirmation message box
            if (MessageBoxManager.ShowQuestionMessageBox(this, MessageValidate.GetMessCancelRequest(rm, MessageValidate.CancelCardConfig))== System.Windows.Forms.DialogResult.Yes)
            {
                long cardConfigId = Convert.ToInt64(dgvEcashConfig.SelectedRows[0].Cells[colId.Index].Value.ToString());
                try
                {
                    result = (int)Status.SUCCESS == EcashConfigFactory.Instance.GetChannel().RemoveEcashConfig(StorageService.CurrentSessionId, cardConfigId);
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
                    MessageBoxManager.ShowInfoMessageBox(this, "Đã hủy cấu hình giao dịch thành công!");
                }
                else
                {
                    MessageBoxManager.ShowErrorMessageBox(this, ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MessageValidate.AppCancelFail));
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
            dtbConfigList.Rows.Clear();
            int take = LocalSettings.Instance.RecordsPerPage;
            int skip = (currentPageIndex - 1) * take;

            List<Config_card> result = EcashList.Skip(skip).Take(take).ToList();
            LoadDataGridView(result);

            pagerPanel1.ShowNumberOfRecords(EcashList.Count, result != null ? result.Count : 0, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
            pagerPanel1.UpdatePagingLinks(EcashList.Count, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
        }

        private void cbxFilterByCardConfigName_CheckedChanged(object sender, EventArgs e)
        {
            tbxConfigTypeTransaction.Enabled = cbxFilterByCardConfigName.Checked;
        }

        private void cbxFilterByAmount_CheckedChanged(object sender, EventArgs e)
        {
            tbxConfigAmount.Enabled = cbxFilterByAmount.Checked;
        }

        private void cbxFilterByApplyTime_CheckedChanged(object sender, EventArgs e)
        {
            dtpApplyTimeFrom.Enabled = dtpApplyTimeTo.Enabled = cbxFilterByApplyTime.Checked;
        }
        #endregion Form events

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

        private void SetShowOrHideButton(bool edit)
        {
            btnAddConfig.Enabled = btnUpdateConfig.Enabled =
            btnRemoveConfig.Enabled = btnReloadConfig.Enabled = edit;
        }
        //private void cbxFilterByNameTransaction_CheckedChanged(object sender, EventArgs e)
        //{
        //    tbxConfigTypeTransaction.Enabled = cbxFilterByCardConfigName.Checked;
        //}

        //private void cbxFilterByAmount_CheckedChanged(object sender, EventArgs e)
        //{
        //    tbxConfigAmount.Enabled = cbxFilterByAmount.Checked;
        //}
        //private void cbxFilterByApplyTime_CheckedChanged(object sender, EventArgs e)
        //{
        //    dtpApplyTimeFrom.Enabled = dtpApplyTimeTo.Enabled = cbxFilterByApplyTime.Checked;

        //}
        # endregion

        #region PartnerInfo

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
        #endregion PartnerInfo

       
     
        //private void cbxFilterByCardConfigName_TextChanged(object sender, EventArgs e)
        //{
        //    tbxConfigTypeTransaction.Enabled = cbxFilterByCardConfigName.Checked;
        //}

        //private void cbxFilterByAmount_CheckedChanged(object sender, EventArgs e)
        //{
        //    tbxConfigAmount.Enabled = cbxFilterByAmount.Checked;
        //}

        //private void cbxFilterByApplyTime_CheckedChanged(object sender, EventArgs e)
        //{
        //    dtpApplyTimeFrom.Enabled = dtpApplyTimeTo.Enabled = cbxFilterByApplyTime.Checked;
        //}

        //private void dtpApplyTimeFrom_ValueChanged(object sender, EventArgs e)
        //{
        //    dtpApplyTimeTo.MinDate = dtpApplyTimeFrom.Value.Date;
        //}

        //private void dtpApplyTimeTo_ValueChanged(object sender, EventArgs e)
        //{
        //    dtpApplyTimeFrom.MaxDate = dtpApplyTimeTo.Value.Date;
        //}
        //private void cbxFilterByCardConfigName_CheckedChanged(object sender, EventArgs e)
        //{
        //    tbxConfigTypeTransaction.Enabled = cbxFilterByCardConfigName.Checked;
        //}

        //private void cbxFilterByAmount_CheckedChanged_1(object sender, EventArgs e)
        //{
        //    tbxConfigAmount.Enabled = cbxFilterByAmount.Checked;
        //}

        //private void cbxFilterByApplyTime_CheckedChanged_1(object sender, EventArgs e)
        //{
        //    dtpApplyTimeFrom.Enabled = dtpApplyTimeTo.Enabled = cbxFilterByApplyTime.Checked;
        //}

        //private void dtpApplyTimeFrom_ValueChanged(object sender, EventArgs e)
        //{
        //    dtpApplyTimeTo.MinDate = dtpApplyTimeFrom.Value.Date;
        //}

        //private void dtpApplyTimeTo_ValueChanged(object sender, EventArgs e)
        //{
        //    dtpApplyTimeFrom.MaxDate = dtpApplyTimeTo.Value.Date;
        //}
       
    }
}
