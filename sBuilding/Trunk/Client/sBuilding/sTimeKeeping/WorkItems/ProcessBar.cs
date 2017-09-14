using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sTimeKeeping.WorkItems
{
    public partial class ProcessBar : Form
    {
        public ProcessBar()
        {
            InitializeComponent();
            progressBar1.PerformLayout();
        }
    }
}
