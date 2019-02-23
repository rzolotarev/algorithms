using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadthFirstTraversal.Visitors
{
    public class BFTraverse
    {
        private Queue<Node> queue = new Queue<Node>();

        public BFTraverse(Node startNode)
        {
            queue.Enqueue(startNode);
        }

        public void Traverse()
        {
            if (queue.Count == 0)
                return;

            var nextNode =  queue.Dequeue();
            StoreDescendants(nextNode);
            PrintInformation(nextNode);
            Traverse();
        }

        private void StoreDescendants(Node node)
        {
            foreach (var descendant in node.Descendants)
                queue.Enqueue(descendant);
        }

        private void PrintInformation(Node node)
        {
            Console.WriteLine(node.Station);
        }
    }
}
