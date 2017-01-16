using StayinAlive.Interface.Models;
using StayinAlive.Interface.Specimen.Attributes;
using System.Collections.Generic;
using System.Numerics;

namespace StayinAlive.Interface.Specimen
{
    public interface ISpecimen
    {
        void Update();

        IEnumerable<SpecimenAttributeBase> Attributes { get; }

        RgbColor Color { get; }

        IEnumerable<Vector2> PolygonPoints { get; }
    }
}
