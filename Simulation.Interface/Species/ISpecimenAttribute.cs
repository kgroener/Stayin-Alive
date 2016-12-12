using System.Collections.Generic;

namespace Simulation.Interface.Specimens
{
    public interface ISpecimenAttribute
    {
        IEnumerable<ISpecimenActuator> Actuators { get; }
        IEnumerable<ISpecimenSensor> Sensors { get; }

    }
}
