using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystemServer
{
    class ClientObject
    {
        protected internal string Id { get; private set; }
        protected internal NetworkStream Stream { get; private set; }
        TcpClient client;
        String ip;
        ServerObject server;

        public ClientObject(TcpClient tcpClient, ServerObject serverObject)
        {
            Id = Guid.NewGuid().ToString();
            ip = ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString();
            client = tcpClient;
            server = serverObject;
            serverObject.AddConnection(this);

            Console.WriteLine(ip + " Подключился");
        }

        public void Process()
        {
            try
            {
                Stream = client.GetStream();

                while (true)
                {
                    try
                    {
                        var message = GetMessage();
                        Console.WriteLine(ip + ":" + message);
                        server.ReciveMessage(message);
                        if (message.Contains("#"))                      
                            server.BroadcastMessage(message);
                    }
                    catch
                    {
                        Console.WriteLine("Ошибка соединения");
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                server.RemoveConnection(this.Id);
                Close();
            }
        }

        private string GetMessage()
        {
            byte[] data = new byte[64];
            StringBuilder builder = new StringBuilder();
            int bytes = 0;
            do
            {
                bytes = Stream.Read(data, 0, data.Length);
                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            }
            while (Stream.DataAvailable);

            return builder.ToString();
        }

        protected internal void Close()
        {
            if (Stream != null)
                Stream.Close();
            if (client != null)
                client.Close();
        }
    }
}
