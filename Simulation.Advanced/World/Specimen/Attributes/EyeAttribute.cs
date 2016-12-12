using Simulation.World.Specimens.Attributes.Actuators;
using Simulation.World.Specimens.Attributes.Sensors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;

namespace Simulation.World.Specimens.Attributes
{
    internal class EyeAttribute : SpecimenAttributeBase
    {
        private readonly ISpecimenSensorInternal[] _sensors;

        public EyeAttribute(ISpecimenInternal specimen, double rotationOffset) : base(specimen)
        {
            _sensors = new ISpecimenSensorInternal[]
                {
                    new ColorSensor(Specimen, rotationOffset, 100, Color.FromScRgb(0, 1, 0, 0)),
                    new ColorSensor(Specimen, rotationOffset, 100, Color.FromScRgb(0, 0, 1, 0)),
                    new ColorSensor(Specimen, rotationOffset, 100, Color.FromScRgb(0, 0, 0, 1)),
                };
        }

        public override IEnumerable<ISpecimenActuatorInternal> Actuators => Enumerable.Empty<ISpecimenActuatorInternal>();
        public override IEnumerable<ISpecimenSensorInternal> Sensors => _sensors;

        public override double Weight => 0.1;

    }
}
