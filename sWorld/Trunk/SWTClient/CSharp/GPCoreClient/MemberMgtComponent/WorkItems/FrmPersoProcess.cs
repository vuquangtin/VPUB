using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using CommonControls.Custom;
using ReaderLibrary;
using Microsoft.Practices.CompositeUI;
using CryptoAlgorithm;
using CommonControls;
using System.ServiceModel;
using CommonHelper.Utils;
using System.Text;
using sWorldModel;
using sWorldModel.Model;
using sWorldModel.Parser;
using sWorldModel.Exceptions;
using sWorldModel.MethodData;
using sWorldModel.TransportData;
using JavaCommunication.Factory;
using CommonHelper.Constants;
using CardChipService;
using JavaCommunication;
using System.ComponentModel;

namespace MemberMgtComponent.WorkItems
{
    public partial class FrmPersoProcess : CommonControls.Custom.CommonDialog
    {
        #region Properties

        private BackgroundWorker loadAppDataWorker;

        private DataGridViewCheckBoxColumn colCheckbox;
        private DataGridViewTextBoxColumn colAppId;
        private DataGridViewTextBoxColumn colAppCode;
        private DataGridViewTextBoxColumn colAppName;
        private DataGridViewTextBoxColumn colDescription;

        private List<long> AppList;

        private PcscReader readerLib;
        private bool processing = false;

        private DataTable dtResult, dtMembers, dtAppData;
        private List<Member> MemberList;
        private DataGridViewRow lastSelectedRow;
        private long partnerId, subOrgId, memberId;
        private int selectIndexMember = 0;
        private bool isMaster;
        ICardChipManager cardChipManager;

        private AesEncryption aes;
        private string svk;

        private MemberWorkItem workItem;
        [ServiceDependency]
        public MemberWorkItem WorkItem
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
            IntializeAppDataGridView();

            this.MemberList = memberList;
            this.isMaster = IsMaster;

            readerLib = new PcscReader();
            readerLib.TagDetected += OnTagDetected;
            readerLib.ReaderNotPresent += OnReaderNotPresent;
            readerLib.ReaderUnplugged += OnReaderUnplugged;
            readerLib.ReaderPlugged += OnReaderPlugged;

            btnClose.Click += btnClose_Clicked;
            btnListDevices.Click += btnListDevices_Clicked;
            btnPause.Click += btnPause_Clicked;
            btnStart.Click += btnStart_Clicked;

            loadAppDataWorker = new BackgroundWorker();
            loadAppDataWorker.WorkerSupportsCancellation = true;
            loadAppDataWorker.DoWork += OnLoadAppDataWorkerDoWork;
            loadAppDataWorker.RunWorkerCompleted += OnLoadAppDataWorkerCompleted;

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
            dtMembers.Columns.Add(colMemberCode1.DataPropertyName);
            dtMembers.Columns.Add(colFirstName1.DataPropertyName);
            dtMembers.Columns.Add(colLastName1.DataPropertyName);
            dgvMembers.DataSource = dtMembers;
            dgvMembers.SelectionChanged += dgvTeachers_SelectionChanged;

            //dgvResult.RowPostPaint += dgvResult_RowPostPaint;
            //dgvResult.Scroll += dgvResult_Scroll;

            Shown += OnFormShown;
            FormClosing += Form_Closing;
        }

        private void OnFormShown(object sender, EventArgs e)
        {
            DoListDevices();
            LoadMemberList();
            LoadAppDataList();
        }

        #endregion

        #region Event's Support

