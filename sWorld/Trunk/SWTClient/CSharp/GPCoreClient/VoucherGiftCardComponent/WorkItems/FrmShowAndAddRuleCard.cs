using CommonControls;
using CommonHelper.Config;
using JavaCommunication;
using JavaCommunication.Factory;
using Microsoft.Practices.CompositeUI;
using sWorldModel;
using sWorldModel.Exceptions;
using sWorldModel.TransportData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;

namespace VoucherGiftCardComponent.WorkItems
{
    public partial class FrmShowAndAddRuleCard : CommonControls.Custom.CommonDialog
    {
        #region Properties

        public const byte ModeAdding = 1;
        public const byte ModeUpdating = 2;
        private byte OperatingMode;
        private int currentPageIndex = 1;

        private List<MemberMobilePersonalizationDTO> RuleMemberList;
        private DataTable dtbCardRuleList;
        //private VoucherGift AddOrUpdateVoucher;

        private long VoucherId;
        private BackgroundWorker bgwLoadCardRuleList;
        private BackgroundWorker bgwAddCardRuleList;

        public DialogPostAction PostAction { get; private set; }

        private ILocalStorageService storageService;
        [ServiceDependency]
        public ILocalStorageService StorageService
        {
            get { return storageService; }
            set { storageService = value; }
        }

        #endregion

        public FrmShowAndAddRuleCard(byte operationMode, List<MemberMobilePersonalizationDTO> RuleMemberList)
        {
            InitializeComponent();
            this.OperatingMode = operationMode;
            this.RuleMemberList = RuleMemberList;
            InitDataTableVoucherGift();
            RegisterEvent();
            
            //LoadMemberDataGridView(RuleMemberList);
        }

        private void RegisterEvent()
        {           
            //btnConfirm.Click += OnButtonConfirmClicked;
            //btnRefresh.Click += OnButtonRefreshClicked;
            //btnCancel.Click += OnButtonCancelClicked;
            //cbTypeCardVoucherGift.SelectedIndexChanged = cbTypeCardVoucherGift_SelectedIndexChanged();
            
            //Add Mobile Personalization
            bgwAddCardRuleList = new BackgroundWorker();
            bgwAddCardRuleList.WorkerSupportsCancellation = true;
            bgwAddCardRuleList.DoWork += OnLoadAddVoucherWorkerDoWork;
            bgwAddCardRuleList.RunWorkerCompleted += OnLoadAddVoucherWorkerCompleted;

            btnSaveCardRules.Click += btnAdd_Click;
            
            Shown += OnFormShown;
        }

        private void OnFormShown(object sender, EventArgs e)
        {
            //this.Text = lblTieuDe.Text = "Cập Nhật Thông Tin Cấu Hình Phiếu";
            //lbNote.Text = "Cập nhật thông tin cấu hình phiếu trong hệ thống.";
            //SetControl(false);
            //SetShowOrHideButton(true);

            bgwLoadCardRuleList = new BackgroundWorker();
            bgwLoadCardRuleList.WorkerSupportsCancellation = true;
            bgwLoadCardRuleList.DoWork += OnLoadCardRuleWorkerDoWork;
            bgwLoadCardRuleList.RunWorkerCompleted += OnLoadCardRuleWorkerRunWorkerCompleted;

            LoadCardRuleVoucher();
        }

        private void InitDataTableVoucherGift()
        {
            dtbCardRuleList = new DataTable();
            dtbCardRuleList.Columns.Add(colId.DataPropertyName);
            dtbCardRuleList.Columns.Add(colLastName.DataPropertyName);
            dtbCardRuleList.Columns.Add(colFirstName.DataPropertyName);
            dtbCardRuleList.Columns.Add(colTelephone.DataPropertyName);
            dtbCardRuleList.Columns.Add(colQrCode.DataPropertyName);
            dtbCardRuleList.Columns.Add(colBarCode.DataPropertyName);
            dtbCardRuleList.Columns.Add(colSerial.DataPropertyName);
            dgvCardRules.DataSource = dtbCardRuleList;
        }

