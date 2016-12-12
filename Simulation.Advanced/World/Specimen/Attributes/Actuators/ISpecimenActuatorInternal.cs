using Simulation.Interface.Specimens;

namespace Simulation.World.Specimens.Attributes.Actuators
{
    interface ISpecimenActuatorInternal : ISpecimenActuator
    {
        ISpecimenInternal Specimen { get; }

        void Update();
    }
}
