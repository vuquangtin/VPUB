using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Practices.CompositeUI.Commands;
using sTimeKeeping.Constants;
using Microsoft.Practices.CompositeUI;
using sWorldModel;
using CommonHelper.Constants;
using CommonHelper.Utils;
using System.Resources;
using CommonControls;
using sTimeKeeping.Model;
using sWorldModel.TransportData;
using CommonHelper.Config;
using System.ServiceModel;
using sWorldModel.Exceptions;
using JavaCommunication.Factory;
using Newtonsoft.Json;
using sTimeKeeping.Factory;
using JavaCommunication;
using sWorldModel.Filters;

namespace sTimeKeeping.WorkItems
{
    /// <summary>
    /// class UsrTimeConfig : UserControl
    /// </summary>
    public partial class UsrTimeConfig : UserControl
    {
        private BackgroundWorker bgwLoadOrgList;
        private BackgroundWorker bgwLoadTimeConfigByOrgId;
        private BackgroundWorker bgwSaveSession;
        private Font startupNodeFont;
        private List<TimeConfig> lstTimeConfig;
        private TreeNode selectedOrgNode;
        private TreeNode rootNode;
        private ResourceManager rm;
        private bool checkNotSelectSession = false;
        private TimeKeepingComponentWorkItem workItem;
        [ServiceDependency]
        public TimeKeepingComponentWorkItem WorkItem
        {
            set { workItem = value; }
        }
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
        public UsrTimeConfig()
        {
            InitializeComponent();
            RegisterEvent();
            Init();
        }
        /// <summary>
        /// Khởi tạo tree
        /// </summary>
        private void InitTreeList()
        {
            rootNode = new TreeNode();
            rootNode.Text = MessageValidate.GetMessage(rm, "All");
            rootNode.Name = "-1";
            trvOrganizations.Nodes.Add(rootNode);
        }
        /// <summary>
        /// đăng ký event
        /// </summary>
        private void RegisterEvent()
        {
            //Tree View
            trvOrganizations.BeforeSelect += trvOrganizations_BeforeSelect;
            trvOrganizations.AfterSelect += trvOrganizations_AfterSelect;

            //Load Tree View
            bgwLoadOrgList = new BackgroundWorker();
            bgwLoadOrgList.WorkerSupportsCancellation = true;
            bgwLoadOrgList.DoWork += bgwLoadOrgList_DoWork;
            bgwLoadOrgList.RunWorkerCompleted += bgwLoadOrgList_RunWorkerCompleted;

            //bgwLoadTimeConfigByOrgId
            bgwLoadTimeConfigByOrgId = new BackgroundWorker();
            bgwLoadTimeConfigByOrgId.WorkerSupportsCancellation = true;
            bgwLoadTimeConfigByOrgId.DoWork += bgwLoadTimeConfigByOrgId_DoWork;
            bgwLoadTimeConfigByOrgId.RunWorkerCompleted += bgwLoadTimeConfigByOrgId_RunWorkerCompleted;

            //Load Tree View
            bgwSaveSession = new BackgroundWorker();
            bgwSaveSession.WorkerSupportsCancellation = true;
            bgwSaveSession.DoWork += bgwSaveSession_DoWork;
            bgwSaveSession.RunWorkerCompleted += bgwSaveSession_RunWorkerCompleted;

            //event click add or remove session
            //btnaddSession.Click += btnAdd_Click;
            //btnRemoveSession.Click += btnDelete_Click;


            startupNodeFont = trvOrganizations.Font;
            btnReload.Click += (s, e) => LoadOrgList();
            Load += OnFormLoad;
        }
        /// <summary>
        /// On Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnFormLoad(object sender, EventArgs e)
        {
            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
            LoadLanguage();
            InitTreeList();
            LoadOrgList();
        }
        /// <summary>
        /// Load Language
        /// </summary>
        private void LoadLanguage()
        {
            this.btnReload.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnReload.Name);
            this.btnSave.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnSave.Name);
            this.btnReloadConfig.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnReloadConfig.Name);
        }
        /// <summary>
        /// Ham nay load danh sach cac to chuc vao tree, ham nay duoc load sau khi usercontroll duoc load
        /// </summary>
        private void LoadOrgList()
        {
            if (!bgwLoadOrgList.IsBusy)
            {
                rootNode.Nodes.Clear();
                bgwLoadOrgList.RunWorkerAsync();
            }
        }
        /// <summary>
        /// Load list timeconfig by orgid
        /// </summary>
        private void LoadTimeConfigByOrgId()
        {
            if (!bgwLoadTimeConfigByOrgId.IsBusy)
            {
                bgwLoadTimeConfigByOrgId.RunWorkerAsync();
            }
        }
        /// <summary>
        /// trvOrganizations_BeforeSelect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trvOrganizations_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            // If background worker is running -> restrict selecting another node
            if (bgwLoadOrgList.IsBusy)
            {
                e.Cancel = true;
                return;
            }

            // Change node font style to normal
            if (selectedOrgNode != null)
            {
                selectedOrgNode.NodeFont = new Font(startupNodeFont, FontStyle.Regular);
                selectedOrgNode.Text = selectedOrgNode.Text;
            }
        }
        /// <summary>
        /// trvOrganizations_AfterSelect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trvOrganizations_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectedNode = e.Node;
            TreeNode parentNode = new TreeNode();
            if (selectedNode != null)
            {
                parentNode = selectedNode.Parent;
                selectedNode.NodeFont = new Font(startupNodeFont, FontStyle.Bold);
                selectedNode.Text = selectedNode.Text;

                if (selectedOrgNode != null && selectedNode == selectedOrgNode)
                {
                    return;
                }
                selectedOrgNode = selectedNode;
                LoadTimeConfigByOrgId();
                SetShowOrHideUpdateOrg();
            }
        }
        /// <summary>
        /// Set an hoac hien cac button add va update
        /// </summary>
        private void SetShowOrHideUpdateOrg()
        {
            bool checkUpdate = selectedOrgNode != null && Convert.ToInt64(selectedOrgNode.Name) > 0;
            //20170304 Bug #655 Fix [TimeKeeping] - Time Keeping Configure - Trang Vo Start
            btnSave.Enabled = btnReloadConfig.Enabled = checkUpdate;
            //20170304 Bug #655 Fix [TimeKeeping] - Time Keeping Configure - Trang Vo End

        }
        /// <summary>
        /// bgwLoadOrgList_DoWork
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwLoadOrgList_DoWork(object sender, DoWorkEventArgs e)
        {
            // filter khong xet du lieu, dung mac dinh
            OrgFilterDto filter = new OrgFilterDto();
            try
            {
                // kiem tra org co duoc hien thi hay khong
                if (!((SystemSettings.Instance.OrgCode).Equals("") || (SystemSettings.Instance.OrgCode).Equals("ALL")))
                {
                    filter.OrgCode = SystemSettings.Instance.OrgCode;
                    filter.FilterByOrgCode = true;
                }

                //lay tat ca org ve bo vao tree
                e.Result = OrganizationFactory.Instance.GetChannel().GetOrgList(storageService.CurrentSessionId, filter);
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
        }
        /// <summary>
        /// bgwLoadOrgList_RunWorkerCompleted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwLoadOrgList_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if (e.Result == null)
            {
                return;
            }
            // Get result from DoWork method
            List<OrgCustomerDto> result = (List<OrgCustomerDto>)e.Result;
            if (result != null)
            {
                foreach (OrgCustomerDto org in result)
                {
                    // kiem tra neu khong phai to chuc phat hanh the moi add vao tree
                    if (!org.Issuer.Equals(SystemSettings.Instance.Master))
                    {

                        TreeNode DeviceDoorGroupNode = new TreeNode();
                        DeviceDoorGroupNode.Text = org.Name;
                        DeviceDoorGroupNode.Name = Convert.ToString(org.OrgId);
                        rootNode.Nodes.Add(DeviceDoorGroupNode);
                    }
                }
                trvOrganizations.Sort();
                rootNode.Expand();
            }
        }
        /// <summary>
        /// bgwLoadOrgList_DoWork
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwLoadTimeConfigByOrgId_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                //load TimeconfigListByOrgId
                e.Result = lstTimeConfig = TimeKeepingTimeConfigFactory.Instance.GetChannel().GetListTimeConfigByOrgId(StorageService.CurrentSessionId, Convert.ToInt64(selectedOrgNode.Name));
                //20170304 Bug #655 Fix [TimeKeeping] - Time Keeping Configure - Trang Vo Start
                if (!CheckHaveASession(lstTimeConfig))
                {
                    // khong co ca lam viec trong lstTimeConfig
                    e.Result = lstTimeConfig = new List<TimeConfig>();
                }
                //20170304 Bug #655 Fix [TimeKeeping] - Time Keeping Configure - Trang Vo End
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

        }
        /// <summary>
        /// bgwLoadOrgList_RunWorkerCompleted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwLoadTimeConfigByOrgId_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if (e.Result == null)
            {
                return;
            }
            // Get result from DoWork method show view
            ShowDataConfig();
        }
        /// <summary>
        /// Kiem tra xem list lây về có bao nhieu phan tu de biet ve control
        /// </summary>
        /// <returns></returns>
        private int CheckMaxControll(int dayOfWeek)
        {
            Dictionary<int, List<SessionWorking>> Dictionary = PareListObjectToShow(lstTimeConfig);
            //truong hop chu nhat khong co cau hinh cham cong
            try
            {
                if (Dictionary != null)
                {
                    //do tat ca cac Dictionary co so luong controll bang nhau nen chi can lay 1 phan tu
                    List<SessionWorking> list = Dictionary[dayOfWeek];
                    return list.Count;
                }
            }
            catch (Exception ex)
            {

            }
            return 0;
        }
        /// <summary>
        /// Show dữ liệu cho người dùng xem
        /// </summary>
        private void ShowDataConfig()
        {
            //Xóa bỏ các controll của tổ chức load trước đó
            //neu danh sách gửi về có dữ liệu
            if (lstTimeConfig.Count > 0)
            {
                //danh sach cac ngay co cau hinh cham cong
                Dictionary<int, List<SessionWorking>> Dictionary = PareListObjectToShow(lstTimeConfig);
                //dem so control can phai ve
                for (int i = 2; i < 9; i++)
                {
                    int numberControllDraw = CheckMaxControll(i);
                    //neu 3 control moi ve giữ lại 2 controll mặc định
                    //duyet tu thu 2 toi chu nhat

                    if (Dictionary.ContainsKey(i))
                    {
                        List<SessionWorking> lstSessionWorking = Dictionary[i];
                        //đồng bộ dữ liệu lên giao diện
                        ShowDataInDay(i, lstSessionWorking, true);
                    }
                }
            }
            else
            {
                //nếu danh sách trả về là rỗng
                //show dữ liệu mặc định
                ShowDataDefault();
            }
        }
        /// <summary>
        /// Sau khi lay duoc list timconfig tu db ve thi pare nguoc lai de show cho nugoi dung xem
        /// </summary>
        /// <param name="result"></param>
        private Dictionary<int, List<SessionWorking>> PareListObjectToShow(List<TimeConfig> result)
        {
            Dictionary<int, List<SessionWorking>> dictionaryPare = new Dictionary<int, List<SessionWorking>>();
            if (null != result)
            {
                for (int i = 0; i < result.Count; i++)
                {
                    //lay ra tung doi tuong timeconfig server gui ve
                    TimeConfig timeConfig = result[i];
                    //pare chuoi json trong timconfig thanh list các ca làm viêc
                    List<SessionWorking> lstSessionWorking = PareJsonToList(timeConfig.sessionWorking, new List<SessionWorking>().GetType()) as List<SessionWorking>;
                    //chuyen nguoc lai thanh Dicontrol de show len man hinh
                    dictionaryPare.Add(timeConfig.dayOfWeek, lstSessionWorking);
                }
            }
            return dictionaryPare;
        }
        /// <summary>
        /// Hàm này được gọi khi tổ chức đó chưa có cấu hình thời gian
        /// set lai giá trị 0 cho tất cả các control
        /// </summary>
        private void ShowDataDefault()
        {
            for (int i = 2; i < 9; i++)
            {
                //tim ra panel cua các ngày trong tuần
                Control[] panelDayOfWeek = panelcontent.Controls.Find(String.Format("pnlDay{0}", i), false);
                Panel panel = (Panel)panelDayOfWeek[0];
                //tìm check box của các ngày trong tuần
                Control[] checkBox = panel.Controls.Find(String.Format("chbxDay{0}", i), false);
                CheckBox chbxDayOfWeek = (CheckBox)checkBox[0];
                //set false cho check box
                chbxDayOfWeek.Checked = false;
                //lay ra session ca 1 ca 2 trong 1 ngay
                //List này chỉ có 1 session12
                List<session12> session = DicControl[i];
                session[0].SetDefaultValue();
            }
        }

        /// <summary>
        /// show data for view
        /// </summary>
        /// <param name="dayOfWeek">day of week</param>
        /// <param name="lstSessionWorking">lstSessionWorking</param>
        /// <param name="flag">dayofweek is check or uncheck</param>
        private void ShowDataInDay(int dayOfWeek, List<SessionWorking> lstSessionWorking, bool flag)
        {
            //lay panel chứa ngày trong tuần
            Control[] panelDayOfWeek = panelcontent.Controls.Find(String.Format("pnlDay{0}", dayOfWeek), false);
            Panel panel = (Panel)panelDayOfWeek[0];
            //lấy checkbox cấu hình châm công của ngày
            Control[] checkBox = panel.Controls.Find(String.Format("chbxDay{0}", dayOfWeek), false);
            CheckBox chbxDayOfWeek = (CheckBox)checkBox[0];
            //fag này xem có check chấm công của ngày hay không
            chbxDayOfWeek.Checked = flag;
            //lay ra tất cả các ca làm việc trong 1 ngày
            List<session12> lstSession = DicControl[dayOfWeek];
            int j = 0;
            foreach (session12 item in lstSession)
            {
                foreach (SessionWorking session in lstSessionWorking)
                {
                    item.Add(j, session);
                    j++;
                }
            }
        }
        /// <summary>
        /// Part 1 chuoi json thanh list  List<SessionWorking>
        /// </summary>
        /// <param name="json"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private Object PareJsonToList(string json, Type type)
        {
            Object result = JsonConvert.DeserializeObject(json, type);
            return result;
        }
        /// <summary>
        /// Lưu các ca làm việc
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwSaveSession_DoWork(object sender, DoWorkEventArgs e)
        {
            //lấy dữ liệu cần lưu
            List<TimeConfig> lstTimconfig = PareList();
            //20170304 Bug #655 Fix [TimeKeeping] - Time Keeping Configure - Trang Vo Start
            if (null != lstTimconfig && CheckHaveASession(lstTimconfig))
            {
                //20170304 Bug #655 Fix [TimeKeeping] - Time Keeping Configure - Trang Vo End
                //org cần lưu theo cấu hình thời gian
                long orgId = Int32.Parse(selectedOrgNode.Name);
                try
                {
                    if (lstTimconfig.Count > 0 && orgId != -1)
                    {
                        e.Result = (int)Status.SUCCESS == TimeKeepingTimeConfigFactory.Instance.GetChannel().InsertListTimconfig(StorageService.CurrentSessionId, lstTimconfig, orgId);
                    }
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
                //20170304 Bug #655 Fix [TimeKeeping] - Time Keeping Configure - Trang Vo Start 
            }
            else
            {
                if (lstTimconfig.Count > 0)
                    MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "NotSeleteSessionConfigTime"));
                else
                    MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "NotSeleteDayConfigTime"));
                checkNotSelectSession = true;
            }
            //20170304 Bug #655 Fix [TimeKeeping] - Time Keeping Configure - Trang Vo End
        }
        /// <summary>
        /// bgwLoadOrgList_RunWorkerCompleted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwSaveSession_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //20170304 Bug #655 Fix [TimeKeeping] - Time Keeping Configure - Trang Vo Start
            if (e.Cancelled || null == e.Result)
            {
                //20170304 Bug #655 Fix [TimeKeeping] - Time Keeping Configure - Trang Vo End
                return;
            }
            if ((bool)e.Result)
            {
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "InsertTimeConfigSuccess"));
                //lưu thành công
                LoadTimeConfigByOrgId();

            }
            else
            {
                //Lưu thất bại
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "InsertTimeConfigFail"));
            }
        }
        #region CAB events

        [CommandHandler(TimeCommandName.ShowTimeConfig)]
        public void ShowTimconfigHandler(object s, EventArgs e)
        {
            UsrTimeConfig ucConfig = workItem.Items.Get<UsrTimeConfig>(DefineName.TimeConfig);
            if (ucConfig == null)
            {
                ucConfig = workItem.Items.AddNew<UsrTimeConfig>(DefineName.TimeConfig);
            }
            else if (ucConfig.IsDisposed)
            {
                workItem.Items.Remove(ucConfig);
                ucConfig = workItem.Items.AddNew<UsrTimeConfig>(DefineName.TimeConfig);
            }
            workItem.Workspaces[WorkspaceName.MainWorkspace].Show(ucConfig);
            ucConfig.Parent.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, DefineName.MenuTimeConfig);
        }
        #endregion
        private Dictionary<int, List<session12>> DicControl = new Dictionary<int, List<session12>>();
        #region InitComponet
        private void Init()
        {
            // monday
            List<session12> lstMonday = new List<session12>();
            lstMonday.Add(sessiont212);
            DicControl.Add(2, lstMonday);

            //tuesday
            List<session12> lstTuesday = new List<session12>();
            lstTuesday.Add(sessiont312);
            DicControl.Add(3, lstTuesday);

            //wednesday
            List<session12> lstWednesday = new List<session12>();
            lstWednesday.Add(sessiont412);
            DicControl.Add(4, lstWednesday);

            //thursday
            List<session12> lstThursday = new List<session12>();
            lstThursday.Add(sessiont512);
            DicControl.Add(5, lstThursday);


            //friday
            List<session12> lstFriday = new List<session12>();
            lstFriday.Add(sessiont612);
            DicControl.Add(6, lstFriday);

            //saturday
            List<session12> lstSaturday = new List<session12>();
            lstSaturday.Add(sessiont712);
            DicControl.Add(7, lstSaturday);

            //sunday
            List<session12> lstSunday = new List<session12>();
            lstSunday.Add(sessiont812);
            DicControl.Add(8, lstSunday);

        }
        #endregion


        //20170304 Bug #655 Fix [TimeKeeping] - Time Keeping Configure - Trang Vo Start
        /// <summary>
        /// fig bug Bug #655
        /// </summary>
        /// <param name="?"></param>
        private bool CheckHaveASession(List<TimeConfig> lstTimconfig)
        {
            //tao bien tam
            int cntSession = 0;
            //kiem tra list
            foreach (TimeConfig timeConfig in lstTimconfig)
            {
                if (timeConfig.sessionWorking.Trim().Equals("[]"))
                    cntSession++;
            }
            //kiem tra gia tri cntSession
            if (cntSession == lstTimconfig.Count)
                return false;
            return true;
        }
        //20170304 Bug #655 Fix [TimeKeeping] - Time Keeping Configure - Trang Vo End



        /// <summary>
        ///  lay ra cac ngay trong tuan co cau hinh cham cong
        /// </summary>
        private Dictionary<int, List<session12>> GetDayWorking()
        {
            Dictionary<int, List<session12>> result = new Dictionary<int, List<session12>>();
            for (int i = 2; i < 9; i++)
            {
                Control[] panel = panelcontent.Controls.Find(String.Format("pnlDay{0}", i), false);
                if (panel.Length == 1)
                {
                    Control[] check = ((Panel)panel[0]).Controls.Find(String.Format("chbxDay{0}", i), false);
                    CheckBox checkbox = ((CheckBox)check[0]);
                    Control[] session = ((Panel)panel[0]).Controls.Find(String.Format("sessiont{0}12", i), false);
                    session12 session12 = ((session12)session[0]);
                    //nếu ngày có chấm công mới lấy dữ liệu để lưu
                    if (checkbox.Checked)
                    {
                        session12.Enabled = true;
                        List<session12> list = DicControl[i];
                        result.Add(i, list);
                    }

                }
            }
            return result;
        }
        //
        /// <summary>
        /// lấy dữ liệu ngày thứ 2 để đồng bộ cho các ngay còn lại trong tuần
        /// </summary>
        /// <returns></returns>
        private List<session12> GetValueMonday()
        {
            //lay ra tat ca cac ca lam viec trong ngay thu 2
            return DicControl[2];
        }
        /// <summary>
        /// ham bat su kien khi click vao nut dong bo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSynchonize_Click(object sender, EventArgs e)
        {
            //lay cac ca lam viec trong mot ngay
            List<session12> lst = GetValueMonday();
            //duyet tu thu 3 den chu nhat
            for (int i = 3; i < 9; i++)
            {
                //lay ra tat ca cac session12 trong 1 ngay
                // 1 session12 chua 1 hoac 2 ca lam viec
                List<session12> session = DicControl[i];
                //duyet tung session, sau do kiem tra list co dữ liệu thuộc trong session này không nếu có thì add gui đi không thi thoi
                for (int j = 0; j < lst.Count; j++)
                {
                    //lay ra tuan tu các session12 trong dicontrol 1 ngay
                    session12 sesion12 = lst[j];
                    List<SessionWorking> sessionWorking = sesion12.GetValueToSyn();
                    if (null != sessionWorking)
                    {
                        session[j].ToEntity(sessionWorking);
                    }
                }
            }
        }
        /// <summary>
        /// Tu mot Dictionary chua ngay trong tuan va cac ca lam viec cua tung ngay pare ra thanh mot list cac cau hinh thoi gian
        /// </summary>
        /// <returns></returns>
        public List<TimeConfig> PareList()
        {
            //list cac ngay trong tuan co cac ca lam viec
            List<TimeConfig> lstTimconfig = new List<TimeConfig>();
            //lay ve tat ca cac ngay co ca lam viec
            Dictionary<int, List<session12>> listSession = GetDayWorking();
            //duyet tu thu 2 den chu nhat muc dich la de lay key cho saveObject
            for (int i = 2; i < 9; i++)
            {
                //kiem tra xem nguoi dung co chon ngay cham cong hok
                if (listSession.ContainsKey(i))
                {
                    List<SessionWorking> result = new List<SessionWorking>();
                    //lay ra cac list session cua tung ngay
                    List<session12> lstsession = listSession[i];
                    //lay ra tung ca trong 1 session
                    for (int j = 0; j < lstsession.Count; j++)
                    {
                        //lay ra tung list sessionworking cua tung session12
                        session12 session12 = lstsession[j];
                        result.AddRange(session12.GetValueToSave());
                    }
                    //pare list object thanh chuoi string sau do gan vao timconfig
                    TimeConfig timconfig = SaveObject(i, result);
                    lstTimconfig.Add(timconfig);
                }
            }
            return lstTimconfig;
        }
        /// <summary>
        /// nút save
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBoxManager.ShowQuestionMessageBox(this, MessageValidate.GetMessage(rm, "timeconfigTimekeeping"), MessageValidate.GetConfirm(rm)) == DialogResult.Yes)
            {
                if (!bgwSaveSession.IsBusy)
                {
                    bgwSaveSession.RunWorkerAsync();
                }
            }
        }
        /// <summary>
        /// Dùng để chuyển các list ca làm việc thành 1 ngày làm việc
        /// </summary>
        /// <param name="key"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public TimeConfig SaveObject(int key, List<SessionWorking> list)
        {
            TimeConfig timconfig = new TimeConfig();
            //Chuyển một list object thành chuỗi json
            String data = JsonConvert.SerializeObject(list);
            timconfig.dayOfWeek = key;
            timconfig.sessionWorking = data;
            return timconfig;
        }
        /// <summary>
        /// nút reload click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReloadConfig_Click(object sender, EventArgs e)
        {
            //gọi lại hàm 
            LoadTimeConfigByOrgId();
        }

        private void chbxDay2_CheckedChanged(object sender, EventArgs e)
        {
            Control[] panel = panelcontent.Controls.Find(String.Format("pnlDay2"), false);
            if (panel.Length == 1)
            {
                Control[] check = ((Panel)panel[0]).Controls.Find(String.Format("chbxDay2"), false);
                CheckBox checkbox = ((CheckBox)check[0]);
                Control[] session = ((Panel)panel[0]).Controls.Find(String.Format("sessiont212"), false);
                session12 session12 = ((session12)session[0]);
                //nếu ngày có chấm công mới lấy dữ liệu để lưu
                if (checkbox.Checked)
                {
                    session12.Enabled = true;
                }
                else
                {
                    session12.Enabled = false;
                }

            }
        }
        /// <summary>
        /// chbxDay3_CheckedChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chbxDay3_CheckedChanged(object sender, EventArgs e)
        {
            Control[] panel = panelcontent.Controls.Find(String.Format("pnlDay3"), false);
            if (panel.Length == 1)
            {
                Control[] check = ((Panel)panel[0]).Controls.Find(String.Format("chbxDay3"), false);
                CheckBox checkbox = ((CheckBox)check[0]);
                Control[] session = ((Panel)panel[0]).Controls.Find(String.Format("sessiont312"), false);
                session12 session12 = ((session12)session[0]);
                //nếu ngày có chấm công mới lấy dữ liệu để lưu
                if (checkbox.Checked)
                {
                    session12.Enabled = true;
                }
                else
                {
                    session12.Enabled = false;
                }

            }
        }
        /// <summary>
        /// chbxDay4_CheckedChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chbxDay4_CheckedChanged(object sender, EventArgs e)
        {
            Control[] panel = panelcontent.Controls.Find(String.Format("pnlDay4"), false);
            if (panel.Length == 1)
            {
                Control[] check = ((Panel)panel[0]).Controls.Find(String.Format("chbxDay4"), false);
                CheckBox checkbox = ((CheckBox)check[0]);
                Control[] session = ((Panel)panel[0]).Controls.Find(String.Format("sessiont412"), false);
                session12 session12 = ((session12)session[0]);
                //nếu ngày có chấm công mới lấy dữ liệu để lưu
                if (checkbox.Checked)
                {
                    session12.Enabled = true;
                }
                else
                {
                    session12.Enabled = false;
                }

            }
        }
        /// <summary>
        /// chbxDay5_CheckedChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chbxDay5_CheckedChanged(object sender, EventArgs e)
        {
            Control[] panel = panelcontent.Controls.Find(String.Format("pnlDay5"), false);
            if (panel.Length == 1)
            {
                Control[] check = ((Panel)panel[0]).Controls.Find(String.Format("chbxDay5"), false);
                CheckBox checkbox = ((CheckBox)check[0]);
                Control[] session = ((Panel)panel[0]).Controls.Find(String.Format("sessiont512"), false);
                session12 session12 = ((session12)session[0]);
                //nếu ngày có chấm công mới lấy dữ liệu để lưu
                if (checkbox.Checked)
                {
                    session12.Enabled = true;
                }
                else
                {
                    session12.Enabled = false;
                }

            }
        }
        /// <summary>
        /// chbxDay6_CheckedChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chbxDay6_CheckedChanged(object sender, EventArgs e)
        {
            Control[] panel = panelcontent.Controls.Find(String.Format("pnlDay6"), false);
            if (panel.Length == 1)
            {
                Control[] check = ((Panel)panel[0]).Controls.Find(String.Format("chbxDay6"), false);
                CheckBox checkbox = ((CheckBox)check[0]);
                Control[] session = ((Panel)panel[0]).Controls.Find(String.Format("sessiont612"), false);
                session12 session12 = ((session12)session[0]);
                //nếu ngày có chấm công mới lấy dữ liệu để lưu
                if (checkbox.Checked)
                {
                    session12.Enabled = true;
                }
                else
                {
                    session12.Enabled = false;
                }

            }
        }
        /// <summary>
        /// chbxDay7_CheckedChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chbxDay7_CheckedChanged(object sender, EventArgs e)
        {
            Control[] panel = panelcontent.Controls.Find(String.Format("pnlDay7"), false);
            if (panel.Length == 1)
            {
                Control[] check = ((Panel)panel[0]).Controls.Find(String.Format("chbxDay7"), false);
                CheckBox checkbox = ((CheckBox)check[0]);
                Control[] session = ((Panel)panel[0]).Controls.Find(String.Format("sessiont712"), false);
                session12 session12 = ((session12)session[0]);
                //nếu ngày có chấm công mới lấy dữ liệu để lưu
                if (checkbox.Checked)
                {
                    session12.Enabled = true;
                }
                else
                {
                    session12.Enabled = false;
                }

            }
        }
        /// <summary>
        /// chbxDay8_CheckedChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chbxDay8_CheckedChanged(object sender, EventArgs e)
        {
            Control[] panel = panelcontent.Controls.Find(String.Format("pnlDay8"), false);
            if (panel.Length == 1)
            {
                Control[] check = ((Panel)panel[0]).Controls.Find(String.Format("chbxDay8"), false);
                CheckBox checkbox = ((CheckBox)check[0]);
                Control[] session = ((Panel)panel[0]).Controls.Find(String.Format("sessiont812"), false);
                session12 session12 = ((session12)session[0]);
                //nếu ngày có chấm công mới lấy dữ liệu để lưu
                if (checkbox.Checked)
                {
                    session12.Enabled = true;
                }
                else
                {
                    session12.Enabled = false;
                }

            }
        }
    }
}
