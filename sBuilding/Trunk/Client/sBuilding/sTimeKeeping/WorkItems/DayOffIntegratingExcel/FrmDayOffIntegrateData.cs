using CommonControls;
using CommonHelper.Constants;
using CommonHelper.Utils;
using Microsoft.Practices.CompositeUI;
using sBuildingCommunication.Factory;
using sTimeKeeping.Factory;
using sTimeKeeping.Model;
using sWorldModel;
using sWorldModel.Exceptions;
using sWorldModel.TransportData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;

namespace sTimeKeeping.WorkItems.DayOffIntegratingExcel
{
    /// <summary>
    /// class FrmDayOffIntegrateData : CommonControls.Custom.CommonDialog
    /// </summary>
    public partial class FrmDayOffIntegrateData : CommonControls.Custom.CommonDialog
    {
        #region Properties

        // const NGHI_PHEP_CA_NGAY
        private const int NGHI_PHEP_CA_NGAY = 1;

        // BackgroundWorker
        private BackgroundWorker bgwIntegrateData;

        // tao danh sach SubOrgCustomerDTO
        private List<DayOffImportObject> DayOffList;
        private List<DayOffImportObject> DayOffErrorList;

        // processedCount
        private int processedCount = 0;

        // ResourceManager
        private ResourceManager rm;

        // TimeKeepingComponentWorkItem
        private TimeKeepingComponentWorkItem workItem;
        [ServiceDependency]
        public TimeKeepingComponentWorkItem WorkItem
        {
            set { workItem = value; }
        }

        // storageService
        private ILocalStorageService storageService;
        [ServiceDependency]
        public ILocalStorageService StorageService
        {
            set { storageService = value; }
        }

        #endregion

        #region Initialization

        /// <summary>
        /// contructor FrmDayOffIntegrateData
        /// </summary>
        /// <param name="eventList"></param>
        public FrmDayOffIntegrateData(List<DayOffImportObject> DayOffList)
        {
            // init
            InitializeComponent();
            InitDataGridView();

            // gan EventList
            this.DayOffList = DayOffList;

            // BackgroundWorker bgwIntegrateData
            bgwIntegrateData = new BackgroundWorker();
            bgwIntegrateData.WorkerSupportsCancellation = true;
            bgwIntegrateData.DoWork += bgwIntegrateData_DoWork;
            bgwIntegrateData.RunWorkerCompleted += bgwIntegrateData_Completed;

            // su kien btnCancel.Click
            btnCancel.Click += btnCancel_Click;
        }

        /// <summary>
        ///  LoadLanguage
        /// </summary>
        private void LoadLanguage()
        {
            rm = storageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
        }

