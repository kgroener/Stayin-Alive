using Simulation.Interface.Models;

namespace Simulation.World.Specimen.Attributes.Actuators
{
    interface ISpecimenInternalActuator
    {
        ISpecimenInternal Specimen { get; }

        void SetActivationLevel(MinusOneToOneRange activation);

        void Update(SimulationWorld world);
    }
}
