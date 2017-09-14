using System;
using System.Collections.Generic;
using System.ComponentModel;
using sWorldModel;
using sWorldModel.TransportData;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JavaCommunication.Factory;
using System.ServiceModel;
using sWorldModel.Exceptions;
using JavaCommunication;
//using sWorldModel.TransportData.Constants;
using CommonHelper.Utils;
using System.Net.Mail;
using System.Text.RegularExpressions;
using CommonControls;
using Microsoft.Practices.CompositeUI;
using sWorldModel.TransportData.Constants;
using CommonHelper.Constants;
using System.Resources;

namespace VoucherGiftCardComponent.WorkItems
{
    public partial class FrmAddOrUpdateRuleVoucherGift : CommonControls.Custom.CommonDialog
    {
        #region Properties

        public const byte ModeAdding = 1;
        public const byte ModeUpdating = 2;
        private byte OperatingMode;

        private VoucherGift OriginalVoucher;
        private VoucherGift AddOrUpdateVoucher;
        private ResourceManager rm;
 
        //private long Id;
        private long OrgId;
        //private long SubOrgId;
        private long VoucherId;

        private BackgroundWorker bgwLoadVoucher;
        private BackgroundWorker bgwAddVoucher;
        private BackgroundWorker bgwUpdateVoucher;

        public DialogPostAction PostAction { get; private set; }

        private ILocalStorageService storageService;
        [ServiceDependency]
        public ILocalStorageService StorageService
        {
            get { return storageService; }
            set { storageService = value; }
        }

        #endregion

        public FrmAddOrUpdateRuleVoucherGift(byte operationMode, long orgId = 0, long voucherId = 0)
        {
            InitializeComponent();
            RegisterEvent();
            this.OperatingMode = operationMode;            
            this.OrgId = orgId;
            this.VoucherId = voucherId;
        }

        private void RegisterEvent()
        {           
            btnConfirm.Click += OnButtonConfirmClicked;
            btnRefresh.Click += OnButtonRefreshClicked;
            btnCancel.Click += OnButtonCancelClicked;
            //cbTypeCardVoucherGift.SelectedIndexChanged = cbTypeCardVoucherGift_SelectedIndexChanged();
            Shown += OnFormShown;
        }

        #region Event's

        private void OnFormShown(object sender, EventArgs e)
        {
            LoadCombobox();
            //Load += OnFormLoad;
            switch (OperatingMode)
            {
                case ModeAdding:
                    InitFormAddVoucher();
                    break;
                case ModeUpdating:
                    InitFormUpdateVoucher();
                    LoadVoucher();
                    break;
                default:
                    throw new ArgumentException("Invalid operating mode!");
            }
            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
        }

        private void LoadCombobox()
        {   
            // Loai Card status to combobox
            List<TypeCard> tatusTypeCard = VoucherCombobox.GetVoucherList();
            DataTable dtbVoucher = new DataTable();
            dtbVoucher.Columns.Add("Id");
            dtbVoucher.Columns.Add("Name");
            foreach (TypeCard ct in tatusTypeCard)
            {
                DataRow row = dtbVoucher.NewRow();
                row.BeginEdit();
                row["Id"] = (int)ct;
                row["Name"] = ct.GetName();
                row.EndEdit();
                dtbVoucher.Rows.Add(row);
            }
            cbTypeCardVoucherGift.DataSource = dtbVoucher;
            cbTypeCardVoucherGift.ValueMember = "Id";
            cbTypeCardVoucherGift.DisplayMember = "Name";

            // Vi tri status to combobox
            List<Location> tatusLocation = VoucherCombobox.GetLocationList();
            DataTable dtbLocation = new DataTable();
            dtbLocation.Columns.Add("Id");
            dtbLocation.Columns.Add("Name");
            foreach (Location ct in tatusLocation)
            {
                DataRow row = dtbLocation.NewRow();
                row.BeginEdit();
                row["Id"] = (int)ct;
                row["Name"] = ct.GetName();
                row.EndEdit();
                dtbLocation.Rows.Add(row);
            }
            cbLocation.DataSource = dtbLocation;
            cbLocation.ValueMember = "Id";
            cbLocation.DisplayMember = "Name";

            cbTypeCardVoucherGift.SelectedIndex = cbLocation.SelectedIndex = 0;
            //cbLocation.Items.Insert(0, "TP Ho Chi Minh");
            //cbLocation.Items.Insert(1, "Ha Noi");
        }

        #region Voucher

        private void OnLoadVoucherWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                OriginalVoucher = VoucherGiftFactory.Instance.GetChannel().GetVourcherByVourcherId(StorageService.CurrentSessionId, VoucherId);
                e.Result = true;
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

        private void OnLoadVoucherWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if (e.Result != null)
            {
                ToModel(OriginalVoucher);
            }
        }

