using System.Collections.Generic;

namespace StayinAlive.World
{
    public interface ISimulationWorld
    {
        IEnumerable<IWorldObject> Objects { get; }
        WorldBoundary Boundary { get; }
    }
}