using System;
using System.Numerics;

namespace Simulation.World.Physics
{
    internal static class CollisionDetector
    {
        private static float Cross(this Vector2 a, Vector2 b)
        {
            return a.X * b.Y - b.X * a.Y;
        }


        private static bool IsZero(this float d)
        {
            const double Epsilon = 1e-10;
            return Math.Abs(d) < Epsilon;
        }

        public static Vector2? CalculateLineSegementsIntersectionPoint(Line a, Line b)
        {
            var lineAStart = a.Start;
            var lineAEnd = a.End;

            var lineBStart = b.Start;
            var lineBEnd = b.End;

            var deltaA = lineAEnd - lineAStart;
            var deltaB = lineBEnd - lineBStart;
            var deltaCrossProduct = deltaA.Cross(deltaB);

            if (deltaCrossProduct.IsZero())
            {
                // Lines are parallel, no intersection
                return null;
            }

            float t = (lineBStart - lineAStart).Cross(deltaB) / deltaCrossProduct;

            var u = (lineBStart - lineAStart).Cross(deltaA) / deltaCrossProduct;

            if (!deltaCrossProduct.IsZero() && (0 <= t && t <= 1) && (0 <= u && u <= 1))
            {
                return lineAStart + Vector2.Multiply(t, deltaA);
            }

            return null;
        }

        public static bool AreColliding(Line lineA, Line lineB)
        {
            return CalculateLineSegementsIntersectionPoint(lineA, lineB).HasValue;
        }


    }
}
