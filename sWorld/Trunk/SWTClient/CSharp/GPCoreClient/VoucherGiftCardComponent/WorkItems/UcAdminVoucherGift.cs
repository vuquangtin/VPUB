using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonControls.Custom;
using Microsoft.Practices.CompositeUI.Commands;
using VoucherGiftCardComponent.Constants;
using Microsoft.Practices.CompositeUI;
using sWorldModel;
using CommonHelper.Constants;
using CommonControls;
using sWorldModel.Exceptions;
using JavaCommunication.Factory;
using sWorldModel.TransportData;
using CommonHelper.Utils;
using CommonHelper.Config;
using ImageAccessor;
using sWorldModel.Filters;
using System.ServiceModel;
using JavaCommunication;
using Microsoft.Practices.CompositeUI.EventBroker;
using SystemMgtComponent.Constants;
using sWorldModel.TransportData.Constants;
using System.Resources;
//using CommonHelper.Utils;

namespace VoucherGiftCardComponent.WorkItems
{
    public partial class UcAdminVoucherGift : CommonUserControl
    {        
        #region Properties
        // Height of filter box when it is hidden
        private int hiddenFilterBoxHeight = 0;
        // The original height of filter box (at startup)
        private int startupFilterBoxHeight = 158;
        private int currentPageIndex = 1;
        private ResourceManager rm;

        Boolean flagInsert = false;
        private VoucherGift VoucherObj;
        private VoucherGift AddOrUpdateVoucher;
        // Data table that contains user records
        private DataTable dtbRuleList;
        private List<MemberMobilePersonalizationDTO> RuleMemberList;
        List<MemberMobilePersonalizationDTO> RulememberListAdd;
        MobilePersonalizationDTO MobilePerVoucher;

        private BackgroundWorker bgwLoadGiftVoucherWorker;
        private BackgroundWorker bgwLoadContentWorker;
        private BackgroundWorker bgwLoadRuleMemberWorker;
        private BackgroundWorker bgwLoadAddVoucherWorker;
        public DialogPostAction PostAction { get; private set; }

        MobilePersonalizationDTO filter;
        // The title font of tree nodes
        private Font startupNodeFont;
        // Selected tree node; cache it to do some effect in UI
        private TreeNode selectedVoucherNode;
        private TreeNode selectedVoucherParentNode;
        private TreeNode rootNode;

        private VoucherGiftCardWorkItem workItem;

        [ServiceDependency]
        public VoucherGiftCardWorkItem WorkItem
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

        #endregion Properties

        #region CAB events

        [EventPublication(VoucherEventTopicNames.VoucherMgtMainShown)]
        public event EventHandler VoucherMgtMainShown;

        [CommandHandler(VoucherGiftCardCommandNames.ShowVoucherGiftCardRule)]
        public void ShowCardMgtMainHandler(object s, EventArgs e)
        {
            UcAdminVoucherGift uc = workItem.Items.Get<UcAdminVoucherGift>(ComponentNames.VoucherGiftCardRuleComponent);
            if (uc == null)
            {
                uc = workItem.Items.AddNew<UcAdminVoucherGift>(ComponentNames.VoucherGiftCardRuleComponent);
            }
            else if (uc.IsDisposed)
            {
                workItem.Items.Remove(uc);
                uc = workItem.Items.AddNew<UcAdminVoucherGift>(ComponentNames.VoucherGiftCardRuleComponent);
            }
            workItem.Workspaces[WorkspaceName.MainWorkspace].Show(uc);
            uc.Parent.Text = MenuNames.MenuVoucherCardCreateRule;
        }

        #endregion

        #region Initialization

        public UcAdminVoucherGift()
        {
            InitializeComponent();
            RegistryEvent();
            InitDataTableVoucherGift();
        }

