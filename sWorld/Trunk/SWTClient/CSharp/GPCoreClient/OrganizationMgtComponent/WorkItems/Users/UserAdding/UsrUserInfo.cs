using System;
using System.Windows.Forms;
using CommonControls.Custom;
using CommonControls;
using sWorldModel.Model;
using sWorldModel.TransportData;
using System.Resources;
using sWorldModel;
using Microsoft.Practices.CompositeUI;
using CommonHelper.Constants;
using CommonHelper.Utils;

namespace SystemMgtComponent.WorkItems.UserAdding
{
    public partial class UsrUserInfo : CommonUserControl, IUserAddingDialog
    {
        #region Properties

        private DialogPostAction postAction = DialogPostAction.NONE;
        public DialogPostAction PostAction
        {
            get { return postAction; }
        }

        public Button AcceptButton
        {
            get { return btnConfirm; }
        }

        public Button CancelButton
        {
            get { return btnCancel; }
        }

        private UserSworld originalUser;

        public UserSworld returnUser;
        public object[] ReturnData
        {
            get { return new object[] { returnUser }; }
        }

        private byte operatingMode = 0;
        public const byte MODE_CREATE = 1;
        public const byte MODE_UPDATE = 2;

        public event EventHandler StepCompleted;

        private ResourceManager rm;
        private WorkItem rootWorkItem;
       

        [ServiceDependency]
        public WorkItem RootWorkItem
        {
            set { rootWorkItem = value; }
        }
        private ILocalStorageService storageService;
        public ILocalStorageService StorageService
        {
            get { return storageService; }
            set { storageService = value; }
        }
        #endregion
        public UsrUserInfo(byte operatingMode, UserSworld user)
        {
            InitializeComponent();

            if (operatingMode == MODE_UPDATE && user != null)
            {
                originalUser = user;
                PopulatePersonalInfoToView();

                if (user.IsRoot)
                {
                    btnConfirm.Enabled = false;
                    //"Thông tin cá nhân của tài khoản thuộc quyền quản trị hệ thống. Do đó, bạn không được phép thay đổi."
                    MessageBoxManager.ShowInfoMessageBox(this,MessageValidate.GetMessage(rm,"cannotchanginformationsystem"));
                }
            }
            else
                originalUser = new UserSworld();

            if (this.operatingMode != operatingMode)
            {
                this.operatingMode = operatingMode;
                ChangeOperatingMode();
            }
        }
        private void OnButtonBackClicked(object sender, EventArgs e)
        {
            postAction = DialogPostAction.BACK;
            if (StepCompleted != null)
            {
                StepCompleted(this, EventArgs.Empty);
            }
        }

        private void OnButtonNextClicked(object sender, EventArgs e)
        {
            returnUser = CollectPersonalInfo();
            if (operatingMode == UsrUserInfo.MODE_CREATE)
            {
                postAction = DialogPostAction.NEXT;
            }
            else
            {
                postAction = DialogPostAction.CONFIRMED;
            }
            if (StepCompleted != null)
            {
                StepCompleted(this, EventArgs.Empty);
            }
        }

        private void OnButtonRefreshClicked(object sender, EventArgs e)
        {
            switch (operatingMode)
            {
                case MODE_CREATE:
                    ClearAllData();
                    break;
                case MODE_UPDATE:
                    PopulatePersonalInfoToView();
                    break;
                default:
                    throw new ArgumentException("Invalid operating mode!");
            }
            tbxLastName.Focus();
        }

        private void OnButtonCancelClicked(object sender, EventArgs e)
        {
            postAction = DialogPostAction.CANCEL;
            if (StepCompleted != null)
            {
                StepCompleted(this, EventArgs.Empty);
            }
        }

        private void ChangeOperatingMode()
        {
            switch (operatingMode)
            {
                case MODE_CREATE:
                    this.Text = "Add User";
                    btnBack.Visible = false;
                    btnBack.Enabled = false;
                    btnConfirm.Text = "Next";
                    break;
                case MODE_UPDATE:
                    this.Text = "Update User";
                    btnBack.Visible = false;
                    btnBack.Enabled = false;
                    btnBack.Visible = false;
                    btnConfirm.Text = "Confirm...";
                    break;
                default:
                    throw new ArgumentException("Invalid operating mode!");
            }
        }

        private void ClearAllData()
        {
            tbxEmailAddress.Text = tbxFirstName.Text = tbxIdCardIssuedPlace.Text = tbxIdCardNo.Text = tbxLastName.Text = tbxNationality.Text = tbxPermanentAddress.Text = tbxPhoneNo.Text = tbxTemporaryAddress.Text = string.Empty;
            dtpBirthDate.Value = dtpIdCardIssuedDate.Value = DateTime.Now;
            dtpBirthDate.Checked = false;
            dtpIdCardIssuedDate.Checked = false;
            rbtfemale.Checked = rbtmale.Checked = rbtnGenderOther.Checked = false;
        }

