using Simulation.Interface.Logging;
using Simulation.Interface.Specimen;

namespace Simulation.Interface
{
    public interface ISimulationMetadata
    {
        string SpecieName { get; }
        ISpecimenFactory CreateSpecimenFactory(ILogger logger);
    }
}
