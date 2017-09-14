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
using UserMgtComponent.WorkItems.UserAdding;
using JavaCommunication.Factory;
using sWorldModel.TransportData;
//using WcfServiceCommon;

namespace UserMgtComponent.WorkItems
{
    public partial class FrmUpdatePersonalInfo : CommonControls.Custom.CommonDialog
    {
        #region Properties

        private UsrUserInfo ucStep21;
        private BackgroundWorker bgwLoadPersonalInfo;
        private BackgroundWorker bgwUpdatePersonalInfo;

        public long UserId { private get; set; }
        public DialogPostAction PostAction { get; private set; }
        public User UpdatedUser { get; set; }

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
                UpdatedUser = UserFactory.Instance.GetChannel().GetUserById(StorageService.CurrentSessionId, this.UserId);
            }
            catch (TimeoutException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.TimeOutExceptionMessage);
            }
            catch (FaultException<WcfServiceFault> ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
            }
            catch (FaultException ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.FaultExceptionMessage
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
            }
            catch (CommunicationException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.CommunicationExceptionMessage);
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
            this.lblIsLoading.Visible = false;
            this.panel1.Controls.Add(ucStep21);
            this.panel1.Controls.SetChildIndex(ucStep21, 0);
            this.AcceptButton = ucStep21.AcceptButton;
            this.CancelButton = ucStep21.CancelButton;
            ucStep21.Focus();
        }

        private void ucStep21_StepCompleted(object sender, EventArgs e)
        {
            if (ucStep21.PostAction != CommonControls.DialogPostAction.CONFIRMED)
            {
                return;
            }
            if (ucStep21.ReturnData == null || ucStep21.ReturnData.Length != 1 || !(ucStep21.ReturnData[0] is User))
            {
                return;
            }
            if (MessageBoxManager.ShowQuestionMessageBox(this, "Bạn có chắc muốn cập nhật thông tin cá nhân cho tài khoản này không?") != DialogResult.Yes)
            {
                return;
            }
            this.UpdatedUser = ucStep21.ReturnData[0] as User;
            if (!bgwUpdatePersonalInfo.IsBusy)
            {
                bgwUpdatePersonalInfo.RunWorkerAsync();
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
                UserFactory.Instance.GetChannel().UpdateUser(StorageService.CurrentSessionId, this.UpdatedUser);
                e.Result = true;
            }
            catch (TimeoutException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.TimeOutExceptionMessage);
            }
            catch (FaultException<WcfServiceFault> ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
            }
            catch (FaultException ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.FaultExceptionMessage
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
            }
            catch (CommunicationException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.CommunicationExceptionMessage);
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
            MessageBoxManager.ShowInfoMessageBox(this, "Thông tin cá nhân của tài khoản đã được cập nhật!");
            this.Hide();
        }
    }
}
