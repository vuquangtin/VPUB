using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Practices.CompositeUI;
using sWorldModel;
using Microsoft.Practices.CompositeUI.EventBroker;
using CardMagneticMgtComponent.Constants;
using Microsoft.Practices.CompositeUI.Commands;
using CommonHelper.Constants;
using JavaCommunication.Factory;
using CommonHelper.Config;
using sWorldModel.TransportData;
using CommonControls;
using System.ServiceModel;
using sWorldModel.Exceptions;
using sWorldModel.Model;
using sWorldModel.Filters;
using CommonControls.Custom;

namespace CardMagneticMgtComponent.WorkItems
{
    //public partial class UsrListCardMagnetic : CommonUserControl
    //{
    //    #region Properties

    //    private BackgroundWorker loadSubOrgWorker;

    //    private int currentPageIndex = 1;
    //    //  private BackgroundWorker bgwLoadPerso;
    //    private BackgroundWorker loadMemberWorker;
    //    private Font startupNodeFont;
    //    private TreeNode selectedOrgNode;
    //    private TreeNode subOrgNodeSelected;
    //    private TreeNode rootNode;
    //    private int startupFilterBoxHeight;
    //    private DataTable dtbListMember;
    //    private List<long> MagneticIds;
    //    private MasterInfoDTO masterInfo;

    //    //private List<MagneticPersonalization> MemberMagneticList;
    //    private PartnerInfoDTO partnerInfoSelect;
    //    private List<PartnerInfoDTO> partnerInfoList;
    //    private PartnerInfoDTO partnerInfoSelected;
    //    private List<CardmagneticDTO> MagneticList;
    
    //    private CardTypeDTO cardTypeInfoSelect;

    //    private CardMagneticFilterDto filter; // Khoi tao ben ngoai cho quy trinh tiep theo

    //    private const int hiddenFilterBoxHeight = 1;
    //    private CardMagneticWorkItem workItem;

    //    [ServiceDependency]
    //    public CardMagneticWorkItem WorkItem
    //    {
    //        set { workItem = value; }
    //    }
    //    private ILocalStorageService storageService;
    //    [ServiceDependency]
    //    public ILocalStorageService StorageService
    //    {
    //        get { return storageService; }
    //        set { storageService = value; }
    //    }

    //    #endregion

    //    #region CAB events

    //    [EventPublication(CardMagneticEventTopicNames.ListCardMagneticMainShown)]
    //    public event EventHandler ListCardMagneticMainShown;

    //    [CommandHandler(CardMagneticCommandNames.ShowCardListMagnetic)]
    //    public void ShowCardMgtMainHandler(object s, EventArgs e)
    //    {
    //        UsrListCardMagnetic uc = workItem.Items.Get<UsrListCardMagnetic>(ComponentNames.ListCardMagneticMgtComponent);
    //        if (uc == null)
    //        {
    //            uc = workItem.Items.AddNew<UsrListCardMagnetic>(ComponentNames.ListCardMagneticMgtComponent);
    //        }
    //        else if (uc.IsDisposed)
    //        {
    //            workItem.Items.Remove(uc);
    //            uc = workItem.Items.AddNew<UsrListCardMagnetic>(ComponentNames.ListCardMagneticMgtComponent);
    //        }

    //        workItem.Workspaces[WorkspaceName.MainWorkspace].Show(uc);
    //        uc.Parent.Text = MenuNames.MenuCardManager;
    //    }

    //     [CommandHandler(CardMagneticCommandNames.MarkBroken)]
    //    private void btnMarkBroken_Click(object sender, EventArgs e)
    //    {
    //        uploadStatus(FrmConfirmChangeStatus.Broken);
    //        LoadMemberList();

    //    }

    //     [CommandHandler(CardMagneticCommandNames.MarkLost)]
    //    private void btnMarkLost_Click(object sender, EventArgs e)
    //    {
    //        uploadStatus(FrmConfirmChangeStatus.Lost);
    //        LoadMemberList();
    //    }

    //    #endregion

    //    #region Constructors

    //    public UsrListCardMagnetic()
    //    {
    //        InitializeComponent();
    //        InitOrganizationsGrid();
    //        Load += UsrListCardMagneticPerso_Load;

    //        loadSubOrgWorker = new BackgroundWorker();
    //        loadSubOrgWorker.WorkerSupportsCancellation = true;
    //        loadSubOrgWorker.DoWork += bgwLoadOrganizations_DoWork;
    //        loadSubOrgWorker.RunWorkerCompleted += bgwLoadOrganizations_Completed;

