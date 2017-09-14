using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sTimeKeeping.Model;
using System.Resources;
using Microsoft.Practices.CompositeUI;
using sWorldModel;
using CommonHelper.Constants;
using CommonHelper.Utils;
using sWorldModel.TransportData;
using CommonHelper.Config;
using CommonControls;
using System.ServiceModel;
using sWorldModel.Exceptions;
using sWorldModel.Filters;
using Microsoft.Practices.CompositeUI.Commands;
using sTimeKeeping.Constants;
using sTimeKeeping.Factory;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using JavaCommunication.Factory;

namespace sTimeKeeping.WorkItems
{
    /// <summary>
    ///  class UsrUserTimeConfig : UserControl
    /// </summary>
    public partial class UsrUserTimeConfig : UserControl
    {
        #region properties

        private BackgroundWorker bgwLoadOrgList;
        private BackgroundWorker bgwLoadConfig;
        private BackgroundWorker bgwSaveConfig;
        private Font startupNodeFont;
        private List<OrgCustomerDto> result;
        private List<List<UserTimeConfig>> listUserTimeConfig;
        private TreeNode memberNodeSelected;
        private TreeNode rootNode;
        private ResourceManager rm;
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
        public UsrUserTimeConfig()
        {
            InitializeComponent();
            RegisterEvent();
        }
        #endregion

