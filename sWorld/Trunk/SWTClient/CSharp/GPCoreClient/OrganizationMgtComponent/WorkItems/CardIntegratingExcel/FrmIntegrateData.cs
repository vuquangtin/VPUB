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
using JavaCommunication;

namespace SystemMgtComponent.WorkItems.CardIntegratingExcel
{
    public partial class FrmIntegrateData : CommonControls.Custom.CommonDialog
    {

        private BackgroundWorker bgwIntegrateData;
        List<CardChipDto> cardChipDto;
        public ResourceManager rm;
        private int processedCount = 0;
        private int allTablesRowCount = 0;

        private SystemWorkItem workItem;
        [ServiceDependency]
        public SystemWorkItem WorkItem
        {
            set { workItem = value; }
        }

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

        public FrmIntegrateData(List<CardChipDto> cardChipDto)
        {
            InitializeComponent();
            this.cardChipDto = cardChipDto;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
            this.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.Name);

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


        private void bgwIntegrateData_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result =(int)Status.SUCCESS == CardChipFactory.Instance.GetChannel().ImportListCard(StorageService.CurrentSessionId, StorageService.CurrentUserName, cardChipDto);
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

        }

       
        private void bgwIntegrateData_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                lblCurrentWork.Text = MessageValidate.GetMessage(rmNew, "messageStopCollect");
            }
            if((bool)e.Result)
            {
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "importExcelSuccess"));
                this.Hide();
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

    }
}