        /// <summary>
        /// override OnLoad off Form
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // run bgwIntegrateData
            if (!bgwIntegrateData.IsBusy)
            {
                bgwIntegrateData.RunWorkerAsync();
            }
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
        /// bgwIntegrateData_DoWork
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwIntegrateData_DoWork(object sender, DoWorkEventArgs e)
        {
            // change ChangeCurrentWork
            ChangeCurrentWork(string.Format("Đang tích hợp dữ liệu..."));

            // create take
            int take = 100, skip = 0;

            // List<SubOrgCustomerDTO> temp
            List<DayOffImportObject> temp;

            //  EventErrorList = new List<SubOrgCustomerDTO>
            DayOffErrorList = new List<DayOffImportObject>();

            // kiem tra take > DayOffList.Count
            if (take > DayOffList.Count)
            {
                take = DayOffList.Count;
            }

            if (DayOffList != null && DayOffList.Count > 0)
            {
                Member member = LoadMember(DayOffList[0].OrgId, DayOffList[0].MemberCode.Trim());
                if (member.SubOrgId != DayOffList[0].SubOrgId)
                {
                    MessageBoxManager.ShowInfoMessageBox(this, "Bạn chọn sai phòng để tích hợp dữ liệu");
                    
                }
                else
                {
                    // importDayOffList
                    while (skip < DayOffList.Count)
                    {
                        // tao temp
                        temp = DayOffList.GetRange(skip, take);

                        // tao List<DayOffImportObject> result
                        List<DayOffImportObject> result = new List<DayOffImportObject>();
                        try
                        {
                            // importDayOffList
                            result = TimeKeepingDayOffConfigFactory.Instance.GetChannel().importDayOffList(storageService.CurrentSessionId, temp);
                            DayOffErrorList.AddRange(result);
                        }
                        catch (TimeoutException)
                        {
                            MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "TimeOutExceptionMessage"));
                        }
                        catch (FaultException<WcfServiceFault> ex)
                        {
                            MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
                        }
                        catch (FaultException ex)
                        {
                            MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "FaultExceptionMessage")
                                    + Environment.NewLine + Environment.NewLine
                                    + ex.Message);
                        }
                        catch (CommunicationException)
                        {
                            MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "CommunicationExceptionMessage"));
                        }
                        // gan lai processedCount
                        processedCount += take;

                        // ChangeCurrentProgress
                        ChangeCurrentProgress();

                        // tang skip
                        skip += take;

                        // gan lai take
                        take = Math.Min(take, DayOffList.Count - skip);
                    }
                }
            }
        }


        /// <summary>
        /// bgwIntegrateData_Completed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwIntegrateData_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled || e.Result == null)
            {
                prgCurrent.Value = 0;
                lblCurrentWork.Text = "Quá trình tích hợp dữ liệu đã bị ngưng!";
                return;
            }
            if (DayOffErrorList != null && DayOffErrorList.Count > 0)
            {
                prgCurrent.Value = 0;
                lblCurrentWork.Text = string.Format("Đã cập nhập {0} thành viên vào hệ thống thành công!", DayOffList.Count - DayOffErrorList.Count);
                LoadDGVDayOffList(DayOffErrorList);
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
            float percentage = ((float)processedCount / DayOffList.Count) * 100;
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
                    this.Close();
                }
            }
            else
            {
                this.Close();
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

        private DataGridViewTextBoxColumn ColMemberCode { get; set; }
        private DataGridViewTextBoxColumn ColMemberName { get; set; }
        private DataGridViewTextBoxColumn ColSubOrg { get; set; }
        private DataGridViewTextBoxColumn ColDate { get; set; }
        private DataGridViewTextBoxColumn ColTypeDayOff { get; set; }
        private DataGridViewTextBoxColumn ColNote { get; set; }
        /// <summary>
        ///  Create Colunm
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

            dgvRecord.Columns.Add(ColMemberCode);
            dgvRecord.Columns.Add(ColMemberName);
            dgvRecord.Columns.Add(ColSubOrg);
            dgvRecord.Columns.Add(ColDate);
            dgvRecord.Columns.Add(ColTypeDayOff);
            dgvRecord.Columns.Add(ColNote);
        }
        /// <summary>
        /// Load DGV DayOff List
        /// </summary>
        /// <param name="dayOffList"></param>
        public void LoadDGVDayOffList(List<DayOffImportObject> dayOffList)
        {
            DataTable result = CreateDayOffDataList();
            dgvRecord.DataSource = result;
            int index = 0;

            // duyet tren dayOff List gan vao DGV
            foreach (DayOffImportObject dayOff in dayOffList)
            {
                DataRow row = result.NewRow();
                row.BeginEdit();

                row[ColMemberCode.DataPropertyName] = dayOff.MemberCode;
                row[ColMemberName.DataPropertyName] = dayOff.MemberName;
                row[ColDate.DataPropertyName] = dayOff.DateOff;
                row[ColTypeDayOff.DataPropertyName] = dayOff.TypeDayOff == NGHI_PHEP_CA_NGAY ? "Nghỉ phép cả ngày" : "Nghỉ phép nnuawr ngày";
                row[ColNote.DataPropertyName] = dayOff.Note;

                row.EndEdit();
                result.Rows.Add(row);

                dgvRecord.Columns[index].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvRecord.Columns[index].SortMode = DataGridViewColumnSortMode.Automatic;
                index++;
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


        #region member
        /// <summary>
        /// load member dua vao member code
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        private Member LoadMember(long orgId, string memberCode)
        {
            Member member = new Member();
            try
            {
                // GetMemberById 
                member = OrganizationFactory.Instance.GetChannel().GetMemberByCode(storageService.CurrentSessionId, orgId, memberCode);

            }
            catch (TimeoutException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "TimeOutExceptionMessage"));
                this.Hide();
            }
            catch (FaultException<WcfServiceFault> ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
                this.Hide();
            }
            catch (FaultException ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "FaultExceptionMessage")
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
                this.Hide();
            }
            catch (CommunicationException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "CommunicationExceptionMessage"));
                this.Hide();
            }
            return member;
        }
        #endregion
    }
}
