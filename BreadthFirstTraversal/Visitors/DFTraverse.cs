using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadthFirstTraversal.Visitors
{
    public class DFTraverse
    {
        private Stack<Node> stack = new Stack<Node>();

        public DFTraverse(Node startNode)
        {
            stack.Push(startNode);
        }

        public void Traverse()
        {
            if (stack.Count == 0)
                return;

            var nextNode = stack.Pop();
            StoreDescendants(nextNode);
            PrintInformation(nextNode);
            Traverse();
        }

        public void StoreDescendants(Node node)
        {
            foreach (var descendant in node.Descendants)
                stack.Push(descendant);
        }

        private void PrintInformation(Node node)
        {
            Console.WriteLine(node.Station);
        }
    }
}
