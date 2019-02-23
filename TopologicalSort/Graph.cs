using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopologicalSort
{
    public class Graph
    {
        private LinkedList<Vertex>[] adjList;

        public Graph()
        {
            adjList = new LinkedList<Vertex>[6];
           
            var first = new LinkedList<Vertex>();
            first.AddLast(new Vertex(1));

            var s2 = new LinkedList<Vertex>();
            s2.AddLast(new Vertex(2));

            var three = new LinkedList<Vertex>();
            three.AddLast(new Vertex(3));

            var t = new LinkedList<Vertex>();

            var fourth = new LinkedList<Vertex>();
            fourth.AddLast(new Vertex(1));
            fourth.AddLast(new Vertex(0));

            var fifth = new LinkedList<Vertex>();
            fifth.AddLast(new Vertex(2));
            fifth.AddLast(new Vertex(0));


            adjList[0] = new LinkedList<Vertex>(t);
            adjList[1] = new LinkedList<Vertex>(t);
            adjList[2] = new LinkedList<Vertex>(three);
            adjList[3] = new LinkedList<Vertex>(first);
            adjList[4] = new LinkedList<Vertex>(fourth);
            adjList[5] = new LinkedList<Vertex>(fifth);
            
        }

        public void TopologicalSort()
        {
            var sorted = new Stack<int>();
            var visitedVertices = new List<bool>();

            foreach(var element in Enumerable.Range(0, adjList.Length))
                visitedVertices.Add(false);
            
            foreach(var element in Enumerable.Range(0, adjList.Length))
            {
                if (visitedVertices[element] == true)
                    continue;

                TopologicalSortUtil(element, visitedVertices, sorted);
            }

            while(sorted.Count > 0)
            {
                Console.WriteLine(sorted.Pop());
            }
        }

        public void TopologicalSortUtil(int vertex, List<bool> visited, Stack<int> stack)
        {
            visited[vertex] = true;
            var currentList = adjList[vertex];
           
            foreach(var currentVertex in currentList)
            {
                if (visited[currentVertex.Value] == true)
                    continue;

                TopologicalSortUtil(currentVertex.Value, visited, stack);
            }

            stack.Push(vertex);
        }
    }
}
