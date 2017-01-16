using StayinAlive.World.Specimen.Attributes.Actuators;
using StayinAlive.World.Specimen.Attributes.Sensors;
using System.Collections.Generic;

namespace StayinAlive.World.Specimen.Attributes
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
