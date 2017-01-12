using Simulation.World;
using Simulation.World.Spawners;
using System;

namespace Simulation.WPF
{
    internal static class SimulationManager
    {
        private static Lazy<Simulation> _simulation;

        static SimulationManager()
        {
            _simulation = new Lazy<Simulation>(() => new Simulation(new SimulationSettings()
            {
                MaximumWorldPopulation = 10,
                WorldBoundary = new WorldBoundary(new System.Numerics.Vector2(500, 500), new System.Numerics.Vector2(1000, 1000)),
                Spawners = new[] { new FoodSpawner() }
            }));
        }

        public static Lazy<Simulation> Simulation => _simulation;

    }
}
