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
using sWorldModel.TransportData;
using CommonHelper.Utils;
using System.Resources;

namespace SystemMgtComponent.WorkItems.IntegratingExcel
{
    public partial class FrmReadExcelData : CommonControls.Custom.CommonDialog
    {
        #region Properties

        private BackgroundWorker bgwReadData;

        private SystemWorkItem workItem;
        [ServiceDependency]
        public SystemWorkItem WorkItem
        {
            set { workItem = value; }
        }

        public List<sWorldModel.TransportData.Member> MemberList { get; set; }
        public long OrgId { private get; set; }
        public long SubOrgId { private get; set; }
        public string FilePath { private get; set; }
        public int ColCodeIndex { private get; set; }
        public int ColFirstNameIndex { private get; set; }
        public int ColLastNameIndex { private get; set; }
        public int ColBirthDateIndex { private get; set; }
        public int ColCompanynameIndex { private get; set; }
        public int ColGenderIndex { private get; set; }
        public int ColDegreeIndex { private get; set; }
        public int ColPositionIndex { private get; set; }
        public int ColPermanentAddressIndex { private get; set; }
        public int ColTemporaryAddressIndex { private get; set; }
        public int ColPhoneNoIndex { private get; set; }
        public int ColEmailIndex { private get; set; }
        public int ColNationalityIndex { private get; set; }
        public int ColContactNameIndex { private get; set; }
        public int ColContactPhoneIndex { private get; set; }
        public int ColContactEmailIndex { private get; set; }
        public int ColContactAddressIndex { private get; set; }

        public int ColIdentityCardIndex { private get; set; }
        public int ColIdentityCardDateIndex { private get; set; }
        public int ColIdentityCardIssueIndex { private get; set; }

        public int FirstRowIndex { private get; set; }

        //check Journalist
        public string Title { private get; set; }

        public ResourceManager rm;

        #endregion

        #region Initialization

        public FrmReadExcelData()
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

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            //dbReader = new AccessDbReader(FilePath, UserId, Password);
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

        private void bgwReadData_DoWork(object sender, DoWorkEventArgs e)
        {
            bool isOk;
            ChangeMessage("Đang thu thập dữ liệu...");
            try
            {

                //v2
                //my.nguyen
                //use import from file excel .xlsx .xls
                ColContactNameIndex = ColContactPhoneIndex = ColContactEmailIndex = ColContactAddressIndex = -1;
                MemberList = ExcelReader.SelectAllMemberListFORALLSTYLESFILEEXCEL(
                   FilePath, OrgId, SubOrgId, ColCodeIndex, ColFirstNameIndex,
                   ColLastNameIndex, ColBirthDateIndex, ColCompanynameIndex, ColGenderIndex,
                   ColDegreeIndex, ColPositionIndex, ColPermanentAddressIndex,
                   ColTemporaryAddressIndex, ColPhoneNoIndex, ColEmailIndex, ColNationalityIndex,
                   ColContactNameIndex, ColContactPhoneIndex, ColContactEmailIndex, ColContactAddressIndex,
                   ColIdentityCardIndex, ColIdentityCardDateIndex, ColIdentityCardIssueIndex,
                   FirstRowIndex, Title, out isOk);

                //v1
                //MemberList = ExcelReader.SelectAllMemberList(
                //    FilePath, OrgId, SubOrgId, ColCodeIndex, ColFirstNameIndex,
                //    ColLastNameIndex, ColBirthDateIndex, ColCompanynameIndex, ColGenderIndex,
                //    ColDegreeIndex, ColPositionIndex, ColPermanentAddressIndex,
                //    ColTemporaryAddressIndex, ColPhoneNoIndex, ColEmailIndex, ColNationalityIndex,
                //    ColContactNameIndex, ColContactPhoneIndex, ColContactEmailIndex, ColContactAddressIndex,
                //    ColIdentityCardIndex, ColIdentityCardDateIndex, ColIdentityCardIssueIndex,
                //    FirstRowIndex, Title, out isOk);

                if (!isOk)
                {
                    MessageBoxManager.ShowErrorMessageBox(this, string.Format("Vui lòng cập nhật ngày sinh theo định dạng ngày/tháng/năm ({0})!", DateTime.Now.ToStringFormatDate()));
                    e.Cancel = true;
                    return;
                }
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
            if (cbxReviewData.Checked)
            {
                FrmReviewData frmReviewData = new FrmReviewData(MemberList);
                workItem.SmartParts.Add(frmReviewData);
                this.Hide();
                frmReviewData.ShowDialog(this);
                this.Dispose();
            }
            else
            {
                if (MessageBoxManager.ShowQuestionMessageBox(this, "Bạn có chắc muốn tích hợp dữ liệu thành viên vào hệ thống không?") == DialogResult.Yes)
                {
                    FrmIntegrateData frmIntegrateData = new FrmIntegrateData(MemberList);
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
