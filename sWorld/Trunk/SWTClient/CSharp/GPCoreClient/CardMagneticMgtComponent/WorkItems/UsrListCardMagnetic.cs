using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using CommonControls.Custom;
using CommonHelper.Constants;
using Microsoft.Practices.CompositeUI;
using System.ServiceModel;
using CommonControls;
using CommonHelper.Config;
using Microsoft.Practices.CompositeUI.Commands;
using Microsoft.Practices.CompositeUI.EventBroker;
using System.Drawing;
using System.Linq;
using sWorldModel.Model;
using sWorldModel;
using sWorldModel.Exceptions;
using sWorldModel.Filters;
using JavaCommunication;
using JavaCommunication.Factory;
using sWorldModel.TransportData;
using CommonHelper.Utils;
using System.Collections.Generic;
using CardMagneticMgtComponent.Constants;
using System;

namespace CardMagneticMgtComponent.WorkItems
{
    public partial class UsrListCardMagnetic : CommonUserControl
    {
        #region Properties

        // Height of filter box when it is hidden
        private int hiddenFilterBoxHeight = 1;
        // The original height of filter box (at startup)
        private int startupFilterBoxHeight;

        private int currentPageIndex = 1;
        private Font startupNodeFont;
        private BackgroundWorker bgwLoadCards;
        private BackgroundWorker loadMemberWorker;
        //private BackgroundWorker loadSubOrgWorker;
        private DataTable dtbListMember;
        //List<CardChipDto> CardChipList;
        private List<CardmagneticDTO> MagneticList;
        private MasterInfoDTO masterInfo;
        private MasterInfoDTO partnerInfo;
        private PartnerInfoDTO partnerInfoSelected;
        private long partnerId, masterId;
        private CardMagneticFilterDto filter;
        private List<long> MagneticIds;

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

        # endregion

        #region CAB events

        [EventPublication(CardMagneticEventTopicNames.ListCardMagneticMainShown)]
        public event EventHandler ListCardMagneticMainShown;

        [CommandHandler(CardMagneticCommandNames.ShowCardListMagnetic)]
        public void ShowCardMgtMainHandler(object s, EventArgs e)
        {
            UsrListCardMagnetic uc = workItem.Items.Get<UsrListCardMagnetic>(ComponentNames.ListCardMagneticMgtComponent);
            if (uc == null)
            {
                uc = workItem.Items.AddNew<UsrListCardMagnetic>(ComponentNames.ListCardMagneticMgtComponent);
            }
            else if (uc.IsDisposed)
            {
                workItem.Items.Remove(uc);
                uc = workItem.Items.AddNew<UsrListCardMagnetic>(ComponentNames.ListCardMagneticMgtComponent);
            }

            workItem.Workspaces[WorkspaceName.MainWorkspace].Show(uc);
            uc.Parent.Text = MenuNames.MenuCardManager;
        }

        [CommandHandler(CardMagneticCommandNames.MarkBroken)]
        private void btnMarkBroken_Click(object sender, EventArgs e)
        {
            uploadStatus(FrmConfirmChangeStatus.Broken);
            LoadCards();
        }

        [CommandHandler(CardMagneticCommandNames.MarkLost)]
        private void btnMarkLost_Click(object sender, EventArgs e)
        {
            uploadStatus(FrmConfirmChangeStatus.Lost);
            LoadCards();
        }

         [CommandHandler(CardMagneticCommandNames.Printed)]
        private void btnMarkPrinted_Click(object sender, EventArgs e)
        {
            uploadStatus(FrmConfirmChangeStatus.Printed);
            LoadCards();
        }

        #endregion

