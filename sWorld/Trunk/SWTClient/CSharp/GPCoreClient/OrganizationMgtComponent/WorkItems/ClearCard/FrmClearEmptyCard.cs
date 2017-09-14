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
using CommonControls;
using CommonHelper.Config;
using CommonHelper.Constants;
using CommonHelper.Utils;
using JavaCommunication.Factory;
using Microsoft.Practices.CompositeUI;
using sWorldModel;
using sWorldModel.Exceptions;
using sWorldModel.TransportData;

namespace SystemMgtComponent.WorkItems.ClearCard
{
    public partial class FrmClearEmptyCard : Form
    {
        #region Properties

        //private AesEncryption aes;
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

        public FrmClearEmptyCard()
        {
            InitializeComponent();

            Shown += OnFormShown;
            FormClosing += OnFormClosing;
        }

        private void OnFormShown(object sender, EventArgs e)
        {
            rm = storageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
            this.Text = MessageValidate.GetMessage(rm, this.Name);

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
                cardReaderControl.Action = ACTION_ON_CARD.CLEAR_EMPTY_CARD;
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
            if (MessageBoxManager.ShowQuestionMessageBox(this, MessageValidate.GetMessStop(rm, MessageValidate.ClearData), MessageValidate.GetConfirm(rm)) != DialogResult.Yes)
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