    //        loadMemberWorker = new BackgroundWorker();
    //        loadMemberWorker.WorkerSupportsCancellation = true;
    //        loadMemberWorker.DoWork += bgwMember_DoWork;
    //        loadMemberWorker.RunWorkerCompleted += bgwMember_WorkerCompleted;


    //        this.cbxFilterByCardType.CheckedChanged += cbxFilterByCardType_CheckedChanged;
           
    //        this.cbxFilterByPrintedStatus.CheckedChanged += cbxFilterByPrintedStatus_CheckedChanged;

    //        this.cbxFilterByCardPhysicalStatus.CheckedChanged += cbxFilterByPrintedStatus_CheckedChanged;

    //        this.btnShowHide.Click += btnShowHide_Clicked;

    //        btnReloadOrgs.Click += (s, e) => LoadSubOrgList();
    //        mniReloadOrgs.Click += (s, e) => LoadSubOrgList();
    //        btnReload.Click += (s, e) => LoadMemberList();
    //        //mniReloadMembers.Click += (s, e) => LoadMemberList();

    //        pagerPanel.LinkLabelClicked += pagerPanel_LinkLabelClicked;

    //        trvOrganizations.AfterExpand += trvOrganizations_AfterExpand;
    //        trvOrganizations.BeforeSelect += trvOrganizations_BeforeSelect;
    //        trvOrganizations.AfterSelect += trvOrganizations_AfterSelect;

    //        dgvPersoes.MouseDown += dgvPersoes_MouseDown;
    //        trvOrganizations.MouseDown += trvOrganizations_MouseDown;

    //        //cbxShowCanceledPersoes.CheckedChanged += cbxShowCanceledPersoes_CheckedChanged;

    //        this.Enter += (s, e) =>
    //        {
    //            if (ListCardMagneticMainShown != null)
    //            {
    //                ListCardMagneticMainShown(this, new CabEventArgs(new object[] { CardMagneticCommandNames.ShowCardListMagnetic }));
    //            }
    //        };
    //    }

    //    #endregion

    //    #region Form events

    //    private void UsrListCardMagneticPerso_Load(object sender, EventArgs e)
    //    {
    //        //load infor master
    //      //  LoadMasterInfo();

    //        //load infor partner
           

    //        // Assign startup value
    //        startupNodeFont = trvOrganizations.Font;
    //        startupFilterBoxHeight = pnlFilterBox.Height;

    //        // Add root node
    //        rootNode = new TreeNode();
    //        rootNode.Text = "Tất Cả";
    //        rootNode.Name = "-1";
    //        trvOrganizations.Nodes.Add(rootNode);

    //        LoadPartnerInfo();

    //        if (partnerInfoList == null)
    //            LoadCardTypeOfPartner(masterInfo.cardtypes);

    //        //Load PartnerInfo
    //        //neu co 1 partner thi hidden combobox
    //        //LoadPartnerInfo();
    //      //  HideOrShowOrg();

    //        // Check permissions
    //        ILocalStorageService storageService = workItem.Services.Get<ILocalStorageService>();
    //        List<Function> permissions = storageService.GetObject(CacheKeyNames.CurrentUserPermissions) as List<Function>;
    //        // Populate card Physical status to combobox
    //        List<CardMagneticPhysicalStatus> cardphysicalstatus = CardMagneticStatusExtMethod.GetCardPhysicalStatusList();
    //        DataTable dtbcardphysicalstatus = new DataTable();
    //        dtbcardphysicalstatus.Columns.Add("Id");
    //        dtbcardphysicalstatus.Columns.Add("Name");
    //        foreach (CardMagneticPhysicalStatus ct in cardphysicalstatus)
    //        {
    //            DataRow row = dtbcardphysicalstatus.NewRow();
    //            row.BeginEdit();
    //            row["Id"] = (int)ct;
    //            row["Name"] = ct.GetName();
    //            row.EndEdit();
    //            dtbcardphysicalstatus.Rows.Add(row);
    //        }

    //        cmbCardPhysicalStatus.DataSource = dtbcardphysicalstatus;
    //        cmbCardPhysicalStatus.ValueMember = "Id";
    //        cmbCardPhysicalStatus.DisplayMember = "Name";

    //        // Populate card Logical status to combobox
    //        List<CardMagneticPhysicalStatus> cardlogicalstatus = CardMagneticStatusExtMethod.GetCardPhysicalStatusList();
    //        DataTable dtbcardlogicalstatus = new DataTable();
    //        dtbcardlogicalstatus.Columns.Add("Id");
    //        dtbcardlogicalstatus.Columns.Add("Name");
    //        foreach (CardMagneticPhysicalStatus ct in cardlogicalstatus)
    //        {
    //            DataRow row = dtbcardlogicalstatus.NewRow();
    //            row.BeginEdit();
    //            row["Id"] = (int)ct;
    //            row["Name"] = ct.GetName();
    //            row.EndEdit();
    //            dtbcardlogicalstatus.Rows.Add(row);
    //        }

