using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using CommonControls.Custom;
using Microsoft.Practices.CompositeUI;
using CryptoAlgorithm;
using CommonControls;
using System.ServiceModel;
using CommonHelper.Utils;
using sWorldModel;
using sWorldModel.Exceptions;
using sWorldModel.TransportData;
using JavaCommunication.Factory;
using CommonHelper.Constants;
using CardChipService;
using JavaCommunication;
using System.ComponentModel;
using CardChipMgtComponent.WorkItems;
using System.Globalization;
using CommonHelper.Config;
using System.Resources;
using ReaderManager;
using ReaderManager.Pcsc;
using ReaderManager.Model;
using System.Threading;

namespace CardChipMgtComponent.WorkItems
{
    public partial class FrmPersoProcess : CommonControls.Custom.CommonDialog
    {
        #region Properties

        private ResourceManager rm;
        private ICardChipManager cardChipManager;
        DataCardObject obj = new DataCardObject();
        private bool processing = false;
        string selectedReader = null;

        private MasterInfoDTO masterInfo;
        private MasterInfoDTO partnerInfo; // this is partner object.But we using function get master data by code. so we declare partner infor like master infor

        private DataTable dtResult, dtMembers;
        private List<Member> MemberList;
        private DataGridViewRow lastSelectedRow;
        private long partnerId, subOrgId, memberId;
        private int selectIndexMember = 0;
        private bool isMaster;

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

        public FrmPersoProcess(List<Member> memberList, bool IsMaster)
        {
            InitializeComponent();

            this.MemberList = memberList;
            this.isMaster = IsMaster;

            
            cardChipManager = new CardChipManager();
            btnClose.Click += btnClose_Clicked;
            btnListDevices.Click += btnListDevices_Clicked;
            btnPause.Click += btnPause_Clicked;
            btnStart.Click += btnStart_Clicked;

            dtResult = new DataTable();
            dtResult.Columns.Add(colCardType.DataPropertyName);
            dtResult.Columns.Add(colMemberFullName.DataPropertyName);
            dtResult.Columns.Add(colSerialNumber.DataPropertyName);
            dtResult.Columns.Add(colResult.DataPropertyName);
            dgvResult.DataSource = dtResult;

            dtMembers = new DataTable();
            dtMembers.Columns.Add(colMemberId1.DataPropertyName);
            dtMembers.Columns.Add(colOrgId.DataPropertyName);
            dtMembers.Columns.Add(colSubOrgId.DataPropertyName);
            dtMembers.Columns.Add(colMemberCode.DataPropertyName);
            dtMembers.Columns.Add(colFirstName.DataPropertyName);
            dtMembers.Columns.Add(colLastName1.DataPropertyName);
            dgvMembers.DataSource = dtMembers;
            dgvMembers.SelectionChanged += dgvTeachers_SelectionChanged;


            Shown += OnFormShown;
            FormClosing += Form_Closing;
        }

        private void OnFormShown(object sender, EventArgs e)
        {
            DoListDevices();
            LoadMemberList();

            rm = storageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
            SetLanguages();
            try
            {
                this.masterInfo = OrganizationFactory.Instance.GetChannel().GetMasterInfo(storageService.CurrentSessionId, SystemSettings.Instance.Master);
                this.partnerInfo = OrganizationFactory.Instance.GetChannel().GetMasterInfo(storageService.CurrentSessionId, SystemSettings.Instance.Partner);
            }
            catch (Exception ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ex.Message);
                this.Hide();
            }
        }

        #endregion

