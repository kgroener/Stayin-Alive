using System.Collections.Generic;

namespace Simulation.Interface.Species
{
    public interface ISpecieFactory
    {

        IEnumerable<ISpecie> CreateGeneration(int size);

        ISpecie Create();
    }
}