        #region init
        /// <summary>
        /// Dang ky su kien
        /// </summary>
        private void RegisterEvent()
        {
            // Tree View
            trvOrganizations.BeforeSelect += trvOrganizations_BeforeSelect;
            trvOrganizations.AfterSelect += trvOrganizations_AfterSelect;

            // Load Tree View
            bgwLoadOrgList = new BackgroundWorker();
            bgwLoadOrgList.WorkerSupportsCancellation = true;
            bgwLoadOrgList.DoWork += bgwLoadOrgList_DoWork;
            bgwLoadOrgList.RunWorkerCompleted += bgwLoadOrgList_RunWorkerCompleted;

            // Load Config
            bgwLoadConfig = new BackgroundWorker();
            bgwLoadConfig.WorkerSupportsCancellation = true;
            bgwLoadConfig.DoWork += bgwLoadConfig_DoWork;
            bgwLoadConfig.RunWorkerCompleted += bgwLoadConfig_RunWorkerCompleted;

            // Save Config
            bgwSaveConfig = new BackgroundWorker();
            bgwSaveConfig.WorkerSupportsCancellation = true;
            bgwSaveConfig.DoWork += bgwSaveConfig_DoWork;
            bgwSaveConfig.RunWorkerCompleted += bgwSaveConfig_RunWorkerCompleted;

            startupNodeFont = trvOrganizations.Font;
            btnReload.Click += (s, e) => LoadOrgList();
            Load += OnFormLoad;

            btnReloadConfig.Click += btnReloadConfig_Click;
            btnSave.Click += btnSave_Click;
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
            // load Language
            LoadLanguage();
            // Init Tree List
            InitTreeList();
            // Load Org List
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
        #endregion

        #region tree

        /// <summary>
        /// Khởi tạo tree
        /// </summary>
        private void InitTreeList()
        {
            rootNode = new TreeNode();
            rootNode.Text = MessageValidate.GetMessage(rm, "All");
            rootNode.Name = "-1";
            rootNode.Tag = ConstantsValue.ROOT_NODE;
            trvOrganizations.Nodes.Add(rootNode);
        }

        /// <summary>
        /// Tạo tree org 
        /// </summary>
        /// <param name="lstOrgCustomerDto"></param>
        public void GetTree(List<OrgCustomerDto> lstOrgCustomerDto)
        {
            //kiem tra null đây để sử dụng cho đệ quy
            if (lstOrgCustomerDto != null)
            {
                foreach (OrgCustomerDto org in lstOrgCustomerDto)
                {
                    if (!org.Issuer.Equals(SystemSettings.Instance.Master))
                    {
                        TreeNode orgNode = new TreeNode();
                        orgNode.Text = org.Name;
                        orgNode.Name = Convert.ToString(org.OrgId);
                        orgNode.Tag = ConstantsValue.ORG_TAG;
                        //tạo tree con từ tree con tạo danh sách người
                        GetSubTree(org, org.OrgId, orgNode);
                        rootNode.Nodes.Add(orgNode);
                    }
                }

            }
        }

        /// <summary>
        /// Tạo tree con
        /// </summary>
        /// <param name="org">object org</param>
        /// <param name="orgId">orgid</param>
        /// <param name="node">node từ parent gui qua để add</param>
        public void GetSubTree(OrgCustomerDto org, long orgId, TreeNode node)
        {
            //doi tượng này sử dụng cho vòng lặp đệ quy
            List<SubOrgCustomerDTO> lstSubOrgCustomerDTO = org.SubOrgList;
            //lọc kiểm tra điều kiện 
            List<SubOrgCustomerDTO> lstSubOrgCustomer = lstSubOrgCustomerDTO.Where(key => key.parentOrgId == orgId).ToList();
            if (lstSubOrgCustomer != null)
            {
                foreach (SubOrgCustomerDTO subOrg in lstSubOrgCustomer)
                {
                    if (subOrg.OrgCode == ConstantsValue.CODE_BAO_CHI)
                        continue;
                    TreeNode subOrgNode = new TreeNode();
                    subOrgNode.Text = subOrg.Name;
                    subOrgNode.Name = Convert.ToString(subOrg.SubOrgId);
                    subOrgNode.Tag = ConstantsValue.SUB_TAG;
                    //điều kiện để add vào nút cha
                    if (orgId == subOrg.parentOrgId)
                    {
                        node.Nodes.Add(subOrgNode);
                        SetMemberInTree(subOrg.SubOrgId, subOrgNode);
                    }
                    //gọi đệ quy
                    GetSubTree(org, subOrg.SubOrgId, subOrgNode);
                }
            }
        }

        /// <summary>
        /// Add tất cả các member thuộc suborg để add vào tree
        /// </summary>
        /// <param name="subOrgId"></param>
        /// <param name="node"></param>
        private void SetMemberInTree(long subOrgId, TreeNode node)
        {
            List<Member> lstMember = new List<Member>();
            //get all member of suborg
            lstMember = OrganizationFactory.Instance.GetChannel().GetMemberListBySubOrg(storageService.CurrentSessionId, subOrgId);
            if (null != lstMember)
            {
                foreach (Member item in lstMember)
                {
                    if (item.Active)
                    {
                        TreeNode memberNode = new TreeNode();
                        memberNode.Text = item.LastName + " " + item.FirstName;
                        memberNode.Name = Convert.ToString(item.Id);
                        // để phân biệt node của người hoặc của suborg
                        memberNode.Tag = ConstantsValue.MEMBER_TAG;
                        node.Nodes.Add(memberNode);
                    }
                }
            }
        }

        /// <summary>
        /// get orgId By Selected Id
        /// </summary>
        /// <param name="parentID"></param>
        /// <param name="selectedID"></param>
        /// <returns></returns>
        private long getOrgIdBySelectedId(long selectedParentId)
        {
            if (null != result)
            {
                foreach (OrgCustomerDto item in result)
                {
                    if (item.SubOrgList != null)
                    {
                        List<SubOrgCustomerDTO> SubOrgCustomerDTO = item.SubOrgList.Where(key => key.SubOrgId == selectedParentId).ToList();
                        if (SubOrgCustomerDTO.Count > 0)
                        {
                            SubOrgCustomerDTO SubOrgCustomer = SubOrgCustomerDTO[0];
                            return SubOrgCustomer.OrgId;
                        }
                    }
                }
            }
            return -1;
        }

        #endregion

        #region event
        /// <summary>
        /// Ham nay load danh sach cac to chuc vao tree, ham nay duoc load sau khi usercontroll duoc load
        /// </summary>
        private void LoadOrgList()
        {
            memberNodeSelected = null;
             btnSave.Enabled = false;
            if (!bgwLoadOrgList.IsBusy)
            {
                rootNode.Nodes.Clear();
                bgwLoadOrgList.RunWorkerAsync();
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

            if (memberNodeSelected != null)
            {
                memberNodeSelected.NodeFont = new Font(startupNodeFont, FontStyle.Regular);
                memberNodeSelected.Text = memberNodeSelected.Text;
            }
        }
        /// <summary>
        /// trvOrganizations_AfterSelect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trvOrganizations_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // 20100305 Fix bug not enable button save and button refesh start
            btnSave.Enabled = btnReloadConfig.Enabled = false;
            // 20100305 Fix bug not enable button save and button refesh end

            TreeNode selectedNode = e.Node;
            TreeNode parentNode = new TreeNode();
            if (selectedNode != null)
            {
                parentNode = selectedNode.Parent;
                selectedNode.NodeFont = new Font(startupNodeFont, FontStyle.Bold);
                selectedNode.Text = selectedNode.Text;

                if (memberNodeSelected != null && selectedNode == memberNodeSelected)
                {
                    return;
                }
                memberNodeSelected = selectedNode;

                // LoadTimeConfigByOrgId();
                bool memTag = selectedNode.Tag.Equals(ConstantsValue.MEMBER_TAG);

                SetShowOrHideUpdateOrg(memTag);
                RemovePanel();

                // load cau hinh cham cong cho tung nguoi
                if (memTag)
                {
                    // 20100305 Fix bug not enable button save and button refesh start
                    btnSave.Enabled = btnReloadConfig.Enabled = true;
                    // 20100305 Fix bug not enable button save and button refesh end
                    LoadUserTimeConfig();
                }
            }
        }

        /// <summary>
        /// Get Member Filter
        /// </summary>
        /// <returns></returns>
        private MemberFilter GetMemberFilter()
        {
            MemberFilter filter = new MemberFilter();
            return filter;
        }
        /// <summary>
        /// Set an hoac hien cac button add va update
        /// </summary>
        private void SetShowOrHideUpdateOrg(bool memTag)
        {
            btnSave.Enabled = memTag;
        }
        /// <summary>
        /// ReLoadTrvOrganizations: reload suborg => bo phan tree cua member
        /// </summary>
        private void ReLoadTrvOrganizations()
        {
            TreeNode root = trvOrganizations.Nodes[0];
            foreach (TreeNode orgNode in root.Nodes)
            {
                foreach (TreeNode subNode in orgNode.Nodes)
                {
                    //if (subNode.Equals(selectedOrgNode))
                    //{
                    //    continue;
                    //}
                    subNode.Nodes.Clear();
                }
            }
        }
        /// <summary>
        /// btnReloadConfig_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReloadConfig_Click(object sender, EventArgs e)
        {
            if (null != memberNodeSelected)
            {
                if (memberNodeSelected.Tag.Equals(ConstantsValue.MEMBER_TAG))
                {
                    LoadUserTimeConfig();
                }
                else
                {
                    RemovePanel();
                }
            }
        }
        /// <summary>
        /// remove Panel
        /// </summary>
        private void RemovePanel()
        {
            for (int i = 2; i < 9; i++)
            {
                Panel panel = (Panel)(panelcontent.Controls.Find(String.Format("pnlDay{0}", i), false)[0]);
                CheckBox chbxDayOfWeek = (CheckBox)(panel.Controls.Find(String.Format("chbxDay{0}", i), false)[0]);
                usersessionworking12 usworking12 = (usersessionworking12)(panel.Controls.Find(String.Format("usersessionworking12{0}", i), false)[0]);
                foreach (Control control in panel.Controls)
                {
                    if (control.Equals(chbxDayOfWeek))
                    {
                        ((CheckBox)control).Checked = false;
                        continue;
                    }
                    if (control.Equals(usworking12))
                    {
                        ((usersessionworking12)control).SetDefaultValue();
                        continue;
                    }
                    panel.Controls.Remove(control);
                }
            }
        }
        /// <summary>
        /// btnSave_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBoxManager.ShowQuestionMessageBox(this, MessageValidate.GetMessage(rm, "AddUserTimeConfigQues")) == System.Windows.Forms.DialogResult.Yes)
            {
                if (!bgwSaveConfig.IsBusy && null != memberNodeSelected && memberNodeSelected.Tag.Equals(ConstantsValue.MEMBER_TAG))
                {
                    bgwSaveConfig.RunWorkerAsync();
                }
            }
        }
        #endregion

