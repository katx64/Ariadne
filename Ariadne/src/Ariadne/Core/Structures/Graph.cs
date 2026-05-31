using System.Collections.Generic;

namespace Ariadne.Core.Structures
{
    internal class Graph
    {
        public Dictionary<Vertex, List<Edge>>? AdjacencyList { get; private set; } = null;

        public Graph()
        {
            Initialize();
        }

        public void AddVertex(Vertex vertex)
        {
            
        }

        public void AddEdge(Edge edge)
        {
            
        }

        public Vertex GetVertex(Type type)
        {
            
        }

        public List<Edge> GetList(Vertex vertex)
        {
            
        }

        public void Reset()
        {
            Initialize();
        }

        public void Print()
        {
            
        }

        private void Initialize()
        {
            AdjacencyList = new Dictionary<Vertex, List<Edge>>();
        }
    }
}