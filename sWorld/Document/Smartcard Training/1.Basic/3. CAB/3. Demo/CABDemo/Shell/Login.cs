using Common;
using Microsoft.Practices.CompositeUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CABDemo
{
    public partial class Login : Form
    {
        private WorkItem rootWorkItem;

        public Login([ServiceDependency]WorkItem rootWorkItem)
        {
            InitializeComponent();
            this.rootWorkItem = rootWorkItem;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm mainForm = rootWorkItem.Items.Get<MainForm>(ComponentNames.MainForm);
            mainForm.RegisterMenu();
            mainForm.Show();
            this.Hide();
        }
    }
}
