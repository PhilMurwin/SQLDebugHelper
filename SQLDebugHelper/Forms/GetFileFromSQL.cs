using Dapper;
using SQLDebugHelper.Infrastructure.Extensions;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace SQLDebugHelper.Forms
{


    public partial class GetFileFromSQL : Form
    {
        private string FormTextPrefix = "Get SQL file from Table: ";
        private string ConnectionString = "";

        public GetFileFromSQL( string tableName, string pConnectionString )
        {
            InitializeComponent();

            ConnectionString = pConnectionString;
            this.Text = FormTextPrefix + tableName;
            lblTableName.Text = tableName;

            var colList = DBObjects.GetTableColumns( tableName );
            var cboDataText = colList.Select( c => c.Name ).ToList();
            var cboColumnText = colList.Select( c => c.Name ).ToList();
            var cboFileNameText = colList.Select( c => c.Name ).ToList();

            cboKeyField.DataSource = cboColumnText;
            cboDataField.DataSource = cboDataText;            
            cboFileNameField.DataSource = cboFileNameText;

            var colName = colList.FindFieldOfType( "varbinary" );
            if( colName != null )
            {
                var idx = cboDataField.FindStringExact( colName );
                cboDataField.SelectedIndex = idx;
            }
        }

        private void btnGetFile_Click( object sender, EventArgs e )
        {
            int dbKeyValue;

            if( int.TryParse( txtKeyValue.Text, out dbKeyValue ) )
            {
                var fileData = GetFileData( dbKeyValue );

                if( fileData != null && fileData.Length > 0 )
                {
                    var fileName = GetFileName( dbKeyValue );

                    OpenInAnotherApp( fileData, fileName );
                }
                else
                {
                    MessageBox.Show( "File not found." );
                }
            }
            else
            {
                MessageBox.Show( "The Key value entered is invalid, please enter a valid integer value." );
            }
        }

        public byte[] GetFileData(int dbKeyValue)
        {
            byte[] fileData = null;

            var keyFieldName = cboKeyField.Items[cboKeyField.SelectedIndex];
            var dataFieldName = cboDataField.Items[cboDataField.SelectedIndex];

            var sql = "select [{1}] from [{0}] where [{2}] = @id";
            var sqlQuery = string.Format( sql, lblTableName.Text, dataFieldName, keyFieldName );

            // Call Dapper to get bytes of data file
            using ( var db = new SqlConnection( ConnectionString ) )
            {
                db.Open();

                // Use Dapper to retrieve data
                fileData = db.Query<byte[]>( sqlQuery, new { id = dbKeyValue }, commandType: CommandType.Text ).FirstOrDefault();

                db.Close();
            }

            return fileData;
        }

        public string GetFileName( int dbKeyValue )
        {
            string fileName = null;


            if( !string.IsNullOrEmpty( txtFileName.Text ) )
            {
                fileName = txtFileName.Text;
            }
            else
            {
                fileName = GetFileNameFromDB( dbKeyValue );
            }

            return fileName ?? dbKeyValue.ToString() + ".txt";
        }

        public string GetFileNameFromDB( int dbKeyValue )
        {
            string fileName = null;

            var keyFieldName = cboKeyField.Items[cboKeyField.SelectedIndex];
            var fileNameField = cboFileNameField.Items[cboFileNameField.SelectedIndex];

            var sql = "select [{1}] from [{0}] where [{2}] = @id";
            var sqlQuery = string.Format( sql, lblTableName.Text, fileNameField, keyFieldName );

            // Call Dapper to get bytes of data file
            using ( var cnn = new SqlConnection( ConnectionString ) )
            {
                cnn.Open();

                // Use Dapper to retrieve data
                fileName = cnn.Query<string>( sqlQuery, new { id = dbKeyValue }, commandType: CommandType.Text ).FirstOrDefault();

                cnn.Close();
            }

            return fileName;
        }

        /// <summary>
        /// Saves the contents of the <paramref name="data"/> array into a 
        /// file named <paramref name="filename"/> placed in a temporary folder,
        /// and runs the associated application for that file extension
        /// in a separate process.
        /// </summary>
        /// <param name="data">The data array.</param>
        /// <param name="filename">The filename.</param>
        private static void OpenInAnotherApp( byte[] data, string filename )
        {
            var tempFolder = System.IO.Path.GetTempPath();
            filename = System.IO.Path.Combine( tempFolder, filename );
            System.IO.File.WriteAllBytes( filename, data );
            System.Diagnostics.Process.Start( filename );
        }

        private void txtFileName_KeyUp( object sender, KeyEventArgs e )
        {
            if( txtFileName.Text.Length > 0 )
            {
                cboFileNameField.Enabled = false;
            }
            else
            {
                cboFileNameField.Enabled = true;
            }
        }
    }
}
