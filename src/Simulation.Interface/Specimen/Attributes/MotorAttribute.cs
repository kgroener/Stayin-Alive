using Simulation.Interface.Models;

namespace Simulation.Interface.Specimen.Attributes
{
    public class MotorAttribute : SpecimenAttributeBase
    {
        public MinusOneToOneRange Steering { get; set; }
        public MinusOneToOneRange Throttle { get; set; }

        internal override object CreateInternal<TParam>(ISpecimenAttributeFactory factory, TParam parameter)
        {
            return factory.CreateSpecific(this, parameter);
        }
    }
}
