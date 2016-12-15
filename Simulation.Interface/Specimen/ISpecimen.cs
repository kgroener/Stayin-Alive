using Simulation.Interface.Specimen.Attributes;
using System.Collections.Generic;
using System.Numerics;
using System.Windows.Media;

namespace Simulation.Interface.Specimen
{
    public interface ISpecimen
    {
        void Update();

        IEnumerable<SpecimenAttributeBase> Attributes { get; }

        Color Color { get; }

        IEnumerable<Vector2> PolygonPoints { get; }
    }
}
