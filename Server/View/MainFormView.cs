// TODO: Add multithreading to call StartServer

namespace Server.View
{
    using System;
    using System.Windows.Forms;

    public partial class MainFormView : Form, IView
    {
        public MainFormView()
        {
            InitializeComponent();
            mtbAddress.ValidatingType = typeof(System.Net.IPAddress);
        }

        public event Action<string, int> StartServer;
        public event Action CloseServer;
        public void ShowLogMessage(string msg)
        {
            rtbLog.Text += msg + "\r\n";
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var address = mtbAddress.Text;
            var port = int.Parse(tbPort.Text);

            StartServer(address, port);
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseServer();
        }
    }
}
