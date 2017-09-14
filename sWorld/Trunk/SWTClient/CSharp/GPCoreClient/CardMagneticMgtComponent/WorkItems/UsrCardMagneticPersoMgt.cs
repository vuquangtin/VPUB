using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using CommonControls.Custom;
using CommonHelper.Constants;
using Microsoft.Practices.CompositeUI;
using System.ServiceModel;
using CommonControls;
using CommonHelper.Config;
using Microsoft.Practices.CompositeUI.Commands;
using Microsoft.Practices.CompositeUI.EventBroker;
using System.Drawing;
using sWorldModel;
using sWorldModel.Exceptions;
using sWorldModel.Filters;
using CryptoAlgorithm;
using CommonHelper.Utils;
using System.Globalization;
using System.IO;
using ExcelLibrary.SpreadSheet;
using JavaCommunication.Factory;
using JavaCommunication;
using Newtonsoft.Json;
using System.Text;
using sWorldModel.TransportData;
using CardMagneticMgtComponent.WorkItems;
using CardMagneticMgtComponent.Constants;
using MemberMgtComponent;

namespace CardMagneticMgtComponent.WorkItems
{
    public partial class UsrCardMagneticPersoMgt : CommonUserControl
    {
        #region Properties

        private int hiddenSettingFileExcelBoxHeight = 0;
        private int startupSettingFileExcelBoxHeight;
        private int hiddenCountExcelBoxHeight = 0;
        private int startupCountBoxHeight;
        private DialogPostAction postAction = DialogPostAction.NONE;
        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;
        private MasterInfoDTO masterInfo;
        private MasterInfoDTO partnerInfo;
        private PartnerInfoDTO partnerInfoSelected;
        // private List<CardTypeDTO> cardType;
        private CardTypeDTO cardTypeInfoSelect;
        
        private List<MemberDataExcelDto> memberList;
        List<MemberDataExcelDto> listperso;
        private PreGenerateData preGenerateData;
        private CardMagneticWorkItem workItem;
        [ServiceDependency]
        public CardMagneticWorkItem WorkItem
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

        public UsrCardMagneticPersoMgt()
        {
            InitializeComponent();
            this.Enter += (s, e) =>
            {
                if (CardMagneticMgtMainShown != null)
                {
                    CardMagneticMgtMainShown(this, new CabEventArgs(new object[] { CardMagneticCommandNames.ShowCardMagneticMgtMain }));
                }
            };
            this.Load += OnFormLoad;
            this.btnBrowseDataFile.Click += btnBrowseDataFile_Click;
            this.cmbCardType.SelectedIndexChanged += cmbCardType_SelectedIndexChanged;
            this.ckbDataDefault.CheckedChanged += ckbDataDefault_CheckedChanged;
            this.rbtnLoadOneSheet.CheckedChanged += rbtnLoadOneSheet_CheckedChanged;
            this.tbxDataFilePath.TextChanged += tbxDataFilePath_TextChanged;
            this.cbxOnlyShowErrorRows.CheckedChanged += cbxOnlyShowErrorRows_CheckedChanged;
            this.btnImportData.Click += btnImportData_Click;
            this.btnGenerateSerialNumber.Click += btnGenerateSerialNumber_Click;
            this.btnExportData.Click += btnExportToExcel_Click;
            startupCountBoxHeight = pnlCount.Height;
            startupSettingFileExcelBoxHeight = pnlSettingFileExcel.Height;

        }

        #endregion

        #region CAB events

        [EventPublication(CardMagneticEventTopicNames.CardMagneticMgtMainShown)]
        public event EventHandler CardMagneticMgtMainShown;

