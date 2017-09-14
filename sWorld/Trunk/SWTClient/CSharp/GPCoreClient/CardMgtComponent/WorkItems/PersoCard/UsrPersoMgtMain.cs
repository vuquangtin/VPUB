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
using CardChipMgtComponent.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.ServiceModel;
using System.Windows.Forms;
using JavaCommunication;
using JavaCommunication.Factory;
using sWorldModel.TransportData;
using CardMgtComponent.WorkItems;
using CommonHelper.Utils;
using System.Resources;


namespace CardChipMgtComponent.WorkItems
{
    public partial class UsrPersoMgtMain : CommonUserControl
    {
        #region Properties
        private BackgroundWorker loadFacultyWorker;

        private int currentPageIndex = 1;
        private DataTable dtblPersoList;
        private BackgroundWorker bgwLoadPerso;
        private List<long> persoIds;
        List<MemberCustomerDTO> MemberList;
        private MasterInfoDTO masterInfo;
        private ResourceManager rm;

        private long OrgId;
        private long parenSelectId;
        private long selectId;

        private List<CmsOrgCustomerDto> partnerInfoList;
        private CmsOrgCustomerDto partnerInfoSelected;
        private int startupFilterBoxHeight;
        private const int hiddenFilterBoxHeight = 1;

        private Dictionary<string, string> GroupSubOrgList;

        private CardWorkItem workItem;

        [ServiceDependency]
        public CardWorkItem WorkItem
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

            bgwLoadPerso = new BackgroundWorker();
            bgwLoadPerso.WorkerSupportsCancellation = true;
            bgwLoadPerso.DoWork += bgwLoadPerso_DoWork;
            bgwLoadPerso.RunWorkerCompleted += bgwLoadPerso_Completed;

            Enter += (s, e) =>
            {
                if (MemberMgtMainShown != null)
                {
                    MemberMgtMainShown(this, EventArgs.Empty);
                }
            };
            Leave += (s, e) =>
            {
                if (MemberMgtMainHide != null)
                {
                    MemberMgtMainHide(this, EventArgs.Empty);
                }
            };

            Load += UsrPersoMgtMain_Load;

            btnShowHide.Click += btnShowHide_Clicked;
            pagerPanel.LinkLabelClicked += pagerPanel_LinkLabelClicked;

            btnReloadPersoes.Click += (s, e) => LoadPersonalizations();
            mniReloadPersoes.Click += (s, e) => LoadPersonalizations();


            cbxFilterByPersoDate.CheckedChanged += cbxFilterByPersoDate_CheckedChanged;
            cbxFilterByPersoStatus.CheckedChanged += cbxFilterByPersoStatus_CheckedChanged;
            //cbxFilterByTeacherCode.CheckedChanged += cbxFilterByTeacherCode_CheckedChanged;
            cbxFilterByMemberName.CheckedChanged += cbxFilterByTeacherName_CheckedChanged;

            cbxShowTeacherColumns.CheckedChanged += cbxShowTeacherColumns_CheckedChanged;

            dtpPersoDateFrom.Value = dtpPersoDateFrom.MaxDate = dtpPersoDateTo.Value = dtpPersoDateTo.MinDate = DateTime.Now;
            dtpPersoDateFrom.ValueChanged += dtpPersoDateFrom_ValueChanged;
            dtpPersoDateTo.ValueChanged += dtpPersoDateTo_ValueChanged;

            dgvPersoes.MouseDown += dgvPersoes_MouseDown;

            cbxShowCanceledPersoes.CheckedChanged += cbxShowCanceledPersoes_CheckedChanged;
        }
        #endregion

        #region Form events

        private void UsrPersoMgtMain_Load(object sender, EventArgs e)
        {
            // Check permissions
            ILocalStorageService storageService = workItem.Services.Get<ILocalStorageService>();
            List<Function> permissions = storageService.GetObject(CacheKeyNames.CurrentUserPermissions) as List<Function>;
            rm = storageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
            treeOrg.StorageService = storageService;
            treeOrg.AfterSelect += TreeOrgAfterSelect;
            treeOrg.InitializeData();
            treeOrg.SetHideButton();
            pagerPanel.StorageService = storageService;
            pagerPanel.LoadLanguage();
            SetLanguages();

            //if (!permissions.Exists(f => f == Function.FUNC_PERSO_CHANGE_STATUS))
            //{
            //    btnLockPerso.Enabled = btnUnLockPerso.Enabled = btnCancelPerso.Enabled = false;
            //    btnLockPerso.Visible = btnUnLockPerso.Visible = btnCancelPerso.Visible = false;
            //}

            // Assign startup value
            startupFilterBoxHeight = pnlFilterBox.Height;

            //Load PartnerInfo
            //neu co 1 partner thi hidden combobox
            //LoadGroupSubOrg();
            LoadPartnerInfo();
            HideOrShowOrg();

        }

