using CommonControls;
using CommonControls.Custom;
using CommonHelper.Config;
using CommonHelper.Constants;
using sWorldModel;
using sWorldModel.Exceptions;
using sWorldModel.Filters;
using sWorldModel.Model;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.Commands;
using Microsoft.Practices.CompositeUI.EventBroker;
using PersoMgtComponent.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.ServiceModel;
using System.Windows.Forms;
using JavaCommunication;
using JavaCommunication.Factory;
using sWorldModel.TransportData;

namespace PersoMgtComponent.WorkItems
{
    public partial class UsrPersoMgtMain : CommonUserControl
    {
        #region Properties

        private BackgroundWorker loadFacultyWorker;

        private int currentPageIndex = -1;
        private DataTable dtblPersoList;
        private BackgroundWorker bgwLoadPerso;

        private Font startupNodeFont;
        private TreeNode selectedOrgNode;
        private TreeNode rootNode;
        private List<PartnerInfoDTO> partnerInfoList;
        private PartnerInfoDTO partnerInfoSelected;
        private int startupFilterBoxHeight;
         private const int hiddenFilterBoxHeight = 1;

        private PersoWorkItem workItem;

        [ServiceDependency]
        public PersoWorkItem WorkItem
        {
            set { workItem = value; }
        }

        private ILocalStorageService storageService;

        [ServiceDependency]
        public ILocalStorageService StorageService
        {
            get { return storageService; }
            set { storageService = value; }
        }

        #endregion

        #region Constructors

        public UsrPersoMgtMain()
        {
            InitializeComponent();
            InitOrganizationsGrid();

            loadFacultyWorker = new BackgroundWorker();
            loadFacultyWorker.WorkerSupportsCancellation = true;
            loadFacultyWorker.DoWork += bgwLoadOrganizations_DoWork;
            loadFacultyWorker.RunWorkerCompleted += bgwLoadOrganizations_Completed;

            bgwLoadPerso = new BackgroundWorker();
            bgwLoadPerso.WorkerSupportsCancellation = true;
            bgwLoadPerso.DoWork += bgwLoadPerso_DoWork;
            bgwLoadPerso.RunWorkerCompleted += bgwLoadPerso_Completed;

            Enter += (s, e) =>
            {
                if (TeacherMgtMainShown != null)
                {
                    TeacherMgtMainShown(this, EventArgs.Empty);
                }
            };
            Leave += (s, e) =>
            {
                if (TeacherMgtMainHide != null)
                {
                    TeacherMgtMainHide(this, EventArgs.Empty);
                }
            };

            Load += UsrPersoMgtMain_Load;

            btnShowHide.Click += btnShowHide_Clicked;
            pagerPanel.LinkLabelClicked += pagerPanel_LinkLabelClicked;

            btnReloadOrgs.Click += (s, e) => LoadOrganizations();
            mniReloadOrgs.Click += (s, e) => LoadOrganizations();
            btnReloadPersoes.Click += (s, e) => LoadPersonalizations();
            mniReloadPersoes.Click += (s, e) => LoadPersonalizations();

            trvOrganizations.AfterExpand += trvOrganizationList_AfterExpand;
            trvOrganizations.BeforeSelect += trvOrganizationList_BeforeSelect;
            trvOrganizations.AfterSelect += trvOrganizationList_AfterSelect;

            cbxFilterByPersoDate.CheckedChanged += cbxFilterByPersoDate_CheckedChanged;
            cbxFilterByPersoStatus.CheckedChanged += cbxFilterByPersoStatus_CheckedChanged;
            //cbxFilterByTeacherCode.CheckedChanged += cbxFilterByTeacherCode_CheckedChanged;
            cbxFilterByMemberName.CheckedChanged += cbxFilterByTeacherName_CheckedChanged;

            cbxShowTeacherColumns.CheckedChanged += cbxShowTeacherColumns_CheckedChanged;

            dtpPersoDateFrom.Value = dtpPersoDateFrom.MaxDate = dtpPersoDateTo.Value = dtpPersoDateTo.MinDate = DateTime.Now;
            dtpPersoDateFrom.ValueChanged += dtpPersoDateFrom_ValueChanged;
            dtpPersoDateTo.ValueChanged += dtpPersoDateTo_ValueChanged;

            dgvPersoes.MouseDown += dgvPersoes_MouseDown;
            trvOrganizations.MouseDown += trvOrganizations_MouseDown;

            cbxShowCanceledPersoes.CheckedChanged += cbxShowCanceledPersoes_CheckedChanged;
        }

        #endregion

        #region Form events

