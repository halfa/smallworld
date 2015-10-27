using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld.Core
{
    public interface Tile
    {
        bool isWalkable(Unit unit);
        int countPoints(Unit unit);
    }
}