        #endregion Form events
        private void SetLanguages()
        {
            this.colMemberId.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colMemberId.Name);
            this.colMemberCode.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colMemberCode.Name);
            this.colFullName.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colFullName.Name);
            this.colTitle.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colTitle.Name);
            this.colSerialNumber.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colSerialNumber.Name);
            this.colCardStatus.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colCardStatus.Name);
            this.colExpirationDate.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colExpirationDate.Name);
            this.colPersoStatus.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colPersoStatus.Name);
            this.colPersoDate.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colPersoDate.Name);
            this.colNotes.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colNotes.Name);


            this.btnExportToExcel.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnExportToExcel.Name);
            this.btnShowHide.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnShowHide.Name);
            this.btnLockPerso.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnLockPerso.Name);
            this.btnUnLockPerso.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnUnLockPerso.Name);
            this.btnCancelPerso.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnCancelPerso.Name);
            this.btnExtendPerso.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnExtendPerso.Name);
            this.btnMarkBroken.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnMarkBroken.Name);
            this.btnUnMarkBroken.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnUnMarkBroken.Name);
            this.btnMarkLost.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnMarkLost.Name);
            this.btnUnMarkLost.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnUnMarkLost.Name);
            this.btnReloadPersoes.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnReloadPersoes.Name);
            this.mniLockPerso.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.mniLockPerso.Name);
            this.mniUnlockPerso.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.mniUnlockPerso.Name);
            this.mniCancelPerso.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.mniCancelPerso.Name);
            this.mniExtendPerso.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.mniExtendPerso.Name);
            this.mniMarkBroken.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.mniMarkBroken.Name);
            this.mniUnMarkBroken.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.mniUnMarkBroken.Name);
            this.mniMarkLost.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.mniMarkLost.Name);
            this.mniUnMarkLost.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.mniUnMarkLost.Name);


        }
        #region Controls events

        private void cmbPartnerInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //partnerInfoSelected = cmbPartnerInfo.SelectedItem as CmsOrgCustomerDto;
            //LoadOrganizations();
        }

        private void tbxMemberName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadPersonalizations();
            }
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            string filePath = ControlExtMethods.ShowSaveFileDialog(MessageValidate.GetMessage(rm, "ChooseFileToExport"), "DanhSachThanhVien", "MS Excel (*.xls)|*.xls");
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
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "ExportSuccess") + filePath);
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
        #region Event after tree select
        private void TreeOrgAfterSelect(long orgId, long parentId, long selectedOrgId)
        {
            //gan 2 giá trị từ event hander
            this.OrgId = orgId;
            this.parenSelectId = parentId;
            this.selectId = selectedOrgId;

            ClearControl();

            LoadPersonalizations();
        }

        //20170403 #Bug 846 Fix Quản lý phát hành_Load dữ liệu - Minh Nguyen Start
        private void ClearControl() {
            lblFilterbymemberId.Checked = false;
            cbxFilterByMemberName.Checked = false;
            cbxFilterByPersoStatus.Checked = false;
            cbxFilterByPersoDate.Checked = false;
            cbxShowTeacherColumns.Checked = false;
            cbxOnlyShowRecordsNeedToUpdate.Checked = false;
            cbxShowCanceledPersoes.Checked = false;
        }
        //20170403 #Bug 846 Fix Quản lý phát hành_Load dữ liệu - Minh Nguyen End

        #endregion
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
                            dgvPersoes.CurrentCell = dgvPersoes.Rows[info.RowIndex].Cells[colMemberCode.Name];
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

        private void cbxShowTeacherColumns_CheckedChanged(object sender, EventArgs e)
        {
            colBirthDate.Visible = colPermanentAddress.Visible = colDegree.Visible = colTemporaryAddress.Visible = colPosition.Visible = colPhoneNo.Visible = colTitle.Visible = colEmail.Visible = cbxShowTeacherColumns.Checked;
        }

        private void btnShowHide_Clicked(object sender, EventArgs e)
        {
            if (pnlFilterBox.Height > hiddenFilterBoxHeight)
            {
                pnlFilterBox.Height = hiddenFilterBoxHeight;
                btnShowHide.Text = btnShowHide.ToolTipText = MessageValidate.GetMessage(rm,MessageValidate.ShowTextSearch);
                btnShowHide.ToolTipText = MessageValidate.GetMessage(rm, MessageValidate.HideTextSearch); ;
                btnShowHide.Image = global::CommonControls.Properties.Resources.ArrowDown_16x16;
            }
            else
            {
                pnlFilterBox.Height = startupFilterBoxHeight;
                btnShowHide.Text = btnShowHide.ToolTipText = MessageValidate.GetMessage(rm, MessageValidate.ShowTextSearch);
                btnShowHide.ToolTipText = MessageValidate.GetMessage(rm, MessageValidate.HideTextSearch);
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
            //20170403 #Bug 846 Fix Quản lý phát hành_Load dữ liệu - Minh Nguyen Start
            if (!cbxFilterByMemberName.Checked) {
                tbxMemberName.Text = String.Empty;
            }
            //20170403 #Bug 846 Fix Quản lý phát hành_Load dữ liệu - Minh Nguyen End
            tbxMemberName.Enabled = cbxFilterByMemberName.Checked;
            lblNotification4.Visible = false;
        }


        private void ckbMemberCodeFilter_CheckedChanged(object sender, EventArgs e)
        {
            //20170403 #Bug 846 Fix Quản lý phát hành_Load dữ liệu - Minh Nguyen Start
            if (!lblFilterbymemberId.Checked) {
                tbxMemberCode.Text = String.Empty;
            }
            //20170403 #Bug 846 Fix Quản lý phát hành_Load dữ liệu - Minh Nguyen End
            tbxMemberCode.Enabled = lblFilterbymemberId.Checked;
            lblNotification3.Visible = false;
        }

        private void cbxFilterByPersoStatus_CheckedChanged(object sender, EventArgs e)
        {
            rbtnSttCanceled.Enabled = rbtnSttLocked.Enabled = rbtnSttNormal.Enabled = rbtnSttExpired.Enabled = cbxFilterByPersoStatus.Checked;
        }

        private void cbxFilterByPersoDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpPersoDateFrom.Enabled = dtpPersoDateTo.Enabled = cbxFilterByPersoDate.Checked;
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
            dtblPersoList.Rows.Clear();
            int take = LocalSettings.Instance.RecordsPerPage;
            int skip = (currentPageIndex - 1) * take;

            List<MemberCustomerDTO> result = MemberList.Skip(skip).Take(take).ToList();
            LoadMemberDataGridView(result);

            pagerPanel.ShowNumberOfRecords(MemberList.Count, result != null ? result.Count : 0, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
            pagerPanel.UpdatePagingLinks(MemberList.Count, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
        }

        #endregion Controls events

        #region Event's Support

        #region PartnerInfo

        private void LoadPartnerInfo()
        {
            try
            {
                this.masterInfo = OrganizationFactory.Instance.GetChannel().GetMasterInfo(StorageService.CurrentSessionId, SystemSettings.Instance.Partner);
            }
            catch (TimeoutException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "TimeOutExceptionMessage"));
                this.Hide();
            }
            catch (FaultException<WcfServiceFault> ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
                this.Hide();
            }
            catch (FaultException ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "FaultExceptionMessage")
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
                this.Hide();
            }
            catch (CommunicationException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "CommunicationExceptionMessage"));
                this.Hide();
            }
        }

        private void HideOrShowOrg()
        {
            //if (partnerInfoList.Count <= 1)
            //    plHideShowOrg.Height = 0;
            //else
            //plHideShowOrg.Height = 55;
        }

        #endregion

        #region Sub Organization functions

        private void InitOrganizationsGrid()
        {
            dtblPersoList = new DataTable();
            dtblPersoList.Columns.Add(colChipPersoId.DataPropertyName);
            dtblPersoList.Columns.Add(colMemberId.DataPropertyName);
            dtblPersoList.Columns.Add(colMemberCode.DataPropertyName);
            dtblPersoList.Columns.Add(colFullName.DataPropertyName);
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






        #region Personalization functions

        private void LoadPersonalizations()
        {
            if (!bgwLoadPerso.IsBusy && selectId > 0)
            {
                dtblPersoList.Rows.Clear();
                pagerPanel.ShowMessage(MessageValidate.GetMessage(rm, MessageValidate.WaitLoadData));
                bgwLoadPerso.RunWorkerAsync(GetPersoFilter());
            }
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="persoIds"></param>
        ///// <param name="status"></param>
        ///// <param name="Reason"></param>
        //private void DoActionChangeStatusPersoes( byte status, string Reason, List<long> persoIds)
        //{
        //    List<MemberCustomerDTO> result = null;
        //    try
        //    {
        //        //TODO: implement call server update status
        //        result = ChipPersonalizationFactory.Instance.GetChannel().GetChangeStatus(storageService.CurrentSessionId, status, Reason, persoIds);

        //    }
        //    catch (TimeoutException)
        //    {
        //        MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.TimeOutExceptionMessage);
        //        return;
        //    }
        //    catch (FaultException<WcfServiceFault> ex)
        //    {
        //        MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
        //        return;
        //    }
        //    catch (FaultException ex)
        //    {
        //        MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.FaultExceptionMessage
        //                + Environment.NewLine + Environment.NewLine
        //                + ex.Message);
        //        return;
        //    }
        //    catch (CommunicationException)
        //    {
        //        MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.CommunicationExceptionMessage);
        //        return;
        //    }
        //    if (result != null && result.Count > 0)
        //    {
        //        LoadPersonalizations();
        //    }
        //}

        ///// <summary>
        ///// upload status of list
        ///// </summary>
        ///// <param name="status"> byte Lock = 1;  Unlock = 2; Cancel = 3;</param>
        //private void uploadStatus(byte status)
        //{
        //    persoIds = new List<long>();
        //    int count = dgvPersoes.SelectedRows.Count;
        //    if (count == 0)
        //    {
        //        MessageBoxManager.ShowErrorMessageBox(this, "Bạn chưa chọn lượt phát hành cho thao tác này!", "Thao Tác Sai");
        //        return;
        //    }

        //    var confirmDialog = FrmConfirmChangeStatus.GetInstance(status);
        //    confirmDialog.ShowDialog();

        //    if (confirmDialog.DialogResult == DialogResult.Yes)
        //    {
        //        foreach (DataGridViewRow row in dgvPersoes.SelectedRows)
        //        {
        //            persoIds.Add(Convert.ToInt64(row.Cells[colChipPersoId.Name].Value.ToString()));
        //        }
        //        DoActionChangeStatusPersoes(status, confirmDialog.Reason, persoIds);
        //    }
        //}

        private PersoChipFilter GetPersoFilter()
        {
            PersoChipFilter filter = new PersoChipFilter();

            if (lblFilterbymemberId.Checked)
            {
                string dataSearchId = FormatCharacterSearch.CheckValue(tbxMemberCode.Text.Trim());
                if (dataSearchId.Length < 2)
                {
                    Invoke(new Action(() => { lblNotification3.Visible = true; }));
                    return null;
                }
                else
                {
                    Invoke(new Action(() => { lblNotification3.Visible = false; }));
                }
                filter.FilterByMemberCode = true;
                filter.MemberCode = tbxMemberCode.Text;
            }

            if (cbxFilterByMemberName.Checked)
            {
                string dataSearchName = FormatCharacterSearch.CheckValue(tbxMemberName.Text.Trim());
                if (dataSearchName.Length < 2)
                {
                    Invoke(new Action(() => { lblNotification4.Visible = true; }));
                    return null;
                }
                else
                {
                    Invoke(new Action(() => { lblNotification4.Visible = false; }));
                }
                filter.FilterByMemberName = true;
                filter.MemberName = tbxMemberName.Text;
            }

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
                filter.FilterByPersoDate = true;

                TimePeriodDto period = new TimePeriodDto();
                period.Start = dtpPersoDateFrom.Value.ToStringFormatDate();
                period.End = dtpPersoDateTo.Value.AddDays(1).ToStringFormatDate();
                filter.PersoDatePeriod = period;
            }
            filter.FilterRecordNeedToUpdate = cbxOnlyShowRecordsNeedToUpdate.Checked;
            filter.ExcludeCanceledPerso = !cbxShowCanceledPersoes.Checked;

            return filter;
        }

        private void bgwLoadPerso_DoWork(object sender, DoWorkEventArgs e)
        {
            if (e.Argument == null)
            {
                return;
            }
            int totalRecords = 0;
            int take = LocalSettings.Instance.RecordsPerPage;
            int skip = 0;
            currentPageIndex = 1;
            PersoChipFilter filter = e.Argument as PersoChipFilter;
            List<MemberCustomerDTO> result = null;

            try
            {
                MemberList = OrganizationFactory.Instance.GetChannel().GetMemberPersoList(storageService.CurrentSessionId, selectId, parenSelectId, filter);
                //result = MemberList.Skip(skip).Take(take).ToList();
                //totalRecords = MemberList.Count;
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
                if (MemberList != null)
                {
                    result = MemberList.Skip(skip).Take(take).ToList();
                    totalRecords = MemberList.Count;
                    pagerPanel.ShowNumberOfRecords(totalRecords, result != null ? result.Count : 0, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
                    pagerPanel.UpdatePagingLinks(totalRecords, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
                }
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

            List<MemberCustomerDTO> result = e.Result as List<MemberCustomerDTO>;
            DateTime today = DateTime.Today;
            LoadMemberDataGridView(result);
            cbxShowCanceledPersoes_CheckedChanged(this, EventArgs.Empty);
        }

        private void LoadMemberDataGridView(List<MemberCustomerDTO> result)
        {
            foreach (MemberCustomerDTO mc in result)
            {
                DataRow row = dtblPersoList.NewRow();
                row.BeginEdit();

                row[colMemberId.DataPropertyName] = mc.Member.Id;
                row[colMemberCode.DataPropertyName] = mc.Member.Code;
                row[colFullName.DataPropertyName] = mc.Member.GetFullName();
                row[colBirthDate.DataPropertyName] = mc.Member.BirthDate;
                row[colPermanentAddress.DataPropertyName] = mc.Member.PermanentAddress;
                row[colTemporaryAddress.DataPropertyName] = mc.Member.TemporaryAddress;
                row[colTitle.DataPropertyName] = mc.Member.Title;
                row[colPosition.DataPropertyName] = mc.Member.Position;
                row[colDegree.DataPropertyName] = mc.Member.Degree;
                row[colPhoneNo.DataPropertyName] = mc.Member.PhoneNo;
                row[colEmail.DataPropertyName] = mc.Member.Email;

                if (mc.PersoCard != null)
                {
                    row[colChipPersoId.DataPropertyName] = mc.PersoCard.ChipPersoId;
                    row[colCardId.DataPropertyName] = mc.PersoCard.CardChipId;
                    row[colSerialNumber.DataPropertyName] = mc.PersoCard.SerialNumber;
                    row[colCardStatus.DataPropertyName] = ((CardPhysicalStatus)mc.PersoCard.PhysicalStatus).GetName();
                    row[colPersoDate.DataPropertyName] = mc.PersoCard.PersoDate;
                    row[colExpirationDate.DataPropertyName] = mc.PersoCard.ExpirationDate;
                    row[colPersoStatus.DataPropertyName] = ((PersoStatus)mc.PersoCard.Status).GetName();
                    row[colNotes.DataPropertyName] = mc.PersoCard.Notes;

                }
                row.EndEdit();
                dtblPersoList.Rows.Add(row);

            }
        }

        private void DoLockPersoes(long[] persoIds, string reason)
        {
            List<MethodResultDto> result = null;
            try
            {
                result = ChipPersonalizationFactory.Instance.GetChannel().LockPersoes(storageService.CurrentSessionId, persoIds, reason.Length > 0 ? reason : "-");
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
            if (result != null && result.Count > 0)
            {
                ResultDialog dlg = ResultDialog.Instance;
                dlg.ChageColumnTitle(0, "Mã Lượt");
                dlg.ChangeColumnWidth(0, 100);
                dlg.ChangeDataSource(result);
                dlg.ShowDialog();
            }
            LoadPersonalizations();
        }

        private void DoUnLockPersoes(long[] persoIds, string reason)
        {
            List<MethodResultDto> result = null;
            try
            {
                result = ChipPersonalizationFactory.Instance.GetChannel().UnLockPersoes(storageService.CurrentSessionId, persoIds, reason.Length > 0 ? reason : "-");
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
            if (result != null && result.Count > 0)
            {
                ResultDialog dlg = ResultDialog.Instance;
                dlg.ChageColumnTitle(0, "Mã Lượt");
                dlg.ChangeColumnWidth(0, 100);
                dlg.ChangeDataSource(result);
                dlg.ShowDialog();
            }
            LoadPersonalizations();
        }

        private void DoCancelPersoes(long[] persoIds, string reason)
        {
            List<MethodResultDto> result = null;
            try
            {
                result = ChipPersonalizationFactory.Instance.GetChannel().CancelPersoes(storageService.CurrentSessionId, persoIds, reason.Length > 0 ? reason : "-");
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
            if (result != null && result.Count > 0)
            {
                ResultDialog dlg = ResultDialog.Instance;
                dlg.ChageColumnTitle(0, "Mã Lượt");
                dlg.ChangeColumnWidth(0, 100);
                dlg.ChangeDataSource(result);
                dlg.ShowDialog();
            }
            LoadPersonalizations();
        }

        private void DoExtendPersoes(long[] persoIds, DateTime expirationDate)
        {
            List<MethodResultDto> result = null;
            try
            {
                result = ChipPersonalizationFactory.Instance.GetChannel().ExtendPerso(storageService.CurrentSessionId, persoIds, expirationDate.ToStringFormatDateServer());
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
            if (result != null && result.Count > 0)
            {
                ResultDialog dlg = ResultDialog.Instance;
                dlg.ChageColumnTitle(0, "Mã Lượt");
                dlg.ChangeColumnWidth(0, 100);
                dlg.ChangeDataSource(result);
                dlg.ShowDialog();
            }
            LoadPersonalizations();
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
            if (result != null && result.Count > 0)
            {
                ResultDialog dlg = ResultDialog.Instance;
                dlg.ChageColumnTitle(0, "Serialnumber");
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
            if (result != null && result.Count > 0)
            {
                ResultDialog dlg = ResultDialog.Instance;
                dlg.ChageColumnTitle(0, "Serialnumber");
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
            if (result != null && result.Count > 0)
            {
                ResultDialog dlg = ResultDialog.Instance;
                dlg.ChageColumnTitle(0, "Serialnumber");
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
            if (result != null && result.Count > 0)
            {
                ResultDialog dlg = ResultDialog.Instance;
                dlg.ChageColumnTitle(0, "Serialnumber");
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
            uc.Parent.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuCardPersoManager);
        }

        //[CommandHandler(PersoCommandNames.LockPerso)]
        public void btnLockPerso_Click(object sender, EventArgs e)
        {
            string checkCoTheChua = dgvPersoes.Rows[dgvPersoes.CurrentRow.Index].Cells[colCardStatus.Name].Value.ToString();
            if (checkCoTheChua != null && checkCoTheChua != "") {
                var selectedRows = dgvPersoes.SelectedRows;
                int rowsCount = selectedRows.Count;
                if (rowsCount == 0) {
                    MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "cancelissuer"), MessageValidate.GetErrorTitle(rm));
                    return;
                }

                var confirmDialog = FrmConfirmChangeStatus.GetInstance(FrmConfirmChangeStatus.Lock, rm);
                confirmDialog.ShowDialog();
                if (confirmDialog.DialogResult == DialogResult.Yes) {
                    long[] persoIds = new long[rowsCount];
                    for (int i = 0; i < rowsCount; i++) {
                        persoIds[i] = Convert.ToInt64(selectedRows[i].Cells[colCardId.Name].Value.ToString());
                    }
                    DoLockPersoes(persoIds, confirmDialog.Reason);
                }
            }
        }

        [CommandHandler(PersoCommandNames.UnLockPerso)]
        public void btnUnLockPerso_Click(object sender, EventArgs e)
        {
            string checkCoTheChua = dgvPersoes.Rows[dgvPersoes.CurrentRow.Index].Cells[colCardStatus.Name].Value.ToString();
            if (checkCoTheChua != null && checkCoTheChua != "") {
                var selectedRows = dgvPersoes.SelectedRows;
                int rowsCount = selectedRows.Count;
                if (rowsCount == 0) {
                    MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessSelect(rm, MessageValidate.UnlockRelease), MessageValidate.GetErrorTitle(rm));
                    return;
                }

                var confirmDialog = FrmConfirmChangeStatus.GetInstance(FrmConfirmChangeStatus.UnLock, rm);
                confirmDialog.ShowDialog();
                if (confirmDialog.DialogResult == DialogResult.Yes) {
                    long[] persoIds = new long[rowsCount];
                    for (int i = 0; i < rowsCount; i++) {
                        persoIds[i] = Convert.ToInt64(selectedRows[i].Cells[colCardId.Name].Value.ToString());
                    }
                    DoUnLockPersoes(persoIds, confirmDialog.Reason);
                }
            }
        }

        [CommandHandler(PersoCommandNames.CancelPerso)]
        public void btnCancelPerso_Click(object sender, EventArgs e)
        {
            string checkCoTheChua = dgvPersoes.Rows[dgvPersoes.CurrentRow.Index].Cells[colCardStatus.Name].Value.ToString();
            if (checkCoTheChua != null && checkCoTheChua != "") {
                var selectedRows = dgvPersoes.SelectedRows;
                int rowsCount = selectedRows.Count;
                if (rowsCount == 0) {
                    MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessSelect(rm, MessageValidate.CancelRelease), MessageValidate.GetErrorTitle(rm));
                    return;
                }

                var confirmDialog = FrmConfirmChangeStatus.GetInstance(FrmConfirmChangeStatus.Cancel, rm);
                confirmDialog.ShowDialog();
                if (confirmDialog.DialogResult == DialogResult.Yes) {
                    if (MessageBoxManager.ShowQuestionMessageBox(this,
                    MessageValidate.GetMessage(rm, "CancelPersonCheck")) == DialogResult.Yes) {
                        long[] persoIds = new long[rowsCount];
                        for (int i = 0; i < rowsCount; i++) {
                            persoIds[i] = Convert.ToInt64(selectedRows[i].Cells[colCardId.Name].Value.ToString());
                        }
                        DoCancelPersoes(persoIds, confirmDialog.Reason);
                    }
                }
            }
        }

        [CommandHandler(PersoCommandNames.ExtendPerso)]
        public void btnExtendPerso_Click(object sender, EventArgs e)
        {
            string checkCoTheChua = dgvPersoes.Rows[dgvPersoes.CurrentRow.Index].Cells[colCardStatus.Name].Value.ToString();
            if (checkCoTheChua != null && checkCoTheChua != "") {
                var selectedRows = dgvPersoes.SelectedRows;
                int rowsCount = selectedRows.Count;
                if (rowsCount == 0) {
                    MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessSelect(rm, MessageValidate.ExtensionRelease), MessageValidate.GetErrorTitle(rm));
                    return;
                }

                var chooseExpDateDialog = new FrmChooseExpDate();
                chooseExpDateDialog.ShowDialog();
                if (chooseExpDateDialog.DialogResult == DialogResult.Yes) {
                    long[] persoIds = new long[rowsCount];
                    for (int i = 0; i < rowsCount; i++) {
                        persoIds[i] = Convert.ToInt64(selectedRows[i].Cells[colChipPersoId.Name].Value.ToString());
                    }
                    DoExtendPersoes(persoIds, chooseExpDateDialog.SelectedDate);
                }
            }
        }

        [CommandHandler(PersoCommandNames.MarkBroken)]
        public void btnMarkBroken_Clicked(object s, EventArgs e)
        {
            string checkCoTheChua = dgvPersoes.Rows[dgvPersoes.CurrentRow.Index].Cells[colCardStatus.Name].Value.ToString();
            if (checkCoTheChua != null && checkCoTheChua != "") {
                var selectedRows = dgvPersoes.SelectedRows;
                int rowsCount = selectedRows.Count;
                if (rowsCount == 0) {
                    MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessSelect(rm, MessageValidate.DamageMark), MessageValidate.GetErrorTitle(rm));
                    return;
                }

                string message = string.Format("Bạn có chắc muốn đánh dấu hư cho {0}thẻ này không?" + Environment.NewLine + Environment.NewLine + "Lưu ý là việc đánh dấu thẻ mất sẽ làm lượt phát hành tương ứng (nếu có) bị vô hiệu hóa.", rowsCount == 1 ? string.Empty : "các ");
                if (MessageBoxManager.ShowQuestionMessageBox(this, message) == DialogResult.Yes) {
                    long[] userIds = new long[rowsCount];
                    for (int i = 0; i < rowsCount; i++) {
                        userIds[i] = Convert.ToInt64(selectedRows[i].Cells[colCardId.Name].Value.ToString());
                    }
                    DoMarkBrokenCard(userIds);
                }
            }
        }

        [CommandHandler(PersoCommandNames.UnMarkBroken)]
        public void btnUnMarkBroken_Clicked(object s, EventArgs e)
        {
            string checkCoTheChua = dgvPersoes.Rows[dgvPersoes.CurrentRow.Index].Cells[colCardStatus.Name].Value.ToString();
            if (checkCoTheChua != null && checkCoTheChua != "") {
                var selectedRows = dgvPersoes.SelectedRows;
                int rowsCount = selectedRows.Count;
                if (rowsCount == 0) {
                    MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessSelect(rm, MessageValidate.DamageMark), MessageValidate.GetErrorTitle(rm));
                    return;
                }

                string message = string.Format("Bạn có chắc muốn hủy đánh dấu hư cho {0}thẻ này không?", rowsCount == 1 ? string.Empty : "các ");
                if (MessageBoxManager.ShowQuestionMessageBox(this, message) == DialogResult.Yes) {
                    long[] userIds = new long[rowsCount];
                    for (int i = 0; i < rowsCount; i++) {
                        userIds[i] = Convert.ToInt64(selectedRows[i].Cells[colCardId.Name].Value.ToString());
                    }
                    DoUnMarkBrokenCard(userIds);
                }
            }
        }

        [CommandHandler(PersoCommandNames.MarkLost)]
        public void btnMarkLost_Clicked(object s, EventArgs e)
        {
            string checkCoTheChua = dgvPersoes.Rows[dgvPersoes.CurrentRow.Index].Cells[colCardStatus.Name].Value.ToString();
            if (checkCoTheChua != null && checkCoTheChua != "") {
                var selectedRows = dgvPersoes.SelectedRows;
                int rowsCount = selectedRows.Count;
                if (rowsCount == 0) {
                    MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessSelect(rm, MessageValidate.LostMark), MessageValidate.GetErrorTitle(rm));
                    return;
                }

                string message = string.Format("Bạn có chắc muốn đánh dấu mất cho {0}thẻ này không?" + Environment.NewLine + Environment.NewLine + "Lưu ý là việc đánh dấu thẻ mất sẽ làm lượt phát hành tương ứng (nếu có) bị vô hiệu hóa.", rowsCount == 1 ? string.Empty : "các ");
                if (MessageBoxManager.ShowQuestionMessageBox(this, message) == DialogResult.Yes) {
                    long[] userIds = new long[rowsCount];
                    for (int i = 0; i < rowsCount; i++) {
                        userIds[i] = Convert.ToInt64(selectedRows[i].Cells[colCardId.Name].Value.ToString());
                    }
                    DoMarkLostCard(userIds);
                }
            }
        }

        [CommandHandler(PersoCommandNames.UnMarkLost)]
        public void btnUnMarkLost_Clicked(object s, EventArgs e)
        {
            string checkCoTheChua = dgvPersoes.Rows[dgvPersoes.CurrentRow.Index].Cells[colCardStatus.Name].Value.ToString();
            if (checkCoTheChua != null && checkCoTheChua != "") {
                var selectedRows = dgvPersoes.SelectedRows;
                int rowsCount = selectedRows.Count;
                if (rowsCount == 0) {
                    MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessSelect(rm, MessageValidate.CancelLostMark), MessageValidate.GetErrorTitle(rm));
                    return;
                }

                string message = string.Format("Bạn có chắc muốn hủy đánh dấu mất cho {0}thẻ này không?", rowsCount == 1 ? string.Empty : "các ");
                if (MessageBoxManager.ShowQuestionMessageBox(this, message) == DialogResult.Yes) {
                    long[] userIds = new long[rowsCount];
                    for (int i = 0; i < rowsCount; i++) {
                        userIds[i] = Convert.ToInt64(selectedRows[i].Cells[colCardId.Name].Value.ToString());
                    }
                    DoUnMarkLostCard(userIds);
                }
            }
        }

        [EventPublication(PersoEventTopicNames.PersoListShown)]
        public event EventHandler MemberMgtMainShown;

        [EventPublication(PersoEventTopicNames.PersoListHide)]
        public event EventHandler MemberMgtMainHide;

        #endregion CAB events


        #region Group

        //private void LoadGroupSubOrg()
        //{
        //    GroupSubOrgList = new Dictionary<string, string>();
        //    String[] result = GroupSettings.Instance.Group.Split(',');

        //    foreach (String group in result)
        //    {
        //        string[] item = group.Split('-');
        //        if (item.Length > 0)
        //            GroupSubOrgList.Add(item.FirstOrDefault(), item.LastOrDefault());
        //    }
        //    GroupSubOrgList.GroupBy(g => g.Value);
        //}

        #endregion

        #endregion

        private void tbxMemberCode_TextChanged(object sender, EventArgs e)
        {
            //20170403 #Bug 846 Fix Quản lý phát hành_Load dữ liệu - Minh Nguyen Start
            DataView dv = new DataView(dtblPersoList);
            string strData = FormatCharacterSearch.CheckValue(tbxMemberCode.Text.Trim());
            dv.RowFilter = string.Format(colFullName.DataPropertyName + " LIKE '%{0}%'", strData);
            dgvPersoes.DataSource = dv;
            //20170403 #Bug 846 Fix Quản lý phát hành_Load dữ liệu - Minh Nguyen End
        }

        private void tbxMemberName_TextChanged(object sender, EventArgs e)
        {
            //20170403 #Bug 846 Fix Quản lý phát hành_Load dữ liệu - Minh Nguyen Start
            DataView dv = new DataView(dtblPersoList);
            string strData = FormatCharacterSearch.CheckValue(tbxMemberName.Text.Trim());
            dv.RowFilter = string.Format(colMemberCode.DataPropertyName + " LIKE '%{0}%'", strData);
            dgvPersoes.DataSource = dv;
            //20170403 #Bug 846 Fix Quản lý phát hành_Load dữ liệu - Minh Nguyen End
        }
    }
}