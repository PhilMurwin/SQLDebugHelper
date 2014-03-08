using System;

namespace Framework.Utility
{
	public class Utils
	{
		public static bool GetBool(string sValue)
		{
			if (string.IsNullOrEmpty(sValue))
				return false;

			int n;
			if (Int32.TryParse(sValue, out n))
				return (n == 1);

			bool b;
			if (Boolean.TryParse(sValue, out b))
				return b;

			sValue = sValue.Trim().ToLower();
			if ((sValue == "true") ||
					(sValue == "on") ||
					(sValue == "yes")
					)
				return true;

			return false;
		}


		public static bool GetBool(object oValue)
		{
			if ((oValue == null) || (oValue is DBNull))
				return false;

			if (oValue is bool)
				return (bool)oValue;

			return GetBool(oValue.ToString());
		}


		public static bool IsNumeric(string sIn)
		{
			if (string.IsNullOrEmpty(sIn))
				return false;

			sIn = sIn.Trim('$');
			double d;
			if (Double.TryParse(sIn, out d))
				return true;

			return false;
		}


		public static bool IsNumeric(object value)
		{
			if ((value == null) || (value is DBNull))
				return false;

			if ((value is int) ||
					(value is uint) ||
					(value is short) ||
					(value is ushort) ||
					(value is long) ||
					(value is ulong) ||
					(value is float) ||
					(value is double) ||
					(value is decimal)
					)
				return true;

			return IsNumeric(value.ToString());
		}


		public static bool IsDate(string sIn)
		{
			if (string.IsNullOrEmpty(sIn))
				return false;

			DateTime dt;
			if (DateTime.TryParse(sIn, out dt))
				return true;

			return false;
		}


		public static bool IsDate(object value)
		{
			if ((value == null) || (value is DBNull))
				return false;

			if (value is DateTime)
				return true;

			return IsDate(value.ToString());
		}


		public static bool IsWholeNumber(string sInput)
		{
			long l;
			if (Int64.TryParse(sInput, out l))
				return (l >= 0);
			else
				return false;
		}


		public static string GetDetailedExceptionMessage(Exception ex)
		{
			string sError = ex.Message;
			if (ex.InnerException != null)
			{
				string sInnerError = ex.InnerException.Message;
				if (sInnerError != null && !sError.Contains(sInnerError))
				{
					if (!sError.TrimEnd().EndsWith("."))
						sError += ".";
					sError += " " + sInnerError;
				}
			}

			return sError;
		}


		/// <summary>
		/// Prints the provided message to the console (this is a helper function that
		/// may be expanded in the future to log the message to a file as well).
		/// </summary>
		/// <param name="caller"></param>
		/// <param name="sLocation">method name</param>
		/// <param name="sType">C# or SQL</param>
		/// <param name="sMessageText">message string</param>
		/// <param name="iLevel">0: debug, 1: information, 2: error</param>
		/// <returns></returns>
		public static string WriteLog(object caller, string sLocation, string sType, string sMessageText, int iLevel)
		{
			string sMessage = string.Format("Location: {0}.{1}\nError Type: {2}\nMessage: {3}\n"
									, (caller != null ? caller.GetType().Name : string.Empty)
									, sLocation
									, sType
									, sMessageText.Trim());  // Trim used to remove line terminator

			Console.Error.WriteLine(sMessage);

			return sMessage;
		}


		/// <summary>
		/// Creates an XML string object by reading a CSV file and building up the XML result using
		/// either the column names in colNames (CSV string) or Col1...Colx.
		/// 
		/// Example of using it is:
		///		str = CSVToXML(filename, "root", 0, "BeginDate,F1,Hr");
		///		creates <root><row><BeginDate v=''/><F1 v=''/><Hr v=''/></row></root>
		/// </summary>
		/// <param name="inputfile"></param>
		/// <param name="rootname"></param>
		/// <param name="headerrows"></param>
		/// <param name="colNames"></param>
		/// <returns></returns>
		public static string CSVToXML(string inputfile, string rootname, int headerrows, string colNames)
		{
			string[] namesAR;
			string[] csvAR;
			int iLine = 0;
			int x;
			System.Text.StringBuilder ret;
			System.IO.StreamReader sr = null;
			string sline;
			string col;
			string val;

			if (colNames == null)
			{
				colNames = "";
			}

			namesAR = colNames.Split(',');

			if (rootname == null || rootname == "")
				rootname = "root";

			int capacity = 0;
			try
			{
				// The file length can be used as an estimate of what the string length
				// will be, though the xml string will be longer that the csv length.
				System.IO.FileInfo fi = new System.IO.FileInfo(inputfile);
				capacity = (int)fi.Length;

				const int block = 10 * 1024; // 10K
				capacity += block - (capacity % block);
			}
			catch (Exception ex)
			{
				System.Diagnostics.Trace.WriteLine(ex.Message);
			}

			ret = new System.Text.StringBuilder(capacity);

			sr = new System.IO.StreamReader(inputfile);

			while (sr.Peek() > -1)
			{
				sline = sr.ReadLine().Trim();
				++iLine;

				if (sline.Length == 0)
					continue;
				else
					if (headerrows >= iLine)
					{
						if (iLine == 1)
						{
							bool bNoNames = (namesAR.Length == 0 || (namesAR.Length == 1 && namesAR[0] == ""));
							if (bNoNames)
							{
								// Extract column names from the header
								namesAR = ScanLine(sline, true);
							}
						}

						continue;
					}

				csvAR = ScanLine(sline, true);

				for (x = 0; x < csvAR.Length; ++x)
				{
					if (x == 0)
						ret.Append("<row>");

					if (x < namesAR.Length)
						col = namesAR[x];  // note: could be empty string if colNames was null or empty
					else
						col = "";

					if (col == "")
						col = string.Format("col{0}", x);

					val = csvAR[x];
					if (string.Compare(val, "NULL", StringComparison.OrdinalIgnoreCase) == 0)
						val = "";

					ret.Append(string.Format("<{0} v=\"{1}\"/>", col, val));
				}

				ret.Append("</row>");
			}
			sr.Close();

			if (ret.Length == 0)
				return "";

			return string.Format("<{0}>{1}</{0}>", rootname, ret.ToString());
		}


