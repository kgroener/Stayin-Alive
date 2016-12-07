using Simulation.Interface.Species;
using Simulation.Models;
using System.Collections.Generic;
using System.Composition;

namespace Simulation.World.Species
{
    public class SpeciesManager
    {
        [ImportMany]
        public IEnumerable<ISpecieFactory> Species { get; set; }

        public SpeciesManager()
        {
            CompositionContainer.Resolve(this);
        }
    }
}
