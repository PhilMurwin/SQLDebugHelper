using System;
using System.Configuration;
using System.IO;
using System.Text;
using System.Collections.Specialized;

namespace Framework.Utility
{
	public class Logger
	{
		public enum MessageType { Information, Warning, Error, MustLog };
		enum LogLevel { All, WarningsAndErrors, ErrorsOnly };

		private static StringCollection mMsgs = new StringCollection();
		private static StringBuilder mLogText = new StringBuilder();
		private static bool mLogAll = false;
		private static bool mLogTrace = false;

		public static string FileName
		{
			get { return string.Format("{0:yyyyMMdd}.log", DateTime.Now); }
		}

		public static string TS
		{
			get { return string.Format("{0:HH:mm:ss.fff}", DateTime.Now); }
		}

		public static bool WriteMessage(MessageType msgType, string message)
		{
			bool bContinue = false;

			int msgCnt = LoadMsgTypes();

			if (mLogTrace == true)
			{
				System.Diagnostics.Trace.WriteLine(message);
			}

			if (msgCnt == 0)
			{
				bContinue = true;
			}
			else if (mLogAll == true || mMsgs.Contains(msgType.ToString().ToUpper()) == true)
			{
				lock (mLogText)
				{
					mLogText.Append(string.Format("{0}  {1}", TS, message + "\r\n"));
				}

				bContinue = Flush();
			}

			return bContinue;
		}

		private static int LoadMsgTypes()
		{
			if (mMsgs.Count > 0)
			{
				return mMsgs.Count;
			}

			if (ConfigurationManager.AppSettings["LogMsgs"] != null)
			{
				string[] sLogMsgs = ConfigurationManager.AppSettings["LogMsgs"].Split(',');
				foreach (string sLogMsg in sLogMsgs)
				{
					//Trim any whitespace from message type
					string logMsgType = sLogMsg.Trim().ToUpper();

					if (logMsgType.Trim() == "*")
					{
						mLogAll = true;
						return 1;
					}
					else if (logMsgType == "INFO")
					{
						//If the flag passed in is "info" we want to trap Information messages, just add it here
						mMsgs.Add("INFORMATION");
					}
					else if (logMsgType == "WARN")
					{
						mMsgs.Add("WARNING");
					}
					else if (logMsgType == "ERR")
					{
						mMsgs.Add("ERROR");
					}

					mMsgs.Add(logMsgType);
				}
			}

			//Make sure errors are always logged
			if (!mMsgs.Contains("ERROR"))
			{
				mMsgs.Add("ERROR");
			}

			if (ConfigurationManager.AppSettings["LogTrace"] != null)
			{
				string traceFlag = ConfigurationManager.AppSettings["LogTrace"];

				if (traceFlag != "0")
				{
					mLogTrace = true;
				}
			}

			return mMsgs.Count;
		}

		public static bool Flush()
		{
			bool bReturn = false;

			/*
			Obtain a lock on the text object before proceeding.  Note that the lock is not released
			until the file operation is completed; even though OpenFile() has a retry mechanism, it is
			not guaranteed to succeed and it may add delays that can be prevented by the lock in the
			case of multiple threads attempting to write to the file (i.e., the file can't be opened
			because of an open handle from another thread in the same process).
			*/
			lock (mLogText)
			{
				if (mLogText.Length == 0)
				{
					bReturn = true;
				}
				else
				{
					FileStream fs = null;
					StreamWriter sw = null;

					try
					{
						fs = OpenFile();

						if (fs != null)
						{
							string sText = mLogText.ToString();
							mLogText.Length = 0;

							fs.Position = fs.Length;

							sw = new StreamWriter(fs);
							sw.Write(sText);

							bReturn = true;
						}
					}
					catch
					{
						bReturn = false;
					}

					if (sw != null)
					{
						sw.Flush();
						sw.Close();

						sw = null;
					}

					if (fs != null)
					{
						fs.Close();
						fs = null;
					}
				}
			}

			return bReturn;
		}

		private static FileStream OpenFile()
		{
			string path;
			FileStream fs = null;
			DateTime startTS = DateTime.Now;
			TimeSpan diffTS;

			path = GetSaveDirectory();
			path += FileName;

			while (fs == null)
			{
				try
				{
					fs = new FileStream(path,
						FileMode.OpenOrCreate & FileMode.Append,
						FileAccess.Write,
						FileShare.None);
				}
				catch (System.IO.IOException)
				{
					diffTS = DateTime.Now - startTS;
					if (diffTS.Seconds >= 5)
					{
						System.Diagnostics.Trace.WriteLine("Warning: logger unable to open file");
						break;
					}

					// Sleep for a 10th of a second and then continue
					System.Threading.Thread.Sleep(100);
				}
				catch (Exception ex)
				{
					System.Diagnostics.Trace.WriteLine(ex.Message);
					break;
				}
			}

			if (fs != null)
			{
				fs.Position = fs.Length;
			}

			return fs;
		}

		public static string GetSaveDirectory()
		{
			DateTime dt = DateTime.Now;
			/* Per-day directories is excessive since the name of the log file also contains the day.
			string sDateFolder = string.Format(@"{0:0000}{1:00}{2:00}\", dt.Year, dt.Month, dt.Day);
			*/
			string sDateFolder = string.Format(@"{0:0000}{1:00}\", dt.Year, dt.Month);
			string path;

			try
			{
				path = ConfigurationManager.AppSettings["LogPath"];

				if (path == null || path == "")
				{
					// Get directory containing the executable
					string sFullName;
					System.Reflection.Module mod = System.Reflection.Assembly.GetExecutingAssembly().GetModules()[0];
					sFullName = mod.FullyQualifiedName;

					FileInfo fInfo = new FileInfo(sFullName);
					path = fInfo.DirectoryName;
				}

				if (!path.EndsWith(@"\"))
				{
					path += @"\";
				}

				path += sDateFolder;

				//If directory does not exist create it
				if (!System.IO.Directory.Exists(path))
				{
					System.IO.Directory.CreateDirectory(path);
				}

				if (!path.EndsWith(@"\"))
				{
					path += @"\";
				}
			}
			catch
			{
				path = @"\";   // default to root directory on current drive
			}

			return path;
		}

	}
}