        #region backgroundWorker
        /// <summary>
        /// bgwLoadOrgList_DoWork
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwLoadOrgList_DoWork(object sender, DoWorkEventArgs e)
        {
            List<OrgCustomerDto> result = null;
            OrgFilterDto filter = new OrgFilterDto();
            try
            {
                // kiem tra org co duoc hien thi hay khong
                if (!((SystemSettings.Instance.OrgCode).Equals("") || (SystemSettings.Instance.OrgCode).Equals("ALL")))
                {
                    filter.OrgCode = SystemSettings.Instance.OrgCode;
                    filter.FilterByOrgCode = true;
                }

                // get all org
                e.Result = result = OrganizationFactory.Instance.GetChannel().GetOrgList(storageService.CurrentSessionId, filter);
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
            result = (List<OrgCustomerDto>)e.Result;
            GetTree(result);
                rootNode.Expand();
        }

     
        /// <summary>
        /// bgwLoadConfig_DoWork
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwLoadConfig_DoWork(object sender, DoWorkEventArgs e)
        {
            // List<MemberCustomerDTO> result = null;
            List<long> memberList = e.Argument as List<long>;
            try
            {
                // load config
                long orgid = getOrgIdBySelectedId(Convert.ToInt32(memberNodeSelected.Parent.Name));
                e.Result = listUserTimeConfig = TimeKeepingUserTimeConfigFactory.Instance.GetChannel().getListUserTimeConfigByMemberId(storageService.CurrentSessionId, orgid, memberList);

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
        /// bgwLoadConfig_RunWorkerCompleted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwLoadConfig_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            List<List<UserTimeConfig>> result = e.Result as List<List<UserTimeConfig>>;
            if (null != result && result.Count > 0)
            {
                LoadConfigOfMember(result[0]);
            }
            //20170304 Bug #656 Fix [TimeKeeping] - Time Keeping Configure - Trang Vo Start
            else
            {
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "NotTimeConfig"));
            }
            //20170304 Bug #656 Fix [TimeKeeping] - Time Keeping Configure - Trang Vo End
        }
        /// <summary>
        /// bgwSaveConfig_DoWork
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwSaveConfig_DoWork(object sender, DoWorkEventArgs e)
        {
            if (null != listUserTimeConfig && listUserTimeConfig.Count != 0)
            {
                //lấy dữ liệu cần lưu
                List<UserTimeConfig> listTimconfig = PareList();
                try
                {
                   foreach (UserTimeConfig usTConfig in listTimconfig)
                   {

                       e.Result = TimeKeepingUserTimeConfigFactory.Instance.GetChannel().update(storageService.CurrentSessionId, usTConfig);
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
            }
        }

        
        /// <summary>
        /// bgwSaveConfig_RunWorkerCompleted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwSaveConfig_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if (((int)e.Result) == 0)
            {
                //lưu thành công
                //LoadTimeConfigByOrgId();
            }
            else
            {
                //Lưu thất bại
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "InsertTimeConfigFail"));
            }
        }
        #endregion

