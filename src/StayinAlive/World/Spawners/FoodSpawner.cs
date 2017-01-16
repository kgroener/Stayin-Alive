using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace StayinAlive.World.Spawners
{
    public sealed class FoodSpawner : IObjectSpawner
    {
        private const int MAXIMUM_FOOD_IN_WORLD = 100;

        public IEnumerable<IWorldObject> GetNewObjectsToSpawn(ISimulationWorld world)
        {
            var amountOfFoodInWorld = world.Objects.OfType<FoodPallet>().Count();

            for (int i = amountOfFoodInWorld; i < MAXIMUM_FOOD_IN_WORLD; i++)
            {
                yield return new FoodPallet(SpawnPositionGenerator.CreateRandomWorldPosition(world, 10));
            }
        }
    }
}
