using BreadthFirstTraversal.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadthFirstTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            var rootNode = new Node("RomanStation");

            var gb = new GraphBuilder(rootNode);
            var firstLine = new Node("AnastasiiaStation");
            firstLine.Descendants.AddLast(new Node("Smart"));
            firstLine.Descendants.AddLast(new Node("Beauty"));
            var secondLine = new Node("StefaniiaStation");
            secondLine.Descendants.AddLast(new Node("Smile"));
            secondLine.Descendants.AddLast(new Node("Joy"));

            gb.AddWithoutShifting(secondLine);
            gb.AddWithoutShifting(firstLine);
           
            var startNode = gb.GetRootNode();

            var bfTraverse = new DFTraverse(startNode);
            bfTraverse.Traverse();
        }
    }
}
