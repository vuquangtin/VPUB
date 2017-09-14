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
using sWorldModel.TransportData;
using System.Resources;
using CommonHelper.Utils;
using CommonHelper.Constants;

namespace SystemMgtComponent.WorkItems.ApartmentIntegratingExcel
{
    public partial class FrmReadExcelData : CommonControls.Custom.CommonDialog
    {
        #region Properties
        private ResourceManager rmNew;

        private BackgroundWorker bgwReadData;

        private SystemWorkItem workItem;
        [ServiceDependency]
        public SystemWorkItem WorkItem
        {
            set { workItem = value; }
        }

        public List<ManagerCostApartment> Apartments { get; set; }

        public string FilePath { private get; set; }

        public int FirstRowIndex { private get; set; }

        public long SubOrgId { private get; set; }

        public int SubOrgCodeIndex { private get; set; }

        public int NameHeadApartmentdIndex { private get; set; }

        public int PayManagerIndex { private get; set; }

        public int PayWaterIndex { private get; set; }

        public int DayPayIndex { private get; set; }

        public int ManagerCostOldIndex { private get; set; }

        public int SumMoneyIndex { private get; set; }

        #endregion

        #region Initialization

        public FrmReadExcelData(ResourceManager rm)
        {
            InitializeComponent();
            rmNew = rm;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
            this.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.Name);


            bgwReadData = new BackgroundWorker();
            bgwReadData.WorkerSupportsCancellation = true;
            bgwReadData.DoWork += bgwReadData_DoWork;
            bgwReadData.RunWorkerCompleted += bgwReadData_Completed;

            cbxReviewData.CheckedChanged += cbxReviewData_CheckChanged;
            btnCancel.Click += btnCancel_Click;
            btnNext.Click += btnNext_Clicked;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

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
            bool isOk;
            ChangeMessage(MessageValidate.GetMessage(rmNew, "LoadingWaitingMoneyWater"));
            try
            {
                Apartments = ExcelReader.SelectManagerCostList(
                    FilePath,SubOrgId, SubOrgCodeIndex, NameHeadApartmentdIndex,
                    PayManagerIndex, PayWaterIndex, DayPayIndex, ManagerCostOldIndex,
                    SumMoneyIndex,FirstRowIndex, out isOk);
            }
            catch (IOException)
            {
              
   
                   MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rmNew, "messageClosefile"));
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

        private void bgwReadData_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                progressBar1.Value = 0;
                lblMessage.Text = MessageValidate.GetMessage(rmNew, "messageStopCollect");
                lblMessage.ForeColor = Color.Red;
            }
            else
            {
                progressBar1.Value = 100;
                lblMessage.Text = MessageValidate.GetMessage(rmNew, "messageCompleteCollect");
                btnNext.Enabled = true;
            }
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
            if (this.IsDisposed)
            {
                return;
            }
            if (MessageBoxManager.ShowQuestionMessageBox(this, MessageValidate.GetMessage(rmNew, "messageStopClose")) == DialogResult.Yes)
            {
                bgwReadData.CancelAsync();
                this.Dispose();
            }
            else
            {
                DialogResult = System.Windows.Forms.DialogResult.None;
            }
        }

        private void btnNext_Clicked(object sender, EventArgs e)
        {
            if (this.IsDisposed)
            {
                return;
            }
            if (cbxReviewData.Checked)
            {
                FrmReviewData frmReviewData = new FrmReviewData(Apartments,rmNew);
                workItem.SmartParts.Add(frmReviewData);
                this.Hide();
                frmReviewData.ShowDialog(this);
                this.Dispose();
            }
            else
            {
                if (MessageBoxManager.ShowQuestionMessageBox(this, MessageValidate.GetMessage(rmNew, "messageIntegrate")) == DialogResult.Yes)
                {
                    FrmIntegrateData frmIntegrateData = new FrmIntegrateData(Apartments,rmNew);
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
