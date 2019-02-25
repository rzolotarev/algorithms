using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraShortestPathAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            var gp = new Graph();
            gp.GetShortestPathTo(0, 2);
        }
    }
}
