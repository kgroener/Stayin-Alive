using Simulation.Interface.Species;

namespace Simulation.World.Species.Attributes.Sensors
{
    interface ISpecieSensorInternal : ISpecieSensor
    {
        ISpecieInternal Specie { get; }

        void Update();
    }
}
