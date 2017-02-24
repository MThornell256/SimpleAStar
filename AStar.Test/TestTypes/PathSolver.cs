using AStar.Interfaces;

namespace AStar.Test
{
    /*
     * Implementation Of Our Path Solver
     * Allows Us To Set The Heuristic Definition.
     * For this case (and probably most cases) we will use Euler Distance Equation
     */
    public class PathSolver : AStarSolver
    {
        public override float Heuristic(IAStarNode a, IAStarNode b)
        {
            return Vector3.Distence((PathNode)a, (PathNode)b);
        }
    }
}
