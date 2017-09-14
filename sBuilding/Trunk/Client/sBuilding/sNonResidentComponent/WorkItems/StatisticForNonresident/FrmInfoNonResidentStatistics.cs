using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Resources;
using Microsoft.Practices.CompositeUI;
using sWorldModel;
using CommonHelper.Utils;
using CommonHelper.Constants;
using CommonControls;
using CommonControls.Custom;
using CommonHelper.Config;
using sNonResidentComponent.Factory;
using System.ServiceModel;
using sWorldModel.Exceptions;
using sNonResidenComponent.WorkItems;
using ClientModel.Model;
using ClientModel.Utils;
using System.IO;
using sExcelExportComponent.ClientModel.Enums;
using sNonResidentComponent.Model.CustomObj.Statistic;
using sNonResidentComponent.WorkItems.ManageMeeting;
using sMeetingComponent.Constants;

namespace sNonResidentComponent.WorkItems.StatisticForNonresident
{
    public partial class FrmInfoNonResidentStatistics : Form
    {

        #region Properties
        public string sysFormatDate;

        int take = Enums.TAKE;
        private DateTime dateFroms;
        private DateTime dateTos;

        private long orgId;
        private int sum;
        private List<NonResidentObj> nonResidentlist;
        private BackgroundWorker loadNonResidentList;
        private DataTable table4Export = null;
        private DataTable dtbNonResidentList;
        String updating = "Updating";
        String cancelled = "Cancelled";
        private int currentPageIndex = 1;
        private const int hiddenFilterBoxHeight = 1;
        private int startupFilterBoxHeight;

        private FrmShiftImage frm = new FrmShiftImage("", "");

        private ResourceManager rm;
        private NonResidentComponentWorkItem workItem;
        [ServiceDependency]
        public NonResidentComponentWorkItem WorkItem
        {
            set { workItem = value; }
        }

        private ILocalStorageService storageService;
        [ServiceDependency]
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
            set { storageService = value; }
        }
        #endregion

