using Simulation.Interface.Specimen;
using Simulation.Models;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;

namespace Simulation.World.Specimen
{
    internal class SpecimenManager
    {
        [ImportMany]
        public IEnumerable<ISpecimenFactory> SpecimenFactories { get; set; }

        public SpecimenManager()
        {
            CompositionContainer.Resolve(this);
        }

        public int SpecimenCount => SpecimenFactories.Count();

        public void PopulateWorld(SimulationWorld world, int maximumWorldPopulation)
        {
            var allowedGenerationSize = Math.Max(1, maximumWorldPopulation / SpecimenCount);

            var specimenAbstracts = SpecimenFactories.SelectMany((v) => v.CreateGeneration(allowedGenerationSize).Take(allowedGenerationSize));

            var specimen = specimenAbstracts.Select(s => new Specimen(world, s));

            world.Populate(specimen);
        }
    }
}
