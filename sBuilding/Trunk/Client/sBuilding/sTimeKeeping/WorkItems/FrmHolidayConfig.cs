using CommonControls;
using CommonHelper.Constants;
using CommonHelper.Utils;
using JavaCommunication.Factory;
using Microsoft.Practices.CompositeUI;
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
using System.Resources;
using System.ServiceModel;

namespace sTimeKeeping.WorkItems {
    public partial class FrmHolidayConfig : CommonControls.Custom.CommonDialog {
        #region Properties
        private byte OperatingMode;
        public const byte ModeAdding = 1;
        public const byte ModeUpdating = 2;

        // Date format
        string dateFormatWithSlash = "dd'/'MM'/'yyyy";
        string dateFormatForDateTimePicker = "dd/MM/yyyy";

        // For monthly calculation
        string dateStartTemp;
        string dateEndTemp;

        HolidayConfig holidayObj = null;
        long holidayId;
        long orgId;

        private BackgroundWorker bgwInsertHoliday, bgwUpdateHoliday;

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
        public FrmHolidayConfig(byte operationMode, long orgId, long holidayId) {
            InitializeComponent();
            this.orgId = orgId;
            this.holidayId = holidayId;
            OperatingMode = operationMode;
            registerEvent();
        }

        private void registerEvent() {
            // Nút Xác nhận - Làm mới - Hủy bỏ
            btnConfirm.Click += btnConfirm_Click;
            btnRefresh.Click += btnRefresh_Click;
            btnCancel.Click += btnCancel_Click;

            // Backgroundworker Insert
            bgwInsertHoliday = new BackgroundWorker();
            bgwInsertHoliday.WorkerSupportsCancellation = true;
            bgwInsertHoliday.DoWork += bgwInsertHoliday_DoWork;
            bgwInsertHoliday.RunWorkerCompleted += bgwInsertHoliday_RunWorkerCompleted;

            // Backgroundworker Update
            bgwUpdateHoliday = new BackgroundWorker();
            bgwUpdateHoliday.WorkerSupportsCancellation = true;
            bgwUpdateHoliday.DoWork += bgwUpdateHoliday_DoWork;
            bgwUpdateHoliday.RunWorkerCompleted += bgwUpdateHoliday_RunWorkerCompleted;
        }

        private void FrmHolidayConfig_Load(object sender, EventArgs e) {
            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);

            if (holidayId != 0) {
                holidayObj = TimeKeepingHolidayConfigFactory.Instance.GetChannel().getHolidayConfigById(StorageService.CurrentSessionId, holidayId);
                initDataToControl(holidayObj);
            }

            tbxHolidayName.Select();

            // Set Language
            setLanguage();

            // Set max length
            tbxHolidayName.MaxLength = ConstantsValue.MAX_LENGTH_TEXT_BOX_VAR_CHAR;
            tbxHolidayDescription.MaxLength = ConstantsValue.MAX_LENGTH_TEXT_BOX_LONG_TEXT;
        }
        #endregion

