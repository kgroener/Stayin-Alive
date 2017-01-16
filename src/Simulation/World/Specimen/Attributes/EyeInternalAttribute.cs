using Simulation.Interface.Specimen.Attributes;
using Simulation.World.Specimen.Attributes.Actuators;
using Simulation.World.Specimen.Attributes.Sensors;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Simulation.World.Specimen.Attributes
{
    internal class EyeInternalAttribute : SpecimenInternalAttributeBase<EyeAttribute>
    {
        private readonly ColorSensor _colorSensor;
        private readonly ISpecimenInternalSensor[] _sensors;

        public EyeInternalAttribute(ISpecimenInternal specimen, EyeAttribute attribute) : base(specimen, attribute)
        {
            _colorSensor = new ColorSensor(Specimen, attribute.RotationOffsetRadians, 500);
            _sensors = new ISpecimenInternalSensor[]
                {
                    _colorSensor,
                };
        }

        public override IEnumerable<ISpecimenInternalActuator> Actuators => Enumerable.Empty<ISpecimenInternalActuator>();
        public override IEnumerable<ISpecimenInternalSensor> Sensors => _sensors;

        public override double Weight => 0.1;

        protected override void GetAttributeActuatorValues(EyeAttribute attribute)
        {

        }

        protected override void SetAttributeSensorValues(EyeAttribute attribute)
        {
            attribute.DetectedColor = _colorSensor.DetectedColor;
            attribute.DetectionDistance = _colorSensor.DetectionDistance;
        }
    }
}
