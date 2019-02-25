using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraShortestPathAlgorithm
{
    public class Vertex
    {
        public int Index { get; set; }
        public int Value { get; set; }

        public Vertex(int v, int index)
        {
            Value = v;
            Index = index;
        }
    }
}
