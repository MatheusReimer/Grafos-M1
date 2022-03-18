using System.Collections.Generic;

namespace Grafos
{
    public abstract class AbstractGraphs<T>
    {
        public int Number { get; set; }

        public List<int> LinkedNumbers { get; set; }
        public abstract bool RemainingNodesExist(List<T> list, T node);
    }
}