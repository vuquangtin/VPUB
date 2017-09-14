using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sWorldModel.TransportData;
using CommonControls;
using System.ServiceModel;
using sWorldModel.Exceptions;
using JavaCommunication.Factory;
using sWorldModel;
using Microsoft.Practices.CompositeUI;
using JavaCommunication;
using CommonHelper.Config;
using CommonHelper.Utils;
using CommonHelper.Constants;
using System.Resources;

namespace SystemMgtComponent.WorkItems
{
    public partial class FrmAddOrEditSubOrg : CommonControls.Custom.CommonDialog
    {
        #region Properties

        private const string NotMaster = @"NOTMASTER";

        public const byte ModeAddingOrg = 1;
        public const byte ModeUpdatingOrg = 2;
        public const byte ModeAddingSubOrg = 3;
        public const byte ModeUpdatingSubOrg = 4;

        private const int SetMaxWightTxtName = 323;

        private byte OperatingMode;
        private long OrgId;
        private long SubOrgId;
        private ManagerCostApartment managerCost = null;

        private ResourceManager rm;

        private Organization OriginalOrg;
        private Organization AddOrUpdateOrg;

        private BackgroundWorker bgwLoadOrg;
        private BackgroundWorker bgwAddOrg;
        private BackgroundWorker bgwUpdateOrg;

        private SubOrganization OriginalSubOrg;
        private SubOrganization AddOrUpdateSubOrg;

        private BackgroundWorker bgwLoadSubOrg;
        private BackgroundWorker bgwAddSubOrg;
        private BackgroundWorker bgwUpdateSubOrg;

        public DialogPostAction PostAction { get; private set; }

        private ILocalStorageService storageService;
        [ServiceDependency]
        public ILocalStorageService StorageService
        {
            get { return storageService; }
            set { storageService = value; }
        }

        #endregion

        public FrmAddOrEditSubOrg(byte operationMode, long orgId = 0, long subOrgId = 0)
        {
            InitializeComponent();
            RegisterEvent();
            this.OrgId = orgId;
            this.SubOrgId = subOrgId;
            this.OperatingMode = operationMode;
        }

        private void RegisterEvent()
        {
            btnCancel.Click += OnButtonCancelClicked;
            btnConfirm.Click += OnButtonConfirmClicked;
            btnRefresh.Click += OnButtonRefreshClicked;
            Shown += OnFormShown;

            //btnAddOrEditGroup.Click += btnAddOrEditGroup_Click;
        }

        #region Event's

        private void OnFormShown(object sender, EventArgs e)
        {
            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
            this.Text = MessageValidate.GetMessage(rm, this.Name);
            switch (OperatingMode)
            {
                case ModeAddingOrg:
                    InitFormAddOrg();
                    break;
                case ModeUpdatingOrg:
                    InitFormUpdateOrg();
                    LoadOrg();
                    break;
                case ModeAddingSubOrg:
                    InitFormAddSubOrg();
                    LoadOrg();
                    break;
                case ModeUpdatingSubOrg:
                    InitFormUpdateSubOrg();
                    LoadSubOrg();
                    break;
                default:
                    throw new ArgumentException("Invalid operating mode!");
            }
            
        }

        //private void btnAddOrEditGroup_Click(object sender, EventArgs e)
        //{
        //    frmAddOrEditGroup frmGroup = new frmAddOrEditGroup(rm);
        //    frmGroup.ShowDialog();

        //    if (frmGroup.DialogResult == DialogResult.OK)
        //    {
        //        LoadGroupSubOrg();
        //    }
        //    frmGroup.Close();
        //    frmGroup.Dispose();
        //}

        #region Org

