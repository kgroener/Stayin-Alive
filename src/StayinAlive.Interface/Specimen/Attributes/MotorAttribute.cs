using StayinAlive.Interface.Models;

namespace StayinAlive.Interface.Specimen.Attributes
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
