using CommonControls;
using Microsoft.Practices.CompositeUI;
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
using sWorldModel;
using JavaCommunication;
using sWorldModel.TransportData.Constants;
using sWorldModel.TransportData;
using CommonHelper.Utils;
using System.Net.Mail;
using System.Text.RegularExpressions;
using CommonHelper.Constants;
using System.Resources;
using System.Globalization;
using SystemMgtComponent.WorkItems.Member;
using CommonHelper.Config;

namespace SystemMgtComponent.WorkItems
{
    public partial class FrmAddOrUpdateMember : CommonControls.Custom.CommonDialog
    {
        #region Properties

        public const byte ModeAdding = 1;
        public const byte ModeUpdating = 2;
        private byte OperatingMode;
        private ResourceManager rm;

        private sWorldModel.TransportData.Member OriginalMember;
        private sWorldModel.TransportData.Member AddOrUpdateMember;
        private sWorldModel.TransportData.Member memberCheck;

        private long orgId;
        private long SuborgID;
        private long MemberId;

        private BackgroundWorker bgwLoadMember;
        private BackgroundWorker bgwAddMember;
        private BackgroundWorker bgwUpdateMember;
        private BackgroundWorker bgwGetemberByCode;

        
        public DialogPostAction PostAction { get; private set; }

        private ILocalStorageService storageService;
        [ServiceDependency]
        public ILocalStorageService StorageService
        {
            get { return storageService; }
            set { storageService = value; }
        }

        #endregion

        public FrmAddOrUpdateMember(byte operationMode, long orgId = 0, long parentOrgId = 0, long memberId = 0)
        {
            InitializeComponent();
            RegisterEvent();
            this.OperatingMode = operationMode;
            this.MemberId = memberId;
            this.orgId = orgId;
            this.SuborgID = parentOrgId;
            LoadMemberTitle();  //load title
        }

        private void LoadMemberTitle()
        {
            String values = MemberTitle.Instance.Values;
            if("" == values)
            {
                cbxTitleMember.Visible = false;
                cbxTitleMember.Items.Add("");
            }
            else
            {
                cbxTitleMember.Visible = true;
                

            }

            String[] titles = values.Split('|');
            foreach(String title in titles)
            {
                cbxTitleMember.Items.Add(title);
            }
            cbxTitleMember.SelectedIndex = 1;
        }

        private void RegisterEvent()
        {
            btnCancel.Click += OnButtonCancelClicked;
            btnConfirm.Click += OnButtonConfirmClicked;
            btnRefresh.Click += OnButtonRefreshClicked;
            Shown += OnFormShown;
        }

        #region Event's

        private void OnFormShown(object sender, EventArgs e)
        {
            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
            this.Text = MessageValidate.GetMessage(rm, this.Name);
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
                    throw new ArgumentException(MessageValidate.GetMessage(rm, "ArgumentException"));
            }

        }

        #region Member


        private void OnLoadMemberWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                OriginalMember = OrganizationFactory.Instance.GetChannel().GetMemberById(StorageService.CurrentSessionId, MemberId);
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

