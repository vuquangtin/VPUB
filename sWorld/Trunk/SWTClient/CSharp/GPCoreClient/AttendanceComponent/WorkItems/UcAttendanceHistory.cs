using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonControls.Custom;
using Microsoft.Practices.CompositeUI.Commands;
using AttendanceComponent.Constants;
using Microsoft.Practices.CompositeUI;
using sWorldModel;
using CommonHelper.Constants;
using CommonControls;
using System.ServiceModel;
using sWorldModel.Exceptions;
using JavaCommunication.Factory;
using sWorldModel.TransportData;
using CommonHelper.Utils;
using CommonHelper.Config;
using ImageAccessor;
using sWorldModel.Filters;
using SystemMgtComponent.WorkItems;
using System.Resources;

namespace AttendanceComponent.WorkItems
{
    public partial class UcAttendanceHistory : CommonUserControl
    {
        #region Properties

        // Height of filter box when it is hidden
        private int hiddenFilterBoxHeight = 1;
        // The original height of filter box (at startup)
        private int startupFilterBoxHeight;

        private ResourceManager rm;

        private int ImageHeight = 0;
        private int currentPageIndex = 1;
        private AttendanceWorkItem workItem;
        private DataTable dtbAttendanceList;
        private BackgroundWorker bgwLoadAttendance;

        private List<Attendance> AttendanceList;

        [ServiceDependency]
        public AttendanceWorkItem WorkItem
        {
            set { workItem = value; }
        }

        private ILocalStorageService storageService;
        [ServiceDependency]
        public ILocalStorageService StorageService
        {
            get { return storageService; }
            set { storageService = value; }
        }

        #endregion
        public UcAttendanceHistory()
        {
            InitializeComponent();
            RegisterEvent();
            InitDataTableAttendance();
        }

        #region Form events

        protected override void OnLoad(EventArgs e)
        {
            LoadAttendance();
            startupFilterBoxHeight = this.pnlFilterBox.Height;

            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (bgwLoadAttendance.IsBusy)
                {
                    bgwLoadAttendance.CancelAsync();
                }
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #endregion

        #region Controls events

        private void bgwLoadAttendance_DoWork(object sender, DoWorkEventArgs e)
        {
            if (e.Argument == null || !(e.Argument is AttendanceFilterDto))
            {
                return;
            }
            AttendanceFilterDto filter = e.Argument as AttendanceFilterDto;
            List<Attendance> result = null;
            int totalRecords = 0;
            int take = LocalSettings.Instance.RecordsPerPage;
            int skip = 0;
            currentPageIndex = 1;

            try
            {
                AttendanceList = AttendanceFoctory.Instance.GetChannel().GetAttendanceList(StorageService.CurrentSessionId, filter);
            }
            catch (TimeoutException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.TimeOutExceptionMessage);
                this.Hide();
            }
            catch (FaultException<WcfServiceFault> ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
                this.Hide();
            }
            catch (FaultException ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.FaultExceptionMessage
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
                this.Hide();
            }
            catch (CommunicationException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.CommunicationExceptionMessage);
                this.Hide();
            }
            finally
            {
                if (AttendanceList != null)
                {
                    result = AttendanceList.Skip(skip).Take(take).ToList();
                    totalRecords = AttendanceList.Count;
                    pagerPanel1.ShowNumberOfRecords(totalRecords, result != null ? result.Count : 0, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
                    pagerPanel1.UpdatePagingLinks(totalRecords, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
                }
                e.Result = result;
            }
        }
        private void bgwLoadAttendance_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if (e.Result == null || !(e.Result is List<Attendance>))
            {
                return;
            }
            List<Attendance> result = e.Result as List<Attendance>;
            LoadAttendanceDataGridView(result);
        }

        private void btnShowHide_Clicked(object s, EventArgs e)
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

        private void pagerPanel_LinkLabelClicked(object s, LinkLabelClickedArgs e)
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
            dtbAttendanceList.Rows.Clear();
            int take = LocalSettings.Instance.RecordsPerPage;
            int skip = (currentPageIndex - 1) * take;

            List<Attendance> result = AttendanceList.Skip(skip).Take(take).ToList();
            LoadAttendanceDataGridView(result);

