using CommonControls;
using CommonControls.Custom;
using CommonHelper.Utils;
using sWorldModel;
using sWorldModel.Exceptions;
using Microsoft.Practices.CompositeUI;
using JavaCommunication.Factory;
using System;
using System.ComponentModel;
using System.ServiceModel;
using System.Windows.Forms;
using JavaCommunication;
using sWorldModel.TransportData;
using CommonHelper.Constants;
using System.Resources;
//using WcfServiceCommon;

namespace MainForm
{
    public partial class FrmMemberInfo : CommonControls.Custom.CommonDialog
    {
        private string PasswordNew = string.Empty;
        private BackgroundWorker bgwChangePassword;
        //20170603 #Bug 649 validate check passworld not correct A - Ten Nguyen Start
        //private BackgroundWorker bgwGetUserSworld;
        private UserSworld userSworld;
        //20170603 #Bug 649 validate check passworld not correct A - Ten Nguyen End
        private ILocalStorageService storageService;
        private ResourceManager rm;
        private SessionDTO session;

        public FrmMemberInfo([ServiceDependency]ILocalStorageService storageService)
        {
            InitializeComponent();

            this.storageService = storageService;

            lblMessage.Text = string.Empty;

            bgwChangePassword = new BackgroundWorker();
            bgwChangePassword.WorkerSupportsCancellation = true;
            bgwChangePassword.DoWork += bgwChangePassword_DoWork;
            bgwChangePassword.RunWorkerCompleted += bgwChangePassword_Completed;
            ////20170603 #Bug 649 validate check passworld not correct A - Ten Nguyen Start
            //bgwGetUserSworld = new BackgroundWorker();
            //bgwGetUserSworld.WorkerSupportsCancellation = true;
            //bgwGetUserSworld.DoWork += bgwGetUserSworld_DoWork;
            //bgwGetUserSworld.RunWorkerCompleted += bgwGetUserSworld_Completed;
            ////20170603 #Bug 649 validate check passworld not correct A - Ten Nguyen End
            tbxNewPasswd1.TextChanged += txtNewPassword1_TexChanged;

            session = storageService.GetObject(CacheKeyNames.CurrentSession) as SessionDTO;
            rm = storageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            ResourceManager rm = storageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
            this.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.Name);
        }
       
        private void bgwChangePassword_DoWork(object sender, DoWorkEventArgs e)
        {
            bool result = false;
            try
            {
                result = (int)Status.SUCCESS == ManagerSystemFactory.Instance.GetChannel().ResetPassword(session.Token, session.Id, PasswordNew);
            }
            catch (TimeoutException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, "TimeOutExceptionMessage"));
            }
            catch (FaultException<WcfServiceFault> ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
            }
            catch (FaultException ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, "FaultExceptionMessage")
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
            }
            catch (CommunicationException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, "CommunicationExceptionMessage"));
            }
            finally
            {
                e.Result = result;
            }
        }

        private void bgwChangePassword_Completed(object sender, RunWorkerCompletedEventArgs e)
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
                this.Hide();
            }
            else
            {
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessFalse(rm, MessageValidate.CurrentPass));
            }
        }

        private void txtNewPassword1_TexChanged(object sender, EventArgs e)
        {
            PasswordScore score = PasswordUtils.CheckPasswordStrength(tbxNewPasswd1.Text);
            lblPasswdStrength.Score = (int)score;
            if (score == PasswordScore.Blank)
            {
                lblPasswdStrength.Text = string.Empty;
            }
            else
            {
                lblPasswdStrength.Text = string.Format(MessageValidate.GetMessage(rm, "msgDoManh"), score.GetName());
            }
        }


        private void btnConfirm_Clicked(object sender, EventArgs e)
        {
            if (tbxOldPasswd.Text.Length == 0)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, MessageValidate.CurrentPassNull), MessageValidate.GetErrorTitle(rm));
                tbxOldPasswd.Focus();
                return;
            }
            ////20170603 #Bug 649 validate check passworld not correct A - Ten Nguyen Start
            //if (tbxOldPasswd.Text != userSworld.PasswordHash)
            //{
            //    MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessFalse(rm, MessageValidate.CurrentPass), MessageValidate.GetErrorTitle(rm));
            //    tbxOldPasswd.Focus();
            //    return;
            //}
            ////20170603 #Bug 649 validate check passworld not correct A - Ten Nguyen Start
            if (tbxNewPasswd1.Text.Length == 0)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, MessageValidate.NewPassNull), MessageValidate.GetErrorTitle(rm));
                tbxNewPasswd1.Focus();
                return;
            }
            if (tbxNewPasswd2.Text.Length == 0)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessageValidate(rm, MessageValidate.ReNewPassNull), MessageValidate.GetErrorTitle(rm));
                tbxNewPasswd2.Focus();
                return;
            }
            if (!tbxNewPasswd1.Text.Equals(tbxNewPasswd2.Text))
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessFalse(rm, MessageValidate.RePass), MessageValidate.GetErrorTitle(rm));
                tbxNewPasswd2.Text = string.Empty;
                tbxNewPasswd2.Focus();
                return;
            }
            if (PasswordUtils.CheckPasswordStrength(tbxNewPasswd1.Text) < PasswordScore.Medium)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessPassWeak(rm, MessageValidate.Select), MessageValidate.GetErrorTitle(rm));
                tbxNewPasswd1.Text = tbxNewPasswd2.Text = string.Empty;
                tbxNewPasswd1.Focus();
                return;
            }
            if (MessageBoxManager.ShowQuestionMessageBox(this, MessageValidate.GetMessage(rm, "msgChangePass")) == DialogResult.Yes)
            {
                if (!bgwChangePassword.IsBusy)
                {
                    DisableInputFields(true);
                    lblMessage.Visible = true;
                    string passOld = tbxOldPasswd.Text.Trim();
                    string userName = session.UserName;
                    PasswordNew = userName+"@"+passOld +"@"+tbxNewPasswd2.Text.Trim();
                    bgwChangePassword.RunWorkerAsync();
                }
            }
        }

        private void btnRefresh_Clicked(object sender, EventArgs e)
        {
            tbxOldPasswd.Text = tbxNewPasswd1.Text = tbxNewPasswd2.Text = string.Empty;
            tbxOldPasswd.Focus();
        }

        private void btnCancel_Clicked(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void DisableInputFields(bool disabled)
        {
            tbxNewPasswd1.ReadOnly = tbxNewPasswd2.ReadOnly = tbxOldPasswd.ReadOnly = !disabled;
            btnCancel.Enabled = btnConfirm.Enabled = btnRefresh.Enabled = !disabled;
        }
    }
}