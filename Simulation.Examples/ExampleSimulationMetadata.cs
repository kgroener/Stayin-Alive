using Simulation.Interface;
using Simulation.Interface.Logging;
using Simulation.Interface.Specimen;

namespace Simulation.Examples
{
    public class ExampleSimulationMetadata : ISimulationMetadata
    {
        public string SpecieName => "ExampleSpecie";

        public ISpecimenFactory CreateSpecimenFactory(ILogger logger)
        {
            return new ExampleSpecimenFactory(logger);
        }
    }
}
