using System;
using System.ComponentModel;
using System.Windows.Forms;
using CommonControls.Custom;
using System.Resources;
using Microsoft.Practices.CompositeUI;
using CommonHelper.Constants;
using CommonHelper.Utils;
using CommonControls;
using Microsoft.Practices.CompositeUI.Commands;
using sTimeKeeping.Constants;
using System.ServiceModel;
using sWorldModel.Exceptions;
using CommonHelper.Config;
using System.Collections.Generic;
using sTimeKeeping.Factory;
using System.Data;
using sTimeKeeping.Model;
using System.Drawing;
using sWorldModel;
using sWorldModel.Filters;
using sBuildingCommunication.Factory;
using sWorldModel.TransportData;
using sTimeKeeping.WorkItems.DayOffIntegratingExcel;

namespace sTimeKeeping.WorkItems {
    public partial class UsrDayOffConfig : CommonUserControl {
        #region Properties
        // Var để kiểm tra người dùng đang thao tác add hay update hay delete
        private int menuButtonMode;
        // Số dòng đang được chọn
        private int rowSelectedCount;
        // Hàng thứ mấy đã được chọn
        private int rowChooseIndex;
        // Hàng thứ mấy đang được chọn
        private int rowSelectIndex;

        private long doConfigId;
        private long subOrgId = 0;

        // For month calculator
        private List<DayOffConfig> listDOConfig;

        // Biến để bỏ qua TextBoxChange
        private bool skipTextChange = false;

        // Day Off List
        private DataTable dtbListDayOff;
        private List<long> listDOConfigId;

        // tree org
        private BackgroundWorker bgwLoadOrgList;
        private Font startupNodeFont;
        private TreeNode rootNode;
        private TreeNode selectedSubOrgParentNode;
        private TreeNode selectedOrgNode;
        private List<OrgCustomerDto> result = null;

        //id to chuc
        private long OrgId = 0;
        //id parent suborg select
        private long parentId = 0;
        //id nguoi dung select in tree
        private long selectedOrgId = 0;

        // For filter DayOff
        private string dateStart;
        private string dateEnd;
        private string dateFormatWithoutSlash = "ddMMyyyy";
        private string dateFormatForDateTimePicker = "dd/MM/yyyy";

        private BackgroundWorker bgwFilterListDayOffByDateAndSubOrgId,
                                 bgwDeleteDayOff;

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
        public UsrDayOffConfig() {
            InitializeComponent();
            registerEvent();
            initTreeView();
            initDataTableListMember();
        }

        private void registerEvent() {
            //cac su kien cua tree
            tvOrganizationList.BeforeSelect += tvOrganizationList_BeforeSelect;
            tvOrganizationList.AfterSelect += tvOrganizationList_AfterSelect;

            // Backgroundworker load organization list
            bgwLoadOrgList = new BackgroundWorker();
            bgwLoadOrgList.WorkerSupportsCancellation = true;
            bgwLoadOrgList.DoWork += bgwLoadOrgList_DoWork;
            bgwLoadOrgList.RunWorkerCompleted += bgwLoadOrgList_RunWorkerCompleted;

            // Refresh Organizations
            startupNodeFont = tvOrganizationList.Font;
            btnRefreshOrg.Click += btnRefreshOrg_Click;

            // Nút Add - Update - Delete - Refresh DayOff Config
            btnAddDayOff.Click += btnAddDayOff_Click;
            btnUpdateDayOffConfig.Click += btnUpdateDayOffConfig_Click;
            btnDeleteDayOffConfig.Click += btnDeleteDayOffConfig_Click;
            btnImportDayOffConfig.Click += btnImportDayOffConfig_Click;
            btnRefreshDayOffList.Click += btnRefreshListDayOff_Click;

            // Backgroundworker load list day off by subOrgId
            bgwFilterListDayOffByDateAndSubOrgId = new BackgroundWorker();
            bgwFilterListDayOffByDateAndSubOrgId.WorkerSupportsCancellation = true;
            bgwFilterListDayOffByDateAndSubOrgId.DoWork += bgwFilterListDayOffByDateAndSubOrgId_DoWork;
            bgwFilterListDayOffByDateAndSubOrgId.RunWorkerCompleted += bgwFilterListDayOffByDateAndSubOrgId_RunWorkerCompleted;

            // Backgroundworker delete day off by doConfigId
            bgwDeleteDayOff = new BackgroundWorker();
            bgwDeleteDayOff.WorkerSupportsCancellation = true;
            bgwDeleteDayOff.DoWork += bgwDeleteDayOff_DoWork;
            bgwDeleteDayOff.RunWorkerCompleted += bgwDeleteDayOff_RunWorkerCompleted;

            // Sự kiện bắt trong DataGridView
            dgvListDayOff.CellDoubleClick += dgvListDayOff_CellDoubleClick;
            dgvListDayOff.MouseDown += dgvListDayOff_MouseDown;

            // Chuột phải vào DataGridView
            miAddDayOff.Click += miAddDayOff_Click;
            miUpdateDayOff.Click += miUpdateDayOff_Click;
            miDeleteDayOff.Click += miDeleteDayOff_Click;
            miRefreshDayOff.Click += miRefreshDayOff_Click;

            // 2 Texbox search
            tbxFilterByMemberName.TextChanged += tbxFilterByMemberName_TextChanged;
            tbxFilterByMemberCode.TextChanged += tbxFilterByMemberCode_TextChanged;

            // DateTimePicker ValueChange cho dpStart và dpEnd
            dpDateStart.ValueChanged += dpDateStart_ValueChanged;
            dpDateEnd.ValueChanged += dpDateEnd_ValueChanged;
        }

