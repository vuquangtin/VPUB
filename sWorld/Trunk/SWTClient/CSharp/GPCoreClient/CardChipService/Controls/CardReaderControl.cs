using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using sWorldModel;
using ReaderManager;
using CommonHelper.Constants;
using CommonHelper.Utils;
using CommonControls;
using ReaderManager.Model;
using sWorldModel.TransportData;
using JavaCommunication.Factory;
using JavaCommunication;
using CardChipMgtComponent.WorkItems;
using System.Collections.Specialized;
using System.Threading;
using Newtonsoft.Json.Linq;
using CommonHelper.Config;

namespace CardChipService.Controls
{
    public partial class CardReaderControl : UserControl
    {
        private DataTable dtCards;
        private ResourceManager rm;
        
        private bool processing = false;
        private ICardChipManager cardChipManager = null;
        private ACTION_ON_CARD action;
        private bool needConfirm = true;
        private FrmConfirmClearData confirmDialog;
        private byte[] DELETE_VALUE = Encoding.ASCII.GetBytes("deleted");

        private Form form;
        public Form Form
        {
            set { form = value; }
        }
        public ACTION_ON_CARD Action
        {
            set { action = value; }
        }

        private MasterInfoDTO masterInfo;
        public MasterInfoDTO Master
        {
            set
            {
                masterInfo = value;
            }
        }
        private ILocalStorageService storageService;
        public ILocalStorageService StorageService
        {
            set
            {
                storageService = value;
            }
        }

        public CardReaderControl()
        {
            InitializeComponent();
            InitializeAction();
        }

        public void InitializeData()
        {
            cardChipManager = new CardChipManager();
            LoadLanguage();
            DoListDevices();
        }

        /// <summary>
        /// initialize necessary control and data
        /// </summary>
        private void InitializeAction()
        {
            btnClose.Click += OnButtonCloseClicked;
            btnListDevices.Click += OnButtonListDevicesClicked;
            btnPause.Click += OnButtonPauseClicked;
            btnStart.Click += OnButtonStartClicked;

            dtCards = new DataTable();
            dtCards.Columns.Add(colSerialNumber.DataPropertyName);
            dtCards.Columns.Add(colType.DataPropertyName);
            dtCards.Columns.Add(colResult.DataPropertyName);
            dgvResult.DataSource = dtCards;

        }

        /// <summary>
        /// load language for all controls in control
        /// </summary>
        private void LoadLanguage()
        {
            rm = storageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
            setitle();
        }

        private void setitle()
        {
            this.colSerialNumber.HeaderText = MessageValidate.GetMessage(rm, this.colSerialNumber.Name);
            this.colType.HeaderText = MessageValidate.GetMessage(rm, this.colType.Name);
            this.colResult.HeaderText = MessageValidate.GetMessage(rm, this.colResult.Name);
        }

        /// <summary>
        /// find all reader connected to pc
        /// </summary>
        private void DoListDevices()
        {
            cmbReaders.DataSource = null;
            List<String> listReaders = cardChipManager.FindAllCardReader();
            if (listReaders != null && listReaders.Count > 0)
            {
                cmbReaders.DataSource = listReaders;
                cmbReaders.SelectedIndex = 0;
            }
        }