        private void IntializeAppDataGridView()
        {
            colCheckbox = new DataGridViewCheckBoxColumn();
            DatagridViewCheckBoxHeaderCell checkBoxHeader = new DatagridViewCheckBoxHeaderCell();
            checkBoxHeader.OnCheckBoxClicked += new CheckBoxClickedHandler(checkBoxHeader_OnCheckBoxClicked);
            colCheckbox.HeaderCell = checkBoxHeader;
            colCheckbox.HeaderText = string.Empty;
            colCheckbox.Width = 22;
            colCheckbox.DataPropertyName = "colCheckbox";
            dgvAppData.Columns.Add(colCheckbox);

            colAppId = new DataGridViewTextBoxColumn();
            colAppId.HeaderText = "AppId";
            colAppId.Visible = false;
            colAppId.DataPropertyName = "AppId";
            colAppId.Name = "colAppId";
            colAppId.ReadOnly = true;
            dgvAppData.Columns.Add(colAppId);

            colAppCode = new DataGridViewTextBoxColumn();
            colAppCode.HeaderText = "Mã Số";
            colAppCode.Width = 80;
            colAppCode.DataPropertyName = "AppCode";
            colAppCode.Name = "colAppCode";
            colAppCode.ReadOnly = true;
            dgvAppData.Columns.Add(colAppCode);

            colAppName = new DataGridViewTextBoxColumn();
            colAppName.HeaderText = "Tên Ứng Dụng";
            colAppName.Width = 160;
            colAppName.DataPropertyName = "AppName";
            colAppName.Name = "colAppName";
            colAppName.ReadOnly = true;
            dgvAppData.Columns.Add(colAppName);

            colDescription = new DataGridViewTextBoxColumn();
            colDescription.HeaderText = "Mô Tả";
            colDescription.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colDescription.DataPropertyName = "Description";
            colDescription.Name = "colDescription";
            colDescription.ReadOnly = true;
            dgvAppData.Columns.Add(colDescription);

            dtAppData = new DataTable();
            dtAppData.Columns.Add(colCheckbox.DataPropertyName);
            dtAppData.Columns.Add(colAppId.DataPropertyName);
            dtAppData.Columns.Add(colAppCode.DataPropertyName);
            dtAppData.Columns.Add(colAppName.DataPropertyName);
            dtAppData.Columns.Add(colDescription.DataPropertyName);
            dgvAppData.DataSource = dtAppData;

            dgvAppData.CellMouseClick += dgvAppData_OnCellMouseUp;
            dgvAppData.SelectionChanged += dgvAppData_SelectionChanged;

            //dgvAppData.RowPostPaint += dgvAppData_RowPostPaint;
            //dgvAppData.Scroll += dgvAppData_Scroll;

            dgvAppData.BorderStyle = BorderStyle.FixedSingle;

            AppList = new List<long>();
        }

        private void LoadMemberList()
        {
            // Populate teacher list to view
            foreach (Member member in MemberList)
            {
                DataRow row = dtMembers.NewRow();
                row[colMemberId1.DataPropertyName] = member.Id;
                row[colOrgId.DataPropertyName] = member.OrgId;
                row[colSubOrgId.DataPropertyName] = member.SubOrgId;
                row[colMemberCode1.DataPropertyName] = member.Code;
                row[colLastName1.DataPropertyName] = member.LastName;
                row[colFirstName1.DataPropertyName] = member.FirstName;
                dtMembers.Rows.Add(row);
            }
            dtMembers.DefaultView.ApplyDefaultSort = true;
            if (dtMembers.Rows.Count > 0)
            {
                dgvMembers.Rows[0].Selected = true;
                lastSelectedRow = dgvMembers.Rows[0];
            }
        }

        private void LoadAppDataList()
        {
            // Call background worker if it's not busy
            if (!loadAppDataWorker.IsBusy)
            {
                dtAppData.Rows.Clear();

                //pagerPanel.ShowMessage("Đang tải dữ liệu, xin hãy chờ...");
                loadAppDataWorker.RunWorkerAsync();
            }
        }

