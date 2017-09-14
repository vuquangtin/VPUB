using CommonHelper.Constants;
using CommonHelper.Utils;
using Microsoft.Practices.CompositeUI;
using sTimeKeeping.Factory;
using sTimeKeeping.Model;
using sWorldModel;
using System;
using System.Collections.Generic;
using System.Resources;

namespace sTimeKeeping.WorkItems {
    public partial class FrmColorConfig : CommonControls.Custom.CommonDialog {
        #region Properties
        public ColorConfig cConfigObj { get; set; }
        ColorConfig cConfigObjTemp = null;
        public List<long> listColorChosen { get; set; }
        List<long> listColorChosenTemp;
        long colorConfigId;
        long colorIdBefore;
        long colorIdAfter;
        long orgId;
        public bool editColor { get; set; }

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
        public FrmColorConfig(List<long> listColorChosen, long colorIdBefore, long colorConfigId, long orgId) {
            InitializeComponent();
            this.listColorChosen = listColorChosen;
            this.colorIdBefore = colorIdBefore;
            this.colorConfigId = colorConfigId;
            this.orgId = orgId;
            registerEvent();
        }

        private void registerEvent() {
            // Nút Xác nhận - Hủy bỏ
            btnConfirm.Click += btnConfirm_Click;
            btnCancel.Click += btnCancel_Click;

            // Chọn màu
            colorRed.Click += colorRed_Click;
            colorPink.Click += colorPink_Click;
            colorPurple.Click += colorPurple_Click;
            colorDeepPurple.Click += colorDeepPurple_Click;
            colorIndigo.Click += colorIndigo_Click;
            colorBlue.Click += colorBlue_Click;
            colorCyan.Click += colorCyan_Click;
            colorTeal.Click += colorTeal_Click;
            colorGreen.Click += colorGreen_Click;
            colorYellow.Click += colorYellow_Click;
            colorAmber.Click += colorAmber_Click;
            colorOrange.Click += colorOrange_Click;
            colorDeepOrange.Click += colorDeepOrange_Click;
            colorBrown.Click += colorBrown_Click;
            colorWhite.Click += colorWhite_Click;
        }

        private void FrmColorConfig_Load(object sender, EventArgs e) {
            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);

            loadColorToPictureBox();
            if (colorConfigId != 0) {
                // Disable những màu đã được chọn
                foreach (long colorId in listColorChosen) {
                    if (colorId != colorIdBefore) {
                        setColorDisable(colorId);
                    }
                }
                cConfigObjTemp = TimeKeepingColorConfigFactory.Instance.GetChannel().getColorConfigById(StorageService.CurrentSessionId, colorConfigId);
                setColorSelected(colorIdBefore);
            }

            listColorChosenTemp = new List<long>();
            foreach (long i in listColorChosen) {
                listColorChosenTemp.Add(i);
            }

            //Set Language
            setLanguage();
        }
        #endregion

