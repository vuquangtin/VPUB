using CommonControls;
using CommonHelper.Constants;
using CommonHelper.Utils;
using Microsoft.Practices.CompositeUI;
using sTimeKeeping.Constants;
using sTimeKeeping.Factory;
using sTimeKeeping.Model;
using sWorldModel;
using sWorldModel.Exceptions;
using sWorldModel.TransportData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Resources;
using System.ServiceModel;
using System.Windows.Forms;

namespace sTimeKeeping.WorkItems {
    public partial class FrmDayOffConfig : CommonControls.Custom.CommonDialog {
        #region Properties
        private byte OperatingMode;
        public const byte ModeAdding = 1;
        public const byte ModeUpdating = 2;

        // Biến để bỏ qua TextBoxChange
        bool skipTextChange = false;

        // Var này để lưu id status trước khi user chọn và id status sau khi user chọn
        int statusBefore = 0;
        int statusAfter = 0;

        DayOffConfig doConfigObj;
        List<long> listMemberId;
        long doConfigId;
        long subOrgId;

        // For monthly calculation
        string dateTemp;

        // List data dùng để lưu data khi user thao tác trên control
        List<string> listDate = new List<string>();
        List<int> listStatus = new List<int>();
        List<string> listDateBase = new List<string>();
        List<int> listStatusBase = new List<int>();
        DateTimePicker dpTemp = new DateTimePicker();
        string dateFormatWithSlash = "dd'/'MM'/'yyyy";
        string dateFormatWithoutSlash = "ddMMyyyy";
        string dateFormatForDateTimePicker = "dd/MM/yyyy";

        // Member List
        private DataTable dtbMemberList;
        long memberId;

        private BackgroundWorker bgwGetListMemberBySubOrgId, bgwSetDayOff,
            bgwUpdateDayOff, bgwGetDayOffById;

        private ResourceManager rm;
        private TimeKeepingComponentWorkItem workItem;
        [ServiceDependency]
        public TimeKeepingComponentWorkItem WorkItem {
            set { workItem = value; }
        }

        private ILocalStorageService storageService;
        public ILocalStorageService StorageService {
            get {
                if (storageService == null) {
                    storageService = workItem.Services.Get<ILocalStorageService>();
                }
                return storageService;
            }
        }
        #endregion

        #region Contructors
        public FrmDayOffConfig(byte operationMode, long subOrgId, long doConfigId) {
            InitializeComponent();
            OperatingMode = operationMode;
            this.subOrgId = subOrgId;
            this.doConfigId = doConfigId;
            registerEvent();
            initDataTableListMember();
        }

        private void registerEvent() {
            // Nút Xác nhận - Hủy bỏ
            btnConfirm.Click += btnConfirm_Click;
            btnRefresh.Click += btnRefresh_Click;
            btnCancel.Click += btnCancel_Click;

            // Bắt sự kiện ngày thay đổi cho DateTimePicker
            dpDateStart.ValueChanged += dpDateStart_ValueChanged;
            dpDateEnd.ValueChanged += dpDateEnd_ValueChanged;

            // 3 checkbox
            cbxHalfDayOff.Click += cbxHalfDayOff_Click;
            cbxFullDayOff.Click += cbxFullDayOff_Click;

            // Backgroundworker Load Member List
            bgwGetListMemberBySubOrgId = new BackgroundWorker();
            bgwGetListMemberBySubOrgId.WorkerSupportsCancellation = true;
            bgwGetListMemberBySubOrgId.DoWork += bgwGetListMemberBySubOrgId_DoWork;
            bgwGetListMemberBySubOrgId.RunWorkerCompleted += bgwGetListMemberBySubOrgId_RunWorkerCompleted;

            // Backgroundworker Insert Day Off Config
            bgwSetDayOff = new BackgroundWorker();
            bgwSetDayOff.WorkerSupportsCancellation = true;
            bgwSetDayOff.DoWork += bgwSetDayOff_DoWork;
            bgwSetDayOff.RunWorkerCompleted += bgwSetDayOff_RunWorkerCompleted;

            // Backgroundworker Update Day Off Config
            bgwUpdateDayOff = new BackgroundWorker();
            bgwUpdateDayOff.WorkerSupportsCancellation = true;
            bgwUpdateDayOff.DoWork += bgwUpdateDayOff_DoWork;
            bgwUpdateDayOff.RunWorkerCompleted += bgwUpdateDayOff_RunWorkerCompleted;

            // Backgroundworker Load Day Off Config by doConfigId
            bgwGetDayOffById = new BackgroundWorker();
            bgwGetDayOffById.WorkerSupportsCancellation = true;
            bgwGetDayOffById.DoWork += bgwGetDayOffById_DoWork;
            bgwGetDayOffById.RunWorkerCompleted += bgwGetDayOffById_RunWorkerCompleted;

            // 2 Texbox search
            tbxFilterByMemberName.TextChanged += tbxFilterByMemberName_TextChanged;
            tbxFilterByMemberCode.TextChanged += tbxFilterByMemberCode_TextChanged;
        }

