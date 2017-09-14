using CommonControls;
using CommonHelper.Config;
using CommonHelper.Constants;
using CommonHelper.Utils;
using Microsoft.Practices.CompositeUI;
using sWorldModel;
using System;
using System.Resources;
using System.Windows.Forms;
//using WcfServiceCommon;

namespace MainForm
{
    public partial class FrmConfigService : CommonControls.Custom.CommonDialog
    {
        private SystemSettings systemConfig;
        private UriBuilder webService;
        private ResourceManager rm;

        private ILocalStorageService storageService;
        public ILocalStorageService StorageService
        {
            get
            {
                if (storageService == null)
                {
                    storageService = rootWorkItem.Services.Get<ILocalStorageService>();
                }
                return storageService;
            }
        }

        private WorkItem rootWorkItem;

        public FrmConfigService([ServiceDependency]WorkItem rootWorkItem)
        {
            InitializeComponent();
            this.rootWorkItem = rootWorkItem;
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
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            ILocalStorageService storageService = rootWorkItem.Services.Get<ILocalStorageService>();
            rm = storageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
            this.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.Name);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            tbxIpAddress.Text = tbxIpAddress.Text.Trim();
            tbxPort.Text = tbxPort.Text.Trim();

            // Kiểm tra xem port có là số nguyên dương không
            uint port;
            if (!uint.TryParse(tbxPort.Text, out port))
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessInvalid(rm, MessageValidate.ServiceValue), MessageValidate.GetErrorTitle(rm));
                return;
            }

            // Hiện thông báo xác nhận hành động
            if (MessageBoxManager.ShowQuestionMessageBox(this, ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, "msgAcceptConfig")) != DialogResult.Yes)
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

            MessageBoxManager.ShowInfoMessageBox(this, ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, "msgSuccessConfig"));
            this.Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
