using CommonControls;
using CommonControls.Custom;
using sWorldModel.Integrating;
using Microsoft.Practices.CompositeUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MemberMgtComponent.WorkItems.Integrating
{
    public partial class FrmReadAccessData : CommonControls.Custom.CommonDialog
    {
        #region Properties

        private BackgroundWorker bgwReadData;
        private AccessDbReader dbReader;

        private MemberWorkItem workItem;
        [ServiceDependency]
        public MemberWorkItem WorkItem
        {
            set { workItem = value; }
        }

        public List<ALL_BO_MON> Departments { get; set; }
        public List<ALL_KHOA> Faculties { get; set; }
        public List<ALL_CBCNV> Teachers { get; set; }
        public List<ALL_CHUC_VU> Positions { get; set; }
        public List<ALL_NGACH> Scales { get; set; }

        #endregion

        #region Initialization

        public FrmReadAccessData(string filePath, string userId, string password)
        {
            InitializeComponent();

            dbReader = new AccessDbReader(filePath, userId, password);

            bgwReadData = new BackgroundWorker();
            bgwReadData.WorkerSupportsCancellation = true;
            bgwReadData.DoWork += bgwReadData_DoWork;
            bgwReadData.RunWorkerCompleted += bgwReadData_Completed;

            cbxReviewData.CheckedChanged += cbxReviewData_CheckChanged;
            btnCancel.Click += btnCancel_Click;
            btnNext.Click += btnNext_Clicked;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!bgwReadData.IsBusy)
            {
                bgwReadData.RunWorkerAsync();
            }
        }

        private const int WS_SYSMENU = 0x80000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style &= ~WS_SYSMENU;
                return cp;
            }
        }

        #endregion

        #region Form events

        private void bgwReadData_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                #region Read scale data

                ChangeProgress(0);
                ChangeMessage("Đang thu thập dữ liệu ngạch...");
                Scales = dbReader.SelectAllScales();

                if (bgwReadData.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                #endregion

                #region Read position data

                ChangeProgress(10);
                ChangeMessage("Đang thu thập dữ liệu chức vụ...");
                Positions = dbReader.SelectAllPositions();

                if (bgwReadData.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                #endregion

                #region Read faculty data

                ChangeProgress(20);
                ChangeMessage("Đang thu thập dữ liệu khoa...");
                Faculties = dbReader.SelectAllFaculties();

                if (bgwReadData.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                #endregion

                #region Read department data

                ChangeProgress(35);
                ChangeMessage("Đang thu thập dữ liệu bộ môn...");
                Departments = dbReader.SelectAllDepartments();

                if (bgwReadData.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                #endregion

                #region Read teacher data

                ChangeProgress(50);
                ChangeMessage("Đang thu thập dữ liệu thành viên...");
                Teachers = dbReader.SelectAllTeachers();

                #endregion
            }
            catch (OleDbException ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ex.Message);
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ex.Message);
                e.Cancel = true;
            }
        }

        private void bgwReadData_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                progressBar1.Value = 0;
                lblMessage.Text = "Quá trình thu thập dữ liệu đã bị ngưng!";
                return;
            }
            progressBar1.Value = 100;
            lblMessage.Text = "Quá trình thu thập dữ liệu đã hoàn tất!";
            btnNext.Enabled = true;
        }

        private void ChangeMessage(string msg)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => { ChangeMessage(msg); }));
                return;
            }
            lblMessage.Text = msg;
        }

        private void ChangeProgress(int percentage)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => { ChangeProgress(percentage); }));
                return;
            }
            progressBar1.Value = percentage;
        }

        private void cbxReviewData_CheckChanged(object sender, EventArgs e)
        {
            if (cbxReviewData.Checked)
            {
                btnNext.Text = "Tiếp Tục";
            }
            else
            {
                btnNext.Text = "Tích Hợp...";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBoxManager.ShowQuestionMessageBox(this, "Bạn có chắc muốn ngừng lại và đóng cửa sổ này không?") == DialogResult.Yes)
            {
                this.Dispose();
            }
            else
            {
                DialogResult = System.Windows.Forms.DialogResult.None;
            }
        }

        private void btnNext_Clicked(object sender, EventArgs e)
        {
            if (cbxReviewData.Checked)
            {
                FrmReviewData frmReviewData = new FrmReviewData(Departments, Faculties, Teachers, Positions, Scales);
                workItem.SmartParts.Add(frmReviewData);
                this.Hide();
                frmReviewData.ShowDialog(this);
                this.Dispose();
            }
            else
            {
                if (MessageBoxManager.ShowQuestionMessageBox(this, "Bạn có chắc muốn tích hợp dữ liệu thành viên vào hệ thống không?") == DialogResult.Yes)
                {
                    FrmIntegrateData frmIntegrateData = new FrmIntegrateData(Departments, Faculties, Teachers, Positions, Scales);
                    workItem.SmartParts.Add(frmIntegrateData);
                    this.Hide();
                    frmIntegrateData.ShowDialog(this);
                    this.Dispose();
                }
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (bgwReadData.IsBusy)
            {
                bgwReadData.CancelAsync();
            }
        }

        #endregion
    }
}
