using System;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;
using Framework.Config;
using Framework.Utility;
using SQLDebugHelper.Forms;

namespace SQLDebugHelper
{
	public partial class SQLDebugHelper : Form
	{
		public SQLDebugHelper()
		{
			InitializeComponent();
		}
		#region Load Methods
		private void SQLDebugHelper_Load(object sender, EventArgs e)
		{
			try
			{
				ServerConfigSection config = ConfigurationManager.GetSection("ServerConfig") as ServerConfigSection;

				foreach (ServerElement server in config.Server)
				{
					toolCboProfiles.Items.Add(server.ProfileName);
				}

				if (toolCboProfiles.Items.Count > 0)
				{
					toolCboProfiles.SelectedIndex = 0;
				}
			}
			catch (Exception err)
			{
				Logger.WriteMessage(Logger.MessageType.Error, "Exception: " + err.Message);
			}
		}
		#endregion Load Methods

		#region Button Events
		private void toolStripButton_Click(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;

			string DBProfile = toolCboProfiles.SelectedItem.ToString();

			ToolStripButton ctrl = sender as ToolStripButton;

			switch (ctrl.Name)
			{
				case "btnMakeDrops":
					txtOutput.Text = DebugHelpers.GenerateDropStatements(txtInput.Text);
					break;
				case "btnPrintExec":
					txtOutput.Text = QueryToPrint.QueryToPrintString(txtInput.Text);
					break;
				case "btnGenInserts":
					txtOutput.Text = InsertGenerator.GenerateInserts(txtInput.Lines.ToArray<string>());
					break;
				case "btnListTable":
					txtOutput.Text = DebugHelpers.GenerateListOfTables(txtInput.Text, DBProfile);
					break;
				case "btnListProcs":
					txtOutput.Text = DebugHelpers.GenerateListOfProcsNFunctions(txtInput.Text, DBProfile);
					break;
				case "btnMapProc":
					GenerateProcTree procTree = new GenerateProcTree();
					txtOutput.Text = procTree.GenerateProcTreeChart(txtInput.Text, DBProfile);
					ShowMap(txtInput.Text);
					break;
				case "btnShowMap":
					ShowMap();
					break;
			}

			Cursor = Cursors.Default;
		}


		#endregion Button Events

		#region Events
		private void mnuFileExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void toolCboProfiles_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				DBObjects.ResetCache(toolCboProfiles.SelectedItem.ToString());
			}
			catch (Exception)
			{
				MessageBox.Show("Error: The selected database profile (" + toolCboProfiles.SelectedItem + ") has an invalid configuration");
			}
		}
		#endregion Events

		#region Event Helpers
		private void ShowMap()
		{
			ShowMap("");
		}

		private void ShowMap(string mapTitle)
		{
			try
			{
				if (txtOutput.Text.Length > 0)
				{
					ProcMap map = new ProcMap(txtOutput.Text, mapTitle);
					map.Show();
				}
				else
				{
					MessageBox.Show("There is no text in the output textbox, nothing to graph.", "SQL Debug Helper - Show Map");
				}
			}
			catch (Exception err)
			{
				MessageBox.Show("Exception: " + err.Message, "SQL Debug Helper - Show Map");
			}
		}
		#endregion Event Helpers
	}
}