        private void UsrPersoMgtMain_Load(object sender, EventArgs e)
        {
            // Check permissions
            ILocalStorageService storageService = workItem.Services.Get<ILocalStorageService>();
            List<Function> permissions = storageService.GetObject(CacheKeyNames.CurrentUserPermissions) as List<Function>;

            if (!permissions.Exists(f => f == Function.FUNC_PERSO_CHANGE_STATUS))
            {
                btnLockPerso.Enabled = btnUnLockPerso.Enabled = btnCancelPerso.Enabled = false;
                btnLockPerso.Visible = btnUnLockPerso.Visible = btnCancelPerso.Visible = false;
            }

            // Assign startup value
            startupNodeFont = trvOrganizations.Font;
            startupFilterBoxHeight = pnlFilterBox.Height;

            // Add root node
            rootNode = new TreeNode();
            rootNode.Text = "Tất Cả";
            rootNode.Name = "-1";
            trvOrganizations.Nodes.Add(rootNode);

            //Load PartnerInfo
            //neu co 1 partner thi hidden combobox
            LoadPartnerInfo();
            HideOrShowOrg();
        }

        #endregion Form events

        #region Controls events

        private void cmbPartnerInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            partnerInfoSelected = cmbPartnerInfo.SelectedItem as PartnerInfoDTO;
            LoadOrganizations();
        }

