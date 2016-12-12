using System.Collections.Generic;

namespace Simulation.Interface.Specimen
{
    public interface ISpecimenFactory
    {
        IEnumerable<ISpecimen> CreateGeneration(int maxAmount);
    }
}
