﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using CommonControls.Custom;
using Microsoft.Practices.CompositeUI;
using CommonHelper.Constants;
using System.ServiceModel;
using CommonHelper.Config;
using Microsoft.Practices.CompositeUI.Commands;
using UserMgtComponent.Constants;
using System.Drawing;
using CommonControls;
//using WcfServiceCommon;
using sWorldModel;
using sWorldModel.Exceptions;
using sWorldModel.Filters;
using sWorldModel.Model;
//using sWorldCommunication;
using JavaCommunication.Factory;
using sWorldModel.TransportData;

namespace UserMgtComponent.WorkItems
{
    public partial class UsrLoginHistory : CommonUserControl
    {
        #region Properties

        // Height of filter box when it is hidden
        private int hiddenFilterBoxHeight = 1;
        // The original height of filter box (at startup)
        private int startupFilterBoxHeight;

        private BackgroundWorker bgwLoadUsers;
        private BackgroundWorker bgwLoadLoginHistories;

        private int currentPageIndex = -1;

        private DataTable dtbLoginHistories;
        private DataTable dtbUsers;

        private UserWorkItem workItem;
        [ServiceDependency]
        public UserWorkItem WorkItem
        {
            set { workItem = value; }
            get { return workItem; }
        }

        private ILocalStorageService storageService;
        [ServiceDependency]
        public ILocalStorageService StorageService
        {
            get { return storageService; }
            set { storageService = value; }
        }

        #endregion

        #region Initialization

        public UsrLoginHistory()
        {
            InitializeComponent();

            dtpLoginTimeFrom.Value = dtpLoginTimeFrom.MaxDate = dtpLoginTimeTo.Value = dtpLoginTimeTo.MinDate = DateTime.Now;

            dtbUsers = new DataTable();
            dtbUsers.Columns.Add("UserName");
            cmbUsers.DisplayMember = cmbUsers.ValueMember = "UserName";
            cmbUsers.DataSource = dtbUsers;

            dtbLoginHistories = new DataTable();
            dtbLoginHistories.Columns.Add(colId.DataPropertyName);
            dtbLoginHistories.Columns.Add(colUserName.DataPropertyName);
            dtbLoginHistories.Columns.Add(colLoginTime.DataPropertyName);
            dtbLoginHistories.Columns.Add(colResult.DataPropertyName);
            dtbLoginHistories.Columns.Add(colFailedReason.DataPropertyName);
            dgvLoginHistories.DataSource = dtbLoginHistories;

            bgwLoadUsers = new BackgroundWorker();
            bgwLoadUsers.WorkerSupportsCancellation = true;
            bgwLoadUsers.DoWork += OnLoadUsersWorkerDoWork;
            bgwLoadUsers.RunWorkerCompleted += OnLoadUsersWorkerCompleted;

            bgwLoadLoginHistories = new BackgroundWorker();
            bgwLoadLoginHistories.WorkerSupportsCancellation = true;
            bgwLoadLoginHistories.DoWork += OnLoadLoginHistoryWorkerDoWork;
            bgwLoadLoginHistories.RunWorkerCompleted += OnLoadLoginHistoryWorkerCompleted;

            cbxFilterByLoginResult.CheckedChanged += OnCheckBoxFilterByLoginResultCheckedChanged;
            cbxFilterByLoginTime.CheckedChanged += OnCheckBoxFilterByLoginTimeCheckedChanged;
            cbxFilterByUserName.CheckedChanged += OnCheckBoxFilterByUserNameCheckedChanged;
            dtpLoginTimeFrom.ValueChanged += OnDateTimeInputTimeFromValueChanged;
            dtpLoginTimeTo.ValueChanged += OnDateTimeInputTimeToValueChanged;
            pagerPanel1.LinkLabelClicked += OnPagerPanelLinkLabelClicked;
            Load += OnFormLoad;

            dgvLoginHistories.MouseDown += OnLoginHistoryTableMouseDown;
        }

        private void OnFormLoad(object sender, EventArgs e)
        {
            this.startupFilterBoxHeight = this.pnlFilterBox.Height;
        }

        #endregion

        #region Load users

        private void LoadUsers()
        {
            if (!bgwLoadUsers.IsBusy)
            {
                dtbUsers.Rows.Clear();
                bgwLoadUsers.RunWorkerAsync();
            }
        }

