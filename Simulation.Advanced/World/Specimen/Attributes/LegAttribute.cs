using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulation.World.Specimens.Attributes.Actuators;
using Simulation.World.Specimens.Attributes.Sensors;

namespace Simulation.World.Specimens.Attributes
{
    internal class LegAttribute : SpecimenAttributeBase
    {
        public LegAttribute(ISpecimenInternal specimen) : base(specimen)
        {
        }

        public override IEnumerable<ISpecimenActuatorInternal> Actuators
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override IEnumerable<ISpecimenSensorInternal> Sensors
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