        #region Set Language
        private void setLanguage() {
            btnCancel.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, btnCancel.Name);
            btnConfirm.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, btnConfirm.Name);
            //20170306 #Bug 733 Fix [sTimeKeeping] Cau hinh chung _Design to select color should change - Minh Nguyen Start
            colorRed.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, colorRed.Name);
            colorPink.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, colorPink.Name);
            colorPurple.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, colorPurple.Name);
            colorDeepPurple.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, colorDeepPurple.Name);
            colorIndigo.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, colorIndigo.Name);
            colorBlue.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, colorBlue.Name);
            colorCyan.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, colorCyan.Name);
            colorTeal.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, colorTeal.Name);
            colorGreen.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, colorGreen.Name);
            colorYellow.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, colorYellow.Name);
            colorAmber.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, colorAmber.Name);
            colorOrange.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, colorOrange.Name);
            colorDeepOrange.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, colorDeepOrange.Name);
            colorBrown.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, colorBrown.Name);
            colorWhite.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, colorWhite.Name);
            //20170306 #Bug 733 Fix [sTimeKeeping] Cau hinh chung _Design to select color should change - Minh Nguyen Start
            Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, Name);
            lblColorConfig.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblColorConfig.Name);
        }
        #endregion

        #region Button's Events
        /// <summary>
        /// Ấn nút xác nhận
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e) {
            updateColorConfig();
        }

        /// <summary>
        /// Ấn nút hủy bỏ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e) {
            listColorChosen = listColorChosenTemp;
            editColor = false;
            Close();
        }

        #region Ấn chọn màu
        private void colorRed_Click(object sender, EventArgs e) {
            colorClick(Convert.ToInt64(ColorValueName.red));
        }

        private void colorPink_Click(object sender, EventArgs e) {
            colorClick(Convert.ToInt64(ColorValueName.pink));
        }

        private void colorPurple_Click(object sender, EventArgs e) {
            colorClick(Convert.ToInt64(ColorValueName.purple));
        }

        private void colorDeepPurple_Click(object sender, EventArgs e) {
            colorClick(Convert.ToInt64(ColorValueName.deep_purple));
        }

        private void colorIndigo_Click(object sender, EventArgs e) {
            colorClick(Convert.ToInt64(ColorValueName.indigo));
        }

        private void colorBlue_Click(object sender, EventArgs e) {
            colorClick(Convert.ToInt64(ColorValueName.blue));
        }

        private void colorCyan_Click(object sender, EventArgs e) {
            colorClick(Convert.ToInt64(ColorValueName.cyan));
        }

        private void colorTeal_Click(object sender, EventArgs e) {
            colorClick(Convert.ToInt64(ColorValueName.teal));
        }

        private void colorGreen_Click(object sender, EventArgs e) {
            colorClick(Convert.ToInt64(ColorValueName.green));
        }

        private void colorYellow_Click(object sender, EventArgs e) {
            colorClick(Convert.ToInt64(ColorValueName.yellow));
        }

        private void colorAmber_Click(object sender, EventArgs e) {
            colorClick(Convert.ToInt64(ColorValueName.amber));
        }

        private void colorOrange_Click(object sender, EventArgs e) {
            colorClick(Convert.ToInt64(ColorValueName.orange));
        }

        private void colorDeepOrange_Click(object sender, EventArgs e) {
            colorClick(Convert.ToInt64(ColorValueName.deep_orange));
        }

        private void colorBrown_Click(object sender, EventArgs e) {
            colorClick(Convert.ToInt64(ColorValueName.brown));
        }

        private void colorWhite_Click(object sender, EventArgs e) {
            colorClick(Convert.ToInt64(ColorValueName.white));
        }
        #endregion
        #endregion

        #region ButtonEvent's Support
        /// <summary>
        /// Ấn trên một màu nào đó
        /// </summary>
        /// <param name="colorId"></param>
        private void colorClick(long colorId) {
            colorIdAfter = colorId;
            changeColorConfig();
        }

        /// <summary>
        /// Update màu
        /// </summary>
        private void updateColorConfig() {
            cConfigObj = ToEntity();
            editColor = true;
            Close();
        }

        /// <summary>
        /// Bắt event ấn nút X ở trên của Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmColorConfig_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e) {
            if (editColor) {
                return;
            }
            listColorChosen = listColorChosenTemp;
            editColor = false;
        }

        /// <summary>
        /// Đổi ô màu đã chọn
        /// </summary>
        private void changeColorConfig() {
            if (colorIdBefore != colorIdAfter) {
                // Chuyển color lại bình thường khi chọn màu khác
                setColorNormal(colorIdBefore);
                // Chuyển color bình thường thành đang được chọn
                setColorSelected(colorIdAfter);

                listColorChosen.Remove(colorIdBefore);
                listColorChosen.Add(colorIdAfter);
                colorIdBefore = colorIdAfter;
                colorIdAfter = 0;
            }
        }
        #endregion

        #region Events
        /// <summary>
        /// Trả về ColorConfig object cuối cùng
        /// </summary>
        /// <returns></returns>
        private ColorConfig ToEntity() {
            ColorConfig colorConfig = new ColorConfig();
            long cName = cConfigObjTemp.colorConfigNameId;

            colorConfig.colorConfigId = colorConfigId;
            colorConfig.colorConfigNameId = cName;
            colorConfig.colorId = colorIdBefore;
            colorConfig.orgId = orgId;

            return colorConfig;
        }

        /// <summary>
        /// Load màu vào control để user chọn
        /// </summary>
        private void loadColorToPictureBox() {
            colorRed.Image = Properties.Resources.colorRed;
            colorPink.Image = Properties.Resources.colorPink;
            colorPurple.Image = Properties.Resources.colorPurple;
            colorDeepPurple.Image = Properties.Resources.colorDeepPurple;
            colorIndigo.Image = Properties.Resources.colorIndigo;
            colorBlue.Image = Properties.Resources.colorBlue;
            colorCyan.Image = Properties.Resources.colorCyan;
            colorTeal.Image = Properties.Resources.colorTeal;
            colorGreen.Image = Properties.Resources.colorGreen;
            colorYellow.Image = Properties.Resources.colorYellow;
            colorAmber.Image = Properties.Resources.colorAmber;
            colorOrange.Image = Properties.Resources.colorOrange;
            colorDeepOrange.Image = Properties.Resources.colorDeepOrange;
            colorBrown.Image = Properties.Resources.colorBrown;
            colorWhite.Image = Properties.Resources.colorWhite;
        }

        /// <summary>
        /// Chuyển lại trạng thái bình thường nếu có một màu nào khác vừa chọn
        /// </summary>
        /// <param name="colorId"></param>
        private void setColorNormal(long colorId) {
            switch (colorId) {
                case 1:
                    colorRed.Image = Properties.Resources.colorRed;
                    break;
                case 2:
                    colorPink.Image = Properties.Resources.colorPink;
                    break;
                case 3:
                    colorPurple.Image = Properties.Resources.colorPurple;
                    break;
                case 4:
                    colorDeepPurple.Image = Properties.Resources.colorDeepPurple;
                    break;
                case 5:
                    colorIndigo.Image = Properties.Resources.colorIndigo;
                    break;
                case 6:
                    colorBlue.Image = Properties.Resources.colorBlue;
                    break;
                case 7:
                    colorCyan.Image = Properties.Resources.colorCyan;
                    break;
                case 8:
                    colorTeal.Image = Properties.Resources.colorTeal;
                    break;
                case 9:
                    colorGreen.Image = Properties.Resources.colorGreen;
                    break;
                case 10:
                    colorYellow.Image = Properties.Resources.colorYellow;
                    break;
                case 11:
                    colorAmber.Image = Properties.Resources.colorAmber;
                    break;
                case 12:
                    colorOrange.Image = Properties.Resources.colorOrange;
                    break;
                case 13:
                    colorDeepOrange.Image = Properties.Resources.colorDeepOrange;
                    break;
                case 14:
                    colorBrown.Image = Properties.Resources.colorBrown;
                    break;
                case 15:
                    colorWhite.Image = Properties.Resources.colorWhite;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Chuyển thành trạng thái đang được chọn
        /// </summary>
        /// <param name="colorId"></param>
        private void setColorSelected(long colorId) {
            switch (colorId) {
                case 1:
                    colorRed.Image = Properties.Resources.colorRed_selected;
                    break;
                case 2:
                    colorPink.Image = Properties.Resources.colorPink_selected;
                    break;
                case 3:
                    colorPurple.Image = Properties.Resources.colorPurple_selected;
                    break;
                case 4:
                    colorDeepPurple.Image = Properties.Resources.colorDeepPurple_selected;
                    break;
                case 5:
                    colorIndigo.Image = Properties.Resources.colorIndigo_selected;
                    break;
                case 6:
                    colorBlue.Image = Properties.Resources.colorBlue_selected;
                    break;
                case 7:
                    colorCyan.Image = Properties.Resources.colorCyan_selected;
                    break;
                case 8:
                    colorTeal.Image = Properties.Resources.colorTeal_selected;
                    break;
                case 9:
                    colorGreen.Image = Properties.Resources.colorGreen_selected;
                    break;
                case 10:
                    colorYellow.Image = Properties.Resources.colorYellow_selected;
                    break;
                case 11:
                    colorAmber.Image = Properties.Resources.colorAmber_selected;
                    break;
                case 12:
                    colorOrange.Image = Properties.Resources.colorOrange_selected;
                    break;
                case 13:
                    colorDeepOrange.Image = Properties.Resources.colorDeepOrange_selected;
                    break;
                case 14:
                    colorBrown.Image = Properties.Resources.colorBrown_selected;
                    break;
                case 15:
                    colorWhite.Image = Properties.Resources.colorWhite_selected;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Ẩn màu đã được sự kiện khác chọn
        /// </summary>
        /// <param name="colorId"></param>
        private void setColorDisable(long colorId) {
            //20170306 #Bug 733 Fix [sTimeKeeping] Cau hinh chung _Design to select color should change - Minh Nguyen Start
            switch (colorId) {
                case 1:
                    colorRed.Visible = false;
                    break;
                case 2:
                    colorPink.Visible = false;
                    break;
                case 3:
                    colorPurple.Visible = false;
                    break;
                case 4:
                    colorDeepPurple.Visible = false;
                    break;
                case 5:
                    colorIndigo.Visible = false;
                    break;
                case 6:
                    colorBlue.Visible = false;
                    break;
                case 7:
                    colorCyan.Visible = false;
                    break;
                case 8:
                    colorTeal.Visible = false;
                    break;
                case 9:
                    colorGreen.Visible = false;
                    break;
                case 10:
                    colorYellow.Visible = false;
                    break;
                case 11:
                    colorAmber.Visible = false;
                    break;
                case 12:
                    colorOrange.Visible = false;
                    break;
                case 13:
                    colorDeepOrange.Visible = false;
                    break;
                case 14:
                    colorBrown.Visible = false;
                    break;
                case 15:
                    colorWhite.Visible = false;
                    break;
                default:
                    break;
            }
            //20170306 #Bug 733 Fix [sTimeKeeping] Cau hinh chung _Design to select color should change - Minh Nguyen End
        }
        #endregion
    }
}
