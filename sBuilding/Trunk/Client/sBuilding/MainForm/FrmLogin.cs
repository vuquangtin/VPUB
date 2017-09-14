﻿using System;
using System.Windows.Forms;
using Microsoft.Practices.CompositeUI;
using CommonControls;
using System.ServiceModel;
using System.Collections.Generic;
using CommonHelper.Constants;
using CommonHelper.Utils;
using System.ComponentModel;
using sWorldModel;
using sWorldModel.Exceptions;
using JavaCommunication.Factory;
using sWorldModel.TransportData;
//using SMSGaywate;
using System.Resources;

namespace MainForm {
    public partial class FrmLogin : CommonControls.Custom.CommonDialog {
        #region Properties

        private FrmConfigService configServiceDialog;
        private BackgroundWorker bgwLogin;
        private ResourceManager rm;

        private WorkItem rootWorkItem;

        private ILocalStorageService storageService;
        public ILocalStorageService StorageService {
            get {
                if (storageService == null) {
                    storageService = rootWorkItem.Services.Get<ILocalStorageService>();
                }
                return storageService;
            }
        }

        #endregion

        #region Initialization

        public FrmLogin([ServiceDependency]WorkItem rootWorkItem) {
            InitializeComponent();

            this.rootWorkItem = rootWorkItem;

            btnLogin.Click += btnLogin_Clicked;
            btnClose.Click += btnCancel_Clicked;
#if DEBUG
            tbxUserName.Text = @"swtadmin";
            tbxPassword.Text = @"1";
#endif

            lblMessage.Text = string.Empty;
            
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            tbxUserName.Focus();
            rm = new ResourceManager("MainForm.Resources.sBuilding", typeof(FrmLogin).Assembly);
            StorageService.StoreObjectPermanently(CacheKeyNames.Languages, rm);
            SetControlLanguages(rm);
            MessageBoxManager.StorageService = storageService;
            MessageBoxManager.LoadLanguage();
        }

        public void ResetToDefault() {
            DisableControls(false);
            EmptyFields();
            lblMessage.Text = string.Empty;
            tbxUserName.Focus();
        }

        #endregion

        private void btnLogin_Clicked(object sender, EventArgs e) {
            if (bgwLogin == null) {
                bgwLogin = new BackgroundWorker();
                bgwLogin.DoWork += bgwLogin_DoWork;
            } else if (bgwLogin.IsBusy) {
                return;
            }
            bgwLogin.RunWorkerAsync();
        }

        private void bgwLogin_DoWork(object sender, DoWorkEventArgs e) {
            DisableControls(true);

            //// Collect data from user interface
            string userName = tbxUserName.Text = tbxUserName.Text.Trim();
            string password = tbxPassword.Text;

            // Check input data
            if (userName.Length == 0) {
                ChangeStatusMessage(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, "lblLoginSuccess"));
                EmptyFields();
                DisableControls(false);
                FocusOnUserNameField();
                return;
            }
            if (password.Length == 0) {
                ChangeStatusMessage(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, "notEnterPass"));
                EmptyFields();
                DisableControls(false);
                FocusOnUserNameField();
                return;
            }

