using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace StayinAlive.Calculations
{
    internal static class PolygonExtensions
    {
        public static float Area(this IEnumerable<Vector2> polygon)
        {
            return (float)AreaCalculations.CalculatePolygonArea(polygon);
        }

        public static Vector2 CenterOfMass(this IEnumerable<Vector2> polygon)
        {
            float X = 0;
            float Y = 0;

            // Add first index to the end
            var polygonExtended = polygon.Concat(polygon.Take(1)).ToArray();

            for (int i = 0; i < polygon.Count(); i++)
            {
                var factor = polygonExtended[i].X * polygonExtended[i + 1].Y -
                             polygonExtended[i + 1].X * polygonExtended[i].Y;

                X += (polygonExtended[i].X + polygonExtended[i + 1].X) * factor;
                Y += (polygonExtended[i].Y + polygonExtended[i + 1].Y) * factor;
            }

            var polygonArea = polygon.Area();

            X = (X / 6f) / polygonArea;
            Y = (Y / 6f) / polygonArea;

            if (X < 0)
            {
                X = -X;
                Y = -Y;
            }

            return new Vector2(X, Y);
        }

        public static IEnumerable<Vector2> Normalize(this IEnumerable<Vector2> polygon)
        {
            var centerOfMass = polygon.CenterOfMass();

            var centeredPolygon = polygon.Select(p => p - centerOfMass);

            var max = centeredPolygon.Max(p => Math.Max(Math.Abs(p.X), Math.Abs(p.Y)));

            var normalizedPolygon = centeredPolygon.Select(p => p / max);

            return normalizedPolygon.ToArray();
        }
    }
}
