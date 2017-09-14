using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ReaderLibrary;
using CryptoAlgorithm;
using CommonHelper.Utils;
using System.Data;
using System.Drawing;
using Microsoft.Practices.CompositeUI;
using UtilitiesMgtComponet.WorkItems;
using sWorldModel;
using JavaCommunication.Factory;
using CommonControls;
using sWorldModel.Exceptions;
using System.ServiceModel;
using sWorldModel.MethodData;
using CommonHelper.Config;
using sWorldModel.TransportData;
using sWorldModel.Model;
using CryptoHelper.Generator;
using System.Text;
using CommonHelper.Constants;
using CryptoHelper;
using System.Security.Cryptography;
using System.Linq;
using CardChipService;

namespace UtilitiesMgtComponet.WorkItems
{
    public partial class FrmWriteMasterKey : Form
    {
        #region Properties

        private PcscReader readerLib;
        private bool processing = false;

        private DataTable dtCards;

        private AesEncryption aes;
        private MasterInfoDTO masterInfo;

        private UtilitiesWorkItem workItem;

        private ICardChipManager cardChipManager;

        [ServiceDependency]
        public UtilitiesWorkItem WorkItem
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

        public FrmWriteMasterKey()
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
                cmbMasterInfo.DataSource = new List<MasterInfoDTO>() { this.masterInfo };
                cmbMasterInfo.ValueMember = "MasterId";
                cmbMasterInfo.DisplayMember = "Name";
                cmbMasterInfo.SelectedIndex = 0;
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
            //aes = new AesEncryption(masterInfo.key.KeyValue1);

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
            if (MessageBoxManager.ShowQuestionMessageBox(this, "Bạn có chắc muốn ngừng quá trình nhập khóa và đóng hộp thoại này không?") != DialogResult.Yes)
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

                #region Step 1: Call service to check data in card and get data for write master key
                ResultCheckCardDTO result = null;

                //  msg when writed key failed
                string MSG = String.Empty;

                //verified server data
                cardChipManager = new CardChipManager(readerLib, serialNumber);
                // convert to hex string
                String serialNumberHex = StringUtils.ByteArrayToHexString(serialNumber);

                try
                {
                    // get data for write master key
                    result = CardChipFactory.Instance.GetChannel().CheckAndGetMasterDataToImportCard(storageService.CurrentSessionId,
                         masterInfo.MasterId, serialNumberHex, cardType, CardConfigration.START_SECTOR_MASTER, CardConfigration.STOP_SECTOR_MASTER);


                    if (null == result)
                    {
                        AppendToTable(serialNumber, cardType, false, CommonMessages.TimeOutExceptionMessage);
                        SwitchProcessingState();
                        return;
                    }

                }
                catch (TimeoutException)
                {
                    AppendToTable(serialNumber, cardType, false, CommonMessages.TimeOutExceptionMessage);
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
                    SwitchProcessingState();
                    return;
                }
                catch (CommunicationException)
                {
                    AppendToTable(serialNumber, cardType, false, CommonMessages.CommunicationExceptionMessage);
                    SwitchProcessingState();
                    return;
                }

                #endregion

                #region Step 2 Check data from server swt

                bool isserver = cardChipManager.RsaVerifiedLicenServerHexValue(result.LicenseServer);
                if (!isserver)
                {
                    AppendToTable(serialNumber, cardType, false, CommonMessages.WrongData);
                    SwitchProcessingState();
                    return;
                }

                #endregion

                #region Step 3: Validation data in in card if card information has in server

                if (result.Status != (int)CARD_STATUS.CARD_HAS_MASTER_READED_ONLY)
                {
                    AppendToTable(serialNumber, cardType, false, CommonMessages.CardReadyInfor);
                    SwitchProcessingState();
                    return;
                }
                #endregion

                #region Step 4: Write master key to 3 sector in card

                bool isOke = cardChipManager.WriteLicenseData(CardConfigration.START_SECTOR_MASTER, CardConfigration.STOP_SECTOR_MASTER, result, out MSG);

                if (!isOke)
                {
                    AppendToTable(serialNumber, cardType, false, MSG);
                    readerLib.Beep(false);
                    SwitchProcessingState();
                    return;
                }

                #endregion

                #region Step 5: Update status for server

                // get data for write master key
                if (0 == CardChipFactory.Instance.GetChannel().UpdateDataForCardBySerialAndMasterId(storageService.CurrentSessionId,
                     masterInfo.MasterId, serialNumberHex, cardType, (int)CARD_STATUS.CARD_HAS_MASTER_WRITED_ONLY))
                {
                    readerLib.Beep(true);
                    AppendToTable(serialNumber, cardType, true, string.Empty);
                }
                else
                {
                    readerLib.Beep(false);
                    AppendToTable(serialNumber, cardType, false, CommonMessages.CanNotWriteCardToSystem);
                }


                SwitchProcessingState();
                #endregion
            }
        }

        #endregion
    }
}