        #region Contructors
        public FrmInfoNonResidentStatistics(DateTime dateFrom, DateTime dateTo, long orgId, int sum)
        {
            InitializeComponent();
            InitDataTableNonResidentList();

            sysFormatDate = UsrManageMeeting.formatDateTime();

            this.dateFroms = dateFrom;
            this.dateTos = dateTo;
            this.sum = sum;
            this.orgId = orgId;
            Load += OnFormLoad;
        }
        #endregion
        /// <summary>
        /// InitDataTableNonResidentList
        /// </summary>
        private void InitDataTableNonResidentList()
        {
            dtbNonResidentList = new DataTable();
            dtbNonResidentList.Columns.Add(colOrderNum.DataPropertyName);
            dtbNonResidentList.Columns.Add(colMemberId.DataPropertyName);
            dtbNonResidentList.Columns.Add(colSerialNumber.DataPropertyName);
            dtbNonResidentList.Columns.Add(colFullName.DataPropertyName);

            dtbNonResidentList.Columns.Add(colPositionPartaker.DataPropertyName);
            dtbNonResidentList.Columns.Add(colOrgPartaker.DataPropertyName);

            dtbNonResidentList.Columns.Add(colBirthDate.DataPropertyName);
            dtbNonResidentList.Columns.Add(colIdentityCard.DataPropertyName);
            dtbNonResidentList.Columns.Add(colIdentityCardDate.DataPropertyName);
            dtbNonResidentList.Columns.Add(colIdentityCardIssue.DataPropertyName);
            dtbNonResidentList.Columns.Add(colNationality.DataPropertyName);
            dtbNonResidentList.Columns.Add(colPhoneNo.DataPropertyName);
            dtbNonResidentList.Columns.Add(colAddress.DataPropertyName);
            dtbNonResidentList.Columns.Add(colPersoStatus.DataPropertyName);
            dtbNonResidentList.Columns.Add(colToOrg.DataPropertyName);
            dtbNonResidentList.Columns.Add(colDate.DataPropertyName);
            dtbNonResidentList.Columns.Add(colInputTime.DataPropertyName);
            dtbNonResidentList.Columns.Add(colOutTime.DataPropertyName);
            dtbNonResidentList.Columns.Add(colNameMeeting.DataPropertyName);
            dtbNonResidentList.Columns.Add(colImageFace.DataPropertyName);
            dtbNonResidentList.Columns.Add(colImageIdentityCard.DataPropertyName);
            dtbNonResidentList.Columns.Add(colContactContent.DataPropertyName);
            dgvNonResident.DataSource = dtbNonResidentList;

            //20170304 #Bug Fix- My Nguyen Start
            // for export
            table4Export = new DataTable();

            table4Export.Columns.Add(colOrderNum.DataPropertyName);
            table4Export.Columns.Add(colMemberId.DataPropertyName);
            table4Export.Columns.Add(colSerialNumber.DataPropertyName);
            table4Export.Columns.Add(colFullName.DataPropertyName);

            table4Export.Columns.Add(colPositionPartaker.DataPropertyName);
            table4Export.Columns.Add(colOrgPartaker.DataPropertyName);

            table4Export.Columns.Add(colBirthDate.DataPropertyName);
            table4Export.Columns.Add(colIdentityCard.DataPropertyName);
            table4Export.Columns.Add(colIdentityCardDate.DataPropertyName);
            table4Export.Columns.Add(colIdentityCardIssue.DataPropertyName);
            table4Export.Columns.Add(colNationality.DataPropertyName);
            table4Export.Columns.Add(colPhoneNo.DataPropertyName);
            table4Export.Columns.Add(colAddress.DataPropertyName);
            table4Export.Columns.Add(colPersoStatus.DataPropertyName);
            table4Export.Columns.Add(colToOrg.DataPropertyName);
            table4Export.Columns.Add(colDate.DataPropertyName);
            table4Export.Columns.Add(colInputTime.DataPropertyName);
            table4Export.Columns.Add(colOutTime.DataPropertyName);
            table4Export.Columns.Add(colNameMeeting.DataPropertyName);
            table4Export.Columns.Add(colImageFace.DataPropertyName);
            table4Export.Columns.Add(colImageIdentityCard.DataPropertyName);
            table4Export.Columns.Add(colContactContent.DataPropertyName);

            dataGridview4Export.DataSource = table4Export;
            //20170304 #Bug Fix- My Nguyen End

        }

        /// <summary>
        /// RegisterEvent
        /// đăng ký sự kiện
        /// </summary>
        private void RegisterEvent()
        {
            CreateBackgroundWorkerEvent();
            pagerPanel.LinkLabelClicked += pagerPanel_LinkLabelClicked;
            btnExportToExcel.Click += btnExportToExcel_Click;
            dgvNonResident.CellClick += dgvNonResidentClicked;
            LoadNonResidentStatisticList();
            //Load += OnFormLoad;
        }

        /// <summary>
        /// mouse leave dgv
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvNonResidentMouseLeave(object sender, EventArgs e)
        {
            workItem.SmartParts.Remove(frm);
            frm.Hide();
        }

        /// <summary>
        /// FrmInfoNonResidentStatistics_FormClosed
        /// closed form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmInfoNonResidentStatistics_FormClosed(object sender, FormClosedEventArgs e)
        {
            workItem.SmartParts.Remove(frm);
            frm.Hide();
        }
        /// <summary>
        /// OnFormLoad
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnFormLoad(object sender, EventArgs e)
        {
            //CustomTypeDate();
            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
            this.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.Name);
            pagerPanel.StorageService = storageService;
            pagerPanel.LoadLanguage();

