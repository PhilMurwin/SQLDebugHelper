using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Framework.Config;

namespace Framework.Data
{
	public class DBConnection : IDisposable
	{
		// Note: the "Global" events provide default values for the per-instance events
		// (so that event handlers can be installed for the entire app instead of doing it for
		// each connection object); there is no invocation directly on the "Global" event objects.
		public static event EventHandler GlobalSQLErrorEvent;
		public static event EventHandler GlobalSQLCallEvent;

		public event EventHandler SQLErrorEvent = GlobalSQLErrorEvent;
		public event EventHandler SQLCallEvent = GlobalSQLCallEvent;

		private string msDriver;
		private string msServer;
		private string msDatabase;
		private string msUserName;
		private string msPassword;
		private int miTimeOut = 30;

		private string msApplicationName;

		private string msError;
		private bool mbSQLError;

		private DateTime mLastSQLStartTime;

		private SqlConnection moConn = new SqlConnection();
		private SqlCommand moCmd = new SqlCommand();

		private SqlDataReader moReader = null;
		private SqlTransaction moTrans = null;

		public int CallSQL(string sSQL, bool bResults)
		{
			try
			{
				if (moReader != null)
				{
					moCmd.Cancel();
					moReader.Close();
					moReader = null;
				}

				moCmd.CommandTimeout = TimeOut;
				moCmd.CommandType = CommandType.Text;
				moCmd.CommandText = sSQL;
				moCmd.Parameters.Clear();

				if (SQLCallEvent != null)
				{
					try { SQLCallEvent(this, System.EventArgs.Empty); }
					catch { }
				}

				mLastSQLStartTime = DateTime.UtcNow;

				if (bResults)
					moReader = moCmd.ExecuteReader();
				else
					moCmd.ExecuteNonQuery();

				mbSQLError = false;
				return 0;
			}

			catch (Exception oError)
			{
				mbSQLError = true;
				OnError(oError);
				return 1;
			}
		}

		public int CallProcedure(
				string sSQL, bool bResults, string[] asParamNames, object[] aoParamValues)
		{
			if (asParamNames.Length != aoParamValues.Length)
			{
				mbSQLError = true;
				OnError("CallProcedure parameters are incorrect: inconsistent array length");
				return 1;
			}

			try
			{
				if (moReader != null)
				{
					moCmd.Cancel();
					moReader.Close();
					moReader = null;
				}

				moCmd.CommandTimeout = TimeOut;
				moCmd.CommandType = CommandType.StoredProcedure;
				moCmd.CommandText = sSQL;
				moCmd.Parameters.Clear();

				for (int i = 0; i < asParamNames.Length; i++)
					moCmd.Parameters.AddWithValue(asParamNames[i], aoParamValues[i]);

				if (SQLCallEvent != null)
				{
					try { SQLCallEvent(this, System.EventArgs.Empty); }
					catch { }
				}

				mLastSQLStartTime = DateTime.UtcNow;

				if (bResults)
					moReader = moCmd.ExecuteReader();
				else
					moCmd.ExecuteNonQuery();

				mbSQLError = false;
				return 0;
			}

			catch (Exception oError)
			{
				mbSQLError = true;
				OnError(oError.Message);
				return 1;
			}
		}

		public DataTable GetDataTable()
		{
			System.Diagnostics.Debug.Assert(moReader != null);

			if (mbSQLError)
				return null;

			try
			{
				DataTable dt = new DataTable();
				dt.Load(moReader);
				return dt;
			}

			catch (Exception oError)
			{
				moCmd.Cancel();
				moReader.Close();
				moReader = null;
				OnError(oError);
				return null;
			}
		}

		public DataSet GetDataSet(string[] tables)
		{
			System.Diagnostics.Debug.Assert(moReader != null);

			if (mbSQLError)
				return null;

			try
			{
				DataSet ds = new DataSet();
				ds.Load(moReader, LoadOption.OverwriteChanges, tables);
				return ds;
			}

			catch (Exception oError)
			{
				moCmd.Cancel();
				moReader.Close();
				moReader = null;
				OnError(oError);
				return null;
			}
		}

		public bool NextResult()
		{
			System.Diagnostics.Debug.Assert(moReader != null);

			if (mbSQLError)
				return false;

			try
			{
				return moReader.NextResult();
			}

			catch (Exception oError)
			{
				moCmd.Cancel();
				moReader.Close();
				moReader = null;
				OnError(oError);
				return false;
			}
		}

