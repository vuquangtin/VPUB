using CommonControls;
using CommonControls.Custom;
using Microsoft.Practices.CompositeUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sWorldModel.TransportData;
using CommonHelper.Constants;
using sWorldModel;
using System.Resources;
using CommonHelper.Utils;

namespace SystemMgtComponent.WorkItems.ApartmentIntegratingExcel
{
    public partial class FrmReviewData : CommonControls.Custom.CommonDialog
    {

        #region propertion

        private BackgroundWorker bgwLoadGroupWorker;
        private List<ManagerCostApartment> Apartments { get; set; }
        //private List<ALL_KHOA> Faculties { get; set; }
        //private List<ALL_CBCNV> Teachers { get; set; }
        //private List<ALL_CHUC_VU> Positions { get; set; }
        //private List<ALL_NGACH> Scales { get; set; }

        private SystemWorkItem workItem;
        [ServiceDependency]
        public SystemWorkItem WorkItem
        {
            set { workItem = value; }
        }
        //set language
        private ResourceManager rm;
      

        #endregion

        #region Initialization
       
        public FrmReviewData(List<ManagerCostApartment> apartments, ResourceManager rm)
        {
            InitializeComponent();
            this.rmNew = rm;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
            this.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.Name);

           
            this.Apartments = apartments;
            lblTotalRecords.Text = string.Empty;

            dgvRecords.AutoGenerateColumns = true;
            cmbTables.SelectedIndexChanged += cmbTables_SelectedIndexChanged;

            string[] dataSetNames = new string[]
            {
                "NoPhi",
                
            };
            cmbTables.DataSource = dataSetNames;
            cmbTables.SelectedIndex = 0;

       
            btnIntegration.Click += btnNext_Click;
            btnCancel.Click += btnCancel_Click;
       }

      

        private const int WS_SYSMENU = 0x80000;
        private ResourceManager rmNew;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style &= ~WS_SYSMENU;
                return cp;
            }
        }

        #endregion

        #region Form events

        private void cmbTables_SelectedIndexChanged(object sender, EventArgs e)
        {
          //  DataGridViewCellStyle style = new DataGridViewCellStyle();
            List<ManagerCostApartment> duplicates = Apartments.GroupBy(s => s.SubOrgCode).SelectMany(grp => grp.Skip(1)).ToList();
            string selectedTables = cmbTables.SelectedItem.ToString();
            switch (selectedTables)
            {
                case "NoPhi":
                    dgvRecords.DataSource = Apartments;
                    break;
            }

            lblTotalRecords.Text = string.Format(MessageValidate.GetMessage(rm, "messageTotalLineData"), dgvRecords.RowCount);//messageTotalLineData

            for (int i = 0; i < dgvRecords.ColumnCount; i++)
            {
                dgvRecords.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvRecords.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)

        {
            if (this.IsDisposed)
            {
                return;
            }
            if (MessageBoxManager.ShowQuestionMessageBox(this, MessageValidate.GetMessage(rm, "messageIntegrate")) == DialogResult.Yes)
            {
                FrmIntegrateData frmIntegrateData = new FrmIntegrateData(Apartments,rmNew);
                workItem.SmartParts.Add(frmIntegrateData);
                this.Hide();
                frmIntegrateData.ShowDialog(this);
                this.Dispose();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (this.IsDisposed)
            {
                return;
            }
            if (MessageBoxManager.ShowQuestionMessageBox(this, MessageValidate.GetMessage(rm, "messageStopClose")) == DialogResult.Yes)
            {
                this.Dispose();
            }
            else
            {
                DialogResult = System.Windows.Forms.DialogResult.None;
            }
        }



        #endregion 

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            DataGridViewCellStyle CellStyle = new DataGridViewCellStyle();
            CellStyle.BackColor = Color.Salmon;
            List<ManagerCostApartment> duplicates = Apartments.GroupBy(s => s.SubOrgCode).SelectMany(grp => grp.Skip(1)).ToList();
            for (int rowIndex = 0; rowIndex < dgvRecords.RowCount; rowIndex++)
            {
                if (duplicates.Any(d => d.SubOrgCode.Equals(dgvRecords.Rows[rowIndex].Cells[0].Value.ToString())))
                        dgvRecords.Rows[rowIndex].DefaultCellStyle = CellStyle;
            }
           
        }
    }
}
