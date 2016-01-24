// TODO: Add multithreading to call StartServer

using System.Net;

namespace Server.View
{
    using System;
    using System.Windows.Forms;

    public partial class MainFormServerView : Form, IView
    {
        public MainFormServerView()
        {
            InitializeComponent();
            mtbAddress.ValidatingType = typeof(IPAddress);
        }

        public event Action<IPAddress, int> StartServer;
        public event Action CloseServer;
        public void ShowLogMessage(string msg)
        {
            rtbLog.Text += msg + "\r\n";
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IPAddress ipAddress;

            // BUG Why i must do this: replace , to . ?? Mask is ###.###.###.### !
            if (IPAddress.TryParse(mtbAddress.Text.Replace(',','.'), out ipAddress))
            {
                //valid ip
                
            }
            else
            {
                throw new Exception("Uncorrect ip-address");
                //is not valid ip
            }

            var port = int.Parse(tbPort.Text);

            StartServer(ipAddress, port);
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseServer();
        }
    }
}
