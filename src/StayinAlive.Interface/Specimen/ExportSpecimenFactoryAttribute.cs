using System;
using System.Composition;

namespace StayinAlive.Interface.Specimen
{
    public class ExportSpecimenFactoryAttribute : ExportAttribute
    {
        public ExportSpecimenFactoryAttribute() : base(typeof(ISpecimenFactory))
        {
        }
    }
}
