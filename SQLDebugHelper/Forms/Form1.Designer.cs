namespace SQLDebugHelper
{
	partial class Form1
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
			this.txtInput = new System.Windows.Forms.RichTextBox();
			this.txtOutput = new System.Windows.Forms.RichTextBox();
			this.splitPoundTable = new System.Windows.Forms.SplitContainer();
			this.grpInput = new System.Windows.Forms.GroupBox();
			this.grpOutput = new System.Windows.Forms.GroupBox();
			this.pnlInstructions = new System.Windows.Forms.Panel();
			this.btnExecToPrint = new System.Windows.Forms.Button();
			this.btnListProcsNFuncs = new System.Windows.Forms.Button();
			this.btnListTables = new System.Windows.Forms.Button();
			this.btnSelect = new System.Windows.Forms.Button();
			this.btnMakeDrop = new System.Windows.Forms.Button();
			this.pnlMain = new System.Windows.Forms.Panel();
			this.btnMapProc = new System.Windows.Forms.Button();
			this.splitPoundTable.Panel1.SuspendLayout();
			this.splitPoundTable.Panel2.SuspendLayout();
			this.splitPoundTable.SuspendLayout();
			this.grpInput.SuspendLayout();
			this.grpOutput.SuspendLayout();
			this.pnlInstructions.SuspendLayout();
			this.pnlMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtInput
			// 
			this.txtInput.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtInput.Location = new System.Drawing.Point(3, 16);
			this.txtInput.Name = "txtInput";
			this.txtInput.Size = new System.Drawing.Size(444, 171);
			this.txtInput.TabIndex = 0;
			this.txtInput.Text = "";
			// 
			// txtOutput
			// 
			this.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtOutput.Location = new System.Drawing.Point(3, 16);
			this.txtOutput.Name = "txtOutput";
			this.txtOutput.Size = new System.Drawing.Size(444, 167);
			this.txtOutput.TabIndex = 1;
			this.txtOutput.Text = "";
			// 
			// splitPoundTable
			// 
			this.splitPoundTable.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitPoundTable.Location = new System.Drawing.Point(0, 0);
			this.splitPoundTable.Name = "splitPoundTable";
			this.splitPoundTable.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitPoundTable.Panel1
			// 
			this.splitPoundTable.Panel1.Controls.Add(this.grpInput);
			// 
			// splitPoundTable.Panel2
			// 
			this.splitPoundTable.Panel2.Controls.Add(this.grpOutput);
			this.splitPoundTable.Size = new System.Drawing.Size(450, 380);
			this.splitPoundTable.SplitterDistance = 190;
			this.splitPoundTable.TabIndex = 4;
			// 
			// grpInput
			// 
			this.grpInput.Controls.Add(this.txtInput);
			this.grpInput.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grpInput.Location = new System.Drawing.Point(0, 0);
			this.grpInput.Name = "grpInput";
			this.grpInput.Size = new System.Drawing.Size(450, 190);
			this.grpInput.TabIndex = 1;
			this.grpInput.TabStop = false;
			this.grpInput.Text = "Input SQL";
			// 
			// grpOutput
			// 
			this.grpOutput.Controls.Add(this.txtOutput);
			this.grpOutput.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grpOutput.Location = new System.Drawing.Point(0, 0);
			this.grpOutput.Name = "grpOutput";
			this.grpOutput.Size = new System.Drawing.Size(450, 186);
			this.grpOutput.TabIndex = 2;
			this.grpOutput.TabStop = false;
			this.grpOutput.Text = "Output";
			// 
			// pnlInstructions
			// 
			this.pnlInstructions.Controls.Add(this.btnMapProc);
			this.pnlInstructions.Controls.Add(this.btnExecToPrint);
			this.pnlInstructions.Controls.Add(this.btnListProcsNFuncs);
			this.pnlInstructions.Controls.Add(this.btnListTables);
			this.pnlInstructions.Controls.Add(this.btnSelect);
			this.pnlInstructions.Controls.Add(this.btnMakeDrop);
			this.pnlInstructions.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlInstructions.Location = new System.Drawing.Point(0, 380);
			this.pnlInstructions.Name = "pnlInstructions";
			this.pnlInstructions.Size = new System.Drawing.Size(450, 85);
			this.pnlInstructions.TabIndex = 5;
			// 
			// btnExecToPrint
			// 
			this.btnExecToPrint.Location = new System.Drawing.Point(130, 50);
			this.btnExecToPrint.Name = "btnExecToPrint";
			this.btnExecToPrint.Size = new System.Drawing.Size(151, 23);
			this.btnExecToPrint.TabIndex = 4;
			this.btnExecToPrint.Text = "Exec Query to Print";
			this.btnExecToPrint.UseVisualStyleBackColor = true;
			this.btnExecToPrint.Click += new System.EventHandler(this.btnExecToPrint_Click);
			// 
			// btnListProcsNFuncs
			// 
			this.btnListProcsNFuncs.Location = new System.Drawing.Point(12, 50);
			this.btnListProcsNFuncs.Name = "btnListProcsNFuncs";
			this.btnListProcsNFuncs.Size = new System.Drawing.Size(112, 23);
			this.btnListProcsNFuncs.TabIndex = 3;
			this.btnListProcsNFuncs.Text = "List Procs && Funcs";
			this.btnListProcsNFuncs.UseVisualStyleBackColor = true;
			this.btnListProcsNFuncs.Click += new System.EventHandler(this.btnListProcsNFuncs_Click);
			// 
			// btnListTables
			// 
			this.btnListTables.Location = new System.Drawing.Point(12, 17);
			this.btnListTables.Name = "btnListTables";
			this.btnListTables.Size = new System.Drawing.Size(112, 23);
			this.btnListTables.TabIndex = 2;
			this.btnListTables.Text = "List Tables";
			this.btnListTables.UseVisualStyleBackColor = true;
			this.btnListTables.Click += new System.EventHandler(this.btnListTables_Click);
			// 
			// btnSelect
			// 
			this.btnSelect.Location = new System.Drawing.Point(130, 17);
			this.btnSelect.Name = "btnSelect";
			this.btnSelect.Size = new System.Drawing.Size(151, 23);
			this.btnSelect.TabIndex = 1;
			this.btnSelect.Text = "Make Select Statements";
			this.btnSelect.UseVisualStyleBackColor = true;
			this.btnSelect.Visible = false;
			this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
			// 
			// btnMakeDrop
			// 
			this.btnMakeDrop.Location = new System.Drawing.Point(287, 17);
			this.btnMakeDrop.Name = "btnMakeDrop";
			this.btnMakeDrop.Size = new System.Drawing.Size(151, 23);
			this.btnMakeDrop.TabIndex = 0;
			this.btnMakeDrop.Text = "Make # table drops";
			this.btnMakeDrop.UseVisualStyleBackColor = true;
			this.btnMakeDrop.Click += new System.EventHandler(this.btnMakeDrop_Click);
			// 
			// pnlMain
			// 
			this.pnlMain.Controls.Add(this.splitPoundTable);
			this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlMain.Location = new System.Drawing.Point(0, 0);
			this.pnlMain.Name = "pnlMain";
			this.pnlMain.Size = new System.Drawing.Size(450, 380);
			this.pnlMain.TabIndex = 6;
			// 
			// btnMapProc
			// 
			this.btnMapProc.Location = new System.Drawing.Point(287, 50);
			this.btnMapProc.Name = "btnMapProc";
			this.btnMapProc.Size = new System.Drawing.Size(151, 23);
			this.btnMapProc.TabIndex = 5;
			this.btnMapProc.Text = "Map Proc";
			this.btnMapProc.UseVisualStyleBackColor = true;
			this.btnMapProc.Click += new System.EventHandler(this.btnMapProc_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(450, 465);
			this.Controls.Add(this.pnlMain);
			this.Controls.Add(this.pnlInstructions);
			this.Name = "Form1";
			this.Text = "Table Finder";
			this.splitPoundTable.Panel1.ResumeLayout(false);
			this.splitPoundTable.Panel2.ResumeLayout(false);
			this.splitPoundTable.ResumeLayout(false);
			this.grpInput.ResumeLayout(false);
			this.grpOutput.ResumeLayout(false);
			this.pnlInstructions.ResumeLayout(false);
			this.pnlMain.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.RichTextBox txtInput;
		private System.Windows.Forms.RichTextBox txtOutput;
		private System.Windows.Forms.SplitContainer splitPoundTable;
		private System.Windows.Forms.GroupBox grpInput;
		private System.Windows.Forms.GroupBox grpOutput;
		private System.Windows.Forms.Panel pnlInstructions;
		private System.Windows.Forms.Button btnMakeDrop;
		private System.Windows.Forms.Panel pnlMain;
		private System.Windows.Forms.Button btnSelect;
		private System.Windows.Forms.Button btnListTables;
		private System.Windows.Forms.Button btnListProcsNFuncs;
		private System.Windows.Forms.Button btnExecToPrint;
		private System.Windows.Forms.Button btnMapProc;
	}
}

