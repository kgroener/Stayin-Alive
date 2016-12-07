using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Simulation.Calculations
{
    internal static class AreaCalculations
    {

        public static double CalculatePolygonArea(IEnumerable<Vector2> points)
        {
            var completedPolygon = points.ToList();
            completedPolygon.Add(points.First());

            var area = Math.Abs(completedPolygon.Take(completedPolygon.Count() - 1)
                .Select((p, i) => (completedPolygon[i + 1].X - p.X) * (completedPolygon[i + 1].Y + p.Y))
                .Sum() / 2d);

            return area;
        }

    }
}
