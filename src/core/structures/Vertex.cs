using System;

namespace Ariadne.Core.Structures
{
    // Info: Other          -> None (General).
    // Info: Source         -> Start.
    // Info: Sink           -> Exit.
    // Info: Accessible     -> Path.
    // Info: Inaccessible   -> Wall.
    internal enum NodeType : byte
    {
        Other           = (byte)'O',
        Source          = (byte)'S',
        Sink            = (byte)'E',
        Accessible      = (byte)' ',
        Inaccessible    = (byte)'#'
    }

    internal sealed class Vertex : IEquatable<Vertex>
    {
        public uint Id { get; init; } = 0;
        public NodeType Type { get; init; }

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