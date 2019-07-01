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

namespace gu_provider_ui_windows
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void AddHubButton_Click(object sender, EventArgs e)
        {
            var f = new AddHubForm();
            f.StartPosition = FormStartPosition.CenterParent;
            var result = f.ShowDialog();
            if (result == DialogResult.OK)
            {
                nodeList.Rows.Add(true, "abc", "def", "ghi");
                /*var client = new RestClient("http://127.0.0.1:61621");
                var req = new RestRequest("status", Method.GET);
                var res = client.Execute(req);
                connectionStatus.Text = res.Content;*/
            }
        }
    }
}
