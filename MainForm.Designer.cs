namespace gu_provider_ui_windows
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.nodeList = new System.Windows.Forms.DataGridView();
            this.Connect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.NodeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NodeIPAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NodeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.connectionStatus = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.addHubButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.autoConnect = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nodeList)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // nodeList
            // 
            this.nodeList.AllowUserToAddRows = false;
            this.nodeList.AllowUserToDeleteRows = false;
            this.nodeList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.nodeList.BackgroundColor = System.Drawing.SystemColors.Window;
            this.nodeList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nodeList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.nodeList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.nodeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.nodeList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Connect,
            this.NodeName,
            this.NodeIPAddress,
            this.NodeID});
            this.nodeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nodeList.EnableHeadersVisualStyles = false;
            this.nodeList.Location = new System.Drawing.Point(8, 43);
            this.nodeList.MultiSelect = false;
            this.nodeList.Name = "nodeList";
            this.nodeList.ReadOnly = true;
            this.nodeList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.nodeList.RowHeadersVisible = false;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.nodeList.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.nodeList.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.nodeList.Size = new System.Drawing.Size(618, 251);
            this.nodeList.TabIndex = 2;
            // 
            // Connect
            // 
            this.Connect.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Connect.HeaderText = "Connect";
            this.Connect.Name = "Connect";
            this.Connect.ReadOnly = true;
            this.Connect.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Connect.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Connect.Width = 71;
            // 
            // NodeName
            // 
            this.NodeName.HeaderText = "Name";
            this.NodeName.Name = "NodeName";
            this.NodeName.ReadOnly = true;
            this.NodeName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // NodeIPAddress
            // 
            this.NodeIPAddress.HeaderText = "IPAddress";
            this.NodeIPAddress.Name = "NodeIPAddress";
            this.NodeIPAddress.ReadOnly = true;
            this.NodeIPAddress.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // NodeID
            // 
            this.NodeID.HeaderText = "Node ID";
            this.NodeID.Name = "NodeID";
            this.NodeID.ReadOnly = true;
            this.NodeID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.nodeList, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(634, 321);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.connectionStatus);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(8, 300);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(618, 13);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // connectionStatus
            // 
            this.connectionStatus.AutoSize = true;
            this.connectionStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.connectionStatus.Location = new System.Drawing.Point(3, 0);
            this.connectionStatus.Name = "connectionStatus";
            this.connectionStatus.Size = new System.Drawing.Size(94, 13);
            this.connectionStatus.TabIndex = 0;
            this.connectionStatus.Text = "Connection Status";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.addHubButton, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.refreshButton, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.autoConnect, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(8, 8);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(618, 29);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // addHubButton
            // 
            this.addHubButton.Location = new System.Drawing.Point(540, 3);
            this.addHubButton.Name = "addHubButton";
            this.addHubButton.Size = new System.Drawing.Size(75, 23);
            this.addHubButton.TabIndex = 0;
            this.addHubButton.Text = "Add &Other Hub";
            this.addHubButton.UseVisualStyleBackColor = true;
            this.addHubButton.Click += new System.EventHandler(this.AddHubButton_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(459, 3);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(75, 23);
            this.refreshButton.TabIndex = 1;
            this.refreshButton.Text = "&Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            // 
            // autoConnect
            // 
            this.autoConnect.AutoSize = true;
            this.autoConnect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.autoConnect.Location = new System.Drawing.Point(4, 3);
            this.autoConnect.Margin = new System.Windows.Forms.Padding(4, 3, 3, 3);
            this.autoConnect.Name = "autoConnect";
            this.autoConnect.Size = new System.Drawing.Size(449, 23);
            this.autoConnect.TabIndex = 2;
            this.autoConnect.Text = "&Automatically connect to all local hubs and to selected hubs";
            this.autoConnect.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 321);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(650, 360);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Golem Unlimited Provider UI";
            ((System.ComponentModel.ISupportInitialize)(this.nodeList)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView nodeList;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Connect;
        private System.Windows.Forms.DataGridViewTextBoxColumn NodeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn NodeIPAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn NodeID;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label connectionStatus;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button addHubButton;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.CheckBox autoConnect;
    }
}

