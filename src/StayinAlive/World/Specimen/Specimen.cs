using StayinAlive.Calculations;
using StayinAlive.Interface.Models;
using StayinAlive.Interface.Specimen;
using StayinAlive.World.Physics;
using StayinAlive.World.Specimen.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace StayinAlive.World.Specimen
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
        public double MaxAngularSpeed => 100 / Weight;
        public double MaxSpeed => 300 / Weight;
        public Vector2 Position { get; private set; }
        public double RotationRadians { get; private set; }
        public double ActualSpeed => _speed;
        public double ActualAngularSpeed => _angularSpeed;

        public double HealthPoints => _healthPoints;

        public bool MarkedForRemoval { get; set; }

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
            _healthPoints -= 1 * lastUpdateDuration.TotalSeconds;

            if (_healthPoints <= 0)
            {
                MarkedForRemoval = true;
                return;
            }

            foreach (var attribute in _attributes)
            {
                attribute.UpdateSensors(_world);
            }

            _specimenImplementation.Update();

            _totalAngularForce -= 0; //_totalAngularForce * lastUpdateDuration.TotalSeconds/10;
            _totalForce -= _totalForce * lastUpdateDuration.TotalSeconds/100;

            foreach (var attribute in _attributes)
            {
                attribute.UpdateActuators(_world);
            }

            _totalForce *= lastUpdateDuration.TotalSeconds;
            _totalAngularForce *= lastUpdateDuration.TotalSeconds;

            if (Math.Abs(_totalForce) < 0.0001)
            {
                _totalForce = 0;
            }

            if (Math.Abs(_totalAngularForce) < 0.0001)
            {
                _totalAngularForce = 0;
            }

            _speed += (_totalForce * 10) / Weight;
            _speed = _speed.Clip(-MaxSpeed, MaxSpeed);

            _angularSpeed = (_totalAngularForce * 100) / Weight;
            _angularSpeed = _angularSpeed.Clip(-MaxAngularSpeed, MaxAngularSpeed);

            RotationRadians += _angularSpeed * lastUpdateDuration.TotalSeconds;
            Position = Position.Move(RotationRadians, _speed, lastUpdateDuration);
        }

        public void OnCollision(IWorldObject collidedObject)
        {

        }
    }
}
