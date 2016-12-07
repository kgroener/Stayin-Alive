using Simulation.Interface.Models;

namespace Simulation.World.Species.Attributes.Actuators
{
    internal abstract class SpecieActuatorBase : ISpecieActuatorInternal
    {
        private MinusOneToOneRange _activation;
        private readonly ISpecieInternal _specie;

        protected MinusOneToOneRange Activation => _activation;

        public SpecieActuatorBase(ISpecieInternal specie)
        {
            _specie = specie;
        }

        public ISpecieInternal Specie => _specie;

        public void SetActivation(MinusOneToOneRange value)
        {
            _activation = value;
        }

        public abstract void Update();
    }
}