        private void OnLoadMemberWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if (e.Result != null)
            {
                ToModel(OriginalMember);
            }
        }

        private void OnLoadAddMemberWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = OrganizationFactory.Instance.GetChannel().AddMember(StorageService.CurrentSessionId, AddOrUpdateMember);
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
            if (e.Result != null && e.Result is sWorldModel.TransportData.Member)
            {
                PostAction = DialogPostAction.SUCCESS;
                Hide();
            }
        }
        private bool CheckMemberCode(string code)
        {
            try
            {
                memberCheck = OrganizationFactory.Instance.GetChannel().GetMemberByCode(StorageService.CurrentSessionId, orgId, code);
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
            return memberCheck != null;
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

            rbtmale.Checked = GenderExtMethod.ToGender(memberCus.Gender) == Gender.Male;
            rbtfemale.Checked = GenderExtMethod.ToGender(memberCus.Gender) == Gender.Female;
            rbtnGenderOther.Checked = GenderExtMethod.ToGender(memberCus.Gender) == Gender.Other;

            txtNationality.Text = memberCus.Nationality;
            txtCompany.Text = memberCus.Companyname;
            txtDegree.Text = memberCus.Degree;
            txtPosition.Text = memberCus.Position;
            txtPhoneNo.Text = memberCus.PhoneNo;
            txtEmail.Text = memberCus.Email;
            txtPermanentAddress.Text = memberCus.PermanentAddress;
            txtTemporaryAddress.Text = memberCus.TemporaryAddress;

            tbxIdentityCard.Text = memberCus.IdentityCard;
            tbxIdentityCardIssue.Text = memberCus.IdentityCardIssue;
            if (string.IsNullOrEmpty(memberCus.IdentityCardIssueDate))
            {
                dtpIdentityCard.Checked = false;
            }
            else
            {
                dtpIdentityCard.Checked = true;
                dtpIdentityCard.Value = memberCus.IdentityCardIssueDate.ToDateFormatString();
            }

            tbxContactName.Text = memberCus.ContactName;
            tbxContactPhone.Text = memberCus.ContactPhone;
            tbxContactEmail.Text = memberCus.ContactEmail;
            tbxContactAddress.Text = memberCus.ContactAddress;
        }

        private sWorldModel.TransportData.Member ToEntity(bool editmode)
        {
            sWorldModel.TransportData.Member member = null;
            if (!editmode)
            {
                member = new sWorldModel.TransportData.Member();

                member.Id = this.MemberId;
                member.OrgId = orgId;
            }
            else
            {
                member = OrganizationFactory.Instance.GetChannel().GetMemberById(StorageService.CurrentSessionId, MemberId);
            }
          

            member.SubOrgId = SuborgID;
            member.Code = txtCode.Text.Trim();
            member.FirstName = txtFirstName.Text.Trim();
            member.LastName = txtLastName.Text.Trim();
            member.BirthDate = dtpBirthDate.Value.ToStringFormatDate();

            member.Gender = rbtmale.Checked ? (int)Gender.Male
                : rbtfemale.Checked ? (int)Gender.Female
                : rbtnGenderOther.Checked ? (int)Gender.Other : 0;

            member.Nationality = txtNationality.Text.Trim();
            member.Companyname = txtCompany.Text.Trim();
            member.Degree = txtDegree.Text.Trim();
            member.Position = txtPosition.Text.Trim();
            member.PhoneNo = txtPhoneNo.Text.Trim();
            member.Email = txtEmail.Text.Trim();
            member.PermanentAddress = txtPermanentAddress.Text.Trim();
            member.TemporaryAddress = txtTemporaryAddress.Text.Trim();

            member.IdentityCard = tbxIdentityCard.Text;
            member.IdentityCardIssue = tbxIdentityCardIssue.Text;
            member.IdentityCardIssueDate = dtpIdentityCard.Value.ToStringFormatDate();

            member.ContactName = tbxContactName.Text.Trim();
            member.ContactPhone = tbxContactPhone.Text.Trim();
            member.ContactEmail = tbxContactEmail.Text.Trim();
            member.ContactAddress = tbxContactAddress.Text.Trim();
           
            member.Title = cbxTitleMember.Text;

            return member;
        }

        //private sWorldModel.TransportData.Member ToEntityEdit()
        //{
        //    sWorldModel.TransportData.Member member = OrganizationFactory.Instance.GetChannel().GetMemberById(StorageService.CurrentSessionId, MemberId);
        //    if (member != null)
        //    {
        //        member.Code = txtCode.Text.Trim();
        //        member.FirstName = txtFirstName.Text.Trim();
        //        member.LastName = txtLastName.Text.Trim();
        //        member.BirthDate = dtpBirthDate.Value.ToStringFormatDate();

        //        member.Gender = rbtmale.Checked ? (int)Gender.Male
        //            : rbtfemale.Checked ? (int)Gender.Female
        //            : rbtnGenderOther.Checked ? (int)Gender.Other : 0;

        //        member.Nationality = txtNationality.Text.Trim();
        //        member.Companyname = txtCompany.Text.Trim();
        //        member.Degree = txtDegree.Text.Trim();
        //        member.Position = txtPosition.Text.Trim();
        //        member.PhoneNo = txtPhoneNo.Text.Trim();
        //        member.Email = txtEmail.Text.Trim();
        //        member.PermanentAddress = txtPermanentAddress.Text.Trim();
        //        member.TemporaryAddress = txtTemporaryAddress.Text.Trim();

        //        member.IdentityCard = tbxIdentityCard.Text;
        //        member.IdentityCardIssue = tbxIdentityCardIssue.Text;
        //        member.IdentityCardIssueDate = dtpIdentityCard.Value.ToStringFormatDate();

        //        member.ContactName = tbxContactName.Text.Trim();
        //        member.ContactPhone = tbxContactPhone.Text.Trim();
        //        member.ContactEmail = tbxContactEmail.Text.Trim();
        //        member.ContactAddress = tbxContactAddress.Text.Trim();
        //        member.Title = cbxTitleMember.Text;
        //    }

        //    return member;
        //}


        #endregion

        #region SetControl

        private void ClearEmptyControl()
        {
            txtCode.Text =
            txtFirstName.Text =
            txtLastName.Text =
            dtpBirthDate.Text =
            txtNationality.Text =
            tbxIdentityCard.Text =
            tbxIdentityCardIssue.Text =
            txtCompany.Text =
            txtDegree.Text =
            txtPosition.Text =
            txtPhoneNo.Text =
            txtEmail.Text =
            txtTemporaryAddress.Text =
            tbxContactName.Text =
            tbxContactPhone.Text =
            tbxContactEmail.Text =
            tbxContactAddress.Text =
            txtPermanentAddress.Text =
            txtPermanentAddress.Text = string.Empty;

            rbtmale.Checked = true;
            rbtfemale.Checked = false;
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
            rbtmale.Enabled =
            rbtfemale.Enabled =
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
            if (string.IsNullOrEmpty(txtCode.Text.Trim()))
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessageValidate(rm, MessageValidate.MemId), MessageValidate.GetErrorTitle(rm));
                txtCode.Focus();
                return false;
            }
           

            if (string.IsNullOrEmpty(txtFirstName.Text))
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessageValidate(rm, MessageValidate.MemName), MessageValidate.GetErrorTitle(rm));
                txtFirstName.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtLastName.Text))
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessageValidate(rm, MessageValidate.FirstName), MessageValidate.GetErrorTitle(rm));
                txtLastName.Focus();
                return false;
            }

            if (!string.IsNullOrEmpty(txtPhoneNo.Text) && !StringUtils.CheckPhoneNumber(txtPhoneNo.Text))
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessageDataFail(rm, MessageValidate.PhoneFirst), MessageValidate.GetErrorTitle(rm));
                txtPhoneNo.Focus();
                return false;
            }
            if (!string.IsNullOrEmpty(tbxIdentityCard.Text) && !StringUtils.CheckPhoneNumber(tbxIdentityCard.Text))
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessageDataFail(rm, MessageValidate.IndentifineCard), MessageValidate.GetErrorTitle(rm));
                tbxIdentityCard.Focus();
                return false;
            }

            if (!string.IsNullOrEmpty(txtEmail.Text) && !StringUtils.CheckEmail(txtEmail.Text))
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessageDataFail(rm, MessageValidate.Email), MessageValidate.GetErrorTitle(rm));
                txtEmail.Focus();
                return false;
            }

            if (!string.IsNullOrEmpty(tbxContactPhone.Text) && !StringUtils.CheckPhoneNumber(tbxContactPhone.Text))
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessageDataFail(rm, MessageValidate.PhoneFirst), MessageValidate.GetErrorTitle(rm));
                tbxContactPhone.Focus();
                return false;
            }

            if (!string.IsNullOrEmpty(tbxContactEmail.Text) && !StringUtils.CheckEmail(tbxContactEmail.Text))
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessageDataFail(rm, MessageValidate.Email), MessageValidate.GetErrorTitle(rm));
                tbxContactEmail.Focus();
                return false;
            }
            //20170503 #Bug XXX bắt lỗi ngày cấp chứng minh nhân dân lớn hơn ngày hiện tại - Ten Nguyen Start
            if (!CompareDate(dtpIdentityCard.Value.Date))
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "dtpIdentityCard"), MessageValidate.GetErrorTitle(rm));
                dtpIdentityCard.Focus();
                return false;
            }
            if (!CompareDate(dtpBirthDate.Value.Date))
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "dtpBirthDate"), MessageValidate.GetErrorTitle(rm));
                dtpBirthDate.Focus();
                return false;
            }
            //20170503 #Bug XXX bắt lỗi ngày cấp chứng minh nhân dân lớn hơn ngày hiện tại - Ten Nguyen end
            return true;
        }
        /// <summary>
        /// Compare date to validate data
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        #endregion
        private bool CompareDate(DateTime date)
        {
            DateTime dtFromDate = date;
            DateTime dtToDate = DateTime.Now;
            TimeSpan difference = dtFromDate - dtToDate;
            double days = difference.TotalDays;

            if (days < 0)
            {
                return true;
            }
            return false;
        }
        #region Member

        private void InitFormAddMember()
        {
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
            this.Text = lblTitle_FrmAddOrUpdateMember.Text = MessageValidate.GetMessage(rm, "updateinformmember");
            lblNote_FrmAddOrUpdateMember.Text = MessageValidate.GetMessage(rm, "updateinformmembertosystem");
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

        private void LoadMember()
        {
            if (!bgwLoadMember.IsBusy && MemberId > 0)
            {
                bgwLoadMember.RunWorkerAsync();
            }
        }

        private void AddMember()
        {
            if (CheckMemberCode(txtCode.Text.Trim()))
            {
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessExist(rm, MessageValidate.MemCode), MessageValidate.GetErrorTitle(rm));
                txtCode.Focus();
                return;
            }
            if (ValidateData() && MessageBoxManager.ShowQuestionMessageBox(this, MessageValidate.GetQuestionAdd(rm, MessageValidate.Member)) == System.Windows.Forms.DialogResult.Yes)
            {
                if (!bgwAddMember.IsBusy)
                {
                    AddOrUpdateMember = ToEntity(false);
                    bgwAddMember.RunWorkerAsync();
                }
            }
        }

        private void UpdateMember()
        {
            if (ValidateData() && MessageBoxManager.ShowQuestionMessageBox(this, MessageValidate.GetQuestionUpdate(rm, MessageValidate.Member)) == System.Windows.Forms.DialogResult.Yes)
            {
                if (!bgwUpdateMember.IsBusy)
                {
                    AddOrUpdateMember = ToEntity(true);
                    bgwUpdateMember.RunWorkerAsync();
                }
            }
        }

        #endregion

        #endregion

        private void tbxIdentityCard_KeyPress(object sender, KeyPressEventArgs e)
        {
            //kí tự nhập vào phải là số hay ko
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
