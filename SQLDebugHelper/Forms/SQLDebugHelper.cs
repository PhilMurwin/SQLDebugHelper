using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using Dapper;
using NLog;
using SQLDebugHelper.Forms;
using SQLDebugHelper.Helpers;
using SQLDebugHelper.Infrastructure.Extensions;

namespace SQLDebugHelper
{
	public partial class SQLDebugHelper : Form
	{
		public readonly ILogger _logger = LogManager.GetCurrentClassLogger();

		public SQLDebugHelper()
		{
			InitializeComponent();

			_logger.Debug( "Now Loading the SQL Debug Helper main form" );
		}

		#region Load Methods
		private void SQLDebugHelper_Load(object sender, EventArgs e)
		{
			try
			{
				var serverConnections = ConfigurationManager.ConnectionStrings;

				if ( serverConnections.Count != 0 )
                {
					foreach ( ConnectionStringSettings connection in serverConnections )
					{
                        toolCboServer.Items.Add( connection.Name );
					}
				}

				if (toolCboServer.Items.Count > 0)
				{
					toolCboServer.SelectedIndex = 0;

                    var dbList = DBObjects.GetDatabaseList( toolCboServer.SelectedItem.ToString() );

                    toolCboDB.Items.AddRange( dbList.ToArray() );

                    if (toolCboDB.Items.Count > 0)
                    {
                        toolCboDB.SelectedIndex = 0;
					}
				}

                SetTree("");
            }
			catch (Exception err)
			{
				_logger.Error( err, "An Exception occurred while loading the SQLDebugHelper form." );
			}
		}
		#endregion Load Methods

		#region Button Events
		private void toolStripButton_Click(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;

            var serverProfile = toolCboServer.SelectedItem.ToString();
            var dbName = toolCboDB.SelectedItem.ToString();

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
                    txtOutput.Text = DebugHelpers.GenerateListOfTables( txtInput.Text, serverProfile, dbName );
					break;
				case "btnListProcs":
                    txtOutput.Text = DebugHelpers.GenerateListOfProcsNFunctions(txtInput.Text, serverProfile, dbName );
					break;
				case "btnShowMap":
					ShowMap();
					break;
			}

			Cursor = Cursors.Default;
		}
		#endregion Button Events

		#region Events
		private void mnuFileExit_Click( object sender, EventArgs e )
		{
			this.Close();
		}

		private void toolCboDB_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
                var serverProfile = toolCboServer.SelectedItem.ToString();
                var dbName = toolCboDB.SelectedItem.ToString();

