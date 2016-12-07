using Simulation.World.Species.Attributes;
using System;
using System.Collections.Generic;

namespace Simulation.World.Species
{
    internal interface ISpecieInternal : IWorldObject
    {
        void ApplyForce(double force);
        void ApplyAngularForce(double force);

        double Weight { get; }
        double MaxSpeed { get; }
        double MaxAngularSpeed { get; }

        double ActualSpeed { get; }
        double ActualAngularSpeed { get; }

        IEnumerable<ISpecieAttributeInternal> Attributes { get; }

        void Update(TimeSpan lastUpdateDuration);
    }
}
