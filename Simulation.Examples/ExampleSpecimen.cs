using Simulation.Interface.Logging;
using Simulation.Interface.Specimen;
using Simulation.Interface.Specimen.Attributes;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Windows.Media;

namespace Simulation.Examples
{
    internal class ExampleSpecimen : ISpecimen
    {
        private readonly EyeAttribute _eyeAttribute;
        private ILogger _logger;
        private readonly MotorAttribute _motorAttribute;
        private Random _random;

        public ExampleSpecimen(ILogger logger)
        {
            _logger = logger;
            _eyeAttribute = new EyeAttribute(0);
            _motorAttribute = new MotorAttribute();
            _random = new Random();
        }

        public IEnumerable<SpecimenAttributeBase> Attributes
        {
            get
            {
                return new SpecimenAttributeBase[]
                {
                    _eyeAttribute,
                    _motorAttribute
                };
            }
        }

        public Color Color => Colors.Red;

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
            if (_eyeAttribute.DetectionDistance.HasValue
                && _eyeAttribute.DetectionDistance.Value < 100)
            {
                if (_motorAttribute.Steering != 0)
                {
                    _motorAttribute.Steering = _random.Next(0, 2) == 0 ? -1 : 1;
                    _motorAttribute.Throttle = 0.2;
                }
            }
            else
            {
                _motorAttribute.Throttle = 1;
                _motorAttribute.Steering = 0;
            }
        }
    }
}