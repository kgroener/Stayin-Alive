using System;
using System.Composition;

namespace Simulation.Interface.Specimen
{
    public class ExportSpecimenFactoryAttribute : ExportAttribute
    {
        public ExportSpecimenFactoryAttribute() : base(typeof(ISpecimenFactory))
        {
        }
    }
}
