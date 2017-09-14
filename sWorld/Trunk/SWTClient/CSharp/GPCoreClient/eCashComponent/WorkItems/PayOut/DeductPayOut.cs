using CardChipService;
using CommonControls;
using CommonControls.Custom;
using CommonHelper.Config;
using CommonHelper.Constants;
using CommonHelper.Utils;
using eCashComponent.Contants;
using HomeComponent.WorkItems;
using JavaCommunication.Factory;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.EventBroker;
using ReaderLibrary;
using sWorldModel;
using sWorldModel.Exceptions;
using sWorldModel.Filters;
using sWorldModel.TransportData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;

namespace eCashComponent.WorkItems.PayOut
{
    public partial class DeductPayOut : CommonControls.Custom.CommonDialog
    {

        #region Properties

        private PcscReader readerLib;
        private bool processing = false;
        private ResourceManager rm;
        private MasterInfoDTO partnerInfo;
        private DataTable dtResults;
        private string strBlank = "2";
        double sumPrice = 0;
        private List<PayOutDto> listPayOutReturn;
        private List<long> listItem;
        private List<long> sendServerItem;
        private List<long> GroupItemConfigList;
        private DataGridViewCheckBoxColumn colCheckbox;
        private DataGridViewTextBoxColumn colGroupItemConfigId;
        private DataGridViewTextBoxColumn colGroupItemConfigName;
        private DataGridViewTextBoxColumn colGroupItemConfigGroupName;
        private DataGridViewTextBoxColumn colGroupItemConfigPrice;
        private DataGridViewTextBoxColumn colGroupItemConfigStartDate;
        private DataGridViewTextBoxColumn colGroupItemConfigEndDate;

        //private BackgroundWorker loadOrgWorker;
        private BackgroundWorker bgwLoadEcashPayOut;

        private BackgroundWorker bgwLoadGroupWorker;
        private BackgroundWorker bgwLoadEcashItem;
        private List<PayOutDto> PayOutList;
        private List<PayOutDto> PayOutListSendServer;
        private List<GroupDto> groupList;
        private long partnerOrgId;
        //
        string tienconlai = "";
        string strserialListPayOut = "";
        //FILTER
        ItemFilterDto filter;

        private DataTable dtbPayOut, dtbGroupItemConfig, dtbItemShow;
        private eCashWorkItem workItem;
        [ServiceDependency]
        public eCashWorkItem WorkItem
        {
            set { workItem = value; }
        }

        private ILocalStorageService storageService;
        [ServiceDependency]
        public ILocalStorageService StorageService
        {
            get { return storageService; }
            set { storageService = value; }
        }

        #endregion Properties

        #region Validate filed Amount

