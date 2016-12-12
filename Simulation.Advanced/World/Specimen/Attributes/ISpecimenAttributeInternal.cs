using Simulation.Interface.Specimen;
using Simulation.World.Specimen.Attributes.Actuators;
using Simulation.World.Specimen.Attributes.Sensors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.World.Specimen.Attributes
{
    internal interface ISpecimenAttributeInternal : ISpecimenAttribute
    {
        ISpecimenInternal Specimen { get; }

        double Weight { get; }

        new IEnumerable<ISpecimenActuatorInternal> Actuators { get; }
        new IEnumerable<ISpecimenSensorInternal> Sensors { get; }
    }
}