        private void OnButtonStartClicked(object sender, EventArgs e)
        {
            if (cmbReaders.SelectedIndex == -1)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessSelect(rm, MessageValidate.Reader), MessageValidate.GetErrorTitle(rm));
                return;
            }
            String selectedReader = cmbReaders.SelectedItem.ToString();
            if (String.Empty != selectedReader)
            {

                if (cardChipManager.WaitingCard(selectedReader))
                {
                    ChangeStatusMessage(MessageValidate.GetMessage(rm, "WaitingTag"));
                    SwitchRunningState(true);
                    cardChipManager.ActionDataHandler += ActionData;
                }
            }
            else
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessSelect(rm, MessageValidate.Reader), MessageValidate.GetErrorTitle(rm));
            }
        }

        private void ActionData(DataCardObject obj)
        {
            
            switch (obj.eventType)
            {
                case DataCardObject.TAG_DETECTED:
                    OnTagDetected(obj.cardType, obj.serialNumber);
                    break;
                case DataCardObject.READER_NOT_PRESENT:
                    OnReaderNotPresent();
                    break;
                case DataCardObject.READER_PLUGGED:
                    OnReaderPlugged();
                    break;
                case DataCardObject.READER_UNPLUGGED:
                    OnReaderUnplugged();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// change control state
        /// </summary>
        /// <param name="running"></param>
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

        /// <summary>
        /// change message
        /// </summary>
        /// <param name="msg"></param>
        private void ChangeStatusMessage(string msg)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(ChangeStatusMessage), msg);
                return;
            }
            lblStatus.Text = msg;
        }

        /// <summary>
        /// change processing state
        /// </summary>
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
                lblStatus.Text = MessageValidate.GetMessage(rm, "WaitingTag");
                processing = false;
            }
            else
            {
                processing = true;
                //lblStatus.BackColor = Color.FromArgb(3, 111, 192);
                lblStatus.BackColor = SystemColors.Highlight;
                //lblStatus.ForeColor = Color.WhiteSmoke;
                lblStatus.ForeColor = SystemColors.HighlightText;
                lblStatus.Text = MessageValidate.GetMessage(rm, "PerformActionOnCard");
            }
        }

        /// <summary>
        /// show status to data gridview
        /// </summary>
        /// <param name="serialNumber"></param>
        /// <param name="cardType"></param>
        /// <param name="result"></param>
        /// <param name="reason"></param>
        private void AppendToTable(String strSerial, int cardType, bool result, String reason)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<String, int, bool, String>(AppendToTable), strSerial, cardType, result, reason);
                return;
            }
            DataRow row = dtCards.NewRow();
            row[colSerialNumber.DataPropertyName] = strSerial;
            row[colType.DataPropertyName] = ((CardChipType)cardType).GetName();
            
            if(result)
                row[colResult.DataPropertyName] = MessageValidate.GetMessage(rm, "SucessfulMessage");
            else
                row[colResult.DataPropertyName] = reason ;
            
            dtCards.Rows.Add(row);

            int lastRowPos = dgvResult.RowCount - 1;
            dgvResult.FirstDisplayedScrollingRowIndex = lastRowPos;
            foreach (DataGridViewRow r in dgvResult.SelectedRows)
            {
                r.Selected = false;
            }
            dgvResult.Rows[lastRowPos].Selected = true;
        }

        #region Event on card

        private DialogResult ShowConfirmDialog()
        {
            if (InvokeRequired)
            {
                return (DialogResult)Invoke(new Func<DialogResult>(() => ShowConfirmDialog()));
            }
            if (needConfirm)
            {
                if (confirmDialog == null || confirmDialog.IsDisposed)
                {
                    confirmDialog = new FrmConfirmClearData();
                }
                confirmDialog.ShowDialog(this);
                needConfirm = !confirmDialog.NotShowMore;
                return confirmDialog.DialogResult;
            }
            return DialogResult.Yes;
        }

        /// <summary>
        /// Khi the duoc tag goi ham nay de xu ly kiem tra qua trinh doc ghi the
        /// 2 tham so nay nhan duoc tu dau doc gui qua thong qua event
        /// 
        /// </summary>
        /// <param name="cardType"></param>
        /// <param name="serialNumber"></param>
        private void OnTagDetected(int cardType, byte[] serialNumber)
        {
            if (!processing)
            {
                SwitchProcessingState();

                cardChipManager.SetCardInfor(cardType, serialNumber);

                Thread.Sleep(400);
                switch (action)
                {
                    case ACTION_ON_CARD.WRITE_MATER_KEY:
                        WriteMaterKey(cardType, serialNumber);
                        break;
                    case ACTION_ON_CARD.CLEAR_EMPTY_CARD:
                        CleanUpCard(cardType, serialNumber);
                        break;

                    case  ACTION_ON_CARD.CLEAR_PERSO_DATA:
                        if (ShowConfirmDialog() != DialogResult.Yes)
                        {
                            SwitchProcessingState();
                            return;
                        }
                        else
                        {
                            ClearPersoOnCard(cardType, serialNumber);
                        }
                        break;
                    

                    case ACTION_ON_CARD.READ_DATA:
                        {
                            ReadDataOnCard(cardType, serialNumber);
                            break;
                        }
                    case ACTION_ON_CARD.READ_PERSO_DATA:
                        {
                            ReadPersoDataOnCard(cardType, serialNumber);
                            break;
                        }
                    case ACTION_ON_CARD.UPADATE_CARD_DATA:
                        {
                            UpdatePersoCardData(cardType, serialNumber);
                            break;
                        }
                }
            }

            SwitchProcessingState();
        }

        private void OnReaderUnplugged()
        {
            ChangeStatusMessage(MessageValidate.GetMessage(rm,"LostConnectionReader"));
            SwitchRunningState(false);
        }

        private void OnReaderPlugged()
        {
            ChangeStatusMessage(MessageValidate.GetMessage(rm,"WaitingTag"));
        }

        private void OnReaderNotPresent()
        {
            ChangeStatusMessage(MessageValidate.GetMessage(rm,"ErrorConnect"));
            SwitchRunningState(false);
        }

        /// <summary>
        /// check card exist on system
        /// </summary>
        /// <param name="strSerial"></param>
        /// <param name="cardType"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        private bool IsCardNotExist(String strSerial, int cardType, int status)
        {
            if (status != (int)CARD_STATUS.CARD_HAS_MASTER_READED_ONLY)
            {
                cardChipManager.Alert(false);
                AppendToTable(strSerial, cardType, false, MessageValidate.GetMessage(rm, "CardReadyInfor"));
                return false;
            }

            return true;
        }

        /// <summary>
        /// check out master from server
        /// </summary>
        /// <param name="strSerial"></param>
        /// <param name="intCardType"></param>
        /// <returns></returns>
        private ResultCheckCardDTO CheckAndGetMasterData(String strSerial, int intCardType)
        {
            ResultCheckCardDTO result = null;
            try
            {
                // check and get master key for writting master key to card
                result = CardChipFactory.Instance.GetChannel().CheckAndGetMasterDataToImportCard(storageService.CurrentSessionId,
                     masterInfo.MasterId, strSerial, intCardType, CardConfigration.START_SECTOR_MASTER, CardConfigration.STOP_SECTOR_MASTER);
                if (null == result)
                {
                    AppendToTable(strSerial, intCardType, false, MessageValidate.GetMessage(rm, "CanNotGetDataFromServer"));
                }

            }
            catch (Exception)
            {
                AppendToTable(strSerial, intCardType, false, MessageValidate.GetMessage(rm, "CanNotGetDataFromServer"));
            }
            return result;
        }

        /// <summary>
        /// Cleck master license on card
        /// </summary>
        /// <param name="strSerial"></param>
        /// <param name="intCardType"></param>
        /// <returns></returns>
        private bool VerifyMasterLicenseOnCard(String strSerial, int intCardType)
        {
            string msg = null;
            bool result = cardChipManager.RsaVerifiedLicenseMaster(CardConfigration.START_SECTOR_MASTER, CardConfigration.STOP_SECTOR_MASTER, out msg);
            if (!result)
            {
                AppendToTable(strSerial, intCardType, false, MessageValidate.GetMessage(rm, msg));
                cardChipManager.Alert(false);

            }
            return result;
        }

        /// <summary>
        /// read header data on card
        /// </summary>
        /// <param name="strSerial"></param>
        /// <param name="intCardType"></param>
        /// <returns></returns>
        private bool ReadHeaderDataOnCard(String strSerial, int intCardType, out byte[] headerdata)
        {
            string msg = "";
            bool result = cardChipManager.ReadHeaderData(out headerdata, out msg);
            if (!result)
            {
                AppendToTable(strSerial, intCardType, false, msg);
                cardChipManager.Alert(false);
            }
            return result;
        }

        /// <summary>
        /// check have partner on card
        /// </summary>
        /// <param name="strSerial"></param>
        /// <param name="intCardType"></param>
        /// <returns></returns>
        private bool VerifyPartnerOnCard(String strSerial, int intCardType, byte[] headerdata)
        {
            bool result = cardChipManager.HasPartner(headerdata);
            string msg;
            //has partner so go to verify partner version
            if (result)
            {
                result = cardChipManager.RsaVerifiedLicensePartner(CardConfigration.START_SECTOR_PARTNER, CardConfigration.STOP_SECTOR_PARTNER, out msg);
                if (!result)
                {
                    AppendToTable(strSerial, intCardType, false, msg);
                    cardChipManager.Alert(false);

                }

            }

            return result;

        }

        /// <summary>
        /// check and get app data to clear data on card
        /// </summary>
        /// <param name="strSerial"></param>
        /// <param name="intCardType"></param>
        /// <param name="sectorBegin"></param>
        /// <param name="sectorEnd"></param>
        /// <param name="appData"></param>
        /// <returns></returns>
        private bool CheckAndGetKeyToClearDataOnCard(String strSerial, int intCardType, byte sectorBegin, byte sectorEnd , out DataToWriteCardDTO appData)
        {
            appData = null;
            bool result = false;
            try
            {
                appData = ChipPersonalizationFactory.Instance.GetChannel().CheckAndGetAppDataToClearCard(storageService.CurrentSessionId, strSerial, intCardType, sectorBegin, sectorEnd, SystemSettings.Instance.Partner);
            }
            catch (Exception ex)
            {
                AppendToTable(strSerial, intCardType, false, ex.Message);
                cardChipManager.Alert(false);
                SwitchProcessingState();
                return result;
            }

            if (null == appData)
            {
                // do not have data from server
                AppendToTable(strSerial, intCardType, false, MessageValidate.GetMessage(rm, "NotData"));
                cardChipManager.Alert(false);
                SwitchProcessingState();
                return result;
            }
            else
            {
                result = cardChipManager.RsaVerifiedPartnerLicenseServerHexValue (appData.LicenseServer);
                if (!result)
                {
                    AppendToTable(strSerial, intCardType, false, MessageValidate.GetMessage(rm, "WrongData"));
                    cardChipManager.Alert(false);
                    SwitchProcessingState();
                    return result;
                }
            }

            return result;

        }
        /// <summary>
        ///  check license
        /// </summary>
        /// <param name="strSerial"></param>
        /// <param name="intCardType"></param>
        /// <param name="strLicense"></param>
        /// <returns></returns>
        private bool CheckMasterServerLicense(String strSerial, int intCardType, String strLicense)
        {
            bool isserver = strLicense != null ? cardChipManager.RsaVerifiedMasterLicenseServerHexValue(strLicense) : false;
            if (!isserver)
            {
                AppendToTable(strSerial, intCardType, false, MessageValidate.GetMessage(rm, "WrongData"));
            }

            return isserver;
        }

        /// <summary>
        /// write master license data
        /// </summary>
        /// <param name="strSerial"></param>
        /// <param name="intCardType"></param>
        /// <param name="carddto"></param>
        /// <returns></returns>
        private bool WriteMasterData(String strSerial, int intCardType, ResultCheckCardDTO carddto)
        {
            // to check the card have on data base or not
            bool result  = IsCardNotExist(strSerial, intCardType, carddto.Status);
            if (result)
            {
                string msg;
                // to wirte license data to card
                result = cardChipManager.WriteLicenseData(CardConfigration.START_SECTOR_MASTER, CardConfigration.STOP_SECTOR_MASTER , carddto, out msg);

                if (!result)
                {
                    AppendToTable(strSerial, intCardType, false, msg);
                    cardChipManager.Alert(false);
                }
            }

            return result;
        }

        private DataToWriteCardDTO GetKeysToClearEmptyCard(int intCardType, String strSerial)
        {
            DataToWriteCardDTO result = new DataToWriteCardDTO();

            //  msg when writed key failed
            string MSG = String.Empty;

            try
            {
                result.KEY = CardChipFactory.Instance.GetChannel().GetKeyClearEmptyCard(storageService.CurrentSessionId,
                     masterInfo.MasterId, strSerial, intCardType);

                if (null == result.KEY)
                {
                    AppendToTable(strSerial, intCardType, false, MessageValidate.GetMessage(rm, "CanNotGetDataFromServer"));
                    
                    return null;
                }

            }
            catch (Exception)
            {
                AppendToTable(strSerial, intCardType, false, MessageValidate.GetMessage(rm, "CanNotGetDataFromServer"));
                return null;
            }

            return result;
        }

        /// <summary>
        /// update card status on server
        /// </summary>
        /// <param name="strSerial"></param>
        /// <param name="intCardType"></param>
        /// <returns></returns>
        private bool UpdateCardStatusToServer(String strSerial, int intCardType)
        {
            // update card information to server
            //NOTE: At the moment, we don't know partner. So that partner id is master id
            bool result = false;
            if (0 == CardChipFactory.Instance.GetChannel().UpdateDataForCardBySerialAndMasterId(storageService.CurrentSessionId,
                 masterInfo.MasterId, masterInfo.MasterId, strSerial, intCardType, (int)CARD_STATUS.CARD_HAS_MASTER_WRITED_ONLY))
            {
                cardChipManager.Alert(true);
                AppendToTable(strSerial, intCardType, true, string.Empty);
                result = true;
            }
            else
            {
                cardChipManager.Alert(false);
                AppendToTable(strSerial, intCardType, false, MessageValidate.GetMessage(rm, "CanNotWriteCardToSystem"));
            }

            return result;
        }

        /// <summary>
        /// call service clear card on server
        /// </summary>
        /// <param name="strSerial"></param>
        /// <param name="intCardType"></param>
        /// <returns></returns>
        private void ClearUpCardOnServer(String strSerial, int intCardType)
        {
            try
            {
                if ((int)Status.SUCCESS == CardMagneticFactory.Instance.GetChannel().ClearCardEmpty(storageService.CurrentSessionId, strSerial))
                {
                    cardChipManager.Alert(true);
                    AppendToTable(strSerial, intCardType, true, string.Empty);
                }
                else
                {
                    cardChipManager.Alert(false);
                    AppendToTable(strSerial, intCardType, false, MessageValidate.GetMessage(rm, "CanNotFindCardOnServer"));
                }
            }
            catch (Exception ex)
            {
                AppendToTable(strSerial, intCardType, false, ex.Message);
            }
        }


        /// <summary>
        /// write license and master key on card
        /// </summary>
        /// <param name="cardType"></param>
        /// <param name="byteSerial"></param>
        private void WriteMaterKey(int cardType, byte[] byteSerial)
        {
            ResultCheckCardDTO result = null;
            String strSerial = StringUtils.ByteArrayToHexString(byteSerial);

            // to check and get a master data from server
            result = CheckAndGetMasterData(strSerial, cardType);
            if (null != result)
            {
                //to check the license from server
                bool isOkie = cardChipManager.RsaVerifiedMasterLicenseServerHexValue(result.LicenseServer);
                if (isOkie)
                {
                    //to write the master key to 3 sector in card
                    isOkie = WriteMasterData(strSerial, cardType, result);
                    if (isOkie)
                    {      //update card status on server
                        UpdateCardStatusToServer(strSerial, cardType);
                    }
                }
                else
                {
                    AppendToTable(strSerial, cardType, false, MessageValidate.GetMessage(rm, "WrongData"));

                }

            }

        }

        /// <summary>
        /// clear empty card 
        /// </summary>
        /// <param name="intCardType"></param>
        /// <param name="byteSerial"></param>
        private void CleanUpCard(int intCardType, byte[] byteSerial)
        {
            DataToWriteCardDTO result = null;
            String strSerial = StringUtils.ByteArrayToHexString(byteSerial);

            String MSG = "";
            result = GetKeysToClearEmptyCard(intCardType, strSerial);
            if (null != result)
            {
                bool isOkie = cardChipManager.ClearUpAllData(result, out MSG, false);
                if (isOkie)
                {
                    ClearUpCardOnServer(strSerial, intCardType);
                }
                else
                {
                    cardChipManager.Alert(false);
                    AppendToTable(strSerial, intCardType, false, MessageValidate.GetMessage(rm, "CanNotClearCardOnSystem"));
                }
            }

        }

        /// <summary>
        /// upate header data
        /// </summary>
        /// <param name="strSerial"></param>
        /// <param name="intCardType"></param>
        /// <param name="keyB"></param>
        /// <param name="headerdata"></param>
        /// <returns></returns>
        private bool UpDateHeaderData(String strSerial, int intCardType, byte[] keyB, byte[] headerdata)
        {
            String msg;
            bool result = cardChipManager.UpdateHeaderData(headerdata, keyB, out msg);
            if (!result)
            {
                AppendToTable(strSerial, intCardType, false, msg);
                cardChipManager.Alert(false);
            }

            return result;
        }

        private void UpdateClearCardDataToServer(String strSerial, int intCardType)
        {

            try
            {
                if ((int)Status.SUCCESS == ChipPersonalizationFactory.Instance.GetChannel().ClearCardData(storageService.CurrentSessionId, strSerial))
                {
                    AppendToTable(strSerial, intCardType, true, string.Empty);
                    cardChipManager.Alert(true);
                }
                else
                {
                    cardChipManager.Alert(false);
                    AppendToTable(strSerial, intCardType, false, MessageValidate.GetMessage(rm, "CanNotClearCardToSystem"));
                }
            }
            catch (Exception ex)
            {
                cardChipManager.Alert(false);
                AppendToTable(strSerial, intCardType, false, ex.Message);
            }
        }
        private void UpdateCardDataToServer(String strSerial,string lastUpdateDate, int intCardType)
        {
            try
            {
                if ((int)Status.SUCCESS == ChipPersonalizationFactory.Instance.GetChannel().UpdateMemberAppOfPerso(storageService.CurrentSessionId, strSerial, lastUpdateDate))
                {
                    AppendToTable(strSerial, intCardType, true, string.Empty);
                    cardChipManager.Alert(true);
                }
                else
                {
                    cardChipManager.Alert(false);
                    AppendToTable(strSerial, intCardType, false, MessageValidate.GetMessage(rm, "c"));
                }
            }
            catch (Exception ex)
            {
                cardChipManager.Alert(false);
                AppendToTable(strSerial, intCardType, false, ex.Message);
            }
        }
        private Member LoadMember(long memberId)
        {
            Member member = new Member();
            try
            {

                member = OrganizationFactory.Instance.GetChannel().GetMemberById(storageService.CurrentSessionId, memberId);
            }
            catch (Exception ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "TimeOutExceptionMessage"));
            }
            
            return member;
        }

        private String SendStringData(string data)
        {
            return data;
        }

        private StringCollection ParserData(string cardData, string amountPayIn = "")
        {
            StringCollection data = new StringCollection();

            JObject jObject = new JObject();

            string[] itemList = cardData.Split('|');
            if (itemList.Length > 0)
            {
                Member member = LoadMember(Convert.ToInt64(itemList[0]));
                data.Add(member.Code);
                data.Add(member.GetFullName());
                data.Add(member.IdentityCard);
                data.Add(member.IdentityCardIssueDate);
                data.Add(member.IdentityCardIssue);
                data.Add(member.Email);
            }

            return data;
        }

        private void ShowCardDataDialog(string serialNumberHex, string cardData, string payInData = null)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => { ShowCardDataDialog(serialNumberHex, cardData, payInData); }));
                return;
            }
            FrmShowMemberData dataDialog = FrmShowMemberData.Instance;
            dataDialog.rm = rm;
            dataDialog.StartPosition = FormStartPosition.CenterScreen;

            dataDialog.SerialNumberHex = serialNumberHex;
            dataDialog.CardDataJson = SendStringData(cardData);
            
            dataDialog.Show();
        }

        private void ClearPersoOnCard(int intCardType, byte[] byteSerial)
        {
            String strSerial = StringUtils.ByteArrayToHexString(byteSerial);
            //check master license on card
            byte[] headerData;
            bool result = ReadHeaderDataOnCard(strSerial, intCardType, out headerData);

            //have header data
            if (result)
            {
                result = VerifyPartnerOnCard(strSerial, intCardType, headerData);
                if (!result)
                    return;

                //get the position of begin sector have data
                byte sectorBegin, sectorEnd;
                cardChipManager.IdentifyBeginSectorFromHeaderData(headerData, out sectorBegin, out sectorEnd);
                // get list key 
                List<int> lsRequestKey = cardChipManager.NeedRequestKeyReadData(headerData);

                if (lsRequestKey.Count > 0)
                {
                    DataToWriteCardDTO appData;
                    result = CheckAndGetKeyToClearDataOnCard(strSerial, intCardType, sectorBegin, sectorEnd, out appData);
                    if (result)
                    {
                        //call function clear data on app
                        String msg;
                        result = cardChipManager.ClearPersoData(appData, out msg);
                        if (!result)
                        {
                            AppendToTable(strSerial, intCardType, false, MessageValidate.GetMessage(rm, "CanNotCleanAppData"));
                            cardChipManager.Alert(false);
                        }
                        else
                        {
                            byte[] keyHeader = StringUtils.HexStringToByteArray(appData.ListSectorKeyPair(3).KeyB);
                            headerData[0] = 0;
                            //update header data
                            result = UpDateHeaderData(strSerial, intCardType, keyHeader, headerData);
                            if (result)
                            {
                                //call service to update on server
                                UpdateClearCardDataToServer(strSerial, intCardType);
                            }
                        }
                    }
                }
                else
                {
                    AppendToTable(strSerial, intCardType, false, MessageValidate.GetMessage(rm, "DoNotHaveDataOnCard"));
                    cardChipManager.Alert(false);
                }

            }
        }

        /// <summary>
        /// clear data on card
        /// </summary>
        /// <param name="intCardType"></param>
        /// <param name="byteSerial"></param>
        /*
        private void CleadDataOnCard(int intCardType, byte[] byteSerial)
        {
             String strSerial = StringUtils.ByteArrayToHexString(byteSerial);
            //check master license on card
             byte[] headerData;
             bool result = ReadHeaderDataOnCard(strSerial, intCardType, out headerData);

            //have header data
             if (result)
             {
                 VerifyPartnerOnCard(strSerial, intCardType, headerData);
                 
                 //get the position of begin sector have data
                 byte sectorBegin, sectorEnd;
                 cardChipManager.IdentifyBeginSectorFromHeaderData(headerData, out sectorBegin, out sectorEnd);
                 // get list key 
                 List<int> lsRequestKey = cardChipManager.NeedRequestKeyReadData(headerData);

                 if (lsRequestKey.Count > 0)
                 {
                     DataToWriteCardDTO appData;
                     result = CheckAndGetKeyToClearDataOnCard(strSerial, intCardType, sectorBegin, sectorEnd, out appData);
                     if (result)
                     {
                         //call function clear data on app
                         String msg;
                         result = cardChipManager.ClearAppData(appData, out msg);
                         if (!result)
                         {
                             AppendToTable(strSerial, intCardType, false, MessageValidate.GetMessage(rm, "CanNotCleanAppData"));
                             cardChipManager.Alert(false);
                         }
                         else
                         {
                             byte[] keyHeader = StringUtils.HexStringToByteArray(appData.ListSectorKeyPair(3).KeyB);
                             headerData[0] = 0;
                             //update header data
                             result = UpDateHeaderData(strSerial, intCardType, keyHeader, headerData);
                             if (result)
                             {
                                 //call service to update on server
                                 UpdateClearCardDataToServer(strSerial, intCardType);
                             }
                         }
                     }
                 }
                 else
                 {
                     AppendToTable(strSerial, intCardType, false, MessageValidate.GetMessage(rm, "DoNotHaveDataOnCard"));
                     cardChipManager.Alert(false);
                 }

             }

        }
        */
        private byte[] TrimEnd(byte[] array)
        {
            int lastIndex = Array.FindLastIndex(array, b => b != 0);

            Array.Resize(ref array, lastIndex + 1);

            return array;
        }

        private void ReadPesoDataOnDesFireCard(int intCardType, byte[] byteSerial)
        {
            String strSerial = StringUtils.ByteArrayToHexString(byteSerial);

            bool result = VerifyMasterLicenseOnCard(strSerial, intCardType);
            if (result)
            {
                byte[] headerData;
                result = ReadHeaderDataOnCard(strSerial, intCardType, out headerData);
                if (result)
                {
                    result = VerifyPartnerOnCard(strSerial, intCardType, headerData);
                    if (result)
                    {
                        byte[] carddata;
                        String msg;
                        DataToReadCardDTO keydata = new DataToReadCardDTO();
                        result = cardChipManager.ReadPersoData(keydata, headerData, out carddata, out msg);
                        if (!result)
                        {
                            AppendToTable(strSerial, intCardType, false, MessageValidate.GetMessage(rm, "NotInfomation"));
                            cardChipManager.Alert(false);
                            return;
                        }
                    
                        //conver to encrypt hex tring
                        byte[] trimdata = TrimEnd(carddata);
                        String hexStrData = StringUtils.GetString(trimdata);

                        //convert to byte array for decrypting
                        byte[] data = StringUtils.HexStringToByteArray(hexStrData);

                        // decrypte data by partner key
                        byte[] decodeData = cardChipManager.decryptData("AES", data, "partner");
                        String strData = Encoding.UTF8.GetString(decodeData);

                        byte[] temp = new byte[1024];

                        if (!result || string.IsNullOrEmpty(strData) || strData == UTF8Encoding.UTF8.GetString(temp) || strData.StartsWith(DELETE_VALUE.ToString()))
                        {
                            AppendToTable(strSerial, intCardType, false, MessageValidate.GetMessage(rm, "NotInfomation"));
                            cardChipManager.Alert(false);
                        }
                        else
                        {
                            ShowCardDataDialog(strSerial, strData);
                            AppendToTable(strSerial, intCardType, true, carddata.ToString());
                            cardChipManager.Alert(true);
                        }
                    }
                   
                }
            }
        }
        /// <summary>
        /// read data on desfirecard
        /// </summary>
        /// <param name="intCardType"></param>
        /// <param name="byteSerial"></param>
        private void ReadDataOnDesFireCard(int intCardType, byte[] byteSerial)
        {
            String strSerial = StringUtils.ByteArrayToHexString(byteSerial);

            bool result = VerifyMasterLicenseOnCard(strSerial, intCardType);
            if (result)
            {
                byte[] headerData;
                result = ReadHeaderDataOnCard(strSerial, intCardType, out headerData);
                if (result)
                {
                    result = VerifyPartnerOnCard(strSerial, intCardType, headerData);
                    if (result)
                    {
                        byte[] carddata;
                        String msg;
                        DataToReadCardDTO keydata = new DataToReadCardDTO();
                        result = cardChipManager.ReadAppData(keydata, headerData, out carddata, out msg);

                        string strData = UTF8Encoding.UTF8.GetString(carddata);
                        byte[] temp = new byte[1024];

                        if (!result || string.IsNullOrEmpty(strData) || strData == UTF8Encoding.UTF8.GetString(temp) || strData.StartsWith(DELETE_VALUE.ToString()))
                        {
                            AppendToTable(strSerial, intCardType, false, MessageValidate.GetMessage(rm, "NotInfomation"));
                            cardChipManager.Alert(false);
                        }
                        else
                        {
                            ShowCardDataDialog(strSerial, strData);
                            AppendToTable(strSerial, intCardType, true, carddata.ToString());
                            cardChipManager.Alert(true);
                        }
                    }
                    else
                    {
                        AppendToTable(strSerial, intCardType, false, MessageValidate.GetMessage(rm, "NotInfomation"));
                        cardChipManager.Alert(false);
                    }
                }
            }

        }
        private void ReadPesoDataOnClassicCard(int intCardType, byte[] byteSerial)
        {
            String strSerial = StringUtils.ByteArrayToHexString(byteSerial);

            bool result = VerifyMasterLicenseOnCard(strSerial, intCardType);
            if (result)
            {
                byte[] headerData;
                result = ReadHeaderDataOnCard(strSerial, intCardType, out headerData);
                if (result)
                {
                    //veridy partner on card
                    VerifyPartnerOnCard(strSerial, intCardType, headerData);

                    //get key to read data
                    List<int> lsRequestKey = cardChipManager.NeedRequestKeyReadData(headerData);
                    if (lsRequestKey.Count == 0)
                    {
                        AppendToTable(strSerial, intCardType, false, MessageValidate.GetMessage(rm, "NotInfomation"));
                        cardChipManager.Alert(false);
                    }
                    else
                    {
                        DataToReadCardDTO keydata = null;
                        try
                        {
                            keydata = ChipPersonalizationFactory.Instance.GetChannel().GetKeyForReadCard(storageService.CurrentSessionId, strSerial, intCardType, lsRequestKey);
                            if (keydata == null)
                            {
                                AppendToTable(strSerial, intCardType, false, MessageValidate.GetMessage(rm, "NotInfomation"));
                                cardChipManager.Alert(false);
                            }
                            else
                            {
                                result = cardChipManager.RsaVerifiedPartnerLicenseServerHexValue(keydata.LicenseServer);
                                if (result)
                                {
                                    byte[] carddata;
                                    String msg;
                                    result = cardChipManager.ReadAppData(keydata, headerData, out carddata, out msg);

                                    string strData = UTF8Encoding.UTF8.GetString(carddata);

                                    if (!result || string.IsNullOrEmpty(strData))
                                    {
                                        AppendToTable(strSerial, intCardType, false, MessageValidate.GetMessage(rm, "NotInfomation"));
                                        cardChipManager.Alert(false);
                                    }
                                    else
                                    {
                                        ShowCardDataDialog(strSerial, strData);
                                        AppendToTable(strSerial, intCardType, true, carddata.ToString());
                                        cardChipManager.Alert(true);
                                    }
                                }
                                else
                                {
                                    AppendToTable(strSerial, intCardType, false, MessageValidate.GetMessage(rm, "WrongData"));
                                    cardChipManager.Alert(false);
                                    SwitchProcessingState();
                                }

                            }
                        }
                        catch (Exception ex)
                        {
                            AppendToTable(strSerial, intCardType, false, ex.Message);
                            cardChipManager.Alert(false);
                        }
                    }

                }
            }
        }
        private void ReadDataOnClassicCard(int intCardType, byte[] byteSerial)
        {
            String strSerial = StringUtils.ByteArrayToHexString(byteSerial);

            bool result = VerifyMasterLicenseOnCard(strSerial, intCardType);
            if (result)
            {
                byte[] headerData;
                result = ReadHeaderDataOnCard(strSerial, intCardType, out headerData);
                if (result)
                {
                    //veridy partner on card
                    VerifyPartnerOnCard(strSerial, intCardType, headerData);

                    //get key to read data
                    List<int> lsRequestKey = cardChipManager.NeedRequestKeyReadData(headerData);
                    if (lsRequestKey.Count == 0)
                    {
                        AppendToTable(strSerial, intCardType, false, MessageValidate.GetMessage(rm, "NotInfomation"));
                        cardChipManager.Alert(false);
                    }
                    else
                    {
                        DataToReadCardDTO keydata = null;
                        try
                        {
                            keydata = ChipPersonalizationFactory.Instance.GetChannel().GetKeyForReadCard(storageService.CurrentSessionId, strSerial, intCardType, lsRequestKey);
                            if (keydata == null)
                            {
                                AppendToTable(strSerial, intCardType, false, MessageValidate.GetMessage(rm, "NotInfomation"));
                                cardChipManager.Alert(false);
                            }
                            else
                            {
                                result = cardChipManager.RsaVerifiedPartnerLicenseServerHexValue(keydata.LicenseServer);
                                if (result)
                                {
                                    byte[] carddata;
                                    String msg;
                                    result = cardChipManager.ReadAppData(keydata, headerData, out carddata, out msg);

                                    string strData = UTF8Encoding.UTF8.GetString(carddata);

                                    if (!result || string.IsNullOrEmpty(strData))
                                    {
                                        AppendToTable(strSerial, intCardType, false, MessageValidate.GetMessage(rm, "NotInfomation"));
                                        cardChipManager.Alert(false);
                                    }
                                    else
                                    {
                                        ShowCardDataDialog(strSerial, strData);
                                        AppendToTable(strSerial, intCardType, true, carddata.ToString());
                                        cardChipManager.Alert(true);
                                    }
                                }
                                else
                                {
                                    AppendToTable(strSerial, intCardType, false, MessageValidate.GetMessage(rm, "WrongData"));
                                    cardChipManager.Alert(false);
                                    SwitchProcessingState();
                                }

                            }
                        }
                        catch (Exception ex)
                        {
                            AppendToTable(strSerial, intCardType, false, ex.Message);
                            cardChipManager.Alert(false);
                        }
                    }

                }
            }
        }

        private void ReadDataOnCard(int intCardType, byte[] byteSerial)
        {
            switch (intCardType)
            {
                case (int)CARD_TYPE.DESFIRE_CARD:
                    ReadDataOnDesFireCard(intCardType, byteSerial);
                    break;
                default:
                    ReadDataOnClassicCard(intCardType, byteSerial);
                    break;

            }
        }

        private void ReadPersoDataOnCard(int intCardType, byte[] byteSerial)
        {
            switch (intCardType)
            {
                case (int)CARD_TYPE.DESFIRE_CARD:
                    ReadPesoDataOnDesFireCard(intCardType, byteSerial);
                    break;
                default:
                    ReadPesoDataOnClassicCard(intCardType, byteSerial);
                    break;

            }
        }

        private void UpdatePersoCardData(int intCardType, byte[] byteSerial)
        {
            string strSerial = StringUtils.ByteArrayToHexString(byteSerial);
           // Step 1: Check if card is supplied by SWT
            bool result = VerifyMasterLicenseOnCard(strSerial, intCardType);
            if (result)
            {
                byte[] headerData;
                result = ReadHeaderDataOnCard(strSerial, intCardType, out headerData);
                if (result)
                {
                    //veridy partner on card
                    result = VerifyPartnerOnCard(strSerial, intCardType, headerData);
                    if (!result)
                        return;

                    //get key to read data
                    //get the position of begin sector have data
                    byte sectorBegin, sectorEnd;
                    List<int> lsRequestKey = cardChipManager.NeedRequestKeyReadData(headerData);
                    cardChipManager.IdentifyBeginSectorFromHeaderData(headerData, out sectorBegin, out sectorEnd);
                    if (lsRequestKey.Count == 0)
                    {
                        AppendToTable(strSerial, intCardType, false, MessageValidate.GetMessage(rm, "NotInfomation"));
                        cardChipManager.Alert(false);
                    }
                    else
                    {
                        DataToWriteCardDTO keydata = null;
                        try
                        {
                            keydata = ChipPersonalizationFactory.Instance.GetChannel().GetDataToUpdateCard(storageService.CurrentSessionId, strSerial, sectorBegin, SystemSettings.Instance.Partner);
                            if (keydata == null)
                            {
                                AppendToTable(strSerial, intCardType, false, MessageValidate.GetMessage(rm, "NotInfomation"));
                                cardChipManager.Alert(false);
                            }
                            else
                            {
                                result = cardChipManager.RsaVerifiedPartnerLicenseServerHexValue( keydata.LicenseServer);
                                if (result)
                                {
                                    String msg;
                                    result = cardChipManager.WritePersoData(keydata, out msg);
                                    if (!result)
                                    {
                                        AppendToTable(strSerial, intCardType, false, MessageValidate.GetMessage(rm, "CanNotUpdateAppData"));
                                        cardChipManager.Alert(false);
                                    }
                                    else
                                    {
                                        byte[] keyHeader = StringUtils.HexStringToByteArray(keydata.ListSectorKeyPair(3).KeyB);
                                        headerData[0] = 0;
                                        //update header data
                                        result = UpDateHeaderData(strSerial, intCardType, keyHeader, headerData);
                                        if (result)
                                        {
                                            //call service to update on server
                                            UpdateCardDataToServer(strSerial, DateTime.Now.ToLongDateString(), intCardType);
                                        }
                                    }
                                }
                                else
                                {
                                    AppendToTable(strSerial, intCardType, false, MessageValidate.GetMessage(rm, "NotInfomation"));
                                    cardChipManager.Alert(false);
                                }

                            }
                        }
                        catch (Exception ex)
                        {
                            AppendToTable(strSerial, intCardType, false, ex.Message);
                            cardChipManager.Alert(false);
                        }
                    }

                }
            }
        }
        private void OnButtonPauseClicked(object sender, EventArgs e)
        {
            cardChipManager.Disconnect();

            ChangeStatusMessage(MessageValidate.GetMessage(rm, "ReaderNotConnected"));
            SwitchRunningState(false);
        }

        private void OnButtonListDevicesClicked(object sender, EventArgs e)
        {
            DoListDevices();
        }

        private void OnButtonCloseClicked(object sender, EventArgs e)
        {
            form.Close();
        }

        /// <summary>
        /// release reader when close form
        /// </summary>
        public void OnFormClosing()
        {
            cardChipManager.Disconnect();
        }

        #endregion
    }
}
