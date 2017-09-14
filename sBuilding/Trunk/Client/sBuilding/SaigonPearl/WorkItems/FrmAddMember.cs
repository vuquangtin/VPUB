using CommonControls;
using CommonControls.Custom;
using CommonHelper.Config;
using CommonHelper.Constants;
using CommonHelper.Utils;
using JavaCommunication;
using Microsoft.Practices.CompositeUI;
using sBuildingCommunication.Factory;
using sBuildingCommunication.Model;
using sWorldModel;
using sWorldModel.Exceptions;
using sWorldModel.Filters;
using sWorldModel.TransportData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;

namespace sAccessComponent.WorkItems
{
    /// <summary>
    /// Add member in group
    /// </summary>
    public partial class FrmAddMember : CommonControls.Custom.CommonDialog
    {
        #region Properties
        private int currentPageIndex = 1;

        private long subOrgId = 0;
        //list suborgid for get listmember
        List<long> listSubOrgId;
        private long groupId;
        private List<RoleChipPersonalizationCustomDTO> MemberList;
        private DataTable dtbMemberList;
        List<SubOrgCustomerDTO> lstSubOrgCustomerDTO;
        private ResourceManager rm;

        private BackgroundWorker loadMemberWorker;
        private BackgroundWorker bgwLoadSubOrg;

        public DialogPostAction PostAction { get; private set; }

        private ILocalStorageService storageService;
        [ServiceDependency]
        public ILocalStorageService StorageService
        {
            get { return storageService; }
            set { storageService = value; }
        }

        #endregion
        #region Contrustor
        public FrmAddMember(long groupId)
        {
            InitializeComponent();
            RegisterEvent();
            InitDataGridViewMember();
            this.groupId = groupId;
        }
        #endregion
        #region Event
        private void RegisterEvent()
        {
            //Load Member
            loadMemberWorker = new BackgroundWorker();
            loadMemberWorker.WorkerSupportsCancellation = true;
            loadMemberWorker.DoWork += OnLoadMemberWorkerDoWork;
            loadMemberWorker.RunWorkerCompleted += OnLoadMemberWorkerCompleted;

            pagerPanel1.LinkLabelClicked += pagerPanel_LinkLabelClicked;

            btnConfirm.Click += OnButtonAddClicked;
            btnCancel.Click += OnButtonCancelClicked;

            Shown += OnFormShown;
        }

