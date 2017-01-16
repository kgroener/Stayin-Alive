using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayinAlive.World
{
    interface IUpdateable
    {
        void Update(TimeSpan lastUpdateDuration);
    }
}
