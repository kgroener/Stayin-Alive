
using Simulation.Interface.Models;

namespace Simulation.Interface.Specimens
{
    public interface ISpecimenSensor
    {
        MinusOneToOneRange GetSensorValue();
    }
}
