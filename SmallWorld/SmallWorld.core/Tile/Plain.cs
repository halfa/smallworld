using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld.Core
{
    /// <summary>
    /// This class is a template for plain tiles.
    /// </summary>
    [Serializable]
    public class Plain : ATile
    {
        /// <summary>
        /// Default constructor for the Plain class.
        /// </summary>
        public Plain()
        {
        }

        /// <summary>
        /// Provide the TileType related to Plain tiles.
        /// </summary>
        /// <returns></returns>
        public override TileType getType()
        {
            return TileType.Plain;
        }
    }
}
