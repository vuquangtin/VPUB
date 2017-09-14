using sWorldModel;
using sWorldModel.Exceptions;
using sWorldModel.Integrating;
using CommonControls;
using Microsoft.Practices.CompositeUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ServiceModel;
using System.Windows.Forms;
using sWorldModel.TransportData;
using JavaCommunication.Factory;
using System.Data;
namespace MemberMgtComponent.WorkItems.IntegratingExcel
{
    public partial class FrmIntegrateData : CommonControls.Custom.CommonDialog
    {
        #region Properties

        private BackgroundWorker bgwIntegrateData;
        private List<Member> MemberList;
        private List<Member> MemberErrorList;
        private int processedCount = 0;

        private MemberWorkItem workItem;
        [ServiceDependency]
        public MemberWorkItem WorkItem
        {
            set { workItem = value; }
        }

        private ILocalStorageService storageService;
        [ServiceDependency]
        public ILocalStorageService StorageService
        {
            set { storageService = value; }
        }

        #endregion

        #region Initialization

        public FrmIntegrateData(List<Member> memberList)
        {
            InitializeComponent();
            InitDataGridView();

            this.MemberList = memberList;
            bgwIntegrateData = new BackgroundWorker();
            bgwIntegrateData.WorkerSupportsCancellation = true;
            bgwIntegrateData.DoWork += bgwIntegrateData_DoWork;
            bgwIntegrateData.RunWorkerCompleted += bgwIntegrateData_Completed;
            btnCancel.Click += btnCancel_Click;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!bgwIntegrateData.IsBusy)
            {
                bgwIntegrateData.RunWorkerAsync();
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

        private void bgwIntegrateData_DoWork(object sender, DoWorkEventArgs e)
        {
            ChangeCurrentWork(string.Format("Đang tích hợp dữ liệu thành viên..."));

            int take = 100, skip = 0;
            List<Member> temp;
            MemberErrorList = new List<Member>();

            if (take > MemberList.Count)
            {
                take = MemberList.Count;
            }
            while (skip < MemberList.Count)
            {
                temp = MemberList.GetRange(skip, take);
                List<Member> result = new List<Member>();
                try
                {
                    result = OrganizationFactory.Instance.GetChannel().ImportMemberData(storageService.CurrentSessionId, temp);
                    MemberErrorList.AddRange(result);
                }
                catch (TimeoutException)
                {
                    MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.TimeOutExceptionMessage);
                }
                catch (FaultException<WcfServiceFault> ex)
                {
                    MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
                }
                catch (FaultException ex)
                {
                    MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.FaultExceptionMessage
                            + Environment.NewLine + Environment.NewLine
                            + ex.Message);
                }
                catch (CommunicationException)
                {
                    MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.CommunicationExceptionMessage);
                }

                processedCount += take;
                ChangeCurrentProgress();

                skip += take;
                take = Math.Min(take, MemberList.Count - skip);
            }
        }

        private void bgwIntegrateData_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                prgCurrent.Value = 0;
                lblCurrentWork.Text = "Quá trình tích hợp dữ liệu đã bị ngưng!";
                return;
            }
            if (MemberErrorList != null && MemberErrorList.Count > 0)
            {
                prgCurrent.Value = 0;
                lblCurrentWork.Text = string.Format("Đã cập nhập {0} thành viên vào hệ thống thành công!", MemberList.Count - MemberErrorList.Count);
                LoadDGVMemberErrorList(MemberErrorList);
            }
            else
            {
                prgCurrent.Value = 100;
                lblCurrentWork.Text = "Quá trình tích hợp dữ liệu đã hoàn tất!";
                btnCancel.Text = "Đóng";
            }
            
        }

        private void ChangeCurrentWork(string msg)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => { ChangeCurrentWork(msg); }));
                return;
            }
            lblCurrentWork.Text = msg;
        }

        private void ChangeCurrentProgress()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => { ChangeCurrentProgress(); }));
                return;
            }
            float percentage = ((float)processedCount / MemberList.Count) * 100;
            if (percentage > 100f)
            {
                percentage = 100f;
            }
            prgCurrent.Value = (int)percentage;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (bgwIntegrateData.IsBusy)
            {
                if (MessageBoxManager.ShowQuestionMessageBox(this, "Bạn có chắc muốn ngừng lại và đóng cửa sổ này không?") == DialogResult.Yes)
                {
                    this.Dispose();
                }
            }
            else
            {
                this.Dispose();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (bgwIntegrateData.IsBusy)
            {
                bgwIntegrateData.CancelAsync();
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

            dgvMemberErroList.Columns.Add(ColCode);
            dgvMemberErroList.Columns.Add(ColFirstName);
            dgvMemberErroList.Columns.Add(ColLastName);
            dgvMemberErroList.Columns.Add(ColBirthDate);
            dgvMemberErroList.Columns.Add(ColGender);
            dgvMemberErroList.Columns.Add(ColNationality);
            dgvMemberErroList.Columns.Add(ColCompanyname);
            dgvMemberErroList.Columns.Add(ColDegree);
            dgvMemberErroList.Columns.Add(ColPosition);
            dgvMemberErroList.Columns.Add(ColPhoneNo);
            dgvMemberErroList.Columns.Add(ColEmail);
            dgvMemberErroList.Columns.Add(ColTemporaryAddress);
            dgvMemberErroList.Columns.Add(ColPermanentAddress);
        }

        public void LoadDGVMemberErrorList(List<Member> memberList)
        {
            DataTable result = CreateMemberDataList();
            dgvMemberErroList.DataSource = result;
            int index = 0;
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

                dgvMemberErroList.Columns[index].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMemberErroList.Columns[index].SortMode = DataGridViewColumnSortMode.Automatic;
                index++;
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
