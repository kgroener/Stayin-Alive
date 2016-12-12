using Simulation.Interface.Specimens;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Windows.Media;

namespace SimulationTest
{
    public class SpecimenTest : ISpecimen
    {
        public IEnumerable<ISpecimenAttribute> Attributes
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Color Color
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerable<Vector2> PolygonPoints
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
