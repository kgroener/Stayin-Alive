using StayinAlive.World.Specimen;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StayinAlive.World
{
    internal class SimulationWorld : ISimulationWorld
    {
        private List<IWorldObject> _objects;
        private List<ISpecimenInternal> _population;
        private readonly WorldBoundary _boundary;

        public IEnumerable<IWorldObject> Objects => UpdateableObjects;
        public IEnumerable<IUpdateableWorldObject> UpdateableObjects => _population.Concat(_objects.OfType<IUpdateableWorldObject>()).ToArray();

        public IEnumerable<ISpecimenInternal> Population => _population;
        public WorldBoundary Boundary => _boundary;

        public SimulationWorld(WorldBoundary boundary)
        {
            _objects = new List<IWorldObject>();
            _population = new List<Specimen.ISpecimenInternal>();
            _boundary = boundary;
        }

        internal void Populate(IEnumerable<Specimen.Specimen> specimen)
        {
            _population = specimen.ToList<ISpecimenInternal>();
        }

        internal void SpawnObject(IWorldObject obj)
        {
            if (obj is ISpecimenInternal)
            {
                throw new InvalidOperationException("Directly spawnig specimen is prohibited, use populate method instead");
            }

            _objects.Add(obj);
        }

        internal void RemoveMarkedObjects()
        {
            _objects.RemoveAll(o => o.MarkedForRemoval);
            _population.RemoveAll(o => o.MarkedForRemoval);
        }
    }
}
