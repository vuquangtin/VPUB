using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CommonControls.Custom;
using CommonHelper.Utils;
using CommonControls;
using System.ComponentModel;
using System.ServiceModel;
using Microsoft.Practices.CompositeUI;
using sWorldModel;
using sWorldModel.Filters;
using sWorldModel.Exceptions;
using JavaCommunication.Factory;
using sWorldModel.TransportData;
using SystemMgtComponent.WorkItems;
using System.Resources;
using CommonHelper.Constants;

namespace SystemMgtComponent.WorkItems.UserAdding
{
    public partial class UsrAccountInfo : CommonUserControl, IUserAddingDialog
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
        public event EventHandler StepCompleted;

        private ResourceManager rm;
        private string userName;
        private string password;
        private long groupId;
        public object[] ReturnData
        {
            get { return new object[] { userName, password, groupId }; }
        }

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

        private BackgroundWorker bgwLoadGroups;

        #endregion

        #region Initialization

        public UsrAccountInfo()
        {
            InitializeComponent();

            cmbGroups.ValueMember = "Id";
            cmbGroups.DisplayMember = "Name";

            tbxPassword1.TextChanged += txtPassword1_TextChanged;
            tbxUserName.Focus();

            bgwLoadGroups = new BackgroundWorker();
            bgwLoadGroups.WorkerSupportsCancellation = true;
            bgwLoadGroups.DoWork += bgwLoadGroups_DoWork;
            bgwLoadGroups.RunWorkerCompleted += bgwLoadGroups_RunWorkerCompleted;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            bgwLoadGroups.RunWorkerAsync();
            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
        }

        private void bgwLoadGroups_DoWork(object sender, DoWorkEventArgs e)
        {
            List<GroupDto> result = null;
            GroupFilterDto filter = new GroupFilterDto();

            try
            {
                result = ManagerSystemFactory.Instance.GetChannel().GetGroupList(StorageService.CurrentSessionId, filter);
            }
            catch (TimeoutException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm,"TimeOutExceptionMessage"));
            }
            catch (FaultException<WcfServiceFault> ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
            }
            catch (FaultException ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm,"FaultExceptionMessage")
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
            }
            catch (CommunicationException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm,"CommunicationExceptionMessage"));
            }
            finally
            {
                e.Result = result;
            }
        }

        private void bgwLoadGroups_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            List<GroupDto> result = (List<GroupDto>)e.Result;
            cmbGroups.DataSource = result;
        }

        #endregion

        #region Form events

        private void btnBack_Click(object sender, EventArgs e)
        {
            btnRefresh_Click(this, EventArgs.Empty);
            postAction = DialogPostAction.BACK;
            if (StepCompleted != null)
            {
                StepCompleted(this, EventArgs.Empty);
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            //Kiểm tra dữ liệu
            tbxUserName.Text = tbxUserName.Text.Trim();
            if (tbxUserName.Text.Length == 0)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessageValidate(rm, MessageValidate.UserId), MessageValidate.GetErrorTitle(rm));
                tbxUserName.Focus();
                return;
            }
            if (tbxPassword1.Text.Length == 0)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessageValidate(rm, MessageValidate.NewPass), MessageValidate.GetErrorTitle(rm));
                tbxPassword1.Focus();
                return;
            }
            if (tbxPassword2.Text.Length == 0)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessageValidate(rm, MessageValidate.ReNewPass), MessageValidate.GetErrorTitle(rm));
                tbxPassword2.Focus();
                return;
            }
            if (!tbxPassword1.Text.Equals(tbxPassword2.Text))
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessFalse(rm, MessageValidate.RePass), MessageValidate.GetErrorTitle(rm));
                tbxPassword2.Text = string.Empty;
                tbxPassword2.Focus();
                return;
            }
            if (cmbGroups.SelectedIndex == -1)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessSelect(rm, MessageValidate.GroupAcc), MessageValidate.GetErrorTitle(rm));
                return;
            }
            if (PasswordUtils.CheckPasswordStrength(tbxPassword1.Text) < PasswordScore.Medium)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessPassWeak(rm, MessageValidate.Select), MessageValidate.GetErrorTitle(rm));
                tbxPassword1.Text = tbxPassword2.Text = string.Empty;
                tbxPassword1.Focus();
                return;
            }

            //Thu thập dữ liệu
            userName = tbxUserName.Text;
            password = tbxPassword1.Text;
            groupId = (long)cmbGroups.SelectedValue;
            if (MessageBoxManager.ShowQuestionMessageBox(this, MessageValidate.GetQuestionAdd(rm,"account")) == DialogResult.Yes)
            {
                postAction = DialogPostAction.CONFIRMED;
                if (StepCompleted != null)
                {
                    StepCompleted(this, EventArgs.Empty);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            tbxUserName.Text = tbxPassword1.Text = tbxPassword2.Text = string.Empty;
            tbxUserName.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            postAction = DialogPostAction.CANCEL;
            if (StepCompleted != null)
            {
                StepCompleted(this, EventArgs.Empty);
            }
        }

        private void txtPassword1_TextChanged(object sender, EventArgs e)
        {
            PasswordScore score = PasswordUtils.CheckPasswordStrength(tbxPassword1.Text);
            lblPasswdStrength.Score = (int)score;
            if (score == PasswordScore.Blank)
            {
                lblPasswdStrength.Text = string.Empty;
            }
            else
            {
                lblPasswdStrength.Text = string.Format(MessageValidate.GetMessage(rm,"msgDoManh"), score.GetName());
            }
        }

        public void ClearAndFocusUserNameField()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(ClearAndFocusUserNameField));
                return;
            }
            tbxUserName.Text = string.Empty;
            tbxUserName.Focus();
        }

        public void ClearAndFocusPasswordField()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(ClearAndFocusPasswordField));
                return;
            }
            tbxPassword1.Text = tbxPassword2.Text = string.Empty;
            tbxPassword1.Focus();
        }

        #endregion
    }
}