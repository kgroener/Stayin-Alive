using Simulation.Interface.Models;
using Simulation.Interface.Specimen.Attributes;
using System.Collections.Generic;
using System.Numerics;

namespace Simulation.Interface.Specimen
{
    public interface ISpecimen
    {
        void Update();

        IEnumerable<SpecimenAttributeBase> Attributes { get; }

        RgbColor Color { get; }

        IEnumerable<Vector2> PolygonPoints { get; }
    }
}
