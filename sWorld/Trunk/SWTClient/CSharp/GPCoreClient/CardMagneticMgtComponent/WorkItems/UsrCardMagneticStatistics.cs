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
using CommonHelper.Constants;
using Microsoft.Practices.CompositeUI;
using CommonControls;
using System.ServiceModel;
using sWorldModel.Exceptions;
using sWorldModel;
using JavaCommunication;
using JavaCommunication.Factory;
using Microsoft.Practices.CompositeUI.EventBroker;
using System.Drawing.PieChart;
using sWorldModel.TransportData;
using CardMagneticMgtComponent.WorkItems;
using CardMagneticMgtComponent.Constants;
using CommonHelper.Config;

namespace CardMagneticMgtComponent.WorkItems
{
    public partial class UsrCardMagneticStatistics : UserControl
    {
        #region Properties

        private MasterInfoDTO masterInfo;
        private List<PartnerInfoDTO> partnerInfoList;

        private BackgroundWorker bgwStatistics;

        private PartnerInfoDTO partnerInfoSelected;

        private CardTypeDTO cardTypeInfoSelect;

        private int alpha = 125;
        
        private String cardType;

        private long masterId, partnerId;

        private Color[] PhysicalColors
        {
            get
            {
                ArrayList colors = new ArrayList();
                colors.Add(Color.FromArgb(alpha, btnBrokenColor.BackColor));
                colors.Add(Color.FromArgb(alpha, btnLostColor.BackColor));
                colors.Add(Color.FromArgb(alpha, btnNormalColor.BackColor));
                colors.Add(Color.FromArgb(alpha, btnLockColor.BackColor));
                colors.Add(Color.FromArgb(alpha, btnExpiredColor.BackColor));
                colors.Add(Color.FromArgb(alpha,btnCancelColor.BackColor));
                return (Color[])colors.ToArray(typeof(Color));
            }
        }

        private Color[] PersoColors
        {
            get
            {
                ArrayList colors = new ArrayList();
                colors.Add(Color.FromArgb(alpha, btnActiveColor.BackColor));
                colors.Add(Color.FromArgb(alpha, btnDeActiveColor.BackColor));
                return (Color[])colors.ToArray(typeof(Color));
            }
        }

        private Color[] PrintColors
        {
            get
            {
                ArrayList colors = new ArrayList();
                colors.Add(Color.FromArgb(alpha, btnPrintColor.BackColor));
                colors.Add(Color.FromArgb(alpha, btnNoPrintColor.BackColor));
                return (Color[])colors.ToArray(typeof(Color));
            }
        }

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

        #endregion

        #region Constructors

        public UsrCardMagneticStatistics()
        {
            InitializeComponent();

            bgwStatistics = new BackgroundWorker();
            bgwStatistics.WorkerSupportsCancellation = true;
            bgwStatistics.DoWork += bgwStatistics_DoWork;

            this.cmbPartnerInfo.SelectedIndexChanged += cmbPartnerInfo_SelectedIndexChanged;
            this.cmbCardType.SelectedIndexChanged += cmbCardType_SelectedIndexChanged;

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

            pieChart3.LeftMargin = 20;
            pieChart3.RightMargin = 20;
            pieChart3.TopMargin = 20;
            pieChart3.BottomMargin = 20;

            pieChart3.SliceRelativeHeight = 0.25F;
            pieChart3.EdgeLineWidth = 1.0F;
            pieChart3.EdgeColorType = EdgeColorType.DarkerThanSurface;

            this.Enter += (s, e) =>
            {
                if (CardMagneticStatisticsShown != null)
                {
                    CardMagneticStatisticsShown(this, new CabEventArgs(new object[] { CardMagneticCommandNames.CardMagneticStatistics }));
                }
            };
        }

        #endregion

        #region Form events

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadMasterInfo();
            //load infor partner
            LoadPartnerInfo();
            if (partnerInfoList == null)
                LoadCardType(masterInfo.cardtypes);
           lblBrokenAmount.Text = lblLostAmount.Text = lblPrintTotalAmount.Text = lblNoPrintAmount.Text = lblPrintAmount.Text = lblExpiredAmount.Text = lblNormalAmount.Text = lblActiveAmount.Text = lblDeActiveAmount.Text = lblCancelAmount.Text = lblNormalAmount.Text = lblLockAmount.Text = lblPhysTotalAmount.Text = lblPersoTotalAmount.Text = string.Empty;
            //    Statistics();
        }

