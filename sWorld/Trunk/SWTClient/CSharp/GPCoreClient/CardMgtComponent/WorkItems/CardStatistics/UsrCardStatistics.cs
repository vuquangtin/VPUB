using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonControls.Custom;
using System.Collections;
using Microsoft.Practices.CompositeUI.Commands;
using CardChipMgtComponent.Constants;
using CommonHelper.Constants;
using Microsoft.Practices.CompositeUI;
//using WcfServiceCommon;
using CommonControls;
using System.ServiceModel;
using System.Drawing.PieChart;
using sWorldModel.Model;
using sWorldModel.Exceptions;
using sWorldModel;
using JavaCommunication;
using JavaCommunication.Factory;
using sWorldModel.TransportData;
using CommonHelper.Config;
using System.Resources;
using CommonHelper.Utils;

namespace CardChipMgtComponent.WorkItems
{
    public partial class UsrCardStatistics : CommonUserControl
    {
        #region Properties

        private BackgroundWorker bgwStatistics;
        private ResourceManager rm;

        private long masterId;
        private long partnerId;

        private int Perso = 6;
        private int NotPerso = 7;

        private int alpha = 125;

        private Color[] PhysicalColors
        {
            get
            {
                ArrayList colors = new ArrayList();
                colors.Add(Color.FromArgb(alpha, btnNormalColor.BackColor));
                colors.Add(Color.FromArgb(alpha, btnLostColor.BackColor));
                colors.Add(Color.FromArgb(alpha, btnBrokenColor.BackColor));
                return (Color[])colors.ToArray(typeof(Color));
            }
        }

        private Color[] PersoColors
        {
            get
            {
                ArrayList colors = new ArrayList();
                colors.Add(Color.FromArgb(alpha, btnNotPersoColor.BackColor));
                colors.Add(Color.FromArgb(alpha, btnPersoColor.BackColor));
                return (Color[])colors.ToArray(typeof(Color));
            }
        }

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

        #region Constructors

        public UsrCardStatistics()
        {
            InitializeComponent();

            bgwStatistics = new BackgroundWorker();
            bgwStatistics.WorkerSupportsCancellation = true;
            bgwStatistics.DoWork += bgwStatistics_DoWork;

            btnReloadStatistics.Click += (s, e) => Statistics();

            pieChart1.LeftMargin = 20;
            pieChart1.RightMargin = 20;
            pieChart1.TopMargin = 20;
            pieChart1.BottomMargin = 20;
            pieChart1.SliceRelativeHeight = 0.25F;
            pieChart1.EdgeLineWidth = 1.0F;
            pieChart1.EdgeColorType = EdgeColorType.DarkerThanSurface;

            pieChart2.LeftMargin = 20;
            pieChart2.RightMargin = 20;
            pieChart2.TopMargin = 20;
            pieChart2.BottomMargin = 20;

            pieChart2.SliceRelativeHeight = 0.25F;
            pieChart2.EdgeLineWidth = 1.0F;
            pieChart2.EdgeColorType = EdgeColorType.DarkerThanSurface;
        }

        #endregion

        #region Form events

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            lblBrokenAmount.Text = lblLostAmount.Text = lblNormalAmount.Text = lblPhysTotalAmount.Text = lblNotPersoAmount.Text = lblPersoAmount.Text = lblPersoTotalAmount.Text = string.Empty;
            LoadPartnerInfo();
            Statistics();
            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
            SetLanguages();
        }

