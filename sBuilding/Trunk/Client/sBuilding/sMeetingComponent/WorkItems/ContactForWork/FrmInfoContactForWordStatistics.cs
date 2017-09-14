using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.Resources;
using Microsoft.Practices.CompositeUI;
using sWorldModel;
using CommonHelper.Utils;
using CommonHelper.Constants;
using CommonControls;
using CommonControls.Custom;
using CommonHelper.Config;
using sMeetingComponent.Model;
using System.ServiceModel;
using sWorldModel.Exceptions;
using sMeetingComponent.Factory;
using ClientModel.Model;
using ClientModel.Utils;
using System.IO;
using sExcelExportComponent.ClientModel.Enums;
using sMeetingComponent.Model.CustomObj.ContactForWorkObj;
using sMeetingComponent.Model.CustomObj.PersonInfoForStatictis;
using sMeetingComponent.Constants;

namespace sMeetingComponent.WorkItems.ContactForWork
{
    public partial class FrmInfoContactForWordStatistics : Form
    {

        #region Properties
        public string sysFormatDate;

        int take = Enums.TAKE;
        private int currentPageIndex = 1;

        private DateTime dateFroms;
        private DateTime dateTos;
        private DateTime startDateMeeting;
        private long orgId;
        private long sum = 0;
        String updating = "updating";

        private SmeetingContactCount SmeetingContactStatistic;
        private SmeetingContactStatisticDetailObj SmeetingContactStatisticDetailObjList;
        private List<SmeetingContactStatistic> SmeetingContactStatisticlist;
        //  List<PersonAttendDetail> personAttendDetaillistNonresident;

        private BackgroundWorker loadSmeetingContactStatisticlist;

        private DataTable dtbSmeetingContactStatisticlist;
        private DataTable table4Export = null;

        private ResourceManager rm;
        private MeetingComponentWorkItem workItem;
        [ServiceDependency]
        public MeetingComponentWorkItem WorkItem
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
        /// <summary>
        /// FrmInfoContactForWordStatistics
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <param name="SmeetingContactStatistic"></param>
        public FrmInfoContactForWordStatistics(DateTime dateFrom, DateTime dateTo, SmeetingContactCount SmeetingContactStatistic)
        {
            InitializeComponent();
            InitDataTableSmeetingContactStatisticlist();

            sysFormatDate = UsrListMeeting.formatDateTime();

            this.dateFroms = dateFrom;
            this.dateTos = dateTo;
            this.sum = SmeetingContactStatistic.sum;
            this.orgId = SmeetingContactStatistic.orgId;

            this.SmeetingContactStatistic = SmeetingContactStatistic;
            startDateMeeting = DateTime.Now;

            Load += OnFormLoad;
        }
        #endregion

        /// <summary>
        /// OnFormLoad
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnFormLoad(object sender, EventArgs e)
        {
            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
            this.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.Name);
            pagerPanel.StorageService = storageService;
            pagerPanel.LoadLanguage();

            SetLanguages();

            RegisterEvent();
        }

