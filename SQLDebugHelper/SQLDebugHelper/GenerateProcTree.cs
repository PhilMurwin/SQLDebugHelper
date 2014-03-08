using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SQLDebugHelper
{
	public class GenerateProcTree
	{
		private string RegExMatches = string.Empty;
		private string m_ProfileName = string.Empty;

		private int m_MaxSameNestedProc = 2;
		string nodeTemplate = "<node id=\"{0}\"/>";

		private HashSet<string> m_MasterNodeList = new HashSet<string>();

		public string GenerateProcTreeChart(string procName, string profileName)
		{
			m_ProfileName = profileName;
			
			RegExMatches = DBObjects.RegExMatchList(profileName);

			SimpleTreeNode<string> parentProc = new SimpleTreeNode<string>(procName);

			FindChildren(parentProc);			

			StringBuilder graph = new StringBuilder();

			foreach (var node in m_MasterNodeList)
			{
				graph.Append(string.Format(nodeTemplate, node));
			}

			graph.Append(BuildGraphML(parentProc));

			//Add surrounding root nodes for graph
			graph.Insert(0, "<graphml><graph id=\"" + parentProc.Value + "\" edgedefault=\"undirected\" >");
			graph.Append("</graph></graphml>");

			return graph.ToString();
		}

		private string BuildGraphViz(SimpleTreeNode<string> treeNode)
		{
			StringBuilder graph = new StringBuilder();

			foreach(var node in treeNode.Children)
			{
				graph.Append(treeNode.Value + "->" + node.Value + ";");

				if (node.Children.Count > 0)
				{
					graph.Append(BuildGraphViz(node));
				}
			}

			return graph.ToString();
		}

		private string BuildGraphML(SimpleTreeNode<string> treeNode)
		{
			string edgeTemplate = "<edge id=\"0\" source=\"{0}\" target=\"{1}\" />";

			StringBuilder graph = new StringBuilder();

			foreach (var node in treeNode.Children)
			{
				graph.Append(string.Format(edgeTemplate, treeNode.Value, node.Value));

				if (node.Children.Count > 0)
				{
					graph.Append(BuildGraphML(node));
				}
			}

			return graph.ToString();
		}

		private void FindChildren(SimpleTreeNode<string> parent)
		{
			string parentProc = parent.Value;
			
			m_MasterNodeList.Add(parentProc);

            string procBody = DBObjects.GetSQLText(parentProc);
			
			List<string> childProcs = GenProcListv3(procBody, parentProc);

			foreach (var procName in childProcs)
			{
				SimpleTreeNode<string> childProc = new SimpleTreeNode<string>();
				childProc.Value = procName;

				parent.Children.Add(childProc);

				if (CheckForDuplicates(childProc, procName) < m_MaxSameNestedProc)
				{
					FindChildren(childProc);
				}
			}

			//Be nice and sleep for a 10th of a second so the user can still do stuff.
			//Thread.Sleep(100);
		}

		private static int CheckForDuplicates(SimpleTreeNode<string> proc, string procName)
		{
			int procCount = 0;

			if (proc.Value == procName)
			{
				procCount++;
			}

			if (proc.Parent != null)
			{
				procCount += CheckForDuplicates(proc.Parent, procName);
			}

			return procCount;
		}

		private List<string> GenProcListv3(string input, string procName)
		{
			List<string> procsNFunctions = new List<string>();

			string beginProcCall = "((exec\\s+\\[?)|(dbo.))";

			//Find all procs contained in the input
			MatchCollection procMatches = Regex.Matches(input, beginProcCall + "(" + RegExMatches + ")\\b", RegexOptions.IgnoreCase);

			foreach (Match procMatch in procMatches)
			{
				string proc = Regex.Replace(procMatch.Value, beginProcCall, "", RegexOptions.IgnoreCase);

				if (!procsNFunctions.Contains(proc) && !proc.ToLower().EndsWith(procName.ToLower()))
				{
					procsNFunctions.Add(proc);
				}
			}

			procsNFunctions.Sort();

			return procsNFunctions;
		}

        //private string GetSQLText(string procName)
        //{
        //    StringBuilder procBody = new StringBuilder();

        //    DBConnection DB = new DBConnection();
        //    DB.SetDB(m_ProfileName);

        //    try
        //    {
        //        string sql = string.Format("sp_helptext {0}", procName);

        //        DB.CallSQL(sql, true);

        //        while (DB.AnotherSQLRecord())
        //        {
        //            procBody.Append(DB.GetSQLData(1));
        //        }

        //        DB.CloseDB();
        //    }
        //    catch (Exception err)
        //    {
        //        Logger.WriteMessage(Logger.MessageType.Error, "Error retreiving proc body: " + err.Message);
        //    }
        //    finally
        //    {
        //        DB.CloseDB();
        //    }

        //    return procBody.ToString();
        //}
	}
}