        private void OnLoadOrgWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                OriginalOrg = OrganizationFactory.Instance.GetChannel().GetOrgById(StorageService.CurrentSessionId, OrgId);
                e.Result = true;
            }
            catch (TimeoutException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm,"TimeOutExceptionMessage"));
            }
            catch (FaultException<WcfServiceFault> ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
            }
            catch (FaultException ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm,"FaultExceptionMessage")
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
            }
            catch (CommunicationException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm,"CommunicationExceptionMessage"));
            }
        }

        private void OnLoadOrgWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if (e.Result != null && OperatingMode == ModeUpdatingOrg)
            {
                ToOrgModel(OriginalOrg);
            }
            if (e.Result != null && OperatingMode == ModeAddingSubOrg)
            {
                txtCode.Text = OriginalOrg.OrgCode;
            }

        }

        private void OnLoadAddOrgWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = (int)Status.SUCCESS == OrganizationFactory.Instance.GetChannel().AddOrg(StorageService.CurrentSessionId, AddOrUpdateOrg);
            }
            catch (TimeoutException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm,"TimeOutExceptionMessage"));
            }
            catch (FaultException<WcfServiceFault> ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
            }
            catch (FaultException ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm,"FaultExceptionMessage") 
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
            }
            catch (CommunicationException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm,"CommunicationExceptionMessage"));
            }
        }

        private void OnLoadAddOrgWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if ((bool)e.Result)
            {
                PostAction = DialogPostAction.SUCCESS;
                Hide();
            }
        }

        private void OnLoadUpdateOrgWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = (int)Status.SUCCESS == OrganizationFactory.Instance.GetChannel().UpdateOrg(StorageService.CurrentSessionId, AddOrUpdateOrg);
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

        private void OnLoadUpdateOrgWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if ((bool)e.Result)
            {
                PostAction = DialogPostAction.SUCCESS;
                Hide();
            }
        }

        #endregion

        #region SubOrg

        private void OnLoadSubOrgWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {

                OriginalSubOrg = OrganizationFactory.Instance.GetChannel().GetSubOrgById(StorageService.CurrentSessionId, SubOrgId);
                managerCost = ManagerCostsFactory.Instance.GetChannel().GetManagerCostBySubOrgId(StorageService.CurrentSessionId, SubOrgId);
                e.Result = true;
            }
            catch (TimeoutException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm,"TimeOutExceptionMessage"));
            }
            catch (FaultException<WcfServiceFault> ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
            }
            catch (FaultException ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm,"FaultExceptionMessage") 
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
            }
            catch (CommunicationException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm,"CommunicationExceptionMessage"));
            }
        }

        private void OnLoadSubOrgWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if (e.Result != null)
            {
                ToSubOrgModel(OriginalSubOrg);
                //dong code phan saigonpearl
                //if (managerCost != null)
                //{
                //    tbxManagerCost.Text = managerCost.PayManager.ToString("N0");
                //    tbxWaterCost.Text = managerCost.PayWater.ToString("N0");
                //    tbxDateCost.Text = managerCost.DayPay;
                //    tbxManagerCostOld.Text = managerCost.ManagerCostOld.ToString("N0");
                //}
                //PopulateGroupDataToView();
                //btnConfirm.Enabled = btnRefresh.Enabled = true;
            }
        }

        private void OnLoadAddSubOrgWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = (int)Status.SUCCESS == OrganizationFactory.Instance.GetChannel().AddSubOrg(StorageService.CurrentSessionId, AddOrUpdateSubOrg);
            }
            catch (TimeoutException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm,"TimeOutExceptionMessage"));
            }
            catch (FaultException<WcfServiceFault> ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
            }
            catch (FaultException ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm,"FaultExceptionMessage")
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
            }
            catch (CommunicationException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm,"CommunicationExceptionMessage"));
            }
        }

        private void OnLoadAddSubOrgWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if ((bool)e.Result)
            {
                PostAction = DialogPostAction.SUCCESS;
                Hide();
            }
            else 
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm,"BaseMessAddFail"));
            }
        }

        private void OnLoadUpdateSubOrgWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = (int)Status.SUCCESS == OrganizationFactory.Instance.GetChannel().UpdateSubOrg(StorageService.CurrentSessionId, AddOrUpdateSubOrg);
            }
            catch (TimeoutException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm,"TimeOutExceptionMessage"));
            }
            catch (FaultException<WcfServiceFault> ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
            }
            catch (FaultException ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm,"FaultExceptionMessage")
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
            }
            catch (CommunicationException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm,"CommunicationExceptionMessage"));
            }
        }

        private void OnLoadUpdateSubOrgWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if ((bool)e.Result)
            {
                PostAction = DialogPostAction.SUCCESS;
                Hide();
            }
        }

        #endregion

        #region Buttons

        private void OnButtonConfirmClicked(object sender, EventArgs e)
        {
            switch (OperatingMode)
            {
                case ModeAddingOrg:
                    AddOrg();
                    break;
                case ModeUpdatingOrg:
                    UpdateOrg();
                    break;
                case ModeAddingSubOrg:
                    AddSubOrg();
                    break;
                case ModeUpdatingSubOrg:
                    UpdateSubOrg();
                    break;
                default:
                    break;
            }

        }

        private void OnButtonRefreshClicked(object sender, EventArgs e)
        {
            ClearEmptyControl();
        }

        private void OnButtonCancelClicked(object sender, EventArgs e)
        {
            this.Hide();
        }

        #endregion

        #endregion

        #region Event's support

        #region Binding Data

        private void ToOrgModel(Organization org)
        {
            txtCode.Text = org.OrgCode;
            txtName.Text = org.Name;
            txtPhone.Text = org.Phone;
            txtEmail.Text = org.Email;
            txtContactName.Text = org.ContactName;
            txtContactEmail.Text = org.ContactEmail;
            txtContactPhone.Text = org.ContactPhone;
            txtContactPhoneMobile.Text = org.ContactMobile;
            txtNote.Text = org.Notes;
        }

        private void ToSubOrgModel(SubOrganization subOrg)
        {
            txtCode.Text = subOrg.orgcode;
            txtName.Text = subOrg.names;
            txtPhone.Text = subOrg.phone;
            txtEmail.Text = subOrg.email;
            txtContactName.Text = subOrg.contactname;
            txtContactEmail.Text = subOrg.contactemail;
            txtContactPhone.Text = subOrg.contactphone;
            txtContactPhoneMobile.Text = subOrg.address;
            txtNote.Text = subOrg.notes;
            //cbxGroup.SelectedValue = subOrg.SwtGroup;
        }

        private Organization ToOrgEntity()
        {
            Organization org = new Organization();
            org = OriginalOrg != null ? OriginalOrg : org;

            org.OrgCode = txtCode.Text.Trim();
            org.Name = txtName.Text.Trim();
            org.OrgShortName =
            org.State =
            org.City =
            org.CountryCode =
            org.WebSite =
            org.Address =
            org.Fax =
            org.ZipCode = "---"; 
            org.Phone = txtPhone.Text.Trim();
            org.Email = txtEmail.Text.Trim();
            org.ContactName = txtContactName.Text.Trim();
            org.ContactEmail = txtContactEmail.Text.Trim();
            org.ContactPhone = txtContactPhone.Text.Trim();
            org.ContactMobile = txtContactPhoneMobile.Text.Trim();
            org.Notes = txtNote.Text.Trim();

            return org;
        }

        private SubOrganization ToSubOrgEntity()
        {
            SubOrganization subOrg = new SubOrganization();
            subOrg = (OriginalSubOrg != null) ? OriginalSubOrg : subOrg;

            subOrg.orgid = OrgId;
            subOrg.suborgid = SubOrgId;
            subOrg.orgcode = txtCode.Text.Trim();

            subOrg.names = txtName.Text.Trim();
            subOrg.State =
            subOrg.city =
            subOrg.countrycode =
            subOrg.website =
            subOrg.fax =
            subOrg.zipcode = "---";
            //saigonpearl
            //subOrg.transferDate = tbxTransferDate.Text.Trim();
            subOrg.phone = txtPhone.Text.Trim();
            subOrg.email = txtEmail.Text.Trim();
            subOrg.contactname = txtContactName.Text.Trim();
            subOrg.contactemail = txtContactEmail.Text.Trim();
            subOrg.contactphone = txtContactPhone.Text.Trim();
            subOrg.address = txtContactPhoneMobile.Text.Trim();
            subOrg.notes = txtNote.Text.Trim();


            if (OriginalOrg == null)
            {
                // edit sub-organization
                subOrg.orgshortname = (null == OriginalSubOrg.orgshortname || OriginalSubOrg.orgshortname == "" || OriginalSubOrg.orgshortname == String.Empty) ? OriginalSubOrg.orgcode : OriginalSubOrg.orgshortname;

            }
            else
            {
                // insert new sub-organization
                subOrg.orgshortname = (null == OriginalOrg.OrgShortName  ||  OriginalOrg.OrgShortName == "" || OriginalOrg.OrgShortName == String.Empty) ? OriginalOrg.Name : OriginalOrg.OrgShortName;
            }

            return subOrg;
        }

        #endregion

        #region SetControl

        private void ClearEmptyControl()
        {
            txtCode.Text =
            txtName.Text =
            txtPhone.Text =
            txtContactName.Text =
            txtContactEmail.Text =
            txtContactPhone.Text =
            txtContactPhoneMobile.Text =
            txtNote.Text = string.Empty;
            txtCode.Focus();
        }

        private void SetControl(bool isView)
        {
            txtCode.ReadOnly =
            txtName.ReadOnly =
            txtPhone.ReadOnly =
            txtEmail.ReadOnly =
            txtContactName.ReadOnly =
            txtContactEmail.ReadOnly =
            txtContactPhone.ReadOnly =
            txtContactPhoneMobile.ReadOnly =
            txtNote.ReadOnly = isView;
        }

        private void SetShowOrHideButton(bool isView)
        {
            btnConfirm.Enabled = btnRefresh.Enabled = isView;
        }

        #endregion

        #region ValidateData

        private bool ValidateData()
        {
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessageValidate(rm, MessageValidate.OrgId), MessageValidate.GetErrorTitle(rm));
                return false;
            }

            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessageValidate(rm, MessageValidate.OrgName), MessageValidate.GetErrorTitle(rm));
                return false;
            }

            //if (string.IsNullOrEmpty(txtPhone.Text))
            //{
            //    MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessageValidate(rm, MessageValidate.Phone), MessageValidate.GetErrorTitle(rm));
            //    return false;
            //}

            //if (string.IsNullOrEmpty(txtEmail.Text))
            //{
            //    MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessageValidate(rm, MessageValidate.Email1), MessageValidate.GetErrorTitle(rm));
            //    return false;
            //}

            if ((!string.IsNullOrEmpty(txtPhone.Text) && !StringUtils.CheckPhoneNumber(txtPhone.Text))
                || (!string.IsNullOrEmpty(txtContactPhone.Text) && !StringUtils.CheckPhoneNumber(txtContactPhone.Text))
                || (!string.IsNullOrEmpty(txtContactPhoneMobile.Text) && !StringUtils.CheckPhoneNumber(txtContactPhoneMobile.Text)))
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessageDataFail(rm, MessageValidate.PhoneFirst), MessageValidate.GetErrorTitle(rm));
                return false;
            }

            if ((!string.IsNullOrEmpty(txtEmail.Text) && !StringUtils.CheckEmail(txtEmail.Text)))
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessageDataFail(rm, MessageValidate.Email), MessageValidate.GetErrorTitle(rm));
                return false;
            }

            if ((!string.IsNullOrEmpty(txtContactEmail.Text) && !StringUtils.CheckEmail(txtContactEmail.Text)))
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessageDataFail(rm, MessageValidate.ContactEmail), MessageValidate.GetErrorTitle(rm));
                return false;
            }

            if (!string.IsNullOrEmpty(txtNote.Text) && txtNote.Text.Length > 200)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessCharOverLoad(rm, MessageValidate.Description, 200), MessageValidate.GetErrorTitle(rm));
                return false;
            }

            return true;
        }

        #endregion

        #region Org

        private void InitFormAddOrg()
        {
            this.Text = lbTitleAddOrEditOrg.Text = MessageValidate.GetMessage(rm,"addnewsuborg");
            lblNoteAddOrEditOrg.Text = MessageValidate.GetMessage(rm,"addnewsuborgtosystem");
            lbInfo_FrmAddOrEditOrg.Text = MessageValidate.GetMessage(rm,"suborginfo");
            SetControl(false);
            SetShowOrHideButton(true);
            ClearEmptyControl();
            plGroup.Visible = false;

            bgwAddOrg = new BackgroundWorker();
            bgwAddOrg.WorkerSupportsCancellation = true;
            bgwAddOrg.DoWork += OnLoadAddOrgWorkerDoWork;
            bgwAddOrg.RunWorkerCompleted += OnLoadAddOrgWorkerRunWorkerCompleted;
        }

        private void InitFormUpdateOrg()
        {
            this.Text = lbTitleAddOrEditOrg.Text = MessageValidate.GetMessage(rm, "updatenewsuborg");
            lblNoteAddOrEditOrg.Text =  MessageValidate.GetMessage(rm,"updatenewsuborgtosystem");
            lbInfo_FrmAddOrEditOrg.Text = MessageValidate.GetMessage(rm, "suborginfo");
            SetControl(false);
            SetShowOrHideButton(true);
            plGroup.Visible = false;

            bgwLoadOrg = new BackgroundWorker();
            bgwLoadOrg.WorkerSupportsCancellation = true;
            bgwLoadOrg.DoWork += OnLoadOrgWorkerDoWork;
            bgwLoadOrg.RunWorkerCompleted += OnLoadOrgWorkerRunWorkerCompleted;

            bgwUpdateOrg = new BackgroundWorker();
            bgwUpdateOrg.WorkerSupportsCancellation = true;
            bgwUpdateOrg.DoWork += OnLoadUpdateOrgWorkerDoWork;
            bgwUpdateOrg.RunWorkerCompleted += OnLoadUpdateOrgWorkerRunWorkerCompleted;
        }

        private void LoadOrg()
        {
            if (!bgwLoadOrg.IsBusy && OrgId > 0)
            {
                bgwLoadOrg.RunWorkerAsync();
            }
        }

        private void AddOrg()
        {
            if (ValidateData() && MessageBoxManager.ShowQuestionMessageBox(this, MessageValidate.GetMessage(rm, "addsub?")) == System.Windows.Forms.DialogResult.Yes)
            {
                if (!bgwAddOrg.IsBusy)
                {
                    AddOrUpdateOrg = ToOrgEntity();
                    bgwAddOrg.RunWorkerAsync();
                }
            }
        }

        private void UpdateOrg()
        {
            if (ValidateData() && MessageBoxManager.ShowQuestionMessageBox(this, MessageValidate.GetMessage(rm, "updatesub?")) == System.Windows.Forms.DialogResult.Yes)
            {
                if (!bgwUpdateOrg.IsBusy)
                {
                    AddOrUpdateOrg = ToOrgEntity();
                    bgwUpdateOrg.RunWorkerAsync();
                }
            }
        }

        #endregion

        #region SubOrg

        private void InitFormAddSubOrg()
        {
            this.Text = lbTitleAddOrEditOrg.Text = MessageValidate.GetMessage(rm, "addnewsuborg");
            lblNoteAddOrEditOrg.Text = MessageValidate.GetMessage(rm, "addnewsuborgtosytem");
            lbInfo_FrmAddOrEditOrg.Text = MessageValidate.GetMessage(rm, "suborginfo");
            //txtName.Width = SetMaxWightTxtName;
            SetControl(false);
            SetShowOrHideButton(true);
            //txtCode.ReadOnly = true;
            ClearEmptyControl();

            bgwLoadOrg = new BackgroundWorker();
            bgwLoadOrg.WorkerSupportsCancellation = true;
            bgwLoadOrg.DoWork += OnLoadOrgWorkerDoWork;
            bgwLoadOrg.RunWorkerCompleted += OnLoadOrgWorkerRunWorkerCompleted;

            bgwAddSubOrg = new BackgroundWorker();
            bgwAddSubOrg.WorkerSupportsCancellation = true;
            bgwAddSubOrg.DoWork += OnLoadAddSubOrgWorkerDoWork;
            bgwAddSubOrg.RunWorkerCompleted += OnLoadAddSubOrgWorkerRunWorkerCompleted;
        }

        private void InitFormUpdateSubOrg()
        {
            this.Text = lbTitleAddOrEditOrg.Text = MessageValidate.GetMessage(rm, "updatesuborg");
            lblNoteAddOrEditOrg.Text = MessageValidate.GetMessage(rm, "updatesuborgtosystem");
            lbInfo_FrmAddOrEditOrg.Text = MessageValidate.GetMessage(rm, "subinfo");
            //txtName.Width = SetMaxWightTxtName;
            SetControl(false);
            SetShowOrHideButton(true);
            //txtCode.ReadOnly = true;

            bgwLoadSubOrg = new BackgroundWorker();
            bgwLoadSubOrg.WorkerSupportsCancellation = true;
            bgwLoadSubOrg.DoWork += OnLoadSubOrgWorkerDoWork;
            bgwLoadSubOrg.RunWorkerCompleted += OnLoadSubOrgWorkerRunWorkerCompleted;

            bgwUpdateSubOrg = new BackgroundWorker();
            bgwUpdateSubOrg.WorkerSupportsCancellation = true;
            bgwUpdateSubOrg.DoWork += OnLoadUpdateSubOrgWorkerDoWork;
            bgwUpdateSubOrg.RunWorkerCompleted += OnLoadUpdateSubOrgWorkerRunWorkerCompleted;
        }

        private void LoadSubOrg()
        {
            if (!bgwLoadSubOrg.IsBusy && OrgId > 0)
            {
                bgwLoadSubOrg.RunWorkerAsync();
            }
        }

        private void AddSubOrg()
        {
            if (ValidateData() && MessageBoxManager.ShowQuestionMessageBox(this, MessageValidate.GetQuestionAdd(rm,MessageValidate.SubOrganization)) == System.Windows.Forms.DialogResult.Yes)
            {
                if (!bgwAddSubOrg.IsBusy)
                {
                    AddOrUpdateSubOrg = ToSubOrgEntity();
                    bgwAddSubOrg.RunWorkerAsync();
                }
            }
        }

        private void UpdateSubOrg()
        {
            if (ValidateData() && MessageBoxManager.ShowQuestionMessageBox(this, MessageValidate.GetQuestionUpdate(rm,MessageValidate.SubOrganization)) == System.Windows.Forms.DialogResult.Yes)
            {
                if (!bgwUpdateSubOrg.IsBusy)
                {
                    AddOrUpdateSubOrg = ToSubOrgEntity();
                    bgwUpdateSubOrg.RunWorkerAsync();
                }
            }
        }

        #endregion

        //private void LoadGroupSubOrg()
        //{
        //    DataTable groupDt = new DataTable();
        //    groupDt.Columns.Add("Code");
        //    groupDt.Columns.Add("Name");
        //    //String[] result = GroupSettings.Instance.Group.Split(',');

        //    foreach (String group in result)
        //    {
        //        string[] item = group.Split('-');
        //        if (item.Length > 0)
        //        {
        //            DataRow row = groupDt.NewRow();
        //            row.BeginEdit();

        //            row["Code"] = item.FirstOrDefault();
        //            row["Name"] = item.LastOrDefault();

        //            row.EndEdit();
        //            groupDt.Rows.Add(row);
        //        }
        //    }
        //    cbxGroup.DataSource = groupDt;
        //    cbxGroup.ValueMember = "Code";
        //    cbxGroup.DisplayMember = "Name";
        //    cbxGroup.SelectedIndex = 0;
        //}

        private void LoadCardType(DataTable groupList)
        {

        }

        #endregion
    }
}
