using CommonControls;
using CommonHelper.Config;
using CommonHelper.Utils;
using System;
using System.Windows.Forms;
using System.Linq;
using CommonHelper.Constants;
using System.Resources;

namespace SystemMgtComponent.WorkItems.IntegratingExcel
{
    public partial class FrmConnectionConfig : CommonControls.Custom.CommonDialog
    {
        public string FilePath { get { return txtInputFilePath.Text; } }
        public long OrgId { get; set; }
        public long SubOrgId { get; set;}
        public int CodeIndex { get { return cmbCode.SelectedIndex; } }
        public int FirstNameIndex { get { return cmbFirstName.SelectedIndex; } }
        public int LastNameIndex { get { return cmbLastName.SelectedIndex; } }
        public int BirthDateIndex { get { return cmbBirthDate.SelectedIndex; } }
        public int GenderIndex { get { return cmbGender.SelectedIndex; } }
        public int CompanyNameIndex { get { return cmbCompanyName.SelectedIndex; } }
        public int DegreeIndex { get { return cmbDegree.SelectedIndex; } }
        public int PositionIndex { get { return cmbPosition.SelectedIndex; } }
        public int PermanentAddressIndex { get { return cmbPermanentAddress.SelectedIndex; } }
        public int TemporaryAddressIndex { get { return cmbTemporaryAddress.SelectedIndex; } }
        public int PhoneNoIndex { get { return cmbPhoneNo.SelectedIndex; } }
        public int EmailIndex { get { return cmbEmail.SelectedIndex; } }
        public int NationalityIndex { get { return cmbNationality.SelectedIndex; } }

        public int IdentityCardIndex { get { return cbxIdentityCard.SelectedIndex; } }
        public int IdentityCardDateIndex { get { return cbxIdentityCardDate.SelectedIndex; } }
        public int IdentityCardIssueIndex { get { return cbxIdentityCardIssue.SelectedIndex; } }

        public int ContactNameIndex { get { return cbxContactName.SelectedIndex; } }
        public int ContactPhoneIndex { get { return cbxContactPhone.SelectedIndex; } }
        public int ContactEmailIndex { get { return cbxContactEmail.SelectedIndex; } }
        public int ContactAddressIndex { get { return cbxContactAddress.SelectedIndex; } }
        public int FirstRowIndex { get { return Convert.ToInt32(tbxStartRowIndex.Text) - 1; } }

        //check Journalist
        public string Title { get { return (cbxCheckJournalist.Checked ? "Nhà báo" : "");  } }

        private ResourceManager rm;

        public FrmConnectionConfig(long orgId, long subOrgId, ResourceManager rm)
        {
            InitializeComponent();

            this.OrgId = orgId;
            this.SubOrgId = subOrgId;
            this.rm = rm;

            string[] cols = ExcelUtils.GenerateColumnCaptions(26);
            cmbCode.DataSource = cols;
            cmbFirstName.DataSource = cols.Clone();
            cmbLastName.DataSource = cols.Clone();
            cmbBirthDate.DataSource = cols.Clone();
            cmbGender.DataSource = cols.Clone();
            cmbCompanyName.DataSource = cols.Clone();
            cmbDegree.DataSource = cols.Clone();
            cmbPosition.DataSource = cols.Clone();
            cmbPermanentAddress.DataSource = cols.Clone();
            cmbTemporaryAddress.DataSource = cols.Clone();
            cmbPhoneNo.DataSource = cols.Clone();
            cmbEmail.DataSource = cols.Clone();
            cmbNationality.DataSource = cols.Clone();
            cbxContactName.DataSource = cols.Clone();
            cbxContactPhone.DataSource = cols.Clone();
            cbxContactEmail.DataSource = cols.Clone();
            cbxContactAddress.DataSource = cols.Clone();
            cbxIdentityCard.DataSource = cols.Clone();
            cbxIdentityCardDate.DataSource = cols.Clone();
            cbxIdentityCardIssue.DataSource = cols.Clone();
            cbxSubOrgCode.DataSource = cols.Clone();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            cmbCode.SelectedIndex = cmbFirstName.SelectedIndex = cmbLastName.SelectedIndex =
            cmbBirthDate.SelectedIndex = cmbGender.SelectedIndex = cmbCompanyName.SelectedIndex =
            cmbDegree.SelectedIndex = cmbPosition.SelectedIndex = cmbPermanentAddress.SelectedIndex =
            cmbTemporaryAddress.SelectedIndex = cmbPhoneNo.SelectedIndex = cmbEmail.SelectedIndex =
            cbxContactName.SelectedIndex = cbxContactPhone.SelectedIndex = cbxContactEmail.SelectedIndex =
            cbxIdentityCard.SelectedIndex = cbxIdentityCardDate.SelectedIndex = cbxIdentityCardIssue.SelectedIndex =
            cbxContactAddress.SelectedIndex = cmbNationality.SelectedIndex = cbxSubOrgCode.SelectedIndex = -1;

            tbxStartRowIndex.Text = tbxStartRowIndex.Value.ToString();
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            //OpenFileDialog dialog = new OpenFileDialog();
           // dialog.Filter = "MS Excel (*.xls)|*.xls";

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";

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

            int[] checkCol = new int[] 
            {
                cmbCode.SelectedIndex, 
                cmbFirstName.SelectedIndex, 
                cmbLastName.SelectedIndex, 
                cmbBirthDate.SelectedIndex, 
                cmbGender.SelectedIndex, 
                cmbCompanyName.SelectedIndex,
                cmbDegree.SelectedIndex, 
                cmbPosition.SelectedIndex, 
                cmbPermanentAddress.SelectedIndex, 
                cmbTemporaryAddress.SelectedIndex, 
                cmbPhoneNo.SelectedIndex, 
                cmbEmail.SelectedIndex, 
                cmbNationality.SelectedIndex, 
                cbxContactName.SelectedIndex,
                cbxContactPhone.SelectedIndex,
                cbxContactEmail.SelectedIndex,
                cbxContactAddress.SelectedIndex,
                cbxIdentityCard.SelectedIndex, 
                cbxIdentityCardDate.SelectedIndex, 
                cbxIdentityCardIssue.SelectedIndex,
                cbxSubOrgCode.SelectedIndex,
            };
            int[] test = checkCol.Where(c => c != -1).ToArray();
            int[] distinct = test.Distinct().ToArray();

            if (test.Length != distinct.Length)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MessageValidate.CheckSameColumn));
                return;
            }

            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
