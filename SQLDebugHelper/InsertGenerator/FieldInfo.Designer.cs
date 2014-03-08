namespace SQLDebugHelper
{
    partial class FieldInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FieldInfo));
            this.btnOK = new System.Windows.Forms.Button();
            this.gridFields = new System.Windows.Forms.DataGridView();
            this.lblTableName = new System.Windows.Forms.Label();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.chkSQL2008 = new System.Windows.Forms.CheckBox();
            this.pnlControls = new System.Windows.Forms.TableLayoutPanel();
            this.chkIdentityInsert = new System.Windows.Forms.CheckBox();
            this.chkNotExists = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridFields)).BeginInit();
            this.pnlControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnOK.Location = new System.Drawing.Point(3, 3);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // gridFields
            // 
            this.gridFields.AllowUserToAddRows = false;
            this.gridFields.AllowUserToDeleteRows = false;
            this.gridFields.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridFields.Location = new System.Drawing.Point(0, 62);
            this.gridFields.Name = "gridFields";
            this.gridFields.Size = new System.Drawing.Size(611, 349);
            this.gridFields.TabIndex = 0;
            // 
            // lblTableName
            // 
            this.lblTableName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTableName.AutoSize = true;
            this.lblTableName.Location = new System.Drawing.Point(84, 8);
            this.lblTableName.Name = "lblTableName";
            this.lblTableName.Size = new System.Drawing.Size(158, 13);
            this.lblTableName.TabIndex = 1;
            this.lblTableName.Text = "Table name for insert statement:";
            // 
            // txtTableName
            // 
            this.txtTableName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtTableName.Location = new System.Drawing.Point(248, 4);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(112, 20);
            this.txtTableName.TabIndex = 2;
            // 
            // chkSQL2008
            // 
            this.chkSQL2008.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkSQL2008.AutoSize = true;
            this.chkSQL2008.Checked = true;
            this.chkSQL2008.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSQL2008.Location = new System.Drawing.Point(366, 6);
            this.chkSQL2008.Name = "chkSQL2008";
            this.chkSQL2008.Size = new System.Drawing.Size(141, 17);
            this.chkSQL2008.TabIndex = 3;
            this.chkSQL2008.Text = "SQL Server 2008 syntax";
            this.chkSQL2008.UseVisualStyleBackColor = true;
            // 
            // pnlControls
            // 
            this.pnlControls.ColumnCount = 4;
            this.pnlControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlControls.Controls.Add(this.chkSQL2008, 3, 0);
            this.pnlControls.Controls.Add(this.btnOK, 0, 0);
            this.pnlControls.Controls.Add(this.txtTableName, 2, 0);
            this.pnlControls.Controls.Add(this.lblTableName, 1, 0);
            this.pnlControls.Controls.Add(this.chkIdentityInsert, 2, 1);
            this.pnlControls.Controls.Add(this.chkNotExists, 3, 1);
            this.pnlControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlControls.Location = new System.Drawing.Point(0, 0);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.RowCount = 2;
            this.pnlControls.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlControls.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlControls.Size = new System.Drawing.Size(611, 62);
            this.pnlControls.TabIndex = 1;
            // 
            // chkIdentityInsert
            // 
            this.chkIdentityInsert.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkIdentityInsert.AutoSize = true;
            this.chkIdentityInsert.Location = new System.Drawing.Point(248, 37);
            this.chkIdentityInsert.Name = "chkIdentityInsert";
            this.chkIdentityInsert.Size = new System.Drawing.Size(89, 17);
            this.chkIdentityInsert.TabIndex = 4;
            this.chkIdentityInsert.Text = "Identity Insert";
            this.chkIdentityInsert.UseVisualStyleBackColor = true;
            // 
            // chkNotExists
            // 
            this.chkNotExists.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkNotExists.AutoSize = true;
            this.chkNotExists.Location = new System.Drawing.Point(366, 37);
            this.chkNotExists.Name = "chkNotExists";
            this.chkNotExists.Size = new System.Drawing.Size(82, 17);
            this.chkNotExists.TabIndex = 5;
            this.chkNotExists.Text = "If Not Exists";
            this.chkNotExists.UseVisualStyleBackColor = true;
            // 
            // FieldInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 411);
            this.Controls.Add(this.gridFields);
            this.Controls.Add(this.pnlControls);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FieldInfo";
            this.Text = "Field Info";
            this.Load += new System.EventHandler(this.FieldInfo_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FieldInfo_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gridFields)).EndInit();
            this.pnlControls.ResumeLayout(false);
            this.pnlControls.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.DataGridView gridFields;
		private System.Windows.Forms.Label lblTableName;
		private System.Windows.Forms.TextBox txtTableName;
		private System.Windows.Forms.CheckBox chkSQL2008;
		private System.Windows.Forms.TableLayoutPanel pnlControls;
		private System.Windows.Forms.CheckBox chkNotExists;
        private System.Windows.Forms.CheckBox chkIdentityInsert;

    }
}