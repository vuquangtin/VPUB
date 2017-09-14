using AttendanceComponent.WorkItems;
using CommonControls;
using CommonHelper.Config;
using CommonHelper.Constants;
using CommonHelper.Utils;
using Microsoft.Practices.CompositeUI;
using sWorldModel;
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
    public partial class frmAddOrEditContact : CommonControls.Custom.CommonDialog
    {
        #region Properties

        private DataTable dtbContactList;
        private Dictionary<string, string> ContactList;
        private ResourceManager rm;

        private readonly int plAddOrEditHeight = 35;

        private AttendanceWorkItem workItem;

        [ServiceDependency]
        public AttendanceWorkItem WorkItem
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

        public frmAddOrEditContact()
        {
            InitializeComponent();
            InitDataTable();

            btnAddContact.Click += btnAddGroup_Click;
            btnUpdateContact.Click += btnUpdateGroup_Click;
            btnRemoveContact.Click += btnRemoveGroup_Click;
            btnSave.Click += btnSave_Click;

            dgvContactList.SelectionChanged += dgvGroupList_SelectionChanged;
        }

        #region Form Event's

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            SaveContactConfig();
            this.DialogResult = DialogResult.OK;
            e.Cancel = false;
        }

        protected override void OnLoad(EventArgs e)
        {
            ContactList = new Dictionary<string, string>();
            LoadContact(GroupSettings.Instance.MemberContact);
            plAddOrEdit.Height = 0;

            ILocalStorageService storageService = workItem.Services.Get<ILocalStorageService>();
            rm = storageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
        }

        private void btnRemoveGroup_Click(object sender, EventArgs e)
        {
            if (dgvContactList.RowCount > 0)
            {
                foreach (DataGridViewRow row in dgvContactList.SelectedRows)
                {
                    string value = row.Cells[colContactName.Name].Value.ToString();
                    dgvContactList.Rows.Remove(row);
                    ContactList.Remove(value);
                    SaveContactConfig();
                }
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
            if (ValidateContact())
            {
                SaveContact();
                ClearTextbox();
                ShowOrHideAddOrEdit(false);
            }
        }

        private void dgvGroupList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvContactList.RowCount > 0)
            {
                foreach (DataGridViewRow row in dgvContactList.SelectedRows)
                {
                    tbxContactName.Text = row.Cells[colContactName.Name].Value.ToString();
                    tbxPhone.Text = row.Cells[colPhone.Name].Value.ToString();
                }
            }
        }

        #endregion

        #region Event's Support

        private void InitDataTable()
        {
            dtbContactList = new DataTable();
            dtbContactList.Columns.Add(colContactName.DataPropertyName);
            dtbContactList.Columns.Add(colPhone.DataPropertyName);
            dgvContactList.DataSource = dtbContactList;
        }

        private void LoadContact(string contactList)
        {
            if (contactList.Length > 1)
            {
                dtbContactList.Rows.Clear();
                String[] result = contactList.Split(',');
                foreach (String group in result)
                {
                    string[] item = group.Split('-');
                    if (item.Length > 0)
                    {
                        string code = item.FirstOrDefault();
                        string name = item.LastOrDefault();

                        DataRow row = dtbContactList.NewRow();
                        row.BeginEdit();

                        row[colContactName.DataPropertyName] = code;
                        row[colPhone.DataPropertyName] = name;

                        row.EndEdit();
                        dtbContactList.Rows.Add(row);
                        ContactList.Add(code, name);
                    }
                }
            }
        }

        private void LoadContact(Dictionary<string, string> contactList)
        {
            dtbContactList.Rows.Clear();
            foreach (string key in contactList.Keys)
            {
                string code = key;
                string name = contactList[key];

                DataRow row = dtbContactList.NewRow();
                row.BeginEdit();

                row[colContactName.DataPropertyName] = code;
                row[colPhone.DataPropertyName] = name;

                row.EndEdit();
                dtbContactList.Rows.Add(row);
            }
        }

        private bool ValidateContact()
        {
            if (string.IsNullOrEmpty(tbxContactName.Text))
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessageValidate(rm, MessageValidate.Attendance_ContactName), MessageValidate.GetErrorTitle(rm));
                return false;
            }
            if (string.IsNullOrEmpty(tbxPhone.Text))
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessageValidate(rm, MessageValidate.MobilePhone), MessageValidate.GetErrorTitle(rm));
                return false;
            }
            if (!StringUtils.CheckPhoneNumber(tbxPhone.Text))
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessageDataFail(rm, MessageValidate.PhoneFirst), MessageValidate.GetErrorTitle(rm));
                return false;
            }
            return true;
        }

        private void SaveContact()
        {
            string code = tbxContactName.Text.Trim();
            string name = tbxPhone.Text.Trim();

            ContactList.Add(code, name);
            LoadContact(ContactList);
        }

        private void SaveContactConfig()
        {
            string contactListStr = string.Empty;
            foreach (string key in ContactList.Keys)
            {
                string group = key + "-" + ContactList[key];
                contactListStr += group + ",";
            }
            GroupSettings.Instance.MemberContact = contactListStr.Length > 0 ? contactListStr.Remove(contactListStr.Length - 1) : string.Empty;
            GroupSettings.Instance.Save();
        }

        private void ClearTextbox()
        {
            tbxContactName.Text = tbxPhone.Text = string.Empty;
        }

        private void ShowOrHideAddOrEdit(bool isShow)
        {
            plAddOrEdit.Height = isShow ? plAddOrEditHeight : 0;
        }

        #endregion

        private void lbTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
