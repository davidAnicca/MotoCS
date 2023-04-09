using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Motocliclisti.ServerC
{
    public class ServerCom
    {
        private readonly Socket _clientSocket =
            new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        private readonly IPAddress _serverIPAddress = IPAddress.Parse("127.0.0.1");
        private readonly int _serverPort = 12345;

        private Main _controller;
        private Thread _notificationThread;

        public ServerCom(Main controller)
        {
            _controller = controller;
            Start();
        }

        private void Start()
        {
            _clientSocket.Connect(new IPEndPoint(_serverIPAddress, _serverPort));

            string responseMessage = "client connected";
            byte[] responseBuffer = Encoding.ASCII.GetBytes(responseMessage);
            _clientSocket.Send(responseBuffer);

            _notificationThread = new Thread(ReceiveNotifications);
            _notificationThread.IsBackground = true;
            _notificationThread.Start();
        }

        private void ReceiveNotifications()
        {
            byte[] buffer = new byte[1024];

            while (true)
            {
                int bytesReceived = _clientSocket.Receive(buffer);
                string message = Encoding.ASCII.GetString(buffer, 0, bytesReceived);
                AddMessageToDisplay(message);
            }
        }

        private void AddMessageToDisplay(string message)
        {
            try
            {
                _controller.BeginInvoke((MethodInvoker)delegate { _controller.Notify(); });
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}