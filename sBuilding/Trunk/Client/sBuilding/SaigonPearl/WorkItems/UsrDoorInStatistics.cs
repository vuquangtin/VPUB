using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Practices.CompositeUI;
using sWorldModel;
using Microsoft.Practices.CompositeUI.Commands;
using CommonHelper.Constants;
using sWorldModel.Filters;
using JavaCommunication.Factory;
using CommonControls;
using sWorldModel.Exceptions;
using sWorldModel.TransportData;
using System.ServiceModel;
using CommonHelper.Config;
using CommonControls.Custom;
using System.Resources;
using CommonHelper.Utils;
using sAccessComponent.Constants;


namespace sAccessComponent.WorkItems {
    public partial class UsrDoorInStatistics : CommonUserControl
    {
        #region Properties

        // Height of filter box when it is hidden
        private int hiddenFilterBoxHeight = 1;
        // The original height of filter box (at startup)
        private int startupFilterBoxHeight;

        private ResourceManager rm;

        private int ImageHeight = 0;
        private int currentPageIndex = 1;
        // The original font of tree nodes
        private Font startupNodeFont;

        private DataTable dtbDoorOutList;
        private BackgroundWorker bgwLoadDoorOut;
        private BackgroundWorker bgwLoadDeviceDoorList;

        private TreeNode rootNode;
        private TreeNode selectedDeviceNode;
        private List<DoorOut> DooroutList;
        private List<DeviceDoor> DeviceDoorList;


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

        #endregion Properties

        #region Initialization

        public UsrDoorInStatistics()
        {
            InitializeComponent();
            RegisterEvent();
            InitDataTableDoorOut();
            InitTreeList();
        }

        protected override void OnLoad(EventArgs e) {
            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);

            LoadDeviceList();
            startupFilterBoxHeight = this.pnlFilterBox.Height;
            // Set Language
            SetLanguage();
        }
        #endregion

