using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadthFirstTraversal
{
    public class Node
    {
        public string Station { get; set; }
        public LinkedList<Node> Descendants { get; set; }

        public Node(string station)
        {
            Station = station;
            Descendants = new LinkedList<Node>();
        }
    }
}
