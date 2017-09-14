using System;
using System.Windows.Forms;
using Microsoft.Practices.CompositeUI.WinForms;
using Microsoft.Practices.CompositeUI;
using System.Threading;
using System.Diagnostics;
using CommonHelper.Constants;
using System.Resources;

namespace MainForm
{
    class ApplicationLoader : FormShellApplication<WorkItem, FrmLogin>
    {
        [STAThread]
        static void Main()
       {
            // Allow only a single instance of an application running
            //bool createdNew;
            //Mutex m = new Mutex(true, "Global\\sWorld", out createdNew);
            string current = Process.GetCurrentProcess().ProcessName;
            Process[] procs = Process.GetProcessesByName(current);
            if (procs.Length > 1)
            {
                ResourceManager rm = new ResourceManager("MainForm.Resources.sBuilding", typeof(FrmLogin).Assembly);
              
                String title = MessageValidate.GetMessage(rm, "ApplicationRunning");
                String action = MessageValidate.GetMessage(rm, "WrongAction");
                MessageBox.Show(title, action, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }

            // Register exception handlers
            AppDomain.CurrentDomain.UnhandledException += AppDomain_UnhandledException;
            Application.ThreadException += Application_ThreadException;

            // Run application
            ApplicationLoader loader = null;
            try
            {
                loader = new ApplicationLoader();                
                loader.Run();
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private static void AppDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            HandleException((Exception)e.ExceptionObject);
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            HandleException(e.Exception);
        }

        protected override void AfterShellCreated()
        {
            base.AfterShellCreated();

            RootWorkItem.Items.Add(this.Shell, ComponentNames.LoginForm);
            RootWorkItem.Items.AddNew<MainForm>(ComponentNames.MainForm);
        }

        private static void HandleException(Exception ex)
        {
            if (ex == null)
                return;
#if(DEBUG)
            MessageBox.Show(ex.ToString(), "DEBUG MODE");
#else
            ///TODO: load message by language
            MessageBox.Show("Chương trình đã xảy ra lỗi không lường trước, thông tin lỗi đã được lưu vào Event Log. Vui lòng liên hệ với bộ phận kỹ thuật của Smart World Technology để được trợ giúp." + Environment.NewLine + Environment.NewLine + "Error Message: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            LogError(ex.ToString());
            //Application.Exit();
#endif
        }

        private static void LogError(string message)
        {
            string source = "sWorld";
            if (!EventLog.SourceExists(source))
            {
                EventLog.CreateEventSource(source, "Application");
            }
            EventLog.WriteEntry(source, message, EventLogEntryType.Error);
        }
    }
}