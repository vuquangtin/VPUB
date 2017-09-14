using CommonControls;
using CommonControls.Custom;
using sWorldModel.Integrating;
using Microsoft.Practices.CompositeUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MemberMgtComponent.WorkItems.Integrating
{
    public partial class FrmReviewData : CommonControls.Custom.CommonDialog
    {
        #region Properties

        private List<ALL_BO_MON> Departments { get; set; }
        private List<ALL_KHOA> Faculties { get; set; }
        private List<ALL_CBCNV> Teachers { get; set; }
        private List<ALL_CHUC_VU> Positions { get; set; }
        private List<ALL_NGACH> Scales { get; set; }

        private MemberWorkItem workItem;
        [ServiceDependency]
        public MemberWorkItem WorkItem
        {
            set { workItem = value; }
        }

        #endregion

        #region Initialization

        public FrmReviewData(List<ALL_BO_MON> departments, List<ALL_KHOA> faculties, List<ALL_CBCNV> teachers, List<ALL_CHUC_VU> positions, List<ALL_NGACH> scales)
        {
            InitializeComponent();

            this.Departments = departments;
            this.Faculties = faculties;
            this.Teachers = teachers;
            this.Positions = positions;
            this.Scales = scales;

            lblTotalRecords.Text = string.Empty;

            dgvRecords.AutoGenerateColumns = true;
            cmbTables.SelectedIndexChanged += cmbTables_SelectedIndexChanged;

            string[] dataSetNames = new string[]
            {
                "ALL_BO_MON",
                "ALL_CBCNV",
                "ALL_CHUC_VU",
                "ALL_KHOA",
                "ALL_NGACH",
            };
            cmbTables.DataSource = dataSetNames;
            cmbTables.SelectedIndex = 0;

            cmbTables.SelectedIndexChanged += cmbTables_SelectedIndexChanged;
            btnNext.Click += btnNext_Click;
            btnCancel.Click += btnCancel_Click;
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

        private void cmbTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedTables = cmbTables.SelectedItem.ToString();

            switch (selectedTables)
            {
                case "ALL_BO_MON":
                    dgvRecords.DataSource = Departments;
                    break;
                case "ALL_KHOA":
                    dgvRecords.DataSource = Faculties;
                    break;
                case "ALL_CBCNV":
                    dgvRecords.DataSource = Teachers;
                    break;
                case "ALL_CHUC_VU":
                    dgvRecords.DataSource = Positions;
                    break;
                case "ALL_NGACH":
                    dgvRecords.DataSource = Scales;
                    break;
                default:
                    break;
            }

            lblTotalRecords.Text = string.Format("Tổng cộng: {0} dòng dữ liệu", dgvRecords.RowCount);

            for (int i = 0; i < dgvRecords.ColumnCount; i++)
            {
                dgvRecords.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvRecords.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
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

        #endregion
    }
}