        public void RegistryEvent(){
            //Show or hide filter
            btnShowHide.Click += btnShowHide_Click;

            //reload list
            btnReloadTrv.Click += (s, e) => LoadGiftVoucherList();

            //btnSyncData.Click+=btnSyncData_Click;
            btnReload.Click += (s, e) => LoadRuleMemberList();           

            //Tree View
            trvGiftVoucher.AfterExpand += trvGiftVoucher_AfterExpand;
            trvGiftVoucher.BeforeSelect += trvGiftVoucher_BeforeSelect;
            trvGiftVoucher.AfterSelect += trvGiftVoucher_AfterSelect;

            //Load Tree View
            bgwLoadGiftVoucherWorker = new BackgroundWorker();
            bgwLoadGiftVoucherWorker.WorkerSupportsCancellation = true;
            bgwLoadGiftVoucherWorker.DoWork += OnLoadTrvWorkerDoWork;
            bgwLoadGiftVoucherWorker.RunWorkerCompleted += OnLoadTrvWorkerCompleted;

            //Load Content
            bgwLoadContentWorker = new BackgroundWorker();
            bgwLoadContentWorker.WorkerSupportsCancellation = true;
            bgwLoadContentWorker.DoWork += OnLoadContentWorkerDoWork;
            bgwLoadContentWorker.RunWorkerCompleted += OnLoadContentWorkerCompleted;

            //Load Phiếu
            bgwLoadRuleMemberWorker = new BackgroundWorker();
            bgwLoadRuleMemberWorker.WorkerSupportsCancellation = true;
            bgwLoadRuleMemberWorker.DoWork += OnLoadRuleMemberWorkerDoWork;
            bgwLoadRuleMemberWorker.RunWorkerCompleted += OnLoadRuleMemberWorkerCompleted;

            //Add Mobile Personalization
            //bgwLoadAddVoucherWorker = new BackgroundWorker();
            //bgwLoadAddVoucherWorker.WorkerSupportsCancellation = true;
            //bgwLoadAddVoucherWorker.DoWork += OnLoadAddVoucherWorkerDoWork;
            //bgwLoadAddVoucherWorker.RunWorkerCompleted += OnLoadAddVoucherWorkerCompleted;

            //Add - Update - Deleted Voucher
            btnRemoveCard.Click += btnRemoveCard_Click;
            btnSyncData.Click += btnSyncMemberData_Clicked;

            Enter += (s, e) =>
            {
                if (VoucherMgtMainShown != null)
                {
                    VoucherMgtMainShown(this, EventArgs.Empty);
                }
            };
            // Assign startup value
            startupNodeFont = trvGiftVoucher.Font;
            dgvSynsVoucherGift.SelectionChanged += dgvVoucher_SelectionChanged;

            Load += OnFormLoad;
        }

