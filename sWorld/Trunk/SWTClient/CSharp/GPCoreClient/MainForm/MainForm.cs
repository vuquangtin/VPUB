using System;
using System.Windows.Forms;
using Microsoft.Practices.CompositeUI;
using CommonHelper.Constants;
using CommonControls;
using Microsoft.Practices.CompositeUI.EventBroker;
using System.ServiceModel;
using sWorldModel;
using sWorldModel.Exceptions;
using JavaCommunication.Factory;
using JavaCommunication;
using System.Globalization;
using System.Resources;
using CommonHelper.Utils;
using CommonHelper.Config;
using System.Drawing;
using System.Threading;

namespace MainForm
{
    public partial class MainForm : Form
    {
        #region Properties

        private FrmMemberInfo passwordChangingDialog;
        private ResourceManager rm;

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

            btnLocalization.Click+=btnLocalization_Click;
            GetButtonLanguages(SystemSettings.Instance.Languages);
        }

        public void Initialize()
        {
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

            // Update status bar
            string curUserName = StorageService.CurrentUserName;
            sttLabelUseName.Text = "Xin chào: " + (curUserName != null ? curUserName : "N/A");
            ILocalStorageService storageService = rootWorkItem.Services.Get<ILocalStorageService>();
            rm = storageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
            this.mnuChangePassword.Text = MessageValidate.GetMessage(rm, this.mnuChangePassword.Name);
            this.mnuSystem.Text = MessageValidate.GetMessage(rm, this.mnuSystem.Name);
            this.mnuLogout.Text = MessageValidate.GetMessage(rm, this.mnuLogout.Name);
            this.mnuExit.Text = MessageValidate.GetMessage(rm, this.mnuExit.Name);
            storageService.Languages = rm;
            MessageBoxManager.StorageService = storageService;
            MessageBoxManager.LoadLanguage();

            // Update status bar
            sttLabelUseName.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, "xinchao") + (curUserName != null ? curUserName : "N/A");
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            ILocalStorageService storageService = rootWorkItem.Services.Get<ILocalStorageService>();
            rm = storageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            if (null == rm)
            {
                rm = new ResourceManager("MainForm.Resources.SaiGonPearl", typeof(FrmLogin).Assembly);
                StorageService.StoreObjectPermanently(CacheKeyNames.Languages, rm);
            }
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
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

        #region CAB events

        [EventPublication(EventTopicNames.UserLoggedIn)]
        public event EventHandler UserLoggedIn;

        [EventPublication(EventTopicNames.UserLoggedOut)]
        public event EventHandler UserLoggedOut;

        #endregion

        private void OnFormClosing(object sender, FormClosingEventArgs e) { 


        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void mniChangePassword_Clicked(object sender, EventArgs e)
        {
            passwordChangingDialog = rootWorkItem.Items.AddNew<FrmMemberInfo>();
            passwordChangingDialog.ShowDialog();

            if (!passwordChangingDialog.IsDisposed)
            {
                passwordChangingDialog.Dispose();
            }
            rootWorkItem.Items.Remove(passwordChangingDialog);
        }

        private void mniExit_Clicked(object sender, EventArgs e)
        {

            if (MessageBoxManager.ShowQuestionMessageBox(this, ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, "msgLogoutProgram")) != DialogResult.Yes)
            {
                return;
            }
            try
            {
                Thread th = new Thread(() =>
                    {
                        try
                        {
                            AuthenticationFactory.Instance.GetChannel().Logout(StorageService.CurrentSessionId);
                        }
                        catch (TimeoutException) { }
                        catch (FaultException<WcfServiceFault>) { }
                        catch (FaultException) { }
                        catch (CommunicationException) { }
                    });
                th.Start();
            }
            finally
            {
                StorageService.ClearAll();
                Application.Exit();
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
                Thread th = new Thread(() =>
                {
                    try
                    {
                        AuthenticationFactory.Instance.GetChannel().Logout(StorageService.CurrentSessionId);
                    }
                    catch (TimeoutException) { }
                    catch (FaultException<WcfServiceFault>) { }
                    catch (FaultException) { }
                    catch (CommunicationException) { }
                });
                th.Start();
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

                rm = new ResourceManager("MainForm.Resources.SaiGonPearl", typeof(FrmLogin).Assembly);
                StorageService.StoreObjectPermanently(CacheKeyNames.Languages, rm);

            }
        }

        private void btnLocalization_Click(object sender, EventArgs e)
        {
            SetButtonLanguages(btnLocalization.Text.ToLower());

            string lang = btnLocalization.Text.ToLower();

            SystemSettings.Instance.Languages = lang;
            SystemSettings.Instance.Save();
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


    }
}