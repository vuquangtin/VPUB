using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using CommonControls.Custom;
using CommonControls;
using Microsoft.Practices.CompositeUI;
using System.ServiceModel;
using CommonHelper.Config;
//using WcfServiceCommon;
using sWorldModel.Exceptions;
using sWorldModel;
using sWorldModel.Filters;
//using sWorldCommunication;
using JavaCommunication.Factory;
using sWorldModel.TransportData;

namespace UserMgtComponent.WorkItems.UserAdding
{
    public partial class UsrMemberList : CommonUserControl, IUserAddingDialog
    {
        #region Properties

        private CommonDataGridView dgvTeacherList = new CommonDataGridView();
        private int currentPageIndex = -1;

        private DialogPostAction postAction = DialogPostAction.NONE;
        public DialogPostAction PostAction
        {
            get { return postAction; }
        }

        public Button AcceptButton
        {
            get { return btnNext; }
        }

        public Button CancelButton
        {
            get { return btnCancel; }
        }

        private long memberId;
        public object[] ReturnData
        {
            get { return new object[] { memberId }; }
        }

        public event EventHandler StepCompleted;

        private BackgroundWorker bgwLoadFaculty;
        private BackgroundWorker bgwTeacherLoading;
        private List<FacultyDepartmentDto> faculties;
        private DataTable dtbTeacherList;

        private WorkItem rootWorkItem;
        private ILocalStorageService storageService;

        [ServiceDependency]
        public WorkItem RootWorkItem
        {
            set { rootWorkItem = value; }
        }

        public ILocalStorageService StorageService
        {
            get
            {
                if (storageService == null)
                {
                    storageService = rootWorkItem.Services.Get<ILocalStorageService>();
                }
                return storageService;
            }
        }

        #endregion

        #region Initialization

        public UsrMemberList()
        {
            InitializeComponent();

            cmbFaculties.DisplayMember = "Name";
            cmbFaculties.ValueMember = "Id";

            cmbDepartments.DisplayMember = "Name";
            cmbDepartments.ValueMember = "Id";

            bgwLoadFaculty = new BackgroundWorker();
            bgwLoadFaculty.WorkerSupportsCancellation = true;
            bgwLoadFaculty.DoWork += bgwLoadFaculty_DoWork;
            bgwLoadFaculty.RunWorkerCompleted += bgwLoadFaculty_RunWorkerCompleted;

            bgwTeacherLoading = new BackgroundWorker();
            bgwTeacherLoading.WorkerSupportsCancellation = true;
            bgwTeacherLoading.DoWork += bgwLoadTeacher_DoWork;
            bgwTeacherLoading.RunWorkerCompleted += bgwLoadTeacher_RunWorkerCompleted;

            dtbTeacherList = new DataTable();
            dtbTeacherList.Columns.Add(colTeacherId.DataPropertyName);
            dtbTeacherList.Columns.Add(colTeacherCode.DataPropertyName);
            dtbTeacherList.Columns.Add(colLastName.DataPropertyName);
            dtbTeacherList.Columns.Add(colFirstName.DataPropertyName);
            dtbTeacherList.Columns.Add(colTitle.DataPropertyName);
            dtbTeacherList.Columns.Add(colPosition.DataPropertyName);
            dtbTeacherList.Columns.Add(colWorking.DataPropertyName);
            dgvTeacherList.DataSource = dtbTeacherList;

            pagerPanel1.LinkLabelClicked += pagerPanel1_LinkLabelClicked;
            cmbFaculties.SelectedIndexChanged += cbxFaculties_SelectedIndexChanged;
            cmbDepartments.SelectedIndexChanged += cbxDepartments_SelectedIndexChanged;
            this.Load += UcAddUserStep22_Load;
        }

        private void UcAddUserStep22_Load(object sender, EventArgs e)
        {
            LoadFaculties();
        }

        #endregion

        #region Load faculties/departments

        private void LoadFaculties()
        {
            cmbFaculties.Items.Clear();
            if (!bgwLoadFaculty.IsBusy)
            {
                bgwLoadFaculty.RunWorkerAsync();
            }
        }

        private void bgwLoadFaculty_DoWork(object sender, DoWorkEventArgs e)
        {
            List<FacultyDepartmentDto> result = null;
            string sessionId = StorageService.CurrentSessionId;
            FacultyFilterDto filter = new FacultyFilterDto();

            try
            {
                //result = ChipPersonalizationFactory.Instance.GetChannel().GetFacultyList(sessionId, filter);
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
            finally
            {
                e.Result = result;
            }
        }

        private void bgwLoadFaculty_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            faculties = (List<FacultyDepartmentDto>)e.Result;
            if (faculties != null)
            {
                faculties.Insert(0, new FacultyDepartmentDto
                {
                    Id = -1,
                    Name = "(Chọn khoa)",
                });
                cmbFaculties.DataSource = faculties;
                if (faculties.Count > 0)
                {
                    cmbFaculties.SelectedIndex = 0;
                }
            }
        }

        #endregion

        #region Load teachers