        private void OnLoadAddVoucherWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                OriginalVoucher = VoucherGiftFactory.Instance.GetChannel().InsertVoucherGift(StorageService.CurrentSessionId, AddOrUpdateVoucher);
                e.Result = true;
            }
            catch (NullReferenceException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.CantNotInsertData);
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

        private void OnLoadAddVoucherWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if ((bool)e.Result)
            {
                MessageBoxManager.ShowInfoMessageBox(this, CommonMessages.InsertSuccess);
                PostAction = DialogPostAction.SUCCESS;
                Hide();
            }
        }

        private void OnLoadUpdateMemberWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                //e.Result = (int)Status.SUCCESS = VoucherGiftFactory.Instance.GetChannel().UpdateVoucherGift(StorageService.CurrentSessionId, AddOrUpdateVoucher);
                OriginalVoucher = VoucherGiftFactory.Instance.GetChannel().UpdateVoucherGift(StorageService.CurrentSessionId, AddOrUpdateVoucher);
                e.Result = true;
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

        private void OnLoadUpdateMemberWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if ((bool)e.Result)
            {
                MessageBoxManager.ShowInfoMessageBox(this, CommonMessages.UpdateSuccess);
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
                    AddVoucher();
                    break;
                case ModeUpdating:
                    UpdateVoucher();
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

        #endregion Event's

        #region Event's support

        #region Binding Data

        private void ToModel(VoucherGift voucher)
        {
            txtTitle.Text = voucher.title;// cbTypeCardVoucherGift.SelectedItem.ToString() = voucher.type;
            //cbTypeCardVoucherGift.SelectedIndex = 0;
            cbTypeCardVoucherGift.SelectedIndex = Convert.ToInt32(voucher.type) - 4;
            cbLocation.SelectedIndex = Convert.ToInt32(voucher.area) - 6; 

            if (string.IsNullOrEmpty(voucher.dateBegin) || string.IsNullOrEmpty(voucher.dateEnd))
            {
                dtpDateBegin.Checked = false;
                dtpDateEnd.Checked = false;
            }
            else
            {
                dtpDateBegin.Checked = true;
                dtpDateEnd.Checked = true;
                dtpDateBegin.Value = voucher.dateBegin.ToDateFormatString();
                dtpDateEnd.Value = voucher.dateEnd.ToDateFormatString();
            }

            //rbtnGenderMale.Checked = GenderExtMethod.ToGender(voucher.gender) == Gender.Male;
            //rbtnGenderFemale.Checked = GenderExtMethod.ToGender(voucher.gender) == Gender.Female;
            //rbtnGenderOther.Checked = GenderExtMethod.ToGender(voucher.gender) == Gender.Other;
            string s = voucher.gender.ToString();
            if (s.Length > 1)
            {
                cbxMale.Checked = cbxFemale.Checked = true;
            }
            else
            {
                cbxMale.Checked = GenderExtMethod.ToGender(voucher.gender) == Gender.Male;
                cbxFemale.Checked = GenderExtMethod.ToGender(voucher.gender) == Gender.Female;
            }

            txtDescription.Text = voucher.description;
        }

        private VoucherGift ToEntity()
        {
            VoucherGift voucher = new VoucherGift();
            voucher = OriginalVoucher != null ? OriginalVoucher : voucher;

            voucher.id = VoucherId;
            voucher.orgId = OrgId;
            voucher.title = txtTitle.Text.Trim();
            voucher.type = cbTypeCardVoucherGift.SelectedValue.ToString();
            voucher.area = cbLocation.SelectedValue.ToString();

            voucher.description = txtDescription.Text.Trim();

            voucher.dateBegin = dtpDateBegin.Value.ToStringFormatDate();
            voucher.dateEnd = dtpDateEnd.Value.ToStringFormatDate();

            //voucher.gender = rbtnGenderMale.Checked ? (int)Gender.Male
            //    : rbtnGenderFemale.Checked ? (int)Gender.Female
            //    : rbtnGenderOther.Checked ? (int)Gender.Other : 0;\
            
            //cbxMale.Checked = GenderExtMethod.ToGender(voucher.gender) == Gender.Male;
            //cbxFemale.Checked = GenderExtMethod.ToGender(voucher.gender) == Gender.Female;
            
            if (cbxMale.Checked && cbxFemale.Checked)
            {
                voucher.gender = 12;
            }
            else
            {
                voucher.gender = cbxMale.Checked ? (int)Gender.Male : cbxFemale.Checked ? (int)Gender.Female : 0;
            }
            
            return voucher;
        }

        #endregion

        #region SetControl

        private void ClearEmptyControl()
        {
            cbTypeCardVoucherGift.SelectedIndex = cbLocation.SelectedIndex = 0;

            cbxMale.Checked = false;
            cbxFemale.Checked = false;            

            txtTitle.Text =
            txtDescription.Text = string.Empty;

            dtpDateBegin.Text = DateTime.Now.ToString();
            dtpDateEnd.Text = DateTime.Now.ToString();
        }

        private void SetControl(bool isView)
        {
            txtTitle.ReadOnly = 
            txtDescription.ReadOnly = isView;

            cbTypeCardVoucherGift.Enabled =
            cbLocation.Enabled =
            dtpDateBegin.Enabled =
            dtpDateEnd.Enabled = !isView;            
        }

        private void SetShowOrHideButton(bool isView)
        {
            btnConfirm.Enabled = btnRefresh.Enabled = isView;
        }

        #endregion SetControl

        #region Validate Data

        private bool ValidateData()
        {
            if (string.IsNullOrEmpty(txtTitle.Text))
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessageValidate(rm, MessageValidate.Title), MessageValidate.GetErrorTitle(rm));
                return false;
            }

            if (txtDescription.Text.Length >= 255)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessCharOverLoad(rm, MessageValidate.Description, 255), MessageValidate.GetErrorTitle(rm));
                return false;
            }

            DateTime testStart = DateTime.Now;
            DateTime testEnd = DateTime.Now.AddDays(10);           

            double totalDay = (testEnd - testStart).TotalDays;

            if (Convert.ToDateTime(dtpDateBegin.Value) > Convert.ToDateTime(dtpDateEnd.Value))
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessDateFail(rm, MessageValidate.Less), MessageValidate.GetErrorTitle(rm));
                return false;
            }

            if ((cbxMale.Checked == false) && (cbxFemale.Checked == false))
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessSelect(rm, MessageValidate.Gender), MessageValidate.GetErrorTitle(rm));
                return false;
            }

            return true;
        }

        #endregion

        #region Load-Add-Update-Voucher

        private void InitFormAddVoucher()
        {
            this.Text = lblTieuDe.Text = "Thêm Thông Tin Cấu Hình Phiếu Mới";
            lbNote.Text = "Thêm thông tin cấu hình phiếu mới vào hệ thống.";
            SetControl(false);
            SetShowOrHideButton(true);
            ClearEmptyControl();

            bgwAddVoucher = new BackgroundWorker();
            bgwAddVoucher.WorkerSupportsCancellation = true;
            bgwAddVoucher.DoWork += OnLoadAddVoucherWorkerDoWork;
            bgwAddVoucher.RunWorkerCompleted += OnLoadAddVoucherWorkerRunWorkerCompleted;
        }

        private void InitFormUpdateVoucher()
        {
            this.Text = lblTieuDe.Text = "Cập Nhật Thông Tin Cấu Hình Phiếu";
            lbNote.Text = "Cập nhật thông tin cấu hình phiếu trong hệ thống.";
            SetControl(false);
            SetShowOrHideButton(true);

            bgwLoadVoucher = new BackgroundWorker();
            bgwLoadVoucher.WorkerSupportsCancellation = true;
            bgwLoadVoucher.DoWork += OnLoadVoucherWorkerDoWork;
            bgwLoadVoucher.RunWorkerCompleted += OnLoadVoucherWorkerRunWorkerCompleted;

            bgwUpdateVoucher = new BackgroundWorker();
            bgwUpdateVoucher.WorkerSupportsCancellation = true;
            bgwUpdateVoucher.DoWork += OnLoadUpdateMemberWorkerDoWork;
            bgwUpdateVoucher.RunWorkerCompleted += OnLoadUpdateMemberWorkerRunWorkerCompleted;
        }

        private void LoadVoucher()
        {
            if (!bgwLoadVoucher.IsBusy && VoucherId > 0)
            {
                bgwLoadVoucher.RunWorkerAsync();
            }
        }

        private void AddVoucher()
        {
            if (ValidateData() && MessageBoxManager.ShowQuestionMessageBox(this, "Bạn có chắc muốn thêm cấu hình phiếu này vào hệ thống không?") == System.Windows.Forms.DialogResult.Yes)
            {
                if (!bgwAddVoucher.IsBusy)
                {
                    AddOrUpdateVoucher = ToEntity();
                    bgwAddVoucher.RunWorkerAsync();
                }
            }
        }

        private void UpdateVoucher()
        {
            if (ValidateData() && MessageBoxManager.ShowQuestionMessageBox(this, "Bạn có chắc muốn cập nhật cấu hình phiếu này không?") == System.Windows.Forms.DialogResult.Yes)
            {
                if (!bgwUpdateVoucher.IsBusy)
                {
                    AddOrUpdateVoucher = ToEntity();
                    bgwUpdateVoucher.RunWorkerAsync();
                }
            }
        }

        #endregion

        #endregion
    }
}
