namespace Simulation.Interface.Specimen.Attributes
{
    internal interface ISpecimenAttributeFactory
    {
        object CreateInternal<TParam>(SpecimenAttributeBase attribute, TParam parameter);

        object CreateSpecific<TParam>(MotorAttribute motorAttribute, TParam parameter);
        object CreateSpecific<TParam>(EyeAttribute eyeAttribute, TParam parameter);
    }
}
