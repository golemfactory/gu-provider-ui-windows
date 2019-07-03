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
        private readonly RestClient restClient = new RestClient("http://127.0.0.1:61621");

        public MainForm()
        {
            InitializeComponent();
            this.checkProviderStatus.Enabled = true;
        }

        private void ReloadHubList()
        {
            var autoMode = restClient.Execute(new RestRequest("nodes/auto", Method.GET));
            if (autoMode.StatusCode == System.Net.HttpStatusCode.OK)
            {
                autoConnect.Checked = autoMode.Content.Contains("true");
            }

            nodeList.Rows.Clear();

            HashSet<string> allNodes = new HashSet<string>();

            var lanListRes = restClient.Execute(new RestRequest("lan/list", Method.GET));
            if (lanListRes.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var hosts = JsonConvert.DeserializeObject<List<NodeInfo>>(lanListRes.Content);
                if (hosts != null)
                {
                    foreach (var host in hosts)
                    {
                        bool status = restClient.Execute(new RestRequest(host.NodeId(), Method.GET)).Content.Contains("true");
                        nodeList.Rows.Add(status, host.Name, host.Address, host.NodeId());
                        allNodes.Add(host.NodeId());
                    }
                }
            }

            var savedNodesRes = restClient.Execute(new RestRequest("nodes?saved", Method.GET));
            if (savedNodesRes.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var hosts = JsonConvert.DeserializeObject<List<SavedNodeInfo>>(savedNodesRes.Content);
                if (hosts != null)
                {
                    foreach (var host in hosts)
                    {
                        bool status = restClient.Execute(new RestRequest(host.NodeId, Method.GET)).Content.Contains("true");
                        if (!allNodes.Contains(host.NodeId))
                        {
                            nodeList.Rows.Add(status, host.Name, host.Address, host.NodeId);
                        }
                    }
                }
            }
        }

        private void AddHubButton_Click(object sender, EventArgs e)
        {
            var f = new AddHubForm
            {
                StartPosition = FormStartPosition.CenterParent
            };
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

        private void AutoConnect_CheckedChanged(object sender, EventArgs e)
        {
            restClient.Execute(new RestRequest("nodes/auto",
                    this.autoConnect.CheckState == CheckState.Checked ? Method.PUT : Method.DELETE, DataFormat.Json)
                .AddHeader("Content-type", "application/json").AddJsonBody(new {}));
            restClient.Execute(new RestRequest("connections/mode/"
                + (this.autoConnect.CheckState == CheckState.Checked ? "auto" : "manual")
                + "?save=1", Method.PUT));
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            this.ReloadHubList();
        }

        private void CheckProviderStatus_Tick(object sender, EventArgs e)
        {
            var res = restClient.Execute(new RestRequest("status?timeout=1", Method.GET));
            if (res.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var statusObj = JsonConvert.DeserializeObject<ServerStatusInfo>(res.Content);
                if (statusObj != null)
                {
                    var status = statusObj.Envs["hostDirect"];
                    this.statusField.Text = "Golem Unlimited Provider Status: " + status;
                    return;
                }
            }
            this.statusField.Text = "No connection";
        }

        private void NodeList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //this.statusField.Text = e.RowIndex + " " + e.ColumnIndex + " " + nodeList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
        }
    }
}

class NodeInfo
{
    [JsonProperty("Service type")]
    public string ServiceType { get; set; }
    [JsonProperty("Host name")]
    public string Name { get; set; }
    [JsonProperty("Addresses")]
    public string Address { get; set; }
    public string Description { get; set; }
    public string NodeId()
    {
        foreach (string line in this.Description.Split('\n'))
        {
            var parts = line.Split('=');
            if (parts.Length <= 1) return ""; else return parts[1];
        }
        return "";
    }
}

class SavedNodeInfo
{
    [JsonProperty("host_name")]
    public string Name { get; set; }
    [JsonProperty("address")]
    public string Address { get; set; }
    [JsonProperty("node_id")]
    public string NodeId { get; set; }
}

class ServerStatusInfo
{
    [JsonProperty("envs")]
    public Dictionary<string, string> Envs { get; set; }
}