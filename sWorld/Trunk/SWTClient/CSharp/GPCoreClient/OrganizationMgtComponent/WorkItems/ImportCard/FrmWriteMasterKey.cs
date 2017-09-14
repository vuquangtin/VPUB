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
using CardChipService;
using CommonControls;
using CommonHelper.Config;
using CommonHelper.Constants;
using CommonHelper.Utils;
using JavaCommunication.Factory;
using Microsoft.Practices.CompositeUI;
using ReaderManager;
using sWorldModel;
using sWorldModel.Exceptions;
using sWorldModel.TransportData;

namespace SystemMgtComponent.WorkItems.ImportCard
{
    public partial class FrmWriteMasterKey : Form
    {
        public FrmWriteMasterKey()
        {
            InitializeComponent();
            Shown += OnFormShown;
            FormClosing += OnFormClosing;
        }

         #region Properties

        private MasterInfoDTO masterInfo;
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

        #region Initialization


        private void OnFormShown(object sender, EventArgs e)
        {
            rm = storageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
            this.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.Name);
            try
            {
                this.masterInfo = OrganizationFactory.Instance.GetChannel().GetMasterInfo(storageService.CurrentSessionId, SystemSettings.Instance.Master);
                if (null != this.masterInfo)
                {
                    cmbMasterInfo.DataSource = new List<MasterInfoDTO>() { this.masterInfo };
                    cmbMasterInfo.ValueMember = "MasterId";
                    cmbMasterInfo.DisplayMember = "Name";
                    cmbMasterInfo.SelectedIndex = 0;
                }
                cardReaderControl.Master = masterInfo;
                cardReaderControl.StorageService = storageService;
                cardReaderControl.InitializeData();
                cardReaderControl.Action = ACTION_ON_CARD.WRITE_MATER_KEY;
                cardReaderControl.Form = this;
            }
            catch (TimeoutException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "TimeOutExceptionMessage"));
                this.Hide();
            }
            catch (FaultException<WcfServiceFault> ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, String.Format("{0}", ex.Detail.Code)));
                this.Hide();
            }
            catch (FaultException ex)
            {
                String msg = MessageValidate.GetMessage(rm, "FaultExceptionMessage")
                   + Environment.NewLine + Environment.NewLine + ex.Message;

                MessageBoxManager.ShowErrorMessageBox(this, msg);
                this.Hide();
            }
            catch (CommunicationException)
            {

                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "CommunicationExceptionMessage"));
                this.Hide();
            }
        }
        #endregion

  
        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBoxManager.ShowQuestionMessageBox(this, MessageValidate.GetMessStop(rm, MessageValidate.SetupKey), MessageValidate.GetConfirm(rm)) != DialogResult.Yes)
            {
                e.Cancel = true;
            }
            else
            {
                cardReaderControl.OnFormClosing();
            }

        }
    }
}
