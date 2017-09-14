using System;
using System.Windows.Forms;
using CommonControls.Custom;
using CommonControls;
using sWorldModel.Model;
using sWorldModel.TransportData;

namespace UserMgtComponent.WorkItems.UserAdding
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
            get { return btnNext; }
        }

        public Button CancelButton
        {
            get { return btnCancel; }
        }

        private User originalUser;

        private User returnUser;
        public object[] ReturnData
        {
            get { return new object[] { returnUser }; }
        }

        private byte operatingMode = 0;
        public const byte MODE_CREATE = 1;
        public const byte MODE_UPDATE = 2;

        public event EventHandler StepCompleted;

        #endregion

        public UsrUserInfo(byte operatingMode, User user)
        {
            InitializeComponent();

            if (operatingMode == MODE_UPDATE && user != null)
            {
                originalUser = user;
                PopulatePersonalInfoToView();

                if (user.IsRoot)
                {
                    btnNext.Enabled = false;
                    MessageBoxManager.ShowInfoMessageBox(this, "Thông tin cá nhân của tài khoản thuộc quyền quản trị hệ thống. Do đó, bạn không được phép thay đổi.");
                }
            }
            else
                originalUser = new User();

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
                    this.Text = "Tạo Tài Khoản Mới";
                    this.label1.Text = "Nhập thông tin cá nhân cho tài khoản mới vào các trường bên dưới.";
                    btnBack.Visible = false;
                    btnBack.Enabled = false;
                    btnNext.Text = "Tiếp Tục";
                    break;
                case MODE_UPDATE:
                    this.Text = "Cập Nhật Thông Tin Cá Nhân";
                    this.label1.Text = "Nhập dữ liệu vào các trường bên dưới rồi nhấn \"Xác Nhận\" để thay đổi thông tin cá nhân của tài khoản.";
                    btnBack.Visible = false;
                    btnBack.Enabled = false;
                    btnBack.Visible = false;
                    btnNext.Text = "Xác Nhận...";
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
            rbtnGenderFemale.Checked = rbtnGenderMale.Checked = rbtnGenderOther.Checked = false;
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
        }

        private User CollectPersonalInfo()
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

            User personalInfo = new User()
            {
                Id= originalUser.Id,
                GroupId = originalUser.GroupId,
                UserName = originalUser.UserName,
                PasswordHash = originalUser.PasswordHash,
                Status = originalUser.Status,
                IsRoot = originalUser.IsRoot,

                BirthDate = dtpBirthDate.Checked ? dtpBirthDate.Value.ToShortDateString() : null,
                Email = tbxEmailAddress.Text.Length != 0 ? tbxEmailAddress.Text : null,
                FirstName = tbxFirstName.Text.Length != 0 ? tbxFirstName.Text : null,
                Gender = rbtnGenderFemale.Checked ? "F" : (rbtnGenderMale.Checked ? "M" : "O"),
                IdCardIssuedDate = dtpIdCardIssuedDate.Checked ? dtpIdCardIssuedDate.Value.ToShortDateString() : null,
                IdCardIssuedPlace = tbxIdCardIssuedPlace.Text.Length != 0 ? tbxIdCardIssuedPlace.Text : null,
                IdCardNo = tbxIdCardNo.Text.Length != 0 ? tbxIdCardNo.Text : null,
                LastName = tbxLastName.Text.Length != 0 ? tbxLastName.Text : null,
                Nationality = tbxNationality.Text.Length != 0 ? tbxNationality.Text : null,
                PermanentAddress = tbxPermanentAddress.Text.Length != 0 ? tbxPermanentAddress.Text : null,
                PhoneNo = tbxPhoneNo.Text.Length != 0 ? tbxPhoneNo.Text : null,
                TemporaryAddress = tbxTemporaryAddress.Text.Length != 0 ? tbxTemporaryAddress.Text : null,
            };
            return personalInfo;
        }
    }
}