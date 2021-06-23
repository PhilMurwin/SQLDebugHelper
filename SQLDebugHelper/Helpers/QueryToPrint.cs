
namespace SQLDebugHelper
{
	public class QueryToPrint
	{
		public static string QueryToPrintString(string inputQuery)
		{
			string outputPrintString = string.Empty;

			outputPrintString = inputQuery;
			outputPrintString = outputPrintString.Replace(",", "),'') + ''',");
			outputPrintString = outputPrintString.Replace("=", "=''' + isnull(convert(varchar(max),");
			
			//Add final closing parens
			outputPrintString = outputPrintString + "), '') + ''''";
			
			return "declare @printexec varchar(max)\nset @printexec='" + outputPrintString + "\nprint @printexec";
		}
	}
}
