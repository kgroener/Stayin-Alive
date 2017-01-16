using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.World
{
    public abstract class ObjectSpawner : ISpawner
    {
        public ObjectSpawner(SimulationWorld world)
        {

        }

        public void Update(TimeSpan lastUpdateDuration)
        {
            throw new NotImplementedException();
        }
    }
}