        #region load config
        /// <summary>
        /// Tao du lieu luu xuong
        /// </summary>
        /// <returns></returns>
        private List<UserTimeConfig> PareList()
        {
            List<UserTimeConfig> listResult = new List<UserTimeConfig>();
            List<SessionWorking> result = new List<SessionWorking>();
            for (int i = 2; i < 9; i++)
            {
                Panel panel = (Panel)(panelcontent.Controls.Find(String.Format("pnlDay{0}", i), false)[0]);
                CheckBox chbxDayOfWeek = (CheckBox)(panel.Controls.Find(String.Format("chbxDay{0}", i), false)[0]);
                if (chbxDayOfWeek.Checked)
                {
                    result = new List<SessionWorking>();
                    usersessionworking12 usworking12 = (usersessionworking12)(panel.Controls.Find(String.Format("usersessionworking12{0}", i), false)[0]);
                    //for tren list session cua tung ngay
                    foreach (Control control in panel.Controls)
                    {
                        if (control.Equals(chbxDayOfWeek))
                        {

                            continue;
                        }
                        //lay ra tung list usersessionworking cua tung usersession12
                        usworking12 = (usersessionworking12)(control);

                        result.AddRange(usworking12.GetValueToSave());
                    }
                    //pare list object thanh chuoi string sau do gan vao timconfig
                    UserTimeConfig timconfig = SaveObject(i, result);
                    listResult.Add(timconfig);
                }
                 
            }
            return listResult;
        }