        #region Contructors
        public UsrListCardMagnetic()
        {
            InitializeComponent();
            dtbListMember = new DataTable();
            dtbListMember.Columns.Add(colMagneticId.DataPropertyName);
            dtbListMember.Columns.Add(colCompany.DataPropertyName);
            dtbListMember.Columns.Add(colPhoneNumber.DataPropertyName);
            dtbListMember.Columns.Add(ColActiveCode.DataPropertyName);
            dtbListMember.Columns.Add(colFullName.DataPropertyName);
            dtbListMember.Columns.Add(colOrgName.DataPropertyName);
            dtbListMember.Columns.Add(colSubOrgName.DataPropertyName);
            dtbListMember.Columns.Add(colExpireDate.DataPropertyName);
            dtbListMember.Columns.Add(colStartDate.DataPropertyName);
            dtbListMember.Columns.Add(colSerialCard.DataPropertyName);
            dtbListMember.Columns.Add(colTrackData.DataPropertyName);
            dtbListMember.Columns.Add(colPrintedStatus.DataPropertyName);
            dtbListMember.Columns.Add(colPhysicalStatus.DataPropertyName);
            dtbListMember.Columns.Add(colNotes.DataPropertyName);
            dtbListMember.Columns.Add(colTypeCrypto.DataPropertyName);
            dtbListMember.Columns.Add(colCardType.DataPropertyName);
            dtbListMember.Columns.Add(colPinCode.DataPropertyName);
            dgvCard.DataSource = dtbListMember;

            pagerPanel1.LinkLabelClicked += pagerPanel_LinkLabelClicked;
            this.btnShowHide.Click += btnShowHide_Clicked;
            //cmbPartnerInfo.SelectedIndexChanged += cmbPartnerInfo_SelectedIndexChanged;
            loadMemberWorker = new BackgroundWorker();
            loadMemberWorker.WorkerSupportsCancellation = true;
            loadMemberWorker.DoWork += bgwMember_DoWork;
            loadMemberWorker.RunWorkerCompleted += bgwMember_WorkerCompleted;

            this.dgvCard.MouseDown += dgvCards_MouseDown;

            this.Load += OnFormLoad;

            this.Enter += (s, e) =>
            {
                if (ListCardMagneticMainShown != null)
                {
                    ListCardMagneticMainShown(this, new CabEventArgs(new object[] { CardMagneticCommandNames.ShowCardListMagnetic }));
                }
            };
        }

        #endregion

        #region Form events

        private void OnFormLoad(object s, EventArgs e)
        {
            LoadPartnerInfo();
            HideOrShowOrg();
            // LoadCardTypeOfPartner(partnerInfoList.cardTypes);

            startupFilterBoxHeight = this.pnlFilterBox.Height;

            // Populate card Physical status to combobox
            List<CardMagneticPhysicalStatus> cardphysicalstatus = CardMagneticStatusExtMethod.GetCardPhysicalStatusList();

            DataTable dtbcardphysicalstatus = new DataTable();
            dtbcardphysicalstatus.Columns.Add("Id");
            dtbcardphysicalstatus.Columns.Add("Name");
            foreach (CardMagneticPhysicalStatus ct in cardphysicalstatus)
            {
                DataRow row = dtbcardphysicalstatus.NewRow();
                row.BeginEdit();
                row["Id"] = (int)ct;
                row["Name"] = ct.GetName();
                row.EndEdit();
                dtbcardphysicalstatus.Rows.Add(row);
            }

            cmbCardPhysicalStatus.DataSource = dtbcardphysicalstatus;
            cmbCardPhysicalStatus.ValueMember = "Id";
            cmbCardPhysicalStatus.DisplayMember = "Name";
        }

        private void cmbPartnerInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //partnerId = (long)cmbPartnerInfo.SelectedValue;
            //LoadCards();
            //partnerInfoSelected = cmbPartnerInfo.SelectedItem as PartnerInfoDTO;
            //if (partnerInfoSelected != null)
            //    LoadCardTypeOfPartner(partnerInfoSelected.cardtypes);
        }

        private void cbxFilterByCardType_CheckedChanged(object sender, EventArgs e)
        {
            cmbCardTypes.Enabled = cbxFilterByCardType.Checked;
        }

        private void cbxFilterByCardPhysicalStatus_CheckedChanged(object sender, EventArgs e)
        {
            cmbCardPhysicalStatus.Enabled = cbxFilterByCardPhysicalStatus.Checked;
        }

        private void cbxFilterByPrintedStatus_CheckedChanged(object sender, EventArgs e)
        {
            rbtnStatusNoPrinted.Enabled = rbtnStatusPrinted.Enabled = cbxFilterByPrintedStatus.Checked;
        }

        # endregion

        #region PartnerInfo

