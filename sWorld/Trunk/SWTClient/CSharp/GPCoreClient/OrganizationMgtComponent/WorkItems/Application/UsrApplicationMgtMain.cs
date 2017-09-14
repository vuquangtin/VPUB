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
using sWorldModel.Model;
using sWorldModel;
using sWorldModel.Exceptions;
using sWorldModel.Filters;
using JavaCommunication;
using JavaCommunication.Factory;
using sWorldModel.TransportData;
using SystemMgtComponent.Constants;
using SystemMgtComponent.WorkItems.Application;
using System.Resources;
using CommonHelper.Utils;

namespace SystemMgtComponent.WorkItems
{
    public partial class UsrApplicationMgtMain : CommonUserControl
    {
        #region Properties

        // Height of filter box when it is hidden
        private int hiddenFilterBoxHeight = 1;
        // The original height of filter box (at startup)
        private int startupFilterBoxHeight;

        private int currentPageIndex = 1;
        private BackgroundWorker bgwLoadAppList;
        private DataTable dtbAppList;
        private List<App> AppList;
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

        public UsrApplicationMgtMain()
        {
            InitializeComponent();
            InitDataGridViewApp();
            RegisterEvent();
        }

        #endregion

        #region CAB events

        [CommandHandler(OrganizationCommandNames.ShowApplicationMgtMain)]
        public void ShowCardMgtMainHandler(object s, EventArgs e)
        {
            UsrApplicationMgtMain uc = workItem.Items.Get<UsrApplicationMgtMain>(ComponentNames.ApplicationMgtComponent);
            if (uc == null)
            {
                uc = workItem.Items.AddNew<UsrApplicationMgtMain>(ComponentNames.ApplicationMgtComponent);
            }
            else if (uc.IsDisposed)
            {
                workItem.Items.Remove(uc);
                uc = workItem.Items.AddNew<UsrApplicationMgtMain>(ComponentNames.ApplicationMgtComponent);
            }

            workItem.Workspaces[WorkspaceName.MainWorkspace].Show(uc);
            uc.Parent.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuAppManager);
        }

        [EventPublication(OrganizationEventTopicNames.ApplicationMgtMainShown)]
        public event EventHandler AppMgtMainShown;

        [EventPublication(OrganizationEventTopicNames.ApplicationMgtMainShown)]
        public event EventHandler AppMgtMainHide;

        #endregion

        #region Form events

        private void OnFormLoad(object s, EventArgs e)
        {
            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
            setLanguage();
            LoadAppList();
        }

        private void setLanguage()
        {
            this.btnAddApp.ToolTipText = MessageValidate.GetMessage(rm, btnAddApp.Name);
            this.btnUpdateApp.ToolTipText = MessageValidate.GetMessage(rm, btnUpdateApp.Name);
            this.btnRemoveApp.ToolTipText = MessageValidate.GetMessage(rm, btnRemoveApp.Name);
            this.btnReloadApp.ToolTipText = MessageValidate.GetMessage(rm, btnReloadApp.Name);

            this.colAppName.HeaderText = MessageValidate.GetMessage(rm, colAppName.Name);
            this.colDescription.HeaderText = MessageValidate.GetMessage(rm, colDescription.Name);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (bgwLoadAppList.IsBusy)
                {
                    bgwLoadAppList.CancelAsync();
                }
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
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
            dtbAppList.Rows.Clear();
            int take = LocalSettings.Instance.RecordsPerPage;
            int skip = (currentPageIndex -1) * take;

            List<App> result = AppList.Skip(skip).Take(take).ToList();
            LoadAppDataGridView(result);

            //pagerPanel1.ShowNumberOfRecords(AppList.Count, result != null ? result.Count : 0, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
            //pagerPanel1.UpdatePagingLinks(AppList.Count, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
        }