        private void OnLoadUsersWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            UserFilterDto filter = new UserFilterDto(); ;
            List<User> result = null;
            try
            {
                result = UserFactory.Instance.GetChannel().GetUserList(StorageService.CurrentSessionId, filter);
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
            finally
            {
                e.Result = result;
            }
        }

        private void OnLoadUsersWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if (e.Result == null || !(e.Result is List<User>))
            {
                return;
            }
            List<User> result = e.Result as List<User>;
            foreach (User r in result)
            {
                DataRow row = dtbUsers.NewRow();
                row.BeginEdit();
                row["UserName"] = r.UserName;
                row.EndEdit();
                dtbUsers.Rows.Add(row);
            }
        }

        #endregion

        #region Load login history

        private void LoadLoginHistory()
        {
            if (bgwLoadLoginHistories.IsBusy)
            {
                return;
            }
            dtbLoginHistories.Rows.Clear();
            LoginHistoryFilterDto filter = new LoginHistoryFilterDto();
            if (cbxFilterByLoginResult.Checked)
            {
                filter.FilterByLoginResult = true;
                filter.LoginSuccess = rbtnLoginSuccess.Checked;
            }
            //if (cbxFilterByLoginTime.Checked)
            //{
            //    filter.FilterByLoginTime = true;
            //    TimePeriodDto period = new TimePeriodDto();
            //    period.Start = dtpLoginTimeFrom.Value.Date;
            //    period.End = dtpLoginTimeTo.Value.Date.Add(new TimeSpan(23, 59, 59));
            //    filter.LoginTimePeriod = period;
            //}
            if (cbxFilterByUserName.Checked && cmbUsers.SelectedIndex > -1)
            {
                filter.FilterByUserName = true;
                filter.UserName = cmbUsers.SelectedValue.ToString();
            }
            pagerPanel1.ShowMessage("Đang tải dữ liệu, xin hãy chờ...");
            bgwLoadLoginHistories.RunWorkerAsync(filter);
        }

        private void OnLoadLoginHistoryWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            if (e.Argument == null || !(e.Argument is LoginHistoryFilterDto))
            {
                return;
            }
            LoginHistoryFilterDto filter = e.Argument as LoginHistoryFilterDto;
            List<LoginHistoryDTO> result = null;
            int totalRecords = 0;

            try
            {
                result = UserFactory.Instance.GetChannel().GetLoginHistoryList(StorageService.CurrentSessionId, filter);
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
            finally
            {
                pagerPanel1.ShowNumberOfRecords(totalRecords, result != null ? result.Count : 0, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
                pagerPanel1.UpdatePagingLinks(totalRecords, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
                e.Result = result;
            }
        }

        private void OnLoadLoginHistoryWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if (e.Result == null || !(e.Result is List<LoginHistoryDTO>))
            {
                return;
            }
            List<LoginHistoryDTO> result = e.Result as List<LoginHistoryDTO>;
            foreach (LoginHistoryDTO r in result)
            {
                DataRow row = dtbLoginHistories.NewRow();
                row.BeginEdit();

                row[colId.DataPropertyName] = r.Id;
                row[colUserName.DataPropertyName] = r.UserName;
                row[colLoginTime.DataPropertyName] = string.Format(LocalSettings.Instance.DateTimeFormatRegex, r.LoginTime);
                //row[colResult.DataPropertyName] = r.LoginResult ? LocalSettings.Instance.CheckSymbol : string.Empty;
                row[colFailedReason.DataPropertyName] = ErrorCodes.GetErrorMessage(r.FailedCode);

                row.EndEdit();
                dtbLoginHistories.Rows.Add(row);
            }
        }

        #endregion

        #region Form events

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            string filePath = ControlExtMethods.ShowSaveFileDialog("Chọn tập tin chứa dữ liệu cần xuất", "MS Excel (*.xls)|*.xls");
            if (filePath != null)
            {
                try
                {
                    dgvLoginHistories.ExportToExcel(filePath);
                }
                catch (Exception ex)
                {
                    MessageBoxManager.ShowErrorMessageBox(this, ex.Message);
                    return;
                }
                MessageBoxManager.ShowInfoMessageBox(this, "Đã xuất dữ liệu ra tập tin tại đường dẫn: " + filePath);
            }
        }

