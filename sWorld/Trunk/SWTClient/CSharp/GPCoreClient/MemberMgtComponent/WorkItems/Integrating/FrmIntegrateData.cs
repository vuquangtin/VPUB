using CommonControls;
using CommonControls.Custom;
using Microsoft.Practices.CompositeUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;
using MemberMgtComponent.Constants;
//using WcfServiceCommon;
using sWorldModel.Integrating;
using sWorldModel;
using sWorldModel.Exceptions;
using JavaCommunication.Factory;

namespace MemberMgtComponent.WorkItems.Integrating
{
    public partial class FrmIntegrateData : CommonControls.Custom.CommonDialog
    {
        #region Properties

        private BackgroundWorker bgwIntegrateData;

        private int processedCount = 0;
        private int allTablesRowCount = 0;

        private List<ALL_KHOA> faculties;
        private List<ALL_BO_MON> departments;
        private List<ALL_CBCNV> teachers;
        private List<ALL_NGACH> scales;
        private List<ALL_CHUC_VU> positions;

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

        public FrmIntegrateData(List<ALL_BO_MON> departments, List<ALL_KHOA> faculties, List<ALL_CBCNV> teachers, List<ALL_CHUC_VU> positions, List<ALL_NGACH> scales)
        {
            InitializeComponent();

            this.faculties = faculties;
            this.departments = departments;
            this.teachers = teachers;
            this.scales = scales;
            this.positions = positions;

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
            allTablesRowCount = faculties.Count + departments.Count + teachers.Count + scales.Count + positions.Count;

            // Positions
            if (!DoIntegrateTable(positions))
            {
                e.Cancel = true;
                return;
            }
            if (bgwIntegrateData.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            // Scales
            if (!DoIntegrateTable(scales))
            {
                e.Cancel = true;
                return;
            }
            if (bgwIntegrateData.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            // Faculties
            if (!DoIntegrateTable(faculties))
            {
                e.Cancel = true;
                return;
            }
            if (bgwIntegrateData.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            // Departments
            if (!DoIntegrateTable(departments))
            {
                e.Cancel = true;
                return;
            }
            if (bgwIntegrateData.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            // Teachers
            if (!DoIntegrateTable(teachers))
            {
                e.Cancel = true;
                return;
            }
        }

        private bool DoIntegrateTable<T>(List<T> tableData)
        {
            if (tableData != null && tableData.Count > 0)
            {
                string tableName = typeof(T).Name;
                ChangeCurrentWork(string.Format("Đang tích hợp dữ liệu {0}...", tableName));
                int take = 100, skip = 0;
                List<T> temp;

                if (take > tableData.Count)
                {
                    take = tableData.Count;
                }
                while (skip < tableData.Count)
                {
                    temp = tableData.GetRange(skip, take);

                    try
                    {
                        if (typeof(T) == typeof(ALL_BO_MON))
                        {
                            IntegratingFactory.Instance.GetChannel().IntegrateDepartments(storageService.CurrentSessionId, temp as List<ALL_BO_MON>);
                        }
                        else if (typeof(T) == typeof(ALL_KHOA))
                        {
                            IntegratingFactory.Instance.GetChannel().IntegrateFaculties(storageService.CurrentSessionId, temp as List<ALL_KHOA>);
                        }
                        else if (typeof(T) == typeof(ALL_CBCNV))
                        {
                            IntegratingFactory.Instance.GetChannel().IntegrateTeachers(storageService.CurrentSessionId, temp as List<ALL_CBCNV>);
                        }
                        else if (typeof(T) == typeof(ALL_CHUC_VU))
                        {
                            IntegratingFactory.Instance.GetChannel().IntegratePositions(storageService.CurrentSessionId, temp as List<ALL_CHUC_VU>);
                        }
                        else if (typeof(T) == typeof(ALL_NGACH))
                        {
                            IntegratingFactory.Instance.GetChannel().IntegrateScales(storageService.CurrentSessionId, temp as List<ALL_NGACH>);
                        }
                        else
                        {
                            throw new NotSupportedException("Invalid integrating table type");
                        }
                    }
                    catch (TimeoutException)
                    {
                        MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.TimeOutExceptionMessage);
                        return false;
                    }
                    catch (FaultException<WcfServiceFault> ex)
                    {
                        MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
                        return false;
                    }
                    catch (FaultException ex)
                    {
                        MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.FaultExceptionMessage
                                + Environment.NewLine + Environment.NewLine
                                + ex.Message);
                        return false;
                    }
                    catch (CommunicationException)
                    {
                        MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.CommunicationExceptionMessage);
                        return false;
                    }

                    processedCount += take;
                    ChangeCurrentProgress();

                    skip += take;
                    take = Math.Min(take, tableData.Count - skip);
                }
            }
            return true;
        }

        private void bgwIntegrateData_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                prgCurrent.Value = 0;
                lblCurrentWork.Text = "Quá trình tích hợp dữ liệu đã bị ngưng!";
                return;
            }

            prgCurrent.Value = 100;
            lblCurrentWork.Text = "Quá trình tích hợp dữ liệu đã hoàn tất!";
            btnCancel.Text = "Đóng";
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
            float percentage = ((float)processedCount / allTablesRowCount) * 100;
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
    }
}
