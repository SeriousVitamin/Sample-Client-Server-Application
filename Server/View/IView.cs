using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.View
{
    public interface IView
    {
        event Action<string, int> StartServer;
        event Action CloseServer;

        void ShowLogMessage(string msg);
    }
}
