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

        public void AddVertex(Vertex vertex)
        {
            AdjacencyList!.Add(vertex, new List<Edge>());
        }

        public void AddEdge(Edge edge)
        {
            AdjacencyList![edge.To!].Add(edge);
        }

        public Vertex? GetVertex(NodeType type)
        {
            foreach (Vertex v in AdjacencyList!.Keys)
            {
                if (v.Type == type)
                {
                    return v;
                }
            }

            return null;
        }

        public List<Edge> GetList(Vertex vertex)
        {
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
                Console.Write($"[INFO]: V[{v.Id}, {(char)v.Type!}] :: ");
                foreach (Edge e in GetList(v))
                {
                    Console.Write($"E[{e.Id}, {e.Weight}, {e.From!}, {e.To!}] -> ");
                }
            }
        }

        private void Initialize()
        {
            AdjacencyList = new Dictionary<Vertex, List<Edge>>();
        }
    }
}