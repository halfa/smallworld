using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld.Core
{
    public interface ITile
    {
        bool isWalkable(SmallWorld.Core.AUnit unit);
        int countPoints(SmallWorld.Core.AUnit unit);
    }
}
