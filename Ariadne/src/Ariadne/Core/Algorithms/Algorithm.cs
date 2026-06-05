using Ariadne.Core.Structures;

namespace Ariadne.Core.Algorithms
{
    internal abstract class Algorithm
    {
        public Algorithm() { }
        
        public abstract void Search(Graph graph);
    }
}