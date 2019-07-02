using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using RestSharp;

namespace gu_provider_ui_windows
{
    public partial class MainForm : Form
    {
        private RestClient restClient = new RestClient("http://127.0.0.1:61621");

        public MainForm()
        {
            InitializeComponent();

            var req = new RestRequest("lan/list", Method.GET);
            var res = restClient.Execute(req);
            List<HubInfo> hosts = JsonConvert.DeserializeObject<List<HubInfo>>(res.Content);
            foreach (HubInfo host in hosts)
            {
                if (host.Description.StartsWith("node_id="))
                {
                    nodeList.Rows.Add(false, host.HostName, host.Addresses, host.Description.Substring(8));
                }
            }
        }

        private void AddHubButton_Click(object sender, EventArgs e)
        {
            var f = new AddHubForm();
            f.StartPosition = FormStartPosition.CenterParent;
            var result = f.ShowDialog();
            if (result == DialogResult.OK)
            {
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void ConfigureMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void NotifyIcon_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}

class HubInfo
{
    [JsonProperty("Service type")]
    public string ServiceType { get; set; }
    [JsonProperty("Host name")]
    public string HostName { get; set; }
    public string Addresses { get; set; }
    public string Description { get; set; }
}