        #region Set Language
        private void SetLanguage() {
            this.lblLeftAreaTitleGroupDoor.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.lblLeftAreaTitleGroupDoor.Name);
            this.lblRightAreaTitleListAttendace.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.lblRightAreaTitleListAttendace.Name);
            this.btnReloadDevice.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnReloadDevice.Name);
            this.btnReloadCards.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnReloadCards.Name);
            this.btnExportToExcel.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnExportToExcel.Name);
            this.cbxFilterBySerialNumber.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.cbxFilterBySerialNumber.Name);
            this.cbxFilterByDate.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.cbxFilterByDate.Name);
            this.cbxLoadImage.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.cbxLoadImage.Name);
            this.colCardId.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colCardId.Name);
            this.colApartment.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colApartment.Name);
            this.colMemberCode.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colMemberCode.Name);
            this.colFullName.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colFullName.Name);
            this.colDateIn.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colDateIn.Name);
            this.colDateOut.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colDateOut.Name);
            this.colImageIn.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colImageIn.Name);
            this.colImageOut.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colImageOut.Name);
        }
        #endregion

        #region Form events

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (bgwLoadDoorOut.IsBusy)
                {
                    bgwLoadDoorOut.CancelAsync();
                }
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #endregion

        #region Controls events

        void trvDeviceList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectedNode = e.Node;
            TreeNode parentNode = new TreeNode();
            if (selectedNode != null)
            {
                parentNode = selectedNode.Parent;
                selectedNode.NodeFont = new Font(startupNodeFont, FontStyle.Bold);
                selectedNode.Text = selectedNode.Text;

                if (selectedDeviceNode != null && selectedNode == selectedDeviceNode)
                {
                    return;
                }

                selectedDeviceNode = selectedNode;

                if (selectedDeviceNode.Level == 1)
                {
                    LoadDoorOut();
                }

                currentPageIndex = 1;
            }
        }

        void trvDeviceList_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            // If background worker is running -> restrict selecting another node
            if (bgwLoadDoorOut.IsBusy)
            {
                e.Cancel = true;
                return;
            }

            // Change node font style to normal
            if (selectedDeviceNode != null)
            {
                selectedDeviceNode.NodeFont = new Font(startupNodeFont, FontStyle.Regular);
                selectedDeviceNode.Text = selectedDeviceNode.Text;
            }
        }

        void trvDeviceList_AfterExpand(object sender, TreeViewEventArgs e)
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
                trvDeviceList.SelectedNode = null;
            }
        }

        void bgwLoadDeviceDoorList_DoWork(object sender, DoWorkEventArgs e)
        {
            List<DeviceDoor> result = null;
            try
            {
                e.Result = DeviceDoorList = AccessFactory.Instance.GetChannel().GetDeviceDoorList(StorageService.CurrentSessionId);
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

        void bgwLoadDeviceDoorList_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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
            List<DeviceDoor> result = (List<DeviceDoor>)e.Result;
            foreach (DeviceDoor device in result)
            {
                TreeNode deviceNode = new TreeNode();
                deviceNode.Text = device.Name + " - " + device.Ip + ":" + device.Port;
                deviceNode.Name = Convert.ToString(device.Id);
                rootNode.Nodes.Add(deviceNode);
            }
        }

        private void bgwLoadDoorOut_DoWork(object sender, DoWorkEventArgs e)
        {
            if (e.Argument == null || !(e.Argument is DoorOutFilterDto))
            {
                return;
            }
            DoorOutFilterDto filter = e.Argument as DoorOutFilterDto;
            List<DoorOut> result = null;
            int totalRecords = 0;
            int take = LocalSettings.Instance.RecordsPerPage;
            int skip = 0;
            currentPageIndex = 1;

            try
            {
                DooroutList = AccessFactory.Instance.GetChannel().GetDoorOutList(StorageService.CurrentSessionId, filter);
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
            finally
            {
                if (DooroutList != null)
                {
                    result = DooroutList.Skip(skip).Take(take).ToList();
                    totalRecords = DooroutList.Count;
                    pagerPanel1.ShowNumberOfRecords(totalRecords, result != null ? result.Count : 0, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
                    pagerPanel1.UpdatePagingLinks(totalRecords, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
                }
                e.Result = result;
            }
        }
        private void bgwLoadDoorOut_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if (e.Result == null || !(e.Result is List<DoorOut>))
            {
                return;
            }
            List<DoorOut> result = e.Result as List<DoorOut>;
            LoadDoorOutDataGridView(result);
        }

        private void btnShowHide_Clicked(object s, EventArgs e)
        {
            if (pnlFilterBox.Height > hiddenFilterBoxHeight)
            {
                pnlFilterBox.Height = hiddenFilterBoxHeight;
                btnShowHideFilter.Text = btnShowHideFilter.ToolTipText = "Hiện Khung Tìm Kiếm";
                btnShowHideFilter.ToolTipText = "Hiện khung tìm kiếm";
                btnShowHideFilter.Image = global::CommonControls.Properties.Resources.ArrowDown_16x16;
            }
            else
            {
                pnlFilterBox.Height = startupFilterBoxHeight;
                btnShowHideFilter.Text = btnShowHideFilter.ToolTipText = "Ẩn Khung Tìm Kiếm";
                btnShowHideFilter.ToolTipText = "Ẩn khung tìm kiếm";
                btnShowHideFilter.Image = global::CommonControls.Properties.Resources.ArrowUp_16x16;
            }
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
            dtbDoorOutList.Rows.Clear();
            int take = LocalSettings.Instance.RecordsPerPage;
            int skip = (currentPageIndex - 1) * take;

            List<DoorOut> result = DooroutList.Skip(skip).Take(take).ToList();
            LoadDoorOutDataGridView(result);

            pagerPanel1.ShowNumberOfRecords(DooroutList.Count, result != null ? result.Count : 0, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
            pagerPanel1.UpdatePagingLinks(DooroutList.Count, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
        }

        private void dgvDoorOutList_Invalidated(object sender, InvalidateEventArgs e)
        {
            try
            {
                for (int i = 0; i < dgvDoorOutList.Rows.Count; i++)
                {
                    if (!cbxLoadImage.Checked ||
                        (dgvDoorOutList.Rows[i].Cells[colImageIn.Index].Value == null &&
                        dgvDoorOutList.Rows[i].Cells[colImageOut.Index].Value == null))
                    {
                        dgvDoorOutList.Rows[i].Height = dgvDoorOutList.RowTemplate.Height;
                    }
                    else
                    {
                        dgvDoorOutList.Rows[i].Height = ImageHeight;
                    }
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void dgvDoorOutList_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo info = dgvDoorOutList.HitTest(e.X, e.Y);
                if (info.RowIndex != -1)
                {
                    if (info.RowIndex >= 0 && info.ColumnIndex >= 0)
                    {
                        if (!dgvDoorOutList.SelectedRows.Contains(dgvDoorOutList.Rows[info.RowIndex]))
                        {
                            foreach (DataGridViewRow row in dgvDoorOutList.SelectedRows)
                            {
                                row.Selected = false;
                            }
                            dgvDoorOutList.Rows[info.RowIndex].Selected = true;
                        }
                    }
                    Rectangle r = dgvDoorOutList.GetCellDisplayRectangle(info.ColumnIndex, info.RowIndex, true);
                    cmsAttendanceRecord.Show((Control)sender, e.X, e.Y);
                }
                else
                {
                    cmsAttendanceRecord.Show((Control)sender, e.X, e.Y);
                }
            }
        }

        private void cbxFilterBySerialNumber_CheckedChanged(object sender, EventArgs e)
        {
            tbxSerialNumber.Enabled = cbxFilterBySerialNumber.Checked;
        }

        private void cbxFilterByDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpDateIn.Enabled = cbxFilterByDate.Checked;
        }

        void mniViewDoorOut_Click(object sender, EventArgs e)
        {
            if (dgvDoorOutList.SelectedRows.Count > 0)
            {
                long doorOutId = Convert.ToInt64(dgvDoorOutList.SelectedRows[0].Cells[colDoorOutId.Index].Value.ToString());
                frmViewDoorOut dialog = new frmViewDoorOut(doorOutId);
                workItem.SmartParts.Add(dialog);
                dialog.ShowDialog();
                workItem.SmartParts.Remove(dialog);
                dialog.Dispose();
            }
        }

        #endregion

        #region Event's Support

        private void RegisterEvent()
        {
            Padding padding = colImageIn.DefaultCellStyle.Padding;
            ImageHeight = (colImageIn.Width - padding.Left - padding.Right) / 4 * 3;

            btnShowHideFilter.Click += btnShowHide_Clicked;
            btnReloadCards.Click += (s, e) => LoadDoorOut();
            btnReloadDevice.Click += (s, e) => LoadDeviceList();
            pagerPanel1.LinkLabelClicked += pagerPanel_LinkLabelClicked;

            dgvDoorOutList.Invalidated += dgvDoorOutList_Invalidated;
            dgvDoorOutList.MouseDown += dgvDoorOutList_MouseDown;

            bgwLoadDoorOut = new BackgroundWorker();
            bgwLoadDoorOut.WorkerSupportsCancellation = true;
            bgwLoadDoorOut.DoWork += bgwLoadDoorOut_DoWork;
            bgwLoadDoorOut.RunWorkerCompleted += bgwLoadDoorOut_Completed;

            mniViewDoorOut.Click += mniViewDoorOut_Click;

            cbxFilterBySerialNumber.CheckedChanged += cbxFilterBySerialNumber_CheckedChanged;
            cbxFilterByDate.CheckedChanged += cbxFilterByDate_CheckedChanged;

            bgwLoadDeviceDoorList = new BackgroundWorker();
            bgwLoadDeviceDoorList.WorkerSupportsCancellation = true;
            bgwLoadDeviceDoorList.DoWork += bgwLoadDeviceDoorList_DoWork;
            bgwLoadDeviceDoorList.RunWorkerCompleted += bgwLoadDeviceDoorList_RunWorkerCompleted;

            //Tree View
            trvDeviceList.AfterExpand += trvDeviceList_AfterExpand;
            trvDeviceList.BeforeSelect += trvDeviceList_BeforeSelect;
            trvDeviceList.AfterSelect += trvDeviceList_AfterSelect;

            // Assign startup value
            startupNodeFont = trvDeviceList.Font;

        }

        private void InitTreeList()
        {
            rootNode = new TreeNode();
            rootNode.Text = "Thiết bị";
            rootNode.Name = "-1";
            trvDeviceList.Nodes.Add(rootNode);
        }

        private void InitDataTableDoorOut()
        {
            dtbDoorOutList = new DataTable();
            dtbDoorOutList.Columns.Add(colApartment.DataPropertyName);
            dtbDoorOutList.Columns.Add(colDoorOutId.DataPropertyName);
            dtbDoorOutList.Columns.Add(colMemberId.DataPropertyName);
            dtbDoorOutList.Columns.Add(colCardId.DataPropertyName);
            dtbDoorOutList.Columns.Add(colMemberCode.DataPropertyName);
            dtbDoorOutList.Columns.Add(colFullName.DataPropertyName);
            dtbDoorOutList.Columns.Add(colDateIn.DataPropertyName);
            dtbDoorOutList.Columns.Add(colDateOut.DataPropertyName);
            dtbDoorOutList.Columns.Add(colImageIn.DataPropertyName, typeof(Image));
            dtbDoorOutList.Columns.Add(colImageOut.DataPropertyName, typeof(Image));
            dgvDoorOutList.DataSource = dtbDoorOutList;
        }

        private void LoadDeviceList()
        {
            if (!bgwLoadDeviceDoorList.IsBusy)
            {
                dtbDoorOutList.Rows.Clear();
                rootNode.Nodes.Clear();
                bgwLoadDeviceDoorList.RunWorkerAsync();
            }
        }

        private DoorOutFilterDto loadfilter()
        {
            DoorOutFilterDto filter = new DoorOutFilterDto();

            if (cbxFilterBySerialNumber.Checked)
            {
                filter.FilterBySerialNumber = true;
                filter.SerialNumber = tbxSerialNumber.Text.Trim();
            }
            if (cbxFilterByDate.Checked)
            {
                filter.FilterByDateIn = true;
                filter.DateIn = dtpDateIn.Value.ToStringFormatDateServer();
            }

            filter.DeviceDoorId = Convert.ToInt64(selectedDeviceNode.Name);
            return filter;
        }

        private void LoadDoorOut()
        {
            if (!bgwLoadDoorOut.IsBusy)
            {
                dtbDoorOutList.Rows.Clear();
                pagerPanel1.ShowMessage("Đang tải dữ liệu, xin hãy chờ...");
                bgwLoadDoorOut.RunWorkerAsync(loadfilter());
            }
        }

        private void LoadDoorOutDataGridView(List<DoorOut> result)
        {
            foreach (DoorOut doorOut in result)
            {
                Member member = LoadMember(doorOut.MemberId);
                DataRow row = dtbDoorOutList.NewRow();
                row.BeginEdit();

                row[colDoorOutId.DataPropertyName] = doorOut.Id;
                row[colCardId.DataPropertyName] = doorOut.SerialNumber;

                if (member != null)
                {
                    row[colMemberId.DataPropertyName] = member.Id;
                    row[colMemberCode.DataPropertyName] = member.Code;
                    row[colFullName.DataPropertyName] = member.GetFullName();

                    SubOrganization subOrg = LoadSubOrg(member.SubOrgId);
                    row[colApartment.DataPropertyName] = subOrg.names;
                }

                row[colDateIn.DataPropertyName] = doorOut.DateIn;
                row[colDateOut.DataPropertyName] = doorOut.DateOut;
                if (cbxLoadImage.Checked)
                {
                }

                row.EndEdit();
                dtbDoorOutList.Rows.Add(row);
                colImageIn.Visible = colImageOut.Visible = cbxLoadImage.Checked;
            }
        }

        private Member LoadMember(long memberId)
        {
            Member member = new Member();
            if (memberId > 0)
            {
                try
                {
                    member = OrganizationFactory.Instance.GetChannel().GetMemberById(StorageService.CurrentSessionId, memberId);
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
            return member;
        }

        private SubOrganization LoadSubOrg(long subOrgId)
        {
            SubOrganization subOrg = null;
            try
            {
                subOrg = OrganizationFactory.Instance.GetChannel().GetSubOrgById(StorageService.CurrentSessionId, subOrgId);

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
            return subOrg;
        }

        #endregion

        #region CAB events

        [CommandHandler(AccessCommandNames.ShowDoorInStatistics)]
        public void ShowCardMgtMainHandler(object s, EventArgs e)
        {
            UsrDoorInStatistics uc = workItem.Items.Get<UsrDoorInStatistics>(ComponentNames.DoorInStatistics);
            if (uc == null)
            {
                uc = workItem.Items.AddNew<UsrDoorInStatistics>(ComponentNames.DoorInStatistics);
            }
            else if (uc.IsDisposed)
            {
                workItem.Items.Remove(uc);
                uc = workItem.Items.AddNew<UsrDoorInStatistics>(ComponentNames.DoorInStatistics);
            }

            workItem.Workspaces[WorkspaceName.MainWorkspace].Show(uc);
            uc.Parent.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuDoorInStatistics);
        }

        //[EventPublication(AccessEventTopicNames.DeviceDoorMgtMainShown)]
        //public event EventHandler DeviceDoorMgtMainShown;

        //[EventPublication(AccessEventTopicNames.CardMgtMainHide)]
        //public event EventHandler CardMgtMainHide;

        #endregion
    }
}