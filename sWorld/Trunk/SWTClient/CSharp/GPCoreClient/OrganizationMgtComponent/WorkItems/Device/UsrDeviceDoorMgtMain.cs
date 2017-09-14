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
using System.Linq;
using sWorldModel;
using sWorldModel.Exceptions;
using JavaCommunication;
using CommonHelper.Utils;
using System.Resources;
using sWorldModel.TransportData;
using SystemMgtComponent.WorkItems;
using SystemMgtComponent.Constants;
using JavaCommunication.Factory;

namespace SystemMgtComponent.WorkItems
{
    public partial class UsrDeviceDoorMgtMain : CommonUserControl
    {
        #region Properties

        private BackgroundWorker bgwLoadDeviceDoorList;

        private int currentPageIndex = 1;
        private DataTable dtbDeviceDoorList;
        private List<DeviceDoor> DeviceDoorList;

        private ResourceManager rm;

        private SystemWorkItem workItem;
        [ServiceDependency]
        public SystemWorkItem WorkItem
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

        public UsrDeviceDoorMgtMain()
        {
            InitializeComponent();
            RegisterEvent();
            InitDataGridViewDeviceDoor();
        }

        protected override void OnLoad(EventArgs e)
        {
            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
            pagerPanel1.StorageService = storageService;
            pagerPanel1.LoadLanguage();
            LoadDeviceDoorList();
            // Set Language
            SetLanguage();
        }

        private void RegisterEvent()
        {
            bgwLoadDeviceDoorList = new BackgroundWorker();
            bgwLoadDeviceDoorList.WorkerSupportsCancellation = true;
            bgwLoadDeviceDoorList.DoWork += bgwLoadDeviceDoorList_DoWork;
            bgwLoadDeviceDoorList.RunWorkerCompleted += bgwLoadDeviceDoorList_RunWorkerCompleted;

            btnAddDevice.Click += btnAddDevice_Click;
            btnUpdateDevice.Click += btnUpdateDevice_Click;
            btnRemoveDevice.Click += btnRemoveDevice_Click;

            btnReload.Click += (s, e) => LoadDeviceDoorList();
            pagerPanel1.LinkLabelClicked += pagerPanel_LinkLabelClicked;
        }

        #endregion

