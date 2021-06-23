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

        public string GenerateProcTreeChart( string procName, string serverProfile, string dbName )
		{
            m_ProfileName = serverProfile;
			
            RegExMatches = DBObjects.RegExMatchList( serverProfile, dbName );

            var parentProc = new SimpleTreeNode<string>(procName);

            FindChildProcedures(parentProc);

            var graph = new StringBuilder();

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

        private void FindChildProcedures(SimpleTreeNode<string> parent)
		{
            var parentProc = parent.Value;
			
			m_MasterNodeList.Add(parentProc);

            var procBody = DBObjects.GetSQLText(parentProc);
			
            var childProcs = GenProcListv3(procBody, parentProc);

			foreach (var procName in childProcs)
			{
				SimpleTreeNode<string> childProc = new SimpleTreeNode<string>();
				childProc.Value = procName;

				parent.Children.Add(childProc);

				if (CheckForDuplicates(childProc, procName) < m_MaxSameNestedProc)
				{
                    FindChildProcedures(childProc);
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
            var procsNFunctions = new List<string>();

            var beginProcCall = "((exec)\\s+((\\[?dbo\\]?.)|(\\[?ff\\]?.))?)";

			//Find all procs contained in the input
            var procMatches = Regex.Matches(input, beginProcCall + "\\s*(" + RegExMatches + ")\\b", RegexOptions.IgnoreCase);

			foreach (Match procMatch in procMatches)
			{
				string proc = Regex.Replace(procMatch.Value, beginProcCall, "", RegexOptions.IgnoreCase);
                proc = proc.Replace( "[", "" ).Replace( "]", "" );

				if (!procsNFunctions.Contains(proc) && !proc.ToLower().EndsWith(procName.ToLower()))
				{
					procsNFunctions.Add(proc);
				}
			}

			procsNFunctions.Sort();

			return procsNFunctions;
		}
	}
}
