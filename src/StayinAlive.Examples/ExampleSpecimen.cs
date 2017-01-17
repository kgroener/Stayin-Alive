using StayinAlive.Interface.Logging;
using StayinAlive.Interface.Models;
using StayinAlive.Interface.Specimen;
using StayinAlive.Interface.Specimen.Attributes;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace StayinAlive.Examples
{
    internal class ExampleSpecimen : ISpecimen
    {
        private ILogger _logger;

        private readonly EyeAttribute _eyeAttributeFront;
        private readonly EyeAttribute _eyeAttributeLeft;
        private readonly EyeAttribute _eyeAttributeRight;

        private readonly MotorAttribute _motorAttribute;
        private Random _random;

        public ExampleSpecimen(ILogger logger)
        {
            _logger = logger;

            _eyeAttributeFront = new EyeAttribute(0);
            _eyeAttributeRight = new EyeAttribute(-Math.PI / 4);
            _eyeAttributeLeft = new EyeAttribute(Math.PI / 4);

            _motorAttribute = new MotorAttribute();
            _random = new Random();
        }

        public IEnumerable<SpecimenAttributeBase> Attributes
        {
            get
            {
                return new SpecimenAttributeBase[]
                {
                    _eyeAttributeFront,
                    _eyeAttributeRight,
                    _eyeAttributeLeft,
                    _motorAttribute
                };
            }
        }

        public RgbColor Color => new RgbColor(0, 0, 255);

        public IEnumerable<Vector2> PolygonPoints
        {
            get
            {
                return new Vector2[]
                {
                    new Vector2(0,0),
                    new Vector2(0,5),
                    new Vector2(5,5),
                    new Vector2(5,0),
                };
            }
        }

        public void Update()
        {
            const int COLOR_THRESHOLD = 100;

            if (_eyeAttributeFront.DetectedColor.HasValue
                && _eyeAttributeFront.DetectedColor.Value.R > COLOR_THRESHOLD
                && _eyeAttributeFront.DetectionDistance.Value < 100)
            {
                _motorAttribute.Throttle = -1;
            }
            else if (_eyeAttributeFront.DetectionDistance.HasValue)
            {
                if (_eyeAttributeFront.DetectedColor.Value.G > COLOR_THRESHOLD
                    && _eyeAttributeFront.DetectionDistance.Value < 100)
                {
                    _motorAttribute.Steering = 0;
                    _motorAttribute.Throttle = 1;
                    return;
                }
                else
                {
                    _motorAttribute.Steering = 0.25;
                    _motorAttribute.Throttle = -_eyeAttributeFront.DetectionDistance.Value / 500;
                }
            }
            else
            {
                _motorAttribute.Throttle = 1;
            }

            if (_eyeAttributeLeft.DetectedColor.HasValue
                && _eyeAttributeLeft.DetectionDistance.Value < 100)
            {
                if (_eyeAttributeLeft.DetectedColor.Value.R > COLOR_THRESHOLD)
                {
                    _motorAttribute.Steering += -1;
                }
                else if (_eyeAttributeLeft.DetectedColor.Value.G > COLOR_THRESHOLD)
                {
                    _motorAttribute.Steering += 1;
                }
            }

            if (_eyeAttributeRight.DetectedColor.HasValue
                && _eyeAttributeRight.DetectionDistance.Value < 100)
            {
                if (_eyeAttributeRight.DetectedColor.Value.R > COLOR_THRESHOLD)
                {
                    _motorAttribute.Steering += 1;
                }
                else if (_eyeAttributeRight.DetectedColor.Value.G > COLOR_THRESHOLD)
                {
                    _motorAttribute.Steering += -1;
                }
            }

        }
    }
}