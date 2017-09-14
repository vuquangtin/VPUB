using CommonControls;
using CommonHelper.Constants;
using CommonHelper.Utils;
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
using System.Resources;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;

namespace eCashComponent
{
    public partial class FrmAddItem : CommonControls.Custom.CommonDialog
    {
        #region Properties

        public const byte ModeAdding = 1;
        public const byte ModeUpdating = 2;
        private byte OperatingMode;

        private ItemDto item;
        private ItemDto AddOrUpdateItem;
        private ResourceManager rm;

          
        //private long SubOrgId;
        private long ItemId;
        //long GroupId
        private long GroupId;
        //
        bool flag_SetText = true;

        private BackgroundWorker bgwLoadEcashItem;
        private BackgroundWorker bgwAddEcashItem;
        private BackgroundWorker bgwUpdateEcashItem;

        public DialogPostAction PostAction { get; private set; }

        private ILocalStorageService storageService;
        [ServiceDependency]
        public ILocalStorageService StorageService
        {
            get { return storageService; }
            set { storageService = value; }
        }

        #endregion

        #region Event
        private void RegisterEvent()
        {
            btnConfirm.Click += OnButtonConfirmClicked;
            btnRefresh.Click += btnRefresh_Click;
            btnCancel.Click += btnCancel_Click;
            tbxPrice.TextChanged += tbxPrice_TextChanged;
            Shown += OnFormShown;
        }

