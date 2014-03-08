namespace SQLDebugHelper
{
	partial class SQLDebugHelper
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SQLDebugHelper));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grpInput = new System.Windows.Forms.GroupBox();
            this.txtInput = new FastColoredTextBoxNS.FastColoredTextBox();
            this.grpOutput = new System.Windows.Forms.GroupBox();
            this.txtOutput = new FastColoredTextBoxNS.FastColoredTextBox();
            this.toolSettings = new Framework.Controls.FloatToolStrip();
            this.lblProfile = new System.Windows.Forms.ToolStripLabel();
            this.toolCboProfiles = new System.Windows.Forms.ToolStripComboBox();
            this.btnMakeDrops = new System.Windows.Forms.ToolStripButton();
            this.btnPrintExec = new System.Windows.Forms.ToolStripButton();
            this.btnGenInserts = new System.Windows.Forms.ToolStripButton();
            this.btnListTable = new System.Windows.Forms.ToolStripButton();
            this.btnListProcs = new System.Windows.Forms.ToolStripButton();
            this.btnMapProc = new System.Windows.Forms.ToolStripButton();
            this.btnShowMap = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grpInput.SuspendLayout();
            this.grpOutput.SuspendLayout();
            this.toolSettings.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 49);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grpInput);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grpOutput);
            this.splitContainer1.Size = new System.Drawing.Size(866, 541);
            this.splitContainer1.SplitterDistance = 408;
            this.splitContainer1.TabIndex = 0;
            // 
            // grpInput
            // 
            this.grpInput.Controls.Add(this.txtInput);
            this.grpInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpInput.Location = new System.Drawing.Point(0, 0);
            this.grpInput.Name = "grpInput";
            this.grpInput.Size = new System.Drawing.Size(408, 541);
            this.grpInput.TabIndex = 1;
            this.grpInput.TabStop = false;
            this.grpInput.Text = "Input";
            // 
            // txtInput
            // 
            this.txtInput.AutoScrollMinSize = new System.Drawing.Size(25, 15);
            this.txtInput.BackBrush = null;
            this.txtInput.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtInput.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInput.Location = new System.Drawing.Point(3, 16);
            this.txtInput.Name = "txtInput";
            this.txtInput.Paddings = new System.Windows.Forms.Padding(0);
            this.txtInput.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.txtInput.Size = new System.Drawing.Size(402, 522);
            this.txtInput.TabIndex = 0;
            // 
            // grpOutput
            // 
            this.grpOutput.Controls.Add(this.txtOutput);
            this.grpOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpOutput.Location = new System.Drawing.Point(0, 0);
            this.grpOutput.Name = "grpOutput";
            this.grpOutput.Size = new System.Drawing.Size(454, 541);
            this.grpOutput.TabIndex = 2;
            this.grpOutput.TabStop = false;
            this.grpOutput.Text = "Output";
            // 
            // txtOutput
            // 
            this.txtOutput.AutoScrollMinSize = new System.Drawing.Size(0, 15);
            this.txtOutput.BackBrush = null;
            this.txtOutput.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtOutput.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOutput.Location = new System.Drawing.Point(3, 16);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Paddings = new System.Windows.Forms.Padding(0);
            this.txtOutput.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.txtOutput.Size = new System.Drawing.Size(448, 522);
            this.txtOutput.TabIndex = 0;
            this.txtOutput.WordWrap = true;
            // 
            // toolSettings
            // 
            this.toolSettings.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblProfile,
            this.toolCboProfiles,
            this.btnMakeDrops,
            this.btnPrintExec,
            this.btnGenInserts,
            this.btnListTable,
            this.btnListProcs,
            this.btnMapProc,
            this.btnShowMap});
            this.toolSettings.Location = new System.Drawing.Point(0, 24);
            this.toolSettings.Name = "toolSettings";
            this.toolSettings.Size = new System.Drawing.Size(866, 25);
            this.toolSettings.TabIndex = 1;
            this.toolSettings.Text = "Settings";
            // 
            // lblProfile
            // 
            this.lblProfile.Name = "lblProfile";
            this.lblProfile.Size = new System.Drawing.Size(62, 22);
            this.lblProfile.Text = "DB Profile:";
            // 
            // toolCboProfiles
            // 
            this.toolCboProfiles.Name = "toolCboProfiles";
            this.toolCboProfiles.Size = new System.Drawing.Size(121, 25);
            this.toolCboProfiles.SelectedIndexChanged += new System.EventHandler(this.toolCboProfiles_SelectedIndexChanged);
            this.toolCboProfiles.Click += new System.EventHandler(this.toolCboProfiles_SelectedIndexChanged);
            // 
            // btnMakeDrops
            // 
            this.btnMakeDrops.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnMakeDrops.Image = ((System.Drawing.Image)(resources.GetObject("btnMakeDrops.Image")));
            this.btnMakeDrops.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMakeDrops.Name = "btnMakeDrops";
            this.btnMakeDrops.Size = new System.Drawing.Size(84, 22);
            this.btnMakeDrops.Text = "# Table Drops";
            this.btnMakeDrops.ToolTipText = "Generate drop statements for the # tables in the sql input window.";
            this.btnMakeDrops.Click += new System.EventHandler(this.toolStripButton_Click);
            // 
            // btnPrintExec
            // 
            this.btnPrintExec.Image = global::SQLDebugHelper.Properties.Resources.print;
            this.btnPrintExec.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintExec.Name = "btnPrintExec";
            this.btnPrintExec.Size = new System.Drawing.Size(78, 22);
            this.btnPrintExec.Text = "Print Exec";
            this.btnPrintExec.ToolTipText = "Paste exec statements in the input window and output a piece of sql to output the" +
    " statement to the print window";
            this.btnPrintExec.Click += new System.EventHandler(this.toolStripButton_Click);
            // 
            // btnGenInserts
            // 
            this.btnGenInserts.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnGenInserts.Image = ((System.Drawing.Image)(resources.GetObject("btnGenInserts.Image")));
            this.btnGenInserts.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGenInserts.Name = "btnGenInserts";
            this.btnGenInserts.Size = new System.Drawing.Size(95, 22);
            this.btnGenInserts.Text = "Generate Inserts";
            this.btnGenInserts.ToolTipText = "Generates insert statements for tab delimited in the input window.";
            this.btnGenInserts.Click += new System.EventHandler(this.toolStripButton_Click);
            // 
            // btnListTable
            // 
            this.btnListTable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnListTable.Image = ((System.Drawing.Image)(resources.GetObject("btnListTable.Image")));
            this.btnListTable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnListTable.Name = "btnListTable";
            this.btnListTable.Size = new System.Drawing.Size(66, 22);
            this.btnListTable.Text = "List Tables";
            this.btnListTable.ToolTipText = "Generates list of tables in the sql in the input window using the selected databa" +
    "se profile.";
            this.btnListTable.Click += new System.EventHandler(this.toolStripButton_Click);
            // 
            // btnListProcs
            // 
            this.btnListProcs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnListProcs.Image = ((System.Drawing.Image)(resources.GetObject("btnListProcs.Image")));
            this.btnListProcs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnListProcs.Name = "btnListProcs";
            this.btnListProcs.Size = new System.Drawing.Size(108, 22);
            this.btnListProcs.Text = "List Procs && Funcs";
            this.btnListProcs.ToolTipText = "Generates list of procs & functions in the sql in the input window using the sele" +
    "cted database profile.";
            this.btnListProcs.Click += new System.EventHandler(this.toolStripButton_Click);
            // 
            // btnMapProc
            // 
            this.btnMapProc.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnMapProc.Image = ((System.Drawing.Image)(resources.GetObject("btnMapProc.Image")));
            this.btnMapProc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMapProc.Name = "btnMapProc";
            this.btnMapProc.Size = new System.Drawing.Size(62, 22);
            this.btnMapProc.Text = "Map Proc";
            this.btnMapProc.ToolTipText = "Map the nested calls of procs and functions up to 10 levels deep";
            this.btnMapProc.Click += new System.EventHandler(this.toolStripButton_Click);
            // 
            // btnShowMap
            // 
            this.btnShowMap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnShowMap.Image = ((System.Drawing.Image)(resources.GetObject("btnShowMap.Image")));
            this.btnShowMap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowMap.Name = "btnShowMap";
            this.btnShowMap.Size = new System.Drawing.Size(67, 22);
            this.btnShowMap.Text = "Show Map";
            this.btnShowMap.Visible = false;
            this.btnShowMap.Click += new System.EventHandler(this.toolStripButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 590);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(866, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(866, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.Size = new System.Drawing.Size(92, 22);
            this.mnuFileExit.Text = "E&xit";
            this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
            // 
            // SQLDebugHelper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 612);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolSettings);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SQLDebugHelper";
            this.Text = "SQLDebugHelper";
            this.Load += new System.EventHandler(this.SQLDebugHelper_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.grpInput.ResumeLayout(false);
            this.grpOutput.ResumeLayout(false);
            this.toolSettings.ResumeLayout(false);
            this.toolSettings.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.GroupBox grpInput;
		private FastColoredTextBoxNS.FastColoredTextBox txtInput;
		private System.Windows.Forms.GroupBox grpOutput;
        private FastColoredTextBoxNS.FastColoredTextBox txtOutput;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
		private System.Windows.Forms.ToolStripComboBox toolCboProfiles;
        private System.Windows.Forms.ToolStripLabel lblProfile;
        private System.Windows.Forms.ToolStripButton btnMakeDrops;
        private System.Windows.Forms.ToolStripButton btnPrintExec;
        private System.Windows.Forms.ToolStripButton btnGenInserts;
        private System.Windows.Forms.ToolStripButton btnListTable;
        private System.Windows.Forms.ToolStripButton btnListProcs;
        private System.Windows.Forms.ToolStripButton btnMapProc;
        private System.Windows.Forms.ToolStripButton btnShowMap;
        private Framework.Controls.FloatToolStrip toolSettings;
	}
}