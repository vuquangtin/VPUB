using System.Data;
using Microsoft.Practices.CompositeUI.Commands;
using sTimeKeeping.Constants;
using System;
using CommonHelper.Constants;
using CommonHelper.Utils;
using System.Resources;
using Microsoft.Practices.CompositeUI;
using sWorldModel;
using CommonControls.Custom;
using System.Collections.Generic;
using sTimeKeeping.Model;
using System.ComponentModel;
using sTimeKeeping.Factory;
using sWorldModel.Exceptions;
using CommonControls;
using System.ServiceModel;
using System.Windows.Forms;
using System.Drawing;
using sWorldModel.TransportData;
using JavaCommunication.Factory;
using sWorldModel.Filters;
using CommonHelper.Config;

namespace sTimeKeeping.WorkItems {
    public partial class UsrHolidayConfig : CommonUserControl {
        #region Properties
        // Var để kiểm tra người dùng đang thao tác add hay update hay delete
        private int menuButtonMode;
        // Số dòng đang được chọn
        int rowSelectedCount;
        // Hàng thứ mấy đã được chọn
        int rowChooseIndex;
        // Hàng thứ mấy đang được chọn
        int rowSelectIndex;

        long holidayId;
        long orgId;

        // For filter Holiday
        string dateStart;
        string dateEnd;
        string dateFormatWithoutSlash = "ddMMyyyy";
        string dateFormatForDateTimePicker = "dd/MM/yyyy";

        // For month calculator
        List<HolidayConfig> listHoliday;

        // Holiday List
        private DataTable dtbListHoliday;
        List<long> listHolidayId;

        // Tree View
        private TreeNode selectedOrgNode;
        private TreeNode rootNode;
        private Font startupNodeFont;

        private BackgroundWorker bgwLoadOrgList, bgwDeleteHoliday, bgwFilterHoliday;

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
        public UsrHolidayConfig() {
            InitializeComponent();
            registerEvent();
            initTreeView();
            initDataTableHolidayConfig();
        }

        private void registerEvent() {
            // Tree View
            tvOrganizationList.BeforeSelect += tvOrganizationList_BeforeSelect;
            tvOrganizationList.AfterSelect += tvOrganizationList_AfterSelect;

            // Nút Add - Update - Delete - Refresh Holiday
            btnAddHolidayConfig.Click += btnAddHolidayConfig_Click;
            btnUpdateHolidayConfig.Click += btnUpdateHolidayConfig_Click;
            btnDeleteHolidayConfig.Click += btnDeleteHolidayConfig_Click;
            btnRefreshHolidayConfig.Click += btnRefreshHolidayConfig_Click;

            // Refresh Organizations
            startupNodeFont = tvOrganizationList.Font;
            btnRefreshOrg.Click += btnRefreshOrg_Click;

            // Backgroundworker load organization list
            bgwLoadOrgList = new BackgroundWorker();
            bgwLoadOrgList.WorkerSupportsCancellation = true;
            bgwLoadOrgList.DoWork += bgwLoadOrgList_DoWork;
            bgwLoadOrgList.RunWorkerCompleted += bgwLoadOrgList_RunWorkerCompleted;

            // Backgroundworker delete
            bgwDeleteHoliday = new BackgroundWorker();
            bgwDeleteHoliday.WorkerSupportsCancellation = true;
            bgwDeleteHoliday.DoWork += bgwDeleteHoliday_DoWork;
            bgwDeleteHoliday.RunWorkerCompleted += bgwDeleteHoliday_RunWorkerCompleted;

            // Backgroundworker filter
            bgwFilterHoliday = new BackgroundWorker();
            bgwFilterHoliday.WorkerSupportsCancellation = true;
            bgwFilterHoliday.DoWork += bgwFilterHoliday_DoWork;
            bgwFilterHoliday.RunWorkerCompleted += bgwFilterHoliday_RunWorkerCompleted;

            // DateTimePicker ValueChange cho dpStart và dpEnd
            dpHolidayStart.ValueChanged += dpHolidayStart_ValueChanged;
            dpHolidayEnd.ValueChanged += dpHolidayEnd_ValueChanged;

            // Sự kiện bắt trong DataGridView
            dgvListHoliday.CellDoubleClick += dgvListHoliday_CellDoubleClick;
            dgvListHoliday.MouseDown += dgvListHoliday_MouseDown;

            // Chuột phải vào DataGridView
            miAddHoliday.Click += miAddHoliday_Click;
            miUpdateHoliday.Click += miUpdateHoliday_Click;
            miDeleteHoliday.Click += miDeleteHoliday_Click;
            miRefreshHoliday.Click += miRefreshHoliday_Click;
        }

