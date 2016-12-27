namespace Simulation.Calculations
{
    internal static class NumberExtensions
    {
        public static double Clip(this double value, double min, double max)
        {
            return value > max ? max : value < min ? min : value;
        }
    }
}
