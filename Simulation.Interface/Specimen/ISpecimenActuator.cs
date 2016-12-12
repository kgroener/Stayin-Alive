using Simulation.Interface.Models;

namespace Simulation.Interface.Specimen
{
    public interface ISpecimenActuator
    {
        void SetActivation(MinusOneToOneRange value);
    }
}
