// todo tcpListener.Close

using System.Text;

namespace Server.Model
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading;

    class Server : IModel
    {
        private TcpListener _tcpListener;

        private bool _isRunning;
        private Chat _chat = new Chat();
        private List<ClientHandler> _clients = new List<ClientHandler>();

        public event Action<string> LogMessage;

        private void SendMessageToClients(List<ClientHandler> clients, string message)
        {
            for (int i = 0; i < clients.Count; i++)
            {
                //clients[i].SendMessage(clients[i], message);
            }
        }

        private void ClientSentMessageEventHandler(object sender, ClientSentMessageEventArgs e)
        {
            _chat.AddMessage(e.Name, DateTime.Now, e.Message);
            var clients = _clients;
            clients.RemoveAt(_clients.FindIndex(cl => cl.Name == e.Name));
            SendMessageToClients(clients, e.Message);
        }
        
        private void ListenForClients()
        {
            _tcpListener.Start();

            while (_isRunning)
            {
                var tcpClient = _tcpListener.AcceptTcpClient();

                var client = new ClientHandler();
                client.SentMessageEvent += ClientSentMessageEventHandler;
                _clients.Add(client);

                var clientThread = new Thread(new ParameterizedThreadStart(client.Connect));
                clientThread.Start(tcpClient);
            }
        }

        public void StartServer(IPAddress address, int port)
        {
            _isRunning = true;
            _tcpListener = new TcpListener(address, port);

            var listenThread = new Thread(new ThreadStart(ListenForClients));
            listenThread.Start();
        }

        public void CloseServer()
        {
            _isRunning = false;
            _clients.ForEach(client => client.Disconnect());
            _tcpListener.Stop();
        }
    }
}
