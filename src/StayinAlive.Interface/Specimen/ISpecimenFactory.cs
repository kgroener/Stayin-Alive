using System.Collections.Generic;

namespace StayinAlive.Interface.Specimen
{
    public interface ISpecimenFactory
    {
        IEnumerable<ISpecimen> CreateFirstGeneration(int maxAmount);

        IEnumerable<ISpecimen> Evolve(int maxAmount, IReadOnlyDictionary<ISpecimen, double> fitnessResults);
    }
}
