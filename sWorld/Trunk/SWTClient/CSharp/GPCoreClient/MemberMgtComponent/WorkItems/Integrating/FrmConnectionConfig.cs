using CommonControls.Custom;
using System;
using System.Windows.Forms;

namespace MemberMgtComponent.WorkItems.Integrating
{
    public partial class FrmConnectionConfig : CommonControls.Custom.CommonDialog
    {
        public string FilePath
        {
            get { return txtInputFilePath.Text; }
        }

        public string UserId
        {
            get { return txtUserId.Text; }
        }

        public string Password
        {
            get { return txtPassword.Text; }
        }

        public FrmConnectionConfig()
        {
            InitializeComponent();
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "MS Access Databases (*.mdb,*.accdb)|*.mdb;*.accdb";
            dialog.InitialDirectory = "";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtInputFilePath.Text = dialog.FileName;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (txtInputFilePath.Text.Length == 0)
            {
                lblMessage.Text = "Bạn chưa chọn tập tin chứa dữ liệu cần tích hợp!";
                return;
            }
            if (AccessDbReader.TestConnection(txtInputFilePath.Text, txtUserId.Text, txtPassword.Text))
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            if (txtInputFilePath.Text.Length == 0)
            {
                lblMessage.Text = "Bạn chưa chọn tập tin chứa dữ liệu cần tích hợp!";
                return;
            }
            if (AccessDbReader.TestConnection(txtInputFilePath.Text, txtUserId.Text, txtPassword.Text))
            {
                lblMessage.Text = "Kết nối thành công!";
            }
            else
            {
                lblMessage.Text = "Kết nối thất bại, vui lòng kiểm tra lại thông số cấu hình!";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