        private void PopulatePersonalInfoToView()
        {
            if (originalUser != null)
            {
                tbxEmailAddress.Text = originalUser.Email != null ? originalUser.Email : string.Empty;
                tbxFirstName.Text = originalUser.FirstName != null ? originalUser.FirstName : string.Empty;
                tbxIdCardIssuedPlace.Text = originalUser.IdCardIssuedPlace != null ? originalUser.IdCardIssuedPlace : string.Empty;
                tbxIdCardNo.Text = originalUser.IdCardNo != null ? originalUser.IdCardNo : string.Empty;
                tbxLastName.Text = originalUser.LastName != null ? originalUser.LastName : string.Empty;
                tbxNationality.Text = originalUser.Nationality != null ? originalUser.Nationality : string.Empty;
                tbxPermanentAddress.Text = originalUser.PermanentAddress != null ? originalUser.PermanentAddress : string.Empty;
                tbxPhoneNo.Text = originalUser.PhoneNo != null ? originalUser.PhoneNo : string.Empty;
                tbxTemporaryAddress.Text = originalUser.TemporaryAddress != null ? originalUser.TemporaryAddress : string.Empty;
                dtpBirthDate.Value = originalUser.BirthDate != null ? Convert.ToDateTime(originalUser.BirthDate) : new DateTime(1900, 1, 1);
                dtpBirthDate.Checked = false;
                dtpIdCardIssuedDate.Value = originalUser.IdCardIssuedDate != null ? Convert.ToDateTime(originalUser.IdCardIssuedDate) : new DateTime(1900, 1, 1);
                dtpIdCardIssuedDate.Checked = false;
                if (originalUser.Gender != null)
                {
                    switch (originalUser.Gender)
                    {
                        case "Nam":
                        case "Male":
                        case "M":
                            rbtmale.Checked = true;
                            break;
                        case "Nữ":
                        case "Female":
                        case "F":
                            rbtfemale.Checked = true;
                            break;
                        default:
                            rbtnGenderOther.Checked = true;
                            break;
                    }
                }
                else
                {
                    rbtfemale.Checked = rbtmale.Checked = rbtnGenderOther.Checked = false;
                }
            }
        }

        private UserSworld CollectPersonalInfo()
        {
            tbxEmailAddress.Text = tbxEmailAddress.Text.Trim();
            tbxFirstName.Text = tbxFirstName.Text.Trim();
            tbxIdCardIssuedPlace.Text = tbxIdCardIssuedPlace.Text.Trim();
            tbxIdCardNo.Text = tbxIdCardNo.Text.Trim();
            tbxLastName.Text = tbxLastName.Text.Trim();
            tbxNationality.Text = tbxNationality.Text.Trim();
            tbxPermanentAddress.Text = tbxPermanentAddress.Text.Trim();
            tbxPhoneNo.Text = tbxPhoneNo.Text.Trim();
            tbxTemporaryAddress.Text = tbxTemporaryAddress.Text.Trim();

            UserSworld personalInfo = new UserSworld();

            personalInfo.id = originalUser.id;
            personalInfo.GroupId = originalUser.GroupId;
            personalInfo.UserName = originalUser.UserName;
            personalInfo.PasswordHash = originalUser.PasswordHash;
            personalInfo.Status = originalUser.Status;
            personalInfo.IsRoot = originalUser.IsRoot;

            personalInfo.BirthDate = dtpBirthDate.Checked ? dtpBirthDate.Value.ToShortDateString() : null;
            personalInfo.Email = tbxEmailAddress.Text.Length != 0 ? tbxEmailAddress.Text : null;
            personalInfo.FirstName = tbxFirstName.Text.Length != 0 ? tbxFirstName.Text : null;
            personalInfo.Gender = rbtfemale.Checked ? "F" : (rbtmale.Checked ? "M" : "O");
            personalInfo.IdCardIssuedDate = dtpIdCardIssuedDate.Checked ? dtpIdCardIssuedDate.Value.ToShortDateString() : null;
            personalInfo.IdCardIssuedPlace = tbxIdCardIssuedPlace.Text.Length != 0 ? tbxIdCardIssuedPlace.Text : null;
            personalInfo.IdCardNo = tbxIdCardNo.Text.Length != 0 ? tbxIdCardNo.Text : null;
            personalInfo.LastName = tbxLastName.Text.Length != 0 ? tbxLastName.Text : null;
            personalInfo.Nationality = tbxNationality.Text.Length != 0 ? tbxNationality.Text : null;
            personalInfo.PermanentAddress = tbxPermanentAddress.Text.Length != 0 ? tbxPermanentAddress.Text : null;
            personalInfo.PhoneNo = tbxPhoneNo.Text.Length != 0 ? tbxPhoneNo.Text : null;
            personalInfo.TemporaryAddress = tbxTemporaryAddress.Text.Length != 0 ? tbxTemporaryAddress.Text : null;

            return personalInfo;
        }
        private void UsrUserInfo_Load(object sender, EventArgs e)
        {
            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
            this.Text = MessageValidate.GetMessage(rm, this.Name);
        }

        private void tbxPhoneNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //kí tự nhập vào phải là số hay ko
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}