    //        //cmbCardLogicalStatus.DataSource = dtbcardlogicalstatus;
    //        //cmbCardLogicalStatus.ValueMember = "Id";
    //        //cmbCardLogicalStatus.DisplayMember = "Name";
    //    }


    //    // Lấy về danh sách partner 
    //    private void cmbPartnerInfo_SelectedIndexChanged(object sender, EventArgs e)
    //    {
    //        partnerInfoSelected = cmbPartnerInfo.SelectedItem as PartnerInfoDTO;
    //      //  LoadSubOrgList();
    //        if (partnerInfoSelected != null)
    //        LoadCardTypeOfPartner(partnerInfoSelected.cardtypes);
    //    }

    //    //partnerInfoSelected = cmbPartnerInfo.SelectedItem as PartnerInfoDTO;
    //    //    if (partnerInfoSelected != null)
    //    //        LoadCardType(partnerInfoSelected.cardtypes);

    //    private void cmbCardPhysicalStatus_SelectedIndexChanged(object sender, EventArgs e)
    //    {
    //        if (cmbCardPhysicalStatus.SelectedIndex >= 0)
    //            cardTypeInfoSelect = cmbCardPhysicalStatus.SelectedItem as CardTypeDTO;
    //    }

    //    private void dgvPersoes_MouseDown(object sender, MouseEventArgs e)
    //    {
    //        if (e.Button == MouseButtons.Right)
    //        {
    //            DataGridView.HitTestInfo info = dgvPersoes.HitTest(e.X, e.Y);
    //            if (info.RowIndex != -1)
    //            {
    //                if (info.RowIndex >= 0 && info.ColumnIndex >= 0)
    //                {
    //                    if (!dgvPersoes.SelectedRows.Contains(dgvPersoes.Rows[info.RowIndex]))
    //                    {
    //                        foreach (DataGridViewRow row in dgvPersoes.SelectedRows)
    //                        {
    //                            row.Selected = false;
    //                        }
    //                        dgvPersoes.Rows[info.RowIndex].Selected = true;
    //                    }
    //                }
    //                Rectangle r = dgvPersoes.GetCellDisplayRectangle(info.ColumnIndex, info.RowIndex, true);
    //                cmsPersoRecord.Show((Control)sender, e.X, e.Y);
    //            }
    //            else
    //            {
    //                cmsPersoTable.Show((Control)sender, e.X, e.Y);
    //            }
    //        }
    //    }

    //    private void btnShowHide_Clicked(object sender, EventArgs e)
    //    {
    //        if (pnlFilterBox.Height > hiddenFilterBoxHeight)
    //        {
    //            pnlFilterBox.Height = hiddenFilterBoxHeight;
    //            btnShowHide.Text = btnShowHide.ToolTipText = "Hiện Khung Tìm Kiếm";
    //            btnShowHide.ToolTipText = "Hiện khung tìm kiếm";
    //            btnShowHide.Image = global::CommonControls.Properties.Resources.ArrowDown_16x16;
    //        }
    //        else
    //        {
    //            pnlFilterBox.Height = startupFilterBoxHeight;
    //            btnShowHide.Text = btnShowHide.ToolTipText = "Ẩn Khung Tìm Kiếm";
    //            btnShowHide.ToolTipText = "Ẩn khung tìm kiếm";
    //            btnShowHide.Image = global::CommonControls.Properties.Resources.ArrowUp_16x16;
    //        }
    //    }

    //    private void pagerPanel_LinkLabelClicked(object s, LinkLabelClickedArgs e)
    //    {
    //        int i;
    //        if (e.LabelText.Equals(PagerPanel.LabelBackText))
    //        {
    //            currentPageIndex -= 1;
    //        }
    //        else if (e.LabelText.Equals(PagerPanel.LabelNextText))
    //        {
    //            currentPageIndex += 1;
    //        }
    //        else if (int.TryParse(e.LabelText, out i))
    //        {
    //            currentPageIndex = i;
    //        }
    //        else
    //        {
    //            return;
    //        }
    //        dtbListMember.Rows.Clear();
    //        int take = LocalSettings.Instance.RecordsPerPage;
    //        int skip = currentPageIndex * take;

    //        List<CardmagneticDTO> result = MagneticList.Skip(skip).Take(take).ToList();
    //        LoadPersoDataGridView(result);

    //        pagerPanel.ShowNumberOfRecords(MagneticList.Count, result != null ? result.Count : 0, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
    //        pagerPanel.UpdatePagingLinks(MagneticList.Count, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
    //    }