            SetLanguages();
            RegisterEvent();
            startupFilterBoxHeight = pnlFilterBox.Height;
        }

        #region language
        /// <summary>
        /// SetLanguages
        /// </summary>
        private void SetLanguages()
        {
            this.colOrderNum.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colOrderNum.Name);
            this.colFullName.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colFullName.Name);

             this.colPositionPartaker.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colPositionPartaker.Name);
            this.colOrgPartaker.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colOrgPartaker.Name);

            this.colBirthDate.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colBirthDate.Name);
            this.colIdentityCard.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colIdentityCard.Name);
            this.colNationality.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colNationality.Name);
            this.colPhoneNo.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colPhoneNo.Name);
            this.colToOrg.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colToOrg.Name);
            this.colDate.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colDate.Name);
            this.colInputTime.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colInputTime.Name);
            this.colPersoStatus.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colPersoStatus.Name);
            this.colOutTime.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colOutTime.Name);
            this.colAddress.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colAddress.Name);
            this.colContactContent.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colContactContent.Name);
            this.colNameMeeting.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colNameMeeting.Name);

            //20170307 #Bug Fix- My Nguyen start
            this.dataGridViewTextBoxColumn1.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colOrderNum.Name);
            this.dataGridViewTextBoxColumn2.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colToOrg.Name);
            this.dataGridViewTextBoxColumn3.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colFullName.Name);

            this.colPositionPartakerEx.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colPositionPartaker.Name);
            this.colOrgPartakerEx.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colOrgPartaker.Name);

            this.dataGridViewTextBoxColumn4.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colNameMeeting.Name);
            this.dataGridViewTextBoxColumn5.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colDate.Name);
            this.dataGridViewTextBoxColumn7.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colInputTime.Name);
            this.dataGridViewTextBoxColumn8.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colOutTime.Name);
            this.dataGridViewTextBoxColumn9.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colContactContent.Name);
            this.dataGridViewTextBoxColumn11.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colBirthDate.Name);
            this.dataGridViewTextBoxColumn12.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colIdentityCard.Name);
            this.dataGridViewTextBoxColumn15.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colNationality.Name);
            this.dataGridViewTextBoxColumn16.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colPhoneNo.Name);
            this.dataGridViewTextBoxColumn17.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colAddress.Name);
            this.dataGridViewTextBoxColumn18.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colPersoStatus.Name);
            //20170307 #Bug Fix- My Nguyen end

            this.btnExportToExcel.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnExportToExcel.Name);

            string updatestr = MessageValidate.GetMessage(rm, "updating");
            if (updatestr != null)
            {
                updating = updatestr;

                if (updating.Equals("") || updating.Equals("LanguagesError"))
                {
                    updating = "updating";
                }
            }
            string cancelledstr = MessageValidate.GetMessage(rm, "cancelled");
            if (cancelledstr != null)
            {
                cancelled = cancelledstr;

                if (cancelled.Equals("") || cancelled.Equals("LanguagesError"))
                {
                    cancelled = "Cancelled";
                }
            }
        }
        #endregion

        #region bgWorker
        /// <summary>
        /// CreateBackgroundWorkerEvent
        /// </summary>
        private void CreateBackgroundWorkerEvent()
        {
            //10: STATICTIS THÔNG TIN CHI TIẾT KHÁCH VÃNG LAI
            loadNonResidentList = new BackgroundWorker();
            loadNonResidentList.WorkerSupportsCancellation = true;
            loadNonResidentList.DoWork += OnLoadNonResidentWorkerDoWork;
            loadNonResidentList.RunWorkerCompleted += OnLoadNonResidentWorkerCompleted;
        }

        #region Load thông tin chi tiết khách vãng lai 
        /// <summary>
        /// LoadNonResidentAtPage
        /// load list info nonresident based on  start, end, dateFrom, dateTo, orgId);
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public List<NonResidentObj> LoadNonResidentAtPage(int start, int end)
        {
            string dateFrom = dateFroms.ToString("yyyy-MM-dd HH:mm:ss");
            string dateTo = dateTos.ToString("yyyy-MM-dd HH:mm:ss");
            List<NonResidentObj> nonResidentlistnew = new List<NonResidentObj>();
            try
            {
                nonResidentlistnew = NonResidentStatisticsFactory.Instance.GetChannel().getListNonresidentByOrgidAndDate(StorageService.CurrentSessionId, start, end, dateFrom, dateTo, orgId);
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
            return nonResidentlistnew;
        }
        #endregion

        #region Gửi yêu cầu lấy thông tin khách vãng lai
        /// <summary>
        /// LoadNonResidentStatisticList
        /// </summary>
        private void LoadNonResidentStatisticList()
        {
            if (!loadNonResidentList.IsBusy)
            {
                dtbNonResidentList.Rows.Clear();
                pagerPanel.ShowMessage(MessageValidate.GetMessage(rm, "smsLoading"));
                loadNonResidentList.RunWorkerAsync();
            }
        }

        /// <summary>
        /// get nonresident list based on from date to date
        /// OnLoadNonResidentWorkerDoWork
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoadNonResidentWorkerDoWork(object sender, DoWorkEventArgs e)
        {

            int totalRecords = 0;
            int skip = 0;
            currentPageIndex = 1;
            List<NonResidentObj> result = null;

            e.Result = nonResidentlist = LoadNonResidentAtPage(skip, take);

            if (nonResidentlist != null)
            {
                //sum=tong
                totalRecords = sum;
                result = nonResidentlist;
                pagerPanel.ShowNumberOfRecords(totalRecords, result != null ? result.Count : 0, take, currentPageIndex);
                pagerPanel.UpdatePagingLinks(totalRecords, take, currentPageIndex);
            }
            e.Result = result;
        }

        /// <summary>
        /// không cho phân trang thi vẫn còn hiển thị thanh link, và không cho xuất exccel
        /// Change statusbar : message not data
        /// </summary>
        private void UploadStatusBar()
        {
            pagerPanel.ShowMessage(MessageValidate.GetMessage(rm, "lblMessageNotData"));
            pagerPanel.UpdatePagingLinks(0, 1, 0);
        }

        //cho phân trang thi vẫn còn hiển thị thanh link, và cho xuất exccel
        /// <summary>
        ///  change status bar: have pagepanel , but not data
        ///  cho phân trang thi vẫn còn hiển thị thanh link, và cho xuất exccel
        /// </summary>
        private void UploadStatusBarHavePagePanel()
        {
            pagerPanel.ShowMessage(MessageValidate.GetMessage(rm, "lblMessageNotData"));
        }
        /// <summary>
        /// OnLoadNonResidentWorkerCompleted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoadNonResidentWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                UploadStatusBar();
                return;
            }
            if (e.Result == null)
            {
                UploadStatusBar();
                return;
            }
            else
            {
                List<NonResidentObj> result = (List<NonResidentObj>)e.Result;
                if (result.Count != 0)
                {
                    LoadNonResidentListdata(result);
                    tbxOrgName.Text = nonResidentlist[0].nonResident.orgName;
                    this.txtdtpDateIn.Text = dateFroms.ToString("dd/MM/yyyy");
                    this.txtdtpDateIn2.Text = dateTos.ToString("dd/MM/yyyy");
                }
                else
                {
                    UploadStatusBar();
                    return;
                }
            }
        }
        #endregion

        #region Hiển thị thông tin khách vãng lai
        /// <summary>
        /// show nonresident list
        /// </summary>
        /// <param name="result"></param>
        public void LoadNonResidentListdata(List<NonResidentObj> result)
        {
            dtbNonResidentList.Clear();
            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            //  DateTime inputtimeOrg = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc); ;
            int index = 0;
            for (int i = 0; i < result.Count; i++)
            {
                DataRow row = dtbNonResidentList.NewRow();
                row.BeginEdit();
                index = i + 1;
                row[colOrderNum.DataPropertyName] = index;
                row[colMemberId.DataPropertyName] = result[i].nonResident.id;
                row[colSerialNumber.DataPropertyName] = result[i].nonResident.serialNumber;
                row[colFullName.DataPropertyName] = result[i].nonResident.name;

                row[colPositionPartaker.DataPropertyName] = result[i].nonResident.nonResidentPosition;
                row[colOrgPartaker.DataPropertyName] = result[i].nonResident.nonResidentOrganization;

                row[colIdentityCard.DataPropertyName] = result[i].nonResident.identityCard;
                row[colIdentityCardIssue.DataPropertyName] = result[i].nonResident.identitycardIssue;
                row[colContactContent.DataPropertyName] = result[i].nonResident.note;
                row[colPhoneNo.DataPropertyName] = result[i].nonResident.phonenumber;
                //   row[colAddress.DataPropertyName] = result[i].nonResident.temporaryAddress;
                row[colToOrg.DataPropertyName] = result[i].nonResident.orgName;
                row[colNameMeeting.DataPropertyName] = result[i].nonResident.meetingName;

                //if (result[i].nonResident.birthday != null && result[i].nonResident.birthday != "")
                //{
                //    DateTime birthday = start.AddMilliseconds(Convert.ToUInt64(result[i].nonResident.birthday)).ToLocalTime();
                //    string sysFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;

                //    row[colBirthDate.DataPropertyName] = birthday.ToString(sysFormat);
                //}
                if (result[i].nonResident.identityCardIssueDate != null && result[i].nonResident.identityCardIssueDate != "")
                {
                    DateTime identityCardIssueDate = start.AddMilliseconds(Convert.ToUInt64(result[i].nonResident.identityCardIssueDate)).ToLocalTime();
                    //string sysFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;

                    row[colIdentityCardDate.DataPropertyName] = identityCardIssueDate.ToString(sysFormatDate);
                }
                DateTime endDate = start.AddMilliseconds(Convert.ToUInt64(result[i].nonResident.outputTime)).ToLocalTime();
                DateTime datedefault = new DateTime(1971, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                DateTime datedefault2 = new DateTime(1972, 2, 2, 0, 0, 0, DateTimeKind.Utc);
                int compareDateEnd = DateTime.Compare(endDate, datedefault);
                int compareDateEnd2 = DateTime.Compare(endDate, datedefault2);

                if (compareDateEnd == 0)
                {
                    row[colOutTime.DataPropertyName] = updating;
                }
                else
                {
                    row[colOutTime.DataPropertyName] = endDate.ToString("HH:mm");
                }

                if (compareDateEnd2 == 0)
                {
                    row[colOutTime.DataPropertyName] = cancelled;
                }
                if (result[i].nonResident.serialNumber.Equals("00000000"))
                {
                    row[colPersoStatus.DataPropertyName] = cancelled;
                }
                else
                {
                    row[colPersoStatus.DataPropertyName] = updating;
                }

                if (result[i].nonResident.inputTime != null && result[i].nonResident.inputTime != "")
                {
                    DateTime inputtime = start.AddMilliseconds(Convert.ToUInt64(result[i].nonResident.inputTime)).ToLocalTime();
                    // inputtimeOrg = inputtime;
                    //  row[colPersoStatus.DataPropertyName] = "Đang hoạt động";

                    // string sysFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
                    row[colDate.DataPropertyName] = inputtime.ToString(sysFormatDate);
                    row[colInputTime.DataPropertyName] = inputtime.ToString("HH:mm");
                }
                //hinh
                if (result[i].dataImageFace != null)
                {
                    row[colImageFace.DataPropertyName] = result[i].dataImageFace;
                }
                if (result[i].dataImageIdentityCard != null)
                {
                    row[colImageIdentityCard.DataPropertyName] = result[i].dataImageIdentityCard;
                }
                row.EndEdit();
                dtbNonResidentList.Rows.Add(row);
            }
            if (dgvNonResident.Rows.Count > 0)
            {
                //focur the first row in table
                btnExportToExcel.Enabled = true;
                dgvNonResident.Rows[0].Selected = true;
            }
            else
            {
                UploadStatusBarHavePagePanel();
            }
        }
        #endregion

        #endregion

        #region event
        /// <summary>
        /// click pagerppanel
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        private void pagerPanel_LinkLabelClicked(object s, LinkLabelClickedArgs e)
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
            dtbNonResidentList.Rows.Clear();
            int skip = (currentPageIndex - 1) * take;
            List<NonResidentObj> nonResidentListNew = LoadNonResidentAtPage(skip, take);
            if (nonResidentListNew != null)
            {
                List<NonResidentObj> result = nonResidentListNew;
                LoadNonResidentListdata(result);
                nonResidentlist = result;
                pagerPanel.ShowNumberOfRecords(sum, result != null ? result.Count : 0, take, currentPageIndex);
                pagerPanel.UpdatePagingLinks(sum, take, currentPageIndex);
            }
            else
            {
                UploadStatusBarHavePagePanel();
                return;
            }
        }
        /// <summary>
        /// click dgv
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvNonResidentClicked(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex != -1)
            {
                workItem.SmartParts.Remove(frm);
                frm.Hide();
                // Get selected rows
                var selectedRows = dgvNonResident.SelectedRows;
                int rowsCount = selectedRows.Count;
                if (rowsCount == 0)
                {
                    //Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Failed, MessageValidate.GetMessSelect(rm, "cancelNonresident"))));
                    return;
                }
                else
                {
                    try
                    {
                        //lấy tên khách vãng lai cần hủy thẻ
                        String ImageFace = selectedRows[0].Cells[colImageFace.Name].Value.ToString();
                        String ImageIdentityCard = selectedRows[0].Cells[colImageIdentityCard.Name].Value.ToString();
                        try
                        {
                            frm = new FrmShiftImage(ImageFace, ImageIdentityCard);
                        }
                        catch (Exception ex)
                        {
                            frm = new FrmShiftImage(ImageFace, ImageIdentityCard);
                        }
                        workItem.SmartParts.Add(frm);
                        int x = lblGoverningOrganization.Parent.Location.X + lblGoverningOrganization.Location.X;
                        int y = lblGoverningOrganization.Parent.Location.Y + lblGoverningOrganization.Parent.Height + 100;

                        frm.Location = new Point(x, y);
                        frm.Show();
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
        }
        #endregion

        #region Chuẩn bị dữ liệu xuất file excel
        //20170304 #Bug Fix- My Nguyen Start
        /// <summary>
        /// lay du dlieu tu server cho export data
        /// </summary>
        /// <param name="totalpage">tong so trang</param>
        /// <returns></returns>
        private void GetDataFOrExport()
        {
            // query lan dau de lay du lieu va so luong records
            string dateFrom = dateFroms.ToString("yyyy-MM-dd HH:mm:ss");
            string dateTo = dateTos.ToString("yyyy-MM-dd HH:mm:ss");
            List<NonResidentObj> nonResidentlistnew = new List<NonResidentObj>();
            try
            {
                int start = 0;
                int end = take;
                nonResidentlistnew = NonResidentStatisticsFactory.Instance.GetChannel().getListNonresidentByOrgidAndDate(StorageService.CurrentSessionId, start, end, dateFrom, dateTo, orgId);
            }
            catch (Exception ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "TimeOutExceptionMessage"));
            }
            //   CommonDataGridView dataExport = new CommonDataGridView();
            if (nonResidentlistnew != null)
            {
                // add data lan dau tien
                PrepareDataToExport(nonResidentlistnew);

                //phân trang
                // int totalRecords = Convert.ToInt32(nonResidentlistnew.sum);
                //sum=tong
                int totalRecords = sum;

                //lay them du lieu neu khong du vi tong so record lon hon so take (take = 20) trong 1 trang
                if (totalRecords > take)
                {
                    int numberPage = (totalRecords / take) + ((totalRecords % take > 0) ? 1 : 0);
                    for (int i = 1; i < numberPage; i++)
                    {
                        int start = i * take;
                        int end = take;
                        nonResidentlistnew = NonResidentStatisticsFactory.Instance.GetChannel().getListNonresidentByOrgidAndDate(StorageService.CurrentSessionId, start, end, dateFrom, dateTo, orgId);
                        PrepareDataToExport(nonResidentlistnew);
                    }
                }
            }
        }

        /// <summary>
        ///  add du lieu vao datagridview
        /// </summary>
        /// <param name="datagridview"></param>
        /// <param name="data"></param>
        private void PrepareDataToExport(List<NonResidentObj> result)
        {
            int index = table4Export.Rows.Count;
            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            for (int i = 0; i < result.Count; i++)
            {
                DataRow row = table4Export.NewRow();
                row.BeginEdit();
                index += 1;
                row[colOrderNum.DataPropertyName] = index;
                row[colMemberId.DataPropertyName] = result[i].nonResident.id;
                row[colSerialNumber.DataPropertyName] = result[i].nonResident.serialNumber;
                row[colFullName.DataPropertyName] = result[i].nonResident.name;

                row[colPositionPartaker.DataPropertyName] = result[i].nonResident.nonResidentPosition;
                row[colOrgPartaker.DataPropertyName] = result[i].nonResident.nonResidentOrganization;

                row[colIdentityCard.DataPropertyName] = result[i].nonResident.identityCard;
                row[colIdentityCardIssue.DataPropertyName] = result[i].nonResident.identitycardIssue;
                row[colContactContent.DataPropertyName] = result[i].nonResident.note;
                row[colPhoneNo.DataPropertyName] = result[i].nonResident.phonenumber;
                //  row[colAddress.DataPropertyName] = result[i].nonResident.temporaryAddress;
                row[colToOrg.DataPropertyName] = result[i].nonResident.orgName;
                row[colNameMeeting.DataPropertyName] = result[i].nonResident.meetingName;

                //if (result[i].nonResident.birthday != null && result[i].nonResident.birthday != "")
                //{
                //    DateTime birthday = start.AddMilliseconds(Convert.ToUInt64(result[i].nonResident.birthday)).ToLocalTime();
                //    string sysFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;

                //    row[colBirthDate.DataPropertyName] = birthday.ToString(sysFormat);
                //}
                if (result[i].nonResident.identityCardIssueDate != null && result[i].nonResident.identityCardIssueDate != "")
                {
                    DateTime identityCardIssueDate = start.AddMilliseconds(Convert.ToUInt64(result[i].nonResident.identityCardIssueDate)).ToLocalTime();
                    //   string sysFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;

                    row[colIdentityCardDate.DataPropertyName] = identityCardIssueDate.ToString(sysFormatDate);
                }
                DateTime endDate = start.AddMilliseconds(Convert.ToUInt64(result[i].nonResident.outputTime)).ToLocalTime();
                DateTime datedefault = new DateTime(1971, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                DateTime datedefault2 = new DateTime(1972, 2, 2, 0, 0, 0, DateTimeKind.Utc);
                int compareDateEnd = DateTime.Compare(endDate, datedefault);
                int compareDateEnd2 = DateTime.Compare(endDate, datedefault2);

                if (compareDateEnd == 0)
                {
                    row[colOutTime.DataPropertyName] = updating;
                }
                else
                {
                    row[colOutTime.DataPropertyName] = endDate.ToString("HH:mm");
                }

                if (compareDateEnd2 == 0)
                {
                    row[colOutTime.DataPropertyName] = cancelled;
                }
                if (result[i].nonResident.serialNumber.Equals("00000000"))
                {
                    row[colPersoStatus.DataPropertyName] = cancelled;
                }
                else
                {
                    row[colPersoStatus.DataPropertyName] = updating;
                }

                if (result[i].nonResident.inputTime != null && result[i].nonResident.inputTime != "")
                {
                    DateTime inputtime = start.AddMilliseconds(Convert.ToUInt64(result[i].nonResident.inputTime)).ToLocalTime();
                    // inputtimeOrg = inputtime;
                    //  row[colPersoStatus.DataPropertyName] = "Đang hoạt động";
                    //string sysFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;

                    row[colDate.DataPropertyName] = inputtime.ToString(sysFormatDate);
                    row[colInputTime.DataPropertyName] = inputtime.ToString("HH:mm");
                }
                //hinh
                if (result[i].dataImageFace != null)
                {
                    row[colImageFace.DataPropertyName] = result[i].dataImageFace;
                }
                if (result[i].dataImageIdentityCard != null)
                {
                    row[colImageIdentityCard.DataPropertyName] = result[i].dataImageIdentityCard;
                }
                row.EndEdit();
                table4Export.Rows.Add(row);
            }
        }
        //20170304 #Bug Fix  - My Nguyen End
        /// <summary>
        /// click export excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            //  String name = MessageValidate.GetMessage(rm, "lbltitleLabelInfoDetailNon") + "_" + tbxOrgName.Text + "_" + dateFroms.ToString("dd-MM-yyyy") + "_" + dateTos.ToString("dd-MM-yyyy");
            // String name = tbxOrgName.ToString() + "_" +;
            String name = MessageValidate.GetMessage(rm, "lbltitleLabelInfoDetailNon") + "_" + dateFroms.ToString("dd-MM-yyyy") + "_" + dateTos.ToString("dd-MM-yyyy");

            string filePath = ControlExtMethods.ShowSaveFileDialog(MessageValidate.GetMessage(rm, "smsChooseFileExport"), name, CategorizeExcel.Categorize);
            if (filePath != null)
            {
                try
                { 
                    // show du lieu truoc do trong table
                    table4Export.Rows.Clear();
                    // tao du lieu moi
                    GetDataFOrExport();


                    ConfigExportFileModel configExportFile = new ConfigExportFileModel();
                    configExportFile.FilePath = filePath;
                    GemboxUtils.Instance.ExportDataGridToFileCustom(dataGridview4Export, configExportFile, 5);//tua de, xuat file
                    GemboxUtils.Instance.ExportDataGridToFile(dataGridview4Export.Rows.Count);//tua de, xuat file
                    GemboxUtils.Instance.AutoFix();

                    //custom
                    //export general information

                    String lbltitleLabelInfoDetailNon = MessageValidate.GetMessage(rm, "lbltitleLabelInfoDetailNon");
                    GemboxUtils.Instance.AddHeader(lbltitleLabelInfoDetailNon == null ? string.Empty : lbltitleLabelInfoDetailNon);

                    int index = 3;
                    String lblTime = MessageValidate.GetMessage(rm, "lblTime");
                    GemboxUtils.Instance.AddCellCustom(index, 0, lblTime == null ? string.Empty : lblTime);
                    GemboxUtils.Instance.AddCellCustom(index, 1, txtdtpDateIn.Text == null ? string.Empty : txtdtpDateIn.Text.ToString());
                    String value = (lblTime == null ? string.Empty : lblTime) + " " + (txtdtpDateIn.Text == null ? string.Empty : txtdtpDateIn.Text.ToString());
                    String lblTo = MessageValidate.GetMessage(rm, "lblTo");
                    GemboxUtils.Instance.AddCellCustom(index, 2, lblTo == null ? string.Empty : lblTo);
                    GemboxUtils.Instance.AddCellCustom(index, 3, txtdtpDateIn2.Text == null ? string.Empty : txtdtpDateIn2.Text.ToString());
                    value += " " + (lblTo == null ? string.Empty : lblTo) + " " + (txtdtpDateIn2.Text == null ? string.Empty : txtdtpDateIn2.Text.ToString());
                    GemboxUtils.Instance.AddCellCustom(index, 0, value == null ? string.Empty : value);
                    value = ""; index++;
                    String lblGoverningOrganization = MessageValidate.GetMessage(rm, "lblGoverningOrganization");
                    GemboxUtils.Instance.AddCellCustom(index, 0, lblGoverningOrganization == null ? string.Empty : lblGoverningOrganization);
                    GemboxUtils.Instance.AddCellCustom(index, 1, tbxOrgName.Text == null ? string.Empty : tbxOrgName.Text.ToString());
                    value = (lblGoverningOrganization == null ? string.Empty : lblGoverningOrganization) + " " + (tbxOrgName.Text == null ? string.Empty : tbxOrgName.Text.ToString());
                    GemboxUtils.Instance.AddCellCustom(index, 0, value == null ? string.Empty : value);
                    value = ""; index++;
                    index = 3;
                    //end custom
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
            }
        }
        #endregion

    }
}
