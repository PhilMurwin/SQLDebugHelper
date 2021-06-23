using Dapper;
using SQLDebugHelper.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SQLDebugHelper
{
    public static class DBObjects
	{
		#region Member Variables
		private static bool includeFuncs = false;
        private static string m_ServerName = string.Empty;
        private static string m_DatabaseName = string.Empty;

		private static List<string> m_TableList = new List<string>();
		private static List<string> m_DBProcList = new List<string>();
		private static List<string> m_DBFunctionList = new List<string>();
		#endregion Member Variables		

        public static void ResetCache( string serverName, string dbName )
		{
            m_ServerName = serverName;
            m_DatabaseName = dbName;

			m_TableList.Clear();
			m_DBProcList.Clear();
			m_DBFunctionList.Clear();

            GetTableList( serverName, dbName );
            GetProcList( serverName, dbName );
		}

		public static List<string> GetDatabaseList( string serverName )
        {
            List<string> dbList = new List<string>();

            var sql = @"select name
from sys.databases
where state = 0
and name not in ('master','msdb','model','tempdb')
order by name";

            using ( var db = new SqlConnection( ConnectionString( serverName, "master" ) ) )
            {
                db.Open();

                // Use Dapper to retrieve data
                dbList = db.Query<string>( sql, commandType: CommandType.Text ).ToList();

                db.Close();
            }

            return dbList;
        }

        public static List<string> GetTableList( string serverName, string dbName )
		{
			List<string> tableList = new List<string>();

            if (m_ServerName != serverName || m_DatabaseName != dbName || m_TableList.Count <= 0)
			{
                var sql = @"select name
                            from sys.tables
                            where [type] = 'U'
                            order by name";

                tableList = GetSQLObjectList( ConnectionString( serverName, dbName ), sql);
			}
			else
			{
				tableList = m_TableList;
			}

			return tableList;
		}

		public static List<string> GetViewList( string serverName, string dbName )
        {
            List<string> viewList = new List<string>();

            if ( m_ServerName != serverName || m_DatabaseName != dbName || m_TableList.Count <= 0 )
            {
                string sql = @"select name
from sys.views
order by name";

                viewList = GetSQLObjectList( ConnectionString( serverName, dbName), sql );
            }
            else
            {
                viewList = m_TableList;
            }

            return viewList;
        }

        public static List<SQLObjectColumnModel> GetTableColumns( string tableName )
        {
            List<SQLObjectColumnModel> columns = null;

            var sql =
                @"select c.name, c.column_id as 'ColumnID', st.name as 'Type', st.is_nullable as 'IsNullable'
                from sys.tables t
                join sys.columns c on c.object_id = t.object_id
                join sys.types st on st.system_type_id = c.system_type_id
                                and st.user_type_id = c.user_type_id
                where t.name = @TableName
                order by c.column_id";

            using( var db = new SqlConnection( ConnectionString( m_ServerName, m_DatabaseName ) ) )
            {
                db.Open();

                // Use Dapper to retrieve data
                columns = db.Query<SQLObjectColumnModel>( sql, new { TableName = tableName }, commandType: CommandType.Text ).ToList();

                db.Close();
            }

            return columns;
        }

        public static List<SQLObjectColumnModel> GetViewColumns( string viewName )
        {
            List<SQLObjectColumnModel> columns = null;

            var sql =
                @"select c.name, c.column_id as 'ColumnID', st.name as 'Type', st.is_nullable as 'IsNullable'
                from sys.views t
                join sys.columns c on c.object_id = t.object_id
                join sys.types st on st.system_type_id = c.system_type_id
                                and st.user_type_id = c.user_type_id
                where t.name = @TableName
                order by c.column_id";

            using ( var db = new SqlConnection( ConnectionString( m_ServerName, m_DatabaseName ) ) )
            {
                db.Open();

                // Use Dapper to retrieve data
                columns = db.Query<SQLObjectColumnModel>( sql, new { TableName = viewName }, commandType: CommandType.Text ).ToList();

                db.Close();
            }

            return columns;
        }

        public static List<string> GetProcList( string serverName, string dbName )
		{
			List<string> procList = new List<string>();

            if ( m_ServerName != serverName || m_DatabaseName != dbName || m_TableList.Count <= 0 )
			{
				string sql = @"select name
                                from sys.objects
                                where type = 'P'
                                and name not like 'sp[_]%'
                                and name not like 'dt[_]%'
                                order by name";

                procList = GetSQLObjectList( ConnectionString( serverName, dbName), sql );
			}
			else
			{
				procList = m_DBProcList;
			}			

			if (includeFuncs)
			{
                procList.AddRange( GetFunctionList( serverName, dbName ) );
			}

			return procList;
		}

        public static string GetSQLText( string procName )
        {
            var procBody = "";
            var sql = "sp_helptext";

            using ( var db = new SqlConnection( ConnectionString( m_ServerName, m_DatabaseName ) ) )
            {
                db.Open();

                // Use Dapper to retrieve data
                var lines = db.Query<string>( sql, new { objname = procName }, commandType: CommandType.StoredProcedure ).ToList();

                db.Close();

                procBody = string.Join( "\n", lines );
            }

            return procBody;
        }

        private static List<string> GetFunctionList( string serverName, string dbName )
		{
			List<string> funcList = new List<string>();

            if ( m_ServerName != serverName || m_DatabaseName != dbName || m_TableList.Count <= 0 )
			{
				string sql = @"select name
                                from sys.objects
                                where type in ('TF','FN')
                                and name not like 'sp[_]%'
                                and name not like 'dt[_]%'
                                order by name";

                funcList = GetSQLObjectList( ConnectionString( m_ServerName, m_DatabaseName ), sql );
			}
			else
			{
				funcList = m_DBFunctionList;
			}

			return funcList;
		}

		public static string ConnectionString( string profileName, string dbName )
        {
            var builder = new SqlConnectionStringBuilder( ConfigurationManager.ConnectionStrings[profileName].ConnectionString )
            {
                InitialCatalog = dbName
            };

            return builder.ConnectionString;
        }

        private static List<string> GetSQLObjectList( string connectionString, string sql )
		{
            var objectList = new List<string>();

            using( var db = new SqlConnection( connectionString ) )
			{
                db.Open();

                // Use Dapper to retrieve data
                objectList = db.Query<string>( sql, commandType: CommandType.Text ).ToList();

				db.Close();
			}

            return objectList;
		}

        public static string RegExMatchList( string serverName, string dbName )
		{
            var procMatchList = new StringBuilder();

            foreach (var proc in GetProcList( serverName, dbName ) )
			{
                procMatchList.Append("(\\[?" + proc + "\\]?)|");
			}

			//Remove last pipe
			procMatchList.Remove(procMatchList.Length - 1, 1);

			return procMatchList.ToString();
		}
	
	}
}
