using System.Numerics;

namespace StayinAlive.World
{
    public class WorldBoundary
    {
        public WorldBoundary(Vector2 topLeft, Vector2 bottomRight)
        {
            TopLeft = topLeft;
            BottomRight = bottomRight;
        }

        public Vector2 TopLeft { get; }
        public Vector2 BottomRight { get; }
    }
}