        /// <summary>
        /// Add Panel UserTimeConfig
        /// </summary>
        /// <param name="userTimeConfig"></param>
        private void LoadList(UserTimeConfig userTimeConfig)
        {
            int index = userTimeConfig.dayOfWeek;

            Panel panel = (Panel)(panelcontent.Controls.Find(String.Format("pnlDay{0}", index), false)[0]);
            CheckBox chbxDayOfWeek = (CheckBox)(panel.Controls.Find(String.Format("chbxDay{0}", index), false)[0]);
            usersessionworking12 userssworking12 = (usersessionworking12)(panel.Controls.Find(String.Format("usersessionworking12{0}", index), false)[0]);
            chbxDayOfWeek.Checked = true;
            AddPanel(userTimeConfig, panel, userssworking12);
        }
        /// <summary>
        /// Dùng để chuyển các list ca làm việc thành 1 ngày làm việc
        /// </summary>
        /// <param name="key"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public UserTimeConfig SaveObject(int key, List<SessionWorking> list)
        {
            UserTimeConfig usertimconfig = new UserTimeConfig();
            // truong hop chi load config cua 1 member duy nhat
            foreach (UserTimeConfig us in listUserTimeConfig[0])
            {
                if (us.dayOfWeek == key)
                {
                    usertimconfig = us;
                    break;
                }
            }
            //Chuyển một list object thành chuỗi json
            String data = JsonConvert.SerializeObject(list);
            usertimconfig.sessionWorking = data;
            return usertimconfig;
        }
        /// <summary>
        /// Load UserTimeConfig
        /// </summary>
        private void LoadUserTimeConfig()
        {
            if (!bgwLoadConfig.IsBusy && memberNodeSelected != null && Convert.ToInt32(memberNodeSelected.Name) > 0)
            {
                bgwLoadConfig.RunWorkerAsync(GetMemberList());
            }
        }
        /// <summary>
        /// Get Member List
        /// </summary>
        /// <returns></returns>
        private List<long> GetMemberList()
        {
            List<long> result = new List<long>();

            if (memberNodeSelected.Tag.Equals(ConstantsValue.MEMBER_TAG))
            {
                result.Add(Convert.ToInt32(memberNodeSelected.Name));
            }
            return result;
        }
        /// <summary>
        /// Load Config Of Member
        /// </summary>
        /// <param name="listConfig"></param>
        private void LoadConfigOfMember(List<UserTimeConfig> listConfig)
        {
            RemovePanel();
            int size = listConfig.Count();
            // load config for new panel
            for (int i = 0; i < size; i++)
            {
                UserTimeConfig userTimeConfig = listConfig[i];

                LoadList(userTimeConfig);
            }
        }
        /// <summary>
        /// add panel
        /// </summary>
        /// <param name="userTimeConfig"></param>
        /// <param name="panel"></param>
        /// <param name="curSsWork"> control co san </param>
        private void AddPanel(UserTimeConfig userTimeConfig, Panel panel, usersessionworking12 curSsWork)
        {
            // chuyen doi json thanh list session working
            List<SessionWorking> ssWorking = ConvertFromStringToListSessionWorking(userTimeConfig.sessionWorking);
            // tinh toan gia tri tong so user control duoc hien thi
            int countUserControl = 0; 
            // neu tong so user control < 2
            // thuc hien set gia tri session working vao control co san
            
            curSsWork.Add(0, ssWorking[0]);
            curSsWork.Show(1);
            if (ssWorking.Count > 1){
                curSsWork.isShowChbx2 = true;
                curSsWork.Add(1, ssWorking[1]);
                curSsWork.Show(2);
                countUserControl = (ssWorking.Count / 3) + (ssWorking.Count % 3 > 0 ? 1 : 0);
            }
            if (ssWorking.Count > 2)
            {
                curSsWork.isShowChbx3 = true;
                curSsWork.Add(2, ssWorking[1]);
                curSsWork.Show(3);
                countUserControl = (ssWorking.Count / 3) + (ssWorking.Count % 3 > 0 ? 1 : 0);
            }
            int index = 0;
            // duyet tren tong so user control
            for ( int j = 1; j < countUserControl; j++)
            {
                usersessionworking12 us = null;
                index = j * 3 + 1;
                // tao user control 
                if ((j == countUserControl - 1) && (ssWorking.Count % 3 > 0))
                {
                    if (ssWorking.Count % 3 == 1)
                    us = new usersessionworking12(index, false, false);
                    else
                    {
                        us = new usersessionworking12(index, true, false);
                        us.Add(1, ssWorking[index]);
                    }
                }
                else
                {
                    us = new usersessionworking12(index, true, true);
                    us.Add(1, ssWorking[index]);
                    us.Add(2, ssWorking[index]);
                }
                us.Add(0, ssWorking[index - 1]);
                
                us.Dock = DockStyle.Bottom;
                // add user contol vao panel
                panel.Controls.Add(us);
            }
        }

