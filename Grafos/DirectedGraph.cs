using System.Collections.Generic;


namespace Grafos
{
    public class DirectedGraph : AbstractGraphs<DirectedGraph>
    {

        public DirectedGraph()
        {
            Number = Number;
            LinkedNumbers = new List<int>();
        }

        public override bool RemainingNodesExist(List<DirectedGraph> list, DirectedGraph node)
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