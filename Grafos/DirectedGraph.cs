using System.Collections.Generic;


namespace Grafos
{
    public class DirectedGraph:AbstractGraphs<DirectedGraph>
    {
        public int Number { get; set; }
        public List<int> LinkedNumbers { get; set; }


        public override bool RemainingNodesExist(List<DirectedGraph> list, DirectedGraph node)
        {
            throw new System.NotImplementedException();
        }
    }



}
