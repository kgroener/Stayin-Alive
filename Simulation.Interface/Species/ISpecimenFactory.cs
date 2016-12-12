using System.Collections.Generic;

namespace Simulation.Interface.Specimens
{
    public interface ISpecimenFactory
    {
        IEnumerable<ISpecimen> CreateGeneration(int maxAmount);
    }
}
