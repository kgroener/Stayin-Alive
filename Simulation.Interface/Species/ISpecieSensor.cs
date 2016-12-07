
using Simulation.Interface.Models;

namespace Simulation.Interface.Species
{
    public interface ISpecieSensor
    {
        MinusOneToOneRange GetSensorValue();
    }
}
