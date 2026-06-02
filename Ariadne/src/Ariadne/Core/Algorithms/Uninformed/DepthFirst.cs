using System;
using System.Collections.Generic;

using Ariadne.Core.Structures;

namespace Ariadne.Core.Algorithms.Uninformed
{
    internal class DepthFirst : Algorithm
    {
        public DepthFirst() : base() { }

        public override void Search(Graph graph)
        {
            Vertex? entry = graph.GetVertex(NodeType.Entry);
            Vertex? exit = graph.GetVertex(NodeType.Exit);
            if (entry is null || exit is null)
            {
                Console.WriteLine("[INFO]: Entry OR Exit is null!");

                return;
            }

            Stack<Vertex> stack = new Stack<Vertex>();
            HashSet<Vertex> visited = new HashSet<Vertex>();

            visited.Add(entry!);
            stack.Push(entry!);
            while(stack.Count > 0)
            {
                Vertex current = stack.Pop();
                if (current.Id == exit!.Id)
                {
                    Console.WriteLine("[INFO]: Path has been found!");

                    return;
                }

                List<Edge> edges = graph.GetList(current);
                foreach (Edge e in edges)
                {
                    if (!visited.Contains(e.To!))
                    {
                        visited.Add(e.To!);
                        stack.Push(e.To!);
                    }
                }
            }

            Console.WriteLine("[WARNING]: No path has been found!");
        }
    }
}