        private void OnFormShown(object sender, EventArgs e)
        {
            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
            // Set Language
            SetLanguage();
            //Load suborg for combobox
            GetSubOrgList();
            pagerPanel1.StorageService = storageService;
            pagerPanel1.LoadLanguage();
            listSubOrgId = GetListSubOrgId();
            //20170603 #Bug 751 add this function for load data when form load - Ten Nguyen Start
            LoadMemberList();
            //20170603 #Bug 751 add this function for load data when form load - Ten Nguyen End
        }
        #endregion
        #region Set Language
        private void SetLanguage()
        {
            this.colSerial.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colSerial.Name);
            this.colName.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colName.Name);
            this.colPhone.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colPhone.Name);
            this.colCmnd.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colCmnd.Name);
            this.colEmail.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colEmail.Name);
        }
        #endregion

        #region InitDataGridViewMember
        private void InitDataGridViewMember()
        {
            dtbMemberList = new DataTable();
            dtbMemberList.Columns.Add(colId.DataPropertyName);
            dtbMemberList.Columns.Add(colStt.DataPropertyName);
            dtbMemberList.Columns.Add(colSerial.DataPropertyName);
            dtbMemberList.Columns.Add(colName.DataPropertyName);
            dtbMemberList.Columns.Add(colPhone.DataPropertyName);
            dtbMemberList.Columns.Add(colCmnd.DataPropertyName);
            dtbMemberList.Columns.Add(colEmail.DataPropertyName);
            dgvMemberList.DataSource = dtbMemberList;
        }
        #endregion
        /// <summary>
        /// Add member in groupMember
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButtonAddClicked(object sender, EventArgs e)
        {
            List<RoleChipPersionalDTO> lstIdMember = GetSelectedMember();
            bool resultAdd = false;
            if (lstIdMember.Count > 0)
            {
                if (MessageBoxManager.ShowQuestionMessageBox(this, MessageValidate.GetMessage(rm, "AreYouAddMeber")) == DialogResult.Yes)
                {
                    try
                    {
                        //Insert list member by groupmember
                        resultAdd = (int)Status.SUCCESS == AccessFactory.Instance.GetChannel().InsertListChipPersionNalizationByRoleId(StorageService.CurrentSessionId, groupId, lstIdMember);
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

                if (resultAdd)
                {
                    //if add success
                    PostAction = DialogPostAction.SUCCESS;
                    Hide();
                }
                else
                {
                    //if add fail
                    MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "addmemberfailed"));
                }
            }
        }
        /// <summary>
        /// Get list member user choose to add
        /// </summary>
        /// <returns></returns>
        private List<RoleChipPersionalDTO> GetSelectedMember()
        {
            //List member user select
            List<RoleChipPersionalDTO> selectedMember = new List<RoleChipPersionalDTO>();
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
                    RoleChipPersionalDTO roleChipPersionalDTO = new RoleChipPersionalDTO();
                    long memberId = Convert.ToInt32(selectedRows[i].Cells[colId.Name].Value.ToString());
                    string serialNumber = selectedRows[i].Cells[colSerial.Name].Value.ToString();
                    roleChipPersionalDTO.memberId = memberId;
                    roleChipPersionalDTO.serialNumber = serialNumber;

                    selectedMember.Add(roleChipPersionalDTO);
                }
            }
            return selectedMember;
        }
        #region Load Member
        private void LoadMemberList()
        {
            if (!loadMemberWorker.IsBusy)
            {
                dtbMemberList.Rows.Clear();
                loadMemberWorker.RunWorkerAsync();
            }
        }
        private void OnLoadMemberWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            int totalRecords = 0;
            int take = LocalSettings.Instance.RecordsPerPage;
            int skip = 0;
            currentPageIndex = 1;
            PersoChipFilter filter = new PersoChipFilter();
            List<RoleChipPersonalizationCustomDTO> result = null;

            try
            {
                //gui kem theo groupid de loai bo cac phan tu trung nhau
                e.Result = MemberList = AccessFactory.Instance.GetChannel().GetListMemberByListSuborgId(storageService.CurrentSessionId, listSubOrgId, groupId);
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
                    pagerPanel1.ShowNumberOfRecords(totalRecords, result != null ? result.Count : 0, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
                    pagerPanel1.UpdatePagingLinks(totalRecords, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
                }
            }
        }


        private void OnLoadMemberWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if (e.Result == null)
            {
                return;
            }
            List<RoleChipPersonalizationCustomDTO> result = (List<RoleChipPersonalizationCustomDTO>)e.Result;
            //load du lieu show cho nguoi dung xem
            LoadMemberDataGridView(result);
        }
        /// <summary>
        /// Show for user view
        /// </summary>
        /// <param name="result"></param>
        private void LoadMemberDataGridView(List<RoleChipPersonalizationCustomDTO> result)
        {
            int count = 1;
            foreach (RoleChipPersonalizationCustomDTO member in result)
            {
                DataRow row = dtbMemberList.NewRow();
                row.BeginEdit();

                row[colId.DataPropertyName] = member.member.Id;
                row[colStt.DataPropertyName] = count;
                row[colSerial.DataPropertyName] = member.serialNumber;
                row[colName.DataPropertyName] = member.member.LastName + " " + member.member.FirstName;
                row[colPhone.DataPropertyName] = member.member.ContactPhone;
                row[colCmnd.DataPropertyName] = member.member.IdentityCard;
                row[colEmail.DataPropertyName] = member.member.Email;

                row.EndEdit();

                dtbMemberList.Rows.Add(row);
                count++;

            }
        }


        #endregion
        #region Buttons

        private void OnButtonCancelClicked(object sender, EventArgs e)
        {
            this.Hide();
        }

        #endregion

        #region Event's support
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
            dtbMemberList.Rows.Clear();
            int take = LocalSettings.Instance.RecordsPerPage;
            int skip = (currentPageIndex - 1) * take;

            List<RoleChipPersonalizationCustomDTO> result = MemberList.Skip(skip).Take(take).ToList();
            LoadMemberDataGridView(result);

            pagerPanel1.ShowNumberOfRecords(MemberList.Count, result != null ? result.Count : 0, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
            pagerPanel1.UpdatePagingLinks(MemberList.Count, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
        }

        #endregion



        #region GetSubOrgList
        /// <summary>
        /// Get all list suborg
        /// </summary>
        private void GetSubOrgList()
        {
            SubOrgFilterDto filter = new SubOrgFilterDto();
            lstSubOrgCustomerDTO = new List<SubOrgCustomerDTO>();
            try
            {
                //get all suborg of all org
                lstSubOrgCustomerDTO = OrganizationFactory.Instance.GetChannel().GetSubOrgList(StorageService.CurrentSessionId, -1/*get all*/, filter);
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
                //show in combobox
                foreach (SubOrgCustomerDTO item in lstSubOrgCustomerDTO)
                {
                    cbxSuborg.Items.Add(item);
                    cbxSuborg.DisplayMember = "Name";
                    cbxSuborg.SetItemChecked(0, true);
                }
            }
        }
        #endregion

        /// <summary>
        /// Same event onchange
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxSuborg_DropDownClosed(object sender, EventArgs e)
        {
            listSubOrgId = GetListSubOrgId();
            LoadMemberList();
        }
        /// <summary>
        /// Get checked items
        /// </summary>
        /// <returns></returns>
        ///   //20170603 #Bug 751 add this function for load data when form load - Ten Nguyen Start
        private List<long> GetListSubOrgId()
        {
            List<long>  listSubOrgId = new List<long>();
            foreach (SubOrgCustomerDTO item in cbxSuborg.CheckedItems)
            {
                long id = item.SubOrgId;
                listSubOrgId.Add(id);
            }
            return listSubOrgId;
        }
        //20170603 #Bug 751 add this function for load data when form load - Ten Nguyen End
    }
}