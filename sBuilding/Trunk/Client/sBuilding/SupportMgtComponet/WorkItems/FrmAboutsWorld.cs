using CommonControls.Custom;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using sWorldModel;
using System.Resources;
using Microsoft.Practices.CompositeUI;
using CommonHelper.Constants;
using CommonHelper.Utils;

namespace UtilitiesMgtComponet.WorkItems
{
    partial class FrmAboutSworld : CommonControls.Custom.CommonDialog
    {
        private ResourceManager rm;
        private ILocalStorageService storageService;

        public FrmAboutSworld(ResourceManager rm)
        {
            this.rm = rm;

            InitializeComponent();
           // this.textBoxDescription.Text = "sCampus là giải pháp quản lý trường học dùng thẻ thông minh (smart card). Thành viên chỉ dùng một thẻ thông minh duy nhất cho tất cả các dịch vụ dùng thẻ như: thẻ chứng thực, thẻ thư viện, thẻ ra vào, thẻ mua sắm, thẻ thanh toán...";
        }


        #region Assembly Attribute Accessors

        #endregion

        private void FrmAboutSworld_Load(object sender, EventArgs e)
        {
            this.Text = MessageValidate.GetMessage(rm, "about_title");
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
            this.lblProductName.Text = MessageValidate.GetMessage(rm, "lblProductName"); ;
            this.lblVersion.Text = MessageValidate.GetMessage(rm, "about_lblVersion");
            this.lblCopyright.Text = MessageValidate.GetMessage(rm, "about_lblCopyright");
            this.lblCompanyName.Text = MessageValidate.GetMessage(rm, "about_lblCompanyname");
          
        }

        private void tableLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