        private void OnFormLoad(object sender, EventArgs e)
        {
            InitGiftVoucherList();
            LoadGiftVoucherList();
            SetShowOrHideButton(false);
            btnSyncData.Enabled = false;
            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
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
            dtbRuleList.Rows.Clear();
            int take = LocalSettings.Instance.RecordsPerPage;
            int skip = (currentPageIndex - 1) * take;

            List<MemberMobilePersonalizationDTO> result = RuleMemberList.Skip(skip).Take(take).ToList();

            LoadMemberDataGridView(result);

            pagerPanel1.ShowNumberOfRecords(RuleMemberList.Count, result != null ? result.Count : 0, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
            pagerPanel1.UpdatePagingLinks(RuleMemberList.Count, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
        }

        #endregion Initialization

        #region Binding Data

        private void ToModel(VoucherGift voucher)
        {
            txtTitle.Text = voucher.title;
            txtTypeCard.Text = VoucherCombobox.ToTypeCardStatus(Convert.ToInt32(voucher.type)).GetName();
            txtLocation.Text = VoucherCombobox.ToLocationStatus(Convert.ToInt32(voucher.area)).GetName();
            //txtGender.Text = GenderExtMethod.ToGender(Convert.ToInt32(voucher.gender)).GetName();
            var sGender = voucher.gender.ToString();
            if (sGender.Length > 1)
            {   //var G1 = sGender.Substring(0,1);
                var sMale = GenderExtMethod.ToGender(1).GetName();
                var sFemale = GenderExtMethod.ToGender(2).GetName();
                txtGender.Text = sMale + "; " + sFemale;
            }
            else
                txtGender.Text = GenderExtMethod.ToGender(Convert.ToInt32(voucher.gender)).GetName();
   
            txtDateBegin.Text = voucher.dateBegin;
            txtDateEnd.Text = voucher.dateEnd;
            txtDescription.Text = voucher.description;
        }

        #endregion

        #region Contructors of Voucher

        private void LoadRuleMemberList()
        {
            if (!bgwLoadRuleMemberWorker.IsBusy)// && selectedOrgNode != null
            {
                dtbRuleList.Rows.Clear();
                RuleMemberList = null;//filter = GetRuleFilter();
                pagerPanel1.ShowMessage("Đang tải dữ liệu, xin hãy chờ...");
                bgwLoadRuleMemberWorker.RunWorkerAsync();
            }
        }

        private void LoadContentList()
        {
            if (!bgwLoadContentWorker.IsBusy)// && selectedOrgNode != null
            {
                dtbRuleList.Rows.Clear(); //RuleMemberList = null; //filter = GetRuleFilter();
                RuleMemberList = null;
                pagerPanel1.ShowMessage("Đang tải dữ liệu, xin hãy chờ...");
                bgwLoadContentWorker.RunWorkerAsync();
                if (!flagInsert)
                {
                    pagerPanel1.ShowMessage("");
                }
            }
        }

        private void InitDataTableVoucherGift()
        {
            dtbRuleList = new DataTable();
            dtbRuleList.Columns.Add(colId.DataPropertyName);
            dtbRuleList.Columns.Add(colLastName.DataPropertyName);
            dtbRuleList.Columns.Add(colFirstName.DataPropertyName);
            dtbRuleList.Columns.Add(colTelephone.DataPropertyName);
            dtbRuleList.Columns.Add(colQrCode.DataPropertyName);
            dtbRuleList.Columns.Add(colBarCode.DataPropertyName);
            dtbRuleList.Columns.Add(colSerial.DataPropertyName);
            dgvSynsVoucherGift.DataSource = dtbRuleList;
        }

        private void SetShowOrHideButton(bool edit)
        {
            btnReload.Enabled = btnReloadTrv.Enabled = edit;
        }

        private void ShowOrHideButtonAction(bool isShow)
        {
            //btnUpdateMember.Enabled = btnRemoveMember.Enabled = isShow;
        }

        #endregion Contructors of Voucher

        #region Form Event
        //Check into box to Auto reducing Node
        private void trvGiftVoucher_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if (chkAutoCloseNode.Checked)
            {
                foreach (TreeNode node in rootNode.Nodes)
                {
                    if (node.IsExpanded && node != e.Node)
                    {
                        node.Collapse();
                    }
                }
                trvGiftVoucher.SelectedNode = null;
            }
        }
        //Display the text on the tree Node label
        private void trvGiftVoucher_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            // If background worker is running -> restrict selecting another node
            if (bgwLoadRuleMemberWorker.IsBusy)
            {
                e.Cancel = true;
                return;
            }

            // Change node font style to normal
            if (selectedVoucherNode != null)
            {
                selectedVoucherNode.NodeFont = new Font(startupNodeFont, FontStyle.Regular);
                selectedVoucherNode.Text = selectedVoucherNode.Text;
            }
        }

        private void trvGiftVoucher_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectedNode = e.Node;
            TreeNode parentNode = new TreeNode();
            if (selectedNode != null)
            {
                parentNode = selectedNode.Parent;
                selectedNode.NodeFont = new Font(startupNodeFont, FontStyle.Bold);
                selectedNode.Text = selectedNode.Text;

                if (selectedVoucherNode != null && selectedNode == selectedVoucherNode)
                {
                    return;
                }

                selectedVoucherParentNode = selectedNode.Parent;
                selectedVoucherNode = selectedNode;

                if (selectedVoucherNode.Level == 1)
                {
                    //LoadVoucherList();
                    LoadContentList();
                    SetShowOrHideButton(true);
                    btnSyncData.Enabled = false;
                }
                else
                {
                    SetShowOrHideButton(false);
                    btnSyncData.Enabled = false;
                }
                currentPageIndex = 1;
            }
        }

