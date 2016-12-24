using Simulation.Interface;
using Simulation.Interface.Logging;
using Simulation.Interface.Specimen;
using System.Composition;

namespace Simulation.Examples
{
    [Export(typeof(ISimulationMetadata))]
    public class ExampleSimulationMetadata : ISimulationMetadata
    {
        public string SpecieName => "ExampleSpecie";

        public ISpecimenFactory CreateSpecimenFactory(ILogger logger)
        {
            return new ExampleSpecimenFactory(logger);
        }
    }
}
