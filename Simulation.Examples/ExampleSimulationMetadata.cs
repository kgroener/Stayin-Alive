using Simulation.Interface;
using Simulation.Interface.Specimen;

namespace Simulation.Examples
{
    public class ExampleSimulationMetadata : ISimulationMetadata
    {
        public string SpecieName => "ExampleSpecie";

        public ISpecimenFactory CreateSpeciminFactory(ILogger simulationLogger)
        {
            return new ExampleSpecimenFactory(simulationLogger);
        }
    }
}