            // Call service to do login
            ChangeStatusMessage(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, "validateAcc"));
            SessionDTO session = null;
            List<PolicySworld> functions;
            try {
                session = AuthenticationFactory.Instance.GetChannel().Login(userName, password);
                if (session.Id == 0) {
                    ChangeStatusMessage(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, "userInCorrect"));
                    EmptyFields();
                    DisableControls(false);
                    FocusOnUserNameField();
                    return;
                }
                // 2017-07-03 Bug718: All - Token for single user -> vu.pham Start
                if (session.Id != 0 && session.IsLogin == true) {
                    if (MessageBoxManager.ShowQuestionMessageBox(this, ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, "msgUserIsLogin")) == DialogResult.Yes)
                    {
                        session = AuthenticationFactory.Instance.GetChannel().Login(userName, password, "OK" /* != null is ok, remove current token => get new token*/);
                    }
                    else
                    {
                        ChangeStatusMessage(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, "statusUserIsLogin"));
                        EmptyFields();
                        DisableControls(false);
                        FocusOnUserNameField();
                        return;
                    }
                }
                // 2017-07-03 Bug718: All - Token for single user -> vu.pham End
                if (session.IsRoot)
                    functions = ManagerSystemFactory.Instance.GetChannel().GetAllPermissionList();//load tat ca cac chuc nang cua he thong
                else
                    functions = ManagerSystemFactory.Instance.GetChannel().GetPermissionList(session.Token, session.Id);
            } catch (System.TimeoutException) {
                ChangeStatusMessage(MessageValidate.GetMessage(rm, "TimeOutExceptionMessage"));
                DisableControls(false);
                FocusOnUserNameField();
                return;
            } catch (FaultException<WcfServiceFault> ex) {
                ChangeStatusMessage(ErrorCodes.GetErrorMessage(ex.Detail.Code));
                DisableControls(false);
                FocusOnUserNameField();
                return;
            } catch (FaultException ex) {
                ChangeStatusMessage(MessageValidate.GetMessage(rm, "FaultExceptionMessage")
                    + Environment.NewLine + Environment.NewLine
                    + ex.Message);
                DisableControls(false);
                FocusOnUserNameField();
                return;
            } catch (CommunicationException ex) {
                MessageBox.Show(ex.ToString());
                ChangeStatusMessage(MessageValidate.GetMessage(rm, "CommunicationExceptionMessage"));
                DisableControls(false);
                FocusOnUserNameField();
                return;
            } finally {
                EmptyFields();
            }
            StorageService.CurrentUserName = session.UserName;
            StorageService.CurrentSessionId = session.Token;
            StorageService.StoreObjectPermanently(CacheKeyNames.CurrentSession, session);
            StorageService.StoreObjectPermanently(CacheKeyNames.CurrentUserPermissions, functions);

            FocusOnUserNameField();
            ChangeStatusMessage(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, "LoginSuccess"));
            ShowMainForm();
        }

        private void SetControlLanguages(ResourceManager rm)
        {
            this.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.Name);
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
            toolTip1.SetToolTip(btnConfigService, MessageValidate.GetMessage(rm, "btnConfigService"));
        }

        private void btnCancel_Clicked(object sender, EventArgs e) {
            Dispose();
        }

        private void EmptyFields() {
            if (InvokeRequired) {
                Invoke(new Action(EmptyFields));
                return;
            }
            tbxPassword.Text = string.Empty;
        }

        private void DisableControls(bool disable) {
            if (InvokeRequired) {
                Invoke(new Action<bool>(DisableControls), disable);
                return;
            }
            tbxUserName.ReadOnly = tbxPassword.ReadOnly = disable;
            btnLogin.Enabled = !disable;
        }

        private void ChangeStatusMessage(string message) {
            if (InvokeRequired) {
                Invoke(new Action<string>(ChangeStatusMessage), message);
                return;
            }
            lblMessage.Text = message;
        }

        private void FocusOnUserNameField() {
            if (InvokeRequired) {
                Invoke(new Action(FocusOnUserNameField));
                return;
            }
            tbxUserName.Focus();
        }

        private void ShowMainForm() {
            if (InvokeRequired) {
                Invoke(new Action(ShowMainForm));
                return;
            }
            MainForm mainForm = rootWorkItem.Items.Get<MainForm>(ComponentNames.MainForm);
            mainForm.Initialize();
            mainForm.Show();
            this.Hide();
        }
        private void btnConfigService_Click(object sender, EventArgs e) {
            configServiceDialog = rootWorkItem.Items.AddNew<FrmConfigService>();
            configServiceDialog.ShowDialog();

            if (!configServiceDialog.IsDisposed) {
                configServiceDialog.Dispose();
            }
            rootWorkItem.Items.Remove(configServiceDialog);
        }
    }
}