    //    private void btnExportToExcel_Click(object sender, EventArgs e)
    //    {
    //        string filePath = ControlExtMethods.ShowSaveFileDialog("Chọn tập tin chứa dữ liệu cần xuất", "MS Excel (*.xls)|*.xls");
    //        if (filePath != null)
    //        {
    //            try
    //            {
    //                dgvPersoes.ExportToExcel(filePath);
    //            }
    //            catch (Exception ex)
    //            {
    //                MessageBoxManager.ShowErrorMessageBox(this, ex.Message);
    //                return;
    //            }
    //            MessageBoxManager.ShowInfoMessageBox(this, "Đã xuất dữ liệu ra tập tin tại đường dẫn: " + filePath);
    //        }
    //    }

    //    #endregion

    //    #region Form Controls

    //    #region PartnerInfo

    //    private void LoadSubOrgList()
    //    {
    //        // Call background worker if it's not busy
    //        if (!loadSubOrgWorker.IsBusy)
    //        {
    //            // Clear existing data
    //            subOrgNodeSelected = null;
    //            dtbListMember.Rows.Clear();
    //            rootNode.Nodes.Clear();
    //            loadSubOrgWorker.RunWorkerAsync();
    //        }
    //    }

    //    private void LoadPartnerInfo()
    //    {
    //        //try
    //        //{
    //        //    var masterInfo = OrganizationFactory.Instance.GetChannel().GetMasterInfo(StorageService.CurrentSessionId, SystemSettings.Instance.Master);
    //        //    this.partnerInfoList = OrganizationFactory.Instance.GetChannel().GetPartnerInfo(StorageService.CurrentSessionId, masterInfo.MasterId, SystemSettings.Instance.Partner);
    //        //    cmbPartnerInfo.DataSource = this.partnerInfoList;
    //        //    cmbPartnerInfo.ValueMember = "PartnerId";
    //        //    cmbPartnerInfo.DisplayMember = "Name";
    //        //    cmbPartnerInfo.SelectedIndex = 0;
    //        //}
    //        //catch (TimeoutException)
    //        //{
    //        //    MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.TimeOutExceptionMessage);
    //        //    this.Hide();
    //        //}
    //        //catch (FaultException<WcfServiceFault> ex)
    //        //{
    //        //    MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
    //        //    this.Hide();
    //        //}
    //        //catch (FaultException ex)
    //        //{
    //        //    MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.FaultExceptionMessage
    //        //            + Environment.NewLine + Environment.NewLine
    //        //            + ex.Message);
    //        //    this.Hide();
    //        //}
    //        //catch (CommunicationException)
    //        //{
    //        //    MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.CommunicationExceptionMessage);
    //        //    this.Hide();
    //        //}
    //        //aes = new AesEncryption(this.masterInfo.MasterKey);

    //        try
    //        {
    //            this.masterInfo = OrganizationFactory.Instance.GetChannel().GetMasterInfo(StorageService.CurrentSessionId, SystemSettings.Instance.Master);
    //            cmbPartnerInfo.DataSource = new List<MasterInfoDTO>() { this.masterInfo };
    //            cmbPartnerInfo.ValueMember = "MasterId";
    //            cmbPartnerInfo.DisplayMember = "Name";
    //            cmbPartnerInfo.SelectedIndex = 0;
    //        }
    //        catch (TimeoutException)
    //        {
    //            MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.TimeOutExceptionMessage);
    //            this.Hide();
    //        }
    //        catch (FaultException<WcfServiceFault> ex)
    //        {
    //            MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
    //            this.Hide();
    //        }
    //        catch (FaultException ex)
    //        {
    //            MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.FaultExceptionMessage
    //                    + Environment.NewLine + Environment.NewLine
    //                    + ex.Message);
    //            this.Hide();
    //        }
    //        catch (CommunicationException)
    //        {
    //            MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.CommunicationExceptionMessage);
    //            this.Hide();
    //        }

    //    }

    //    private void LoadCardTypeOfPartner(List<CardTypeDTO> cardTypes)
    //    {
    //        cmbCardTypes.DataSource = cardTypes;
    //        cmbCardTypes.DisplayMember = "cardTypeName";
    //        cmbCardTypes.ValueMember = "prefix";
    //        cmbCardTypes.SelectedIndex = 0;
    //    }

    //    //private void HideOrShowOrg()
    //    //{
    //    //    if (partnerInfoList.Count <= 1)
    //    //        plHideShowOrg.Height = 0;
    //    //    else
    //    //        plHideShowOrg.Height = 55;
    //    //}

    //    #endregion

    //    #region Load OrgPartner

