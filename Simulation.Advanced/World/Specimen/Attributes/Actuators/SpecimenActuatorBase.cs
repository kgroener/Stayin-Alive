using Simulation.Interface.Models;

namespace Simulation.World.Specimen.Attributes.Actuators
{
    internal abstract class SpecimenActuatorBase : ISpecimenActuatorInternal
    {
        private MinusOneToOneRange _activation;
        private readonly ISpecimenInternal _specimen;

        protected MinusOneToOneRange Activation => _activation;

        public SpecimenActuatorBase(ISpecimenInternal specimen)
        {
            _specimen = specimen;
        }

        public ISpecimenInternal Specimen => _specimen;

        public void SetActivation(MinusOneToOneRange value)
        {
            _activation = value;
        }

        public abstract void Update();
    }
}
