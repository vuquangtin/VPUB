using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using CommonControls;
using System.Drawing;
using System.Linq;
using System.Text;
using Microsoft.Practices.CompositeUI;
using sWorldModel;
using System.ServiceModel;
using sWorldModel.Exceptions;
using System.Resources;
using CommonHelper.Utils;
using CommonHelper.Constants;
using System.Windows.Forms;
using JavaCommunication.Factory;
using sWorldModel.TransportData;
using ClientModel.Utils;
using ClientModel.Model;
using sExcelExportComponent.ClientModel.Enums;

namespace SystemMgtComponent.WorkItems.ExportDataCard
{
    public partial class FrmExportDataCard : Form
    {
        private ResourceManager rm;
        private DataTable dtbCardData;
        private BackgroundWorker bgwLoadListCard;
        private ILocalStorageService storageService;
        [ServiceDependency]
        public ILocalStorageService StorageService
        {
            get { return storageService; }
            set { storageService = value; }
        }
        public FrmExportDataCard(long a, bool b)
        {
            InitializeComponent();
            InitDataGridView();
            RegisterEvent();
        }
        private void RegisterEvent()
        {
            bgwLoadListCard = new BackgroundWorker();
            bgwLoadListCard.WorkerSupportsCancellation = true;
            bgwLoadListCard.DoWork += OnLoadCardWorkerDoWork;
            bgwLoadListCard.RunWorkerCompleted += OnLoadCardRunWorkerCompleted;
            btnExit.Click += OnButtonCancelClicked;
            btnExport.Click += OnButtonExportClicked;
            Shown += OnFormShown;
        }
        private void OnFormShown(object sender, EventArgs e)
        {
            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
            this.Text = MessageValidate.GetMessage(rm, this.Name);
            LoadListCard();
        }
        private void LoadListCard()
        {
            if (!bgwLoadListCard.IsBusy)
            {
                dtbCardData.Rows.Clear();
                bgwLoadListCard.RunWorkerAsync();
            }
        }
        private void OnLoadCardWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = CardChipFactory.Instance.GetChannel().GetCardChipListExport(StorageService.CurrentSessionId);
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

        private void OnLoadCardRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if (e.Result != null)
            {
                List<CardChipDto> lstCardChip = (List<CardChipDto>)e.Result;
                LoadDataForDataGidView(lstCardChip);

            }
        }
        private void InitDataGridView()
        {
            dtbCardData = new DataTable();
            dtbCardData.Columns.Add(OrgmasterId.DataPropertyName);
            dtbCardData.Columns.Add(orgmastercode.DataPropertyName);
            dtbCardData.Columns.Add(physycalStatus.DataPropertyName);
            dtbCardData.Columns.Add(serial.DataPropertyName);
            dtbCardData.Columns.Add(CardType.DataPropertyName);
            dtbCardData.Columns.Add(Typecript.DataPropertyName);
            dtbCardData.Columns.Add(headerPosition.DataPropertyName);
            dtbCardData.Columns.Add(LicenseMaster.DataPropertyName);
            dgvCardData.DataSource = dtbCardData;
        }

        public void LoadDataForDataGidView(List<CardChipDto> lstCardChip)
        {
            foreach (CardChipDto cardChipDto in lstCardChip)
            {
                DataRow row = dtbCardData.NewRow();
                row.BeginEdit();

                row[OrgmasterId.DataPropertyName] = cardChipDto.OrgMasterId;
                row[orgmastercode.DataPropertyName] = cardChipDto.OrgMasterCode;
                row[physycalStatus.DataPropertyName] = cardChipDto.PhysicalStatus;
                row[serial.DataPropertyName] = cardChipDto.SerialNumberHex;
                row[CardType.DataPropertyName] = cardChipDto.TypeCard;
                row[Typecript.DataPropertyName] = cardChipDto.TypeCrypto;
                row[headerPosition.DataPropertyName] = cardChipDto.headerposision;
                row[LicenseMaster.DataPropertyName] = cardChipDto.licensemaster;

                row.EndEdit();
                dtbCardData.Rows.Add(row);
            }
        }
        public void OnButtonCancelClicked(object sender, EventArgs e)
        {
            this.Hide();
        }
        public void OnButtonExportClicked(object sender, EventArgs e)
        {
            string filePath = ControlExtMethods.ShowSaveFileDialog(MessageValidate.GetMessage(rm, "smsChooseFileExport"), "Danh sach the ", CategorizeExcel.Categorize);
            if (filePath != null)
            {
                try
                {
                    //set đường dẫn lưu file 
                    ConfigExportFileModel configExportFile = new ConfigExportFileModel();
                    configExportFile.FilePath = filePath;
                    //bỏ data với đường dẫn vào file excel
                    //13 là số dòng bắt đầu xuất hiện của bảng data
                    GemboxUtils.Instance.ExportDataGridToFileCustom(dgvCardData, configExportFile, 3);//tua de, xuat file 
                    GemboxUtils.Instance.AutoFix();
                    //import data vào file excel

                    int countExport = Convert.ToInt32(tbxNumberCard.Value);

                    GemboxUtils.Instance.ExportDataGridToFile(countExport);//so luong dong du lieu can xuat

                    //export general information
                    GemboxUtils.Instance.AddHeader(MessageValidate.GetMessage(rm, "lstCardExport"));
                    try
                    {
                        GemboxUtils.Instance.Save();
                    }
                    catch (IOException x)
                    {
                        MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "fileExcelOpen"));
                    }
                    //end
                }
                catch (Exception ex)
                {
                    MessageBoxManager.ShowErrorMessageBox(this, ex.Message);
                    return;
                }
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "smsLinkFile") + filePath);
                this.Hide();
            }
        }
    }
}
