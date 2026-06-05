using System;
using System.Collections.Generic;
using System.Linq;

namespace Ariadne.Core.Structures
{
    internal class Graph
    {
        public Dictionary<Vertex, List<Edge>> AdjacencyList { get; private set; } = new Dictionary<Vertex, List<Edge>>();

        public Graph() { }

        public void AddVertex(Vertex? vertex)
        {
            if (vertex is null)
            {
                Console.WriteLine("[Warning]: Vertex is null! Vertex can not be added!");

                return;    
            }

            AdjacencyList.Add(vertex, new List<Edge>());
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
                Console.WriteLine("[Warning]: Vertex \"From\" of edge is null! Edge can not be added!");

                return;
            }
            
            if (edge.To is null)
            {
                Console.WriteLine("[Warning]: Vertex \"To\" of edge is null! Edge can not be added!");

                return;
            }

            if (!AdjacencyList.ContainsKey(edge.From))
            {
                Console.WriteLine("[Warning]: Vertex \"From\" of edge can not be found in adjacency list! Edge can not be added!");

                return;
            }

            if (!AdjacencyList.ContainsKey(edge.To))
            {
                Console.WriteLine("[Warning]: Vertex \"To\" of edge can not be found in adjacency list! Edge can not be added!");

                return;
            }

            AdjacencyList[edge.From].Add(edge);
        }

        // Info: Find the Vertex with .Type == type. If not return null.
        public Vertex? GetVertex(NodeType type)
        {
            Vertex? vertex = AdjacencyList.Keys.FirstOrDefault(vertex => vertex.Type == type);
            // Info: This is for debugging!
            if (vertex is null)
            {
                Console.WriteLine("[Warning]: Vertex with .Type == type is null! Returning null!");
                
                return null;
            }
 
            return vertex;
        }

        public List<Edge> GetEdges(Vertex? vertex)
        {
            if (vertex is null)
            {
                Console.WriteLine("[Warning]: Vertex is null! Returning empty List<Edge>!");

                return new List<Edge>();
            }

            if (!AdjacencyList.ContainsKey(vertex))
            {
                Console.WriteLine("[Warning]: Vertex can not be found in adjacency list! Returning empty List<Edge>!");

                return new List<Edge>();
            }

            return AdjacencyList[vertex];
        }

        // Info: Get Vertex with .Type == NodeType.Source and .Type == NodeType.Sink!
        public (Vertex? source, Vertex? sink) GetSourceAndSink()
        {
            return (GetVertex(NodeType.Source), GetVertex(NodeType.Sink));
        }

        public bool ContainsSourceAndSink()
        {
            (Vertex? source, Vertex? sink) = GetSourceAndSink();

            return source is not null && sink is not null;
        }

        // Info: Garbage collector takes care of the old adjacency list.
        public void Reset()
        {
            AdjacencyList = new Dictionary<Vertex, List<Edge>>();
        }

        public void Print()
        {
            foreach (Vertex v in AdjacencyList.Keys)
            {
                Console.Write($"[Info]: V[{v.Id}, {(char)v.Type}] :: ");
                foreach (Edge e in GetEdges(v))
                {
                    Console.Write($"E[{e.Id}, {e.Weight}, {e.From!.Id}, {e.To!.Id}] -> ");
                }

                Console.WriteLine();
            }
        }
    }
}