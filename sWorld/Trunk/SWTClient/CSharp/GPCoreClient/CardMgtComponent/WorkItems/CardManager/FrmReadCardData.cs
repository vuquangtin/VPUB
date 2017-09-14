using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using CommonControls.Custom;
using CryptoAlgorithm;
using Microsoft.Practices.CompositeUI;
using CommonControls;
using CommonHelper.Utils;
using System.ServiceModel;
using System.Collections.Specialized;
using sWorldModel.Parser;
using sWorldModel.Model;
using sWorldModel;
using sWorldModel.Exceptions;
using sWorldModel.MethodData;
using JavaCommunication;
using JavaCommunication.Factory;
using CommonHelper.Config;
using sWorldModel.TransportData;
using CardChipService;
using CommonHelper.Constants;
using System.Text;
using System.Resources;
using System.Linq;
using ReaderManager.Model;
using ReaderManager;
using System.Threading;
using System.Globalization;

namespace CardChipMgtComponent.WorkItems
{
    public partial class FrmReadCardData : Form
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

        public FrmReadCardData()
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
                cardReaderControl.Action = ACTION_ON_CARD.READ_PERSO_DATA;
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