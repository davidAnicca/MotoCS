using System.Data.SQLite;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ServerMotociclisti;

public class SockConnections
{
    private Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    private IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
    private int port = 12345;
    private string _constring;

    public void Start()
    {
        bdConfig();

        serverSocket.Bind(new IPEndPoint(ipAddress, port));
        serverSocket.Listen(5);

        while (true)
        {
            try
            {
                Socket clientSocket = serverSocket.Accept();
                Thread clientThread = new Thread(() =>
                {
                    byte[] buffer = new byte[1024];
                    int bytesReceived = clientSocket.Receive(buffer);

                    string receivedMessage = Encoding.ASCII.GetString(buffer, 0, bytesReceived);
                    Console.WriteLine("Received message from client: " + receivedMessage);

                    string responseMessage = "Hello from server!";
                    byte[] responseBuffer = Encoding.ASCII.GetBytes(responseMessage);
                    clientSocket.Send(responseBuffer);

                    SendWhenChanged(clientSocket);
                });
                clientThread.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    private void bdConfig()
    {
        StreamReader reader = new StreamReader("bd.config");
        _constring = reader.ReadLine();
    }

    private void SendWhenChanged(Socket clientSock)
    {
        int prevCount = 0;
        while (true)
        {
            int currentCount = GetCount();
            if (prevCount != currentCount)
            {
                prevCount = currentCount;
                string message = "Mesaj spam!";
                byte[] messageBuffer = Encoding.ASCII.GetBytes(message);
                clientSock.Send(messageBuffer);
            }

            Thread.Sleep(5000);
        }
    }

    private int GetCount()
    {
        using (SQLiteConnection connection = new SQLiteConnection(
                   _constring))
        {
            int count = 0;
            connection.Open();
            using (SQLiteCommand command = new SQLiteCommand("select count(name) cn from participants", connection))
            {
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        count = reader.GetInt16(reader.GetOrdinal("cn"));
                    }
                }
            }

            connection.Close();
            return count;
        }
    }
}