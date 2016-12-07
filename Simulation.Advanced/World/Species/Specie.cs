using Simulation.Calculations;
using Simulation.Interface.Species;
using Simulation.World.Physics;
using Simulation.World.Species.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Windows.Media;

namespace Simulation.World.Species
{
    internal class Specie : ISpecieInternal
    {
        private readonly IEnumerable<ISpecieAttributeInternal> _attributes;
        private readonly ISpecie _specieImplementation;
        private readonly double _weight;
        private double _totalAngularForce;
        private double _totalForce;
        private double _speed;
        private double _angularSpeed;

        public Specie(ISpecie specie)
        {
            _specieImplementation = specie;

            List<ISpecieAttributeInternal> attributes = new List<ISpecieAttributeInternal>();
            foreach (var attribute in specie.Attributes)
            {
                var internalAttribute = attribute as ISpecieAttributeInternal;
                if (internalAttribute == null)
                {
                    throw new NotSupportedException($"Custom specie attributes are not supported!");
                }
                attributes.Add(internalAttribute);
            }
            _attributes = attributes;
            _weight = CalculateWeight();
        }

        public IEnumerable<Vector2> PolygonPoints => _specieImplementation.PolygonPoints;
        public IEnumerable<ISpecieAttributeInternal> Attributes => _attributes;
        public Color Color => _specieImplementation.Color;
        public double Weight => _weight;
        public double MaxAngularSpeed => 100 / Weight;
        public double MaxSpeed => 100 / Weight;
        public Vector2 Position { get; private set; }
        public double RotationRadians { get; private set; }
        public double ActualSpeed => _speed;
        public double ActualAngularSpeed => _angularSpeed;

        private double CalculateWeight()
        {
            var shapeWeight = AreaCalculations.CalculatePolygonArea(_specieImplementation.PolygonPoints);
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

        public void Update(TimeSpan lastUpdateDuration)
        {
            foreach (var sensor in _attributes.SelectMany(a => a.Sensors))
            {
                sensor.Update();
            }

            _specieImplementation.Update();

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
