using CommonControls;
using CommonControls.Custom;
using CommonHelper.Utils;
using sWorldModel;
using sWorldModel.Exceptions;
using Microsoft.Practices.CompositeUI;
//using sWorldCommunication;
using System;
using System.ComponentModel;
using System.ServiceModel;
using System.Windows.Forms;
using JavaCommunication.Factory;
//using WcfServiceCommon;

namespace UserMgtComponent.WorkItems
{
    public partial class FrmResetPassword : CommonControls.Custom.CommonDialog
    {
        private BackgroundWorker bgwResetPassword;

        private WorkItem rootWorkItem;
        private ILocalStorageService storageSvc;

        [ServiceDependency]
        public WorkItem RootWorkItem
        {
            set { rootWorkItem = value; }
        }

        public ILocalStorageService StorageService
        {
            get
            {
                if (storageSvc == null)
                {
                    storageSvc = rootWorkItem.Services.Get<ILocalStorageService>();
                }
                return storageSvc;
            }
        }

        public long UserId { private get; set; }

        public FrmResetPassword()
        {
            InitializeComponent();

            bgwResetPassword = new BackgroundWorker();
            bgwResetPassword.WorkerSupportsCancellation = true;
            bgwResetPassword.DoWork += bgwResetPassword_DoWork;
            bgwResetPassword.RunWorkerCompleted += bgwResetPassword_RunWorkerCompleted;

            tbxNewPasswd1.TextChanged += txtNewPasswd1_TextChanged;
            lblMessage.Text = string.Empty;
            btnCancel.Click += btnCancel_Click;
            btnConfirm.Click += btnConfirm_Click;
            btnRefresh.Click += btnRefresh_Click;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (tbxNewPasswd1.Text.Length == 0)
            {
                MessageBoxManager.ShowErrorMessageBox(this, "Bạn chưa nhập mật khẩu mới!", "Thao Tác Sai");
                tbxNewPasswd1.Focus();
                return;
            }
            if (tbxNewPasswd2.Text.Length == 0)
            {
                MessageBoxManager.ShowErrorMessageBox(this, "Bạn chưa nhập lại mật khẩu mới!", "Thao Tác Sai");
                tbxNewPasswd2.Focus();
                return;
            }
            if (!tbxNewPasswd1.Text.Equals(tbxNewPasswd2.Text))
            {
                MessageBoxManager.ShowErrorMessageBox(this, "Mật khẩu nhập lại không đúng!", "Thao Tác Sai");
                tbxNewPasswd2.Text = string.Empty;
                tbxNewPasswd2.Focus();
                return;
            }
            if (PasswordUtils.CheckPasswordStrength(tbxNewPasswd1.Text) < PasswordScore.Medium)
            {
                MessageBoxManager.ShowErrorMessageBox(this, "Mật khẩu quá yếu, vui lòng chọn mật khẩu khác!", "Thao Tác Sai");
                tbxNewPasswd1.Text = tbxNewPasswd2.Text = string.Empty;
                tbxNewPasswd1.Focus();
                return;
            }
            if (MessageBoxManager.ShowQuestionMessageBox(this, "Bạn có chắc muốn cài lại mật khẩu cho tài khoản đã chọn không?") == System.Windows.Forms.DialogResult.Yes)
            {
                if (!bgwResetPassword.IsBusy)
                {
                    DisableInputFields(true);
                    lblMessage.Visible = true;
                    bgwResetPassword.RunWorkerAsync();
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            tbxNewPasswd1.Text = tbxNewPasswd2.Text = string.Empty;
            tbxNewPasswd1.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void bgwResetPassword_DoWork(object sender, DoWorkEventArgs e)
        {
            bool result = false;
            try
            {
                UserFactory.Instance.GetChannel().ResetPassword(StorageService.CurrentSessionId, UserId, tbxNewPasswd1.Text);
                result = true;
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

            e.Result = result;
        }

        private void bgwResetPassword_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblMessage.Visible = false;
            DisableInputFields(false);
            if (e.Cancelled)
            {
                return;
            }
            bool result = (bool)e.Result;
            if (result)
            {
                MessageBoxManager.ShowInfoMessageBox(this, "Mật khẩu đã được cập nhật!", "Thông Báo");
                this.Hide();
            }
        }

        private void txtNewPasswd1_TextChanged(object sender, EventArgs e)
        {
            PasswordScore score = PasswordUtils.CheckPasswordStrength(tbxNewPasswd1.Text);
            lblPasswdStrength.Score = (int)score;
            if (score == PasswordScore.Blank)
            {
                lblPasswdStrength.Text = string.Empty;
            }
            else
            {
                lblPasswdStrength.Text = string.Format("Độ mạnh: {0}", score.GetName());
            }
        }

        private void DisableInputFields(bool disabled)
        {
            tbxNewPasswd1.ReadOnly = tbxNewPasswd2.ReadOnly = !disabled;
            btnCancel.Enabled = btnConfirm.Enabled = btnRefresh.Enabled = !disabled;
        }
    }
}
