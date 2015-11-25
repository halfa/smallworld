using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld.Core
{
    /// <summary>
    /// This class is an abstract template for in game map tiles.
    /// </summary>
    [Serializable]
    public abstract class ATile
    {
        /// <summary>
        /// Determines the actual type of the current tile.
        /// </summary>
        /// <returns></returns>
        public abstract TileType getType();
    }
}