            pagerPanel1.ShowNumberOfRecords(AttendanceList.Count, result != null ? result.Count : 0, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
            pagerPanel1.UpdatePagingLinks(AttendanceList.Count, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
        }

        private void dgvAttendanceList_Invalidated(object sender, InvalidateEventArgs e)
        {
            try
            {
                for (int i = 0; i < dgvAttendanceList.Rows.Count; i++)
                {
                    if (!cbxLoadImage.Checked ||
                        (dgvAttendanceList.Rows[i].Cells[colImageIn.Index].Value == null &&
                        dgvAttendanceList.Rows[i].Cells[colImageOut.Index].Value == null))
                    {
                        dgvAttendanceList.Rows[i].Height = dgvAttendanceList.RowTemplate.Height;
                    }
                    else
                    {
                        dgvAttendanceList.Rows[i].Height = ImageHeight;
                    }
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void dgvAttendanceList_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo info = dgvAttendanceList.HitTest(e.X, e.Y);
                if (info.RowIndex != -1)
                {
                    if (info.RowIndex >= 0 && info.ColumnIndex >= 0)
                    {
                        if (!dgvAttendanceList.SelectedRows.Contains(dgvAttendanceList.Rows[info.RowIndex]))
                        {
                            foreach (DataGridViewRow row in dgvAttendanceList.SelectedRows)
                            {
                                row.Selected = false;
                            }
                            dgvAttendanceList.Rows[info.RowIndex].Selected = true;
                        }
                    }
                    Rectangle r = dgvAttendanceList.GetCellDisplayRectangle(info.ColumnIndex, info.RowIndex, true);
                    cmsAttendanceRecord.Show((Control)sender, e.X, e.Y);
                }
                else
                {
                    cmsAttendanceRecord.Show((Control)sender, e.X, e.Y);
                }
            }
        }

        private void cbxFilterBySerialNumber_CheckedChanged(object sender, EventArgs e)
        {
            tbxSerialNumber.Enabled = cbxFilterBySerialNumber.Checked;
        }

        private void cbxFilterByDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpDateIn.Enabled = cbxFilterByDate.Checked;
        }

        private void btnSendSms_Click(object sender, EventArgs e)
        {
            SendSMS();
        }

        void mniViewAttendance_Click(object sender, EventArgs e)
        {
            if (dgvAttendanceList.SelectedRows.Count > 0) 
            {
                long attendanceId = Convert.ToInt64(dgvAttendanceList.SelectedRows[0].Cells[colAttendanceId.Index].Value.ToString());
                frmViewAttendance dialog = new frmViewAttendance(attendanceId);
                workItem.SmartParts.Add(dialog);
                dialog.ShowDialog();
                workItem.SmartParts.Remove(dialog);
                dialog.Dispose();
            }
        }

        void mniSendSMS_Click(object sender, EventArgs e)
        {
            SendSMS();
        }

        #endregion

        #region Event's Support

        private void RegisterEvent()
        {
            Padding padding = colImageIn.DefaultCellStyle.Padding;
            ImageHeight = (colImageIn.Width - padding.Left - padding.Right) / 4 * 3;

            btnShowHideFilter.Click += btnShowHide_Clicked;
            btnReloadCards.Click += (s, e) => LoadAttendance();
            pagerPanel1.LinkLabelClicked += pagerPanel_LinkLabelClicked;

            dgvAttendanceList.Invalidated += dgvAttendanceList_Invalidated;
            dgvAttendanceList.MouseDown += dgvAttendanceList_MouseDown;

            bgwLoadAttendance = new BackgroundWorker();
            bgwLoadAttendance.WorkerSupportsCancellation = true;
            bgwLoadAttendance.DoWork += bgwLoadAttendance_DoWork;
            bgwLoadAttendance.RunWorkerCompleted += bgwLoadAttendance_Completed;

            mniSendSMS.Click += mniSendSMS_Click;
            mniViewAttendance.Click += mniViewAttendance_Click;

            btnSendSms.Click += btnSendSms_Click;
        }

        private void InitDataTableAttendance()
        {
            dtbAttendanceList = new DataTable();
            dtbAttendanceList.Columns.Add(colAttendanceId.DataPropertyName);
            dtbAttendanceList.Columns.Add(colMemberId.DataPropertyName);
            dtbAttendanceList.Columns.Add(colSerialNumber.DataPropertyName);
            dtbAttendanceList.Columns.Add(colMemberCode.DataPropertyName);
            dtbAttendanceList.Columns.Add(colMemberFullName.DataPropertyName);
            dtbAttendanceList.Columns.Add(colDateIn.DataPropertyName);
            dtbAttendanceList.Columns.Add(colDateOut.DataPropertyName);
            dtbAttendanceList.Columns.Add(colImageIn.DataPropertyName, typeof(Image));
            dtbAttendanceList.Columns.Add(colImageOut.DataPropertyName, typeof(Image));
            dgvAttendanceList.DataSource = dtbAttendanceList;
        }

        private AttendanceFilterDto loadfilter()
        {
            AttendanceFilterDto filter = new AttendanceFilterDto();

            if (cbxFilterBySerialNumber.Checked)
            {
                filter.FilterBySerialNumber = true;
                filter.SerialNumber = tbxSerialNumber.Text.Trim();
            }
            if (cbxFilterByDate.Checked)
            {
                filter.FilterByDateIn = true;
                filter.DateIn = dtpDateIn.Value.ToString("yyyy/MM/dd");
            }
            return filter;
        }

        private void LoadAttendance()
        {
            if (!bgwLoadAttendance.IsBusy)
            {
                dtbAttendanceList.Rows.Clear();
                pagerPanel1.ShowMessage("Đang tải dữ liệu, xin hãy chờ...");
                bgwLoadAttendance.RunWorkerAsync(loadfilter());
            }
        }

        private void LoadAttendanceDataGridView(List<Attendance> result)
        {
            foreach (Attendance attendance in result)
            {
                Member member = LoadMember(attendance.MemberId);
                DataRow row = dtbAttendanceList.NewRow();
                row.BeginEdit();

                row[colAttendanceId.DataPropertyName] = attendance.Id;
                row[colSerialNumber.DataPropertyName] = attendance.SerialNumber;

                if (member != null)
                {
                    row[colMemberId.DataPropertyName] = member.Id;
                    row[colMemberCode.DataPropertyName] = member.Code;
                    row[colMemberFullName.DataPropertyName] = member.GetFullName();
                }

                row[colDateIn.DataPropertyName] = attendance.DateIn;
                row[colDateOut.DataPropertyName] = attendance.DateOut;
                if (cbxLoadImage.Checked)
                {
                    row[colImageIn.DataPropertyName] = string.IsNullOrEmpty(attendance.ImgIn)
                        ? global::AttendanceComponent.Properties.Resources.NoImage
                        : ImageUtils.Base64ToImage(attendance.ImgIn);
                    row[colImageOut.DataPropertyName] = string.IsNullOrEmpty(attendance.ImgIn)
                        ? global::AttendanceComponent.Properties.Resources.NoImage
                        : ImageUtils.Base64ToImage(attendance.ImgOut);
                }

                row.EndEdit();
                dtbAttendanceList.Rows.Add(row);
                colImageIn.Visible = colImageOut.Visible = cbxLoadImage.Checked;
            }
        }

        private Member LoadMember(long memberId)
        {
            Member member = new Member();
            if (memberId > 0)
            {
                try
                {
                    member = OrganizationFactory.Instance.GetChannel().GetMemberById(StorageService.CurrentSessionId, memberId);
                }
                catch (TimeoutException)
                {
                    MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.TimeOutExceptionMessage);
                    this.Hide();
                }
                catch (FaultException<WcfServiceFault> ex)
                {
                    MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
                    this.Hide();
                }
                catch (FaultException ex)
                {
                    MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.FaultExceptionMessage
                            + Environment.NewLine + Environment.NewLine
                            + ex.Message);
                    this.Hide();
                }
                catch (CommunicationException)
                {
                    MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.CommunicationExceptionMessage);
                    this.Hide();
                }
            }
            return member;
        }

        private void SendSMS()
        {
            var selectedRows = dgvAttendanceList.SelectedRows;
            int rowsCount = selectedRows.Count;
            if (rowsCount == 0)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessNonMember(rm, MessageValidate.Member), MessageValidate.GetErrorTitle(rm));
                return;
            }
            long[] persoIds = new long[rowsCount];
            for (int i = 0; i < rowsCount; i++)
            {
                persoIds[i] = Convert.ToInt64(selectedRows[i].Cells[colMemberId.Name].Value.ToString());
            }
            frmSendSmsToContact dialog = new frmSendSmsToContact(persoIds);
            workItem.SmartParts.Add(dialog);
            dialog.ShowDialog();
            workItem.SmartParts.Remove(dialog);
            dialog.Dispose();
        }

        #endregion

        #region CAB events

        [CommandHandler(AttendanceCommandNames.ShowAttendanceMgtMain)]
        public void ShowPersoMgtMainViewHandler(object s, EventArgs e)
        {
            UcAttendanceHistory uc = workItem.Items.Get<UcAttendanceHistory>(ComponentNames.AttendanceMgtComponent);
            if (uc == null)
            {
                uc = workItem.Items.AddNew<UcAttendanceHistory>(ComponentNames.AttendanceMgtComponent);
            }
            else if (uc.IsDisposed)
            {
                workItem.Items.Remove(uc);
                uc = workItem.Items.AddNew<UcAttendanceHistory>(ComponentNames.AttendanceMgtComponent);
            }
            workItem.Workspaces[WorkspaceName.MainWorkspace].Show(uc);
            uc.Parent.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuAttendanceHistory);
        }

        #endregion

    }
}
