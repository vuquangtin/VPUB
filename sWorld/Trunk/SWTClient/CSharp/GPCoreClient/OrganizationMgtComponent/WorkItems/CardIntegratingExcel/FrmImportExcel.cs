using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using CommonHelper.Utils;
using CommonHelper.Constants;
using System.Linq;
using System.Text;
using CommonControls;
using System.Windows.Forms;
using System.Resources;
using Microsoft.Practices.CompositeUI;

namespace SystemMgtComponent.WorkItems.CardIntegratingExcel
{
    public partial class FrmImportExcel : CommonControls.Custom.CommonDialog
    {
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
        public int CodeIndex { get { return cmbCreateBy.SelectedIndex; } }
        public int FirstNameIndex { get { return cmbCreateDate.SelectedIndex; } }
        public int BirthDateIndex { get { return cmbLogicalStatus.SelectedIndex; } }
        public int GenderIndex { get { return cmbOrgPartnerId.SelectedIndex; } }
        public int CompanyNameIndex { get { return cmbSerial.SelectedIndex; } }
        public int DegreeIndex { get { return cmbCardType.SelectedIndex; } }
        public int PositionIndex { get { return cmbTypeEncript.SelectedIndex; } }
        public int PermanentAddressIndex { get { return cmbLicensePartner.SelectedIndex; } }
        public int TemporaryAddressIndex { get { return cmbModifyBy.SelectedIndex; } }
        public int PhoneNoIndex { get { return cmbHeaderPosion.SelectedIndex; } }
        public int EmailIndex { get { return cmbLicenseMaster.SelectedIndex; } }
        public int NationalityIndex { get { return cmbOrgMasterId.SelectedIndex; } }

        public int IdentityCardIndex { get { return cbxOrgPartnerCode.SelectedIndex; } }
        public int IdentityCardDateIndex { get { return cbxOrgPartnerId.SelectedIndex; } }
        public int IdentityCardIssueIndex { get { return cbxPhysicalStatus.SelectedIndex; } }


        private ResourceManager rm;

        public FrmImportExcel()
        {
            InitializeComponent();
            string[] cols = ExcelUtils.GenerateColumnCaptions(26);
            cmbCreateBy.DataSource = cols;
            cmbCreateDate.DataSource = cols.Clone();
            cmbLogicalStatus.DataSource = cols.Clone();
            cmbOrgPartnerId.DataSource = cols.Clone();
            cmbSerial.DataSource = cols.Clone();
            cmbCardType.DataSource = cols.Clone();
            cmbTypeEncript.DataSource = cols.Clone();
            cmbLicensePartner.DataSource = cols.Clone();
            cmbModifyBy.DataSource = cols.Clone();
            cmbHeaderPosion.DataSource = cols.Clone();
            cmbLicenseMaster.DataSource = cols.Clone();
            cmbOrgMasterId.DataSource = cols.Clone();
            cbxOrgPartnerCode.DataSource = cols.Clone();
            cbxOrgPartnerId.DataSource = cols.Clone();
            cbxPhysicalStatus.DataSource = cols.Clone();
            cbxDateModify.DataSource = cols.Clone();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            cmbCreateBy.SelectedIndex = cmbCreateDate.SelectedIndex = 
            cmbLogicalStatus.SelectedIndex = cmbOrgPartnerId.SelectedIndex = cmbSerial.SelectedIndex =
            cmbCardType.SelectedIndex = cmbTypeEncript.SelectedIndex = cmbLicensePartner.SelectedIndex =
            cmbModifyBy.SelectedIndex = cmbHeaderPosion.SelectedIndex = cmbLicenseMaster.SelectedIndex =
            cbxOrgPartnerCode.SelectedIndex = cbxOrgPartnerId.SelectedIndex = cbxPhysicalStatus.SelectedIndex;

            tbxStartRowIndex.Text = 2.ToString();
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
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
                MessageBoxManager.ShowErrorMessageBox(this, ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MessageValidate.ExcelPath));
                return;
            }
            if (tbxStartRowIndex.Text.Length == 0)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MessageValidate.FirstDataPosition));
                return;
            }

            DialogResult = DialogResult.OK;

            if (DialogResult == DialogResult.OK)
            {
                FrmReadExcelData frmReadData = new FrmReadExcelData(rm);
                workItem.SmartParts.Add(frmReadData);

                frmReadData.FilePath = FilePath;
                frmReadData.FirstRowIndex = FirstRowIndex;

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
