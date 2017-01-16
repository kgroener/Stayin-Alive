using NUnit.Framework;
using Simulation.World.Physics;
using System.Numerics;

namespace Simulation.Tests
{
    public class CollisionDetectionTests
    {
        [TestCase(0, 0, 500, 0, 0, -10, 0, 10, ExpectedResult = true)]
        [TestCase(0, 0, 500, 0, 250, -10, 250, 10, ExpectedResult = true)]
        [TestCase(0, 0, 500, 0, 500, -10, 500, 10, ExpectedResult = true)]
        [TestCase(0, 0, 500, 0, 501, -10, 501, 10, ExpectedResult = false)]
        [TestCase(0, 0, 500, 0, -1, -10, -1, 10, ExpectedResult = false)]

        [TestCase(0, -10, 0, 10, 0, 0, 500, 0, ExpectedResult = true)]
        [TestCase(250, -10, 250, 10, 0, 0, 500, 0, ExpectedResult = true)]
        [TestCase(500, -10, 500, 10, 0, 0, 500, 0, ExpectedResult = true)]
        [TestCase(501, -10, 501, 10, 0, 0, 500, 0, ExpectedResult = false)]
        [TestCase(-1, -10, -1, 10, 0, 0, 500, 0, ExpectedResult = false)]

        [TestCase(0, 0, 500, 500, 0, 500, 500, 0, ExpectedResult = true)]
        [TestCase(0, 0, 500, 500, 251, 249, 500, 0, ExpectedResult = false)]
        [TestCase(0, 0, 500, 500, 0, 500, 249, 251, ExpectedResult = false)]

        [TestCase(0, 500, 500, 0, 0, 0, 500, 500, ExpectedResult = true)]
        [TestCase(251, 249, 500, 0, 0, 0, 500, 500, ExpectedResult = false)]
        [TestCase(0, 500, 249, 251, 0, 0, 500, 500, ExpectedResult = false)]

        public bool CollisionDetection_GivenEdgeAndRay_CorrectResult(float rayX1, float rayY1, float rayX2, float rayY2, float edgeX1, float edgeY1, float edgeX2, float edgeY2)
        {
            var ray = new Line() { Start = new Vector2(rayX1, rayY1), End = new Vector2(rayX2, rayY2) };
            var edge = new Line() { Start = new Vector2(edgeX1, edgeY1), End = new Vector2(edgeX2, edgeY2) };

            return CollisionDetector.AreColliding(ray, edge);
        }
    }
}