    //    private void InitOrganizationsGrid()
    //    {
    //        dtbListMember = new DataTable();
    //        dtbListMember.Columns.Add(colMagneticId.DataPropertyName);
    //        dtbListMember.Columns.Add(colCompany.DataPropertyName);
    //        dtbListMember.Columns.Add(colPhoneNumber.DataPropertyName);
    //        dtbListMember.Columns.Add(ColActiveCode.DataPropertyName);
    //        dtbListMember.Columns.Add(colFullName.DataPropertyName);
    //        dtbListMember.Columns.Add(colOrgName.DataPropertyName);
    //        dtbListMember.Columns.Add(colSubOrgName.DataPropertyName);
    //        dtbListMember.Columns.Add(colExpireDate.DataPropertyName);
    //        dtbListMember.Columns.Add(colStartDate.DataPropertyName);
    //        dtbListMember.Columns.Add(colSerialCard.DataPropertyName);
    //        dtbListMember.Columns.Add(colTrackData.DataPropertyName);
    //        dtbListMember.Columns.Add(colPrintedStatus.DataPropertyName);
    //        dtbListMember.Columns.Add(colPhysicalStatus.DataPropertyName);
    //        dtbListMember.Columns.Add(colNotes.DataPropertyName);
    //        dtbListMember.Columns.Add(colTypeCrypto.DataPropertyName);
    //        dtbListMember.Columns.Add(colCardType.DataPropertyName);
    //        dtbListMember.Columns.Add(colPinCode.DataPropertyName);
    //        dgvPersoes.DataSource = dtbListMember;
    //    }

    //    private void trvOrganizationList_AfterExpand(object sender, TreeViewEventArgs e)
    //    {
    //        if (chkAutoCloseNode.Checked)
    //        {
    //            foreach (TreeNode node in rootNode.Nodes)
    //            {
    //                if (node.IsExpanded && node != e.Node)
    //                {
    //                    node.Collapse();
    //                }
    //            }
    //            trvOrganizations.SelectedNode = null;
    //        }
    //    }

    //    private void trvOrganizationList_BeforeSelect(object sender, TreeViewCancelEventArgs e)
    //    {
    //        //// If background worker is running -> restrict selecting another node
    //        //if (loadMemberWorker.IsBusy)
    //        //{
    //        //    e.Cancel = true;
    //        //    return;
    //        //}

    //        //// Change node font style to normal
    //        //if (selectedOrgNode != null)
    //        //{
    //        //    selectedOrgNode.NodeFont = new Font(startupNodeFont, FontStyle.Regular);
    //        //    selectedOrgNode.Text = selectedOrgNode.Text;
    //        //}
    //    }

    //    private void trvOrganizationList_AfterSelect(object sender, TreeViewEventArgs e)
    //    {
    //        TreeNode selectedNode = e.Node;
    //        if (selectedNode != null)
    //        {
    //            selectedNode.NodeFont = new Font(startupNodeFont, FontStyle.Bold);
    //            selectedNode.Text = selectedNode.Text;

    //            if (selectedOrgNode != null && selectedNode == selectedOrgNode)
    //            {
    //                return;
    //            }
    //            selectedOrgNode = selectedNode;
    //            currentPageIndex = 1;
    //            LoadMemberList();
    //        }
    //    }

    //    private void trvOrganizations_MouseDown(object sender, MouseEventArgs e)
    //    {
    //        if (e.Button == MouseButtons.Right)
    //        {
    //            TreeNode node = trvOrganizations.GetNodeAt(trvOrganizations.PointToClient(Control.MousePosition));
    //            if (node == null)
    //            {
    //                cmsOrgTree.Show((Control)sender, e.Location.X, e.Location.Y);
    //            }
    //        }
    //    }

    //    //private void LoadOrganizations()
    //    //{
    //    //    // Call background worker if it's not busy

    //    //    if (!loadFacultyWorker.IsBusy)
    //    //    {
    //    //        // Clear existing data
    //    //        rootNode.Nodes.Clear();
    //    //        loadFacultyWorker.RunWorkerAsync();
    //    //    }
    //    //}

    //    private void bgwLoadOrganizations_DoWork(object s, DoWorkEventArgs e)
    //    {
    //        List<PartnerInfoDTO> result = null;
    //    //    SubOrgFilterDto filter = new SubOrgFilterDto();
    //        try
    //        {
    //            result = OrganizationFactory.Instance.GetChannel().GetPartnerInfo(StorageService.CurrentSessionId, masterInfo.MasterId, SystemSettings.Instance.Partner);
    //        }
    //        catch (TimeoutException)
    //        {
    //            MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.TimeOutExceptionMessage);
    //        }
    //        catch (FaultException<WcfServiceFault> ex)
    //        {
    //            MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
    //        }
    //        catch (FaultException ex)
    //        {
    //            MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.FaultExceptionMessage
    //                    + Environment.NewLine + Environment.NewLine
    //                    + ex.Message);
    //        }
    //        catch (CommunicationException)
    //        {
    //            MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.CommunicationExceptionMessage);
    //        }
    //        finally
    //        {
    //            e.Result = result;
    //        }

