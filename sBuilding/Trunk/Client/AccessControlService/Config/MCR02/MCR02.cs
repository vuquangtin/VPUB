using AccessControlService;
using AccessControlService.Service;
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
using JavaCommunication.Factory;
using CommonControls;
using System.ServiceModel;
using sWorldModel.Exceptions;
using sTimeKeeping.Model;
using AccessControlService.Camera.LibVLC;
using System.Drawing;
using ImageAccessor;
using CommonHelper.Utils;

namespace sAccessControl.Device.Reader.MCR02
{
    public class MCR02
    {
        //   private static TcpListener tcpListener;
        //  private static Thread listenThread;
        private static int milliseconds = UserLoginConfigSection.Instance.TimeOpenDoor;

        private AccessMessageService mainServer;
        private SessionDTO session = null;

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

        public static Int64 index = 0; //for testing only
        public static List<TcpListener> listTcpListener = new List<TcpListener>();

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
            // tcpListener.Stop();
            stopServer();
        }

        /*
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

                //Thread.Sleep(20);
            }
        }

         * */
        /*
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

                //data = data.Trim();
                String[] words = data.Split(',');
                if (words.Length >= 2 && words[1].StartsWith("UID="))
                {
                    devID = words[0];
                    unixTimestamp = (Int32)(DateTime.Now.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                    String UID = words[1].Substring(4);

                    //for testing only
                    //Console.WriteLine(hastable[tcpClient].ToString() + " " + ipNumber + " - begin " + DateTime.Now.ToString("HH:mm:ss tt") + data);
                    
                    //get serial of device
                    //byte[] serrialbytes = BitConverter.GetBytes(Convert.ToUInt32(words[1].Split('=').Last()));
                    byte[] serrialbytes = BitConverter.GetBytes(Convert.ToUInt32(UID));
                    string serial = StringUtils.ByteArrayToHexString(serrialbytes);

                    serial = "246F284C";
                    // send to server to chec access in server 
                    DoorOut doorOut = null;
                    bool result = SystemService.Instance.AccessProcess(serial, ipNumber, out doorOut);
                    
                    if (result)
                    {
                        //mcrReply = devID; Mo cửa
                        mcrReply = devID + "," + CommandUtils.OpenDoorByMilliseconds(milliseconds) + ",TSYNC=" + unixTimestamp.ToString();
                    }
                    else
                    {
                        //mcrReply = devID; đóng cửa
                        mcrReply = devID + "," + CommandUtils.CloseDoor() + ",TSYNC=" + unixTimestamp.ToString();
                    }

                    byte[] sendBytes = Encoding.ASCII.GetBytes(mcrReply);
                    clientStream.Write(sendBytes, 0, sendBytes.Length);
                    clientStream.Flush();
                    clientStream.Close();

                    //for testing only
                    //Console.WriteLine(hastable[tcpClient].ToString() + " " +ipNumber + " - finish " + DateTime.Now.ToString("HH:mm:ss tt") + data);


                    AccessMessageService.SendMemberId(doorOut.MemberId.ToString() + "-" + doorOut.Status);
                }
                

            }
            catch(Exception e)
            {
                Console.WriteLine("111" + e.Message);
            }
            finally
            {
                tcpClient.Close();
            }
        }

        */
        public void startAccessProcessor()
        {
            initServer(System.Convert.ToInt16(UserLoginConfigSection.Instance.Number));
        }

        /*
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

        */
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


        private void initServer(int number)
        {
            //get local IP
            IPAddress ipaddress = GetLocalIPAddress();
            if (null == ipaddress)
            {
                System.Console.WriteLine("Cannot login to server at " + DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff",
                   CultureInfo.InvariantCulture));
                return;
            }

            int port = System.Convert.ToInt16(UserLoginConfigSection.Instance.PortReader);
            for (int i = 0; i < number; i++)
            {

                int tmpport = port + i;
                TcpListener tcplistener = new TcpListener(ipaddress, tmpport);
                Thread listenThread = new Thread(new ParameterizedThreadStart(MultiListenerReaderClients));
                listenThread.Start(tcplistener);
                listTcpListener.Add(tcplistener);
                System.Console.WriteLine(DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff",
                   CultureInfo.InvariantCulture) + " Server start at " + tmpport.ToString());
            }
#if!_PASSED
            //login to server
            while (session == null)
            {
                session = Login();
            }
