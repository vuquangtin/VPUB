using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using sWorldModel.TransportData;
using Microsoft.Practices.CompositeUI;
using sWorldModel;
using HomeComponent.WorkItems;
using sWorldModel.Filters;
using CommonControls.Custom;
using CommonHelper.Config;
using CommonHelper.Utils;
using CommonHelper.Constants;
using JavaCommunication.Factory;
using CommonControls;
using System.ServiceModel;
using sWorldModel.Exceptions;
using Microsoft.Practices.CompositeUI.EventBroker;
using eCashComponent.Contants;
using Microsoft.Practices.CompositeUI.Commands;
using System.Globalization;

namespace eCashComponent.WorkItems.StatisticsPayOut
{
    public partial class UsrPayOutStatistics : CommonUserControl
    {

        #region Properties

        // Height of filter box when it is hidden
        private int hiddenFilterBoxHeight = 0;
        // The original height of filter box (at startup)
        private int startupFilterBoxHeight = 105;
        private int currentPageIndex = 1;
        private ResourceManager rm;

        // Data table that contains user records
        private DataTable dtbStatistic;
        private List<PayOutStatisticDto> SatatisticList;

        //

        //sum

        double sumAmount = 0;
        private MasterInfoDTO partnerInfo;
        private long partnerOrgId;

        //private BackgroundWorker loadOrgWorker;
        private BackgroundWorker bgwLoadEcashStatistic;

        //filter;
        StatisticDeductFilter filter;
        string strBank = "1";

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

        public UsrPayOutStatistics()
        {
            InitializeComponent();
            RegisterEvent();
            InitDataTableEcashConfig();
        }

        private void InitDataTableEcashConfig()
        {
            dtbStatistic = new DataTable();
            dtbStatistic.Columns.Add(colMemberCode.DataPropertyName);
            dtbStatistic.Columns.Add(colItemName.DataPropertyName);
            dtbStatistic.Columns.Add(colAmount.DataPropertyName);
            dtbStatistic.Columns.Add(colMemberName.DataPropertyName);
            dtbStatistic.Columns.Add(colTimeTopUp.DataPropertyName);
            dtbStatistic.Columns.Add(colIpAddress.DataPropertyName);
            dtbStatistic.Columns.Add(colMemberId.DataPropertyName);
            dtbStatistic.Columns.Add(colAmountstay.DataPropertyName);
            dtbStatistic.Columns.Add(colDataReadToCard.DataPropertyName);
            dtbStatistic.Columns.Add(colStatus.DataPropertyName);

            dgvStatisticTopUp.DataSource = dtbStatistic;
        }

        #endregion Contructors

        #region Initialization
        private void RegisterEvent()
        {
            //Load EcashStatistic
            bgwLoadEcashStatistic = new BackgroundWorker();
            bgwLoadEcashStatistic.WorkerSupportsCancellation = true;
            bgwLoadEcashStatistic.DoWork += OnLoadEcashStatisticWorkerDoWork;
            bgwLoadEcashStatistic.RunWorkerCompleted += OnLoadEcashStatisticWorkerCompleted;

            //Show or hide filter
            btnShowHide.Click += btnShowHide_Click;

            //Add - Update - Deleted Voucher
            //           btnAddConfig.Click += btnAddConfig_Click;
            //           btnUpdateConfig.Click += btnUpdateConfig_Click;
            //           btnRemoveConfig.Click += btnRemoveConfig_Click;

            //reload list         
            btnReloadTopUp.Click += (s, e) => LoadStatisticList();

            dtpApplyTimeFrom.Value = dtpApplyTimeFrom.MaxDate = dtpApplyTimeTo.Value = dtpApplyTimeTo.MinDate = DateTime.Now;
            dtpApplyTimeFrom.ValueChanged += dtpApplyTimeFrom_ValueChanged;
            dtpApplyTimeTo.ValueChanged += dtpApplyTimeTo_ValueChanged;

            pagerPanel1.LinkLabelClicked += pagerPanel_LinkLabelClicked;

            Enter += (s, e) =>
            {
                if (ShowEcashStatisticDeduct != null)
                {
                    ShowEcashStatisticDeduct(this, EventArgs.Empty);
                }
            };

            Load += OnFormLoad;
        }

