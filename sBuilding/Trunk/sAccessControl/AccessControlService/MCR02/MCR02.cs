using AccessControlService.SendMessage;
using AccessControlService.Service;
using CommonHelper.Utils;
using sAccessControl.Config;
using sWorldModel.TransportData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Globalization;

namespace sAccessControl.Device.Reader.MCR02
{
    public class MCR02
    {
        private static TcpListener tcpListener;
        private static Thread listenThread;
        private static int milliseconds = UserLoginConfigSection.Instance.TimeOpenDoor;

        private static AccessMessageService mainServer;

        public static string msUser;
        public static string msPass;
        public static string msURL;

        public static string myUser;
        public static string myPass;
        public static string myURL;
        public static string serverPORT;
        public static int cFlag;

        public static string WelcomeMessage;

        public static bool AccessStatus = true;

        private static MCR02 instance = new MCR02();
        public static MCR02 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MCR02();
                }
                return instance;
            }
        }
        public MCR02() { }

        public void AccessStart() 
        {
            AccessStatus = true;
        }

        public void AccessStop()
        {
            AccessStatus = false;
            tcpListener.Stop();
        }

        private static void ListenReaderDeviceClients()
        {
            tcpListener.Start();

            while (AccessStatus)
            {
                //blocks until a client has connected to the server
                TcpClient client = tcpListener.AcceptTcpClient();

                //create a thread to handle communication 
                //with connected client
                Thread clientThread = new Thread(new ParameterizedThreadStart(HandleReaderConnection));
                clientThread.Start(client);

                Thread.Sleep(10);
            }
        }

        private static void HandleReaderConnection(object client)
        {
            string data = "";
            TcpClient tcpClient = (TcpClient)client;
            NetworkStream clientStream = tcpClient.GetStream();
            tcpClient.ReceiveTimeout = 90 * 1000;
            byte[] message = new byte[4096];
            int bytesRead;
            string devID = "";
            string ipNumber = "";
            string mcrReply = "";
            Int32 unixTimestamp;

            ipNumber = ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString();
            bytesRead = 0;

            try
            {
                //blocks until a client sends a message
                bytesRead = clientStream.Read(message, 0, 4096);
                data = Encoding.ASCII.GetString(message, 0, bytesRead);
                if (bytesRead == 0)
                    return;
                data = data.Trim();
                char[] comma = { ',' };
                string[] words = data.Split(comma);
                devID = words[0];
                unixTimestamp = (Int32)(DateTime.Now.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

                //get serial of device
                byte[] serrialbytes = BitConverter.GetBytes(Convert.ToUInt32(words[1].Split('=').Last()));
                string serial = StringUtils.ByteArrayToHexString(serrialbytes);
                

                // send to server to chec access in server 
                DoorOut doorOut = null;
                bool result = SystemService.Instance.AccessProcess(serial, ipNumber, out doorOut);
                if (result)
                {
                    //mcrReply = devID; Mo cửa
                    mcrReply = devID + "," + CommandUtils.OpenDoorByMilliseconds(milliseconds) + ",TSYNC=" + unixTimestamp.ToString();
                }
                else
                {//mcrReply = devID; đóng cửa
                    mcrReply = devID + "," + CommandUtils.CloseDoor() + ",TSYNC=" + unixTimestamp.ToString();
                }

                AccessMessageService.SendMemberId(doorOut.MemberId.ToString() + "-" + doorOut.Status);
                byte[] sendBytes = Encoding.ASCII.GetBytes(mcrReply);
                clientStream.Write(sendBytes, 0, sendBytes.Length);

            }
            catch
            {
            }   
            tcpClient.Close();
        }

        public void AccessProcessor()
        {

            //get local IP
            IPAddress ipaddress = GetLocalIPAddress();
            if (null == ipaddress)
            {
                System.Console.WriteLine("Cannot login to server at " + DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff",
                   CultureInfo.InvariantCulture));
                return;
            }


            //listen for comming reader device
            tcpListener = new TcpListener(ipaddress, System.Convert.ToInt16(UserLoginConfigSection.Instance.PortReader));
            listenThread = new Thread(new ThreadStart(ListenReaderDeviceClients));
            listenThread.Start();

            //send message to access control
            //Gui memberId cho ung dung le~ tan de show thong tin member + phi quan ly + tien nuoc
            // Parse the server's IP address out of the TextBox
            // Create a new instance of the ChatServer object
            mainServer = new AccessMessageService(ipaddress);
            // Start listening for connections
            mainServer.StartListening();
        }


        public IPAddress GetLocalIPAddress()
        {
            IPHostEntry host;
            IPAddress localIP = null;
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = ip;
                    break;
                }
            }
            return localIP;
        }
    }
}