        /// <summary>
        /// Convert From String To List SessionWorking
        /// </summary>
        /// <param name="strJson"></param>
        /// <returns> list object session working on day </returns>
        private static List<SessionWorking> ConvertFromStringToListSessionWorking(string strJson)
        {
            var jsonSerializer = new JavaScriptSerializer();
            List<SessionWorking> sessionWorkings = new List<SessionWorking>();
            if (null == strJson)
            {
                SessionWorking obj = new SessionWorking();
                sessionWorkings.Add(obj);
            }
            else
            {
                sessionWorkings = jsonSerializer.Deserialize<List<SessionWorking>>(strJson);
            }

            return sessionWorkings;
        }
        #endregion

        #region CAB events

        [CommandHandler(TimeCommandName.ShowUserTimeConfig)]
        public void ShowCardMgtMainHandler(object s, EventArgs e)
        {
            UsrUserTimeConfig uc = workItem.Items.Get<UsrUserTimeConfig>(DefineName.UserTimeConfig);
            if (uc == null)
            {
                uc = workItem.Items.AddNew<UsrUserTimeConfig>(DefineName.UserTimeConfig);
            }
            else if (uc.IsDisposed)
            {
                workItem.Items.Remove(uc);
                uc = workItem.Items.AddNew<UsrUserTimeConfig>(DefineName.UserTimeConfig);
            }
            workItem.Workspaces[WorkspaceName.MainWorkspace].Show(uc);
            uc.Parent.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, DefineName.MenuUserTimeConfig);
        }

        #endregion

    }
}
