using CommonControls;
using CommonHelper.Config;
using CommonHelper.Utils;
using System;
using System.Windows.Forms;
using System.Linq;
using Microsoft.Practices.CompositeUI;
using SystemMgtComponent.WorkItems;
using System.Resources;
using sWorldModel;
using CommonHelper.Constants;

namespace SystemMgtComponent.WorkItems.ApartmentIntegratingExcel
{
    public partial class FrmConnectionConfig : CommonControls.Custom.CommonDialog
    {
        public ResourceManager rm;
        private SystemWorkItem workItem;
        [ServiceDependency]
        public SystemWorkItem WorkItem
        {
            set { workItem = value; }
        }
       
        public string FilePath { get { return txtInputFilePath.Text; } }


        public int FirstRowIndex
        {
            get { return Convert.ToInt32(tbxStartRowIndex.Text) - 1; }
        }

        public long SubOrgId { set; get; }
        public int SubOrgCodeIndex
        {
            get { return cmbSubOrgId.SelectedIndex; }
        }

        public int NameHeadApartmentdIndex
        {
            get { return cmbNameHeadApartment.SelectedIndex; }
        }

        public int PayManagerIndex
        {
            get { return cmbPayManager.SelectedIndex; }
        }

        public int PayWaterIndex
        {
            get { return cmbPayWater.SelectedIndex; }
        }

        public int DayPayIndex
        {
            get { return cmbDayPay.SelectedIndex; }
        }

        public int ManagerCostOldIndex
        {
            get { return cmbManagerCostOld.SelectedIndex; }
        }

        public int SumMoneyIndex
        {
            get { return cmbSumMoney.SelectedIndex; }
        }


        public FrmConnectionConfig(ResourceManager rm)
        {
            InitializeComponent();
            string[] cols = ExcelUtils.GenerateColumnCaptions(26);
            cmbSubOrgId.DataSource = cols.Clone();
            cmbNameHeadApartment.DataSource = cols.Clone();
            cmbPayManager.DataSource = cols.Clone();
            cmbPayWater.DataSource = cols.Clone();
            cmbDayPay.DataSource = cols.Clone();
            cmbManagerCostOld.DataSource = cols.Clone();
            cmbSumMoney.DataSource = cols.Clone();

        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
           
            cmbSubOrgId.SelectedIndex = LocalSettings.Instance.SubOrgIdCol;
            cmbNameHeadApartment.SelectedIndex = LocalSettings.Instance.NameHeadApartmentCol;
            cmbPayManager.SelectedIndex = LocalSettings.Instance.PayManagerCol;
            cmbPayWater.SelectedIndex = LocalSettings.Instance.PayWaterCol;
            cmbDayPay.SelectedIndex = LocalSettings.Instance.DayPayCol;
            cmbManagerCostOld.SelectedIndex = LocalSettings.Instance.UpdateTimeCol;
            cmbSumMoney.SelectedIndex = LocalSettings.Instance.SumMoneyCol;

            tbxStartRowIndex.Text = (LocalSettings.Instance.ApartmentFirstRow + 1).ToString();
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "MS Excel (*.xls)|*.xls";
            dialog.InitialDirectory = "";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtInputFilePath.Text = dialog.FileName;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(FilePath))
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "ExcelPath"));//ExcelPath
                return;
            }

            //int[] test = new int[] 
            //{
            //    cmbSubOrgId.SelectedIndex,
            //    cmbNameHeadApartment.SelectedIndex,
            //     cmbPayManager.SelectedIndex,
            //    cmbPayWater.SelectedIndex,
            //     cmbDayPay.SelectedIndex,
            //    cmbManagerCostOld.SelectedIndex,
            //    cmbSumMoney.SelectedIndex
            //};
            //int[] distinct = test.Distinct().ToArray();
            //if (test.Length != distinct.Length)
            //{
            //    MessageBoxManager.ShowErrorMessageBox(this, "Có các cột trùng vị trí với nhau, xin hãy kiểm tra lại!");
            //    return;
            //}

            ChangeFielData();
            DialogResult = DialogResult.OK;


            if (DialogResult == DialogResult.OK)
            {
                FrmReadExcelData frmReadData = new FrmReadExcelData(rm);
                workItem.SmartParts.Add(frmReadData);

                frmReadData.FilePath = FilePath;
                frmReadData.FirstRowIndex = FirstRowIndex;

                frmReadData.SubOrgId = SubOrgId;
                frmReadData.SubOrgCodeIndex = SubOrgCodeIndex;
                frmReadData.NameHeadApartmentdIndex = NameHeadApartmentdIndex;
                frmReadData.PayManagerIndex = PayManagerIndex;
                frmReadData.PayWaterIndex = PayWaterIndex;
                frmReadData.DayPayIndex = DayPayIndex;
                frmReadData.ManagerCostOldIndex = ManagerCostOldIndex;
                frmReadData.SumMoneyIndex = SumMoneyIndex;

                frmReadData.ShowDialog();

                frmReadData.Dispose();
                workItem.SmartParts.Remove(frmReadData);
            }

            Dispose();
            //   workItem.SmartParts.Remove();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void ChangeFielData()
        {
            LocalSettings.Instance.SubOrgIdCol = cmbSubOrgId.SelectedIndex;
            LocalSettings.Instance.NameHeadApartmentCol = cmbNameHeadApartment.SelectedIndex;
            LocalSettings.Instance.PayManagerCol = cmbPayManager.SelectedIndex;
            LocalSettings.Instance.PayWaterCol = cmbPayWater.SelectedIndex;
            LocalSettings.Instance.DayPayCol = cmbDayPay.SelectedIndex;
            LocalSettings.Instance.UpdateTimeCol = cmbManagerCostOld.SelectedIndex;
            LocalSettings.Instance.SumMoneyCol = cmbSumMoney.SelectedIndex;
            LocalSettings.Instance.Save();
        }
    }
}
