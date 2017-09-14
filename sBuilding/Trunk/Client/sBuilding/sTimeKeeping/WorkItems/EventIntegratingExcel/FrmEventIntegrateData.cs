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
using CommonHelper.Constants;
using System.Resources;
using CommonHelper.Utils;
using sTimeKeeping.Model;
using sTimeKeeping.Factory;

namespace sTimeKeeping.WorkItems.EventIntegratingExcel
{
    /// <summary>
    /// class FrmEventIntegrateData : CommonControls.Custom.CommonDialog
    /// </summary>
    public partial class FrmEventIntegrateData : CommonControls.Custom.CommonDialog
    {
        #region Properties

        // Properties
        private BackgroundWorker bgwIntegrateData;
        private List<EventImportObject> EventList;
        private List<EventImportObject> EventErrorList;
        private int processedCount = 0;
        private ResourceManager rm;

        // workItem && storageService
        private TimeKeepingComponentWorkItem workItem;
        [ServiceDependency]
        public TimeKeepingComponentWorkItem WorkItem
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

        /// <summary>
        /// contructor FrmEventIntegrateData
        /// </summary>
        /// <param name="eventList"></param>
        public FrmEventIntegrateData(List<EventImportObject> eventList)
        {
            // Init
            InitializeComponent();
            InitDataGridView();

            // gan gia tri
            this.EventList = eventList;

            // BackgroundWorker bgwIntegrateData
            bgwIntegrateData = new BackgroundWorker();
            bgwIntegrateData.WorkerSupportsCancellation = true;
            bgwIntegrateData.DoWork += bgwIntegrateData_DoWork;
            bgwIntegrateData.RunWorkerCompleted += bgwIntegrateData_Completed;

            // su kien
            btnCancel.Click += btnCancel_Click;
        }

        /// <summary>
        /// LoadLanguage
        /// </summary>
        private void LoadLanguage()
        {
            rm = storageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
        }

        /// <summary>
        /// override OnLoad of Form
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Run bgwIntegrateData
            if (!bgwIntegrateData.IsBusy)
            {
                bgwIntegrateData.RunWorkerAsync();
            }
        }

        private const int WS_SYSMENU = 0x80000;
        /// <summary>
        /// override CreateParams methods
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
            ChangeCurrentWork(string.Format("Đang tích hợp dữ liệu..."));

            // tao bien
            int take = 100, skip = 0;
            List<EventImportObject> temp;
            EventErrorList = new List<EventImportObject>();

            // gan gia tri cho take
            if (take > EventList.Count)
            {
                take = EventList.Count;
            }

