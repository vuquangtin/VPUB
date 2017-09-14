using ClientModel.Model;
using ClientModel.Utils;
using ClientModel.Controls.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sExcelExportComponent.WorkItems
{
    public partial class FrmExportDtToFile : Form
    {
        #region Private Properties

        private ConfigExportFileModel configExportFile = null;
        private DataTable dtSoucre = null;
        private CommonDataGridView dgvSoucre = null;
        private BackgroundWorker bgwLoadData;
        private BackgroundWorker bgwExportData;
        private int processedCount = 0;
        //private MonthlyPassFilterDto monthlyPassFilter = null;
        // private int recordsPerPage = LocalConfigsManager.Instance.RecordsPerPages;
        private int maxRow = 0;
        private string number = "STT";

        #endregion

        #region Public Constructor

        /// public FrmExportDtToFile(ConfigExportFileModel configExportFile, CommonDataGridView dgvSoucre, MonthlyPassFilterDto monthlyPassFilter)
        public FrmExportDtToFile(ConfigExportFileModel configExportFile, CommonDataGridView dgvSoucre)
        {
            InitializeComponent();

            this.configExportFile = configExportFile;
            this.dgvSoucre = dgvSoucre;
            //this.monthlyPassFilter = monthlyPassFilter;

            btnOpenFile.Click += btnOpenFile_Click;

            bgwLoadData = new BackgroundWorker();
            bgwLoadData.WorkerSupportsCancellation = true;
            bgwLoadData.DoWork += bgwLoadData_DoWork;
            bgwLoadData.RunWorkerCompleted += bgwLoadData_Completed;

            bgwExportData = new BackgroundWorker();
            bgwExportData.WorkerSupportsCancellation = true;
            bgwExportData.DoWork += bgwExportData_DoWork;
            bgwExportData.RunWorkerCompleted += bgwExportData_Completed;
        }

        #endregion

        #region Public Methods



        #endregion

        #region UI Component Events

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SetFormType();

            if (!bgwLoadData.IsBusy)
            {
                bgwLoadData.RunWorkerAsync();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (bgwExportData.IsBusy)
            {
                //if (MessageBoxUtils.ShowConfirmMessage("Bạn có chắc muốn ngừng lại và đóng cửa sổ này không?") == DialogResult.Yes)
                //{
                //    bgwExportData.CancelAsync();
                //}
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.KeyCode == Keys.Escape)
            {
                if (this.IsDisposed)
                {
                    return;
                }
                if (bgwExportData.IsBusy)
                {
                    //if (MessageBoxUtils.ShowConfirmMessage("Bạn có chắc muốn ngừng lại và đóng cửa sổ này không?") == DialogResult.Yes)
                    //{
                    //    bgwExportData.CancelAsync();
                    //    this.Dispose();
                    //}
                }
                else
                {
                    this.Dispose();
                }
            }
        }

        private void bgwLoadData_DoWork(object sender, DoWorkEventArgs e)
        {
            //try
            //{
            //    maxRow = ParkingProxy.CreateProxy().CountMonthlyPassesThatMatch(StorageService.AdminSession.Id, monthlyPassFilter);
            //}
            //catch (ParkingException ex)
            //{
            //    Invoke(new Action(() => MessageBoxUtils.ShowErrorMessage(this, ex.GetErrorMessage(true))));
            //    return;
            //}
        }

        private void bgwLoadData_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!bgwExportData.IsBusy)
            {
                lblCurrentWork.Text = "Đang xuất dữ liệu. Vui lòng chờ đợi...";
                bgwExportData.RunWorkerAsync();
            }
        }

        private void bgwExportData_DoWork(object sender, DoWorkEventArgs e)
        {
            dtSoucre = InitDtMonthlyPass();
            //  List<MonthlyPassForGridDisplayDto> result = new List<MonthlyPassForGridDisplayDto>();
            do
            {
                dtSoucre.Rows.Clear();
                // etown xóa các cột không cần
                dtSoucre.Columns.Clear();
                dtSoucre.Columns.Add("STT");
                dtSoucre.Columns.Add("Họ");
                dtSoucre.Columns.Add("Tên");
                dtSoucre.Columns.Add("Phòng ban");
                dtSoucre.Columns.Add("Loại xe");
                dtSoucre.Columns.Add("Loại đăng ký");
                dtSoucre.Columns.Add("Thời gian");
                dtSoucre.Columns.Add("Biển số xe");
                dtSoucre.Columns.Add("Hiệu xe");
                dtSoucre.Columns.Add("Màu sơn");

                if (bgwExportData.CancellationPending)
                {
                    return;
                }
                //try
                //{
                //    long maxMonthlyPassId = result.Count == 0 ? 0 : result.Max(mp => mp.Id) + 1;
                //    //result = ParkingProxy.CreateProxy().GetMonthlyPassList(StorageService.AdminSession.Id, (byte)PagingType.Next, monthlyPassFilter, recordsPerPage + 1, maxMonthlyPassId);
                //    result = ParkingProxy.CreateProxy().GetMonthlyPassList(StorageService.AdminSession.Id, (byte)PagingType.Next, monthlyPassFilter, maxRow, 0);

                //}
                //catch (ParkingException ex)
                //{
                //    Invoke(new Action(() => MessageBoxUtils.ShowErrorMessage(this, ex.GetErrorMessage(true))));
                //    return;
                //}
                // int rowIndex = 1;
                //htmynguyen dòng dữ liệu cần xuất
                //add từng dòng dữ liệu
                //foreach (MonthlyPassForGridDisplayDto mp in result)
                //{
                //    DataRow drow = dtSoucre.NewRow();

                //    drow[number] = rowIndex;
                //    //drow[dgvSoucre.Columns[0].HeaderText] = mp.Id;
                //    //drow[dgvSoucre.Columns[1].HeaderText] = mp.OrganizationName;
                //    drow["Họ"] = mp.CustomerLastName;
                //    drow["Tên"] = mp.CustomerFirstName;
                //    drow["Phòng ban"] = mp.PhongBan;
                //    //drow["Loại xe"] = ((VehicleType)mp.VehicleType).GetName();
                //    //if (((ParkingTimeType)mp.ParkingTimeType).GetName().Equals("Toàn thời gian"))
                //    //{
                //    //    drow["Loại đăng ký"] = "24 giờ/ngày";
                //    //    drow["Thời gian"] = "";
                //    //}
                //    //else
                //    //{
                //    //    drow["Loại đăng ký"] = "12 giờ/ngày";
                //    //    //if (((ParkingTimeType)mp.ParkingTimeType).GetName().Equals("Giờ hành chính"))
                //    //    //{
                //    //    //    drow["Thời gian"] = "6h đến 19h";
                //    //    //}
                //    //    //else
                //    //    //{
                //    //    //    drow["Thời gian"] = "19h đến 6h";
                //    //    //}
                //    //}

                ////drow["Biển số xe"] = VehicleNumberUtils.FormatNumberForDisplay(mp.VehicleType, mp.VehicleNumber);


                ////drow[dgvSoucre.Columns[6].HeaderText] = mp.CardNumber;
                //    // mota = hieu xe + mau son
                //    string vehicleDescription = mp.VehicleDescription;
                //    string mauSon = "";
                //    string hieuXe = "";
                //    try
                //    {
                //        mauSon = vehicleDescription.Substring(vehicleDescription.LastIndexOf(" ")).Trim();
                //        hieuXe = vehicleDescription.Replace(mauSon, "").Trim();
                //    }
                //    catch (Exception ex)
                //    {
                //        hieuXe = vehicleDescription;
                //    }

                //    drow["Màu sơn"] = mauSon;
                //    drow["Hiệu xe"] = hieuXe;
                //    //drow[dgvSoucre.Columns[9].HeaderText] = ((ParkingTimeType)mp.ParkingTimeType).GetName();
                //    //drow[dgvSoucre.Columns[9].HeaderText] = mp.IsFree ? "*" : string.Empty;
                //    //drow[dgvSoucre.Columns[10].HeaderText] = (mp.Status == (byte)MonthlyPassStatus.Locked) ? "*" : string.Empty;
                //    //drow[dgvSoucre.Columns[11].HeaderText] = mp.EffectiveDate.ToString("dd/MM/yyyy");
                //    //drow[dgvSoucre.Columns[12].HeaderText] = mp.ExpirationDate.HasValue ? mp.ExpirationDate.Value.ToString("dd/MM/yyyy") : string.Empty;

                //    dtSoucre.Rows.Add(drow);
                //    rowIndex++;
                //}
                GemboxUtils.Instance.ExportDataTableToFile(dtSoucre, configExportFile);
                GemboxUtils.Instance.ExportDataTableToFile(dtSoucre);

                processedCount += dtSoucre.Rows.Count;
                ChangeCurrentProgress();
            }
            // while (result.Count == recordsPerPage + 1);
            while (true);

            GemboxUtils.Instance.AddFooter();
            GemboxUtils.Instance.AutoFix();
            try
            {
                GemboxUtils.Instance.Save();
                e.Result = true;
            }
            catch (IOException)
            {
                //  MessageBoxUtils.ShowWarningMessage("Tập tin MS Excel đang mở. Vui lòng đóng tập tin MS Excel và thực hiện quá trình xuất dữ liệu!");
                e.Result = false;
            }
        }

        private void bgwExportData_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((bool)e.Result)
            {
                prgCurrent.Value = 100;
                lblCurrentWork.Text = "Quá trình xuất dữ liệu đã hoàn tất!";
                btnOpenFile.Enabled = true;
            }
            else
            {
                lblCurrentWork.Text = "Quá trình xuất dữ liệu đã bị ngưng!";
                lblCurrentWork.ForeColor = Color.Red;
                btnOpenFile.Enabled = false;
            }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(configExportFile.FilePath);
        }

        #endregion

        #region UI Supporting Methods

        private void ChangeCurrentProgress()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => { ChangeCurrentProgress(); }));
                return;
            }
            float percentage = ((float)processedCount / maxRow) * 100;
            if (percentage > 100f)
            {
                percentage = 100f;
            }
            prgCurrent.Value = (int)percentage;
        }

        private void SetFormType()
        {
            //this.Text = FormExportFileTypeExt.GetName(FormExportFileType.MonthlyPass);
            //lblDescription.Text = FormExportFileTypeExt.GetDescription(FormExportFileType.MonthlyPass);
        }

        #endregion

        #region Load Data

        private DataTable InitDtMonthlyPass()
        {
            DataTable dtData = new DataTable();
            dtData.Columns.Add(number, typeof(long));
            for (int colIndex = 0; colIndex < dgvSoucre.ColumnCount - 1; colIndex++)
            {
                if (dgvSoucre.Columns[colIndex].Visible == false)
                    continue;
                string cellFormat = string.IsNullOrEmpty(dgvSoucre.Columns[colIndex].DefaultCellStyle.Format) ? string.Empty : dgvSoucre.Columns[colIndex].DefaultCellStyle.Format.Substring(0, 1);
                //if (cellFormat.Equals("N"))
                //{
                //    dtData.Columns.Add(dgvSoucre.Columns[colIndex].HeaderText, typeof(long));
                //}
                //else
                //{
                dtData.Columns.Add(dgvSoucre.Columns[colIndex].HeaderText, typeof(string));
                //}
            }

            return dtData;
        }

        #endregion

        #region Export Data
        #endregion
    }
}