        private void SetLanguages()
        {
            this.btnReloadStatistics.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnReloadStatistics.Name);
        }

        #endregion

        #region CAB events

        [CommandHandler(CardCommandNames.ShowCardStatistics)]
        public void ShowCardMgtMainHandler(object s, EventArgs e)
        {
            UsrCardStatistics uc = workItem.Items.Get<UsrCardStatistics>(ComponentNames.CardStatisticsComponent);
            if (uc == null)
            {
                uc = workItem.Items.AddNew<UsrCardStatistics>(ComponentNames.CardStatisticsComponent);
            }
            else if (uc.IsDisposed)
            {
                workItem.Items.Remove(uc);
                uc = workItem.Items.AddNew<UsrCardStatistics>(ComponentNames.CardStatisticsComponent);
            }

            workItem.Workspaces[WorkspaceName.MainWorkspace].Show(uc);
            uc.Parent.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuCardStatistics);
        }

        #endregion

        #region Controls events

        #region PartnerInfo

        private void LoadPartnerInfo()
        {
            try
            {
                var masterInfo = OrganizationFactory.Instance.GetChannel().GetMasterInfo(StorageService.CurrentSessionId, SystemSettings.Instance.Master);
                masterId = masterInfo.MasterId;
                var partnerInfo = OrganizationFactory.Instance.GetChannel().GetMasterInfo(StorageService.CurrentSessionId, SystemSettings.Instance.Partner);
                partnerId = partnerInfo.MasterId;
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

        #endregion

        private void mniSetupChart_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
            ContextMenuStrip menuStrip = menuItem.Owner as ContextMenuStrip;
            PieChartControl pie = menuStrip.SourceControl as PieChartControl;

            FrmPieChartSetup frmSetup = FrmPieChartSetup.Instance;
            frmSetup.ChartMargin = new Padding((int)pie.LeftMargin, (int)pie.TopMargin, (int)pie.RightMargin, (int)pie.BottomMargin);
            frmSetup.ChartShadowStyle = pie.ShadowStyle;
            frmSetup.ChartHeight = pie.SliceRelativeHeight;
            frmSetup.EdgeColorType = pie.EdgeColorType;
            frmSetup.EdgeLineWidth = pie.EdgeLineWidth;
            frmSetup.ChartAngle = pie.InitialAngle;
            frmSetup.ShowDialog();

            if (frmSetup.DialogResult == DialogResult.OK)
            {
                pie.LeftMargin = frmSetup.ChartMargin.Left;
                pie.TopMargin = frmSetup.ChartMargin.Top;
                pie.RightMargin = frmSetup.ChartMargin.Right;
                pie.BottomMargin = frmSetup.ChartMargin.Bottom;
                pie.ShadowStyle = frmSetup.ChartShadowStyle;
                pie.SliceRelativeHeight = frmSetup.ChartHeight;
                pie.EdgeColorType = frmSetup.EdgeColorType;
                pie.EdgeLineWidth = frmSetup.EdgeLineWidth;
                pie.InitialAngle = frmSetup.ChartAngle;
            }
        }

        private void btnBrokenColor_Click(object sender, EventArgs e)
        {
            if (dlgColorChooser.ShowDialog() == DialogResult.OK)
            {
                btnBrokenColor.BackColor = dlgColorChooser.Color;
                pieChart1.Colors = PhysicalColors;
            }
        }

        private void btnLostColor_Click(object sender, EventArgs e)
        {
            if (dlgColorChooser.ShowDialog() == DialogResult.OK)
            {
                btnLostColor.BackColor = dlgColorChooser.Color;
                pieChart1.Colors = PhysicalColors;
            }
        }

        private void btnNormalColor_Click(object sender, EventArgs e)
        {
            if (dlgColorChooser.ShowDialog() == DialogResult.OK)
            {
                btnNormalColor.BackColor = dlgColorChooser.Color;
                pieChart1.Colors = PhysicalColors;
            }
        }

        private void btnNotPersoColor_Click(object sender, EventArgs e)
        {
            if (dlgColorChooser.ShowDialog() == DialogResult.OK)
            {
                btnNotPersoColor.BackColor = dlgColorChooser.Color;
                pieChart2.Colors = PersoColors;
            }
        }

        private void btnPersoColor_Click(object sender, EventArgs e)
        {
            if (dlgColorChooser.ShowDialog() == DialogResult.OK)
            {
                btnPersoColor.BackColor = dlgColorChooser.Color;
                pieChart2.Colors = PersoColors;
            }
        }

        private void cmbPartnerInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //partnerId = Convert.ToInt64(cmbPartnerInfo.SelectedValue.ToString());
            Statistics();
        }

        private void Statistics()
        {
            if (!bgwStatistics.IsBusy)
            {
                lblLoading1.Visible = true;
                lblLoading2.Visible = true;

                pieChart1.Values = null;
                pieChart2.Values = null;



                bgwStatistics.RunWorkerAsync();
            }
        }

        private void bgwStatistics_DoWork(object sender, DoWorkEventArgs e)
        {
            List<CardStatisticsData> result = null;

            // Call service to get statistics data group by physical status
            try
            {
                result = CardChipFactory.Instance.GetChannel().StatisticCardChipByStatus(storageService.CurrentSessionId, masterId, partnerId);
            }
            catch (TimeoutException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "TimeOutExceptionMessage"));
                return;
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
                return;
            }

            // Draw first pie chart
            if (result != null)
            {
                DrawFirstPieChart(result);
                DrawSecondPieChart(result);
            }
        }

        private void DrawFirstPieChart(List<CardStatisticsData> data)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<List<CardStatisticsData>>(DrawFirstPieChart), data);
                return;
            }

            // Hide loading label
            lblLoading1.Visible = false;

            // Set values
            ArrayList values = new ArrayList();
            ArrayList texts = new ArrayList();

            CardStatisticsData item = data.Find(e => e.Status == (int)CardPhysicalStatus.Broken);
            decimal brokenAmount = item == null ? 0 : (decimal)item.Amount;
            decimal totalAmount = brokenAmount;

            item = data.Find(e => e.Status == (int)CardPhysicalStatus.Lost);
            decimal lostAmount = item == null ? 0 : (decimal)item.Amount;
            totalAmount += lostAmount;

            item = data.Find(e => e.Status == (int)CardPhysicalStatus.Normal);
            decimal normalAmount = item == null ? 0 : (decimal)item.Amount;
            totalAmount += normalAmount;
            
            lblBrokenAmount.Text = brokenAmount.ToString();
            lblLostAmount.Text = lostAmount.ToString();
            lblNormalAmount.Text = normalAmount.ToString();
            lblPhysTotalAmount.Text = totalAmount.ToString();

            // Set Texts
            int brokenPercentage = 0, lostPercentage = 0, normalPercentage = 0;
            if (brokenAmount > 0)
            {
                values.Add(brokenAmount);
                brokenPercentage = (int)(brokenAmount / totalAmount * 100);
                texts.Add(string.Format("{0} ({1} %)", CardPhysicalStatus.Broken.GetName(), brokenPercentage));
            }
            if (lostAmount > 0)
            {
                values.Add(lostAmount);
                lostPercentage = (int)(lostAmount / totalAmount * 100);
                texts.Add(string.Format("{0} ({1} %)", MessageValidate.GetMessage(rm,"lostcard"), lostPercentage));
            }
            else
            {
                values.Add(normalAmount);
                normalPercentage = 100 - brokenPercentage - lostPercentage;
                texts.Add(string.Format("{0} ({1} %)", MessageValidate.GetMessage(rm, "normal"), normalPercentage));
            }

            pieChart1.Values = (decimal[])values.ToArray(typeof(decimal));

            // Set Colors
            pieChart1.Colors = PhysicalColors;

            // Set Texts
            pieChart1.Texts = (string[])texts.ToArray(typeof(string));
        }

        private void DrawSecondPieChart(List<CardStatisticsData> data)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<List<CardStatisticsData>>(DrawSecondPieChart), data);
                return;
            }

            // Hide loading label
            lblLoading2.Visible = false;

            // Set values
            ArrayList values = new ArrayList();

            CardStatisticsData item = data.Find(e => e.Status ==NotPerso);
            decimal notPersoAmount = item == null ? 0 : (decimal)item.Amount;
            decimal totalAmount = notPersoAmount;


            item = data.Find(e => e.Status == Perso);
            decimal persoAmount = item == null ? 0 : (decimal)item.Amount;
            totalAmount += persoAmount;
            
            lblNotPersoAmount.Text = notPersoAmount.ToString();
            lblPersoAmount.Text = persoAmount.ToString();
            lblPersoTotalAmount.Text = totalAmount.ToString();

            // Set Texts
            ArrayList texts = new ArrayList();
            int notPersoPercentage = 0, persoPercentage = 0;
            if (totalAmount > 0)
            {
                values.Add(notPersoAmount);
                notPersoPercentage = (int)(notPersoAmount / totalAmount * 100);
                texts.Add(string.Format(MessageValidate.GetMessage(rm, "messageNotRelease"), notPersoPercentage));// messageNotRelease

                values.Add(persoAmount);
                persoPercentage = 100 - notPersoPercentage;
                texts.Add(string.Format(MessageValidate.GetMessage(rm, "messageRelease"), persoPercentage));//messageRelease
            }

            pieChart2.Values = (decimal[])values.ToArray(typeof(decimal));

            // Set Colors
            pieChart2.Colors = PersoColors;

            pieChart2.Texts = (string[])texts.ToArray(typeof(string));
        }

        #endregion


    }
}
