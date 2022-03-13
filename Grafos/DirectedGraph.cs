using System.Collections.Generic;


namespace Grafos
{
    public class DirectedGraph
    {
        public int Number { get; set; }

        public List<int> LinkedNumbers { get; set; }

        public DirectedGraph() {
            Number = Number;
            LinkedNumbers = new List<int>();
        }


        public bool RemainingNodesExist(List<DirectedGraph> list,DirectedGraph node)
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
