using CommonControls;
using CommonControls.Custom;
using sWorldModel;
using sWorldModel.Exceptions;
using sWorldModel.Model;
using Microsoft.Practices.CompositeUI;
//using sWorldCommunication;
using System;
using System.ComponentModel;
using System.ServiceModel;
using System.Windows.Forms;
using SystemMgtComponent.WorkItems.UserAdding;
using JavaCommunication.Factory;
using sWorldModel.TransportData;
using CommonHelper.Utils;
using System.Resources;
using CommonHelper.Constants;
//using WcfServiceCommon;

namespace SystemMgtComponent.WorkItems.Users
{
    public partial class FrmUpdatePersonalInfo : CommonControls.Custom.CommonDialog
    {
        #region Properties

        private UsrUserInfo ucStep21;
        private BackgroundWorker bgwLoadPersonalInfo;
        private BackgroundWorker bgwUpdatePersonalInfo;
        private ResourceManager rm;

        public long UserId { private get; set; }
        public DialogPostAction PostAction { get; private set; }
        public UserSworld UpdatedUser { get; set; }

        private WorkItem rootWorkItem;
        [ServiceDependency]
        public WorkItem RootWorkItem
        {
            set { rootWorkItem = value; }
        }

        private ILocalStorageService storageService;
        public ILocalStorageService StorageService
        {
            get
            {
                if (storageService == null)
                {
                    storageService = rootWorkItem.Services.Get<ILocalStorageService>();
                }
                return storageService;
            }
        }

        #endregion

        public FrmUpdatePersonalInfo()
        {
            InitializeComponent();

            this.bgwLoadPersonalInfo = new BackgroundWorker();
            this.bgwLoadPersonalInfo.WorkerSupportsCancellation = true;
            this.bgwLoadPersonalInfo.DoWork += bgwLoadPersonalInfo_DoWork;
            this.bgwLoadPersonalInfo.RunWorkerCompleted += bgwLoadPersonalInfo_RunWorkerCompleted;

            this.bgwUpdatePersonalInfo = new BackgroundWorker();
            this.bgwUpdatePersonalInfo.WorkerSupportsCancellation = true;
            this.bgwUpdatePersonalInfo.DoWork += bgwUpdatePersonalInfo_DoWork;
            this.bgwUpdatePersonalInfo.RunWorkerCompleted += bgwUpdatePersonalInfo_RunWorkerCompleted;

            this.Load += DlgUpdateUser_Load;
        }

        private void DlgUpdateUser_Load(object sender, EventArgs e)
        {
            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);

            this.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.Name);
            // Load personal info of user
            if (!bgwLoadPersonalInfo.IsBusy)
            {
                bgwLoadPersonalInfo.RunWorkerAsync();
            }
        }

        private void bgwLoadPersonalInfo_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                UpdatedUser = ManagerSystemFactory.Instance.GetChannel().GetUserById(StorageService.CurrentSessionId, this.UserId);
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
        }

        private void bgwLoadPersonalInfo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if (UpdatedUser == null)
            {
                return;
            }
            this.ucStep21 = new UsrUserInfo(UsrUserInfo.MODE_UPDATE, UpdatedUser);
            this.ucStep21.Dock = DockStyle.Fill;
            this.ucStep21.StepCompleted += ucStep21_StepCompleted;
            ucStep21.StorageService = storageService;
            this.lblIsLoading.Visible = false;
            this.panel1.Controls.Add(ucStep21);
            this.panel1.Controls.SetChildIndex(ucStep21, 0);
            this.AcceptButton = ucStep21.AcceptButton;
            this.CancelButton = ucStep21.CancelButton;
            ucStep21.Focus();
        }

        private bool ValidateUser(UserSworld user)
        {
            if (null != user)
            {
                if (null != user.IdCardNo && StringUtils.IsNumber(user.IdCardNo.Trim()))
                {
                    MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessageDataFail(rm, MessageValidate.CMND), MessageValidate.GetErrorTitle(rm));
                    return false;
                }

                if (null != user.PhoneNo && !StringUtils.CheckPhoneNumber(user.PhoneNo.Trim()))
                {
                    MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessageDataFail(rm, MessageValidate.PhoneFirst), MessageValidate.GetErrorTitle(rm));
                    return false;
                }

                if ( null != user.Email && !StringUtils.CheckEmail(user.Email))
                {
                    MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessageDataFail(rm, MessageValidate.Email), MessageValidate.GetErrorTitle(rm));
                    return false;
                }
            }
            return true;
        }

        private void ucStep21_StepCompleted(object sender, EventArgs e)
        {
            if (ucStep21.PostAction != CommonControls.DialogPostAction.CONFIRMED)
            {
                return;
            }
            if (!ValidateUser(ucStep21.returnUser))
                return;
            this.UpdatedUser = ucStep21.ReturnData[0] as UserSworld;
            if (MessageBoxManager.ShowQuestionMessageBox(this, MessageValidate.GetQuestionUpdate(rm, "account")) == DialogResult.Yes)
            {
                if (!bgwUpdatePersonalInfo.IsBusy)
                {
                    bgwUpdatePersonalInfo.RunWorkerAsync();
                }
            }
        }

        private void bgwUpdatePersonalInfo_DoWork(object sender, DoWorkEventArgs e)
        {
            if (this.UpdatedUser == null)
            {
                return;
            }
            try
            {
                ManagerSystemFactory.Instance.GetChannel().UpdateUser(StorageService.CurrentSessionId, ucStep21.returnUser);
                e.Result = true;
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
        }

        private void bgwUpdatePersonalInfo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if (e.Result == null)
            {
                return;
            }
            this.PostAction = DialogPostAction.SUCCESS;
            this.Hide();
        }
    }
}
