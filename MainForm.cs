using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestSharp;

class HubInfo
{
    string Service_type { get; set; }
    string Host_name { get; set; }
    string Addresses { get; set; }
    string Description { get; set; }
}

namespace gu_provider_ui_windows
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        /*nodeList.Rows.Add(true, "abc", "def", "ghi");
        var client = new RestClient("http://127.0.0.1:61621");
        var req = new RestRequest("lan/list", Method.GET);
        var res = client.Execute<List<HubInfo>>(req);
        connectionStatus.Text = res.Content;*/

        private void AddHubButton_Click(object sender, EventArgs e)
        {
            var f = new AddHubForm();
            f.StartPosition = FormStartPosition.CenterParent;
            var result = f.ShowDialog();
            if (result == DialogResult.OK)
            {
            }
        }
    }
}
