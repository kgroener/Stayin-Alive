using Simulation.Interface.Specimen;
using Simulation.Models;
using System.Collections.Generic;
using System.Composition;

namespace Simulation.World.Specimen
{
    public class SpecimensManager
    {
        [ImportMany]
        public IEnumerable<ISpecimenFactory> Specimen { get; set; }

        public SpecimensManager()
        {
            CompositionContainer.Resolve(this);
        }
    }
}
