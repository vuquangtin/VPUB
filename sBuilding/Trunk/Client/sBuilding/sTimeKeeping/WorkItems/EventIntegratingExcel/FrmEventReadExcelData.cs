using sWorldModel.Integrating;
using CommonControls;
using CommonControls.Custom;
using Microsoft.Practices.CompositeUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using CommonHelper.Utils;
using System.Resources;
using sTimeKeeping.Model;

namespace sTimeKeeping.WorkItems.EventIntegratingExcel
{
    /// <summary>
    /// class FrmEventReadExcelData : CommonControls.Custom.CommonDialog
    /// </summary>
    public partial class FrmEventReadExcelData : CommonControls.Custom.CommonDialog
    {
        #region Properties

        // tao bien BackgroundWorker bgwReadData
        private BackgroundWorker bgwReadData;

        // TimeKeepingComponentWorkItem
        private TimeKeepingComponentWorkItem workItem;
        [ServiceDependency]
        public TimeKeepingComponentWorkItem WorkItem
        {
            set { workItem = value; }
        }

        //tao bien List<EventImportObject> EventList
        public List<EventImportObject> EventList { get; set; }

        // FilePath
        public string FilePath { get; set; }

        public long OrgId { get; set; }
        public long SubOrgId { get; set; }

        // binding vs GUI
        public int colEventNameIndex { get; set; }
        public int colHourBeginIndex { get; set; }
        public int colDateIndex { get; set; }
        public int colHourKeepingIndex { get; set; }
        public int colDescriptionIndex { get; set; }
        public int colMemberCodeIndex { get; set; }
        public int colMemberNameIndex { get; set; }

        // firstRowIndex
        public int firstRowIndex { private get; set; }

        // ResourceManager
        public ResourceManager rm;

        #endregion

        #region Initialization

        /// <summary>
        /// contructor FrmEventReadExcelData
        /// </summary>
        public FrmEventReadExcelData()
        {
            InitializeComponent();

            // BackgroundWorker bgwReadData
            bgwReadData = new BackgroundWorker();
            bgwReadData.WorkerSupportsCancellation = true;
            bgwReadData.DoWork += bgwReadData_DoWork;
            bgwReadData.RunWorkerCompleted += bgwReadData_Completed;

            // gan su kien 
            cbxReviewData.CheckedChanged += cbxReviewData_CheckChanged;
            btnCancel.Click += btnCancel_Click;
            btnNext.Click += btnNext_Clicked;
        }

        /// <summary>
        /// override OnShown of Form
        /// </summary>
        /// <param name="e"></param>
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            // run bgwReadData
            if (!bgwReadData.IsBusy)
            {
                bgwReadData.RunWorkerAsync();
            }

            // SetResoucreLanguages
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
        }

        private const int WS_SYSMENU = 0x80000;

        /// <summary>
        /// override CreateParams
        /// </summary>
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
        /// bgwReadData_DoWork
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwReadData_DoWork(object sender, DoWorkEventArgs e)
        {
            // tao isOk
            bool isOk;

            // ChangeMessage
            ChangeMessage("Đang thu thập dữ liệu...");

            try
            {
                //trang.vo
                //use import from file excel .xlsx .xls
                EventList = EventExcelReader.SelectAllEventList(FilePath, OrgId, SubOrgId, colEventNameIndex, colDateIndex,
            colHourBeginIndex, colHourKeepingIndex, colDescriptionIndex, colMemberNameIndex, colMemberCodeIndex, firstRowIndex, out isOk);
            }
            // IOException Exception
            catch (IOException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, "Tập tin Excel đang mở. Vui lòng đóng tập tin và thử lại!");
                e.Cancel = true;
                return;
            }
            // Exception
            catch (Exception ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ex.Message);
                e.Cancel = true;
                return;
            }

            // ChangeProgress ve 100
            ChangeProgress(100);
        }

        /// <summary>
        /// bgwReadData_Completed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwReadData_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            // kiem tra e.Cancelled
            if (e.Cancelled)
            {
                progressBar1.Value = 0;
                lblMessage.Text = "Quá trình thu thập dữ liệu đã bị ngưng!";
                return;
            }

            // neu thu thap du lieu da hoan tat
            progressBar1.Value = 100;
            lblMessage.Text = "Quá trình thu thập dữ liệu đã hoàn tất!";
            btnNext.Enabled = true;
        }

        /// <summary>
        /// ChangeMessage
        /// </summary>
        /// <param name="msg"></param>
        private void ChangeMessage(string msg)
        {
            // Invoke
            if (InvokeRequired)
            {
                Invoke(new Action(() => { ChangeMessage(msg); }));
                return;
            }

            // gan lblMessage.Text
            lblMessage.Text = msg;
        }

        /// <summary>
        /// ChangeProgress
        /// </summary>
        /// <param name="percentage"></param>
        private void ChangeProgress(int percentage)
        {
            // Invoke
            if (InvokeRequired)
            {
                Invoke(new Action(() => { ChangeProgress(percentage); }));
                return;
            }

            // gan progressBar1.Value
            progressBar1.Value = percentage;
        }

        /// <summary>
        /// cbxReviewData_CheckChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxReviewData_CheckChanged(object sender, EventArgs e)
        {
            // kiem tra cbxReviewData.Checked
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
        /// btnCancel_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            // neu muon ngung
            if (MessageBoxManager.ShowQuestionMessageBox(this, "Bạn có chắc muốn ngừng lại và đóng cửa sổ này không?") == DialogResult.Yes)
            {
                // bgwReadData.CancelAsync
                bgwReadData.CancelAsync();

                this.Dispose();
            }
            else
            {
                DialogResult = System.Windows.Forms.DialogResult.None;
            }
        }

        /// <summary>
        /// btnNext_Clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Clicked(object sender, EventArgs e)
        {
            // kiem tra cbxReviewData.Checked
            if (cbxReviewData.Checked)
            {
                // tao FrmEventReviewData
                FrmEventReviewData frmReviewData = new FrmEventReviewData(EventList);
                workItem.SmartParts.Add(frmReviewData);
                this.Hide();

                // ShowDialog
                frmReviewData.ShowDialog(this);
                this.Dispose();
            }
            else
            {
                // nue chon tich hop
                if (MessageBoxManager.ShowQuestionMessageBox(this, "Bạn có chắc muốn tích hợp dữ liệu thành viên vào hệ thống không?") == DialogResult.Yes)
                {
                    // tao FrmEventIntegrateData
                    FrmEventIntegrateData frmIntegrateData = new FrmEventIntegrateData(EventList);
                    workItem.SmartParts.Add(frmIntegrateData);
                    this.Hide();

                    // ShowDialog
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

            // run bgwReadData
            if (bgwReadData.IsBusy)
            {
                bgwReadData.CancelAsync();
            }
        }

        #endregion
    }
}
