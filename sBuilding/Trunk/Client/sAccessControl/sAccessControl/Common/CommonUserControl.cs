using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sAccessControl.Common
{
    public partial class CommonUserControl : UserControl
    {
        public CommonUserControl()
        {
            InitializeComponent();
            this.Font = new Font("Tahoma", 9.25F);
            this.BackColor = SystemColors.Control;
            this.ForeColor = SystemColors.ControlText;
            this.Padding = new Padding(5, 5, 5, 5);
        }
    }
}
