using System.Collections.Generic;
using System.Numerics;
using System.Windows.Media;

namespace Simulation.Interface.Specimens
{
    public interface ISpecimen
    {
        void Update();

        IEnumerable<ISpecimenAttribute> Attributes { get; }

        Color Color { get; }

        IEnumerable<Vector2> PolygonPoints { get; }
    }
}