        [CommandHandler(CardMagneticCommandNames.ShowCardMagneticMgtMain)]
        public void ShowCardMgtMainHandler(object s, EventArgs e)
        {
            UsrCardMagneticPersoMgt uc = workItem.Items.Get<UsrCardMagneticPersoMgt>(ComponentNames.CardMagneticMgtComponent);
            if (uc == null)
            {
                uc = workItem.Items.AddNew<UsrCardMagneticPersoMgt>(ComponentNames.CardMagneticMgtComponent);
            }
            else if (uc.IsDisposed)
            {
                workItem.Items.Remove(uc);
                uc = workItem.Items.AddNew<UsrCardMagneticPersoMgt>(ComponentNames.CardMagneticMgtComponent);
            }

            workItem.Workspaces[WorkspaceName.MainWorkspace].Show(uc);
            uc.Parent.Text = "Cấp thẻ từ";
        }

        #endregion

        #region Form Event's

        private void OnFormLoad(object sender, EventArgs e)
        {
            //load infor master
            LoadMasterInfo();

            //load infor partner
            LoadPartnerInfo();

            if (partnerInfo == null)
                LoadCardType(masterInfo.cardtypes);

            SetShowHide();
            LoadComboboxFilter();
            SetComboboxFilter();
        }

        private void btnBrowseDataFile_Click(object sender, EventArgs e)
        {
            BrowseFileExcel();
        }

        //private void cmbPartnerInfo_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    partnerInfoSelected = cmbPartnerInfo.SelectedItem as PartnerInfoDTO;
        //    if (partnerInfoSelected != null)
        //        LoadCardType(partnerInfoSelected.cardtypes);
        //}

