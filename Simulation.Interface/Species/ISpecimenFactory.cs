using System.Collections.Generic;

namespace Simulation.Interface.Specimens
{
    public interface ISpecimentFactory
    {
        IEnumerable<ISpecimen> CreateGeneration(int maxAmount);
    }
}
