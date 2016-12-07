namespace Simulation.World.Species.Attributes.Actuators
{
    internal class AngularForceActuator : SpecieActuatorBase
    {
        public AngularForceActuator(ISpecieInternal specie) : base(specie)
        {
        }

        public override void Update()
        {
            Specie.ApplyAngularForce(Activation);
        }
    }
}