        #endregion Initialization

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
        private void cbxFilterByPayIn_CheckedChanged(object sender, EventArgs e)
        {
            tbxPayIn.Enabled = cbxFilterByPayIn.Checked;

        }

        private void cbxFilterBySerialNumber_CheckedChanged(object sender, EventArgs e)
        {
            tbxSerialNumber.Enabled = cbxFilterBySerialNumber.Checked;

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
        #endregion Control

        #region Form events
        private StatisticDeductFilter GetRuleFilter()
        {
            StatisticDeductFilter filter = new StatisticDeductFilter();

            if (cbxFilterByPayIn.Checked)
            {
                tbxPayIn.Text = tbxPayIn.Text.Trim();
                if (tbxPayIn.Text.Length < 2)
                {
                    Invoke(new Action(() => { lblNotification1.Visible = true; }));
                    return null;
                }
                else
                {
                    Invoke(new Action(() => { lblNotification1.Visible = false; }));
                }
                filter.FilterByAmount = true;
                filter.Amount = Convert.ToDouble(tbxPayIn.Text);
            }
            if (cbxFilterBySerialNumber.Checked)
            {
                tbxSerialNumber.Text = tbxSerialNumber.Text.Trim();
                if (tbxSerialNumber.Text.Length < 2)
                {
                    Invoke(new Action(() => { lblNotification2.Visible = true; }));
                    return null;
                }
                else
                {
                    Invoke(new Action(() => { lblNotification2.Visible = false; }));
                }
                filter.FilterBySerialNumber = true;
                filter.SerialNumber = tbxSerialNumber.Text;
            }
            if (cbxFilterByApplyTime.Checked)
            {
                filter.FilterBystatisticPayOutDate = true;

                StatisticPayInDate payinFromTo = new StatisticPayInDate();
                payinFromTo.DateIn = dtpApplyTimeFrom.Value.ToStringFormatDateServeryyyyMMdd().Trim();
                payinFromTo.DateOut = dtpApplyTimeTo.Value.AddDays(1).ToStringFormatDateServeryyyyMMdd().Trim();
                filter.statisticPayOutDate = payinFromTo;
            }


            return filter;
        }
        private void LoadStatisticList()
        {
            if (!bgwLoadEcashStatistic.IsBusy)
            {
                dtbStatistic.Rows.Clear();
                SatatisticList = null;
                filter = GetRuleFilter();
                pagerPanel1.ShowMessage("Đang tải dữ liệu, xin hãy chờ...");
                bgwLoadEcashStatistic.RunWorkerAsync();
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
            dtbStatistic.Rows.Clear();
            int take = LocalSettings.Instance.RecordsPerPage;
            int skip = (currentPageIndex - 1) * take;

            List<PayOutStatisticDto> result = SatatisticList.Skip(skip).Take(take).ToList();
            LoadDataGridView(result);

            pagerPanel1.ShowNumberOfRecords(SatatisticList.Count, result != null ? result.Count : 0, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
            pagerPanel1.UpdatePagingLinks(SatatisticList.Count, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
        }
        private void OnFormLoad(object sender, EventArgs e)
        {
            LoadPartnerInfo();
            LoadStatisticList();
            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
        }
        private void LoadDataGridView(List<PayOutStatisticDto> result)
        {
            DataRow row1 = dtbStatistic.NewRow();
            row1.BeginEdit();
            string[] xuatTinhTrang = { "Bình thường", "Khóa", "Hủy bỏ", "Gia hạn", "Hư", "Mất", "khóa thẻ" };

            foreach (PayOutStatisticDto pi in result)
            {
                if (pi.Status == 12)
                    continue;
                Member member = LoadMember(pi.MemberId);
                ItemDto item = GetItemById(pi.AppId);
                DataRow row = dtbStatistic.NewRow();
                row.BeginEdit();

                row[colMemberCode.DataPropertyName] = member.Code;
                row[colItemName.DataPropertyName] = item.Name;
                row[colAmount.DataPropertyName] = pi.Amount.ToString("N0", CultureInfo.InvariantCulture);
                row[colMemberName.DataPropertyName] = member.GetFullName();
                row[colTimeTopUp.DataPropertyName] = pi.PayOutDate;
                row[colIpAddress.DataPropertyName] = pi.UnitCode;

                row[colAmountstay.DataPropertyName] = pi.DataWriteToCard == null? "---" : pi.DataWriteToCard;
                //  row[colMemberId.DataPropertyName] = pi.MemberId;
                row[colStatus.DataPropertyName] = xuatTinhTrang[pi.Status];

                //last Row
                sumAmount += pi.Amount;
                //

                row.EndEdit();
                dtbStatistic.Rows.Add(row);
            }

            //   listcheck.GroupBy(x => x.SerialNumber).Select(y => y.First());
            //row1[colAmount.DataPropertyName] = sumAmount.ToString("N0", CultureInfo.InvariantCulture);
            //row1[colMaThe.DataPropertyName] = "Tổng thẻ: " + result.Distinct().ToList().Count;


            //row1.EndEdit();
            //dtbStatistic.Rows.Add(row1);
            //sumAmount = 0;
        }
        private void OnLoadEcashStatisticWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            int totalRecords = 0;
            int take = LocalSettings.Instance.RecordsPerPage;
            int skip = 0;
            currentPageIndex = 1;
            List<PayOutStatisticDto> result = null;
            try
            {
                SatatisticList = EcashConfigFactory.Instance.GetChannel().GetPayOutRequestFilterByPayOutRequestId(StorageService.CurrentSessionId, 0, filter);
            }
            catch (NullReferenceException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.InformNotExistData);
                SatatisticList = null;
            }
            catch (TimeoutException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.TimeOutExceptionMessage);
                SatatisticList = null;
            }
            catch (FaultException<WcfServiceFault> ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
                SatatisticList = null;
            }
            catch (FaultException ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.FaultExceptionMessage
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
                SatatisticList = null;
            }
            catch (CommunicationException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.CommunicationExceptionMessage);
                SatatisticList = null;
            }
            finally
            {
                if (SatatisticList != null)
                {
                    result = SatatisticList.Skip(skip).Take(take).ToList();
                    totalRecords = SatatisticList.Count;
                    pagerPanel1.ShowNumberOfRecords(totalRecords, result != null ? result.Count : 0, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
                    pagerPanel1.UpdatePagingLinks(totalRecords, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
                }
                e.Result = result;
            }
        }
        private void OnLoadEcashStatisticWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if (e.Result == null)
            {
                return;
            }
            List<PayOutStatisticDto> result = (List<PayOutStatisticDto>)e.Result;
            LoadDataGridView(result);
        }

        private Member LoadMember(long memberId)
        {
            Member member = new Member();
            if (memberId > 0)
            {
                try
                {
                    member = OrganizationFactory.Instance.GetChannel().GetMemberById(StorageService.CurrentSessionId, memberId);
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
            return member;
        }
        private ItemDto GetItemById(long itemId)
        {
            ItemDto item = new ItemDto();
            if (itemId > 0) 
            {
                try
                {
                    item = EcashConfigFactory.Instance.GetChannel().GetItemByItemId(StorageService.CurrentSessionId, itemId);
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
            return item;
        }

        #endregion Form events

        #region CAB events
        [EventPublication(ECashCommandNames.ShowEcashPayOut)]
        public event EventHandler ShowEcashStatisticDeduct;

        [CommandHandler(ECashCommandNames.ShowEcashPayOut)]
        public void ShowECashConfigMainViewHandler(object s, EventArgs e)
        {
            UsrPayOutStatistics uc = workItem.Items.Get<UsrPayOutStatistics>(ComponentNames.ECashComponentDeductStastistic);
            if (uc == null)
            {
                uc = workItem.Items.AddNew<UsrPayOutStatistics>(ComponentNames.ECashComponentDeductStastistic);
            }
            else if (uc.IsDisposed)
            {
                workItem.Items.Remove(uc);
                uc = workItem.Items.AddNew<UsrPayOutStatistics>(ComponentNames.ECashComponentDeductStastistic);
            }
            workItem.Workspaces[WorkspaceName.MainWorkspace].Show(uc);
            uc.Parent.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuEcashStatisticDeduct);
        }
        #endregion CAB events

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






    }
}
