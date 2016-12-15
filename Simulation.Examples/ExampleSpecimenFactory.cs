using Simulation.Interface.Specimen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Examples
{
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
