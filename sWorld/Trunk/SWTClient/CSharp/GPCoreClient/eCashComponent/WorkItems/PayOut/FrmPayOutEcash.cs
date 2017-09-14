using HomeComponent.WorkItems;
using Microsoft.Practices.CompositeUI;
using ReaderLibrary;
using sWorldModel;
using sWorldModel.TransportData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Windows.Forms;

namespace eCashComponent.WorkItems.PayOut
{
    public partial class FrmPayOutEcash : Form
    {
        public FrmPayOutEcash()
        {
            InitializeComponent();
        
        }
      
        /*  #region Properties

       private PcscReader readerLib;
       private bool processing = false;
       private ResourceManager rm;
       private MasterInfoDTO partnerInfo;
       private DataTable dtResults;
       private string strBlank = "1";

       private BackgroundWorker bgwLoadGroupItemWorker;

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

     
        
       #endregion

       #region Payout
      
          public FrmPayOutEcash()
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

       }
       #endregion Payout

       #region Form events
       private void OnButtonStartClicked(object sender, EventArgs e)
       {
           if (cmbReaders.SelectedIndex == -1)
           {
               MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessSelect(rm, MessageValidate.Reader), MessageValidate.GetErrorTitle(rm));
               return;
           }
           //if (Validatefield())
           //{
               //tbnAmount.ReadOnly = true;
               SwitchRunningState(true);
               ChangeStatusMessage("Đang kết nối với thiết bị đọc...");

               string selectedReader = cmbReaders.SelectedItem.ToString();
               readerLib.ConnectToReader(selectedReader);
           //}
       }
       private void OnButtonPauseClicked(object sender, EventArgs e)
       {
         //  tbnAmount.ReadOnly = false;
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
           if (MessageBoxManager.ShowQuestionMessageBox(this, "Bạn có chắc muốn ngừng quá trình nhập khóa và đóng hộp thoại này không?") != DialogResult.Yes)
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
               string KeyB;
               string payInData = strBlank, payOutData = strBlank;

               #region Step 1: Check if card is supplied by master

               // Verify license master card
               if (!cardChipManager.RsaVerifiedLicenseMaster(CardConfigration.START_SECTOR_MASTER, CardConfigration.STOP_SECTOR_MASTER, out MSG))
               {
                   AppendToTable(serialNumber, cardType, new PayInDto(), false, MSG);
                   readerLib.Beep(false);
                   SwitchProcessingState();
                   return;
               }

               #endregion

               #region Step 2: Read header data

               byte[] headerdata;
               if (!cardChipManager.ReadHeaderData(out headerdata, out MSG))
               {
                   AppendToTable(serialNumber, cardType, new PayInDto(), false, MSG);
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
                       AppendToTable(serialNumber, cardType, new PayInDto(), false, MSG);
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
                   AppendToTable(serialNumber, cardType, new PayInDto(), false, MSG);
                   readerLib.Beep(false);
                   SwitchProcessingState();
                   return;
               }

               if (!cardChipManager.GetPayOutData(out payOutData, out MSG))
               {
                   AppendToTable(serialNumber, cardType, new PayInDto(), false, MSG);
                   readerLib.Beep(false);
                   SwitchProcessingState();
                   return;
               }

               #endregion

               #region Step 5: Validate Card

               try
               {
                   checkValidate = EcashConfigFactory.Instance.GetChannel().ValidateCard(storageService.CurrentSessionId, strserial, payInData, payOutData, strBlank);
               }
               catch (TimeoutException)
               {
                   AppendToTable(serialNumber, cardType, new PayInDto(), false, CommonMessages.TimeOutExceptionMessage);
                   readerLib.Beep(false);
                   SwitchProcessingState();
                   return;
               }
               catch (FaultException<WcfServiceFault> ex)
               {
                   AppendToTable(serialNumber, cardType, new PayInDto(), false, ErrorCodes.GetErrorMessage(ex.Detail.Code));
                   readerLib.Beep(false);
                   SwitchProcessingState();
                   return;
               }
               catch (FaultException ex)
               {
                   AppendToTable(serialNumber, cardType, new PayInDto(), false, ex.Message);
                   readerLib.Beep(false);
                   SwitchProcessingState();
                   return;
               }
               catch (CommunicationException)
               {
                   AppendToTable(serialNumber, cardType, new PayInDto(), false, CommonMessages.CommunicationExceptionMessage);
                   readerLib.Beep(false);
                   SwitchProcessingState();
                   return;
               }

               if (checkValidate != 0)
               {
                   AppendToTable(serialNumber, cardType, new PayInDto(), false, "thông tin của thẻ này lổi");
                   readerLib.Beep(false);
                   SwitchProcessingState();
                   return;
               }

               #endregion

               #region GetDataPayOutWriteToCard

               #endregion

               #region UpdateStatusPayOut

               #endregion
           }
       }
       private void AppendToTable(byte[] serialNumber, int cardType, PayInDto payIn, bool result, string reason)
       {
           if (InvokeRequired)
           {
               Invoke(new Action<byte[], int, PayInDto, bool, string>(AppendToTable), serialNumber, cardType, payIn, result, reason);
               return;
           }
           MemberCustomerDto member = LoadMember(payIn.MemberId);
           DataRow row = dtResults.NewRow();
           row[colSerialNumber.DataPropertyName] = StringUtils.ByteArrayToHexString(serialNumber);
           row[colType.DataPropertyName] = ((CardChipType)cardType).GetName();
           row[colMemberName.DataPropertyName] = member != null && member.objMem != null ? member.objMem.GetFullName() : string.Empty;
           row[colAmount.DataPropertyName] = payIn.DataWriteToCard;
           row[colPayinDate.DataPropertyName] = payIn.PayInDate;
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
       private MemberCustomerDto LoadMember(long memberId)
       {
           MemberCustomerDto member = new MemberCustomerDto();
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
           return member;
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

       #endregion Form events

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
      
        */
    }
}
