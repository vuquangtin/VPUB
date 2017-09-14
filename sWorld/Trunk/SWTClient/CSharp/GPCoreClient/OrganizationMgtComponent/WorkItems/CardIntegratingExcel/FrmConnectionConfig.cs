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

namespace SystemMgtComponent.WorkItems.CardIntegratingExcel
{
    public partial class FrmImportDataCard : CommonControls.Custom.CommonDialog
    {
        public ResourceManager rm;
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
        public string FilePath { get { return txtInputFilePath.Text; } }


        public int FirstRowIndex
        {
            get { return Convert.ToInt32(tbxStartRowIndex.Text) - 1; }
        }

        public int OrgMaserId { get { return cmbOrgMasterId.SelectedIndex; } }
        public int OrgMasterCode { get { return cmbOrgMasterCode.SelectedIndex; } }
        public int HeaderPosion { get { return cmbHeaderPosion.SelectedIndex; } }
        public int CardType { get { return cmbCardType.SelectedIndex; } }
        public int Serial { get { return cmbSerial.SelectedIndex; } }
        public int TypeEncript { get { return cmbTypeEncript.SelectedIndex; } }
        public int LicenseMaster { get { return cmbLicenseMaster.SelectedIndex; } }
        public int PhysicalStatus { get { return cbxPhysicalStatus.SelectedIndex; } }

        public FrmImportDataCard()
        {
            InitializeComponent();

            string[] cols = ExcelUtils.GenerateColumnCaptions(26);

            cmbOrgMasterId.DataSource = cols.Clone();
            cmbOrgMasterCode.DataSource = cols.Clone();
            cmbHeaderPosion.DataSource = cols.Clone();
            cmbCardType.DataSource = cols.Clone();
            cmbTypeEncript.DataSource = cols.Clone();
            cmbLicenseMaster.DataSource = cols.Clone();
            cmbSerial.DataSource = cols.Clone();
            cbxPhysicalStatus.DataSource = cols.Clone();

        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            rm = storageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
            this.Text = MessageValidate.GetMessage(rm, this.Name);

            cmbOrgMasterId.SelectedIndex = cmbSerial.SelectedIndex = cmbOrgMasterCode.SelectedIndex = cmbHeaderPosion.SelectedIndex =
            cmbCardType.SelectedIndex = cmbTypeEncript.SelectedIndex = cmbLicenseMaster.SelectedIndex
             = cbxPhysicalStatus.SelectedIndex = -1;

            tbxStartRowIndex.Text = tbxStartRowIndex.Value.ToString();
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

            int[] checkCol = new int[]
            {
                cmbOrgMasterCode.SelectedIndex,
                cmbHeaderPosion.SelectedIndex,
                 cmbCardType.SelectedIndex,
                cmbTypeEncript.SelectedIndex,
                 cmbLicenseMaster.SelectedIndex,
                cmbSerial.SelectedIndex,
                cbxPhysicalStatus.SelectedIndex
        };
            int[] test = checkCol.Where(c => c != -1).ToArray();
            int[] distinct = test.Distinct().ToArray();
            if (test.Length != distinct.Length)
            {
                MessageBoxManager.ShowErrorMessageBox(this, "Có các cột trùng vị trí với nhau, xin hãy kiểm tra lại!");
                return;
            }

            DialogResult = DialogResult.OK;

            if (DialogResult == DialogResult.OK)
            {
                FrmReadExcelData frmReadData = new FrmReadExcelData(rm);
                workItem.SmartParts.Add(frmReadData);

                frmReadData.FilePath = FilePath;
                frmReadData.FirstRowIndex = FirstRowIndex;
                frmReadData.OrgMaserId = OrgMaserId;
                frmReadData.OrgMasterCode = OrgMasterCode;
                frmReadData.HeaderPosion = HeaderPosion;
                frmReadData.CardType = CardType;
                frmReadData.Serial = Serial;
                frmReadData.TypeEncript = TypeEncript;
                frmReadData.LicenseMaster = LicenseMaster;
                frmReadData.PhysicalStatus = PhysicalStatus;
                frmReadData.ShowDialog();

                frmReadData.Dispose();
                workItem.SmartParts.Remove(frmReadData);
            }
            Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        

    }
}