    //        //try
    //        //{
    //        //    if (masterInfo == null) return;

    //        //    this.partnerInfoList = OrganizationFactory.Instance.GetChannel().GetPartnerInfo(StorageService.CurrentSessionId, masterInfo.MasterId, SystemSettings.Instance.Partner);
    //        //    cmbPartnerInfo.DataSource = this.partnerInfoList;
    //        //    cmbPartnerInfo.ValueMember = "PartnerId";
    //        //    cmbPartnerInfo.DisplayMember = "Name";
    //        //}
    //        //catch (TimeoutException)
    //        //{
    //        //    MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.TimeOutExceptionMessage);
    //        //    this.Hide();
    //        //}
    //        //catch (FaultException<WcfServiceFault> ex)
    //        //{
    //        //    MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
    //        //    this.Hide();
    //        //}
    //        //catch (FaultException ex)
    //        //{
    //        //    MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.FaultExceptionMessage
    //        //            + Environment.NewLine + Environment.NewLine
    //        //            + ex.Message);
    //        //    this.Hide();
    //        //}
    //        //catch (CommunicationException)
    //        //{
    //        //    MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.CommunicationExceptionMessage);
    //        //    this.Hide();
    //        //}
    //    }

    //    private void bgwLoadOrganizations_Completed(object s, RunWorkerCompletedEventArgs e)
    //    {
    //        if (e.Cancelled)
    //        {
    //            return;
    //        }
    //        if (e.Result == null || !(e.Result is List<PartnerInfoDTO>))
    //        {
    //            return;
    //        }
    //        List<PartnerInfoDTO> result = e.Result as List<PartnerInfoDTO>;
    //        //rootNode.Nodes.Clear();
    //        foreach (PartnerInfoDTO subOrg in result)
    //        {
    //            TreeNode subOrgNode = new TreeNode();
    //            subOrgNode.Text = subOrg.Name;
    //            subOrgNode.Name = Convert.ToString(subOrg.PartnerId);
    //            rootNode.Nodes.Add(subOrgNode);
    //            //  subOrgNode.Collapse();

    //            //foreach (DepartmentDto department in subOrg.ListOfDepartments)
    //            //{
    //            //    TreeNode departmentNode = new TreeNode();
    //            //    departmentNode.Text = department.Name;
    //            //    departmentNode.Name = Convert.ToString(department.Id);
    //            //    subOrgNode.Nodes.Add(departmentNode);
    //            //}
    //            subOrgNode.Collapse();
    //        }
    //        trvOrganizations.Sort();
    //        rootNode.Expand();
    //    }

    //    private void cbxFilterByCardType_CheckedChanged(object sender, EventArgs e)
    //    {
    //        cmbCardTypes.Enabled = cbxFilterByCardType.Checked;
    //    }

    //    private void cbxFilterByPrintedStatus_CheckedChanged(object sender, EventArgs e)
    //    {
    //        rbtnStatusNoPrinted.Enabled = rbtnStatusPrinted.Enabled = cbxFilterByPrintedStatus.Checked;
    //    }

    //    private void cbxFilterByCardPhysicalStatus_CheckedChanged(object sender, EventArgs e)
    //    {
    //        cmbCardPhysicalStatus.Enabled = cbxFilterByCardPhysicalStatus.Checked;

    //    }

    //    #endregion

    //    #region Filter functions

    //    private CardMagneticFilterDto GetFilterMagnetic()
    //    {
    //        CardMagneticFilterDto filter = new CardMagneticFilterDto();

    //        if (cbxFilterByCardType.Checked && cmbCardTypes.SelectedIndex > -1)
    //        {
    //            filter.FilterByCardType = true;
    //            filter.Prefix = cmbCardTypes.SelectedValue.ToString();
    //        }

    //        if (cbxFilterByCardPhysicalStatus.Checked && cmbCardPhysicalStatus.SelectedIndex > -1)
    //        {
    //            filter.FilterByCardPhysicalStatus = true;
    //            filter.CardPhysicalStatus = Convert.ToInt32(cmbCardPhysicalStatus.SelectedValue);
    //        }

