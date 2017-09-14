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
using CommonHelper.Constants;
using CommonHelper.Utils;
using System.Resources;

namespace MainForm
{
    public partial class FrmEditUser : CommonControls.Custom.CommonDialog
    {
        #region Properties

        private long UserId;
        private SessionDTO session;
        private ResourceManager rm;

        private UserSworld OriginalUser;
        private UserSworld AddOrUpdateUser;

        private BackgroundWorker bgwLoadUser;
        private BackgroundWorker bgwUpdateUser;

        public DialogPostAction PostAction { get; private set; }

        private ILocalStorageService storageService;

        #endregion

        public FrmEditUser([ServiceDependency]ILocalStorageService storageService)
        {
            InitializeComponent();
            RegisterEvent();
            session = storageService.GetObject(CacheKeyNames.CurrentSession) as SessionDTO;
            this.UserId = session.Id;
        }

        private void RegisterEvent()
        {
            SetControl(false);
            SetShowOrHideButton(true);

            bgwLoadUser = new BackgroundWorker();
            bgwLoadUser.WorkerSupportsCancellation = true;
            bgwLoadUser.DoWork += OnLoadOrgWorkerDoWork;
            bgwLoadUser.RunWorkerCompleted += OnLoadOrgWorkerRunWorkerCompleted;

            bgwUpdateUser = new BackgroundWorker();
            bgwUpdateUser.WorkerSupportsCancellation = true;
            bgwUpdateUser.DoWork += OnLoadUpdateOrgWorkerDoWork;
            bgwUpdateUser.RunWorkerCompleted += OnLoadUpdateOrgWorkerRunWorkerCompleted;

            btnCancel.Click += OnButtonCancelClicked;
            btnConfirm.Click += OnButtonConfirmClicked;
            btnRefresh.Click += OnButtonRefreshClicked;
            Shown += OnFormShown;
        }

        #region Event's

        private void OnFormShown(object sender, EventArgs e)
        {
            LoadUser();
            rm = storageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
        }

        #region User

        private void OnLoadOrgWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                OriginalUser = ManagerSystemFactory.Instance.GetChannel().GetUserById(session.Token, UserId);
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

        private void OnLoadOrgWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if (e.Result != null)
            {
                ToModel(OriginalUser);
            }
        }

        private void OnLoadUpdateOrgWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = (int)Status.SUCCESS == ManagerSystemFactory.Instance.GetChannel().UpdateUser(session.Token, AddOrUpdateUser);
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

        private void OnLoadUpdateOrgWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if ((bool)e.Result)
            {
                MessageBoxManager.ShowInfoMessageBox(this, "Đã cập nhật thông tin tài khoản thành công!");
                PostAction = DialogPostAction.SUCCESS;
                Hide();
            }
        }

        #endregion

        #region Buttons

        private void OnButtonConfirmClicked(object sender, EventArgs e)
        {
            UpdateUser();
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

        private void ToModel(UserSworld user)
        {
            tbxLastName.Text = user.LastName;
            tbxFirstName.Text = user.FirstName;
            tbxNationality.Text = user.Nationality;
            tbxIdCardNo.Text = user.IdCardNo;
            dtpIdCardIssuedDate.Value = user.IdCardIssuedDate.ToDateFormatString();
            tbxIdCardIssuedPlace.Text = user.IdCardIssuedPlace;
            dtpBirthDate.Value = user.BirthDate.ToDateFormatString();
            tbxEmailAddress.Text = user.Email;
            tbxTemporaryAddress.Text = user.TemporaryAddress;
            tbxPermanentAddress.Text = user.PermanentAddress;

            if (user.Gender != null)
            {
                switch (user.Gender)
                {
                    case "Nam":
                    case "Male":
                    case "M":
                        rbtnGenderMale.Checked = true;
                        break;
                    case "Nữ":
                    case "Female":
                    case "F":
                        rbtnGenderFemale.Checked = true;
                        break;
                    default:
                        rbtnGenderOther.Checked = true;
                        break;
                }
            }
            else
            {
                rbtnGenderFemale.Checked = rbtnGenderMale.Checked = rbtnGenderOther.Checked = false;
            }
        }

        private UserSworld ToEntity()
        {
            UserSworld user = new UserSworld();
            user = OriginalUser != null ? OriginalUser : user;

            user.LastName = tbxLastName.Text.Trim();
            user.FirstName = tbxFirstName.Text.Trim();
            user.Nationality = tbxNationality.Text.Trim();
            user.IdCardNo = tbxIdCardNo.Text.Trim();
            user.IdCardIssuedDate = dtpIdCardIssuedDate.Value.ToStringFormatDate();
            user.IdCardIssuedPlace = tbxIdCardIssuedPlace.Text.Trim();
            user.BirthDate = dtpBirthDate.Value.ToStringFormatDate();
            user.Gender = rbtnGenderFemale.Checked ? "F" : (rbtnGenderMale.Checked ? "M" : "O");
            user.Email = tbxEmailAddress.Text.Trim();
            user.TemporaryAddress = tbxTemporaryAddress.Text.Trim();
            user.PermanentAddress = tbxPermanentAddress.Text.Trim();

            return user;
        }

        #endregion

        #region SetControl

        private void ClearEmptyControl()
        {
            tbxEmailAddress.Text =
                tbxFirstName.Text =
                tbxIdCardIssuedPlace.Text =
                tbxIdCardNo.Text =
                tbxLastName.Text =
                tbxNationality.Text =
                tbxPermanentAddress.Text =
                tbxPhoneNo.Text =
                tbxTemporaryAddress.Text = string.Empty;
            dtpBirthDate.Value = dtpIdCardIssuedDate.Value = DateTime.Now;
            dtpBirthDate.Checked = false;
            dtpIdCardIssuedDate.Checked = false;
            rbtnGenderFemale.Checked = rbtnGenderMale.Checked = rbtnGenderOther.Checked = false;
        }

        private void SetControl(bool isView)
        {
            tbxEmailAddress.ReadOnly = 
                tbxFirstName.ReadOnly =
                tbxIdCardIssuedPlace.ReadOnly =
                tbxIdCardNo.ReadOnly =
                tbxLastName.ReadOnly = 
                tbxNationality.ReadOnly =
                tbxPermanentAddress.ReadOnly =
                tbxPhoneNo.ReadOnly =
                tbxTemporaryAddress.ReadOnly = isView;
            dtpBirthDate.Enabled = 
                dtpIdCardIssuedDate.Enabled =
                dtpBirthDate.Enabled =
                dtpIdCardIssuedDate.Enabled =
                rbtnGenderFemale.Enabled =
                rbtnGenderMale.Enabled =
                rbtnGenderOther.Enabled = !isView;
        }

        private void SetShowOrHideButton(bool isView)
        {
            btnConfirm.Enabled = btnRefresh.Enabled = isView;
        }

        #endregion

        #region ValidateData

        private bool ValidateData()
        {
            if (string.IsNullOrEmpty(tbxLastName.Text))
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessageValidate(rm, MessageValidate.LastName), MessageValidate.GetErrorTitle(rm));
                return false;
            }

            if (string.IsNullOrEmpty(tbxFirstName.Text))
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessageValidate(rm, MessageValidate.FirstName), MessageValidate.GetErrorTitle(rm));
                return false;
            }
            return true;
        }

        #endregion

        #region User

        private void LoadUser()
        {
            if (!bgwLoadUser.IsBusy && UserId > 0)
            {
                bgwLoadUser.RunWorkerAsync();
            }
        }

        private void UpdateUser()
        {
            if (ValidateData() && MessageBoxManager.ShowQuestionMessageBox(this, "Bạn có chắc muốn cập nhật thông tin tài khoản này không?") == System.Windows.Forms.DialogResult.Yes)
            {
                if (!bgwUpdateUser.IsBusy)
                {
                    AddOrUpdateUser = ToEntity();
                    bgwUpdateUser.RunWorkerAsync();
                }
            }
        }

        #endregion

        #endregion
    }
}