        private void LoadTeachers()
        {
            dtbTeacherList.Rows.Clear();
            if (!bgwTeacherLoading.IsBusy)
            {
                MemberFilter filter = new MemberFilter();
                if (cmbDepartments.SelectedIndex > 0)
                {
                    //filter.FilterByDepartment = true;
                    //filter.DepartmentId = Convert.ToInt64(cmbDepartments.SelectedValue);
                }
                else if (cmbFaculties.SelectedIndex > 0)
                {
                    //filter.FilterByFaculty = true;
                    //filter.FacultyId = Convert.ToInt64(cmbFaculties.SelectedValue);
                }
                pagerPanel1.ShowMessage("Đang tải dữ liệu, xin hãy chờ...");
                bgwTeacherLoading.RunWorkerAsync(filter);
            }
        }

        private void bgwLoadTeacher_DoWork(object sender, DoWorkEventArgs e)
        {
            List<MemberCustomerDTO> result = null;
            MemberFilter memberFilter = (MemberFilter)e.Argument;
            string sessionId = StorageService.CurrentSessionId;
            int totalRecords = 0;

            try
            {
                //result = ChipPersonalizationFactory.Instance.GetChannel().GetMemberList(sessionId,1,memberFilter);
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
            finally
            {
                pagerPanel1.ShowNumberOfRecords(totalRecords, result != null ? result.Count : 0, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
                pagerPanel1.UpdatePagingLinks(totalRecords, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
                e.Result = result;
            }
        }

        private void bgwLoadTeacher_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            List<MemberCustomerDTO> result = (List<MemberCustomerDTO>)e.Result;
            if (result != null)
            {
                foreach (MemberCustomerDTO r in result)
                {
                    DataRow row = dtbTeacherList.NewRow();
                    row.BeginEdit();

                    //row[colTeacherId.DataPropertyName] = r.Id;
                    //row[colTeacherCode.DataPropertyName] = r.Code;
                    //row[colLastName.DataPropertyName] = r.PersonalInfo.LastName;
                    //row[colFirstName.DataPropertyName] = r.PersonalInfo.FirstName;
                    //row[colTitle.DataPropertyName] = r.Title;
                    //row[colPosition.DataPropertyName] = r.Position;
                    //row[colWorking.DataPropertyName] = r.IsWorking.HasValue && r.IsWorking.Value ? LocalSettings.Instance.CheckSymbol : string.Empty;

                    row.EndEdit();
                    dtbTeacherList.Rows.Add(row);
                }
            }
        }

        #endregion

        #region Form events

        private void pagerPanel1_LinkLabelClicked(object sender, LinkLabelClickedArgs e)
        {
            int i;
            if (e.LabelText.Equals(PagerPanel.LabelBackText))
            {
                currentPageIndex -= 1;
            }
            else if (e.LabelText.Equals(PagerPanel.LabelNextText))
            {
                currentPageIndex += 1;
            }
            else if (int.TryParse(e.LabelText, out i))
            {
                currentPageIndex = i;
            }
            else
            {
                return;
            }
            LoadTeachers();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            postAction = DialogPostAction.BACK;
            if (StepCompleted != null)
            {
                StepCompleted(this, EventArgs.Empty);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            var selectedRows = dgvTeacherList.SelectedRows;
            if (selectedRows.Count == 0)
            {
                MessageBoxManager.ShowErrorMessageBox(this, "Bạn chưa chọn thành viên sẽ được cấp tài khoản!", "Thao Tác Sai");
                return;
            }
            if (selectedRows.Count == 1)
            {

                memberId = Convert.ToInt64(selectedRows[0].Cells["colTeacherId"].Value);
                postAction = DialogPostAction.NEXT;
                if (StepCompleted != null)
                {
                    StepCompleted(this, EventArgs.Empty);
                }
            }
            else
            {
                MessageBoxManager.ShowErrorMessageBox(this, "Vui lòng chỉ chọn một thành viên duy nhất!", "Thao Tác Sai");
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            postAction = DialogPostAction.CANCEL;
            if (StepCompleted != null)
            {
                StepCompleted(this, EventArgs.Empty);
            }
        }

        private void cbxFaculties_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (faculties == null)
            {
                return;
            }

            // Reload department list
            List<DepartmentDto> departments = new List<DepartmentDto>();
            departments.Add(new DepartmentDto
            {
                Id = -1,
                Name = "(Chọn bộ môn)",
            });
            if (cmbFaculties.SelectedIndex > 0)
            {
                long selectedValue = Convert.ToInt64(cmbFaculties.SelectedValue);
                departments.AddRange(faculties.Find(f => f.Id == selectedValue).ListOfDepartments);

                currentPageIndex = 1;
                LoadTeachers();
            }
            cmbDepartments.DataSource = departments;
            if (departments.Count > 0)
            {
                cmbDepartments.SelectedIndex = 0;
            }
        }

        private void cbxDepartments_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDepartments.SelectedIndex != 0)
            {
                currentPageIndex = 1;
                LoadTeachers();
            }
        }

        #endregion
    }
}