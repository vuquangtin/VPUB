using CommonControls;
using Microsoft.Practices.CompositeUI;
using sWorldModel;
using sWorldModel.TransportData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JavaCommunication.Factory;
using System.ServiceModel;
using sWorldModel.Exceptions;
using JavaCommunication;
using sWorldModel.TransportData.Constants;
using CommonHelper.Utils;
using System.Net.Mail;
using System.Text.RegularExpressions;
using JavaCommunication.Common;
//using ImageAccessor;
using System.Resources;
using CommonHelper.Constants;
using SystemMgtComponent.WorkItems.Member;

namespace SystemMgtComponent.WorkItems
{
    public partial class FrmAddOrUpdateMemberAttendance : CommonControls.Custom.CommonDialog
    {
        #region Properties

        public const byte ModeAdding = 1;
        public const byte ModeUpdating = 2;
        private byte OperatingMode;
        private int ImageHeight = 0;

        private sWorldModel.TransportData.Member OriginalMember;
        private sWorldModel.TransportData.Member AddOrUpdateMember;
        private List<MemberRelativeDto> MemberRelativeList;

        private DataTable dbMemberList;

        private long OrgId;
        private long SubOrgId;
        private long MemberId;

        private ResourceManager rm;

        private BackgroundWorker bgwLoadMember;
        private BackgroundWorker bgwAddMember;
        private BackgroundWorker bgwUpdateMember;

        public DialogPostAction PostAction { get; private set; }

        private ILocalStorageService storageService;
        [ServiceDependency]
        public ILocalStorageService StorageService
        {
            get { return storageService; }
            set { storageService = value; }
        }

        #endregion

        public FrmAddOrUpdateMemberAttendance(byte operationMode, long orgId = 0, long subOrgId = 0, long memberId = 0)
        {
            InitializeComponent();
            InitTableMemberRelative();
            RegisterEvent();
            this.OperatingMode = operationMode;
            this.MemberId = memberId;
            this.OrgId = orgId;
            this.SubOrgId = subOrgId;
        }

        private void RegisterEvent()
        {
            Padding padding = colImage.DefaultCellStyle.Padding;
            ImageHeight = (colImage.Width - padding.Left - padding.Right) / 4 * 3;

            btnCancel.Click += OnButtonCancelClicked;
            btnConfirm.Click += OnButtonConfirmClicked;
            btnRefresh.Click += OnButtonRefreshClicked;
            btnChooseImage.Click += btnChooseImage_Click;

            dgvMemberRelativeList.Invalidated += dgvMemberRelativeList_Invalidated;

            btnAddMemberRelative.Click += btnAddMemberRelative_Click;
            btnUpdateMemberRelative.Click += btnUpdateMemberRelative_Click;
            btnRemoveMemberRelative.Click += btnRemoveMemberRelative_Click;
            btnReloadMemberRelative.Click += (s, e) => LoadMember();

            Shown += OnFormShown;
        }

        #region Event's

        private void OnFormShown(object sender, EventArgs e)
        {
            // btnConfirm.Enabled = btnRefresh.Enabled = true;
            //  Switch view to corresponding mode
            switch (OperatingMode)
            {
                case ModeAdding:
                    InitFormAddMember();
                    break;
                case ModeUpdating:
                    InitFormUpdateMember();
                    LoadMember();
                    break;
                default:
                    throw new ArgumentException("Invalid operating mode!");
            }
            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
        }

