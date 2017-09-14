using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using sAccessComponent.Constants;
using Microsoft.Practices.CompositeUI.Commands;
using CommonHelper.Constants;
using sBuildingCommunication.Define;
using CommonHelper.Utils;
using CommonHelper.Config;
using CommonControls;
using System.ServiceModel;
using sWorldModel.Exceptions;
using sBuildingCommunication.Factory;
using JavaCommunication;
using CommonControls.Custom;
using sBuildingCommunication.Model;
using System.Resources;
using Microsoft.Practices.CompositeUI;
using sWorldModel;
using sWorldModel.TransportData;
using sWorldModel.Filters;

namespace sAccessComponent.WorkItems
{
    public partial class UsrMemberGroupMgt : CommonUserControl
    {
        #region Properties

        private BackgroundWorker bgwLoadMemberListByRole;
        private BackgroundWorker bgwGetRoleById;
        private BackgroundWorker bgwloadRoleListWorker;
        private BackgroundWorker bgwloadMemberListAddWorker;
        private int currentPageIndex = 1;
        private DataTable dtbMemberList;
        private List<RoleDTO> Roles;
        private long orgId;
        private long subOrgId;
        List<SubOrgCustomerDTO> lstSubOrgCustomerDTO;
        private List<RoleChipPersonalizationCustomDTO> roleChipPersonalizationCustomDTO;
        // Selected tree node; cache it to do some effect in UI
        private Font startupNodeFont;
        private TreeNode selectedOrgNode;
        private TreeNode selectedOrgParentNode;
        private TreeNode rootNode;
        private MasterInfoDTO masterInfo;
        private ResourceManager rm;

        private AccessComponentWorkItem workItem;
        [ServiceDependency]
        public AccessComponentWorkItem WorkItem
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

        #endregion

        #region Contructors

        public UsrMemberGroupMgt()
        {
            InitializeComponent();
            RegisterEvent();
            InitDataGridView();
        }
        private void InitDataGridView()
        {
            dtbMemberList = new DataTable();
            dtbMemberList.Columns.Add(colroleChipPersonalizationId.DataPropertyName);
            dtbMemberList.Columns.Add(colId.DataPropertyName);
            dtbMemberList.Columns.Add(colUserName.DataPropertyName);
            dtbMemberList.Columns.Add(colPhone.DataPropertyName);
            dtbMemberList.Columns.Add(colCmnd.DataPropertyName);
            dtbMemberList.Columns.Add(colEmail.DataPropertyName);
            dtbMemberList.Columns.Add(colSerialNumber.DataPropertyName);

            dgvMemberList.DataSource = dtbMemberList;
        }
        #region Event's
        private void RegisterEvent()
        {
            //Tree View
            trvOrganizations.BeforeSelect += trvOrganizations_BeforeSelect;
            trvOrganizations.AfterSelect += trvOrganizations_AfterSelect;
            //Load Tree View
            bgwLoadMemberListByRole = new BackgroundWorker();
            bgwLoadMemberListByRole.WorkerSupportsCancellation = true;
            bgwLoadMemberListByRole.DoWork += bgwLoadMemberList_DoWork;
            bgwLoadMemberListByRole.RunWorkerCompleted += bgwLoadMemberList_RunWorkerCompleted;

            bgwloadRoleListWorker = new BackgroundWorker();
            bgwloadRoleListWorker.WorkerSupportsCancellation = true;
            bgwloadRoleListWorker.DoWork += OnloadRoleWorkerDoWork;
            bgwloadRoleListWorker.RunWorkerCompleted += OnloadRoleWorkerCompleted;



            //Add - Update - Deleted SubOrg
            btnAddGroupMember.Click += btnAddGroup_Click;
            btnEditGroupMember.Click += btnUpdateGroupMember_Click;
            btnRemoveGroupMember.Click += btnRemoveRole_Click;
            dgvMemberList.MouseDown += dgvMembers_MouseDown;
            btnAddNewMember.Click += btnAddNewMember_Click;
            btnDeleteMember.Click += btnDeleteMember_Click;

            btnReloadGroupMember.Click += (s, e) => LoadRoleList();
            pagerPanel1.LinkLabelClicked += pagerPanel_LinkLabelClicked;
            startupNodeFont = trvOrganizations.Font;
            txbFillterName.TextChanged += txbFillterName_TextChanged;

            Load += OnFormLoad;
        }
        /// <summary>
        /// Search by member name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txbFillterName_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dtbMemberList);
            dv.RowFilter = string.Format("Name LIKE'%{0}%'", txbFillterName.Text.Trim());
            dgvMemberList.DataSource = dv;

        }

