using Simulation.Contracts;
using Simulation.World.Physics;
using Simulation.Interface.Models;
using System.Collections.Generic;
using System.Linq;

namespace Simulation.World.Species.Attributes.Sensors
{
    internal abstract class RayCastingSensor : SpecieSensorBase, IRotateable
    {
        public RayCastingSensor(ISpecieInternal specie, double initialDirectionRadians) : base(specie)
        {
            RotationRadians = initialDirectionRadians;
        }

        public abstract double RangePixels { get; }

        public double RotationRadians { get; set; }

        public sealed override void Update()
        {
            Line ray = new Line()
            {
                Start = Specie.Position,
                End = Specie.Position.Translate(RotationRadians, RangePixels)
            };

            List<IWorldObject> rayCastResults = new List<IWorldObject>();

            foreach (var obj in SimulationWorld.Objects.Where(o => o != Specie))
            {
                var points = obj.PolygonPoints.ToArray();
                for (int i = 0; i < points.Length; i++)
                {
                    Line edge;
                    if (i == 0)
                    {
                        edge = new Line()
                        {
                            Start = points.Last(),
                            End = points[i]
                        };
                    }
                    else
                    {
                        edge = new Line()
                        {
                            Start = points[i - 1],
                            End = points[i]
                        };
                    }

                    if (CollisionDetector.AreColliding(ray, edge))
                    {
                        rayCastResults.Add(obj);
                        break;
                    }
                }
            }

            HandleRayCastResult(rayCastResults);
        }

        protected IWorldObject GetNearestCollision(IEnumerable<IWorldObject> collisions)
        {
            var nearest = collisions.First();
            var nearestDistance = (Specie.Position - nearest.Position).Length();
            foreach (var obj in collisions.Skip(1))
            {
                var distance = (Specie.Position - obj.Position).Length();
                if (distance < nearestDistance)
                {
                    nearest = obj;
                    nearestDistance = distance;
                }
            }

            return nearest;
        }

        protected abstract void HandleRayCastResult(IEnumerable<IWorldObject> collisions);
    }
}
