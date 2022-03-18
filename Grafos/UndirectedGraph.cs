using System.Collections.Generic;


namespace Grafos
{
    public class UndirectedGraph : AbstractGraphs<UndirectedGraph>, IGraphs
    {


        public UndirectedGraph()
        {
            Number = Number;
            LinkedNumbers = new List<int>();
        }

        public int Number { get; set; }
        public List<int> LinkedNumbers { get; set; }

        public override bool RemainingNodesExist(List<UndirectedGraph> list, UndirectedGraph node)
        {
            int numbersConnected = node.LinkedNumbers.Count;
            if (numbersConnected != list.Count)
            {
                return true;
            }
            return false;
        }
    }
}