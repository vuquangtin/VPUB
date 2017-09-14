using CommonControls;
using CommonHelper.Config;
using sWorldModel;
using System;
using System.Windows.Forms;
//using WcfServiceCommon;

namespace sAccessControl
{
    public partial class FrmConfigService : CommonControls.Custom.CommonDialog
    {
        private SystemSettings systemConfig;
        private UriBuilder webService;
        public FrmConfigService()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            systemConfig = SystemSettings.Instance;
            if (systemConfig.JavaWebService != null && systemConfig.JavaWebService.Length > 0) 
            {
                webService = new UriBuilder(systemConfig.JavaWebService);
                tbxIpAddress.Text = webService.Host;
                tbxPort.Text = webService.Port.ToString();
            }

            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            tbxIpAddress.Text = tbxIpAddress.Text.Trim();
            tbxPort.Text = tbxPort.Text.Trim();

            // Kiểm tra xem port có là số nguyên dương không
            uint port;
            if (!uint.TryParse(tbxPort.Text, out port))
            {
                MessageBoxManager.ShowErrorMessageBox(this, "Giá trị cổng dịch vụ không hợp lệ!", "Thao Tác Sai");
                return;
            }

            // Hiện thông báo xác nhận hành động
            if (MessageBoxManager.ShowQuestionMessageBox(this, "Bạn có chắc muốn thay đổi địa chỉ máy chủ không?") != DialogResult.Yes)
            {
                return;
            }

            try
            {
                webService.Host = tbxIpAddress.Text;
                webService.Port = (int)port;
                systemConfig.JavaWebService = webService.Uri.ToString();
                systemConfig.Save();
            }
            catch (Exception ex)
            {
                //MessageBoxManager.ShowErrorMessageBox(this, ex.Message);
                MessageBoxManager.ShowErrorMessageBox(this, ex.ToString());
                return;
            }

            MessageBoxManager.ShowInfoMessageBox(this, "Đã thay đổi địa chỉ dịch vụ thành công!");
            this.Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
