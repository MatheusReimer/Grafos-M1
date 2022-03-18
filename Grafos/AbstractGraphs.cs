using System.Collections.Generic;

namespace Grafos
{
    public abstract class AbstractGraphs<T>
    {
        public abstract bool RemainingNodesExist(List<T> list, T node);
    }
}