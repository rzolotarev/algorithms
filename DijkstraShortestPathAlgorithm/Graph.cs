using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraShortestPathAlgorithm
{
    public class Graph
    {
        private List<MapTableRaw> mapTable;
        private LinkedList<Vertex>[] adjList;
        private List<int> visited;
        private Queue<int> queue = new Queue<int>();

        public Graph()
        {
            InitGraph();
        }

        private void InitGraph()
        {
            adjList = new LinkedList<Vertex>[5];

            var first = new LinkedList<Vertex>();
            first.AddLast(new Vertex(6, 1));
            first.AddLast(new Vertex(1, 3));

            var second = new LinkedList<Vertex>();
            second.AddLast(new Vertex(6, 0));
            second.AddLast(new Vertex(2, 3));
            second.AddLast(new Vertex(5, 2));

            var three = new LinkedList<Vertex>();
            three.AddLast(new Vertex(5, 1));
            three.AddLast(new Vertex(5, 4));

            var fourth = new LinkedList<Vertex>();
            fourth.AddLast(new Vertex(1, 0));
            fourth.AddLast(new Vertex(1, 4));
            fourth.AddLast(new Vertex(2, 1));


            var fifth = new LinkedList<Vertex>();
            fifth.AddLast(new Vertex(1, 3));
            fifth.AddLast(new Vertex(2, 1));
            fifth.AddLast(new Vertex(5, 2));

            adjList[0] = new LinkedList<Vertex>(first);
            adjList[1] = new LinkedList<Vertex>(second);
            adjList[2] = new LinkedList<Vertex>(three);
            adjList[3] = new LinkedList<Vertex>(fourth);
            adjList[4] = new LinkedList<Vertex>(fifth);
        }

        private void InitMapTable(int startPoint)
        {
            mapTable = new List<MapTableRaw>();
            foreach (var vertex in Enumerable.Range(0, adjList.Length))
            {
                var currentRaw = new MapTableRaw() { CurrentVertex = vertex, ShortestPath = Int32.MaxValue, PrecedingValue = -1 };
                if (vertex == startPoint)
                    currentRaw.ShortestPath = 0;

                mapTable.Add(currentRaw);
            }
        }

        public void BuildMapTable(int startPoint)
        {
            visited = new List<int>();
            InitMapTable(startPoint);
            queue.Enqueue(startPoint);
            
            while(queue.Count > 0)
            {
                var currentVertex = queue.Dequeue();
                
                foreach (var adjVertex in adjList[currentVertex])
                {
                    if (VertexAlreadyVisited(adjVertex.Index))
                        continue;

                    if (!NewPathShorter(currentVertex, adjVertex))
                        continue;
                    
                    mapTable[adjVertex.Index].ShortestPath = adjVertex.Value + mapTable[currentVertex].ShortestPath;
                    mapTable[adjVertex.Index].PrecedingValue = currentVertex;  
                }

                visited.Add(currentVertex);
                
                if (TryToGetUnvisitedVertex(out int result))
                    queue.Enqueue(result);
            }
        }

        private bool NewPathShorter(int consideredVertex, Vertex adjacentVertex)
        {
            return adjacentVertex.Value + mapTable[consideredVertex].ShortestPath < mapTable[adjacentVertex.Index].ShortestPath;
        }

        private bool VertexAlreadyVisited(int currentVertex)
        {
            return visited.Contains(currentVertex);
        }

        private bool TryToGetUnvisitedVertex(out int result)
        {
            result = -1;

            var orderedByLength = mapTable.OrderBy(r => r.ShortestPath);

            foreach(var closedVertex in orderedByLength)
            {
                if (visited.Contains(closedVertex.CurrentVertex))
                    continue;

                result = closedVertex.CurrentVertex;
                return true;
            }

            return false;
        }

        public void GetShortestPathTo(int startPoint,int destinationPoint)
        {
            
            var path = new Stack<int>();
            BuildMapTable(startPoint);
            var currentPoint = destinationPoint;
           
            while (currentPoint != startPoint)
            {
                path.Push(currentPoint);
               
                currentPoint = mapTable[currentPoint].PrecedingValue;

                if (currentPoint == -1)
                {
                    Console.WriteLine("Sorry there is no path for this input parameters");
                    return;
                }
            }

            Console.Write("Path: " + startPoint);
            while (path.Count > 0)
                Console.Write(" -> " + path.Pop());
            Console.WriteLine();
            Console.WriteLine($"Length: {mapTable[destinationPoint].ShortestPath}");
        }
    }
}
