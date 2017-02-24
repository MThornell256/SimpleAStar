using AStar.Interfaces;
using System;

namespace AStar
{

    /*
     * The Node Of The Current Working Calculation Of The Solver
     * 
     */
    public class AStarWorkingNode : IComparable<AStarWorkingNode>// where T: IAStarNode
    {
        public AStarWorkingNode(IAStarNode node)
        {
            Self = node;
        }

        public float FScore { get { return GScore + HScore; } }

        // G: Dist From Start
        // The Total Cost It Takes To Get To This Node
        public float GScore { get; set; }

        // H: Dist To Goal
        // A Huristic Guess Of How Far We Are From The Goal
        public float HScore { get; set; }

        public AStarWorkingNode Parent { get; set; }
        public IAStarNode Self { get; private set; }

        public int CompareTo(AStarWorkingNode other)
        {
            if (FScore > other.FScore)
                return 1;
            else if (FScore < other.FScore)
                return -1;
            else
                return 0;
        }

        public override bool Equals(object obj)
        {
            if (obj is AStarWorkingNode)
            {
                AStarWorkingNode castObject = (AStarWorkingNode)obj;
                return Self.Equals(castObject.Self);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return Self.GetHashCode();
        }
    }
}
