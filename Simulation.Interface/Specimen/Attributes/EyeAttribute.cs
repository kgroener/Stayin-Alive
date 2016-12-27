using Simulation.Interface.Models;

namespace Simulation.Interface.Specimen.Attributes
{
    public class EyeAttribute : SpecimenAttributeBase
    {
        public EyeAttribute(double rotationOffset)
        {
            RotationOffsetRadians = rotationOffset;
        }

        public double RotationOffsetRadians { get; }

        public RgbColor? DetectedColor { get; internal set; }
        public double? DetectionDistance { get; internal set; }

        internal override object CreateInternal<TParam>(ISpecimenAttributeFactory factory, TParam parameter)
        {
            return factory.CreateSpecific(this, parameter);
        }
    }
}
