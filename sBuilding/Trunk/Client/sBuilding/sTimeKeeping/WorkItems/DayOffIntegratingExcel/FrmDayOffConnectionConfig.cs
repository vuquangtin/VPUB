using CommonControls;
using CommonHelper.Constants;
using CommonHelper.Utils;
using sWorldModel.TransportData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Windows.Forms;

namespace sTimeKeeping.WorkItems.DayOffIntegratingExcel
{
    /// <summary>
    /// class FrmDayOffConnectionConfig : CommonControls.Custom.CommonDialog
    /// </summary>
    public partial class FrmDayOffConnectionConfig : CommonControls.Custom.CommonDialog
    {
        // List<SubOrgCustomerDTO>
        public List<SubOrgCustomerDTO> listSubOrg;

        // FilePath
        public string FilePath { get { return txtInputFilePath.Text; } }

        public long OrgId { get; set; }
        public long SubOrgId { get; set; }

        // binding with form
        public int MemberCodeIndex { get { return cbxMemberCode.SelectedIndex; } }
        public int MemberNameIndex { get { return cbxMemberName.SelectedIndex; } }
        public int DateIndex { get { return cmbDate.SelectedIndex; } }
        public int TypeIndex { get { return cmbType.SelectedIndex; } }
        public int NoteIndex { get { return cmbNote.SelectedIndex; } }

        // FirstRowIndex
        public int FirstRowIndex { get { return Convert.ToInt32(tbxStartRowIndex.Text) - 1; } }

        // ResourceManager
        private ResourceManager rm;

        /// <summary>
        /// contructor FrmDayOffConnectionConfig
        /// </summary>
        /// <param name="orgId"></param>
        /// <param name="listSubOrg"></param>
        /// <param name="rm"></param>
        public FrmDayOffConnectionConfig(long orgId, long listSubOrg, ResourceManager rm)
        {
            InitializeComponent();

            // gan gia tri thuoc tinh
            this.OrgId = orgId;
            this.SubOrgId = listSubOrg;

            // ResourceManager
            this.rm = rm;

            // gan DataSource
            string[] cols = ExcelUtils.GenerateColumnCaptions(26);
            cbxMemberCode.DataSource = cols;
            cbxMemberName.DataSource = cols.Clone();
            cmbDate.DataSource = cols.Clone();
            cmbType.DataSource = cols.Clone();
            cbxMemberCode.DataSource = cols.Clone();
            cbxMemberName.DataSource = cols.Clone();
            cmbNote.DataSource = cols.Clone();
        }

        /// <summary>
        /// override OnShown of Form
        /// </summary>
        /// <param name="e"></param>
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            // SelectedIndex default = -1
            cbxMemberCode.SelectedIndex = cbxMemberName.SelectedIndex =
            cmbDate.SelectedIndex = cmbType.SelectedIndex =
            cmbNote.SelectedIndex = -1;

            // gan tbxStartRowIndex.Tex
            tbxStartRowIndex.Text = tbxStartRowIndex.Value.ToString();

            // SetResoucreLanguages
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
        }

        /// <summary>
        /// btnSelectFile_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            //OpenFileDialog
            OpenFileDialog dialog = new OpenFileDialog();

            // Filter theo *.xls;*.xlsx;*.xlsm
            dialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";

            dialog.InitialDirectory = "";

            // ialog.ShowDialog() == DialogResult.OK
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // txtInputFilePath.Text = dialog.FileName
                txtInputFilePath.Text = dialog.FileName;
            }
        }

        /// <summary>
        /// btnNext_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click(object sender, EventArgs e)
        {
            // kiem tra null 
            if (string.IsNullOrEmpty(FilePath))
            {
                MessageBoxManager.ShowErrorMessageBox(this, ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MessageValidate.ExcelPath));
                return;
            }

            // kiem tra tbxStartRowIndex.Text.Length == 0
            if (tbxStartRowIndex.Text.Length == 0)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MessageValidate.FirstDataPosition));
                return;
            }

            // tao mang cac index da chon
            int[] checkCol = new int[] 
            {
                cbxMemberCode.SelectedIndex, 
                cbxMemberName.SelectedIndex, 
                cmbDate.SelectedIndex, 
                cmbType.SelectedIndex, 
                cmbNote.SelectedIndex, 
            };

            // tao mang test
            int[] test = checkCol.Where(c => c != -1).ToArray();

            // tao mang distinct co cac gia tri ko trung
            int[] distinct = test.Distinct().ToArray();

            // neu test.Length != distinct.Length => co su trung lap
            if (test.Length != distinct.Length)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MessageValidate.CheckSameColumn));
                return;
            }

            // DialogResult = ok
            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// btnCancel_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            // DialogResult = Cancel
            DialogResult = DialogResult.Cancel;
        }
    }
}
