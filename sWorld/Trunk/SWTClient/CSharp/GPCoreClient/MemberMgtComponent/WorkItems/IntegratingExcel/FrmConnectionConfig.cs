using CommonControls;
using CommonHelper.Config;
using CommonHelper.Utils;
using System;
using System.Windows.Forms;
using System.Linq;

namespace MemberMgtComponent.WorkItems.IntegratingExcel
{
    public partial class FrmConnectionConfig : CommonControls.Custom.CommonDialog
    {
        public string FilePath { get { return txtInputFilePath.Text; } }
        public long OrgId { get; set; }
        public long SubOrgId { get; set; }
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
        public int FirstRowIndex { get { return Convert.ToInt32(tbxStartRowIndex.Text) - 1; } }

        public FrmConnectionConfig(long orgId, long subOrgId)
        {
            InitializeComponent();

            this.OrgId = orgId;
            this.SubOrgId = subOrgId;

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
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            //cmbBirthDate.SelectedIndex = LocalSettings.Instance.StudentBirthDateCol;
            //cmbCode.SelectedIndex = LocalSettings.Instance.StudentCodeCol;
            //cmbPosition.SelectedIndex = LocalSettings.Instance.StudentDegreeCol;
            //cmbNationality.SelectedIndex = LocalSettings.Instance.StudentFacultyAliasCol;
            //cmbTemporaryAddress.SelectedIndex = LocalSettings.Instance.StudentFirstNameCol;
            //cmbDegree.SelectedIndex = LocalSettings.Instance.StudentLastNameCol;
            //cmbPhoneNo.SelectedIndex = LocalSettings.Instance.StudentModeOfStudyCol;
            //cmbFirstName.SelectedIndex = LocalSettings.Instance.StudentStudyFromCol;
            //cmbUniqueId.SelectedIndex = LocalSettings.Instance.StudentIdCol;
            cmbCode.SelectedIndex = cmbFirstName.SelectedIndex = cmbLastName.SelectedIndex =
            cmbBirthDate.SelectedIndex = cmbGender.SelectedIndex = cmbCompanyName.SelectedIndex =
            cmbDegree.SelectedIndex = cmbPosition.SelectedIndex = cmbPermanentAddress.SelectedIndex =
            cmbTemporaryAddress.SelectedIndex = cmbPhoneNo.SelectedIndex = cmbEmail.SelectedIndex =
            cmbNationality.SelectedIndex = -1;

            tbxStartRowIndex.Text = 2.ToString();
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
                MessageBoxManager.ShowErrorMessageBox(this, "Vui lòng chọn đường dẫn đến tập tin dữ liệu MS Excel!");
                return;
            }
            if (tbxStartRowIndex.Text.Length == 0)
            {
                MessageBoxManager.ShowErrorMessageBox(this, "Bạn chưa nhập vị trí dòng dữ liệu đầu tiên!");
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
            };
            int[] test = checkCol.Where(c => c != -1).ToArray();
            int[] distinct = test.Distinct().ToArray();

            if (test.Length != distinct.Length)
            {
                MessageBoxManager.ShowErrorMessageBox(this, "Có các cột trùng vị trí với nhau, xin hãy kiểm tra lại!");
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
