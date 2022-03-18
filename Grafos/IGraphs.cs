using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafos
{
    public interface IGraphs
    {
        public int Number { get; set; }

        public List<int> LinkedNumbers { get; set; }
    }
}
