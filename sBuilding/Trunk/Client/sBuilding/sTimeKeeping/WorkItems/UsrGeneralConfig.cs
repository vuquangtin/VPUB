using CommonControls;
using CommonControls.Custom;
using CommonHelper.Config;
using CommonHelper.Constants;
using CommonHelper.Utils;
using JavaCommunication.Factory;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.Commands;
using Newtonsoft.Json;
using sTimeKeeping.Constants;
using sTimeKeeping.Factory;
using sTimeKeeping.Model;
using sWorldModel;
using sWorldModel.Exceptions;
using sWorldModel.Filters;
using sWorldModel.TransportData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.ServiceModel;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace sTimeKeeping.WorkItems {
    public partial class UsrGeneralConfig : CommonUserControl {
        #region Properties
        int rowChooseIndex;

        List<ColorConfig> listChangedObj;
        List<long> listColorChosen;
        List<string> listTime;
        ColorConfig cConfigObj;
        GeneralConfig gConfigObj;
        GeneralConfig gConfigTemp;
        long colorConfigId;
        long colorId;
        bool editColor;

        //20170307 #Bug 732 Fix Cau hinh chung _Do not have confirmation for saving data change - Minh Nguyen Start
        // Backup data for compare
        string strGConfig = null;
        List<long> listColorIdBefore;
        List<long> listColorIdAfter;
        List<ColorConfig> listColorAfter;
        //20170307 #Bug 732 Fix Cau hinh chung _Do not have confirmation for saving data change - Minh Nguyen End

        // Tree Org
        long orgId = 0;

        // Color List
        private DataTable dtbColorConfigList;
        Color colorValue;
        string colorName;

        // Tree View
        private TreeNode selectedOrgNode;
        private TreeNode rootNode;
        private Font startupNodeFont;

        private BackgroundWorker bgwLoadOrgList, bgwLoadColorConfigListByOrgId,
                                 bgwLoadGeneralConfigByOrgId, bgwUpdateColor, bgwUpdateGeneralConfig;

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
        public UsrGeneralConfig() {
            InitializeComponent();
            registerEvent();
            initTreeView();
            initDataTableColorConfig();
        }

        private void registerEvent() {
            // Tree View
            tvOrganizationList.BeforeSelect += tvOrganizationList_BeforeSelect;
            tvOrganizationList.AfterSelect += tvOrganizationList_AfterSelect;

            // Nút Add - Update - Delete - Refresh General Config
            btnSaveGeneralConfig.Click += btnSaveGeneralConfig_Click;
            btnRefreshGeneralConfig.Click += btnRefreshGeneralConfig_Click;

            // Refresh Organizations
            startupNodeFont = tvOrganizationList.Font;
            btnRefreshOrg.Click += btnRefreshOrg_Click;

            // NumbericUpDown
            nudCardTag.Leave += nudCardTag_Leave;
            nudLate.Leave += nudLate_Leave;
            nudLateHalfDay.Leave += nudLateHalfDay_Leave;

            // Backgroundworker load general config
            bgwLoadGeneralConfigByOrgId = new BackgroundWorker();
            bgwLoadGeneralConfigByOrgId.WorkerSupportsCancellation = true;
            bgwLoadGeneralConfigByOrgId.DoWork += bgwLoadGeneralConfigByOrgId_DoWork;
            bgwLoadGeneralConfigByOrgId.RunWorkerCompleted += bgwLoadGeneralConfigByOrgId_RunWorkerCompleted;

            // Backgroundworker load organization list
            bgwLoadOrgList = new BackgroundWorker();
            bgwLoadOrgList.WorkerSupportsCancellation = true;
            bgwLoadOrgList.DoWork += bgwLoadOrgList_DoWork;
            bgwLoadOrgList.RunWorkerCompleted += bgwLoadOrgList_RunWorkerCompleted;

            // Backgroundworker load color config list
            bgwLoadColorConfigListByOrgId = new BackgroundWorker();
            bgwLoadColorConfigListByOrgId.WorkerSupportsCancellation = true;
            bgwLoadColorConfigListByOrgId.DoWork += bgwLoadColorConfigListByOrgId_DoWork;
            bgwLoadColorConfigListByOrgId.RunWorkerCompleted += bgwLoadColorConfigListByOrgId_RunWorkerCompleted;

            // Backgroundworker set color config
            bgwUpdateColor = new BackgroundWorker();
            bgwUpdateColor.WorkerSupportsCancellation = true;
            bgwUpdateColor.DoWork += bgwUpdateColor_DoWork;
            bgwUpdateColor.RunWorkerCompleted += bgwUpdateColor_RunWorkerCompleted;

            // Backgroundworker set general config
            bgwUpdateGeneralConfig = new BackgroundWorker();
            bgwUpdateGeneralConfig.WorkerSupportsCancellation = true;
            bgwUpdateGeneralConfig.DoWork += bgwUpdateGeneralConfig_DoWork;
            bgwUpdateGeneralConfig.RunWorkerCompleted += bgwUpdateGeneralConfig_RunWorkerCompleted;

            // Double click on dgvListColorConfig
            dgvListColorConfig.CellClick += dgvListColorConfig_CellClick;
        }

        protected override void OnLoad(EventArgs e) {
            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);

            loadListOrgToTreeView();
            initComboBoxTime();

            // Set label for multilanguages
            setLanguage();
        }
        #endregion

        #region Set Language
        private void setLanguage() {
            //20170305 #Bug #734 Fix Toolbar menu - Minh Nguyen Start
            btnRefreshGeneralConfig.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, btnRefreshGeneralConfig.Name);
            btnRefreshGeneralConfig.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, btnRefreshGeneralConfig.Name);
            btnRefreshOrg.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, btnRefreshOrg.Name);
            btnRefreshOrg.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, btnRefreshOrg.Name);
            btnSaveGeneralConfig.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, btnSaveGeneralConfig.Name);
            btnSaveGeneralConfig.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, btnSaveGeneralConfig.Name);
            //20170305 #Bug #734 Fix Toolbar menu - Minh Nguyen End
            colColorConfigNo.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, colColorConfigNo.Name);
            colColorConfigName.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, colColorConfigName.Name);
            colColorValue.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, colColorValue.Name);
            lblCardTag.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblCardTag.Name);
            lblLate.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblLate.Name);
            lblLateHalfDay.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblLateHalfDay.Name);
            lblLeftAreaTitleOrg.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblLeftAreaTitleOrg.Name);
            lblRightAreaTitleGeneralConfig.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblRightAreaTitleGeneralConfig.Name);

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
            tvOrganizationList.Nodes.Add(rootNode);
        }

        /// <summary>
        /// Load danh sách org vào TreeView
        /// </summary>
        private void loadListOrgToTreeView() {
            if (!bgwLoadOrgList.IsBusy) {
                dtbColorConfigList.Rows.Clear();
                rootNode.Nodes.Clear();
                bgwLoadOrgList.RunWorkerAsync();
            }
        }
        #endregion

        #region Set DataGridView Color
        /// <summary>
        /// Tạo DataTable để lưu trữ data cho DataGridView
        /// </summary>
        private void initDataTableColorConfig() {
            // Tạo một cái DataTable để lưu listColorConfig và gán cho DataGridView
            dtbColorConfigList = new DataTable();

            dtbColorConfigList.Columns.Add(colColorConfigId.DataPropertyName);
            dtbColorConfigList.Columns.Add(colColorId.DataPropertyName);
            dtbColorConfigList.Columns.Add(colColorConfigNo.DataPropertyName);
            dtbColorConfigList.Columns.Add(colColorValue.DataPropertyName);
            dtbColorConfigList.Columns.Add(colColorConfigName.DataPropertyName);

            // Gán data trong DataTable vào DataGridView
            dgvListColorConfig.DataSource = dtbColorConfigList;
        }

        /// <summary>
        /// Load Color Config get được từ server vào DataGridView
        /// </summary>
        /// <param name="listColorConfig"></param>
        private void loadListColorConfigToDataGridView(List<ColorConfig> listColorConfig) {
            int noNumber = 0;
            int rowIndex = 0;
            string colorConfigName;
            listColorChosen = new List<long>();
            dtbColorConfigList.Clear();
            foreach (ColorConfig cConfig in listColorConfig) {
                noNumber++;
                DataRow row = dtbColorConfigList.NewRow();
                row.BeginEdit();

                // Add một dòng mới vào DataTable
                row[colColorConfigId.DataPropertyName] = cConfig.colorConfigId;
                row[colColorId.DataPropertyName] = cConfig.colorId;
                row[colColorConfigNo.DataPropertyName] = noNumber;

                row.EndEdit();
                dtbColorConfigList.Rows.Add(row);
                // Lấy tên của sự kiện (Ngày lễ, nghỉ nửa ngày,...)
                colorConfigName = ColorEventName.getColorEventName((ColorEventId) cConfig.colorConfigNameId, rm);
                // Lấy mã màu để tô màu cho DataGridView
                colorValue = ColorTranslator.FromHtml(ColorValue.getColorValue((ColorValueName) cConfig.colorId));
                // Lấy tên của màu đó (đỏ, vàng, xanh,...)
                colorName = ColorValue.getColorName((ColorValueName) cConfig.colorId, rm);
                rowIndex = dtbColorConfigList.Rows.IndexOf(row);
                // Lấy rowIndex (số thứ tự của dòng đó), gán tên sự kiện đã lấy được cho cột Tên sự kiện
                dgvListColorConfig.Rows[rowIndex].Cells[colColorConfigName.Name].Value = colorConfigName;
                // Và lấy tên màu để gán cho cột Màu
                dgvListColorConfig.Rows[rowIndex].Cells[colColorValue.Name].Value = colorName;
                // Ô màu là màu trắng (15) thì chữ trong ô đó là màu đen cho dễ nhìn
                if (cConfig.colorId == 15) {
                    dgvListColorConfig.Rows[rowIndex].Cells[colColorValue.Name].Style = new DataGridViewCellStyle {
                        ForeColor = Color.Black,
                        BackColor = colorValue
                    };
                } else {
                    // Còn nếu ô đó là những màu còn lại thì là chữ màu trắng
                    dgvListColorConfig.Rows[rowIndex].Cells[colColorValue.Name].Style = new DataGridViewCellStyle {
                        ForeColor = Color.White,
                        BackColor = colorValue
                    };
                }
            }

            // Add những màu đã chọn vào list để khóa chọn
            addColorIdToListColorChosen();
            dgvListColorConfig.ClearSelection();
        }
        #endregion

        #region Set General Config Time
        /// <summary>
        /// Lấy list giá trị thời gian ra (phút, giờ)
        /// Gán cho 3 ComboBox
        /// </summary>
        private void initComboBoxTime() {
            listTime = new List<string>();
            listTime = TimeValue.setTimeValue(rm);
            for (int i = 0; i < listTime.Count; i++) {
                cbbCardTag.Items.Add(listTime[i]);
                cbbLate.Items.Add(listTime[i]);
                cbbLateHalfDay.Items.Add(listTime[i]);
            }
        }

        /// <summary>
        /// Gán giá trị get được từ server về cho control
        /// </summary>
        /// <param name="gConfig"></param>
        private void loadGeneralConfigToComboBox(GeneralConfig gConfig) {
            if (null != gConfig) {
                GeneralConfigJson gConfigJson = ConvertStringJsonToObject(gConfig.generalConfigJson);
                gConfigTemp = gConfig;

                // Gán cho cardTag
                nudCardTag.Value = gConfigJson.cardTag.value;
                cbbCardTag.SelectedIndex = gConfigJson.cardTag.type;

                // Gán cho late
                nudLate.Value = gConfigJson.late.value;
                cbbLate.SelectedIndex = gConfigJson.late.type;

                // Gán cho lateHalfDay
                nudLateHalfDay.Value = gConfigJson.lateHalfDay.value;
                cbbLateHalfDay.SelectedIndex = gConfigJson.lateHalfDay.type;
            } else {
                nudCardTag.Value = nudLate.Value = nudLateHalfDay.Value = 1;
                cbbCardTag.SelectedIndex = cbbLate.SelectedIndex = cbbLateHalfDay.SelectedIndex = -1;
            }
        }
        #endregion

        #region Button's Event
        /// <summary>
        /// Ấn nút Save General Config
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveGeneralConfig_Click(object sender, EventArgs e) {
            checkNumbericUpDown();
            if (MessageBoxManager.ShowQuestionMessageBox(this,
                            MessageValidate.GetMessage(rm, "SaveGeneralConfigCheck")) == DialogResult.Yes) {
                setGeneralConfig();
                saveGeneralConfig();
                dgvListColorConfig.ClearSelection();
                listColorChosen = new List<long>();
                //20170307 #Bug 732 Fix Cau hinh chung _Do not have confirmation for saving data change - Minh Nguyen Start
                strGConfig = null;
                listColorIdBefore = new List<long>();
                listColorIdAfter = new List<long>();
                listColorAfter = new List<ColorConfig>();
                //20170307 #Bug 732 Fix Cau hinh chung _Do not have confirmation for saving data change - Minh Nguyen End
                // Lưu lại list màu để disable các màu đã được chọn khi load form chọn màu
                // phòng trường hợp không load lại datagridview color list
                addColorIdToListColorChosen();
            }
        }

        /// <summary>
        /// Ấn nút Refresh General Config
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefreshGeneralConfig_Click(object sender, EventArgs e) {
            //20170307 #Bug 732 Fix Cau hinh chung _Do not have confirmation for saving data change - Minh Nguyen Start
            if (null != strGConfig) {
                setGeneralConfig();
                if (!compareDataDiffOrNot()) {
                    if (MessageBoxManager.ShowQuestionMessageBox(this,
                            MessageValidate.GetMessage(rm, "CancelGeneralConfigCheck")) == DialogResult.No) {
                        return;
                    }
                }
            }
            //20170307 #Bug 732 Fix Cau hinh chung _Do not have confirmation for saving data change - Minh Nguyen End
            loadGeneralConfig();
        }

        /// <summary>
        /// Ấn nút Refresh Organizations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefreshOrg_Click(object sender, EventArgs e) {
            //20170307 #Bug 732 Fix Cau hinh chung _Do not have confirmation for saving data change - Minh Nguyen Start
            if (null != strGConfig) {
                setGeneralConfig();
                if (!compareDataDiffOrNot()) {
                    if (MessageBoxManager.ShowQuestionMessageBox(this,
                            MessageValidate.GetMessage(rm, "CancelGeneralConfigCheck")) == DialogResult.No) {
                        return;
                    }
                }
            }
            resetControl();
            //20170307 #Bug 732 Fix Cau hinh chung _Do not have confirmation for saving data change - Minh Nguyen End
            loadListOrgToTreeView();
        }
        #endregion

        #region ButtonEvent's Support
        /// <summary>
        /// Load FrmColorConfig lên để chọn màu
        /// </summary>
        private void loadFrmColorConfig() {
            rowChooseIndex = dgvListColorConfig.CurrentCell.RowIndex;
            DataGridViewRow selectedRowForUpdate = dgvListColorConfig.Rows[rowChooseIndex];
            colorConfigId = Convert.ToInt64(selectedRowForUpdate.Cells[colColorConfigId.Name].Value.ToString());
            colorId = Convert.ToInt64(selectedRowForUpdate.Cells[colColorId.Name].Value.ToString());
            FrmColorConfig frmColorConfig = new FrmColorConfig(listColorChosen, colorId, colorConfigId, orgId);

            if (null != frmColorConfig) {
                workItem.SmartParts.Add(frmColorConfig);
                frmColorConfig.ShowDialog();
                workItem.SmartParts.Remove(frmColorConfig);
                cConfigObj = frmColorConfig.cConfigObj;
                editColor = frmColorConfig.editColor;
                listColorChosen = frmColorConfig.listColorChosen;
                frmColorConfig.Hide();
                changeGeneralConfig();
            }
        }

        /// <summary>
        /// Get cấu hình chung từ server về
        /// </summary>
        private void loadGeneralConfig() {
            if (!bgwLoadColorConfigListByOrgId.IsBusy && !bgwLoadGeneralConfigByOrgId.IsBusy) {
                listChangedObj = new List<ColorConfig>();
                dtbColorConfigList.Rows.Clear();
                bgwLoadColorConfigListByOrgId.RunWorkerAsync();
                bgwLoadGeneralConfigByOrgId.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Khi người dùng chỉnh xong cấu hình nào đó thì cập nhật lại user control
        /// Nhưng chưa cập nhật lên server
        /// </summary>
        private void changeGeneralConfig() {
            if (editColor) {
                colorValue = ColorTranslator.FromHtml(ColorValue.getColorValue((ColorValueName) cConfigObj.colorId));
                colorName = ColorValue.getColorName((ColorValueName) cConfigObj.colorId, rm);
                dgvListColorConfig.Rows[rowChooseIndex].Cells[colColorValue.Name].Value = colorName;
                if (cConfigObj.colorId == 15) {
                    dgvListColorConfig.Rows[rowChooseIndex].Cells[colColorValue.Name].Style = new DataGridViewCellStyle {
                        ForeColor = Color.Black,
                        BackColor = colorValue
                    };
                } else {
                    dgvListColorConfig.Rows[rowChooseIndex].Cells[colColorValue.Name].Style = new DataGridViewCellStyle {
                        ForeColor = Color.White,
                        BackColor = colorValue
                    };
                }
                DataGridViewRow selectedRowForUpdate = dgvListColorConfig.Rows[rowChooseIndex];
                selectedRowForUpdate.Cells[colColorId.Name].Value = cConfigObj.colorId;
                listChangedObj.Add(cConfigObj);

                //20170307 #Bug 732 Fix Cau hinh chung _Do not have confirmation for saving data change - Minh Nguyen End
                // Update list color after backup for compare with before
                foreach (var p in listColorAfter.Where(p => (p.colorConfigId == cConfigObj.colorConfigId))) {
                    listColorIdAfter[listColorAfter.IndexOf(p)] = cConfigObj.colorId;
                }
                //20170307 #Bug 732 Fix Cau hinh chung _Do not have confirmation for saving data change - Minh Nguyen End
            }
        }

        /// <summary>
        /// Cập nhật lên server
        /// </summary>
        private void saveGeneralConfig() {
            if (!bgwUpdateColor.IsBusy && !bgwUpdateGeneralConfig.IsBusy) {
                bgwUpdateColor.RunWorkerAsync();
                bgwUpdateGeneralConfig.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Lấy dữ liệu cấu hình thời gian của 3 ComboBox
        /// </summary>
        private void setGeneralConfig() {
            GeneralConfigJson gConfigJson = new GeneralConfigJson();
            GeneralConfigTime timeCardTag = new GeneralConfigTime();
            GeneralConfigTime timeLate = new GeneralConfigTime();
            GeneralConfigTime timeLateHalfDay = new GeneralConfigTime();

            // Lấy dữ liệu thời gian tag thẻ
            timeCardTag.value = Convert.ToInt32(nudCardTag.Value);
            if (cbbCardTag.SelectedIndex == TimeValue.MINUTE) {
                timeCardTag.type = TimeValue.MINUTE;
            } else {
                timeCardTag.type = TimeValue.HOUR;
            }
            gConfigJson.cardTag = timeCardTag;

            // Lấy dữ liệu thời gian trễ
            timeLate.value = Convert.ToInt32(nudLate.Value);
            if (cbbLate.SelectedIndex == TimeValue.MINUTE) {
                timeLate.type = TimeValue.MINUTE;
            } else {
                timeLate.type = TimeValue.HOUR;
            }
            gConfigJson.late = timeLate;

            // Lấy dữ liệu thời gian trễ tính nửa ngày
            timeLateHalfDay.value = Convert.ToInt32(nudLateHalfDay.Value);
            if (cbbLateHalfDay.SelectedIndex == TimeValue.MINUTE) {
                timeLateHalfDay.type = TimeValue.MINUTE;
            } else {
                timeLateHalfDay.type = TimeValue.HOUR;
            }
            gConfigJson.lateHalfDay = timeLateHalfDay;

            // Set General Config Object
            gConfigObj = ConvertObjectToStringJson(gConfigJson);
        }

        /// <summary>
        /// Đổi một đối tượng sang dạng chuỗi string Json
        /// </summary>
        /// <param name="gConfigJson"></param>
        /// <returns></returns>
        private GeneralConfig ConvertObjectToStringJson(GeneralConfigJson gConfigJson) {
            GeneralConfig gConfig = new GeneralConfig();
            string strJson = JsonConvert.SerializeObject(gConfigJson);

            gConfig.generalConfigId = gConfigTemp.generalConfigId;
            gConfig.orgId = orgId;
            gConfig.generalConfigJson = strJson;

            return gConfig;
        }

        /// <summary>
        /// Đổi chuỗi string Json sang một đối tượng
        /// </summary>
        /// <param name="strJson"></param>
        /// <returns></returns>
        private GeneralConfigJson ConvertStringJsonToObject(string strJson) {
            var jsonSerializer = new JavaScriptSerializer();
            GeneralConfigJson gConfigJson = jsonSerializer.Deserialize<GeneralConfigJson>(strJson);

            return gConfigJson;
        }

        /// <summary>
        /// Kích hoạt menu button Add - Update - Delete Color
        /// </summary>
        /// <param name="check"></param>
        private void enableGeneralConfig(bool check) {
            // Enable or Disable
            btnSaveGeneralConfig.Enabled = btnRefreshGeneralConfig.Enabled =
            nudCardTag.Enabled = nudLate.Enabled = nudLateHalfDay.Enabled =
            cbbCardTag.Enabled = cbbLate.Enabled = cbbLateHalfDay.Enabled = check;
        }
        #endregion

        #region Events
        /// <summary>
        /// Khi user click lên ô nào đó trong cột màu của dgvListColorConfig
        /// thì load FrmColorConfig cho user chọn màu luôn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvListColorConfig_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex > -1) {
                dgvListColorConfig.ClearSelection();
                int columnColorIndex = dgvListColorConfig.Columns[colColorValue.Name].Index;
                if (e.ColumnIndex == columnColorIndex) {
                    loadFrmColorConfig();
                }
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

                //20170307 #Bug 732 Fix Cau hinh chung _Do not have confirmation for saving data change - Minh Nguyen Start
                if (selectedOrgNode != null &&
                    selectedNode == selectedOrgNode) {
                    return;
                }

                if (null != strGConfig) {
                    setGeneralConfig();
                    if (!compareDataDiffOrNot()) {
                        if (MessageBoxManager.ShowQuestionMessageBox(this,
                        MessageValidate.GetMessage(rm, "CancelGeneralConfigCheck")) == DialogResult.No) {
                            // Chọn lại node mà người dùng đã chọn trước khi đổi node
                            selectedNode.NodeFont = new Font(startupNodeFont, FontStyle.Regular);
                            selectedNode.Text = selectedNode.Text;
                            tvOrganizationList.SelectedNode = selectedOrgNode;
                            selectedOrgNode.NodeFont = new Font(startupNodeFont, FontStyle.Bold);
                            selectedOrgNode.Text = selectedOrgNode.Text;
                            return;
                        }
                    }
                }

                // Nếu node là org thì get dữ liệu
                if (selectedNode.Level == 1) {
                    orgId = Convert.ToInt64(selectedNode.Name);
                    enableGeneralConfig(true);
                    loadGeneralConfig();
                    dgvListColorConfig.Enabled = true;
                } else {
                    // Còn node không phải là org thì disable hết các control và clear data
                    resetControl();
                    //20170307 #Bug 732 Fix Cau hinh chung _Do not have confirmation for saving data change - Minh Nguyen End
                }

                selectedOrgNode = selectedNode;
            }
        }

        /// <summary>
        /// Lưu lại các màu đã chọn
        /// </summary>
        private void addColorIdToListColorChosen() {
            foreach (DataGridViewRow dgvRow in dgvListColorConfig.Rows) {
                listColorChosen.Add(Convert.ToInt64(dgvRow.Cells[colColorId.Name].Value));
            }
        }

        //20170305 #Bug #731 Fix Validation is not implement - Minh Nguyen Start
        private void nudCardTag_Leave(object sender, EventArgs e) {
            if (nudCardTag.Text == "") {
                nudCardTag.Text = "1";
            }
        }

        private void nudLate_Leave(object sender, EventArgs e) {
            if (nudLate.Text == "") {
                nudLate.Text = "1";
            }
        }

        private void nudLateHalfDay_Leave(object sender, EventArgs e) {
            if (nudLateHalfDay.Text == "") {
                nudLateHalfDay.Text = "1";
            }
        }

        /// <summary>
        /// Method kiểm tra NumbericUpDown khác rỗng
        /// </summary>
        private void checkNumbericUpDown() {
            if (nudCardTag.Text == "") {
                nudCardTag.Text = "1";
            }

            if (nudLate.Text == "") {
                nudLate.Text = "1";
            }

            if (nudLateHalfDay.Text == "") {
                nudLateHalfDay.Text = "1";
            }
        }
        //20170305 #Bug #731 Fix Validation is not implement - Minh Nguyen End

        //20170307 #Bug 732 Fix Cau hinh chung _Do not have confirmation for saving data change - Minh Nguyen Start
        private bool compareDataDiffOrNot() {
            bool result = false;
            var firstNotSecond = listColorIdBefore.Except(listColorIdAfter).ToList();
            var secondNotFirst = listColorIdAfter.Except(listColorIdBefore).ToList();

            result = strGConfig.Equals(gConfigObj.generalConfigJson) &&
                !firstNotSecond.Any() && !secondNotFirst.Any();

            return result;
        }

        private void resetControl() {
            nudCardTag.Value = nudLate.Value = nudLateHalfDay.Value = 1;
            cbbCardTag.SelectedIndex = cbbLate.SelectedIndex = cbbLateHalfDay.SelectedIndex = -1;
            dtbColorConfigList.Rows.Clear();
            enableGeneralConfig(false);
            dgvListColorConfig.Enabled = false;
            strGConfig = null;
            listColorIdBefore = new List<long>();
            listColorIdAfter = new List<long>();
            listColorAfter = new List<ColorConfig>();
        }
        //20170307 #Bug 732 Fix Cau hinh chung _Do not have confirmation for saving data change - Minh Nguyen End
        #endregion

        #region Background Worker
        #region Load General Config From Server
        private void bgwLoadGeneralConfigByOrgId_DoWork(object sender, DoWorkEventArgs e) {
            try {
                e.Result = TimeKeepingGeneralConfigFactory.Instance.GetChannel().getGeneralConfigByOrgId(StorageService.CurrentSessionId, orgId);
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

        private void bgwLoadGeneralConfigByOrgId_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (e.Cancelled) {
                return;
            }

            if (null != e.Result) {
                GeneralConfig gConfig = (GeneralConfig) e.Result;
                loadGeneralConfigToComboBox(gConfig);
                // Backup data
                strGConfig = gConfig.generalConfigJson;
            } else {
                return;
            }

        }
        #endregion

        #region Load Color List from Server
        private void bgwLoadColorConfigListByOrgId_DoWork(object sender, DoWorkEventArgs e) {
            List<ColorConfig> result = new List<ColorConfig>();

            try {
                result = TimeKeepingColorConfigFactory.Instance.GetChannel().getColorConfigListByOrgId(StorageService.CurrentSessionId, orgId);
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

        private void bgwLoadColorConfigListByOrgId_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (e.Cancelled) {
                return;
            }
            if (e.Result == null) {
                return;
            }

            // Lấy danh sách color từ DoWork
            List<ColorConfig> result = (List<ColorConfig>) e.Result;
            listColorIdBefore = new List<long>();
            listColorIdAfter = new List<long>();
            listColorAfter = new List<ColorConfig>();

            // Nếu danh sách color không rỗng thì load vào DataGridView
            if (null != result) {
                loadListColorConfigToDataGridView(result);
                // Backup Data
                foreach (ColorConfig cConfig in result) {
                    listColorIdBefore.Add(cConfig.colorId);
                    listColorIdAfter.Add(cConfig.colorId);
                }
                listColorAfter = result;
            }
        }
        #endregion

        #region Load Org from Server
        private void bgwLoadOrgList_DoWork(object sender, DoWorkEventArgs e) {
            List<OrgCustomerDto> result = null;
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

        private void bgwLoadOrgList_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (e.Cancelled) {
                return;
            }

            // Lấy danh sách org từ DoWork
            List<OrgCustomerDto> result = (List<OrgCustomerDto>) e.Result;

            // Nếu danh sách org không rỗng thì load vào TreeView
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

        #region Update Color Config
        private void bgwUpdateColor_DoWork(object sender, DoWorkEventArgs e) {
            List<ColorConfig> result = new List<ColorConfig>();
            ColorConfig temp = null;

            foreach (ColorConfig cConfig in listChangedObj) {
                try {
                    temp = TimeKeepingColorConfigFactory.Instance.GetChannel().updateColorConfig(StorageService.CurrentSessionId, cConfig);
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
                result.Add(temp);
            }

            e.Result = result;
        }

        private void bgwUpdateColor_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (e.Cancelled) {
                return;
            }

            if (null == e.Result) {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "InsertFail"));
            }
        }
        #endregion

        #region Update General Config
        private void bgwUpdateGeneralConfig_DoWork(object sender, DoWorkEventArgs e) {
            try {
                e.Result = TimeKeepingGeneralConfigFactory.Instance.GetChannel().updateGeneralConfig(StorageService.CurrentSessionId, gConfigObj);
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

        private void bgwUpdateGeneralConfig_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (e.Cancelled) {
                return;
            }

            if (null == e.Result) {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "InsertFail"));
            }
        }
        #endregion
        #endregion

        #region CAB events
        [CommandHandler(TimeCommandName.ShowGeneralConfig)]
        public void ShowGeneralConfigMgtMainHandler(object s, EventArgs e) {
            UsrGeneralConfig uGeneralConfig = workItem.Items.Get<UsrGeneralConfig>(DefineName.GeneralConfig);
            if (null == uGeneralConfig) {
                uGeneralConfig = workItem.Items.AddNew<UsrGeneralConfig>(DefineName.GeneralConfig);
            } else if (uGeneralConfig.IsDisposed) {
                workItem.Items.Remove(uGeneralConfig);
                uGeneralConfig = workItem.Items.AddNew<UsrGeneralConfig>(DefineName.GeneralConfig);
            }

            workItem.Workspaces[WorkspaceName.MainWorkspace].Show(uGeneralConfig);
            uGeneralConfig.Parent.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, DefineName.MenuGeneralConfig);
        }
        #endregion
    }
}
