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

        public bool Exists(int numberToSearch, List<DirectedGraph> list)
        {
            foreach(var number in list)
            {
                if (number.Number.Equals(numberToSearch))
                {
                    return true;
                }
          
            }
            return false;
        }
    }



}
