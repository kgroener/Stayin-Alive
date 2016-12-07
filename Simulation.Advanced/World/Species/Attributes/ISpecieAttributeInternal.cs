using Simulation.Interface.Species;
using Simulation.World.Species.Attributes.Actuators;
using Simulation.World.Species.Attributes.Sensors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.World.Species.Attributes
{
    internal interface ISpecieAttributeInternal : ISpecieAttribute
    {
        ISpecieInternal Specie { get; }

        double Weight { get; }

        new IEnumerable<ISpecieActuatorInternal> Actuators { get; }
        new IEnumerable<ISpecieSensorInternal> Sensors { get; }
    }
}
