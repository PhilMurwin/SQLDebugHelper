using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using GraphSharp.Controls;
using QuickGraph;
using QuickGraph.Serialization;

namespace Windows.Controls
{
    /// <summary>
    /// Interaction logic for GraphPanel.xaml
    /// </summary>
    public partial class GraphPanel : DockPanel
    {
        private ControlGraph graph;

        public GraphPanel()
        {
            InitializeComponent();
        }

        public void LoadData(string graphml)
        {
            StringReader inputTextReader = new StringReader(graphml);

            var xreader = XmlReader.Create(inputTextReader);
            //create the serializer
            var serializer = new QuickGraph.Serialization.GraphMLDeserializer<ControlVertex, ControlEdge, ControlGraph>();
            graph = new ControlGraph();

            //deserialize the graph
            serializer.Deserialize(xreader, graph,
                                    id => new ControlVertex(id),
                                    (source, target, id) => new ControlEdge(id, source, target));

            DataContext = graph;
        }

        public void Relayout()
        {
            layout.Relayout();
        }
        
    }

#region Helper Classes

    public class ControlVertex
    {
        public string ID
        {
            get;
            private set;
        }

        public ControlVertex(string id)
        {
            ID = id;
        }

        public override string ToString()
        {
            return ID;
        }
    }
    public class ControlEdge : Edge<ControlVertex>
    {
        public string ID
        {
            get;
            private set;
        }

        public ControlEdge(string id, ControlVertex source, ControlVertex target)
            : base(source, target)
        {
            ID = id;
        }
    }
    public class ControlGraph : BidirectionalGraph<ControlVertex, ControlEdge>
    {
        public ControlGraph() { }

        public ControlGraph(bool allowParallelEdges)
            : base(allowParallelEdges) { }

        public ControlGraph(bool allowParallelEdges, int vertexCapacity)
            : base(allowParallelEdges, vertexCapacity) { }
    }
 
	#endregion

    public class MyGraphLayout : GraphLayout<ControlVertex, ControlEdge, BidirectionalGraph<ControlVertex, ControlEdge>> { }

}
