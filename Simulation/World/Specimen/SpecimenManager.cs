using Simulation.Interface.Specimen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Simulation.World.Specimen
{
    internal class SpecimenManager
    {
        private Random _random;


        private IEnumerable<ISpecimenFactory> _specimenFactories;

        public SpecimenManager(IEnumerable<ISpecimenFactory> specimenFactories)
        {
            _specimenFactories = specimenFactories;

            _random = new Random();
        }

        public int SpecimenCount => _specimenFactories.Count();

        public void PopulateWorld(SimulationWorld world, int maximumWorldPopulation)
        {
            var allowedGenerationSize = Math.Max(1, maximumWorldPopulation / SpecimenCount);

            var specimenAbstracts = _specimenFactories.SelectMany((v) => v.CreateFirstGeneration(allowedGenerationSize).Take(allowedGenerationSize));

            var specimen = specimenAbstracts.Select(s => new Specimen(world, s, new Vector2(_random.Next(200, 500), _random.Next(200, 500)), _random.NextDouble() * Math.PI * 2));

            world.Populate(specimen);
        }
    }
}
