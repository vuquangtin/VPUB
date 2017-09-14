using System;
using System.ComponentModel;
using sWorldModel.TransportData;
using CommonControls;
using System.ServiceModel;
using sWorldModel.Exceptions;
using JavaCommunication.Factory;
using sWorldModel;
using Microsoft.Practices.CompositeUI;
using System.Resources;
using CommonHelper.Constants;
using CommonHelper.Utils;

namespace sAccessComponent.WorkItems {
    public partial class FrmAddOrEditMontlyDebt : CommonControls.Custom.CommonDialog
    {
        #region Properties

        private ResourceManager rm;

        private sWorldConfig sWorldConfig;

        private BackgroundWorker bgwLoadConfig;
        private BackgroundWorker bgwUpdateConfig;

        public DialogPostAction PostAction { get; private set; }

        private ILocalStorageService storageService;
        [ServiceDependency]
        public ILocalStorageService StorageService
        {
            get { return storageService; }
            set { storageService = value; }
        }

        #endregion      

        public FrmAddOrEditMontlyDebt()
        {
            InitializeComponent();
            RegisterEvent();
        }

        private void RegisterEvent()
        {
            btnCancel.Click += OnButtonCancelClicked;
            btnConfirm.Click += OnButtonConfirmClicked;
            Shown += OnFormShown;

            bgwLoadConfig = new BackgroundWorker();
            bgwLoadConfig.WorkerSupportsCancellation = true;
            bgwLoadConfig.DoWork += bgwLoadConfig_DoWork;
            bgwLoadConfig.RunWorkerCompleted += bgwLoadConfig_RunWorkerCompleted;

            bgwUpdateConfig = new BackgroundWorker();
            bgwUpdateConfig.WorkerSupportsCancellation = true;
            bgwUpdateConfig.DoWork += bgwUpdateConfig_DoWork;
            bgwUpdateConfig.RunWorkerCompleted += bgwUpdateConfig_RunWorkerCompleted;
        }
        protected override void OnLoad(EventArgs e) {
            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);

            // Set Language
            SetLanguage();
        }

        #region Set Language
        private void SetLanguage() {
            this.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.Name);
            this.lblInfoNoQuaHan.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.lblInfoNoQuaHan.Name);
            this.lblNoQuaHanConfig.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.lblNoQuaHanConfig.Name);
            this.btnConfirm.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnConfirm.Name);
            this.btnCancel.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnCancel.Name);
        }
        #endregion

        #region Event's

        private void OnFormShown(object sender, EventArgs e)
        {
            LoadAccessConfig();
            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
        }

        private void OnButtonConfirmClicked(object sender, EventArgs e)
        {
            UpdateAccessConfig();
        }

        private void OnButtonCancelClicked(object sender, EventArgs e)
        {
            this.Hide();
        }

        void bgwLoadConfig_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = sWorldConfig = AccessFactory.Instance.GetChannel().GetAccessConfig(StorageService.CurrentSessionId);
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

        void bgwLoadConfig_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if (e.Result != null)
            {
                numMontlyDebt.Value = Convert.ToDecimal(sWorldConfig.Value);
            }
        }

        void bgwUpdateConfig_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = sWorldConfig = AccessFactory.Instance.GetChannel().UpdateAccessConfig(StorageService.CurrentSessionId,sWorldConfig);
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

        void bgwUpdateConfig_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if (e.Result != null)
            {
                MessageBoxManager.ShowInfoMessageBox(this, "Đã cập nhật ngày tổng nợ phí thành công!");
                numMontlyDebt.Value = Convert.ToDecimal(sWorldConfig.Value);
            }
        }

        #endregion

        #region Event's support

        private void LoadAccessConfig()
        {
            if (!bgwLoadConfig.IsBusy)
            {
                bgwLoadConfig.RunWorkerAsync();
            }
        }

        private void UpdateAccessConfig()
        {
            if (!bgwUpdateConfig.IsBusy)
            {
                sWorldConfig.Value = numMontlyDebt.Value.ToString();
                bgwUpdateConfig.RunWorkerAsync();
            }
        }

        #endregion
    }
}
