using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace WebControlApplication
{
    public partial class GeneralForm : Form
    {
        private const string PARAM_IP = "default_ip";
        private const string PARAM_PORT = "default_port";

        private static Server server;
        private readonly static string configFile = Path.Combine(Directory.GetCurrentDirectory(), "config.cfg");
        private readonly Dictionary<string, string> config = new Dictionary<string, string>();

        public GeneralForm()
        {
            InitializeComponent();

            if (File.Exists(configFile))
            {
                string[] lines = File.ReadAllLines(configFile);
                foreach (string line in lines)
                {
                    string[] configFromFile = line.Split('=');
                    if (configFromFile.Length == 2 && string.IsNullOrWhiteSpace(configFromFile[1]) == false)
                    {
                        config.Add(configFromFile[0].Trim(), configFromFile[1].Trim());
                    }
                }
            }

            server = new Server(this);
            this.inputIp.Text = Server.GetLocalIPAddress();
            if (config.ContainsKey(PARAM_IP) && config.ContainsKey(PARAM_PORT))
            {
                this.inputIp.Text = config[PARAM_IP];
                this.inputPort.Text = config[PARAM_PORT];
                this.OpenConnect();
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.HideForm();
            }
        }

        private void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.OpenForm();
        }

        public void Log(string code)
        {
            code += Environment.NewLine;
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(Log), new object[] { code });
                return;
            }
            this.textBoxLog.Text += code;
        }

        private void OpenForm()
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }

        private void HideForm()
        {
            this.Hide();
            this.WindowState = FormWindowState.Minimized;
            notifyIcon.Visible = true;
        }

        private void OpenConnect()
        {
            server.Start();

            this.buttonConnect.Enabled = false;
            this.inputIp.Enabled = false;
            this.inputPort.Enabled = false;
            this.buttonCloseConnect.Enabled = true;

            this.HideForm();
        }

        private void CloseConnect()
        {
            server.Stop();

            this.buttonConnect.Enabled = true;
            this.inputIp.Enabled = true;
            this.inputPort.Enabled = true;
            this.buttonCloseConnect.Enabled = false;
        }

        private void ButtonConnect_Click(object sender, EventArgs e)
        {
            this.OpenConnect();
        }

        private void ButtonCloseConnect_Click(object sender, EventArgs e)
        {
            this.CloseConnect();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            using (FileStream file = File.Create(configFile))
            {
                string[] content = new string[2];
                content[0] = PARAM_IP + "=" + this.inputIp.Text;
                content[1] = PARAM_PORT + "=" + this.inputPort.Text;
                
                byte[] info = new UTF8Encoding(true).GetBytes(string.Join(Environment.NewLine, content));
                file.Write(info, 0, info.Length);
                this.Log(configFile + " saved");
            } 
        }
    }
}
