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
using CommonHelper.Utils;
using System.Net.Mail;
using System.Text.RegularExpressions;
using CommonControls;
using Microsoft.Practices.CompositeUI;
using sWorldModel.TransportData.Constants;
using CommonHelper.Constants;
using System.Resources;

namespace eCashComponent.WorkItems.Config
{
    public partial class FrmAddConfig : CommonControls.Custom.CommonDialog
    {
        #region Properties

        public const byte ModeAdding = 1;
        public const byte ModeUpdating = 2;
        private byte OperatingMode;

        private Config_card config;
        private Config_card AddOrUpdateConfig;
        private ResourceManager rm;

        //private long Id;
        private long OrgId;
        //private long SubOrgId;
        private long ConfigId;
        //
        bool flag_SetText = true;

        private BackgroundWorker bgwLoadEcashConfig;
        private BackgroundWorker bgwAddEcashConfig;
        private BackgroundWorker bgwUpdateEcashConfig;

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
            txtAmount.TextChanged += txtAmount_TextChanged;
            Shown += OnFormShown;
        }

        private void OnFormShown(object sender, EventArgs e)
        {
            switch (OperatingMode)
            {
                case ModeAdding:
                    InitFormAddEcashConfig();
                    break;
                case ModeUpdating:
                    InitFormUpdateEcashConfig();
                    LoadEcashConfig();
                    break;
                default:
                    throw new ArgumentException("Invalid operating mode!");
            }
            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
        }
        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (flag_SetText)
                {
                    string strTemp = txtAmount.Text;
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
                    double flTienThuong = double.Parse(txtAmount.Text.Trim(','));
                    flag_SetText = false;
                    txtAmount.Text = flTienThuong.ToString("N0");

                }
                else
                {
                    flag_SetText = true;
                
                    txtAmount.Select(txtAmount.TextLength, 0);

                }
            }
            catch (Exception ex)
            {

            
            }
        }
        #endregion Event
          
        #region Ecash

        public FrmAddConfig(byte operationMode, long orgId = 0, long configId = 0)
        {

            InitializeComponent();
            RegisterEvent();
            this.OperatingMode = operationMode;
            this.ConfigId = configId;
            this.OrgId = orgId;

        }
        private void OnLoadAddEcashConfigWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = config = EcashConfigFactory.Instance.GetChannel().InsertEcashConfig(StorageService.CurrentSessionId, AddOrUpdateConfig);
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
        private void OnLoadAddEcashConfigWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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
        private void OnLoadEcashConfigWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = config = EcashConfigFactory.Instance.GetChannel().GetEcashConfigById(StorageService.CurrentSessionId, ConfigId);
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
        private void OnLoadEcashConfigWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if (e.Result != null)
            {
                ToModel(config);
            }
        }
        private void OnLoadUpdateEcashConfigWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = config = EcashConfigFactory.Instance.GetChannel().UpdateEcashConfig(StorageService.CurrentSessionId, AddOrUpdateConfig);
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
        private void OnLoadUpdateEcashConfigWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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
            if (string.IsNullOrEmpty(txtTranscriptName.Text))
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessageValidate(rm, MessageValidate.CardConfigNameConfig), MessageValidate.GetErrorTitle(rm));
                return false;
            }

            //if (string.IsNullOrEmpty(txtAmount.Text))
            //{
            //    MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessageValidate(rm, MessageValidate.Amount), MessageValidate.GetErrorTitle(rm));
            //    return false;
            //}

            //if (txtAmount.Text.Length >= 15)
            //{
            //    MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessProgram(rm, MessageValidate.CardConfigValidateAmount), MessageValidate.GetErrorTitle(rm));
            //    return false;
            //}

            //if (!StringUtils.IsNumber(txtAmount.Text))
            //{
            //    MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessageDataFail(rm, MessageValidate.CardConfigValidateAmountisNumber), MessageValidate.GetErrorTitle(rm));
            //    return false;
            //}

            if (txtNote.Text.Length >= 255)
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
           
          
            
            return true;
        }

        #endregion

        #region Binding Data

        private void ToModel(Config_card ecashconfig)
        {
            txtTranscriptName.Text = ecashconfig.Name;
            txtAmount.Text = ecashconfig.Amount.ToString();
            txtNote.Text = ecashconfig.Description;

            if (string.IsNullOrEmpty(ecashconfig.StartDate) || string.IsNullOrEmpty(ecashconfig.EndDate))
            {
                dtpDateBegin.Checked = false;
                dtpDateEnd.Checked = false;
            }
            else
            {
                dtpDateBegin.Checked = true;
                dtpDateEnd.Checked = true;
                dtpDateBegin.Value = ecashconfig.StartDate.ToDateTimeFormatString();
                dtpDateEnd.Value = ecashconfig.EndDate.ToDateTimeFormatString();
            }
        }

        private Config_card ToEntity()
        {
            Config_card ecashconfig = new Config_card();
            ecashconfig = config != null ? config : ecashconfig;

            ecashconfig.Id = ConfigId;
            ecashconfig.OrgId = OrgId;
            ecashconfig.Name = txtTranscriptName.Text.Trim();
            ecashconfig.Amount = 0;
          

            ecashconfig.Description = txtNote.Text.Trim();


            ecashconfig.StartDate = dtpDateBegin.Value.ToStringFormatDateFullServer();
        //    ecashconfig.StartDate = (dtpDateBegin.Value);
            ecashconfig.EndDate = dtpDateEnd.Value.ToStringFormatDateFullServer();

            ecashconfig.StartDate = dtpDateBegin.Value.ToStringFormatDateFullServer();
            ecashconfig.EndDate = dtpDateEnd.Value.ToStringFormatDateFullServer();


            return ecashconfig;
        }

        private void AddEcashConfig()
        {
            if (ValidateData() && MessageBoxManager.ShowQuestionMessageBox(this, MessageValidate.GetBaseMessAddGroup(rm, MessageValidate.CancelCardConfig)) == System.Windows.Forms.DialogResult.Yes)
            {
                if (!bgwAddEcashConfig.IsBusy)
                {
                    AddOrUpdateConfig = ToEntity();
                    bgwAddEcashConfig.RunWorkerAsync();
                }
            }
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
                    AddEcashConfig();
                    break;
                case ModeUpdating:
                    UpdateEcashConfig();
                    break;
                default:
                    break;
            }

        }
        private void ClearEmptyControl()
        {
            txtTranscriptName.Text = "";
            txtAmount.Text = "";
            txtNote.Text = "";
            //
           // dtpDateBegin.Value = DateTime.Now;
            string[] ChuoiNgayHienTai = DateTime.Now.ToString().Split(' ');
            string NgayMacDinh = ChuoiNgayHienTai[0] +" "+ "08:00:00";
            dtpDateBegin.Value = Convert.ToDateTime(NgayMacDinh);
            //
           // dtpDateEnd.Value = DateTime.Now;

             NgayMacDinh = ChuoiNgayHienTai[0] + " " + "23:59:59";
            dtpDateEnd.Value = Convert.ToDateTime(NgayMacDinh);
        }


        private void SetControl(bool isView)
        {
            txtAmount.ReadOnly =
            txtNote.ReadOnly = isView;


            dtpDateBegin.Enabled =
            dtpDateEnd.Enabled = !isView;
        }

        private void SetShowOrHideButton(bool isView)
        {
            btnConfirm.Enabled = btnRefresh.Enabled = isView;
        }

        #endregion SetControl

        #region Load-Add-Update-EcashConfig

        private void InitFormAddEcashConfig()
        {
            this.Text = lbTitle_FrmAddOrEditConfig.Text = "Thêm Thông Tin Cấu Hình Dịch Vụ Mới";
            lblNote_FrmAddOrEditConfig.Text = "Thêm thông tin cấu hình dịch vụ mới vào hệ thống.";
            SetControl(false);
            SetShowOrHideButton(true);
            ClearEmptyControl();

            bgwAddEcashConfig = new BackgroundWorker();
            bgwAddEcashConfig.WorkerSupportsCancellation = true;
            bgwAddEcashConfig.DoWork += OnLoadAddEcashConfigWorkerDoWork;
            bgwAddEcashConfig.RunWorkerCompleted += OnLoadAddEcashConfigWorkerRunWorkerCompleted;
        }

        private void InitFormUpdateEcashConfig()
        {
            this.Text = lbTitle_FrmAddOrEditConfig.Text = "Cập Nhật Thông Tin Cấu Hình Dịch Vụ";
            lblNote_FrmAddOrEditConfig.Text = "Cập nhật thông tin cấu hình dịch vụ trong hệ thống.";
            SetControl(false);
            SetShowOrHideButton(true);

            bgwLoadEcashConfig = new BackgroundWorker();
            bgwLoadEcashConfig.WorkerSupportsCancellation = true;
            bgwLoadEcashConfig.DoWork += OnLoadEcashConfigWorkerDoWork;
            bgwLoadEcashConfig.RunWorkerCompleted += OnLoadEcashConfigWorkerRunWorkerCompleted;

            bgwUpdateEcashConfig = new BackgroundWorker();
            bgwUpdateEcashConfig.WorkerSupportsCancellation = true;
            bgwUpdateEcashConfig.DoWork += OnLoadUpdateEcashConfigWorkerDoWork;
            bgwUpdateEcashConfig.RunWorkerCompleted += OnLoadUpdateEcashConfigWorkerRunWorkerCompleted;
        }
        private void LoadEcashConfig()
        {
            if (!bgwLoadEcashConfig.IsBusy && ConfigId > 0)
            {
                bgwLoadEcashConfig.RunWorkerAsync();
            }
        }
        private void UpdateEcashConfig()
        {
            if (ValidateData() && MessageBoxManager.ShowQuestionMessageBox(this, "Bạn có chắc muốn cập nhật cấu hình dịch vụ này không?") == System.Windows.Forms.DialogResult.Yes)
            {
                if (!bgwUpdateEcashConfig.IsBusy)
                {
                    AddOrUpdateConfig = ToEntity();
                    bgwUpdateEcashConfig.RunWorkerAsync();
                }
            }
        }
        #endregion Load-Add-Update-Voucher




    }
}
