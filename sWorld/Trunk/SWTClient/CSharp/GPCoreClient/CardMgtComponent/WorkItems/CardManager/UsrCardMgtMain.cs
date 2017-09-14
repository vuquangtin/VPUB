using System;
using System.Collections.Generic;
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
using CardChipMgtComponent.Constants;
using sWorldModel.Model;
using sWorldModel;
using sWorldModel.Exceptions;
using sWorldModel.Filters;
using JavaCommunication;
using JavaCommunication.Factory;
using sWorldModel.TransportData;
using CommonHelper.Utils;
using System.Resources;

namespace CardChipMgtComponent.WorkItems
{
    public partial class UsrCardMgtMain : CommonUserControl
    {
        #region Properties

        // Height of filter box when it is hidden
        private int hiddenFilterBoxHeight = 1;
        // The original height of filter box (at startup)
        private int startupFilterBoxHeight;
        private ResourceManager rm;

        private int currentPageIndex = 1;
        private Font startupNodeFont;
        private BackgroundWorker bgwLoadCards;
        private BackgroundWorker loadSubOrgWorker;
        private DataTable dtbCardList;
        List<CardChipDto> CardChipList;
        private MasterInfoDTO masterInfo;
        private MasterInfoDTO partnerInfo;
        private long partnerId, masterId;
        private TreeNode selectedOrgNode;
        private TreeNode rootNode;

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

        #region Contructors

        public UsrCardMgtMain()
        {
            InitializeComponent();

            dtbCardList = new DataTable();
            dtbCardList.Columns.Add(colCardId.DataPropertyName);
            dtbCardList.Columns.Add(colCardType.DataPropertyName);
            dtbCardList.Columns.Add(colSerialNumber.DataPropertyName);
            dtbCardList.Columns.Add(colSttPersonalized.DataPropertyName);
            dtbCardList.Columns.Add(colSttBroken.DataPropertyName);
            dtbCardList.Columns.Add(colSttLost.DataPropertyName);
            dtbCardList.Columns.Add(colImportedOn.DataPropertyName);
            dgvCardList.DataSource = dtbCardList;

            bgwLoadCards = new BackgroundWorker();
            bgwLoadCards.WorkerSupportsCancellation = true;
            bgwLoadCards.DoWork += bgwLoadCards_DoWork;
            bgwLoadCards.RunWorkerCompleted += bgwLoadCards_Completed;

            btnShowHideFilter.Click += btnShowHide_Clicked;

            this.pagerPanel1.LinkLabelClicked += pagerPanel_LinkLabelClicked;
            this.dgvCardList.MouseDown += dgvCards_MouseDown;

            this.cbxFilterByPhysicalStt.CheckedChanged += cbxFilterByPhysicalStatus_CheckedChanged;
            this.cbxFilterByCardType.CheckedChanged += cbxFilterByCardType_CheckedChanged;
            this.cbxFilterByPersoStatus.CheckedChanged += cbxFilterByPersoStatus_CheckedChanged;

            //cmbPartnerInfo.SelectedIndexChanged += cmbPartnerInfo_SelectedIndexChanged;

            //this.btnImportCard.Click += btnImportCard_Clicked;
            btnReloadCards.Click += (s, e) => LoadCards();

            this.Load += OnFormLoad;
            this.Enter += (s, e) =>
            {
                if (CardMgtMainShown != null)
                {
                    CardMgtMainShown(this, new CabEventArgs(new object[] { ComponentNames.CardMgtComponent }));
                }
            };
            this.Leave += (s, e) =>
            {
                if (CardMgtMainHide != null)
                {
                    CardMgtMainHide(this, new CabEventArgs(new object[] { ComponentNames.CardMgtComponent }));
                }
            };
        }

        #endregion

        #region Form events

        private void OnFormLoad(object s, EventArgs e)
        {
            LoadPartnerInfo();
            HideOrShowOrg();
            LoadCardType();
            LoadCards();
            startupFilterBoxHeight = this.pnlFilterBox.Height;

            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
            pagerPanel1.StorageService = storageService;
            pagerPanel1.LoadLanguage();
            // set table languages 
            SetLanguages();
        }
        
