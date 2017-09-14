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

namespace MemberMgtComponent.WorkItems.IntegratingExcel
{
    public partial class FrmReviewData : CommonControls.Custom.CommonDialog
    {
        #region Properties

        private List<Member> MemberList { get; set; }

        private MemberWorkItem workItem;
        [ServiceDependency]
        public MemberWorkItem WorkItem
        {
            set { workItem = value; }
        }

        #endregion

        #region Initialization

        public FrmReviewData(List<Member> memberList)
        {
            InitializeComponent();
            InitDataGridView();

            this.MemberList = memberList;

            lblTotalRecords.Text = string.Empty;

            dgvRecords.AutoGenerateColumns = true;
            cmbTables.SelectedIndexChanged += cmbTables_SelectedIndexChanged;

            cmbTables.SelectedIndexChanged += cmbTables_SelectedIndexChanged;
            btnNext.Click += btnNext_Click;
            btnCancel.Click += btnCancel_Click;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            string[] dataSetNames = new string[]
            {
                "MEMBER_ALL_LIST",
            };
            cmbTables.DataSource = dataSetNames;
            cmbTables.SelectedIndex = 0;
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
                case "MEMBER_ALL_LIST":
                    LoadDGVMemberList(MemberList);
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
                FrmIntegrateData frmIntegrateData = new FrmIntegrateData(MemberList);
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

        #region InitializationDataGridView

        private DataGridViewTextBoxColumn ColCode { get; set; }
        private DataGridViewTextBoxColumn ColFirstName { get; set; }
        private DataGridViewTextBoxColumn ColLastName { get; set; }
        private DataGridViewTextBoxColumn ColBirthDate { get; set; }
        private DataGridViewTextBoxColumn ColGender { get; set; }
        private DataGridViewTextBoxColumn ColNationality { get; set; }
        private DataGridViewTextBoxColumn ColCompanyname { get; set; }
        private DataGridViewTextBoxColumn ColDegree { get; set; }
        private DataGridViewTextBoxColumn ColPosition { get; set; }
        private DataGridViewTextBoxColumn ColPhoneNo { get; set; }
        private DataGridViewTextBoxColumn ColEmail { get; set; }
        private DataGridViewTextBoxColumn ColPermanentAddress { get; set; }
        private DataGridViewTextBoxColumn ColTemporaryAddress { get; set; }

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

        public void InitDataGridView()
        {
            ColCode = CreateColunm("Code", "Mã TV", 60);
            ColFirstName = CreateColunm("FirstName", "Họ Và Tên Đệm", 120);
            ColLastName = CreateColunm("LastName", "Tên", 80);
            ColBirthDate = CreateColunm("BirthDate", "Ngày Sinh", 100);
            ColGender = CreateColunm("Gender", "Giới Tính", 80);
            ColNationality = CreateColunm("Nationality", "Quốc Tịch", 100);
            ColCompanyname = CreateColunm("Companyname", "Tên Công Ty", 160);
            ColDegree = CreateColunm("Degree", "Trình Độ", 120);
            ColPosition = CreateColunm("Position", "Chức Vụ", 120);
            ColPhoneNo = CreateColunm("PhoneNo", "Điện Thoại", 100);
            ColEmail = CreateColunm("Email", "Email", 160);
            ColPermanentAddress = CreateColunm("PermanentAddress", "Địa Chỉ Thường Trú", 250);
            ColTemporaryAddress = CreateColunm("TemporaryAddress", "Địa Chỉ Tạm Trú", 250);

            dgvRecords.Columns.Add(ColCode);
            dgvRecords.Columns.Add(ColFirstName);
            dgvRecords.Columns.Add(ColLastName);
            dgvRecords.Columns.Add(ColBirthDate);
            dgvRecords.Columns.Add(ColGender);
            dgvRecords.Columns.Add(ColNationality);
            dgvRecords.Columns.Add(ColCompanyname);
            dgvRecords.Columns.Add(ColDegree);
            dgvRecords.Columns.Add(ColPosition);
            dgvRecords.Columns.Add(ColPhoneNo);
            dgvRecords.Columns.Add(ColEmail);
            dgvRecords.Columns.Add(ColTemporaryAddress);
            dgvRecords.Columns.Add(ColPermanentAddress);
        }

        public void LoadDGVMemberList(List<Member> memberList)
        {
            DataTable result = CreateMemberDataList();
            
            foreach (Member member in memberList)
            {
                DataRow row = result.NewRow();
                row.BeginEdit();

                row[ColCode.DataPropertyName] = member.Code;
                row[ColFirstName.DataPropertyName] = member.FirstName;
                row[ColLastName.DataPropertyName] = member.LastName;
                row[ColBirthDate.DataPropertyName] = member.BirthDate;
                row[ColGender.DataPropertyName] = member.Gender;
                row[ColNationality.DataPropertyName] = member.Nationality;
                row[ColCompanyname.DataPropertyName] = member.Companyname;
                row[ColDegree.DataPropertyName] = member.Degree;
                row[ColPosition.DataPropertyName] = member.Position;
                row[ColPhoneNo.DataPropertyName] = member.PhoneNo;
                row[ColEmail.DataPropertyName] = member.Email;
                row[ColPermanentAddress.DataPropertyName] = member.PermanentAddress;
                row[ColTemporaryAddress.DataPropertyName] = member.TemporaryAddress;

                row.EndEdit();
                result.Rows.Add(row);
                dgvRecords.DataSource = result;
            }
        }

        public DataTable CreateMemberDataList()
        {
            DataTable dbMemberList = new DataTable();

            dbMemberList.Columns.Add(ColCode.DataPropertyName);
            dbMemberList.Columns.Add(ColFirstName.DataPropertyName);
            dbMemberList.Columns.Add(ColLastName.DataPropertyName);
            dbMemberList.Columns.Add(ColBirthDate.DataPropertyName);
            dbMemberList.Columns.Add(ColGender.DataPropertyName);
            dbMemberList.Columns.Add(ColNationality.DataPropertyName);
            dbMemberList.Columns.Add(ColCompanyname.DataPropertyName);
            dbMemberList.Columns.Add(ColDegree.DataPropertyName);
            dbMemberList.Columns.Add(ColPosition.DataPropertyName);
            dbMemberList.Columns.Add(ColPhoneNo.DataPropertyName);
            dbMemberList.Columns.Add(ColEmail.DataPropertyName);
            dbMemberList.Columns.Add(ColPermanentAddress.DataPropertyName);
            dbMemberList.Columns.Add(ColTemporaryAddress.DataPropertyName);

            return dbMemberList;
        }

        

        #endregion
    }
}
