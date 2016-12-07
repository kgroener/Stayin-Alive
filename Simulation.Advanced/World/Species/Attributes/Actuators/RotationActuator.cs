using Simulation.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.World.Species.Attributes.Actuators
{
    internal class RotationActuator : SpecieActuatorBase
    {
        private readonly IRotateable _rotateable;

        public RotationActuator(ISpecieInternal specie, IRotateable rotateable) : base(specie)
        {
            _rotateable = rotateable;
        }

        public override void Update()
        {
            _rotateable.RotationRadians = Activation * Math.PI; 
        }
    }
}
