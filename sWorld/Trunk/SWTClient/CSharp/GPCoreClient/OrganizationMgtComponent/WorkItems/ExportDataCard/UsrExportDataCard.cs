using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.ServiceModel;
using sWorldModel.Exceptions;
using JavaCommunication.Factory;
using sWorldModel.Filters;
using CommonControls;
using CommonHelper.Constants;
using System.Text;
using Microsoft.Practices.CompositeUI;
using SystemMgtComponent.Constants;
using sWorldModel.TransportData;
using System.Resources;
using sWorldModel;
using Microsoft.Practices.CompositeUI.EventBroker;
using Microsoft.Practices.CompositeUI.Commands;
using System.Windows.Forms;
using CommonHelper.Utils;
using CommonControls.Custom;
using CommonHelper.Config;

namespace SystemMgtComponent.WorkItems.ExportDataCard
{
    public partial class UsrExportDataCard : CommonUserControl
    {
        private ResourceManager rm;
        private BackgroundWorker loadOrgWorker;
        private BackgroundWorker bgwLoadListCard;
        private DataTable dtbCardData;
        private BackgroundWorker bgwLoadListCardByOrgPartner;
        private Font startupNodeFont;
        // Selected tree node; cache it to do some effect in UI
        private TreeNode selectedOrgNode;
        private int currentPageIndex = 1;
        private TreeNode rootNode;
        private TreeNode parentNode;
        List<CardChipDto> lstCardChip;
        List<CardChipDto> lstCardChipExport;
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

        public UsrExportDataCard()
        {
            InitializeComponent();
            RegisterEvents();
            InitTreeList();
            InitDataGridView();
            LoadOrgList();
            LoadListCard();
            btnExportCard.Click += btnExportCard_Clicked;

        }
        private void RegisterEvents()
        {
            //Tree View
            trvMaster.BeforeSelect += trvOrganizations_BeforeSelect;
            trvMaster.AfterSelect += trvOrganizations_AfterSelect;

            loadOrgWorker = new BackgroundWorker();
            loadOrgWorker.WorkerSupportsCancellation = true;
            loadOrgWorker.DoWork += OnLoadOrgWorkerDoWork;
            loadOrgWorker.RunWorkerCompleted += OnLoadOrgWorkerCompleted;

            bgwLoadListCard = new BackgroundWorker();
            bgwLoadListCard.WorkerSupportsCancellation = true;
            bgwLoadListCard.DoWork += OnLoadCardWorkerDoWork;
            bgwLoadListCard.RunWorkerCompleted += OnLoadCardRunWorkerCompleted;

            bgwLoadListCardByOrgPartner = new BackgroundWorker();
            bgwLoadListCardByOrgPartner.WorkerSupportsCancellation = true;
            bgwLoadListCardByOrgPartner.DoWork += OnLoadCardWorkerByPartnerDoWork;
            bgwLoadListCardByOrgPartner.RunWorkerCompleted += OnLoadCardByPartnerRunWorkerCompleted;

            pagerPanel.LinkLabelClicked += pagerPanel_LinkLabelClicked;
            startupNodeFont = trvMaster.Font;
            Load += OnFormLoad;

        }
        private void trvOrganizations_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            // Change node font style to normal
            if (selectedOrgNode != null)
            {
                selectedOrgNode.NodeFont = new Font(startupNodeFont, FontStyle.Regular);
                selectedOrgNode.Text = selectedOrgNode.Text;
            }
        }

