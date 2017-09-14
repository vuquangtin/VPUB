using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonControls.Custom;
using System.Resources;
using HomeComponent.WorkItems;
using Microsoft.Practices.CompositeUI;
using sWorldModel;
using sWorldModel.TransportData;
using sWorldModel.Filters;
using Microsoft.Practices.CompositeUI.EventBroker;
using eCashComponent.Contants;
using CommonHelper.Config;
using JavaCommunication.Factory;
using CommonControls;
using sWorldModel.Exceptions;
using System.ServiceModel;
using CommonHelper.Constants;
using CommonHelper.Utils;
using Microsoft.Practices.CompositeUI.Commands;
using System.Globalization;

namespace eCashComponent.WorkItems.Statistics
{
    public partial class UsrTopUpStattistics : CommonUserControl
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
        private PayOutDto payout;
        private List<PayInStatisticDto> SatatisticList;
        bool flag_SetText = true;
        //

        //sum

        double sumAmount = 0;
        private MasterInfoDTO partnerInfo;
        private long partnerOrgId;

        //private BackgroundWorker loadOrgWorker;
        private BackgroundWorker bgwLoadEcashStatistic;

        //filter;
        StatisticTouUpFilter filter;
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

        public UsrTopUpStattistics()
        {
            InitializeComponent();
            RegisterEvent();
            InitDataTableEcashConfig();



        }
        private void InitDataTableEcashConfig()
        {
            DataGridViewButtonColumn ktr = new DataGridViewButtonColumn();


            ktr.Text = "Bấm vào xem thông tin kháo thẻ";
            ktr.Name = "bt";
            ktr.UseColumnTextForButtonValue = true;
            //  ktr.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            ktr.FlatStyle = FlatStyle.Standard;
            ktr.CellTemplate.Style.BackColor = Color.Honeydew;
            ktr.HeaderText = "Tình Trạng  Khóa Thẻ";
            ktr.DisplayIndex = 8;

            dgvStatisticTopUp.Columns.Insert(4, ktr);
            dgvStatisticTopUp.Columns[4].Visible = false;
            //   dgvStatisticTopUp.Columns.Add(ktr);

            dtbStatistic = new DataTable();
            dtbStatistic.Columns.Add(colMemberCode.DataPropertyName);
            dtbStatistic.Columns.Add(colAmount.DataPropertyName);
            dtbStatistic.Columns.Add(colTimeTopUp.DataPropertyName);
            dtbStatistic.Columns.Add(colIpAddress.DataPropertyName);
            //dtbStatistic.Columns.Add(colMemberId.DataPropertyName);
            dtbStatistic.Columns.Add(colDataReadToCard.DataPropertyName);
            dtbStatistic.Columns.Add(colFullName.DataPropertyName);
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
            dgvStatisticTopUp.CellClick += dataGridView1_CellClick;

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
                if (ShowEcashStatisticTopUp != null)
                {
                    ShowEcashStatisticTopUp(this, EventArgs.Empty);
                }
            };

