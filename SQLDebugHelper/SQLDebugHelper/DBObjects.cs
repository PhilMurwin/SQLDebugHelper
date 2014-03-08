using System;
using System.Collections.Generic;
using System.Text;
using Framework.Data;
using Framework.Utility;

namespace SQLDebugHelper
{
	public static class DBObjects
	{
		#region Member Variables
		private static bool includeFuncs = false;
		private static string m_ProfileName = string.Empty;

		private static List<string> m_TableList = new List<string>();
		private static List<string> m_DBProcList = new List<string>();
		private static List<string> m_DBFunctionList = new List<string>();
		#endregion Member Variables		

		public static void ResetCache(string profileName)
		{
            m_ProfileName = profileName;

			m_TableList.Clear();
			m_DBProcList.Clear();
			m_DBFunctionList.Clear();

			GetTableList(profileName);
			GetProcList(profileName);
		}

		public static List<string> GetTableList(string profileName)
		{
			List<string> tableList = new List<string>();

			if (m_ProfileName != profileName || m_TableList.Count <= 0)
			{
				string sql = @"select name
							from sys.tables
							where [type] = 'U'
							order by name";

				tableList = GetSQLObjectList(sql, profileName);
			}
			else
			{
				tableList = m_TableList;
			}

			return tableList;
		}

		public static List<string> GetProcList(string profileName)
		{
			List<string> procList = new List<string>();

			if (m_ProfileName != profileName || m_DBProcList.Count <= 0)
			{
				string sql = @"select name
								from sys.objects
								where type = 'P'
								and name not like 'sp[_]%'
								and name not like 'dt[_]%'
								order by name";

				procList = GetSQLObjectList(sql, profileName);
			}
			else
			{
				procList = m_DBProcList;
			}			

			if (includeFuncs)
			{
				procList.AddRange(GetFunctionList(profileName));
			}

			return procList;
		}

        public static string GetSQLText(string procName)
        {
            StringBuilder procBody = new StringBuilder();

            using (DBConnection DB = new DBConnection())
            {
                DB.SetDB(m_ProfileName);

                try
                {
                    string sql = string.Format("sp_helptext {0}", procName);

                    DB.CallSQL(sql, true);

                    while (DB.AnotherSQLRecord())
                    {
                        procBody.Append(DB.GetSQLData(1));
                    }

                    DB.CloseDB();
                }
                catch (Exception err)
                {
                    Logger.WriteMessage(Logger.MessageType.Error, "Error retreiving proc body: " + err.Message);
                }
                finally
                {
                    DB.CloseDB();
                }
            }

            return procBody.ToString();
        }

		private static List<string> GetFunctionList(string profileName)
		{
			List<string> funcList = new List<string>();

			if (m_ProfileName != profileName || m_DBFunctionList.Count <= 0)
			{
				string sql = @"select name
								from sys.objects
								where type in ('TF','FN')
								and name not like 'sp[_]%'
								and name not like 'dt[_]%'
								order by name";

				funcList = GetSQLObjectList(sql, profileName);
			}
			else
			{
				funcList = m_DBFunctionList;
			}

			return funcList;
		}

		private static List<string> GetSQLObjectList(string sql, string profileName)
		{
			List<string> sqlObjectList = new List<string>();

			using (DBConnection db = new DBConnection())
			{
				db.SetDB(profileName);

				db.CallSQL(sql, true);

				while (db.AnotherSQLRecord())
				{
					sqlObjectList.Add(db.GetSQLData(1));
				}
			}

			return sqlObjectList;
		}

		public static string RegExMatchList(string profileName)
		{
			StringBuilder procMatchList = new StringBuilder();

			foreach (var proc in GetProcList(profileName))
			{
				procMatchList.Append("(" + proc + ")|");
			}

			//Remove last pipe
			procMatchList.Remove(procMatchList.Length - 1, 1);

			return procMatchList.ToString();
		}
	
	}
}
