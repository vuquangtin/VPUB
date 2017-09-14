using CommonControls;
using JavaCommunication.Factory;
using sAccessControl.Config;
using sWorldModel.Exceptions;
using sWorldModel.TransportData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using CommonHelper.Utils;
using System.Timers;

namespace AccessControlService.Service
{
    public class SystemService
    {
        private static SystemService instance = new SystemService();
        public static SystemService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SystemService();
                }
                return instance;
            }
        }
        public SystemService() { }

        private SessionDTO session = null;
        private int Process = 1;
        private int Success = 2;

        public SessionDTO Login() 
        {
            try
            {
                session = AuthenticationFactory.Instance.GetChannel().Login(UserLoginConfigSection.Instance.User, UserLoginConfigSection.Instance.Password);
            }
            catch (System.TimeoutException)
            {
                Console.WriteLine(CommonMessages.TimeOutExceptionMessage);
                Console.ReadLine();
                return session;
            }
            catch (FaultException<WcfServiceFault> ex)
            {
                Console.WriteLine(ErrorCodes.GetErrorMessage(ex.Detail.Code));
                Console.ReadLine();
                return session;
            }
            catch (FaultException ex)
            {
                Console.WriteLine(CommonMessages.FaultExceptionMessage
                    + Environment.NewLine + Environment.NewLine
                    + ex.Message);
                Console.ReadLine();
                return session;
            }
            catch (CommunicationException ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadLine();
                return session;
            }
            return session;
        }

        public bool AccessProcess(string serialNumberStr, string ipAddress, out DoorOut doorOut)
        {
            if (string.IsNullOrEmpty(serialNumberStr) || string.IsNullOrEmpty(ipAddress)) 
            {
                doorOut = new DoorOut();
                return false;
            }
                

            DateTime date = DateTime.Now;
            doorOut = new DoorOut()
            {
                SerialNumber = serialNumberStr,
                DateIn = date.ToStringFormatDateFullServer(),
                DateOut = date.ToStringFormatDateFullServer(),
            };

            try
            {
                doorOut = AccessFactory.Instance.GetChannel().AccessProcess(session.Token, ipAddress, doorOut);
            }
            catch (System.TimeoutException)
            {
                Console.WriteLine(CommonMessages.TimeOutExceptionMessage);
                Console.ReadLine();
                return false;
            }
            catch (FaultException<WcfServiceFault> ex)
            {
                Console.WriteLine(ErrorCodes.GetErrorMessage(ex.Detail.Code));
                Console.ReadLine();
                return false;
            }
            catch (FaultException ex)
            {
                Console.WriteLine(CommonMessages.FaultExceptionMessage
                    + Environment.NewLine + Environment.NewLine
                    + ex.Message);
                Console.ReadLine();
                return false;
            }
            catch (CommunicationException ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadLine();
                return false;
            }
            return doorOut != null && doorOut.Id > 0 && (doorOut.Status == Success || doorOut.Status == Process);
        }
    }
}
