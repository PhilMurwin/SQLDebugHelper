using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace SQLDebugHelper
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		#region Button Events
		private void btnMakeDrop_Click(object sender, EventArgs e)
		{
			txtOutput.Text = DebugHelpers.GenerateDropStatements(txtInput.Text);
		}

		private void btnSelect_Click(object sender, EventArgs e)
		{
			txtOutput.Text = DebugHelpers.GenerateSelectStatements(txtInput.Text);
		}

		private void btnListTables_Click(object sender, EventArgs e)
		{
			txtOutput.Text = DebugHelpers.GenerateListOfTables(txtInput.Text);
		}

		private void btnListProcsNFuncs_Click(object sender, EventArgs e)
		{
			txtOutput.Text = DebugHelpers.GenerateListOfProcsNFunctions(txtInput.Text);
		}
		#endregion Button Events

		private void btnExecToPrint_Click(object sender, EventArgs e)
		{
			txtOutput.Text = QueryToPrint.QueryToPrintString(txtInput.Text);
		}

		private void btnMapProc_Click(object sender, EventArgs e)
		{
			GenerateProcTree procMap = new GenerateProcTree();
			txtOutput.Text = procMap.GenerateProcTreeChart(txtInput.Text);
		}

	}
}
