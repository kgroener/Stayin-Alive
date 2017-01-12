using System;
using System.Numerics;

namespace Simulation.World.Spawners
{
    internal static class SpawnPositionGenerator
    {
        private static Random _random = new Random();

        public static Vector2 CreateRandomWorldPosition(ISimulationWorld world, double margin = 0)
        {
            var deltaX = world.Boundary.BottomRight.X - world.Boundary.TopLeft.X - (2 * margin);
            var deltaY = world.Boundary.BottomRight.Y - world.Boundary.TopLeft.Y - (2 * margin);

            var offsetX = world.Boundary.TopLeft.X + margin;
            var offsetY = world.Boundary.TopLeft.Y + margin;

            var x = offsetX + _random.NextDouble() * deltaX;
            var y = offsetY + _random.NextDouble() * deltaY;

            return new Vector2((float)x, (float)y);
        }
    }
}