            // vong lap import
            while (skip < EventList.Count)
            {
                // gan gia tri List<EventImportObject>
                temp = EventList.GetRange(skip, take);

                List<EventImportObject> result = new List<EventImportObject>();
                try
                {
                    // import
                    result = TimeKeepingEventFactory.Instance.GetChannel().importEventList(storageService.CurrentSessionId, temp);
                    EventErrorList.AddRange(result);
                }
                // Exception TimeoutException
                catch (TimeoutException)
                {
                    MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "TimeOutExceptionMessage"));
                }
                // Exception FaultException<WcfServiceFault>
                catch (FaultException<WcfServiceFault> ex)
                {
                    MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
                }
                // Exception FaultException
                catch (FaultException ex)
                {
                    MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "FaultExceptionMessage")
                            + Environment.NewLine + Environment.NewLine
                            + ex.Message);
                }
                // Exception CommunicationException
                catch (CommunicationException)
                {
                    MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "CommunicationExceptionMessage"));
                }
         
                processedCount += take;

                //ChangeCurrentProgress
                ChangeCurrentProgress();

                // gan take
                skip += take;
                take = Math.Min(take, EventList.Count - skip);
            }
        }

        /// <summary>
        /// bgwIntegrateData_Completed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwIntegrateData_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            // kiem tra e.Cancelled
            if (e.Cancelled)
            {
                prgCurrent.Value = 0;
                lblCurrentWork.Text = "Quá trình tích hợp dữ liệu đã bị ngưng!";
                return;
            }

            // kiem tra EventErrorList != null && EventErrorList.Count > 0
            if (EventErrorList != null && EventErrorList.Count > 0)
            {
                prgCurrent.Value = 0;
                lblCurrentWork.Text = string.Format("Đã cập nhập {0} thành viên vào hệ thống thành công!", EventList.Count - EventErrorList.Count);
                LoadDGVEventErrorList(EventErrorList);
            }
            else
            {
                // EventErrorList == null || EventErrorList.Count == 0
                prgCurrent.Value = 100;
                lblCurrentWork.Text = "Quá trình tích hợp dữ liệu đã hoàn tất!";
                btnCancel.Text = "Đóng";
            }

        }

        /// <summary>
        /// ChangeCurrentWork
        /// </summary>
        /// <param name="msg"></param>
        private void ChangeCurrentWork(string msg)
        {
            // Invoke 
            if (InvokeRequired)
            {
                Invoke(new Action(() => { ChangeCurrentWork(msg); }));
                return;
            }

            // gan lblCurrentWork.Text = msg
            lblCurrentWork.Text = msg;
        }

        /// <summary>
        /// ChangeCurrentProgress
        /// </summary>
        private void ChangeCurrentProgress()
        {
            // Invoke
            if (InvokeRequired)
            {
                Invoke(new Action(() => { ChangeCurrentProgress(); }));
                return;
            }

            // tinh toan percentage
            float percentage = ((float)processedCount / EventList.Count) * 100;
            if (percentage > 100f)
            {
                percentage = 100f;
            }

            // gan gia tri cho prgCurrent.Value 
            prgCurrent.Value = (int)percentage;
        }

        /// <summary>
        /// btnCancel_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// OnFormClosing
        /// </summary>
        /// <param name="e"></param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // cancel bgwIntegrateData
            if (bgwIntegrateData.IsBusy)
            {
                bgwIntegrateData.CancelAsync();
            }
        }

        #endregion

        #region InitializationDataGridView

        // khai bao column
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
            // DataGridViewTextBoxColumn col
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            col.DataPropertyName = dataPropertyName;
            col.HeaderText = headerName;
            col.Name = string.Format("col{0}", dataPropertyName);
            col.ReadOnly = isReadOnly;
            col.Width = wight;
            return col;
        }

        /// <summary>
        /// InitDataGridView
        /// </summary>
        public void InitDataGridView()
        {
            // CreateColunm
            ColMemberCode = CreateColunm("MemberCode", "Mã Chuyên viên", 60);
            ColMemberName = CreateColunm("MemberName", "Họ và tên", 225);
            ColSubOrg = CreateColunm("SubOrg", "Phòng ban", 120);
            ColEventName = CreateColunm("EventName", "Tên sự kiện", 250);
            ColDate = CreateColunm("Date", "Ngày", 100);
            ColHourBegin = CreateColunm("HourBegin", "Thời gian bắt đầu", 80);
            ColHourKeeping = CreateColunm("HourKeeping", "Thời gian", 100);
            ColDescription = CreateColunm("Description", "Mô tả", 250);

            // Add Columns
            dgvMemberErroList.Columns.Add(ColMemberCode);
            dgvMemberErroList.Columns.Add(ColMemberName);
            dgvMemberErroList.Columns.Add(ColSubOrg);
            dgvMemberErroList.Columns.Add(ColEventName);
            dgvMemberErroList.Columns.Add(ColDate);
            dgvMemberErroList.Columns.Add(ColHourBegin);
            dgvMemberErroList.Columns.Add(ColHourKeeping);
            dgvMemberErroList.Columns.Add(ColDescription);
        }

        /// <summary>
        /// LoadDGVEventErrorList
        /// </summary>
        /// <param name="memberList"></param>
        public void LoadDGVEventErrorList(List<EventImportObject> eventList)
        {
            // create DataTable
            DataTable result = CreateMemberDataList();
            dgvMemberErroList.DataSource = result;
            int index = 0;

            // duyet 
            foreach (EventImportObject eventrCus in eventList)
            {
                // new row
                DataRow row = result.NewRow();
                row.BeginEdit();

                // set cho new row
                row[ColMemberCode.DataPropertyName] = eventrCus.MemberCode;
                row[ColMemberName.DataPropertyName] = eventrCus.MemberName;
                row[ColEventName.DataPropertyName] = eventrCus.EventName;
                row[ColDate.DataPropertyName] = eventrCus.Date;
                row[ColHourBegin.DataPropertyName] = eventrCus.HourBegin;
                row[ColHourKeeping.DataPropertyName] = eventrCus.HourKeeping;
                row[ColDescription.DataPropertyName] = eventrCus.Description;

                row.EndEdit();

                // add
                result.Rows.Add(row);
                
                dgvMemberErroList.Columns[index].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMemberErroList.Columns[index].SortMode = DataGridViewColumnSortMode.Automatic;
                index++;
            }
        }

        /// <summary>
        /// CreateMemberDataList
        /// </summary>
        /// <returns></returns>
        public DataTable CreateMemberDataList()
        {
            // new data table
            DataTable dbMemberList = new DataTable();

            // add for new datatable
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
