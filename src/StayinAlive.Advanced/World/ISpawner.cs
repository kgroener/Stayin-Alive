using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.World
{
    interface ISpawner
    {
        void Update(TimeSpan lastUpdateDuration);
    }
}
