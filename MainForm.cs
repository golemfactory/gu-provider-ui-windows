using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Newtonsoft.Json;
using RestSharp;
using System.IO;
using System.Diagnostics;

namespace gu_provider_ui_windows
{
    public partial class MainForm : Form
    {
        private readonly RestClient restClient = new RestClient("http://127.0.0.1:61621");

        private Process providerProcess= null;



        public MainForm()
        {
            var my_path = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = my_path + "\\gu_provider.exe",
                    Arguments = "-v server run --user ",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true,
                    WorkingDirectory = my_path
                }
            };

            try
            {
                process.Start();
                this.providerProcess = process;
            }
            catch (System.ComponentModel.Win32Exception e) { }

            InitializeComponent();
            this.checkProviderStatus.Enabled = true;
            this.Visible = false;
        }

        private void ReloadHubList()
        {
            restClient.ExecuteAsync(new RestRequest("nodes/auto", Method.GET), autoMode =>
            {
                if (autoMode.ResponseStatus != ResponseStatus.Completed)
                {
                    return;
                }
                if (autoMode.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    autoConnect.Invoke((MethodInvoker)delegate
                    {
                        autoConnect.SelectedIndexChanged -= AutoConnect_SelectedChanged;
                        autoConnect.SelectedIndex = Int32.Parse(autoMode.Content);
                        autoConnect.SelectedIndexChanged += AutoConnect_SelectedChanged;
                        FinishReloadingHubList();
                    });
                }
            });
        }

        private void FinishReloadingHubList()
        {
            nodeList.Rows.Clear();

            HashSet<string> allNodes = new HashSet<string>();
            var items = (nodeList.Columns[1] as DataGridViewComboBoxColumn).Items;

            var lanListRes = restClient.Execute(new RestRequest("lan/list", Method.GET));
            if (lanListRes.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var hosts = JsonConvert.DeserializeObject<List<NodeInfo>>(lanListRes.Content);

                

                if (hosts != null)
                {
                    foreach (var host in hosts)
                    {
                        Int32 mode = Int32.Parse(restClient.Execute(new RestRequest("nodes/" + host.NodeId(), Method.GET)).Content);

                        var colItems = ((DataGridViewComboBoxColumn)nodeList.Columns[1]).Items;
                        nodeList.Rows.Add(host.Name, items[mode], "-", host.Address, host.NodeId());
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
                        Int32 mode = Int32.Parse(restClient.Execute(new RestRequest("nodes/" + host.NodeId, Method.GET)).Content);
                        if (!allNodes.Contains(host.NodeId))
                        {
                            nodeList.Rows.Add(host.Name, items[mode], "-", host.Address, host.NodeId);                            
                        }
                    }
                }
            }
        }

        private void AddHubButton_Click(object sender, EventArgs e)
        {
            using (var f = new AddHubForm { StartPosition = FormStartPosition.CenterParent })
            {
                var result = f.ShowDialog();
                if (result == DialogResult.OK)
                {
                    var ipPort = f.ipAddress.Text + ":" + f.portNumber.Text;
                    try
                    {
                        var urlString = "http://" + ipPort;
                        var hubResponse = new RestClient(urlString).Execute(new RestRequest("node_id/", Method.GET)).Content;
                        var nodeIdAndHostName = hubResponse.Split(new char[] { ' ' }, 2);
                        AddressHostNameAccessLevel body = new AddressHostNameAccessLevel
                        {
                            Address = ipPort,
                            HostName = nodeIdAndHostName[1],
                            AccessLevel = 1
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
                        MessageBox.Show("Cannot add " + ipPort + ". Please check IP address and port number. Error: " + err.Message);
                    }
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
            if (providerProcess != null)
            {
                providerProcess.Kill();
                providerProcess = null;
            }
            notifyIcon.Dispose();
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

        private void UpdateConnectionStatus()
        {
            if (this.Visible == false || this.WindowState == FormWindowState.Minimized) { return; }
            restClient.ExecuteAsync(new RestRequest("connections/list/all", Method.GET), response =>
            {
                if (response.ResponseStatus != ResponseStatus.Completed)
                {
                    return;
                }
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var connections = JsonConvert.DeserializeObject<List<List<string>>>(response.Content);
                    var statuses = new Dictionary<string, string>();
                    if (connections != null)
                    {
                        foreach (var c in connections)
                        {
                            statuses.Add(c[0], c[1]);
                        }
                    }
                    foreach (DataGridViewRow row in nodeList.Rows)
                    {
                        string ip = (string)row.Cells[3].Value;
                        if (statuses.ContainsKey(ip))
                        {
                            if (!((string)row.Cells[2].Value).Equals(statuses[ip]))
                            {
                                row.Cells[2].Value = statuses[ip];
                            }
                        }
                        else
                        {
                            row.Cells[2].Value = "-";
                        }
                    }
                 }
            });
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
                        statusField.Invoke((MethodInvoker)delegate
                        {
                            statusField.Text = "Golem Unlimited Provider Status: " + status;
                            if (tableLayoutPanel2.Enabled == false)
                            {
                                tableLayoutPanel2.Enabled = true;
                                ReloadHubList();
                            }
                            if (status == "Ready") this.UpdateConnectionStatus();
                        });
                        return;
                    }
                }
                statusField.Invoke((MethodInvoker)delegate
                {
                    statusField.Text = "No connection to Golem Unlimited Provider. Please run it on this PC.";
                    if (tableLayoutPanel2.Enabled == true)
                    {
                        nodeList.Rows.Clear();
                        tableLayoutPanel2.Enabled = false;
                    }
                });
            });
        }

        private void AutoConnect_SelectedChanged(object sender, EventArgs e)
        {
            var enabledRes = restClient.Execute(new RestRequest("nodes/auto",
                    this.autoConnect.SelectedIndex > 0 ? Method.PUT : Method.DELETE, DataFormat.Json)
                .AddHeader("Content-type", "application/json").AddJsonBody(new { accessLevel = this.autoConnect.SelectedIndex }));
            if (enabledRes.StatusCode != System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show("Cannot change auto/manual permission.");
                return;
            }
            var connectedRes = restClient.Execute(new RestRequest("connections/mode/"
                + (this.autoConnect.SelectedIndex > 0 ? "auto" : "manual")
                + "?save=1", Method.PUT));
            if (connectedRes.StatusCode != System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show("Cannot change auto/manual connection mode.");
                return;
            }
        }

        private void NodeList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex == 1)
            {
                var cell = (DataGridViewComboBoxCell)nodeList.Rows[e.RowIndex].Cells[1];
                Int32 selected = 0;
                for (int i = 0; i < cell.Items.Count; ++i)
                {
                    if (cell.Items[i].Equals(cell.Value)) selected = i;
                }
                string nodeId = (string)nodeList.Rows[e.RowIndex].Cells[4].Value;
                AddressHostNameAccessLevel body = new AddressHostNameAccessLevel
                {
                    Address = (string)nodeList.Rows[e.RowIndex].Cells[3].Value,
                    HostName = (string)nodeList.Rows[e.RowIndex].Cells[0].Value,
                    AccessLevel = selected
                };
                var enabledRes = restClient.Execute(new RestRequest("nodes/" + nodeId, selected > 0 ? Method.PUT : Method.DELETE, DataFormat.Json)
                    .AddParameter("application/json", JsonConvert.SerializeObject(body), ParameterType.RequestBody));
                if (enabledRes.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show("Cannot change node permission. node_id=" + nodeId);
                    return;
                }
                var connectedRes = restClient.Execute(new RestRequest("connections/" + (selected > 0 ? "connect" : "disconnect") + "?save=1", Method.POST)
                    .AddHeader("Content-type", "application/json").AddJsonBody(new string[] { body.Address }));
                if (connectedRes.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show("Cannot connect to " + body.Address);
                    return;
                }
                this.nodeList.Invalidate();
            }
        }

        private void NodeList_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (this.nodeList.IsCurrentCellDirty)
            {
                this.nodeList.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void NodeList_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            Debug.WriteLine($"data error={e.Exception}");
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

class AddressHostNameAccessLevel
{
    [JsonProperty("address")]
    public string Address { get; set; }
    [JsonProperty("hostName")]
    public string HostName { get; set; }
    [JsonProperty("accessLevel")]
    public int AccessLevel { get; set; }
}