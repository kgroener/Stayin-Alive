using System;
using System.Numerics;

namespace Simulation.World.Physics
{
    internal static class VectorExtensions
    {
        public static Vector2 Move(this Vector2 position, double directionRadians, double speed_pps, TimeSpan updateDuration)
        {
            var direction = new Vector2((float)Math.Cos(directionRadians), -(float)Math.Sin(directionRadians));

            return position + Vector2.Multiply(direction, (float)(speed_pps * updateDuration.TotalSeconds));
        }

        public static Vector2 Translate(this Vector2 position, double directionRadians, double length)
        {
            var direction = new Vector2((float)Math.Cos(directionRadians), -(float)Math.Sin(directionRadians));

            return position + Vector2.Multiply(direction, (float)length);
        }

        public static bool IsBetween(this Vector2 targetPoint, Vector2 point1, Vector2 point2)
        {
            double minX = Math.Min(point1.X, point2.X);
            double minY = Math.Min(point1.Y, point2.Y);
            double maxX = Math.Max(point1.X, point2.X);
            double maxY = Math.Max(point1.Y, point2.Y);

            return minX <= targetPoint.X
                && targetPoint.X <= maxX
                && minY <= targetPoint.Y
                && targetPoint.Y <= maxY;
        }
    }
}