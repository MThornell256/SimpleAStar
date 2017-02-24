using AStar.Interfaces;

namespace AStar
{
    public class AStarNodeConnection : IAStarNodeConnection
    {

        public AStarNodeConnection(IAStarNode node, float cost = 1.0f)
        {
            Node = node;
            Cost = cost;
        }

        public float Cost { get; set; }
        public IAStarNode Node { get; set; }
    }
}
