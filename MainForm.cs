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
            this.Visible = false;
        }

        private void ReloadHubList()
        {
            var autoMode = restClient.Execute(new RestRequest("nodes/auto", Method.GET));
            if (autoMode.ResponseStatus != ResponseStatus.Completed)
            {
                MessageBox.Show("Cannot connect to Golem Unlimited Provider.");
                return;
            }
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
                var ipPort = f.ipAddress.Text + ":" + f.portNumber.Text;
                try
                {
                    var urlString = "http://" + ipPort;
                    var hubResponse = new RestClient(urlString).Execute(new RestRequest("node_id/", Method.GET)).Content;
                    var nodeIdAndHostName = hubResponse.Split(new char[] { ' ' }, 2);
                    AddressAndHostName body = new AddressAndHostName
                    {
                        Address = ipPort,
                        HostName = nodeIdAndHostName[1]
                    };
                    var enabledRes = restClient.Execute(new RestRequest("nodes/" + nodeIdAndHostName[0], Method.PUT, DataFormat.Json)
                        .AddParameter("application/json", JsonConvert.SerializeObject(body), ParameterType.RequestBody));
                    if (enabledRes.StatusCode != System.Net.HttpStatusCode.OK)
                    {
                        MessageBox.Show("Cannot change node permission. node_id=" + nodeIdAndHostName[0]);
                        return;
                    }
                    var connectedRes = restClient.Execute(new RestRequest("connections/connect?save=1", Method.POST)
                        .AddHeader("Content-type", "application/json").AddJsonBody(new string[] { body.Address }));
                    if (connectedRes.StatusCode != System.Net.HttpStatusCode.OK)
                    {
                        MessageBox.Show("Cannot connect to " + body.Address);
                        return;
                    }
                    ReloadHubList();
                }
                catch (Exception err)
                {
                    MessageBox.Show("Cannot add " + ipPort + ". Error: " + err.Message);
                }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void ShowForm(object sender, EventArgs e)
        {
            if (sender == notifyIcon && e is MouseEventArgs && ((MouseEventArgs)e).Button == MouseButtons.Right) { return; }
            if (this.Visible == false || this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
                this.Show();
                this.ReloadHubList();
            } else if (sender == notifyIcon)
            {
                this.Hide();
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.NumberOfRuns == 0)
            {
                ShowForm(sender, e);
            }
            ++Properties.Settings.Default.NumberOfRuns;
            Properties.Settings.Default.Save();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            this.ReloadHubList();
        }

        private void CheckProviderStatus_Tick(object sender, EventArgs e)
        {
            restClient.ExecuteAsync(new RestRequest("status?timeout=1", Method.GET), res =>
            {
                if (res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var statusObj = JsonConvert.DeserializeObject<ServerStatusInfo>(res.Content);
                    if (statusObj != null)
                    {
                        var status = statusObj.Envs["hostDirect"];
                        statusField.Invoke((MethodInvoker)(() => statusField.Text = "Golem Unlimited Provider Status: " + status));
                        return;
                    }
                }
                statusField.Invoke((MethodInvoker)(() => statusField.Text = "No connection"));
            });
        }

        private void AutoConnect_CheckedChanged(object sender, EventArgs e)
        {
            var enabledRes = restClient.Execute(new RestRequest("nodes/auto",
                    this.autoConnect.CheckState == CheckState.Checked ? Method.PUT : Method.DELETE, DataFormat.Json)
                .AddHeader("Content-type", "application/json").AddJsonBody(new { }));
            if (enabledRes.StatusCode != System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show("Cannot change auto/manual permission.");
                return;
            }
            var connectedRes = restClient.Execute(new RestRequest("connections/mode/"
                + (this.autoConnect.CheckState == CheckState.Checked ? "auto" : "manual")
                + "?save=1", Method.PUT));
            if (connectedRes.StatusCode != System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show("Cannot change auto/manual connection mode.");
                return;
            }
        }

        private void NodeList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                bool enable = (bool)nodeList.Rows[e.RowIndex].Cells[0].EditedFormattedValue;
                string nodeId = (string)nodeList.Rows[e.RowIndex].Cells[3].Value;
                AddressAndHostName body = new AddressAndHostName
                {
                    Address = (string)nodeList.Rows[e.RowIndex].Cells[2].Value,
                    HostName = (string)nodeList.Rows[e.RowIndex].Cells[1].Value
                };
                var enabledRes = restClient.Execute(new RestRequest("nodes/" + nodeId, enable ? Method.PUT : Method.DELETE, DataFormat.Json)
                    .AddParameter("application/json", JsonConvert.SerializeObject(body), ParameterType.RequestBody));
                if (enabledRes.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show("Cannot change node permission. node_id=" + nodeId);
                    return;
                }
                var connectedRes = restClient.Execute(new RestRequest("connections/" + (enable ? "connect" : "disconnect") + "?save=1", Method.POST)
                    .AddHeader("Content-type", "application/json").AddJsonBody(new string[] { body.Address }));
                if (connectedRes.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show("Cannot connect to " + body.Address);
                    return;
                }
            }

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

class AddressAndHostName
{
    [JsonProperty("address")]
    public string Address { get; set; }
    [JsonProperty("hostName")]
    public string HostName { get; set; }
}