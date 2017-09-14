using CommonControls;
using sWorldModel;
using sWorldModel.Exceptions;
using sWorldModel.TransportData;
using Microsoft.Practices.CompositeUI;
//using sWorldCommunication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ServiceModel;
using System.Windows.Forms;
using JavaCommunication.Factory;
using System.Resources;
using CommonHelper.Utils;
using CommonHelper.Constants;
//using WcfServiceCommon;

namespace SystemMgtComponent.WorkItems.Users
{
    public partial class FrmChangeUserGroup : CommonControls.Custom.CommonDialog
    {
        private BackgroundWorker bgwChangeGroup;
        private long userId;
        private ResourceManager rm;

        private ILocalStorageService storageService;
        [ServiceDependency]
        public ILocalStorageService StorageService
        {
            get { return storageService; }
            set { storageService = value; }
        }

        public DialogPostAction PostAction { get; private set; }
        public long SelectedGroupId { get; private set; }

        public FrmChangeUserGroup(long userId, List<GroupDto> groups)
        {
            InitializeComponent();

            this.userId = userId;

            cmbGroups.DataSource = groups;
            cmbGroups.DisplayMember = "Name";
            cmbGroups.ValueMember = "Id";

            bgwChangeGroup = new BackgroundWorker();
            bgwChangeGroup.WorkerSupportsCancellation = true;
            bgwChangeGroup.DoWork += OnChangeGroupWorkerDoWork;
            bgwChangeGroup.RunWorkerCompleted += OnChangeGroupWorkerRunWorkerCompleted;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
            this.Text = MessageValidate.GetMessage(rm, this.Name);
        }

        private void OnButtonConfirmClicked(object sender, EventArgs e)
        {
            if (cmbGroups.SelectedIndex == -1)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessSelect(rm, MessageValidate.NewGroup), MessageValidate.GetErrorTitle(rm));
                return;
            }
            GroupDto selectedGroup = (GroupDto)cmbGroups.SelectedItem;
            if (MessageBoxManager.ShowQuestionMessageBox(this, string.Format(MessageValidate.GetMessage(rm, "changePosition"), selectedGroup.Name)) == DialogResult.Yes)
            {
                SelectedGroupId = (long)cmbGroups.SelectedValue;
                if (!bgwChangeGroup.IsBusy)
                {
                    bgwChangeGroup.RunWorkerAsync();
                }
            }
        }

        private void OnChangeGroupWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = 0 == ManagerSystemFactory.Instance.GetChannel().ChangeUserGroup(StorageService.CurrentSessionId, userId, SelectedGroupId);
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
        }

        private void OnChangeGroupWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if (e.Result != null && (bool)e.Result)
            {
                PostAction = DialogPostAction.SUCCESS;
                this.Hide();
            }else {
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "changedPositionFail"));

            }
        }

        private void OnButtonCancelClicked(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}