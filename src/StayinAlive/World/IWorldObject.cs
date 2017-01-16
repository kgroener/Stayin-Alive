using StayinAlive.Interface.Models;
using System.Collections.Generic;
using System.Numerics;

namespace StayinAlive.World
{
    public interface IWorldObject
    {
        Vector2 Position { get; }
        double RotationRadians { get; }
        IEnumerable<Vector2> PolygonPoints { get; }
        RgbColor Color { get; }
        bool MarkedForRemoval { get; set; }

        void OnCollision(IWorldObject collidedObject);
    }
}
