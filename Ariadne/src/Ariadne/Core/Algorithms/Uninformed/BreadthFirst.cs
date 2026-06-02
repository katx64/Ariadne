using System;
using System.Collections.Generic;

using Ariadne.Core.Structures;

namespace Ariadne.Core.Algorithms.Uninformed
{
    internal class BreadthFirst : Algorithm
    {
        public BreadthFirst() : base() { }

        public override void Search(Graph graph)
        {
            Vertex? entry = graph.GetVertex(NodeType.Entry);
            Vertex? exit = graph.GetVertex(NodeType.Exit);
            if (entry is null || exit is null)
            {
                Console.WriteLine("[INFO]: Entry OR Exit is null!");

                return;
            }

            Queue<Vertex> queue = new Queue<Vertex>();
            HashSet<Vertex> visited = new HashSet<Vertex>();

            visited.Add(entry!);
            queue.Enqueue(entry!);
            while(queue.Count > 0)
            {
                Vertex current = queue.Dequeue();
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
                        queue.Enqueue(e.To!);
                    }
                }
            }
            
            Console.WriteLine("[WARNING]: No path has been found!");
        }
    }
}