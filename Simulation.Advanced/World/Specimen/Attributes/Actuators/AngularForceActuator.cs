namespace Simulation.World.Specimen.Attributes.Actuators
{
    internal class AngularForceActuator : SpecimenActuatorBase
    {
        public AngularForceActuator(ISpecimenInternal specimen) : base(specimen)
        {
        }

        public override void Update()
        {
            Specimen.ApplyAngularForce(Activation);
        }
    }
}
