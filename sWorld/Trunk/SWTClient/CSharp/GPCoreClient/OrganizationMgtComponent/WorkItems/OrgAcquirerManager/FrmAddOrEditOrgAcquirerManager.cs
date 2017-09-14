using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sWorldModel.TransportData;
using CommonControls;
using System.ServiceModel;
using sWorldModel.Exceptions;
using JavaCommunication.Factory;
using sWorldModel;
using Microsoft.Practices.CompositeUI;
using JavaCommunication;
using CommonControls.Custom;
using CommonHelper.Config;
using CommonHelper.Constants;
using System.Resources;
using CommonHelper.Utils;

namespace SystemMgtComponent.WorkItems.OrgAcquirerManager
{
    public partial class FrmAddOrEditOrgAcquirerManager : CommonControls.Custom.CommonDialog
    {
        #region Properties

        public const byte ModeAdding = 1;
        public const byte ModeUpdating = 2;

        private const int SetMaxWightTxtName = 323;

        private byte OperatingMode;
        private DataTable dtbMasterList;

        private string MasterCode;
        private List<long> PartnerList;
        private ResourceManager rm;

        private long SelectMasterId;
        private List<long> SelectPartnerList = new List<long>();

        private BackgroundWorker bgwLoadOrg;
        private BackgroundWorker bgwAddOrgAcquirer;
        private BackgroundWorker bgwUpdateOrgAcquirer;

        public DialogPostAction PostAction { get; private set; }

        private ILocalStorageService storageService;
        [ServiceDependency]
        public ILocalStorageService StorageService
        {
            get { return storageService; }
            set { storageService = value; }
        }

        #endregion

        public FrmAddOrEditOrgAcquirerManager(byte operationMode, string masterCode, List<long> partnerList = null)
        {
            InitializeComponent();
            InitDataGridView();
            RegisterEvent();
            this.MasterCode = masterCode;
            this.PartnerList = partnerList;
            this.OperatingMode = operationMode;
        }

        private void RegisterEvent()
        {
            btnCancel.Click += OnButtonCancelClicked;
            btnConfirm.Click += OnButtonConfirmClicked;
            btnRefresh.Click += OnButtonRefreshClicked;
            dgvPartnerList.CellMouseUp += dgvPartnerList_OnCellMouseUp;
            Shown += OnFormShown;
        }

        #region Event's

        private void OnFormShown(object sender, EventArgs e)
        {
            // btnConfirm.Enabled = btnRefresh.Enabled = true;
            //  Switch view to corresponding mode
            switch (OperatingMode)
            {
                case ModeAdding:
                    InitFormAddOrgAcquirer();
                    LoadOrg();
                    break;
                case ModeUpdating:
                    InitFormUpdateOrgAcquirer();
                    LoadOrg();
                    break;
                default:
                    throw new ArgumentException("Invalid operating mode!");
            }

            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
        }

        #region Data Grid View Partner

        private void checkBoxHeader_OnCheckBoxClicked(bool status)
        {
            SelectPartnerList.Clear();
            for (int i = 0; i < dgvPartnerList.Rows.Count; i++)
            {
                dgvPartnerList.Rows[i].Selected = status;
                dgvPartnerList.Rows[i].Cells[0].Value = status;
                if (status)
                {
                    SelectPartnerList.Add(Convert.ToInt32(dgvPartnerList.Rows[i].Cells[ColOrgId.Index].Value.ToString()));
                    dgvPartnerList.Rows[i].DefaultCellStyle.BackColor = SystemColors.Highlight;
                    dgvPartnerList.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                }
                else
                {
                    dgvPartnerList.Rows[i].DefaultCellStyle.BackColor = Color.White;
                    dgvPartnerList.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                }

            }
        }

