using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld.Core
{
    /// <summary>
    /// This class is a template for forest tiles.
    /// </summary>
    [Serializable]
    public class Forest : ATile
    {
        /// <summary>
        /// Default constructor for the Forest class.
        /// </summary>
        public Forest()
        {
        }

        /// <summary>
        /// Provide the TileType related to Forest tiles.
        /// </summary>
        /// <returns></returns>
        public override TileType getType()
        {
            return TileType.Forest;
        }
    }
}
