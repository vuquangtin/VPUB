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

namespace SystemMgtComponent.WorkItems.IntegratingExcel
{
    public partial class FrmReviewData : CommonControls.Custom.CommonDialog
    {
        #region Properties

        private List<sWorldModel.TransportData.Member> MemberList { get; set; }

        private SystemWorkItem workItem;
        [ServiceDependency]
        public SystemWorkItem WorkItem
        {
            set { workItem = value; }
        }

        #endregion

        #region Initialization

        public FrmReviewData(List<sWorldModel.TransportData.Member> memberList)
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
        private DataGridViewTextBoxColumn ColContactName { get; set; }
        private DataGridViewTextBoxColumn ColContactPhone { get; set; }
        private DataGridViewTextBoxColumn ColContactEmail { get; set; }
        private DataGridViewTextBoxColumn ColContactAddress { get; set; }

        private DataGridViewTextBoxColumn ColIdentityCard { get; set; }
        private DataGridViewTextBoxColumn ColIdentityCardDate { get; set; }
        private DataGridViewTextBoxColumn ColIdentityCardIssue { get; set; }

        private DataGridViewTextBoxColumn Title { get; set; }

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

            Title = CreateColunm("Title", "Nhà báo", 80);

            ColFirstName = CreateColunm("FirstName", "Tên", 120);
            ColLastName = CreateColunm("LastName", "Họ Và Tên Đệm", 80);
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
            ColContactName = CreateColunm("ContactName", "Tên Người Liên Hệ", 250);
            ColContactPhone = CreateColunm("ContactPhone", "Số ĐTDD Người Liên Hệ", 250);
            ColContactEmail = CreateColunm("ContactEmail", "Email Người Liên Hệ", 250);
            ColContactAddress = CreateColunm("ContactAddress", "Địa Chỉ Người Liên Hệ", 250);
            ColIdentityCard = CreateColunm("IdentityCard", "CMND", 250);
            ColIdentityCardDate = CreateColunm("IdentityCardDate", "Ngày Cấp", 250);
            ColIdentityCardIssue = CreateColunm("IdentityCardIssue", "Nơi Cấp", 250);

            dgvRecords.Columns.Add(ColCode);

            dgvRecords.Columns.Add(Title);

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
            dgvRecords.Columns.Add(ColContactName);
            dgvRecords.Columns.Add(ColContactPhone);
            dgvRecords.Columns.Add(ColContactEmail);
            dgvRecords.Columns.Add(ColContactAddress);
            dgvRecords.Columns.Add(ColIdentityCard);
            dgvRecords.Columns.Add(ColIdentityCardDate);
            dgvRecords.Columns.Add(ColIdentityCardIssue);
        }

        public void LoadDGVMemberList(List<sWorldModel.TransportData.Member> memberList)
        {
            DataTable result = CreateMemberDataList();

            foreach (sWorldModel.TransportData.Member memberCus in memberList)
            {
                DataRow row = result.NewRow();
                row.BeginEdit();

                row[ColCode.DataPropertyName] = memberCus.Code;

                row[Title.DataPropertyName] = memberCus.Title;

                row[ColFirstName.DataPropertyName] = memberCus.FirstName;
                row[ColLastName.DataPropertyName] = memberCus.LastName;
                row[ColBirthDate.DataPropertyName] = memberCus.BirthDate;
                row[ColGender.DataPropertyName] = memberCus.Gender;
                row[ColNationality.DataPropertyName] = memberCus.Nationality;
                row[ColCompanyname.DataPropertyName] = memberCus.Companyname;
                row[ColDegree.DataPropertyName] = memberCus.Degree;
                row[ColPosition.DataPropertyName] = memberCus.Position;
                row[ColPhoneNo.DataPropertyName] = memberCus.PhoneNo;
                row[ColEmail.DataPropertyName] = memberCus.Email;
                row[ColPermanentAddress.DataPropertyName] = memberCus.PermanentAddress;
                row[ColTemporaryAddress.DataPropertyName] = memberCus.TemporaryAddress;

                row[ColIdentityCard.DataPropertyName] = memberCus.IdentityCard;
                row[ColIdentityCardDate.DataPropertyName] = memberCus.IdentityCardIssueDate;
                row[ColIdentityCardIssue.DataPropertyName] = memberCus.IdentityCardIssue;

                row[ColContactName.DataPropertyName] = memberCus.ContactName;
                row[ColContactPhone.DataPropertyName] = memberCus.ContactPhone;
                row[ColContactEmail.DataPropertyName] = memberCus.ContactEmail;
                row[ColContactAddress.DataPropertyName] = memberCus.ContactAddress;

                row.EndEdit();
                result.Rows.Add(row);
                dgvRecords.DataSource = result;
            }
        }

        public DataTable CreateMemberDataList()
        {
            DataTable dbMemberList = new DataTable();

            dbMemberList.Columns.Add(ColCode.DataPropertyName);

            dbMemberList.Columns.Add(Title.DataPropertyName);

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

            dbMemberList.Columns.Add(ColIdentityCard.DataPropertyName);
            dbMemberList.Columns.Add(ColIdentityCardDate.DataPropertyName);
            dbMemberList.Columns.Add(ColIdentityCardIssue.DataPropertyName);

            dbMemberList.Columns.Add(ColContactName.DataPropertyName);
            dbMemberList.Columns.Add(ColContactPhone.DataPropertyName);
            dbMemberList.Columns.Add(ColContactEmail.DataPropertyName);
            dbMemberList.Columns.Add(ColContactAddress.DataPropertyName);

            return dbMemberList;
        }

        

        #endregion
    }
}