        private void OnFormShown(object sender, EventArgs e)
        {
            switch (OperatingMode)
            {
                case ModeAdding:
                    InitFormAddEcashItem();
                    break;
                case ModeUpdating:
                    InitFormUpdateEcashItem();
                    LoadEcashItem();
                    break;
                default:
                    throw new ArgumentException("Invalid operating mode!");
            }
            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
        }
        private void tbxPrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (flag_SetText)
                {
                    string strTemp = tbxPrice.Text;
                    if (String.IsNullOrEmpty(strTemp)) return;
                    int iIndex = strTemp.IndexOf('.');
                    if (iIndex == -1)
                    {
                    }
                    else
                    {
                        string strT = strTemp.Substring(iIndex + 1, 1);
                        if (!String.IsNullOrEmpty(strT))
                        {
                        }
                    }
                    double flTienThuong = double.Parse(tbxPrice.Text.Trim(','));
                    flag_SetText = false;
                    tbxPrice.Text = flTienThuong.ToString("N0");

                }
                else
                {
                    flag_SetText = true;

                    tbxPrice.Select(tbxPrice.TextLength, 0);

                }
            }
            catch (Exception ex)
            {

            }
        }
        #endregion Event
          
        #region Ecash

        public FrmAddItem(byte operationMode, long groupId = 0, long itemId = 0)
        {

            InitializeComponent();
            RegisterEvent();
            this.OperatingMode = operationMode;
            this.ItemId = itemId;
            this.GroupId = groupId;

        }
        private void OnLoadAddEcashItemWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = item = EcashConfigFactory.Instance.GetChannel().InsertItem(StorageService.CurrentSessionId, AddOrUpdateItem);
               
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
        private void OnLoadAddEcashItemWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if (e.Result != null)
            {
                MessageBoxManager.ShowInfoMessageBox(this, CommonMessages.InsertSuccess);
                PostAction = DialogPostAction.SUCCESS;
                Hide();
            }
        }
        private void OnLoadEcashGroupWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = item = EcashConfigFactory.Instance.GetChannel().GetItemByItemId(StorageService.CurrentSessionId, ItemId);
           //     e.Result = true;
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
        private void OnLoadEcashItemWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if (e.Result != null)
            {
                ToModel(item);
            }
        }
        private void OnLoadUpdateEcashItemWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = item = EcashConfigFactory.Instance.GetChannel().UpdateItem(StorageService.CurrentSessionId, AddOrUpdateItem);
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
        private void OnLoadUpdateEcashItemWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if (e.Result != null)
            {
                MessageBoxManager.ShowInfoMessageBox(this, CommonMessages.UpdateSuccess);
                PostAction = DialogPostAction.SUCCESS;
                Hide();
            }
        }
    
                      
        #endregion Ecash

        #region Validate Data

        private bool ValidateData()
        {

            if (tbxPrice.Text.Length > 19)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessProgram(rm, MessageValidate.CardConfigValidateAmount), MessageValidate.GetErrorTitle(rm));
                return false;
            }
            if (tbxItemName.Text.Length == 0)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessageValidate(rm, MessageValidate.MenuEcashNameItem), MessageValidate.GetErrorTitle(rm));
                return false;
            }

            if (tbxDescriptionItem.Text.Length >= 255)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessCharOverLoad(rm, MessageValidate.Description, 255), MessageValidate.GetErrorTitle(rm));
                return false;
            }

            if (string.IsNullOrEmpty(tbxPrice.Text))
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessageValidate(rm, MessageValidate.Amount), MessageValidate.GetErrorTitle(rm));
                return false;
            }

            if (!StringUtils.IsNumber(tbxPrice.Text))
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessProgram(rm, MessageValidate.CardConfigValidateAmountisNumber), MessageValidate.GetErrorTitle(rm));
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
            return true;
        }

        #endregion

        #region Binding Data

        private void ToModel(ItemDto item)
        {
            tbxItemName.Text = item.Name;
            tbxDescriptionItem.Text = item.Description;
            tbxPrice.Text = item.Price.ToString();
            dtpDateBegin.Value = item.StartDate.ToDateTimeFormatString();
            dtpDateEnd.Value = item.EndDate.ToDateTimeFormatString();
        }

        private ItemDto ToEntity()
        {
            ItemDto itemLocal = new ItemDto();
            itemLocal = item != null ? item : itemLocal;

            itemLocal.GroupId = GroupId;
            itemLocal.Name = tbxItemName.Text.Trim();
            itemLocal.Price = Convert.ToDouble(tbxPrice.Text);
            itemLocal.StartDate = dtpDateBegin.Value.ToStringFormatDateFullServer();
            itemLocal.EndDate = dtpDateEnd.Value.ToStringFormatDateFullServer();
            itemLocal.Description = tbxDescriptionItem.Text.Trim();

            return itemLocal;
        }

        #endregion Ecash
        
        #region SetControl
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearEmptyControl();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void OnButtonConfirmClicked(object sender, EventArgs e)
        {
            switch (OperatingMode)
            {
                case ModeAdding:
                    AddEcashItem();
                    break;
                case ModeUpdating:
                    UpdateEcashItem();
                    break;
                default:
                    break;
            }

        }
        private void ClearEmptyControl()
        {
            tbxItemName.Text = "";
         
            tbxDescriptionItem.Text = "";

            tbxPrice.Text = "";

            string[] ChuoiNgayHienTai = DateTime.Now.ToString().Split(' ');
            string NgayMacDinh = ChuoiNgayHienTai[0] + " " + "08:00:00";
            dtpDateBegin.Value = Convert.ToDateTime(NgayMacDinh);
            //
            // dtpDateEnd.Value = DateTime.Now;

            NgayMacDinh = ChuoiNgayHienTai[0] + " " + "23:59:59";
            dtpDateEnd.Value = Convert.ToDateTime(NgayMacDinh);
        }


        private void SetControl(bool isView)
        {
           tbxDescriptionItem.ReadOnly = isView;

                       
        }

        private void SetShowOrHideButton(bool isView)
        {
            btnConfirm.Enabled = btnRefresh.Enabled = isView;
        }

        #endregion SetControl

        #region Load-Add-Update-Ecash Item

        private void AddEcashItem()
        {
            if (ValidateData() != false && MessageBoxManager.ShowQuestionMessageBox(this, "Bạn có chắc muốn thêm dịch vụ này vào hệ thống không?") == System.Windows.Forms.DialogResult.Yes)
            {
                if (!bgwAddEcashItem.IsBusy)
                {
                    AddOrUpdateItem = ToEntity();
                    bgwAddEcashItem.RunWorkerAsync();
                }
            }
        }
        private void InitFormAddEcashItem()
        {
            this.Text = lbTitle.Text = "Thêm Thông Tin Dịch Vụ Mới";
            lbNote.Text = "Thêm thông tin dịch vụ mới vào hệ thống.";
            SetControl(false);
            SetShowOrHideButton(true);
            ClearEmptyControl();

            bgwAddEcashItem = new BackgroundWorker();
            bgwAddEcashItem.WorkerSupportsCancellation = true;
            bgwAddEcashItem.DoWork += OnLoadAddEcashItemWorkerDoWork;
            bgwAddEcashItem.RunWorkerCompleted += OnLoadAddEcashItemWorkerRunWorkerCompleted;


        }

        private void InitFormUpdateEcashItem()
        {
            this.Text = lbTitle.Text = "Cập Nhật Thông Tin Dịch Vụ Mới";
            lbNote.Text = "Cập nhật thông tin dịch vụ mới trong hệ thống.";
            SetControl(false);
            SetShowOrHideButton(true);

            bgwLoadEcashItem = new BackgroundWorker();
            bgwLoadEcashItem.WorkerSupportsCancellation = true;
            bgwLoadEcashItem.DoWork += OnLoadEcashGroupWorkerDoWork;
            bgwLoadEcashItem.RunWorkerCompleted += OnLoadEcashItemWorkerRunWorkerCompleted;

            bgwUpdateEcashItem = new BackgroundWorker();
            bgwUpdateEcashItem.WorkerSupportsCancellation = true;
            bgwUpdateEcashItem.DoWork += OnLoadUpdateEcashItemWorkerDoWork;
            bgwUpdateEcashItem.RunWorkerCompleted += OnLoadUpdateEcashItemWorkerRunWorkerCompleted;
        }
        private void LoadEcashItem()
        {
            if (!bgwLoadEcashItem.IsBusy && ItemId > 0)
            {
                bgwLoadEcashItem.RunWorkerAsync();
            }
        }
        private void UpdateEcashItem()
        {
            if (ValidateData() != false && MessageBoxManager.ShowQuestionMessageBox(this, MessageValidate.GetBaseMessAddGroup(rm, MessageValidate.CancelCardItem)) == System.Windows.Forms.DialogResult.Yes)
            {
                if (!bgwUpdateEcashItem.IsBusy)
                {
                    AddOrUpdateItem = ToEntity();
                    bgwUpdateEcashItem.RunWorkerAsync();
                }
            }
        }

        #endregion Load-Add-Update Item

        
    }
}
