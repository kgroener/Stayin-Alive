using Simulation.Interface.Specimen;

namespace Simulation.World.Specimen.Attributes.Sensors
{
    interface ISpecimenSensorInternal : ISpecimenSensor
    {
        ISpecimenInternal Specimen { get; }

        void Update(SimulationWorld world);
    }
}
