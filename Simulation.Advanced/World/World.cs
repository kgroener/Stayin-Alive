using Simulation.World.Specimen;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Simulation.World
{
    internal class SimulationWorld
    {
        private List<IWorldObject> _objects;
        private IEnumerable<ISpecimenInternal> _population;

        public IEnumerable<IWorldObject> Objects => _population.Concat(_objects);

        public IEnumerable<ISpecimenInternal> Population => _population;

        public SimulationWorld()
        {
            _objects = new List<IWorldObject>();
            _population = Enumerable.Empty<ISpecimenInternal>();
        }

        internal void Populate(IEnumerable<Specimen.Specimen> specimen)
        {
            _population = specimen.ToArray();
        }

        internal void SpawnObject(IWorldObject obj)
        {
            if (obj is ISpecimenInternal)
            {
                throw new InvalidOperationException("Directly spawnig specimen is prohibited, use populate method instead");
            }

            _objects.Add(obj);
        }
    }
}