        protected override void OnLoad(EventArgs e) {
            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls , rm);
            loadListOrgToTreeView();

            // Set DateTimePicker Start and End
            setDateTimePicker();
            // Set Language
            setLanguage();
        }
        #endregion

        #region Set Language
        private void setLanguage() {
            //20170305 #Bug #734 Fix Toolbar menu - Minh Nguyen Start
            btnAddHolidayConfig.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm , btnAddHolidayConfig.Name);
            btnAddHolidayConfig.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm , btnAddHolidayConfig.Name);
            btnDeleteHolidayConfig.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm , btnDeleteHolidayConfig.Name);
            btnDeleteHolidayConfig.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm , btnDeleteHolidayConfig.Name);
            btnRefreshHolidayConfig.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm , btnRefreshHolidayConfig.Name);
            btnRefreshHolidayConfig.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm , btnRefreshHolidayConfig.Name);
            btnRefreshOrg.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm , btnRefreshOrg.Name);
            btnRefreshOrg.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm , btnRefreshOrg.Name);
            btnUpdateHolidayConfig.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm , btnUpdateHolidayConfig.Name);
            //20170305 #Bug #734 Fix Toolbar menu - Minh Nguyen End
            btnUpdateHolidayConfig.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm , btnUpdateHolidayConfig.Name);
            colHolidayNo.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm , colHolidayNo.Name);
            colDescription.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm , colDescription.Name);
            colHolidayEnd.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm , colHolidayEnd.Name);
            colHolidayName.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm , colHolidayName.Name);
            colHolidayStart.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm , colHolidayStart.Name);
            lblFilterByCondition.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm , lblFilterByCondition.Name);
            lblDateEnd.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm , lblDateEnd.Name);
            lblDateBegin.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm , lblDateBegin.Name);
            lblLeftAreaTitleOrg.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm , lblLeftAreaTitleOrg.Name);
            lblRightAreaTitleHolidayConfig.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm , lblRightAreaTitleHolidayConfig.Name);
            miAddHoliday.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm , miAddHoliday.Name);
            miDeleteHoliday.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm , miDeleteHoliday.Name);
            miRefreshHoliday.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm , miRefreshHoliday.Name);
            miUpdateHoliday.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm , miUpdateHoliday.Name);

            // Root node All ở treeView list Organization
            rootNode.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm , "All");
        }
        #endregion

        #region Set TreeView Organization
        /// <summary>
        /// Gán node đầu to TreeView
        /// </summary>
        private void initTreeView() {
            rootNode = new TreeNode();
            rootNode.Name = "-1";
            tvOrganizationList.Nodes.Add(rootNode);
        }

        /// <summary>
        /// Load danh sách org vào TreeView
        /// </summary>
        private void loadListOrgToTreeView() {
            if (!bgwLoadOrgList.IsBusy) {
                dtbListHoliday.Rows.Clear();
                rootNode.Nodes.Clear();
                bgwLoadOrgList.RunWorkerAsync();
            }
        }
        #endregion

        #region Set DataGridView Holiday
        /// <summary>
        /// Tạo DataTable để lưu trữ data cho DataGridView
        /// </summary>
        private void initDataTableHolidayConfig() {
            // Tạo một cái DataTable để lưu listHoliday và gán cho DataGridView
            dtbListHoliday = new DataTable();

            dtbListHoliday.Columns.Add(colHolidayId.DataPropertyName);
            dtbListHoliday.Columns.Add(colHolidayNo.DataPropertyName);
            dtbListHoliday.Columns.Add(colHolidayName.DataPropertyName);
            dtbListHoliday.Columns.Add(colHolidayStart.DataPropertyName);
            dtbListHoliday.Columns.Add(colHolidayEnd.DataPropertyName);
            dtbListHoliday.Columns.Add(colDescription.DataPropertyName);

            // Gán data trong DataTable vào DataGridView
            dgvListHoliday.DataSource = dtbListHoliday;
        }

        /// <summary>
        /// Load list Holiday get được từ server vào DataGridView
        /// </summary>
        /// <param name="listHoliday"></param>
        private void loadListHolidayConfigToDataGridView(List<HolidayConfig> listHoliday) {
            int noNumber = 0;
            foreach (HolidayConfig holiday in listHoliday) {
                noNumber++;
                DataRow row = dtbListHoliday.NewRow();
                row.BeginEdit();

                // Add một dòng mới vào DataTable
                row[colHolidayId.DataPropertyName] = holiday.holidayId;
                row[colHolidayNo.DataPropertyName] = noNumber;
                row[colHolidayName.DataPropertyName] = holiday.holidayName;
                row[colHolidayStart.DataPropertyName] = holiday.holidayStart;
                row[colHolidayEnd.DataPropertyName] = holiday.holidayEnd;
                row[colDescription.DataPropertyName] = holiday.holidayDescription;

                row.EndEdit();
                dtbListHoliday.Rows.Add(row);
            }

            // Nếu có dữ liệu trong dtbListHoliday thì mới hiện btnUpdate và btnDelete
            if (dtbListHoliday.Rows.Count == 0) {
                btnUpdateHolidayConfig.Enabled = btnDeleteHolidayConfig.Enabled = false;
            } else {
                btnUpdateHolidayConfig.Enabled = btnDeleteHolidayConfig.Enabled = true;
            }
        }
        #endregion

        #region Button's Event
        /// <summary>
        /// Ấn nút Add Holiday
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddHolidayConfig_Click(object sender , EventArgs e) {
            menuButtonMode = FrmHolidayConfig.ModeAdding;
            loadFrmHolidayConfig(menuButtonMode);
        }

        /// <summary>
        /// Ấn nút Update Holiday
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateHolidayConfig_Click(object sender , EventArgs e) {
            menuButtonMode = FrmHolidayConfig.ModeUpdating;
            loadFrmHolidayConfig(menuButtonMode);
        }

        /// <summary>
        /// Ấn nút Delete Holiday
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteHolidayConfig_Click(object sender , EventArgs e) {
            if (MessageBoxManager.ShowQuestionMessageBox(this ,
                MessageValidate.GetMessage(rm , "DeleteHolidayCheck")) == DialogResult.Yes) {
                menuButtonMode = 3;
                deleteHoliday();
            }
        }

        /// <summary>
        /// Ấn nút Refresh Holiday
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefreshHolidayConfig_Click(object sender , EventArgs e) {
            startFilterHoliday();
        }

        /// <summary>
        /// Ấn nút Refresh Organizations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefreshOrg_Click(object sender , EventArgs e) {
            dtbListHoliday.Rows.Clear();
            loadListOrgToTreeView();
            enableMenuHoliday(false);
            enableFilterHoliday(false);
            dgvListHoliday.Enabled = false;
        }

        /// <summary>
        /// Chuột phải rồi ấn thêm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miAddHoliday_Click(object sender , EventArgs e) {
            menuButtonMode = FrmHolidayConfig.ModeAdding;
            loadFrmHolidayConfig(menuButtonMode);
        }

        /// <summary>
        /// Chuột phải rồi ấn cập nhật
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miUpdateHoliday_Click(object sender , EventArgs e) {
            menuButtonMode = FrmHolidayConfig.ModeUpdating;
            loadFrmHolidayConfig(menuButtonMode);
        }

        /// <summary>
        /// Chuột phải rồi ấn xóa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miDeleteHoliday_Click(object sender , EventArgs e) {
            if (MessageBoxManager.ShowQuestionMessageBox(this ,
                MessageValidate.GetMessage(rm , "DeleteHolidayCheck")) == DialogResult.Yes) {
                menuButtonMode = 3;
                deleteHoliday();
            }
        }

        /// <summary>
        /// Chuột phải rồi ấn làm mới
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miRefreshHoliday_Click(object sender , EventArgs e) {
            startFilterHoliday();
        }
        #endregion

        #region ButtonEvent's Support
        /// <summary>
        /// Load form để user Add hoặc Update holiday
        /// </summary>
        /// <param name="menuButton"></param>
        private void loadFrmHolidayConfig(int menuButton) {
            FrmHolidayConfig frmHolidayConfig = null;
            // menuButton 1 là adding
            // menuButton 2 là updating
            switch (menuButton) {
                case 1:
                    frmHolidayConfig = new FrmHolidayConfig(FrmHolidayConfig.ModeAdding , orgId , 0);
                    break;
                case 2:
                    rowSelectedCount = dgvListHoliday.SelectedRows.Count;

                    if (rowSelectedCount == 1) {
                        holidayId = Convert.ToInt64(CurrentRow().Cells[colHolidayId.Name].Value.ToString());

                        frmHolidayConfig = new FrmHolidayConfig(FrmHolidayConfig.ModeUpdating , orgId , holidayId);
                    } else {
                        MessageBoxManager.ShowErrorMessageBox(this , MessageValidate.GetMessage(rm , "OnlyOneHolidayCanUpdate"));
                        return;
                    }
                    break;
                default:
                    break;
            }

            if (null != frmHolidayConfig) {
                workItem.SmartParts.Add(frmHolidayConfig);
                frmHolidayConfig.ShowDialog();
                workItem.SmartParts.Remove(frmHolidayConfig);
                frmHolidayConfig.Hide();
                startFilterHoliday();
            }
        }

        /// <summary>
        /// Lọc holiday dựa vào 2 giá trị của dpHolidayStart và dpHolidayEnd
        /// </summary>
        private void startFilterHoliday() {
            dateStart = dpHolidayStart.Value.Date.ToString(dateFormatWithoutSlash);
            dateEnd = dpHolidayEnd.Value.Date.ToString(dateFormatWithoutSlash);

            if (!bgwFilterHoliday.IsBusy) {
                dtbListHoliday.Rows.Clear();
                bgwFilterHoliday.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Delete holiday
        /// </summary>
        private void deleteHoliday() {
            // Nếu có nhiều dòng đang chọn thì add các hConfigId của từng dòng vào một cái list id
            listHolidayId = new List<long>();
            rowSelectedCount = dgvListHoliday.SelectedRows.Count;
            rowChooseIndex = dgvListHoliday.CurrentCell.RowIndex;

            foreach (DataGridViewRow selectedRowForDelete in dgvListHoliday.SelectedRows) {
                holidayId = Convert.ToInt64(selectedRowForDelete.Cells[colHolidayId.Name].Value.ToString());

                listHolidayId.Add(holidayId);
            }
            // Có id rồi thì chạy BackgroundWorker delete
            if (!bgwDeleteHoliday.IsBusy) {
                bgwDeleteHoliday.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Enable các button
        /// </summary>
        /// <param name="check"></param>
        private void enableMenuHoliday(bool check) {
            btnAddHolidayConfig.Enabled = btnUpdateHolidayConfig.Enabled =
                btnDeleteHolidayConfig.Enabled = btnRefreshHolidayConfig.Enabled = check;
        }

        /// <summary>
        /// Enable 2 DateTimePicker
        /// </summary>
        /// <param name="check"></param>
        private void enableFilterHoliday(bool check) {
            dpHolidayStart.Enabled = dpHolidayEnd.Enabled = check;
        }
        #endregion

        #region Events
        /// <summary>
        /// Double click trên một ô trong DataGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvListHoliday_CellDoubleClick(object sender , DataGridViewCellEventArgs e) {
            if (e.RowIndex > -1) {
                menuButtonMode = FrmHolidayConfig.ModeUpdating;
                loadFrmHolidayConfig(menuButtonMode);
            }
        }

        /// <summary>
        /// Người dùng chọn dpHolidayStart ngày bắt đầu khác
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dpHolidayStart_ValueChanged(object sender , EventArgs e) {
            // Kiểm tra nếu ngày bắt đầu sau ngày kết thúc
            // Thì gán lại ngày kết thúc bằng ngày bắt đầu
            if (dpHolidayEnd.Value.Date < dpHolidayStart.Value.Date) {
                dpHolidayEnd.Value = dpHolidayStart.Value;
            }
        }

        /// <summary>
        /// Người dùng chọn dpHolidayEnd ngày kết thúc khác
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dpHolidayEnd_ValueChanged(object sender , EventArgs e) {
            // Kiểm tra nếu ngày bắt đầu sau ngày kết thúc
            // Thì gán lại ngày kết thúc bằng ngày bắt đầu
            if (dpHolidayEnd.Value.Date < dpHolidayStart.Value.Date) {
                dpHolidayEnd.Value = dpHolidayStart.Value;
            }
        }

        /// <summary>
        /// Chuột phải trên một dòng trong DataGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvListHoliday_MouseDown(object sender , MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                miAddHoliday.Visible = miUpdateHoliday.Visible =
                    miDeleteHoliday.Visible = miRefreshHoliday.Visible = true;
                DataGridView.HitTestInfo htInfo = dgvListHoliday.HitTest(e.X , e.Y);
                if (htInfo.RowIndex != -1) {
                    if (htInfo.RowIndex >= 0 && htInfo.ColumnIndex >= 0) {
                        if (!dgvListHoliday.SelectedRows.Contains(dgvListHoliday.Rows[htInfo.RowIndex])) {
                            // Clear select khi chuột phải qua một vùng chọn khác vùng đang chọn
                            foreach (DataGridViewRow row in dgvListHoliday.SelectedRows) {
                                row.Selected = false;
                            }

                            dgvListHoliday.CurrentCell = dgvListHoliday.Rows[htInfo.RowIndex].Cells[colHolidayNo.Name];
                        }
                    }

                    miAddHoliday.Visible = miRefreshHoliday.Visible = false;
                } else {
                    miUpdateHoliday.Visible = miDeleteHoliday.Visible = false;
                }
                cmsHoliday.Show((Control) sender , e.X , e.Y);
            }
        }

        /// <summary>
        /// TreeView list Org trước khi chọn node
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvOrganizationList_BeforeSelect(object sender , TreeViewCancelEventArgs e) {
            if (bgwLoadOrgList.IsBusy) {
                e.Cancel = true;
                return;
            }

            if (selectedOrgNode != null) {
                selectedOrgNode.NodeFont = new Font(startupNodeFont , FontStyle.Regular);
                selectedOrgNode.Text = selectedOrgNode.Text;
            }
        }

        /// <summary>
        /// TreeView list Org sau khi chọn node
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvOrganizationList_AfterSelect(object sender , TreeViewEventArgs e) {
            TreeNode selectedNode = e.Node;

            if (selectedNode != null) {
                selectedNode.NodeFont = new Font(startupNodeFont , FontStyle.Bold);
                selectedNode.Text = selectedNode.Text;

                if (selectedOrgNode != null && selectedNode == selectedOrgNode) {
                    return;
                }

                selectedOrgNode = selectedNode;

                // Người dùng sau khi chọn node
                // Nếu node là org thì get dữ liệu
                if (selectedNode.Level == 1) {
                    orgId = Convert.ToInt64(selectedNode.Name);
                    enableMenuHoliday(true);
                    enableFilterHoliday(true);
                    dgvListHoliday.Enabled = true;
                    startFilterHoliday();
                } else {
                    // Còn node không phải là org thì disable hết các control và clear data
                    enableMenuHoliday(false);
                    enableFilterHoliday(false);
                    dgvListHoliday.Enabled = false;
                    dtbListHoliday.Rows.Clear();
                }
            }
        }

        /// <summary>
        /// Set ngày tháng mặc định cho 2 DateTimePicker
        /// Bắt đầu từ đầu tháng tới cuối tháng của tháng hiện tại
        /// </summary>
        private void setDateTimePicker() {
            int currentYear = DateTime.Today.Year;
            int currentMonth = DateTime.Today.Month;
            int firstDayOfMonth = 1;
            int lastDayOfMonth = DateTime.DaysInMonth(currentYear , currentMonth);
            // Set DateTimePicker bắt đầu là ngày đầu của tháng tại thời điểm hiện tại hiện tại
            dpHolidayStart.Value = new DateTime(currentYear , currentMonth , firstDayOfMonth);
            // Set DateTimePicker kết thúc là ngày cuối của tháng tại thời điểm hiện tại hiện tại
            dpHolidayEnd.Value = new DateTime(currentYear , currentMonth , lastDayOfMonth);
        }

        /// <summary>
        /// Trả về dòng đang chọn hiện tại trong DataGridView dgvListHoliday
        /// </summary>
        /// <returns></returns>
        private DataGridViewRow CurrentRow() {
            rowChooseIndex = dgvListHoliday.CurrentRow.Index;
            DataGridViewRow currentRow = dgvListHoliday.Rows[rowChooseIndex];

            return currentRow;
        }

        /// <summary>
        /// Update lại thống kê chấm công theo tháng
        /// </summary>
        /// <param name="session"></param>
        /// <param name="dateStart"></param>
        /// <param name="dateEnd"></param>
        /// <param name="listMemberId"></param>
        private void reUpdateMonthlyReport(string session , string dateStart , string dateEnd , List<long> listMemberId) {
            int result = TimeKeepingFactory.Instance.GetChannel()
                .insertOrUpdateMonthlyReport(session , dateStart , dateEnd , listMemberId);
        }
        #endregion

        #region Background Worker
        #region Delete Holiday
        private void bgwDeleteHoliday_DoWork(object sender , DoWorkEventArgs e) {
            int result = 0;
            listHoliday = new List<HolidayConfig>();

            try {
                foreach (long holidayId in listHolidayId) {
                    HolidayConfig hConfig = TimeKeepingHolidayConfigFactory.Instance.GetChannel().getHolidayConfigById(StorageService.CurrentSessionId , holidayId);
                    listHoliday.Add(hConfig);
                }

                result = TimeKeepingHolidayConfigFactory.Instance.GetChannel().deleteHolidayConfigById(StorageService.CurrentSessionId , listHolidayId);
            } catch (TimeoutException) {
                MessageBoxManager.ShowErrorMessageBox(this , MessageValidate.GetMessage(rm , "TimeOutExceptionMessage"));
            } catch (FaultException<WcfServiceFault> ex) {
                MessageBoxManager.ShowErrorMessageBox(this , ErrorCodes.GetErrorMessage(ex.Detail.Code));
            } catch (FaultException ex) {
                MessageBoxManager.ShowErrorMessageBox(this , MessageValidate.GetMessage(rm , "FaultExceptionMessage")
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
            } catch (CommunicationException) {
                MessageBoxManager.ShowErrorMessageBox(this , MessageValidate.GetMessage(rm , "CommunicationExceptionMessage"));
            } finally {
                e.Result = result;
            }
        }

        private void bgwDeleteHoliday_RunWorkerCompleted(object sender , RunWorkerCompletedEventArgs e) {
            if (e.Cancelled) {
                return;
            }

            // Nếu xóa thành công thì refresh lại dgvListHoliday
            if (Convert.ToInt16(e.Result) == 0) {
                startFilterHoliday();

                // Cập nhật lại thống kê theo tháng
                foreach (HolidayConfig hConfig in listHoliday) {
                    List<long> listMemberId = new List<long>();
                    // Lấy list Member trong lít MemberCustomerDTo
                    // Sau đó lấy từng id của từng member add vô listMemberId
                    MemberFilter filter = new MemberFilter();
                    List<MemberCustomerDTO> listMemberCustomerDTO = OrganizationFactory.Instance.GetChannel()
                        .GetMemberList(StorageService.CurrentSessionId , hConfig.orgId , -1 , filter);
                    foreach (MemberCustomerDTO memberCustomerDTO in listMemberCustomerDTO) {
                        listMemberId.Add(memberCustomerDTO.Member.Id);
                    }
                    // Update lại thống kê chấm công theo tháng
                    reUpdateMonthlyReport(StorageService.CurrentSessionId ,
                        DateTime.ParseExact(hConfig.holidayStart , dateFormatForDateTimePicker , null).ToString("yyyy-MM-dd") ,
                        DateTime.ParseExact(hConfig.holidayEnd , dateFormatForDateTimePicker , null).ToString("yyyy-MM-dd") ,
                        listMemberId);
                }
            } else {
                MessageBoxManager.ShowErrorMessageBox(this , MessageValidate.GetMessage(rm , "DeleteFail"));
            }
        }
        #endregion

        #region Filter Holiday
        private void bgwFilterHoliday_DoWork(object sender , DoWorkEventArgs e) {
            List<HolidayConfig> result = new List<HolidayConfig>();
            int take = LocalSettings.Instance.RecordsPerPage;

            try {
                result = TimeKeepingHolidayConfigFactory.Instance.GetChannel().filterHolidayListByOrgId(StorageService.CurrentSessionId , dateStart , dateEnd , orgId);
            } catch (TimeoutException) {
                MessageBoxManager.ShowErrorMessageBox(this , MessageValidate.GetMessage(rm , "TimeOutExceptionMessage"));
            } catch (FaultException<WcfServiceFault> ex) {
                MessageBoxManager.ShowErrorMessageBox(this , ErrorCodes.GetErrorMessage(ex.Detail.Code));
            } catch (FaultException ex) {
                MessageBoxManager.ShowErrorMessageBox(this , MessageValidate.GetMessage(rm , "FaultExceptionMessage")
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
            } catch (CommunicationException) {
                MessageBoxManager.ShowErrorMessageBox(this , MessageValidate.GetMessage(rm , "CommunicationExceptionMessage"));
            } finally {
                e.Result = result;
            }
        }

        private void bgwFilterHoliday_RunWorkerCompleted(object sender , RunWorkerCompletedEventArgs e) {
            if (e.Cancelled) {
                return;
            }
            if (e.Result == null) {
                return;
            }

            // Lấy danh sách holiday từ DoWork
            List<HolidayConfig> result = (List<HolidayConfig>) e.Result;

            // Nếu danh sách holiday không rỗng thì load vào DataGridView
            if (null != result) {
                loadListHolidayConfigToDataGridView(result);
            }

            // Những dòng code sau để đặt con trỏ ở vị trí cần đặt
            // 1 là add mode, 2 là update mode, 3 là delete mode
            switch (menuButtonMode) {
                case 1:
                    // Để con trỏ/dòng chọn ở cuối DataGridView nếu mới load hoặc mới add holiday
                    rowSelectIndex = dgvListHoliday.Rows.Count - 1;
                    break;
                case 2:
                    // Để con trỏ/dòng chọn ở vị trí mới update holiday
                    rowSelectIndex = rowChooseIndex;
                    break;
                case 3:
                    if (rowSelectedCount == 1) {
                        if (rowChooseIndex == dgvListHoliday.Rows.Count) {
                            // Để con trỏ/dòng chọn ở trên vị trí mới delete holiday nếu delete ở cuối danh sách
                            rowSelectIndex = rowChooseIndex - 1;
                        } else {
                            // Để con trỏ/dòng chọn ở vị trí mới delete holiday
                            rowSelectIndex = rowChooseIndex;
                        }
                    } else {
                        // Nếu chọn nhiều dòng để xóa thì để con trỏ/dòng chọn ở cuối danh sách luôn
                        rowSelectIndex = dgvListHoliday.Rows.Count - 1;
                    }
                    break;
                default:
                    // Mặc định để con trỏ/dòng chọn ở cuối danh sách luôn
                    rowSelectIndex = dgvListHoliday.Rows.Count - 1;
                    break;
            }

            if (dgvListHoliday.RowCount >= 1) {
                if (rowSelectIndex >= 0) {
                    dgvListHoliday.CurrentCell = dgvListHoliday.Rows[rowSelectIndex].Cells[colHolidayNo.Name];
                    menuButtonMode = 0;
                }
            }
        }
        #endregion

        #region Load Org từ server
        private void bgwLoadOrgList_DoWork(object sender , DoWorkEventArgs e) {
            List<OrgCustomerDto> result = null;
            OrgFilterDto filter = new OrgFilterDto();

            try {
                // Lọc OrgCode
                if (!((SystemSettings.Instance.OrgCode).Equals("") || (SystemSettings.Instance.OrgCode).Equals("ALL"))) {
                    filter.OrgCode = SystemSettings.Instance.OrgCode;
                    filter.FilterByOrgCode = true;
                }

                result = OrganizationFactory.Instance.GetChannel().GetOrgList(storageService.CurrentSessionId , filter);
            } catch (TimeoutException) {
                MessageBoxManager.ShowErrorMessageBox(this , MessageValidate.GetMessage(rm , "TimeOutExceptionMessage"));
            } catch (FaultException<WcfServiceFault> ex) {
                MessageBoxManager.ShowErrorMessageBox(this , ErrorCodes.GetErrorMessage(ex.Detail.Code));
            } catch (FaultException ex) {
                MessageBoxManager.ShowErrorMessageBox(this , MessageValidate.GetMessage(rm , "FaultExceptionMessage")
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
            } catch (CommunicationException) {
                MessageBoxManager.ShowErrorMessageBox(this , MessageValidate.GetMessage(rm , "CommunicationExceptionMessage"));
            } finally {
                e.Result = result;
            }
        }

        private void bgwLoadOrgList_RunWorkerCompleted(object sender , RunWorkerCompletedEventArgs e) {
            if (e.Cancelled) {
                return;
            }

            // Lấy danh sách org từ DoWork
            List<OrgCustomerDto> result = (List<OrgCustomerDto>) e.Result;

            // Nếu danh sách org không rỗng thì load vào TreeView
            // Nếu khác rỗng thì load
            if (null != result) {
                foreach (OrgCustomerDto org in result) {
                    if (!org.Issuer.Equals(SystemSettings.Instance.Master)) {
                        TreeNode Node = new TreeNode();
                        Node.Text = org.Name;
                        Node.Name = Convert.ToString(org.OrgId);
                        rootNode.Nodes.Add(Node);
                    }
                }

                tvOrganizationList.Sort();
                rootNode.Expand();
            }
        }
        #endregion
        #endregion

        #region CAB events
        [CommandHandler(TimeCommandName.ShowHolidayConfig)]
        public void ShowHolidayConfigMgtMainHandler(object s , EventArgs e) {
            UsrHolidayConfig uHolidayConfig = workItem.Items.Get<UsrHolidayConfig>(DefineName.HolidayConfig);
            if (null == uHolidayConfig) {
                uHolidayConfig = workItem.Items.AddNew<UsrHolidayConfig>(DefineName.HolidayConfig);
            } else if (uHolidayConfig.IsDisposed) {
                workItem.Items.Remove(uHolidayConfig);
                uHolidayConfig = workItem.Items.AddNew<UsrHolidayConfig>(DefineName.HolidayConfig);
            }

            workItem.Workspaces[WorkspaceName.MainWorkspace].Show(uHolidayConfig);
            uHolidayConfig.Parent.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm , DefineName.MenuHolidayConfig);
        }
        #endregion
    }
}