        #region Set Language
        private void SetLanguage()
        {
            this.lblRightAreaTitle_Device.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.lblRightAreaTitle_Device.Name);
            this.btnAddDevice.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnAddDevice.Name);
            this.btnUpdateDevice.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnUpdateDevice.Name);
            this.btnRemoveDevice.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnRemoveDevice.Name);
            this.btnReload.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnReload.Name);
            this.colDeviceName.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colDeviceName.Name);
            this.colIP.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colIP.Name);
            this.colLocked.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colLocked.Name);
            this.colStatus.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colStatus.Name);
            this.colDescription.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colDescription.Name);
        }
        #endregion

        #region Event's

        void btnRemoveDevice_Click(object sender, EventArgs e)
        {
            bool result;
            if (dgvDeviceDoorList.SelectedRows.Count == 0)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessSelect(rm, MessageValidate.CancelApp), MessageValidate.GetErrorTitle(rm));
                return;
            }

            //Show confirmation message box
            if (MessageBoxManager.ShowQuestionMessageBox(this, MessageValidate.GetMessage(rm, "areyousuredeletedevice")) == DialogResult.Yes)
            {
                long deviceDoorId = Convert.ToInt64(dgvDeviceDoorList.SelectedRows[0].Cells[colId.Index].Value.ToString());
                try
                {
                    result = (int)Status.SUCCESS == AccessFactory.Instance.GetChannel().DeleteDeviceDoor(StorageService.CurrentSessionId, deviceDoorId);
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
                // Check return result
                if (result)
                {
                    LoadDeviceDoorList();
                }
                else
                {
                    MessageBoxManager.ShowErrorMessageBox(this, ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MessageValidate.AppCancelFail));
                }
            }
        }

        void btnUpdateDevice_Click(object sender, EventArgs e)
        {
            if (dgvDeviceDoorList.SelectedRows.Count > 0)
            {
                long deviceDoorId = Convert.ToInt64(dgvDeviceDoorList.SelectedRows[0].Cells[colId.Index].Value.ToString());
                FrmAddOrEditDeviceDoor dialog = new FrmAddOrEditDeviceDoor(FrmAddOrEditDeviceDoor.ModeUpdating, deviceDoorId);
                workItem.SmartParts.Add(dialog);
                dialog.ShowDialog();
                workItem.SmartParts.Remove(dialog);
                dialog.Dispose();
                LoadDeviceDoorList();
            }
        }

        void btnAddDevice_Click(object sender, EventArgs e)
        {
            FrmAddOrEditDeviceDoor dialog = new FrmAddOrEditDeviceDoor(FrmAddOrEditDeviceDoor.ModeAdding);
            workItem.SmartParts.Add(dialog);
            dialog.ShowDialog();
            workItem.SmartParts.Remove(dialog);
            dialog.Dispose();
            LoadDeviceDoorList();
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
            dtbDeviceDoorList.Rows.Clear();
            int take = LocalSettings.Instance.RecordsPerPage;
            int skip = (currentPageIndex - 1) * take;

            List<DeviceDoor> result = DeviceDoorList.Skip(skip).Take(take).ToList();
            LoadDeviceDoorDataGridView(result);

            pagerPanel1.ShowNumberOfRecords(DeviceDoorList.Count, result != null ? result.Count : 0, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
            pagerPanel1.UpdatePagingLinks(DeviceDoorList.Count, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
        }

        void bgwLoadDeviceDoorList_DoWork(object sender, DoWorkEventArgs e)
        {
            List<DeviceDoor> result = null;
            int totalRecords = 0;
            int take = LocalSettings.Instance.RecordsPerPage;
            int skip = 0;
            currentPageIndex = 1;
            try
            {
                DeviceDoorList = AccessFactory.Instance.GetChannel().GetDeviceDoorList(StorageService.CurrentSessionId);
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
                if (DeviceDoorList != null)
                {
                    result = DeviceDoorList.Skip(skip).Take(take).ToList();
                    totalRecords = DeviceDoorList.Count;
                    pagerPanel1.ShowNumberOfRecords(totalRecords, result != null ? result.Count : 0, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
                    pagerPanel1.UpdatePagingLinks(totalRecords, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
                }
                e.Result = result;
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
            LoadDeviceDoorDataGridView(result);
        }

        #endregion

        #region Event's Support

        private void InitDataGridViewDeviceDoor()
        {
            dtbDeviceDoorList = new DataTable();
            dtbDeviceDoorList.Columns.Add(colId.DataPropertyName);
            dtbDeviceDoorList.Columns.Add(colDeviceName.DataPropertyName);
            dtbDeviceDoorList.Columns.Add(colIP.DataPropertyName);
            dtbDeviceDoorList.Columns.Add(colPort.DataPropertyName);
            dtbDeviceDoorList.Columns.Add(colOpenDoor.DataPropertyName);
            dtbDeviceDoorList.Columns.Add(colCloseDoor.DataPropertyName);
            dtbDeviceDoorList.Columns.Add(colStatus.DataPropertyName);
            dtbDeviceDoorList.Columns.Add(colLocked.DataPropertyName);
            dtbDeviceDoorList.Columns.Add(colDescription.DataPropertyName);
            dgvDeviceDoorList.DataSource = dtbDeviceDoorList;
        }

        private void LoadDeviceDoorList()
        {
            if (!bgwLoadDeviceDoorList.IsBusy)
            {
                dtbDeviceDoorList.Rows.Clear();
                pagerPanel1.ShowMessage(MessageValidate.GetMessage(rm, "waitLoadData"));
                bgwLoadDeviceDoorList.RunWorkerAsync();
            }
        }

        private void LoadDeviceDoorDataGridView(List<DeviceDoor> result)
        {
            foreach (DeviceDoor deviceDoor in result)
            {
                DataRow row = dtbDeviceDoorList.NewRow();
                row.BeginEdit();

                row[colId.DataPropertyName] = deviceDoor.Id;
                row[colDeviceName.DataPropertyName] = deviceDoor.Name;
                row[colIP.DataPropertyName] = deviceDoor.Ip;
                row[colPort.DataPropertyName] = deviceDoor.Port;
                row[colOpenDoor.DataPropertyName] = deviceDoor.TimeOpen;
                row[colCloseDoor.DataPropertyName] = deviceDoor.TimeClose;
                row[colStatus.DataPropertyName] = deviceDoor.Status;
                row[colLocked.DataPropertyName] = deviceDoor.Locked ? LocalSettings.Instance.CheckSymbol : string.Empty;
                row[colDescription.DataPropertyName] = deviceDoor.Description;

                row.EndEdit();
                dtbDeviceDoorList.Rows.Add(row);
            }
        }

        #endregion

        #region CAB events

        [CommandHandler(OrganizationCommandNames.ShowDeviceDoorMgtMain)]
        public void ShowCardMgtMainHandler(object s, EventArgs e)
        {
            UsrDeviceDoorMgtMain uc = workItem.Items.Get<UsrDeviceDoorMgtMain>(ComponentNames.DeviceDoorMgtMain);
            if (uc == null)
            {
                uc = workItem.Items.AddNew<UsrDeviceDoorMgtMain>(ComponentNames.DeviceDoorMgtMain);
            }
            else if (uc.IsDisposed)
            {
                workItem.Items.Remove(uc);
                uc = workItem.Items.AddNew<UsrDeviceDoorMgtMain>(ComponentNames.DeviceDoorMgtMain);
            }

            workItem.Workspaces[WorkspaceName.MainWorkspace].Show(uc);
            uc.Parent.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuDeviceDoorManager);
        }
        #endregion

        private void tbxFillterName_TextChanged(object sender, EventArgs e)
        {
            String data = FormatCharacterSearch.CheckValue(tbxFillterName.Text.Trim());
            DataView dv = new DataView(dtbDeviceDoorList);
            dv.RowFilter = string.Format("Name LIKE '%{0}%'", data);
            dgvDeviceDoorList.DataSource = dv;
        }
        private void tbxFillterIp_TextChanged(object sender, EventArgs e)
        {
            String data = FormatCharacterSearch.CheckValue(tbxFillterIp.Text.Trim());
            DataView dv = new DataView(dtbDeviceDoorList);
            dv.RowFilter = string.Format("IP LIKE '%{0}%'", data);
            dgvDeviceDoorList.DataSource = dv;
        }
    }
}