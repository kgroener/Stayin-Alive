using System.Collections.Generic;

namespace StayinAlive.World.Spawners
{
    public interface IObjectSpawner
    {
        IEnumerable<IWorldObject> GetNewObjectsToSpawn(ISimulationWorld world);
    }
}
