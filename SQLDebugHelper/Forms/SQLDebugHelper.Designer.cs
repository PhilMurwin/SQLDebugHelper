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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SQLDebugHelper));
            this.toolSettings = new CustomControls.FloatToolStrip();
            this.lblServer = new System.Windows.Forms.ToolStripLabel();
            this.toolCboServer = new System.Windows.Forms.ToolStripComboBox();
            this.lblDB = new System.Windows.Forms.ToolStripLabel();
            this.toolCboDB = new System.Windows.Forms.ToolStripComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tabDebugHelp = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pnlTabDebugHelp = new System.Windows.Forms.SplitContainer();
            this.grpInput = new System.Windows.Forms.GroupBox();
            this.txtInput = new FastColoredTextBoxNS.FastColoredTextBox();
            this.grpOutput = new System.Windows.Forms.GroupBox();
            this.txtOutput = new FastColoredTextBoxNS.FastColoredTextBox();
            this.toolDebug = new CustomControls.FloatToolStrip();
            this.btnMakeDrops = new System.Windows.Forms.ToolStripButton();
            this.btnPrintExec = new System.Windows.Forms.ToolStripButton();
            this.btnGenInserts = new System.Windows.Forms.ToolStripButton();
            this.tabCodeGeneration = new System.Windows.Forms.TabPage();
            this.pnlCodeGen = new System.Windows.Forms.SplitContainer();
            this.treeDBView = new System.Windows.Forms.TreeView();
            this.contextTreeDB = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxGenBaseModel = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxGenPOCO = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxViewData = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxSQLFile = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxMapProc = new System.Windows.Forms.ToolStripMenuItem();
            this.grpSearch = new System.Windows.Forms.GroupBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.txtCodeGen = new FastColoredTextBoxNS.FastColoredTextBox();
            this.toolCodeGen = new CustomControls.FloatToolStrip();
            this.btnCopyToClipboard = new System.Windows.Forms.ToolStripButton();
            this.btnShowMap = new System.Windows.Forms.ToolStripButton();
            this.toolSettings.SuspendLayout();
            this.mnuMain.SuspendLayout();
            this.tabDebugHelp.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTabDebugHelp)).BeginInit();
            this.pnlTabDebugHelp.Panel1.SuspendLayout();
            this.pnlTabDebugHelp.Panel2.SuspendLayout();
            this.pnlTabDebugHelp.SuspendLayout();
            this.grpInput.SuspendLayout();
            this.grpOutput.SuspendLayout();
            this.toolDebug.SuspendLayout();
            this.tabCodeGeneration.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCodeGen)).BeginInit();
            this.pnlCodeGen.Panel1.SuspendLayout();
            this.pnlCodeGen.Panel2.SuspendLayout();
            this.pnlCodeGen.SuspendLayout();
            this.contextTreeDB.SuspendLayout();
            this.grpSearch.SuspendLayout();
            this.toolCodeGen.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolSettings
            // 
            this.toolSettings.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblServer,
            this.toolCboServer,
            this.lblDB,
            this.toolCboDB});
            this.toolSettings.Location = new System.Drawing.Point(0, 24);
            this.toolSettings.Name = "toolSettings";
            this.toolSettings.Size = new System.Drawing.Size(866, 25);
            this.toolSettings.TabIndex = 1;
            this.toolSettings.Text = "Settings";
            // 
            // lblServer
            // 
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(79, 22);
            this.lblServer.Text = "Server Profile:";
            // 
            // toolCboServer
            // 
            this.toolCboServer.Name = "toolCboServer";
            this.toolCboServer.Size = new System.Drawing.Size(121, 25);
            this.toolCboServer.SelectedIndexChanged += new System.EventHandler(this.toolCboServer_SelectedIndexChanged);
            // 
            // lblDB
            // 
            this.lblDB.Name = "lblDB";
            this.lblDB.Size = new System.Drawing.Size(58, 22);
            this.lblDB.Text = "Database:";
            // 
            // toolCboDB
            // 
            this.toolCboDB.Name = "toolCboDB";
            this.toolCboDB.Size = new System.Drawing.Size(200, 25);
            this.toolCboDB.SelectedIndexChanged += new System.EventHandler(this.toolCboDB_SelectedIndexChanged);
            this.toolCboDB.Click += new System.EventHandler(this.toolCboDB_SelectedIndexChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 590);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(866, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(866, 24);
            this.mnuMain.TabIndex = 2;
            this.mnuMain.Text = "menuStrip1";
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
            this.mnuFileExit.Size = new System.Drawing.Size(93, 22);
            this.mnuFileExit.Text = "E&xit";
            this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
            // 
            // tabDebugHelp
            // 
            this.tabDebugHelp.Controls.Add(this.tabPage1);
            this.tabDebugHelp.Controls.Add(this.tabCodeGeneration);
            this.tabDebugHelp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDebugHelp.Location = new System.Drawing.Point(0, 49);
            this.tabDebugHelp.Name = "tabDebugHelp";
            this.tabDebugHelp.SelectedIndex = 0;
            this.tabDebugHelp.Size = new System.Drawing.Size(866, 541);
            this.tabDebugHelp.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pnlTabDebugHelp);
            this.tabPage1.Controls.Add(this.toolDebug);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(858, 515);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Debug Helpers";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pnlTabDebugHelp
            // 
            this.pnlTabDebugHelp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTabDebugHelp.Location = new System.Drawing.Point(3, 28);
            this.pnlTabDebugHelp.Name = "pnlTabDebugHelp";
            // 
            // pnlTabDebugHelp.Panel1
            // 
            this.pnlTabDebugHelp.Panel1.Controls.Add(this.grpInput);
            // 
            // pnlTabDebugHelp.Panel2
            // 
            this.pnlTabDebugHelp.Panel2.Controls.Add(this.grpOutput);
            this.pnlTabDebugHelp.Size = new System.Drawing.Size(852, 484);
            this.pnlTabDebugHelp.SplitterDistance = 399;
            this.pnlTabDebugHelp.TabIndex = 0;
            // 
            // grpInput
            // 
            this.grpInput.Controls.Add(this.txtInput);
            this.grpInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpInput.Location = new System.Drawing.Point(0, 0);
            this.grpInput.Name = "grpInput";
            this.grpInput.Size = new System.Drawing.Size(399, 484);
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
            this.txtInput.Size = new System.Drawing.Size(393, 465);
            this.txtInput.TabIndex = 0;
            // 
            // grpOutput
            // 
            this.grpOutput.Controls.Add(this.txtOutput);
            this.grpOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpOutput.Location = new System.Drawing.Point(0, 0);
            this.grpOutput.Name = "grpOutput";
            this.grpOutput.Size = new System.Drawing.Size(449, 484);
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
            this.txtOutput.Size = new System.Drawing.Size(443, 465);
            this.txtOutput.TabIndex = 0;
            this.txtOutput.WordWrap = true;
            // 
            // toolDebug
            // 
            this.toolDebug.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnMakeDrops,
            this.btnPrintExec,
            this.btnGenInserts});
            this.toolDebug.Location = new System.Drawing.Point(3, 3);
            this.toolDebug.Name = "toolDebug";
            this.toolDebug.Size = new System.Drawing.Size(852, 25);
            this.toolDebug.TabIndex = 0;
            this.toolDebug.Text = "floatToolStrip1";
            // 
            // btnMakeDrops
            // 
            this.btnMakeDrops.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnMakeDrops.Image = ((System.Drawing.Image)(resources.GetObject("btnMakeDrops.Image")));
            this.btnMakeDrops.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMakeDrops.Name = "btnMakeDrops";
            this.btnMakeDrops.Size = new System.Drawing.Size(82, 22);
            this.btnMakeDrops.Text = "# Table Drops";
            this.btnMakeDrops.ToolTipText = "Generate drop statements for the # tables in the sql input window.";
            this.btnMakeDrops.Click += new System.EventHandler(this.toolStripButton_Click);
            // 
            // btnPrintExec
            // 
            this.btnPrintExec.Image = global::SQLDebugHelper.Properties.Resources.print;
            this.btnPrintExec.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintExec.Name = "btnPrintExec";
            this.btnPrintExec.Size = new System.Drawing.Size(94, 22);
            this.btnPrintExec.Text = "Exec 2 String";
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
            // tabCodeGeneration
            // 
            this.tabCodeGeneration.Controls.Add(this.pnlCodeGen);
            this.tabCodeGeneration.Controls.Add(this.toolCodeGen);
            this.tabCodeGeneration.Location = new System.Drawing.Point(4, 22);
            this.tabCodeGeneration.Name = "tabCodeGeneration";
            this.tabCodeGeneration.Padding = new System.Windows.Forms.Padding(3);
            this.tabCodeGeneration.Size = new System.Drawing.Size(858, 515);
            this.tabCodeGeneration.TabIndex = 1;
            this.tabCodeGeneration.Text = "Code Generation";
            this.tabCodeGeneration.UseVisualStyleBackColor = true;
            this.tabCodeGeneration.Enter += new System.EventHandler(this.tabCodeGeneration_Enter);
            // 
            // pnlCodeGen
            // 
            this.pnlCodeGen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCodeGen.Location = new System.Drawing.Point(3, 28);
            this.pnlCodeGen.Name = "pnlCodeGen";
            // 
            // pnlCodeGen.Panel1
            // 
            this.pnlCodeGen.Panel1.Controls.Add(this.treeDBView);
            this.pnlCodeGen.Panel1.Controls.Add(this.grpSearch);
            // 
            // pnlCodeGen.Panel2
            // 
            this.pnlCodeGen.Panel2.Controls.Add(this.txtCodeGen);
            this.pnlCodeGen.Size = new System.Drawing.Size(852, 484);
            this.pnlCodeGen.SplitterDistance = 284;
            this.pnlCodeGen.TabIndex = 1;
            // 
            // treeDBView
            // 
            this.treeDBView.ContextMenuStrip = this.contextTreeDB;
            this.treeDBView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeDBView.Location = new System.Drawing.Point(0, 47);
            this.treeDBView.Name = "treeDBView";
            this.treeDBView.Size = new System.Drawing.Size(284, 437);
            this.treeDBView.TabIndex = 1;
            this.treeDBView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeDBView_NodeMouseClick);
            // 
            // contextTreeDB
            // 
            this.contextTreeDB.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxGenBaseModel,
            this.ctxGenPOCO,
            this.ctxViewData,
            this.ctxSQLFile,
            this.ctxMapProc});
            this.contextTreeDB.Name = "contextTreeDB";
            this.contextTreeDB.Size = new System.Drawing.Size(182, 114);
            this.contextTreeDB.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextTreeDB_ItemClicked);
            // 
            // ctxGenBaseModel
            // 
            this.ctxGenBaseModel.Name = "ctxGenBaseModel";
            this.ctxGenBaseModel.Size = new System.Drawing.Size(181, 22);
            this.ctxGenBaseModel.Text = "Gen BaseViewModel";
            this.ctxGenBaseModel.ToolTipText = "Generate BaseViewModel class to output pane";
            // 
            // ctxGenPOCO
            // 
            this.ctxGenPOCO.Name = "ctxGenPOCO";
            this.ctxGenPOCO.Size = new System.Drawing.Size(181, 22);
            this.ctxGenPOCO.Text = "Gen POCO";
            // 
            // ctxViewData
            // 
            this.ctxViewData.Name = "ctxViewData";
            this.ctxViewData.Size = new System.Drawing.Size(181, 22);
            this.ctxViewData.Text = "View Top 10 Rows";
            // 
            // ctxSQLFile
            // 
            this.ctxSQLFile.Name = "ctxSQLFile";
            this.ctxSQLFile.Size = new System.Drawing.Size(181, 22);
            this.ctxSQLFile.Text = "Get SQL File";
            // 
            // ctxMapProc
            // 
            this.ctxMapProc.Name = "ctxMapProc";
            this.ctxMapProc.Size = new System.Drawing.Size(181, 22);
            this.ctxMapProc.Text = "Map Proc";
            // 
            // grpSearch
            // 
            this.grpSearch.Controls.Add(this.txtSearch);
            this.grpSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSearch.Location = new System.Drawing.Point(0, 0);
            this.grpSearch.Name = "grpSearch";
            this.grpSearch.Size = new System.Drawing.Size(284, 47);
            this.grpSearch.TabIndex = 0;
            this.grpSearch.TabStop = false;
            this.grpSearch.Text = "Search";
            // 
            // txtSearch
            // 
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearch.Location = new System.Drawing.Point(3, 16);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(278, 20);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // txtCodeGen
            // 
            this.txtCodeGen.AutoScrollMinSize = new System.Drawing.Size(25, 15);
            this.txtCodeGen.BackBrush = null;
            this.txtCodeGen.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCodeGen.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtCodeGen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCodeGen.Location = new System.Drawing.Point(0, 0);
            this.txtCodeGen.Name = "txtCodeGen";
            this.txtCodeGen.Paddings = new System.Windows.Forms.Padding(0);
            this.txtCodeGen.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.txtCodeGen.Size = new System.Drawing.Size(564, 484);
            this.txtCodeGen.TabIndex = 1;
            // 
            // toolCodeGen
            // 
            this.toolCodeGen.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCopyToClipboard,
            this.btnShowMap});
            this.toolCodeGen.Location = new System.Drawing.Point(3, 3);
            this.toolCodeGen.Name = "toolCodeGen";
            this.toolCodeGen.Size = new System.Drawing.Size(852, 25);
            this.toolCodeGen.TabIndex = 0;
            this.toolCodeGen.Text = "floatToolStrip1";
            // 
            // btnCopyToClipboard
            // 
            this.btnCopyToClipboard.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnCopyToClipboard.Enabled = false;
            this.btnCopyToClipboard.Image = ((System.Drawing.Image)(resources.GetObject("btnCopyToClipboard.Image")));
            this.btnCopyToClipboard.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCopyToClipboard.Name = "btnCopyToClipboard";
            this.btnCopyToClipboard.Size = new System.Drawing.Size(109, 22);
            this.btnCopyToClipboard.Text = "Copy To Clipboard";
            this.btnCopyToClipboard.Click += new System.EventHandler(this.btnCopyToClipboard_Click);
            // 
            // btnShowMap
            // 
            this.btnShowMap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnShowMap.Enabled = false;
            this.btnShowMap.Image = ((System.Drawing.Image)(resources.GetObject("btnShowMap.Image")));
            this.btnShowMap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowMap.Name = "btnShowMap";
            this.btnShowMap.Size = new System.Drawing.Size(67, 22);
            this.btnShowMap.Text = "Show Map";
            // 
            // SQLDebugHelper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 612);
            this.Controls.Add(this.tabDebugHelp);
            this.Controls.Add(this.toolSettings);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.mnuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuMain;
            this.Name = "SQLDebugHelper";
            this.Text = "SQLDebugHelper";
            this.Load += new System.EventHandler(this.SQLDebugHelper_Load);
            this.toolSettings.ResumeLayout(false);
            this.toolSettings.PerformLayout();
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.tabDebugHelp.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.pnlTabDebugHelp.Panel1.ResumeLayout(false);
            this.pnlTabDebugHelp.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlTabDebugHelp)).EndInit();
            this.pnlTabDebugHelp.ResumeLayout(false);
            this.grpInput.ResumeLayout(false);
            this.grpOutput.ResumeLayout(false);
            this.toolDebug.ResumeLayout(false);
            this.toolDebug.PerformLayout();
            this.tabCodeGeneration.ResumeLayout(false);
            this.tabCodeGeneration.PerformLayout();
            this.pnlCodeGen.Panel1.ResumeLayout(false);
            this.pnlCodeGen.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlCodeGen)).EndInit();
            this.pnlCodeGen.ResumeLayout(false);
            this.contextTreeDB.ResumeLayout(false);
            this.grpSearch.ResumeLayout(false);
            this.grpSearch.PerformLayout();
            this.toolCodeGen.ResumeLayout(false);
            this.toolCodeGen.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.MenuStrip mnuMain;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
		private System.Windows.Forms.ToolStripComboBox toolCboServer;
        private System.Windows.Forms.ToolStripLabel lblServer;
        private CustomControls.FloatToolStrip toolSettings;
        private System.Windows.Forms.TabControl tabDebugHelp;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.SplitContainer pnlTabDebugHelp;
        private System.Windows.Forms.GroupBox grpInput;
        private FastColoredTextBoxNS.FastColoredTextBox txtInput;
        private System.Windows.Forms.GroupBox grpOutput;
        private FastColoredTextBoxNS.FastColoredTextBox txtOutput;
        private CustomControls.FloatToolStrip toolDebug;
        private System.Windows.Forms.ToolStripButton btnMakeDrops;
        private System.Windows.Forms.ToolStripButton btnPrintExec;
        private System.Windows.Forms.ToolStripButton btnGenInserts;
        private System.Windows.Forms.TabPage tabCodeGeneration;
        private System.Windows.Forms.SplitContainer pnlCodeGen;
        private System.Windows.Forms.TreeView treeDBView;
        private System.Windows.Forms.GroupBox grpSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private CustomControls.FloatToolStrip toolCodeGen;
        private System.Windows.Forms.ToolStripButton btnCopyToClipboard;
        private System.Windows.Forms.ToolStripButton btnShowMap;
        private System.Windows.Forms.ContextMenuStrip contextTreeDB;
        private System.Windows.Forms.ToolStripMenuItem ctxGenBaseModel;
        private System.Windows.Forms.ToolStripMenuItem ctxGenPOCO;
        private System.Windows.Forms.ToolStripMenuItem ctxViewData;
        private System.Windows.Forms.ToolStripMenuItem ctxSQLFile;
        private System.Windows.Forms.ToolStripMenuItem ctxMapProc;
        private System.Windows.Forms.ToolStripLabel lblDB;
        private System.Windows.Forms.ToolStripComboBox toolCboDB;
        private FastColoredTextBoxNS.FastColoredTextBox txtCodeGen;
    }
}