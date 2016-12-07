using Simulation.World.Species.Attributes.Actuators;
using Simulation.World.Species.Attributes.Sensors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;

namespace Simulation.World.Species.Attributes
{
    internal class EyeAttribute : SpecieAttributeBase
    {
        private readonly ISpecieSensorInternal[] _sensors;

        public EyeAttribute(ISpecieInternal specie, double rotationOffset) : base(specie)
        {
            _sensors = new ISpecieSensorInternal[]
                {
                    new ColorSensor(Specie, rotationOffset, 100, Color.FromScRgb(0, 1, 0, 0)),
                    new ColorSensor(Specie, rotationOffset, 100, Color.FromScRgb(0, 0, 1, 0)),
                    new ColorSensor(Specie, rotationOffset, 100, Color.FromScRgb(0, 0, 0, 1)),
                };
        }

        public override IEnumerable<ISpecieActuatorInternal> Actuators => Enumerable.Empty<ISpecieActuatorInternal>();
        public override IEnumerable<ISpecieSensorInternal> Sensors => _sensors;

        public override double Weight => 0.1;

    }
}