        protected override void OnLoad(EventArgs e) {
            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);

            dpDateStart.Select();
            dpDateStart.Enabled = true;
            if (OperatingMode == ModeAdding) {
                // Mặc định CheckBox nghỉ cả ngày
                statusBefore = Convert.ToInt32(DOStatus.full_day_off);
                checkBox(statusBefore);
                getListMemberBySubOrgId();
                dpDateEnd.Enabled = true;
                setListDateAndStatus();
            } else {
                loadDayOffConfigById();
                tbxFilterByMemberName.Enabled = tbxFilterByMemberCode.Enabled =
                    btnRefresh.Enabled = false;
            }

            // Set Language cho Form
            setLanguage();

            // Set max length
            tbxFilterByMemberCode.MaxLength = ConstantsValue.MAX_LENGTH_TEXT_BOX_VAR_CHAR;
            tbxFilterByMemberName.MaxLength = ConstantsValue.MAX_LENGTH_TEXT_BOX_VAR_CHAR;
        }
        #endregion

        #region Set Language
        private void setLanguage() {
            btnCancel.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, btnCancel.Name);
            btnConfirm.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, btnConfirm.Name);
            btnRefresh.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, btnRefresh.Name);
            cbxFullDayOff.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, cbxFullDayOff.Name);
            cbxHalfDayOff.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, cbxHalfDayOff.Name);
            colMemCode.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, colMemCode.Name);
            colMemberName.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, colMemberName.Name);
            if (OperatingMode == ModeUpdating) {
                Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, Name + "_Update");
                lblDayOffConfig.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblDayOffConfig.Name + "_Update");
                lblNoteDayOff.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblNoteDayOff.Name + "_Update");
            } else {
                Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, Name);
                lblDayOffConfig.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblDayOffConfig.Name);
                lblNoteDayOff.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblNoteDayOff.Name);
            }
            lblDateBegin.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblDateBegin.Name);
            lblDateEnd.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblDateEnd.Name);
            lblDayOffStatus.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblDayOffStatus.Name);
            lblDetail.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblDetail.Name);
            lblFilterByMemberCode.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblFilterByMemberCode.Name);
            lblFilterByMemberName.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblFilterByMemberName.Name);
            lblMust.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblMust.Name);
        }
        #endregion

        #region Set DataGridView Member
        /// <summary>
        /// Tạo DataTable để lưu trữ data cho DataGridView
        /// </summary>
        private void initDataTableListMember() {
            dtbMemberList = new DataTable();

            dtbMemberList.Columns.Add(colMemberId.DataPropertyName);
            dtbMemberList.Columns.Add(colMemberNo.DataPropertyName);
            dtbMemberList.Columns.Add(colMemCode.DataPropertyName);
            dtbMemberList.Columns.Add(colMemberName.DataPropertyName);

            dgvMember.DataSource = dtbMemberList;
        }

        /// <summary>
        /// Load member get được từ server vào DataGridView
        /// </summary>
        /// <param name="listMember"></param>
        private void setMemberToDataGridView(List<Member> listMember) {
            int noNumber = 0;
            foreach (Member member in listMember) {
                noNumber++;
                DataRow row = dtbMemberList.NewRow();
                row.BeginEdit();

                row[colMemberId.DataPropertyName] = member.Id;
                row[colMemberNo.DataPropertyName] = noNumber;
                row[colMemCode.DataPropertyName] = member.Code;
                row[colMemberName.DataPropertyName] = member.LastName + " " + member.FirstName;

                row.EndEdit();
                dtbMemberList.Rows.Add(row);
            }
        }
        #endregion

        #region Button's Events
        /// <summary>
        /// Ấn nút xác nhận
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e) {
            string addOrUpdateDayOffCheck = "";

            switch (OperatingMode) {
                case ModeAdding:
                    addOrUpdateDayOffCheck = "AddDayOffCheck";
                    break;
                case ModeUpdating:
                    addOrUpdateDayOffCheck = "UpdateDayOffCheck";
                    break;
                default:
                    break;
            }
            if (MessageBoxManager.ShowQuestionMessageBox(this,
                            MessageValidate.GetMessage(rm, addOrUpdateDayOffCheck)) == DialogResult.Yes) {
                saveDayOffConfig();
            }
        }

        /// <summary>
        /// Ấn nút làm mới
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e) {
            uncheckAllCheckBox();
            statusBefore = Convert.ToInt32(DOStatus.full_day_off);
            checkBox(statusBefore);
            dpDateStart.Select();
            tbxFilterByMemberName.Text = tbxFilterByMemberCode.Text = String.Empty;
        }

        /// <summary>
        /// Ấn nút hủy bỏ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e) {
            Close();
        }

        /// <summary>
        /// Ấn CheckBox nghỉ nửa ngày
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxHalfDayOff_Click(object sender, EventArgs e) {
            statusClick(Convert.ToInt32(DOStatus.half_day_off));
            if (OperatingMode == ModeAdding) {
                setListDateAndStatus();
            }
        }

        /// <summary>
        /// Ấn CheckBox nghỉ cả ngày
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxFullDayOff_Click(object sender, EventArgs e) {
            statusClick(Convert.ToInt32(DOStatus.full_day_off));
            if (OperatingMode == ModeAdding) {
                setListDateAndStatus();
            }
        }
        #endregion

        #region ButtonEvent's Support
        /// <summary>
        /// Lưu cấu hình của ngày nghỉ đã đăng ký
        /// </summary>
        private void saveDayOffConfig() {
            if (statusBefore == 0) {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "StatusNotChecked"));
            } else {
                switch (OperatingMode) {
                    case ModeAdding:
                        setDayOffConfig();
                        break;
                    case ModeUpdating:
                        doConfigObj = ToEntity();
                        updateDayOffConfig();
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Lưu lại list date và status khi được cấu hình mới
        /// Lưu những ngày từ dpStart đến dpEnd
        /// </summary>
        private void setListDateAndStatus() {
            listDate = new List<string>();
            listStatus = new List<int>();
            DateTime startDate = dpDateStart.Value.Date;
            DateTime endDate = dpDateEnd.Value.Date;

            // Vòng lập để gán lại listDate và listStatus trở lại như trên database
            // Khôi phục lại
            for (int i = 0; i < listDateBase.Count; i++) {
                listDate[i] = listDateBase[i];
                listStatus[i] = listStatusBase[i];
            }
            // Vòng lập để lưu lại list các ngày từ 1 ngày nào đó tới 1 ngày nào đó
            for (DateTime betweenDate = startDate; betweenDate <= endDate; betweenDate = betweenDate.AddDays(1)) {
                // Tìm trong listDate xem betweenDate có nằm trong đó không
                int checkPosition = listDate.IndexOf(betweenDate.ToString(dateFormatWithSlash));
                // Nếu chưa có thì add ngày đó vào listDate
                // Ngày chủ nhật được nghỉ nên sẽ skip ngày chủ nhật
                if (betweenDate.DayOfWeek != DayOfWeek.Sunday && checkPosition < 0) {
                    listDate.Add(betweenDate.ToString(dateFormatWithSlash));
                    listStatus.Add(statusBefore);
                } else if (checkPosition >= 0) {
                    // Nếu ngày đó đã có trong listDate rồi
                    // Thì cập nhật lại status tại vị trí của ngày đó
                    listStatus[checkPosition] = statusBefore;
                }
            }
        }

        /// <summary>
        /// Add những memberId vào listMemberId
        /// Sau đó dùng listMemberId insert/update Day Off theo từng memberId lên database
        /// </summary>
        private void setDayOffConfig() {
            listMemberId = new List<long>();

            foreach (DataGridViewRow selectedRowForDelete in dgvMember.SelectedRows) {
                memberId = Convert.ToInt64(selectedRowForDelete.Cells[colMemberId.Name].Value.ToString());

                listMemberId.Add(memberId);
            }
            // Có id rồi thì chạy BackgroundWorker Set DayOff
            if (!bgwSetDayOff.IsBusy) {
                bgwSetDayOff.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Update Day Off
        /// </summary>
        private void updateDayOffConfig() {
            if (!bgwUpdateDayOff.IsBusy) {
                bgwUpdateDayOff.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Load Day Off by id
        /// </summary>
        private void loadDayOffConfigById() {
            if (!bgwGetDayOffById.IsBusy) {
                dtbMemberList.Rows.Clear();
                bgwGetDayOffById.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Kiểm tra khi người dùng đang update một ngày, chọn lại ngày khác nhưng
        /// ngày mới chọn đã được cấu hình từ trước rồi
        /// </summary>
        private void checkDayOffAlreadyExist() {
            // Lấy DayOff theo memberId và date
            DayOffConfig doConfigCheck = TimeKeepingDayOffConfigFactory.Instance.GetChannel()
                .getDayOffByMemberIdAndDate(StorageService.CurrentSessionId, memberId, dpDateStart.Value.Date.ToString(dateFormatWithoutSlash));

            // Nếu như date đó chưa được đăng ký
            // thì cho người dùng thao tác bình thường
            // còn nếu có rồi thì hiện thông báo cho người dùng biết ngày này đã được đăng ký
            if (null != doConfigCheck) {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "DayOffAlreadyExist"));
                // Gán lại giá trị ban đầu cho các control
                dpDateStart.Value = DateTime.ParseExact(doConfigObj.date, dateFormatForDateTimePicker, null);
                checkBox(doConfigObj.status);
                statusBefore = doConfigObj.status;
            }
        }

        /// <summary>
        /// Get danh sách member theo subOrgId
        /// </summary>
        private void getListMemberBySubOrgId() {
            if (!bgwGetListMemberBySubOrgId.IsBusy) {
                dtbMemberList.Rows.Clear();
                bgwGetListMemberBySubOrgId.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Thay đổi 2 ô CheckBox trạng thái
        /// </summary>
        private void changeDayOffStatus() {
            if (statusBefore != statusAfter) {
                // Chuyển status đang chọn lại bình thường (uncheck) khi chọn status khác
                uncheckBox(statusBefore);
                // Check status mới được ấn
                checkBox(statusAfter);

                statusBefore = statusAfter;
                statusAfter = 0;
            }
        }
        #endregion

        #region Events
        /// <summary>
        /// Trả về DayOffConfig object cuối cùng để update lên database
        /// </summary>
        /// <returns></returns>
        private DayOffConfig ToEntity() {
            DayOffConfig doConfig = new DayOffConfig();

            doConfig.dayOffConfigId = doConfigId;
            doConfig.memberId = memberId;
            doConfig.date = dpDateStart.Value.Date.ToString(dateFormatWithSlash);
            doConfig.status = statusBefore;
            doConfig.subOrgId = subOrgId;

            return doConfig;
        }

        /// <summary>
        /// Khi những checkbox status được nhấn
        /// </summary>
        /// <param name="status"></param>
        private void statusClick(int status) {
            // Kiểm tra xem nếu người dùng check ngược lại ô đang check thì uncheck ô đó
            if (statusBefore == status) {
                uncheckAllCheckBox();
                statusBefore = statusAfter = 0;
            } else {
                statusAfter = status;
                changeDayOffStatus();
            }
        }

        /// <summary>
        /// DateTimePicker dpDateStart đổi giá trị
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dpDateStart_ValueChanged(object sender, EventArgs e) {
            if (dpDateEnd.Value.Date < dpDateStart.Value.Date) {
                dpDateEnd.Value = dpDateStart.Value;
            }

            switch (OperatingMode) {
                case ModeAdding:
                    setListDateAndStatus();
                    break;
                case ModeUpdating:
                    if (dpDateStart.Value != dpTemp.Value) {
                        // Kiểm tra xem ngày người dùng mới chọn có được đăng ký chưa
                        // Rồi thông báo cho người dùng biết
                        checkDayOffAlreadyExist();
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// DateTimePicker dpDateEnd đổi giá trị
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dpDateEnd_ValueChanged(object sender, EventArgs e) {
            if (dpDateEnd.Value.Date < dpDateStart.Value.Date) {
                dpDateEnd.Value = dpDateStart.Value;
            }

            switch (OperatingMode) {
                case ModeAdding:
                    setListDateAndStatus();
                    break;
                case ModeUpdating:
                    uncheckAllCheckBox();
                    if (dpDateEnd.Value.Date == dpDateStart.Value.Date) {
                        // Tìm thử xem ngày hiện tại đang chọn có trong listDate chưa
                        int checkPosition = listDate.IndexOf(dpDateEnd.Value.Date.ToString(dateFormatWithSlash));
                        // Nếu có rồi thì lấy status của ngày đó từ trong listStatus ra
                        if (checkPosition >= 0) {
                            checkBox(listStatus[checkPosition]);
                        }
                    } else if (dpDateEnd.Value.Date < dpDateStart.Value.Date) {
                        dpDateEnd.Value = dpDateStart.Value;
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Search theo tên nhân viên trong DataGridView danh sách ngày nghỉ
        /// Nhận từng chữ người dùng nhập vào TextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxFilterByMemberName_TextChanged(object sender, EventArgs e) {
            if (skipTextChange) {
                return;
            }

            if (tbxFilterByMemberCode.Text != String.Empty) {
                skipTextChange = true;
                tbxFilterByMemberCode.Clear();
                skipTextChange = false;
            }
            DataView dv = new DataView(dtbMemberList);
            string strData = FormatCharacterSearch.CheckValue(tbxFilterByMemberName.Text.Trim());
            dv.RowFilter = string.Format(colMemberName.DataPropertyName + " LIKE '%{0}%'", strData);
            dgvMember.DataSource = dv;
            if (dv.Count == 0) {
                btnConfirm.Enabled = false;
            } else {
                btnConfirm.Enabled = true;
            }
        }


        /// <summary>
        /// Search theo mã nhân viên trong datagridview danh sách ngày nghỉ
        /// Nhận từng chữ người dùng nhập vào TextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxFilterByMemberCode_TextChanged(object sender, EventArgs e) {
            if (skipTextChange) {
                return;
            }

            if (tbxFilterByMemberName.Text != String.Empty) {
                skipTextChange = true;
                tbxFilterByMemberName.Clear();
                skipTextChange = false;
            }
            DataView dv = new DataView(dtbMemberList);
            string strData = FormatCharacterSearch.CheckValue(tbxFilterByMemberCode.Text.Trim());
            dv.RowFilter = string.Format(colMemCode.DataPropertyName + " LIKE '%{0}%'", strData);
            dgvMember.DataSource = dv;
            if (dv.Count == 0) {
                btnConfirm.Enabled = false;
            } else {
                btnConfirm.Enabled = true;
            }
        }

        /// <summary>
        /// Uncheck hết các CheckBox ở trong control
        /// </summary>
        private void uncheckAllCheckBox() {
            cbxHalfDayOff.Checked = cbxFullDayOff.Checked = false;
            statusBefore = statusAfter = 0;
        }

        /// <summary>
        /// Uncheck một ô CheckBox nào đó
        /// </summary>
        /// <param name="status"></param>
        private void uncheckBox(int status) {
            switch (status) {
                case 1:
                    cbxHalfDayOff.Checked = false;
                    break;
                case 2:
                    cbxFullDayOff.Checked = false;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Check vào một ô CheckBox nào đó
        /// </summary>
        /// <param name="status"></param>
        private void checkBox(int status) {
            switch (status) {
                case 1:
                    cbxHalfDayOff.Checked = true;
                    break;
                case 2:
                    cbxFullDayOff.Checked = true;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Trả về dòng đang chọn hiện tại trong DataGridView dgvMember
        /// </summary>
        /// <returns></returns>
        private DataGridViewRow CurrentRow() {
            // Dòng đang được chọn hiện tại trong DataGridView
            int rowChooseIndex = dgvMember.CurrentCell.RowIndex;
            DataGridViewRow currentRow = dgvMember.Rows[rowChooseIndex];

            return currentRow;
        }

        /// <summary>
        /// Update lại thống kê chấm công theo tháng
        /// </summary>
        /// <param name="session"></param>
        /// <param name="dateStart"></param>
        /// <param name="dateEnd"></param>
        /// <param name="listMemberId"></param>
        private void reUpdateMonthlyReport(string session, string dateStart, string dateEnd, List<long> listMemberId) {
            int result = TimeKeepingFactory.Instance.GetChannel()
                .insertOrUpdateMonthlyReport(session, dateStart, dateEnd, listMemberId);
        }
        #endregion

        #region Background Worker
        #region Get Member List
        // Load Member list
        private void bgwGetListMemberBySubOrgId_DoWork(object sender, DoWorkEventArgs e) {
            List<Member> result = new List<Member>();

            try {
                result = TimeKeepingDayOffConfigFactory.Instance.GetChannel().getMemberBySubOrgId(StorageService.CurrentSessionId, subOrgId);
            } catch (TimeoutException) {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "TimeOutExceptionMessage"));
            } catch (FaultException<WcfServiceFault> ex) {
                MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
            } catch (FaultException ex) {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "FaultExceptionMessage")
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
            } catch (CommunicationException) {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "CommunicationExceptionMessage"));
            } finally {
                e.Result = result;
            }
        }

        private void bgwGetListMemberBySubOrgId_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (e.Cancelled) {
                return;
            }
            if (e.Result == null) {
                return;
            }

            // Lấy danh sách member từ DoWork
            List<Member> result = (List<Member>) e.Result;

            // Nếu danh sách member không rỗng thì load vào DataGridView
            if (result.Count > 0) {
                setMemberToDataGridView(result);
                memberId = Convert.ToInt64(CurrentRow().Cells[colMemberId.Name].Value.ToString());
            } else {
                btnConfirm.Enabled = false;
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "NullMemberList"));
                return;
            }
        }
        #endregion

        #region Set DayOff Config
        private void bgwSetDayOff_DoWork(object sender, DoWorkEventArgs e) {
            try {
                foreach (long memberId in listMemberId) {
                    for (int i = 0; i < listDate.Count; i++) {
                        DayOffConfig doConfig = new DayOffConfig();

                        doConfig.memberId = memberId;
                        doConfig.date = listDate[i];
                        doConfig.status = listStatus[i];
                        doConfig.subOrgId = subOrgId;
                        e.Result = TimeKeepingDayOffConfigFactory.Instance.GetChannel()
                            .insertOrUpdateDayOffByListMemberId(StorageService.CurrentSessionId, doConfig);
                    }
                }
            } catch (TimeoutException) {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "TimeOutExceptionMessage"));
            } catch (FaultException<WcfServiceFault> ex) {
                MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
            } catch (FaultException ex) {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "FaultExceptionMessage")
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
            } catch (CommunicationException) {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "CommunicationExceptionMessage"));
            }
        }

        private void bgwSetDayOff_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (e.Cancelled) {
                return;
            }

            if (null != e.Result) {
                // Update lại thống kê chấm công theo tháng
                reUpdateMonthlyReport(StorageService.CurrentSessionId,
                    DateTime.ParseExact(listDate[0], dateFormatForDateTimePicker, null).ToString("yyyy-MM-dd"),
                    DateTime.ParseExact(listDate[listDate.Count - 1], dateFormatForDateTimePicker, null).ToString("yyyy-MM-dd"),
                    listMemberId);
                Close();
            } else {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "InsertFail"));
            }
        }
        #endregion

        #region Update DayOffConfig
        private void bgwUpdateDayOff_DoWork(object sender, DoWorkEventArgs e) {
            DayOffConfig result = null;

            try {
                result = TimeKeepingDayOffConfigFactory.Instance.GetChannel().updateDayOffConfig(StorageService.CurrentSessionId, doConfigObj);
            } catch (TimeoutException) {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "TimeOutExceptionMessage"));
            } catch (FaultException<WcfServiceFault> ex) {
                MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
            } catch (FaultException ex) {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "FaultExceptionMessage")
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
            } catch (CommunicationException) {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "CommunicationExceptionMessage"));
            } finally {
                e.Result = result;
            }
        }

        private void bgwUpdateDayOff_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (e.Cancelled) {
                return;
            }

            if (null != e.Result) {
                DayOffConfig doConfig = (DayOffConfig) e.Result;
                listMemberId = new List<long>();
                listMemberId.Add(doConfig.memberId);
                // Update lại thống kê chấm công theo tháng
                reUpdateMonthlyReport(StorageService.CurrentSessionId,
                    DateTime.ParseExact(doConfig.date, dateFormatForDateTimePicker, null).ToString("yyyy-MM-dd"),
                    DateTime.ParseExact(doConfig.date, dateFormatForDateTimePicker, null).ToString("yyyy-MM-dd"),
                    listMemberId);
                reUpdateMonthlyReport(StorageService.CurrentSessionId,
                    DateTime.ParseExact(dateTemp, dateFormatForDateTimePicker, null).ToString("yyyy-MM-dd"),
                    DateTime.ParseExact(dateTemp, dateFormatForDateTimePicker, null).ToString("yyyy-MM-dd"),
                    listMemberId);
                Close();
            } else {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "InsertFail"));
            }
        }
        #endregion

        #region Get DayOff Config By doConfigId
        private void bgwGetDayOffById_DoWork(object sender, DoWorkEventArgs e) {
            try {
                e.Result = TimeKeepingDayOffConfigFactory.Instance.GetChannel().getDayOffConfigById(StorageService.CurrentSessionId, doConfigId);
            } catch (TimeoutException) {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "TimeOutExceptionMessage"));
            } catch (FaultException<WcfServiceFault> ex) {
                MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
            } catch (FaultException ex) {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "FaultExceptionMessage")
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
            } catch (CommunicationException) {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "CommunicationExceptionMessage"));
            }
        }

        private void bgwGetDayOffById_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (e.Cancelled) {
                return;
            }

            if (null == e.Result) {
                return;
            }

            DayOffConfig doConfig = (DayOffConfig) e.Result;
            List<DayOffConfig> listDayOff = new List<DayOffConfig>();
            listDayOff.Add(doConfig);
            doConfigObj = doConfig;
            // Lưu dữ liệu
            storeData(listDayOff);
            initDataToControl(doConfig);
            dpTemp.Value = dpDateStart.Value;
        }
        #endregion
        #endregion

        #region Data Control
        /// <summary>
        /// Load dữ liệu vào control/form nếu có dữ liệu
        /// </summary>
        /// <param name="doConfig"></param>
        private void initDataToControl(DayOffConfig doConfig) {
            Member member = TimeKeepingDayOffConfigFactory.Instance.GetChannel().getMemberById(StorageService.CurrentSessionId, doConfig.memberId);
            List<Member> listMember = new List<Member>();
            dateTemp = doConfig.date;

            listMember.Add(member);
            // Gán ngày của object cho 2 dateTimePicker
            dpDateStart.Value = DateTime.ParseExact(doConfig.date, dateFormatForDateTimePicker, null);
            dpDateEnd.Value = DateTime.ParseExact(doConfig.date, dateFormatForDateTimePicker, null);
            // Lấy status của object để check vào 2 checkbox status
            if (doConfig.status == Convert.ToInt32(DOStatus.half_day_off)) {
                cbxHalfDayOff.Checked = true;
            } else if (doConfig.status == Convert.ToInt32(DOStatus.full_day_off)) {
                cbxFullDayOff.Checked = true;
            }
            statusBefore = doConfig.status;
            setMemberToDataGridView(listMember);
            if (dgvMember.RowCount > 0) {
                memberId = Convert.ToInt64(CurrentRow().Cells[colMemberId.Name].Value.ToString());
            }
        }

        /// <summary>
        /// Lưu lại những dayoff config (ngày và trạng thái) vào 2 list: listDate và listStatus
        /// sau khi get từ server về
        /// </summary>
        /// <param name="listDayOffCurrentMember"></param>
        private void storeData(List<DayOffConfig> listDayOffCurrentMember) {
            listDate = new List<string>();
            listStatus = new List<int>();
            listDateBase = new List<string>();
            listStatusBase = new List<int>();

            if (listDayOffCurrentMember != null) {
                foreach (DayOffConfig doConfig in listDayOffCurrentMember) {
                    listDate.Add(doConfig.date);
                    listStatus.Add(doConfig.status);

                    // Lưu lại cấu hình từ database để dễ hồi phục
                    listDateBase.Add(doConfig.date);
                    listStatusBase.Add(doConfig.status);
                }
            }
        }
        #endregion
    }
}
