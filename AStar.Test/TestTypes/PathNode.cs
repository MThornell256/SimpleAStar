using AStar.Interfaces;

namespace AStar.Test
{
    /*
     * A Representation Of A Typical Path Node
     * Inherrates From Our Simple Vector3 Class To Represent A Point In 3d Space
     * 
     */ 
    public class PathNode : Vector3, IAStarNode
    {
        public PathNode()
            : base(0,0,0)
        { }

        public PathNode(float x, float y, float z) 
            : base(x, y, z)
        { }

        // A List Of Connected Nodes
        public IAStarNodeConnection[] Connections { get; set; }
    }
}