        private void cmbPartnerInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            partnerInfoSelected = cmbPartnerInfo.SelectedItem as PartnerInfoDTO;
            if (partnerInfoSelected != null)
                LoadCardType(partnerInfoSelected.cardtypes);
        }

        private void cmbCardType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCardType.SelectedIndex >= 0)
                cardTypeInfoSelect = cmbCardType.SelectedItem as CardTypeDTO;
        }

        private void LoadMasterInfo()
        {
            try
            {
                this.masterInfo = OrganizationFactory.Instance.GetChannel().GetMasterInfo(StorageService.CurrentSessionId, SystemSettings.Instance.Master);
                cmbMasterInfo.DataSource = new List<MasterInfoDTO>() { this.masterInfo };
                cmbMasterInfo.ValueMember = "MasterId";
                cmbMasterInfo.DisplayMember = "Name";
                cmbMasterInfo.SelectedIndex = 0;
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
            //aes = new AesEncryption(this.masterInfo.MasterKey);
        }

        private void LoadPartnerInfo()
        {
            try
            {
                if (masterInfo == null) return;

                this.partnerInfoList = OrganizationFactory.Instance.GetChannel().GetPartnerInfo(StorageService.CurrentSessionId, masterInfo.MasterId, SystemSettings.Instance.Partner);
                cmbPartnerInfo.DataSource = this.partnerInfoList;
                cmbPartnerInfo.ValueMember = "PartnerId";
                cmbPartnerInfo.DisplayMember = "Name";
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
            //aes = new AesEncryption(this.masterInfo.MasterKey);
        }

        private void LoadCardType(List<CardTypeDTO> cardTypes)
        {
            cmbCardType.DataSource = cardTypes;
            cmbCardType.ValueMember = "prefix";
            cmbCardType.DisplayMember = "cardTypeName";
            cmbCardType.SelectedIndex = 0;
        }

        #endregion

        #region CAB events

        [EventPublication(CardMagneticEventTopicNames.CardMagneticStatisticsShown)]
        public event EventHandler CardMagneticStatisticsShown;

        [CommandHandler(CardMagneticCommandNames.CardMagneticStatistics)]
        public void ShowCardMgtMainHandler(object s, EventArgs e)
        {
            UsrCardMagneticStatistics uc = workItem.Items.Get<UsrCardMagneticStatistics>(ComponentNames.CardMagneticMgtStatisticsComponent);
            if (uc == null)
            {
                uc = workItem.Items.AddNew<UsrCardMagneticStatistics>(ComponentNames.CardMagneticMgtStatisticsComponent);
            }
            else if (uc.IsDisposed)
            {
                workItem.Items.Remove(uc);
                uc = workItem.Items.AddNew<UsrCardMagneticStatistics>(ComponentNames.CardMagneticMgtStatisticsComponent);
            }

            workItem.Workspaces[WorkspaceName.MainWorkspace].Show(uc);
            uc.Parent.Text = "Thống kê thẻ từ";
        }

        #endregion

        #region Controls events

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

        private void btnCancelColor_Click(object sender, EventArgs e)
        {
            if (dlgColorChooser.ShowDialog() == DialogResult.OK)
            {
                btnCancelColor.BackColor = dlgColorChooser.Color;
                pieChart1.Colors = PhysicalColors;
            }
        }

        private void btnExpiredColor_Click(object sender, EventArgs e)
        {
            if (dlgColorChooser.ShowDialog() == DialogResult.OK)
            {
                btnExpiredColor.BackColor = dlgColorChooser.Color;
                pieChart1.Colors = PhysicalColors;
            }
        }

        private void btnLockColor_Click(object sender, EventArgs e)
        {
            if (dlgColorChooser.ShowDialog() == DialogResult.OK)
            {
                btnLockColor.BackColor = dlgColorChooser.Color;
                pieChart1.Colors = PhysicalColors;
            }
        }

        private void btnPrintColor_Click(object sender, EventArgs e)
        {
            if (dlgColorChooser.ShowDialog() == DialogResult.OK)
            {
                btnPrintColor.BackColor = dlgColorChooser.Color;
                pieChart3.Colors = PrintColors;
            }
        }

        private void btnNoPrintColor_Click(object sender, EventArgs e)
        {
            if (dlgColorChooser.ShowDialog() == DialogResult.OK)
            {
                btnNoPrintColor.BackColor = dlgColorChooser.Color;
                pieChart3.Colors = PrintColors;
            }
        }

        private void btnActiveColor_Click(object sender, EventArgs e)
        {
            if (dlgColorChooser.ShowDialog() == DialogResult.OK)
            {
                btnActiveColor.BackColor = dlgColorChooser.Color;
                pieChart2.Colors = PersoColors;
            }
        }

        private void btnDeActiveColor_Click(object sender, EventArgs e)
        {
            if (dlgColorChooser.ShowDialog() == DialogResult.OK)
            {
                btnDeActiveColor.BackColor = dlgColorChooser.Color;
                pieChart2.Colors = PersoColors;
            }
        }

        # region Statistics

        private void Statistics()
        {
            if (!bgwStatistics.IsBusy)
            {
                lblLoading1.Visible = true;
                lblLoading2.Visible = true;
                lblLoading3.Visible = true;

                pieChart1.Values = null;
                pieChart2.Values = null;
                pieChart3.Values = null;

                masterId = Convert.ToInt64(cmbMasterInfo.SelectedValue);
                partnerId = Convert.ToInt64(cmbPartnerInfo.SelectedValue);
                cardType = cmbCardType.SelectedValue.ToString();

                bgwStatistics.RunWorkerAsync();
            }
        }

        private void bgwStatistics_DoWork(object sender, DoWorkEventArgs e)
        {
            List<CardStatisticsData> result = null;

            // Call service to get statistics data group by physical status
            try
            {
                result = CardMagneticFactory.Instance.GetChannel().StatisticCardMagneticStatus(storageService.CurrentSessionId,
                    masterId,
                    partnerId, 
                    cardType);
            }
            catch (TimeoutException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.TimeOutExceptionMessage);
                return;
            }
            catch (FaultException<WcfServiceFault> ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
            }
            catch (FaultException ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.FaultExceptionMessage
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
            }
            catch (CommunicationException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.CommunicationExceptionMessage);
                return;
            }

           //  Draw first pie chart
            if (result != null)
            {
                DrawPhysicalPieChart(result);
                DrawActivePieChart(result);
                DrawPrintedPieChart(result);
            }
            result = null;
          
        }

        private void DrawPhysicalPieChart(List<CardStatisticsData> data)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<List<CardStatisticsData>>(DrawPhysicalPieChart), data);
                return;
            }

            // Hide loading label
            lblLoading1.Visible = false;

           //  Set values
            ArrayList values = new ArrayList();
            ArrayList texts = new ArrayList();

            //
            CardStatisticsData item = data.Find(e => e.Status == (int)CardMagneticPhysicalStatus.Broken);

            decimal brokenAmount = item == null ? 0 : (decimal)item.Amount;
            decimal totalAmount = brokenAmount;
            
            item = data.Find(e => e.Status == (int)CardMagneticPhysicalStatus.Lost);
            decimal lostAmount = item == null ? 0 : (decimal)item.Amount;
            totalAmount += lostAmount;

            item = data.Find(e => e.Status == (int)CardMagneticPhysicalStatus.Normal);
            decimal normalAmount = item == null ? 0 : (decimal)item.Amount;
            totalAmount += normalAmount;

            // Những trạng thái thuộc về CardMagneticStatus
            CardStatisticsData item1 = data.Find(e => e.Status == (int)CardMagneticStatus.Cancel);
            decimal cancelAmount = item1 == null ? 0 : (decimal)item1.Amount;
            totalAmount += cancelAmount;

            item1 = data.Find(e => e.Status == (int)CardMagneticStatus.Expired);
            decimal expiredAmount = item1 == null ? 0 : (decimal)item1.Amount;
            totalAmount += expiredAmount;

            item1 = data.Find(e => e.Status == (int)CardMagneticStatus.Lock);
            decimal lockAmount = item1 == null ? 0 : (decimal)item1.Amount;
            totalAmount += item1 == null ? 0 : (decimal)item1.Amount;
  
            lblBrokenAmount.Text = brokenAmount.ToString();
            lblLostAmount.Text = lostAmount.ToString();
            lblNormalAmount.Text = normalAmount.ToString();
            lblCancelAmount.Text = cancelAmount.ToString();
            lblLockAmount.Text = lockAmount.ToString();
            lblExpiredAmount.Text = expiredAmount.ToString();

            lblPhysTotalAmount.Text = totalAmount.ToString();

          //   Set Texts

            if (totalAmount > 0)
            {

                decimal brokenPercentage = (brokenAmount / totalAmount * 100);
                if (brokenPercentage > 0)
                {
                    texts.Add(string.Format("{0} ({1} %)", CardMagneticPhysicalStatus.Broken.GetName(), Math.Round(brokenPercentage, 2)));
                    values.Add(brokenAmount);
                }
                decimal lostPercentage = (lostAmount / totalAmount * 100);
                if (lostPercentage > 0)
                {
                    texts.Add(string.Format("{0} ({1} %)", CardMagneticPhysicalStatus.Lost.GetName(), Math.Round(lostPercentage, 2)));
                    values.Add(lostAmount);
                }

                decimal cancelPercentage = (cancelAmount / totalAmount * 100);
                if (cancelPercentage > 0)
                {
                    texts.Add(string.Format("{0} ({1} %)", CardMagneticStatus.Cancel.GetName(), Math.Round(cancelPercentage, 2)));
                    values.Add(cancelAmount);
                }

                decimal expiredPercentage = (expiredAmount / totalAmount * 100);
                if (expiredPercentage > 0)
                {
                    texts.Add(string.Format("{0} ({1} %)", CardMagneticStatus.Expired.GetName(), Math.Round(expiredAmount, 2)));
                    values.Add(expiredAmount);
                }

                decimal lockPercentage = (lockAmount / totalAmount * 100);
                if (lockPercentage > 0)
                {
                    texts.Add(string.Format("{0} ({1} %)", CardMagneticStatus.Lock.GetName(), Math.Round(lockPercentage, 2)));
                    values.Add(lockAmount);
                }

                decimal normalPercentage = (normalAmount / totalAmount * 100);
                if (normalPercentage > 0)
                {
                    texts.Add(string.Format("{0} ({1} %)", CardMagneticPhysicalStatus.Normal.GetName(), Math.Round(normalPercentage, 2)));
                    values.Add(normalAmount);
                }

                pieChart1.Values = (decimal[])values.ToArray(typeof(decimal));
               //  Set Colors
                pieChart1.Colors = PhysicalColors;
              //   Set Texts
                pieChart1.Texts = (string[])texts.ToArray(typeof(string));

            }
        }

        private void DrawActivePieChart(List<CardStatisticsData> data)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<List<CardStatisticsData>>(DrawActivePieChart), data);
                return;
            }

           //  Hide loading label
            lblLoading2.Visible = false;

           //  Set values
            ArrayList values = new ArrayList();
            ArrayList texts = new ArrayList();

            CardStatisticsData item = data.Find(e => e.Status == (int)CardMagneticStatus.Actived);

            decimal activeAmount = item == null ? 0 : (decimal)item.Amount;
            decimal totalAmount = activeAmount;


            item = data.Find(e => e.Status == (int)CardMagneticStatus.DeActived);
            decimal deactiveAmount = item == null ? 0 : (decimal)item.Amount;
            totalAmount += deactiveAmount;
           

            lblActiveAmount.Text = activeAmount.ToString();
            lblDeActiveAmount.Text = deactiveAmount.ToString();
            
            lblPersoTotalAmount.Text = totalAmount.ToString();

            if (totalAmount >0)
            {
                decimal activePercentage = (activeAmount / totalAmount * 100);
                if (activePercentage > 0)
                {
                    texts.Add(string.Format("{0} ({1} %)", CardMagneticStatus.Actived.GetName(), Math.Round(activePercentage, 2)));
                    values.Add(activeAmount);
                }

                decimal deactivePercentage = (deactiveAmount / totalAmount * 100);
                if (deactivePercentage > 0)
                {
                    texts.Add(string.Format("{0} ({1} %)", CardMagneticStatus.DeActived.GetName(), Math.Round(deactivePercentage, 2)));
                    values.Add(deactiveAmount);
                }

                pieChart2.Values = (decimal[])values.ToArray(typeof(decimal));

                // Set Colors
                pieChart2.Colors = PersoColors;

                 //Set Texts
                pieChart2.Texts = (string[])texts.ToArray(typeof(string));

            }
        }

        private void DrawPrintedPieChart(List<CardStatisticsData> data)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<List<CardStatisticsData>>(DrawPrintedPieChart), data);
                return;
            }

            // Hide loading label
            lblLoading3.Visible = false;

            // Set values
            ArrayList values = new ArrayList();
            ArrayList texts = new ArrayList();

            CardStatisticsData item = data.Find(e => e.Status == (int)CardMageneticPrintedStatus.Printed);

            decimal printAmount = item == null ? 0 : (decimal)item.Amount;
            decimal totalAmount = printAmount;

            item = data.Find(e => e.Status == (int)CardMageneticPrintedStatus.NotPrinted);
            decimal notprintAmount = item == null ? 0 : (decimal)item.Amount;
            totalAmount += notprintAmount;

            lblPrintAmount.Text = printAmount.ToString();
            lblNoPrintAmount.Text = notprintAmount.ToString();

            lblPrintTotalAmount.Text = totalAmount.ToString();

            if (totalAmount > 0)
            {
                decimal printPercentage = (printAmount / totalAmount * 100);
                if (printPercentage > 0)
                {
                    texts.Add(string.Format("{0} ({1} %)", CardMageneticPrintedStatus.Printed.GetName(), Math.Round(printPercentage, 2)));
                    values.Add(printAmount);
                }

                decimal notprintPercentage = (notprintAmount / totalAmount * 100);
                if (notprintPercentage > 0)
                {
                    texts.Add(string.Format("{0} ({1} %)", CardMageneticPrintedStatus.NotPrinted.GetName(), Math.Round(notprintPercentage, 2)));
                    values.Add(notprintAmount);
                }

                pieChart3.Values = (decimal[])values.ToArray(typeof(decimal));

                // Set Colors
                pieChart3.Colors = PrintColors;

                // Set Texts
                pieChart3.Texts = (string[])texts.ToArray(typeof(string));

            }
        }

        #endregion

        #endregion

      

    }
}
