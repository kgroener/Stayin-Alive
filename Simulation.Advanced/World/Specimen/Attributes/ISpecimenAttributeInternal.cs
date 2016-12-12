using Simulation.Interface.Specimens;
using Simulation.World.Specimens.Attributes.Actuators;
using Simulation.World.Specimens.Attributes.Sensors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.World.Specimens.Attributes
{
    internal interface ISpecimenAttributeInternal : ISpecimenAttribute
    {
        ISpecimenInternal Specimen { get; }

        double Weight { get; }

        new IEnumerable<ISpecimenActuatorInternal> Actuators { get; }
        new IEnumerable<ISpecimenSensorInternal> Sensors { get; }
    }
}
