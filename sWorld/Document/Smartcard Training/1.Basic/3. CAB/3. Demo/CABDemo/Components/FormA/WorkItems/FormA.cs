using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormA
{
    public partial class frmA : Form
    {
        public frmA()
        {
            InitializeComponent();
        }

        public void AddLabel(string textAlain) 
        {
            Label lb = new Label();
            lb.Text = textAlain;
        }
    }
}
