using StayinAlive.Contracts;
using System;

namespace StayinAlive.World.Specimen.Attributes.Actuators
{
    internal class RotationActuator : SpecimenActuatorBase
    {
        private readonly IRotateable _rotateable;

        public RotationActuator(ISpecimenInternal specimen, IRotateable rotateable) : base(specimen)
        {
            _rotateable = rotateable;
        }

        public override void Update(SimulationWorld world)
        {
            _rotateable.RotationRadians = Activation * Math.PI;
        }
    }
}
