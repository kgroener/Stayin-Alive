
using Simulation.Interface.Models;

namespace Simulation.Interface.Specimen
{
    public interface ISpecimenSensor
    {
        MinusOneToOneRange GetSensorValue();
    }
}
