using StayinAlive.Interface.Models;

namespace StayinAlive.World.Specimen.Attributes.Actuators
{
    internal abstract class SpecimenActuatorBase : ISpecimenInternalActuator
    {
        private MinusOneToOneRange _activation;
        private readonly ISpecimenInternal _specimen;

        protected MinusOneToOneRange Activation { get; private set; }

        public SpecimenActuatorBase(ISpecimenInternal specimen)
        {
            _specimen = specimen;
        }

        public ISpecimenInternal Specimen => _specimen;

        public abstract void Update(SimulationWorld world);

        public void SetActivationLevel(MinusOneToOneRange activation)
        {
            Activation = activation;
        }
    }
}
