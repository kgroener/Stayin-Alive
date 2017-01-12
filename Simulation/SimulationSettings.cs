using Simulation.World;
using Simulation.World.Spawners;
using System.Collections.Generic;

namespace Simulation
{
    public class SimulationSettings
    {
        public int MaximumWorldPopulation { get; set; }

        public WorldBoundary WorldBoundary { get; set; }

        public IEnumerable<IObjectSpawner> Spawners { get; set; }
    }
}
