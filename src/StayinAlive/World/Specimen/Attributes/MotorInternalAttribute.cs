using StayinAlive.Interface.Specimen.Attributes;
using StayinAlive.World.Specimen.Attributes.Actuators;
using StayinAlive.World.Specimen.Attributes.Sensors;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StayinAlive.World.Specimen.Attributes
{
    internal class MotorInternalAttribute : SpecimenInternalAttributeBase<MotorAttribute>
    {
        private readonly ISpecimenInternalActuator[] _actuators;
        private readonly AngularForceActuator _angularForceActuator;
        private readonly ForceActuator _forceActuator;

        public MotorInternalAttribute(ISpecimenInternal specimen, MotorAttribute attribute) : base(specimen, attribute)
        {
            _forceActuator = new ForceActuator(specimen);
            _angularForceActuator = new AngularForceActuator(specimen);

            _actuators = new ISpecimenInternalActuator[]
            {
                _forceActuator,
                _angularForceActuator
            };
        }

        public override IEnumerable<ISpecimenInternalActuator> Actuators => _actuators;

        public override IEnumerable<ISpecimenInternalSensor> Sensors => Enumerable.Empty<ISpecimenInternalSensor>();

        public override double Weight => 10;

        protected override void GetAttributeActuatorValues(MotorAttribute attribute)
        {
            _forceActuator.SetActivationLevel(attribute.Throttle);
            _angularForceActuator.SetActivationLevel(attribute.Steering);
        }

        protected override void SetAttributeSensorValues(MotorAttribute attribute)
        {
            
        }
    }
}
