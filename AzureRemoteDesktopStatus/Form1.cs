using System;
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

        private void Log(string state)
        {
            logTextBox.AppendText($"{DateTime.Now:u}> {state}\r\n");
        }
    }
}