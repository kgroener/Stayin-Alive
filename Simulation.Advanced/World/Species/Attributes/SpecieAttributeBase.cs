using Simulation.Interface.Species;
using Simulation.World.Species.Attributes.Actuators;
using Simulation.World.Species.Attributes.Sensors;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Simulation.World.Species.Attributes
{
    internal abstract class SpecieAttributeBase : ISpecieAttributeInternal
    {
        private readonly ISpecieInternal _specie;

        public SpecieAttributeBase(ISpecieInternal specie)
        {
            _specie = specie;
        }

        IEnumerable<ISpecieActuator> ISpecieAttribute.Actuators => Actuators;
        IEnumerable<ISpecieSensor> ISpecieAttribute.Sensors => Sensors; 

        public abstract IEnumerable<ISpecieActuatorInternal> Actuators { get; }
        public abstract IEnumerable<ISpecieSensorInternal> Sensors { get; }

        public abstract double Weight { get; }

        public ISpecieInternal Specie => _specie;
    }
}
