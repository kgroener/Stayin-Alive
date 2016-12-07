using System.Collections.Generic;
using System.Numerics;
using System.Windows.Media;

namespace Simulation.World
{
    interface IWorldObject
    {
        Vector2 Position { get; }
        double RotationRadians { get; }
        IEnumerable<Vector2> PolygonPoints { get; }
        Color Color { get; }
    }
}
