using NUnit.Framework;
using System.Collections.Generic;

namespace AStar.Test
{
    [TestFixture]
    public class PathTests
    {
        private PathNode[,] CreateNodeGraph(int Width, int Height)
        {
            PathNode[,] nodeGraph = new PathNode[Width,Height];

            // Create Nodes
            for (int x = 0; x < Width; ++x)
            {
                for (int y = 0; y < Height; ++y)
                {
                    nodeGraph[x,y] = new PathNode(x,y,0);
                }
            }

            // Create Connections (4 Directional)
            for (int x = 0; x < Width; ++x)
            {
                for (int y = 0; y < Height; ++y)
                {
                    List<AStarNodeConnection> connectedNodes = new List<AStarNodeConnection>();

                    if (y + 1 < Height)
                        connectedNodes.Add(new AStarNodeConnection(nodeGraph[x, y + 1]));
                    if (y - 1 >= 0)
                        connectedNodes.Add(new AStarNodeConnection(nodeGraph[x, y - 1]));

                    if (x + 1 < Width)
                        connectedNodes.Add(new AStarNodeConnection(nodeGraph[x + 1, y]));
                    if (x - 1 >= 0)
                        connectedNodes.Add(new AStarNodeConnection(nodeGraph[x - 1, y]) );

                    nodeGraph[x, y].Connections = connectedNodes.ToArray();
                }
            }

            return nodeGraph;
        }

        [Test]
        public void ExecutePathSolver()
        {
            PathNode[,] graph = CreateNodeGraph(10, 10);

            PathSolver solver = new PathSolver();
            AStarResult result = solver.Solve(graph[2, 2], graph[8, 8]);

            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual(graph[8, 8], result.Result.Last.Value);
        }

        [Test]
        public void ExecutePathSolver_Unsolvable()
        {
            PathNode[,] graph = CreateNodeGraph(10, 10);

            for (int i = 0; i < 10; ++i)
                graph[5, i].Connections = new Interfaces.IAStarNodeConnection[0];

            PathSolver solver = new PathSolver();
            AStarResult result = solver.Solve(graph[2, 2], graph[8, 8]);

            Assert.AreEqual(false, result.IsSuccess);
            Assert.AreEqual(graph[5, 8], result.Result.Last.Value);
        }

        [Test]
        public void QueueTest()
        {
            PriorityQueue<AStarWorkingNode> q = new PriorityQueue<AStarWorkingNode>();

            AStarWorkingNode node1 = new AStarWorkingNode(new PathNode()) { GScore = 1.0f, HScore = 5.0f};
            AStarWorkingNode node2 = new AStarWorkingNode(new PathNode()) { GScore = 0.2f, HScore = 4.5f };
            AStarWorkingNode node3 = new AStarWorkingNode(new PathNode()) { GScore = 0.5f, HScore = 5.0f };

            q.Enqueue(node1);
            q.Enqueue(node2);
            q.Enqueue(node3);

            AStarWorkingNode node;
            node = q.Dequeue();
            Assert.AreEqual(4.7f, node.FScore);

            node = q.Dequeue();
            Assert.AreEqual(5.5f, node.FScore);

            node = q.Dequeue();
            Assert.AreEqual(6.0f, node.FScore);
        }

        [Test]
        public void WorkingNodeEquallityTest()
        {
            PathNode pNode1 = new PathNode();
            PathNode pNode2 = new PathNode();

            AStarWorkingNode wNode1 = new AStarWorkingNode(pNode1);
            AStarWorkingNode wNode2 = new AStarWorkingNode(pNode1);
                             
            AStarWorkingNode wNode3 = new AStarWorkingNode(pNode2);

            Assert.AreEqual(true, wNode1.Equals(wNode2));
            Assert.AreEqual(false, wNode1.Equals(wNode3));

            // Test Hash Set
            HashSet<AStarWorkingNode> set = new HashSet<AStarWorkingNode>();
            set.Add(wNode1);

            Assert.AreEqual(true, set.Contains(wNode2));
            Assert.AreEqual(false, set.Contains(wNode3));
        }

    }
}