        private void dgvMemberRelativeList_Invalidated(object sender, InvalidateEventArgs e)
        {
            try
            {
                for (int i = 0; i < dgvMemberRelativeList.Rows.Count; i++)
                {
                    dgvMemberRelativeList.Rows[i].Height = ImageHeight;
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        #region Member

        private void OnLoadMemberWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                OriginalMember = OrganizationFactory.Instance.GetChannel().GetMemberById(StorageService.CurrentSessionId, MemberId);
                MemberRelativeList = OrganizationFactory.Instance.GetChannel().GetMemberRelativeList(StorageService.CurrentSessionId, MemberId);
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

        private void OnLoadMemberWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if (OriginalMember != null)
            {
                ToModel(OriginalMember);
            }
            if (MemberRelativeList != null && MemberRelativeList.Count > 0)
            {
                foreach (MemberRelativeDto memberRelative in MemberRelativeList)
                {
                    DataRow row = dbMemberList.NewRow();
                    row.BeginEdit();

                    row[colMemberRelativeId.DataPropertyName] = memberRelative.Id;
                    row[colImage.DataPropertyName] = string.IsNullOrEmpty(memberRelative.ImgRelative)
                        ? (Bitmap)global::SystemMgtComponent.Properties.Resources.NoImage
                        : (Bitmap)ImageUtils.Base64ToImage(memberRelative.ImgRelative);
                    row[colContactName.DataPropertyName] = memberRelative.FullName;
                    row[colPhone.DataPropertyName] = memberRelative.Phone;
                    row[colEmail.DataPropertyName] = memberRelative.Email;
                    row[colAddress.DataPropertyName] = memberRelative.Address;

                    row.EndEdit();
                    dbMemberList.Rows.Add(row);
                }
            }
        }

        private void OnLoadAddMemberWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = AddOrUpdateMember = OrganizationFactory.Instance.GetChannel().AddMember(StorageService.CurrentSessionId, AddOrUpdateMember);
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

        private void OnLoadAddMemberWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if (e.Result != null)
            {
                MessageBoxManager.ShowInfoMessageBox(this, "Đã thêm thành viên mới thành công!");
                PostAction = DialogPostAction.SUCCESS;
                Hide();
            }
        }

        private void OnLoadUpdateMemberWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = (int)Status.SUCCESS == OrganizationFactory.Instance.GetChannel().UpdateMember(StorageService.CurrentSessionId, AddOrUpdateMember);
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

        private void OnLoadUpdateMemberWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if ((bool)e.Result)
            {
                MessageBoxManager.ShowInfoMessageBox(this, "Đã cập nhật thành viên thành công!");
                PostAction = DialogPostAction.SUCCESS;
                Hide();
            }
        }

        #endregion

        #region Buttons

        private void OnButtonConfirmClicked(object sender, EventArgs e)
        {
            switch (OperatingMode)
            {
                case ModeAdding:
                    AddMember();
                    break;
                case ModeUpdating:
                    UpdateMember();
                    break;
                default:
                    break;
            }

        }

        private void OnButtonRefreshClicked(object sender, EventArgs e)
        {
            ClearEmptyControl();
        }

        private void OnButtonCancelClicked(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            picMember.Image = OpenFileDialogUtils.SelectImageDialog();
        }

        void btnRemoveMemberRelative_Click(object sender, EventArgs e)
        {
            long memberRelativeId = Convert.ToInt64(dgvMemberRelativeList.SelectedRows[0].Cells[colMemberRelativeId.Name].Value.ToString());
            if (MemberId > 0 && memberRelativeId > 0)
            {
                if (OrganizationFactory.Instance.GetChannel().RemoveMemberRelative(StorageService.CurrentSessionId, memberRelativeId) == (int)Status.SUCCESS)
                {
                    MessageBoxManager.ShowInfoMessageBox(this, "Đã hủy người liên hệ thành công!");
                    LoadMember();
                }
            }
        }

        void btnUpdateMemberRelative_Click(object sender, EventArgs e)
        {
            long memberRelativeId = Convert.ToInt64(dgvMemberRelativeList.SelectedRows[0].Cells[colMemberRelativeId.Name].Value.ToString());
            if (MemberId > 0 && memberRelativeId > 0)
            {
                FrmAddOrEditMemberContact dialog = new FrmAddOrEditMemberContact(FrmAddOrEditMemberContact.ModeUpdating, MemberId, memberRelativeId);
                dialog.rm = rm;
                dialog.session = StorageService.CurrentSessionId;
                dialog.ShowDialog();
                dialog.Dispose();
                LoadMember();
            }
        }

        private void btnAddMemberRelative_Click(object sender, EventArgs e)
        {
            FrmAddOrEditMemberContact dialog = new FrmAddOrEditMemberContact(FrmAddOrEditMemberContact.ModeAdding, MemberId);
            dialog.rm = rm;
            dialog.session = StorageService.CurrentSessionId;
            dialog.ShowDialog();
            dialog.Dispose();
            LoadMember();
        }

        #endregion

        #endregion

        #region Event's support

        #region Binding Data

