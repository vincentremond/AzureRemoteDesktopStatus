using System;
using System.Net.Sockets;
using System.Windows.Forms;

namespace AzureRemoteDesktopStatus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void startButton_Click(object sender, EventArgs e)
        {
            try
            {
                await AzureHelper.Start();
                Log("Start requested");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }

        private async void stopButton_Click(object sender, EventArgs e)
        {
            try
            {
                await AzureHelper.Deallocate();
                Log("Deallocate requested");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }

        private async void refreshButton_Click(object sender, EventArgs e)
        {
            try
            {
                var state = await AzureHelper.Refresh();
                Log(state);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }

        private async void testButton_Click(object sender, EventArgs e)
        {
            try
            {
                Log($"Trying to connect to {Constants.HostName}:{Constants.RdpPort}");
                var result = TestTcpConnection(Constants.HostName, Constants.RdpPort);
                Log(result ? "Success" : "Failure");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }

        private static bool TestTcpConnection(string hostName, int rdpPort)
        {
            try
            {
                using var tcpClient = new TcpClient();
                tcpClient.Connect(hostName, rdpPort);
                return tcpClient.Connected;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private void Log(string state)
        {
            logTextBox.AppendText($"{DateTime.Now:u}> {state}\r\n");
        }
    }
}