using Simulation.Interface.Models;

namespace Simulation.World.Species.Attributes.Sensors
{
    internal abstract class SpecieSensorBase : ISpecieSensorInternal
    {
        private MinusOneToOneRange _sensorValue;
        private readonly ISpecieInternal _specie;

        public SpecieSensorBase(ISpecieInternal specie)
        {
            _specie = specie;
        }

        public ISpecieInternal Specie => _specie;

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
