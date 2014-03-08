using System;
using System.Data;
using System.Windows.Forms;

namespace SQLDebugHelper
{
    public partial class FieldInfo : Form
    {
        private DataTable fieldData;

        public DataTable FieldData
        {
            get { return fieldData; }
            set { fieldData = value; }
        }

		public string TableName
		{
			get { return txtTableName.Text; }
		}

		public bool UseSQL2008Syntax
		{
			get { return chkSQL2008.Checked; }
		}

		public bool UseIfNotExists
		{
			get { return chkNotExists.Checked; }
		}

        public bool UseIdentityInsert
        {
            get { return chkIdentityInsert.Checked; }
        }

        public FieldInfo()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
			this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Hide();
        }

        private void FieldInfo_Load(object sender, EventArgs e)
        {
            gridFields.DataSource = fieldData;
        }

		private void FieldInfo_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				this.DialogResult = System.Windows.Forms.DialogResult.Cancel;

				Close();
			}
		}
    }
}