        private void ToModel(MemberMobilePersonalizationDTO voucher)
        {
            //txtTitle.Text = voucher.title;// cbTypeCardVoucherGift.SelectedItem.ToString() = voucher.type;
            ////cbTypeCardVoucherGift.SelectedIndex = 0;
            //cbTypeCardVoucherGift.SelectedIndex = Convert.ToInt32(voucher.type) - 4;
            //cbLocation.SelectedIndex = Convert.ToInt32(voucher.area) - 6;

            //if (string.IsNullOrEmpty(voucher.dateBegin) || string.IsNullOrEmpty(voucher.dateEnd))
            //{
            //    dtpDateBegin.Checked = false;
            //    dtpDateEnd.Checked = false;
            //}
            //else
            //{
            //    dtpDateBegin.Checked = true;
            //    dtpDateEnd.Checked = true;
            //    dtpDateBegin.Value = voucher.dateBegin.ToDateFormatString();
            //    dtpDateEnd.Value = voucher.dateEnd.ToDateFormatString();
            //}

            ////rbtnGenderMale.Checked = GenderExtMethod.ToGender(voucher.gender) == Gender.Male;
            ////rbtnGenderFemale.Checked = GenderExtMethod.ToGender(voucher.gender) == Gender.Female;
            ////rbtnGenderOther.Checked = GenderExtMethod.ToGender(voucher.gender) == Gender.Other;
            //string s = voucher.gender.ToString();
            //if (s.Length > 1)
            //{
            //    cbxMale.Checked = cbxFemale.Checked = true;
            //}
            //else
            //{
            //    cbxMale.Checked = GenderExtMethod.ToGender(voucher.gender) == Gender.Male;
            //    cbxFemale.Checked = GenderExtMethod.ToGender(voucher.gender) == Gender.Female;
            //}

            //txtDescription.Text = voucher.description;
        }

        private void LoadMemberDataGridView(List<MemberMobilePersonalizationDTO> result)
        {
            foreach (MemberMobilePersonalizationDTO mb in result)
            {
                DataRow row = dtbCardRuleList.NewRow();
                row.BeginEdit();
                row[colId.DataPropertyName] = mb.Id;
                row[colLastName.DataPropertyName] = mb.LastName;
                row[colFirstName.DataPropertyName] = mb.FirstName;
                row[colTelephone.DataPropertyName] = mb.telephone;
                row[colQrCode.DataPropertyName] = mb.qrcode;
                row[colBarCode.DataPropertyName] = mb.barcode;
                row[colSerial.DataPropertyName] = mb.serial;

                row.EndEdit();
                dtbCardRuleList.Rows.Add(row);
            }
        }

        private void OnLoadCardRuleWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            int totalRecords = 0;
            int take = LocalSettings.Instance.RecordsPerPage;
            int skip = 0;
            currentPageIndex = 1;
            List<MemberMobilePersonalizationDTO> result = null;

            if (RuleMemberList != null)
            {
                result = RuleMemberList.Skip(skip).Take(take).ToList();
                totalRecords = RuleMemberList.Count;
                pagerPanel1.ShowNumberOfRecords(totalRecords, result != null ? result.Count : 0, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
                pagerPanel1.UpdatePagingLinks(totalRecords, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
            }
            e.Result = result;
        }

        private void OnLoadCardRuleWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                //btnSyncData.Enabled = false;
                return;
            }
            if (e.Result == null)
            {
                //btnSyncData.Enabled = false;
                return;
            }

            List<MemberMobilePersonalizationDTO> result = (List<MemberMobilePersonalizationDTO>)e.Result;
            LoadMemberDataGridView(result);
        }

        private void OnLoadAddVoucherWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {                                                               //, Convert.ToInt64(selectedVoucherNode.Name)
                e.Result = (int)Status.SUCCESS == VoucherGiftFactory.Instance.GetChannel().InsertRuleVoucher(storageService.CurrentSessionId, RuleMemberList);
                //flagInsert = (bool)e.Result;
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

        private void OnLoadAddVoucherWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if ((bool)e.Result)
            {
                //MessageBoxManager.ShowInfoMessageBox(this, CommonMessages.InsertSuccess);
                //LoadCardRuleVoucher();
                PostAction = DialogPostAction.SUCCESS;
                Hide();
                //btnSyncData.Enabled = false;
            }
            else
            {
                MessageBoxManager.ShowInfoMessageBox(this, CommonMessages.InsertFailed);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (MessageBoxManager.ShowQuestionMessageBox(this, CommonMessages.InformAddDataInto) == System.Windows.Forms.DialogResult.Yes)
            {
                if (!bgwAddCardRuleList.IsBusy)
                {
                    dtbCardRuleList.Rows.Clear();
                    bgwAddCardRuleList.RunWorkerAsync();
                }
            }
        }

        private void LoadCardRuleVoucher()
        {
            if (!bgwLoadCardRuleList.IsBusy && RuleMemberList != null)
            {
                bgwLoadCardRuleList.RunWorkerAsync();
            }
        }
    }
}
