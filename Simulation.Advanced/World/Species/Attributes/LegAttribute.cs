using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulation.World.Species.Attributes.Actuators;
using Simulation.World.Species.Attributes.Sensors;

namespace Simulation.World.Species.Attributes
{
    internal class LegAttribute : SpecieAttributeBase
    {
        public LegAttribute(ISpecieInternal specie) : base(specie)
        {
        }

        public override IEnumerable<ISpecieActuatorInternal> Actuators
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override IEnumerable<ISpecieSensorInternal> Sensors
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override double Weight
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