    //        if (cbxFilterByPrintedStatus.Checked)
    //        {
    //            filter.FilterByCardPrintedStatus = true;
    //            CardMageneticPrintedStatus physicalStt = CardMageneticPrintedStatus.NotPrinted;
    //            if (rbtnStatusPrinted.Checked)
    //            {
    //                physicalStt = CardMageneticPrintedStatus.Printed;
    //            }
    //            filter.CardPrintedStatus = (int)physicalStt;
    //        }

    //        if (selectedOrgNode != null)
    //        {
    //            if (selectedOrgNode.Level == 1)
    //            {
    //                filter.FilterByOrgPartner = true;
    //                filter.OrgPartnerId = Convert.ToInt32(selectedOrgNode.Name);
    //            }
    //            //else if (selectedOrgNode.Level == 2)
    //            //{
    //            //    filter.FilterByDepartmentId = true;
    //            //    filter.DepartmentId = Convert.ToInt32(selectedOrgNode.Name);
    //            //}
    //        }

    //        return filter;
    //    }

    //    #endregion

    //    #endregion

    //    #region Functions for member

    //    private void LoadMemberList()
    //    {
    //        if (!loadMemberWorker.IsBusy && subOrgNodeSelected != null)
    //        {
    //            dtbListMember.Rows.Clear();
    //            filter = GetFilterMagnetic();// quy trinh  A, B
    //            pagerPanel.ShowMessage("Đang tải dữ liệu, xin hãy chờ...");
    //            loadMemberWorker.RunWorkerAsync();
    //        }
    //    }

    //    private void trvOrganizations_AfterExpand(object sender, TreeViewEventArgs e)
    //    {
    //        if (chkAutoCloseNode.Checked)
    //        {
    //            foreach (TreeNode node in rootNode.Nodes)
    //            {
    //                if (node.IsExpanded && node != e.Node)
    //                {
    //                    node.Collapse();
    //                }
    //            }
    //            trvOrganizations.SelectedNode = null;
    //        }
    //    }

    //    private void trvOrganizations_BeforeSelect(object sender, TreeViewCancelEventArgs e)
    //    {
    //        // If background worker is running -> restrict selecting another node
    //        if (loadMemberWorker.IsBusy)
    //        {
    //            e.Cancel = true;
    //            return;
    //        }

    //        // Change node font style to normal
    //        if (subOrgNodeSelected != null)
    //        {
    //            subOrgNodeSelected.NodeFont = new Font(startupNodeFont, FontStyle.Regular);
    //            subOrgNodeSelected.Text = subOrgNodeSelected.Text;
    //        }
    //    }

    //    private void trvOrganizations_AfterSelect(object sender, TreeViewEventArgs e)
    //    {
    //        TreeNode selectedNode = e.Node;
    //        if (selectedNode != null)
    //        {
    //            selectedNode.NodeFont = new Font(startupNodeFont, FontStyle.Bold);
    //            selectedNode.Text = selectedNode.Text;

    //            if (subOrgNodeSelected != null && selectedNode == subOrgNodeSelected)
    //            {
    //                return;
    //            }
    //            subOrgNodeSelected = selectedNode;
    //            currentPageIndex = 1;
    //            LoadMemberList();
    //        }
    //    }

    //    private void bgwMember_DoWork(object sender, DoWorkEventArgs e)
    //    {
    //        int totalRecords = 0;
    //        int take = LocalSettings.Instance.RecordsPerPage;
    //        int skip = 0;

    //        List<CardmagneticDTO> result = null;
    //        if (filter == null)
    //        {
    //            return;
    //        }
    //        try
    //        {
    //            //MagneticList = MagneticPersonalizationFactory.Instance.GetChannel().GetMagneticList(storageService.CurrentSessionId, partnerInfoSelected.PartnerId, Convert.ToInt64(subOrgNodeSelected.Name), filter);

    //           // MagneticList = MagneticPersonalizationFactory.Instance.GetChannel().GetMagneticList(storageService.CurrentSessionId, partnerInfoSelected.PartnerId, masterInfo.MasterId, filter);
     
    //        }
    //        catch (TimeoutException)
    //        {
    //            MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.TimeOutExceptionMessage);
    //            result = null;
    //        }
    //        catch (FaultException<WcfServiceFault> ex)
    //        {
    //            MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
    //            result = null;
    //        }
    //        catch (FaultException ex)
    //        {
    //            MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.FaultExceptionMessage
    //                    + Environment.NewLine + Environment.NewLine
    //                    + ex.Message);
    //            result = null;
    //        }
    //        catch (CommunicationException)
    //        {
    //            MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.CommunicationExceptionMessage);
    //            result = null;
    //        }
    //        finally
    //        {
    //            if (MagneticList != null)
    //            {
    //                result = MagneticList.Skip(skip).Take(take).ToList();
    //                totalRecords = MagneticList.Count;
    //                pagerPanel.ShowNumberOfRecords(totalRecords, result != null ? result.Count : 0, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
    //                pagerPanel.UpdatePagingLinks(totalRecords, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
    //            }
    //            e.Result = result;
    //        }
    //    }

