using StayinAlive.World;
using StayinAlive.World.Spawners;
using System.Collections.Generic;

namespace StayinAlive
{
    public class SimulationSettings
    {
        public int MaximumWorldPopulation { get; set; }

        public WorldBoundary WorldBoundary { get; set; }

        public IEnumerable<IObjectSpawner> Spawners { get; set; }
    }
}