        private void tbxTeacherName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadPersonalizations();
            }
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            string filePath = ControlExtMethods.ShowSaveFileDialog("Chọn tập tin chứa dữ liệu cần xuất", "MS Excel (*.xls)|*.xls");
            if (filePath != null)
            {
                try
                {
                    dgvPersoes.ExportToExcel(filePath);
                }
                catch (Exception ex)
                {
                    MessageBoxManager.ShowErrorMessageBox(this, ex.Message);
                    return;
                }
                MessageBoxManager.ShowInfoMessageBox(this, "Đã xuất dữ liệu ra tập tin tại đường dẫn: " + filePath);
            }
        }

        private void cbxShowCanceledPersoes_CheckedChanged(object sender, EventArgs e)
        {
            dgvPersoes.CurrentCell = null;
            foreach (DataGridViewRow r in dgvPersoes.Rows)
            {
                if (r.Cells[colPersoStatus.Index].Value.ToString().Equals(PersoStatus.Canceled.GetName()))
                {
                    r.Visible = cbxShowCanceledPersoes.Checked;
                }
            }
        }

        private void trvOrganizations_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeNode node = trvOrganizations.GetNodeAt(trvOrganizations.PointToClient(Control.MousePosition));
                if (node == null)
                {
                    cmsOrgTree.Show((Control)sender, e.Location.X, e.Location.Y);
                }
            }
        }

        private void dgvPersoes_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo info = dgvPersoes.HitTest(e.X, e.Y);
                if (info.RowIndex != -1)
                {
                    if (info.RowIndex >= 0 && info.ColumnIndex >= 0)
                    {
                        if (!dgvPersoes.SelectedRows.Contains(dgvPersoes.Rows[info.RowIndex]))
                        {
                            foreach (DataGridViewRow row in dgvPersoes.SelectedRows)
                            {
                                row.Selected = false;
                            }
                            dgvPersoes.Rows[info.RowIndex].Selected = true;
                        }
                    }
                    Rectangle r = dgvPersoes.GetCellDisplayRectangle(info.ColumnIndex, info.RowIndex, true);
                    cmsPersoRecord.Show((Control)sender, e.X, e.Y);
                }
                else
                {
                    cmsPersoTable.Show((Control)sender, e.X, e.Y);
                }
            }
        }

        private void pagerPanel_LinkLabelClicked(object sender, LinkLabelClickedArgs e)
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
            LoadPersonalizations();
        }

        private void cbxShowTeacherColumns_CheckedChanged(object sender, EventArgs e)
        {
            colBirthDate.Visible = colPermanentAddress.Visible = colDegree.Visible = colTemporaryAddress.Visible = colPosition.Visible = colPhoneNo.Visible = colTitle.Visible = colEmail.Visible = cbxShowTeacherColumns.Checked;
        }

        private void trvOrganizationList_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if (cbxAutoCloseNode.Checked)
            {
                foreach (TreeNode node in rootNode.Nodes)
                {
                    if (node.IsExpanded && node != e.Node)
                    {
                        node.Collapse();
                    }
                }
                trvOrganizations.SelectedNode = null;
            }
        }

        private void trvOrganizationList_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            // If background worker is running -> restrict selecting another node
            if (bgwLoadPerso.IsBusy)
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

        private void trvOrganizationList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectedNode = e.Node;
            if (selectedNode != null)
            {
                selectedNode.NodeFont = new Font(startupNodeFont, FontStyle.Bold);
                selectedNode.Text = selectedNode.Text;

                if (selectedOrgNode != null && selectedNode == selectedOrgNode)
                {
                    return;
                }
                selectedOrgNode = selectedNode;

                currentPageIndex = 1;
                LoadPersonalizations();
            }
        }

        private void btnShowHide_Clicked(object sender, EventArgs e)
        {
            if (pnlFilterBox.Height > hiddenFilterBoxHeight)
            {
                pnlFilterBox.Height = hiddenFilterBoxHeight;
                btnShowHide.Text = btnShowHide.ToolTipText = "Hiện Khung Tìm Kiếm";
                btnShowHide.ToolTipText = "Hiện khung tìm kiếm";
                btnShowHide.Image = global::CommonControls.Properties.Resources.ArrowDown_16x16;
            }
            else
            {
                pnlFilterBox.Height = startupFilterBoxHeight;
                btnShowHide.Text = btnShowHide.ToolTipText = "Ẩn Khung Tìm Kiếm";
                btnShowHide.ToolTipText = "Ẩn khung tìm kiếm";
                btnShowHide.Image = global::CommonControls.Properties.Resources.ArrowUp_16x16;
            }
        }

        private void dtpPersoDateTo_ValueChanged(object sender, EventArgs e)
        {
            dtpPersoDateFrom.MaxDate = dtpPersoDateTo.Value.Date;
        }

        private void dtpPersoDateFrom_ValueChanged(object sender, EventArgs e)
        {
            dtpPersoDateTo.MinDate = dtpPersoDateFrom.Value.Date;
        }

        private void cbxFilterByTeacherName_CheckedChanged(object sender, EventArgs e)
        {
            tbxMemberName.Enabled = cbxFilterByMemberName.Checked;
            lblNotification1.Visible = false;
        }

        //private void cbxFilterByTeacherCode_CheckedChanged(object sender, EventArgs e)
        //{
        //    tbxTeacherCode.Enabled = cbxFilterByTeacherCode.Checked;
        //    lblNotification2.Visible = false;
        //}

        private void cbxFilterByPersoStatus_CheckedChanged(object sender, EventArgs e)
        {
            rbtnSttCanceled.Enabled = rbtnSttLocked.Enabled = rbtnSttNormal.Enabled = rbtnSttExpired.Enabled = cbxFilterByPersoStatus.Checked;
        }

        private void cbxFilterByPersoDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpPersoDateFrom.Enabled = dtpPersoDateTo.Enabled = cbxFilterByPersoDate.Checked;
        }

        #endregion Controls events

        #region Event's Support

        #region PartnerInfo

        private void LoadPartnerInfo()
        {
            try
            {
                var masterInfo = OrganizationFactory.Instance.GetChannel().GetMasterInfo(StorageService.CurrentSessionId, SystemSettings.Instance.Master);
                this.partnerInfoList = OrganizationFactory.Instance.GetChannel().GetPartnerInfo(StorageService.CurrentSessionId, masterInfo.MasterId, SystemSettings.Instance.Partner);
                cmbPartnerInfo.DataSource = this.partnerInfoList;
                cmbPartnerInfo.ValueMember = "PartnerId";
                cmbPartnerInfo.DisplayMember = "Name";
                cmbPartnerInfo.SelectedIndex = 0;
            }
            catch (TimeoutException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.TimeOutExceptionMessage);
                this.Hide();
            }
            catch (FaultException<WcfServiceFault> ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
                this.Hide();
            }
            catch (FaultException ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.FaultExceptionMessage
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
                this.Hide();
            }
            catch (CommunicationException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.CommunicationExceptionMessage);
                this.Hide();
            }
            //aes = new AesEncryption(this.masterInfo.MasterKey);
        }

        private void HideOrShowOrg()
        {
            if (partnerInfoList.Count <= 1)
                plHideShowOrg.Height = 0;
            else
                plHideShowOrg.Height = 55;
        }

        #endregion

        #region Faculty/Department functions

        private void InitOrganizationsGrid()
        {
            dtblPersoList = new DataTable();
            dtblPersoList.Columns.Add(colChipPersoId.DataPropertyName);
            dtblPersoList.Columns.Add(colMemberId.DataPropertyName);
            dtblPersoList.Columns.Add(colLastName.DataPropertyName);
            dtblPersoList.Columns.Add(colFirstName.DataPropertyName);
            dtblPersoList.Columns.Add(colTitle.DataPropertyName);
            dtblPersoList.Columns.Add(colPosition.DataPropertyName);
            dtblPersoList.Columns.Add(colBirthDate.DataPropertyName);
            dtblPersoList.Columns.Add(colPermanentAddress.DataPropertyName);
            dtblPersoList.Columns.Add(colTemporaryAddress.DataPropertyName);
            dtblPersoList.Columns.Add(colPhoneNo.DataPropertyName);
            dtblPersoList.Columns.Add(colSerialNumber.DataPropertyName);
            dtblPersoList.Columns.Add(colCardId.DataPropertyName);
            dtblPersoList.Columns.Add(colPersoStatus.DataPropertyName);
            dtblPersoList.Columns.Add(colPersoDate.DataPropertyName);
            dtblPersoList.Columns.Add(colCardStatus.DataPropertyName);
            dtblPersoList.Columns.Add(colNotes.DataPropertyName);
            dtblPersoList.Columns.Add(colDegree.DataPropertyName);
            dtblPersoList.Columns.Add(colEmail.DataPropertyName);
            dtblPersoList.Columns.Add(colExpirationDate.DataPropertyName);
            dgvPersoes.DataSource = dtblPersoList;
        }

        private void LoadOrganizations()
        {
            // Call background worker if it's not busy
            if (!loadFacultyWorker.IsBusy)
            {
                // Clear existing data
                rootNode.Nodes.Clear();
                loadFacultyWorker.RunWorkerAsync();
            }
        }

        private void bgwLoadOrganizations_DoWork(object s, DoWorkEventArgs e)
        {
            List<SubOrgCustomerDTO> result = null;
            SubOrgFilterDto filter = new SubOrgFilterDto();
            try
            {
                result = ChipPersonalizationFactory.Instance.GetChannel().GetSubOrgList(storageService.CurrentSessionId, partnerInfoSelected.PartnerId, filter);
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

        private void bgwLoadOrganizations_Completed(object s, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }

            if (e.Result == null || !(e.Result is List<SubOrgCustomerDTO>))
            {
                return;
            }
            List<SubOrgCustomerDTO> result = e.Result as List<SubOrgCustomerDTO>;
            foreach (SubOrgCustomerDTO subOrg in result)
            {
                TreeNode subOrgNode = new TreeNode();
                subOrgNode.Text = subOrg.Name;
                subOrgNode.Name = Convert.ToString(subOrg.OrgId);
                rootNode.Nodes.Add(subOrgNode);
                subOrgNode.Collapse();
            }
            trvOrganizations.Sort();
            rootNode.Expand();
        }





        #endregion

        #region Personalization functions

        private void LoadPersonalizations()
        {
            if (!bgwLoadPerso.IsBusy && selectedOrgNode != null)
            {
                dtblPersoList.Rows.Clear();
                pagerPanel.ShowMessage("Đang tải dữ liệu, xin hãy chờ...");
                bgwLoadPerso.RunWorkerAsync();
            }
        }

        private PersoFilter GetPersoFilter()
        {
            PersoFilter filter = new PersoFilter();

            if (cbxFilterByMemberName.Checked)
            {
                tbxMemberName.Text = tbxMemberName.Text.Trim();
                if (tbxMemberName.Text.Length < 2)
                {
                    Invoke(new Action(() => { lblNotification1.Visible = true; }));
                    return null;
                }
                else
                {
                    Invoke(new Action(() => { lblNotification1.Visible = false; }));
                }
                filter.FilterByMemberName = true;
                filter.MemberName = tbxMemberName.Text;
            }
            //if (cbxFilterByTeacherCode.Checked)
            //{
            //    tbxTeacherCode.Text = tbxTeacherCode.Text.Trim();
            //    if (tbxTeacherCode.Text.Length < 2)
            //    {
            //        Invoke(new Action(() => { lblNotification2.Visible = true; }));
            //        return null;
            //    }
            //    else
            //    {
            //        Invoke(new Action(() => { lblNotification2.Visible = false; }));
            //    }
            //    //filter.FilterByTeacherCode = true;
            //    //filter.TeacherCode = tbxTeacherCode.Text;
            //}
            //if (selectedOrgNode != null)
            //{
            //    if (selectedOrgNode.Level == 1)
            //    {
            //        filter.FilterByFacultyId = true;
            //        filter.FacultyId = Convert.ToInt64(selectedOrgNode.Name);
            //    }
            //    else if (selectedOrgNode.Level == 2)
            //    {
            //        filter.FilterByDepartmentId = true;
            //        filter.DepartmentId = Convert.ToInt64(selectedOrgNode.Name);
            //    }
            //}
            if (cbxFilterByPersoStatus.Checked)
            {
                filter.FilterByPersoStatus = true;
                if (rbtnSttCanceled.Checked)
                {
                    filter.PersoStatus = (int)PersoStatus.Canceled;
                }
                else if (rbtnSttLocked.Checked)
                {
                    filter.PersoStatus = (int)PersoStatus.Locked;
                }
                else if (rbtnSttNormal.Checked)
                {
                    filter.PersoStatus = (int)PersoStatus.Normal;
                }
                else
                {
                    filter.PersoStatus = (int)PersoStatus.Expired;
                }
            }
            if (cbxFilterByPersoDate.Checked)
            {
                //filter.FilterByPersoDate = true;

                //TimePeriodDto period = new TimePeriodDto();
                //period.Start = dtpPersoDateFrom.Value.Date;
                //period.End = dtpPersoDateTo.Value.Date.Add(new TimeSpan(23, 59, 59));
                //filter.PersoDatePeriod = period;
            }
            filter.FilterRecordNeedToUpdate = cbxOnlyShowRecordsNeedToUpdate.Checked;
            filter.ExcludeCanceledPerso = !cbxShowCanceledPersoes.Checked;

            return filter;
        }

        private void bgwLoadPerso_DoWork(object sender, DoWorkEventArgs e)
        {
            int totalRecords = 0;
            int take = LocalSettings.Instance.RecordsPerPage;
            int skip = (currentPageIndex - 1) * take;

            PersoFilter filter = GetPersoFilter();
            if (filter == null)
            {
                return;
            }

            List<MemberChipPersoDTO> result = null;

            try
            {
                result = ChipPersonalizationFactory.Instance.GetChannel().GetMemberPersoList(storageService.CurrentSessionId, partnerInfoSelected.PartnerId, Convert.ToInt64(selectedOrgNode.Name), filter);
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
                pagerPanel.ShowNumberOfRecords(totalRecords, result != null ? result.Count : 0, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
                pagerPanel.UpdatePagingLinks(totalRecords, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
                e.Result = result;
            }
        }

        private void bgwLoadPerso_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if (e.Result == null)
            {
                return;
            }

            List<MemberChipPersoDTO> result = e.Result as List<MemberChipPersoDTO>;
            DateTime today = DateTime.Today;

            foreach (MemberChipPersoDTO mc in result)
            {
                DataRow row = dtblPersoList.NewRow();
                row.BeginEdit();

                row[colMemberId.DataPropertyName] = mc.Member.Id;
                row[colLastName.DataPropertyName] = mc.Member.LastName;
                row[colFirstName.DataPropertyName] = mc.Member.FirstName;
                row[colBirthDate.DataPropertyName] = mc.Member.BirthDate;
                row[colPermanentAddress.DataPropertyName] = mc.Member.PermanentAddress;
                row[colTemporaryAddress.DataPropertyName] = mc.Member.TemporaryAddress;
                row[colTitle.DataPropertyName] = mc.Member.Title;
                row[colPosition.DataPropertyName] = mc.Member.Position;
                row[colDegree.DataPropertyName] = mc.Member.Degree;
                row[colPhoneNo.DataPropertyName] = mc.Member.PhoneNo;
                row[colEmail.DataPropertyName] = mc.Member.Email;
                row[colTemporaryAddress.DataPropertyName] = mc.Member.TemporaryAddress;

                row[colChipPersoId.DataPropertyName] = mc.PersoCard.ChipPersoId;
                row[colCardId.DataPropertyName] = mc.PersoCard.CardChipId;
                row[colSerialNumber.DataPropertyName] = mc.PersoCard.SerialNumber;
                row[colCardStatus.DataPropertyName] = ((CardPhysicalStatus)mc.PersoCard.PhysicalStatus).GetName();
                row[colPersoDate.DataPropertyName] = mc.PersoCard.PersoDate;
                row[colExpirationDate.DataPropertyName] = string.Format("{0:dd/MM/yyyy}", mc.PersoCard.ExpirationDate);
                row[colPersoStatus.DataPropertyName] = ((PersoStatus)mc.PersoCard.Status).GetName();
                row[colNotes.DataPropertyName] = mc.PersoCard.Notes;

                row.EndEdit();
                dtblPersoList.Rows.Add(row);
            }
            cbxShowCanceledPersoes_CheckedChanged(this, EventArgs.Empty);
        }

        private void DoLockPersoes(long[] persoIds, string reason)
        {
            List<MethodResultDto> result = null;
            try
            {
                result = ChipPersonalizationFactory.Instance.GetChannel().LockPersoes(storageService.CurrentSessionId, persoIds, reason);
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
            if (result != null && result.Count > 0)
            {
                ResultDialog dlg = ResultDialog.Instance;
                dlg.ChageColumnTitle(0, "Mã Lượt");
                dlg.ChangeColumnWidth(0, 100);
                dlg.ChangeDataSource(result);
                dlg.ShowDialog();
            }
            if (result.Exists(e => e.Result))
            {
                LoadPersonalizations();
            }
        }

        private void DoUnLockPersoes(long[] persoIds, string reason)
        {
            List<MethodResultDto> result = null;
            try
            {
                result = ChipPersonalizationFactory.Instance.GetChannel().UnLockPersoes(storageService.CurrentSessionId, persoIds, reason);
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
            if (result != null && result.Count > 0)
            {
                ResultDialog dlg = ResultDialog.Instance;
                dlg.ChageColumnTitle(0, "Mã Lượt");
                dlg.ChangeColumnWidth(0, 100);
                dlg.ChangeDataSource(result);
                dlg.ShowDialog();
            }
            if (result.Exists(e => e.Result))
            {
                LoadPersonalizations();
            }
        }

        private void DoCancelPersoes(long[] persoIds, string reason)
        {
            List<MethodResultDto> result = null;
            try
            {
                result = ChipPersonalizationFactory.Instance.GetChannel().CancelPersoes(storageService.CurrentSessionId, persoIds, reason);
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
            if (result != null && result.Count > 0)
            {
                ResultDialog dlg = ResultDialog.Instance;
                dlg.ChageColumnTitle(0, "Mã Lượt");
                dlg.ChangeColumnWidth(0, 100);
                dlg.ChangeDataSource(result);
                dlg.ShowDialog();
            }
            if (result.Exists(e => e.Result))
            {
                LoadPersonalizations();
            }
        }

        private void DoExtendPersoes(long[] persoIds, DateTime expirationDate)
        {
            List<MethodResultDto> result = null;
            try
            {
                result = ChipPersonalizationFactory.Instance.GetChannel().ExtendPerso(storageService.CurrentSessionId, persoIds, expirationDate);
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
            if (result != null && result.Count > 0)
            {
                ResultDialog dlg = ResultDialog.Instance;
                dlg.ChageColumnTitle(0, "Mã Lượt");
                dlg.ChangeColumnWidth(0, 100);
                dlg.ChangeDataSource(result);
                dlg.ShowDialog();
            }
            if (result.Exists(e => e.Result))
            {
                LoadPersonalizations();
            }
        }

        #endregion

        #region Card functions

        private void DoMarkBrokenCard(long[] cardIds)
        {
            List<MethodResultDto> result = null;
            try
            {
                result = CardChipFactory.Instance.GetChannel().MarkBrokenCards(storageService.CurrentSessionId, cardIds);
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
            if (result != null && result.Count > 0)
            {
                ResultDialog dlg = ResultDialog.Instance;
                dlg.ChageColumnTitle(0, "Mã Thẻ");
                dlg.ChangeColumnWidth(0, 100);
                dlg.ChangeDataSource(result);
                dlg.ShowDialog();
                LoadPersonalizations();
            }
        }

        private void DoUnMarkBrokenCard(long[] cardIds)
        {
            List<MethodResultDto> result = null;
            try
            {
                result = CardChipFactory.Instance.GetChannel().UnMarkBrokenCards(storageService.CurrentSessionId, cardIds);
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
            if (result != null && result.Count > 0)
            {
                ResultDialog dlg = ResultDialog.Instance;
                dlg.ChageColumnTitle(0, "Mã Thẻ");
                dlg.ChangeColumnWidth(0, 100);
                dlg.ChangeDataSource(result);
                dlg.ShowDialog();

                //if (result.Exists(e => e.Result))
                //{
                //    var selectedRows = dgvCardList.SelectedRows;
                LoadPersonalizations();

                //    foreach (DataGridViewRow row in selectedRows)
                //    {
                //        row.Selected = true;
                //    }
                //}
            }
        }

        private void DoMarkLostCard(long[] cardIds)
        {
            List<MethodResultDto> result = null;
            try
            {
                result = CardChipFactory.Instance.GetChannel().MarkLostCards(storageService.CurrentSessionId, cardIds);
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
            if (result != null && result.Count > 0)
            {
                ResultDialog dlg = ResultDialog.Instance;
                dlg.ChageColumnTitle(0, "Mã Thẻ");
                dlg.ChangeColumnWidth(0, 100);
                dlg.ChangeDataSource(result);
                dlg.ShowDialog();

                //if (result.Exists(e => e.Result))
                //{
                //    var selectedRows = dgvCardList.SelectedRows;
                LoadPersonalizations();

                //    foreach (DataGridViewRow row in selectedRows)
                //    {
                //        row.Selected = true;
                //    }
                //}
            }
        }

        private void DoUnMarkLostCard(long[] cardIds)
        {
            List<MethodResultDto> result = null;
            try
            {
                result = CardChipFactory.Instance.GetChannel().UnMarkLostCards(storageService.CurrentSessionId, cardIds);
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
            if (result != null && result.Count > 0)
            {
                ResultDialog dlg = ResultDialog.Instance;
                dlg.ChageColumnTitle(0, "Mã Thẻ");
                dlg.ChangeColumnWidth(0, 100);
                dlg.ChangeDataSource(result);
                dlg.ShowDialog();

                //if (result.Exists(e => e.Result))
                //{
                //    var selectedRows = dgvCardList.SelectedRows;
                LoadPersonalizations();

                //    foreach (DataGridViewRow row in selectedRows)
                //    {
                //        row.Selected = true;
                //    }
                //}
            }
        }

        #endregion

        #endregion

        #region CAB events

        [CommandHandler(PersoCommandNames.ShowPersoMgtMain)]
        public void ShowPersoMgtMainViewHandler(object s, EventArgs e)
        {
            UsrPersoMgtMain uc = workItem.Items.Get<UsrPersoMgtMain>(ComponentNames.PersoMgtComponent);
            if (uc == null)
            {
                uc = workItem.Items.AddNew<UsrPersoMgtMain>(ComponentNames.PersoMgtComponent);
            }
            else if (uc.IsDisposed)
            {
                workItem.Items.Remove(uc);
                uc = workItem.Items.AddNew<UsrPersoMgtMain>(ComponentNames.PersoMgtComponent);
            }
            workItem.Workspaces[WorkspaceName.MainWorkspace].Show(uc);
            uc.Parent.Text = "Danh Sách Lượt Phát Hành";
        }

        [CommandHandler(PersoCommandNames.LockPerso)]
        public void btnLockPerso_Click(object sender, EventArgs e)
        {
            var selectedRows = dgvPersoes.SelectedRows;
            int rowsCount = selectedRows.Count;
            if (rowsCount == 0)
            {
                MessageBoxManager.ShowErrorMessageBox(this, "Bạn chưa chọn lượt phát hành cần khóa!", "Thao Tác Sai");
                return;
            }

            var confirmDialog = FrmConfirmChangeStatus.GetInstance(FrmConfirmChangeStatus.Lock);
            confirmDialog.ShowDialog();
            if (confirmDialog.DialogResult == DialogResult.Yes)
            {
                long[] persoIds = new long[rowsCount];
                for (int i = 0; i < rowsCount; i++)
                {
                    persoIds[i] = Convert.ToInt64(selectedRows[i].Cells[colChipPersoId.Name].Value.ToString());
                }
                DoLockPersoes(persoIds, confirmDialog.Reason);
            }
        }

        [CommandHandler(PersoCommandNames.UnLockPerso)]
        public void btnUnLockPerso_Click(object sender, EventArgs e)
        {
            var selectedRows = dgvPersoes.SelectedRows;
            int rowsCount = selectedRows.Count;
            if (rowsCount == 0)
            {
                MessageBoxManager.ShowErrorMessageBox(this, "Bạn chưa chọn lượt phát hành cần mở khóa!", "Thao Tác Sai");
                return;
            }

            var confirmDialog = FrmConfirmChangeStatus.GetInstance(FrmConfirmChangeStatus.Unlock);
            confirmDialog.ShowDialog();
            if (confirmDialog.DialogResult == DialogResult.Yes)
            {
                long[] persoIds = new long[rowsCount];
                for (int i = 0; i < rowsCount; i++)
                {
                    persoIds[i] = Convert.ToInt64(selectedRows[i].Cells[colChipPersoId.Name].Value.ToString());
                }
                DoUnLockPersoes(persoIds, confirmDialog.Reason);
            }
        }

        [CommandHandler(PersoCommandNames.CancelPerso)]
        public void btnCancelPerso_Click(object sender, EventArgs e)
        {
            var selectedRows = dgvPersoes.SelectedRows;
            int rowsCount = selectedRows.Count;
            if (rowsCount == 0)
            {
                MessageBoxManager.ShowErrorMessageBox(this, "Bạn chưa chọn lượt phát hành cần hủy!", "Thao Tác Sai");
                return;
            }

            var confirmDialog = FrmConfirmChangeStatus.GetInstance(FrmConfirmChangeStatus.Cancel);
            confirmDialog.ShowDialog();
            if (confirmDialog.DialogResult == DialogResult.Yes)
            {
                long[] persoIds = new long[rowsCount];
                for (int i = 0; i < rowsCount; i++)
                {
                    persoIds[i] = Convert.ToInt64(selectedRows[i].Cells[colChipPersoId.Name].Value.ToString());
                }
                DoCancelPersoes(persoIds, confirmDialog.Reason);
            }
        }

        [CommandHandler(PersoCommandNames.ExtendPerso)]
        public void btnExtendPerso_Click(object sender, EventArgs e)
        {
            var selectedRows = dgvPersoes.SelectedRows;
            int rowsCount = selectedRows.Count;
            if (rowsCount == 0)
            {
                MessageBoxManager.ShowErrorMessageBox(this, "Bạn chưa chọn lượt phát hành cần gia hạn!", "Thao Tác Sai");
                return;
            }

            var chooseExpDateDialog = new FrmChooseExpDate();
            chooseExpDateDialog.ShowDialog();
            if (chooseExpDateDialog.DialogResult == DialogResult.Yes)
            {
                long[] persoIds = new long[rowsCount];
                for (int i = 0; i < rowsCount; i++)
                {
                    persoIds[i] = Convert.ToInt64(selectedRows[i].Cells[colChipPersoId.Name].Value.ToString());
                }
                DoExtendPersoes(persoIds, chooseExpDateDialog.SelectedDate);
            }
        }

        [CommandHandler(PersoCommandNames.MarkBroken)]
        public void btnMarkBroken_Clicked(object s, EventArgs e)
        {
            var selectedRows = dgvPersoes.SelectedRows;
            int rowsCount = selectedRows.Count;
            if (rowsCount == 0)
            {
                MessageBoxManager.ShowErrorMessageBox(this, "Bạn chưa chọn thẻ cần đánh dấu hư!", "Thao Tác Sai");
                return;
            }

            string message = string.Format("Bạn có chắc muốn đánh dấu hư cho {0}thẻ này không?" + Environment.NewLine + Environment.NewLine + "Lưu ý là việc đánh dấu thẻ mất sẽ làm lượt phát hành tương ứng (nếu có) bị vô hiệu hóa.", rowsCount == 1 ? string.Empty : "các ");
            if (MessageBoxManager.ShowQuestionMessageBox(this, message) == DialogResult.Yes)
            {
                long[] userIds = new long[rowsCount];
                for (int i = 0; i < rowsCount; i++)
                {
                    userIds[i] = Convert.ToInt64(selectedRows[i].Cells[colCardId.Name].Value.ToString());
                }
                DoMarkBrokenCard(userIds);
            }
        }

        [CommandHandler(PersoCommandNames.UnMarkBroken)]
        public void btnUnMarkBroken_Clicked(object s, EventArgs e)
        {
            var selectedRows = dgvPersoes.SelectedRows;
            int rowsCount = selectedRows.Count;
            if (rowsCount == 0)
            {
                MessageBoxManager.ShowErrorMessageBox(this, "Bạn chưa chọn thẻ cần hủy đánh dấu hư!", "Thao Tác Sai");
                return;
            }

            string message = string.Format("Bạn có chắc muốn hủy đánh dấu hư cho {0}thẻ này không?", rowsCount == 1 ? string.Empty : "các ");
            if (MessageBoxManager.ShowQuestionMessageBox(this, message) == DialogResult.Yes)
            {
                long[] userIds = new long[rowsCount];
                for (int i = 0; i < rowsCount; i++)
                {
                    userIds[i] = Convert.ToInt64(selectedRows[i].Cells[colCardId.Name].Value.ToString());
                }
                DoUnMarkBrokenCard(userIds);
            }
        }

        [CommandHandler(PersoCommandNames.MarkLost)]
        public void btnMarkLost_Clicked(object s, EventArgs e)
        {
            var selectedRows = dgvPersoes.SelectedRows;
            int rowsCount = selectedRows.Count;
            if (rowsCount == 0)
            {
                MessageBoxManager.ShowErrorMessageBox(this, "Bạn chưa chọn thẻ cần đánh dấu mất!", "Thao Tác Sai");
                return;
            }

            string message = string.Format("Bạn có chắc muốn đánh dấu mất cho {0}thẻ này không?" + Environment.NewLine + Environment.NewLine + "Lưu ý là việc đánh dấu thẻ mất sẽ làm lượt phát hành tương ứng (nếu có) bị vô hiệu hóa.", rowsCount == 1 ? string.Empty : "các ");
            if (MessageBoxManager.ShowQuestionMessageBox(this, message) == DialogResult.Yes)
            {
                long[] userIds = new long[rowsCount];
                for (int i = 0; i < rowsCount; i++)
                {
                    userIds[i] = Convert.ToInt64(selectedRows[i].Cells[colCardId.Name].Value.ToString());
                }
                DoMarkLostCard(userIds);
            }
        }

        [CommandHandler(PersoCommandNames.UnMarkLost)]
        public void btnUnMarkLost_Clicked(object s, EventArgs e)
        {
            var selectedRows = dgvPersoes.SelectedRows;
            int rowsCount = selectedRows.Count;
            if (rowsCount == 0)
            {
                MessageBoxManager.ShowErrorMessageBox(this, "Bạn chưa chọn thẻ cần hủy đánh dấu mất!", "Thao Tác Sai");
                return;
            }

            string message = string.Format("Bạn có chắc muốn hủy đánh dấu mất cho {0}thẻ này không?", rowsCount == 1 ? string.Empty : "các ");
            if (MessageBoxManager.ShowQuestionMessageBox(this, message) == DialogResult.Yes)
            {
                long[] userIds = new long[rowsCount];
                for (int i = 0; i < rowsCount; i++)
                {
                    userIds[i] = Convert.ToInt64(selectedRows[i].Cells[colCardId.Name].Value.ToString());
                }
                DoUnMarkLostCard(userIds);
            }
        }

        [EventPublication(PersoEventTopicNames.PersoListShown)]
        public event EventHandler TeacherMgtMainShown;

        [EventPublication(PersoEventTopicNames.PersoListHide)]
        public event EventHandler TeacherMgtMainHide;

        #endregion CAB events

        
    }
}