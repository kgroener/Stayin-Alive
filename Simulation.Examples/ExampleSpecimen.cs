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
        private readonly EyeAttribute _eyeAttributeFront;
        private readonly EyeAttribute _eyeAttributeLeft;
        private readonly EyeAttribute _eyeAttributeRight;
        private readonly MotorAttribute _motorAttribute;
        private Random _random;

        public ExampleSpecimen()
        {
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

        public Color Color => Colors.Red;

        public IEnumerable<Vector2> PolygonPoints
        {
            get
            {
                return new Vector2[]
                {
                    new Vector2(0,0),
                    new Vector2(0,50),
                    new Vector2(50,50),
                    new Vector2(50,0),
                };
            }
        }

        public void Update()
        {
            if (_eyeAttributeFront.DetectionDistance.HasValue
                && _eyeAttributeFront.DetectionDistance.Value < 100
                )
            {
                _motorAttribute.Throttle = _eyeAttributeFront.DetectionDistance.Value / 100;
            }
            else
            {
                _motorAttribute.Throttle = 1;
            }

            _motorAttribute.Steering = ((500 - _eyeAttributeRight.DetectionDistance.GetValueOrDefault()) / 500 - (500 - _eyeAttributeLeft.DetectionDistance.GetValueOrDefault()) / 500);
        }
    }
}