namespace AStar.Interfaces
{
    public interface IAStarNodeConnection
    {
        IAStarNode Node { get; }
        float Cost { get; }
    }
}
