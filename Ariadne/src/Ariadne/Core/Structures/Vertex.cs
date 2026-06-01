namespace Ariadne.Core.Structures
{
    // Info: Entry -> Starting point.
    // Info: Exit  -> Target point.
    // Info: Open  -> Passage or path.
    // Info: Close -> Blocked or wall.
    internal enum NodeType
    {
        Entry = 'S', Exit = 'E', Open = ' ', Close = '#'
    }

    internal class Vertex
    {
        public uint Id { get; private set; } = 0;
        public NodeType? Type { get; set; } = null;

        public Vertex(uint id, NodeType type)
        {
            Id = id;
            Type = type;
        }

        public bool Equals(Vertex? other)
        {
            return other != null && other!.Id == Id; 
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Vertex);
        }

        public override int GetHashCode()
        {
            return (int)Id;
        }
    }
}