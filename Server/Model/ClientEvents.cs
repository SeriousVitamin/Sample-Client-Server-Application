using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Model
{
    public class ClientLogEventArgs : EventArgs
    {
        public string Name { get; private set; }
        public string LogMessage { get; private set; }

        public ClientLogEventArgs(string clientName, string logMessage)
        {
            Name = clientName;
            LogMessage = logMessage;
        }
    }

    public class ClientSentMessageEventArgs : EventArgs
    {
        public string Name { get; private set; }
        public string Message { get; private set; }

        public ClientSentMessageEventArgs(string clientName, string message)
        {
            Name = clientName;
            Message = message;
        }
    }

    public class ClientRequestedUsersListEvent : EventArgs
    {
        public string Name { get; private set; }

        public ClientRequestedUsersListEvent(string name)
        {
            Name = name;
        }
    }

    public class ClientChangeNameEvent : EventArgs
    {
        public string NewName { get; private set;}

        public ClientChangeNameEvent(string newName)
        {
            NewName = newName;
        }
    }
}