		public static string[] ScanLine(string sline)
		{
			return ScanLine(sline, false);
		}


		public static string[] ScanLine(string sline, bool bXmlEscape)
		{
			string[] sReturn = null;
			string sData = "";
			string sField = "";
			int ic = 0;
			int iq = 0;

			try
			{
				while (sline.Length > 0)
				{
					ic = sline.IndexOf(",");
					iq = sline.IndexOf("\"");
					sField = "";

					if ((ic > -1) || (iq > -1))
					{
						if (ic > -1 && (iq == -1 || ic < iq))  // next delimiter is a comma?
						{
							sField = sline.Substring(0, ic);
							sData += sField + "|";
							sline = sline.Substring(ic + 1);
						}
						else
							if (iq >= 0)  // found a quote?
							{
								int iq1 = iq;

								// find the next "
								iq = sline.IndexOf("\"", iq + 1);
								if (iq > -1)
								{
									ic = sline.IndexOf(",", iq);

									if (iq1 == 0)
									{
										if (ic == -1)
										{
											ic = iq;
										}
										else
										{
											// There's a comma after the ending quote; any content between
											// the ending quote and the next comma is ignored...
										}

										sField = sline.Substring(1, iq - 1);  // length has -1 because of start position

										sData += sField + "|";

										sline = sline.Substring(ic + 1);
									}
									else
									{
										// The quote doesn't start at the beginning, so assume that it's part of the field,
										// which may also have content after the quote, so the field ends at the next comma.
										if (ic == -1)
											ic = sline.Length;

										sField = sline.Substring(0, ic);
										sData += sField + "|";

										if (ic < sline.Length)
											sline = sline.Substring(ic + 1);
										else
											sline = "";
									}
								}
								else
								{
									sData += sline.Substring(1);
									sline = "";
								}
							}
					}
					else
					{
						sData += sline;
						sline = "";
					}
				}

				if (bXmlEscape)
					sData = FixXMLReservedChars(sData);

				while (sData.EndsWith("|"))
				{
					sData = sData.Substring(0, sData.Length - 1);
				}

				sReturn = sData.Split('|');
			}
			catch (Exception e)
			{
				Console.WriteLine("Error while processing line: " + sline);
				Console.WriteLine(e.Message);
				throw;
			}

			return sReturn;
		}


		public static string FixXMLReservedChars(string sWork)
		{
			/*
			 * This function will fix the XML Reserved Characters 
			 * found in a string.
			 * XML Reserved Characters		Replacement Characters
			 *			>						&gt; 
			 *			<						&lt; 
			 *			'						&apos; 
			 *			"						&quot; 
			 *			&						&amp; 
			 *			%						&#37; 
			 */

			string sReturn = string.Empty;

			try
			{
				for (int i = 0; i < sWork.Length; i++)
				{
					string cCurrent = sWork.Substring(i, 1);
					switch (cCurrent)
					{
						case ">":	// Greater than
							sReturn += "&gt;";
							break;
						case "<":	// Less than
							sReturn += "&lt;";
							break;
						case "'":	// Apostrophe (single quote) 
							sReturn += "&apos;";
							break;
						case "\"":	// Quotation mark (double quote)
							sReturn += "&quot;";
							break;
						case "&":	// Ampersand
							sReturn += "&amp;";
							break;
						case "%":	// Percent
							sReturn += "&#37;";
							break;
						default:
							sReturn += cCurrent;
							break;
					}
				}
			}
			catch
			{
				sReturn = sWork;
			}

			return sReturn;
		}


		public static int FindString(string source, string find, bool bPositionAfter)
		{
			int nPos = System.Globalization.CultureInfo.CurrentCulture.CompareInfo.IndexOf(
					source, find, System.Globalization.CompareOptions.IgnoreCase);

			if (bPositionAfter && (nPos >= 0))
				nPos += find.Length;

			return nPos;
		}


		public static int FindString(string source, string find)
		{
			return FindString(source, find, false);
		}
	}
}
