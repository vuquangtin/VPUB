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
//using WcfServiceCommon;

namespace SystemMgtComponent.WorkItems.UserAdding
{
    public partial class FrmAddUser : CommonControls.Custom.CommonDialog
    {
        #region Properties

        private UsrAddUserOptions usrAddUserOptions;
        private UsrUserInfo usrPersonalInfo;
        private UsrMemberList usrMemberList;
        private UsrAccountInfo usrAccountInfo;

        private IUserAddingDialog previousDialog;
        private BackgroundWorker bgwAddUser;
        private ResourceManager rm;

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

        private UserSworld addedUser = null;
        public UserSworld AddedUser
        {
            get
            {
                return addedUser;
            }
        }

        #endregion

        public FrmAddUser()
        {
            InitializeComponent();

            bgwAddUser = new BackgroundWorker();
            bgwAddUser.WorkerSupportsCancellation = true;
            bgwAddUser.DoWork += bgwAddUser_DoWork;
            bgwAddUser.RunWorkerCompleted += bgwAddUser_RunWorkerCompleted;

            //usrAddUserOptions = new UsrAddUserOptions();
            //usrAddUserOptions.Dock = DockStyle.Fill;
            //usrAddUserOptions.StepCompleted += UsrAddUserOptions_Completed;
            //AcceptButton = usrAddUserOptions.AcceptButton;
            //CancelButton = usrAddUserOptions.CancelButton;

            //pnlMainContainer.Controls.Add(usrAddUserOptions);
            //pnlMainContainer.Controls.SetChildIndex(usrAddUserOptions, 0);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);


            usrPersonalInfo = new UsrUserInfo(UsrUserInfo.MODE_CREATE, null);
            usrPersonalInfo.Dock = DockStyle.Fill;
            usrPersonalInfo.StepCompleted += UsrPersonalInfo_Completed;
            usrPersonalInfo.StorageService = storageService;
            AcceptButton = usrPersonalInfo.AcceptButton;
            CancelButton = usrPersonalInfo.CancelButton;

            pnlMainContainer.Controls.Add(usrPersonalInfo);
            pnlMainContainer.Controls.SetChildIndex(usrPersonalInfo, 0);

            usrPersonalInfo.Focus();
            this.Text = MessageValidate.GetMessage(rm, this.Name);
        }

        private void UsrAddUserOptions_Completed(object sender, EventArgs e)
        {
            usrAddUserOptions.Visible = false;
            previousDialog = usrAddUserOptions;
            bool isCreateNew = (bool)usrAddUserOptions.ReturnData[0];

            if (usrAddUserOptions.PostAction == DialogPostAction.CANCEL)
            {
                this.Hide();
                return;
            }
            if (usrAddUserOptions.PostAction != DialogPostAction.NEXT)
            {
                return;
            }
            if (isCreateNew)
            {
                if (this.Controls.Contains(usrPersonalInfo))
                {
                    usrPersonalInfo.Visible = true;
                }
                else
                {
                    usrPersonalInfo = new UsrUserInfo(UsrUserInfo.MODE_CREATE, null);
                    usrPersonalInfo.Dock = DockStyle.Fill;
                    usrPersonalInfo.StepCompleted += UsrPersonalInfo_Completed;
                    pnlMainContainer.Controls.Add(usrPersonalInfo);
                    pnlMainContainer.Controls.SetChildIndex(usrPersonalInfo, 1);
                }
                AcceptButton = usrPersonalInfo.AcceptButton;
                CancelButton = usrPersonalInfo.CancelButton;
                usrPersonalInfo.Focus();
            }
            else
            {
                if (this.Controls.Contains(usrMemberList))
                {
                    usrMemberList.Visible = true;
                }
                else
                {
                    usrMemberList = workItem.Items.AddNew<UsrMemberList>();
                    usrMemberList.Dock = DockStyle.Fill;
                    usrMemberList.StepCompleted += UsrMemberList_StepCompleted;
                    pnlMainContainer.Controls.Add(usrMemberList);
                    pnlMainContainer.Controls.SetChildIndex(usrMemberList, 1);

                }
                AcceptButton = usrMemberList.AcceptButton;
                CancelButton = usrMemberList.CancelButton;
                usrMemberList.Focus();
            }
        }

