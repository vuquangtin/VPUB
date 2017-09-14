using System;
using System.Net.Sockets;
using System.Text;
using AccessControlService.Service;
using CommonHelper.Utils;
using sAccessControl.Config;
using sAccessControl.Device.Reader.MCR02;
using sWorldModel.TransportData;
using System.Configuration;
using System.Threading;
using sTimeKeeping.Model;
using System.Drawing;

namespace AccessControlService
{
    public class SocketHandler
    {
        private byte[] message = new byte[1028];
        private string messsageReceive;
        private Socket socket;
        private SessionDTO session;
        private String IPNumber;
        private NetworkStream networkStream = null;
        private AsyncCallback callbackRead = null;
        private AsyncCallback callbackWrite = null;
        private readonly int milliseconds = UserLoginConfigSection.Instance.TimeOpenDoor;

        #region sTimeKeeping
        // sTimeKeeping
        // kiểm tra config có sử dụng timekeeping hay không?
        private bool UseTimeKeeping = ConfigurationManager.AppSettings["use_timekeeping"].Equals("true");
        //----
        #endregion

        public SocketHandler(Socket sc, String ip, SessionDTO sess)
        {
            socket = sc;
            IPNumber = ip;
            session = sess;
            networkStream = new NetworkStream(sc);
            callbackRead = new AsyncCallback(this.OnReadComplete);
            callbackWrite = new AsyncCallback(this.OnWriteComplete);
        }

        private void OnReadComplete(IAsyncResult ar)
        {
            try
            {
                int bytesRead = networkStream.EndRead(ar);

                if (bytesRead > 0)
                {
                    string data = Encoding.ASCII.GetString(message, 0, bytesRead);
                    Console.WriteLine("IP = {0} Data={1}", IPNumber, data);
                    Int32 unixTimestamp = (Int32)(DateTime.Now.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

                    string devID;
                    bool result = CheckOnServer(data, out devID);
                    if (result)
                    {
                        // has card data on server
                        //mcrReply = devID; Mo cửa
                        messsageReceive = devID + "," + CommandUtils.OpenDoorByMilliseconds(milliseconds) + ",TSYNC=" + unixTimestamp.ToString();
                        Console.WriteLine("-----> open");
                    }
                    else
                    {
                        // does not has card data on server
                        //mcrReply = devID; đóng cửa
                        messsageReceive = devID + "," + CommandUtils.CloseDoor() + ",TSYNC=" + unixTimestamp.ToString();
                        Console.WriteLine("-----> close");
                    }

                    byte[] sendBytes = Encoding.ASCII.GetBytes(messsageReceive);
                    networkStream.BeginWrite(sendBytes, 0, sendBytes.Length, callbackWrite, null);
                }
                else
                {
                    networkStream.Close();
                    socket.Close();
                    networkStream = null;
                    socket = null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }
        private void OnWriteComplete(IAsyncResult ar)
        {
            try
            {
                networkStream.EndWrite(ar);
                networkStream.Close();
                socket.Close();
                networkStream = null;
                socket = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("OnWriteComplete Exception: " + ex.Message);
            }
        }

        /// <summary>
        /// Check card value on server
        /// </summary>
        /// <param name="data">card value</param>
        /// <returns></returns>
        private bool CheckOnServer(string data, out string devID)
        {
            string[] words = data.Split(',');
            string UID = "123456789";

            if (words.Length == 2)
            {
                devID = words[0];
                UID = words[1].Substring(4).TrimEnd();
            }
            else if (words.Length > 2)
            {
                devID = words[0];
                int size = words[1].IndexOf(devID) - 4;
                UID = words[1].Substring(4, size);
            }

            if (words.Length >= 2)
            {
                devID = words[0];

                string serial = UID;
                try
                {
                    uint tmp = Convert.ToUInt32(UID);
                    byte[] serrialbytes = BitConverter.GetBytes(tmp);
                    serial = StringUtils.ByteArrayToHexString(serrialbytes);
                }
                catch (Exception ex)
                {
                    serial = UID;
                }

                #region sTimeKeeping mở tiến trình riêng xử lý 
                // kiểm tra config có sử dụng timekeeping hay không?
                if (UseTimeKeeping)
                {
                    Thread clientThread = new Thread(new ParameterizedThreadStart(StartTimeKeeping));
                    clientThread.Start(serial + "-" + IPNumber);
                }
                #endregion

                Console.WriteLine("----->Serial = {0}", serial);

                // send to server to chec access in server 
                DoorOut doorOut = null;
                SystemService service = new SystemService(session);

                return service.AccessProcess(serial, IPNumber, out doorOut);
            }
            else
            {
                Console.WriteLine("Wrong data format: " + data);
                devID = "";
                return false;
            }
        }
        /// <summary>
        /// Start read data
        /// </summary>
        public void StartRead()
        {
            try
            {
                networkStream.BeginRead(message, 0, message.Length, callbackRead, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Begin read exception: " + ex.Message);
            }
        }

        #region sTimeKeeping

        /// <summary>
        /// Start TimeKeeping
        /// </summary>
        /// <param name="client"></param>
        private void StartTimeKeeping(object param)
        {
            string[] itemList = ((string)param).Split('-');
            if (itemList.Length > 0)
            {
                string serial = itemList[0];
                string ipNumber = itemList[1];
                SystemService service = new SystemService(session);
                //kiem tra dau doc
                try
                {
                    TimeKeepingAcessDTO result = service.checkIpDeviceForTimeKeeping(serial, ipNumber);
                    if (null != result && result.memberId > 0)
                    {
                        // insert
                        Shift shift = new Shift();
                        shift.deviceDoorId = result.deviceDoorId;
                        shift.deviceDoorIp = ipNumber;
                        shift.memberId = result.memberId;
                        shift.serialNumber = serial;

                        Shift shiftResult = service.insertShift(shift);

                        Image image = (new MCR02()).TakeSnapShot();

                        TimeKeepingImage timeKeepingImage = new TimeKeepingImage();
                        timeKeepingImage.image = ImageUtils.ImageToBase64(image);

                        int imgResult = service.insertShiftImage(shiftResult.Id, timeKeepingImage);
                    }
                }
                catch (Exception e)
                {

                }
            }
        }



        #endregion
    }
}
