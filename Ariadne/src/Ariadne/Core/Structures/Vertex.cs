namespace Ariadne.Core.Structures
{
    // Info: Other          -> None.
    // Info: Source         -> Start.
    // Info: Sink           -> Exit.
    // Info: Accessible     -> Path.
    // Info: Inaccessible   -> Wall.
    internal enum NodeType
    {
        Other = 'O', Source = 'S', Sink = 'E', Accessible = ' ', Inaccessible = '#'
    }

    internal class Vertex
    {
        public uint Id { get; private set; } = 0;
        public NodeType Type { get; set; } = NodeType.Other;

        // Warning: NodeType can be null, but should never be null.
        public Vertex(uint id, NodeType type)
        {
            Id = id;
            Type = type;
        }

        public bool Equals(Vertex? other)
        {
            return other is not null && other.Id == Id; 
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Vertex);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}