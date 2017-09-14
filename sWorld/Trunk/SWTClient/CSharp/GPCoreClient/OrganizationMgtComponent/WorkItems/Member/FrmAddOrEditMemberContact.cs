using CommonControls;
using CommonHelper.Constants;
using CommonHelper.Utils;
using JavaCommunication;
using JavaCommunication.Factory;
using Microsoft.Practices.CompositeUI;
using sWorldModel;
using sWorldModel.Exceptions;
using sWorldModel.TransportData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;

namespace SystemMgtComponent.WorkItems.Member
{
    public partial class FrmAddOrEditMemberContact : CommonControls.Custom.CommonDialog
    {
        public const byte ModeAdding = 1;
        public const byte ModeUpdating = 2;

        private byte OperatingMode;
        private long MemberRelativeId;
        private long MemberId;
        public ResourceManager rm = null;

        private MemberRelativeDto OriginalMemberRelative;
        private MemberRelativeDto AddOrUpdateMemberRelative;

        private BackgroundWorker bgwLoadMemberRelative;
        private BackgroundWorker bgwAddMemberRelative;
        private BackgroundWorker bgwUpdateMemberRelative;

        public DialogPostAction PostAction { get; private set; }

        public string session { set; get; }

        public FrmAddOrEditMemberContact(byte operationMode,long memberId, long memberRelativeId = 0)
        {
            InitializeComponent();
            RegisterEvent();
            this.MemberRelativeId = memberRelativeId;
            this.MemberId = memberId;
            this.OperatingMode = operationMode;
        }

        private void RegisterEvent()
        {
            btnCancel.Click += OnButtonCancelClicked;
            btnConfirm.Click += OnButtonConfirmClicked;
            btnRefresh.Click += OnButtonRefreshClicked;

            btnChooseImage.Click += btnChooseImage_Click;

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
                    InitFormMemberRelativeApp();
                    break;
                case ModeUpdating:
                    InitFormUpdateMemberRelative();
                    LoadMemberRelative();
                    break;
                default:
                    throw new ArgumentException("Invalid operating mode!");
            }

            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
        }

        #region Member Relative

        private void OnLoadAppWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                OriginalMemberRelative = OrganizationFactory.Instance.GetChannel().GetMemberRelativeById(session, MemberRelativeId);
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

        private void OnLoadMemberRelativeWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if (e.Result != null)
            {
                ToModel(OriginalMemberRelative);
                //PopulateGroupDataToView();
                //btnConfirm.Enabled = btnRefresh.Enabled = true;
            }
        }

        private void OnLoadMemberRelativeOrgWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = (int)Status.SUCCESS == OrganizationFactory.Instance.GetChannel().AddMemberRelative(session, AddOrUpdateMemberRelative);
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

        private void OnLoadAddMemberRelativeWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if ((bool)e.Result)
            {
                MessageBoxManager.ShowInfoMessageBox(this, "Đã thêm người liên hệ mới thành công!");
                PostAction = DialogPostAction.SUCCESS;
                Hide();
            }
        }

        private void OnLoadUpdateMemberRelativeWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = (int)Status.SUCCESS == OrganizationFactory.Instance.GetChannel().UpdateMemberRelative(session, AddOrUpdateMemberRelative);
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

        private void OnLoadUpdateMemberRelativeWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if ((bool)e.Result)
            {
                MessageBoxManager.ShowInfoMessageBox(this, "Đã cập nhật người liên hệ thành công!");
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
                    AddMemberRelative();
                    break;
                case ModeUpdating:
                    UpdateMemberRelative();
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

        void btnChooseImage_Click(object sender, EventArgs e)
        {
            picMember.Image = OpenFileDialogUtils.SelectImageDialog();
           
        }

        #endregion

        #endregion

        #region Event's support

        #region Binding Data

        private void ToModel(MemberRelativeDto memberRelative)
        {
            tbxContactName.Text = memberRelative.FullName;
            tbxContactPhone.Text = memberRelative.Phone;
            tbxContactEmail.Text = memberRelative.Email;
            tbxContactAddress.Text = memberRelative.Address;
            picMember.Image = ImageUtils.Base64ToImage(memberRelative.ImgRelative);
        }

        private MemberRelativeDto ToEntity()
        {
            MemberRelativeDto memberRelative = new MemberRelativeDto();
            memberRelative = OriginalMemberRelative != null ? OriginalMemberRelative : memberRelative;

            memberRelative.MemberId = MemberId;
            memberRelative.FullName = tbxContactName.Text.Trim();
            memberRelative.Phone = tbxContactPhone.Text.Trim();
            memberRelative.Email = tbxContactEmail.Text.Trim();
            memberRelative.Address = tbxContactAddress.Text.Trim();
            memberRelative.ImgRelative = ImageUtils.ImageToBase64(picMember.Image);

            return memberRelative;
        }

        #endregion

        #region SetControl

        private void ClearEmptyControl()
        {
            tbxContactName.Text =
            tbxContactPhone.Text =
            tbxContactEmail.Text =
            tbxContactAddress.Text = string.Empty;
            tbxContactName.Focus();
        }

        private void SetControl(bool isView)
        {
           tbxContactName.ReadOnly =
           tbxContactPhone.ReadOnly =
           tbxContactEmail.ReadOnly =
           tbxContactAddress.ReadOnly = isView;
        }

        private void SetShowOrHideButton(bool isView)
        {
            btnConfirm.Enabled = btnRefresh.Enabled = isView;
        }

        #endregion

        #region ValidateData

        private bool ValidateData()
        {
            if (!string.IsNullOrEmpty(tbxContactPhone.Text) && !StringUtils.CheckPhoneNumber(tbxContactPhone.Text))
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessageDataFail(rm, MessageValidate.PhoneFirst), MessageValidate.GetErrorTitle(rm));
                return false;
            }

            if (!string.IsNullOrEmpty(tbxContactEmail.Text) && !StringUtils.CheckEmail(tbxContactEmail.Text))
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessageDataFail(rm, MessageValidate.Email), MessageValidate.GetErrorTitle(rm));
                return false;
            }
            return true;
        }

        #endregion

        #region Member Relative

        private void InitFormMemberRelativeApp()
        {
            this.Text = lbTitle.Text = "Thêm Người Liên Hệ Mới";
            lbNote.Text = "Thêm người liên hệ mới vào hệ thống.";
            SetControl(false);
            SetShowOrHideButton(true);
            ClearEmptyControl();

            bgwAddMemberRelative = new BackgroundWorker();
            bgwAddMemberRelative.WorkerSupportsCancellation = true;
            bgwAddMemberRelative.DoWork += OnLoadMemberRelativeOrgWorkerDoWork;
            bgwAddMemberRelative.RunWorkerCompleted += OnLoadAddMemberRelativeWorkerRunWorkerCompleted;
        }

        private void InitFormUpdateMemberRelative()
        {
            this.Text = lbTitle.Text = "Cập Nhật Thông Tin Người Liên Hệ";
            lbNote.Text = "Cập nhật người liên hệ trong hệ thống.";
            SetControl(false);
            SetShowOrHideButton(true);

            bgwLoadMemberRelative = new BackgroundWorker();
            bgwLoadMemberRelative.WorkerSupportsCancellation = true;
            bgwLoadMemberRelative.DoWork += OnLoadAppWorkerDoWork;
            bgwLoadMemberRelative.RunWorkerCompleted += OnLoadMemberRelativeWorkerRunWorkerCompleted;

            bgwUpdateMemberRelative = new BackgroundWorker();
            bgwUpdateMemberRelative.WorkerSupportsCancellation = true;
            bgwUpdateMemberRelative.DoWork += OnLoadUpdateMemberRelativeWorkerDoWork;
            bgwUpdateMemberRelative.RunWorkerCompleted += OnLoadUpdateMemberRelativeWorkerRunWorkerCompleted;
        }

        private void LoadMemberRelative()
        {
            if (!bgwLoadMemberRelative.IsBusy && MemberRelativeId > 0)
            {
                bgwLoadMemberRelative.RunWorkerAsync();
            }
        }

        private void AddMemberRelative()
        {
            if (ValidateData() && MessageBoxManager.ShowQuestionMessageBox(this, "Bạn có chắc muốn thêm người liên hệ này vào hệ thống không?") == System.Windows.Forms.DialogResult.Yes)
            {
                if (!bgwAddMemberRelative.IsBusy)
                {
                    AddOrUpdateMemberRelative = ToEntity();
                    bgwAddMemberRelative.RunWorkerAsync();
                }
            }
        }

        private void UpdateMemberRelative()
        {
            if (ValidateData() && MessageBoxManager.ShowQuestionMessageBox(this, "Bạn có chắc muốn cập nhật người liên hệ này không?") == System.Windows.Forms.DialogResult.Yes)
            {
                if (!bgwUpdateMemberRelative.IsBusy)
                {
                    AddOrUpdateMemberRelative = ToEntity();
                    bgwUpdateMemberRelative.RunWorkerAsync();
                }
            }
        }

        #endregion

        #endregion
    }
}
