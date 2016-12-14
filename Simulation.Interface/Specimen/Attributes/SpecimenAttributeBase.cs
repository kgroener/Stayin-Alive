namespace Simulation.Interface.Specimen.Attributes
{
    public abstract class SpecimenAttributeBase : ISpecimenAttribute
    {
        internal abstract object CreateInternal<TParam>(ISpecimenAttributeFactory factory, TParam parameter);
    }
}
