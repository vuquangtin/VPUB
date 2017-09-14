using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ReaderManager.Reader.MCR02
{
    public class NetworkService
    {

        #region Properties

        private TcpListener tcpListener;
        //biến core của class, quyết định việc on/off service.
        private volatile bool isServiceOn;

        // EventHandler của việc sự kiện tag thẻ.
        public EventDelegate.TagDetectedHandler TagDetected;

        #endregion

        //Contrustor
        public NetworkService(int serPort)
        {
            //Khởi tạo tcpListener, dùng để lắng nghe request của reader.
            tcpListener = new TcpListener(getServerAddress(), serPort);
            //Mặc định off
            isServiceOn = false;
        }

        #region Public Method

        //khởi chạy service
        public bool StartService()
        {
            if (!isServiceOn)
            {
                //chỉ chạy khi đang off
                new Thread(new ThreadStart(ListenForClients)).Start();
                isServiceOn = true;
            }
            //trả về tình trạng on/off của service.
            return isServiceOn;
        }

        //dừng service.
        public void StopService()
        {
            isServiceOn = false;
        }

        #endregion

        #region Private Methods

        private void ListenForClients()
        {
            //bắt đầu lắng nghe
            tcpListener.Start();

            //chạy cho tới khi StopService() được gọi
            while (isServiceOn)
            {
                //nếu không connection request trong hàng đợi thì sleep 0.1s
                //nhằm tăng hiệu quả của luồng.
                if (!tcpListener.Pending())
                {
                    Thread.Sleep(100);
                    continue;
                }

                try
                {
                    //lấy connection request từ hàng đợi
                    TcpClient client = tcpListener.AcceptTcpClient();
                    //tạo luồng mới để xử lý cho connection này.
                    new Thread(new ParameterizedThreadStart(HandleEachClient)).Start(client);
                }
                catch
                {
                    //phòng hờ lỗi đặc biệt từ mạng.
                    break;
                }
            }
            //dừng việc lắng nghe
            tcpListener.Stop();
        }

        //xử lý cho 1 connection request.
        private void HandleEachClient(object client)
        {
            //vì ParameterizedThreadStart chỉ nhận object nên phải ép kiểu lại
            TcpClient tcpClient = (TcpClient)client;
            //biến dùng để đọc dữ liệu từ mạng.
            NetworkStream clientStream = tcpClient.GetStream();
            //thời gian chờ đọc dữ liệu, phải có để phòng ngừa quá tải.
            clientStream.ReadTimeout = 1000;

            //các biến dùng trong việc đọc request data
            string data = "", cmd;
            byte[] holder = new byte[4096];
            int bytesRead = 0;

            //bỏ vào loop chạy 1 lần chỉ vì mục đích brake ra skip code.
            do
            {
                try
                {
                    //đọc request data từ connection này.
                    bytesRead = clientStream.Read(holder, 0, 4096);
                    data = Encoding.ASCII.GetString(holder, 0, bytesRead);
                }
                catch
                {
                    //đọc không được thì bỏ (tương đương với 1 lần tag thẻ ko ăn)
                    break;
                }

                //data empty (tương đương dọc dữ liệu sai).
                if (bytesRead == 0)
                    break;

                // Hàm StopService() được gọi trong quá trình đọc request data.
                if (!isServiceOn)
                    break;

                //mục đích để parse request ra devID và UID
                TerminalRequest request = new TerminalRequest(data);

                if (TagDetected != null)
                {
                    //fire event, nhận về cmd
                    TagDetected(request.UID, out cmd);
                    //bổ sung thông tin cho cmd
                    cmd = request.devID + "," + cmd;
                }
                else
                    //quăng lỗi Event chưa được app implement.
                    throw new MCRException(MCRException.EVENT_NOT_FOLLOWED);

                try
                {
                    //gửi cmd tới reader
                    byte[] sendBytes = Encoding.ASCII.GetBytes(cmd);
                    clientStream.Write(sendBytes, 0, sendBytes.Length);
                }
                catch
                {
                    throw new MCRException(MCRException.CANNOT_SEND_REPLY);
                }
            } while (false);

            //close tcp
            tcpClient.GetStream().Close();
            tcpClient.Close();
        }

        //trả về IP của máy đang sử dụng lib.
        private IPAddress getServerAddress()
        {
            return Dns.GetHostEntry(Dns.GetHostName()).AddressList.Where(o => o.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).First();
        }

        #endregion
    }
}
