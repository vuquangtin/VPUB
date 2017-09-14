using System;
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
using MemberMgtComponent.Constants;
using System.Drawing;
using CommonControls;
using Newtonsoft.Json;
//using WcfServiceCommon;
using sWorldModel.Integrating;
using sWorldModel.Exceptions;
using sWorldModel.Filters;
using sWorldModel.Model;
using sWorldModel;

namespace MemberMgtComponent.WorkItems
{
    public partial class UsrIntegratingLog : CommonUserControl
    {
        #region Properties

        // Height of filter box when it is hidden
        private int hiddenFilterBoxHeight = 1;
        // The original height of filter box (at startup)
        private int startupFilterBoxHeight;

        private BackgroundWorker bgwLoadLogs;
        private int currentPageIndex = -1;
        private DataTable dtbIntegratingLogs;
        private DataTable dtbChangedTypes;

        private MemberWorkItem workItem;
        [ServiceDependency]
        public MemberWorkItem WorkItem
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

        public UsrIntegratingLog()
        {
            InitializeComponent();

            dtpTimeFrom.Value = dtpTimeFrom.MaxDate = dtpTimeTo.Value = dtpTimeTo.MinDate = DateTime.Now;

            dtbChangedTypes = new DataTable();
            dtbChangedTypes.Columns.Add("TypeAlias");
            dtbChangedTypes.Columns.Add("TypeName");
            cmbChangedTypes.DisplayMember = "TypeName";
            cmbChangedTypes.ValueMember = "TypeAlias";
            cmbChangedTypes.DataSource = dtbChangedTypes;

            dtbIntegratingLogs = new DataTable();
            dtbIntegratingLogs.Columns.Add(colId.DataPropertyName);
            dtbIntegratingLogs.Columns.Add(colUserName.DataPropertyName);
            dtbIntegratingLogs.Columns.Add(colIntegratingTime.DataPropertyName);
            dtbIntegratingLogs.Columns.Add(colResult.DataPropertyName);
            dtbIntegratingLogs.Columns.Add(colReason.DataPropertyName);
            dtbIntegratingLogs.Columns.Add(colTableNameVietnamese.DataPropertyName);
            dtbIntegratingLogs.Columns.Add(colTableName.DataPropertyName);
            dtbIntegratingLogs.Columns.Add(colChanges.DataPropertyName);
            dtbIntegratingLogs.Columns.Add(colChangedType.DataPropertyName);
            dgvIntegratingLogs.DataSource = dtbIntegratingLogs;

            bgwLoadLogs = new BackgroundWorker();
            bgwLoadLogs.WorkerSupportsCancellation = true;
            bgwLoadLogs.DoWork += bgwLoadIntegratingLog_DoWork;
            bgwLoadLogs.RunWorkerCompleted += bgwLoadIntegratingLog_Completed;

            cbxFilterByLoginResult.CheckedChanged += cbxFilterByLoginResult_CheckedChanged;
            cbxFilterByLoginTime.CheckedChanged += cbxFilterByLoginTime_CheckedChanged;
            cbxFilterByChangedType.CheckedChanged += cbxFilterByChangedType_CheckedChanged;

            dtpTimeFrom.ValueChanged += dtpTimeFrom_ValueChanged;
            dtpTimeTo.ValueChanged += dtpTimeTo_ValueChanged;
            pagerPanel1.LinkLabelClicked += pagerPanel_LinkLabelClicked;

            dgvIntegratingLogs.MultiSelect = false;
            dgvIntegratingLogs.MouseDown += dgvIntegratingLog_MouseDown;
            dgvIntegratingLogs.SelectionChanged += dgvIntegratingLog_SelectionChanged;

            dgvChanges.AutoGenerateColumns = true;
            dgvChanges.DataSourceChanged += dgvChanges_DataSourceChanged;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.startupFilterBoxHeight = this.pnlFilterBox.Height;
        }

        #endregion

        #region Load integrating log

