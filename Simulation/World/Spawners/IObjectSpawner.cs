using System.Collections.Generic;

namespace Simulation.World.Spawners
{
    public interface IObjectSpawner
    {
        IEnumerable<IWorldObject> GetNewObjectsToSpawn(ISimulationWorld world);
    }
}
