using StayinAlive.Calculations;
using StayinAlive.Interface.Models;
using StayinAlive.World.Specimen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace StayinAlive.World.Spawners
{
    internal class FoodPallet : IUpdateableWorldObject
    {
        private static Random _random = new Random();
        private const int MAX_RESTORATION_POINTS = 10;
        private TimeSpan _timeAlive;

        private double _restorationPoints;
        private readonly Vector2[] _polygonPoints;

        public FoodPallet(Vector2 position)
        {
            Position = position;
            _timeAlive = TimeSpan.FromTicks(0);
            _restorationPoints = MAX_RESTORATION_POINTS;
            _polygonPoints = new[] {
                    new Vector2(0, 0),
                    new Vector2(1, 0),
                    new Vector2(1, -1),
                    new Vector2(2, -1),
                    new Vector2(2, -2),
                    new Vector2(1, -2),
                    new Vector2(1, -3),
                    new Vector2(0, -3),
                    new Vector2(0, -2),
                    new Vector2(-1, -2),
                    new Vector2(-1, -1),
                    new Vector2(0, -1),
                }.Normalize()
                .Select(p => p * 5)
                .ToArray();
        }

        public RgbColor Color
        {
            get
            {
                return _restorationPoints > 0 ? new RgbColor(50, 128, 50) : new RgbColor(128, 50, 50);
            }
        }

        public bool MarkedForRemoval { get; set; }

        public IEnumerable<Vector2> PolygonPoints
        {
            get
            {

                return _polygonPoints;
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

