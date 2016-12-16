using Simulation.Interface.Specimen;

namespace Simulation.Interface
{
    public interface ISimulationMetadata
    {
        string SpecieName { get; }
        ISpecimenFactory CreateSpeciminFactory(ILogger simulationLogger);
    }
}
