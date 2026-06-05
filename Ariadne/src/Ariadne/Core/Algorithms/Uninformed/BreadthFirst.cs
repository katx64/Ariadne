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
            if (!graph.ContainsSourceAndSink())
            {
                Console.WriteLine("[Error]: Graph does not contains source and-or sink!");

                return;
            }

            (Vertex? source, Vertex? sink) = graph.GetSourceAndSink();

            HashSet<Vertex> visited = new HashSet<Vertex>();
            Queue<Vertex> frontier = new Queue<Vertex>();
            
            visited.Add(source!);
            frontier.Enqueue(source!);
            while(frontier.Count > 0)
            {
                Vertex current = frontier.Dequeue();
                if (current.Id == sink!.Id)
                {
                    Console.WriteLine("[INFO]: Path has been found!");

                    return;
                }

                foreach (Edge e in graph.GetEdges(current))
                {
                    if (!visited.Contains(e.To!))
                    {
                        visited.Add(e.To!);
                        frontier.Enqueue(e.To!);
                    }
                }
            }

            Console.WriteLine("[WARNING]: No path has been found!");
        }
    }
}