		public bool AnotherSQLRecord()
		{
			System.Diagnostics.Debug.Assert(moReader != null);

			if (mbSQLError)
				return false;

			try
			{
				return moReader.Read();
			}

			catch (Exception oError)
			{
				moCmd.Cancel();
				moReader.Close();
				moReader = null;
				OnError(oError);
				return false;
			}
		}

		public int GetColumnCount()
		{
			System.Diagnostics.Debug.Assert(moReader != null);

			try
			{
				return moReader.FieldCount;
			}

			catch
			{
				return 0;
			}
		}

		public int GetOrdinal(string sColName)
		{
			System.Diagnostics.Debug.Assert(moReader != null);

			try
			{
				return moReader.GetOrdinal(sColName) + 1;
			}

			catch (Exception oError)
			{
				throw new ApplicationException("Invalid column name: " + oError.Message);
			}
		}

		public string GetColumnName(int iCol)
		{
			System.Diagnostics.Debug.Assert(moReader != null);

			try
			{
				return moReader.GetName(iCol);
			}

			catch (Exception oError)
			{
				throw new ApplicationException("Invalid column ordinal: " + oError.Message);
			}
		}

		public string GetSQLData(int iCol)
		{
			System.Diagnostics.Debug.Assert(moReader != null);

			try
			{
				--iCol;
				if (moReader.IsDBNull(iCol))
					return string.Empty;
				else
					return moReader.GetValue(iCol).ToString();
			}

			catch (ArgumentException oError)
			{
				OnError(oError);
				return string.Empty;
			}
			catch (Exception oError)
			{
				moCmd.Cancel();
				moReader.Close();
				moReader = null;
				OnError(oError);
				return string.Empty;
			}
		}

		public string GetSQLData(string sColName)
		{
			return GetSQLData(GetOrdinal(sColName));
		}

		public object GetSQLDataObject(int iCol)
		{
			try
			{
				--iCol;
				if (moReader.IsDBNull(iCol))
					return null;
				else
					return moReader.GetValue(iCol);
			}

			catch (ArgumentException oError)
			{
				OnError(oError);
				return string.Empty;
			}
			catch (Exception oError)
			{
				moCmd.Cancel();
				moReader.Close();
				moReader = null;
				OnError(oError);
				return string.Empty;
			}
		}

		public object GetSQLDataObject(string sColName)
		{
			return GetSQLDataObject(GetOrdinal(sColName));
		}

		/// <summary>
		/// Assumes that the CADONet_Sql class public vars Server, Database, Username,
		/// and Password have been initialized.
		/// </summary>
		/// <returns>true if successful, throws an exception for all errors</returns>
		public bool OpenDB()
		{
			try
			{
				CloseDB();

				moConn.ConnectionString = ConnectionString();
				moConn.Open();

				moCmd.Connection = moConn;

				return true;
			}

			catch (Exception oError)
			{
				OnError(oError);
				return false;
			}
		}

		public void CloseDB()
		{
			try
			{
				moCmd.Cancel();

				if (moReader != null)
				{
					moReader.Close();
					moReader = null;
				}

				moConn.Close();
			}
			catch { }
		}

		public void BeginTrans(string sTransName)
		{
			moTrans = moConn.BeginTransaction();
			moCmd.Transaction = moTrans;
		}

		public void RollbackTrans()
		{
			moTrans.Rollback();
		}

		public void CommitTrans()
		{
			moTrans.Commit();
		}

		public bool EndTrans()
		{
			if (mbSQLError)
			{
				moTrans.Rollback();
				return false;
			}
			else
			{
				moTrans.Commit();
				return true;
			}
		}

		public string EnQuotes(string sIN)
		{
			if (string.IsNullOrEmpty(sIN))
				return "NULL";

			System.Text.StringBuilder sTemp = new System.Text.StringBuilder(sIN);
			sTemp.Replace("'", "''");
			sTemp.Insert(0, "'");
			sTemp.Append("'");
			return sTemp.ToString();

		}

		public string Driver
		{
			get { return msDriver; }
			set { msDriver = value; }
		}

		public string Server
		{
			get { return msServer; }
			set { msServer = value; }
		}

		public string Database
		{
			get { return msDatabase; }
			set { msDatabase = value; }
		}

		public string Username
		{
			get { return msUserName; }
			set { msUserName = value; }
		}

		public string Password
		{
			get { return msPassword; }
			set { msPassword = value; }
		}

