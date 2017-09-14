using CommonControls;
using CommonHelper.Config;
using CommonHelper.Utils;
using System;
using System.Windows.Forms;
using System.Linq;
using CommonHelper.Constants;
using System.Resources;
using sTimeKeeping.Model;
using System.Collections.Generic;
using sWorldModel.TransportData;

namespace sTimeKeeping.WorkItems.EventIntegratingExcel
{
    /// <summary>
    /// class FrmEventConnectionConfig : CommonControls.Custom.CommonDialog
    /// </summary>
    public partial class FrmEventConnectionConfig : CommonControls.Custom.CommonDialog
    {
        #region Properties

        // Properties
        public string FilePath { get { return txtInputFilePath.Text; } }
        public List<SubOrgCustomerDTO> listSubOrg;

        // OrgId
        public long OrgId { get; set; }

        // SubOrgId
        public long SubOrgId { get; set;}

        //binding with form
        public int EventNameIndex { get { return cmbEventName.SelectedIndex; } }
        public int HourBeginIndex { get { return cmbHourBegin.SelectedIndex; } }
        public int DateIndex { get { return cmbDate.SelectedIndex; } }
        public int HourKeepingIndex { get { return cmbHourKeeping.SelectedIndex; } }
        public int DescriptionIndex { get { return cmbDescription.SelectedIndex; } }
        public int MemberCodeIndex { get { return cbxMemberCode.SelectedIndex; } }
        public int MemberNameIndex { get { return cbxMemberName.SelectedIndex; } }

        // FirstRowIndex
        public int FirstRowIndex { get { return Convert.ToInt32(tbxStartRowIndex.Text) - 1; } }

        // List<string> subOrgStringList
        private List<string> subOrgStringList = new List<string>();

        // ResourceManager rm
        private ResourceManager rm;

        #endregion 

        /// <summary>
        /// contructor FrmEventConnectionConfig
        /// </summary>
        /// <param name="orgId"></param>
        /// <param name="listSubOrg"></param>
        /// <param name="rm"></param>
        public FrmEventConnectionConfig(long orgId, List<SubOrgCustomerDTO> listSubOrg, ResourceManager rm)
        {
            // InitializeComponent
            InitializeComponent();

            // gan gia tri bien
            this.OrgId = orgId;
            this.listSubOrg = listSubOrg;

            // tao gia tri cho subOrgStringList
            setSubOrgStringList(listSubOrg);

            // gan cmbSubOrg.DataSource = subOrgStringList
            this.cmbSubOrg.DataSource = subOrgStringList;

            // gan ResourceManager
            this.rm = rm;

            // tao DataSource cho cac combobox 
            string[] cols = ExcelUtils.GenerateColumnCaptions(26);
            cmbEventName.DataSource = cols;
            cmbHourBegin.DataSource = cols.Clone();
            cmbDate.DataSource = cols.Clone();
            cmbHourKeeping.DataSource = cols.Clone();
            cbxMemberCode.DataSource = cols.Clone();
            cbxMemberName.DataSource = cols.Clone();
            cmbDescription.DataSource = cols.Clone();
        }

        /// <summary>
        /// override OnShown of form
        /// </summary>
        /// <param name="e"></param>
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            // gan defaul index = -1
            cmbEventName.SelectedIndex = cmbHourBegin.SelectedIndex =
            cmbDate.SelectedIndex = cmbHourKeeping.SelectedIndex =
            cbxMemberCode.SelectedIndex = cbxMemberName.SelectedIndex = 
            cmbDescription.SelectedIndex = -1;

            // gan gia tri tbxStartRowIndex.Text  
            tbxStartRowIndex.Text = tbxStartRowIndex.Value.ToString();

            // set ResoucreLanguages
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
        }

        /// <summary>
        /// tao SubOrgStringList
        /// </summary>
        /// <param name="listSubOrg"></param>
        private void setSubOrgStringList(List<SubOrgCustomerDTO> listSubOrg)
        {
            // duyet tren listSubOrg
            foreach (SubOrgCustomerDTO sub in listSubOrg)
            {
                // add item vao subOrgStringList
                subOrgStringList.Add(sub.Name);
            }
        }

        /// <summary>
        /// getSubOrgId
        /// </summary>
        /// <returns></returns>
        private long getSubOrgId()
        {
            //get SubOrgCustomerDTO from listSubOrg
            SubOrgCustomerDTO subInfo = listSubOrg[cmbSubOrg.SelectedIndex];

            // kiem tra null
            if (null != subInfo)
                return subInfo.SubOrgId;
            return -1;
        }

        #region event

        /// <summary>
        /// su kien btnSelectFile_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            // Filter theo cac loai file *.xls;*.xlsx;*.xlsm" 
            dialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";

            dialog.InitialDirectory = "";

            // kiem tra dialog.ShowDialog() == DialogResult.OK
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtInputFilePath.Text = dialog.FileName;
            }
        }

        /// <summary>
        ///  su kien btnNext_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click(object sender, EventArgs e)
        {
            // validate null 
            if (string.IsNullOrEmpty(FilePath))
            {
                MessageBoxManager.ShowErrorMessageBox(this, ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MessageValidate.ExcelPath));
                return;
            }

            // validate tbxStartRowIndex.Text.Length == 0
            if (tbxStartRowIndex.Text.Length == 0)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MessageValidate.FirstDataPosition));
                return;
            }

            // gan SubOrgId
            this.SubOrgId = getSubOrgId();

            // tao mang gia tri checkCol
            int[] checkCol = new int[] 
            {
                cmbEventName.SelectedIndex, 
                cmbHourBegin.SelectedIndex, 
                cmbDate.SelectedIndex, 
                cmbHourKeeping.SelectedIndex, 
                cbxMemberCode.SelectedIndex,
                cbxMemberName.SelectedIndex,
                cmbDescription.SelectedIndex, 
            };

            // tao mang test
            int[] test = checkCol.Where(c => c != -1).ToArray();

            // tao mang distinct khong trung gia tri
            int[] distinct = test.Distinct().ToArray();

            // kiem tra su trung gia tri trong mang checkCol
            if (test.Length != distinct.Length)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MessageValidate.CheckSameColumn));
                return;
            }
            // DialogResult = ok
            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// su kien btnCancel_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            // DialogResult = Cancel
            DialogResult = DialogResult.Cancel;
        }

        #endregion
    }
}
