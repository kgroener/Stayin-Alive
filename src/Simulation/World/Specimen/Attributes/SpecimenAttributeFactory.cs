using Simulation.Interface.Specimen.Attributes;

namespace Simulation.World.Specimen.Attributes
{
    internal class SpecimenAttributeFactory : ISpecimenAttributeFactory
    {
        public ISpecimenInternalAttribute CreateInternalAttribute(SpecimenAttributeBase s, ISpecimenInternal specimen)
        {
            return (this as ISpecimenAttributeFactory).CreateInternal(s, specimen) as ISpecimenInternalAttribute;
        }

        object ISpecimenAttributeFactory.CreateInternal<TParam>(SpecimenAttributeBase attribute, TParam parameter)
        {
            return attribute.CreateInternal(this, parameter);
        }

        object ISpecimenAttributeFactory.CreateSpecific<TParam>(EyeAttribute eyeAttribute, TParam parameter)
        {
            return new EyeInternalAttribute(parameter as ISpecimenInternal, eyeAttribute);
        }

        object ISpecimenAttributeFactory.CreateSpecific<TParam>(MotorAttribute motorAttribute, TParam parameter)
        {
            return new MotorInternalAttribute(parameter as ISpecimenInternal, motorAttribute);
        }
    }
}
