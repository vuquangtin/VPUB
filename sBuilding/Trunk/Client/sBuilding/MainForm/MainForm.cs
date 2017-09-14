using System;
using System.Windows.Forms;
using Microsoft.Practices.CompositeUI;
using CommonHelper.Constants;
using CommonControls;
using System.Threading;
using Microsoft.Practices.CompositeUI.EventBroker;
using System.ServiceModel;
using sWorldModel;
using sWorldModel.Exceptions;
using JavaCommunication.Factory;
using System.Resources;
using CommonHelper.Utils;
using CommonHelper.Config;
using System.Drawing;
using CameraComponent;
using System.Collections.Generic;
using CommonControls.Custom;
using ScanComponent;

namespace MainForm
{
    public partial class MainForm : Form
    {
        #region Properties

        private FrmChangePassworld passwordChangingDialog;
        private ResourceManager rm;

        private bool isUseReader = false;

        private ILocalStorageService storageService;
        public ILocalStorageService StorageService
        {
            get
            {
                if (storageService == null)
                {
                    storageService = rootWorkItem.Services.Get<ILocalStorageService>();
                }
                return storageService;
            }
        }

        private WorkItem rootWorkItem;

        #endregion

        #region Initialization
        public MainForm([ServiceDependency]WorkItem rootWorkItem)
        {
            InitializeComponent();

            this.rootWorkItem = rootWorkItem;

            paletteWorkspace.Name = WorkspaceName.PaletteWorkspace;
            mainWorkspace.Name = WorkspaceName.MainWorkspace;

            mnuChangePassword.Click += mniChangePassword_Clicked;
            mnuExit.Click += mniExit_Clicked;
            mnuLogout.Click += mniLogout_Clicked;

            btnLocalization.Click += btnLocalization_Click;
            GetButtonLanguages(SystemSettings.Instance.Languages);
        }
        private Dictionary<String, object> WorkSpaceStore = new Dictionary<string, object>();
        public void Initialize()
        {


            ILocalStorageService storageService = rootWorkItem.Services.Get<ILocalStorageService>();
            rm = new ResourceManager("MainForm.Resources.sBuilding", typeof(FrmLogin).Assembly);
            storageService.StoreObjectPermanently(CacheKeyNames.Languages, rm);

            // Register menu bar
            if (!rootWorkItem.UIExtensionSites.Contains(ExtensionSiteNames.MainMenu))
            {
                rootWorkItem.UIExtensionSites.RegisterSite(ExtensionSiteNames.MainMenu, this.menuBar);
            }

            // Raise user login successfully event
            if (UserLoggedIn != null)
            {
                UserLoggedIn(this, EventArgs.Empty);
            }

            //Set Language
            SetLanguage();

        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            ILocalStorageService storageService = rootWorkItem.Services.Get<ILocalStorageService>();
            rm = storageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            if (null == rm)
            {
                rm = new ResourceManager("MainForm.Resources.sBuilding", typeof(FrmLogin).Assembly);
                StorageService.StoreObjectPermanently(CacheKeyNames.Languages, rm);
            }
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
            this.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.Name);
            storageService.Languages = rm;
            MessageBoxManager.StorageService = storageService;
            MessageBoxManager.LoadLanguage();
            //Set Language
            SetLanguage();

