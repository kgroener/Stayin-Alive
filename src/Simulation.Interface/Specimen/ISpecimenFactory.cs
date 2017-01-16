using System.Collections.Generic;

namespace Simulation.Interface.Specimen
{
    public interface ISpecimenFactory
    {
        IEnumerable<ISpecimen> CreateFirstGeneration(int maxAmount);

        IEnumerable<ISpecimen> Evolve(int maxAmount, IReadOnlyDictionary<ISpecimen, double> fitnessResults);
    }
}
