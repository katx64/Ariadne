using System;

using Ariadne.Core.Structures;

namespace Ariadne.Utility.Conversion
{
    internal sealed class Converter
    {
        private static Converter? _Instance = null;

        private Converter() { }

        public static Converter GetInstance()
        {
            if (_Instance is null)
            {
                Console.WriteLine("[Info]: Creating new Converter instance!");

                _Instance = new Converter();
            }

            return _Instance;
        }

        private bool IsTraversable(Vertex vertex)
        {
            return vertex.Type != NodeType.Inaccessible && vertex.Type != NodeType.Other;
        }

        public Vertex[,] ToVertexArray(string[] lines)
        {
            int height = lines.Length;
            if (height == 0)
            {
                Console.WriteLine("[Warning]: Can not convert to vertices! Returning empty vertex array (Vertex[0, 0])!");

                return new Vertex[0, 0];
            }

            int width = lines[0].Length;
            if (width == 0)
            {
                Console.WriteLine("[Warning]: Can not convert to vertices! Returning empty vertex array (Vertex[0, 0])!");

                return new Vertex[0, 0];
            }

            Vertex[,] vertices = new Vertex[height, width];
            for(int h = 0; h < height; h++)
            {
                for(int w = 0; w < width; w++)
                {
                    NodeType type = lines[h][w] switch
                    {
                        (char)NodeType.Accessible   => NodeType.Accessible,
                        (char)NodeType.Inaccessible => NodeType.Inaccessible,
                        (char)NodeType.Other        => NodeType.Other,
                        (char)NodeType.Source       => NodeType.Source,
                        (char)NodeType.Sink         => NodeType.Sink,
                        _                           => NodeType.Other
                    };

                    vertices[h, w] = new Vertex((uint)(h * width + w), type);
                }
            }

            return vertices;
        }
        
        public Graph ToGraph(Vertex[,] vertices)
        {            
            int height = vertices.GetLength(0);
            if (height == 0)
            {
                Console.WriteLine("[Warning]: Can not convert to graph! Returning empty graph!");
            
                return new Graph();
            }

            int width = vertices.GetLength(1);
            if (width == 0)
            {
                Console.WriteLine("[Warning]: Can not convert to graph! Returning empty graph!");

                return new Graph();
            }

            // Info: Add Source, Sink and the Traversable vertices to graph!
            Graph graph = new Graph();
            for (int h = 0; h < height; h++)
            {
                for(int w = 0; w < width; w++)
                {
                    if (!IsTraversable(vertices[h, w]))
                    {
                        continue;
                    }

                    graph.AddVertex(vertices[h, w]);
                }
            }

            // Info: Then we connect the added vertices with edges "Right", "Down", "Left", "Up"!
            for(int h = 0; h < height; h++)
            {
                for(int w = 0; w < width; w++)
                {
                    Vertex vertex = vertices[h, w];

                    if (!IsTraversable(vertex))
                    {
                        // Console.WriteLine("[Warning]: Vertex can not be traversed!");

                        continue;
                    }

                    // Info: Right
                    if (w < width - 1 && IsTraversable(vertices[h, w + 1]))
                    {
                        graph.AddEdge(new Edge((uint)((h * width + w) * 4), 1, vertex, vertices[h, w + 1]));                        
                    }

                    // Info: Down
                    if (h < height - 1 && IsTraversable(vertices[h + 1, w]))
                    {
                        graph.AddEdge(new Edge((uint)((h * width + w) * 4 + 1), 1, vertex, vertices[h + 1, w]));
                    }

                    // Info: Left
                    if (w > 0 &&  IsTraversable(vertices[h, w - 1]))
                    {
                        graph.AddEdge(new Edge((uint)((h * width + w) * 4 + 2), 1, vertex, vertices[h, w - 1]));
                    }

                    // Info: Up
                    if (h > 0 && IsTraversable(vertices[h - 1, w]))
                    {
                        graph.AddEdge(new Edge((uint)((h * width + w) * 4 + 3), 1, vertex, vertices[h - 1, w]));
                    }
                }
            }

            return graph;
        }
    }
}