using CommonHelper.Constants;
using CommonHelper.Utils;
using Microsoft.Practices.CompositeUI;
using sTimeKeeping.Factory;
using sTimeKeeping.Model;
using sWorldModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Windows.Forms;

namespace sTimeKeeping.WorkItems
{
    /// <summary>
    /// class FrmTimeStatisticDetail : Form
    /// </summary>
    public partial class FrmTimeStatisticDetail : Form
    {
        // khai bao
        private long memId;
        private long orgId;
        private DateTime date;
        private DateTime dateCheck = DateTime.Now;

        // rm
        private ResourceManager rm;

        // workItem
        private TimeKeepingComponentWorkItem workItem;
        [ServiceDependency]
        public TimeKeepingComponentWorkItem WorkItem
        {
            set { workItem = value; }
        }

        // storageService
        private ILocalStorageService storageService;
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
        }

        /// <summary>
        /// contructor
        /// </summary>
        /// <param name="memCode"></param>
        /// <param name="memName"></param>
        /// <param name="date"></param>
        /// <param name="memId"></param>
        /// <param name="orgId"></param>
        public FrmTimeStatisticDetail(string memCode, string memName, DateTime date, long memId, long orgId)
        {
            // init
            InitializeComponent();

            // gan value
            this.memId = memId;
            this.orgId = orgId;
            this.date = date;
            lblMemCode.Text = memCode;
            lblMemName.Text = memName;
            lblDate.Text = date.ToString("dd/MM/yyyy");

            // su kien load
            this.Load += FrmTimeStatisticDetail_Load;
        }

        /// <summary>
        /// load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmTimeStatisticDetail_Load(object sender, EventArgs e)
        {
            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
            this.KeyPreview = true;
            // set label
            SetAllLabel();

            #region tao timedetailist cho cac sheet

            // TimeDetail
            // const cho colorConfigList & timeConfig
            List<ColorConfig> colorConfigList = TimeDetail.getColorConfigList(StorageService.CurrentSessionId, orgId);
            TimeDetail.colorConfigList = colorConfigList;
            List<TimeConfig> timeConfig = TimeDetail.getTimeConfig(StorageService.CurrentSessionId, orgId);
            TimeDetail.timeConfig = timeConfig;
            TimeDetail.Session = StorageService.CurrentSessionId;
            TimeDetail.OrgId = orgId;

            // prepare for ListTimeDetail
            List<List<UserTimeConfig>> ListUserTimeConfig = null;
            DayOffConfig dayoff;
            int checkHoliday;

            List<Shift> listShift = TimeKeepingShiftFactory.Instance.GetChannel().getShift(StorageService.CurrentSessionId, date.ToString("yyyy-MM-dd HH:mm:ss"),
                                date.ToString("yyyy-MM-dd HH:mm:ss"), memId + string.Empty, 0, 0);// da co memberid, tim theo memberId va list date

            //get ConfigForStatisticDTO tu server
                string dateString = date.ToString("yyyy-MM-dd HH:mm:ss");
                ConfigForStatisticDTO config = TimeKeepingTimeConfigFactory.Instance.GetChannel().GetTimeConfigEventConfigByFilter(StorageService.CurrentSessionId, memId, dateString, orgId);
                List<Event> listEvent = new List<Event>();
                if (null != config)
                {
                    if (null != config.eventList)
                        listEvent = config.eventList;
 }

                     // dayoff
                string dateStringDayOff = date.ToString("dd/MM/yyyy");
                dayoff = TimeKeepingDayOffConfigFactory.Instance.GetChannel().getDayOffByMemberIdAndDate(StorageService.CurrentSessionId, memId, dateStringDayOff);

                dateCheck = date;
                //checkHoliday = TimeKeepingHolidayConfigFactory.Instance.GetChannel().checkHoliday(StorageService.CurrentSessionId, dateCheck, orgId);
                checkHoliday = TimeDetail.checkHolidayOfOrg(StorageService.CurrentSessionId, orgId, dateCheck);

                //get ConfigForStatisticDTO tu server
                dateString = date.ToString("yyyy-MM-dd HH:mm:ss");
                config = TimeKeepingTimeConfigFactory.Instance.GetChannel().GetTimeConfigEventConfigByFilter(StorageService.CurrentSessionId, memId, dateString, orgId);

                // tinh toan list timedetail
                //list = TimeDetail.ListTimeDetail(StorageService.CurrentSessionId, orgId, listShift, memberId, date, dateCheck);
                List<List<TimeDetail>>  list = TimeDetail.ListTimeDetailForMiniSheet(listShift, config, ListUserTimeConfig, dayoff, date, checkHoliday);

                    //List<List<TimeDetail>> list = TimeDetail.ListTimeDetailForBigSheet(StorageService.CurrentSessionId, orgId, listShift, memId, date, dateCheck);
                    List<ColorConfig> colorConfigs = TimeKeepingColorConfigFactory.Instance.GetChannel().getColorConfigListByOrgId(StorageService.CurrentSessionId, orgId);
                    List<TimeDetail> listFill = list[0];
                    if (list.Count > 1) listFill = list[1];
                    List<TimeDetail> listLeft = null;
                    if (list.Count > 1) listLeft = list[0];
                    List<TimeDetail> listRight = null;
                    if (list.Count > 2) listRight = list[2];
                    sheet s = new sheet(listLeft, listFill, listRight, listEvent);
                    workItem.SmartParts.Add(s);

                    // add vao Controls
                    pnlFill.Controls.Add(s);
            #endregion
        }

        /// <summary>
        /// To Shift Filter Dto
        /// </summary>
        /// <returns></returns>
        private static ShiftFilterDto ToShiftFilterDto(long memberId, DateTime date)
        {
            ShiftFilterDto filter = new ShiftFilterDto();
            filter.FilterByDateIn = true;

            filter.DateIn = date.ToString("yyyy-MM-dd HH:mm:ss");

            filter.FilterByMemberId = true;
            filter.MemberId = memberId;
            return filter;
        }

        #region init for languages

        /// <summary>
        /// Set All Label
        /// </summary>
        private void SetAllLabel()
        {
            this.lbldateevent.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.lbldateevent.Name);
            this.lblMemberCode.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.lblMemberCode.Name);
            this.lblMemberName.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.lblMemberName.Name);
            this.lblDetailInfo.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.lblMemberName.Name);
            this.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.Name);
        }
        #endregion

        /// <summary>
        /// su kien enter 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmTimeStatisticDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Close();
            }
        }

    }
}
