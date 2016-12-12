using Simulation.Models;

namespace Simulation.World.Specimen.Attributes.Actuators
{
    internal class ForceActuator : SpecimenActuatorBase
    {
        public ForceActuator(ISpecimenInternal specimen) : base(specimen)
        {
        }

        public override void Update()
        {
            Specimen.ApplyForce(Activation);
        }
    }
}
