using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadthFirstTraversal
{
    public class GraphBuilder
    {
        private Node RootNode { get; set; }
        private Node LastNode { get; set; }

        public GraphBuilder(Node node)
        {
            RootNode = node;
            LastNode = RootNode;
        }

        public Node GetRootNode() => RootNode;

        public void AddWithoutShifting(Node currentNode)
        {
            Add(currentNode);
        }

        public void AddWithShifting(Node currentNode)
        {
            Add(currentNode);
            LastNode = currentNode;
        }

        private void Add(Node currentNode)
        {
            if (LastNode == null)
                throw new InvalidOperationException("there is no any node in the graph ");


            LastNode.Descendants.AddLast(currentNode);
        }
    }
}
