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
using System.Resources;
using CommonHelper.Constants;
using CommonHelper.Utils;

namespace SystemMgtComponent.WorkItems.Application
{
    public partial class FrmAddOrEditApp : CommonControls.Custom.CommonDialog
    {
        #region Properties

        public const byte ModeAdding = 1;
        public const byte ModeUpdating = 2;

        private const int SetMaxWightTxtName = 323;

        private byte OperatingMode;
        private long AppId;
        private ResourceManager rm;

        private App OriginalApp;
        private App AddOrUpdateApp;

        private BackgroundWorker bgwLoadApp;
        private BackgroundWorker bgwAddApp;
        private BackgroundWorker bgwUpdateApp;

        public DialogPostAction PostAction { get; private set; }

        private ILocalStorageService storageService;
        [ServiceDependency]
        public ILocalStorageService StorageService
        {
            get { return storageService; }
            set { storageService = value; }
        }

        #endregion      

        public FrmAddOrEditApp(byte operationMode, long appId = 0)
        {
            InitializeComponent();
            RegisterEvent();
            this.AppId = appId;
            this.OperatingMode = operationMode;
        }

        private void RegisterEvent()
        {
            btnCancel.Click += OnButtonCancelClicked;
            btnConfirm.Click += OnButtonConfirmClicked;
            btnRefresh.Click += OnButtonRefreshClicked;
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
                    InitFormAddApp();
                    break;
                case ModeUpdating:
                    InitFormUpdateApp();
                    LoadApp();
                    break;
                default:
                    throw new ArgumentException("Invalid operating mode!");
            }

            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
            this.Text = MessageValidate.GetMessage(rm, this.Name);
        }

        #region Application

        private void OnLoadAppWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                OriginalApp = ApplicationFactory.Instance.GetChannel().GetAppById(StorageService.CurrentSessionId, AppId);
                e.Result = true;
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

        private void OnLoadAppWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if (e.Result != null)
            {
                ToModel(OriginalApp);
                //PopulateGroupDataToView();
                //btnConfirm.Enabled = btnRefresh.Enabled = true;
            }
        }

        private void OnLoadAddOrgWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = (int)Status.SUCCESS == ApplicationFactory.Instance.GetChannel().InsertApp(StorageService.CurrentSessionId, AddOrUpdateApp);
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

        private void OnLoadAddAppWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if ((bool)e.Result)
            {
                Hide();
            }
            else
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "addappfailed"));
            }
        }

        private void OnLoadUpdateAppWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = (int)Status.SUCCESS == ApplicationFactory.Instance.GetChannel().UpdateApp(StorageService.CurrentSessionId, AddOrUpdateApp);
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

        private void OnLoadUpdateAppWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if ((bool)e.Result)
            {
                Hide();
            }else {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "updateappfailed"));
            }
        }

        #endregion

        #region Buttons

        private void OnButtonConfirmClicked(object sender, EventArgs e)
        {
            switch (OperatingMode)
            {
                case ModeAdding:
                    AddApp();
                    break;
                case ModeUpdating:
                    UpdateApp();
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

        private void ToModel(App app)
        {
            //txtAppCode.Text = app.AppCode;
            txtAppName.Text = app.NameApp;
            txtDescription.Text = app.Description;
        }

        private App ToEntity()
        {
            App app = new App();
            app = OriginalApp != null ? OriginalApp : app;

            app.AppCode = string.Empty;
            app.NameApp = txtAppName.Text.Trim();
            app.Description = txtDescription.Text.Trim();

            //default
            app.CountModule = 1;
            app.ModulesName = "ModulesName";

            return app;
        }

        #endregion

        #region SetControl

        private void ClearEmptyControl()
        {
            //txtAppCode.Text =
            txtAppName.Text =
            txtDescription.Text = string.Empty;
            txtAppName.Focus();
        }

        private void SetControl(bool isView)
        {
            //txtAppCode.ReadOnly =
            txtAppName.ReadOnly =
            txtDescription.ReadOnly = isView;
        }

        private void SetShowOrHideButton(bool isView)
        {
            btnConfirm.Enabled = btnRefresh.Enabled = isView;
        }

        #endregion

        #region ValidateData

        private bool ValidateData()
        {
            //if (string.IsNullOrEmpty(txtAppCode.Text))
            //{
            //    MessageBoxManager.ShowErrorMessageBox(this, "Bạn chưa nhập mã ứng dụng!", "Thao Tác Sai");
            //    return false;
            //}

            if (string.IsNullOrEmpty(txtAppName.Text))
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessageValidate(rm, MessageValidate.AppName), MessageValidate.GetErrorTitle(rm));
                return false;
            }
            return true;
        }

        #endregion

        #region Application

        private void InitFormAddApp()
        {
            SetControl(false);
            SetShowOrHideButton(true);
            ClearEmptyControl();

            bgwAddApp = new BackgroundWorker();
            bgwAddApp.WorkerSupportsCancellation = true;
            bgwAddApp.DoWork += OnLoadAddOrgWorkerDoWork;
            bgwAddApp.RunWorkerCompleted += OnLoadAddAppWorkerRunWorkerCompleted;
        }
        private void InitFormUpdateApp()
        {
            this.Text = lblThemUngDung.Text = MessageValidate.GetMessage(rm, "UpdateApp");
            lbNoteAddApp.Text = MessageValidate.GetMessage(rm, "UpdateApponsytem");
            SetControl(false);
            SetShowOrHideButton(true);
            bgwLoadApp = new BackgroundWorker();
            bgwLoadApp.WorkerSupportsCancellation = true;
            bgwLoadApp.DoWork += OnLoadAppWorkerDoWork;
            bgwLoadApp.RunWorkerCompleted += OnLoadAppWorkerRunWorkerCompleted;

            bgwUpdateApp = new BackgroundWorker();
            bgwUpdateApp.WorkerSupportsCancellation = true;
            bgwUpdateApp.DoWork += OnLoadUpdateAppWorkerDoWork;
            bgwUpdateApp.RunWorkerCompleted += OnLoadUpdateAppWorkerRunWorkerCompleted;
        }
        private void LoadApp()
        {
            if (!bgwLoadApp.IsBusy && AppId > 0)
            {
                bgwLoadApp.RunWorkerAsync();
            }
        }

        private void AddApp()
        {
            if (ValidateData() && MessageBoxManager.ShowQuestionMessageBox(this,MessageValidate.GetQuestionAdd(rm,MessageValidate.App)) == System.Windows.Forms.DialogResult.Yes)
            {
                if (!bgwAddApp.IsBusy)
                {
                    AddOrUpdateApp = ToEntity();
                    bgwAddApp.RunWorkerAsync();
                }
            }
        }
        private void UpdateApp()
        {
            if (ValidateData() && MessageBoxManager.ShowQuestionMessageBox(this, MessageValidate.GetQuestionUpdate(rm, MessageValidate.App)) == System.Windows.Forms.DialogResult.Yes)
            {
                if (!bgwUpdateApp.IsBusy)
                {
                    AddOrUpdateApp = ToEntity();
                    bgwUpdateApp.RunWorkerAsync();
                }
            }
        }

        #endregion

        #endregion
    }
}
