﻿using AccessControlService.Service;
using sAccessControl.Device.Reader.MCR02;
using sWorldModel.TransportData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;
using CommonHelper.Utils;

namespace AccessControlService
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
#if !_PASSED

                SessionDTO session = null;
                while (session == null)
                {
                    session = SystemService.Instance.Login();
                    System.Console.WriteLine("Cannot login to server at " + DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff",
                        CultureInfo.InvariantCulture));
                    Thread.Sleep(200);
                }

                System.Console.WriteLine("Login sucessful to server at " + DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff",
                     CultureInfo.InvariantCulture));

                if (session != null && session.Id > 0)
                {
                    MCR02.Instance.AccessStart();
                    //MCR02.Instance.AccessProcessor();
                    MCR02.Instance.startAccessProcessor();
                }
#else
                MCR02.Instance.AccessStart();
                MCR02.Instance.startAccessProcessor();
#endif

                while (true)
                {
                    Thread.Sleep(2000);
                }
            }
            catch(Exception e)
            {
                System.Console.WriteLine(e.Message);
                System.Environment.Exit(1);
            }
        }
    }
}
