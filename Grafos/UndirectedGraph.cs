using System.Collections.Generic;


namespace Grafos
{
    public class UndirectedGraph: AbstractGraphs<UndirectedGraph>
    {
        public int Number { get; set; }

        public List<int> LinkedNumbers { get; set; }

        public UndirectedGraph()
        {
            Number = Number;
            LinkedNumbers = new List<int>();
        }

        public override bool RemainingNodesExist(List<UndirectedGraph> list, UndirectedGraph node)
        {
            throw new System.NotImplementedException();
        }
    }
}
