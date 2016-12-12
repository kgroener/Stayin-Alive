using System.Collections.Generic;

namespace Simulation.Interface.Specimen
{
    public interface ISpecimenAttribute
    {
        IEnumerable<ISpecimenActuator> Actuators { get; }
        IEnumerable<ISpecimenSensor> Sensors { get; }

    }
}
