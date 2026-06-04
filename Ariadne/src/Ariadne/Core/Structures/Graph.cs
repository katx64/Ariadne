using System;
using System.Collections.Generic;
using System.Linq;

namespace Ariadne.Core.Structures
{
    internal class Graph
    {
        public Dictionary<Vertex, List<Edge>>? AdjacencyList { get; private set; } = null;

        public Graph()
        {
            Initialize();
        }

        public void AddVertex(Vertex? vertex)
        {
            if (vertex is null)
            {
                Console.WriteLine("[Warning]: Vertex is null! Vertex can not be added!");

                return;    
            }

            AdjacencyList!.Add(vertex, new List<Edge>());
        }

        // Info: Every edge in List<Edge> will have a unique Id, so it doesn't matter.
        public void AddEdge(Edge? edge)
        {
            if (edge is null)
            {
                Console.WriteLine("[Warning]: Edge is null! Edge can not be added!");

                return;
            }

            if (edge.From is null)
            {
                Console.WriteLine("[Warning]: Edge \"From\" Vertex is null! Edge can not be added!");

                return;
            }

            if (!AdjacencyList!.ContainsKey(edge.From))
            {
                Console.WriteLine("[Warning]: Edge \"From\" Vertex can not be found in adjacency list! Edge can not be added!");

                return;
            }

            AdjacencyList![edge.From].Add(edge);
        }

        // Info: Find the Vertex with .Type == type. If not return null.
        public Vertex? GetVertex(NodeType? type)
        {
            if (type is null)
            {
                Console.WriteLine("[Warning]: NodeType is null! Returning null!");

                return null;
            }

            Vertex? vertex = AdjacencyList!.Keys.FirstOrDefault(vertex => vertex.Type == type);
            if (vertex is null)
            {
                Console.WriteLine("[Warning]: Vertex with .Type == type is null! Returning null!");
                
                return null;
            }
 
            return vertex;
        }

        public List<Edge> GetEdgeArray(Vertex? vertex)
        {
            if (vertex is null)
            {
                Console.WriteLine("[Warning]: Vertex is null! Returning empty List<Edge>!");

                return new List<Edge>();
            }

            if (!AdjacencyList!.ContainsKey(vertex))
            {
                Console.WriteLine("[Warning]: Vertex can not be found in adjacency list! Returning empty List<Edge>!");

                return new List<Edge>();
            }

            return AdjacencyList![vertex];
        }

        // Info: Garbage collector takes care of the old adjacency list.
        public void Reset()
        {
            Initialize();
        }

        public void Print()
        {
            foreach (Vertex v in AdjacencyList!.Keys)
            {
                Console.Write($"[Info]: V[{v.Id}, {(v.Type is null ? "null" : (char)v.Type)}]");
                foreach (Edge e in GetEdgeArray(v))
                {
                    Console.Write($"E[{e.Id}, {e.Weight}, {(e.From is null ? "null" : e.From.Id)}, {(e.To is null ? "null" : e.To.Id)}] -> ");
                }
                Console.WriteLine();
            }
        }

        private void Initialize()
        {
            AdjacencyList = new Dictionary<Vertex, List<Edge>>();
        }
    }
}