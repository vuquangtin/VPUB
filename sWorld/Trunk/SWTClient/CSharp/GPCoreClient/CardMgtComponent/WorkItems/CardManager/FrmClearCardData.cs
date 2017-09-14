using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Practices.CompositeUI;
using CommonControls;
using CryptoAlgorithm;
using System.ServiceModel;
using CommonHelper.Utils;
using System.Data;
using System.Drawing;
using sWorldModel.Exceptions;
using sWorldModel;
using JavaCommunication;
using JavaCommunication.Factory;
using CardChipService;
using CommonHelper.Constants;
using sWorldModel.TransportData;
using System.Resources;
using ReaderManager;
using ReaderManager.Model;

namespace CardChipMgtComponent.WorkItems
{
    public partial class FrmClearCardData : Form
    {
      #region Properties

        private ResourceManager rm;

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

        #region Initialization

        public FrmClearCardData()
        {
            InitializeComponent();

            Shown += OnFormShown;
            FormClosing += OnFormClosing;
        }

        private void OnFormShown(object sender, EventArgs e)
        {
            rm = storageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
            this.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.Name);

            try
            {
                cardReaderControl.StorageService = storageService;
                cardReaderControl.InitializeData();
                cardReaderControl.Action = ACTION_ON_CARD.CLEAR_PERSO_DATA;
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
            if (MessageBoxManager.ShowQuestionMessageBox(this, MessageValidate.GetMessStop(rm, MessageValidate.ReadData), MessageValidate.GetConfirm(rm)) != DialogResult.Yes)
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