        #region language
        /// <summary>
        /// SetLanguages
        /// </summary>
        private void SetLanguages()
        {
            this.colOrderNum.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colOrderNum.Name);
            this.colOrgPartaker.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colOrgPartaker.Name);
            this.colNameAttendMeeting.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colNameAttendMeeting.Name);
            this.colPosition.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colPosition.Name);
            this.colDateTime.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colDateTime.Name);
            this.colInputTime.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colInputTime.Name);
            this.colOutputTime.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colOutputTime.Name);
            this.colNote.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colNote.Name);
            this.colIdentityCard.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colIdentityCard.Name);
            this.colPhone.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colPhone.Name);

            //20170307 #Bug Fix- My Nguyen start
            this.dataGridViewTextBoxColumn1.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colOrderNum.Name);
            this.dataGridViewTextBoxColumn2.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colNameAttendMeeting.Name);
            this.dataGridViewTextBoxColumn3.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colOrgPartaker.Name);
            this.dataGridViewTextBoxColumn4.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colDateTime.Name);
            this.dataGridViewTextBoxColumn5.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colInputTime.Name);
            this.dataGridViewTextBoxColumn6.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colOutputTime.Name);
            this.dataGridViewTextBoxColumn7.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colNote.Name);
            this.colPositionEx.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colPosition.Name);
            this.colIdentityCardEx.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colIdentityCard.Name);
            this.colPhoneEx.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colPhone.Name);
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
        }

        /// <summary>
        /// Show info org contact
        /// </summary>
        /// <param name="SmeetingContactStatistic"></param>
        private void LoadSmeetingContactStatistic(SmeetingContactCount SmeetingContactStatistic)
        {
            if (SmeetingContactStatistic != null)
            {
                tbxOrgName.Text = SmeetingContactStatistic.orgName;
                this.txtdtpDateIn.Text = dateFroms.ToString("dd/MM/yyyy");
                this.txtdtpDateIn2.Text = dateTos.ToString("dd/MM/yyyy");
            }
        }
        #endregion

        /// <summary>
        /// InitDataTableSmeetingContactStatisticlist
        /// </summary>
        private void InitDataTableSmeetingContactStatisticlist()
        {
            dtbSmeetingContactStatisticlist = new DataTable();
            dtbSmeetingContactStatisticlist.Columns.Add(colOrderNum.DataPropertyName);
            dtbSmeetingContactStatisticlist.Columns.Add(colOrgPartaker.DataPropertyName);
            dtbSmeetingContactStatisticlist.Columns.Add(colNameAttendMeeting.DataPropertyName);
            dtbSmeetingContactStatisticlist.Columns.Add(colPosition.DataPropertyName);
            dtbSmeetingContactStatisticlist.Columns.Add(colNote.DataPropertyName);
            dtbSmeetingContactStatisticlist.Columns.Add(colDateTime.DataPropertyName);
            dtbSmeetingContactStatisticlist.Columns.Add(colInputTime.DataPropertyName);
            dtbSmeetingContactStatisticlist.Columns.Add(colOutputTime.DataPropertyName);
            dtbSmeetingContactStatisticlist.Columns.Add(colIdentityCard.DataPropertyName);
            dtbSmeetingContactStatisticlist.Columns.Add(colPhone.DataPropertyName);

            dgvPersonAttendDetail.DataSource = dtbSmeetingContactStatisticlist;

            //20170304 #Bug Fix- My Nguyen Start
            // for export
            table4Export = new DataTable();
            table4Export.Columns.Add(colOrderNum.DataPropertyName);
            table4Export.Columns.Add(colOrgPartaker.DataPropertyName);
            table4Export.Columns.Add(colNameAttendMeeting.DataPropertyName);
            table4Export.Columns.Add(colPositionEx.DataPropertyName);
            table4Export.Columns.Add(colNote.DataPropertyName);
            table4Export.Columns.Add(colDateTime.DataPropertyName);
            table4Export.Columns.Add(colInputTime.DataPropertyName);
            table4Export.Columns.Add(colOutputTime.DataPropertyName);
            table4Export.Columns.Add(colIdentityCardEx.DataPropertyName);
            table4Export.Columns.Add(colPhoneEx.DataPropertyName);

            dataGridview4Export.DataSource = table4Export;
            //20170304 #Bug Fix- My Nguyen End
        }

        /// <summary>
        /// đăng ký sự kiện
        /// RegisterEvent
        /// </summary>
        private void RegisterEvent()
        {
            CreateBackgroundWorkerEvent();

            pagerPanel.LinkLabelClicked += pagerPanel_LinkLabelClicked;
            btnExportToExcel.Click += btnExportToExcel_Click;

            LoadSmeetingContactStatistic(SmeetingContactStatistic);
            LoadSmeetingContactStatisticlist();
        }
        /// <summary>
        /// CreateBackgroundWorkerEvent
        /// </summary>
        private void CreateBackgroundWorkerEvent()
        {
            //19: THống kê LIÊN HỆ CÔNG TÁC: LẤy thông tin chi tiết người đến liên hệ
            loadSmeetingContactStatisticlist = new BackgroundWorker();
            loadSmeetingContactStatisticlist.WorkerSupportsCancellation = true;
            loadSmeetingContactStatisticlist.DoWork += OnLoadSmeetingContactStatisticDetailWorkerDoWork;
            loadSmeetingContactStatisticlist.RunWorkerCompleted += OnLoadSmeetingContactStatisticDetailWorkerCompleted;
        }

        #region LoadEventAttendMeetingAtPage : Load danh sách người tham dự cuộc họp
        /// <summary>
        /// Statictis: get list info detail person contact based on (start, end, dateFrom, dateTo, orgId);
        /// Lấy danh sách thông tin người đến liên hệ công tác
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public SmeetingContactStatisticDetailObj LoadEventAttendMeetingAtPage(int start, int end)
        {
            string dateFrom = dateFroms.ToString("yyyy-MM-dd");
            string dateTo = dateTos.ToString("yyyy-MM-dd");
            SmeetingContactStatisticDetailObj SmeetingContactStatisticDetailObjnew = new SmeetingContactStatisticDetailObj();
            try
            {
                SmeetingContactStatisticDetailObjnew = ContactForWorkFactory.Instance.GetChannel().getListSmeetingContactStatisticDetaItByDateAndOrgId(StorageService.CurrentSessionId, start, end, dateFrom, dateTo, orgId);
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
            return SmeetingContactStatisticDetailObjnew;
        }
        #endregion

        #region Gửi yêu cầu lấy thông tin chi tiết người tham dự 
        /// <summary>
        /// LoadSmeetingContactStatisticlist
        /// </summary>
        public void LoadSmeetingContactStatisticlist()
        {
            if (!loadSmeetingContactStatisticlist.IsBusy)
            {
                dtbSmeetingContactStatisticlist.Rows.Clear();
                pagerPanel.ShowMessage(MessageValidate.GetMessage(rm, "smsLoading"));
                loadSmeetingContactStatisticlist.RunWorkerAsync();
            }
        }

        /// <summary>
        /// OnLoadSmeetingContactStatisticDetailWorkerDoWork
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoadSmeetingContactStatisticDetailWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            int totalRecords = 0;
            int skip = 0;
            currentPageIndex = 1;
            List<SmeetingContactStatistic> result = new List<SmeetingContactStatistic>();
            try
            {
                e.Result = SmeetingContactStatisticDetailObjList = LoadEventAttendMeetingAtPage(skip, take);
            }
            catch (FaultException ex)
            {
            }
            finally
            {
                if (SmeetingContactStatisticDetailObjList != null)
                {
                    totalRecords = Convert.ToInt32(sum);

                    if (SmeetingContactStatisticDetailObjList.contactStatisticDetails != null)
                        result = SmeetingContactStatisticDetailObjList.contactStatisticDetails;

                    pagerPanel.ShowNumberOfRecords(totalRecords, result != null ? result.Count : 0, take, currentPageIndex);
                    pagerPanel.UpdatePagingLinks(totalRecords, take, currentPageIndex);
                }
                e.Result = result;
            }
        }

        /// <summary>
        /// lấy thông tin khách vãng lai add vào chung đối tượng với thông tin người tham dự để hiển thi 
        /// PREPARED DATA : GET info nonresident add on attendmeeting to show info
        /// </summary>
        /// <param name="listNonresident"></param>
        /// <returns></returns>
        public static List<PersonAttendDetail> AddListNonresident(List<NonResident> listNonresident)
        {
            List<PersonAttendDetail> personAttendDetaillistNonresidentNew = new List<PersonAttendDetail>();
            for (int i = 0; i < listNonresident.Count; i++)
            {
                PersonAttendDetail personAttendDetailItem = new PersonAttendDetail();
                personAttendDetailItem.organizationAttendName = listNonresident[i].nonResidentOrganization;
                personAttendDetailItem.partakerName = listNonresident[i].name;
                personAttendDetailItem.journalist = false;
                personAttendDetailItem.add = false;
                personAttendDetailItem.note = listNonresident[i].note;
                personAttendDetailItem.inputTime = listNonresident[i].inputTime;
                personAttendDetailItem.outputTime = listNonresident[i].outputTime;
                personAttendDetailItem.identityCard = listNonresident[i].identityCard;
                personAttendDetailItem.phonenumber = listNonresident[i].phonenumber;
                personAttendDetailItem.isNonresident = true;

                personAttendDetaillistNonresidentNew.Add(personAttendDetailItem);
            }
            return personAttendDetaillistNonresidentNew;
        }

        /// <summary>
        /// Change statusbar : message not data
        /// </summary>
        private void UploadStatusBar()
        {
            btnExportToExcel.Enabled = false;
            pagerPanel.ShowMessage(MessageValidate.GetMessage(rm, "lblMessageNotData"));
            pagerPanel.UpdatePagingLinks(0, 1, 0);
        }

        /// <summary>
        /// change status bar: have pagepanel , but not data
        /// cho phân trang thi vẫn còn hiển thị thanh link, và cho xuất exccel
        /// </summary>
        private void UploadStatusBarHavePagePanel()
        {
            pagerPanel.ShowMessage(MessageValidate.GetMessage(rm, "lblMessageNotData"));
        }

        /// <summary>
        /// OnLoadSmeetingContactStatisticDetailWorkerCompleted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoadSmeetingContactStatisticDetailWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                UploadStatusBar();
                // MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "SmsNotConnectData"));
                //return;
            }
            if (e.Result == null)
            {
                UploadStatusBar();
                // MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "smsNotFilter"));
                //return;
            }
            else
            {
                List<SmeetingContactStatistic> result = (List<SmeetingContactStatistic>)e.Result;
                if (result.Count != 0)
                {
                    LoadAttendMeetingListdata(result);
                }
                else
                {
                    UploadStatusBar();
                    // MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "smsNotFilter"));
                    //return;
                }
            }
        }
        #endregion

        #region Hiển thị thông tin chi tiết của người đến liên hệ công tác
        /// <summary>
        /// show list info person contact
        /// </summary>
        /// <param name="result"></param>
        public void LoadAttendMeetingListdata(List<SmeetingContactStatistic> result)
        {
            dtbSmeetingContactStatisticlist.Clear();
            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            int index = 0;

            for (int i = 0; i < result.Count; i++)
            {
                DataRow row = dtbSmeetingContactStatisticlist.NewRow();
                row.BeginEdit();
                index = i + 1;
                row[colOrderNum.DataPropertyName] = index;
                row[colOrgPartaker.DataPropertyName] = result[i].organizationAttendName;
                row[colNameAttendMeeting.DataPropertyName] = result[i].partakerName;
                row[colPosition.DataPropertyName] = result[i].position;
                row[colIdentityCard.DataPropertyName] = result[i].identityCard;
                row[colPhone.DataPropertyName] = result[i].phonenumber;
                row[colNote.DataPropertyName] = result[i].note;

                if (result[i].inputTime != null && result[i].inputTime != "")
                {
                    DateTime inputtime = start.AddMilliseconds(Convert.ToUInt64(result[i].inputTime)).ToLocalTime();
                    //string sysFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
                    row[colDateTime.DataPropertyName] = inputtime.ToString(sysFormatDate);
                    row[colInputTime.DataPropertyName] = inputtime.ToString("HH:mm");
                }
                if (result[i].outputTime != null && result[i].outputTime != "")
                {
                    DateTime endDate = start.AddMilliseconds(Convert.ToUInt64(result[i].outputTime)).ToLocalTime();
                    DateTime datedefault = new DateTime(1971, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                    int compareDateEnd = DateTime.Compare(endDate, datedefault);

                    if (compareDateEnd == 0)
                    {
                        row[colOutputTime.DataPropertyName] = updating;
                    }
                    else
                    {
                        row[colOutputTime.DataPropertyName] = endDate.ToString("HH:mm");
                    }
                }
                row.EndEdit();
                dtbSmeetingContactStatisticlist.Rows.Add(row);
            }

            if (dgvPersonAttendDetail.Rows.Count > 0)
            {
                btnExportToExcel.Enabled = true;
                //focur the first row in table
                dgvPersonAttendDetail.Rows[0].Selected = true;
            }
            else
            {
                //UploadStatusBar();
                UploadStatusBarHavePagePanel();
            }
        }
        #endregion

        #region Chuẩn bị dữ liệu xuất file excel
        //20170304 #Bug Fix- My Nguyen Start
        /// <summary>
        /// lay du dlieu tu server cho xuất file
        /// get data for export file
        /// </summary>
        /// <param name="totalpage">tong so trang</param>
        /// <returns></returns>
        private void GetDataFOrExport()
        {
            // query lan dau de lay du lieu va so luong records
            string dateFrom = dateFroms.ToString("yyyy-MM-dd");
            string dateTo = dateTos.ToString("yyyy-MM-dd");
            SmeetingContactStatisticDetailObj personAttendDetailObjnew = new SmeetingContactStatisticDetailObj();
            try
            {
                int start = 0;
                int end = take;
                personAttendDetailObjnew = ContactForWorkFactory.Instance.GetChannel().getListSmeetingContactStatisticDetaItByDateAndOrgId(StorageService.CurrentSessionId, start, end, dateFrom, dateTo, orgId);
            }
            catch (Exception ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ex.Message);
                //      MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "TimeOutExceptionMessage"));
            }

            CommonDataGridView dataExport = new CommonDataGridView();
            if (personAttendDetailObjnew != null)
            {
                //thông tin khách vãng lai tham dự họp
                SmeetingContactStatisticlist = new List<SmeetingContactStatistic>();

                if (personAttendDetailObjnew.contactStatisticDetails != null)
                    SmeetingContactStatisticlist = personAttendDetailObjnew.contactStatisticDetails;

                // add data lan dau tien
                // PrepareDataToExport(personAttendDetailObjnew.personAttendDetails);
                PrepareDataToExport(SmeetingContactStatisticlist);

                //phân trang
                int totalRecords = Convert.ToInt32(personAttendDetailObjnew.sum);

                //lay them du lieu neu khong du vi tong so record lon hon so take (take = 20) trong 1 trang
                if (totalRecords > take)
                {
                    int numberPage = (totalRecords / take) + ((totalRecords % take > 0) ? 1 : 0);
                    for (int i = 1; i < numberPage; i++)
                    {
                        //int start = i * take + 1;
                        int start = i * take;
                        int end = take;
                        personAttendDetailObjnew = ContactForWorkFactory.Instance.GetChannel().getListSmeetingContactStatisticDetaItByDateAndOrgId(StorageService.CurrentSessionId, start, end, dateFrom, dateTo, orgId);
                        if (personAttendDetailObjnew != null)
                        {
                            //thông tin khách vãng lai tham dự họp
                            SmeetingContactStatisticlist = new List<SmeetingContactStatistic>();

                            if (personAttendDetailObjnew.contactStatisticDetails != null)
                                SmeetingContactStatisticlist = personAttendDetailObjnew.contactStatisticDetails;

                            // add data lan dau tien
                            // PrepareDataToExport(personAttendDetailObjnew.personAttendDetails);
                            PrepareDataToExport(SmeetingContactStatisticlist);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// PrepareDataToExport
        /// THêm dữ liệu vào dgv
        /// </summary>
        /// <param name="datagridview"></param>
        /// <param name="data"></param>
        private void PrepareDataToExport(List<SmeetingContactStatistic> result)
        {
            int index = table4Export.Rows.Count;

            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            for (int i = 0; i < result.Count; i++)
            {
                DataRow row = table4Export.NewRow();
                row.BeginEdit();
                index += 1;

                row[colOrderNum.DataPropertyName] = index;
                row[colOrgPartaker.DataPropertyName] = result[i].organizationAttendName;
                row[colNameAttendMeeting.DataPropertyName] = result[i].partakerName;
                row[colPosition.DataPropertyName] = result[i].position;
                row[colIdentityCard.DataPropertyName] = result[i].identityCard;
                row[colPhone.DataPropertyName] = result[i].phonenumber;
                row[colNote.DataPropertyName] = result[i].note;

                if (result[i].inputTime != null && result[i].inputTime != "")
                {
                    DateTime inputtime = start.AddMilliseconds(Convert.ToUInt64(result[i].inputTime)).ToLocalTime();
                    //   string sysFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
                    row[colDateTime.DataPropertyName] = inputtime.ToString(sysFormatDate);

                    row[colInputTime.DataPropertyName] = inputtime.ToString("HH:mm");
                }
                if (result[i].outputTime != null && result[i].outputTime != "")
                {
                    DateTime endDate = start.AddMilliseconds(Convert.ToUInt64(result[i].outputTime)).ToLocalTime();
                    DateTime datedefault = new DateTime(1971, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                    int compareDateEnd = DateTime.Compare(endDate, datedefault);

                    if (compareDateEnd == 0)
                    {
                        row[colOutputTime.DataPropertyName] = updating;
                    }
                    else
                    {
                        row[colOutputTime.DataPropertyName] = endDate.ToString("HH:mm");
                    }
                }
                row.EndEdit();

                table4Export.Rows.Add(row);
            }
        }
        //20170304 #Bug Fix- My Nguyen End

        /// <summary>
        /// EXPORT FILE EXCEL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            //  String name = MessageValidate.GetMessage(rm, "lbltitleLabelInfoMeetinginoutContactForWork") + "_" + tbxOrgName.Text + "_" + startDateMeeting.ToString("dd-MM-yyyy");
            String name = MessageValidate.GetMessage(rm, "lbltitleLabelInfoMeetinginoutContactForWork") + "_" + startDateMeeting.ToString("dd-MM-yyyy");
            string filePath = ControlExtMethods.ShowSaveFileDialog(MessageValidate.GetMessage(rm, "smsChooseFileExport"), name, CategorizeExcel.Categorize);
            if (filePath != null)
            {
                try
                {
                    //ExportToExcel(dgvPersonAttendDetail, filePath);
                    //dgvPersonAttendDetail.ExportToExcel(filePath);

                    // show du lieu truoc do trong table
                    table4Export.Rows.Clear();
                    // tao du lieu moi
                    GetDataFOrExport();
                    //cach1
                    //ExportToExcel(dataGridview4Export, filePath);

                    ConfigExportFileModel configExportFile = new ConfigExportFileModel();
                    configExportFile.FilePath = filePath;
                    GemboxUtils.Instance.ExportDataGridToFileCustom(dataGridview4Export, configExportFile, 5);//tua de, xuat file //12
                    GemboxUtils.Instance.AutoFixA4();
                    GemboxUtils.Instance.ExportDataGridToFile(dataGridview4Export.Rows.Count);//noi dung dgv

                    int widthA4 = configExportFile.GetSizePageA4Height();
                    WidthA4Percent withA4Percent = new WidthA4Percent(widthA4);
                    GemboxUtils.Instance.AutoFixColIndex(4);//Date
                    int widthColOrg = withA4Percent.GetWidth13();  // widthA4 * 13 / 100;
                    GemboxUtils.Instance.SetWidthColIndex(2, widthColOrg);//2300

                    GemboxUtils.Instance.AutoFixWidthColIndexEnd(1, configExportFile.GetSizePageA4Height());//21000:29700

                    //custom
                    //export general information
                    String lbltitleLabelInfoMeetinginoutContactForWork = MessageValidate.GetMessage(rm, "lbltitleLabelInfoMeetinginoutContactForWork");
                    GemboxUtils.Instance.AddHeader(lbltitleLabelInfoMeetinginoutContactForWork == null ? string.Empty : lbltitleLabelInfoMeetinginoutContactForWork);

                    int index = 3;
                    String lblGoverningOrganization = MessageValidate.GetMessage(rm, "lblGoverningOrganization");
                    String value = (lblGoverningOrganization == null ? string.Empty : lblGoverningOrganization) + " " + (tbxOrgName.Text == null ? string.Empty : tbxOrgName.Text.ToString());
                    GemboxUtils.Instance.AddCellCustom(index, 0, value == null ? string.Empty : value);
                    value = "";
                    index++;

                    String lblHour = MessageValidate.GetMessage(rm, "lblHour");
                    value = (lblHour == null ? string.Empty : lblHour) + " " + (txtdtpDateIn.Text == null ? string.Empty : txtdtpDateIn.Text.ToString());
                    String lblHourEnd = MessageValidate.GetMessage(rm, "lblHourEnd");
                    value += " " + (lblHourEnd == null ? string.Empty : lblHourEnd) + " " + (txtdtpDateIn2.Text == null ? string.Empty : txtdtpDateIn2.Text.ToString());
                    GemboxUtils.Instance.AddCellCustom(index, 0, value == null ? string.Empty : value);
                    value = "";
                    index++;

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

        #region Event's
        /// <summary>
        /// even clicj pagerpanel
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
            dtbSmeetingContactStatisticlist.Rows.Clear();
            int skip = (currentPageIndex - 1) * take;
            int totalRecords = 0;

            SmeetingContactStatisticDetailObj SmeetingContactStatisticDetailObjListnew = LoadEventAttendMeetingAtPage(skip, take);
            if (SmeetingContactStatisticDetailObjListnew != null)
            {
                List<SmeetingContactStatistic> result = new List<SmeetingContactStatistic>();
                if (SmeetingContactStatisticDetailObjListnew.contactStatisticDetails != null)
                    result = SmeetingContactStatisticDetailObjListnew.contactStatisticDetails;

                LoadAttendMeetingListdata(result);
                totalRecords = Convert.ToInt32(sum);

                pagerPanel.ShowNumberOfRecords(totalRecords, result != null ? result.Count : 0, take, currentPageIndex);
                pagerPanel.UpdatePagingLinks(totalRecords, take, currentPageIndex);
            }
            else
            {
                // sang trang 2 thì chỉ cho  hien thi chữ thông báo không có dữ liệu
                //nhưng van cho xuât file dư lieu excel
                UploadStatusBarHavePagePanel();
                // UploadStatusBar();
                // MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "smsNotFilter"));
                return;
            }
        }
        #endregion

    }
}