        private void LoadPartnerInfo()
        {
            try
            {
                this.masterInfo = OrganizationFactory.Instance.GetChannel().GetMasterInfo(StorageService.CurrentSessionId, SystemSettings.Instance.Master);
                masterId = masterInfo.MasterId;
                this.partnerInfo = OrganizationFactory.Instance.GetChannel().GetMasterInfo(StorageService.CurrentSessionId, SystemSettings.Instance.Partner);
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
        }

        private void HideOrShowOrg()
        {
            //if (partnerInfo.Count <= 1)
            //    plHideShowOrg.Height = 0;
            //else
            //    plHideShowOrg.Height = 55;
        }

        #endregion

        #region Control

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
            dtbListMember.Rows.Clear();
            int take = LocalSettings.Instance.RecordsPerPage;
            int skip = (currentPageIndex - 1) * take;

            List<CardmagneticDTO> result = MagneticList.Skip(skip).Take(take).ToList();
            LoadPersoDataGridView(result);

            pagerPanel1.ShowNumberOfRecords(MagneticList.Count, result != null ? result.Count : 0, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
            pagerPanel1.UpdatePagingLinks(MagneticList.Count, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadCards();

        }

        [CommandHandler(CardMagneticCommandNames.Printed)]
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            
            string filePath = ControlExtMethods.ShowSaveFileDialog("Chọn tập tin chứa dữ liệu cần xuất", "MS Excel (*.xls)|*.xls");
            if (filePath != null)
            {
                try
                {
                    dgvCard.ExportToExcel(filePath);
                }
                catch (Exception ex)
                {
                    MessageBoxManager.ShowErrorMessageBox(this, ex.Message);
                    return;
                }
                MessageBoxManager.ShowInfoMessageBox(this, "Đã xuất dữ liệu ra tập tin tại đường dẫn: " + filePath);
            }
            uploadAllStatus(FrmConfirmChangeStatus.Printed);
            LoadCards();

        }

        private void dgvCards_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo info = dgvCard.HitTest(e.X, e.Y);
                cmsCardTable.Show((Control)sender, e.X, e.Y);
            }
        }

        #endregion

        #region Functions for card

        private void LoadCardTypeOfPartner(List<CardTypeDTO> cardTypes)
        {
            cmbCardTypes.DataSource = cardTypes;
            cmbCardTypes.DisplayMember = "cardTypeName";
            cmbCardTypes.ValueMember = "prefix";
            cmbCardTypes.SelectedIndex = 0;
        }
        private void LoadCards()
        {
            if (!loadMemberWorker.IsBusy)
            {
                dtbListMember.Rows.Clear();
                pagerPanel1.ShowMessage("Đang tải dữ liệu, xin hãy chờ...");
                loadMemberWorker.RunWorkerAsync(GetFilterMagnetic());
            }
        }

        private CardMagneticFilterDto GetFilterMagnetic()
        {
            CardMagneticFilterDto filter = new CardMagneticFilterDto();

            if (cbxFilterByCardType.Checked && cmbCardTypes.SelectedIndex > -1)
            {
                filter.FilterByCardType = true;
                filter.Prefix = cmbCardTypes.SelectedValue.ToString();
            }

            if (cbxFilterByCardPhysicalStatus.Checked && cmbCardPhysicalStatus.SelectedIndex > -1)
            {
                filter.FilterByCardPhysicalStatus = true;
                filter.CardPhysicalStatus = Convert.ToInt32(cmbCardPhysicalStatus.SelectedValue);
            }

            if (cbxFilterByPrintedStatus.Checked)
            {
                filter.FilterByCardPrintedStatus = true;
                CardMageneticPrintedStatus physicalStt = CardMageneticPrintedStatus.NotPrinted;
                if (rbtnStatusPrinted.Checked)
                {
                    physicalStt = CardMageneticPrintedStatus.Printed;
                }
                filter.CardPrintedStatus = (int)physicalStt;
            }

            return filter;
        }

        private void bgwMember_DoWork(object sender, DoWorkEventArgs e)
        {
            if (e.Argument == null || !(e.Argument is CardMagneticFilterDto))
            {
                return;
            }
            CardMagneticFilterDto filter = e.Argument as CardMagneticFilterDto;
            List<CardmagneticDTO> result = null;
            int totalRecords = 0;
            int take = LocalSettings.Instance.RecordsPerPage;
            int skip = 0;
            currentPageIndex = 1;

            try
            {
                MagneticList = MagneticPersonalizationFactory.Instance.GetChannel().GetMagneticList(storageService.CurrentSessionId, masterId, partnerInfo.MasterId, filter);
            }
            catch (TimeoutException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.TimeOutExceptionMessage);
                result = null;
            }
            catch (FaultException<WcfServiceFault> ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
                result = null;
            }
            catch (FaultException ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.FaultExceptionMessage
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
                result = null;
            }
            catch (CommunicationException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.CommunicationExceptionMessage);
                result = null;
            }
            finally
            {
                if (MagneticList != null)
                {
                    result = MagneticList.Skip(skip).Take(take).ToList();
                    totalRecords = MagneticList.Count;
                    pagerPanel1.ShowNumberOfRecords(totalRecords, result != null ? result.Count : 0, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
                    pagerPanel1.UpdatePagingLinks(totalRecords, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
                }
                e.Result = result;
            }
        }

        private void bgwMember_WorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if (e.Result == null)
            {
                return;
            }

            List<CardmagneticDTO> result = e.Result as List<CardmagneticDTO>;
            DateTime today = DateTime.Today;
            LoadPersoDataGridView(result);
        }

        private void LoadPersoDataGridView(List<CardmagneticDTO> result)
        {
            foreach (CardmagneticDTO mm in result)
            {
                DataRow row = dtbListMember.NewRow();
                row.BeginEdit();

                row[colMagneticId.DataPropertyName] = mm.MagneticId;
                row[colFullName.DataPropertyName] = mm.FullName;
                row[colPhoneNumber.DataPropertyName] = mm.PhoneNumber;
                row[colOrgName.DataPropertyName] = mm.OrgName;
                row[colSubOrgName.DataPropertyName] = mm.SubOrgName;
                row[colTrackData.DataPropertyName] = mm.TrackData;
                row[ColActiveCode.DataPropertyName] = mm.ActiveCode;
                row[colTypeCrypto.DataPropertyName] = mm.TypeCrypto;
                row[colCardType.DataPropertyName] = mm.cardtypes;
                row[colSerialCard.DataPropertyName] = mm.SerialCard;
                //row[colCardType.DataPropertyName] = CardTypeExtMethod.ToCardType(mm.cardtypes).GetName();
                row[colPinCode.DataPropertyName] = mm.PinCode;
                row[colStartDate.DataPropertyName] = mm.StartDate;
                row[colExpireDate.DataPropertyName] = mm.ExpireDate;
                row[colPhysicalStatus.DataPropertyName] = ((CardMagneticPhysicalStatus)mm.PhysicalStatus).GetName();
                row[colPrintedStatus.DataPropertyName] = ((CardMageneticPrintedStatus)mm.PrintStatus).GetName();
                row[colNotes.DataPropertyName] = mm.Notes;

                row.EndEdit();
                dtbListMember.Rows.Add(row);
            }
        }

        #endregion


        #region Thay đổi trạng thái vật lý thẻ

        private void DoActionChangeStatusPersoes(byte status, string Reason, List<long> MagneticIds)
        {

            List<CardmagneticDTO> result = null;
            try
            {
                //TODO: implement call server update status
                result = MagneticPersonalizationFactory.Instance.GetChannel().GetChangeStatusPhysicalMagnetic(storageService.CurrentSessionId, status, Reason, MagneticIds);

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
                LoadCards();
            }
        }

        private void uploadStatus(byte status)
        {
            MagneticIds = new List<long>();
            int count = dgvCard.SelectedRows.Count;
            if (count == 0)
            {
                MessageBoxManager.ShowErrorMessageBox(this, "Bạn chưa chọn lượt phát hành cho thao tác này!", "Thao Tác Sai");
                return;
            }

            var confirmDialog = FrmConfirmChangeStatus.GetInstance(status);
            confirmDialog.ShowDialog();

            if (confirmDialog.DialogResult == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dgvCard.SelectedRows)
                {
                    MagneticIds.Add(Convert.ToInt64(row.Cells[colMagneticId.Name].Value.ToString()));
                }
                DoActionChangeStatusPersoes(status, confirmDialog.Reason, MagneticIds);
            }
        }

        private void uploadAllStatus(byte status)
        {
            MagneticIds = new List<long>();
            foreach (DataGridViewRow row in dgvCard.Rows)
            {
                MagneticIds.Add(Convert.ToInt64(row.Cells[colMagneticId.Name].Value.ToString()));
            }
            DoActionChangeStatusPersoes(status, "Xuat file Excel", MagneticIds);
        }

        #endregion


    }
}


