namespace StayinAlive.World.Specimen.Attributes.Sensors
{
    internal abstract class SpecimenSensorBase : ISpecimenInternalSensor
    {
        private readonly ISpecimenInternal _specimen;

        public SpecimenSensorBase(ISpecimenInternal specimen)
        {
            _specimen = specimen;
        }

        public ISpecimenInternal Specimen => _specimen;

        public abstract void Update(SimulationWorld world);
    }
}
