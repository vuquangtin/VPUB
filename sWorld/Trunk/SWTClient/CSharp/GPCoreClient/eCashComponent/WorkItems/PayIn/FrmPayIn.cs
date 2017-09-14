using CardChipService;
using CommonControls;
using CommonHelper.Config;
using CommonHelper.Constants;
using CommonHelper.Utils;
using eCashComponent.Contants;
using HomeComponent.WorkItems;
using JavaCommunication.Factory;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.Commands;
using Microsoft.Practices.CompositeUI.EventBroker;
using ReaderLibrary;
using sWorldModel;
using sWorldModel.Exceptions;
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

namespace eCashComponent.WorkItems.TopUp
{
    public partial class FrmPayIn : CommonControls.Custom.CommonDialog
    {
        #region Properties

        private PcscReader readerLib;
        private bool processing = false;
        private ResourceManager rm;
        private MasterInfoDTO partnerInfo;
        private DataTable dtResults;
        private string strBlank = "1";
        private bool flag_SetText = true;
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
            if (string.IsNullOrEmpty(tbnAmount.Text))
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessageValidate(rm, MessageValidate.Amount), MessageValidate.GetErrorTitle(rm));
                return false;
            }
            if (!StringUtils.IsNumber(tbnAmount.Text))
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessInvalid(rm, MessageValidate.Amount), MessageValidate.GetErrorTitle(rm));
                return false;
            }
            return true;
        }
        #endregion

        #region Payin
        public FrmPayIn()
        {

            InitializeComponent();
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
            tbnAmount.TextChanged += tbnAmount_TextChanged;


            dtResults = new DataTable();
            dtResults.Columns.Add(colSerialNumber.DataPropertyName);
            dtResults.Columns.Add(colType.DataPropertyName);
            dtResults.Columns.Add(colMemberName.DataPropertyName);
            dtResults.Columns.Add(colAmount.DataPropertyName);
            dtResults.Columns.Add(colPayinDate.DataPropertyName);
            dtResults.Columns.Add(colResult.DataPropertyName);
            dgvResult.DataSource = dtResults;

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

                cmbPartnerInfo.DataSource = new List<MasterInfoDTO>() { this.partnerInfo };
                //cmbPartnerInfo.DataSource = partnerInfo;
                cmbPartnerInfo.ValueMember = "MasterId";
                cmbPartnerInfo.DisplayMember = "Name";
                cmbPartnerInfo.SelectedIndex = 0;

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

        }
        #endregion PayIn

        #region Form events


        private void OnButtonStartClicked(object sender, EventArgs e)
        {
            if (cmbReaders.SelectedIndex == -1)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessSelect(rm, MessageValidate.Reader), MessageValidate.GetErrorTitle(rm));
                return;
            }
            if (Validatefield())
            {
                tbnAmount.ReadOnly = true;
                SwitchRunningState(true);
                ChangeStatusMessage("Đang kết nối với thiết bị đọc...");

                string selectedReader = cmbReaders.SelectedItem.ToString();
                readerLib.ConnectToReader(selectedReader);
            }
        }

        private void OnButtonPauseClicked(object sender, EventArgs e)
        {
            tbnAmount.ReadOnly = false;
            readerLib.DisconnectFromReader();

            SwitchRunningState(false);
            ChangeStatusMessage("Chưa kết nối với thiết bị đọc");
        }

        private void OnButtonListDevicesClicked(object sender, EventArgs e)
        {
            DoListDevices();
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

        private void OnButtonCloseClicked(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbnAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (flag_SetText)
                {
                    string strTemp = tbnAmount.Text;
                    if (String.IsNullOrEmpty(strTemp)) return;
                    int iIndex = strTemp.IndexOf('.');
                    if (iIndex == -1)
                    {
                    }
                    else
                    {
                        string strT = strTemp.Substring(iIndex + 1, 1);
                        if (!String.IsNullOrEmpty(strT))
                        {
                        }
                    }
                    double flTienThuong = double.Parse(tbnAmount.Text.Trim(','));
                    flag_SetText = false;
                    tbnAmount.Text = flTienThuong.ToString("N0");

                }
                else
                {
                    flag_SetText = true;

                    tbnAmount.Select(tbnAmount.TextLength, 0);

                }
            }
            catch (Exception ex)
            {


            }
        }


        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBoxManager.ShowQuestionMessageBox(this, MessageValidate.GetMessStop(rm, MessageValidate.MenuEcashTopUp)) != DialogResult.Yes)
            {
                e.Cancel = true;
            }
            else
            {
                readerLib.DisconnectFromReader();
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

        private void AppendToTable(byte[] serialNumber, int cardType, PayInDto payIn, bool result, string reason)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<byte[], int, PayInDto, bool, string>(AppendToTable), serialNumber, cardType, payIn, result, reason);
                return;
            }

            DataRow row = dtResults.NewRow();
            row[colSerialNumber.DataPropertyName] = StringUtils.ByteArrayToHexString(serialNumber);
            row[colType.DataPropertyName] = ((CardChipType)cardType).GetName();

            if (payIn != null)
            {
                Member member = LoadMember(payIn.MemberId);
                row[colMemberName.DataPropertyName] = member != null ? member.GetFullName() : string.Empty;
                row[colAmount.DataPropertyName] = payIn.Amount.ToString("N0", CultureInfo.InvariantCulture);
                row[colPayinDate.DataPropertyName] = payIn.PayInDate;
            }


            //row[colMemberName.DataPropertyName] = member != null ? member.GetFullName() : string.Empty;
            //row[colAmount.DataPropertyName] = payIn.Amount;
            //row[colPayinDate.DataPropertyName] = payIn.PayInDate;

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
                PayInDto payinDto = null;
                int checkValidate;
                int status;
                string payInData = strBlank, payOutData = strBlank;

                #region Step 1: Check if card is supplied by master

                // Verify license master card
                if (!cardChipManager.RsaVerifiedLicenseMaster(CardConfigration.START_SECTOR_MASTER, CardConfigration.STOP_SECTOR_MASTER, out MSG))
                {
                    AppendToTable(serialNumber, cardType, payinDto, false, MSG);
                    readerLib.Beep(false);
                    SwitchProcessingState();
                    return;
                }

                #endregion

                #region Step 2: Read header data

                byte[] headerdata;
                if (!cardChipManager.ReadHeaderData(out headerdata, out MSG))
                {
                    AppendToTable(serialNumber, cardType, payinDto, false, MSG);
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
                        AppendToTable(serialNumber, cardType, payinDto, false, MSG);
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
                    AppendToTable(serialNumber, cardType, payinDto, false, MSG);
                    readerLib.Beep(false);
                    SwitchProcessingState();
                    return;
                }

                if (!cardChipManager.GetPayOutData(out payOutData, out MSG))
                {
                    AppendToTable(serialNumber, cardType, payinDto, false, MSG);
                    readerLib.Beep(false);
                    SwitchProcessingState();
                    return;
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
                    AppendToTable(serialNumber, cardType, payinDto, false, CommonMessages.TimeOutExceptionMessage);
                    readerLib.Beep(false);
                    SwitchProcessingState();
                    return;
                }
                catch (FaultException<WcfServiceFault> ex)
                {
                    AppendToTable(serialNumber, cardType, payinDto, false, ErrorCodes.GetErrorMessage(ex.Detail.Code));
                    readerLib.Beep(false);
                    SwitchProcessingState();
                    return;
                }
                catch (FaultException ex)
                {
                    AppendToTable(serialNumber, cardType, payinDto, false, ex.Message);
                    readerLib.Beep(false);
                    SwitchProcessingState();
                    return;
                }
                catch (CommunicationException)
                {
                    AppendToTable(serialNumber, cardType, payinDto, false, CommonMessages.CommunicationExceptionMessage);
                    readerLib.Beep(false);
                    SwitchProcessingState();
                    return;
                }

                #endregion

                #region Step 6: Get data pay in wirte to card

                if (checkValidate == 0)
                {
                    payinDto = new PayInDto();

                    payinDto.Amount = Convert.ToDouble(tbnAmount.Text);
                    payinDto.SerialNumber = strserial;
                    payinDto.IpAddress = "1";
                    payinDto.PayInDate = DateTime.Now.ToStringFormatDateFullServer();

                    payinDto.DataWriteToCard = payInData;
                    payinDto.Owner = storageService.CurrentUserName;
                    try
                    {
                        payinDto = EcashConfigFactory.Instance.GetChannel().GetDataPayInWriteToCard(storageService.CurrentSessionId, payinDto, cardType);
                    }
                    catch (TimeoutException)
                    {
                        AppendToTable(serialNumber, cardType, payinDto, false, CommonMessages.TimeOutExceptionMessage);
                        readerLib.Beep(false);
                        SwitchProcessingState();
                        return;
                    }
                    catch (FaultException<WcfServiceFault> ex)
                    {
                        AppendToTable(serialNumber, cardType, payinDto, false, ErrorCodes.GetErrorMessage(ex.Detail.Code));
                        readerLib.Beep(false);
                        SwitchProcessingState();
                        return;
                    }
                    catch (FaultException ex)
                    {
                        AppendToTable(serialNumber, cardType, payinDto, false, ex.Message);
                        readerLib.Beep(false);
                        SwitchProcessingState();
                        return;
                    }
                    catch (CommunicationException)
                    {
                        AppendToTable(serialNumber, cardType, payinDto, false, CommonMessages.CommunicationExceptionMessage);
                        readerLib.Beep(false);
                        SwitchProcessingState();
                        return;
                    }

                    if (payinDto == null)
                    {
                        AppendToTable(serialNumber, cardType, payinDto, false, "Hệ thống không chứa thông tin của thẻ này");
                        readerLib.Beep(false);
                        SwitchProcessingState();
                        return;
                    }

                    if (!cardChipManager.WriteTopUpData(payinDto.KeyB, payinDto.KeyB, payinDto.DataWriteToCard, out MSG))
                    {
                        AppendToTable(serialNumber, cardType, payinDto, false, MSG);
                        readerLib.Beep(false);
                        SwitchProcessingState();
                        return;
                    }
                }

                #endregion

                #region Step 7: Update status pay in success to sever
                //ghi thanh cong thi moi cap nhat

                if (payinDto != null)
                {
                    try
                    {
                        status = EcashConfigFactory.Instance.GetChannel().UpdateStatusPayIn(storageService.CurrentSessionId, payinDto, strBlank);
                    }
                    catch (TimeoutException)
                    {
                        AppendToTable(serialNumber, cardType, payinDto, false, CommonMessages.TimeOutExceptionMessage);
                        readerLib.Beep(false);
                        SwitchProcessingState();
                        return;
                    }
                    catch (FaultException<WcfServiceFault> ex)
                    {
                        AppendToTable(serialNumber, cardType, payinDto, false, ErrorCodes.GetErrorMessage(ex.Detail.Code));
                        readerLib.Beep(false);
                        SwitchProcessingState();
                        return;
                    }
                    catch (FaultException ex)
                    {
                        AppendToTable(serialNumber, cardType, payinDto, false, ex.Message);
                        readerLib.Beep(false);
                        SwitchProcessingState();
                        return;
                    }
                    catch (CommunicationException)
                    {
                        AppendToTable(serialNumber, cardType, payinDto, false, CommonMessages.CommunicationExceptionMessage);
                        readerLib.Beep(false);
                        SwitchProcessingState();
                        return;
                    }

                    if (status != 0)
                    {
                        AppendToTable(serialNumber, cardType, payinDto, false, "Hệ thống cập nhật phát sinh lổi");
                        readerLib.Beep(false);
                        SwitchProcessingState();
                        return;
                    }
                }
                #endregion

                AppendToTable(serialNumber, cardType, payinDto, true, string.Empty);//payinDto
                readerLib.Beep(true);
                SwitchProcessingState();
            }
        }

        private bool ShowResultValidate(int checkValidate, byte[] serialNumber, int cardType)
        {
            switch (checkValidate)
            {
                //case (int)CardPhysicalStatus.NotCardSystem:
                //    AppendToTable(serialNumber, cardType, new PayInDto(), false, "Thẻ không có trong hệ thống");
                //    readerLib.Beep(false);
                //    SwitchProcessingState();
                //    return false;
                case (int)CardPhysicalStatus.Broken:
                    AppendToTable(serialNumber, cardType, new PayInDto(), false, "Thẻ đã hư");
                    readerLib.Beep(false);
                    SwitchProcessingState();
                    return false;
                case (int)CardPhysicalStatus.Lost:
                    AppendToTable(serialNumber, cardType, new PayInDto(), false, "Thẻ đã thông báo mất");
                    readerLib.Beep(false);
                    SwitchProcessingState();
                    return false;
                case (int)PersoStatus.Locked:
                    AppendToTable(serialNumber, cardType, new PayInDto(), false, "Thẻ đã bị khóa");
                    readerLib.Beep(false);
                    SwitchProcessingState();
                    return false;
                case (int)PersoStatus.Canceled:
                    AppendToTable(serialNumber, cardType, new PayInDto(), false, "Lượt phát hành của thẻ đã bị hủy");
                    readerLib.Beep(false);
                    SwitchProcessingState();
                    return false;
                case (int)PersoStatus.NotPerso:
                    AppendToTable(serialNumber, cardType, new PayInDto(), false, "Thẻ chưa được phát hành");
                    readerLib.Beep(false);
                    SwitchProcessingState();
                    return false;
                default:
                    return true;
            }
        }

        #endregion

        #region hold Amount
        private string holdAmount(string amount)
        {

            return amount;

        }

        private void ckbAmount_CheckedChanged(object sender, EventArgs e)
        {
            string hold = colAmount.ToString();
        }
        #endregion



    }
}
