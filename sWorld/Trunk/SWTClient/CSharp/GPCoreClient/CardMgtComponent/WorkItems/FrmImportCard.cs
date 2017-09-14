using System;
using System.Windows.Forms;
using CommonControls.Custom;
using Microsoft.Practices.CompositeUI;
using ReaderLibrary;
using CommonControls;
using CryptoAlgorithm;
using System.ServiceModel;
using CommonHelper.Utils;
using System.Data;
using System.Drawing;
//using WcfServiceCommon;
using sWorldModel;
using sWorldModel.Exceptions;
using sWorldModel.Model;
using sWorldModel.MethodData;
using JavaCommunication;
using CommonHelper.Config;
using  JavaCommunication.Factory;
using System.Collections.Generic;
using sWorldModel.TransportData;

namespace CardMgtComponent.WorkItems
{
    public partial class FrmImportCard : CommonControls.Custom.CommonDialog
    {
        #region Properties

        private PcscReader readerLib;
        private bool processing = false;

        private DataTable dtCards;

        private AesEncryption aes;
        private MasterInfoDTO masterInfo;

        private CardWorkItem workItem;
        [ServiceDependency]
        public CardWorkItem WorkItem
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

        #endregion

        #region Initialization

        public FrmImportCard()
        {
            InitializeComponent();

            readerLib = new PcscReader();
            readerLib.TagDetected += OnTagDetected;
            readerLib.ReaderNotPresent += OnReaderNotPresent;
            readerLib.ReaderUnplugged += OnReaderUnplugged;
            readerLib.ReaderPlugged += OnReaderPlugged;

            btnClose.Click += OnButtonCloseClicked;
            btnListDevices.Click += OnButtonListDevicesClicked;
            btnPause.Click += OnButtonPauseClicked;
            btnStart.Click += OnButtonStartClicked;

            dtCards = new DataTable();
            dtCards.Columns.Add(colSerialNumber.DataPropertyName);
            dtCards.Columns.Add(colType.DataPropertyName);
            dtCards.Columns.Add(colResult.DataPropertyName);
            dgvResult.DataSource = dtCards;

            Shown += OnFormShown;
            FormClosing += OnFormClosing;
        }

        private void OnFormShown(object sender, EventArgs e)
        {
            try
            {
                this.masterInfo = OrganizationFactory.Instance.GetChannel().GetMasterInfo(storageService.CurrentSessionId, SystemSettings.Instance.Master);
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
            aes = new AesEncryption(string.Empty);//key

            DoListDevices();
        }

        #endregion

        #region Form events

        private void OnButtonStartClicked(object sender, EventArgs e)
        {
            if (cmbReaders.SelectedIndex == -1)
            {
                MessageBoxManager.ShowErrorMessageBox(this, "Bạn chưa chọn thiết bị đọc!", "Thao Tác Sai");
                return;
            }

            SwitchRunningState(true);
            ChangeStatusMessage("Đang kết nối với thiết bị đọc...");

            string selectedReader = cmbReaders.SelectedItem.ToString();
            readerLib.ConnectToReader(selectedReader);
        }

        private void OnButtonPauseClicked(object sender, EventArgs e)
        {
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

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBoxManager.ShowQuestionMessageBox(this, "Bạn có chắc muốn ngừng quá trình nhập thẻ và đóng hộp thoại này không?") != DialogResult.Yes)
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

        private void AppendToTable(byte[] serialNumber, int cardType, bool result, string reason)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<byte[], int, bool, string>(AppendToTable), serialNumber, cardType, result, reason);
                return;
            }
            DataRow row = dtCards.NewRow();
            row[colSerialNumber.DataPropertyName] = StringUtils.ByteArrayToHexString(serialNumber);
            row[colType.DataPropertyName] = ((CardChipType)cardType).GetName();
            row[colResult.DataPropertyName] = result ? "Thành công" : "Thất bại (" + reason + ")";
            dtCards.Rows.Add(row);

            int lastRowPos = dgvResult.RowCount - 1;
            dgvResult.FirstDisplayedScrollingRowIndex = lastRowPos;
            foreach (DataGridViewRow r in dgvResult.SelectedRows)
            {
                r.Selected = false;
            }
            dgvResult.Rows[lastRowPos].Selected = true;
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

                #region Step 1: Check if card is supplied by SWT

                // Check if card is supplied by SWT
                byte[] cipher = aes.Encrypt(string.Empty);//key
                byte[] firstSectorKeyA = new byte[6];
                Array.Copy(cipher, 0, firstSectorKeyA, 0, firstSectorKeyA.Length);
                if (!readerLib.IsSwtCard(firstSectorKeyA))
                {
                    AppendToTable(serialNumber, cardType, false, "Không phải thẻ do SWT cung cấp");
                    SwitchProcessingState();
                    return;
                }

                #endregion

                #region Step 2: Call service to get data