        protected override void OnLoad(EventArgs e) {
            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(Controls, rm);
            loadListOrgToTreeView();

            // Set DateTimePicker Start and End
            setDateTimePicker();
            // Set Language
            setLanguage();

            // Set max length
            tbxFilterByMemberCode.MaxLength = ConstantsValue.MAX_LENGTH_TEXT_BOX_VAR_CHAR;
            tbxFilterByMemberName.MaxLength = ConstantsValue.MAX_LENGTH_TEXT_BOX_VAR_CHAR;
        }
        #endregion

        #region Set Language
        private void setLanguage() {
            //20170305 #Bug #734 Fix Toolbar menu - Minh Nguyen Start
            btnAddDayOff.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, btnAddDayOff.Name);
            btnAddDayOff.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, btnAddDayOff.Name);
            btnDeleteDayOffConfig.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, btnDeleteDayOffConfig.Name);
            btnDeleteDayOffConfig.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, btnDeleteDayOffConfig.Name);
            btnImportDayOffConfig.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, btnImportDayOffConfig.Name);
            btnImportDayOffConfig.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, btnImportDayOffConfig.Name);
            btnRefreshDayOffList.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, btnRefreshDayOffList.Name);
            btnRefreshDayOffList.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, btnRefreshDayOffList.Name);
            btnUpdateDayOffConfig.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, btnUpdateDayOffConfig.Name);
            //20170305 #Bug #734 Fix Toolbar menu - Minh Nguyen End
            btnUpdateDayOffConfig.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, btnUpdateDayOffConfig.Name);
            colDayOffNo.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, colDayOffNo.Name);
            colDayOff.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, colDayOff.Name);
            colMemberName.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, colMemberName.Name);
            colMemCode.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, colMemCode.Name);
            colStatus.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, colStatus.Name);
            lblDateEnd.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblDateEnd.Name);
            lblDateBegin.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblDateBegin.Name);
            lblFilterByCondition.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblFilterByCondition.Name);
            lblLeftAreaTitleOrg.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblLeftAreaTitleOrg.Name);
            lblRightAreaTitleDayOffConfig.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblRightAreaTitleDayOffConfig.Name);
            miAddDayOff.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, miAddDayOff.Name);
            miDeleteDayOff.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, miDeleteDayOff.Name);
            miRefreshDayOff.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, miRefreshDayOff.Name);
            miUpdateDayOff.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, miUpdateDayOff.Name);

            // Root node All ở treeView list Organization
            rootNode.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, "All");
        }
        #endregion

        #region Set TreeView Organization
        /// <summary>
        /// Gán node đầu to TreeView
        /// </summary>
        private void initTreeView() {
            rootNode = new TreeNode();
            rootNode.Name = "-1";
            rootNode.Tag = ConstantsValue.ROOT_NODE;
            tvOrganizationList.Nodes.Add(rootNode);
        }

        /// <summary>
        /// Load danh sách org vào TreeView
        /// </summary>
        private void loadListOrgToTreeView() {
            //trvOrganizations.StorageService = storageService;
            //trvOrganizations.AfterSelect += TreeOrgAfterSelect;
            //trvOrganizations.InitializeData();

            //trvOrganizations.SetHideButton();

            // tree org sau
            if (!bgwLoadOrgList.IsBusy) {
                // Clear existing data
                selectedOrgNode = null;
                dtbListDayOff.Rows.Clear();
                rootNode.Nodes.Clear();
                bgwLoadOrgList.RunWorkerAsync();
            }
        }
        #endregion

        #region Set DataGridView Member
        /// <summary>
        /// Tạo DataTable để lưu trữ data cho DataGridView
        /// </summary>
        private void initDataTableListMember() {
            dtbListDayOff = new DataTable();

            dtbListDayOff.Columns.Add(colDayOffId.DataPropertyName);
            dtbListDayOff.Columns.Add(colDayOffNo.DataPropertyName);
            dtbListDayOff.Columns.Add(colMemCode.DataPropertyName);
            dtbListDayOff.Columns.Add(colMemberName.DataPropertyName);
            dtbListDayOff.Columns.Add(colDayOff.DataPropertyName);
            dtbListDayOff.Columns.Add(colStatus.DataPropertyName);

            dgvListDayOff.DataSource = dtbListDayOff;
        }

        /// <summary>
        /// Load Day Off get được từ server vào DataGridView
        /// </summary>
        /// <param name="listDayOff"></param>
        private void loadListDayOffConfigToDataGridView(List<DayOffConfig> listDayOff) {
            int noNumber = 0;
            string status;
            foreach (DayOffConfig doConfig in listDayOff) {
                Member member = TimeKeepingDayOffConfigFactory.Instance.GetChannel().getMemberById(StorageService.CurrentSessionId, doConfig.memberId);
                //20170403 #Bug 885 Fix Đăng ký nghỉ_bị lỗi - Minh Nguyen Start
                if (null != member) {
                    noNumber++;
                    DataRow row = dtbListDayOff.NewRow();
                    //20170403 #Bug 885 Fix Đăng ký nghỉ_bị lỗi - Minh Nguyen End
                    row.BeginEdit();

                    row[colDayOffId.DataPropertyName] = doConfig.dayOffConfigId;
                    row[colDayOffNo.DataPropertyName] = noNumber;
                    row[colMemCode.DataPropertyName] = member.Code;
                    row[colMemberName.DataPropertyName] = member.LastName + " " + member.FirstName;
                    row[colDayOff.DataPropertyName] = doConfig.date;
                    status = DayOffStatus.getDayOffStatus((DOStatus) doConfig.status, rm);
                    row[colStatus.DataPropertyName] = status;

                    row.EndEdit();
                    dtbListDayOff.Rows.Add(row);
                }
            }
        }
        #endregion

        #region Button's Event
        /// <summary>
        /// Ấn nút Add Day Off
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddDayOff_Click(object sender, EventArgs e) {
            menuButtonMode = FrmDayOffConfig.ModeAdding;
            loadFrmDayOffConfig();
        }

        /// <summary>
        /// Ấn nút Update Day Off
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateDayOffConfig_Click(object sender, EventArgs e) {
            menuButtonMode = FrmDayOffConfig.ModeUpdating;
            loadFrmDayOffConfig();
        }

        /// <summary>
        /// Ân nút Delete Day Off
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteDayOffConfig_Click(object sender, EventArgs e) {
            if (MessageBoxManager.ShowQuestionMessageBox(this,
                MessageValidate.GetMessage(rm, "DeleteDayOffCheck")) == DialogResult.Yes) {
                menuButtonMode = 3;
                deleteDayOff();
            }
        }

        /// <summary>
        /// Ân nút Import Day Off
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImportDayOffConfig_Click(object sender, EventArgs e) {
            //tao danh sach org cua to chuc
            SubOrgFilterDto subOrgFilter = new SubOrgFilterDto();
            //gan du lieu vao 
            //Organization orgObject = OrganizationFactory.Instance.GetChannel().GetOrgById(storageService.CurrentSessionId, OrgId);
            //OrgCustomerDto orgObject = OrganizationFactory.Instance.GetChannel().GetOrgList(storageService.CurrentSessionId, );
            List<SubOrgCustomerDTO> listSubOrg = OrganizationFactory.Instance.GetChannel().GetSubOrgList(
                storageService.CurrentSessionId, OrgId, subOrgFilter);

            FrmDayOffConnectionConfig frmConnConfig = new FrmDayOffConnectionConfig(OrgId, subOrgId, rm);
            frmConnConfig.ShowDialog();

            if (frmConnConfig.DialogResult == DialogResult.OK) {
                FrmDayOffReadExcelData frmReadData = new FrmDayOffReadExcelData();
                workItem.SmartParts.Add(frmReadData);
                frmReadData.FilePath = frmConnConfig.FilePath;

                frmReadData.OrgId = frmConnConfig.OrgId;
                frmReadData.SubOrgId = frmConnConfig.SubOrgId;
                frmReadData.colMemberNameIndex = frmConnConfig.MemberNameIndex;
                frmReadData.colMemberCodeIndex = frmConnConfig.MemberCodeIndex;
                frmReadData.colDateIndex = frmConnConfig.DateIndex;
                frmReadData.colTypeDayOffIndex = frmConnConfig.TypeIndex;
                frmReadData.colNoteIndex = frmConnConfig.NoteIndex;

                frmReadData.firstRowIndex = frmConnConfig.FirstRowIndex;
                frmReadData.rm = rm;
                frmReadData.ShowDialog();

                frmReadData.Dispose();
                workItem.SmartParts.Remove(frmReadData);
            }

            frmConnConfig.Dispose();
            workItem.SmartParts.Remove(frmConnConfig);
        }

        /// <summary>
        /// Ấn nút Refresh Day Off
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefreshListDayOff_Click(object sender, EventArgs e) {
            refreshListDayOff();
        }

        /// <summary>
        /// Ấn nút Refresh Organizations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefreshOrg_Click(object sender, EventArgs e) {
            dtbListDayOff.Rows.Clear();
            loadListOrgToTreeView();
            enableToolStripButton(false);
            dgvListDayOff.Enabled = false;
        }

        /// <summary>
        /// Chuột phải rồi ấn thêm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miAddDayOff_Click(object sender, EventArgs e) {
            menuButtonMode = FrmDayOffConfig.ModeAdding;
            loadFrmDayOffConfig();
        }

        /// <summary>
        /// Chuột phải rồi ấn cập nhật
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miUpdateDayOff_Click(object sender, EventArgs e) {
            menuButtonMode = FrmDayOffConfig.ModeUpdating;
            loadFrmDayOffConfig();
        }

        /// <summary>
        /// Chuột phải rồi ấn xóa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miDeleteDayOff_Click(object sender, EventArgs e) {
            if (MessageBoxManager.ShowQuestionMessageBox(this,
                MessageValidate.GetMessage(rm, "DeleteDayOffCheck")) == DialogResult.Yes) {
                menuButtonMode = 3;
                deleteDayOff();
            }
        }

        /// <summary>
        /// Chuột phải rồi ấn làm mới
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miRefreshDayOff_Click(object sender, EventArgs e) {
            refreshListDayOff();
        }
        #endregion

        #region ButtonEvent's Support
        /// <summary>
        /// Load FrmDayOffConfig cho người dùng Add hoặc Update Day Off
        /// </summary>
        private void loadFrmDayOffConfig() {
            FrmDayOffConfig frmDayOffConfig = null;
            // menuButton 1 là adding
            // menuButton 2 là updating
            switch (menuButtonMode) {
                case 1:
                    frmDayOffConfig = new FrmDayOffConfig(FrmDayOffConfig.ModeAdding, subOrgId, 0);
                    break;
                case 2:
                    rowSelectedCount = dgvListDayOff.SelectedRows.Count;

                    if (rowSelectedCount == 1) {
                        doConfigId = Convert.ToInt64(CurrentRow().Cells[colDayOffId.Name].Value.ToString());

                        frmDayOffConfig = new FrmDayOffConfig(FrmDayOffConfig.ModeUpdating, subOrgId, doConfigId);
                    } else {
                        MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "OnlyOneDayOffCanUpdate"));
                        return;
                    }
                    break;
                default:
                    break;
            }

            if (null != frmDayOffConfig) {
                workItem.SmartParts.Add(frmDayOffConfig);
                frmDayOffConfig.ShowDialog();
                workItem.SmartParts.Remove(frmDayOffConfig);
                frmDayOffConfig.Hide();
                refreshListDayOff();
            }
        }

        /// <summary>
        /// Filter Day Off
        /// </summary>
        private void startFilterDayOff() {
            dateStart = dpDateStart.Value.Date.ToString(dateFormatWithoutSlash);
            dateEnd = dpDateEnd.Value.Date.ToString(dateFormatWithoutSlash);

            if (!bgwFilterListDayOffByDateAndSubOrgId.IsBusy) {
                dtbListDayOff.Rows.Clear();
                bgwFilterListDayOffByDateAndSubOrgId.RunWorkerAsync();
            }
        }

        private void refreshListDayOff() {
            dtbListDayOff.Rows.Clear();
            tbxFilterByMemberName.Text = tbxFilterByMemberCode.Text = String.Empty;
            startFilterDayOff();
        }

        /// <summary>
        /// Delete ngày nghỉ
        /// </summary>
        private void deleteDayOff() {
            // Nếu có nhiều dòng đang chọn thì add các doConfigId của từng dòng vào một cái list id
            listDOConfigId = new List<long>();
            rowSelectedCount = dgvListDayOff.SelectedRows.Count;
            rowChooseIndex = dgvListDayOff.CurrentCell.RowIndex;

            foreach (DataGridViewRow selectedRowForDelete in dgvListDayOff.SelectedRows) {
                doConfigId = Convert.ToInt64(selectedRowForDelete.Cells[colDayOffId.Name].Value.ToString());

                listDOConfigId.Add(doConfigId);
            }

            // Có id rồi thì chạy BackgroundWorker delete
            if (!bgwDeleteDayOff.IsBusy) {
                bgwDeleteDayOff.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Enable các control
        /// </summary>
        /// <param name="check"></param>
        private void enableToolStripButton(bool check) {
            btnAddDayOff.Enabled = btnUpdateDayOffConfig.Enabled =
            btnDeleteDayOffConfig.Enabled = btnImportDayOffConfig.Enabled = btnRefreshDayOffList.Enabled =
                dpDateStart.Enabled = dpDateEnd.Enabled =
                tbxFilterByMemberCode.Enabled = tbxFilterByMemberName.Enabled = check;
        }
        #endregion

        #region Events
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
            DataView dv = new DataView(dtbListDayOff);
            string strData = FormatCharacterSearch.CheckValue(tbxFilterByMemberName.Text.Trim());
            dv.RowFilter = string.Format(colMemberName.DataPropertyName + " LIKE '%{0}%'", strData);
            dgvListDayOff.DataSource = dv;

            if (dv.Count == 0) {
                btnUpdateDayOffConfig.Enabled = btnDeleteDayOffConfig.Enabled = false;
            } else {
                btnUpdateDayOffConfig.Enabled = btnDeleteDayOffConfig.Enabled = true;
            }
        }

        /// <summary>
        /// Search theo mã nhân viên trong DataGridView danh sách ngày nghỉ
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

            DataView dv = new DataView(dtbListDayOff);
            string strData = FormatCharacterSearch.CheckValue(tbxFilterByMemberCode.Text.Trim());
            dv.RowFilter = string.Format(colMemCode.DataPropertyName + " LIKE '%{0}%'", strData);
            dgvListDayOff.DataSource = dv;
            // Nếu có dữ liệu trong dtbListDayOff thì mới hiện btnUpdate và btnDelete
            if (dv.Count == 0) {
                btnUpdateDayOffConfig.Enabled = btnDeleteDayOffConfig.Enabled = false;
            } else {
                btnUpdateDayOffConfig.Enabled = btnDeleteDayOffConfig.Enabled = true;
            }
        }

        /// <summary>
        /// Double click trên một dòng trong DataGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvListDayOff_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex > -1) {
                menuButtonMode = FrmDayOffConfig.ModeUpdating;
                loadFrmDayOffConfig();
            }
        }

        /// <summary>
        /// Chuột phải trên một dòng trong DataGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvListDayOff_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                miAddDayOff.Visible = miUpdateDayOff.Visible =
                    miDeleteDayOff.Visible = miRefreshDayOff.Visible = true;
                DataGridView.HitTestInfo htInfo = dgvListDayOff.HitTest(e.X, e.Y);
                if (htInfo.RowIndex != -1) {
                    if (htInfo.RowIndex >= 0 && htInfo.ColumnIndex >= 0) {
                        if (!dgvListDayOff.SelectedRows.Contains(dgvListDayOff.Rows[htInfo.RowIndex])) {
                            // Clear select khi chuột phải qua một vùng chọn khác vùng đang chọn
                            foreach (DataGridViewRow row in dgvListDayOff.SelectedRows) {
                                row.Selected = false;
                            }

                            dgvListDayOff.CurrentCell = dgvListDayOff.Rows[htInfo.RowIndex].Cells[colDayOffNo.Name];
                        }
                    }

                    miAddDayOff.Visible = miRefreshDayOff.Visible = false;
                } else {
                    miUpdateDayOff.Visible = miDeleteDayOff.Visible = false;
                }
                cmsDayOff.Show((Control) sender, e.X, e.Y);
            }
        }

        /// <summary>
        /// Khi user chọn dpDatrStart ngày bắt đầu mới
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dpDateStart_ValueChanged(object sender, EventArgs e) {
            // Nếu ngày bắt đầu sau ngày kết thúc thì gán ngày kết thúc bằng ngày bắt đầu
            if (dpDateEnd.Value.Date < dpDateStart.Value.Date) {
                dpDateEnd.Value = dpDateStart.Value;
            }
        }

        /// <summary>
        /// Khi user chọn dpDateEnd ngày kết thúc mới
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dpDateEnd_ValueChanged(object sender, EventArgs e) {
            // Nếu ngày bắt đầu sau ngày kết thúc thì gán ngày kết thúc bằng ngày bắt đầu
            if (dpDateEnd.Value.Date < dpDateStart.Value.Date) {
                dpDateEnd.Value = dpDateStart.Value;
            }
        }

        /// <summary>
        /// TreeView list Org trước khi chọn node
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvOrganizationList_BeforeSelect(object sender, TreeViewCancelEventArgs e) {
            if (bgwLoadOrgList.IsBusy) {
                e.Cancel = true;
                return;
            }

            if (selectedOrgNode != null) {
                selectedOrgNode.NodeFont = new Font(startupNodeFont, FontStyle.Regular);
                selectedOrgNode.Text = selectedOrgNode.Text;
            }
        }
        /// <summary>
        /// TreeView list Org sau khi chọn node
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvOrganizationList_AfterSelect(object sender, TreeViewEventArgs e) {
            TreeNode selectedNode = e.Node;

            if (selectedNode != null) {
                selectedNode.NodeFont = new Font(startupNodeFont, FontStyle.Bold);
                selectedNode.Text = selectedNode.Text;
                selectedSubOrgParentNode = selectedNode;

                if (selectedOrgNode != null && selectedNode == selectedOrgNode) {
                    return;
                }

                if (null == selectedNode.Parent) {
                    selectedSubOrgParentNode.Name = "-1";
                } else {
                    selectedSubOrgParentNode = selectedNode.Parent;
                }

                selectedOrgNode = selectedNode;

                if (null != selectedNode.Parent) {
                    OrgId = GetOrgId(selectedNode);
                } else {
                    OrgId = Convert.ToInt64(selectedOrgNode.Name);
                }

                parentId = Convert.ToInt64(selectedSubOrgParentNode.Name);
                selectedOrgId = Convert.ToInt64(selectedOrgNode.Name);

                if (selectedOrgId == -1) {
                    // Nếu node đó không phải là subOrg thì disable các control
                    enableToolStripButton(false);
                    dtbListDayOff.Rows.Clear();
                    return;
                }

                if (parentId != -1) {
                    subOrgId = selectedOrgId;
                    btnAddDayOff.Enabled = btnRefreshDayOffList.Enabled = btnImportDayOffConfig.Enabled =
                        dpDateStart.Enabled = dpDateEnd.Enabled =
                        tbxFilterByMemberCode.Enabled = tbxFilterByMemberName.Enabled = true;
                    dgvListDayOff.Enabled = true;
                    startFilterDayOff();
                } else {
                    // Nếu node đó không phải là subOrg thì disable các control
                    enableToolStripButton(false);
                    dgvListDayOff.Enabled = false;
                    dtbListDayOff.Rows.Clear();
                }
            }
        }

        /// <summary>
        /// TreeView list Org sau khi chọn node
        /// </summary>
        /// <param name="orgID"></param>
        /// <param name="parentId"></param>
        /// <param name="selectedOrgId"></param>
        private void TreeOrgAfterSelect(long orgID, long parentId, long selectedOrgId) {
            //if (selectedOrgId == -1) {
            //    // Nếu node đó không phải là subOrg thì disable các control
            //    enableToolStripButton(false);
            //    dtbListDayOff.Rows.Clear();
            //    return;
            //}

            //if (parentId != -1) {
            //    subOrgId = selectedOrgId;
            //    enableToolStripButton(true);
            //    dgvListDayOff.Enabled = true;
            //    startFilterDayOff();
            //} else {
            //    // Nếu node đó không phải là subOrg thì disable các control
            //    enableToolStripButton(false);
            //    dgvListDayOff.Enabled = false;
            //    dtbListDayOff.Rows.Clear();
            //}
        }

        /// <summary>
        /// Set ngày tháng mặc định cho 2 DateTimePicker
        /// Bắt đầu từ đầu tháng tới cuối tháng của tháng hiện tại
        /// </summary>
        private void setDateTimePicker() {
            int currentYear = DateTime.Today.Year;
            int currentMonth = DateTime.Today.Month;
            int firstDayOfMonth = 1;
            int lastDayOfMonth = DateTime.DaysInMonth(currentYear, currentMonth);
            // Set DateTimePicker bắt đầu là ngày đầu của tháng tại thời điểm hiện tại hiện tại
            dpDateStart.Value = new DateTime(currentYear, currentMonth, firstDayOfMonth);
            // Set DateTimePicker kết thúc là ngày cuối của tháng tại thời điểm hiện tại hiện tại
            dpDateEnd.Value = new DateTime(currentYear, currentMonth, lastDayOfMonth);
        }

        /// <summary>
        /// Trả về dòng đang chọn hiện tại trong DataGridView dgvListDayOff
        /// </summary>
        /// <returns></returns>
        private DataGridViewRow CurrentRow() {
            rowChooseIndex = dgvListDayOff.CurrentRow.Index;
            DataGridViewRow currentRow = dgvListDayOff.Rows[rowChooseIndex];

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

        /// <summary>
        /// Lây orgid tại node đang chọn
        /// </summary>
        /// <param name="orgID"></param>
        /// <param name="parentId"></param>
        /// <param name="selectedOrgId"></param>
        private long GetOrgId(TreeNode node) {
            long orgId = -1;
            while (Convert.ToString(node.Tag) != ConstantsValue.ROOT_NODE) {
                orgId = Convert.ToInt64(node.Name);
                node = node.Parent;
            }

            return orgId;
        }

        /// <summary>
        /// Hàm đệ quy tạo tree con
        /// </summary>
        /// <param name="org">object org</param>
        /// <param name="orgId">orgid</param>
        /// <param name="node">node từ parent gui qua để add</param>
        public void GetSubTree(OrgCustomerDto org, long orgId, TreeNode node) {
            //doi tượng này sử dụng cho vòng lặp đệ quy
            List<SubOrgCustomerDTO> lstSubOrgCustomerDTO = org.SubOrgList;
            //lọc kiểm tra điều kiện 
            if (null != lstSubOrgCustomerDTO) {
                List<SubOrgCustomerDTO> lstSubOrgCustomer = new List<SubOrgCustomerDTO>();
                foreach (SubOrgCustomerDTO sub in lstSubOrgCustomerDTO) {
                    if (sub.parentOrgId == orgId)
                        lstSubOrgCustomer.Add(sub);
                }
                if (lstSubOrgCustomer != null) {
                    foreach (SubOrgCustomerDTO subOrg in lstSubOrgCustomer) {
                        if (subOrg.OrgCode == ConstantsValue.CODE_BAO_CHI)
                            continue;
                        TreeNode subOrgNode = new TreeNode();
                        subOrgNode.Text = subOrg.Name;
                        subOrgNode.Name = Convert.ToString(subOrg.SubOrgId);
                        subOrgNode.Tag = ConstantsValue.SUB_TAG;
                        //điều kiện để add vào nút cha
                        if (orgId == subOrg.parentOrgId) {
                            node.Nodes.Add(subOrgNode);
                        }
                        //gọi đệ quy
                        GetSubTree(org, subOrg.SubOrgId, subOrgNode);
                    }
                }
            }
        }
        #endregion

        #region Background Worker
        #region Filter Day Off List By subOrgId From Server
        private void bgwFilterListDayOffByDateAndSubOrgId_DoWork(object sender, DoWorkEventArgs e) {
            List<DayOffConfig> result = new List<DayOffConfig>();
            int take = LocalSettings.Instance.RecordsPerPage;

            try {
                result = TimeKeepingDayOffConfigFactory.Instance.GetChannel().filterListDayOffBySubOrgId(StorageService.CurrentSessionId, dateStart, dateEnd, subOrgId);
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

        private void bgwFilterListDayOffByDateAndSubOrgId_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (e.Cancelled) {
                return;
            }
            if (e.Result == null) {
                return;
            }

            // Lấy danh sách dayoff từ DoWork
            List<DayOffConfig> result = (List<DayOffConfig>) e.Result;

            // Nếu danh sách dayoff không rỗng thì load vào DataGridView
            if (null != result) {
                loadListDayOffConfigToDataGridView(result);
            }

            // Những dòng code sau để đặt con trỏ ở vị trí cần đặt
            // 1 là add mode, 2 là update mode, 3 là delete mode
            switch (menuButtonMode) {
                case 1:
                    // Để con trỏ/dòng chọn ở cuối DataGridView nếu mới load hoặc mới add dayoff
                    rowSelectIndex = dgvListDayOff.Rows.Count - 1;
                    break;
                case 2:
                    // Để con trỏ/dòng chọn ở vị trí mới update dayoff
                    rowSelectIndex = rowChooseIndex;
                    break;
                case 3:
                    if (rowSelectedCount == 1) {
                        if (rowChooseIndex == dgvListDayOff.Rows.Count) {
                            // Để con trỏ/dòng chọn ở trên vị trí mới delete dayoff nếu delete ở cuối danh sách
                            rowSelectIndex = rowChooseIndex - 1;
                        } else {
                            // Để con trỏ/dòng chọn ở vị trí mới delete dayoff
                            rowSelectIndex = rowChooseIndex;
                        }
                    } else {
                        // Nếu chọn nhiều dòng để xóa thì để con trỏ/dòng chọn ở cuối danh sách luôn
                        rowSelectIndex = dgvListDayOff.Rows.Count - 1;
                    }
                    break;
                default:
                    // Mặc định để con trỏ/dòng chọn ở cuối danh sách luôn
                    rowSelectIndex = dgvListDayOff.Rows.Count - 1;
                    break;
            }

            // Set dòng chọn
            if (dgvListDayOff.RowCount >= 1) {
                if (rowSelectIndex >= 0) {
                    dgvListDayOff.CurrentCell = dgvListDayOff.Rows[rowSelectIndex].Cells[colDayOffNo.Name];
                    menuButtonMode = 0;
                }
            }

            // Nếu có dữ liệu trong dtbListDayOff thì mới hiện btnUpdate và btnDelete
            if (dtbListDayOff.Rows.Count == 0) {
                btnUpdateDayOffConfig.Enabled = btnDeleteDayOffConfig.Enabled = false;
            } else {
                btnUpdateDayOffConfig.Enabled = btnDeleteDayOffConfig.Enabled = true;
            }
        }
        #endregion

        #region Delete Day Off
        private void bgwDeleteDayOff_DoWork(object sender, DoWorkEventArgs e) {
            int result = 0;
            listDOConfig = new List<DayOffConfig>();

            try {
                foreach (long doConfigId in listDOConfigId) {
                    DayOffConfig doConfig = TimeKeepingDayOffConfigFactory.Instance.GetChannel().getDayOffConfigById(StorageService.CurrentSessionId, doConfigId);
                    listDOConfig.Add(doConfig);
                }

                result = TimeKeepingDayOffConfigFactory.Instance.GetChannel().deleteDayOffConfig(StorageService.CurrentSessionId, listDOConfigId);
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

        private void bgwDeleteDayOff_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (e.Cancelled) {
                return;
            }

            if (Convert.ToInt16(e.Result) == 0) {
                startFilterDayOff();

                // Cập nhật lại thống kê theo tháng
                foreach (DayOffConfig doConfig in listDOConfig) {
                    List<long> listMemberId = new List<long>();
                    listMemberId.Add(doConfig.memberId);
                    // Update lại thống kê chấm công theo tháng
                    reUpdateMonthlyReport(StorageService.CurrentSessionId,
                        DateTime.ParseExact(doConfig.date, dateFormatForDateTimePicker, null).ToString("yyyy-MM-dd"),
                        DateTime.ParseExact(doConfig.date, dateFormatForDateTimePicker, null).ToString("yyyy-MM-dd"),
                        listMemberId);
                }
            } else {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "DeleteFail"));
            }
        }
        #endregion

        #region Load Org từ server
        /// <summary>
        /// OnLoadOrgWorkerDoWork
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        private void bgwLoadOrgList_DoWork(object s, DoWorkEventArgs e) {

            OrgFilterDto filter = new OrgFilterDto();
            try {
                // Lọc OrgCode
                if (!((SystemSettings.Instance.OrgCode).Equals("") || (SystemSettings.Instance.OrgCode).Equals("ALL"))) {
                    filter.OrgCode = SystemSettings.Instance.OrgCode;
                    filter.FilterByOrgCode = true;
                }

                result = OrganizationFactory.Instance.GetChannel().GetOrgList(storageService.CurrentSessionId, filter);
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
        /// <summary>
        /// OnLoadOrgWorkerCompleted
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        private void bgwLoadOrgList_RunWorkerCompleted(object s, RunWorkerCompletedEventArgs e) {
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
                        TreeNode orgNode = new TreeNode();
                        orgNode.Text = org.Name;
                        orgNode.Name = Convert.ToString(org.OrgId);
                        orgNode.Tag = ConstantsValue.ORG_TAG;
                        //tạo tree con từ tree con tạo danh sách người
                        GetSubTree(org, org.OrgId, orgNode);
                        rootNode.Nodes.Add(orgNode);
                    }
                }

                tvOrganizationList.Sort();
                rootNode.Expand();
            }
        }
        #endregion
        #endregion

        #region CAB events
        [CommandHandler(TimeCommandName.ShowDayOffConfig)]
        public void ShowDayOffMgtMainHandler(object s, EventArgs e) {
            UsrDayOffConfig uDayOffConfig = workItem.Items.Get<UsrDayOffConfig>(DefineName.DayOffConfig);
            if (null == uDayOffConfig) {
                uDayOffConfig = workItem.Items.AddNew<UsrDayOffConfig>(DefineName.DayOffConfig);
            } else if (uDayOffConfig.IsDisposed) {
                workItem.Items.Remove(uDayOffConfig);
                uDayOffConfig = workItem.Items.AddNew<UsrDayOffConfig>(DefineName.DayOffConfig);
            }

            workItem.Workspaces[WorkspaceName.MainWorkspace].Show(uDayOffConfig);
            uDayOffConfig.Parent.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, DefineName.MenuDayOffConfig);
        }
        #endregion
    }
}
