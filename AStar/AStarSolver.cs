using AStar.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace AStar
{
    public abstract class AStarSolver//<T> where T : IAStarNode
    {
        private PriorityQueue<AStarWorkingNode> _open;
        private HashSet <AStarWorkingNode> _closed;

        public abstract float Heuristic(IAStarNode a, IAStarNode b);

        private AStarWorkingNode CreateWorkingNode(IAStarNode self, IAStarNode goal, AStarWorkingNode parent, float gScore)
        {
            return new AStarWorkingNode(self)
            {
                GScore = gScore,
                HScore = Heuristic(self, goal),
                Parent = parent,
            };
        }

        public AStarResult Solve(IAStarNode start, IAStarNode end)
        {
            Reset();
            
            // Step 1 - Add The Starting Node To The Open List
            _open.Enqueue(CreateWorkingNode(start, end, null, 0));

            AStarWorkingNode endNode = null;
            while (_open.Count > 0)
            {
                // Step 2:
                // Take The Best Node From The Open List
                AStarWorkingNode currentNode = _open.Dequeue();

                // Step 3:
                // Add All Connections To The Open List 
                foreach (IAStarNodeConnection connection in currentNode.Self.Connections)
                {
                    var candidateNode = CreateWorkingNode(connection.Node, end, currentNode, currentNode.GScore + connection.Cost);

                    // but only if have havn't been previously closed
                    if (!_closed.Contains(candidateNode) && !_open.Contains(candidateNode))
                    {
                        _open.Enqueue(candidateNode);
                    }
                    // If it has been previously closed; check to see if this is better
                    else if (_closed.Contains(candidateNode))
                    {
                        AStarWorkingNode closedNode = _closed.FirstOrDefault(x => x.Self == candidateNode.Self);
                        if (candidateNode.FScore < closedNode.FScore)
                        {
                            closedNode.Parent = candidateNode.Parent;
                            closedNode.GScore = candidateNode.GScore;
                        }
                    }
                }
                // then close the current node
                _closed.Add(currentNode);

                // Step 3b 
                // If We Are At The End, Exit Search Earily
                if (currentNode.Self == end)
                {
                    endNode = currentNode;
                    break;
                }
            }

            // Step 4
            // Ready The Result Object Check For Path Success
            // If We Didnt Succeed; Find The Best Candidate For The End Point
            AStarResult result = new AStarResult();
            result.IsSuccess = endNode != null;
            if (!result.IsSuccess)
            {
                endNode = _closed
                    .OrderBy(x => x.HScore)
                    .FirstOrDefault();
            }

            // Step 5:
            // Compile The Path
            LinkedList<IAStarNode> resultPath = new LinkedList<IAStarNode>();
            while (endNode.Parent != null)
            {
                resultPath.AddFirst(endNode.Self);
                endNode = endNode.Parent;
            }
            resultPath.AddFirst(endNode.Self);
            result.Result = resultPath;

            return result;
        }

        private void Reset()
        {
            _open = new PriorityQueue<AStarWorkingNode>();
            _closed = new HashSet<AStarWorkingNode>();
        }
    }
}
