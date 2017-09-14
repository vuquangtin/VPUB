using System;
using System.Linq;
using System.Windows.Forms;
using CommonControls;
using System.ServiceModel;
using System.Threading;
using System.Collections.Generic;
using CommonHelper.Constants;
using CommonHelper.Utils;
using System.ComponentModel;
using sWorldModel;
using sWorldModel.Exceptions;
using sWorldModel.Model;
using  JavaCommunication.Factory;
using CommonHelper.Config;
using JavaCommunication;
using sWorldModel.TransportData;
using SMSGaywate;

namespace sAccessControl
{
    public partial class FrmLogin : CommonControls.Custom.CommonDialog
    {
        #region Properties

        private BackgroundWorker bgwLogin;
        private SessionDTO session = null;

        #endregion

        #region Initialization

        public FrmLogin()
        {
            InitializeComponent();

            btnLogin.Click += btnLogin_Clicked;
            btnClose.Click += btnCancel_Clicked;
#if (DEBUG)
            tbxUserName.Text = @"swtadmin";
            tbxPassword.Text = @"1";
#endif

            lblMessage.Text = string.Empty;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            tbxUserName.Focus();
        }

        public void ResetToDefault()
        {
            DisableControls(false);
            EmptyFields();
            lblMessage.Text = string.Empty;
            tbxUserName.Focus();
        }

        #endregion

        private void btnLogin_Clicked(object sender, EventArgs e)
        {
            if (bgwLogin == null)
            {
                bgwLogin = new BackgroundWorker();
                bgwLogin.DoWork += bgwLogin_DoWork;
            }
            else if (bgwLogin.IsBusy)
            {
                return;
            }
            bgwLogin.RunWorkerAsync();
        }

        private void bgwLogin_DoWork(object sender, DoWorkEventArgs e)
        {
            DisableControls(true);

            //// Collect data from user interface
            string userName = tbxUserName.Text = tbxUserName.Text.Trim();
            string password = tbxPassword.Text;

            // Check input data
            if (userName.Length == 0)
            {
                ChangeStatusMessage("Bạn chưa nhập tên tài khoản.");
                EmptyFields();
                DisableControls(false);
                FocusOnUserNameField();
                return;
            }
            if (password.Length == 0)
            {
                ChangeStatusMessage("Bạn chưa nhập mật khẩu.");
                EmptyFields();
                DisableControls(false);
                FocusOnUserNameField();
                return;
            }

            // Call service to do login
            ChangeStatusMessage("Đang xác thực tài khoản...");
            
            try
            {
                session = AuthenticationFactory.Instance.GetChannel().Login(userName, password);
                if (session.Id == 0)
                {
                    ChangeStatusMessage("Tài khoản hoặc mật khẩu không đúng.");
                    EmptyFields();
                    DisableControls(false);
                    FocusOnUserNameField();
                    return;
                }
            }
            catch (System.TimeoutException)
            {
                ChangeStatusMessage(CommonMessages.TimeOutExceptionMessage);
                DisableControls(false);
                FocusOnUserNameField();
                return;
            }
            catch (FaultException<WcfServiceFault> ex)
            {
                ChangeStatusMessage(ErrorCodes.GetErrorMessage(ex.Detail.Code));
                DisableControls(false);
                FocusOnUserNameField();
                return;
            }
            catch (FaultException ex)
            {
                ChangeStatusMessage(CommonMessages.FaultExceptionMessage
                    + Environment.NewLine + Environment.NewLine
                    + ex.Message);
                DisableControls(false);
                FocusOnUserNameField();
                return;
            }
            catch (CommunicationException ex)
            {
                MessageBox.Show(ex.ToString());
                ChangeStatusMessage(CommonMessages.CommunicationExceptionMessage);
                DisableControls(false);
                FocusOnUserNameField();
                return;
            }
            finally
            {
                EmptyFields();
            }

            FocusOnUserNameField();
            ChangeStatusMessage("Đăng nhập thành công!");
            ShowMainForm(password);
        }

        private void btnCancel_Clicked(object sender, EventArgs e)
        {
            Dispose();
        }

        private void EmptyFields()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(EmptyFields));
                return;
            }
            tbxPassword.Text = tbxUserName.Text = string.Empty;
        }

        private void DisableControls(bool disable)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<bool>(DisableControls), disable);
                return;
            }
            tbxUserName.ReadOnly = tbxPassword.ReadOnly = disable;
            btnLogin.Enabled = !disable;
        }

        private void ChangeStatusMessage(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(ChangeStatusMessage), message);
                return;
            }
            lblMessage.Text = message;
        }

        private void FocusOnUserNameField()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(FocusOnUserNameField));
                return;
            }
            tbxUserName.Focus();
        }

        private void ShowMainForm(string password)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(ShowMainForm), password);
                return;
            }
            MainForm mainForm = new MainForm(session, password);
            mainForm.Show();
            this.Hide();
        }

        private void btnConfigService_Click(object sender, EventArgs e)
        {
            FrmConfigService frm = new FrmConfigService();
            frm.ShowDialog();
        }
    }
}