        private void trvOrganizations_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectedNode = e.Node;
            TreeNode parentNode = new TreeNode();
            if (selectedNode != null)
            {
                parentNode = selectedNode.Parent;
                selectedNode.NodeFont = new Font(startupNodeFont, FontStyle.Bold);
                selectedNode.Text = selectedNode.Text;

                if (selectedOrgNode != null && selectedNode == selectedOrgNode)
                {
                    return;
                }

                selectedOrgNode = selectedNode;
                if (selectedOrgNode.Level > 0)
                {
                    LoadListCardByOrgPartner();
                }
                else
                {
                    ClearEmptyControl();
                }
            }

        }
        private void InitTreeList()
        {
            rootNode = new TreeNode();
            rootNode.Text = "Tất Cả";
            rootNode.Name = "-1";
            trvMaster.Nodes.Add(rootNode);
        }
        private void InitDataGridView()
        {
            dtbCardData = new DataTable();
            dtbCardData.Columns.Add(colIndex.DataPropertyName);
            dtbCardData.Columns.Add(colSerial.DataPropertyName);
            dtbCardData.Columns.Add(colCardType.DataPropertyName);
            dtbCardData.Columns.Add(colDateExport.DataPropertyName);
            dgvCardExport.DataSource = dtbCardData;
        }
        private void LoadOrgList()
        {
            if (!loadOrgWorker.IsBusy)
            {
                rootNode.Nodes.Clear();
                loadOrgWorker.RunWorkerAsync();
            }
        }
        private void ClearEmptyControl()
        {
            dtbCardData.Rows.Clear();
        }
        private void OnLoadOrgWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            List<CmsOrgCustomerDto> lstOrg = null;
            OrgFilterDto filter = new OrgFilterDto();

            try
            {
                lstOrg = OrganizationFactory.Instance.GetChannel().GetAllOrgList(StorageService.CurrentSessionId);
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
                e.Result = lstOrg;
            }
        }

        private void OnLoadOrgWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            // Get result from DoWork method
            List<CmsOrgCustomerDto> result = (List<CmsOrgCustomerDto>)e.Result;
            if (result != null)
            {
                foreach (CmsOrgCustomerDto org in result)
                {
                    if (org.Issuer.Equals(SystemSettings.Instance.Master))
                        continue;
                    TreeNode orgNode = new TreeNode();
                    orgNode.Text = org.Name;
                    orgNode.Name = Convert.ToString(org.OrgId);
                    rootNode.Nodes.Add(orgNode);
                }
                trvMaster.Sort();
                rootNode.Expand();
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
            dtbCardData.Rows.Clear();
            int take = LocalSettings.Instance.RecordsPerPage;
            int skip = (currentPageIndex - 1) * take;
            if (lstCardChipExport != null)
            {
                List<CardChipDto> result = lstCardChipExport.Skip(skip).Take(take).ToList();
                LoadDataForDataGidView(result);

                pagerPanel.ShowNumberOfRecords(lstCardChipExport.Count, result != null ? result.Count : 0, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
                pagerPanel.UpdatePagingLinks(lstCardChipExport.Count, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
            }
        }

        private void LoadListCard()
        {
            if (!bgwLoadListCard.IsBusy)
            {
                bgwLoadListCard.RunWorkerAsync();
            }
        }
        private void LoadListCardByOrgPartner()
        {
            if (!bgwLoadListCardByOrgPartner.IsBusy)
            {
                dtbCardData.Rows.Clear();
                pagerPanel.ShowMessage(MessageValidate.GetMessage(rm, "waitLoadData"));
                bgwLoadListCardByOrgPartner.RunWorkerAsync();
            }
        }

        private void OnLoadCardWorkerByPartnerDoWork(object sender, DoWorkEventArgs e)
        {
            int totalRecords = 0;
            int take = LocalSettings.Instance.RecordsPerPage;
            int skip = 0;
            try
            {
                e.Result = CardChipFactory.Instance.GetChannel().GetCardChipListExport(StorageService.CurrentSessionId, Convert.ToInt64(selectedOrgNode.Name));
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
                lstCardChipExport = (List<CardChipDto>)e.Result;

                lstCardChipExport = lstCardChipExport.Skip(skip).Take(take).ToList();
                totalRecords = lstCardChipExport.Count;
                pagerPanel.ShowNumberOfRecords(totalRecords, lstCardChipExport != null ? lstCardChipExport.Count : 0, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
                pagerPanel.UpdatePagingLinks(totalRecords, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
            }
        }

        private void OnLoadCardByPartnerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if (e.Result != null)
            {
                lstCardChipExport = (List<CardChipDto>)e.Result;
                numbercardCanExport.Text = (lstCardChip.Count - lstCardChipExport.Count) + "";
                numbercardExport.Text = lstCardChipExport.Count.ToString();

                LoadDataForDataGidView(lstCardChipExport);
            }
        }
        private void OnLoadCardWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = CardChipFactory.Instance.GetChannel().GetCardChipListExport(StorageService.CurrentSessionId);
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

        private void OnLoadCardRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if (e.Result != null)
            {
                lstCardChip = (List<CardChipDto>)e.Result;
                numberCard.Text = lstCardChip.Count.ToString();


            }
        }
        public void LoadDataForDataGidView(List<CardChipDto> lstCardChip)
        {
            int count = 1;
            foreach (CardChipDto cardChipDto in lstCardChip)
            {
                DataRow row = dtbCardData.NewRow();
                row.BeginEdit();

                row[colIndex.DataPropertyName] = count;
                row[colSerial.DataPropertyName] = cardChipDto.SerialNumberHex;
                row[colCardType.DataPropertyName] =((CardChipType)cardChipDto.TypeCard).GetName();
                row[colDateExport.DataPropertyName] = cardChipDto.CreatedOn;

                row.EndEdit();
                dtbCardData.Rows.Add(row);
                count++;
            }
        }
        private void OnFormLoad(object sender, EventArgs e)
        {
            // Check permissions
            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
            pagerPanel.StorageService = storageService;
            pagerPanel.LoadLanguage();
        }

        [CommandHandler(OrganizationCommandNames.ShowExportCard)]
        public void ShowOrgMgtMainHandler(object s, EventArgs e)
        {
            UsrExportDataCard uc = workItem.Items.Get<UsrExportDataCard>(ComponentNames.ExportDataCard);
            if (uc == null)
            {
                uc = workItem.Items.AddNew<UsrExportDataCard>(ComponentNames.ExportDataCard);
            }
            else if (uc.IsDisposed)
            {
                workItem.Items.Remove(uc);
                uc = workItem.Items.AddNew<UsrExportDataCard>(ComponentNames.ExportDataCard);
            }

            workItem.Workspaces[WorkspaceName.MainWorkspace].Show(uc);
            uc.Parent.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuExportCard);
        }

        public void btnExportCard_Clicked(object sender, EventArgs e)
        {
            FrmExportDataCard dialog = new FrmExportDataCard(1, false);
            workItem.SmartParts.Add(dialog);
            dialog.ShowDialog();

            workItem.SmartParts.Remove(dialog);
            dialog.Dispose();
        }

        private void lblFilterbyserial_CheckedChanged(object sender, EventArgs e)
        {
            tbxSerialCard.Enabled = lblFilterbyserial.Checked;
        }

        private void cbxFilterByMemberName_CheckedChanged(object sender, EventArgs e)
        {
            tbxCardType.Enabled = cbxFilterByMemberName.Checked;
        }

        private void cbxFilterByExportDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpPersoDateFrom.Enabled = dtpPersoDateTo.Enabled = cbxFilterByExportDate.Checked;
        }
    }
}
