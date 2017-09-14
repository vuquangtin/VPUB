using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CommonControls.Custom;
using Microsoft.Practices.CompositeUI;
using ReaderLibrary;
using CommonControls;
using CryptoAlgorithm;
using System.ServiceModel;
using CommonHelper.Utils;
using System.Data;
using System.Drawing;
//using WcfServiceCommon;
using sWorldModel.Exceptions;
using sWorldModel;
using sWorldModel.Parser;
using sWorldModel.Model;
using sWorldModel.MethodData;
using JavaCommunication;
using JavaCommunication.Factory;
using Microsoft.Practices.CompositeUI.EventBroker;
using MemberMgtComponent.Constants;
using Microsoft.Practices.CompositeUI.Commands;
using CommonHelper.Constants;
using System.ComponentModel;
using sWorldModel.Filters;
using CommonHelper.Config;
using sWorldModel.TransportData;


namespace MemberMgtComponent.WorkItems
{
    public partial class UsrListCardMagneticMgt : UserControl
    {

        #region Properties

        private int currentPageIndex;
        private DataTable dtbCardMagneticList;
        private BackgroundWorker bgwLoadCards;
        private MasterInfoDTO masterInfo;
        private List<PartnerInfoDTO> partnerInfo;
        private PartnerInfoDTO partnerInfoSelect;
        private CardTypeDTO cardTypeInfoSelect;

        private CardMagneticWorkItem workItem;
        [ServiceDependency]
        public CardMagneticWorkItem WorkItem
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

        #region Initialization

        public UsrListCardMagneticMgt()
        {
            InitializeComponent();

            dtbCardMagneticList = new DataTable();
            dtbCardMagneticList.Columns.Add(colMagneticId.DataPropertyName);
            dtbCardMagneticList.Columns.Add(colOrgMasterId.DataPropertyName);
            dtbCardMagneticList.Columns.Add(colOrgPartnerId.DataPropertyName);
            dtbCardMagneticList.Columns.Add(colIssuerCode.DataPropertyName);
            dtbCardMagneticList.Columns.Add(colPartnerCode.DataPropertyName);
            dtbCardMagneticList.Columns.Add(colCardNumber.DataPropertyName);
            dtbCardMagneticList.Columns.Add(colStartDate.DataPropertyName);
            dtbCardMagneticList.Columns.Add(colExpirationDate.DataPropertyName);
            dtbCardMagneticList.Columns.Add(colSLogicalStatus.DataPropertyName);
            dgvCardMagneticList.DataSource = dtbCardMagneticList;

            bgwLoadCards = new BackgroundWorker();
            bgwLoadCards.WorkerSupportsCancellation = true;
            bgwLoadCards.DoWork += bgwLoadCards_DoWork;
            bgwLoadCards.RunWorkerCompleted += bgwLoadCards_Completed;

            this.Load += OnFormLoad;
            this.cmbCardTypes.SelectedIndexChanged += cmbCardTypes_SelectedIndexChanged;
            this.cbxFilterByCardType.CheckedChanged += cbxFilterByCardType_CheckedChanged;
            this.cbxFilterLogicalStatus.CheckedChanged += cbxFilterLogicalStatus_CheckedChanged;

            this.Enter += (s, e) =>
            {
                if (ListCardMagneticMainShown != null)
                {
                    ListCardMagneticMainShown(this, new CabEventArgs(new object[] { CardMagneticCommandNames.ShowCardListMagneticMgt }));
                }
            };
            this.btnReloadCards.Click += btnReloadCards_Click;
        }
        #endregion

        #region CAB events

        [EventPublication(CardMagneticEventTopicNames.ListCardMagneticPersoMainShown)]
        public event EventHandler ListCardMagneticMainShown;

        [CommandHandler(CardMagneticCommandNames.ShowCardListMagneticMgt)]
        public void ShowCardMgtMainHandler(object s, EventArgs e)
        {
            UsrListCardMagneticMgt uc = workItem.Items.Get<UsrListCardMagneticMgt>(ComponentNames.ListCardMagneticMgtComponent);
            if (uc == null)
            {
                uc = workItem.Items.AddNew<UsrListCardMagneticMgt>(ComponentNames.ListCardMagneticMgtComponent);
            }
            else if (uc.IsDisposed)
            {
                workItem.Items.Remove(uc);
                uc = workItem.Items.AddNew<UsrListCardMagneticMgt>(ComponentNames.ListCardMagneticMgtComponent);
            }

            workItem.Workspaces[WorkspaceName.MainWorkspace].Show(uc);
            uc.Parent.Text = "Danh sách thẻ từ";
        }

        #endregion

        #region Functions for card

