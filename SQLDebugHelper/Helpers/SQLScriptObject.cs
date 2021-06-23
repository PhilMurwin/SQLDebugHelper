using SQLDebugHelper.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLDebugHelper.Helpers
{
    public static class SQLScriptObject
    {
        public static string GenerateBaseViewModel( string tableName )
        {
            const string classTemplate =
@"[Serializable]
public class {0} : BaseViewModel
{{
{1}
}}
";
            const string fieldTemplate =
@"    [Display(Name = ""{1}"")]
    [ModelDataSet(SetName = ""{3}"", OrderID = {2})]
    public {0} {1} {{ get; set; }}

";
            var tableCols = DBObjects.GetTableColumns( tableName );
            return GenerateClassFromColumnList( tableCols, classTemplate, fieldTemplate, tableName );
        }

        public static string GeneratePOCO( string objName, bool isView )
        {
            const string classTemplate =
@"public class {0}
{{
{1}
}}
";
            const string fieldTemplate =
@"  public {0} {1} {{ get; set; }}
";

            string poco;

            if ( isView )
            {
                var viewCols = DBObjects.GetViewColumns( objName );
                poco = GenerateClassFromColumnList( viewCols, classTemplate, fieldTemplate, objName );
            }
            else
            {
                var tableCols = DBObjects.GetTableColumns( objName );
                poco = GenerateClassFromColumnList( tableCols, classTemplate, fieldTemplate, objName );
            }

            return poco;
        }

        private static string GenerateClassFromColumnList( List<SQLObjectColumnModel> colList, string classTemplate, string fieldTemplate, string tableName )
        {
            var fields = new StringBuilder();

            foreach ( var col in colList )
            {
                string datatype;
                switch ( col.Type.ToLower() )
                {
                    case "int":
                        datatype = "int";
                        break;
                    case "numeric":
                        datatype = col.IsNullable ? "decimal?" : "decimal";
                        break;
                    case "datetime":
                        datatype = "DateTime";
                        break;
                    case "bit":
                        datatype = "bool";
                        break;
                    case "nvarchar":
                    case "varchar":
                        datatype = "string";
                        break;
                    default:
                        datatype = "string";
                        break;
                }

                var singleField = string.Format( fieldTemplate, datatype, col.Name, col.ColumnID * 10, tableName + "Grid" );
                fields.Append( singleField );
            }

            return string.Format( classTemplate, tableName + "Model", fields.ToString() );
        }

        public static bool VerifyProc( string serverProfile, string dbName, string procName )
        {
            return DBObjects.GetProcList( serverProfile, dbName ).Any( t => t == procName );
        }

        public static bool VerifyTable( string serverProfile, string dbName, string tableName )
        {
            return DBObjects.GetTableList( serverProfile, dbName ).Any( t => t == tableName );
        }

        public static bool VerifyView( string serverProfile, string dbName, string viewName )
        {
            return DBObjects.GetViewList( serverProfile, dbName ).Any( t => t == viewName );
        }
    }
}
