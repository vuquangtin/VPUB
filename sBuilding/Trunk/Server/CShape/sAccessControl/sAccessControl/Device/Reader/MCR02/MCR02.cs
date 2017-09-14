using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace sAccessControl.Device.Reader.MCR02
{
    public class MCR02
    {
        private static TcpListener tcpListener;
        private static Thread listenThread;

        public volatile static int NumberofClients;
        static readonly object _locker = new object();

        public static string msUser;
        public static string msPass;
        public static string msURL;

        public static string myUser;
        public static string myPass;
        public static string myURL;
        public static string serverPORT;
        public static int cFlag;

        public static string WelcomeMessage;

        private static void ListenForClients()
        {
            tcpListener.Start();

            while (true)
            {
                //blocks until a client has connected to the server
                TcpClient client = tcpListener.AcceptTcpClient();

                //create a thread to handle communication 
                //with connected client
                Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                clientThread.Start(client);

                Thread.Sleep(10);
            }
        }


        // This method's signature must match the TimerCallback delega
        private static void OutBoxHandler(Object state)
        {
            // This method is executed by a thread pool thread
        }

        /*
         * // get your files (names)
            string[] fileNames = Directory.GetFiles("c:\\Temp\\", "*.*");

            // Now read the creation time for each file
            DateTime[] creationTimes = new DateTime[fileNames.Length];
            for (int i=0; i < fileNames.Length; i++)
            creationTimes[i] = new FileInfo(fileNames[i]).CreationTime;

            // sort it
            Array.Sort(creationTimes,fileNames);

            // and print for test
            Console.WriteLine("Files ordered by creation time");
            for (int i=0; i < fileNames.Length; i++)
                Console.WriteLine("{0}: {1}", creationTimes[i], fileNames[i]);

         */

        private static void HandleClientComm(object client)
        {
            string data = null;
            TcpClient tcpClient = (TcpClient)client;
            NetworkStream clientStream = tcpClient.GetStream();
            tcpClient.ReceiveTimeout = 90 * 1000;
            byte[] message = new byte[4096];
            int bytesRead;
            string devID = "";
            string ipNumber = "";
            string mcrReply = "";
            string ServerEchoStr = "";
            Int32 unixTimestamp;

            ipNumber = ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString();

            //AddLog.LogtoFile("Server", "Received Socket Connection...IP Number: " + ipNumber);

            ++NumberofClients;

            while (true)
            {
                bytesRead = 0;
                data = "";

                try
                {
                    //blocks until a client sends a message
                    bytesRead = clientStream.Read(message, 0, 4096);
                    data = Encoding.ASCII.GetString(message, 0, bytesRead);
                }
                catch
                {
                    //AddLog.LogtoFile("Server", "Data Receive Error: " + data);
                    //AddLog.LogtoFile("Server", "Data Receive Error Disconnecting Client...1");
                    break;
                }

                if (bytesRead == 0)
                {
                    //AddLog.LogtoFile("Server", "Client Disconnedted From Server...2");
                    break;
                }

                data = data.Trim();

                char[] comma = { ',' };
                string[] words = data.Split(comma);

                devID = words[0];

                //ServerEchoStr = ini.IniReadValue("SERVER_ECHO", "ECHO_STRING");

                unixTimestamp = (Int32)(DateTime.Now.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

                //mcrReply = devID;
                mcrReply = devID + "," + CommandUtils.OpenDoorByMilliseconds(500) + ",TSYNC=" + unixTimestamp.ToString();

                //Console.ForegroundColor = ConsoleColor.White;
                //AddLog.LogtoFile("Server", ipNumber + " ; " + devID + " Data From:\n" + data);
                //Console.ForegroundColor = ConsoleColor.Green;


                //Send a Reply Message
                try
                {
                    byte[] sendBytes = Encoding.ASCII.GetBytes(mcrReply);
                    clientStream.Write(sendBytes, 0, sendBytes.Length);
                    //Console.ForegroundColor = ConsoleColor.Gray;
                    //AddLog.LogtoFile("Server", ipNumber + " ; " + devID + " Data Sent:\n" + mcrReply);
                    //Console.ForegroundColor = ConsoleColor.Green;
                }
                catch
                {
                    //AddLog.LogtoFile("Server", "Data Write Error to Socket...");
                    break;
                }

                if (cFlag != 0)
                    break;
            }

            //Console.ForegroundColor = ConsoleColor.Red;
            //AddLog.LogtoFile("Server", "Client Disconnected or Timeout Occured...");
            //Console.ForegroundColor = ConsoleColor.Green;

            --NumberofClients;

            //t.Dispose();
            tcpClient.Close();
        }

        // This method's signature must match the TimerCallback delega
        public static void GSATimer(Object state)
        {
            int tmpNumberofClients;

            tmpNumberofClients = NumberofClients;

            //lock (_locker)
            //{
            //    tmpNumberofClients = NumberofClients;
            //}

            // This method is executed by a thread pool thread 
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(DateTime.Now + ": Server Alive...Active Clients Count: " + tmpNumberofClients.ToString());
            Console.ForegroundColor = ConsoleColor.Green;
        }
    }
}
