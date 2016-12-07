using System.Collections.Generic;
using System.Numerics;
using System.Windows.Media;

namespace Simulation.Interface.Species
{
    public interface ISpecie
    {
        void Update();

        IEnumerable<ISpecieAttribute> Attributes { get; }

        Color Color { get; }

        IEnumerable<Vector2> PolygonPoints { get; }
    }
}
