using System.Collections.Generic;

namespace Simulation.World
{
    public interface ISimulationWorld
    {
        IEnumerable<IWorldObject> Objects { get; }
        WorldBoundary Boundary { get; }
    }
}