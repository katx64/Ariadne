namespace Ariadne.Core.Structures
{
    internal class Edge
    {
        public uint Id { get; private set; } = 0;
        public int Weight { get; set; } = 0;
        public Vertex? From { get; set; } = null;
        public Vertex? To { get; set; } = null;

        // Warning: From and To can be null, but should never be null.
        public Edge(uint id, int weight, Vertex? from, Vertex? to)
        {
            Id = id;
            Weight = weight;
            From = from;
            To = to;
        }
    }
}