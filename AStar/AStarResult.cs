using AStar.Interfaces;
using System.Collections.Generic;

namespace AStar
{
    /*
     * The output path of the calculation
     */
    public class AStarResult//<T> where T: IAStarNode
    {
        // The Final Cost Of This Path
        public float Cost { get; set; }

        // Did We Reach The Goal Node?
        public bool IsSuccess { get; set; }

        // The Number Of Nodes Traversed
        public int Count { get { return Result.Count; } }

        // The Data
        public LinkedList<IAStarNode> Result { get; set; }
    }
}
