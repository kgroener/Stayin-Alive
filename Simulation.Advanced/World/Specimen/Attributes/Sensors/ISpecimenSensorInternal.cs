using Simulation.Interface.Specimens;

namespace Simulation.World.Specimens.Attributes.Sensors
{
    interface ISpecimenSensorInternal : ISpecimenSensor
    {
        ISpecimenInternal Specimen { get; }

        void Update();
    }
}
