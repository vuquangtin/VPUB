using CommonControls;
using Microsoft.Practices.CompositeUI;
using sTimeKeeping.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sTimeKeeping.WorkItems.DayOffIntegratingExcel
{
    /// <summary>
    /// class FrmDayOffReviewData : CommonControls.Custom.CommonDialog
    /// </summary>
    public partial class FrmDayOffReviewData : CommonControls.Custom.CommonDialog
    {
        #region Properties
        // Properties
        private const int NGHI_PHEP_CA_NGAY = 1;

        private bool checkReview = true;

        private List<DayOffImportObject> DayOffList { get; set; }

        private TimeKeepingComponentWorkItem workItem;
        [ServiceDependency]
        public TimeKeepingComponentWorkItem WorkItem
        {
            set { workItem = value; }
        }

        #endregion

        #region Initialization

        /// <summary>
        /// contructor Initialization
        /// </summary>
        /// <param name="memberList"></param>
        public FrmDayOffReviewData(List<DayOffImportObject> memberList)
        {
            InitializeComponent();
            InitDataGridView();

            this.DayOffList = memberList;
            lblTotalRecords.Text = string.Empty;
            dgvRecords.AutoGenerateColumns = true;

            // gan su kien
            cmbTables.SelectedIndexChanged += cmbTables_SelectedIndexChanged;
            cmbTables.SelectedIndexChanged += cmbTables_SelectedIndexChanged;
            btnNext.Click += btnNext_Click;
            btnCancel.Click += btnCancel_Click;
        }
        /// <summary>
        /// event OnShown of form 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            string[] dataSetNames = new string[]
            {
                "DAY_OFF_ALL_LIST",
            };
            cmbTables.DataSource = dataSetNames;
            cmbTables.SelectedIndex = 0;
        }
        
        private const int WS_SYSMENU = 0x80000;
        /// <summary>
        /// override ham CreateParams
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
        /// su kien SelectedIndexChanged of cmbTables
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedTables = cmbTables.SelectedItem.ToString();

            switch (selectedTables)
            {
                case "DAY_OFF_ALL_LIST":
                    LoadDGVDayOffList(DayOffList);
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

        /// <summary>
        /// su kien khi Click btnNext
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (checkReview)
            {
                if (MessageBoxManager.ShowQuestionMessageBox(this, "Bạn có chắc muốn tích hợp dữ liệu vào hệ thống không?") == DialogResult.Yes)
                {
                    checkReview = false;
                    FrmDayOffIntegrateData frmIntegrateData = new FrmDayOffIntegrateData(DayOffList);
                    workItem.SmartParts.Add(frmIntegrateData);
                    this.Hide();
                    frmIntegrateData.ShowDialog(this);
                    this.Close();

                    //workItem.SmartParts.Remove(this);
                }
                
            }
           
        }

        /// <summary>
        /// su kien khi Click btnCancel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        #region InitializationDataGridView

        private DataGridViewTextBoxColumn ColMemberCode { get; set; }
        private DataGridViewTextBoxColumn ColMemberName { get; set; }
        private DataGridViewTextBoxColumn ColSubOrg { get; set; }
        private DataGridViewTextBoxColumn ColDate { get; set; }
        private DataGridViewTextBoxColumn ColTypeDayOff { get; set; }
        private DataGridViewTextBoxColumn ColNote { get; set; }

        /// <summary>
        /// Create Colunm
        /// </summary>
        /// <param name="dataPropertyName"></param>
        /// <param name="headerName"></param>
        /// <param name="wight"></param>
        /// <param name="isReadOnly"></param>
        /// <returns></returns>
        public DataGridViewTextBoxColumn CreateColunm(string dataPropertyName, string headerName, int wight, bool isReadOnly = true)
        {
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            col.DataPropertyName = dataPropertyName;
            col.HeaderText = headerName;
            col.Name = string.Format("col{0}", dataPropertyName);
            col.ReadOnly = isReadOnly;
            col.Width = wight;
            return col;
        }

        /// <summary>
        /// Init Data Grid View
        /// </summary>
        public void InitDataGridView()
        {
            ColMemberCode = CreateColunm("MemberCode", "Mã Chuyên viên", 60);
            ColMemberName = CreateColunm("MemberName", "Họ và tên", 225);
            ColSubOrg = CreateColunm("SubOrg", "Phòng ban", 255);
            ColDate = CreateColunm("Date", "Ngày nghỉ", 100);
            ColTypeDayOff = CreateColunm("TypeDayOff", "Loại nghỉ phép", 80);
            ColNote = CreateColunm("HourNote", "Chú thích", 255);

            dgvRecords.Columns.Add(ColMemberCode);
            dgvRecords.Columns.Add(ColMemberName);
            dgvRecords.Columns.Add(ColSubOrg);
            dgvRecords.Columns.Add(ColDate);
            dgvRecords.Columns.Add(ColTypeDayOff);
            dgvRecords.Columns.Add(ColNote);
        }

        /// <summary>
        /// Load DGV DayOff List
        /// </summary>
        /// <param name="dayOffList"></param>
        public void LoadDGVDayOffList(List<DayOffImportObject> dayOffList)
        {
            DataTable result = CreateDayOffDataList();

            foreach (DayOffImportObject dayOff in dayOffList)
            {
                DataRow row = result.NewRow();
                row.BeginEdit();

                row[ColMemberCode.DataPropertyName] = dayOff.MemberCode;
                row[ColMemberName.DataPropertyName] = dayOff.MemberName;
                row[ColDate.DataPropertyName] = dayOff.DateOff;
                row[ColTypeDayOff.DataPropertyName] = dayOff.TypeDayOff == NGHI_PHEP_CA_NGAY ? "Nghỉ phép cả ngày" : "Nghỉ phép nửa ngày";
                row[ColNote.DataPropertyName] = dayOff.Note;

                row.EndEdit();
                result.Rows.Add(row);
                dgvRecords.DataSource = result;
            }
        }
        /// <summary>
        /// Create DayOff Data List
        /// </summary>
        /// <returns></returns>
        public DataTable CreateDayOffDataList()
        {
            DataTable dbMemberList = new DataTable();

            dbMemberList.Columns.Add(ColMemberCode.DataPropertyName);
            dbMemberList.Columns.Add(ColMemberName.DataPropertyName);
            dbMemberList.Columns.Add(ColSubOrg.DataPropertyName);
            dbMemberList.Columns.Add(ColDate.DataPropertyName);
            dbMemberList.Columns.Add(ColTypeDayOff.DataPropertyName);
            dbMemberList.Columns.Add(ColNote.DataPropertyName);

            return dbMemberList;
        }

        #endregion
    }
}