#endif
            //send message to access control
            //Gui memberId cho ung dung le~ tan de show thong tin member + phi quan ly + tien nuoc
            // Parse the server's IP address out of the TextBox
            // Create a new instance of the ChatServer object
            mainServer = new AccessMessageService(ipaddress);
            // Start listening for connections
            mainServer.StartListening();


        }

        private void stopServer()
        {
            foreach (TcpListener obj in listTcpListener)
            {
                obj.Stop();
            }
        }
        private void MultiListenerReaderClients(object obj)
        {
            TcpListener listener = (TcpListener)obj;
            listener.Start();

            while (AccessStatus)
            {
                //blocks until a client has connected to the server
                TcpClient client = listener.AcceptTcpClient();

                //create a thread to handle communication 
                //with connected client
                Thread clientThread = new Thread(new ParameterizedThreadStart(ClientConnectionHander));
                clientThread.Start(client);

                //Thread.Sleep(20);
            }
        }

        private void ClientConnectionHander(object client)
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
            Console.Write(ipNumber + " ");
            bytesRead = 0;

            try
            {
                //blocks until a client sends a message
                bytesRead = clientStream.Read(message, 0, 4096);
                data = Encoding.ASCII.GetString(message, 0, bytesRead);

                if (bytesRead == 0)
                    return;

                String[] words = data.Split(',');
                String UID = "123456789";
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
                    unixTimestamp = (Int32)(DateTime.Now.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

                    //byte[] serrialbytes = BitConverter.GetBytes(Convert.ToUInt32(UID));
                    //string serial = StringUtils.ByteArrayToHexString(serrialbytes);

                    string serial = UID;
                    // send to server to chec access in server 
                    DoorOut doorOut = null;

                    #region phan tag the cham cong
                    //kiem tra config co su dung timekeeping ko?
                    if (UserLoginConfigSection.Instance.UseTimeKeeping == "true")
                    {
                        //mo thread
                        Thread clientThread = new Thread(new ParameterizedThreadStart(TimeKeepingProcess));
                        clientThread.Start(serial + "-" + ipNumber);

                    }

                    #endregion
#if !_PASSED
                    SystemService service = new SystemService(session);
                    bool result = service.AccessProcess(serial, ipNumber, out doorOut);

                    if (result)
                    {
                        //mcrReply = devID; Mo cửa
                        mcrReply = devID + "," + CommandUtils.OpenDoorByMilliseconds(milliseconds) + ",TSYNC=" + unixTimestamp.ToString();
                        Console.WriteLine(" Serial=" + serial + " card data=" + words[1] + "--open");
                    }
                    else
                    {
                        //mcrReply = devID; đóng cửa
                        mcrReply = devID + "," + CommandUtils.CloseDoor() + ",TSYNC=" + unixTimestamp.ToString();
                        Console.WriteLine(" Serial=" + serial + " card data=" + words[1] + "--close");
                    }

                    byte[] sendBytes = Encoding.ASCII.GetBytes(mcrReply);
                    clientStream.Write(sendBytes, 0, sendBytes.Length);
                    clientStream.Flush();
                    clientStream.Close();

                    if (doorOut != null)
                    {
                        Thread messageThread = new Thread(new ParameterizedThreadStart(ThreadSendMessage));
                        messageThread.Start(doorOut.MemberId.ToString() + "-" + doorOut.Status);
                    }
#else
                    mcrReply = devID + "," + CommandUtils.OpenDoorByMilliseconds(milliseconds) + ",TSYNC=" + unixTimestamp.ToString();
                    Console.WriteLine("Pass add serial=" + serial + "--open");
                    byte[] sendBytes = Encoding.ASCII.GetBytes(mcrReply);
                    clientStream.Write(sendBytes, 0, sendBytes.Length);
                    clientStream.Flush();
                    clientStream.Close();
#endif
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(DateTime.Now.ToString("HH:mm:ss tt") + " " + e.Message);
            }
            finally
            {
                tcpClient.Close();
            }
        }

        public void ThreadSendMessage(object msg)
        {
            mainServer.SendMemberIdToReciption((string)msg);
        }

        private SessionDTO Login()
        {
            try
            {
                session = AuthenticationFactory.Instance.GetChannel().Login(UserLoginConfigSection.Instance.User, UserLoginConfigSection.Instance.Password);
            }
            catch (System.TimeoutException)
            {
                Console.WriteLine(CommonMessages.TimeOutExceptionMessage);
                Console.ReadLine();
                session = null;
                return session;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
                session = null;
                return session;
            }

            return session;
        }

        public void TimeKeepingProcess(object param)
        {
            string[] itemList = ((string)param).Split('-');
            if (itemList.Length > 0)
            {
                string serial = itemList[0];
                string ipNumber = itemList[1];
                SystemService service = new SystemService(session);
                //kiem tra dau doc
                TimeKeepingAcessDTO result = service.checkIpDeviceForTimeKeeping(serial, ipNumber);
                if (null != result)
                {
                    // insert
                    Shift shift = new Shift();
                    //DateTime date = DateTime.Now;
                    //shift.dateIn = date.ToString("yyyy-MM-dd HH:mm:ss");
                    shift.deviceDoorId = result.deviceDoorId;
                    shift.deviceDoorIp = ipNumber;
                    shift.memberId = result.memberId;
                    shift.serialNumber = serial;

                    Shift shiftResult = service.insertShift(shift);

                    string source = @"rtsp://192.168.1.90:554/video.mp4";

                    LibvlcMedia media = new LibvlcMedia(LibvlcInstance.GetInstance(), source);

                    LibvlcMediaPlayer videoSource = new LibvlcMediaPlayer(media);

                    Image image = videoSource.TakeSnapshot();

                    IImageRepository imageRepository = ImageRepositoryManager.Instance.GetRepository();
                    try
                    {
                        imageRepository.SaveTimeKeepingImages(shiftResult.Id , ImageUtils.ImageToByteArray(image));
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
        }
    }
}
