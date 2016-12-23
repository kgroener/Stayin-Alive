using Simulation.Interface.Logging;
using Simulation.Interface.Specimen;
using System.Collections.Generic;

namespace Simulation.Examples
{
    public class ExampleSpecimenFactory : ISpecimenFactory
    {
        private ILogger _logger;

        public ExampleSpecimenFactory(ILogger logger)
        {
            _logger = logger;
        }

        public IEnumerable<ISpecimen> CreateFirstGeneration(int maxAmount)
        {
            for (int i = 0; i < maxAmount; i++)
            {
                yield return new ExampleSpecimen(_logger);
            }
        }

        public IEnumerable<ISpecimen> Evolve(int maxAmount, IReadOnlyDictionary<ISpecimen, double> fitnessResults)
        {
            for (int i = 0; i < maxAmount; i++)
            {
                yield return new ExampleSpecimen(_logger);
            }
        }
    }
}
