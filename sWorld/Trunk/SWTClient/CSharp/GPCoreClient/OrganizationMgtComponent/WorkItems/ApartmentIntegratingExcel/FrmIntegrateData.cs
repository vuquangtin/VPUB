using CommonControls;
using Microsoft.Practices.CompositeUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ServiceModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using sWorldModel.TransportData;
using sWorldModel;
using sWorldModel.Exceptions;
using sWorldCommunication.Interface;
using JavaCommunication.Factory;
using CommonHelper.Config;
using System.Resources;
using CommonHelper.Utils;
using CommonHelper.Constants;

namespace SystemMgtComponent.WorkItems.ApartmentIntegratingExcel
{
    public partial class FrmIntegrateData : CommonControls.Custom.CommonDialog
    {
        #region Properties

        private BackgroundWorker bgwIntegrateData;

        private int processedCount = 0;
        private int allTablesRowCount = 0;

        MasterInfoDTO masterInfo;
        private List<ManagerCostApartment> apartment;
        private List<ManagerCostApartment> lstReturn;
        //private List<ALL_BO_MON> departments;
        //private List<ALL_CBCNV> teachers;
        //private List<ALL_NGACH> scales;
        //private List<ALL_CHUC_VU> positions;

        private SystemWorkItem workItem;
        [ServiceDependency]
        public SystemWorkItem WorkItem
        {
            set { workItem = value; }
        }

        //private ILocalStorageService storageService;
        //[ServiceDependency]
        //public ILocalStorageService StorageService
        //{
        //    set { storageService = value; }
        //}

        private ILocalStorageService storageService;

        public ILocalStorageService StorageService
        {
            get
            {
                if (storageService == null)
                {
                    storageService = workItem.Services.Get<ILocalStorageService>();
                }
                return storageService;
            }
        }
        
        #endregion

        #region Initialization

        public FrmIntegrateData(List<ManagerCostApartment> apartment, ResourceManager rm)
        {
            InitializeComponent();
            this.rmNew = rm;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
            this.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.Name);

            this.apartment = apartment;
         

            bgwIntegrateData = new BackgroundWorker();
            bgwIntegrateData.WorkerSupportsCancellation = true;
            bgwIntegrateData.DoWork += bgwIntegrateData_DoWork;
            bgwIntegrateData.RunWorkerCompleted += bgwIntegrateData_Completed;

            btnCancel.Click += btnCancel_Click;
        }

      

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GetPartnerInfo();
            if (!bgwIntegrateData.IsBusy)
            {
                bgwIntegrateData.RunWorkerAsync();
            }
        }

        private const int WS_SYSMENU = 0x80000;
        private ResourceManager rmNew;

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
            allTablesRowCount = apartment.Count;

            // Positions
            if (!DoIntegrateTable(apartment))
            {
                e.Cancel = true;
                return;
            }  
            if (bgwIntegrateData.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

           
        }

        private bool DoIntegrateTable<T>(List<T> tableData)
        {
            if (tableData != null && tableData.Count > 0)
            {
                string tableName = ""; //typeof(T).Name;
                ChangeCurrentWork(string.Format(MessageValidate.GetMessage(rmNew, "Loadingdatas"), tableName));
                int take = 50, skip = 0;
                List<T> temp;
               
                if (take > tableData.Count)
                {
                    take = tableData.Count;
                }
                while (skip < tableData.Count)
                {
                    if (bgwIntegrateData.CancellationPending)
                    {
                        return false;
                    }

                    temp = tableData.GetRange(skip, take);

                    try
                    {
                        if (typeof(T) == typeof(ManagerCostApartment))
                        {
                            lstReturn = ManagerCostsFactory.Instance.GetChannel().InsertFileExcel(StorageService.CurrentSessionId, masterInfo.MasterId, temp as List<ManagerCostApartment>);
                        }
                        else
                        {
                            throw new NotSupportedException("Invalid integrating table type");
                        }
                    }
                    catch (TimeoutException)
                    {
                        MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rmNew, "TimeOutExceptionMessage"));
                        return false;
                    }
                    catch (FaultException<WcfServiceFault> ex)
                    {
                        MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
                        return false;
                    }
                    catch (FaultException ex)
                    {
                        MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rmNew, "FaultExceptionMessage")
                                + Environment.NewLine + Environment.NewLine
                                + ex.Message);
                        return false;
                    }
                    catch (CommunicationException)
                    {
                        MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rmNew, "CommunicationExceptionMessage"));
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
            btnCancel.Text = MessageValidate.GetMessage(rmNew, "statusClose");

            if (e.Cancelled)
            {
                lblCurrentWork.Text = MessageValidate.GetMessage(rmNew, "messageStopCollect");
                lblCurrentWork.ForeColor = Color.Red;
            }
            else
            {
                prgCurrent.Value = 100;
                lblCurrentWork.Text = MessageValidate.GetMessage(rmNew, "messageCompleteCollect");
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
            float percentage = ((float)processedCount / allTablesRowCount) * 100;
            if (percentage > 100f)
            {
                percentage = 100f;
            }
            prgCurrent.Value = (int)percentage;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (this.IsDisposed)
            {
                return;
            }
            if (bgwIntegrateData.IsBusy)
            {
                if (MessageBoxManager.ShowQuestionMessageBox(this, MessageValidate.GetMessage(rmNew, "messageStopClose")) == DialogResult.Yes)
                {
                    bgwIntegrateData.CancelAsync();
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

        private void GetPartnerInfo() 
        {
            try
            {
                this.masterInfo = OrganizationFactory.Instance.GetChannel().GetMasterInfo(StorageService.CurrentSessionId, SystemSettings.Instance.Partner);
            }
            catch (TimeoutException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rmNew, "TimeOutExceptionMessage"));
            }
            catch (FaultException<WcfServiceFault> ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
            }
            catch (FaultException ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rmNew, "FaultExceptionMessage")
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
            }
            catch (CommunicationException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rmNew, "CommunicationExceptionMessage"));
            }
        }

        #endregion
    }
}
