using Simulation.Interface.Species;

namespace Simulation.World.Species.Attributes.Actuators
{
    interface ISpecieActuatorInternal : ISpecieActuator
    {
        ISpecieInternal Specie { get; }

        void Update();
    }
}