        private void ToModel(sWorldModel.TransportData.Member memberCus)
        {
            txtCode.Text = memberCus.Code;
            txtFirstName.Text = memberCus.FirstName;
            txtLastName.Text = memberCus.LastName;

            if (string.IsNullOrEmpty(memberCus.BirthDate))
            {
                dtpBirthDate.Checked = false;
            }
            else
            {
                dtpBirthDate.Checked = true;
                dtpBirthDate.Value = memberCus.BirthDate.ToDateFormatString();
            }

            rbtnGenderMale.Checked = GenderExtMethod.ToGender(memberCus.Gender) == Gender.Male;
            rbtnGenderFemale.Checked = GenderExtMethod.ToGender(memberCus.Gender) == Gender.Female;
            rbtnGenderOther.Checked = GenderExtMethod.ToGender(memberCus.Gender) == Gender.Other;

            txtNationality.Text = memberCus.Nationality;
            txtCompany.Text = memberCus.Companyname;
            txtDegree.Text = memberCus.Degree;
            txtPosition.Text = memberCus.Position;
            txtPhoneNo.Text = memberCus.PhoneNo;
            txtEmail.Text = memberCus.Email;
            txtPermanentAddress.Text = memberCus.PermanentAddress;
            txtTemporaryAddress.Text = memberCus.TemporaryAddress;
            picMember.Image = ImageUtils.Base64ToImage(memberCus.ImgMember);
        }

        private sWorldModel.TransportData.Member ToEntity()
        {
            sWorldModel.TransportData.Member member = new sWorldModel.TransportData.Member();

            member.OrgId = OrgId;
            member.SubOrgId = SubOrgId;
            member.Code = txtCode.Text.Trim();
            member.FirstName = txtFirstName.Text.Trim();
            member.LastName = txtLastName.Text.Trim();
            member.BirthDate = dtpBirthDate.Value.ToStringFormatDate();

            member.Gender = rbtnGenderMale.Checked ? (int)Gender.Male
                : rbtnGenderFemale.Checked ? (int)Gender.Female
                : rbtnGenderOther.Checked ? (int)Gender.Other : 0;

            member.Nationality = txtNationality.Text.Trim();
            member.Companyname = txtCompany.Text.Trim();
            member.Degree = txtDegree.Text.Trim();
            member.Position = txtPosition.Text.Trim();
            member.PhoneNo = txtPhoneNo.Text.Trim();
            member.Email = txtEmail.Text.Trim();
            member.PermanentAddress = txtPermanentAddress.Text.Trim();
            member.TemporaryAddress = txtTemporaryAddress.Text.Trim();

            return member;
        }

        #endregion

        #region SetControl

        private void ClearEmptyControl()
        {
            txtCode.Text =
            txtFirstName.Text =
            txtLastName.Text =
            dtpBirthDate.Text =
            txtNationality.Text =
            txtCompany.Text =
            txtDegree.Text =
            txtPosition.Text =
            txtPhoneNo.Text =
            txtEmail.Text =
            txtPermanentAddress.Text =
            txtPermanentAddress.Text = string.Empty;

            rbtnGenderMale.Checked = true;
            rbtnGenderFemale.Checked = false;
            rbtnGenderOther.Checked = false;

            txtCode.Focus();
        }

        private void SetControl(bool isView)
        {
            txtCode.ReadOnly =
            txtFirstName.ReadOnly =
            txtLastName.ReadOnly =
            txtNationality.ReadOnly =
            txtCompany.ReadOnly =
            txtDegree.ReadOnly =
            txtPosition.ReadOnly =
            txtPhoneNo.ReadOnly =
            txtEmail.ReadOnly =
            txtPermanentAddress.ReadOnly =
            txtPermanentAddress.ReadOnly = isView;

            dtpBirthDate.Enabled =
            rbtnGenderMale.Enabled =
            rbtnGenderFemale.Enabled =
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
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessageValidate(rm, MessageValidate.MemId), MessageValidate.GetErrorTitle(rm));
                return false;
            }

