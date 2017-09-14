using Common;
using Microsoft.Practices.CompositeUI.WinForms;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.EventBroker;
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
    public partial class MainForm : Form
    {
        #region Properties

        private WorkItem _rootWorkItem;

        #endregion

        public MainForm([ServiceDependency]WorkItem rootWorkItem)
        {
            InitializeComponent();
            _rootWorkItem = rootWorkItem;
            //this.paletteWorkspace.Name = ComponentNames.PaletteWorkspace;
            this.mainWorkspace.Name = ComponentNames.MainWorkspace;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //RegisterMenu();
        }

        public void RegisterMenu()
        {
            // Register menu bar
            if (!_rootWorkItem.UIExtensionSites.Contains(ComponentNames.MainMenu))
            {
                _rootWorkItem.UIExtensionSites.RegisterSite(ComponentNames.MainMenu, menuBar);
            }

            // Raise user login successfully event
            if (UserLoggedIn != null)
            {
                UserLoggedIn(this, EventArgs.Empty);
            }
        }

        #region CAB events

        [EventPublication(ComponentNames.UserLoggedIn)]
        public event EventHandler UserLoggedIn;

        [EventPublication(ComponentNames.UserLoggedOut)]
        public event EventHandler UserLoggedOut;

        #endregion

        
    }
}
