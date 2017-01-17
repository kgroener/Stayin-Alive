using System.Numerics;

namespace StayinAlive.Calculations
{
    internal static class NumberExtensions
    {
        public static double Clip(this double value, double min, double max)
        {
            return value > max ? max : value < min ? min : value;
        }

        public static float Clip(this float value, float min, float max)
        {
            return value > max ? max : value < min ? min : value;
        }

        public static Vector2 Clip(this Vector2 value, Vector2 min, Vector2 max)
        {
            return new Vector2(value.X.Clip(min.X, max.X), value.Y.Clip(min.Y, max.Y));
        }
    }
}
