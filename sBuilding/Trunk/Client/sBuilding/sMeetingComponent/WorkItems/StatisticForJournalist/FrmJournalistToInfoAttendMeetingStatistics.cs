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
using System.ServiceModel;
using sWorldModel.Exceptions;
using sMeetingComponent.Factory;
using sMeetingComponent.Constants;
using ClientModel.Model;
using ClientModel.Utils;
using System.IO;
using sExcelExportComponent.ClientModel.Enums;
using sMeetingComponent.Model.CustomObj.JournalistObjForStatictis;
using sMeetingComponent.Model.CustomObj.PersonInfoForStatictis;

namespace sMeetingComponent.WorkItems.StatisticForJournalist
{
    public partial class FrmJournalistInfoAttendMeetingStatistics : Form
    {

        #region Properties
        public string sysFormatDate;

        int take = Enums.TAKE;

        private DateTime dateFroms;
        private DateTime dateTos;
        private DateTime startDateMeeting;
        private long meetingId;
        private long sum = 0;
        String updating = "updating";

        private DataTable table4Export = null;
        private DataTable dtbPersonAttendDetailList;
        private int currentPageIndex = 1;

        private JournalistAttendStatistic personAttendObj;
        private JournalistAttendStatisticDetailObj personAttendDetailObjList;
        private List<JournalistAttendStatisticDetail> personAttendDetaillist;
        private BackgroundWorker loadPersonAttendDetailList;

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
        /// FrmJournalistInfoAttendMeetingStatistics
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <param name="meetingId"></param>
        /// <param name="sum"></param>
        /// <param name="personAttendObj"></param>
        public FrmJournalistInfoAttendMeetingStatistics(DateTime dateFrom, DateTime dateTo, long meetingId, int sum, JournalistAttendStatistic personAttendObj)
        {
            InitializeComponent();
            InitDataTablePersonAttendDetailList();
            this.dateFroms = dateFrom;
            this.dateTos = dateTo;
            this.sum = sum;
            this.meetingId = meetingId;
            this.personAttendObj = personAttendObj;
            startDateMeeting = DateTime.Now;

            sysFormatDate = UsrListMeeting.formatDateTime();

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

            this.colPositionPartaker.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colPositionPartaker.Name);