        private void OnLoadAppDataWorkerDoWork(object s, DoWorkEventArgs e)
        {
            List<App> result = null;
            try
            {
                result = ApplicationFactory.Instance.GetChannel().GetAppDataList(storageService.CurrentSessionId, 1, 1);
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

        private void OnLoadAppDataWorkerCompleted(object s, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }

            if (e.Result == null || !(e.Result is List<App>))
            {
                return;
            }

            List<App> result = e.Result as List<App>;
            foreach (App app in result)
            {
                DataRow row = dtAppData.NewRow();
                row.BeginEdit();

                row[colCheckbox.DataPropertyName] = false;
                row[colAppId.DataPropertyName] = app.Id;
                row[colAppCode.DataPropertyName] = app.AppCode;
                row[colAppName.DataPropertyName] = app.AppName;
                row[colDescription.DataPropertyName] = app.Description;

                row.EndEdit();
                dtAppData.Rows.Add(row);
            }
        }

        #endregion

        #region Form events

        #region App data List
        private void checkBoxHeader_OnCheckBoxClicked(bool status)
        {
            AppList.Clear();
            for (int i = 0; i < dgvAppData.Rows.Count; i++)
            {
                dgvAppData.Rows[i].Selected = status;
                dgvAppData.Rows[i].Cells[0].Value = status;
                if (status)
                {
                    AppList.Add(Convert.ToInt32(dgvAppData.Rows[i].Cells[colAppId.Index].Value.ToString()));
                    dgvAppData.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                    dgvAppData.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                }
                else
                {
                    dgvAppData.Rows[i].DefaultCellStyle.BackColor = Color.White;
                    dgvAppData.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                }

            }
        }

        private void SetSelectedRowAppData(DataGridViewRow row, bool rowChecked)
        {
            if (rowChecked)
            {
                row.Cells[0].Value = true;
                AppList.Add(Convert.ToInt32(row.Cells[colAppId.Index].Value.ToString()));
            }
            else
            {
                row.Cells[0].Value = false;
                AppList.Remove(Convert.ToInt32(row.Cells[colAppId.Index].Value.ToString()));
            }
        }

        private void SetAppDataList()
        {
            AppList = new List<long>();
            foreach (DataGridViewRow row in dgvAppData.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value))
                {
                    row.Selected = true;
                    row.DefaultCellStyle.BackColor = Color.Green;
                    row.DefaultCellStyle.ForeColor = Color.White;
                    AppList.Add(Convert.ToInt32(row.Cells[colAppId.Index].Value.ToString()));
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                    row.Selected = false;
                }
            }

            ////Set Check All or UnCheckAll
            //if (AppList.Count == dgvAppData.Rows.Count)
            //    dgvAppData.Rows[-1].Cells[0].Value = true;
            //else
            //    dgvAppData.Rows[-1].Cells[0].Value = false;
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