        private bool Validatefield()
        {

            if (dgvSelectItemShow.RowCount < 1)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessSelect(rm, MessageValidate.NameItemDeduct), MessageValidate.GetErrorTitle(rm));
                //MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetBaseMessValidateofDeduct(rm, MessageValidate.MenuEcashNameItemDeduct), MessageValidate.GetErrorTitle(rm));
                return false;
            }
            if (dgvSelectItemShow.RowCount > 1)
            {
                MessageBoxManager.ShowErrorMessageBox(this, "Cong Thanh");
                //MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetBaseMessValidateofDeduct(rm, MessageValidate.MenuEcashNameItemDeduct), MessageValidate.GetErrorTitle(rm));
                return false;
            }
            if (PayOutListSendServer.Count > 1)
            {
                MessageBoxManager.ShowErrorMessageBox(this, "Cong Thanh");
                //MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetBaseMessValidateofDeduct(rm, MessageValidate.MenuEcashNameItemDeduct), MessageValidate.GetErrorTitle(rm));
                return false;
            }
            //if (PayOutList.Count > 1)
            //{
            //    MessageBoxManager.ShowErrorMessageBox(this, "Cong Thanh");
            //    MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetBaseMessValidateofDeduct(rm, MessageValidate.MenuEcashNameItemDeduct), MessageValidate.GetErrorTitle(rm));
            //    return false;
            //}
            return true;
        }

        private bool ValidateMoney(string dataPayIn, string dataPayOut)
        {
            if (dataPayIn.Equals("payin"))
                return false;
            if (dataPayOut.Equals("payout"))
                return true;
            string amountPayIn = dataPayIn.Split(',').FirstOrDefault();
            string amountPayOut = dataPayOut.Split(',').FirstOrDefault();
            double moneyPayIn = Convert.ToDouble(float.Parse(amountPayIn));
            double moneyPayOut = Convert.ToDouble(float.Parse(amountPayOut));
            double moneyItem = Convert.ToDouble(dgvSelectItemShow.SelectedRows[0].Cells[colItemPrice.Index].Value.ToString());
            if ((moneyPayIn - moneyPayOut) < moneyItem)
                return false;

            return true;
        }

        #endregion

        #region Payout
        public DeductPayOut()
        {

            InitializeComponent();
            //   LoadPartnerInfo();
            IntializeGroupItemConfigDataGridView();
            RegisterEvent();

        }

        private void RegisterEvent()
        {
            readerLib = new PcscReader();
            readerLib.TagDetected += OnTagDetected;
            readerLib.ReaderNotPresent += OnReaderNotPresent;
            readerLib.ReaderUnplugged += OnReaderUnplugged;
            readerLib.ReaderPlugged += OnReaderPlugged;

            btnClose.Click += OnButtonCloseClicked;
            btnListDevices.Click += OnButtonListDevicesClicked;
            btnPause.Click += OnButtonPauseClicked;
            btnStart.Click += OnButtonStartClicked;

            //Load GROUP item config
            bgwLoadGroupWorker = new BackgroundWorker();
            bgwLoadGroupWorker.WorkerSupportsCancellation = true;
            bgwLoadGroupWorker.DoWork += bgwLoadGroupItemConfigWorker_DoWork;
            bgwLoadGroupWorker.RunWorkerCompleted += bgwLoadGroupItemConfigWorker_RunWorkerCompleted;

            btnReloadGroupItem.Click += (s, e) => LoadGroupAndItemList();


            dtResults = new DataTable();
            dtResults.Columns.Add(colSerialNumber.DataPropertyName);
            //dtResults.Columns.Add(colType.DataPropertyName);
            dtResults.Columns.Add(colMemberName.DataPropertyName);
            dtResults.Columns.Add(colAmount.DataPropertyName);
            dtResults.Columns.Add(colPayinDate.DataPropertyName);
            dtResults.Columns.Add(colAmountStay.DataPropertyName);
            dtResults.Columns.Add(colResult.DataPropertyName);
            dgvResult.DataSource = dtResults;

            //Enter += (s, e) =>
            //{
            //    if (EcashMgtGroupItemConfigShown != null)
            //    {
            //        EcashMgtGroupItemConfigShown(this, EventArgs.Empty);
            //    }
            //};

            Shown += OnFormShown;
            FormClosing += OnFormClosing;
        }
        private void OnFormShown(object sender, EventArgs e)
        {
            rm = storageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);

            try
            {
                partnerInfo = OrganizationFactory.Instance.GetChannel().GetMasterInfo(storageService.CurrentSessionId, SystemSettings.Instance.Partner);

                //cmbPartnerInfo.DataSource = new List<MasterInfoDTO>() { this.partnerInfo };
                ////cmbPartnerInfo.DataSource = partnerInfo;
                //cmbPartnerInfo.ValueMember = "MasterId";
                //cmbPartnerInfo.DisplayMember = "Name";
                //cmbPartnerInfo.SelectedIndex = 0;

            }
            catch (TimeoutException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.TimeOutExceptionMessage);
                this.Hide();
            }
            catch (FaultException<WcfServiceFault> ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
                this.Hide();
            }
            catch (FaultException ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.FaultExceptionMessage
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
                this.Hide();
            }
            catch (CommunicationException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.CommunicationExceptionMessage);
                this.Hide();
            }
            DoListDevices();

            LoadGroupAndItemList();
        }
        #endregion Payout

        #region Form CAB
        [EventPublication(EcashEventTopicName.EcashMgtDeductConfigShown)]//??
        public event EventHandler EcashMgtDeductConfigShown;
        #endregion

        #region Form events
        private void IntializeGroupItemConfigDataGridView()
        {
            colCheckbox = new DataGridViewCheckBoxColumn();
            DatagridViewCheckBoxHeaderCell checkBoxHeader = new DatagridViewCheckBoxHeaderCell();
         //   checkBoxHeader.OnCheckBoxClicked += new CheckBoxClickedHandler(checkBoxHeader_OnCheckBoxClicked);
            colCheckbox.HeaderCell = checkBoxHeader;
            colCheckbox.HeaderText = string.Empty;
            colCheckbox.Width = 22;
            colCheckbox.DataPropertyName = "colCheckbox";
            dgvGroupItemConfig.Columns.Add(colCheckbox);

            colGroupItemConfigId = new DataGridViewTextBoxColumn();
            colGroupItemConfigId.HeaderText = "GroupItemConfigId";
            colGroupItemConfigId.Visible = false;
            colGroupItemConfigId.DataPropertyName = "GroupItemConfigId";
            colGroupItemConfigId.Name = "colGroupItemConfigId";
            colGroupItemConfigId.ReadOnly = true;
            dgvGroupItemConfig.Columns.Add(colGroupItemConfigId);

            colGroupItemConfigGroupName = new DataGridViewTextBoxColumn();
            colGroupItemConfigGroupName.HeaderText = "Tên Danh Nhóm";
            colGroupItemConfigGroupName.Width = 100;
            colGroupItemConfigGroupName.DataPropertyName = "GroupItemConfigGroupName";
            colGroupItemConfigGroupName.Name = "colGroupItemConfigGroupName";
            colGroupItemConfigGroupName.ReadOnly = true;
            dgvGroupItemConfig.Columns.Add(colGroupItemConfigGroupName);

            colGroupItemConfigName = new DataGridViewTextBoxColumn();
            colGroupItemConfigName.HeaderText = "Tên Danh Mục";
            colGroupItemConfigName.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colGroupItemConfigName.Width = 100;
            colGroupItemConfigName.DataPropertyName = "GroupItemConfigName";
            colGroupItemConfigName.Name = "colGroupItemConfigName";
            colGroupItemConfigName.ReadOnly = true;
            dgvGroupItemConfig.Columns.Add(colGroupItemConfigName);

            colGroupItemConfigPrice = new DataGridViewTextBoxColumn();
            colGroupItemConfigPrice.HeaderText = "Giá Tiền";
            colGroupItemConfigPrice.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colGroupItemConfigPrice.DataPropertyName = "GroupItemConfigPrice";
            colGroupItemConfigPrice.Name = "colGroupItemConfigPrice";
            colGroupItemConfigPrice.ReadOnly = true;
            dgvGroupItemConfig.Columns.Add(colGroupItemConfigPrice);

            colGroupItemConfigStartDate = new DataGridViewTextBoxColumn();
            colGroupItemConfigStartDate.HeaderText = "Ngày Bắt Đầu";
            //colGroupItemConfigStartDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colGroupItemConfigStartDate.Visible = false;
            colGroupItemConfigStartDate.DataPropertyName = "GroupItemConfigStartDate";
            colGroupItemConfigStartDate.Name = "colGroupItemConfigStartDate";
            colGroupItemConfigStartDate.ReadOnly = true;
            dgvGroupItemConfig.Columns.Add(colGroupItemConfigStartDate);

            colGroupItemConfigEndDate = new DataGridViewTextBoxColumn();
            colGroupItemConfigEndDate.HeaderText = "Ngày Kết Thúc";
            // colGroupItemConfigEndDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colGroupItemConfigEndDate.Visible = false;
            colGroupItemConfigEndDate.DataPropertyName = "GroupItemConfigEndDate";
            colGroupItemConfigEndDate.Name = "colGroupItemConfigEndDate";
            colGroupItemConfigEndDate.ReadOnly = true;
            dgvGroupItemConfig.Columns.Add(colGroupItemConfigEndDate);

            dtbItemShow = new DataTable();
            dtbItemShow.Columns.Add(colitemshow.DataPropertyName);
            dtbItemShow.Columns.Add(colItemPrice.DataPropertyName);
            dtbItemShow.Columns.Add(colStartDate.DataPropertyName);
            dtbItemShow.Columns.Add(colEndDate.DataPropertyName);
            dgvSelectItemShow.DataSource = dtbItemShow;

            dtbGroupItemConfig = new DataTable();
            dtbGroupItemConfig.Columns.Add(colCheckbox.DataPropertyName);
            dtbGroupItemConfig.Columns.Add(colGroupItemConfigId.DataPropertyName);
            dtbGroupItemConfig.Columns.Add(colGroupItemConfigGroupName.DataPropertyName);
            dtbGroupItemConfig.Columns.Add(colGroupItemConfigName.DataPropertyName);
            dtbGroupItemConfig.Columns.Add(colGroupItemConfigPrice.DataPropertyName);
            dtbGroupItemConfig.Columns.Add(colGroupItemConfigStartDate.DataPropertyName);
            dtbGroupItemConfig.Columns.Add(colGroupItemConfigEndDate.DataPropertyName);
            dgvGroupItemConfig.DataSource = dtbGroupItemConfig;

            dgvGroupItemConfig.CellMouseClick += dgvAppData_OnCellMouseUp;//vao day 0
            dgvGroupItemConfig.SelectionChanged += dgvAppData_SelectionChanged;//??

            dgvGroupItemConfig.BorderStyle = BorderStyle.FixedSingle;

            GroupItemConfigList = new List<long>();
        }

        private void dgvAppData_OnCellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex > -1)
            {
                DataGridViewRow rowIndex = dgvGroupItemConfig.Rows[e.RowIndex];
                bool value = Convert.ToBoolean(dgvGroupItemConfig.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                SetSelectedRowAppData(rowIndex, !value);//vao day 1
                SetAppDataList();

                dgvGroupItemConfig.EndEdit();
            }
        }

        private void SetAppDataList()//chay xem check dong nao
        {
            //GroupItemConfigList
            PayOutListSendServer = new List<PayOutDto>();
           
            dtbItemShow.Rows.Clear();
            DataRow dtItemShow = dtbItemShow.NewRow();
            foreach (DataGridViewRow row in dgvGroupItemConfig.Rows)
            {
                DataRow rowItemShow = dtbItemShow.NewRow();
                long itemId = Convert.ToInt32(row.Cells[colGroupItemConfigId.Index].Value.ToString());
                if (Convert.ToBoolean(row.Cells[0].Value) && GroupItemConfigList.Any(i=>i == itemId))
                {
                    row.Selected = true;
                    row.DefaultCellStyle.BackColor = SystemColors.Highlight;
                    row.DefaultCellStyle.ForeColor = Color.White;

                    rowItemShow.BeginEdit();

                    rowItemShow[colitemshow.DataPropertyName] = row.Cells[colGroupItemConfigName.Index].Value.ToString();
                    rowItemShow[colItemPrice.DataPropertyName] = row.Cells[colGroupItemConfigPrice.Index].Value.ToString();

                    rowItemShow[colStartDate.DataPropertyName] = row.Cells[colGroupItemConfigStartDate.Index].Value.ToString();
                    rowItemShow[colEndDate.DataPropertyName] = row.Cells[colGroupItemConfigEndDate.Index].Value.ToString();

                    string a = row.Cells[colGroupItemConfigPrice.Index].Value.ToString();
                    string[] tach = a.Split(' ');
                    //tong tien tru
                    sumPrice = Convert.ToInt32(tach[0].Replace(",", ""));

                    rowItemShow.EndEdit();

                    dtbItemShow.Rows.Add(rowItemShow);
                    dgvSelectItemShow.DataSource = dtbItemShow;
                    //
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                    row.Cells[0].Value = false;
                    row.Selected = false;
                }

            }
        }
        private void SetSelectedRowAppData(DataGridViewRow row, bool rowChecked)
        {
            GroupItemConfigList.Clear();
            if (rowChecked)
            {
                row.Cells[0].Value = true;
                GroupItemConfigList.Add(Convert.ToInt32(row.Cells[colGroupItemConfigId.Index].Value.ToString()));
            }
            else
            {
                row.Cells[0].Value = false;
                GroupItemConfigList.Remove(Convert.ToInt32(row.Cells[colGroupItemConfigId.Index].Value.ToString()));
            }
        }
        private void dgvAppData_SelectionChanged(object sender, EventArgs e)
        {
            //foreach (DataGridViewRow row in dgvAppData.Rows)
            //{
            //    if (AppList.Any(appId => appId == Convert.ToInt64(row.Cells[colAppId.Index].Value.ToString())))
            //    {
            //        row.Cells[0].Value = true;
            //        AppList.Add(Convert.ToInt32(row.Cells[colAppId.Index].Value.ToString()));
            //    }
            //}
        }

        private void checkBoxHeader_OnCheckBoxClicked(bool status)
        {
            //GroupItemConfigList.Clear();
            //for (int i = 0; i < dgvGroupItemConfig.Rows.Count; i++)
            //{
            //    dgvGroupItemConfig.Rows[i].Selected = status;
            //    dgvGroupItemConfig.Rows[i].Cells[0].Value = status;
            //    if (status)
            //    {
            //        GroupItemConfigList.Add(Convert.ToInt32(dgvGroupItemConfig.Rows[i].Cells[colGroupItemConfigId.Index].Value.ToString()));
            //        dgvGroupItemConfig.Rows[i].DefaultCellStyle.BackColor = SystemColors.Highlight;
            //        dgvGroupItemConfig.Rows[i].DefaultCellStyle.ForeColor = Color.White;
            //    }
            //    else
            //    {
            //        dgvGroupItemConfig.Rows[i].DefaultCellStyle.BackColor = Color.White;
            //        dgvGroupItemConfig.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
            //    }

            //}
        }
        //private void LoadItemDataGridView(List<ItemDto> result)
        //{
        //    Rectangle rect = this.dataGridView1.GetCellDisplayRectangle(0, -1, true);
        //    chkbox.Size = new Size(18, 18);
        //    rect.Offset(40, 2);
        //    chkbox.Location = rect.Location;
        //    chkbox.CheckedChanged += chkBoxChange;
        //    this.dataGridView1.Controls.Add(chkbox);
        //            foreach (ItemDto item in result)
        //                {
        //                    DataRow row = dtbPayOut.NewRow();
        //                    row.BeginEdit();

        //                    //row[colId.DataPropertyName] = item.Id;

        //                    row[colItem.DataPropertyName] = item.Name;
        //                    row[colprice.DataPropertyName] = item.Price;



        //                    row.EndEdit();
        //                    dtbPayOut.Rows.Add(row);
        //                }


        //}
        //    private void chkBoxChange(object sender, EventArgs e)
        //{
        //    for (int k = 0; k <= dataGridView1.RowCount - 1; k++)
        //    {
        //        this.dataGridView1[0, k].Value = this.chkbox.Checked;
        //    }
        //    this.dataGridView1.EndEdit();
        //}
        void bgwLoadGroupItemConfigWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            List<GroupItemConfig> result = null;
            LoadPartnerInfo();
            try
            {
                result = EcashConfigFactory.Instance.GetChannel().getGroupItemByConfig(StorageService.CurrentSessionId, partnerOrgId);
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
            finally
            {
                e.Result = result;
            }
        }
        void bgwLoadGroupItemConfigWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }

            if (e.Result == null || !(e.Result is List<GroupItemConfig>))
            {
                return;
            }

            List<GroupItemConfig> result = e.Result as List<GroupItemConfig>;


            foreach (GroupItemConfig gr in result)
            {
                int flag = 0;
                foreach (ItemDto item in gr.lstItem)
                {

                    DataRow row = dtbGroupItemConfig.NewRow();
                    row.BeginEdit();

                    row[colCheckbox.DataPropertyName] = false;
                    row[colGroupItemConfigId.DataPropertyName] = item.Id;
                    if (flag == 0)
                    {
                        row[colGroupItemConfigGroupName.DataPropertyName] = gr.groupName;

                    }
                    flag = 1;

                    row[colGroupItemConfigName.DataPropertyName] = item.Name;
                    row[colGroupItemConfigPrice.DataPropertyName] = item.Price.ToString("N0", CultureInfo.InvariantCulture);
                    row[colGroupItemConfigStartDate.DataPropertyName] = item.StartDate;
                    row[colGroupItemConfigEndDate.DataPropertyName] = item.EndDate;


                    row.EndEdit();
                    dtbGroupItemConfig.Rows.Add(row);

                }

            }
        }

        //private void AppendToTable(byte[] serialNumber, int cardType, PayInDto payIn, bool result, string reason)
        //{
        //    if (InvokeRequired)
        //    {
        //        Invoke(new Action<byte[], int, PayInDto, bool, string>(AppendToTable), serialNumber, cardType, payIn, result, reason);
        //        return;
        //    }
        //    MemberCustomerDto member = LoadMember(payIn.MemberId);
        //    DataRow row = dtResults.NewRow();
        //    row[colSerialNumber.DataPropertyName] = StringUtils.ByteArrayToHexString(serialNumber);
        //    row[colType.DataPropertyName] = ((CardChipType)cardType).GetName();
        //    row[colMemberName.DataPropertyName] = member != null && member.objMem != null ? member.objMem.GetFullName() : string.Empty;
        //    row[colAmount.DataPropertyName] = payIn.DataWriteToCard;
        //    row[colPayinDate.DataPropertyName] = payIn.PayInDate;
        //    row[colResult.DataPropertyName] = result ? "Thành công" : "Thất bại (" + reason + ")";
        //    dtResults.Rows.Add(row);

        //    int lastRowPos = dgvResult.RowCount - 1;
        //    dgvResult.FirstDisplayedScrollingRowIndex = lastRowPos;
        //    foreach (DataGridViewRow r in dgvResult.SelectedRows)
        //    {
        //        r.Selected = false;
        //    }
        //    dgvResult.Rows[lastRowPos].Selected = true;
        //}
        private void OnButtonStartClicked(object sender, EventArgs e)
        {
            if (cmbReaders.SelectedIndex == -1)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessSelect(rm, MessageValidate.Reader), MessageValidate.GetErrorTitle(rm));
                return;
            }
         
            if (Validatefield())
            {

            dgvGroupItemConfig.Enabled = false;
            SwitchRunningState(true);
            ChangeStatusMessage("Đang kết nối với thiết bị đọc...");

            string selectedReader = cmbReaders.SelectedItem.ToString();
            readerLib.ConnectToReader(selectedReader);

            }
            //}
        }
        private void OnButtonPauseClicked(object sender, EventArgs e)
        {
            //  tbnAmount.ReadOnly = false;
            dgvGroupItemConfig.Enabled = true;
            readerLib.DisconnectFromReader();

            SwitchRunningState(false);
            ChangeStatusMessage("Chưa kết nối với thiết bị đọc");
        }
        private void OnButtonListDevicesClicked(object sender, EventArgs e)
        {
            DoListDevices();
        }
        private void OnButtonCloseClicked(object sender, EventArgs e)
        {
            this.Close();
        }
        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBoxManager.ShowQuestionMessageBox(this, MessageValidate.GetMessStop(rm, MessageValidate.CloseEcashDeDuct)) != DialogResult.Yes)
            {
                e.Cancel = true;
            }
            else
            {
                readerLib.DisconnectFromReader();
            }
        }
        private void DoListDevices()
        {
            cmbReaders.DataSource = null;
            string[] listReaders = readerLib.ListReaders();
            if (listReaders != null && listReaders.Length > 0)
            {
                cmbReaders.DataSource = listReaders;
                cmbReaders.SelectedIndex = 0;
            }
        }
        private void ChangeStatusMessage(string msg)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(ChangeStatusMessage), msg);
                return;
            }
            lblStatus.Text = msg;
        }
        private void SwitchRunningState(bool running)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<bool>(SwitchRunningState), running);
                return;
            }
            cmbReaders.Enabled = btnStart.Enabled = btnListDevices.Enabled = !running;
            btnPause.Enabled = running;
        }

        private List<PayOutDto> ListSendServer(List<long> AppId)
        {
            if (PayOutListSendServer == null)
                PayOutListSendServer = new List<PayOutDto>();
            PayOutListSendServer.Clear();
            for (int i = 0; i < AppId.Count; i++)
            {
                PayOutDto payOutDto = new PayOutDto();

                payOutDto.SerialNumber = strserialListPayOut;
                payOutDto.AppId = AppId[i];
                payOutDto.UnitCode = "1";//ngân hàng sử dụng trường này
                payOutDto.PayOutDate = DateTime.Now.ToStringFormatDateFullServer();
                payOutDto.Owner = storageService.CurrentUserName;
                PayOutListSendServer.Add(payOutDto);
            }
            return PayOutList;
        }

        private void OnTagDetected(int cardType, byte[] serialNumber)
        {
            if (!processing)
            {
                SwitchProcessingState();

                //  msg when writed key failed
                string MSG = String.Empty;

                //verified server data
                CardChipManager cardChipManager = new CardChipManager(readerLib, serialNumber);
                string strserial = StringUtils.ByteArrayToHexString(serialNumber);
                strserialListPayOut = strserial;
                PayOutDto payOutDto = null;
                int checkValidate;
                int status;
                string KeyB;
                string payInData = strBlank, payOutData = strBlank;

                #region Step 1: Check if card is supplied by master

                // Verify license master card
                if (!cardChipManager.RsaVerifiedLicenseMaster(CardConfigration.START_SECTOR_MASTER, CardConfigration.STOP_SECTOR_MASTER, out MSG))
                {
                    AppendToTable(serialNumber, cardType, new PayOutDto(), false, MSG);
                    readerLib.Beep(false);
                    SwitchProcessingState();
                    return;
                }

                #endregion

                #region Step 2: Read header data

                byte[] headerdata;
                if (!cardChipManager.ReadHeaderData(out headerdata, out MSG))
                {
                    AppendToTable(serialNumber, cardType, new PayOutDto(), false, MSG);
                    readerLib.Beep(false);
                    SwitchProcessingState();
                    return;
                }

                #endregion

                #region Step 3: check partner if has partner

                if (cardChipManager.HasPartner(headerdata))
                {
                    #region Step 4. Check if card is has partner license

                    if (!cardChipManager.RsaVerifiedLicensePartner(CardConfigration.START_SECTOR_PARTNER, CardConfigration.STOP_SECTOR_PARTNER, out MSG))
                    {
                        AppendToTable(serialNumber, cardType, new PayOutDto(), false, MSG);
                        readerLib.Beep(false);
                        SwitchProcessingState();
                        return;
                    }

                    #endregion
                }

                #endregion

                #region Step 4: Read PayInData and PayOutData for card

                if (!cardChipManager.GetPayInData(out payInData, out MSG))
                {
                    AppendToTable(serialNumber, cardType, new PayOutDto(), false, MSG);
                    readerLib.Beep(false);
                    SwitchProcessingState();
                    return;
                }

                if (!cardChipManager.GetPayOutData(out payOutData, out MSG))
                {
                    AppendToTable(serialNumber, cardType, new PayOutDto(), false, MSG);
                    readerLib.Beep(false);
                    SwitchProcessingState();
                    return;
                }

                if (!ValidateMoney(payInData, payOutData))
                {
                    AppendToTable(serialNumber, cardType, new PayOutDto(), false, "Số tiền trong thẻ không đủ điều kiện sử dụng dịch vụ này");
                    readerLib.Beep(false);
                    SwitchProcessingState();
                    return;
                }
                if (!string.IsNullOrEmpty(payInData))// && !string.IsNullOrEmpty(payInData))
                {
                    Balance(payInData,payOutData);

                }


                #endregion

                #region Step 5: Validate Card

                try
                {
                    checkValidate = EcashConfigFactory.Instance.GetChannel().ValidateCard(storageService.CurrentSessionId, strserial, payInData, payOutData, strBlank);
                    if (!ShowResultValidate(checkValidate, serialNumber, cardType))
                        return;
                }
                catch (TimeoutException)
                {
                    AppendToTable(serialNumber, cardType, new PayOutDto(), false, CommonMessages.TimeOutExceptionMessage);
                    readerLib.Beep(false);
                    SwitchProcessingState();
                    return;
                }
                catch (FaultException<WcfServiceFault> ex)
                {
                    AppendToTable(serialNumber, cardType, new PayOutDto(), false, ErrorCodes.GetErrorMessage(ex.Detail.Code));
                    readerLib.Beep(false);
                    SwitchProcessingState();
                    return;
                }
                catch (FaultException ex)
                {
                    AppendToTable(serialNumber, cardType, new PayOutDto(), false, ex.Message);
                    readerLib.Beep(false);
                    SwitchProcessingState();
                    return;
                }
                catch (CommunicationException)
                {
                    AppendToTable(serialNumber, cardType, new PayOutDto(), false, CommonMessages.CommunicationExceptionMessage);
                    readerLib.Beep(false);
                    SwitchProcessingState();
                    return;
                }

                #endregion

                #region Step 6: GetDataPayOutWriteToCard


                ListSendServer(GroupItemConfigList);
                //chi duoc giui 1 recover
                
                try
                {
                    listPayOutReturn = EcashConfigFactory.Instance.GetChannel().GetDataPayOutWriteToCard(storageService.CurrentSessionId, PayOutListSendServer, cardType);
                }
                catch (TimeoutException)
                {
                    AppendToTable(serialNumber, cardType, new PayOutDto(), false, CommonMessages.TimeOutExceptionMessage);
                    readerLib.Beep(false);
                    SwitchProcessingState();
                    return;
                }
                catch (FaultException<WcfServiceFault> ex)
                {
                    AppendToTable(serialNumber, cardType, new PayOutDto(), false, ErrorCodes.GetErrorMessage(ex.Detail.Code));
                    readerLib.Beep(false);
                    SwitchProcessingState();
                    return;
                }
                catch (FaultException ex)
                {
                    AppendToTable(serialNumber, cardType, new PayOutDto(), false, ex.Message);
                    readerLib.Beep(false);
                    SwitchProcessingState();
                    return;
                }
                catch (CommunicationException)
                {
                    AppendToTable(serialNumber, cardType, new PayOutDto(), false, CommonMessages.CommunicationExceptionMessage);
                    readerLib.Beep(false);
                    SwitchProcessingState();
                    return;
                }

                if (listPayOutReturn == null)
                {
                    AppendToTable(serialNumber, cardType, new PayOutDto(), false, "Hệ thống không chứa thông tin của thẻ này");
                    readerLib.Beep(false);
                    SwitchProcessingState();
                    return;
                }

                if (!cardChipManager.WriteDeductData(listPayOutReturn[listPayOutReturn.Count - 1].KeyB, listPayOutReturn[listPayOutReturn.Count - 1].KeyB, listPayOutReturn[listPayOutReturn.Count - 1].DataWriteToCard, out MSG))
                {
                    AppendToTable(serialNumber, cardType, new PayOutDto(), false, MSG);
                    readerLib.Beep(false);
                    SwitchProcessingState();
                    return;
                }

                #endregion

                #region Step 7: UpdateStatusPayOut
                if (listPayOutReturn != null)
                {
                    try
                    {
                        status = EcashConfigFactory.Instance.GetChannel().UpdateStatusPayOut(storageService.CurrentSessionId, listPayOutReturn, strBlank);
                    }
                    catch (TimeoutException)
                    {
                        AppendToTable(serialNumber, cardType, new PayOutDto(), false, CommonMessages.TimeOutExceptionMessage);
                        readerLib.Beep(false);
                        SwitchProcessingState();
                        return;
                    }
                    catch (FaultException<WcfServiceFault> ex)
                    {
                        AppendToTable(serialNumber, cardType, new PayOutDto(), false, ErrorCodes.GetErrorMessage(ex.Detail.Code));
                        readerLib.Beep(false);
                        SwitchProcessingState();
                        return;
                    }
                    catch (FaultException ex)
                    {
                        AppendToTable(serialNumber, cardType, new PayOutDto(), false, ex.Message);
                        readerLib.Beep(false);
                        SwitchProcessingState();
                        return;
                    }
                    catch (CommunicationException)
                    {
                        AppendToTable(serialNumber, cardType, new PayOutDto(), false, CommonMessages.CommunicationExceptionMessage);
                        readerLib.Beep(false);
                        SwitchProcessingState();
                        return;
                    }

                    if (status != 0)
                    {
                        AppendToTable(serialNumber, cardType, new PayOutDto(), false, "Hệ thống cập nhật phát sinh lổi");
                        readerLib.Beep(false);
                        SwitchProcessingState();
                        return;
                    }
                }
                #endregion

              //  foreach (PayOutDto payout in listPayOutReturn)
              //  {
                AppendToTable(serialNumber, cardType, listPayOutReturn[0], true, string.Empty);
            //    }
                readerLib.Beep(true);
                SwitchProcessingState();

       
            }
        }

        private string Balance(string inpaydata, string outpaydata)
        {
            try
            {
                string[] CatChuoiIn = inpaydata.Split(',');
                string[] CatChuoiOut = outpaydata.Split(',');

                double ConverterIn = Convert.ToDouble(CatChuoiIn[0]);
                double ConverterOut = 0;
                if (!outpaydata.Equals("payout"))
                {
                    ConverterOut = Convert.ToDouble(CatChuoiOut[0]);
                }
                double tiencon = ConverterIn - ConverterOut - (Convert.ToDouble(sumPrice));
                tienconlai = tiencon.ToString();
                return tienconlai;
            }
            catch (Exception ex) { }
            return tienconlai;
        }


        private void AppendToTable(byte[] serialNumber, int cardType, PayOutDto payOut, bool result, string reason)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<byte[], int, PayOutDto, bool, string>(AppendToTable), serialNumber, cardType, payOut, result, reason);
                return;
            }

            DataRow row = dtResults.NewRow();
            row[colSerialNumber.DataPropertyName] = StringUtils.ByteArrayToHexString(serialNumber);
            //row[colType.DataPropertyName] = ((CardChipType)cardType).GetName();
            if (payOut != null)
            {
                Member member = LoadMember(payOut.MemberId);
                //tien con trong the
                // string amuontStay = payOut.DataWriteToCard.Split(','); 

                row[colMemberName.DataPropertyName] = member != null ? member.GetFullName() : string.Empty;
                row[colAmount.DataPropertyName] = payOut.Amount.ToString("N0") + " " + "VNĐ";
                row[colPayinDate.DataPropertyName] = payOut.PayOutDate;
                if (!tienconlai.Equals(""))
                {
                    double tienconlaicuoi = Convert.ToDouble(tienconlai);
                    tienconlai = tienconlaicuoi.ToString("N0", CultureInfo.InvariantCulture);
                    row[colAmountStay.DataPropertyName] = tienconlai + " " + "VNĐ";
                }


            }
            row[colResult.DataPropertyName] = result ? "Thành công" : "Thất bại (" + reason + ")";
            dtResults.Rows.Add(row);

            int lastRowPos = dgvResult.RowCount - 1;
            dgvResult.FirstDisplayedScrollingRowIndex = lastRowPos;
            foreach (DataGridViewRow r in dgvResult.SelectedRows)
            {
                r.Selected = false;
            }
            dgvResult.Rows[lastRowPos].Selected = true;
        }

        private void SwitchProcessingState()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(SwitchProcessingState));
                return;
            }
            if (processing)
            {
                lblStatus.BackColor = this.BackColor;
                lblStatus.ForeColor = this.ForeColor;
                lblStatus.Text = "Đang chờ thẻ...";
                processing = false;
            }
            else
            {
                processing = true;
                //lblStatus.BackColor = Color.FromArgb(3, 111, 192);
                lblStatus.BackColor = SystemColors.Highlight;
                //lblStatus.ForeColor = Color.WhiteSmoke;
                lblStatus.ForeColor = SystemColors.HighlightText;
                lblStatus.Text = "Phát hiện thẻ, đang xử lý...";
            }
        }
        #endregion
                
        #region Reader library events
        private void OnReaderUnplugged(object sender, EventArgs e)
        {
            ChangeStatusMessage("Bị mất kết nối với thiết bị đọc!");
            SwitchRunningState(false);
        }
        private void OnReaderPlugged(object sender, EventArgs e)
        {
            ChangeStatusMessage("Đang chờ thẻ...");
        }
        private void OnReaderNotPresent(object sender, EventArgs e)
        {
            ChangeStatusMessage("Không thể kết nối với thiết bị đọc, hãy kiểm tra lại!");
            SwitchRunningState(false);
        }
        #endregion Reader library events

        #region load form

        private Member LoadMember(long memberId)
        {
            Member member = new Member();

            try
            {
                if (memberId > 0)
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
            return member;
        }
        private void OnFormLoad(object sender, EventArgs e)
        {
            LoadPartnerInfo();
            LoadStatisticList();
            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
        }

        private void LoadStatisticList()
        {
            if (!bgwLoadEcashPayOut.IsBusy)
            {
                dtbPayOut.Rows.Clear();
                PayOutList = null;
                //  filter = GetRuleFilter();
                //pagerPanel1.ShowMessage("Đang tải dữ liệu.");
                bgwLoadEcashPayOut.RunWorkerAsync();
            }
        }

        private void LoadGroupAndItemList()
        {
            if (!bgwLoadGroupWorker.IsBusy)
            {
                dtbGroupItemConfig.Rows.Clear();
                //pagerPanel1.ShowMessage("Đang tải dữ liệu.");
                bgwLoadGroupWorker.RunWorkerAsync();
            }
        }

        private bool ShowResultValidate(int checkValidate, byte[] serialNumber, int cardType)
        {
            switch (checkValidate)
            {
                //case (int)CardPhysicalStatus.NotCardSystem:
                //    AppendToTable(serialNumber, cardType, new PayOutDto(), false, "Thẻ không có trong hệ thống");
                //    readerLib.Beep(false);
                //    SwitchProcessingState();
                //    return false;
                case (int)CardPhysicalStatus.Broken:
                    AppendToTable(serialNumber, cardType, new PayOutDto(), false, "Thẻ đã hư");
                    readerLib.Beep(false);
                    SwitchProcessingState();
                    return false;
                case (int)CardPhysicalStatus.Lost:
                    AppendToTable(serialNumber, cardType, new PayOutDto(), false, "Thẻ đã thông báo mất");
                    readerLib.Beep(false);
                    SwitchProcessingState();
                    return false;
                case (int)PersoStatus.Locked:
                    AppendToTable(serialNumber, cardType, new PayOutDto(), false, "Thẻ đã bị khóa");
                    readerLib.Beep(false);
                    SwitchProcessingState();
                    return false;
                case (int)PersoStatus.Canceled:
                    AppendToTable(serialNumber, cardType, new PayOutDto(), false, "Lượt phát hành của thẻ đã bị hủy");
                    readerLib.Beep(false);
                    SwitchProcessingState();
                    return false;
                case (int)PersoStatus.NotPerso:
                    AppendToTable(serialNumber, cardType, new PayOutDto(), false, "Thẻ chưa được phát hành");
                    readerLib.Beep(false);
                    SwitchProcessingState();
                    return false;
                default:
                    return true;
            }
        }
        #endregion

        #region PartnerInfo

        private void LoadPartnerInfo()
        {
            try
            {
                partnerInfo = OrganizationFactory.Instance.GetChannel().GetMasterInfo(storageService.CurrentSessionId, SystemSettings.Instance.Partner);
                partnerOrgId = partnerInfo.MasterId;
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
