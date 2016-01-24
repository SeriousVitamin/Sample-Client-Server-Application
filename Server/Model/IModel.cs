using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Server.Model
{
    public interface IModel
    {
        event Action<string> LogMessage;
        void StartServer(IPAddress address, int port);
        void CloseServer();
    }
}