        private void LoadIntegratingLog()
        {
            if (bgwLoadLogs.IsBusy)
            {
                return;
            }
            dtbIntegratingLogs.Rows.Clear();

            IntegratingLogFilterDto filter = new IntegratingLogFilterDto();
            if (cbxFilterByLoginResult.Checked)
            {
                filter.FilterByResult = true;
                filter.IntegratingSuccess = rbtnLoginSuccess.Checked;
            }
            if (cbxFilterByLoginTime.Checked)
            {
                filter.FilterByIntegratingTime = true;

                TimePeriodDto period = new TimePeriodDto();
                period.Start = dtpTimeFrom.Value.Date;
                period.End = dtpTimeTo.Value.Date.Add(new TimeSpan(23, 59, 59));
                filter.IntegratingTimePeriod = period;
            }
            if (cbxFilterByChangedType.Checked && cmbChangedTypes.SelectedIndex > -1)
            {
                filter.FilterByChangedType = true;
                filter.ChangedType = cmbChangedTypes.SelectedValue.ToString();
            }

            pagerPanel1.ShowMessage("Đang tải dữ liệu, xin hãy chờ...");
            bgwLoadLogs.RunWorkerAsync(filter);
        }

        private void bgwLoadIntegratingLog_DoWork(object sender, DoWorkEventArgs e)
        {
            if (e.Argument == null || !(e.Argument is IntegratingLogFilterDto))
            {
                return;
            }
            IntegratingLogFilterDto filter = e.Argument as IntegratingLogFilterDto;
            List<IntegratingLogDto> result = null;
            int totalRecords = 0;

            try
            {
                result = JavaCommunicationIntegrating.Instance.GetIntegratingLogList(StorageService.CurrentSessionId, filter, (currentPageIndex - 1) * LocalSettings.Instance.RecordsPerPage, LocalSettings.Instance.RecordsPerPage, out totalRecords);
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

        private void bgwLoadIntegratingLog_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if (e.Result == null || !(e.Result is List<IntegratingLogDto>))
            {
                return;
            }
            List<IntegratingLogDto> result = e.Result as List<IntegratingLogDto>;
            foreach (IntegratingLogDto r in result)
            {
                DataRow row = dtbIntegratingLogs.NewRow();
                row.BeginEdit();

                row[colId.DataPropertyName] = r.Id;
                row[colUserName.DataPropertyName] = r.ChangedBy;
                row[colIntegratingTime.DataPropertyName] = string.Format(LocalSettings.Instance.DateTimeFormatRegex, r.ChangedOn);
                row[colResult.DataPropertyName] = r.Result ? LocalSettings.Instance.CheckSymbol : string.Empty;
                row[colReason.DataPropertyName] = r.Reason;
                row[colTableNameVietnamese.DataPropertyName] = TableNames.GetVietnameseName(r.ChangedTable);
                row[colTableName.DataPropertyName] = r.ChangedTable;
                row[colChanges.DataPropertyName] = r.Changes;
                row[colChangedType.DataPropertyName] = HistoryChangedTypeExtMethods.GetName(r.ChangedType);

                row.EndEdit();
                dtbIntegratingLogs.Rows.Add(row);
            }
        }

        #endregion

        #region Form events

        private void dgvChanges_DataSourceChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvChanges.ColumnCount; i++)
            {
                dgvChanges.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            string filePath = ControlExtMethods.ShowSaveFileDialog("Chọn tập tin chứa dữ liệu cần xuất", "MS Excel (*.xls)|*.xls");
            if (filePath != null)
            {
                try
                {
                    dgvIntegratingLogs.ExportToExcel(filePath);
                }
                catch (Exception ex)
                {
                    MessageBoxManager.ShowErrorMessageBox(this, ex.Message);
                    return;
                }
                MessageBoxManager.ShowInfoMessageBox(this, "Đã xuất dữ liệu ra tập tin tại đường dẫn: " + filePath);
            }
        }

        private void dgvIntegratingLog_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvIntegratingLogs.SelectedRows.Count != 1)
            {
                return;
            }
            DataGridViewRow row = dgvIntegratingLogs.SelectedRows[0];

