using CommonControls;
using CommonHelper.Config;
using CommonHelper.Constants;
using CommonHelper.Utils;
using JavaCommunication.Factory;
using Microsoft.Practices.CompositeUI;
using sWorldModel;
using sWorldModel.Exceptions;
using sWorldModel.Filters;
using sWorldModel.TransportData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Resources;
using System.ServiceModel;
using System.Windows.Forms;

namespace SystemMgtComponent.WorkItems.MoveSubOrganizationForPerson {
    public partial class FrmMoveSubOrgForMember : CommonControls.Custom.CommonDialog {
        #region Properties
        List<OrgSubOrgCustomDTO> listSubOrg;
        long subOrgIdLeft, subOrgIdRight;
        long parentOrgIdLeft, parentOrgIdRight;
        List<sWorldModel.TransportData.Member> listMemberLeft, listMemberRight;

        // Member List
        private DataTable dtbMemberListLeft;
        private DataTable dtbMemberListRight;
        List<MoveMemberSubOrg> listMemberIDLeftRight;

        bool onLoad = true;
        bool currentIsLeft = true;
        bool skipEventDGVSelectChange = false;
        private BackgroundWorker bgwLoadOrgList, bgwLoadMemberListLeft, bgwLoadMemberListRight, bgwMoveMemberSubOrg;