        private void OnFormLoad(object sender, EventArgs e)
        {
            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
            InitTreeList();
            LoadRoleList();
            pagerPanel1.StorageService = storageService;
            pagerPanel1.LoadLanguage();
            // Set Language
            SetLanguage();
            //LoadMemberListByRole();
        }
        private void InitTreeList()
        {
            rootNode = new TreeNode();
            rootNode.Text = MessageValidate.GetMessage(rm, "All");
            rootNode.Name = "-1";
            trvOrganizations.Nodes.Add(rootNode);
        }
        #endregion
        /// <summary>
        /// Ham nay bat su kien chuot phai
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvMembers_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo info = dgvMemberList.HitTest(e.X, e.Y);
                if (info.RowIndex != -1)
                {
                    if (info.RowIndex >= 0 && info.ColumnIndex >= 0)
                    {
                        if (!dgvMemberList.SelectedRows.Contains(dgvMemberList.Rows[info.RowIndex]))
                        {
                            foreach (DataGridViewRow row in dgvMemberList.SelectedRows)
                            {
                                row.Selected = false;
                            }
                            dgvMemberList.Rows[info.RowIndex].Selected = true;
                        }
                    }
                    Rectangle r = dgvMemberList.GetCellDisplayRectangle(info.ColumnIndex, info.RowIndex, true);
                    cmsMemberRecord.Show((Control)sender, e.X, e.Y);
                }
            }
        }
        /// <summary>
        /// Load tat ca cac role len tree
        /// </summary>
        private void LoadRoleList()
        {
            ClearEmptyControll();
            if (!bgwloadRoleListWorker.IsBusy)
            {
                dtbMemberList.Rows.Clear();
                rootNode.Nodes.Clear();
                bgwloadRoleListWorker.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Clear empty controll
        /// </summary>
        private void ClearEmptyControll()
        {
            txbnamegroup.Text =
            txbDescription.Text = "";
        }
        /// <summary>
        /// Load danh sach cac member thuoc role 
        /// </summary>
        private void LoadMemberListByRole()
        {
            if (!bgwLoadMemberListByRole.IsBusy)
            {
                dtbMemberList.Rows.Clear();
                this.mniDeleteMember.Visible = true;
                bgwLoadMemberListByRole.RunWorkerAsync();
            }
        }


        private void OnloadRoleWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
               e.Result = AccessFactory.Instance.GetChannel().GetRoleList(StorageService.CurrentSessionId);
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
        private void OnloadRoleWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if (e.Result == null)
            {
                return;
            }
            //Get result from DoWork method
            List<RoleDTO> result = (List<RoleDTO>)e.Result;
            if (result != null)
            {
                foreach (RoleDTO role in result)
                {
                    TreeNode RoleNode = new TreeNode();
                    RoleNode.Text = role.name;
                    RoleNode.Name = Convert.ToString(role.roleId);
                    rootNode.Nodes.Add(RoleNode);
                }
                trvOrganizations.Sort();
                rootNode.Expand();
            }
        }
        private void trvOrganizations_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            // If background worker is running -> restrict selecting another node
            if (bgwLoadMemberListByRole.IsBusy)
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
                LoadMemberListByRole();
                GetRoleById();
                SetShowOrHideUpdateOrg();
                currentPageIndex = 1;
            }
        }

        #endregion
        #region GetRoleById
        private void GetRoleById()
        {
            bgwGetRoleById = new BackgroundWorker();
            bgwGetRoleById.WorkerSupportsCancellation = true;
            bgwGetRoleById.DoWork += OnGetRoleByIdDoWork;
            bgwGetRoleById.RunWorkerCompleted += OnGetRoleByIdWorkerCompleted;
            if (!bgwGetRoleById.IsBusy)
            {
                bgwGetRoleById.RunWorkerAsync();
            }
        }

        private void OnGetRoleByIdDoWork(object sender, DoWorkEventArgs e)
        {
            long roleId = Int32.Parse(selectedOrgNode.Name);
            if (roleId != -1)
            {
                try
                {
                    e.Result = AccessFactory.Instance.GetChannel().GetRoleById(StorageService.CurrentSessionId, roleId);
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
        private void OnGetRoleByIdWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            //Get result from DoWork method
            RoleDTO role = (RoleDTO)e.Result;
            if (role != null)
            {
                ShowRoleView(role);
            }
        }
        private void ShowRoleView(RoleDTO role)
        {
            txbnamegroup.Text = role.name;
            txbDescription.Text = role.description;
        }
        #endregion
        #region Set Language
        private void SetLanguage()
        {
            this.lblLeftAreaTitleGroupMember.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.lblLeftAreaTitleGroupMember.Name);
            this.lblRightAreaTitlegGroupMember.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.lblRightAreaTitlegGroupMember.Name);
            this.btnAddGroupMember.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnAddGroupMember.Name);
            this.btnEditGroupMember.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnEditGroupMember.Name);
            this.btnRemoveGroupMember.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnRemoveGroupMember.Name);
            this.btnReloadGroupMember.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnReloadGroupMember.Name);
            this.btnReloadMember.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnReloadMember.Name);
            this.btnAddNewMember.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnAddNewMember.Name);
            this.btnDeleteMember.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnDeleteMember.Name);
            this.colUserName.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colUserName.Name);
            this.colPhone.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colPhone.Name);
            this.colCmnd.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colCmnd.Name);
            this.colEmail.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colEmail.Name);
        }
        #endregion
        #region Event's
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
            int take = LocalSettings.Instance.RecordsPerPage;
            int skip = (currentPageIndex - 1) * take;

            List<RoleChipPersonalizationCustomDTO> result = roleChipPersonalizationCustomDTO.Skip(skip).Take(take).ToList();
            LoadRoleChipPersonalizationToDataGridView(result);

            pagerPanel1.ShowNumberOfRecords(roleChipPersonalizationCustomDTO.Count, result != null ? result.Count : 0, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
            pagerPanel1.UpdatePagingLinks(roleChipPersonalizationCustomDTO.Count, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
        }

        void bgwLoadMemberList_DoWork(object sender, DoWorkEventArgs e)
        {
            List<RoleChipPersonalizationCustomDTO> result = null;
            int totalRecords = 0;
            int take = LocalSettings.Instance.RecordsPerPage;
            int skip = 0;
            currentPageIndex = 1;
            try
            {
                //ham nay lay ve danh sach nguoi dung thuoc group de show trong datatable get tu bang member
                e.Result = roleChipPersonalizationCustomDTO = AccessFactory.Instance.GetChannel().GetPersonalizationByRoleId(storageService.CurrentSessionId, Convert.ToInt64(selectedOrgNode.Name));
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
            finally
            {
                if (roleChipPersonalizationCustomDTO != null)
                {
                    result = roleChipPersonalizationCustomDTO.Skip(skip).Take(take).ToList();
                    totalRecords = roleChipPersonalizationCustomDTO.Count;
                    pagerPanel1.ShowNumberOfRecords(totalRecords, result != null ? result.Count : 0, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
                    pagerPanel1.UpdatePagingLinks(totalRecords, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
                }
            }
        }

        void bgwLoadMemberList_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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
            List<RoleChipPersonalizationCustomDTO> result = (List<RoleChipPersonalizationCustomDTO>)e.Result;
            LoadRoleChipPersonalizationToDataGridView(result);
        }
        /// <summary>
        /// Ham nay dung de them mot nhom thiet bi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            FrmAddOrEditGroupMember dialog = new FrmAddOrEditGroupMember(FrmAddOrEditGroupMember.ModeAdding);
            workItem.SmartParts.Add(dialog);
            dialog.ShowDialog();
            workItem.SmartParts.Remove(dialog);
            dialog.Dispose();
            LoadRoleList();
        }
        /// <summary>
        /// Form add new member for group
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddNewMember_Click(object sender, EventArgs e)
        {
            FrmAddMember dialog = new FrmAddMember(Convert.ToInt64(selectedOrgNode.Name));
            workItem.SmartParts.Add(dialog);
            dialog.ShowDialog();
            workItem.SmartParts.Remove(dialog);
            dialog.Dispose();
            LoadRoleList();
            LoadMemberListByRole();

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateGroupMember_Click(object sender, EventArgs e)
        {
            if (selectedOrgNode.Level == 1)
            {
                FrmAddOrEditGroupMember dialog = new FrmAddOrEditGroupMember(FrmAddOrEditGroupMember.ModeUpdating, Convert.ToInt64(selectedOrgNode.Name));
                workItem.SmartParts.Add(dialog);
                dialog.ShowDialog();
                workItem.SmartParts.Remove(dialog);
                dialog.Dispose();
                LoadRoleList();
            }
            else
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "pleasechoosegroupedit"));
                return;
            }
        }

        private void btnRemoveRole_Click(object sender, EventArgs e)
        {
            bool result;
            //Show confirmation message box
            if (selectedOrgNode == null && selectedOrgNode.Level < 1)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessSelect(rm, MessageValidate.GetMessage(rm, "CancelGroup")), MessageValidate.GetErrorTitle(rm));
                return;
            }

            //Show confirmation message box
            if (MessageBoxManager.ShowQuestionMessageBox(this, string.Format(MessageValidate.GetMessage(rm, "AreYouCancelGroup"), selectedOrgNode.Text)) == DialogResult.Yes)
            {
                try
                {
                    result = (int)Status.SUCCESS == AccessFactory.Instance.GetChannel().RemoveRole(StorageService.CurrentSessionId, Convert.ToInt64(selectedOrgNode.Name));
                }
                catch (TimeoutException)
                {
                    MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "TimeOutExceptionMessage"));
                    return;
                }
                catch (FaultException<WcfServiceFault> ex)
                {
                    MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
                    return;
                }
                catch (FaultException ex)
                {
                    MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "FaultExceptionMessage")
                            + Environment.NewLine + Environment.NewLine
                            + ex.Message);
                    return;
                }
                catch (CommunicationException)
                {
                    MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "CommunicationExceptionMessage"));
                    return;
                }
                // Check return result
                if (result != null && result)
                {
                    trvOrganizations.Nodes.Remove(selectedOrgNode);
                    LoadRoleList();
                }
                else
                {
                    MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "CancelGroupFail"));
                }
            }
        }

        #endregion

        #region Event's Support

       
        private void LoadRoleChipPersonalizationToDataGridView(List<RoleChipPersonalizationCustomDTO> result)
        {
            foreach (RoleChipPersonalizationCustomDTO roleChipPersonalizationCustomDTO in result)
            {
                DataRow row = dtbMemberList.NewRow();
                row.BeginEdit();
                row[colroleChipPersonalizationId.DataPropertyName] = roleChipPersonalizationCustomDTO.roleChipPersonalizationId;
                row[colId.DataPropertyName] = roleChipPersonalizationCustomDTO.member.Id;
                row[colUserName.DataPropertyName] = roleChipPersonalizationCustomDTO.member.LastName + " " + roleChipPersonalizationCustomDTO.member.FirstName;
                row[colPhone.DataPropertyName] = roleChipPersonalizationCustomDTO.member.ContactPhone;
                row[colCmnd.DataPropertyName] = roleChipPersonalizationCustomDTO.member.IdentityCard;
                row[colEmail.DataPropertyName] = roleChipPersonalizationCustomDTO.member.Email;

                row.EndEdit();
                dtbMemberList.Rows.Add(row);
            }
        }

        #endregion

        #region CAB events

        [CommandHandler(AccessCommandNames.ShowMemberGroupMgtMain)]
        public void ShowMemberGroupMgtMainHandler(object s, EventArgs e)
        {
            UsrMemberGroupMgt uc = workItem.Items.Get<UsrMemberGroupMgt>(ComponentName.MemberGroupMgt);
            if (uc == null)
            {
                uc = workItem.Items.AddNew<UsrMemberGroupMgt>(ComponentName.MemberGroupMgt);
            }
            else if (uc.IsDisposed)
            {
                workItem.Items.Remove(uc);
                uc = workItem.Items.AddNew<UsrMemberGroupMgt>(ComponentName.MemberGroupMgt);
            }

            workItem.Workspaces[WorkspaceName.MainWorkspace].Show(uc);
            uc.Parent.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuName.MenuMemberGroupManager);
        }
        private void SetShowOrHideUpdateOrg()
        {
            bool checkUpdate = selectedOrgNode != null && Convert.ToInt64(selectedOrgNode.Name) > 0;
            btnAddGroupMember.Enabled = selectedOrgNode != null;
            btnEditGroupMember.Enabled = btnRemoveGroupMember.Enabled =
                btnDeleteMember.Enabled = btnAddNewMember.Enabled = checkUpdate;
        }

        #endregion
        /// <summary>
        /// delete member whem mouse right click
        /// we can multiselect ok
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteMember_Click(object sender, EventArgs e)
        {
            List<long> lstIdRoleChipPersional = GetListIdRoleChipPersional();
            bool resultDelete = false;
            if (lstIdRoleChipPersional.Count > 0)
            {
                if (MessageBoxManager.ShowQuestionMessageBox(this, string.Format(MessageValidate.GetMessage(rm, "AreYouCancelMeber"), selectedOrgNode.Text)) == DialogResult.Yes)
                {
                    try
                    {
                        resultDelete = (int)Status.SUCCESS == AccessFactory.Instance.GetChannel().DeleteListRoleChipPersional(StorageService.CurrentSessionId, lstIdRoleChipPersional);
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
                    if (resultDelete != null && resultDelete)
                    {
                        LoadMemberListByRole();
                    }
                    else
                    {
                        MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "CancelmemberFail"));
                        LoadMemberListByRole();
                    }
                }
            }
        }
        /// <summary>
        /// Get list Id object người dùng chọn để gửi lên server xóa
        /// </summary>
        /// <returns></returns>
        private List<long> GetListIdRoleChipPersional()
        {
            List<long> selectedIdMember = new List<long>();
            var selectedRows = dgvMemberList.SelectedRows;
            int rowsCount = selectedRows.Count;
            if (rowsCount == 0)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessSelect(rm, MessageValidate.Member), MessageValidate.GetErrorTitle(rm));
            }
            else
            {
                // Get selected member
                for (int i = 0; i < rowsCount; i++)
                {
                    //lay id từ dòng người dùng check
                    long id = Convert.ToInt32(selectedRows[i].Cells[colroleChipPersonalizationId.Name].Value.ToString());
                    selectedIdMember.Add(id);
                }
            }
            return selectedIdMember;
        }

        private void btnReloadMember_Click(object sender, EventArgs e)
        {
            LoadMemberListByRole();
        }
    }
}