        private void SetSelectedRowPartnerData(DataGridViewRow row, bool rowChecked)
        {
            if (rowChecked)
            {
                row.Cells[0].Value = true;
                row.DefaultCellStyle.BackColor = SystemColors.Highlight;
                row.DefaultCellStyle.ForeColor = Color.White;
                SelectPartnerList.Add(Convert.ToInt32(row.Cells[ColOrgId.Index].Value.ToString()));
            }
            else
            {
                row.Cells[0].Value = false;
                row.DefaultCellStyle.BackColor = Color.White;
                row.DefaultCellStyle.ForeColor = Color.Black;
                SelectPartnerList.Remove(Convert.ToInt32(row.Cells[ColOrgId.Index].Value.ToString()));
            }
        }

        private void SetAppDataList()
        {
            SelectPartnerList = new List<long>();
            foreach (DataGridViewRow row in dgvPartnerList.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value))
                {
                    row.Selected = true;
                    row.DefaultCellStyle.BackColor = SystemColors.Highlight;
                    row.DefaultCellStyle.ForeColor = Color.White;
                    SelectPartnerList.Add(Convert.ToInt32(row.Cells[ColOrgId.Index].Value.ToString()));
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                    row.Selected = false;
                }
            }
        }

        private void dgvPartnerList_OnCellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex > -1)
            {
                DataGridViewRow rowIndex = dgvPartnerList.Rows[e.RowIndex];
                bool value = Convert.ToBoolean(dgvPartnerList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                SetSelectedRowPartnerData(rowIndex, !value);
                SetAppDataList();

                dgvPartnerList.EndEdit();
            }
        }

        #endregion

        #region OrgAcquirer

        private void OnLoadOrgAcquirerWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = OrganizationFactory.Instance.GetChannel().GetAllOrgList(StorageService.CurrentSessionId);
            }
            catch (TimeoutException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "TimeOutExceptionMessage"));
            }
            catch (FaultException<WcfServiceFault> ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
            }
            catch (FaultException ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "FaultExceptionMessage")
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
            }
            catch (CommunicationException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "CommunicationExceptionMessage"));
            }
        }

        private void OnLoadOrgAcquirerWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if (e.Result == null)
            {
                return;
            }
            List<CmsOrgCustomerDto> result = (List<CmsOrgCustomerDto>)e.Result;
            LoadPartnerList(result);
            SelectMasterId = result.Count > 0 ? result.FirstOrDefault(p => p.OrgCode.Equals(MasterCode)).OrgId : 0;
            ToModel();
        }

        private void OnLoadAddOrgAcquirerWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = (int)Status.SUCCESS == OrganizationFactory.Instance.GetChannel().InsertOrgAcquirer(StorageService.CurrentSessionId, SelectMasterId, SelectPartnerList);
            }
            catch (TimeoutException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "TimeOutExceptionMessage"));
            }
            catch (FaultException<WcfServiceFault> ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
            }
            catch (FaultException ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "FaultExceptionMessage")
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
            }
            catch (CommunicationException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "CommunicationExceptionMessage"));
            }
        }

        private void OnLoadAddOrgAcquirerWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if ((bool)e.Result)
            {
                MessageBoxManager.ShowInfoMessageBox(this, "Đã thêm tổ chức chấp nhận thẻ mới thành công!");
                PostAction = DialogPostAction.SUCCESS;
                Hide();
            }
        }

        private void OnLoadUpdateOrgAcquirerWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = (int)Status.SUCCESS == OrganizationFactory.Instance.GetChannel().InsertOrgAcquirer(StorageService.CurrentSessionId, SelectMasterId, SelectPartnerList);
            }
            catch (TimeoutException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "TimeOutExceptionMessage"));
            }
            catch (FaultException<WcfServiceFault> ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
            }
            catch (FaultException ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "FaultExceptionMessage")
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
            }
            catch (CommunicationException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "CommunicationExceptionMessage"));
            }
        }

        private void OnLoadUpdateOrgAcquirerWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if ((bool)e.Result)
            {
                MessageBoxManager.ShowInfoMessageBox(this, "Đã cập nhật tổ chức chấp nhận thẻ thành công!");
                PostAction = DialogPostAction.SUCCESS;
                Hide();
            }
        }

        #endregion

        #region Buttons

        private void OnButtonConfirmClicked(object sender, EventArgs e)
        {
            switch (OperatingMode)
            {
                case ModeAdding:
                    AddOrgAcquirer();
                    break;
                case ModeUpdating:
                    UpdateOrgAcquirer();
                    break;
                default:
                    break;
            }

        }

        private void OnButtonRefreshClicked(object sender, EventArgs e)
        {
            ClearEmptyControl();
        }

        private void OnButtonCancelClicked(object sender, EventArgs e)
        {
            this.Hide();
        }

        #endregion

        #endregion

        #region Event's support

        #region Binding Data

        private void ToModel()
        {
            if (PartnerList != null && PartnerList.Count > 0)
            {
                SelectPartnerList = new List<long>();
                foreach (DataGridViewRow row in dgvPartnerList.Rows)
                {
                    if (MasterCode == row.Cells[ColOrgId.Index].Value.ToString())
                    {
                        SelectMasterId = Convert.ToInt64(row.Cells[ColOrgId.Index].Value.ToString());
                    }
                    if (PartnerList.Any(id => id == Convert.ToInt64(row.Cells[ColOrgId.Index].Value.ToString())))
                    {
                        SetSelectedRowPartnerData(row, true);
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow row in dgvPartnerList.Rows)
                {
                    if (MasterCode == row.Cells[ColOrgCode.Index].Value.ToString())
                    {
                        SelectMasterId = Convert.ToInt64(row.Cells[ColOrgId.Index].Value.ToString());
                    }
                }
            }
        }

        private void ToEntity()
        {
            if (dgvPartnerList.SelectedRows.Count > 0)
            {
                SelectPartnerList = new List<long>();
                foreach (DataGridViewRow row in dgvPartnerList.SelectedRows)
                {
                    SelectPartnerList.Add(Convert.ToInt64(dgvPartnerList.SelectedRows[0].Cells[ColOrgId.Index].Value.ToString()));
                }
            }
        }

        #endregion

        #region SetControl

        private void ClearEmptyControl()
        {
            if (dgvPartnerList.SelectedRows.Count > 0)
            {
                dgvPartnerList.SelectedRows[0].Selected = false;
            }
            checkBoxHeader_OnCheckBoxClicked(false);
        }

        private void SetControl(bool isView)
        {

        }

        private void SetShowOrHideButton(bool isView)
        {
            btnConfirm.Enabled = btnRefresh.Enabled = isView;
        }

        #endregion

        #region ValidateData

        private bool ValidateData()
        {
            if (SelectPartnerList.Count == 0)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessSelect(rm, MessageValidate.CoReleaseOrg), MessageValidate.GetErrorTitle(rm));
                return false;
            }
            return true;
        }

        #endregion

        #region OrgAcquirer

        private void InitFormAddOrgAcquirer()
        {
            this.Text = lbTitle.Text = "Thêm Tổ Chức Chấp Nhận Thẻ Mới";
            lbNote.Text = "Thêm một tổ chức chấp nhận thẻ mới vào hệ thống.";
            SetControl(false);
            SetShowOrHideButton(true);
            ClearEmptyControl();

            bgwLoadOrg = new BackgroundWorker();
            bgwLoadOrg.WorkerSupportsCancellation = true;
            bgwLoadOrg.DoWork += OnLoadOrgAcquirerWorkerDoWork;
            bgwLoadOrg.RunWorkerCompleted += OnLoadOrgAcquirerWorkerRunWorkerCompleted;

            bgwAddOrgAcquirer = new BackgroundWorker();
            bgwAddOrgAcquirer.WorkerSupportsCancellation = true;
            bgwAddOrgAcquirer.DoWork += OnLoadAddOrgAcquirerWorkerDoWork;
            bgwAddOrgAcquirer.RunWorkerCompleted += OnLoadAddOrgAcquirerWorkerRunWorkerCompleted;
        }

        private void InitFormUpdateOrgAcquirer()
        {
            this.Text = lbTitle.Text = "Cập Nhật Thông Tin Tổ Chức Chấp Nhận Thẻ";
            lbNote.Text = "Cập nhật tổ chức chấp nhận thẻ trong hệ thống.";
            SetControl(false);
            SetShowOrHideButton(true);

            bgwLoadOrg = new BackgroundWorker();
            bgwLoadOrg.WorkerSupportsCancellation = true;
            bgwLoadOrg.DoWork += OnLoadOrgAcquirerWorkerDoWork;
            bgwLoadOrg.RunWorkerCompleted += OnLoadOrgAcquirerWorkerRunWorkerCompleted;

            bgwUpdateOrgAcquirer = new BackgroundWorker();
            bgwUpdateOrgAcquirer.WorkerSupportsCancellation = true;
            bgwUpdateOrgAcquirer.DoWork += OnLoadUpdateOrgAcquirerWorkerDoWork;
            bgwUpdateOrgAcquirer.RunWorkerCompleted += OnLoadUpdateOrgAcquirerWorkerRunWorkerCompleted;
        }

        private void LoadOrg()
        {
            if (!bgwLoadOrg.IsBusy)
            {
                bgwLoadOrg.RunWorkerAsync();
            }
        }

        private void AddOrgAcquirer()
        {
            if (ValidateData() && MessageBoxManager.ShowQuestionMessageBox(this, "Bạn có chắc muốn thêm tổ chức chấp nhận thẻ này vào hệ thống không?") == System.Windows.Forms.DialogResult.Yes)
            {
                if (!bgwAddOrgAcquirer.IsBusy)
                {
                    bgwAddOrgAcquirer.RunWorkerAsync();
                }
            }
        }

        private void UpdateOrgAcquirer()
        {
            if (ValidateData() && MessageBoxManager.ShowQuestionMessageBox(this, "Bạn có chắc muốn cập nhật tổ chức chấp nhận thẻ này không?") == System.Windows.Forms.DialogResult.Yes)
            {
                if (!bgwUpdateOrgAcquirer.IsBusy)
                {
                    bgwUpdateOrgAcquirer.RunWorkerAsync();
                }
            }
        }

        #endregion

        #endregion

        #region InitializationDataGridView

        private DataGridViewTextBoxColumn ColOrgId { get; set; }
        private DataGridViewTextBoxColumn ColOrgCode { get; set; }
        private DataGridViewTextBoxColumn ColOrgName { get; set; }
        private DataGridViewTextBoxColumn ColOrgShortName { get; set; }
        private DataGridViewTextBoxColumn ColState { get; set; }
        private DataGridViewTextBoxColumn ColCity { get; set; }
        private DataGridViewTextBoxColumn ColPhoneNo { get; set; }
        private DataGridViewTextBoxColumn ColFax { get; set; }
        private DataGridViewTextBoxColumn ColWebsite { get; set; }
        private DataGridViewTextBoxColumn ColAddress { get; set; }

        public DataGridViewCheckBoxColumn CreateCheckBoxHeader()
        {
            DataGridViewCheckBoxColumn colCheckbox = new DataGridViewCheckBoxColumn();
            DatagridViewCheckBoxHeaderCell checkBoxHeader = new DatagridViewCheckBoxHeaderCell();
            checkBoxHeader.OnCheckBoxClicked += new CheckBoxClickedHandler(checkBoxHeader_OnCheckBoxClicked);
            colCheckbox.HeaderCell = checkBoxHeader;
            colCheckbox.HeaderText = string.Empty;
            colCheckbox.Width = 22;
            colCheckbox.DataPropertyName = "colCheckbox";
            return colCheckbox;
        }

        public DataGridViewTextBoxColumn CreateColunm(string dataPropertyName, string headerName, int wight, bool visiable)
        {
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            col.SortMode = DataGridViewColumnSortMode.Automatic;
            col.DataPropertyName = dataPropertyName;
            col.HeaderText = headerName;
            col.Name = string.Format("col{0}", dataPropertyName);
            col.Visible = visiable;
            col.Width = wight;

            return col;
        }

        public void InitDataGridView()
        {
            ColOrgId = CreateColunm("OrgId", string.Empty, 0, false);
            ColOrgCode = CreateColunm("OrgCode ", string.Empty, 0, false);
            ColOrgName = CreateColunm("OrgName", "Tên Tổ Chức", 80, true);
            ColOrgShortName = CreateColunm("OrgShortName", "Tên Viết Tắt", 100, true);
            ColState = CreateColunm("State", "Vùng/Miền", 80, true);
            ColCity = CreateColunm("City", "Thành Phố", 100, true);
            ColFax = CreateColunm("Fax", "Fax", 160, true);
            ColPhoneNo = CreateColunm("PhoneNo", "Điện Thoại", 100, true);
            ColWebsite = CreateColunm("ColWebsite", "Website", 160, true);
            ColAddress = CreateColunm("Address", "Địa Chỉ", 120, true);

            dgvPartnerList.Columns.Add(CreateCheckBoxHeader());
            dgvPartnerList.Columns.Add(ColOrgId);
            dgvPartnerList.Columns.Add(ColOrgCode);
            dgvPartnerList.Columns.Add(ColOrgName);
            dgvPartnerList.Columns.Add(ColOrgShortName);
            dgvPartnerList.Columns.Add(ColState);
            dgvPartnerList.Columns.Add(ColCity);
            dgvPartnerList.Columns.Add(ColFax);
            dgvPartnerList.Columns.Add(ColPhoneNo);
            dgvPartnerList.Columns.Add(ColWebsite);
            dgvPartnerList.Columns.Add(ColAddress);
        }

        public void LoadPartnerList(List<CmsOrgCustomerDto> orgList)
        {
            DataTable result = CreateOrgDataList();

            foreach (CmsOrgCustomerDto org in orgList)
            {
                if (org.Issuer.Equals(SystemSettings.Instance.Master) || org.Issuer.Equals(SystemSettings.Instance.Partner))
                    continue;

                DataRow row = result.NewRow();
                row.BeginEdit();

                row[ColOrgId.DataPropertyName] = org.OrgId;
                row[ColOrgCode.DataPropertyName] = org.OrgCode;
                row[ColOrgName.DataPropertyName] = org.Name;
                row[ColOrgShortName.DataPropertyName] = org.OrgShortName;
                row[ColState.DataPropertyName] = org.State;
                row[ColCity.DataPropertyName] = org.City;
                row[ColFax.DataPropertyName] = org.Fax;
                row[ColAddress.DataPropertyName] = org.Address;
                row[ColPhoneNo.DataPropertyName] = org.Phone;
                row[ColWebsite.DataPropertyName] = org.Email;

                row.EndEdit();
                result.Rows.Add(row);
            }
            dgvPartnerList.DataSource = result;
        }

        public DataTable CreateOrgDataList()
        {
            DataTable dbPartnerList = new DataTable();

            dbPartnerList.Columns.Add(ColOrgId.DataPropertyName);
            dbPartnerList.Columns.Add(ColOrgCode.DataPropertyName);
            dbPartnerList.Columns.Add(ColOrgName.DataPropertyName);
            dbPartnerList.Columns.Add(ColOrgShortName.DataPropertyName);
            dbPartnerList.Columns.Add(ColState.DataPropertyName);
            dbPartnerList.Columns.Add(ColCity.DataPropertyName);
            dbPartnerList.Columns.Add(ColFax.DataPropertyName);
            dbPartnerList.Columns.Add(ColAddress.DataPropertyName);
            dbPartnerList.Columns.Add(ColPhoneNo.DataPropertyName);
            dbPartnerList.Columns.Add(ColWebsite.DataPropertyName);

            return dbPartnerList;
        }

        #endregion
    }
}
