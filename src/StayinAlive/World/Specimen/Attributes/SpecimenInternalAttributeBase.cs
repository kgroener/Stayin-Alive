using StayinAlive.Interface.Specimen;
using StayinAlive.World.Specimen.Attributes.Actuators;
using StayinAlive.World.Specimen.Attributes.Sensors;
using System.Collections.Generic;

namespace StayinAlive.World.Specimen.Attributes
{
    internal abstract class SpecimenInternalAttributeBase<TAttribute> : ISpecimenInternalAttribute where TAttribute : ISpecimenAttribute
    {
        private readonly ISpecimenInternal _specimen;
        private readonly TAttribute _attribute;

        public SpecimenInternalAttributeBase(ISpecimenInternal specimen, TAttribute attribute)
        {
            _specimen = specimen;
            _attribute = attribute;
        }

        public abstract IEnumerable<ISpecimenInternalActuator> Actuators { get; }
        public abstract IEnumerable<ISpecimenInternalSensor> Sensors { get; }

        public abstract double Weight { get; }

        public ISpecimenInternal Specimen => _specimen;

        protected abstract void SetAttributeSensorValues(TAttribute attribute);
        protected abstract void GetAttributeActuatorValues(TAttribute attribute);

        public void UpdateSensors(SimulationWorld world)
        {
            foreach (var sensor in Sensors)
            {
                sensor.Update(world);
            }

            SetAttributeSensorValues(_attribute);
        }

        public void UpdateActuators(SimulationWorld world)
        {
            GetAttributeActuatorValues(_attribute);

            foreach (var actuator in Actuators)
            {
                actuator.Update(world);
            }
        }
    }
}