        #region Event's Support
        private void SetLanguages()
        {
            this.colCardType.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colCardType.Name);
            this.colMemberFullName.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colMemberFullName.Name);
            this.colSerialNumber.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colSerialNumber.Name);
            this.colResult.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colResult.Name);

            this.colMemberCode.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colMemberCode.Name);
            this.colFirstName.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colFirstName.Name);
            this.colLastName1.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colLastName1.Name);
            this.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.Name);

        }
        

        private void LoadMemberList()
        {
            // Populate teacher list to view
            if (MemberList.Count == 0)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "PersoIsMember"));
                SwitchRunningState(true);
            }
            foreach (Member member in MemberList)
            {
                DataRow row = dtMembers.NewRow();
                row[colMemberId1.DataPropertyName] = member.Id;
                row[colOrgId.DataPropertyName] = member.OrgId;
                row[colSubOrgId.DataPropertyName] = member.SubOrgId;
                row[colMemberCode.DataPropertyName] = member.Code;
                row[colLastName1.DataPropertyName] = member.LastName;
                row[colFirstName.DataPropertyName] = member.FirstName;
                dtMembers.Rows.Add(row);
            }
            dtMembers.DefaultView.ApplyDefaultSort = true;
            if (dtMembers.Rows.Count > 0)
            {
                dgvMembers.Rows[0].Selected = true;
                lastSelectedRow = dgvMembers.Rows[0];
            }
        }

        
        #endregion


        private void dgvTeachers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMembers.SelectedRows.Count == 0)
            {
                if (dgvMembers.Rows.Count > 0 && lastSelectedRow != null)
                {
                    lastSelectedRow.Selected = true;
                }
            }
            else
            {
                // MultiSelect is false
                lastSelectedRow = dgvMembers.SelectedRows[0];
            }
        }

        private void btnStart_Clicked(object sender, EventArgs e)
        {
            if (cmbReaders.SelectedIndex == -1)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessSelect(rm, MessageValidate.Reader), MessageValidate.GetErrorTitle(rm));
                return;
            }
            selectedReader = cmbReaders.SelectedItem.ToString();

            
            if ( cardChipManager.WaitingCard(selectedReader))
            {
                SwitchRunningState(true);
                ChangeStatusMessage(MessageValidate.GetMessage(rm,"WaitingTag"));
                cardChipManager.ActionDataHandler += ActionData;
            }
            else
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessSelect(rm, MessageValidate.Reader), MessageValidate.GetErrorTitle(rm));

            }
        }

        /// <summary>
        /// Hàm ReadDataFromCard được thực hiện bằng việc nhận đối tương từ pcsc gửi qua thông qua object DataCardObject
        /// các đối tượng được phân biệt qua thuộc tính eventType
        /// </summary>
        /// <param name="obj"></param>
        private void ActionData(DataCardObject obj)
        {
            switch (obj.eventType)
            {
                case DataCardObject.TAG_DETECTED:
                    OnTagDetected(obj.cardType, obj.serialNumber);
                    break;
                case DataCardObject.TAG_REMOVED:
                    OnTagRemoved();
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

        private void OnTagRemoved()
        {
           
        }

        private void btnPause_Clicked(object sender, EventArgs e)
        {
            cardChipManager.Disconnect();
            SwitchRunningState(false);
            ChangeStatusMessage(MessageValidate.GetMessage(rm, "ReaderNotConnected"));
        }

        private void btnListDevices_Clicked(object sender, EventArgs e)
        {
            DoListDevices();
        }

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

        private void btnClose_Clicked(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Đóng form, kiểm tra nếu có đầu đọc thì ngắt kết nối
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            if (MessageBoxManager.ShowQuestionMessageBox(this, MessageValidate.GetMessStop(rm, MessageValidate.Allocation), MessageValidate.GetErrorTitle(rm)) != DialogResult.Yes)
            {
                e.Cancel = true;
            }
            else
            {
                // kiểm tra nếu có đầu đọc thì ngắt kết nối
                cardChipManager.Disconnect();
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
            dgvAppData.Enabled = cmbReaders.Enabled = btnStart.Enabled = btnListDevices.Enabled = !running;
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
                lblStatus.Text = MessageValidate.GetMessage(rm, "WaitingTag");// "Đang chờ thẻ...";
                processing = false;
            }
            else
            {
                processing = true;
                //lblStatus.BackColor = Color.FromArgb(3, 111, 192);
                lblStatus.BackColor = SystemColors.Highlight;
                //lblStatus.ForeColor = Color.WhiteSmoke;
                lblStatus.ForeColor = SystemColors.HighlightText;
                lblStatus.Text = MessageValidate.GetMessage(rm, "FoundCard"); //"Phát hiện thẻ, đang xử lý...";
            }
        }

        private void JumpToNextMemberRecord()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(JumpToNextMemberRecord));
                return;
            }
            if (dgvMembers.Rows.Count == 0)
            {
                return;
            }
            if (dgvMembers.SelectedRows.Count == 0)
            {
                return;
            }

            if (dgvMembers.Rows.Count <= selectIndexMember)
                return;
            if (dgvMembers.Rows[selectIndexMember].Selected)
            {
                dgvMembers.Rows[selectIndexMember].Visible = true;
            }
            //int currentIndex = dgvMembers.SelectedRows[0].Index;     // MultiSelect is disable
            if (dgvMembers.Rows.Count >= selectIndexMember + 1)
            {
                dgvMembers.Rows[selectIndexMember].Selected = true;
                memberId = Convert.ToInt64(dgvMembers.Rows[selectIndexMember].Cells[colMemberId1.Index].Value.ToString());
                //get partner information
                
                partnerId = Convert.ToInt64(dgvMembers.Rows[selectIndexMember].Cells[colOrgId.Index].Value.ToString());
                subOrgId = Convert.ToInt64(dgvMembers.Rows[selectIndexMember].Cells[colSubOrgId.Index].Value.ToString());
            }
        }

        private void AppendToTable(byte[] serialNumber, int cardType, bool result, string reason)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<byte[], int, bool, string>(AppendToTable), serialNumber, cardType, result, reason);
                return;
            }

            DataRow row = dtResult.NewRow();
            row[colCardType.DataPropertyName] = ((CardChipType)cardType).GetName();
            if (selectIndexMember < dgvMembers.Rows.Count)
                row[colMemberFullName.DataPropertyName] = dgvMembers.Rows[selectIndexMember].Cells[colFirstName.Index].Value.ToString() + " " +
                    dgvMembers.Rows[selectIndexMember].Cells[colLastName1.Index].Value.ToString();
            row[colSerialNumber.DataPropertyName] = StringUtils.ByteArrayToHexString(serialNumber);
            row[colResult.DataPropertyName] = result ? MessageValidate.GetMessage(rm, "SucessfulMessage") : MessageValidate.GetMessage(rm, "FaileMessage")+" (" + reason + ")";
            dtResult.Rows.Add(row);

            int lastRowPos = dgvResult.RowCount - 1;
            dgvResult.FirstDisplayedScrollingRowIndex = lastRowPos;
            foreach (DataGridViewRow r in dgvResult.SelectedRows)
            {
                r.Selected = false;
            }
            dgvResult.Rows[lastRowPos].Selected = true;
            dgvResult.Rows[lastRowPos].DefaultCellStyle.BackColor = result ? Color.White : Color.Red;
        }

        private void cbxExpiration_CheckedChanged(object sender, EventArgs e)
        {
            dtpExpiration.Enabled = cbxExpiration.Checked;

        }


        #region Reader library events

        private void OnReaderUnplugged()
        {
            ChangeStatusMessage(MessageValidate.GetMessage(rm, "LostConnectionReader"));
            SwitchRunningState(false);
        }

        private void OnReaderPlugged()
        {
            ChangeStatusMessage(MessageValidate.GetMessage(rm, "WaitingTag"));
        }

        private void OnReaderNotPresent()
        {
            ChangeStatusMessage(MessageValidate.GetMessage(rm, "ErrorConnect"));
            SwitchRunningState(false);
        }

        private void OnTagDetected(int cardType, byte[] serialNumber)
        {
            if (!processing)
            {
                SwitchProcessingState();
                JumpToNextMemberRecord();

                #region Properties

                ResultCheckCardDTO resultCheckCard = null;
                DataToWriteCardDTO personData = null;
                Thread.Sleep(500);
                //  msg when writed key failed
                string MSG = String.Empty;

                cardChipManager.SetCardInfor(cardType, serialNumber);
                String strSerial = StringUtils.ByteArrayToHexString(serialNumber);
                byte sectorDataNotPartner = 4;//khi master va partner trung nhau
                byte sectorDataPartner = 7;//khi master va partner khac nhau
                int result = -1;

                #endregion

                #region Step 1 Verified License Master

                bool hasMaster = cardChipManager.RsaVerifiedLicenseMaster(CardConfigration.START_SECTOR_MASTER, CardConfigration.STOP_SECTOR_MASTER, out MSG);
               
                if (!hasMaster)
                {
                    AppendToTable(serialNumber, cardType, false, MessageValidate.GetMessage(rm, "Cardnotissuer"));
                    cardChipManager.Alert(false);
                    SwitchProcessingState();
                    return;
                }

                #endregion

                #region Step 2: Write PartnerKey if has partner

                if (!isMaster)
                {
                    #region Step 2.1.1: Call service to check data in card and get data for write partner key
                    try
                    {
                        // get data for write master key
                        // partnerInfo.MasterId is partnerInfo.Id in this case
                        resultCheckCard = CardChipFactory.Instance.GetChannel().CheckAndGetPartnerDataToImportCard(storageService.CurrentSessionId,
                             partnerInfo.MasterId, strSerial, cardType, CardConfigration.START_SECTOR_PARTNER, CardConfigration.STOP_SECTOR_PARTNER);


                        if (null == resultCheckCard)
                        {
                            AppendToTable(serialNumber, cardType, false, MessageValidate.GetMessage(rm,"TimeOutExceptionMessage"));
                            cardChipManager.Alert(false);
                            SwitchProcessingState();
                            return;
                        }

                    }
                    catch (Exception ex)
                    {
                        AppendToTable(serialNumber, cardType, false,ex.Message);
                        SwitchProcessingState();
                        return;
                    }
                    
                    #endregion

                    #region Step 2.1.2 Check data from server swt (partner license server)

                    bool isserver = cardChipManager.RsaVerifiedPartnerLicenseServerHexValue(resultCheckCard.LicenseServer);
                    if (!isserver)
                    {
                        AppendToTable(serialNumber, cardType, false, MessageValidate.GetMessage(rm, "WrongData"));
                        cardChipManager.Alert(false);
                        SwitchProcessingState();
                        return;
                    }

                    #endregion

                    #region Step 2.1.3: Validation data in in card if card information has in server

                    if (resultCheckCard.Status != (int)CARD_STATUS.CARD_HAS_MASTER_PARTNER_READED)
                    {
                        AppendToTable(serialNumber, cardType, false, MessageValidate.GetMessage(rm,"CardReadyInfor"));
                        cardChipManager.Alert(false);
                        SwitchProcessingState();
                        return;
                    }
                    #endregion

                    #region Step 2.1.4 Write partner in card

                    bool isOke = cardChipManager.WriteLicenseData(CardConfigration.START_SECTOR_PARTNER, CardConfigration.STOP_SECTOR_PARTNER, resultCheckCard, out MSG);

                    if (!isOke)
                    {
                        AppendToTable(serialNumber, cardType, false, MSG);
                        cardChipManager.Alert(false);
                        SwitchProcessingState();
                        return;
                    }

                    #endregion

                    #region Step 2.1.5 Update license partner to server

                    result = CardChipFactory.Instance.GetChannel().UpdateDataForCardBySerialAndPartnerId(storageService.CurrentSessionId,
                         this.partnerId, strSerial, cardType, (int)CARD_STATUS.CARD_HAS_MASTER_PARTNER_WRITE);

                    if (result != (int)Status.SUCCESS)
                    {
                        AppendToTable(serialNumber, cardType, false, MessageValidate.GetMessage(rm, "CanNotWriteCardToSystem"));
                        cardChipManager.Alert(false);
                        SwitchProcessingState();
                        return;
                    }

                    #endregion
                }
                #endregion

                #endregion

                #region Step 3: Write persion data to card

                #region Step 3.1: Check and get key pair data
                try
                {
                    // them vao list of id app ma da chon o tren giao dien
                    personData = ChipPersonalizationFactory.Instance.GetChannel().CheckAndGetPersonData(storageService.CurrentSessionId,
                        memberId, strSerial, cardType, isMaster ? sectorDataNotPartner : sectorDataPartner, SystemSettings.Instance.Partner);
                }
                catch (Exception ex)
                {
                    AppendToTable(serialNumber, cardType, false, ex.Message);
                    cardChipManager.Alert(false);
                    SwitchProcessingState();
                    return;
                }

                if (personData == null)
                {
                    AppendToTable(serialNumber, cardType, false, MessageValidate.GetMessage(rm, "CanNotGetDataFromServer"));//khong the ghi thong tin len the
                    cardChipManager.Alert(false);
                    SwitchProcessingState();
                    return;
                }

                #endregion

                #region Step 3.2 Check data for writing in card from server swt

                if (!cardChipManager.RsaVerifiedPartnerLicenseServerHexValue(personData.LicenseServer))
                {
                    AppendToTable(serialNumber, cardType, false, MessageValidate.GetMessage(rm, "WrongData"));
                    cardChipManager.Alert(false);
                    SwitchProcessingState();
                    return;
                }

                #endregion

                #region Step 3.3: Write Data to card

                if (!cardChipManager.WritePersoData(personData, out MSG))
                {
                    AppendToTable(serialNumber, cardType, false, MSG);
                    cardChipManager.Alert(false);
                    SwitchProcessingState();
                    return;
                }

                #endregion


                #endregion

                #region Step 4: Write Header Data


                if (!cardChipManager.WriteHeaderData(isMaster, personData.KEY, out MSG))
                {
                    AppendToTable(serialNumber, cardType, false, MessageValidate.GetMessage(rm, "FailedMessage"));
                    cardChipManager.Alert(false);
                    SwitchProcessingState();
                    return;
                }

                #endregion

                #region Step 5: Update data for server
                // get data for write master key && update perso card


                // nho them list app vao de biet the do da nghi nhung app nao
                string serialExp = strSerial;
                
                if (cbxExpiration.Checked)
                {
                    serialExp += "@" + dtpExpiration.Text.Replace("/", "-");
                }
                result = ChipPersonalizationFactory.Instance.GetChannel().PersoCardChip(storageService.CurrentSessionId, memberId, serialExp);
                if (result != (int)Status.SUCCESS)
                {
                    AppendToTable(serialNumber, cardType, false, MessageValidate.GetMessage(rm, "CanNotWriteCardToSystem"));
                    cardChipManager.Alert(false);
                    SwitchProcessingState();
                    return;
                }
                #endregion

                // success
                AppendToTable(serialNumber, cardType, true, String.Empty);
                cardChipManager.Alert(true);
                JumpToNextMemberRecord(); // go to next record
                selectIndexMember = dgvResult.RowCount == selectIndexMember++ ? selectIndexMember : selectIndexMember++;
                SwitchProcessingState();
            }
        }
        
    }
}
