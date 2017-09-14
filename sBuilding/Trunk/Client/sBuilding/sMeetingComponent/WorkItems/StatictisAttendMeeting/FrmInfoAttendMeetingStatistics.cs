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
using sMeetingComponent.Constants;
using ClientModel.Model;
using ClientModel.Utils;
using System.IO;
using sExcelExportComponent.ClientModel.Enums;
using sMeetingComponent.Model.CustomObj.PersonInfoForStatictis;

namespace sMeetingComponent.WorkItems.StatictisAttendMeeting
{
    public partial class FrmInfoAttendMeetingStatistics : Form
    {

        #region Properties
        public string sysFormatDate;

        int take = Enums.TAKE;

        private int currentPageIndex = 1;

        private DateTime dateFroms;
        private DateTime dateTos;
        private DateTime startDateMeeting;
        private long meetingId;
        private long sum = 0;
        String updating = "updating";

        private PersonAttendObj personAttendObj;
        private PersonAttendDetailObj personAttendDetailObjList;
        private List<PersonAttendDetail> personAttendDetaillist;
        private BackgroundWorker loadPersonAttendDetailList;

        private DataTable dtbPersonAttendDetailList;
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
        /// FrmInfoAttendMeetingStatistics
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <param name="meetingId"></param>
        /// <param name="sum"></param>
        /// <param name="personAttendObj"></param>
        public FrmInfoAttendMeetingStatistics(DateTime dateFrom, DateTime dateTo, long meetingId, int sum, PersonAttendObj personAttendObj)
        {
            InitializeComponent();
            InitDataTablePersonAttendDetailList();
            sysFormatDate = UsrListMeeting.formatDateTime();

            this.dateFroms = dateFrom;
            this.dateTos = dateTo;
            this.sum = sum;
            this.meetingId = meetingId;
            this.personAttendObj = personAttendObj;
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

            this.colPositionPartaker.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colPositionPartaker.Name);

