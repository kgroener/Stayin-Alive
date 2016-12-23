using System;

namespace Simulation.WPF
{
    internal static class SimulationManager
    {
        private static Lazy<Simulation> _simulation;

        static SimulationManager()
        {
            _simulation = new Lazy<Simulation>(() => new Simulation(new SimulationSettings() { MaximumWorldPopulation = 100 }));
        }

        public static Lazy<Simulation> Simulation => _simulation;

    }
}