        private void OnLoginHistoryTableMouseDown(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo info = dgvLoginHistories.HitTest(e.X, e.Y);
            if (info.RowIndex != -1)
            {
                if (info.RowIndex >= 0 && info.ColumnIndex >= 0)
                {
                    if (!dgvLoginHistories.SelectedRows.Contains(dgvLoginHistories.Rows[info.RowIndex]))
                    {
                        foreach (DataGridViewRow row in dgvLoginHistories.SelectedRows)
                        {
                            row.Selected = false;
                        }
                        dgvLoginHistories.Rows[info.RowIndex].Selected = true;
                    }
                }
            }
            if (e.Button == MouseButtons.Right)
            {
                Rectangle r = dgvLoginHistories.GetCellDisplayRectangle(info.ColumnIndex, info.RowIndex, true);
                cmsHistoryTable.Show((Control)sender, e.X, e.Y);
            }
        }

        private void OnButtonShowHideClicked(object sender, EventArgs e)
        {
            if (pnlFilterBox.Height > hiddenFilterBoxHeight)
            {
                pnlFilterBox.Height = hiddenFilterBoxHeight;
                btnShowHideFilter.Text = btnShowHideFilter.ToolTipText = "Hiện Khung Tìm Kiếm";
                btnShowHideFilter.ToolTipText = "Hiện khung tìm kiếm";
                btnShowHideFilter.Image = global::CommonControls.Properties.Resources.ArrowDown_16x16;
            }
            else
            {
                pnlFilterBox.Height = startupFilterBoxHeight;
                btnShowHideFilter.Text = btnShowHideFilter.ToolTipText = "Ẩn Khung Tìm Kiếm";
                btnShowHideFilter.ToolTipText = "Ẩn khung tìm kiếm";
                btnShowHideFilter.Image = global::CommonControls.Properties.Resources.ArrowUp_16x16;
            }
        }

        private void OnButtonSearchClicked(object sender, EventArgs e)
        {
            currentPageIndex = 1;
            LoadLoginHistory();
        }

        private void OnPagerPanelLinkLabelClicked(object sender, LinkLabelClickedArgs e)
        {
            int i;
            if (e.LabelText.Equals(PagerPanel.LabelBackText))
            {
                currentPageIndex -= 1;
            }
            else if (e.LabelText.Equals(PagerPanel.LabelNextText))
            {
                currentPageIndex += 1;
            }
            else if (int.TryParse(e.LabelText, out i))
            {
                currentPageIndex = i;
            }
            else
            {
                return;
            }
            LoadLoginHistory();
        }

        private void OnCheckBoxFilterByUserNameCheckedChanged(object sender, EventArgs e)
        {
            cmbUsers.Enabled = cbxFilterByUserName.Checked;
            if (cmbUsers.Enabled && dtbUsers.Rows.Count == 0)
            {
                LoadUsers();
            }
        }

        private void OnCheckBoxFilterByLoginTimeCheckedChanged(object sender, EventArgs e)
        {
            dtpLoginTimeFrom.Enabled = dtpLoginTimeTo.Enabled = cbxFilterByLoginTime.Checked;
        }

        private void OnCheckBoxFilterByLoginResultCheckedChanged(object sender, EventArgs e)
        {
            rbtnLoginSuccess.Enabled = rbtnLoginFailed.Enabled = cbxFilterByLoginResult.Checked;
        }

        private void OnDateTimeInputTimeToValueChanged(object sender, EventArgs e)
        {
            dtpLoginTimeFrom.MaxDate = dtpLoginTimeTo.Value.Date;
        }

        private void OnDateTimeInputTimeFromValueChanged(object sender, EventArgs e)
        {
            dtpLoginTimeTo.MinDate = dtpLoginTimeFrom.Value.Date;
        }

        [CommandHandler(UserCommandNames.ShowLoginHistoryMain)]
        public void ShowLoginHistoryMainHandler(object s, EventArgs e)
        {
            UsrLoginHistory uc = workItem.Items.Get<UsrLoginHistory>(ComponentNames.LoginHistoryComponent);
            if (uc == null)
            {
                workItem.Items.AddNew<UsrLoginHistory>(ComponentNames.LoginHistoryComponent);
            }
            else if (uc.IsDisposed)
            {
                workItem.Items.Remove(uc);
                uc = workItem.Items.AddNew<UsrLoginHistory>(ComponentNames.LoginHistoryComponent);
            }

            workItem.Workspaces[WorkspaceName.MainWorkspace].Show(uc);
            uc.Parent.Text = "Lịch Sử Đăng Nhập";
        }

        #endregion
    }
}