            this.colOrgPartaker.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colOrgPartaker.Name);
            this.colNameAttendMeeting.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colNameAttendMeeting.Name);
            this.colPeopleAdded.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colPeopleAdded.Name);
            this.colJournalist.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colJournalist.Name);

            this.colDateTime.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colDateTime.Name);
            this.colInputTime.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colInputTime.Name);
            this.colOutputTime.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colOutputTime.Name);
            this.colNote.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colNote.Name);

            this.colIsNonResident.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colIsNonResident.Name);
            this.colIdentityCard.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colIdentityCard.Name);
            this.colPhone.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colPhone.Name);
            this.colCheck.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colCheck.Name);

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

            this.colIsNonResidentEx.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colIsNonResident.Name);
            this.colIdentityCardEx.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colIdentityCard.Name);
            this.colPhoneEx.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colPhone.Name);
            this.colCheckEx.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colCheck.Name);

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
        /// SHow info statictis number attend meeting
        /// </summary>
        /// <param name="personAttendObj"></param>
        private void LoadPersonAttendObj(PersonAttendObj personAttendObj)
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

                txtnumberPeopleInvited.Text = personAttendObj.sumPeopleAttendInvited.ToString();//được mời
                txtnumberPeopleAttendInvited.Text = personAttendObj.numberPeopleAttendInvited.ToString();//được mời mà tham dự
                txtnumberPeopleAdded.Text = personAttendObj.numberPeopleAdded.ToString();//thêm vào
                txtnumberJournalist.Text = personAttendObj.numberJournalist.ToString();//nhà báo
                txtnumberNonresidentAttend.Text = personAttendObj.numberNonresident.ToString();//khách vãng lai

                int total = personAttendObj.numberPeopleAttendInvited + personAttendObj.numberPeopleAdded + personAttendObj.numberJournalist + personAttendObj.numberNonresident;
                txtTotal.Text = total.ToString();
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

            dtbPersonAttendDetailList.Columns.Add(colIsNonResident.DataPropertyName);
            dtbPersonAttendDetailList.Columns.Add(colIdentityCard.DataPropertyName);
            dtbPersonAttendDetailList.Columns.Add(colPhone.DataPropertyName);

            dtbPersonAttendDetailList.Columns.Add(colCheck.DataPropertyName);

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

            table4Export.Columns.Add(colIsNonResidentEx.DataPropertyName);
            table4Export.Columns.Add(colIdentityCardEx.DataPropertyName);
            table4Export.Columns.Add(colPhoneEx.DataPropertyName);

            table4Export.Columns.Add(colCheckEx.DataPropertyName);

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

        /// <summary>
        /// CreateBackgroundWorkerEvent
        /// </summary>
        private void CreateBackgroundWorkerEvent()
        {
            //12: THống kê : LẤy thông tin chi tiết người tham dự họp
            loadPersonAttendDetailList = new BackgroundWorker();
            loadPersonAttendDetailList.WorkerSupportsCancellation = true;
            loadPersonAttendDetailList.DoWork += OnLoadPersonAttendDetailWorkerDoWork;
            loadPersonAttendDetailList.RunWorkerCompleted += OnLoadPersonAttendDetailWorkerCompleted;
        }

        #region LoadEventAttendMeetingAtPage : Load danh sách người tham dự cuộc họp
        /// <summary>
        /// LoadEventAttendMeetingAtPage
        /// Load info statictis person attend meeting based on (start, end, meetingId);
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public PersonAttendDetailObj LoadEventAttendMeetingAtPage(int start, int end)
        {
            string dateFrom = dateFroms.ToString("yyyy-MM-dd");
            string dateTo = dateTos.ToString("yyyy-MM-dd");
            PersonAttendDetailObj personAttendDetailObjnew = new PersonAttendDetailObj();
            try
            {
                personAttendDetailObjnew = AttendMeetingStatisticFactory.Instance.GetChannel().getListAttendMeetingByMeetingidAndDate(StorageService.CurrentSessionId, start, end, meetingId);
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

        #region Gửi yêu cầu lấy thông tin chi tiết người tham dự 
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

        /// <summary>
        /// OnLoadPersonAttendDetailWorkerDoWork
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoadPersonAttendDetailWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            int totalRecords = 0;
            int skip = 0;
            currentPageIndex = 1;
            List<PersonAttendDetail> result = new List<PersonAttendDetail>();
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

                    if (personAttendDetailObjList.personAttendDetails != null)
                        result = personAttendDetailObjList.personAttendDetails;

                    //thông tin khách vãng lai tham dự họp
                    if (personAttendDetailObjList.nonresidentDetails != null)
                    {
                        result.AddRange(AddListNonresident(personAttendDetailObjList.nonresidentDetails));
                    }
                    //end thông tin khách vãng lai tham dự họp

                    pagerPanel.ShowNumberOfRecords(totalRecords, result != null ? result.Count : 0, take, currentPageIndex);
                    pagerPanel.UpdatePagingLinks(totalRecords, take, currentPageIndex);
                }
                e.Result = result;
            }
        }

        /// <summary>
        /// PLUS: Get list nonresident add on list peron attend meeting
        /// lấy thông tin khách vãng lai add vào chung đối tượng với thông tin người tham dự để hiển thi 
        /// </summary>
        /// <param name="listNonresident"></param>
        /// <returns></returns>
        public static List<PersonAttendDetail> AddListNonresident(List<NonResident> listNonresident)
        {
            List<PersonAttendDetail> personAttendDetaillistNonresidentNew = new List<PersonAttendDetail>();
            for (int i = 0; i < listNonresident.Count; i++)
            {
                PersonAttendDetail personAttendDetailItem = new PersonAttendDetail();
                //210417
                //them 2 truong chuc vu, voi status co tham du hop hay khong
                personAttendDetailItem.partakerPosition = listNonresident[i].nonResidentPosition;
                personAttendDetailItem.status = listNonresident[i].status;
                //
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
                personAttendDetailItem.status = true;

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
                List<PersonAttendDetail> result = (List<PersonAttendDetail>)e.Result;
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

        #region Hiển thị thông tin chi tiết của người tham dự cuộc hop
        /// <summary>
        /// show list info person attend meeting
        /// </summary>
        /// <param name="result"></param>
        public void LoadAttendMeetingListdata(List<PersonAttendDetail> result)
        {
            dtbPersonAttendDetailList.Clear();
            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            int index = 0;

            for (int i = 0; i < result.Count; i++)
            {
                DataRow row = dtbPersonAttendDetailList.NewRow();
                row.BeginEdit();
                index = i + 1;
                row[colOrderNum.DataPropertyName] = index;
                //row[colPositionPartaker.DataPropertyName] = "CV";
                row[colPositionPartaker.DataPropertyName] = result[i].partakerPosition;

                row[colOrgPartaker.DataPropertyName] = result[i].organizationAttendName;
                row[colNameAttendMeeting.DataPropertyName] = result[i].partakerName;

                row[colJournalist.DataPropertyName] = result[i].journalist;

                row[colIsNonResident.DataPropertyName] = result[i].isNonresident;
                row[colIdentityCard.DataPropertyName] = result[i].identityCard;
                row[colPhone.DataPropertyName] = result[i].phonenumber;


                row[colPeopleAdded.DataPropertyName] = result[i].add;
                row[colNote.DataPropertyName] = result[i].note;

                //row[colCheck.DataPropertyName] = true;
                row[colCheck.DataPropertyName] = result[i].status;

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
            PersonAttendDetailObj personAttendDetailObjnew = new PersonAttendDetailObj();
            try
            {
                int start = 0;
                int end = take;
                personAttendDetailObjnew = AttendMeetingStatisticFactory.Instance.GetChannel().getListAttendMeetingByMeetingidAndDate(StorageService.CurrentSessionId, start, end, meetingId);
            }
            catch (Exception ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ex.Message);
            }

            CommonDataGridView dataExport = new CommonDataGridView();
            if (personAttendDetailObjnew != null)
            {
                //thông tin khách vãng lai tham dự họp
                personAttendDetaillist = new List<PersonAttendDetail>();

                if (personAttendDetailObjnew.personAttendDetails != null)
                    personAttendDetaillist = personAttendDetailObjnew.personAttendDetails;

                if (personAttendDetailObjnew.nonresidentDetails != null)
                {
                    personAttendDetaillist.AddRange(AddListNonresident(personAttendDetailObjnew.nonresidentDetails));
                }
                //end thông tin khách vãng lai tham dự họp

                // add data lan dau tien
                PrepareDataToExport(personAttendDetaillist);

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
                        personAttendDetailObjnew = AttendMeetingStatisticFactory.Instance.GetChannel().getListAttendMeetingByMeetingidAndDate(StorageService.CurrentSessionId, start, end, meetingId);
                        if (personAttendDetailObjnew != null)
                        {
                            //thông tin khách vãng lai tham dự họp
                            personAttendDetaillist = new List<PersonAttendDetail>();

                            if (personAttendDetailObjnew.personAttendDetails != null)
                                personAttendDetaillist = personAttendDetailObjnew.personAttendDetails;

                            if (personAttendDetailObjnew.nonresidentDetails != null)
                            {
                                personAttendDetaillist.AddRange(AddListNonresident(personAttendDetailObjnew.nonresidentDetails));
                            }
                            //end thông tin khách vãng lai tham dự họp

                            // add data lan dau tien
                            PrepareDataToExport(personAttendDetaillist);
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
        private void PrepareDataToExport(List<PersonAttendDetail> result)
        {
            int index = table4Export.Rows.Count;

            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            for (int i = 0; i < result.Count; i++)
            {
                DataRow row = table4Export.NewRow();
                row.BeginEdit();
                index += 1;

                row[colOrderNum.DataPropertyName] = index;
                //  row[colPositionPartaker.DataPropertyName] = "CV";
                row[colPositionPartaker.DataPropertyName] = result[i].partakerPosition;

                row[colOrgPartaker.DataPropertyName] = result[i].organizationAttendName;
                row[colNameAttendMeeting.DataPropertyName] = result[i].partakerName;
                row[colJournalist.DataPropertyName] = result[i].journalist;

                row[colIsNonResident.DataPropertyName] = result[i].isNonresident;
                row[colIdentityCard.DataPropertyName] = result[i].identityCard;
                row[colPhone.DataPropertyName] = result[i].phonenumber;

                row[colPeopleAdded.DataPropertyName] = result[i].add;
                row[colNote.DataPropertyName] = result[i].note;

                //row[colCheck.DataPropertyName] = true;
                row[colCheck.DataPropertyName] = result[i].status;

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
            }
        }
        //20170304 #Bug Fix- My Nguyen End

        /// <summary>
        /// click btn export
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            //  String name = MessageValidate.GetMessage(rm, "lbltitleLabelInfoMeetinginout") + "_" + tbxOrgName.Text + "_" + txtNameMeeting.Text + "_" + startDateMeeting.ToString("dd-MM-yyyy");
            String name = MessageValidate.GetMessage(rm, "lbltitleLabelInfoMeetinginout") + "_" + startDateMeeting.ToString("dd-MM-yyyy");
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
                    GemboxUtils.Instance.SetPortrait(true);

                    GemboxUtils.Instance.ExportDataGridToFileCustom(dataGridview4Export, configExportFile, 14);//tua de, xuat file //13
                    GemboxUtils.Instance.AutoFixA4();
                    GemboxUtils.Instance.ExportDataGridToFile(dataGridview4Export.Rows.Count);//dữ liệu

                    int widthA4 = configExportFile.GetSizePageA4Width();
                    WidthA4Percent withA4Percent = new WidthA4Percent(widthA4);

                    //int widthCol = withA4Percent.GetWidth9();
                    //GemboxUtils.Instance.SetWidthColIndex(3, widthCol);

                    int widthColOrg = withA4Percent.SetWidth(WidthA4Percent.size20);
                    GemboxUtils.Instance.SetWidthColIndex(2, widthColOrg);
                    GemboxUtils.Instance.SetWidthColIndex(3, widthColOrg);

                    int widthColAttend = withA4Percent.SetWidth(WidthA4Percent.size8);
                    GemboxUtils.Instance.SetWidthColIndex(4, widthColAttend);


                    GemboxUtils.Instance.AutoFixWidthColIndexEnd(1, configExportFile.GetSizePageA4Width());

                    //custom
                    GemboxUtils.Instance.AddTemplateHeader();
                    //export general information
                    String lbltitleLabelInfoMeetinginout = MessageValidate.GetMessage(rm, "lbltitleLabelInfoMeetinginout");
                    GemboxUtils.Instance.AddHeader(lbltitleLabelInfoMeetinginout == null ? string.Empty : lbltitleLabelInfoMeetinginout);

                    // int index = ConstantsEnum.positionIndexCol;//2
                    int index = ConstantsEnum.Instance.positionIndexForPrint;
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
                    String lblnumberPeopleInvited = MessageValidate.GetMessage(rm, "lblnumberPeopleInvitedFull");
                    //  value = (lblnumberPeopleInvited == null ? string.Empty : lblnumberPeopleInvited) + " "
                    //  + (txtnumberPeopleInvited.Text == null ? string.Empty : txtnumberPeopleInvited.Text.ToString());

                    //số lượng in excel: số khách đăng ký gồm: đăng ký trên web và số người đăng ký trên phần mềm (thêm vào)
                    int sumRegisterWeb = (txtnumberPeopleInvited.Text == null ? 0 : Convert.ToInt32(txtnumberPeopleInvited.Text.ToString()));
                    int sumRegisterClient = (txtnumberPeopleAdded.Text == null ? 0 : Convert.ToInt32(txtnumberPeopleAdded.Text.ToString()));

                    value = (lblnumberPeopleInvited == null ? string.Empty : lblnumberPeopleInvited) + " " + (sumRegisterWeb + sumRegisterClient);
                    //end

                    GemboxUtils.Instance.AddCellCustom(index, 0, value == null ? string.Empty : value);
                    value = "";
                    index++;

                    //String lblnumberPeopleAdded = MessageValidate.GetMessage(rm, "lblnumberPeopleAdded");
                    //value = (lblnumberPeopleAdded == null ? string.Empty : lblnumberPeopleAdded) + " " + (txtnumberPeopleAdded.Text == null ? string.Empty : txtnumberPeopleAdded.Text.ToString());
                    //GemboxUtils.Instance.AddCellCustom(index, 0, value == null ? string.Empty : value);
                    //value = "";
                    //index++;

                    //String lblnumberPeopleAttendInvited = MessageValidate.GetMessage(rm, "lblnumberPeopleAttendInvited");
                    //value = (lblnumberPeopleAttendInvited == null ? string.Empty : lblnumberPeopleAttendInvited) + " " + (txtnumberPeopleAttendInvited.Text == null ? string.Empty : txtnumberPeopleAttendInvited.Text.ToString());
                    //GemboxUtils.Instance.AddCellCustom(index, 0, value == null ? string.Empty : value);
                    //value = "";
                    //index++;

                    String lblnumberJournalist = MessageValidate.GetMessage(rm, "lblnumberJournalistFull");
                    value = (lblnumberJournalist == null ? string.Empty : lblnumberJournalist) + " " + (txtnumberJournalist.Text == null ? string.Empty : txtnumberJournalist.Text.ToString());
                    GemboxUtils.Instance.AddCellCustom(index, 0, value == null ? string.Empty : value);
                    value = "";
                    index++;

                    //String lblnumberNonresidentAttend = MessageValidate.GetMessage(rm, "lblnumberNonresidentAttend");
                    //value = (lblnumberNonresidentAttend == null ? string.Empty : lblnumberNonresidentAttend) + " "
                    //    + (txtnumberNonresidentAttend.Text == null ? string.Empty : txtnumberNonresidentAttend.Text.ToString());
                    //GemboxUtils.Instance.AddCellCustom(index, 0, value == null ? string.Empty : value);
                    //value = "";
                    //index++;

                    String lblnumberTotal = MessageValidate.GetMessage(rm, "lblnumberTotalFull");
                    value = (lblnumberTotal == null ? string.Empty : lblnumberTotal) + " " + (txtTotal.Text == null ? string.Empty : txtTotal.Text.ToString());
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

                    GemboxUtils.Instance.SetPortrait(false);
                    MessageBoxManager.ShowErrorMessageBox(this, ex.Message);
                    return;
                }
                GemboxUtils.Instance.SetPortrait(false);
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "smsLinkFile") + filePath);
            }
        }
        #endregion

        #region event
        /// <summary>
        /// click pager panel
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

            PersonAttendDetailObj personAttendDetailObjlistnew = LoadEventAttendMeetingAtPage(skip, take);
            if (personAttendDetailObjlistnew != null)
            {
                List<PersonAttendDetail> result = new List<PersonAttendDetail>();
                if (personAttendDetailObjlistnew.personAttendDetails != null)
                    result = personAttendDetailObjlistnew.personAttendDetails;

                //thông tin khách vãng lai tham dự họp
                if (personAttendDetailObjlistnew.nonresidentDetails != null)
                {

                    result.AddRange(AddListNonresident(personAttendDetailObjlistnew.nonresidentDetails));
                }
                //end thông tin khách vãng lai tham dự họp

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