        private void LoadCards()
        {
            if (!bgwLoadCards.IsBusy)
            {
                dtbCardMagneticList.Rows.Clear();

                CardMagneticFilterDto filter = new CardMagneticFilterDto();

                if (cbxFilterByCardType.Checked && cmbCardTypes.SelectedIndex > -1)
                {
                    filter.FilterByCardType = true;
                    filter.Prefix = Convert.ToInt32(cmbCardTypes.SelectedValue);
                }

                if (cbxFilterLogicalStatus.Checked)
                {
                    filter.FilterByCardLogicalStatus = true;
                    filter.CardLogicalStatus = Convert.ToInt32(rbtnStatusActive.Checked);
                }

                pagerPanel1.ShowMessage("Đang tải dữ liệu, xin hãy chờ...");
                bgwLoadCards.RunWorkerAsync(filter);
            }
        }

        private void bgwLoadCards_DoWork(object s, DoWorkEventArgs e)
        {
            if (e.Argument == null || !(e.Argument is CardMagneticFilterDto))
            {
                return;
            }
            CardMagneticFilterDto filter = e.Argument as CardMagneticFilterDto;
            List<CMSCardmagneticDto> result = null;
            int totalRecords = 0;

            try
            {
                result = MagneticPersonalizationFactory.Instance.GetChannel().GetCardMagneticList(StorageService.CurrentSessionId, filter);

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
                pagerPanel1.ShowNumberOfRecords(totalRecords, result != null ? result.Count : 0, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
                pagerPanel1.UpdatePagingLinks(totalRecords, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
                e.Result = result;
            }
        }

        private void bgwLoadCards_Completed(object s, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if (e.Result == null)
            {
                return;
            }

            List<CMSCardmagneticDto> result = e.Result as List<CMSCardmagneticDto>;

            foreach (CMSCardmagneticDto cardMagnetic in result)
            {
                DataRow row = dtbCardMagneticList.NewRow();
                row.BeginEdit();
                row[colMagneticId.DataPropertyName] = cardMagnetic.MagneticId;
                row[colOrgMasterId.DataPropertyName] = cardMagnetic.OrgMasterId;
                row[colOrgPartnerId.DataPropertyName] = cardMagnetic.OrgPartnerId;
                row[colCardNumber.DataPropertyName] = cardMagnetic.CardNumber;
                row.EndEdit();
                dtbCardMagneticList.Rows.Add(row);
            }
            dgvCardMagneticList.DataSource = dtbCardMagneticList;
        }

        #endregion

        #region Form Event's

        private void OnFormLoad(object sender, EventArgs e)
        {
            //load infor master
            LoadMasterInfo();

            //load infor partner
            LoadPartnerInfo();
        }


        private void cmbMasterInfo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbPartnerInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            partnerInfoSelect = cmbPartnerInfo.SelectedItem as PartnerInfoDTO;
            //if (partnerInfoSelect.cardtypes != null)
            LoadCardTypeOfPartner(partnerInfoSelect);
        }

        private void cmbCardTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCardTypes.SelectedIndex >= 0)
                cardTypeInfoSelect = cmbCardTypes.SelectedItem as CardTypeDTO;
        }

        private void LoadMasterInfo()
        {
            try
            {
                this.masterInfo = OrganizationFactory.Instance.GetChannel().GetMasterInfo(StorageService.CurrentSessionId, SystemSettings.Instance.Master);
                cmbMasterInfo.DataSource = new List<MasterInfoDTO>() { this.masterInfo };
                cmbMasterInfo.ValueMember = "MasterId";
                cmbMasterInfo.DisplayMember = "Name";
                cmbMasterInfo.SelectedIndex = 0;
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

        private void LoadPartnerInfo()
        {
            try
            {
                if (masterInfo == null) return;

                this.partnerInfo = OrganizationFactory.Instance.GetChannel().GetPartnerInfo(StorageService.CurrentSessionId, masterInfo.MasterId, SystemSettings.Instance.Partner);
                cmbPartnerInfo.DataSource = this.partnerInfo;
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

        private void LoadCardTypeOfPartner(PartnerInfoDTO partner)
        {
            cmbCardTypes.DataSource = partner.cardtypes;
            cmbCardTypes.ValueMember = "prefix";
            cmbCardTypes.DisplayMember = "cardTypeName";
            cmbCardTypes.SelectedIndex = 0;
        }

        #endregion

        #region Controls events

        private void btnReloadCards_Click(object s, EventArgs e)
        {
            LoadCards();
        }

        private void cbxFilterByCardType_CheckedChanged(object s, EventArgs e)
        {
            cmbCardTypes.Enabled = cbxFilterByCardType.Checked;
        }

        private void cbxFilterLogicalStatus_CheckedChanged(object s, EventArgs e)
        {
            rbtnStatusActive.Enabled = rbtnStatusDeActive.Enabled = cbxFilterLogicalStatus.Checked;
        }


        #endregion


        private void btnShowHide_Clicked(object sender, EventArgs e)
        {

        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {

        }

        private void btnRefreshCardList_Clicked(object sender, EventArgs e)
        {

        }


    }
}
