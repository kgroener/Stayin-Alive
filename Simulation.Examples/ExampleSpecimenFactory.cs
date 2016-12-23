using Simulation.Interface.Specimen;
using System.Collections.Generic;

namespace Simulation.Examples
{
    [ExportSpecimenFactory]
    public class ExampleSpecimenFactory : ISpecimenFactory
    {
        public IEnumerable<ISpecimen> CreateGeneration(int maxAmount)
        {
            for (int i = 0; i < maxAmount; i++)
            {
                yield return new ExampleSpecimen();
            }
        }
    }
}
