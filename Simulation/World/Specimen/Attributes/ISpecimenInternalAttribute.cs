using Simulation.World.Specimen.Attributes.Actuators;
using Simulation.World.Specimen.Attributes.Sensors;
using System.Collections.Generic;

namespace Simulation.World.Specimen.Attributes
{
    internal interface ISpecimenInternalAttribute
    {
        ISpecimenInternal Specimen { get; }

        double Weight { get; }

        IEnumerable<ISpecimenInternalActuator> Actuators { get; }
        IEnumerable<ISpecimenInternalSensor> Sensors { get; }

        void UpdateSensors(SimulationWorld world);
        void UpdateActuators(SimulationWorld world);
    }
}