            this.colNameAttendMeeting.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colNameAttendMeeting.Name);
            this.colPeopleAdded.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colPeopleAdded.Name);
            this.colJournalist.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colJournalist.Name);

            this.colDateTime.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colDateTime.Name);
            this.colInputTime.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colInputTime.Name);
            this.colOutputTime.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colOutputTime.Name);
            this.colNote.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colNote.Name);

            //20170307 #Bug Fix- My Nguyen start
            this.dataGridViewTextBoxColumn1.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colOrderNum.Name);
            this.dataGridViewTextBoxColumn2.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colNameAttendMeeting.Name);

            this.colPositionPartakerEx.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colPositionPartaker.Name);

            this.dataGridViewTextBoxColumn3.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colOrgPartaker.Name);
            this.dataGridViewCheckBoxColumn1.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colPeopleAdded.Name);
            this.dataGridViewCheckBoxColumn2.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colJournalist.Name);
            this.dataGridViewTextBoxColumn4.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colDateTime.Name);
            this.dataGridViewTextBoxColumn5.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colInputTime.Name);
            this.dataGridViewTextBoxColumn6.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colOutputTime.Name);
            this.dataGridViewTextBoxColumn7.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colNote.Name);
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
        /// LoadPersonAttendObj
        /// Show info number journalist attend meeting
        /// </summary>
        /// <param name="personAttendObj"></param>
        private void LoadPersonAttendObj(JournalistAttendStatistic personAttendObj)
        {
            if (personAttendObj != null)
            {
                tbxOrgName.Text = personAttendObj.organizationMeetingName;
                txtNameMeeting.Text = personAttendObj.meetingName;
                DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                startDateMeeting = start.AddMilliseconds(Convert.ToUInt64(personAttendObj.startTime)).ToLocalTime();
                DateTime endDate = start.AddMilliseconds(Convert.ToUInt64(personAttendObj.endTime)).ToLocalTime();
                DateTime datedefault = new DateTime(1971, 1, 1, 0, 0, 0, DateTimeKind.Utc);

                txtDate.Text = startDateMeeting.ToString(sysFormatDate);
                txtdtpDateIn.Text = startDateMeeting.ToString("HH:mm");
                txtdtpDateIn2.Text = endDate.ToString("HH:mm");
                txtnumberPeopleAttendInvited.Text = personAttendObj.numberJournalist.ToString();//tham du cua nha báo
            }
        }
        #endregion

        /// <summary>
        /// InitDataTablePersonAttendDetailList
        /// </summary>
        private void InitDataTablePersonAttendDetailList()
        {
            dtbPersonAttendDetailList = new DataTable();
            dtbPersonAttendDetailList.Columns.Add(colOrderNum.DataPropertyName);

            dtbPersonAttendDetailList.Columns.Add(colPositionPartaker.DataPropertyName);

            dtbPersonAttendDetailList.Columns.Add(colOrgPartaker.DataPropertyName);
            dtbPersonAttendDetailList.Columns.Add(colNameAttendMeeting.DataPropertyName);
            dtbPersonAttendDetailList.Columns.Add(colPeopleAdded.DataPropertyName);
            dtbPersonAttendDetailList.Columns.Add(colJournalist.DataPropertyName);
            dtbPersonAttendDetailList.Columns.Add(colNote.DataPropertyName);
            dtbPersonAttendDetailList.Columns.Add(colDateTime.DataPropertyName);
            dtbPersonAttendDetailList.Columns.Add(colInputTime.DataPropertyName);
            dtbPersonAttendDetailList.Columns.Add(colOutputTime.DataPropertyName);
            dgvPersonAttendDetail.DataSource = dtbPersonAttendDetailList;

            //20170304 #Bug Fix- My Nguyen Start
            // for export
            table4Export = new DataTable();
            table4Export.Columns.Add(colOrderNum.DataPropertyName);

            table4Export.Columns.Add(colPositionPartaker.DataPropertyName);

            table4Export.Columns.Add(colOrgPartaker.DataPropertyName);
            table4Export.Columns.Add(colNameAttendMeeting.DataPropertyName);
            table4Export.Columns.Add(colPeopleAdded.DataPropertyName);
            table4Export.Columns.Add(colJournalist.DataPropertyName);
            table4Export.Columns.Add(colNote.DataPropertyName);
            table4Export.Columns.Add(colDateTime.DataPropertyName);
            table4Export.Columns.Add(colInputTime.DataPropertyName);
            table4Export.Columns.Add(colOutputTime.DataPropertyName);
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

            LoadPersonAttendObj(personAttendObj);
            LoadPersonAttendDetailList();
        }

        #region bgWorker
        /// <summary>
        /// CreateBackgroundWorkerEvent
        /// </summary>
        private void CreateBackgroundWorkerEvent()
        {
            //16: THống kê BÁO CHÍ : LẤy thông tin chi tiết NHÀ BÁO người tham dự họp
            loadPersonAttendDetailList = new BackgroundWorker();
            loadPersonAttendDetailList.WorkerSupportsCancellation = true;
            loadPersonAttendDetailList.DoWork += OnLoadPersonAttendDetailWorkerDoWork;
            loadPersonAttendDetailList.RunWorkerCompleted += OnLoadPersonAttendDetailWorkerCompleted;
        }

        /// <summary>
        /// LoadPersonAttendDetailList
        /// </summary>
        public void LoadPersonAttendDetailList()
        {
            if (!loadPersonAttendDetailList.IsBusy)
            {
                dtbPersonAttendDetailList.Rows.Clear();
                pagerPanel.ShowMessage(MessageValidate.GetMessage(rm, "smsLoading"));
                loadPersonAttendDetailList.RunWorkerAsync();
            }
        }

        #region LoadEventAttendMeetingAtPage Load danh sách báo chí tham dự cuộc họp
        /// <summary>
        /// LoadEventAttendMeetingAtPage
        /// Load list journalist attend meeting based on (start, end, meetingId);
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public JournalistAttendStatisticDetailObj LoadEventAttendMeetingAtPage(int start, int end)
        {
            string dateFrom = dateFroms.ToString("yyyy-MM-dd");
            string dateTo = dateTos.ToString("yyyy-MM-dd");
            JournalistAttendStatisticDetailObj personAttendDetailObjnew = new JournalistAttendStatisticDetailObj();
            try
            {
                personAttendDetailObjnew = AttendMeetingStatisticFactory.Instance.GetChannel().getListAttendMeetingJournalistByMeetingidAndDate(StorageService.CurrentSessionId, start, end, meetingId);
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
            return personAttendDetailObjnew;
        }
        #endregion

        #region Gửi yêu cầu lấy danh sách thông tin chi tiết của báo chí tham dự họp
        /// <summary>
        /// get list attendmeeting based on meetingid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoadPersonAttendDetailWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            int totalRecords = 0;
            int skip = 0;
            currentPageIndex = 1;
            List<JournalistAttendStatisticDetail> result = new List<JournalistAttendStatisticDetail>();
            try
            {
                e.Result = personAttendDetailObjList = LoadEventAttendMeetingAtPage(skip, take);
            }
            catch (FaultException ex)
            {
            }
            finally
            {
                if (personAttendDetailObjList != null)
                {
                    totalRecords = Convert.ToInt32(sum);
                    result = personAttendDetailObjList.attendStatisticDetails;

                    pagerPanel.ShowNumberOfRecords(totalRecords, result != null ? result.Count : 0, take, currentPageIndex);
                    pagerPanel.UpdatePagingLinks(totalRecords, take, currentPageIndex);
                }
                e.Result = result;
            }
        }


        /// <summary>
        /// GetListInfoJournalist
        /// lấy thông tin nhà báo
        /// </summary>
        /// <param name="listPersonAttendDetail"></param>
        /// <returns></returns>
        public static List<PersonAttendDetail> GetListInfoJournalist(List<PersonAttendDetail> listPersonAttendDetail)
        {
            List<PersonAttendDetail> listInfoJournalist = new List<PersonAttendDetail>();
            for (int i = 0; i < listPersonAttendDetail.Count; i++)
            {
                if (listPersonAttendDetail[i].journalist)//&& (!listPersonAttendDetail[i].isNonresident))
                {
                    listInfoJournalist.Add(listPersonAttendDetail[i]);
                }
            }
            return listInfoJournalist;
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
        /// OnLoadPersonAttendDetailWorkerCompleted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoadPersonAttendDetailWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                UploadStatusBar();
            }
            if (e.Result == null)
            {
                UploadStatusBar();
            }
            else
            {
                List<JournalistAttendStatisticDetail> result = (List<JournalistAttendStatisticDetail>)e.Result;
                if (result.Count != 0)
                {
                    LoadAttendMeetingListdata(result);
                }
                else
                {
                    UploadStatusBar();
                }
            }
        }
        #endregion

        #region Hiển thị thông tin chi tiết danh sách nhà báo tham dự họp
        /// <summary>
        /// LoadAttendMeetingListdata
        /// Show list info detail attend meeting
        /// </summary>
        /// <param name="result"></param>
        public void LoadAttendMeetingListdata(List<JournalistAttendStatisticDetail> result)
        {
            dtbPersonAttendDetailList.Clear();
            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            int index = 0;

            for (int i = 0; i < result.Count; i++)
            {
                //nhà báo mới hiển thị
                DataRow row = dtbPersonAttendDetailList.NewRow();
                row.BeginEdit();
                index = index + 1;
                row[colOrderNum.DataPropertyName] = index;

                row[colPositionPartaker.DataPropertyName] = result[i].partakerPosition;

                row[colOrgPartaker.DataPropertyName] = result[i].organizationAttendName;
                row[colNameAttendMeeting.DataPropertyName] = result[i].partakerName;
                row[colNote.DataPropertyName] = result[i].note;

                if (result[i].inputTime != null && result[i].inputTime != "")
                {
                    DateTime inputtime = start.AddMilliseconds(Convert.ToUInt64(result[i].inputTime)).ToLocalTime();
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
                dtbPersonAttendDetailList.Rows.Add(row);
            }

            if (dgvPersonAttendDetail.Rows.Count > 0)
            {
                btnExportToExcel.Enabled = true;
                //focur the first row in table
                dgvPersonAttendDetail.Rows[0].Selected = true;
            }
            else
            {
                UploadStatusBarHavePagePanel();
            }
        }
        #endregion

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
            string dateFrom = dateFroms.ToString("yyyy-MM-dd");
            string dateTo = dateTos.ToString("yyyy-MM-dd");
            JournalistAttendStatisticDetailObj personAttendDetailObjnew = new JournalistAttendStatisticDetailObj();
            try
            {
                int start = 0;
                int end = take;
                personAttendDetailObjnew = AttendMeetingStatisticFactory.Instance.GetChannel().getListAttendMeetingJournalistByMeetingidAndDate(StorageService.CurrentSessionId, start, end, meetingId);
            }
            catch (Exception ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ex.Message);
            }

            CommonDataGridView dataExport = new CommonDataGridView();
            if (personAttendDetailObjnew != null)
            {

                //lấy thông tin nhà báo
                personAttendDetaillist = new List<JournalistAttendStatisticDetail>();
                if (personAttendDetailObjnew.attendStatisticDetails != null)
                    personAttendDetaillist = personAttendDetailObjList.attendStatisticDetails;

                PrepareDataToExport(personAttendDetaillist);
                //end
                //phân trang
                int totalRecords = Convert.ToInt32(personAttendDetailObjnew.sum);

                //lay them du lieu neu khong du vi tong so record lon hon so take (take = 20) trong 1 trang
                if (totalRecords > take)
                {
                    int numberPage = (totalRecords / take) + ((totalRecords % take > 0) ? 1 : 0);
                    for (int i = 1; i < numberPage; i++)
                    {
                        int start = i * take;
                        int end = take;
                        personAttendDetailObjnew = AttendMeetingStatisticFactory.Instance.GetChannel().getListAttendMeetingJournalistByMeetingidAndDate(StorageService.CurrentSessionId, start, end, meetingId);
                        if (personAttendDetailObjnew != null)
                        {
                            //lấy thông tin nhà báo
                            personAttendDetaillist = new List<JournalistAttendStatisticDetail>();
                            if (personAttendDetailObjnew.attendStatisticDetails != null)
                                personAttendDetaillist = personAttendDetailObjnew.attendStatisticDetails;
                            PrepareDataToExport(personAttendDetaillist);
                            //end
                        }
                    }
                }
            }
        }

        /// <summary>
        ///  add du lieu vao datagridview
        /// </summary>
        /// <param name="datagridview"></param>
        /// <param name="data"></param>
        private void PrepareDataToExport(List<JournalistAttendStatisticDetail> result)
        {
            int index = table4Export.Rows.Count;

            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            for (int i = 0; i < result.Count; i++)
            {
                DataRow row = table4Export.NewRow();
                row.BeginEdit();
                index += 1;

                row[colOrderNum.DataPropertyName] = index;
                row[colPositionPartaker.DataPropertyName] = result[i].partakerPosition;

                row[colOrgPartaker.DataPropertyName] = result[i].organizationAttendName;
                row[colNameAttendMeeting.DataPropertyName] = result[i].partakerName;
                //row[colJournalist.DataPropertyName] = result[i].journalist;
                //row[colPeopleAdded.DataPropertyName] = result[i].add;
                row[colNote.DataPropertyName] = result[i].note;

                if (result[i].inputTime != null && result[i].inputTime != "")
                {
                    DateTime inputtime = start.AddMilliseconds(Convert.ToUInt64(result[i].inputTime)).ToLocalTime();
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
                //}
            }
        }
        //20170304 #Bug Fix- My Nguyen End

        /// <summary>
        /// click export
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            String name = MessageValidate.GetMessage(rm, "lbltitleLabelInfoMeetinginoutOfJournalist") + "_" + startDateMeeting.ToString("dd-MM-yyyy");
            //String name = MessageValidate.GetMessage(rm, "lbltitleLabelInfoMeetinginoutOfJournalist") + "_" + tbxOrgName.Text + "_" + txtNameMeeting.Text + "_" + startDateMeeting.ToString("dd-MM-yyyy");
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
                    GemboxUtils.Instance.ExportDataGridToFileCustom(dataGridview4Export, configExportFile, 8);//tua de, xuat file
                    GemboxUtils.Instance.AutoFixA4();
                    GemboxUtils.Instance.ExportDataGridToFile(dataGridview4Export.Rows.Count);//tua de, xuat file

                    int widthA4 = configExportFile.GetSizePageA4Height();

                    WidthA4Percent withA4Percent = new WidthA4Percent(widthA4);
                    int widthCol = withA4Percent.GetWidth13();  //widthA4 * 8 / 100;
                    GemboxUtils.Instance.SetWidthColIndex(2, widthCol);//2300

                    GemboxUtils.Instance.AutoFixWidthColIndexEnd(1, configExportFile.GetSizePageA4Height());

                    //custom
                    //export general information
                    String lbltitleLabelInfoMeetinginoutOfJournalist = MessageValidate.GetMessage(rm, "lbltitleLabelInfoMeetinginoutOfJournalist");
                    GemboxUtils.Instance.AddHeader(lbltitleLabelInfoMeetinginoutOfJournalist == null ? string.Empty : lbltitleLabelInfoMeetinginoutOfJournalist);

                    int index = ConstantsEnum.positionIndexCol;
                    String lblGoverningOrganization = MessageValidate.GetMessage(rm, "lblGoverningOrganization");
                    String value = (lblGoverningOrganization == null ? string.Empty : lblGoverningOrganization) + " " + (tbxOrgName.Text == null ? string.Empty : tbxOrgName.Text.ToString());
                    GemboxUtils.Instance.AddCellCustom(index, 0, value == null ? string.Empty : value);
                    value = "";
                    index++;
                    String lblMeeting = MessageValidate.GetMessage(rm, "lblMeeting");
                    value = (lblMeeting == null ? string.Empty : lblMeeting) + " " + (txtNameMeeting.Text == null ? string.Empty : txtNameMeeting.Text.ToString());
                    GemboxUtils.Instance.AddCellCustom(index, 0, value == null ? string.Empty : value);
                    value = "";
                    index++;
                    String lblTime = MessageValidate.GetMessage(rm, "lblTime");
                    GemboxUtils.Instance.AddCellCustom(index, 0, lblTime == null ? string.Empty : lblTime);
                    GemboxUtils.Instance.AddCellCustom(index, 1, txtDate.Text == null ? string.Empty : txtDate.Text.ToString());
                    value = (lblTime == null ? string.Empty : lblTime) + " " + (txtDate.Text == null ? string.Empty : txtDate.Text.ToString());
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
                    String lblnumberPeopleAttendInvited = MessageValidate.GetMessage(rm, "lblnumberJournalist");
                    value = (lblnumberPeopleAttendInvited == null ? string.Empty : lblnumberPeopleAttendInvited) + " " + (txtnumberPeopleAttendInvited.Text == null ? string.Empty : txtnumberPeopleAttendInvited.Text.ToString());
                    GemboxUtils.Instance.AddCellCustom(index, 0, value == null ? string.Empty : value);
                    value = "";
                    index++;

                    GemboxUtils.Instance.AddCellCustom(index, 0, value == null ? string.Empty : value);

                    index = ConstantsEnum.positionIndexCol;
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

        #region Load thông tin theo Phân trang
        /// <summary>
        /// click pagerpanel
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
            dtbPersonAttendDetailList.Rows.Clear();
            int skip = (currentPageIndex - 1) * take;
            int totalRecords = 0;

            JournalistAttendStatisticDetailObj personAttendDetailObjlistnew = LoadEventAttendMeetingAtPage(skip, take);
            if (personAttendDetailObjlistnew != null)
            {
                //lấy thông tin nhà báo
                List<JournalistAttendStatisticDetail> result = new List<JournalistAttendStatisticDetail>();
                if (personAttendDetailObjlistnew.attendStatisticDetails != null)
                    result = personAttendDetailObjlistnew.attendStatisticDetails;
                //end
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
                return;
            }
        }
        #endregion
    }
}