    //    private void bgwMember_WorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    //    {
    //        if (e.Cancelled)
    //        {
    //            return;
    //        }
    //        if (e.Result == null)
    //        {
    //            return;
    //        }

    //        List<CardmagneticDTO> result = e.Result as List<CardmagneticDTO>;
    //        DateTime today = DateTime.Today;
    //        LoadPersoDataGridView(result);
    //    }

    //    private void LoadPersoDataGridView(List<CardmagneticDTO> result)
    //    {
    //        foreach (CardmagneticDTO mm in result)
    //        {
    //            DataRow row = dtbListMember.NewRow();
    //            row.BeginEdit();
              
    //            row[colMagneticId.DataPropertyName] = mm.MagneticId;
    //            row[colFullName.DataPropertyName] = mm.FullName;
    //            row[colPhoneNumber.DataPropertyName] = mm.PhoneNumber;
    //            row[colOrgName.DataPropertyName] = mm.OrgName;
    //            row[colSubOrgName.DataPropertyName] = mm.SubOrgName;
    //            row[colTrackData.DataPropertyName] = mm.TrackData;
    //            row[ColActiveCode.DataPropertyName] = mm.ActiveCode;
    //            row[colTypeCrypto.DataPropertyName] = mm.TypeCrypto;
    //            row[colCardType.DataPropertyName] = mm.cardtypes;
    //            row[colSerialCard.DataPropertyName] = mm.SerialCard;
    //            //row[colCardType.DataPropertyName] = CardTypeExtMethod.ToCardType(mm.cardtypes).GetName();
    //            row[colPinCode.DataPropertyName] = mm.PinCode;
    //            row[colStartDate.DataPropertyName] = mm.StartDate;
    //            row[colExpireDate.DataPropertyName] = mm.ExpireDate;
    //            row[colPhysicalStatus.DataPropertyName] = ((CardMagneticPhysicalStatus)mm.PhysicalStatus).GetName();
    //            row[colPrintedStatus.DataPropertyName] = ((CardMageneticPrintedStatus)mm.PrintStatus).GetName();
    //            row[colNotes.DataPropertyName] = mm.Notes;

    //            row.EndEdit();
    //            dtbListMember.Rows.Add(row);
    //        }
    //    }

    //    #region Thay đổi trạng thái vật lý thẻ

    //    private void DoActionChangeStatusPersoes(byte status, string Reason, List<long> MagneticIds)
    //    {

    //        List<CardmagneticDTO> result = null;
    //        try
    //        {
    //            //TODO: implement call server update status
    //            result = MagneticPersonalizationFactory.Instance.GetChannel().GetChangeStatusPhysicalMagnetic(storageService.CurrentSessionId, status, Reason, MagneticIds);

    //        }
    //        catch (TimeoutException)
    //        {
    //            MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.TimeOutExceptionMessage);
    //            return;
    //        }
    //        catch (FaultException<WcfServiceFault> ex)
    //        {
    //            MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
    //            return;
    //        }
    //        catch (FaultException ex)
    //        {
    //            MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.FaultExceptionMessage
    //                    + Environment.NewLine + Environment.NewLine
    //                    + ex.Message);
    //            return;
    //        }
    //        catch (CommunicationException)
    //        {
    //            MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.CommunicationExceptionMessage);
    //            return;
    //        }
    //        if (result != null && result.Count > 0)
    //        {
    //            LoadMemberList();
    //        }
    //    }

    //    private void uploadStatus(byte status)
    //    {
    //        MagneticIds = new List<long>();
    //        int count = dgvPersoes.SelectedRows.Count;
    //        if (count == 0)
    //        {
    //            MessageBoxManager.ShowErrorMessageBox(this, "Bạn chưa chọn lượt phát hành cho thao tác này!", "Thao Tác Sai");
    //            return;
    //        }

    //        var confirmDialog = FrmConfirmChangeStatus.GetInstance(status);
    //        confirmDialog.ShowDialog();

    //        if (confirmDialog.DialogResult == DialogResult.Yes)
    //        {
    //            foreach (DataGridViewRow row in dgvPersoes.SelectedRows)
    //            {
    //                MagneticIds.Add(Convert.ToInt64(row.Cells[colMagneticId.Name].Value.ToString()));
    //            }
    //            DoActionChangeStatusPersoes(status, confirmDialog.Reason, MagneticIds);
    //        }
    //    }

    //    #endregion

    //    #endregion

    //}
}

