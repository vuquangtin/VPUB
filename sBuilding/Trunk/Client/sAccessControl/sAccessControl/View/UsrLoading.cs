using sAccessControl.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sAccessControl
{
    public partial class UsrLoading : CommonUserControl
    {
        public UsrLoading()
        {
            InitializeComponent();
            label1.Text.ToUpper();
        }

        public void ShowMessage()
        {
            this.Visible = true;
        }

        public void HideMessage()
        {
            this.Visible = false;
        }
    }
}