        private void SetLanguages()
        {
          

            this.colCardId.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colCardId.Name);
            this.colCardType.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colCardType.Name);
            this.colSerialNumber.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colSerialNumber.Name);
            this.colSttPersonalized.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colSttPersonalized.Name);
            this.colSttBroken.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colSttBroken.Name);
            this.colSttLost.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colSttLost.Name);
            this.colImportedOn.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colImportedOn.Name);
           
            this.btnExportToExcel.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnExportToExcel.Name);
            this.btnReloadCards.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnReloadCards.Name);
            this.btnShowHideFilter.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnShowHideFilter.Name);

            this.mniImportCard.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.mniImportCard.Name);
            this.mniExportExcelToolStripMenuItem.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.mniExportExcelToolStripMenuItem.Name);
            this.mniReloadCards.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.mniReloadCards.Name);
              
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (bgwLoadCards.IsBusy)
                {
                    bgwLoadCards.CancelAsync();
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

        private void cmbPartnerInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //partnerId = (long)cmbPartnerInfo.SelectedValue;
            LoadCards();
        }

        private void dgvCards_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo info = dgvCardList.HitTest(e.X, e.Y);
                cmsCardTable.Show((Control)sender, e.X, e.Y);
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
            dtbCardList.Rows.Clear();
            int take = LocalSettings.Instance.RecordsPerPage;
            int skip = (currentPageIndex -1) * take;

            List<CardChipDto> result = CardChipList.Skip(skip).Take(take).ToList();
            LoadCardDataGridView(result);

            pagerPanel1.ShowNumberOfRecords(CardChipList.Count, result != null ? result.Count : 0, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
            pagerPanel1.UpdatePagingLinks(CardChipList.Count, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
        }

        private void btnRefreshCardList_Clicked(object s, EventArgs e)
        {
            currentPageIndex = 1;
            LoadCards();
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

        private void cbxFilterByPhysicalStatus_CheckedChanged(object s, EventArgs e)
        {
            rbtnStatusNormal.Enabled = rbtnStatusBroken.Enabled = rbtnStatusLost.Enabled = cbxFilterByPhysicalStt.Checked;
        }

        private void cbxFilterByCardType_CheckedChanged(object s, EventArgs e)
        {
            cmbCardTypes.Enabled = cbxFilterByCardType.Checked;
        }

        private void cbxFilterByPersoStatus_CheckedChanged(object s, EventArgs e)
        {
            rbtnStatusPerso.Enabled = rbtnStatusNotPerso.Enabled = cbxFilterByPersoStatus.Checked;
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            string filePath = ControlExtMethods.ShowSaveFileDialog(MessageValidate.GetMessage(rm, "smsChooseFileExport"), "DanhSachThe", "MS Excel (*.xls)|*.xls");
            if (filePath != null)
            {
                try
                {
                    dgvCardList.ExportToExcel(filePath);
                }
                catch (Exception ex)
                {
                    MessageBoxManager.ShowErrorMessageBox(this, ex.Message);
                    return;
                }
                MessageBoxManager.ShowInfoMessageBox(this, "Đã xuất dữ liệu ra tập tin tại đường dẫn: " + filePath);
            }
        }

        private void rbtnStatusNotPerso_CheckedChanged(object sender, EventArgs e)
        {
            dtbCardList.Rows.Clear();
            List<CardChipDto> result = CardChipList.Where(c => !c.Personalized).ToList();
            LoadCardDataGridView(result);
        }

        private void rbtnStatusPerso_CheckedChanged(object sender, EventArgs e)
        {
            dtbCardList.Rows.Clear();
            List<CardChipDto> result = CardChipList.Where(c => c.Personalized).ToList();
            LoadCardDataGridView(result);
        }

        #endregion

        #region Event's support

        #region PartnerInfo

        private void LoadPartnerInfo()
        {
            try
            {
                partnerInfo = OrganizationFactory.Instance.GetChannel().GetMasterInfo(StorageService.CurrentSessionId, SystemSettings.Instance.Partner);
                this.masterInfo = OrganizationFactory.Instance.GetChannel().GetMasterInfo(StorageService.CurrentSessionId, SystemSettings.Instance.Master);
                masterId = masterInfo.MasterId;
                //cmbPartnerInfo.ValueMember = "PartnerId";
                //cmbPartnerInfo.DisplayMember = "Name";
                //cmbPartnerInfo.DataSource = this.partnerInfoList;
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
            //    plHideShowOrg.Height = 55;
        }

        #endregion

        #region Functions for card

        private void LoadCardType()
        {
            List<CardChipType> cardTypes = CardTypeExtMethod.GetCardTypeList();
            DataTable dtbCardTypes = new DataTable();
            dtbCardTypes.Columns.Add("Id");
            dtbCardTypes.Columns.Add("Name");
            foreach (CardChipType ct in cardTypes)
            {
                DataRow row = dtbCardTypes.NewRow();
                row.BeginEdit();
                row["Id"] = (int)ct;
                row["Name"] = ct.GetName();
                row.EndEdit();
                dtbCardTypes.Rows.Add(row);
            }
            cmbCardTypes.ValueMember = "Id";
            cmbCardTypes.DisplayMember = "Name";
            cmbCardTypes.DataSource = dtbCardTypes;
        }

        private CardFilterDto LoadFilter()
        {
            CardFilterDto filter = new CardFilterDto();

            if (cbxFilterByCardType.Checked && cmbCardTypes.SelectedIndex > -1)
            {
                filter.FilterByCardType = true;
                filter.CardType = Convert.ToInt32(cmbCardTypes.SelectedValue);
            }
            if (cbxFilterByPhysicalStt.Checked)
            {
                filter.FilterByPhysicalStatus = true;
                CardPhysicalStatus physicalStt = CardPhysicalStatus.Normal;
                if (rbtnStatusBroken.Checked)
                {
                    physicalStt = CardPhysicalStatus.Broken;
                }
                else if (rbtnStatusLost.Checked)
                {
                    physicalStt = CardPhysicalStatus.Lost;
                }
                filter.PhysicalStatus = (int)physicalStt;
            }
            
            return filter;
        }

        private void LoadCards()
        {
            if (!bgwLoadCards.IsBusy)
            {
                dtbCardList.Rows.Clear();
                pagerPanel1.ShowMessage(MessageValidate.GetMessage(rm, "LoadingWaiting"));
                bgwLoadCards.RunWorkerAsync(LoadFilter());
            }
        }

        private void bgwLoadCards_DoWork(object s, DoWorkEventArgs e)
        {

            if (e.Argument == null || !(e.Argument is CardFilterDto))
            {
                return;
            }
            CardFilterDto filter = e.Argument as CardFilterDto;
            List<CardChipDto> result = null;
            int totalRecords = 0;
            int take = LocalSettings.Instance.RecordsPerPage;
            int skip = 0;
            currentPageIndex = 1;

            try
            {
                CardChipList = CardChipFactory.Instance.GetChannel().GetCardChipList(StorageService.CurrentSessionId, masterInfo.MasterId, partnerInfo.MasterId, filter);
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
                if (CardChipList != null)
                {
                    result = CardChipList.Skip(skip).Take(take).ToList();
                    totalRecords = CardChipList.Count;
                    pagerPanel1.ShowNumberOfRecords(totalRecords, result != null ? result.Count : 0, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
                    pagerPanel1.UpdatePagingLinks(totalRecords, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
                }
                e.Result = result;
            }
        }

        private void bgwLoadCards_Completed(object s, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if (e.Result == null || !(e.Result is List<CardChipDto>))
            {
                return;
            }
            List<CardChipDto> result = e.Result as List<CardChipDto>;

            if (cbxFilterByPersoStatus.Checked)
            {
                if (rbtnStatusPerso.Checked)
                {
                    LoadCardDataGridView(result.Where(c=>c.Personalized).ToList());
                }
                else 
                {
                    LoadCardDataGridView(result.Where(c => !c.Personalized).ToList());
                }
            }
            else
                LoadCardDataGridView(result);
        }

        private void LoadCardDataGridView(List<CardChipDto> result)
        {
            foreach (CardChipDto cardChip in result)
            {
                DataRow row = dtbCardList.NewRow();
                row.BeginEdit();

                row[colCardId.DataPropertyName] = cardChip.CardChipId;
                row[colCardType.DataPropertyName] = CardTypeExtMethod.ToCardType(cardChip.TypeCard).GetName();
                row[colSerialNumber.DataPropertyName] = cardChip.SerialNumberHex;
                row[colImportedOn.DataPropertyName] = cardChip.CreatedOn;
                switch (cardChip.PhysicalStatus)
                {
                    case (int)CardPhysicalStatus.Broken:
                        row[colSttBroken.DataPropertyName] = LocalSettings.Instance.CheckSymbol;
                        break;
                    case (int)CardPhysicalStatus.Lost:
                        row[colSttLost.DataPropertyName] = LocalSettings.Instance.CheckSymbol;
                        break;
                    default:
                        break;
                }
                row[colSttPersonalized.DataPropertyName] = cardChip.Personalized ? LocalSettings.Instance.CheckSymbol : string.Empty;

                row.EndEdit();
                dtbCardList.Rows.Add(row);
            }
        }

        #endregion

        #endregion

        #region CAB events

        [CommandHandler(CardCommandNames.ShowCardMgtMain)]
        public void ShowCardMgtMainHandler(object s, EventArgs e)
        {
            UsrCardMgtMain uc = workItem.Items.Get<UsrCardMgtMain>(ComponentNames.CardMgtComponent);
            if (uc == null)
            {
                uc = workItem.Items.AddNew<UsrCardMgtMain>(ComponentNames.CardMgtComponent);
            }
            else if (uc.IsDisposed)
            {
                workItem.Items.Remove(uc);
                uc = workItem.Items.AddNew<UsrCardMgtMain>(ComponentNames.CardMgtComponent);
            }

            workItem.Workspaces[WorkspaceName.MainWorkspace].Show(uc);
            uc.Parent.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuCardManager);
        }

        //[CommandHandler(CardCommandNames.WriteKey)]
        //public void btnImportCard_Clicked(object s, EventArgs e)
        //{
        //    FrmWriteMasterKey dialog = new FrmWriteMasterKey();
        //    workItem.SmartParts.Add(dialog);

        //    dialog.ShowDialog();

        //    workItem.SmartParts.Remove(dialog);
        //    dialog.Dispose();
        //}

        [EventPublication(CardEventTopicNames.CardMgtMainShown)]
        public event EventHandler CardMgtMainShown;

        [EventPublication(CardEventTopicNames.CardMgtMainHide)]
        public event EventHandler CardMgtMainHide;

        #endregion

     
    }
}