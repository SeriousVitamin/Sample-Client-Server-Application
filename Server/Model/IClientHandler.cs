using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server.Model
{
    interface IClientHandler
    {
        void Connect(object client);
        void Disconnect();
    }
}