        private void LoadMemberDataGridView(List<MemberMobilePersonalizationDTO> result)
        {
            foreach (MemberMobilePersonalizationDTO mb in result)
            {
                DataRow row = dtbRuleList.NewRow();
                row.BeginEdit();
                row[colId.DataPropertyName] = mb.Id;
                row[colLastName.DataPropertyName] = mb.LastName;
                row[colFirstName.DataPropertyName] = mb.FirstName;
                row[colTelephone.DataPropertyName] = mb.telephone;
                row[colQrCode.DataPropertyName] = mb.qrcode;   
                row[colBarCode.DataPropertyName] = mb.barcode;
                row[colSerial.DataPropertyName] = mb.serial;

                row.EndEdit();
                dtbRuleList.Rows.Add(row);
            }
            btnSyncData.Enabled = result != null && result.Count > 0;
        }

        private void dgvVoucher_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSynsVoucherGift.CurrentRow != null)
                ShowOrHideButtonAction(string.IsNullOrEmpty(dgvSynsVoucherGift.CurrentRow.Cells[colId.Index].Value.ToString()));
        }
        
        private void OnLoadTrvWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            List<VoucherGift> result = null;
            VoucherGiftFilterDto filter = new VoucherGiftFilterDto();

            try
            {
                result = VoucherGiftFactory.Instance.GetChannel().GetVoucherFilterListByOrgID(StorageService.CurrentSessionId, 0, filter);
            }
            catch (NullReferenceException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.NotExistDataNode);
                RuleMemberList = null;
            }
            catch (TimeoutException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.TimeOutExceptionMessage);
            }
            catch (FaultException<WcfServiceFault> ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
            }
            catch (FaultException ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.FaultExceptionMessage
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
            }
            catch (CommunicationException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.CommunicationExceptionMessage);
            }
            finally
            {
                e.Result = result;
            }
        }

        private void OnLoadTrvWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            // Get result from DoWork method
            List<VoucherGift> result = (List<VoucherGift>)e.Result;
            if (result != null)
            {
                foreach (VoucherGift vc in result)
                {                  
                    TreeNode subVoucherNode = new TreeNode();
                    subVoucherNode.Text = vc.title;
                    subVoucherNode.Name = Convert.ToString(vc.id);
                    rootNode.Nodes.Add(subVoucherNode);
                }
                
                rootNode.Expand();
            }
        }


        private void OnLoadContentWorkerDoWork(object sender, DoWorkEventArgs e)
        {      
            try
            {
                VoucherObj = VoucherGiftFactory.Instance.GetChannel().GetVourcherByVourcherId(StorageService.CurrentSessionId, Convert.ToInt64(selectedVoucherNode.Name));
                e.Result = true;
            }
            catch (TimeoutException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.TimeOutExceptionMessage);
            }
            catch (FaultException<WcfServiceFault> ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
            }
            catch (FaultException ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.FaultExceptionMessage
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
            }
            catch (CommunicationException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.CommunicationExceptionMessage);
            }
        }

        private void OnLoadContentWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if (e.Result != null)
            {
                ToModel(VoucherObj);
            }
        }


        private void OnLoadRuleMemberWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            int totalRecords = 0;
            int take = LocalSettings.Instance.RecordsPerPage;
            int skip = 0;
            currentPageIndex = 1;
            List<MemberMobilePersonalizationDTO> result = null;
            try
            {
                RuleMemberList = VoucherGiftFactory.Instance.GetChannel().GetRuleMemberListByVoucherID(storageService.CurrentSessionId, Convert.ToInt64(selectedVoucherNode.Name));
            }
            //catch (NullReferenceException)
            //{
            //    MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.InformNotExistData);
            //    RuleMemberList = null;
            //}
            catch (TimeoutException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.TimeOutExceptionMessage);
                RuleMemberList = null;
            }
            catch (FaultException<WcfServiceFault> ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
                RuleMemberList = null;
            }
            catch (FaultException ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.FaultExceptionMessage
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
                RuleMemberList = null;
            }
            catch (CommunicationException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.CommunicationExceptionMessage);
                RuleMemberList = null;
            }
            finally
            {
                if (RuleMemberList != null)
                {
                    result = RuleMemberList.Skip(skip).Take(take).ToList();
                    totalRecords = RuleMemberList.Count;
                    pagerPanel1.ShowNumberOfRecords(totalRecords, result != null ? result.Count : 0, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
                    pagerPanel1.UpdatePagingLinks(totalRecords, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
                }
                e.Result = result;
            }
        }

        private void OnLoadRuleMemberWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                btnSyncData.Enabled = false;
                return;
            }
            if (e.Result == null)
            {
                btnSyncData.Enabled = false;
                return;
            }
                        
            List<MemberMobilePersonalizationDTO> result = (List<MemberMobilePersonalizationDTO>)e.Result;
            RulememberListAdd = (List<MemberMobilePersonalizationDTO>)e.Result;
            LoadMemberDataGridView(result);
        }


        //private void OnLoadAddVoucherWorkerDoWork(object sender, DoWorkEventArgs e)
        //{
        //    try
        //    {                                                               //, Convert.ToInt64(selectedVoucherNode.Name)
        //        e.Result = (int)Status.SUCCESS == VoucherGiftFactory.Instance.GetChannel().InsertRuleVoucher(storageService.CurrentSessionId, RulememberListAdd);
        //        flagInsert = (bool)e.Result;
        //    }
        //    catch (NullReferenceException)
        //    {
        //        MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.CantNotInsertData);
        //    }
        //    catch (TimeoutException)
        //    {
        //        MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.TimeOutExceptionMessage);
        //    }
        //    catch (FaultException<WcfServiceFault> ex)
        //    {
        //        MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
        //    }
        //    catch (FaultException ex)
        //    {
        //        MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.FaultExceptionMessage
        //                + Environment.NewLine + Environment.NewLine
        //                + ex.Message);
        //    }
        //    catch (CommunicationException)
        //    {
        //        MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.CommunicationExceptionMessage);
        //    }
        //}

        //private void OnLoadAddVoucherWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    if (e.Cancelled)
        //    {
        //        return;
        //    }
        //    if ((bool)e.Result)
        //    {
        //        MessageBoxManager.ShowInfoMessageBox(this, CommonMessages.InsertSuccess);
        //        LoadRuleMemberList();
        //        PostAction = DialogPostAction.SUCCESS;
        //        //Hide();
        //        btnSyncData.Enabled = false;
        //    }
        //    else
        //    {
        //        MessageBoxManager.ShowInfoMessageBox(this, CommonMessages.InsertFailed);
        //    }
        //}

        [CommandHandler(OrganizationCommandNames.SyncDataRule)]
        private void btnSyncMemberData_Clicked(object sender, EventArgs e)
        {
            // Show Rule Detail dialog and delegate this task to it
            FrmShowAndAddRuleCard dialog = new FrmShowAndAddRuleCard(FrmShowAndAddRuleCard.ModeAdding, RulememberListAdd);
            workItem.SmartParts.Add(dialog);
            dialog.ShowDialog();
            workItem.SmartParts.Remove(dialog);
            btnSyncData.Enabled = false;
            LoadRuleMemberList();
        }

        [CommandHandler(OrganizationCommandNames.RemoveRule)]
        private void btnRemoveCard_Click(object sender, EventArgs e)
        {
            bool result;
            //if (dgvRulesVoucherGift.SelectedRows.Count == 0)
            //{
            //    MessageBoxManager.ShowErrorMessageBox(this, "Bạn chưa chọn cấu hình phiếu cần hủy!", "Thao Tác Sai");
            //    return;
            //}

            //Show confirmation message box
            if (MessageBoxManager.ShowQuestionMessageBox(this, "Bạn có chắc muốn hủy những Card này không?") == System.Windows.Forms.DialogResult.Yes)
            {
                //long voucherId = Convert.ToInt64(dgvRulesVoucherGift.SelectedRows[0].Cells[0].Value.ToString());
                try
                {
                    result = (int)Status.SUCCESS == VoucherGiftFactory.Instance.GetChannel().RemoveRuleVoucher(StorageService.CurrentSessionId, RulememberListAdd);
                }
                catch (TimeoutException)
                {
                    MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.TimeOutExceptionMessage);
                    return;
                }
                catch (FaultException<WcfServiceFault> ex)
                {
                    MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
                    return;
                }
                catch (FaultException ex)
                {
                    MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.FaultExceptionMessage
                            + Environment.NewLine + Environment.NewLine
                            + ex.Message);
                    return;
                }
                catch (CommunicationException)
                {
                    MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.CommunicationExceptionMessage);
                    return;
                }
                // Check return result
                if (result)
                {
                    LoadRuleMemberList();
                    MessageBoxManager.ShowInfoMessageBox(this, "Đã hủy cấu hình phiếu thành công!");
                }
                else
                {
                    MessageBoxManager.ShowErrorMessageBox(this, "Hủy cấu hình phiếu thất bại");
                }
            }
        }

        #region Control

        private void btnShowHide_Click(object sender, EventArgs e)
        {
            if (pnlFilterBox.Height == hiddenFilterBoxHeight)
            {
                pnlFilterBox.Height = startupFilterBoxHeight;
                btnShowHide.Text = btnShowHide.ToolTipText = "Ẩn Khung Tìm Kiếm";
                btnShowHide.ToolTipText = "Ẩn khung tìm kiếm";
                btnShowHide.Image = global::CommonControls.Properties.Resources.ArrowUp_16x16;
            }
            else
            {
                pnlFilterBox.Height = hiddenFilterBoxHeight;
                btnShowHide.Text = btnShowHide.ToolTipText = "Hiện Khung Tìm Kiếm";
                btnShowHide.ToolTipText = "Hiện khung tìm kiếm";
                btnShowHide.Image = global::CommonControls.Properties.Resources.ArrowDown_16x16;
            }
        }

        #endregion Control

        private void btnReloadTrv_Click(object sender, EventArgs e)
        {
        }

        //private void btnSyncData_Click(object sender, EventArgs e)
        //{
        //    if (MessageBoxManager.ShowQuestionMessageBox(this, CommonMessages.InformAddDataInto) == System.Windows.Forms.DialogResult.Yes)
        //    {
        //        if (!bgwLoadAddVoucherWorker.IsBusy)
        //        {
        //            dtbRuleList.Rows.Clear();
        //            RuleMemberList = null;
        //            bgwLoadAddVoucherWorker.RunWorkerAsync();                    
        //        }
        //    }         
        //}

        private void btnReload_Click(object sender, EventArgs e)
        {
            //LoadRuleMemberList();
        }
      
        #endregion Form Event

        #region Validate Data

        //private bool ValidateData()
        //{
        //    if (string.IsNullOrEmpty(txtContent.Text))
        //    {
        //        //lblNotification1.Text = "Vui lòng nhập ít nhất 2 ký tự";
        //        //Invoke(new Action(() => { lblNotification1.Visible = true; }));
        //        MessageBoxManager.ShowErrorMessageBox(this, "Bạn chưa nhập nội dung!", "Thao Tác Sai");
        //        return false;
        //    }

        //    if (txtContent.Text.Length > 255)
        //    {
        //        MessageBoxManager.ShowErrorMessageBox(this, "Phần Nội dung. Dữ liệu nhập vào không được vượt quá 255 ký tự!", "Thao Tác Sai");
        //        return false;
        //    } 
        //    //else
        //    //{
        //    //    Invoke(new Action(() => { lblNotification1.Visible = false; }));
        //    //}

        //    DateTime testStart = DateTime.Now;

        //    if (Convert.ToDateTime(dtpDateDuration.Value) < testStart)
        //    {
        //        MessageBoxManager.ShowErrorMessageBox(this, "Bạn nhập sai, hạn sử dụng lớn hơn ngày hiện tại!", "Thao Tác Sai");
        //        return false;
        //    }
        //    return true;
        //}

        #endregion Validate Data

        #region load Gift Voucher

        private void InitGiftVoucherList()
        {
            rootNode = new TreeNode();
            rootNode.Text = "Tất cả";
            rootNode.Name = "-1";
            trvGiftVoucher.Nodes.Add(rootNode);
        }

        private void LoadGiftVoucherList()
        {
            if (!bgwLoadGiftVoucherWorker.IsBusy)
            {
                dtbRuleList.Rows.Clear();
                rootNode.Nodes.Clear();
                bgwLoadGiftVoucherWorker.RunWorkerAsync();
            }
        }

        #endregion               
    }
}