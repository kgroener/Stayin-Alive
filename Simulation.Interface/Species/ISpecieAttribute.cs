using System.Collections.Generic;

namespace Simulation.Interface.Species
{
    public interface ISpecieAttribute
    {
        IEnumerable<ISpecieActuator> Actuators { get; }
        IEnumerable<ISpecieSensor> Sensors { get; }

    }
}
