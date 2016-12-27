using Simulation.Calculations;
using Simulation.Interface.Models;
using Simulation.Interface.Specimen;
using Simulation.World.Physics;
using Simulation.World.Specimen.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Simulation.World.Specimen
{
    internal class Specimen : ISpecimenInternal
    {
        private readonly IEnumerable<ISpecimenInternalAttribute> _attributes;
        private readonly ISpecimen _specimenImplementation;
        private readonly double _weight;
        private double _totalAngularForce;
        private double _totalForce;
        private double _speed;
        private double _angularSpeed;
        private readonly SimulationWorld _world;
        private double _healthPoints;

        public Specimen(SimulationWorld world, ISpecimen specimen, Vector2 initialPosition, double initialRotation)
        {
            _world = world;
            _specimenImplementation = specimen;

            _healthPoints = 100;
            Position = initialPosition;
            RotationRadians = initialRotation;

            var specimenAttributeFactory = new SpecimenAttributeFactory();
            _attributes = specimen.Attributes.Select(a => specimenAttributeFactory.CreateInternalAttribute(a, this));
            _weight = CalculateWeight();
        }

        public IEnumerable<Vector2> PolygonPoints => _specimenImplementation.PolygonPoints;
        public IEnumerable<ISpecimenInternalAttribute> Attributes => _attributes;
        public RgbColor Color => _specimenImplementation.Color;
        public double Weight => _weight;
        public double MaxAngularSpeed => 10 / Weight;
        public double MaxSpeed => 10 / Weight;
        public Vector2 Position { get; private set; }
        public double RotationRadians { get; private set; }
        public double ActualSpeed => _speed;
        public double ActualAngularSpeed => _angularSpeed;

        public double HealthPoints => _healthPoints;

        private double CalculateWeight()
        {
            var shapeWeight = AreaCalculations.CalculatePolygonArea(_specimenImplementation.PolygonPoints) / 10;
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
            foreach (var attribute in _attributes)
            {
                attribute.UpdateSensors(_world);
            }

            _specimenImplementation.Update();

            _totalAngularForce /= 100;
            _totalForce /= 4;

            foreach (var attribute in _attributes)
            {
                attribute.UpdateActuators(_world);
            }

            if (Math.Abs(_totalForce) < 0.0001)
            {
                _totalForce = 0;
            }

            if (Math.Abs(_totalAngularForce) < 0.0001)
            {
                _totalAngularForce = 0;
            }

            _speed += (_totalForce * lastUpdateDuration.TotalSeconds) / Weight;
            _speed = _speed.Clip(-MaxSpeed, MaxSpeed);

            _angularSpeed += (_totalAngularForce * lastUpdateDuration.TotalSeconds) / Weight;
            _angularSpeed = _angularSpeed.Clip(-MaxAngularSpeed, MaxAngularSpeed);

            RotationRadians += _angularSpeed;
            Position = Position.Move(RotationRadians, _speed, lastUpdateDuration);
        }
    }
}
