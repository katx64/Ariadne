namespace Ariadne.Core.Structures
{
    internal sealed class Edge
    {
        public uint Id { get; init; } = 0;
        public int Weight { get; set; } = 1;
        public Vertex From { get; init; }
        public Vertex To { get; init; }

        public Edge(uint id, int weight, Vertex from, Vertex to)
        {
            Id = id;
            Weight = weight;
            From = from;
            To = to;
        }
    }
}