		public int TimeOut
		{
			get { return miTimeOut; }
			set { miTimeOut = value; }
		}

		public string ApplicationName
		{
			get { return msApplicationName; }
			set { msApplicationName = value; }
		}

		public string LastError
		{
			get { return msError; }
		}

		public DateTime LastSQLStartTime
		{
			get { return mLastSQLStartTime; }
		}

		public string ConnectionString()
		{
			StringBuilder sbConnString = new StringBuilder();

			string sUserName = Username;
			string sAppName = ApplicationName;

			sbConnString.Append("server=" + Server + ";database=" + Database);
			if (!string.IsNullOrEmpty(sUserName))
				sbConnString.Append(";user id=" + sUserName + ";password=" + Password);
			else
				sbConnString.Append(";Integrated Security=True");   // Windows authentication

			if (!string.IsNullOrEmpty(sAppName))
				sbConnString.Append(";application name=" + sAppName);

			string sPoolSize = ConfigurationManager.AppSettings["DBConnectionMaxPoolSize"];
			if (!string.IsNullOrEmpty(sPoolSize))
			{
				if (sPoolSize == "0")
				{
					sbConnString.Append(";Pooling=false");
					//System.Diagnostics.Trace.WriteLine("Creating non-pooled database connection.");
				}
				else if (Framework.Utility.Utils.IsWholeNumber(sPoolSize))
				{
					sbConnString.Append(";Pooling=true;Max Pool Size=" + sPoolSize);
					//System.Diagnostics.Trace.WriteLine(string.Format("Creating pooled connection (pool size: {0})", sPoolSize));
				}
			}

			return sbConnString.ToString();
		}

		protected virtual void OnError(string sErrorText)
		{
			OnError(sErrorText, null);
		}

		protected virtual void OnError(Exception ex)
		{
			OnError(ex.Message, ex);
		}

		protected virtual void OnError(string sErrorText, Exception ex)
		{
			msError = sErrorText;

			if (SQLErrorEvent != null)
				SQLErrorEvent(this, System.EventArgs.Empty);

			throw new ApplicationException(msError, ex);
		}

		/// <summary>
		/// Sets up the database connection using the default config settings
		/// <para>Opens the database connection</para>
		/// </summary>
		/// <returns></returns>
		public bool SetDB()
		{
			return SetDBViaPrefix("", true);
		}

		public bool SetDB(string profileName)
		{
			bool bRet = false;

			ServerConfigSection config = ConfigurationManager.GetSection("ServerConfig") as ServerConfigSection;
			ServerElement server = config.FindProfile(profileName);

			this.Server = server.DBServer;
			this.Database = server.database;
			this.Username = server.username;
			this.Password = server.password;
			string sTimeout = server.timeout;

			if (IsWholeNumber(sTimeout))
				this.TimeOut = Convert.ToInt32(sTimeout);

			if (this.Server == null)
			{
				// Configuration unavailable; fail the operation immediately.
				throw new Exception("Database settings unavailable");
			}
			else
			{
				//if (bOpen)
				{
					bRet = this.OpenDB();
				}
			}

			return bRet;
		}

		public bool SetDBViaPrefix(string prefix, bool bOpen)
		{
			bool bRet = false;

			//this.ShowErrors = false;
			this.Server = ConfigurationManager.AppSettings[prefix + "DBserver"];
			this.Database = ConfigurationManager.AppSettings[prefix + "Database"];
			this.Username = ConfigurationManager.AppSettings[prefix + "Username"];
			this.Password = ConfigurationManager.AppSettings[prefix + "Password"];

			string sTimeout = ConfigurationManager.AppSettings[prefix + "Timeout"];
			if (IsWholeNumber(sTimeout))
				this.TimeOut = Convert.ToInt32(sTimeout);

			if (this.Server == null)
			{
				// Configuration unavailable; fail the operation immediately.
				throw new Exception("Database settings unavailable");
			}
			else
			{
				if (bOpen)
				{
					bRet = this.OpenDB();
				}
			}

			return bRet;
		}

		public static bool IsWholeNumber(string sInput)  // returns true if the string is a non-negative integer
		{
			bool bReturn = false;

			try
			{
				//long lTemp = Convert.ToInt64(sInput);
				long lTemp;
				if (System.Int64.TryParse(sInput, out lTemp))
					bReturn = (lTemp >= 0);
				else
					bReturn = false;
			}
			catch { }

			return bReturn;
		}

		public void Dispose()
		{
			CloseDB();
		}
	}
}
