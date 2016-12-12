using Simulation.Interface.Models;

namespace Simulation.World.Specimens.Attributes.Sensors
{
    internal abstract class SpecimenSensorBase : ISpecimenSensorInternal
    {
        private MinusOneToOneRange _sensorValue;
        private readonly ISpecimenInternal _specimen;

        public SpecimenSensorBase(ISpecimenInternal specimen)
        {
            _specimen = specimen;
        }

        public ISpecimenInternal Specimen => _specimen;

        public MinusOneToOneRange GetSensorValue()
        {
            return _sensorValue;
        }

        protected void SetSensorValue(MinusOneToOneRange value)
        {
            _sensorValue = value;
        }

        public abstract void Update();
    }
}