                DBObjects.ResetCache( serverProfile, dbName );
                SetTree( "" );
			}
            catch
			{
                MessageBox.Show("Error: The selected database profile (" + toolCboDB.SelectedItem + ") has an invalid configuration");
			}
		}

		private void txtSearch_KeyPress( object sender, KeyPressEventArgs e )
		{
			if ( e.KeyChar == (char)Keys.Enter )
			{
				SetTree( txtSearch.Text );
			}
		}

		private void btnCopyToClipboard_Click( object sender, EventArgs e )
		{
			var ctrl = pnlCodeGen.Panel2.GetNamedChildControl( "txtCodeGen" );

			if ( ctrl != null )
			{
				Clipboard.SetText( ctrl.Text );
			}
			else
			{
				MessageBox.Show( "Control cannot be copied to clipboard" );
			}
		}

		private void tabCodeGeneration_Enter( object sender, EventArgs e )
		{
			SetTree( "" );
		}
		#endregion Events

		#region Event Helpers
		private void ShowMap()
		{
            var ctrl = pnlCodeGen.Panel2.GetNamedChildControl( "txtMapXML" );

            if( ctrl != null )
            {
                ShowMap( "", ctrl.Text );
		}
            else
            {
                MessageBox.Show( "Control cannot be copied to clipboard" );
            }

        }

        private void ShowMap(string mapTitle, string xml)
		{
			try
			{
                if (xml.Length == 0)
				{
                    MessageBox.Show("There is nothing to graph.", "SQL Debug Helper - Show Map");
                    return;
				}
                else if ( !xml.IsXmlString() )
				{
                    MessageBox.Show( "Invalid XML, unable to graph.", "SQL Debug Helper - Show Map" );
                    return;
				}

                var map = new ProcMap( xml, mapTitle );
                map.Show();
			}
			catch (Exception err)
			{
				MessageBox.Show("Exception: " + err.Message, "SQL Debug Helper - Show Map");
			}
		}
        #endregion Event Helpers

        public void SetTree( string searchText )
        {
            treeDBView.Nodes.Clear();

            var serverName = toolCboServer.SelectedItem.ToString();
            var DBName = toolCboDB.SelectedItem.ToString();

            var tableList = DBObjects.GetTableList( serverName, DBName );
            var tableNodes = tableList.Where( t => t.ToLower().Contains( searchText.ToLower() ) ).Select( t => new TreeNode( t ) ).ToArray();
            treeDBView.Nodes.Add( new TreeNode( "Tables", tableNodes ) );

            var procList = DBObjects.GetProcList( serverName, DBName );
            var procNodes = procList.Where( p => p.ToLower().Contains( searchText.ToLower() ) ).Select( p => new TreeNode( p ) ).ToArray();
            treeDBView.Nodes.Add( new TreeNode( "Procs", procNodes ) );

            var viewList = DBObjects.GetViewList( serverName, DBName );
            var viewNodes = viewList.Where( v => v.ToLower().Contains( searchText.ToLower() ) ).Select( v => new TreeNode( v ) ).ToArray();
            treeDBView.Nodes.Add( new TreeNode( "Views", viewNodes ) );

            treeDBView.ExpandAll();
        }

		private void treeDBView_NodeMouseClick( object sender, TreeNodeMouseClickEventArgs e )
		{
			if ( e.Button == MouseButtons.Right )
			{
				treeDBView.SelectedNode = e.Node;

				ToggleTableContextMenus( false );
				ToggleViewContextMenus( false );
				ToggleProcContextMenus( false );

				if ( e.Node.Parent != null && e.Node.Parent.Text.Equals( "Tables" ) )
				{
					ToggleTableContextMenus( true );
				}

				if ( e.Node.Parent != null && e.Node.Parent.Text.Equals( "Views" ) )
				{
					ToggleViewContextMenus( true );
				}

				if ( e.Node.Parent != null && e.Node.Parent.Text.Equals( "Procs" ) )
				{
					ToggleProcContextMenus( true );
				}
			}
		}

		private void ToggleTableContextMenus( bool enable )
		{
			ctxGenBaseModel.Enabled =
			ctxGenPOCO.Enabled =
			ctxViewData.Enabled =
			ctxSQLFile.Enabled =
			enable;
		}

		private void ToggleViewContextMenus( bool enable )
		{
			//ctxGenBaseModel.Enabled =
			ctxGenPOCO.Enabled =
			ctxViewData.Enabled =
			//ctxSQLFile.Enabled =
			enable;
		}

		private void ToggleProcContextMenus( bool enable )
		{
			ctxMapProc.Enabled = enable;
		}

		private void contextTreeDB_ItemClicked( object sender, ToolStripItemClickedEventArgs e )
		{
			var mnuItem = e.ClickedItem.Name;
			var serverProfile = toolCboServer.SelectedItem.ToString();
			var dbName = toolCboDB.SelectedItem.ToString();

			var contextMenu = sender as ContextMenuStrip;
			var tree = contextMenu.SourceControl as TreeView;
			var itemNode = tree.SelectedNode;
			var itemName = itemNode.Text;
			var parentNodeText = itemNode.Parent.Text;

			switch ( parentNodeText.ToLower() )
			{
				case "procs":
					var procOnlyContextOptions = new[] { "ctxMapProc" };
					if ( procOnlyContextOptions.Any( c => c.ToLower() == mnuItem.ToLower() ) )
					{
						if ( SQLScriptObject.VerifyProc( serverProfile, dbName, itemName ) )
						{
							switch ( mnuItem.ToLower() )
							{
								case "ctxmapproc":
									MapProc( itemName );
									break;
							}
						}
					}
					break;
				case "tables":
					var tableOnlyContextOptions = new[] { "ctxGenBaseModel", "ctxGenPoco", "ctxViewData", "ctxSQLFile" };
					if ( tableOnlyContextOptions.Any( c => c.ToLower() == mnuItem.ToLower() ) )
					{
						if ( SQLScriptObject.VerifyTable( serverProfile, dbName, itemName ) )
						{
							switch ( mnuItem.ToLower() )
							{
								case "ctxgenbasemodel":
									GenBaseView( itemName );
									break;
								case "ctxgenpoco":
									GenPOCO( itemName );
									break;
								case "ctxviewdata":
									ViewTableData( itemName );
									break;
								case "ctxsqlfile":
									GetSQLFile( itemName );
									break;
							}
						}
					}
					break;
				case "views":
					var viewOnlyContextOptions = new[] { "ctxGenPoco", "ctxViewData", "ctxSQLFile" };
					if ( viewOnlyContextOptions.Any( c => c.ToLower() == mnuItem.ToLower() ) )
					{
						if ( SQLScriptObject.VerifyView( serverProfile, dbName, itemName ) )
						{
							switch ( mnuItem.ToLower() )
							{
								case "ctxgenpoco":
									GenPOCO( itemName, true );
									break;
								case "ctxviewdata":
									ViewTableData( itemName );
									break;
								case "ctxsqlfile":
									GetSQLFile( itemName );
									break;
							}
						}
					}
					break;
			}
		}

		private void MapProc( string procName )
		{
			pnlCodeGen.Panel2.RemoveAllChildControls();

			var serverProfile = toolCboServer.SelectedItem.ToString();
			var dbName = toolCboDB.SelectedItem.ToString();

			var procTree = new GenerateProcTree();
			var procTreeXML = procTree.GenerateProcTreeChart( procName, serverProfile, dbName );
			var xmlPretty = new XmlDocument().LoadXmlString( procTreeXML ).Beautify();

			var txtBox = GetFastColorTextBox( "txtMapXML" );
			txtBox.Text = xmlPretty;

			pnlCodeGen.Panel2.Controls.Add( txtBox );

			ShowMap( procName, txtBox.Text );
		}

		private void GenBaseView( string tableName )
		{
			pnlCodeGen.Panel2.RemoveAllChildControls();

			var baseViewModel = SQLScriptObject.GenerateBaseViewModel( tableName );
			var txtBox = GetFastColorTextBox( "txtCodeGen" );
			txtBox.Text = baseViewModel;

			pnlCodeGen.Panel2.Controls.Add( txtBox );
			btnCopyToClipboard.Enabled = true;
		}

		private void GenPOCO( string tableName, bool isView = false )
		{
			pnlCodeGen.Panel2.RemoveAllChildControls();

			var pocoClass = SQLScriptObject.GeneratePOCO( tableName, isView );
			var txtBox = GetFastColorTextBox( "txtCodeGen" );
			txtBox.Text = pocoClass;

			pnlCodeGen.Panel2.Controls.Add( txtBox );
			btnCopyToClipboard.Enabled = true;
		}

		private FastColoredTextBoxNS.FastColoredTextBox GetFastColorTextBox( string txtBoxName )
		{
			var txtBox = new FastColoredTextBoxNS.FastColoredTextBox();

			txtBox.AutoScrollMinSize = new System.Drawing.Size( 0, 15 );
			txtBox.BackBrush = null;
			txtBox.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtBox.DisabledColor = System.Drawing.Color.FromArgb( ((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))) );
			txtBox.Dock = System.Windows.Forms.DockStyle.Fill;
			txtBox.Location = new System.Drawing.Point( 0, 0 );
			txtBox.Name = txtBoxName;
			txtBox.Paddings = new System.Windows.Forms.Padding( 0 );
			txtBox.SelectionColor = System.Drawing.Color.FromArgb( ((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))) );
			txtBox.WordWrap = true;

			btnCopyToClipboard.Enabled = true;
			btnShowMap.Enabled = true;

			return txtBox;
		}

		private void ViewTableData( string tableName )
		{
			btnCopyToClipboard.Enabled = false;
			pnlCodeGen.Panel2.RemoveAllChildControls();

			var dt = GetTableData( tableName );
			var dv = GetDataGridView();
			dv.DataSource = dt;

			pnlCodeGen.Panel2.Controls.Add( dv );

			if ( dt.Rows.Count == 0 )
            {
				MessageBox.Show( "No Records Found" );
            }
		}

		private DataTable GetTableData( string tableName )
		{
			var serverProfile = toolCboServer.SelectedItem.ToString();
			var dbName = toolCboDB.SelectedItem.ToString();

			DataTable dt = new DataTable();
			dt.TableName = "Data";

			if ( SQLScriptObject.VerifyTable( serverProfile, dbName, tableName ) || SQLScriptObject.VerifyView( serverProfile, dbName, tableName ) )
			{
				var sql = "select top 10 * from [{0}]";

				using ( var db = new SqlConnection( DBObjects.ConnectionString( serverProfile, dbName ) ) )
				{
					db.Open();

					// Use Dapper to retrieve data
					var items = db.Query( string.Format( sql, tableName ), commandType: CommandType.Text );
					dt = items.ToDataTable();

					db.Close();
				}
			}

			return dt;
		}

		private DataGridView GetDataGridView()
		{
			var dv = new DataGridView();
			dv.Name = "dvData";
			dv.Dock = DockStyle.Fill;
			dv.AllowUserToAddRows = false;
			dv.ReadOnly = true;
			dv.BringToFront();

			return dv;
		}

		private void GetSQLFile( string tableName )
		{
			var serverProfile = toolCboServer.SelectedItem.ToString();
			var dbName = toolCboDB.SelectedItem.ToString();

			var connectionString = DBObjects.ConnectionString( serverProfile, dbName );

            var sqlFile = new GetFileFromSQL( tableName, connectionString );
            var result = sqlFile.ShowDialog();
        }
	}
}