        private void cmbCardType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCardType.SelectedIndex >= 0)
                cardTypeInfoSelect = cmbCardType.SelectedItem as CardTypeDTO;
        }

        private void ckbDataDefault_CheckedChanged(object sender, EventArgs e)
        {
            //string mess = ckbDataDefault.Checked ?
            //    "Bạn có chắc chuyển sang phát hành thẻ với dữ liệu từ tập tin Excel không?"
            //    : "Bạn có chắc chuyển sang phát hành thẻ với dữ liệu mặc định không?";
            //if (MessageBoxManager.ShowQuestionMessageBox(this, mess) == DialogResult.Yes)
            //{
            //    SetShowHide();
            //}
            //else
            //    ckbDataDefault.Checked = ckbDataDefault.Checked ? true : false;
            SetShowHide();
        }

        private void rbtnLoadOneSheet_CheckedChanged(object sender, EventArgs e)
        {
            cmbSheetNames.Enabled = rbtnLoadOneSheet.Checked;
        }

        private void tbxDataFilePath_TextChanged(object sender, EventArgs e)
        {
            cmbSheetNames.Items.Clear();

            if (tbxDataFilePath.Text.Length != 0)
            {
                string[] sheetNames = DataManagerFileExcel.Instance.LoadSheetNames(tbxDataFilePath.Text);
                if (sheetNames == null)
                {
                    return;
                }

                foreach (string name in sheetNames)
                {
                    cmbSheetNames.Items.Add(name);
                }
                if (cmbSheetNames.Items.Count > 0)
                {
                    cmbSheetNames.SelectedIndex = 0;
                }
            }
        }

        private void cbxOnlyShowErrorRows_CheckedChanged(object sender, EventArgs e)
        {
            OnlyShowErrorRows();
        }

        private void btnImportData_Click(object sender, EventArgs e)
        {
            dgvCustomerData.Rows.Clear();

            if (!ckbDataDefault.Checked)
            {
                if (CheckInputData())
                {
                    LoadDataGrid();
                }
            }
            else 
            {
                // Load dữ liệu mặc định

                LoadDataDefaultGrid();
            }

            if (dgvCustomerData.RowCount != null)
            {
                btnGenerateSerialNumber.Enabled = true;
            }
        }

        private void btnGenerateSerialNumber_Click(object sender, EventArgs e)
        {
                if (ValidateGenerateSerialNumber())
                    GenerateSerialNumber();           
            // Xác nhận trước khi lưu xuống Database
                //if (MessageBoxManager.ShowQuestionMessageBox(this, "Bạn có chắc muốn lưu dữ liệu vào hệ thống không?") == DialogResult.Yes)
                //{
                //    postAction = DialogPostAction.CONFIRMED;
                //    PersoMagneticCardInforDTO data = GenerateSerialNumber();
                //    if (listperso == null && listperso.Count == 0)
                //        return;

                //    int kq = MagneticPersonalizationFactory.Instance.GetChannel().SaveDataPresoCardMagnetic(StorageService.CurrentSessionId, data);

                //    if ((int)Status.SUCCESS == kq)
                //    {
                //        MessageBox.Show("Lưu thành công");
                //    }
                //    else
                //    {
                //        MessageBox.Show("Chưa lưu được");
                //    }
                  
                //}
                if (dgvCustomerData.RowCount != null)
                {
                    btnSaveData.Enabled = true;
                    btnExportData.Enabled = true;
                }
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            string filePath = ControlExtMethods.ShowSaveFileDialog("Chọn tập tin chứa dữ liệu cần xuất", "MS Excel (*.xls)|*.xls");
            if (filePath != null)
            {
                try
                {
                    dgvCustomerData.ExportToExcel(filePath);
                }
                catch (Exception ex)
                {
                    MessageBoxManager.ShowErrorMessageBox(this, ex.Message);
                    return;
                }
                MessageBoxManager.ShowInfoMessageBox(this, "Đã xuất dữ liệu ra tập tin tại đường dẫn: " + filePath);
            }
        }

        #endregion

        #region Event's Support

        private void LoadMasterInfo()
        {
            try
            {
                this.masterInfo = OrganizationFactory.Instance.GetChannel().GetMasterInfo(StorageService.CurrentSessionId, SystemSettings.Instance.Master);
                //cmbMasterInfo.DataSource = new List<MasterInfoDTO>() { this.masterInfo };
                //cmbMasterInfo.ValueMember = "MasterId";
                //cmbMasterInfo.DisplayMember = "Name";
                //cmbMasterInfo.SelectedIndex = 0;
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
            //aes = new AesEncryption(this.masterInfo.MasterKey);
        }

        private void LoadPartnerInfo()
        {
            try
            {
                if (masterInfo == null) return;

                this.partnerInfo = OrganizationFactory.Instance.GetChannel().GetMasterInfo(StorageService.CurrentSessionId, SystemSettings.Instance.Partner);
                cmbMasterInfo.DataSource = this.partnerInfo;
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
            //aes = new AesEncryption(this.masterInfo.MasterKey);
        }

        private void LoadCardType(List<CardTypeDTO> cardTypes)
        {
            cmbCardType.DataSource = cardTypes;
            cmbCardType.ValueMember = "prefix";
            cmbCardType.DisplayMember = "cardTypeName";
            cmbCardType.SelectedIndex = 0;
        }

        #region Settings File Excel

        private void SetShowHide()
        {
            if (!ckbDataDefault.Checked)
            {
                pnlSettingFileExcel.Height = startupSettingFileExcelBoxHeight;
                pnlCount.Height = hiddenCountExcelBoxHeight;
                cbxCount.Text = "0";
            }
            else
            {
                pnlSettingFileExcel.Height = hiddenSettingFileExcelBoxHeight;
                pnlCount.Height = startupCountBoxHeight;
                tbxDataFilePath.Text = string.Empty;
            }
            dgvCustomerData.Rows.Clear();
        }

        private void BrowseFileExcel()
        {
            if (openFileDialog == null)
            {
                openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "Open File";
                openFileDialog.Filter = "Microsoft Excel 97 - 2003 | *.xls";
                openFileDialog.Multiselect = false;
            }
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                tbxDataFilePath.Text = openFileDialog.FileName;
            }
        }

        private void LoadComboboxFilter()
        {
            string[] excelColumns = ExcelUtils.GenerateColumnCaptions(26);
            cmbLastNameColumnIndex.DataSource = excelColumns;
            cmbFirstNameColumnIndex.DataSource = excelColumns.Clone();
            cmbPhoneNumberColumnIndex.DataSource = excelColumns.Clone();
            cmbCompanyColumnIndex.DataSource = excelColumns.Clone();
            cmbExpiredTimeColIndex.DataSource = excelColumns.Clone();
        }

        private void SetComboboxFilter()
        {
            cmbLastNameColumnIndex.SelectedIndex = cmbLastNameColumnIndex.SelectedIndex > 1 ? cmbLastNameColumnIndex.SelectedIndex : 1;
            cmbFirstNameColumnIndex.SelectedIndex = cmbLastNameColumnIndex.SelectedIndex + 1;
            cmbPhoneNumberColumnIndex.SelectedIndex = cmbFirstNameColumnIndex.SelectedIndex + 1;
            cmbCompanyColumnIndex.SelectedIndex = cmbPhoneNumberColumnIndex.SelectedIndex + 1;
            cmbExpiredTimeColIndex.SelectedIndex = cmbCompanyColumnIndex.SelectedIndex + 1;
        }

        private void OnlyShowErrorRows()
        {
            foreach (DataGridViewRow row in dgvCustomerData.Rows)
            {
                CheckRowError(row.Index);

                if (cbxOnlyShowErrorRows.Checked)
                {
                    row.Visible = HasErrorOnRow(row.Index);
                }
                else
                {
                    row.Visible = true;
                }
            }
        }

        #endregion

        #region Load dữ liệu từ file excel

        // List dữ liệu từ file excel gửi qua server để cá thể hóa
        private  List<MemberDataExcelDto> LoadMemberDataList()
        {
            string filePath = tbxDataFilePath.Text;
            int sheetIndex = rbtnLoadAllSheets.Checked ? -1 : cmbSheetNames.SelectedIndex;
            int titleRowIndex = int.Parse(tbxHeaderRowIndex.Text) - 1;
            int lastNameColIndex = cmbLastNameColumnIndex.SelectedIndex;
            int firstNameColIndex = cmbFirstNameColumnIndex.SelectedIndex;
            int phoneColIndex = cmbPhoneNumberColumnIndex.SelectedIndex;
            int companyColIndex = cmbCompanyColumnIndex.SelectedIndex;
            int expiredTimeColIndex = cmbExpiredTimeColIndex.SelectedIndex;

            // Load data from Excel file
            return DataManagerFileExcel.Instance.LoadBookData(filePath, sheetIndex, titleRowIndex, phoneColIndex, firstNameColIndex, lastNameColIndex, companyColIndex, expiredTimeColIndex);
        }

        // Load dữ liệu từ file excel trước khi cá thể hóa
        private void LoadDataGrid()
        {
            //load data from excel to list object
            memberList = LoadMemberDataList();

            //show member to datagrid
            int index;
            for (int i = 0; i < memberList.Count; i++)
            {
                MemberDataExcelDto c = memberList[i];
                index = dgvCustomerData.Rows.Add(1);

                int j = c.CompanyName.IndexOf("công ty cp ", StringComparison.CurrentCultureIgnoreCase);
                if (j > -1)
                {
                    c.CompanyName = c.CompanyName.Remove(j, 11);
                }
                else
                {
                    j = c.CompanyName.IndexOf("công ty ", StringComparison.CurrentCultureIgnoreCase);
                    if (j > -1)
                    {
                        c.CompanyName = c.CompanyName.Remove(j, 8);
                    }
                }
                j = c.CompanyName.IndexOf("cổ phần ", StringComparison.CurrentCultureIgnoreCase);
                if (j > -1)
                {
                    c.CompanyName = c.CompanyName.Remove(j, 8);
                }
                j = c.CompanyName.IndexOf("tnhh ", StringComparison.CurrentCultureIgnoreCase);
                if (j > -1)
                {
                    c.CompanyName = c.CompanyName.Remove(j, 5);
                }

                dgvCustomerData.Rows[index].Cells[colOrderNo.DataPropertyName].Value = i + 1;
                dgvCustomerData.Rows[index].Cells[colSheetName.DataPropertyName].Value = c.SheetName;
                dgvCustomerData.Rows[index].Cells[colCustomerName.DataPropertyName].Value = c.FullName;
                dgvCustomerData.Rows[index].Cells[colCompanyName.DataPropertyName].Value = c.CompanyName;
                dgvCustomerData.Rows[index].Cells[colPhoneNumber.DataPropertyName].Value = c.PhoneNumber;
                dgvCustomerData.Rows[index].Cells[colExpiredTime.DataPropertyName].Value = c.ExpiredTime;
                CheckRowError(i);

                if (cbxOnlyShowErrorRows.Checked)
                {
                    dgvCustomerData.Rows[index].Visible = HasErrorOnRow(index);
                }
            }
        }

        private bool ValidateDataDefault()
        {
            if (string.IsNullOrEmpty(cbxCount.Text))
            {
                MessageBox.Show("Vui lòng nhập số lượng thẻ cần phát hành!", "Thao Tác Sai", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (Convert.ToInt32(cbxCount.Text) <= 0)
            {
                MessageBox.Show("Vui lòng nhập số lượng thẻ cần phát hành!", "Thao Tác Sai", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        // Load dữ liệu mặc định lên gridview trước lúc cá thể hóa
        private void LoadDataDefaultGrid()
        {
            int isdefault = (ckbDataDefault.Checked == true ? (int)MAGNETIC_INFOR.DEFULT_VALUE : (int)MAGNETIC_INFOR.NO_DEFULT);
            preGenerateData = MagneticPersonalizationFactory.Instance.GetChannel().GetPreGenerateData(StorageService.CurrentSessionId,
                masterInfo.MasterId, partnerInfo.MasterId, isdefault);

            string expiredTime = dtpExpirationDate.Value.ToString("dd/MM/yyyy");
            int index;
            for (int i = 0; i < Convert.ToInt32(cbxCount.Text); i++)
            {
                index = dgvCustomerData.Rows.Add(1);

                dgvCustomerData.Rows[index].Cells[colOrderNo.DataPropertyName].Value = i + 1;
                dgvCustomerData.Rows[index].Cells[colSheetName.DataPropertyName].Value = "Sheet 1";
                dgvCustomerData.Rows[index].Cells[colCustomerName.DataPropertyName].Value = preGenerateData.FullName;
                dgvCustomerData.Rows[index].Cells[colCompanyName.DataPropertyName].Value = preGenerateData.CompanyName;
                dgvCustomerData.Rows[index].Cells[colPhoneNumber.DataPropertyName].Value = preGenerateData.PhoneNumber;
                dgvCustomerData.Rows[index].Cells[colExpiredTime.DataPropertyName].Value = expiredTime;
                CheckRowError(i);

                if (cbxOnlyShowErrorRows.Checked)
                {
                    dgvCustomerData.Rows[index].Visible = HasErrorOnRow(index);
                }
            }
        }

        #endregion

        #region GenerateSerialNumber

        private bool ValidateGenerateSerialNumber()
        {
            // Check amount of rows on datagridview
            if (dgvCustomerData.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng cập nhật dữ liệu!", "Thao Tác Sai", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Check row error
            bool error = false;
            for (int i = 0; i < dgvCustomerData.RowCount; i++)
            {
                CheckRowError(i);
                if (!error)
                {
                    error = HasErrorOnRow(i);
                }
            }

            if (error)
            {
                MessageBox.Show("Dữ liệu hiện tại đang có lỗi, vui lòng sửa các lỗi này trước!", "Thao Tác Sai", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cmbMasterInfo.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn tổ chức phát hành thẻ!", "Thao Tác Sai", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //if (cmbPartnerInfo.SelectedValue == null)
            //{
            //    MessageBox.Show("Vui lòng chọn tổ chức chấp nhận thẻ!", "Thao Tác Sai", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return false;
            //}

            return true;
        }

        private int checkchange()
        {
            int kq = 0;
            if (ckbDataDefault.Checked == true)
            {
                kq = 1;
            }
            return kq;
        }

        private PersoMagneticCardInforDTO GenerateSerialNumber()
        {
            string generatedSerialNumber = string.Empty;
            PersoMagneticCardInforDTO persodata = new PersoMagneticCardInforDTO();

            if (1 != checkchange())
            {
                //Lấy từ file excel
                persodata.listperso = memberList;
                persodata.count = memberList.Count;
            }
            else
            {
                // Lấy dữ liệu mặc định
                persodata.ExpiredTime = dtpExpirationDate.Value.ToStringFormatDate();
                persodata.count = Convert.ToInt32(cbxCount.Text);
            }
            int isDefault = checkchange();
            persodata.prefix = cardTypeInfoSelect.prefix;
            persodata.isdefault = (int)isDefault; // Nếu partner ko có thì isdefault gửi về là chuỗi 4 chữ số: 0000

            persodata.masterid = masterInfo.MasterId;
            persodata.mastercode = masterInfo.code;
            
            persodata.partnercode = partnerInfoSelected != null ? partnerInfoSelected.code : null;
            persodata.partnerid = partnerInfoSelected != null ? partnerInfoSelected.PartnerId : 0;

            listperso = MagneticPersonalizationFactory.Instance.GetChannel().SendDataToServerForGeneral(StorageService.CurrentSessionId, persodata);
            persodata.listperso = listperso;
            dgvCustomerData.Rows.Clear(); // xóa dữ liệu tải lên trước khi sinh mã số và track từ
            int index = 0;
            foreach (MemberDataExcelDto item in listperso) // Lấy ra từng dòng record trong danh sách trả về
            {
                index = dgvCustomerData.Rows.Add(1);
                //  MemberDataExcelDto member = new MemberDataExcelDto();
                dgvCustomerData.Rows[index].Cells[colOrderNo.DataPropertyName].Value = index + 1;
                dgvCustomerData.Rows[index].Cells[colSheetName.DataPropertyName].Value = "Sheet 1";
                dgvCustomerData.Rows[index].Cells[colCustomerName.DataPropertyName].Value = item.FullName;
                dgvCustomerData.Rows[index].Cells[colCompanyName.DataPropertyName].Value = item.CompanyName;
                dgvCustomerData.Rows[index].Cells[colPhoneNumber.DataPropertyName].Value = item.PhoneNumber;
                dgvCustomerData.Rows[index].Cells[colExpiredTime.DataPropertyName].Value = item.ExpiredTime;
                //dgvCustomerData.Rows[index].Cells[colExpiredTime.DataPropertyName].Value = Convert.ToDateTime(item.ExpiredTime).ToString("dd/MM/yyyy");
                dgvCustomerData.Rows[index].Cells[colSerialNumber.DataPropertyName].Value = item.SerialNumber;
                dgvCustomerData.Rows[index].Cells[colTrackOneData.DataPropertyName].Value = item.TrackData;

                CheckRowError(index);

                if (cbxOnlyShowErrorRows.Checked)
                {
                    dgvCustomerData.Rows[index].Visible = HasErrorOnRow(index);
                }
                index++;
            }
            return persodata;
        }

        // Lấy dữ liệu trên Grid lưu xuống Database

        private void btnSaveData_Click(object sender, EventArgs e)
        {
            PersoMagneticCardInforDTO data = GenerateSerialNumber();

            if (listperso == null && listperso.Count == 0)
                return;

            int kq = MagneticPersonalizationFactory.Instance.GetChannel().SaveDataPresoCardMagnetic(StorageService.CurrentSessionId, data);

            if ((int)Status.SUCCESS == kq)
            {
                MessageBox.Show("Lưu thành công");
            }
            else
            {
                MessageBox.Show("Chưa lưu được");
            }
            //if (MessageBoxManager.ShowQuestionMessageBox(this, "Bạn có chắc muốn lưu thông tin vào hệ thống không?") == DialogResult.Yes)
            //{
            //    postAction = DialogPostAction.CONFIRMED;

            //}

        }

        #endregion

        #endregion

        #region Data Checking

        private bool CheckInputData()
        {
            // Kiểm tra người dùng đã chọn đường dẫn đến file excel chưa
            if (tbxDataFilePath.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa chỉ đường dẫn đến tập tin Excel chứa dữ liệu khách hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Kiểm tra người dùng đã chọn sheet chưa
            if (rbtnLoadOneSheet.Checked)
            {
                if (cmbSheetNames.SelectedIndex < 0)
                {
                    MessageBox.Show("Bạn chưa sheet cần nhập dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            // Kiểm tra vị trí đòng tiêu đề có là số hay không
            uint test;
            tbxHeaderRowIndex.Text = tbxHeaderRowIndex.Text.Trim();
            if (tbxHeaderRowIndex.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập vị trí dòng tiêu đề của mỗi sheet!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!uint.TryParse(tbxHeaderRowIndex.Text, out test))
            {
                MessageBox.Show("Vị trí dòng tiêu đề của mỗi sheet không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Kiểm tra người dùng đã chọn vị trí cột số điện thoại chưa
            if (cmbPhoneNumberColumnIndex.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn chưa chọn vị trí cột số điện thoại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Kiểm tra người dùng đã chọn vị trí cột công ty chưa
            if (cmbCompanyColumnIndex.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn chưa chọn vị trí cột tên công ty!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Kiểm tra người dùng đã chọn vị trí cột tên khách hàng chưa
            if (cmbFirstNameColumnIndex.SelectedIndex < 0 && cmbLastNameColumnIndex.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn chưa chọn vị trí cột tên khách hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Kiểm tra người dùng đã chọn vị trí cột thời hạn thẻ chưa
            if (cmbExpiredTimeColIndex.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn chưa chọn vị trí cột thời hạn thẻ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void CheckRowError(int rowIndex)
        {
            DataGridViewRow row = dgvCustomerData.Rows[rowIndex];

            // Kiểm tra dữ liệu cột tên khách hàng
            object test = row.Cells[colCustomerName.DataPropertyName].Value;
            string customerName = test == null ? string.Empty : test.ToString();
            if (customerName.Length == 0)
            {
                row.Cells[colCustomerName.DataPropertyName].ErrorText = "Tên khách hàng không được rỗng";
            }
            else
            {
                row.Cells[colCustomerName.DataPropertyName].ErrorText = string.Empty;
            }

            // Kiểm tra dữ liệu cột tên công ty
            test = row.Cells[colCompanyName.DataPropertyName].Value;
            string companyName = test == null ? string.Empty : test.ToString();
            if (companyName.Length > 50)
            {
                row.Cells[colCompanyName.DataPropertyName].ErrorText = "Tên công ty không được quá 25 ký tự";
            }
            else
            {
                row.Cells[colCompanyName.DataPropertyName].ErrorText = string.Empty;
            }

            // Kiểm tra dữ liệu cột số điện thoại
            test = row.Cells[colPhoneNumber.DataPropertyName].Value;
            string phoneNumber = test == null ? string.Empty : test.ToString();
            if (phoneNumber.Length != 0 && phoneNumber.Length != 10 && phoneNumber.Length != 11)
            {
                row.Cells[colPhoneNumber.DataPropertyName].ErrorText = "Số điện thoại không hợp lệ";
            }
            else
            {
                row.Cells[colPhoneNumber.DataPropertyName].ErrorText = string.Empty;
            }

            // Kiểm tra dữ liệu cột thời hạn thẻ
            test = row.Cells[colExpiredTime.DataPropertyName].Value;
            string expiredTime = test == null ? string.Empty : test.ToString();
            DateTime test2;
            if (expiredTime.Length == 0 || !DateTime.TryParseExact(expiredTime, "dd/MM/yyyy", null, DateTimeStyles.None, out test2))
            {
                row.Cells[colExpiredTime.DataPropertyName].ErrorText = "Ngày hết hạn không hợp lệ";
            }
            else
            {
                row.Cells[colExpiredTime.DataPropertyName].ErrorText = string.Empty;
            }
        }

        private bool HasErrorOnRow(int rowIndex)
        {
            DataGridViewRow row = dgvCustomerData.Rows[rowIndex];
            for (int i = 0; i < row.Cells.Count; i++)
            {
                if (row.Cells[i].ErrorText.Length > 0)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion



    }
}
