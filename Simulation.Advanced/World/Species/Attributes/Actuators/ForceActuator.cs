using Simulation.Models;

namespace Simulation.World.Species.Attributes.Actuators
{
    internal class ForceActuator : SpecieActuatorBase
    {
        public ForceActuator(ISpecieInternal specie) : base(specie)
        {
        }

        public override void Update()
        {
            Specie.ApplyForce(Activation);
        }
    }
}
