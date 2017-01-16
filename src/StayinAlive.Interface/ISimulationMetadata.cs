using StayinAlive.Interface.Logging;
using StayinAlive.Interface.Specimen;

namespace StayinAlive.Interface
{
    public interface ISimulationMetadata
    {
        string SpecieName { get; }
        ISpecimenFactory CreateSpecimenFactory(ILogger logger);
    }
}
