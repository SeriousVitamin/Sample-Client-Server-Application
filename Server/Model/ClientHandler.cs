using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server.Model
{
    public class ClientHandler : IDisposable, IClientHandler
    {
        private bool _connected = true;
        private const int Size = 4096;
        
        #region - Fields -

        private TcpClient _tcpClient;
        public string Name { get; set; }

        #endregion - Fields -

        #region - Events -

        public event EventHandler<ClientSentMessageEventArgs> SentMessageEvent;

        public event EventHandler<ClientLogEventArgs> LogMessageEvent;
        
        public event EventHandler<ClientChangeNameEvent> ChangeNameEvent;
        
        public event EventHandler<ClientRequestedUsersListEvent> RequestedUsersListEvent;

        #endregion - Events -

        #region - Public methods -
        
        public void Connect(object client)
        {
            _tcpClient = (TcpClient)client;

            var listenThread = new Thread(new ThreadStart(ListenForMessages));
            listenThread.Start();
        }

        public void Disconnect()
        {
            _connected = false;
            _tcpClient.Close();
        }

        public void SendMessage(string text)
        {
            var clientStream = _tcpClient.GetStream();
            var message = Encoding.UTF8.GetBytes(text);
            while (true)
            {
                int bytesRead;
                try
                {
                    bytesRead = clientStream.Read(message, 0, Size);
                }
                catch
                {
                    break;
                }

                if (bytesRead == 0)
                {
                    break;
                }

                var encoder = new UnicodeEncoding();
                var msg = encoder.GetString(message, 0, bytesRead);
                SentMessageEvent(this, new ClientSentMessageEventArgs(Name, msg));

                var result = Action(msg);
                Echo(result, encoder, clientStream);
            }
        }

        public void SendUser(string users)
        {
            
        }

        public void Dispose()
        {
            Disconnect();
        }

        #endregion - Public methods -

        #region - Private methods -

        private void ListenForMessages()
        {
            var clientStream = _tcpClient.GetStream();
            var message = new byte[Size];
            try
            {
                while (_connected)
                {
                    int bytesRead;
                    try
                    {
                        bytesRead = clientStream.Read(message, 0, Size);
                    }
                    catch
                    {
                        break;
                    }

                    if (bytesRead == 0)
                    {
                        break;
                    }

                    var encoder = new UnicodeEncoding();
                    var msg = encoder.GetString(message, 0, bytesRead);

                    var result = Action(msg);
                    Echo(result, encoder, clientStream);
                }
                _tcpClient.Close();
            }
            catch (Exception ex)
            {
                LogMessageEvent(this, new ClientLogEventArgs(Name, ex.ToString()));
            }
            finally
            {
                //Console.ReadLine();
            }
        }

        private void Echo(string msg, UnicodeEncoding encoder, NetworkStream clientStream)
        {
            var buffer = encoder.GetBytes(msg);

            clientStream.Write(buffer, 0, buffer.Length);
            clientStream.Flush();
        }

        private string Action(string msg)
        {
            var result = "Error";
            var strings = msg.Split('|');
            var command = strings[0];
            var text = msg.Replace(command, string.Empty);

            switch (strings[0])
            {
                case "0":
                    // change name
                    ChangeNameEvent(this, new ClientChangeNameEvent(text));
                    result = "Success";
                    break;
                case "1":
                    // get users
                    RequestedUsersListEvent(this, new ClientRequestedUsersListEvent(Name));
                    result = "Success";
                    break;
                case "2":
                    // sent message
                    SentMessageEvent(this, new ClientSentMessageEventArgs(Name, text));
                    result = "Success";
                    break;
            }

            return result;
        }

        #endregion - Private methods -
    }
}
