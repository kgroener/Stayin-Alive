namespace StayinAlive.World.Specimen.Attributes.Actuators
{
    internal class AngularForceActuator : SpecimenActuatorBase
    {
        public AngularForceActuator(ISpecimenInternal specimen) : base(specimen)
        {
        }

        public override void Update(SimulationWorld world)
        {
            Specimen.ApplyAngularForce(Activation*10);
        }
    }
}
