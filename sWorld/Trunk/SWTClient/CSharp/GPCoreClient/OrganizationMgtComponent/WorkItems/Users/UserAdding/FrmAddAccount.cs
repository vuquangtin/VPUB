using CommonControls;
using CommonControls.Custom;
using sWorldModel;
using sWorldModel.Exceptions;
using sWorldModel.Model;
using Microsoft.Practices.CompositeUI;
//using sWorldCommunication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ServiceModel;
using System.Windows.Forms;
using JavaCommunication.Factory;
using sWorldModel.TransportData;
using SystemMgtComponent.WorkItems;
using CommonHelper.Utils;
using System.Resources;
using CommonHelper.Constants;

namespace SystemMgtComponent.WorkItems.UserAdding
{
    public partial class FrmAddAccount : CommonControls.Custom.CommonDialog
    {
        private ResourceManager rm;
        public long groupId;
        private BackgroundWorker bgwAddUser;

        private SystemWorkItem workItem;

        [ServiceDependency]
        public SystemWorkItem WorkItem
        {
            set { workItem = value; }
        }

        private ILocalStorageService storageService;
        public ILocalStorageService StorageService
        {
            get
            {
                if (storageService == null)
                {
                    storageService = workItem.Services.Get<ILocalStorageService>();
                }
                return storageService;
            }
        }
        private void RegisterEvent()
        {
            btnConfirm.Click += btnConfirm_Click;
            btnRefresh.Click += ClearData;
            btnCancel.Click += btnConfirm_Clicked;

            bgwAddUser = new BackgroundWorker();
            bgwAddUser.WorkerSupportsCancellation = true;
            bgwAddUser.DoWork += bgwAddUser_DoWork;
            bgwAddUser.RunWorkerCompleted += bgwAddUser_RunWorkerCompleted;
            Shown += OnFormShown;
        }
        private void OnFormShown(object sender, EventArgs e)
        {
            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
            this.Text = MessageValidate.GetMessage(rm, this.Name);
            tbxUserName.Focus();
        }
        public FrmAddAccount(long groupAccountId)
        {
            InitializeComponent();
            RegisterEvent();
            this.groupId = groupAccountId;
           
        }
        private void AddUser()
        {
            if (ValidateData() && MessageBoxManager.ShowQuestionMessageBox(this, MessageValidate.GetQuestionAdd(rm, "account")) == System.Windows.Forms.DialogResult.Yes)
            {
                if (!bgwAddUser.IsBusy)
                {
                    bgwAddUser.RunWorkerAsync(ToEntity());
                }
            }
        }
        private void bgwAddUser_DoWork(object sender, DoWorkEventArgs e)
        {
            UserSworld user = (UserSworld)e.Argument;
            if (null != user)
            {
                try
                {
                    e.Result = ManagerSystemFactory.Instance.GetChannel().AddUser(StorageService.CurrentSessionId, user);
                }
                catch (TimeoutException)
                {
                    MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "TimeOutExceptionMessage"));
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
        }

        private void bgwAddUser_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if (e.Result != null)
            {
                this.Hide();
            }
            if(e.Result == null)
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "accExist"));
        }

        /// <summary>
        /// Event confirm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            AddUser();
        }
        private void ClearData(object sender, EventArgs e)
        {
            tbxUserName.Text =
            tbxPassword1.Text =
            tbxPassword2.Text =
            tbxEmailAddress.Text =
            tbxFirstName.Text =
            tbxIdCardIssuedPlace.Text =
            tbxIdCardNo.Text =
            tbxLastName.Text =
            tbxNationality.Text =
            tbxPermanentAddress.Text =
            tbxPhoneNo.Text =
            tbxTemporaryAddress.Text = string.Empty;
        }
        private void btnConfirm_Clicked(object sender, EventArgs e)
        {
            this.Hide();
        }
        /// <summary>
        /// Get value  controll for insertDB
        /// </summary>
        /// <returns></returns>
        private UserSworld ToEntity()
        {
            UserSworld userSworld = new UserSworld();
            userSworld.GroupId = groupId;
            userSworld.UserName = tbxUserName.Text.Trim();
            userSworld.PasswordHash = tbxPassword1.Text.Trim();
            userSworld.BirthDate = dtpBirthDate.Checked ? dtpBirthDate.Value.ToShortDateString() : null;
            userSworld.Email = tbxEmailAddress.Text.Length != 0 ? tbxEmailAddress.Text : null;
            userSworld.FirstName = tbxFirstName.Text.Length != 0 ? tbxFirstName.Text : null;
            userSworld.Gender = rbtfemale.Checked ? "F" : (rbtmale.Checked ? "M" : "O");
            userSworld.IdCardIssuedDate = dtpIdCardIssuedDate.Checked ? dtpIdCardIssuedDate.Value.ToShortDateString() : null;
            userSworld.IdCardIssuedPlace = tbxIdCardIssuedPlace.Text.Length != 0 ? tbxIdCardIssuedPlace.Text : null;
            userSworld.IdCardNo = tbxIdCardNo.Text.Length != 0 ? tbxIdCardNo.Text : null;
            userSworld.LastName = tbxLastName.Text.Length != 0 ? tbxLastName.Text : null;
            userSworld.Nationality = tbxNationality.Text.Length != 0 ? tbxNationality.Text : null;
            userSworld.PermanentAddress = tbxPermanentAddress.Text.Length != 0 ? tbxPermanentAddress.Text : null;
            userSworld.PhoneNo = tbxPhoneNo.Text.Length != 0 ? tbxPhoneNo.Text : null;
            userSworld.TemporaryAddress = tbxTemporaryAddress.Text.Length != 0 ? tbxTemporaryAddress.Text : null;
            return userSworld;

        }
        /// <summary>
        /// Check value data
        /// </summary>
        /// <returns></returns>
        private bool ValidateData()
        {
            //Kiểm tra dữ liệu
            tbxUserName.Text = tbxUserName.Text.Trim();
            if (tbxUserName.Text.Length == 0)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessageValidate(rm, MessageValidate.UserId), MessageValidate.GetErrorTitle(rm));
                tbxUserName.Focus();
                return false;
            }
            if (tbxPassword1.Text.Length == 0)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessageValidate(rm, MessageValidate.NewPass), MessageValidate.GetErrorTitle(rm));
                tbxPassword1.Focus();
                return false;
            }
            if (tbxPassword2.Text.Length == 0)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessageValidate(rm, MessageValidate.ReNewPass), MessageValidate.GetErrorTitle(rm));
                tbxPassword2.Focus();
                return false;
            }
            if (!tbxPassword1.Text.Equals(tbxPassword2.Text))
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessFalse(rm, MessageValidate.RePass), MessageValidate.GetErrorTitle(rm));
                tbxPassword2.Text = string.Empty;
                tbxPassword2.Focus();
                return false;
            }

            if (PasswordUtils.CheckPasswordStrength(tbxPassword1.Text) < PasswordScore.Medium)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessPassWeak(rm, MessageValidate.Select), MessageValidate.GetErrorTitle(rm));
                tbxPassword1.Text = tbxPassword2.Text = string.Empty;
                tbxPassword1.Focus();
                return false;
            }
            return true;
        }

        private void tbxPassword1_TextChanged(object sender, EventArgs e)
        {
            PasswordScore score = PasswordUtils.CheckPasswordStrength(tbxPassword1.Text);
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

        private void tbxIdCardNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //kí tự nhập vào phải là số hay ko
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void tbxPhoneNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //kí tự nhập vào phải là số hay ko
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
