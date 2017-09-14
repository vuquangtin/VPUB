using sWorldModel.Integrating;
using CommonControls;
using CommonControls.Custom;
using Microsoft.Practices.CompositeUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sWorldModel.TransportData;
using sTimeKeeping.Model;

namespace sTimeKeeping.WorkItems.EventIntegratingExcel
{
    /// <summary>
    /// class FrmEventReviewData : CommonControls.Custom.CommonDialog
    /// </summary>
    public partial class FrmEventReviewData : CommonControls.Custom.CommonDialog
    {
        #region Properties

        // EventList
        private List<EventImportObject> EventList { get; set; }

        // TimeKeepingComponentWorkItem
        private TimeKeepingComponentWorkItem workItem;
        [ServiceDependency]
        public TimeKeepingComponentWorkItem WorkItem
        {
            set { workItem = value; }
        }

        #endregion

        #region Initialization

        /// <summary>
        /// contructor FrmEventReviewData
        /// </summary>
        /// <param name="memberList"></param>
        public FrmEventReviewData(List<EventImportObject> memberList)
        {
            // init
            InitializeComponent();
            InitDataGridView();

            // gan gia tri EventList
            this.EventList = memberList;

            // gan Empty cho lblTotalRecords.Text 
            lblTotalRecords.Text = string.Empty;

            dgvRecords.AutoGenerateColumns = true;

            // gan su kien 
            cmbTables.SelectedIndexChanged += cmbTables_SelectedIndexChanged;
            cmbTables.SelectedIndexChanged += cmbTables_SelectedIndexChanged;
            btnNext.Click += btnNext_Click;
            btnCancel.Click += btnCancel_Click;
        }

        /// <summary>
        /// override OnShown of Form
        /// </summary>
        /// <param name="e"></param>
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            // tao dataSetNames
            string[] dataSetNames = new string[]
            {
                "EVENT_ALL_LIST",
            };

            // gan DataSource
            cmbTables.DataSource = dataSetNames;
            cmbTables.SelectedIndex = 0;
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
        /// cmbTables_SelectedIndexChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            // get selectedTables tu cmbTables.SelectedItem
            string selectedTables = cmbTables.SelectedItem.ToString();

            // kiem tra selectedTables
            switch (selectedTables)
            {
                case "EVENT_ALL_LIST":
                    // neu EVENT_ALL_LIST thi LoadDGVMemberList(EventList)
                    LoadDGVEventList(EventList);
                    break;
                default:
                    break;
            }

            // set text cho lblTotalRecords la tong so dong
            lblTotalRecords.Text = string.Format("Tổng cộng: {0} dòng dữ liệu", dgvRecords.RowCount);

            // duyet tren dgvRecords.ColumnCount
            for (int i = 0; i < dgvRecords.ColumnCount; i++)
            {
                // set AutoSizeMode
                dgvRecords.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                // set SortMode
                dgvRecords.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }

        /// <summary>
        /// btnNext_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click(object sender, EventArgs e)
        {
            // neu chon tich hop
            if (MessageBoxManager.ShowQuestionMessageBox(this, "Bạn có chắc muốn tích hợp dữ liệu vào hệ thống không?") == DialogResult.Yes)
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

        /// <summary>
        /// btnCancel_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            // neu chon ngung lai
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

        // InitializationDataGridView
        private DataGridViewTextBoxColumn ColMemberCode { get; set; }
        private DataGridViewTextBoxColumn ColMemberName { get; set; }
        private DataGridViewTextBoxColumn ColSubOrg { get; set; }
        private DataGridViewTextBoxColumn ColEventName { get; set; }
        private DataGridViewTextBoxColumn ColDate { get; set; }
        private DataGridViewTextBoxColumn ColHourBegin { get; set; }
        private DataGridViewTextBoxColumn ColHourKeeping { get; set; }
        private DataGridViewTextBoxColumn ColDescription { get; set; }

        /// <summary>
        /// CreateColunm
        /// </summary>
        /// <param name="dataPropertyName"></param>
        /// <param name="headerName"></param>
        /// <param name="wight"></param>
        /// <param name="isReadOnly"></param>
        /// <returns></returns>
        public DataGridViewTextBoxColumn CreateColunm(string dataPropertyName, string headerName, int wight, bool isReadOnly = true)
        {
            // tao DataGridViewTextBoxColumn
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
            ColEventName = CreateColunm("EventName", "Tên sự kiện", 255);
            ColDate = CreateColunm("Date", "Ngày", 100);
            ColHourBegin = CreateColunm("HourBegin", "Thời gian bắt đầu", 80);
            ColHourKeeping = CreateColunm("HourKeeping", "Thời gian", 100);
            ColDescription = CreateColunm("Description", "Mô tả", 255);

            // add column vao dgvRecords
            dgvRecords.Columns.Add(ColMemberCode);
            dgvRecords.Columns.Add(ColMemberName);
            dgvRecords.Columns.Add(ColSubOrg);
            dgvRecords.Columns.Add(ColEventName);
            dgvRecords.Columns.Add(ColDate);
            dgvRecords.Columns.Add(ColHourBegin);
            dgvRecords.Columns.Add(ColHourKeeping);
            dgvRecords.Columns.Add(ColDescription);
        }

        /// <summary>
        /// Load EventList
        /// </summary>
        /// <param name="eventList"></param>
        public void LoadDGVEventList(List<EventImportObject> eventList)
        {
            // get result ;list
            DataTable result = CreateMemberDataList();

            // duyet tren eventList
            foreach (EventImportObject eventCus in eventList)
            {
                // tao new row
                DataRow row = result.NewRow();

                // BeginEdit
                row.BeginEdit();

                // gan gia tri
                row[ColMemberCode.DataPropertyName] = eventCus.MemberCode;
                row[ColMemberName.DataPropertyName] = eventCus.MemberName;
                row[ColEventName.DataPropertyName] = eventCus.EventName;
                row[ColDate.DataPropertyName] = eventCus.Date;
                row[ColHourBegin.DataPropertyName] = eventCus.HourBegin;
                row[ColHourKeeping.DataPropertyName] = eventCus.HourKeeping;
                row[ColDescription.DataPropertyName] = eventCus.Description;

                // EndEdit 
                row.EndEdit();

                // add row 
                result.Rows.Add(row);

                // set DataSource
                dgvRecords.DataSource = result;
            }
        }

        public DataTable CreateMemberDataList()
        {
            DataTable dbMemberList = new DataTable();

            dbMemberList.Columns.Add(ColMemberCode.DataPropertyName);
            dbMemberList.Columns.Add(ColMemberName.DataPropertyName);
            dbMemberList.Columns.Add(ColSubOrg.DataPropertyName);
            dbMemberList.Columns.Add(ColEventName.DataPropertyName);
            dbMemberList.Columns.Add(ColDate.DataPropertyName);
            dbMemberList.Columns.Add(ColHourBegin.DataPropertyName);
            dbMemberList.Columns.Add(ColHourKeeping.DataPropertyName);
            dbMemberList.Columns.Add(ColDescription.DataPropertyName);
            
            return dbMemberList;
        }
        
        #endregion
    }
}