        #region Set Language
        private void setLanguage() {
            btnCancel.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, btnCancel.Name);
            btnConfirm.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, btnConfirm.Name);
            btnRefresh.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, btnRefresh.Name);
            if (OperatingMode == ModeUpdating) {
                Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, Name + "_Update");
                lblAddOrEditHoliday.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblAddOrEditHoliday.Name + "_Update");
                lblNoteHoliday.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblNoteHoliday.Name + "_Update");
            } else {
                Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, Name);
                lblAddOrEditHoliday.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblAddOrEditHoliday.Name);
                lblNoteHoliday.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblNoteHoliday.Name);
            }
            lblDescription.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblDescription.Name);
            lblDetail.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblDetail.Name);
            lblDateEnd.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblDateEnd.Name);
            lblHolidayName.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblHolidayName.Name);
            lblDateBegin.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblDateBegin.Name);
            lblMust.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblMust.Name);
        }
        #endregion

        #region Button's Events
        /// <summary>
        /// Ấn nút xác nhận
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e) {
            checkDateStartDateEnd();
        }

        /// <summary>
        /// Ấn nút làm mới
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e) {
            clearEmptyControl();
        }

        /// <summary>
        /// Ấn nút hủy bỏ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e) {
            Close();
        }
        #endregion

        #region ButtonEvent's Support
        /// <summary>
        /// Làm mới các control
        /// </summary>
        private void clearEmptyControl() {
            tbxHolidayName.Text = String.Empty;
            dpHolidayStart.Value = dpHolidayEnd.Value = DateTime.Now;
            tbxHolidayDescription.Text = String.Empty;
            tbxHolidayName.Select();
        }

        /// <summary>
        /// Kiểm tra 2 cái DateTimePick, ngày bắt đầu phải trước ngày kết thúc
        /// </summary>
        private void checkDateStartDateEnd() {
            if (dpHolidayStart.Value.Date > dpHolidayEnd.Value.Date) {
                MessageBoxManager.ShowErrorMessageBox(this,
                    MessageValidate.GetMessage(rm, "HolidayEndMustAfterHolidayStart"));
            } else {
                holidayObj = ToEntity();

                switch (OperatingMode) {
                    case ModeAdding:
                        if (MessageBoxManager.ShowQuestionMessageBox(this,
                            MessageValidate.GetMessage(rm, "AddHolidayCheck")) == System.Windows.Forms.DialogResult.Yes) {
                            if (!bgwInsertHoliday.IsBusy) {
                                bgwInsertHoliday.RunWorkerAsync();
                            }
                        }
                        break;
                    case ModeUpdating:
                        if (MessageBoxManager.ShowQuestionMessageBox(this,
                            MessageValidate.GetMessage(rm, "UpdateHolidayCheck")) == System.Windows.Forms.DialogResult.Yes) {
                            if (!bgwUpdateHoliday.IsBusy) {
                                bgwUpdateHoliday.RunWorkerAsync();
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        #endregion

        #region Events
        /// <summary>
        /// Trả về HolidayConfig object cuối cùng
        /// </summary>
        /// <returns></returns>
        private HolidayConfig ToEntity() {
            HolidayConfig holidayConfig = new HolidayConfig();
            string hName = tbxHolidayName.Text;
            string hStart = dpHolidayStart.Value.Date.ToString(dateFormatWithSlash);
            string hEnd = dpHolidayEnd.Value.Date.ToString(dateFormatWithSlash);
            string hDes = tbxHolidayDescription.Text;

            if (null == hStart && null == hEnd && null == hDes) {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "NullValue"));
                return null;
            }

            if (holidayId != 0) {
                holidayConfig.holidayId = holidayId;
            }
            holidayConfig.holidayName = hName;
            holidayConfig.holidayStart = hStart;
            holidayConfig.holidayEnd = hEnd;
            holidayConfig.holidayDescription = hDes;
            holidayConfig.orgId = orgId;

            return holidayConfig;
        }

        /// <summary>
        /// Field Name Holiday nếu bị bỏ trống sẽ disable nút xác Nhận
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxHolidayName_TextChanged(object sender, EventArgs e) {
            if (tbxHolidayName.Text.Length > 0) {
                btnConfirm.Enabled = true;
            } else {
                btnConfirm.Enabled = false;
            }
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
        #region Insert Holiday
        private void bgwInsertHoliday_DoWork(object sender, DoWorkEventArgs e) {
            HolidayConfig result = null;

            try {
                result = TimeKeepingHolidayConfigFactory.Instance.GetChannel().insertHolidayConfig(StorageService.CurrentSessionId, holidayObj);
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

        private void bgwInsertHoliday_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (e.Cancelled) {
                return;
            }

            if (null != e.Result) {
                HolidayConfig hConfig = (HolidayConfig) e.Result;
                List<long> listMemberId = new List<long>();
                // Lấy list Member trong lít MemberCustomerDTo
                // Sau đó lấy từng id của từng member add vô listMemberId
                MemberFilter filter = new MemberFilter();
                List<MemberCustomerDTO> listMemberCustomerDTO = OrganizationFactory.Instance.GetChannel()
                    .GetMemberList(StorageService.CurrentSessionId, hConfig.orgId, -1, filter);
                foreach (MemberCustomerDTO memberCustomerDTO in listMemberCustomerDTO) {
                    listMemberId.Add(memberCustomerDTO.Member.Id);
                }
                // Update lại thống kê chấm công theo tháng
                reUpdateMonthlyReport(StorageService.CurrentSessionId,
                    DateTime.ParseExact(hConfig.holidayStart, dateFormatForDateTimePicker, null).ToString("yyyy-MM-dd"),
                    DateTime.ParseExact(hConfig.holidayEnd, dateFormatForDateTimePicker, null).ToString("yyyy-MM-dd"),
                    listMemberId);
                Close();
            } else {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "InsertFail"));
            }
        }
        #endregion

        #region Update Holiday
        private void bgwUpdateHoliday_DoWork(object sender, DoWorkEventArgs e) {
            try {
                e.Result = TimeKeepingHolidayConfigFactory.Instance.GetChannel().updateHolidayConfig(StorageService.CurrentSessionId, holidayObj);
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

        private void bgwUpdateHoliday_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (e.Cancelled) {
                return;
            }

            if (null != e.Result) {
                HolidayConfig hConfig = (HolidayConfig) e.Result;
                List<long> listMemberId = new List<long>();
                // Lấy list Member trong lít MemberCustomerDTo
                // Sau đó lấy từng id của từng member add vô listMemberId
                MemberFilter filter = new MemberFilter();
                List<MemberCustomerDTO> listMemberCustomerDTO = OrganizationFactory.Instance.GetChannel()
                    .GetMemberList(StorageService.CurrentSessionId, hConfig.orgId, -1, filter);
                foreach (MemberCustomerDTO memberCustomerDTO in listMemberCustomerDTO) {
                    listMemberId.Add(memberCustomerDTO.Member.Id);
                }
                // Update lại thống kê chấm công theo tháng
                reUpdateMonthlyReport(StorageService.CurrentSessionId,
                    DateTime.ParseExact(hConfig.holidayStart, dateFormatForDateTimePicker, null).ToString("yyyy-MM-dd"),
                    DateTime.ParseExact(hConfig.holidayEnd, dateFormatForDateTimePicker, null).ToString("yyyy-MM-dd"),
                    listMemberId);
                reUpdateMonthlyReport(StorageService.CurrentSessionId,
                    DateTime.ParseExact(dateStartTemp, dateFormatForDateTimePicker, null).ToString("yyyy-MM-dd"),
                    DateTime.ParseExact(dateEndTemp, dateFormatForDateTimePicker, null).ToString("yyyy-MM-dd"),
                    listMemberId);
                Close();
            } else {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "InsertFail"));
            }
        }
        #endregion
        #endregion

        #region Data Control
        /// <summary>
        /// Load data vào control sau khi get từ server về
        /// </summary>
        /// <param name="hConfig"></param>
        private void initDataToControl(HolidayConfig hConfig) {
            dateStartTemp = hConfig.holidayStart;
            dateEndTemp = hConfig.holidayEnd;
            string dateFormatForDateTimePicker = "dd/MM/yyyy";

            tbxHolidayName.Text = hConfig.holidayName;
            dpHolidayStart.Value = DateTime.ParseExact(hConfig.holidayStart, dateFormatForDateTimePicker, null);
            dpHolidayEnd.Value = DateTime.ParseExact(hConfig.holidayEnd, dateFormatForDateTimePicker, null);
            tbxHolidayDescription.Text = hConfig.holidayDescription;
        }
        #endregion
    }
}
