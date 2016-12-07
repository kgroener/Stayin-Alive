using Simulation.Interface.Models;

namespace Simulation.Interface.Species
{
    public interface ISpecieActuator
    {
        void SetActivation(MinusOneToOneRange value);
    }
}