        private bool ValidateUser(UserSworld user)
        {
            if (null != user)
            {
                if ( null != user.IdCardNo && StringUtils.IsNumber(user.IdCardNo.Trim()))
                {
                    MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessageDataFail(rm, MessageValidate.CMND), MessageValidate.GetErrorTitle(rm));
                    return false;
                }

                if (null != user.PhoneNo && !StringUtils.CheckPhoneNumber(user.PhoneNo.Trim()))
                {
                    MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessageDataFail(rm, MessageValidate.PhoneFirst), MessageValidate.GetErrorTitle(rm));
                    return false;
                }

                if (null != user.Email &&!StringUtils.CheckEmail(user.Email.Trim()))
                {
                    MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessageDataFail(rm, MessageValidate.Email), MessageValidate.GetErrorTitle(rm));
                    return false;
                }
            }
            return true;
        }

        private void UsrPersonalInfo_Completed(object sender, EventArgs e)
        {
            if (!ValidateUser(usrPersonalInfo.returnUser))
            {
                return;
            }
            usrPersonalInfo.Visible = false;
            previousDialog = usrPersonalInfo;
            if (usrPersonalInfo.PostAction == DialogPostAction.CANCEL)
            {
                this.Hide();
                return;
            }
            //if (usrPersonalInfo.PostAction == DialogPostAction.BACK)
            //{
            //    AcceptButton = usrAddUserOptions.AcceptButton;
            //    CancelButton = usrAddUserOptions.CancelButton;
            //    usrAddUserOptions.Visible = true;
            //    usrAddUserOptions.Focus();
            //    return;
            //}
            if (usrPersonalInfo.PostAction != DialogPostAction.NEXT)
            {
                return;
            }

            usrAccountInfo = workItem.Items.Get<UsrAccountInfo>("UsrAccountInfo");
            if (usrAccountInfo == null)
            {
                usrAccountInfo = workItem.Items.AddNew<UsrAccountInfo>("UsrAccountInfo");
            }
            else if (usrAccountInfo.IsDisposed)
            {
                workItem.SmartParts.Remove("UsrAccountInfo");
                usrAccountInfo = workItem.Items.AddNew<UsrAccountInfo>("UsrAccountInfo");
            }
            else
            {
                usrAccountInfo.Visible = true;
            }

            usrAccountInfo.Dock = DockStyle.Fill;
            usrAccountInfo.StepCompleted += UsrAccountInfo_StepCompleted;

            pnlMainContainer.Controls.Add(usrAccountInfo);
            pnlMainContainer.Controls.SetChildIndex(usrAccountInfo, 1);

            AcceptButton = usrAccountInfo.AcceptButton;
            CancelButton = usrAccountInfo.CancelButton;
            usrAccountInfo.Focus();
        }
        private void UsrMemberList_StepCompleted(object sender, EventArgs e)
        {
            usrMemberList.Visible = false;
            previousDialog = usrMemberList;
            if (usrMemberList.PostAction == DialogPostAction.CANCEL)
            {
                this.Hide();
                return;
            }
            if (usrMemberList.PostAction == DialogPostAction.BACK)
            {
                AcceptButton = usrAddUserOptions.AcceptButton;
                CancelButton = usrAddUserOptions.CancelButton;
                usrAddUserOptions.Visible = true;
                usrAddUserOptions.Focus();
                return;
            }
            if (usrMemberList.PostAction != DialogPostAction.NEXT)
            {
                return;
            }

            usrAccountInfo = workItem.Items.Get<UsrAccountInfo>("UsrAccountInfo");
            if (usrAccountInfo == null)
            {
                usrAccountInfo = workItem.Items.AddNew<UsrAccountInfo>("UsrAccountInfo");
            }
            else if (usrAccountInfo.IsDisposed)
            {
                workItem.SmartParts.Remove("UsrAccountInfo");
                usrAccountInfo = workItem.Items.AddNew<UsrAccountInfo>("UsrAccountInfo");
            }
            else
            {
                usrAccountInfo.Visible = true;
            }

            usrAccountInfo.Dock = DockStyle.Fill;
            usrAccountInfo.StepCompleted += UsrAccountInfo_StepCompleted;

            pnlMainContainer.Controls.Add(usrAccountInfo);
            pnlMainContainer.Controls.SetChildIndex(usrAccountInfo, 1);

            AcceptButton = usrAccountInfo.AcceptButton;
            CancelButton = usrAccountInfo.CancelButton;
            usrAccountInfo.Focus();
        }
        private void UsrAccountInfo_StepCompleted(object sender, EventArgs e)
        {
            if (usrAccountInfo.PostAction == DialogPostAction.CANCEL)
            {
                this.Hide();
                return;
            }
            if (usrAccountInfo.PostAction == DialogPostAction.BACK)
            {
                usrAccountInfo.Visible = false;
                if (usrPersonalInfo != null && usrPersonalInfo == previousDialog)
                {
                    AcceptButton = usrPersonalInfo.AcceptButton;
                    CancelButton = usrPersonalInfo.CancelButton;
                    usrPersonalInfo.Visible = true;
                    usrPersonalInfo.Focus();
                }
                else if (usrMemberList != null && usrMemberList == previousDialog)
                {
                    AcceptButton = usrMemberList.AcceptButton;
                    CancelButton = usrMemberList.CancelButton;
                    usrMemberList.Visible = true;
                    usrMemberList.Focus();
                }
                return;
            }
            if (usrAccountInfo.PostAction != DialogPostAction.CONFIRMED)
            {
                return;
            }

            if (!bgwAddUser.IsBusy)
            {
                /* 
                 * Chuẩn bị dữ liệu cho việc tạo user
                 * 0: tạo mới PersonalInfo (true) hay dùng TeacherId (false)
                 * 1: user name
                 * 2: password
                 * 3: group id
                 * 4: đối tượng PersonalInfo hoặc TeacherId
                 */
                object[] data = usrAccountInfo.ReturnData;
                object[] args = new object[5];
                args[1] = (string)data[0];
                args[2] = (string)data[1];
                args[3] = (long)data[2];
                if (previousDialog == usrPersonalInfo)
                {
                    args[0] = true;
                    args[4] = usrPersonalInfo.ReturnData[0];
                }
                else
                {
                    args[0] = false;
                    args[4] = usrMemberList.ReturnData[0];
                }
                bgwAddUser.RunWorkerAsync(args);
            }
        }

        private void bgwAddUser_DoWork(object sender, DoWorkEventArgs e)
        {
            object[] args = (object[])e.Argument;
            try
            {
                if ((bool)args[0])
                {
                    UserSworld user = (UserSworld)args[4];
                    user.UserName = (string)args[1];
                    user.PasswordHash = (string)args[2];
                    user.GroupId = (long)args[3];
                    addedUser = ManagerSystemFactory.Instance.GetChannel().AddUser(StorageService.CurrentSessionId, user);
                }
                else
                {
                    addedUser = ManagerSystemFactory.Instance.GetChannel().AddUser(StorageService.CurrentSessionId, (string)args[1], (string)args[2], (long)args[3], (long)args[4]);
                }
            }
            catch (TimeoutException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "TimeOutExceptionMessage"));
            }
            //catch (FaultException<WcfServiceFault> ex)
            //{
            //    MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
            //    switch (ex.Detail.Code)
            //    {
            //        case ErrorCodes.USERNAME_TAKEN:
            //            usrAccountInfo.ClearAndFocusUserNameField();
            //            break;
            //        case ErrorCodes.PASSWORD_TOO_WEAK:
            //            usrAccountInfo.ClearAndFocusPasswordField();
            //            break;
            //        default:
            //            break;
            //    }
            //}
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

        private void bgwAddUser_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if (addedUser != null)
            {
                this.Hide();
            }
            else
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "accExist"));
        }
    }
}