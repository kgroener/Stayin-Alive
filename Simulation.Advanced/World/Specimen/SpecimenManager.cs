using Simulation.Interface.Specimen;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Simulation.World.Specimen
{
    internal class SpecimenManager
    {
        private IEnumerable<ISpecimenFactory> _specimenFactories;

        public SpecimenManager(IEnumerable<ISpecimenFactory> specimenFactories)
        {
            _specimenFactories = specimenFactories;
        }

        public int SpecimenCount => _specimenFactories.Count();

        public void PopulateWorld(SimulationWorld world, int maximumWorldPopulation)
        {
            var allowedGenerationSize = Math.Max(1, maximumWorldPopulation / SpecimenCount);

            var specimenAbstracts = _specimenFactories.SelectMany((v) => v.CreateFirstGeneration(allowedGenerationSize).Take(allowedGenerationSize));

            var specimen = specimenAbstracts.Select(s => new Specimen(world, s));

            world.Populate(specimen);
        }
    }
}
