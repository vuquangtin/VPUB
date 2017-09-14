using CommonControls;
using CommonHelper.Config;
using CommonHelper.Constants;
using CommonHelper.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Windows.Forms;

namespace SystemMgtComponent.WorkItems
{
    public partial class frmAddOrEditGroup : CommonControls.Custom.CommonDialog
    {
        #region Properties

        private DataTable dtbGroupList;
        private Dictionary<string, string> GroupList;

        private readonly int plAddOrEditHeight = 35;
        private ResourceManager rm;

        #endregion

        public frmAddOrEditGroup(ResourceManager rm)
        {
            InitializeComponent();
            InitDataTable();

            this.rm = rm;

            btnAddGroup.Click += btnAddGroup_Click;
            btnUpdateGroup.Click += btnUpdateGroup_Click;
            btnRemoveGroup.Click += btnRemoveGroup_Click;
            btnSave.Click += btnSave_Click;

            dgvGroupList.SelectionChanged += dgvGroupList_SelectionChanged;
        }

        #region Form Event's

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            //SaveGroupConfig();
            this.DialogResult = DialogResult.OK;
            e.Cancel = false;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
        }

        protected override void OnLoad(EventArgs e)
        {
            //LoadGroup(GroupSettings.Instance.Group);
            plAddOrEdit.Height = 0;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
            this.Text = MessageValidate.GetMessage(rm, this.Name);
            
        }

        private void btnRemoveGroup_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvGroupList.SelectedRows)
            {
                GroupList.Remove(row.Cells[colGroupCode.Name].Value.ToString());
                dgvGroupList.Rows.Remove(row);
                //SaveGroupConfig();
            }
        }

        private void btnUpdateGroup_Click(object sender, EventArgs e)
        {
            ShowOrHideAddOrEdit(true);
        }

        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            ShowOrHideAddOrEdit(true);
            ClearTextbox();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveGroup();
            ClearTextbox();
            ShowOrHideAddOrEdit(false);
        }

        private void dgvGroupList_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvGroupList.SelectedRows)
            {
                tbxGroupCode.Text = row.Cells[colGroupCode.Name].Value.ToString();
                tbxGroupName.Text = row.Cells[colGroupName.Name].Value.ToString();
            }
        }

        #endregion

        #region Event's Support

        private void InitDataTable()
        {
            dtbGroupList = new DataTable();
            dtbGroupList.Columns.Add(colGroupCode.DataPropertyName);
            dtbGroupList.Columns.Add(colGroupName.DataPropertyName);
            dgvGroupList.DataSource = dtbGroupList;
        }

        private void LoadGroup(string groupList)
        {
            dtbGroupList.Rows.Clear();
            GroupList = new Dictionary<string, string>();
            String[] result = groupList.Split(',');
            foreach (String group in result)
            {
                string[] item = group.Split('-');
                if (item.Length > 0)
                {
                    string code = item.FirstOrDefault();
                    string name = item.LastOrDefault();

                    DataRow row = dtbGroupList.NewRow();
                    row.BeginEdit();

                    row[colGroupCode.DataPropertyName] = code;
                    row[colGroupName.DataPropertyName] = name;

                    row.EndEdit();
                    dtbGroupList.Rows.Add(row);
                    GroupList.Add(code, name);
                }
            }
        }

        private void LoadGroup(Dictionary<string, string> groupList)
        {
            dtbGroupList.Rows.Clear();
            foreach (string key in groupList.Keys)
            {
                string code = key;
                string name = groupList[key];

                DataRow row = dtbGroupList.NewRow();
                row.BeginEdit();

                row[colGroupCode.DataPropertyName] = code;
                row[colGroupName.DataPropertyName] = name;

                row.EndEdit();
                dtbGroupList.Rows.Add(row);
            }
        }

        private bool ValidateGroup()
        {
            if (string.IsNullOrEmpty(tbxGroupCode.Text))
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessageValidate(rm, MessageValidate.GroupId), MessageValidate.GetErrorTitle(rm));
                return false;
            }
            if (string.IsNullOrEmpty(tbxGroupName.Text))
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessageValidate(rm, MessageValidate.GroupName), MessageValidate.GetErrorTitle(rm));
                return false;
            }
            return true;
        }

        private void SaveGroup()
        {
            string code = tbxGroupCode.Text.Trim();
            string name = tbxGroupName.Text.Trim();

            if (ValidateGroup())
            {
                GroupList.Add(code, name);
                LoadGroup(GroupList);
            }
        }

        //private void SaveGroupConfig()
        //{
        //    string groupListStr = string.Empty;
        //    foreach (string key in GroupList.Keys)
        //    {
        //        string group = key + "-" + GroupList[key];
        //        groupListStr += group + ",";
        //    }
        //    GroupSettings.Instance.Group = groupListStr.Length > 0 ? groupListStr.Remove(groupListStr.Length - 1) : string.Empty;
        //    GroupSettings.Instance.Save();
        //}

        private void ClearTextbox()
        {
            tbxGroupCode.Text = tbxGroupName.Text = string.Empty;
        }

        private void ShowOrHideAddOrEdit(bool isShow)
        {
            plAddOrEdit.Height = isShow ? plAddOrEditHeight : 0;
        }

        #endregion
    }
}
