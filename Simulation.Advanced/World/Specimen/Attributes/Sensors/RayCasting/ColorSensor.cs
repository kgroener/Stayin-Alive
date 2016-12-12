using Simulation.Interface.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;

namespace Simulation.World.Specimen.Attributes.Sensors
{
    internal class ColorSensor : RayCastingSensor
    {
        private readonly double _rangePixels;
        private readonly Color _sensitivity;
        private readonly float _totalSensitivity;

        public ColorSensor(ISpecimenInternal specimen, double directionRadians, double rangePixels, Color colorSensitivity) : base(specimen, directionRadians)
        {
            _rangePixels = rangePixels;
            _sensitivity = colorSensitivity;
            _totalSensitivity = _sensitivity.ScR + _sensitivity.ScG + _sensitivity.ScB;
        }

        public override double RangePixels => _rangePixels;

        protected override void HandleRayCastResult(IEnumerable<IWorldObject> collisions)
        {
            MinusOneToOneRange sensorValue = 0;
            if (collisions.Any())
            {
                var nearest = GetNearestCollision(collisions);

                var red = nearest.Color.ScR * _sensitivity.ScR;
                var green = nearest.Color.ScG * _sensitivity.ScG;
                var blue = nearest.Color.ScB * _sensitivity.ScB;

                sensorValue = (red + green + blue) / _totalSensitivity;
            }

            SetSensorValue(sensorValue);
        }


    }
}
