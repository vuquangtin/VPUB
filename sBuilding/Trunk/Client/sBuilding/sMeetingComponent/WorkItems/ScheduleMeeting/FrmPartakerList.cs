using ClientModel.Model;
using ClientModel.Utils;
using CommonControls;
using CommonControls.Custom;
using CommonHelper.Config;
using CommonHelper.Constants;
using CommonHelper.Utils;
using JavaCommunication;
using Microsoft.Practices.CompositeUI;
using Newtonsoft.Json;
using sExcelExportComponent.ClientModel.Enums;
using sMeetingComponent.Constants;
using sMeetingComponent.Model;
using sWorldModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Resources;
using System.Windows.Forms;

namespace sMeetingComponent.WorkItems.ScheduleMeeting
{
    #region CHƯA SỬ DỤNG: do không xem thành phần tham dự cuộc hop
    #endregion
    /// <summary>
    /// NOT USE
    /// </summary>
    public partial class FrmPartakerList : Form
    {

        #region Properties
        public string sysFormatDate;

        //   int take = LocalSettings.Instance.RecordsPerPage;
        private DataTable dtbEventListPartaker;
        String listPartakerNonresident;
        private int currentPageIndex = 1;
        List<PartakerObj> jsonListPartaker;

        public DialogPostAction PostAction { get; private set; }
        private ResourceManager rm;
        private MeetingComponentWorkItem workItem;
        [ServiceDependency]
        public MeetingComponentWorkItem WorkItem
        {
            set { workItem = value; }
        }

        private ILocalStorageService storageService;
        private EventMeeting eventMeetingInfo;

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
        /// FrmPartakerList
        /// </summary>
        /// <param name="eventMeetingInfo"></param>
        /// <param name="listPartakerNonresident"></param>
        public FrmPartakerList(EventMeeting eventMeetingInfo, string listPartakerNonresident)
        {
            this.eventMeetingInfo = eventMeetingInfo;
            this.listPartakerNonresident = listPartakerNonresident;
            InitializeComponent();
            InitDataTableEventListPartakers();
            sysFormatDate = UsrListMeeting.formatDateTime();

            RegisterEvent();
        }
        #endregion

        /// <summary>
        /// InitDataTableEventListPartakers
        /// </summary>
        private void InitDataTableEventListPartakers()
        {
            dtbEventListPartaker = new DataTable();
            dtbEventListPartaker.Columns.Add(colSTT.DataPropertyName);
            dtbEventListPartaker.Columns.Add(colNamePartaker.DataPropertyName);
            dtbEventListPartaker.Columns.Add(colNameOrg.DataPropertyName);
            dtbEventListPartaker.Columns.Add(colPositionPartaker.DataPropertyName);
            dtbEventListPartaker.Columns.Add(colCheck.DataPropertyName);
            dgvListAttend.DataSource = dtbEventListPartaker;
        }

        /// <summary>
        /// đăng ký sự kiện
        /// RegisterEvent
        /// </summary>
        private void RegisterEvent()
        {
            pagerPanel1.LinkLabelClicked += pagerPanel_LinkLabelClicked;
            btnExportToExcel.Click += btnExportToExcel_Click;
            LoadeetingInfo(eventMeetingInfo);
            Load += OnFormLoad;
        }

        /// <summary>
        /// HIển thị thông tin cuộc họp
        /// LoadeetingInfo
        /// Show info meeting
        /// </summary>
        /// <param name="eventMeetingInfo"></param>
        private void LoadeetingInfo(EventMeeting eventMeetingInfo)
        {
            if (eventMeetingInfo != null)
            {
                tbxOrgName.Text = eventMeetingInfo.organizationMeetingName;
                txtNameMeeting.Text = eventMeetingInfo.name;
                DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                DateTime startDateMeeting = DateTime.Now;
                startDateMeeting = start.AddMilliseconds(Convert.ToUInt64(eventMeetingInfo.startTime)).ToLocalTime();
                DateTime endDate = start.AddMilliseconds(Convert.ToUInt64(eventMeetingInfo.endTime)).ToLocalTime();
                DateTime datedefault = new DateTime(1971, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                // string sysFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;

                txtDate.Text = startDateMeeting.ToString(sysFormatDate);
                txtdtpDateIn.Text = startDateMeeting.ToString("HH:mm");
                txtdtpDateIn2.Text = endDate.ToString("HH:mm");

                // txtRoomname.Text = eventMeetingInfo.roomName.ToString();
                txtnote.Text = eventMeetingInfo.note == null ? string.Empty : eventMeetingInfo.note.ToString();
            }
        }

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
            pagerPanel1.StorageService = storageService;
            pagerPanel1.LoadLanguage();
            SetLanguages();

            FormatJsonPartaker(listPartakerNonresident);
        }

