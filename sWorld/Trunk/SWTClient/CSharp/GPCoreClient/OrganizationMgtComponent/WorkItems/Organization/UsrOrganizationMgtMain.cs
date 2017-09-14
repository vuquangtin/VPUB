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
using SystemMgtComponent.Constants;
using Microsoft.Practices.CompositeUI.Commands;
using CommonHelper.Constants;
using sWorldModel.Model;
using sWorldModel.Filters;
using JavaCommunication.Factory;
using CommonControls;
using sWorldModel.Exceptions;
using sWorldModel.TransportData;
using System.ServiceModel;
using JavaCommunication;
using SystemMgtComponent.WorkItems.IntegratingExcel;
using CommonHelper.Config;
using SystemMgtComponent.WorkItems;
using CommonControls.Custom;
using System.Resources;
using CommonHelper.Utils;


namespace SystemMgtComponent.WorkItems
{
    public partial class UsrOrganizationMgtMain : CommonUserControl
    {
        #region Properties

        private const string NotMaster = @"NOTMASTER";
        // Height of filter box when it is hidden
        private int currentPageIndex = 1;

        // Data table that contains user records
        private DataTable dtbSubOrgList;
        private List<SubOrganization> SubOrgList;
        private BackgroundWorker loadOrgWorker;
        private BackgroundWorker loadSubOrgWorker;
        private ResourceManager rm;
        //id to chuc
        private long OrgId = 0;
        //id parent suborg select
        private long SelectParentId = 0;
        //id nguoi dung select in tree
        private long SelectId = 0;
        private SystemWorkItem workItem;
        [ServiceDependency]
        public SystemWorkItem WorkItem
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

        public UsrOrganizationMgtMain()
        {
            InitializeComponent();
            RegisterEvents();
            InitOrganizationsGrid();

        }

        private void RegisterEvents()
        {
            //loadSubOrgWorker
            loadSubOrgWorker = new BackgroundWorker();
            loadSubOrgWorker.WorkerSupportsCancellation = true;
            loadSubOrgWorker.DoWork += OnLoadSubOrgWorkerDoWork;
            loadSubOrgWorker.RunWorkerCompleted += OnLoadSubOrgWorkerCompleted;
            //loadOrgWorker
            loadOrgWorker = new BackgroundWorker();
            loadOrgWorker.WorkerSupportsCancellation = true;
            loadOrgWorker.DoWork += OnLoadOrgWorkerDoWork;
            loadOrgWorker.RunWorkerCompleted += OnLoadOrgWorkerCompleted;
            //Show or hide filter

            Enter += (s, e) =>
            {
                if (OrganiztionMgtMainShown != null)
                {
                    OrganiztionMgtMainShown(this, EventArgs.Empty);
                }
            };

            // Assign startup value
            //startupNodeFont = trvOrganizations.Font;

            Load += OnFormLoad;
        }

        private void OnFormLoad(object sender, EventArgs e)
        {
            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
            treeOrg.StorageService = storageService;
            treeOrg.AfterSelect += TreeOrgAfterSelect;
            treeOrg.InitializeData();
            //set languages
            ChangeLanguages();

        }
        private void ChangeLanguages()
        {

        }
        #endregion Initialization

        #region CAB events

        [EventPublication(OrganizationEventTopicNames.OrganiztionMgtMainShown)]
        public event EventHandler OrganiztionMgtMainShown;

        [CommandHandler(OrganizationCommandNames.ShowOrganizationMgtMain)]
        public void ShowOrgMgtMainHandler(object s, EventArgs e)
        {
            UsrOrganizationMgtMain uc = workItem.Items.Get<UsrOrganizationMgtMain>(ComponentNames.OrganizationMgtComponent);
            if (uc == null)
            {
                uc = workItem.Items.AddNew<UsrOrganizationMgtMain>(ComponentNames.OrganizationMgtComponent);
            }
            else if (uc.IsDisposed)
            {
                workItem.Items.Remove(uc);
                uc = workItem.Items.AddNew<UsrOrganizationMgtMain>(ComponentNames.OrganizationMgtComponent);
            }

            workItem.Workspaces[WorkspaceName.MainWorkspace].Show(uc);
            uc.Parent.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuOrgManager);
        }

        #endregion CAB events

        #region Form events


        private void TreeOrgAfterSelect(long orgID, long parentId, long selectedOrgId)
        {
            
            this.OrgId = orgID;
            this.SelectParentId = parentId;
            this.SelectId = selectedOrgId;
            //20170603 #Bug 747 Sửa lỗi ẩn hiện các button - Ten Nguyen Start
            //20170307 #Bug 833 Fix Quản lý - Thành viên_nhập thông tin - Minh Nguyen Start
            if (parentId == -1 || orgID == -1 || selectedOrgId == -1) {
                ClearControl();
            //20170307 #Bug 833 Fix Quản lý - Thành viên_nhập thông tin - Minh Nguyen End
            } //else if (selectedOrgId != -1) { // comment vì khi click vào org không hiển thị thông tin org
            if (selectedOrgId != -1)
            {
                if (parentId == -1) {
                    LoadOrgById();
                } else {
                    LoadSubOrgById();
                }
            }
            //20170603 #Bug 747 Sửa lỗi ẩn hiện các button - Ten Nguyen End
        }

