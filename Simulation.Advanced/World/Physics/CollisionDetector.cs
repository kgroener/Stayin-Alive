using Simulation.Interface.Models;
using Simulation.Models;
using System.Numerics;

namespace Simulation.World.Physics
{
    internal static class CollisionDetector
    {
        private static Vector2? GetLineIntersectionPoint(Line lineA, Line lineB)
        {

            float A1 = lineA.End.Y - lineA.Start.Y;
            float A2 = lineB.End.Y - lineB.Start.Y;

            float B1 = lineA.End.X - lineA.Start.X;
            float B2 = lineB.End.X - lineB.Start.X;

            float delta = A1 * B2 - A2 * B1;
            if (delta == 0)
            {
                // lines are parallel
                return null;
            }

            float C1 = A1 * lineA.Start.X + B1 * lineA.Start.Y;
            float C2 = A2 * lineB.Start.X + B2 * lineB.Start.Y;

            float x = (B2 * C1 - B1 * C2) / delta;
            float y = (A1 * C2 - A2 * C1) / delta;

            return new Vector2(x, y);
        }

        public static Vector2? GetCollisionPoint(Line lineA, Line lineB)
        {
            var intersectionPoint = GetLineIntersectionPoint(lineA, lineB);

            if (intersectionPoint.HasValue
                && intersectionPoint.Value.IsBetween(lineA.Start, lineA.End)
                && intersectionPoint.Value.IsBetween(lineB.Start, lineB.End))
            {
                return intersectionPoint;
            }

            return null;
        }

        public static bool AreColliding(Line lineA, Line lineB)
        {
            return GetCollisionPoint(lineA, lineB).HasValue;
        }


    }
}
