using System;
using System.Numerics;

namespace Simulation.World.Physics
{
    public struct Line
    {
        public Vector2 Start { get; set; }
        public Vector2 End { get; set; }

        /// <summary>
        /// In radians
        /// </summary>
        public double Angle
        {
            get
            {
                return Math.Atan2(End.Y - Start.Y, End.X - Start.X);
            }
        }
    }
}
