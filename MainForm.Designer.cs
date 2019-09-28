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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.nodeList = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.statusField = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.addHubButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.autoConnect = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.configureMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkProviderStatus = new System.Windows.Forms.Timer(this.components);
            this.NodeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Connect = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NodeIPAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NodeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.nodeList)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.contextMenu.SuspendLayout();
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
            this.NodeName,
            this.Connect,
            this.Status,
            this.NodeIPAddress,
            this.NodeID});
            this.nodeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nodeList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.nodeList.EnableHeadersVisualStyles = false;
            this.nodeList.Location = new System.Drawing.Point(8, 43);
            this.nodeList.MultiSelect = false;
            this.nodeList.Name = "nodeList";
            this.nodeList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.nodeList.RowHeadersVisible = false;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.nodeList.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.nodeList.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.nodeList.Size = new System.Drawing.Size(618, 251);
            this.nodeList.TabIndex = 2;
            this.nodeList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.NodeList_CellContentClick);
            this.nodeList.CurrentCellDirtyStateChanged += new System.EventHandler(this.NodeList_CurrentCellDirtyStateChanged);
            this.nodeList.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.NodeList_DataError);
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
            this.flowLayoutPanel1.Controls.Add(this.statusField);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(8, 300);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(618, 13);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // statusField
            // 
            this.statusField.AutoSize = true;
            this.statusField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusField.Location = new System.Drawing.Point(3, 0);
            this.statusField.Name = "statusField";
            this.statusField.Size = new System.Drawing.Size(94, 13);
            this.statusField.TabIndex = 0;
            this.statusField.Text = "Connection Status";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.addHubButton, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.refreshButton, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.autoConnect, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Enabled = false;
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
            this.refreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // autoConnect
            // 
            this.autoConnect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.autoConnect.FormattingEnabled = true;
            this.autoConnect.Items.AddRange(new object[] {
            "No Change",
            "Allow (Sandbox)",
            "Allow (Full Access)"});
            this.autoConnect.Location = new System.Drawing.Point(140, 3);
            this.autoConnect.Name = "autoConnect";
            this.autoConnect.Size = new System.Drawing.Size(121, 21);
            this.autoConnect.TabIndex = 2;
            this.autoConnect.SelectedIndexChanged += new System.EventHandler(this.AutoConnect_SelectedChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Unconfigured Local Hubs:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Golem Unlimited Provider UI";
            this.notifyIcon.Visible = true;
            this.notifyIcon.Click += new System.EventHandler(this.ShowForm);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configureMenuItem,
            this.exitMenuItem});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(128, 48);
            // 
            // configureMenuItem
            // 
            this.configureMenuItem.Name = "configureMenuItem";
            this.configureMenuItem.Size = new System.Drawing.Size(127, 22);
            this.configureMenuItem.Text = "Configure";
            this.configureMenuItem.Click += new System.EventHandler(this.ShowForm);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(127, 22);
            this.exitMenuItem.Text = "Exit";
            this.exitMenuItem.Click += new System.EventHandler(this.ExitMenuItem_Click);
            // 
            // checkProviderStatus
            // 
            this.checkProviderStatus.Interval = 1000;
            this.checkProviderStatus.Tick += new System.EventHandler(this.CheckProviderStatus_Tick);
            // 
            // NodeName
            // 
            this.NodeName.FillWeight = 34.31496F;
            this.NodeName.HeaderText = "Hub Name";
            this.NodeName.Name = "NodeName";
            this.NodeName.ReadOnly = true;
            this.NodeName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Connect
            // 
            this.Connect.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.Connect.FillWeight = 50F;
            this.Connect.HeaderText = "Permission";
            this.Connect.Items.AddRange(new object[] {
            "Denied",
            "Allowed (Sandbox)",
            "Allowed (Full Access)"});
            this.Connect.Name = "Connect";
            this.Connect.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Connect.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Status
            // 
            this.Status.FillWeight = 34.31496F;
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // NodeIPAddress
            // 
            this.NodeIPAddress.FillWeight = 34.31496F;
            this.NodeIPAddress.HeaderText = "IPAddress";
            this.NodeIPAddress.Name = "NodeIPAddress";
            this.NodeIPAddress.ReadOnly = true;
            this.NodeIPAddress.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // NodeID
            // 
            this.NodeID.FillWeight = 61.76692F;
            this.NodeID.HeaderText = "Node ID";
            this.NodeID.Name = "NodeID";
            this.NodeID.ReadOnly = true;
            this.NodeID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 321);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(650, 360);
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Golem Unlimited Provider UI";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.nodeList)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView nodeList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label statusField;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button addHubButton;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem configureMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.Timer checkProviderStatus;
        private System.Windows.Forms.ComboBox autoConnect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NodeName;
        private System.Windows.Forms.DataGridViewComboBoxColumn Connect;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn NodeIPAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn NodeID;
    }
}

