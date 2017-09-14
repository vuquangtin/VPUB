using JavaCommunication.Factory;
using sAccessControl.Config;
using sWorldModel.Exceptions;
using sWorldModel.TransportData;
using System;
using System.ServiceModel;
using CommonHelper.Utils;
using sTimeKeeping.Model;
using sTimeKeeping.Factory;

namespace AccessControlService.Service
{
    public class SystemService
    {
        private static SystemService instance = new SystemService(null);
        public static SystemService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SystemService(null);
                }
                return instance;
            }
        }

        public SystemService(SessionDTO ses) {
            session = ses;
        }

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
                doorOut = sBuildingCommunication.Factory.AccessFactory.Instance.GetChannel().AccessProcess(session.Token, UserLoginConfigSection.Instance.SaigonpearlCode, ipAddress, doorOut);
                //doorOut = AccessFactory.Instance.GetChannel().AccessProcess(session.Token, ipAddress, doorOut);
            }
            catch (System.TimeoutException)
            {
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

        /// <summary>
        /// kiem tra dau doc co duoc su dung cho cham cong
        /// </summary>
        /// <returns></returns>
        public TimeKeepingAcessDTO checkIpDeviceForTimeKeeping(string serial, string ip)
        {
            return TimeKeepingDeviceConfigFactory.Instance.GetChannel().checkIpDeviceForTimeKeeping(session.Token, serial, ip);
        }
        /// <summary>
        /// ghi dữ liệu khi tag time keeping
        /// </summary>
        /// <param name="shift"></param>
        /// <returns></returns>
        public Shift insertShift(Shift shift)
        {
            return TimeKeepingShiftFactory.Instance.GetChannel().insertShift(session.Token, shift);
        }

        public int insertShiftImage(long id, TimeKeepingImage image)
        {
            return TimeKeepingShiftFactory.Instance.GetChannel().insertShiftImage(session.Token, id, image);
        }
    }
}
