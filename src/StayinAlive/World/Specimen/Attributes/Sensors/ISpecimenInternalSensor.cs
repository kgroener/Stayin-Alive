namespace StayinAlive.World.Specimen.Attributes.Sensors
{
    interface ISpecimenInternalSensor
    {
        ISpecimenInternal Specimen { get; }

        void Update(SimulationWorld world);
    }
}