        private void OnLoadAppWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            List<App> result = null;
            int totalRecords = 0;
            int take = LocalSettings.Instance.RecordsPerPage;
            int skip = 0;
            currentPageIndex = 1;
            try
            {
                AppList = ApplicationFactory.Instance.GetChannel().GetAppDataList(StorageService.CurrentSessionId, 0, 0);
                
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
                if (AppList != null)
                {
                    result = AppList.Skip(skip).Take(take).ToList();
                    totalRecords = AppList.Count;
                    //pagerPanel1.ShowNumberOfRecords(totalRecords, result != null ? result.Count : 0, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
                    //pagerPanel1.UpdatePagingLinks(totalRecords, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
                }
                e.Result = result;
            }
        }

        private void OnLoadAppWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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
            List<App> result = (List<App>)e.Result;
            LoadAppDataGridView(result);
        }

        private void LoadAppDataGridView(List<App> result)
        {
            foreach (App app in result)
            {
                DataRow row = dtbAppList.NewRow();
                row.BeginEdit();

                row[colAppId.DataPropertyName] = app.Id;
                row[colAppCode.DataPropertyName] = app.AppCode;
                row[colAppName.DataPropertyName] = app.NameApp;
                row[colDescription.DataPropertyName] = app.Description;

                row.EndEdit();
                dtbAppList.Rows.Add(row);
            }
        }

        //[CommandHandler(OrganizationCommandNames.AddOrg)]
        private void btnAddApp_Click(object sender, EventArgs e)
        {
            FrmAddOrEditApp dialog = new FrmAddOrEditApp(FrmAddOrEditApp.ModeAdding);
            workItem.SmartParts.Add(dialog);
            dialog.ShowDialog();
            workItem.SmartParts.Remove(dialog);
            dialog.Dispose();
            LoadAppList();
        }

        //[CommandHandler(OrganizationCommandNames.UpdateOrg)]
        private void btnUpdateApp_Click(object sender, EventArgs e)
        {
            if (dgvAppList.SelectedRows.Count > 0)
            {
                long appId = Convert.ToInt64(dgvAppList.SelectedRows[0].Cells[0].Value.ToString());
                FrmAddOrEditApp dialog = new FrmAddOrEditApp(FrmAddOrEditApp.ModeUpdating, appId);
                workItem.SmartParts.Add(dialog);
                dialog.ShowDialog();
                workItem.SmartParts.Remove(dialog);
                dialog.Dispose();
                LoadAppList();
            }
        }

        private void btnRemoveApp_Click(object sender, EventArgs e)
        {
            bool result;
            if (dgvAppList.SelectedRows.Count == 0)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessSelect(rm, MessageValidate.CancelApp), MessageValidate.GetErrorTitle(rm));
                return;
            }

            //Show confirmation message box
            //"Hủy ứng dụng sẽ làm hủy luôn các ứng dụng con thuộc ứng dụng đó. Bạn có chắc muốn hủy ứng dụng này không?"
            if (MessageBoxManager.ShowQuestionMessageBox(this,MessageValidate.GetMessage(rm,"questionCancel" )) == DialogResult.Yes)
            {
                long appId = Convert.ToInt64(dgvAppList.SelectedRows[0].Cells[0].Value.ToString());
                try
                {
                    result = (int)Status.SUCCESS == ApplicationFactory.Instance.GetChannel().DeleteApp(StorageService.CurrentSessionId, appId);
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
                    LoadAppList();
                    
                }
                else
                {
                    MessageBoxManager.ShowErrorMessageBox(this, ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MessageValidate.AppCancelFail));
                }
            }
        }

        #endregion

        #region Event's Support

        private void InitDataGridViewApp()
        {
            dtbAppList = new DataTable();
            dtbAppList.Columns.Add(colAppId.DataPropertyName);
            dtbAppList.Columns.Add(colAppCode.DataPropertyName);
            dtbAppList.Columns.Add(colAppName.DataPropertyName);
            dtbAppList.Columns.Add(colDescription.DataPropertyName);
            dgvAppList.DataSource = dtbAppList;
        }

        private void RegisterEvent()
        {
            bgwLoadAppList = new BackgroundWorker();
            bgwLoadAppList.WorkerSupportsCancellation = true;
            bgwLoadAppList.DoWork += OnLoadAppWorkerDoWork;
            bgwLoadAppList.RunWorkerCompleted += OnLoadAppWorkerCompleted;

            btnAddApp.Click += btnAddApp_Click;
            btnUpdateApp.Click += btnUpdateApp_Click;
            btnRemoveApp.Click += btnRemoveApp_Click;

            btnReloadApp.Click += (s, e) => LoadAppList();

            //pagerPanel1.LinkLabelClicked += pagerPanel_LinkLabelClicked;

            this.Load += OnFormLoad;
            this.Enter += (s, e) =>
            {
                if (AppMgtMainShown != null)
                {
                    AppMgtMainShown(this, new CabEventArgs(new object[] { ComponentNames.ApplicationMgtComponent }));
                }
            };
            this.Leave += (s, e) =>
            {
                if (AppMgtMainHide != null)
                {
                    AppMgtMainHide(this, new CabEventArgs(new object[] { ComponentNames.ApplicationMgtComponent }));
                }
            };
        }

        private void LoadAppList()
        {
            if (!bgwLoadAppList.IsBusy)
            {
                dtbAppList.Rows.Clear();
                //pagerPanel1.ShowMessage(MessageValidate.GetMessage(rm, "waitLoadData"));
                //pagerPanel1.ShowMessage(MessageValidate.GetMessage(rm, MessageValidate.WaitLoadData));
                bgwLoadAppList.RunWorkerAsync();
            }
        }

        #endregion

    }
}