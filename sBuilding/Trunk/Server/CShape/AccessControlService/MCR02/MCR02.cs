using AccessControlService;
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
using AccessControlService.Camera.LibVLC;
using System.Configuration;
using System.Drawing;
using System.Timers;

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


        #region sTimeKeeping
        private static bool UseTimeKeeping = false;
        private static LibvlcMediaPlayer videoSource;
        private static string source = "";
        private static System.Timers.Timer aTimer;
        #endregion

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
            stopServer();
        }



        public void startAccessProcessor()
        {
            initServer(System.Convert.ToInt16(UserLoginConfigSection.Instance.Number));
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

        /// <summary>
        /// create server listener
        /// </summary>
        /// <param name="number"></param>
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

            #region sTimeKeeping start camera
            try
            {
                // sTimeKeeping kiểm tra config có sử dụng timekeeping hay không?
                UseTimeKeeping = ConfigurationManager.AppSettings["use_timekeeping"].Equals("true");
                // đường dẫn camera trong file config
                source = ConfigurationManager.AppSettings["camera_address"];
                if (UseTimeKeeping)
                {
                    LibvlcMedia media = new LibvlcMedia(LibvlcInstance.GetInstance(), source);
                    videoSource = new LibvlcMediaPlayer(media);
                    CheckCamera();
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
            }

            #endregion

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
            }
        }

        /// <summary>
        /// follow and read data asynchronyc
        /// </summary>
        /// <param name="client"></param>
        private void ClientConnectionHander(object client)
        {
            TcpClient tcpClient = (TcpClient)client;
            Socket socket = tcpClient.Client;
            string ipNumber = ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString();
            SocketHandler handler = new SocketHandler(tcpClient.Client, ipNumber, session);
            handler.StartRead();
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

        #region sTimeKeeping TakeSnapShot
        public Image TakeSnapShot()
        {
            // kiểm tra video play, nếu chưa thì play
            //videoSource.CheckPlayVideo();
            // chụp hình
            return videoSource.TakeSnapshot();
        }
        #endregion
        #region sTimeKeeping timer

        private static void CheckCamera()
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(30000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private static void OnTimedEvent(Object obj, ElapsedEventArgs e)
        {
            if (UseTimeKeeping)
            {
                if (!videoSource.CheckIsPlay())
                {
                    Console.WriteLine("not Play");
                    videoSource.Dispose();
                    LibvlcMedia media = new LibvlcMedia(LibvlcInstance.GetInstance(), source);
                    videoSource = new LibvlcMediaPlayer(media);
                }
                else 
                {
                    Console.WriteLine("Play");
                }
            }
        }
        #endregion
    }
}