        private void dgvAppData_OnCellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex > -1)
            {
                DataGridViewRow rowIndex = dgvAppData.Rows[e.RowIndex];
                bool value = Convert.ToBoolean(dgvAppData.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                SetSelectedRowAppData(rowIndex, !value);
                SetAppDataList();

                dgvAppData.EndEdit();
            }
        }

        //private void dgvAppData_Scroll(object sender, ScrollEventArgs e)
        //{
        //    if (dgvAppData.SelectedRows.Count > 0)
        //    {
        //        dgvAppData.InvalidateRow(dgvAppData.SelectedRows[0].Index);
        //    }
        //}

        //private void dgvAppData_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        //{
        //    var dgv = (DataGridView)sender;
        //    // run this piece of code only for the selected row
        //    if (dgv.Rows[e.RowIndex].Selected)
        //    {
        //        int width = dgvAppData.Width;
        //        Rectangle r = dgv.GetRowDisplayRectangle(e.RowIndex, false);
        //        var rect = new Rectangle(r.X, r.Y, width - 1, r.Height - 1);

        //        // draw the border around the selected row using the highlight color and using a border width of 2
        //        ControlPaint.DrawBorder(e.Graphics, rect,
        //            SystemColors.Highlight, 2, ButtonBorderStyle.Solid,
        //            SystemColors.Highlight, 2, ButtonBorderStyle.Solid,
        //            SystemColors.Highlight, 2, ButtonBorderStyle.Solid,
        //            SystemColors.Highlight, 2, ButtonBorderStyle.Solid);
        //    }
        //}

        // Prevent datagridview clear it's selected rows
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
                MessageBoxManager.ShowErrorMessageBox(this, "Bạn chưa chọn thiết bị đọc!", "Thao Tác Sai");
                return;
            }

            SwitchRunningState(true);
            ChangeStatusMessage("Đang kết nối với thiết bị đọc...");

            string selectedReader = cmbReaders.SelectedItem.ToString();
            readerLib.ConnectToReader(selectedReader);
        }

        private void btnPause_Clicked(object sender, EventArgs e)
        {
            readerLib.DisconnectFromReader();

            SwitchRunningState(false);
            ChangeStatusMessage("Chưa kết nối với thiết bị đọc");
        }

        private void btnListDevices_Clicked(object sender, EventArgs e)
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

        private void btnClose_Clicked(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            if (MessageBoxManager.ShowQuestionMessageBox(this, "Bạn có chắc muốn ngừng quá trình cấp thẻ và đóng hộp thoại này không?") != DialogResult.Yes)
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

            if (dgvMembers.Rows[selectIndexMember].Selected)
            {
                dgvMembers.Rows[selectIndexMember].Visible = true;
            }
            //int currentIndex = dgvMembers.SelectedRows[0].Index;     // MultiSelect is disable
            if (dgvMembers.Rows.Count >= selectIndexMember + 1)
            {
                dgvMembers.Rows[selectIndexMember].Selected = true;
                memberId = Convert.ToInt64(dgvMembers.Rows[selectIndexMember].Cells[colMemberId1.Index].Value.ToString());
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
            row[colMemberFullName.DataPropertyName] = dgvMembers.Rows[selectIndexMember].Cells[colFirstName1.Index].Value.ToString() + " " +
                dgvMembers.Rows[selectIndexMember].Cells[colLastName1.Index].Value.ToString();
            row[colSerialNumber.DataPropertyName] = StringUtils.ByteArrayToHexString(serialNumber);
            row[colResult.DataPropertyName] = result ? "Thành công" : "Thất bại (" + reason + ")";
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
                JumpToNextMemberRecord();

                #region Properties

                ResultCheckCardDTO resultCheckCard = null;
                DataToWriteCardDTO appData = null;

                //  msg when writed key failed
                string MSG = String.Empty;
                //verified server data
                ICardChipManager cardChipManager = new CardChipManager(readerLib, serialNumber);
                // convert to hex string
                String serialNumberHex = StringUtils.ByteArrayToHexString(serialNumber);
                string strSerial = StringUtils.ByteArrayToHexString(serialNumber);
                byte sectorDataNotPartner = 4;//khi master va partner trung nhau
                byte sectorDataPartner = 7;//khi master va partner khac nhau
                int result = -1;

                #endregion

                #region Step 1 Verified License Master

                if (!cardChipManager.RsaVerifiedLicenseMaster(CardConfigration.START_SECTOR_MASTER, CardConfigration.STOP_SECTOR_MASTER, out MSG))
                {
                    AppendToTable(serialNumber, cardType, false, MSG);
                    readerLib.Beep(false);
                    SwitchProcessingState();
                    return;
                }

                #endregion

                #region Step 2: Write PartnerKey if has partner

                #region Step 2.1: if master and partner are diffirent

                if (!isMaster)
                {
                    #region Step 2.1.1: Call service to check data in card and get data for write partner key
                    try
                    {
                        // get data for write master key
                        resultCheckCard = CardChipFactory.Instance.GetChannel().CheckAndGetPartnerDataToImportCard(storageService.CurrentSessionId,
                             partnerId, serialNumberHex, cardType, CardConfigration.START_SECTOR_PARTNER, CardConfigration.STOP_SECTOR_PARTNER);


                        if (null == resultCheckCard)
                        {
                            AppendToTable(serialNumber, cardType, false, CommonMessages.TimeOutExceptionMessage);
                            readerLib.Beep(false);
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

                    #region Step 2.1.2 Check data from server swt

                    bool isserver = cardChipManager.RsaVerifiedLicenServerHexValue(resultCheckCard.LicenseServer);
                    if (!isserver)
                    {
                        AppendToTable(serialNumber, cardType, false, CommonMessages.WrongData);
                        readerLib.Beep(false);
                        SwitchProcessingState();
                        return;
                    }

                    #endregion

                    #region Step 2.1.3: Validation data in in card if card information has in server

                    if (resultCheckCard.Status != (int)CARD_STATUS.CARD_HAS_MASTER_PARTNER_READED)
                    {
                        AppendToTable(serialNumber, cardType, false, CommonMessages.CardReadyInfor);
                        readerLib.Beep(false);
                        MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.CardReadyInfor);
                        SwitchProcessingState();
                        return;
                    }
                    #endregion

                    #region Step 2.1.4 Write partner in card

                    bool isOke = cardChipManager.WriteLicenseData(CardConfigration.START_SECTOR_PARTNER, CardConfigration.STOP_SECTOR_PARTNER, resultCheckCard, out MSG);

                    if (!isOke)
                    {
                        AppendToTable(serialNumber, cardType, false, MSG);
                        readerLib.Beep(false);
                        SwitchProcessingState();
                        return;
                    }

                    #endregion

                    #region Step 2.1.5 Update license partner to server

                    result = CardChipFactory.Instance.GetChannel().UpdateDataForCardBySerialAndPartnerId(storageService.CurrentSessionId,
                         this.partnerId, serialNumberHex, cardType, (int)CARD_STATUS.CARD_HAS_MASTER_PARTNER_WRITE);

                    if (result != (int)Status.SUCCESS)
                    {
                        AppendToTable(serialNumber, cardType, false, CommonMessages.CanNotWriteCardToSystem);
                        readerLib.Beep(false);
                        SwitchProcessingState();
                        return;
                    }

                    #endregion
                }
                #endregion

                #endregion

                #region Step 3: Write Data to card

                #region Step 3.1: Check and get key pair data
                try
                {
                    // them vao list of id app ma da chon o tren giao dien
                    appData = ChipPersonalizationFactory.Instance.GetChannel().CheckAndGetAppDataToPersoCard(storageService.CurrentSessionId,
                        memberId, strSerial, cardType, isMaster ? sectorDataNotPartner : sectorDataPartner, AppList);
                }
                catch (TimeoutException)
                {
                    AppendToTable(serialNumber, cardType, false, CommonMessages.TimeOutExceptionMessage);
                    readerLib.Beep(false);
                    SwitchProcessingState();
                    return;
                }
                catch (FaultException<WcfServiceFault> ex)
                {
                    AppendToTable(serialNumber, cardType, false, ErrorCodes.GetErrorMessage(ex.Detail.Code));
                    readerLib.Beep(false);
                    SwitchProcessingState();
                    return;
                }
                catch (FaultException ex)
                {
                    AppendToTable(serialNumber, cardType, false, ex.Message);
                    readerLib.Beep(false);
                    SwitchProcessingState();
                    return;
                }
                catch (CommunicationException)
                {
                    AppendToTable(serialNumber, cardType, false, CommonMessages.CommunicationExceptionMessage);
                    readerLib.Beep(false);
                    SwitchProcessingState();
                    return;
                }

                if (appData == null)
                {
                    AppendToTable(serialNumber, cardType, false, "Hệ thống không chứa thông tin của các ứng dụng trên thẻ");
                    readerLib.Beep(false);
                    SwitchProcessingState();
                    return;
                }

                #endregion

                #region Step 3.2 Check data for writing in card from server swt

                if (!cardChipManager.RsaVerifiedLicenServerHexValue(appData.LicenseServer))
                {
                    AppendToTable(serialNumber, cardType, false, CommonMessages.WrongData);
                    readerLib.Beep(false);
                    SwitchProcessingState();
                    return;
                }

                #endregion

                #region Step 3.3: Write Data to card

                if (!cardChipManager.WriteAppData(appData, out MSG))
                {
                    AppendToTable(serialNumber, cardType, false, MSG);
                    readerLib.Beep(false);
                    SwitchProcessingState();
                    return;
                }

                #endregion


                #endregion

                #region Step 4: Write Header Data

                if (!cardChipManager.WriteHeaderData(isMaster, appData.KEY, out MSG))
                {
                    AppendToTable(serialNumber, cardType, false, MSG);
                    readerLib.Beep(false);
                    SwitchProcessingState();
                    return;
                }

                #endregion

                #region Step 5: Update data for server
                // get data for write master key && update perso card
               

                // nho them list app vao de biet the do da nghi nhung app nao
                result = ChipPersonalizationFactory.Instance.GetChannel().PersoCardChip(storageService.CurrentSessionId, memberId, serialNumberHex, AppList);
                if (result != (int)Status.SUCCESS)
                {
                    AppendToTable(serialNumber, cardType, false, CommonMessages.CanNotWriteCardToSystem);
                    readerLib.Beep(false);
                    SwitchProcessingState();
                    return;
                }

                #endregion

                // success
                AppendToTable(serialNumber, cardType, true, String.Empty);
                readerLib.Beep(true);
                JumpToNextMemberRecord();
                selectIndexMember++;
                SwitchProcessingState();


                #region Step 1: Check if card is supplied by SWT

                //// Check if card is supplied by SWT
                //byte[] cipher = aes.Encrypt(svk);
                //byte[] firstSectorKeyA = new byte[6];
                //Array.Copy(cipher, 0, firstSectorKeyA, 0, firstSectorKeyA.Length);
                //if (!readerLib.IsSwtCard(firstSectorKeyA))
                //{
                //    AppendToResultTable(teacherCode, teacherName, serialNumberHex, false, "Không phải thẻ do SWT cung cấp");
                //    SwitchProcessingState();
                //    return;
                //}

                #endregion

                #region Step 2: Prepare data for perso

                //// Check form status
                //if (dgvTeachers.Rows.Count == 0)
                //{
                //    SwitchProcessingState();
                //    return;
                //}
                //else if (dgvTeachers.SelectedRows.Count == 0)
                //{thành viên
                //    MessageBoxManager.ShowErrorMessageBox(this, "Bạn chưa chọn  cần cấp thẻ!", "Thao Tác Sai");
                //    return;
                //}

                //long teacherId = Convert.ToInt64(dgvTeachers.SelectedRows[0].Cells[colMemberId1.Index].Value.ToString());
                //string teacherName = dgvTeachers.SelectedRows[0].Cells[colLastName1.Index].Value.ToString() + " " + dgvTeachers.SelectedRows[0].Cells[colFirstName1.Index].Value.ToString();
                //string teacherCode = dgvTeachers.SelectedRows[0].Cells[colMemberCode1.Index].Value.ToString();
                //string serialNumberHex = StringUtils.ByteArrayToHexString(serialNumber);

                #endregion

                #region Step 3: Call service to get data

                //// Login to header using default key A
                //if (!readerLib.AuthenticateDefault(1))
                //{
                //    AppendToResultTable(teacherCode, teacherName, serialNumberHex, false, "Không đăng nhập được vào header");
                //    SwitchProcessingState();
                //    return;
                //}

                //// Get data on header
                //byte[] headerData;
                //if (!readerLib.ReadHeader(out headerData))
                //{
                //    AppendToResultTable(teacherCode, teacherName, serialNumberHex, false, "Không đọc được dữ liệu header");
                //    SwitchProcessingState();
                //    return;
                //}

                //DataForPersoCard data;

                //// Call service to get data for perso
                //try
                //{
                //    data = ChipPersonalizationFactory.Instance.GetChannel().CheckAndGetDataToPersoCard(storageService.CurrentSessionId, teacherId, serialNumber, headerData[0], headerData[1]);
                //}
                //catch (TimeoutException)
                //{
                //    AppendToResultTable(teacherCode, teacherName, serialNumberHex, false, CommonMessages.TimeOutExceptionMessage);
                //    MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.TimeOutExceptionMessage);
                //    SwitchProcessingState();
                //    return;
                //}
                //catch (FaultException<WcfServiceFault> ex)
                //{
                //    AppendToResultTable(teacherCode, teacherName, serialNumberHex, false, ErrorCodes.GetErrorMessage(ex.Detail.Code));
                //    if (ex.Detail.Code == ErrorCodes.TEACHER_PERSONALIZED
                //        || ex.Detail.Code == ErrorCodes.TEACHER_NOT_WORKING
                //        || ex.Detail.Code == ErrorCodes.TEACHER_WORKING_ABROAD
                //        || ex.Detail.Code == ErrorCodes.TEACHER_CONTRACT_END)
                //    {
                //        JumpToNextTeacherRecord();
                //    }
                //    SwitchProcessingState();
                //    return;
                //}
                //catch (FaultException ex)
                //{
                //    AppendToResultTable(teacherCode, teacherName, serialNumberHex, false, ex.Message);
                //    MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.FaultExceptionMessage
                //        + Environment.NewLine + Environment.NewLine
                //        + ex.Message);
                //    SwitchProcessingState();
                //    return;
                //}
                //catch (CommunicationException)
                //{
                //    AppendToResultTable(teacherCode, teacherName, serialNumberHex, false, CommonMessages.CommunicationExceptionMessage);
                //    MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.CommunicationExceptionMessage);
                //    SwitchProcessingState();
                //    return;
                //}

                #endregion

                #region Step 4: Write header data

                //// Login to header using key B
                //if (!readerLib.Authenticate(1, false, data.HeaderKeyB))
                //{
                //    AppendToResultTable(teacherCode, teacherName, serialNumberHex, false, "Không đăng nhập được vào header");
                //    SwitchProcessingState();
                //    return;
                //}

                //// Update header data
                //data.TeacherAppMetadata.GetAppMetadataBytes().CopyTo(headerData, AppMetadataParser.StartPositionOnHeader);
                //if (!readerLib.WriteHeader(headerData))
                //{
                //    AppendToResultTable(teacherCode, teacherName, serialNumberHex, false, "Không ghi được dữ liệu vào header");
                //    SwitchProcessingState();
                //    return;
                //}

                #endregion

                #region Step 5: Write teacher app data

                //// Check teacher data length
                //int dataMaxLength = data.TeacherAppMetadata.MaxSectorUsed * MifareClassicParams.SECTOR_SIZE;
                //if (data.TeacherData.Length > dataMaxLength)
                //{
                //    byte[] temp = data.TeacherData;
                //    data.TeacherData = new byte[dataMaxLength];
                //    Array.Copy(temp, 0, data.TeacherData, 0, dataMaxLength);
                //}

                //byte endSectorNumber = (byte)(data.TeacherAppMetadata.StartSectorNumber + data.TeacherAppMetadata.MaxSectorUsed - 1);
                //byte[] sectorData;

                //for (byte s = data.TeacherAppMetadata.StartSectorNumber, i = 0; s <= endSectorNumber; s++, i++)
                //{
                //    // Copy sector data to a 16-bytes array
                //    int len = data.TeacherData.Length - i * MifareClassicParams.SECTOR_SIZE;
                //    if (len > MifareClassicParams.SECTOR_SIZE)
                //    {
                //        sectorData = new byte[MifareClassicParams.SECTOR_SIZE];
                //        Array.Copy(data.TeacherData, i * MifareClassicParams.SECTOR_SIZE, sectorData, 0, 48);
                //    }
                //    else if (len > 0)
                //    {
                //        sectorData = new byte[len];
                //        Array.Copy(data.TeacherData, i * MifareClassicParams.SECTOR_SIZE, sectorData, 0, len);
                //    }
                //    else
                //    {
                //        break;
                //    }

                //    // Get sector key pair
                //    KeyUpdateSetDto keySet = data.AppSectorKeyUpdateSets[s];

                //    // Login to sector using key B
                //    bool alreadyNewKeys = false;
                //    if (!readerLib.Authenticate(s, false, keySet.CurrentKeyB))
                //    {
                //        // If write failed then re-login with new keys
                //        if (!readerLib.Authenticate(s, true, keySet.NewKeyA) || !readerLib.Authenticate(s, false, keySet.NewKeyB))
                //        {
                //            AppendToResultTable(teacherCode, teacherName, serialNumberHex, false, "Không đăng nhập được vào sector " + s);
                //            SwitchProcessingState();
                //            return;
                //        }
                //        alreadyNewKeys = true;
                //    }

                //    // Write data to sector
                //    if (!readerLib.WriteSector(s, sectorData))
                //    {
                //        AppendToResultTable(teacherCode, teacherName, serialNumberHex, false, "Không ghi được dữ liệu vào sector " + s);
                //        SwitchProcessingState();
                //        return;
                //    }

                //    // Write new key pair to sector if app using an AMK
                //    if (data.TeacherAppMetadata.KeyAlias != 0 && !alreadyNewKeys)
                //    {
                //        if (!readerLib.WriteDataKeys(s, keySet.NewKeyA, keySet.NewKeyB))
                //        {
                //            // If write failed then re-login with new keys
                //            if (!readerLib.Authenticate(s, true, keySet.NewKeyA) || !readerLib.Authenticate(s, false, keySet.NewKeyB))
                //            {
                //                AppendToResultTable(teacherCode, teacherName, serialNumberHex, false, "Không ghi được khóa vào sector " + s);
                //                SwitchProcessingState();
                //                return;
                //            }
                //        }
                //    }
                //}

                #endregion

                #region Step 5.1: Write teacher code to block 14

                //byte[] block14Data;
                //if (!readerLib.ReadBlock(14, out block14Data))
                //{
                //    return;
                //}

                //byte[] teacherCodeBytes = Encoding.ASCII.GetBytes(teacherCode);
                //teacherCodeBytes.CopyTo(block14Data, 10);
                //if (!readerLib.WriteBlock(14, teacherCodeBytes))
                //{
                //    return;
                //}

                //#endregion

                //#region Step 6: Call service to complete perso

                //try
                //{
                //    JavaCommunicationPersonalization.Instance.PersoCard(storageService.CurrentSessionId, teacherId, serialNumberHex);
                //    AppendToResultTable(teacherCode, teacherName, serialNumberHex, true, string.Empty);
                //    JumpToNextTeacherRecord();
                //}
                //catch (TimeoutException)
                //{
                //    AppendToResultTable(teacherCode, teacherName, serialNumberHex, false, CommonMessages.TimeOutExceptionMessage);
                //    MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.TimeOutExceptionMessage);
                //}
                //catch (FaultException<WcfServiceFault> ex)
                //{
                //    AppendToResultTable(teacherCode, teacherName, serialNumberHex, false, ErrorCodes.GetErrorMessage(ex.Detail.Code));
                //    if (ex.Detail.Code == ErrorCodes.TEACHER_PERSONALIZED
                //        || ex.Detail.Code == ErrorCodes.TEACHER_NOT_WORKING
                //        || ex.Detail.Code == ErrorCodes.TEACHER_WORKING_ABROAD
                //        || ex.Detail.Code == ErrorCodes.TEACHER_CONTRACT_END)
                //    {
                //        JumpToNextTeacherRecord();
                //    }
                //}
                //catch (FaultException ex)
                //{
                //    AppendToResultTable(teacherCode, teacherName, serialNumberHex, false, ex.Message);
                //    MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.FaultExceptionMessage
                //        + Environment.NewLine + Environment.NewLine
                //        + ex.Message);
                //}
                //catch (CommunicationException)
                //{
                //    AppendToResultTable(teacherCode, teacherName, serialNumberHex, false, CommonMessages.CommunicationExceptionMessage);
                //    MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.CommunicationExceptionMessage);
                //}
                //finally
                //{
                //    SwitchProcessingState();
                //}

                #endregion
            }
        }

        #endregion


    }
}