            // Update status bar
            string curUserName = StorageService.CurrentUserName;
            sttLabelUseName.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, "xinchao") + (curUserName != null ? curUserName : "N/A");
        }

        #endregion

        #region Set Language
        private void SetLanguage()
        {
            this.mnuSystem.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.mnuSystem.Name);
            this.mnuOptions.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.mnuOptions.Name);
            this.mnuUpdateInfo.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.mnuUpdateInfo.Name);
            this.mnuChangePassword.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.mnuChangePassword.Name);
            this.mnuLogout.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.mnuLogout.Name);
            this.mnuExit.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.mnuExit.Name);
        }
        #endregion

        #region CAB events

        [EventPublication(EventTopicNames.UserLoggedIn)]
        public event EventHandler UserLoggedIn;

        [EventPublication(EventTopicNames.UserLoggedOut)]
        public event EventHandler UserLoggedOut;

        #endregion

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBoxManager.ShowQuestionMessageBox(this, ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, "msgOffProgram")) != DialogResult.Yes)
            {
                e.Cancel = true;
            }
            else
            {
                try
                {
                    try
                    {
                        AuthenticationFactory.Instance.GetChannel().Logout(StorageService.CurrentSessionId);
                    }
                    catch (TimeoutException) { }
                }
                finally
                {
                    StorageService.ClearAll();
                    Application.ExitThread();
                    VideoSourceFactory.GetInstance().Close();
                    if (null != ScanFactory.GetInstance().scanFunctionTable)
                    {
                        ScanFactory.GetInstance().CloseScanDevice();
                    }
                    CloseReaderOpen();
                    Application.Exit();
                }
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                try
                {
                    AuthenticationFactory.Instance.GetChannel().Logout(StorageService.CurrentSessionId);
                }
                catch (TimeoutException) { }
            }
            finally
            {
                StorageService.ClearAll();
                Application.ExitThread();
                VideoSourceFactory.GetInstance().Close();
                if (null != ScanFactory.GetInstance().scanFunctionTable)
                {
                    ScanFactory.GetInstance().CloseScanDevice();
                }
                CloseReaderOpen();
                Application.Exit();
            }
        }

        private void mniChangePassword_Clicked(object sender, EventArgs e)
        {
           
            passwordChangingDialog = rootWorkItem.Items.AddNew<FrmChangePassworld>();
            passwordChangingDialog.ShowDialog();

            if (!passwordChangingDialog.IsDisposed)
            {
                passwordChangingDialog.Dispose();
            }
            rootWorkItem.Items.Remove(passwordChangingDialog);
        }

        private void mniExit_Clicked(object sender, EventArgs e)
        {

            if (MessageBoxManager.ShowQuestionMessageBox(this, ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, "msgOffProgram")) == DialogResult.Yes)
            {
                try
                {
                    try
                    {
                        AuthenticationFactory.Instance.GetChannel().Logout(StorageService.CurrentSessionId);
                    }
                    catch (TimeoutException) { }
                }
                finally
                {
                    StorageService.ClearAll();
                    Application.ExitThread();
                    VideoSourceFactory.GetInstance().Close();
                    if (null != ScanFactory.GetInstance().scanFunctionTable)
                    {
                        ScanFactory.GetInstance().CloseScanDevice();
                    }
                    CloseReaderOpen();
                    Application.Exit();
                }
            }
        }
        private void mniLogout_Clicked(object sender, EventArgs e)
        {
            if (MessageBoxManager.ShowQuestionMessageBox(this, ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, "msgLogoutProgram")) != DialogResult.Yes)
            {
                return;
            }
            try
            {
                try
                {
                    AuthenticationFactory.Instance.GetChannel().Logout(StorageService.CurrentSessionId);
                }
                catch (TimeoutException) { }
                catch (FaultException<WcfServiceFault>) { }
                catch (FaultException) { }
                catch (CommunicationException) { }

            }
            finally
            {
                if (UserLoggedOut != null)
                {
                    UserLoggedOut(this, EventArgs.Empty);
                }

                // Clear cache
                StorageService.ClearAll();
                // Show login dialog
                FrmLogin loginForm = (FrmLogin)rootWorkItem.Items[ComponentNames.LoginForm];
                loginForm.ResetToDefault();
                loginForm.Show();
                this.Hide();
            }
        }

        private void btnLocalization_Click(object sender, EventArgs e)
        {
            SetButtonLanguages(btnLocalization.Text.ToLower());

            string lang = btnLocalization.Text.ToLower();

            SystemSettings.Instance.Languages = lang;
            SystemSettings.Instance.Save();

            ResoucreLanguagesUtils.Instance.Refresh();
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
            storageService.Languages = rm;
            MessageBoxManager.StorageService = storageService;
            MessageBoxManager.LoadLanguage();
            //Set Language
            SetLanguage();

            UserLoggedOut(this, EventArgs.Empty);
            UserLoggedIn(this, EventArgs.Empty);
        }

        private void SetButtonLanguages(string lang)
        {
            switch (lang)
            {
                case Languages.VN:
                    lang = Languages.EN;
                    btnLocalization.BackColor = Color.FromArgb(192, 192, 255);
                    break;
                case Languages.EN:
                    lang = Languages.VN;
                    btnLocalization.BackColor = Color.FromArgb(255, 192, 192);
                    break;
                default:
                    lang = Languages.VN;
                    break;
            }
            btnLocalization.Text = lang.ToUpper();
        }

        private void GetButtonLanguages(string lang)
        {
            switch (lang)
            {
                case Languages.VN:
                    lang = Languages.VN;
                    btnLocalization.BackColor = Color.FromArgb(255, 192, 192);
                    break;
                case Languages.EN:
                    lang = Languages.EN;
                    btnLocalization.BackColor = Color.FromArgb(192, 192, 255);
                    break;
                default:
                    lang = Languages.VN;
                    btnLocalization.BackColor = Color.FromArgb(255, 192, 192);
                    break;
            }
            btnLocalization.Text = lang.ToUpper();
        }

        /// <summary>
        /// Tat tu dong bat tat cua man hinh UsrListMeeting do hien tai khong co quet the o man hinh nay : CHUA SU DUNG 
        /// </summary>
        private void CloseReaderOpen()
        {
            if (WorkSpaceStore.ContainsKey("UsrAddNonResident"))
            {
                ((sNonResidentComponent.WorkItems.UsrAddNonResident)WorkSpaceStore["UsrAddNonResident"]).PauseReader();


            }
            if (WorkSpaceStore.ContainsKey("UsrListMeeting"))
            {
                ((sMeetingComponent.WorkItems.UsrListMeeting)WorkSpaceStore["UsrListMeeting"]).PauseReader();
            }

            #region  usrJournalist
            if (WorkSpaceStore.ContainsKey("UsrJournalistAttendMeeting"))
            {
                ((sMeetingComponent.WorkItems.UsrJournalistAttendMeeting)WorkSpaceStore["UsrJournalistAttendMeeting"]).PauseReader();
            }
            #endregion

        }
        /// <summary>
        /// Tat tu dong bat tat cua man hinh UsrListMeeting do hien tai khong co quet the o man hinh nay : CHUA SU DUNG 
        /// </summary>
        private void mainWorkspace_SmartPartActivated(object sender, Microsoft.Practices.CompositeUI.SmartParts.WorkspaceEventArgs e)
        {

            if (e.SmartPart is sNonResidentComponent.WorkItems.UsrAddNonResident)
            {
                // Nếu không phải là tab Khách vãng lại thì tạm ngưng kết nối với máy scan
                if (null == ScanFactory.GetInstance().scanFunctionTable || !ScanFactory.GetInstance().isCameraStarted)
                {
                    ((sNonResidentComponent.WorkItems.UsrAddNonResident)e.SmartPart).StartScanDevice();
                }

                isUseReader = true;
                for (int i = 0; i < ((Microsoft.Practices.CompositeUI.WinForms.TabWorkspace)sender).TabCount; i++)
                {
                    if (((Microsoft.Practices.CompositeUI.WinForms.TabWorkspace)sender).SmartParts[i] is sMeetingComponent.WorkItems.UsrListMeeting)
                    {
                        ((sMeetingComponent.WorkItems.UsrListMeeting)((Microsoft.Practices.CompositeUI.WinForms.TabWorkspace)sender).SmartParts[i]).PauseReader();
                        break;
                    }
                }

                for (int i = 0; i < ((Microsoft.Practices.CompositeUI.WinForms.TabWorkspace)sender).TabCount; i++)
                {

                    if (((Microsoft.Practices.CompositeUI.WinForms.TabWorkspace)sender).SmartParts[i] is sMeetingComponent.WorkItems.UsrJournalistAttendMeeting)
                    {
                        ((sMeetingComponent.WorkItems.UsrJournalistAttendMeeting)((Microsoft.Practices.CompositeUI.WinForms.TabWorkspace)sender).SmartParts[i]).PauseReader();
                        break;
                    }

                }

                ((sNonResidentComponent.WorkItems.UsrAddNonResident)e.SmartPart).StartReader();
                ((sNonResidentComponent.WorkItems.UsrAddNonResident)e.SmartPart).AutoRefreshWhenChangeTab();
                if (!WorkSpaceStore.ContainsKey("UsrAddNonResident"))
                    WorkSpaceStore.Add("UsrAddNonResident", (sNonResidentComponent.WorkItems.UsrAddNonResident)e.SmartPart);
                else
                    WorkSpaceStore["UsrAddNonResident"] = (sNonResidentComponent.WorkItems.UsrAddNonResident)e.SmartPart;

            }
            else
            {
                // Nếu không phải là tab Khách vãng lại thì tạm ngưng kết nối với máy scan
                if (null != ScanFactory.GetInstance().scanFunctionTable && ScanFactory.GetInstance().isCameraStarted)
                {
                    ScanFactory.GetInstance().StopScanDevice();
                }

                if (e.SmartPart is sMeetingComponent.WorkItems.UsrListMeeting)
                {
                    isUseReader = true;
                    for (int i = 0; i < ((Microsoft.Practices.CompositeUI.WinForms.TabWorkspace)sender).TabCount; i++)
                    {
                        if (((Microsoft.Practices.CompositeUI.WinForms.TabWorkspace)sender).SmartParts[i] is sNonResidentComponent.WorkItems.UsrAddNonResident)
                        {
                            ((sNonResidentComponent.WorkItems.UsrAddNonResident)((Microsoft.Practices.CompositeUI.WinForms.TabWorkspace)sender).SmartParts[i]).PauseReader();
                        }
                    }

                    for (int i = 0; i < ((Microsoft.Practices.CompositeUI.WinForms.TabWorkspace)sender).TabCount; i++)
                    {

                        if (((Microsoft.Practices.CompositeUI.WinForms.TabWorkspace)sender).SmartParts[i] is sMeetingComponent.WorkItems.UsrJournalistAttendMeeting)
                        {
                            ((sMeetingComponent.WorkItems.UsrJournalistAttendMeeting)((Microsoft.Practices.CompositeUI.WinForms.TabWorkspace)sender).SmartParts[i]).PauseReader();
                            break;
                        }

                    }

                        ((sMeetingComponent.WorkItems.UsrListMeeting)e.SmartPart).StartReader();
                        ((sMeetingComponent.WorkItems.UsrListMeeting)e.SmartPart).AutoRefreshWhenChangeTab();
                    if (!WorkSpaceStore.ContainsKey("UsrListMeeting"))
                    {
                        WorkSpaceStore.Add("UsrListMeeting", (sMeetingComponent.WorkItems.UsrListMeeting)e.SmartPart);
                    }
                    else
                    {
                        WorkSpaceStore["UsrListMeeting"] = (sMeetingComponent.WorkItems.UsrListMeeting)e.SmartPart;
                    }
                }

                #region usrJournalist
                else
                if (e.SmartPart is sMeetingComponent.WorkItems.UsrJournalistAttendMeeting)
                {
                    isUseReader = true;
                    for (int i = 0; i < ((Microsoft.Practices.CompositeUI.WinForms.TabWorkspace)sender).TabCount; i++)
                    {
                        if (((Microsoft.Practices.CompositeUI.WinForms.TabWorkspace)sender).SmartParts[i] is sNonResidentComponent.WorkItems.UsrAddNonResident)
                        {
                            ((sNonResidentComponent.WorkItems.UsrAddNonResident)((Microsoft.Practices.CompositeUI.WinForms.TabWorkspace)sender).SmartParts[i]).PauseReader();
                        }
                    }

                    for (int i = 0; i < ((Microsoft.Practices.CompositeUI.WinForms.TabWorkspace)sender).TabCount; i++)
                    {

                        if (((Microsoft.Practices.CompositeUI.WinForms.TabWorkspace)sender).SmartParts[i] is sMeetingComponent.WorkItems.UsrListMeeting)
                        {
                            ((sMeetingComponent.WorkItems.UsrListMeeting)((Microsoft.Practices.CompositeUI.WinForms.TabWorkspace)sender).SmartParts[i]).PauseReader();
                            break;
                        }

                    }

                    ((sMeetingComponent.WorkItems.UsrJournalistAttendMeeting)e.SmartPart).StartReader();
                    ((sMeetingComponent.WorkItems.UsrJournalistAttendMeeting)e.SmartPart).AutoRefreshWhenChangeTab();
                    if (!WorkSpaceStore.ContainsKey("UsrJournalistAttendMeeting"))
                    {
                        WorkSpaceStore.Add("UsrJournalistAttendMeeting", (sMeetingComponent.WorkItems.UsrJournalistAttendMeeting)e.SmartPart);
                    }
                    else
                    {
                        WorkSpaceStore["UsrJournalistAttendMeeting"] = (sMeetingComponent.WorkItems.UsrJournalistAttendMeeting)e.SmartPart;
                    }

                }
                //else if (e.SmartPart is sMeetingComponent.WorkItems.StatisticForJournalist.UsrJournalistToAttendMeetingStatistics)
                //{
                //    ((sMeetingComponent.WorkItems.StatisticForJournalist.UsrJournalistToAttendMeetingStatistics)e.SmartPart).AutoRefreshWhenChangeTab();
                //}
                //else if (e.SmartPart is sMeetingComponent.WorkItems.StatisticForJournalist.UsrJournalistToAttendMeetingStatisticsDetail)
                //{
                //    ((sMeetingComponent.WorkItems.StatisticForJournalist.UsrJournalistToAttendMeetingStatisticsDetail)e.SmartPart).AutoRefreshWhenChangeTab();
                //}
                //else if (e.SmartPart is sNonResidentComponent.WorkItems.StatisticForNonresident.UsrNonResidentStatisticsDetail)
                //{
                //    ((sNonResidentComponent.WorkItems.StatisticForNonresident.UsrNonResidentStatisticsDetail)e.SmartPart).AutoRefreshWhenChangeTab();
                //}
                //else if (e.SmartPart is sNonResidentComponent.WorkItems.StatisticForNonresident.UsrNonResidentStatistics)
                //{
                //    ((sNonResidentComponent.WorkItems.StatisticForNonresident.UsrNonResidentStatistics)e.SmartPart).AutoRefreshWhenChangeTab();
                //}
                //else if (e.SmartPart is sNonResidentComponent.WorkItems.StatisticForNonresident.UsrManageCardNonResident)
                //{
                //    //((sNonResidentComponent.WorkItems.StatisticForNonresident.UsrManageCardNonResident)e.SmartPart).AutoRefreshWhenChangeTab();
                //}
                //else if (e.SmartPart is sNonResidentComponent.WorkItems.ManageMeeting.UsrManageMeeting)
                //{
                //    ((sNonResidentComponent.WorkItems.ManageMeeting.UsrManageMeeting)e.SmartPart).AutoRefreshWhenChangeTab();
                //}
                #endregion

                else
                {
                    if (isUseReader)
                    {
                        for (int i = 0; i < ((Microsoft.Practices.CompositeUI.WinForms.TabWorkspace)sender).TabCount; i++)
                        {
                            if (((Microsoft.Practices.CompositeUI.WinForms.TabWorkspace)sender).SmartParts[i] is sMeetingComponent.WorkItems.UsrListMeeting)
                            {
                                ((sMeetingComponent.WorkItems.UsrListMeeting)((Microsoft.Practices.CompositeUI.WinForms.TabWorkspace)sender).SmartParts[i]).PauseReader();
                            }
                            if (((Microsoft.Practices.CompositeUI.WinForms.TabWorkspace)sender).SmartParts[i] is sNonResidentComponent.WorkItems.UsrAddNonResident)
                            {
                                ((sNonResidentComponent.WorkItems.UsrAddNonResident)((Microsoft.Practices.CompositeUI.WinForms.TabWorkspace)sender).SmartParts[i]).PauseReader();
                            }
                            if (((Microsoft.Practices.CompositeUI.WinForms.TabWorkspace)sender).SmartParts[i] is sMeetingComponent.WorkItems.UsrJournalistAttendMeeting)
                            {
                                ((sMeetingComponent.WorkItems.UsrJournalistAttendMeeting)((Microsoft.Practices.CompositeUI.WinForms.TabWorkspace)sender).SmartParts[i]).PauseReader();
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Tat tu dong bat tat cua man hinh UsrListMeeting do hien tai khong co quet the o man hinh nay : CHUA SU DUNG 
        /// </summary>
        private void mainWorkspace_SmartPartClosing(object sender, Microsoft.Practices.CompositeUI.SmartParts.WorkspaceCancelEventArgs e)
        {
            if (e.SmartPart is sNonResidentComponent.WorkItems.UsrAddNonResident)
            {
                ((sNonResidentComponent.WorkItems.UsrAddNonResident)e.SmartPart).PauseReader();
                ((sNonResidentComponent.WorkItems.UsrAddNonResident)e.SmartPart).StopScanDevice();
            }
            if (e.SmartPart is sMeetingComponent.WorkItems.UsrListMeeting)
            {
                ((sMeetingComponent.WorkItems.UsrListMeeting)e.SmartPart).PauseReader();
            }

            #region usrJournalist
            if (e.SmartPart is sMeetingComponent.WorkItems.UsrJournalistAttendMeeting)
            {
                ((sMeetingComponent.WorkItems.UsrJournalistAttendMeeting)e.SmartPart).PauseReader();
            }
            #endregion
        }

    }
}