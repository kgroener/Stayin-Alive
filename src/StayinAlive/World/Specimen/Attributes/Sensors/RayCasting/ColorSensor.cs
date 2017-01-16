using StayinAlive.Interface.Models;
using System.Collections.Generic;
using System.Linq;

namespace StayinAlive.World.Specimen.Attributes.Sensors
{
    internal class ColorSensor : RayCastingSensor
    {
        private readonly double _rangePixels;

        public ColorSensor(ISpecimenInternal specimen, double directionRadians, double rangePixels)
            : base(specimen, directionRadians)
        {
            _rangePixels = rangePixels;
        }

        public override double RangePixels => _rangePixels;

        protected override void HandleRayCastResult(IEnumerable<IWorldObject> collisions)
        {
            MinusOneToOneRange sensorValue = 0;
            if (collisions.Any())
            {
                var nearest = GetNearestCollision(collisions);

                DetectedColor = nearest.Color;
                DetectionDistance = (Specimen.Position - nearest.Position).Length();
            }
            else
            {
                DetectedColor = null;
                DetectionDistance = null;
            }


        }

        public RgbColor? DetectedColor { get; private set; }
        public double? DetectionDistance { get; private set; }
    }
}