        private ResourceManager rm;
        private SystemWorkItem workItem;
        [ServiceDependency]
        public SystemWorkItem WorkItem {
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
        public FrmMoveSubOrgForMember() {
            InitializeComponent();
            registerEvent();
            initDataTableListMemberLeft();
            initDataTableListMemberRight();
        }

        private void registerEvent() {
            // Backgroundworker load danh sách org
            bgwLoadOrgList = new BackgroundWorker();
            bgwLoadOrgList.WorkerSupportsCancellation = true;
            bgwLoadOrgList.DoWork += bgwLoadOrgList_DoWork;
            bgwLoadOrgList.RunWorkerCompleted += bgwLoadOrgList_RunWorkerCompleted;

            // Backgroundworker load danh sách member left
            bgwLoadMemberListLeft = new BackgroundWorker();
            bgwLoadMemberListLeft.WorkerSupportsCancellation = true;
            bgwLoadMemberListLeft.DoWork += bgwLoadMemberListLeft_DoWork;
            bgwLoadMemberListLeft.RunWorkerCompleted += bgwLoadMemberListLeft_RunWorkerCompleted;

            // Backgroundworker load danh sách member right
            bgwLoadMemberListRight = new BackgroundWorker();
            bgwLoadMemberListRight.WorkerSupportsCancellation = true;
            bgwLoadMemberListRight.DoWork += bgwLoadMemberListRight_DoWork;
            bgwLoadMemberListRight.RunWorkerCompleted += bgwLoadMemberListRight_RunWorkerCompleted;

            // Backgroundworker move member sub org
            bgwMoveMemberSubOrg = new BackgroundWorker();
            bgwMoveMemberSubOrg.WorkerSupportsCancellation = true;
            bgwMoveMemberSubOrg.DoWork += bgwMoveMemberSubOrg_DoWork;
            bgwMoveMemberSubOrg.RunWorkerCompleted += bgwMoveMemberSubOrg_RunWorkerCompleted;

            // ComboBox
            cbxLeft.SelectedIndexChanged += cbxLeft_SelectedIndexChanged;
            cbxRight.SelectedIndexChanged += cbxRight_SelectedIndexChanged;

            // DataGridView
            dgvLeft.CellClick += dgvLeft_CellClick;
            dgvRight.CellClick += dgvRight_CellClick;
            dgvLeft.SelectionChanged += dgvLeft_SelectionChanged;
            dgvRight.SelectionChanged += dgvRight_SelectionChanged;

            // 2 Button
            btnConfirm.Click += btnConfirm_Click;
            btnRefresh.Click += btnRefresh_Click;
            btnCancel.Click += btnCancel_Click;
            btnMoveToRight.Click += btnMoveToRight_Click;
            btnMoveToLeft.Click += btnMoveToLeft_Click;
        }

        protected override void OnLoad(EventArgs e) {
            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(Controls, rm);

            // Set Language
            setLanguage();

            // Lấy danh sách sub-org từ server
            getListOrg();
        }
        #endregion

        #region Set Language
        private void setLanguage() {
            btnCancel.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, btnCancel.Name);
            btnConfirm.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, btnConfirm.Name);
            btnRefresh.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, btnRefresh.Name);
            colFullNameLeft.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, colFullNameLeft.Name);
            colFullNameRight.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, colFullNameRight.Name);
            colNoLeft.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, colNoLeft.Name);
            colNoRight.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, colNoRight.Name);
            Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, Name);
            lblListMemberLeft.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblListMemberLeft.Name);
            lblListMemberRight.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblListMemberRight.Name);
            lblMoveFrom.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblMoveFrom.Name);
            lblMoveSubOrg.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblMoveSubOrg.Name);
            lblMoveTo.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblMoveTo.Name);
            lblMSOInformation.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblMSOInformation.Name);
        }
        #endregion

        #region Events
        /// <summary>
        /// Load danh sách org từ server
        /// </summary>
        private void getListOrg() {
            if (!bgwLoadOrgList.IsBusy) {
                bgwLoadOrgList.RunWorkerAsync();
            }
        }

        public void GetSubTree(OrgCustomerDto org, long orgId, List<OrgSubOrgCustomDTO> listOSO) {
            List<SubOrgCustomerDTO> lstSubOrgCustomerDTO = org.SubOrgList;

            // does not have sub organization
            if (null != lstSubOrgCustomerDTO) {
                List<SubOrgCustomerDTO> lstSubOrgCustomer = lstSubOrgCustomerDTO.Where(key => key.parentOrgId == orgId).ToList();
                if (lstSubOrgCustomer != null) {
                    foreach (SubOrgCustomerDTO subOrg in lstSubOrgCustomer) {
                        OrgSubOrgCustomDTO oso = new OrgSubOrgCustomDTO();

                        oso.id = subOrg.SubOrgId;
                        oso.parentId = subOrg.parentOrgId;
                        oso.name = subOrg.Name;
                        if (orgId == subOrg.parentOrgId) {
                            listOSO.Add(oso);
                        }
                        GetSubTree(org, subOrg.SubOrgId, listOSO);
                    }
                }
            }
        }

        /// <summary>
        /// Gán danh sách Sub-Org get được từ server vào 2 ComboBox
        /// </summary>
        /// <param name="result"></param>
        private void initComboBoxOrg(List<OrgSubOrgCustomDTO> result) {
            // ComboBox left
            cbxLeft.BindingContext = new BindingContext();
            cbxLeft.DataSource = result;
            cbxLeft.DisplayMember = "name";

            // ComboBox right
            cbxRight.BindingContext = new BindingContext();
            cbxRight.DataSource = result;
            cbxRight.DisplayMember = "name";
        }

        /// <summary>
        /// Get danh sách member theo subOrgId
        /// </summary>
        private void getListMemberLeft() {
            if (!bgwLoadMemberListLeft.IsBusy) {
                dtbMemberListLeft.Rows.Clear();
                bgwLoadMemberListLeft.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Get danh sách member theo subOrgId
        /// </summary>
        private void getListMemberRight() {
            if (!bgwLoadMemberListRight.IsBusy) {
                dtbMemberListRight.Rows.Clear();
                bgwLoadMemberListRight.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Chuẩn bị list ID member để gửi qua server
        /// </summary>
        private void getListMember() {
            listMemberIDLeftRight = new List<MoveMemberSubOrg>();

            if (dtbMemberListLeft.Rows.Count > 0) {
                for (int i = 0; i < dtbMemberListLeft.Rows.Count; i++) {
                    DataRow row = dtbMemberListLeft.Rows[i];
                    MoveMemberSubOrg moveMember = new MoveMemberSubOrg();

                    moveMember.memberID = Convert.ToInt64(row[colIDLeft.Name]);
                    moveMember.isLeft = true;

                    listMemberIDLeftRight.Add(moveMember);
                }
            }

            if (dtbMemberListRight.Rows.Count > 0) {
                for (int i = 0; i < dtbMemberListRight.Rows.Count; i++) {
                    DataRow row = dtbMemberListRight.Rows[i];
                    MoveMemberSubOrg moveMember = new MoveMemberSubOrg();

                    moveMember.memberID = Convert.ToInt64(row[colIDRight.Name]);
                    moveMember.isLeft = false;

                    listMemberIDLeftRight.Add(moveMember);
                }
            }
        }

        /// <summary>
        /// Move Sub-ORG
        /// </summary>
        private void moveMemberSubOrg() {
            if (!bgwMoveMemberSubOrg.IsBusy) {
                bgwMoveMemberSubOrg.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Chọn ComboBox Sub-Org bên trái
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxLeft_SelectedIndexChanged(object sender, EventArgs e) {
            if (null != cbxLeft.SelectedItem) {
                OrgSubOrgCustomDTO oso = (OrgSubOrgCustomDTO) cbxLeft.SelectedItem;
                if (null != oso) {
                    subOrgIdLeft = oso.id;
                    parentOrgIdLeft = oso.parentId;
                    getListMemberLeft();
                    if (null != listMemberRight) {
                        dtbMemberListRight.Rows.Clear();
                        setMemberToDataGridViewRight(listMemberRight);
                    }

                    // Sau khi chọn org xong thì focus vô danh sách thành viên bên đó
                    dgvRight.ClearSelection();
                    dgvLeft.Focus();
                }
            }
        }

        /// <summary>
        /// Chọn ComboBox Sub-Org bên phải
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxRight_SelectedIndexChanged(object sender, EventArgs e) {
            if (null != cbxRight.SelectedItem) {
                OrgSubOrgCustomDTO oso = (OrgSubOrgCustomDTO) cbxRight.SelectedItem;
                if (null != oso) {
                    subOrgIdRight = oso.id;
                    parentOrgIdRight = oso.parentId;
                    getListMemberRight();
                    if (null != listMemberLeft) {
                        dtbMemberListLeft.Rows.Clear();
                        setMemberToDataGridViewLeft(listMemberLeft);
                    }

                    // Sau khi chọn org xong thì focus vô danh sách thành viên bên đó
                    dgvLeft.ClearSelection();
                    dgvRight.Focus();
                }
            }
        }

        private void dgvLeft_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (!currentIsLeft) {
                skipEventDGVSelectChange = true;
                dgvRight.ClearSelection();
                currentIsLeft = true;
            }
        }

        private void dgvRight_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (currentIsLeft) {
                skipEventDGVSelectChange = true;
                dgvLeft.ClearSelection();
                currentIsLeft = false;
            }
        }

        private void dgvLeft_SelectionChanged(object sender, EventArgs e) {
            if (!onLoad) {
                if (!skipEventDGVSelectChange) {
                    if (subOrgIdLeft == subOrgIdRight) {
                        enabledButton(false);
                        btnMoveToLeft.Enabled = false;
                    } else {
                        enabledButton(true);
                    }
                }
                skipEventDGVSelectChange = false;
            }
        }

        private void dgvRight_SelectionChanged(object sender, EventArgs e) {
            if (!onLoad) {
                if (!skipEventDGVSelectChange) {
                    if (subOrgIdLeft == subOrgIdRight) {
                        enabledButton(true);
                        btnMoveToRight.Enabled = false;
                    } else {
                        enabledButton(false);
                    }
                }
                skipEventDGVSelectChange = false;
            }
        }

        private void enabledButton(bool value) {
            btnMoveToRight.Enabled = value;
            btnMoveToLeft.Enabled = !value;
        }

        private void refreshForm() {
            onLoad = true;
            currentIsLeft = true;
            skipEventDGVSelectChange = false;
            if (subOrgIdLeft == subOrgIdRight) {
                btnMoveToLeft.Enabled = btnMoveToRight.Enabled = false;
            } else {
                enabledButton(true);
            }
            getListMemberLeft();
            getListMemberRight();
        }
        #endregion

        #region Button Events
        private void btnConfirm_Click(object sender, EventArgs e) {
            if (MessageBoxManager.ShowQuestionMessageBox(this,
                            MessageValidate.GetMessage(rm, "MoveMemberSubOrgCheck")) == DialogResult.Yes) {
                getListMember();
                moveMemberSubOrg();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e) {
            refreshForm();
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            Close();
        }

        private void btnMoveToRight_Click(object sender, EventArgs e) {
            foreach (DataGridViewRow selectedRowForMove in dgvLeft.SelectedRows) {
                DataRow row = dtbMemberListLeft.Rows[selectedRowForMove.Index];

                // Move trên giao diện
                dtbMemberListRight.Rows.Add(row.ItemArray);
                row.Delete();
            }
        }

        private void btnMoveToLeft_Click(object sender, EventArgs e) {
            foreach (DataGridViewRow selectedRowForMove in dgvRight.SelectedRows) {
                DataRow row = dtbMemberListRight.Rows[selectedRowForMove.Index];

                // Move trên giao diện
                dtbMemberListLeft.Rows.Add(row.ItemArray);
                row.Delete();
            }
        }
        #endregion

        #region Set DataGridView Member
        /// <summary>
        /// Tạo DataTable để lưu trữ data cho DataGridView bên trái
        /// </summary>
        private void initDataTableListMemberLeft() {
            dtbMemberListLeft = new DataTable();

            dtbMemberListLeft.Columns.Add(colNoLeft.Name);
            dtbMemberListLeft.Columns.Add(colIDLeft.Name);
            dtbMemberListLeft.Columns.Add(colFullNameLeft.Name);

            dgvLeft.DataSource = dtbMemberListLeft;
        }

        /// <summary>
        /// Tạo DataTable để lưu trữ data cho DataGridView bên phải
        /// </summary>
        private void initDataTableListMemberRight() {
            dtbMemberListRight = new DataTable();

            dtbMemberListRight.Columns.Add(colNoRight.Name);
            dtbMemberListRight.Columns.Add(colIDRight.Name);
            dtbMemberListRight.Columns.Add(colFullNameRight.Name);

            dgvRight.DataSource = dtbMemberListRight;
        }

        /// <summary>
        /// Load member get được từ server vào DataGridView bên trái
        /// </summary>
        /// <param name="listMember"></param>
        private void setMemberToDataGridViewLeft(List<sWorldModel.TransportData.Member> listMember) {
            foreach (sWorldModel.TransportData.Member member in listMember) {
                DataRow row = dtbMemberListLeft.NewRow();
                row.BeginEdit();

                row[colIDLeft.DataPropertyName] = member.Id;
                row[colNoLeft.DataPropertyName] = member.Code;
                row[colFullNameLeft.DataPropertyName] = member.LastName + " " + member.FirstName;

                row.EndEdit();
                dtbMemberListLeft.Rows.Add(row);
            }
        }

        /// <summary>
        /// Load member get được từ server vào DataGridView bên phải
        /// </summary>
        /// <param name="listMember"></param>
        private void setMemberToDataGridViewRight(List<sWorldModel.TransportData.Member> listMember) {
            foreach (sWorldModel.TransportData.Member member in listMember) {
                DataRow row = dtbMemberListRight.NewRow();
                row.BeginEdit();

                row[colIDRight.DataPropertyName] = member.Id;
                row[colNoRight.DataPropertyName] = member.Code;
                row[colFullNameRight.DataPropertyName] = member.LastName + " " + member.FirstName;

                row.EndEdit();
                dtbMemberListRight.Rows.Add(row);
            }
        }
        #endregion

        #region Background Worker
        #region Load Sub-Org List
        private void bgwLoadOrgList_DoWork(object sender, DoWorkEventArgs e) {
            OrgFilterDto filter = new OrgFilterDto();

            if (!((SystemSettings.Instance.OrgCode).Equals("") || (SystemSettings.Instance.OrgCode).Equals("ALL"))) {
                filter.OrgCode = SystemSettings.Instance.OrgCode;
                filter.FilterByOrgCode = true;
            }
            try {
                e.Result = OrganizationFactory.Instance.GetChannel().GetListSubOrg(storageService.CurrentSessionId, filter);
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

        private void bgwLoadOrgList_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (e.Cancelled) {
                return;
            }

            // Lấy danh sách org từ DoWork
            List<OrgCustomerDto> result = (List<OrgCustomerDto>) e.Result;

            // Nếu danh sách org không rỗng thì load vào ComboBox
            if (null != result) {
                listSubOrg = new List<OrgSubOrgCustomDTO>();
                foreach (OrgCustomerDto org in result) {
                    if (!org.Issuer.Equals(SystemSettings.Instance.Master)) {
                        OrgSubOrgCustomDTO oso = new OrgSubOrgCustomDTO();

                        oso.id = org.OrgId;
                        oso.parentId = org.parentOrgId;
                        oso.name = org.Name;
                        GetSubTree(org, org.OrgId, listSubOrg);
                    }
                }

                initComboBoxOrg(listSubOrg);
                btnConfirm.Enabled = true;
            }
        }
        #endregion

        #region Load Member List
        private void bgwLoadMemberListLeft_DoWork(object sender, DoWorkEventArgs e) {
            try {
                e.Result = OrganizationFactory.Instance.GetChannel().GetListMemberBySubOrgID(StorageService.CurrentSessionId, subOrgIdLeft, parentOrgIdLeft);
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

        private void bgwLoadMemberListLeft_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (e.Cancelled) {
                return;
            }
            if (e.Result == null) {
                return;
            }

            // Lấy danh sách member từ DoWork
            listMemberLeft = new List<sWorldModel.TransportData.Member>();
            listMemberLeft = (List<sWorldModel.TransportData.Member>) e.Result;

            // Nếu danh sách member không rỗng thì load vào DataGridView
            if (listMemberLeft.Count > 0) {
                setMemberToDataGridViewLeft(listMemberLeft);
            }
        }

        private void bgwLoadMemberListRight_DoWork(object sender, DoWorkEventArgs e) {
            try {
                e.Result = OrganizationFactory.Instance.GetChannel().GetListMemberBySubOrgID(StorageService.CurrentSessionId, subOrgIdRight, parentOrgIdRight);
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

        private void bgwLoadMemberListRight_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (e.Cancelled) {
                return;
            }
            if (e.Result == null) {
                return;
            }

            // Lấy danh sách member từ DoWork
            listMemberRight = new List<sWorldModel.TransportData.Member>();
            listMemberRight = (List<sWorldModel.TransportData.Member>) e.Result;

            // Nếu danh sách member không rỗng thì load vào DataGridView
            if (listMemberRight.Count > 0) {
                setMemberToDataGridViewRight(listMemberRight);

                if (onLoad) {
                    // Mặc định focus vào bảng bên trái khi mới mở cửa sổ
                    dgvRight.ClearSelection();
                    onLoad = false;
                }
            }
        }
        #endregion

        #region Move Member Sub-Org
        private void bgwMoveMemberSubOrg_DoWork(object sender, DoWorkEventArgs e) {
            try {
                e.Result = OrganizationFactory.Instance.GetChannel().MoveSubOrg(StorageService.CurrentSessionId, subOrgIdLeft, subOrgIdRight, listMemberIDLeftRight);
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
        private void bgwMoveMemberSubOrg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (e.Cancelled) {
                return;
            }
            if (e.Result == null) {
                return;
            }

            if (Convert.ToInt16(e.Result) != 0) {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "MoveMemberSubOrgFail"));
            } else {
                refreshForm();
            }
        }
        #endregion
        #endregion
    }
}