        /// <summary>
        /// SetLanguages
        /// </summary>
        private void SetLanguages()
        {
            this.colSTT.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colSTT.Name);
            this.colNamePartaker.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colNamePartaker.Name);
            this.colPositionPartaker.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colPositionPartaker.Name);
            this.colCheck.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colCheck.Name);
            this.colNameOrg.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colNameOrg.Name);
            this.btnExportToExcel.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnExportToExcel.Name);
        }

        #region Hiển thị danh sách người tham dự
        /// <summary>
        /// Lấy dabh sách người tham dự cuộc họp
        /// </summary>
        /// <param name="listPartakerNonresident"></param>
        private void FormatJsonPartaker(string listPartakerNonresident)
        {
            jsonListPartaker = new List<PartakerObj>();
            jsonListPartaker = JsonConvert.DeserializeObject<List<PartakerObj>>(listPartakerNonresident);
            int totalRecords = 0;
            currentPageIndex = 1;
            int take = LocalSettings.Instance.RecordsPerPage;
            int skip = 0;

            if (jsonListPartaker != null)
            {
                List<PartakerObj> result = jsonListPartaker.Skip(skip).Take(take).ToList();
                totalRecords = jsonListPartaker.Count;
                pagerPanel1.ShowNumberOfRecords(totalRecords, result != null ? result.Count : 0, take, currentPageIndex);
                pagerPanel1.UpdatePagingLinks(totalRecords, take, currentPageIndex);

                loadPartakersToTable(result);
            }
            else
            {
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "SmsNotInforAttendMeeting"));
                this.Close();
            }
        }

        /// <summary>
        /// show list partakers
        /// </summary>
        private void loadPartakersToTable(List<PartakerObj> partakerOtherList)
        { //xóa bảng trước khi init
            dtbEventListPartaker.Clear();
            int index = 0;
            //nếu có dữ liệu thêm người tham dự 
            if (partakerOtherList.Count > 0)
            {
                for (int i = 0; i < partakerOtherList.Count; i++)
                {
                    DataRow row = dtbEventListPartaker.NewRow();
                    row.BeginEdit();
                    index = i + 1;
                    row[colSTT.DataPropertyName] = index;
                    row[colNamePartaker.DataPropertyName] = partakerOtherList[i].name;
                    row[colNameOrg.DataPropertyName] = partakerOtherList[i].orgname;

                    row[colPositionPartaker.DataPropertyName] = partakerOtherList[i].position;
                    row[colCheck.DataPropertyName] = true;
                    row.EndEdit();
                    dtbEventListPartaker.Rows.Add(row);
                }
            }

            if (dgvListAttend.Rows.Count > 0)
            {
                //focur the first row in table
                btnExportToExcel.Enabled = true;
                dgvListAttend.Rows[0].Selected = true;
            }
            else
            {
                UploadStatusBarHavePagePanel();
            }
        }

        //cho phân trang thi vẫn còn hiển thị thanh link, và cho xuất exccel
        private void UploadStatusBarHavePagePanel()
        {
            // btnExportToExcel.Enabled = false;
            pagerPanel1.ShowMessage(MessageValidate.GetMessage(rm, "lblMessageNotData"));
            //  pagerPanel.UpdatePagingLinks(0, 1, 0);
        }
        #endregion

        #region Button Event's 
        private void btnExportToExcel_Click(object sender, EventArgs e)
        {

            //       String name = MessageValidate.GetMessage(rm, "lblListAttend") + "_" + tbxOrgName.Text.ToString() + "_" + txtNameMeeting.Text.ToString();//+ dateFroms.ToString("dd-MM-yyyy") + "_" + dateTos.ToString("dd-MM-yyyy");
            String name = MessageValidate.GetMessage(rm, "lblListAttend");//+ dateFroms.ToString("dd-MM-yyyy") + "_" + dateTos.ToString("dd-MM-yyyy");
            string filePath = ControlExtMethods.ShowSaveFileDialog(MessageValidate.GetMessage(rm, "smsChooseFileExport"), name, CategorizeExcel.Categorize);
            if (filePath != null)
            {
                try
                {   //   dgvListAttend.ExportToExcel(filePath);

                    //cach 1
                    //ExportToExcel(dgvListAttend, filePath);

                    ConfigExportFileModel configExportFile = new ConfigExportFileModel();
                    configExportFile.FilePath = filePath;
                    GemboxUtils.Instance.ExportDataGridToFileCustom(dgvListAttend, configExportFile, 9);//tua de, xuat file
                    GemboxUtils.Instance.ExportDataGridToFile(dgvListAttend.Rows.Count);//tua de, xuat file
                    GemboxUtils.Instance.AutoFix();

                    //custom
                    //export general information
                    String lblListAttend = MessageValidate.GetMessage(rm, "lblListAttend");
                    GemboxUtils.Instance.AddHeader(lblListAttend == null ? string.Empty : lblListAttend);
                    int index = ConstantsEnum.positionIndexCol;
                    String lblGoverningOrganization = MessageValidate.GetMessage(rm, "lblGoverningOrganization");
                    String value = (lblGoverningOrganization == null ? string.Empty : lblGoverningOrganization)
                        + " " + (tbxOrgName.Text == null ? string.Empty : tbxOrgName.Text.ToString());
                    GemboxUtils.Instance.AddCellCustom(index, 0, value == null ? string.Empty : value);
                    value = "";
                    index++;
                    String lblMeeting = MessageValidate.GetMessage(rm, "lblMeeting");
                    value = (lblMeeting == null ? string.Empty : lblMeeting)
                       + " " + (txtNameMeeting.Text == null ? string.Empty : txtNameMeeting.Text.ToString());
                    GemboxUtils.Instance.AddCellCustom(index, 0, value == null ? string.Empty : value);
                    value = "";
                    index++;
                    String lblTime = MessageValidate.GetMessage(rm, "lblTime");
                    value = (lblTime == null ? string.Empty : lblTime) + " " + (txtDate.Text == null ? string.Empty : txtDate.Text.ToString());
                    GemboxUtils.Instance.AddCellCustom(index, 0, value == null ? string.Empty : value);
                    value = ""; index++;
                    String lblHour = MessageValidate.GetMessage(rm, "lblHour");
                    value = (lblHour == null ? string.Empty : lblHour)
                        + " " + (txtdtpDateIn.Text == null ? string.Empty : txtdtpDateIn.Text.ToString());
                    String lblHourEnd = MessageValidate.GetMessage(rm, "lblHourEnd");
                    //GemboxUtils.Instance.AddCellCustom(index, 2, lblHourEnd == null ? string.Empty : lblHourEnd);
                    //GemboxUtils.Instance.AddCellCustom(index, 3, txtdtpDateIn2.Text == null ? string.Empty : txtdtpDateIn2.Text.ToString());
                    //giờ kết thúc
                    //   value += " " + (lblHourEnd == null ? string.Empty : lblHourEnd)
                    //     + " " + (txtdtpDateIn2.Text == null ? string.Empty : txtdtpDateIn2.Text.ToString());
                    GemboxUtils.Instance.AddCellCustom(index, 0, value == null ? string.Empty : value);
                    value = ""; index++;
                    String lblNotes = MessageValidate.GetMessage(rm, "lblNotes");
                    value = (lblNotes == null ? string.Empty : lblNotes) + " " + (txtnote.Text == null ? string.Empty : txtnote.Text.ToString());
                    GemboxUtils.Instance.AddCellCustom(index, 0, value == null ? string.Empty : value);
                    value = ""; index++;

                    GemboxUtils.Instance.AddCellCustom(index, 0, "");

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
            dtbEventListPartaker.Rows.Clear();
            int take = LocalSettings.Instance.RecordsPerPage;
            int skip = (currentPageIndex - 1) * take;

            List<PartakerObj> result = jsonListPartaker.Skip(skip).Take(take).ToList();
            pagerPanel1.ShowNumberOfRecords(jsonListPartaker.Count, result != null ? result.Count : 0, take, currentPageIndex);
            pagerPanel1.UpdatePagingLinks(jsonListPartaker.Count, take, currentPageIndex);

            loadPartakersToTable(result);
        }

        #endregion
    }
}


