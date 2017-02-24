namespace AStar.Interfaces
{
    public interface IAStarNode
    {
        IAStarNodeConnection[] Connections { get; }
    }
}
