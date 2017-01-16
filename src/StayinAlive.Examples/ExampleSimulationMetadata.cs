using StayinAlive.Interface;
using StayinAlive.Interface.Logging;
using StayinAlive.Interface.Specimen;
using System.Composition;

namespace StayinAlive.Examples
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