        //20170403 #Bug 833 Fix Quản lý - Thành viên_nhập thông tin - Minh Nguyen Start
        private void ClearControl() {
            txtCode.Text = String.Empty;
            txtName.Text = String.Empty;
            txtOrgShortName.Text = String.Empty;
            txtState.Text = String.Empty;
            txtCity.Text = String.Empty;
            txtCountryCode.Text = String.Empty;
            txtZipCode.Text = String.Empty;
            txtPhone.Text = String.Empty;
            txtFax.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtWebsite.Text = String.Empty;
            txtAddress.Text = String.Empty;
            txtContactName.Text = String.Empty;
            txtContactEmail.Text = String.Empty;
            txtContactPhone.Text = String.Empty;
            txtContactPhoneMobile.Text = String.Empty;
            txtNote.Text = String.Empty;
        }
        //20170403 #Bug 833 Fix Quản lý - Thành viên_nhập thông tin - Minh Nguyen End

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
            dtbSubOrgList.Rows.Clear();
            int take = LocalSettings.Instance.RecordsPerPage;
            int skip = (currentPageIndex - 1) * take;

            List<SubOrganization> result = SubOrgList.Skip(skip).Take(take).ToList();
            LoadSubOrgDataGridView(result);

            // pagerPanel1.ShowNumberOfRecords(SubOrgList.Count, result != null ? result.Count : 0, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
            //pagerPanel1.UpdatePagingLinks(SubOrgList.Count, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
        }
        #region Load Org
        private void OnLoadOrgWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = OrganizationFactory.Instance.GetChannel().GetOrgById(StorageService.CurrentSessionId,OrgId);
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

        private void OnLoadOrgWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if (e.Result == null)
            {
                return;
            }
            ToOrgModel((Organization)e.Result);
        }
        #endregion
        #region Load SubOrg
        private void OnLoadSubOrgWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = OrganizationFactory.Instance.GetChannel().GetSubOrgById(StorageService.CurrentSessionId, SelectId);
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

        private void OnLoadSubOrgWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if (e.Result == null)
            {
                return;
            }
            ToSubOrgModel((SubOrganization)e.Result);
        }
        #endregion
        private void LoadSubOrgDataGridView(List<SubOrganization> result)
        {
            foreach (SubOrganization subOrg in result)
            {
                DataRow row = dtbSubOrgList.NewRow();
                row.BeginEdit();

                //row[colOrgId.DataPropertyName] = subOrg.OrgId;
                //row[colSubOrgId.DataPropertyName] = subOrg.SubOrgId;
                //row[colOrgCode.DataPropertyName] = subOrg.OrgCode;
                //row[colName.DataPropertyName] = subOrg.Name;
                //row[colOrgShortName.DataPropertyName] = subOrg.OrgShortName;
                //row[colState.DataPropertyName] = subOrg.State;
                //row[colCity.DataPropertyName] = subOrg.City;
                //row[colCountryCount.DataPropertyName] = subOrg.CountryCode;
                //row[colZipCode.DataPropertyName] = subOrg.ZipCode;
                //row[colPhoneNo.DataPropertyName] = subOrg.Phone;
                //row[colFax.DataPropertyName] = subOrg.Fax;
                //row[colEmail.DataPropertyName] = subOrg.Email;
                //row[colWebsite.DataPropertyName] = subOrg.WebSite;
                //row[colAddress.DataPropertyName] = subOrg.Address;

                //row[colContactName.DataPropertyName] = subOrg.ContactName;
                //row[colContactEmail.DataPropertyName] = subOrg.ContactEmail;
                //row[colContactPhone.DataPropertyName] = subOrg.ContactPhone;
                //row[colContactMobile.DataPropertyName] = subOrg.ContactMobile;
                //row[colContactFax.DataPropertyName] = subOrg.ContactFax;
                //row[colNotes.DataPropertyName] = subOrg.Notes;

                row.EndEdit();
                dtbSubOrgList.Rows.Add(row);
            }
        }




        #region Event's support

        #region Organization

        private void LoadOrgById()
        {
            if (!loadOrgWorker.IsBusy)
            {
                loadOrgWorker.RunWorkerAsync();
            }
        }
        private void LoadSubOrgById()
        {
            if (!loadSubOrgWorker.IsBusy)
            {
                loadSubOrgWorker.RunWorkerAsync();
            }
        }


        #endregion

        #region SubOrg

        private void InitOrganizationsGrid()
        {
            dtbSubOrgList = new DataTable();
            //dtbSubOrgList.Columns.Add(colOrgId.DataPropertyName);
            //dtbSubOrgList.Columns.Add(colSubOrgId.DataPropertyName);
            //dtbSubOrgList.Columns.Add(colOrgCode.DataPropertyName);
            //dtbSubOrgList.Columns.Add(colName.DataPropertyName);
            //dtbSubOrgList.Columns.Add(colOrgShortName.DataPropertyName);
            //dtbSubOrgList.Columns.Add(colState.DataPropertyName);
            //dtbSubOrgList.Columns.Add(colCity.DataPropertyName);
            //dtbSubOrgList.Columns.Add(colCountryCount.DataPropertyName);
            //dtbSubOrgList.Columns.Add(colZipCode.DataPropertyName);
            //dtbSubOrgList.Columns.Add(colPhoneNo.DataPropertyName);
            //dtbSubOrgList.Columns.Add(colFax.DataPropertyName);
            //dtbSubOrgList.Columns.Add(colEmail.DataPropertyName);
            //dtbSubOrgList.Columns.Add(colWebsite.DataPropertyName);
            //dtbSubOrgList.Columns.Add(colAddress.DataPropertyName);

            //dtbSubOrgList.Columns.Add(colContactName.DataPropertyName);
            //dtbSubOrgList.Columns.Add(colContactEmail.DataPropertyName);
            //dtbSubOrgList.Columns.Add(colContactPhone.DataPropertyName);
            //dtbSubOrgList.Columns.Add(colContactMobile.DataPropertyName);
            //dtbSubOrgList.Columns.Add(colContactFax.DataPropertyName);
            //dtbSubOrgList.Columns.Add(colNotes.DataPropertyName);

            //dgvSubOrgList.DataSource = dtbSubOrgList;
        }

        private void SetShowOrHideUpdateSubOrg()
        {
            //bool checkUpdate = selectedOrgNode != null && Convert.ToInt64(selectedOrgNode.Name) > 0
            //    && dgvSubOrgList.SelectedRows.Count > 0
            //    && Convert.ToInt64(dgvSubOrgList.SelectedRows[0].Cells[0].Value.ToString()) > 0;

            //btnAddSubOrg.Enabled = selectedOrgNode != null && Convert.ToInt64(selectedOrgNode.Name) > 0;
            //btnUpdateSubOrg.Enabled = btnRemoveSubOrg.Enabled = checkUpdate;
        }


        private OrgFilterDto GetOrgFilter()
        {
            OrgFilterDto filter = new OrgFilterDto();

            //if (cbxFilterBySubOrgName.Checked )
            //{
            //    filter.FilterByOrgName = true;
            //    filter.OrgName = tbxOrgName.Text.Trim();
            //}

            return filter;
        }

        private void ToOrgModel(Organization org)
        {
            txtCode.Text = org.OrgCode;
            txtName.Text = org.Name;
            txtOrgShortName.Text = org.OrgShortName;
            txtState.Text = org.State;
            txtCity.Text = org.City;
            txtCountryCode.Text = org.CountryCode;
            txtZipCode.Text = org.ZipCode;
            txtPhone.Text = org.Phone;
            txtFax.Text = org.Fax;
            txtEmail.Text = org.Email;
            txtWebsite.Text = org.WebSite;
            txtAddress.Text = org.Address;
            txtContactName.Text = org.ContactName;
            txtContactEmail.Text = org.ContactEmail;
            txtContactPhone.Text = org.ContactPhone;
            txtContactPhoneMobile.Text = org.ContactMobile;
            txtNote.Text = org.Notes;

            lbIssuer.Visible = !org.Issuer.Contains(NotMaster);
        }
        private void ToSubOrgModel(SubOrganization subOrg)
        {
            txtCode.Text = subOrg.orgcode;
            txtName.Text = subOrg.names;
            txtOrgShortName.Text = subOrg.orgshortname;
            txtState.Text = subOrg.State;
            txtCity.Text = subOrg.city;
            txtCountryCode.Text = subOrg.countrycode;
            txtZipCode.Text = subOrg.zipcode;
            txtPhone.Text = subOrg.phone;
            txtFax.Text = subOrg.fax;
            txtEmail.Text = subOrg.email;
            txtWebsite.Text = subOrg.website;
            txtAddress.Text = subOrg.address;
            txtContactName.Text = subOrg.contactname;
            txtContactEmail.Text = subOrg.contactemail;
            txtContactPhone.Text = subOrg.contactphone;
            txtContactPhoneMobile.Text = subOrg.contactphone;
            txtNote.Text = subOrg.notes;

        }
        private void ClearEmptyControl()
        {
            txtCode.Text =
            txtName.Text =
            txtOrgShortName.Text =
            txtState.Text =
            txtCity.Text =
            txtCountryCode.Text =
            txtZipCode.Text =
            txtPhone.Text =
            txtFax.Text =
            txtEmail.Text =
            txtWebsite.Text =
            txtAddress.Text =
            txtContactName.Text =
            txtContactEmail.Text =
            txtContactPhone.Text =
            txtContactPhoneMobile.Text =
            txtNote.Text = string.Empty;
        }

    }
    #endregion
    #endregion
    #endregion
}
