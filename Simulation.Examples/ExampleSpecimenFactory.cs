using Simulation.Interface;
using Simulation.Interface.Specimen;
using System.Collections.Generic;

namespace Simulation.Examples
{
    public class ExampleSpecimenFactory : ISpecimenFactory
    {
        private ILogger _logger;

        public ExampleSpecimenFactory(ILogger simulationLogger)
        {
            _logger = simulationLogger;
        }

        public IEnumerable<ISpecimen> CreateFirstGeneration(int maxAmount)
        {
            for (int i = 0; i < maxAmount; i++)
            {
                yield return new ExampleSpecimen(_logger);
            }
        }
    }
}
