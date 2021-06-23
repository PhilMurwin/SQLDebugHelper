using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SQLDebugHelper
{
	public static class DebugHelpers
	{
		/// <summary>
		/// Generates Drop statements for # tables in the input sql
		/// </summary>
		/// <param name="inputSQL"></param>
		/// <returns></returns>
		public static string GenerateDropStatements(string inputSQL)
		{
			StringBuilder dropStatements = new StringBuilder();
			List<string> tableNames = new List<string>();

			//Create a list of all # tables found in the inputSQL
			foreach (string sqlLine in inputSQL.Split('\n'))
			{
				if (sqlLine.ToLower().Contains("create table #") || sqlLine.ToLower().Contains("into #"))
				{
					string tablename = FindTempTableName(sqlLine);

					if (!tableNames.Contains(tablename))
					{
						tableNames.Add(tablename);
					}
				}
			}

			//Sort the list so it's easy to find them
			tableNames.Sort();

			//Generate if blocks around each # table
			foreach (var table in tableNames)
			{
				dropStatements.Append("if object_id('tempdb.." + table + "') is not null \nbegin\n\t" + "drop table " + table + "\nend\n");
			}

			//If we found # tables then add a TEMPDEBUG label at the beginning of the drop string
			if (dropStatements.Length > 0)
			{
				dropStatements.Insert(0,"--goto tempdebug --sample goto statement to access the TEMPDEBUG label below\n\nTEMPDEBUG:\n");
			}

			return (dropStatements.Length > 0 ? dropStatements.ToString() : "No # tables found.");
		}

		/// <summary>
		/// Takes a line of SQL and checks it for # tables, returns the name of the pound table if one is found present
		/// <para>Currently assumes only one # table per line.  probably not the best plan ever</para>
		/// </summary>
		/// <param name="sqlLine"></param>
		/// <returns></returns>
		private static string FindTempTableName(string sqlLine)
		{
			string tempTableName = string.Empty;

			string reFiller = ".*?";	// Non-greedy match on filler
			string rePoundTable = "((?:#[a-zA-Z][a-zA-Z0-9_]+))";	// Pound Table

			Regex r = new Regex(reFiller + rePoundTable, RegexOptions.IgnoreCase | RegexOptions.Singleline);
			Match m = r.Match(sqlLine);

			if (m.Success)
			{
				tempTableName = m.Groups[1].ToString();
			}

			return tempTableName;
		}

		/// <summary>
		/// Accepts a SQL input string and searches for table names based on the database the profilename links to
		/// </summary>
		/// <param name="inputSQL"></param>
		/// <param name="profileName"></param>
		/// <returns></returns>
		public static string GenerateListOfTables( string inputSQL, string serverName, string dbName )
		{
			StringBuilder listOfTables = new StringBuilder();
			List<string> tableNames = new List<string>();

            inputSQL = GetProcBody( inputSQL, serverName, dbName );

			//Look for tables present in each line
			foreach( var table in DBObjects.GetTableList( serverName, dbName ) )
			{
				if (inputSQL.ToLower().Contains(table.ToLower()))
				{
					//Look for the whole word in the full input string
					if (Regex.IsMatch(inputSQL, @"\b" + table + @"\b", RegexOptions.IgnoreCase))
					{
						if (!tableNames.Contains(table))
						{
							tableNames.Add(table);
						}
					}
				}
			}

			tableNames.Sort();

			//for each table in the list add it to string based output
			foreach (var table in tableNames)
			{
				listOfTables.AppendLine(table);
			}

			return (listOfTables.Length > 0 ? listOfTables.ToString() : "No Tables Found.");
		}

		/// <summary>
		/// Accepts a SQL input string and searches for procs and/or functions based on the database the profilename links to
		/// </summary>
		/// <param name="inputSQL"></param>
		/// <param name="profileName"></param>
		/// <returns></returns>
		public static string GenerateListOfProcsNFunctions( string inputSQL, string serverProfile, string dbName )
		{
			StringBuilder listOfProcsNFunctions = new StringBuilder();
			List<string> procsNFunctions = new List<string>();

            inputSQL = GetProcBody( inputSQL, serverProfile, dbName );

			//Look for tables present in each line
			foreach (var proc in DBObjects.GetProcList( serverProfile, dbName ) )
			{
				if (inputSQL.ToLower().Contains(proc.ToLower()))
				{
					//Look for the whole word in the full input string
					if (Regex.IsMatch(inputSQL, @"\b" + proc + @"\b", RegexOptions.IgnoreCase))
					{
						if (!procsNFunctions.Contains(proc))
						{
							procsNFunctions.Add(proc);
						}
					}
				}
			}

			procsNFunctions.Sort();

			//for each proc/func in the list add it to the string based output
			foreach (var table in procsNFunctions)
			{
				listOfProcsNFunctions.Append(table + "\n");
			}

			return (listOfProcsNFunctions.Length > 0 ? listOfProcsNFunctions.ToString() : "No Procs or Functions Found");
		}

        private static string GetProcBody( string inputSQL, string serverProfile, string dbName )
        {
            if (inputSQL.Length <= Global.MaxSQLObjectNameLength
                && DBObjects.GetProcList( serverProfile, dbName ).Contains(inputSQL))
            {
                inputSQL = DBObjects.GetSQLText(inputSQL);
            }

            return inputSQL;
        }
	}
}
