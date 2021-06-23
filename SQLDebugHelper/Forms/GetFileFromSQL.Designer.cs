namespace SQLDebugHelper.Forms
{
    partial class GetFileFromSQL
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblSQLTable = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lblTableName = new System.Windows.Forms.Label();
            this.lblKeyField = new System.Windows.Forms.Label();
            this.cboKeyField = new System.Windows.Forms.ComboBox();
            this.lblWhichKey = new System.Windows.Forms.Label();
            this.txtKeyValue = new System.Windows.Forms.TextBox();
            this.cboDataField = new System.Windows.Forms.ComboBox();
            this.lblDataField = new System.Windows.Forms.Label();
            this.btnGetFile = new System.Windows.Forms.Button();
            this.cboFileNameField = new System.Windows.Forms.ComboBox();
            this.lblFileName = new System.Windows.Forms.Label();
            this.grpFileName = new System.Windows.Forms.GroupBox();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.lblFileNameOr = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grpFileName.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSQLTable
            // 
            this.lblSQLTable.AutoSize = true;
            this.lblSQLTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSQLTable.Location = new System.Drawing.Point(12, 20);
            this.lblSQLTable.Name = "lblSQLTable";
            this.lblSQLTable.Size = new System.Drawing.Size(160, 17);
            this.lblSQLTable.TabIndex = 0;
            this.lblSQLTable.Text = "Get SQL file from table: ";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // lblTableName
            // 
            this.lblTableName.AutoSize = true;
            this.lblTableName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTableName.Location = new System.Drawing.Point(174, 20);
            this.lblTableName.Name = "lblTableName";
            this.lblTableName.Size = new System.Drawing.Size(101, 17);
            this.lblTableName.TabIndex = 2;
            this.lblTableName.Text = "<Table Name>";
            // 
            // lblKeyField
            // 
            this.lblKeyField.AutoSize = true;
            this.lblKeyField.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKeyField.Location = new System.Drawing.Point(12, 46);
            this.lblKeyField.Name = "lblKeyField";
            this.lblKeyField.Size = new System.Drawing.Size(113, 17);
            this.lblKeyField.TabIndex = 3;
            this.lblKeyField.Text = "Select Key Field:";
            // 
            // cboKeyField
            // 
            this.cboKeyField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKeyField.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboKeyField.FormattingEnabled = true;
            this.cboKeyField.Location = new System.Drawing.Point(177, 43);
            this.cboKeyField.Name = "cboKeyField";
            this.cboKeyField.Size = new System.Drawing.Size(149, 24);
            this.cboKeyField.TabIndex = 4;
            // 
            // lblWhichKey
            // 
            this.lblWhichKey.AutoSize = true;
            this.lblWhichKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWhichKey.Location = new System.Drawing.Point(12, 76);
            this.lblWhichKey.Name = "lblWhichKey";
            this.lblWhichKey.Size = new System.Drawing.Size(142, 17);
            this.lblWhichKey.TabIndex = 5;
            this.lblWhichKey.Text = "Key value to retrieve:";
            // 
            // txtKeyValue
            // 
            this.txtKeyValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKeyValue.Location = new System.Drawing.Point(177, 73);
            this.txtKeyValue.Name = "txtKeyValue";
            this.txtKeyValue.Size = new System.Drawing.Size(149, 23);
            this.txtKeyValue.TabIndex = 6;
            // 
            // cboDataField
            // 
            this.cboDataField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDataField.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDataField.FormattingEnabled = true;
            this.cboDataField.Location = new System.Drawing.Point(177, 103);
            this.cboDataField.Name = "cboDataField";
            this.cboDataField.Size = new System.Drawing.Size(149, 24);
            this.cboDataField.TabIndex = 8;
            // 
            // lblDataField
            // 
            this.lblDataField.AutoSize = true;
            this.lblDataField.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataField.Location = new System.Drawing.Point(12, 106);
            this.lblDataField.Name = "lblDataField";
            this.lblDataField.Size = new System.Drawing.Size(119, 17);
            this.lblDataField.TabIndex = 7;
            this.lblDataField.Text = "Select Data Field:";
            // 
            // btnGetFile
            // 
            this.btnGetFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetFile.Location = new System.Drawing.Point(202, 251);
            this.btnGetFile.Name = "btnGetFile";
            this.btnGetFile.Size = new System.Drawing.Size(124, 26);
            this.btnGetFile.TabIndex = 9;
            this.btnGetFile.Text = "Get SQL File";
            this.btnGetFile.UseVisualStyleBackColor = true;
            this.btnGetFile.Click += new System.EventHandler(this.btnGetFile_Click);
            // 
            // cboFileNameField
            // 
            this.cboFileNameField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFileNameField.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFileNameField.FormattingEnabled = true;
            this.cboFileNameField.Location = new System.Drawing.Point(162, 19);
            this.cboFileNameField.Name = "cboFileNameField";
            this.cboFileNameField.Size = new System.Drawing.Size(149, 24);
            this.cboFileNameField.TabIndex = 11;
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileName.Location = new System.Drawing.Point(6, 19);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(138, 17);
            this.lblFileName.TabIndex = 10;
            this.lblFileName.Text = "Select filename field:";
            // 
            // grpFileName
            // 
            this.grpFileName.Controls.Add(this.label1);
            this.grpFileName.Controls.Add(this.lblFileNameOr);
            this.grpFileName.Controls.Add(this.txtFileName);
            this.grpFileName.Controls.Add(this.lblFileName);
            this.grpFileName.Controls.Add(this.cboFileNameField);
            this.grpFileName.Location = new System.Drawing.Point(15, 137);
            this.grpFileName.Name = "grpFileName";
            this.grpFileName.Size = new System.Drawing.Size(321, 106);
            this.grpFileName.TabIndex = 12;
            this.grpFileName.TabStop = false;
            this.grpFileName.Text = "Filename";
            // 
            // txtFileName
            // 
            this.txtFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFileName.Location = new System.Drawing.Point(115, 71);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(200, 23);
            this.txtFileName.TabIndex = 12;
            this.txtFileName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFileName_KeyUp);
            // 
            // lblFileNameOr
            // 
            this.lblFileNameOr.AutoSize = true;
            this.lblFileNameOr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileNameOr.Location = new System.Drawing.Point(128, 49);
            this.lblFileNameOr.Name = "lblFileNameOr";
            this.lblFileNameOr.Size = new System.Drawing.Size(47, 17);
            this.lblFileNameOr.TabIndex = 13;
            this.lblFileNameOr.Text = "- OR -";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "Enter filename:";
            // 
            // GetFileFromSQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 302);
            this.Controls.Add(this.grpFileName);
            this.Controls.Add(this.btnGetFile);
            this.Controls.Add(this.cboDataField);
            this.Controls.Add(this.lblDataField);
            this.Controls.Add(this.txtKeyValue);
            this.Controls.Add(this.lblWhichKey);
            this.Controls.Add(this.cboKeyField);
            this.Controls.Add(this.lblKeyField);
            this.Controls.Add(this.lblTableName);
            this.Controls.Add(this.lblSQLTable);
            this.Name = "GetFileFromSQL";
            this.Text = "Get SQL file from Table: ";
            this.grpFileName.ResumeLayout(false);
            this.grpFileName.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSQLTable;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label lblTableName;
        private System.Windows.Forms.Label lblKeyField;
        private System.Windows.Forms.ComboBox cboKeyField;
        private System.Windows.Forms.Label lblWhichKey;
        private System.Windows.Forms.TextBox txtKeyValue;
        private System.Windows.Forms.ComboBox cboDataField;
        private System.Windows.Forms.Label lblDataField;
        private System.Windows.Forms.Button btnGetFile;
        private System.Windows.Forms.ComboBox cboFileNameField;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.GroupBox grpFileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFileNameOr;
        private System.Windows.Forms.TextBox txtFileName;
    }
}