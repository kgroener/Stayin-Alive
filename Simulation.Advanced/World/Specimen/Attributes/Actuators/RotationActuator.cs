using Simulation.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.World.Specimens.Attributes.Actuators
{
    internal class RotationActuator : SpecimenActuatorBase
    {
        private readonly IRotateable _rotateable;

        public RotationActuator(ISpecimenInternal specimen, IRotateable rotateable) : base(specimen)
        {
            _rotateable = rotateable;
        }

        public override void Update()
        {
            _rotateable.RotationRadians = Activation * Math.PI; 
        }
    }
}
