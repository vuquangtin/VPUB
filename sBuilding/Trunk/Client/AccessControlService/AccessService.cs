using AccessControlService.Service;
using sAccessControl.Device.Reader.MCR02;
using sWorldModel.TransportData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace AccessControlService
{
    partial class AccessService : ServiceBase
    {
        public AccessService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            SessionDTO session = null;

            while (session == null)
                session = SystemService.Instance.Login();

            if (session != null && session.Id > 0)
            {
                MCR02.Instance.AccessStart();
               // MCR02.Instance.AccessProcessor();
                MCR02.Instance.startAccessProcessor();
            }
        }

        protected override void OnStop()
        {
            MCR02.Instance.AccessStop();
        }
    }
}
