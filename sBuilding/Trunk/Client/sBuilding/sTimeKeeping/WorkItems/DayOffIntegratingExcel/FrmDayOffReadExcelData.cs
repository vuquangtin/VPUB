using CommonControls;
using CommonHelper.Utils;
using Microsoft.Practices.CompositeUI;
using sBuildingCommunication.Factory;
using sTimeKeeping.Model;
using sWorldModel.TransportData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Windows.Forms;

namespace sTimeKeeping.WorkItems.DayOffIntegratingExcel
{
    /// <summary>
    /// class FrmDayOffReadExcelData : CommonControls.Custom.CommonDialog
    /// </summary>
    public partial class FrmDayOffReadExcelData : CommonControls.Custom.CommonDialog
    {
        #region Properties

        private BackgroundWorker bgwReadData;

        private TimeKeepingComponentWorkItem workItem;
        [ServiceDependency]
        public TimeKeepingComponentWorkItem WorkItem
        {
            set { workItem = value; }
        }

        public List<DayOffImportObject> DayOffList { get; set; }
        public string FilePath { get; set; }
        public long OrgId { get; set; }
        public long SubOrgId { get; set; }
        public int colMemberCodeIndex { get; set; }
        public int colMemberNameIndex { get; set; }
        public int colDateIndex { get; set; }
        public int colTypeDayOffIndex { get; set; }
        public int colNoteIndex { get; set; }

        public int firstRowIndex { private get; set; }

        public ResourceManager rm;

        #endregion

        #region Initialization
        /// <summary>
        /// contructor
        /// </summary>
        public FrmDayOffReadExcelData()
        {
            InitializeComponent();
            bgwReadData = new BackgroundWorker();
            bgwReadData.WorkerSupportsCancellation = true;
            bgwReadData.DoWork += bgwReadData_DoWork;
            bgwReadData.RunWorkerCompleted += bgwReadData_Completed;

            cbxReviewData.CheckedChanged += cbxReviewData_CheckChanged;
            btnCancel.Click += btnCancel_Click;
            btnNext.Click += btnNext_Clicked;
        }
        /// <summary>
        /// override OnShown
        /// </summary>
        /// <param name="e"></param>
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            if (!bgwReadData.IsBusy)
            {
                bgwReadData.RunWorkerAsync();
            }
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
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
        /// <summary>
        /// bgwReadData DoWork
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwReadData_DoWork(object sender, DoWorkEventArgs e)
        {
            bool isOk;
            ChangeMessage("Đang thu thập dữ liệu...");
            try
            {
                //use import from file excel .xlsx .xls
                DayOffList = DayOffExcelReader.SelectAllDayOffList(FilePath, OrgId, SubOrgId, colMemberCodeIndex,
                    colMemberNameIndex, colDateIndex, colTypeDayOffIndex, colNoteIndex,
                    firstRowIndex, out isOk);
            }
            catch (IOException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, "Tập tin Excel đang mở. Vui lòng đóng tập tin và thử lại!");
                e.Cancel = true;
                return;
            }
            catch (Exception ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ex.Message);
                e.Cancel = true;
                return;
            }
            ChangeProgress(100);
        }
        /// <summary>
        /// bgwReadData Completed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Change Message
        /// </summary>
        /// <param name="msg"></param>
        private void ChangeMessage(string msg)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => { ChangeMessage(msg); }));
                return;
            }
            lblMessage.Text = msg;
        }

        /// <summary>
        /// Change Progress
        /// </summary>
        /// <param name="percentage"></param>
        private void ChangeProgress(int percentage)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => { ChangeProgress(percentage); }));
                return;
            }
            progressBar1.Value = percentage;
        }

        /// <summary>
        /// su kien CheckChanged cua cbxReviewData
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// su kien Click cua btnCancel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBoxManager.ShowQuestionMessageBox(this, "Bạn có chắc muốn ngừng lại và đóng cửa sổ này không?") == DialogResult.Yes)
            {
                bgwReadData.CancelAsync();
                this.Dispose();
            }
            else
            {
                DialogResult = System.Windows.Forms.DialogResult.None;
            }
        }

        /// <summary>
        /// su kien Click cua btnNext
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Clicked(object sender, EventArgs e)
        {
            // neu cbxReviewData duoc check thi hien thi FrmDayOffReviewData
            if (cbxReviewData.Checked)
            {
                FrmDayOffReviewData frmReviewData = new FrmDayOffReviewData(DayOffList);
                workItem.SmartParts.Add(frmReviewData);
                this.Hide();
                frmReviewData.ShowDialog(this);
                this.Dispose();
            }
            else
            {
                // nguoc lai hien thi FrmDayOffIntegrateData
                if (MessageBoxManager.ShowQuestionMessageBox(this, "Bạn có chắc muốn tích hợp dữ liệu thành viên vào hệ thống không?") == DialogResult.Yes)
                {
                    FrmDayOffIntegrateData frmIntegrateData = new FrmDayOffIntegrateData(DayOffList);
                    workItem.SmartParts.Add(frmIntegrateData);
                    this.Hide();
                    frmIntegrateData.ShowDialog(this);
                    this.Dispose();
                }
            }
        }

        /// <summary>
        /// override OnFormClosing
        /// </summary>
        /// <param name="e"></param>
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
