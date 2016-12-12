using Simulation.Interface.Models;

namespace Simulation.Interface.Specimens
{
    public interface ISpecimenActuator
    {
        void SetActivation(MinusOneToOneRange value);
    }
}
