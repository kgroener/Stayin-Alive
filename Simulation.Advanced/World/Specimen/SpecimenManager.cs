using Simulation.Interface.Specimens;
using Simulation.Models;
using System.Collections.Generic;
using System.Composition;

namespace Simulation.World.Specimens
{
    public class SpecimensManager
    {
        [ImportMany]
        public IEnumerable<ISpecimentFactory> Specimens { get; set; }

        public SpecimensManager()
        {
            CompositionContainer.Resolve(this);
        }
    }
}