            switch(row.Cells[colTableName.Index].Value.ToString())
            {
                case TableNames.Teacher:
                    ALL_CBCNV cb = JsonConvert.DeserializeObject<ALL_CBCNV>(row.Cells[colChanges.Index].Value.ToString());
                    dgvChanges.DataSource = new List<ALL_CBCNV> { cb };
                    break;
                case TableNames.Department:
                    ALL_BO_MON bm = JsonConvert.DeserializeObject<ALL_BO_MON>(row.Cells[colChanges.Index].Value.ToString());
                    dgvChanges.DataSource = new List<ALL_BO_MON> { bm };
                    break;
                case TableNames.Faculty:
                    ALL_KHOA kh = JsonConvert.DeserializeObject<ALL_KHOA>(row.Cells[colChanges.Index].Value.ToString());
                    dgvChanges.DataSource = new List<ALL_KHOA> { kh };
                    break;
                case TableNames.ScaleDetail:
                    ALL_NGACH ng = JsonConvert.DeserializeObject<ALL_NGACH>(row.Cells[colChanges.Index].Value.ToString());
                    dgvChanges.DataSource = new List<ALL_NGACH> { ng };
                    break;
                case TableNames.PositionDetail:
                    ALL_CHUC_VU cv = JsonConvert.DeserializeObject<ALL_CHUC_VU>(row.Cells[colChanges.Index].Value.ToString());
                    dgvChanges.DataSource = new List<ALL_CHUC_VU> { cv };
                    break;
                default:
                    break;
            }
        }

        private void dgvIntegratingLog_MouseDown(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo info = dgvIntegratingLogs.HitTest(e.X, e.Y);
            if (info.RowIndex != -1)
            {
                if (info.RowIndex >= 0 && info.ColumnIndex >= 0)
                {
                    if (!dgvIntegratingLogs.SelectedRows.Contains(dgvIntegratingLogs.Rows[info.RowIndex]))
                    {
                        foreach (DataGridViewRow row in dgvIntegratingLogs.SelectedRows)
                        {
                            row.Selected = false;
                        }
                        dgvIntegratingLogs.Rows[info.RowIndex].Selected = true;
                    }
                }
            }
            if (e.Button == MouseButtons.Right)
            {
                Rectangle r = dgvIntegratingLogs.GetCellDisplayRectangle(info.ColumnIndex, info.RowIndex, true);
                cmsLogTable.Show((Control)sender, e.X, e.Y);
            }
        }

        private void btnShowHide_Clicked(object sender, EventArgs e)
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

        private void btnSearch_Clicked(object sender, EventArgs e)
        {
            currentPageIndex = 1;
            LoadIntegratingLog();
        }

        private void pagerPanel_LinkLabelClicked(object sender, LinkLabelClickedArgs e)
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
            LoadIntegratingLog();
        }

        private void cbxFilterByChangedType_CheckedChanged(object sender, EventArgs e)
        {
            cmbChangedTypes.Enabled = cbxFilterByChangedType.Checked;
            if (cmbChangedTypes.Enabled && dtbChangedTypes.Rows.Count == 0)
            {
                List<HistoryChangedType> list = HistoryChangedTypeExtMethods.GetHistoryChangedTypeList();
                foreach (var item in list)
                {
                    DataRow r = dtbChangedTypes.NewRow();
                    r.BeginEdit();

                    r["TypeAlias"] = item.GetAlias();
                    r["TypeName"] = item.GetName();

                    r.EndEdit();
                    dtbChangedTypes.Rows.Add(r);
                }
            }
        }

        private void cbxFilterByLoginTime_CheckedChanged(object sender, EventArgs e)
        {
            dtpTimeFrom.Enabled = dtpTimeTo.Enabled = cbxFilterByLoginTime.Checked;
        }

        private void cbxFilterByLoginResult_CheckedChanged(object sender, EventArgs e)
        {
            rbtnLoginSuccess.Enabled = rbtnLoginFail.Enabled = cbxFilterByLoginResult.Checked;
        }

        private void dtpTimeTo_ValueChanged(object sender, EventArgs e)
        {
            dtpTimeFrom.MaxDate = dtpTimeTo.Value.Date;
        }

        private void dtpTimeFrom_ValueChanged(object sender, EventArgs e)
        {
            dtpTimeTo.MinDate = dtpTimeFrom.Value.Date;
        }

        [CommandHandler(TeacherCommandNames.ShowIntegratingLog)]
        public void ShowIntegratingLogHandler(object s, EventArgs e)
        {
            UsrIntegratingLog uc = workItem.Items.Get<UsrIntegratingLog>(ComponentNames.IntegratingLogComponent);
            if (uc == null)
            {
                workItem.Items.AddNew<UsrIntegratingLog>(ComponentNames.IntegratingLogComponent);
            }
            else if (uc.IsDisposed)
            {
                workItem.Items.Remove(uc);
                uc = workItem.Items.AddNew<UsrIntegratingLog>(ComponentNames.IntegratingLogComponent);
            }

            workItem.Workspaces[WorkspaceName.MainWorkspace].Show(uc);
            uc.Parent.Text = "Lịch Sử Tích Hợp";
        }

        #endregion
    }
}