            if (string.IsNullOrEmpty(txtFirstName.Text))
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessageValidate(rm, MessageValidate.LastName), MessageValidate.GetErrorTitle(rm));
                return false;
            }

            if (string.IsNullOrEmpty(txtLastName.Text))
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessageValidate(rm, MessageValidate.MemName), MessageValidate.GetErrorTitle(rm));
                return false;
            }

            if (string.IsNullOrEmpty(txtPhoneNo.Text))
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessageValidate(rm, MessageValidate.Phone), MessageValidate.GetErrorTitle(rm));
                return false;
            }

            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessageValidate(rm, MessageValidate.Email1), MessageValidate.GetErrorTitle(rm));
                return false;
            }

            if (!StringUtils.CheckPhoneNumber(txtPhoneNo.Text))
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessageDataFail(rm, MessageValidate.PhoneFirst), MessageValidate.GetErrorTitle(rm));
                return false;
            }

            if (!StringUtils.CheckEmail(txtEmail.Text))
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessageDataFail(rm, MessageValidate.Email), MessageValidate.GetErrorTitle(rm));
                return false;
            }


            return true;
        }

        #endregion

        #region Member

        private void InitFormAddMember()
        {
            this.Text = lbTitle.Text = "Thêm Thành Viên Mới";
            lbNote.Text = "Thêm một thành viên mới vào hệ thống.";
            SetControl(false);
            SetShowOrHideButton(true);
            ClearEmptyControl();

            bgwAddMember = new BackgroundWorker();
            bgwAddMember.WorkerSupportsCancellation = true;
            bgwAddMember.DoWork += OnLoadAddMemberWorkerDoWork;
            bgwAddMember.RunWorkerCompleted += OnLoadAddMemberWorkerRunWorkerCompleted;
        }

        private void InitFormUpdateMember()
        {
            this.Text = lbTitle.Text = "Cập Nhật Thông Tin Thành Viên";
            lbNote.Text = "Cập nhật thành viên trong hệ thống.";
            SetControl(false);
            SetShowOrHideButton(true);

            bgwLoadMember = new BackgroundWorker();
            bgwLoadMember.WorkerSupportsCancellation = true;
            bgwLoadMember.DoWork += OnLoadMemberWorkerDoWork;
            bgwLoadMember.RunWorkerCompleted += OnLoadMemberWorkerRunWorkerCompleted;

            bgwUpdateMember = new BackgroundWorker();
            bgwUpdateMember.WorkerSupportsCancellation = true;
            bgwUpdateMember.DoWork += OnLoadUpdateMemberWorkerDoWork;
            bgwUpdateMember.RunWorkerCompleted += OnLoadUpdateMemberWorkerRunWorkerCompleted;
        }

        private void InitTableMemberRelative()
        {
            dbMemberList = new DataTable();
            dbMemberList.Columns.Add(colMemberRelativeId.DataPropertyName);
            dbMemberList.Columns.Add(colImage.DataPropertyName, typeof(Image));
            dbMemberList.Columns.Add(colContactName.DataPropertyName);
            dbMemberList.Columns.Add(colPhone.DataPropertyName);
            dbMemberList.Columns.Add(colEmail.DataPropertyName);
            dbMemberList.Columns.Add(colAddress.DataPropertyName);
            dgvMemberRelativeList.DataSource = dbMemberList;
        }

        private void LoadMember()
        {
            if (MemberId > 0 && !bgwLoadMember.IsBusy)
            {
                dbMemberList.Rows.Clear();
                bgwLoadMember.RunWorkerAsync();
            }
        }

        private void AddMember()
        {
            if (ValidateData() && MessageBoxManager.ShowQuestionMessageBox(this, "Bạn có chắc muốn thêm thành viên này vào hệ thống không?") == System.Windows.Forms.DialogResult.Yes)
            {
                if (!bgwAddMember.IsBusy)
                {
                    AddOrUpdateMember = ToEntity();
                    bgwAddMember.RunWorkerAsync();
                }
            }
        }

        private void UpdateMember()
        {
            if (ValidateData() && MessageBoxManager.ShowQuestionMessageBox(this, "Bạn có chắc muốn cập nhật thành viên này không?") == System.Windows.Forms.DialogResult.Yes)
            {
                if (!bgwUpdateMember.IsBusy)
                {
                    AddOrUpdateMember = ToEntity();
                    bgwUpdateMember.RunWorkerAsync();
                }
            }
        }

        #endregion

        #endregion
    }
}