                DataForImportCard data = null;
                try
                {
                    data = CardChipFactory.Instance.GetChannel().CheckAndGetDataToImportCard(storageService.CurrentSessionId, serialNumber, cardType);
                }
                catch (TimeoutException)
                {
                    AppendToTable(serialNumber, cardType, false, CommonMessages.TimeOutExceptionMessage);
                    MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.TimeOutExceptionMessage);
                    SwitchProcessingState();
                    return;
                }
                catch (FaultException<WcfServiceFault> ex)
                {
                    AppendToTable(serialNumber, cardType, false, ErrorCodes.GetErrorMessage(ex.Detail.Code));
                    SwitchProcessingState();
                    return;
                }
                catch (FaultException ex)
                {
                    AppendToTable(serialNumber, cardType, false, ex.Message);
                    MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.FaultExceptionMessage
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
                    SwitchProcessingState();
                    return;
                }
                catch (CommunicationException)
                {
                    AppendToTable(serialNumber, cardType, false, CommonMessages.CommunicationExceptionMessage);
                    MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.CommunicationExceptionMessage);
                    SwitchProcessingState();
                    return;
                }

                #endregion

                //#region Step 3: Write key & data to header

                //// Login to sector 1 with default key
                //if (!readerLib.AuthenticateDefault(1))
                //{
                //    AppendToTable( serialNumber, cardType, false, "Không đăng nhập được vào header");
                //    SwitchProcessingState();
                //    return;
                //}

                //// Write data to header
                //if (!readerLib.WriteHeader(data.GetHeaderDataBytes()))
                //{
                //    // If write failed then re-login with new key B
                //    if (!readerLib.Authenticate(1, false, data.HeaderKeyB))
                //    {
                //        AppendToTable(serialNumber, cardType, false, "Không ghi được dữ liệu vào header");
                //        SwitchProcessingState();
                //        return;
                //    }
                //    // Then re-write header data
                //    if (!readerLib.WriteHeader(data.GetHeaderDataBytes()))
                //    {
                //        AppendToTable( serialNumber, cardType, false, "Không ghi được dữ liệu vào header");
                //        SwitchProcessingState();
                //        return;
                //    }
                //}
                //else
                //{
                //    // Write key B to header
                //    if (!readerLib.WriteHeaderKeyB(data.HeaderKeyB))
                //    {
                //        AppendToTable( serialNumber, cardType, false, "Không ghi được khóa vào header");
                //        SwitchProcessingState();
                //        return;
                //    }
                //}

                //#endregion

                //#region Step 4: Write key pair to data sectors

                //// Write key A/B to other sector
                //var sectors = data.DataSectorKeyPairs.Keys;
                //foreach(var s in sectors)
                //{
                //    KeyPairDto keyPair = data.DataSectorKeyPairs[s];

                //    // Login with default key
                //    if (readerLib.AuthenticateDefault(s))
                //    {
                //        // Write new key pair to trailer block
                //        if (!readerLib.WriteDataKeys(s, keyPair.KeyA, keyPair.KeyB))
                //        {
                //            AppendToTable(serialNumber, cardType, false, "Không ghi được khóa vào sector " + s);
                //            SwitchProcessingState();
                //            return;
                //        }
                //    }
                //    else
                //    {
                //        // If login failed then check if keys already wrote
                //        if (!readerLib.Authenticate(s, true, keyPair.KeyA) || !readerLib.Authenticate(s, false, keyPair.KeyB))
                //        {
                //            AppendToTable(serialNumber, cardType, false, "Không ghi được khóa vào sector " + s);
                //            SwitchProcessingState();
                //            return;
                //        }
                //    }
                //}

                //#endregion

                //#region Step 5: Import card to system

                //// Call service to import card
                //try
                //{
                //    CardDto newCard = CardChipFactory.Instance.GetChannel().ImportCard(storageService.CurrentSessionId, serialNumber, cardType, data.HmkAlias, data.DmkAlias);
                //    AppendToTable(serialNumber, cardType, true, string.Empty);
                //}
                //catch (TimeoutException)
                //{
                //    AppendToTable(serialNumber, cardType, false, CommonMessages.TimeOutExceptionMessage);
                //    MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.TimeOutExceptionMessage);
                //}
                //catch (FaultException<WcfServiceFault> ex)
                //{
                //    AppendToTable(serialNumber, cardType, false, ErrorCodes.GetErrorMessage(ex.Detail.Code));
                //}
                //catch (FaultException ex)
                //{
                //    AppendToTable(serialNumber, cardType, false, ex.Message);
                //    MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.FaultExceptionMessage
                //        + Environment.NewLine + Environment.NewLine
                //        + ex.Message);
                //}
                //catch (CommunicationException)
                //{
                //    AppendToTable(serialNumber, cardType, false, CommonMessages.CommunicationExceptionMessage);
                //    MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.CommunicationExceptionMessage);
                //}
                //finally
                //{
                //    SwitchProcessingState();
                //}

                //#endregion
            }
        }

        #endregion
    }
}
