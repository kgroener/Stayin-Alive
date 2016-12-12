using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulation.World.Specimen.Attributes.Actuators;
using Simulation.World.Specimen.Attributes.Sensors;

namespace Simulation.World.Specimen.Attributes
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
