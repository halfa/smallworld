using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld.Core
{
    /// <summary>
    /// This enum contains keywords for all the different tile types.
    /// </summary>
    [Serializable]
    public enum TileType
    {
        Forest = 0,
        Mountain = 1,
        Plain = 2,
        Water = 3
    }
}