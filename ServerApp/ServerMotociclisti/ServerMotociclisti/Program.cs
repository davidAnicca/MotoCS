// See https://aka.ms/new-console-template for more information


namespace ServerMotociclisti
{
    class ServerApp
    {
        public static void Main()
        {
            Console.WriteLine("Server started");
            SockConnections sockConnections = new SockConnections();
            sockConnections.Start();
        }
    }
}