            Load += OnFormLoad;
        }

        #endregion Initialization

        #region Control
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 9)
            {
                MessageBox.Show((e.RowIndex + 1) + "  Row  " + (e.ColumnIndex + 1) + "  Column button clicked ");
            }
        }
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

        

        private void cbxFilterBySerialNumber_CheckedChanged(object sender, EventArgs e)
        {
            tbxSerialNumber.Enabled = cbxFilterBySerialNumber.Checked;

        }
        private void cbxFilterByPayIn_CheckedChanged_2(object sender, EventArgs e)
        {
            tbxPayIn.Enabled = cbxFilterByPayIn.Checked;
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



        private StatisticTouUpFilter GetRuleFilter()
        {
            StatisticTouUpFilter filter = new StatisticTouUpFilter();

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
                filter.FilterBystatisticPayInDate = true;

                StatisticPayInDate payinFromTo = new StatisticPayInDate();
                payinFromTo.DateIn = dtpApplyTimeFrom.Value.ToStringFormatDateServeryyyyMMdd().Trim();
                payinFromTo.DateOut = dtpApplyTimeTo.Value.ToStringFormatDateServeryyyyMMdd().Trim();
                filter.statisticPayInDate = payinFromTo;
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

            List<PayInStatisticDto> result = SatatisticList.Skip(skip).Take(take).ToList();
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
        //private string chuoithemphayvaotien(string Amount)
        //{
        //    try
        //    {
        //        //if (flag_SetText)
        //        //{
        //        //    string strTemp = Amount;
        //        //    if (String.IsNullOrEmpty(strTemp)) return;
        //        //    int iIndex = strTemp.IndexOf('.');
        //        //    if (iIndex == -1)
        //        //    {
        //        //    }
        //        //    else
        //        //    {
        //        //        string strT = strTemp.Substring(iIndex + 1, 1);
        //        //        if (!String.IsNullOrEmpty(strT))
        //        //        {
        //        //        }
        //        //    }
        //        //    double flTienThuong = double.Parse(tbnAmount.Text.Trim(','));
        //        //    flag_SetText = false;
        //        //    tbnAmount.Text = flTienThuong.ToString("N0");

        //        //}
        //        //else
        //        //{
        //        //    flag_SetText = true;
        //        //    // Đưa con trỏ về cuối chuỗi.
        //        //    tbnAmount.Select(tbnAmount.TextLength, 0);

        //        //}
        //    }
        //    catch (Exception ex)
        //    {


        //    }
        //}
        private void LoadDataGridView(List<PayInStatisticDto> result)
        {
            string[] SumPrice;
            DataRow row1 = dtbStatistic.NewRow();
            row1.BeginEdit();
            string[] xuatTinhTrang = { "Bình thường", "Khóa", "Hủy bỏ", "Gia hạn", "Hư", "Mất", "khóa thẻ" };

            foreach (PayInStatisticDto pi in result)
            {
                if (pi.Status == 12)
                    continue;
                DataRow row = dtbStatistic.NewRow();
                row.BeginEdit();

                Member member = LoadMember(pi.MemberId);

                row[colMemberCode.DataPropertyName] = member.Code;
                row[colAmount.DataPropertyName] = pi.Amount.ToString("N0", CultureInfo.InvariantCulture);
                row[colTimeTopUp.DataPropertyName] = pi.PayInDate;
                row[colIpAddress.DataPropertyName] = pi.IpAddress;
                SumPrice = pi.DataWriteToCard.Split(',');

                row[colDataReadToCard.DataPropertyName] = SumPrice[0];
                row[colFullName.DataPropertyName] = pi.FullName;
                row[colStatus.DataPropertyName] = xuatTinhTrang[pi.Status];


                //last Row
                sumAmount += pi.Amount;
                //

                row.EndEdit();
                dtbStatistic.Rows.Add(row);
            }

            ////   listcheck.GroupBy(x => x.SerialNumber).Select(y => y.First());
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
            List<PayInStatisticDto> result = null;
            try
            {
                SatatisticList = EcashConfigFactory.Instance.GetChannel().GetPayInRequestFilterByPayInRequestId(StorageService.CurrentSessionId, 0, filter);
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
            List<PayInStatisticDto> result = (List<PayInStatisticDto>)e.Result;
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

        #endregion Form events

        #region CAB events
        [EventPublication(ECashCommandNames.ShowEcashStatisticTopUp)]
        public event EventHandler ShowEcashStatisticTopUp;

        [CommandHandler(ECashCommandNames.ShowEcashStatisticTopUp)]
        public void ShowECashConfigMainViewHandler(object s, EventArgs e)
        {
            UsrTopUpStattistics uc = workItem.Items.Get<UsrTopUpStattistics>(ComponentNames.ECashComponentTopUpStastistic);
            if (uc == null)
            {
                uc = workItem.Items.AddNew<UsrTopUpStattistics>(ComponentNames.ECashComponentTopUpStastistic);
            }
            else if (uc.IsDisposed)
            {
                workItem.Items.Remove(uc);
                uc = workItem.Items.AddNew<UsrTopUpStattistics>(ComponentNames.ECashComponentTopUpStastistic);
            }
            workItem.Workspaces[WorkspaceName.MainWorkspace].Show(uc);
            uc.Parent.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuEcashStatisticTopUp);
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
