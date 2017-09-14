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
//using WcfServiceCommon;

namespace UserMgtComponent.WorkItems
{
    public partial class FrmChangeUserGroup : CommonControls.Custom.CommonDialog
    {
        private BackgroundWorker bgwChangeGroup;
        private long userId;

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

        private void OnButtonConfirmClicked(object sender, EventArgs e)
        {
            if (cmbGroups.SelectedIndex == -1)
            {
                MessageBoxManager.ShowErrorMessageBox(this, "Bạn chưa chọn nhóm mới!", "Thao Tác Sai");
                return;
            }
            GroupDto selectedGroup = (GroupDto)cmbGroups.SelectedItem;
            if (MessageBoxManager.ShowQuestionMessageBox(this, string.Format("Bạn có chắc muốn chuyển tài khoản này sang nhóm {0} không?", selectedGroup.Name)) == DialogResult.Yes)
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
                e.Result = 0 == UserFactory.Instance.GetChannel().ChangeUserGroup(StorageService.CurrentSessionId, userId, SelectedGroupId);
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

        private void OnChangeGroupWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if (e.Result != null && (bool)e.Result)
            {
                MessageBoxManager.ShowInfoMessageBox(this, "Đã chuyển tài khoản sang nhóm mới!");
                PostAction = DialogPostAction.SUCCESS;
                this.Hide();
            }
        }

        private void OnButtonCancelClicked(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}