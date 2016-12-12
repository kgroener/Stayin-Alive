using Simulation.Interface.Specimen;

namespace Simulation.World.Specimen.Attributes.Actuators
{
    interface ISpecimenActuatorInternal : ISpecimenActuator
    {
        ISpecimenInternal Specimen { get; }

        void Update();
    }
}
