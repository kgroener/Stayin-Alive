using Simulation.Interface.Models;
using Simulation.World.Specimen;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace Simulation.World.Spawners
{
    internal class FoodPallet : IUpdateableWorldObject
    {
        private const int MAX_RESTORATION_POINTS = 10;
        private TimeSpan _timeAlive;

        private double _restorationPoints;

        public FoodPallet(Vector2 position)
        {
            Position = position;
            _timeAlive = TimeSpan.FromTicks(0);
            _restorationPoints = MAX_RESTORATION_POINTS;
        }

        public RgbColor Color
        {
            get
            {
                return _restorationPoints > 0 ? new RgbColor(0, 255, 0) : new RgbColor(255, 0, 0);
            }
        }

        public bool MarkedForRemoval { get; set; }

        public IEnumerable<Vector2> PolygonPoints
        {
            get
            {
                return new[] { new Vector2(-2, 2), new Vector2(2, 2), new Vector2(2, -2), new Vector2(-2, -2) };
            }
        }

        public Vector2 Position { get; }

        public double RotationRadians => 0;

        public void OnCollision(IWorldObject collidedObject)
        {
            if (MarkedForRemoval)
            {
                return;
            }

            var specimen = collidedObject as ISpecimenInternal;
            if (specimen != null)
            {
                specimen.Heal(_restorationPoints);
                MarkedForRemoval = true;
            }
        }

        public void Update(TimeSpan lastUpdateDuration)
        {
            _timeAlive += lastUpdateDuration;

            var totalSecondsAlive = _timeAlive.TotalSeconds;
            if (totalSecondsAlive >= 10 && totalSecondsAlive <= 30)
            {
                double factor = (20 - totalSecondsAlive) / 10;
                _restorationPoints = MAX_RESTORATION_POINTS * factor;
            }

            if (_timeAlive.TotalSeconds >= 40)
            {
                MarkedForRemoval = true;
            }
        }
    }
}

