using Simulation.Calculations;
using Simulation.Interface.Specimen;
using Simulation.World.Physics;
using Simulation.World.Specimen.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Windows.Media;

namespace Simulation.World.Specimen
{
    internal class Specimen : ISpecimenInternal
    {
        private readonly IEnumerable<ISpecimenAttributeInternal> _attributes;
        private readonly ISpecimen _specimenImplementation;
        private readonly double _weight;
        private double _totalAngularForce;
        private double _totalForce;
        private double _speed;
        private double _angularSpeed;
        private readonly SimulationWorld _world;
        private double _healthPoints;

        public Specimen(SimulationWorld world, ISpecimen specimen)
        {
            _world = world;
            _specimenImplementation = specimen;

            List<ISpecimenAttributeInternal> attributes = new List<ISpecimenAttributeInternal>();
            foreach (var attribute in specimen.Attributes)
            {
                var internalAttribute = attribute as ISpecimenAttributeInternal;
                if (internalAttribute == null)
                {
                    throw new NotSupportedException($"Custom specimen attributes are not supported!");
                }
                attributes.Add(internalAttribute);
            }

            _attributes = attributes;
            _weight = CalculateWeight();
        }

        public IEnumerable<Vector2> PolygonPoints => _specimenImplementation.PolygonPoints;
        public IEnumerable<ISpecimenAttributeInternal> Attributes => _attributes;
        public Color Color => _specimenImplementation.Color;
        public double Weight => _weight;
        public double MaxAngularSpeed => 100 / Weight;
        public double MaxSpeed => 100 / Weight;
        public Vector2 Position { get; private set; }
        public double RotationRadians { get; private set; }
        public double ActualSpeed => _speed;
        public double ActualAngularSpeed => _angularSpeed;

        public double HealthPoints => _healthPoints;

        private double CalculateWeight()
        {
            var shapeWeight = AreaCalculations.CalculatePolygonArea(_specimenImplementation.PolygonPoints);
            var attributeWeight = _attributes.Sum(a => a.Weight);

            return shapeWeight + attributeWeight;
        }

        public void ApplyAngularForce(double force)
        {
            _totalAngularForce += force;
        }

        public void ApplyForce(double force)
        {
            _totalForce += force;
        }

        public void TakeDamage(double damage)
        {
            _healthPoints = (_healthPoints - damage).Clip(0, 100);
        }

        public void Heal(double health)
        {
            _healthPoints = (_healthPoints + health).Clip(0, 100);
        }

        public void Update(TimeSpan lastUpdateDuration)
        {
            foreach (var sensor in _attributes.SelectMany(a => a.Sensors))
            {
                sensor.Update(_world);
            }

            _specimenImplementation.Update();

            _totalAngularForce = 0;
            _totalForce = 0;

            foreach (var actuator in _attributes.SelectMany(a => a.Actuators))
            {
                actuator.Update();
            }

            _speed += (_totalForce * 1000 * lastUpdateDuration.TotalSeconds) / Weight;
            _speed = _speed.Clip(-MaxSpeed, MaxSpeed);

            _angularSpeed += (_totalAngularForce * 1000 * lastUpdateDuration.TotalSeconds) / Weight;
            _angularSpeed = _angularSpeed.Clip(-MaxAngularSpeed, MaxAngularSpeed);

            RotationRadians += _angularSpeed;
            Position = Position.Move(RotationRadians, _speed, lastUpdateDuration);
        }
    }
}
